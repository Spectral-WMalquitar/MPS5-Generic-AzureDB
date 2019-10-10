Imports DevExpress.XtraEditors

Public Class Document
    Private DocumentList As New List(Of Dictionary(Of Integer, String))()
    Private DocumentList1 As New List(Of Dictionary(Of String, SqlClient.SqlParameter))()

    Dim FormName As String = "Crew Documents"
    'Dim LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Dim tabChanged As Boolean = False, PrevTab As String = ""
    Dim type As String = ""
    'Dim FileList As ArrayList
    Dim tblCapacity As New DataTable
    Dim tblCapacityMap As New DataTable
    Dim DataViewCapacity As New DataView

    Dim clsgridflout As New clsGridFlyOut
    Dim stopnaba As Boolean = False

#Region "Documents"

    'initialize Controls
    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        CreateButtons()
        Me.TabControl.SelectedTabPageIndex = 0
        Dim tblCntry As DataTable

        'Travel Document Table
        tblCntry = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC")
        Me.repFKeyDocument.DataSource = DB.CreateTable("SELECT * FROM dbo.DocumentList WHERE FKeyDocGroup='SYSTRAVELDOC' ORDER BY Name") 'ORDER BY Name Added By Calvhin Fixed Image "7-14-2016(1092) Travel Document - Type"
        Me.rtdFKeyCntry.DataSource = tblCntry
        AddUnboundColumn(Me.TravelDocView, TravelDocGrid, "File_Name", "FileName", False)
        AddUnboundColumn(Me.TravelDocImageView, TravelDocGrid, "FileName", "FileName", False)

        'Certificate
        Me.LicCertType.DataSource = DB.CreateTable("SELECT * FROM dbo.DocumentList WHERE FKeyDocGroup='SYSLICCERT' ORDER BY Name ASC")
        'Me.LicCertCapacity.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCapacity ORDER BY Name ASC")
        RefreshCapacity()
        Me.LicCertLimit.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmLimit ORDER BY Name ASC")
        Me.LicCertCntry.DataSource = tblCntry
        AddUnboundColumn(Me.LicCertView, LicCertGrid, "File_Name", "File Name", False)
        AddUnboundColumn(Me.LicCertDocImageView, LicCertGrid, "FileName", "FileName", False)

        'Medical Certificates
        Me.MedCntry.DataSource = tblCntry
        Me.MedType.DataSource = DB.CreateTable("SELECT * FROM dbo.DocumentList WHERE FKeyDocGroup= 'SYSMEDCERT' ORDER BY Name ASC")
        AddUnboundColumn(Me.MedicalView, MedicalGrid, "File_Name", "File Name", False)
        AddUnboundColumn(Me.MedicalImageView, MedicalGrid, "FileName", "File Name", False)

        Me.RepCompDefined.DataSource = DB.CreateTable("SELECT PKey, Name FROM tblAdmDocument WHERE FKeyDocGroup = 'SYSCOMPDEF' ORDER BY Name ASC ")
        AddUnboundColumn(Me.CompanyDefinedView, CompanyDefinedGrid, "File_Name", "File Name", False)
        AddUnboundColumn(Me.CompanyDefinedImageView, CompanyDefinedGrid, "FileName", "File Name", False)
        ''Training Repository
        'Me.repTrainingCourse.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourse ORDER BY Name ASC")
        'Me.repTrainingCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCntry ORDER BY Name ASC")
        'Me.repTrainingCourseStat.DataSource = getCouseStatus()
        'Me.repTrainingCourseType.DataSource = getCourseType()
        'Me.repTrainingCourseInst.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourseInst ORDER BY Name ASC")
        'Me.repTrainingDoc.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCourseDocList")
        'Me.repTrainingLimit.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmLimit ORDER BY Name ASC")
        'Me.repTrainingCapacity.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCapacity ORDER BY Name ASC, SortCode ASC")
        'Me.repCurrency.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmCurr ORDER BY Name ASC")
        'AddUnboundColumn(Me.TrainingSub, TrainingGrid, "FileName", "File Name", False)

        ''Education
        'AddUnboundColumn(Me.EducView, EducGrid, "FileName", "File Name", False)

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
    End Sub

    'load sub
    Private Sub LoadSub()

        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "TravelDoc" 'Travel Documents
                'Me.TravelDocView.Focus()
                CrewSubDocImage("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_TravelDoc WHERE FKeyIDNbr='" & strID & "' ORDER BY DateIssue ASC",
                                "SYSTRAVELDOC", Me.TravelDocGrid, Me.TravelDocView, Me.TravelDocImageView)
            Case "LicCert" 'Certificate
                'Me.LicCertView.Focus()
                'Me.LicCertGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_LicCert WHERE FKeyIDNbr='" & strID & "' ORDER BY DateIssue ASC")
                CrewSubDocImage("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_LicCert WHERE FKeyIDNbr='" & strID & "' ORDER BY DateIssue ASC",
                                "SYSLICCERT", Me.LicCertGrid, Me.LicCertView, Me.LicCertDocImageView)
            Case "Medical" 'Medical
                'Me.MedicalView.Focus()
                'Me.MedicalGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_MedCert WHERE FKeyIDNbr='" & strID & "' ORDER BY Document ASC")
                CrewSubDocImage("SELECT * FROM dbo.frmCrew_MedCert WHERE FKeyIDNbr='" & strID & "' ORDER BY Document ASC",
                       "SYSMEDCERT", Me.MedicalGrid, Me.MedicalView, Me.MedicalImageView)
            Case "CompanyDefined"
                CrewSubDocImage("SELECT *,CAST(0 AS BIT) AS Edited FROM CrewCompanyDefined WHERE FKeyIDNbr = '" & strID & "' ORDER BY Name ASC", "SYSCOMPDEF", Me.CompanyDefinedGrid, Me.CompanyDefinedView, Me.CompanyDefinedImageView)
        End Select

    End Sub

    'Refresh
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        getSelectedView()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Crew Documents - " & strDesc)
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetPrintBiodataVisiblity(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPrintListCaption(Name, "Print Biodata")
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetEditCaption(Name, "Add/Edit")
        'If IsNothing(focusedView) Then AllowDeletion(Name, False)
        If Not bLoaded Then 'Prevent lookup edit to reload data source 
            initControls()
            LoadSub()
            bLoaded = True
            PrevTab = Me.TabControl.SelectedTabPage.Tag
        End If

        If blList.GetID() = "" Then
            'commented out by tony20190712 : adding must be disabled if blList (crew list) does not have any record
            'AddData()
            AllowEditing(Name, False)
            AllowDeletion(Name, False)
        Else
            AllowDeletion(Name, False)
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'Travel Document
            EditSubAllowGrid(Me.TravelDocView, False)
            EditSubAllowGrid(Me.TravelDocImageView, False)
            AllowFilePathBtn(repBtnEditTravelDoc, False)

            'Certificates
            EditSubAllowGrid(Me.LicCertView, False)
            EditSubAllowGrid(Me.LicCertDocImageView, False)
            AllowFilePathBtn(repBtnEditCert, False)
            'Medical Certificate
            EditSubAllowGrid(Me.MedicalView, False)
            EditSubAllowGrid(Me.MedicalImageView, False)
            AllowFilePathBtn(repBtnEditMed, False)

            'Company Defined
            EditSubAllowGrid(Me.CompanyDefinedView, False)
            EditSubAllowGrid(Me.CompanyDefinedImageView, False)
            AllowFilePathBtn(rptBtnCompDefined, False)
            BRECORDUPDATEDs = False
        End If
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        getSelectedView()
        header.Focus()

        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, True)
        Else
            ResetControlOnEdit()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, False)
        End If

        'Travel Document
        EditSubAllowGrid(Me.TravelDocView, isEditdable)
        EditSubAllowGrid(Me.TravelDocImageView, isEditdable)
        AllowFilePathBtn(repBtnEditTravelDoc, isEditdable)

        'Certificates
        EditSubAllowGrid(Me.LicCertView, isEditdable)
        EditSubAllowGrid(Me.LicCertDocImageView, isEditdable)
        AllowFilePathBtn(repBtnEditCert, isEditdable)

        'Medical Certificate
        EditSubAllowGrid(Me.MedicalView, isEditdable)
        EditSubAllowGrid(Me.MedicalImageView, isEditdable)
        AllowFilePathBtn(repBtnEditMed, isEditdable)

        'Company Defined
        EditSubAllowGrid(Me.CompanyDefinedImageView, isEditdable)
        EditSubAllowGrid(Me.CompanyDefinedView, isEditdable)
        AllowFilePathBtn(rptBtnCompDefined, isEditdable)

    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        'FileList = New ArrayList
        Dim CompanyID As String = Trim(IfNull(blList.GetFocusedRowData("COIDNo"), ""))
        Dim info As Boolean = False
        If IsNothing(focusedView) Then
            Exit Sub
        End If
        If Not focusedView.HasColumnErrors Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {}) Then
                Select Case IIf(tabChanged, PrevTab, Me.TabControl.SelectedTabPage.Tag)
                    Case "TravelDoc" 'Travel Document
                        info = DB.RunSqls(SaveTravelDoc(CompanyID))
                        'info = SaveMainDocument(TravelDocView, strID)
                    Case "LicCert" 'Certificates
                        info = DB.RunSqls(SaveLicCert(strID))
                        'Case "Educ" 'Education
                        '    info = DB.RunSqls(SaveEducation(strID))
                    Case "Medical" 'Medical
                        info = DB.RunSqls(SaveMedCert(strID))
                        'info = DB.RunSqls(SaveVslHistory(id))
                        'Case "Training"
                        '    info = DB.RunSqls(SaveTraining(strID))
                    Case "CompanyDefined"
                        info = DB.RunSqls(SaveCompanyDefined(strID))
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

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        header.Focus()

        Dim flag As Boolean = False
        ALLOWNEXTS = flag

        If BRECORDUPDATEDs Then
            Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
            If res = MsgBoxResult.Yes Then
                If TravelDocView.HasColumnErrors() Or LicCertView.HasColumnErrors Or MedicalView.HasColumnErrors Then
                    flag = False
                    ALLOWNEXTS = flag
                    'Else
                    '    If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, showMsg) Then
                    '        If bAddMode Then
                    '            'If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                    '            '    flag = False
                    '            '    ALLOWNEXTS = flag
                    '            'Else
                    '            flag = True
                    '            ALLOWNEXTS = flag
                    '            SaveData() '
                    '            'End If
                    '        Else
                    '            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & strID & "'") Then
                    '                flag = False
                    '                ALLOWNEXTS = flag
                Else
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData() '
                End If
                '        End If
                '    Else
                '        flag = False
                '        ALLOWNEXTS = flag
                '    End If
                'End If
            ElseIf res = MsgBoxResult.No Then
                RefreshData()
                flag = False
                ALLOWNEXTS = True
            End If
        Else
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

    Private Sub DeleteMain()
        MyBase.DeleteData()
        Dim info As Boolean = False
        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed("tblCrewInfo", strID) Then 'Check if the record is in use or a system data

                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName, strID) 'neil
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy)

                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                If info Then
                    ClearFields(Me.LayoutControl1.Root, False)
                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    RefreshData()
                    blList.RefreshData()
                    BRECORDUPDATEDs = False
                End If
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If
        End If
    End Sub

    Private Sub DeleteSubTable()
        Dim GrdView As New DevExpress.XtraGrid.Views.Grid.GridView
        Dim info As Boolean = False, FNames As New ArrayList
        Dim subDesc As String = "", subtblcount As Integer = 0
        Dim DelSQL As String = "", PKey As String = ""

        Dim oLogDeletion As New LogDeletion 'tonytest

        With focusedView
            Select Case .Name
                Case TravelDocView.Name, LicCertView.Name, MedicalView.Name, CompanyDefinedView.Name
                    GrdView = focusedView
                    PKey = IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")
                    subDesc = .GetRowCellDisplayText(.FocusedRowHandle, IIf(.Name.Equals(CompanyDefinedView.Name), "FKeyComCompanyDefined", "FKeyDocument"))

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil	'tony20160719
                    Dim cActionDesc As String = ""
                    If .Name = TravelDocView.Name Then cActionDesc = "Travel Document"
                    If .Name = LicCertView.Name Then cActionDesc = "Certificate"
                    If .Name = MedicalView.Name Then cActionDesc = "Medical"
                    If .Name = CompanyDefinedView.Name Then cActionDesc = "Company Defined"

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, cActionDesc, 0, System.Environment.MachineName, subDesc & " : " & .GetRowCellValue(.FocusedRowHandle, "Number"), FormName, strID)
                    clsAudit.saveAuditPreDelDetails("tblDocument", PKey, LastUpdatedBy) 'neil

                    DelSQL = "DELETE FROM dbo.tblDocument" & " WHERE PKey='" & PKey & "'"
                    
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblDocument", _
                        "PKey = '" & PKey & "'", _
                        "<< Delete Crew Data - Documents - " & cActionDesc & " >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Documents - " & cActionDesc & ">", _
                        GetUserName())
                    '-->

                    'get the FileNames of the Child Table
                    DB.BeginReader("SELECT * FROM dbo.tblDocImage WHERE FKeyCrewDocumentID ='" & PKey & "'")
                    subtblcount = 0
                    While DB.Read
                        FNames.Add(CStr(DB.ReaderItem("FilePath")))
                        subtblcount = subtblcount + 1
                    End While
                    DB.CloseReader()

                Case TravelDocImageView.Name, LicCertDocImageView.Name, MedicalImageView.Name, CompanyDefinedImageView.Name
                    Dim _MainView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(.ParentView, DevExpress.XtraGrid.Views.Grid.GridView)
                    Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = _MainView.GetDetailView(_MainView.FocusedRowHandle, 0)
                    GrdView = vw
                    PKey = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "PKey"), "")
                    subDesc = IfNull(vw.GetRowCellDisplayText(vw.FocusedRowHandle, "Description"), "NewRecord")

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil	'tony20160719
                    Dim cActionDesc As String = ""
                    'If .Name = TravelDocView.Name Then cActionDesc = "Travel Document"
                    'If .Name = LicCertView.Name Then cActionDesc = "Certificate"
                    'If .Name = MedicalView.Name Then cActionDesc = "Medical"
                    If .Name = TravelDocImageView.Name Then cActionDesc = "Travel Document"
                    If .Name = LicCertDocImageView.Name Then cActionDesc = "Certificate"
                    If .Name = MedicalImageView.Name Then cActionDesc = "Medical"
                    If .Name = CompanyDefinedImageView.Name Then cActionDesc = "Company Defined"

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, cActionDesc, 0, System.Environment.MachineName, focusedView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyCrewDocumentID") & " : " & subDesc, FormName, strID)

                    clsAudit.saveAuditPreDelDetails("tblDocImage", PKey, LastUpdatedBy) 'neil

                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblDocImage", _
                        "PKey = '" & PKey & "'", _
                        "<< Delete Crew Data - Documents - " & cActionDesc & " Scanned Image >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Documents - " & cActionDesc & " Scanned Image>", _
                        GetUserName())
                    '-->

                    DelSQL = "DELETE FROM dbo.tblDocImage WHERE PKey='" & PKey & "'"

            End Select
            If Not GrdView.Name.Equals("") Then
                With GrdView
                    If MsgBox("Are you sure want to delete the '" & subDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        'Delete SubTable First
                        If subtblcount > 0 Then
                            For Each fileName As String In FNames
                                If Not Trim(fileName).Equals("") Then
                                    Try
                                        Kill(GenerateCrewFilePath(fileName))
                                    Catch ex As Exception

                                    End Try
                                End If
                            Next
                        End If

                        'Delete Per Record
                        'If Not .GetRowCellValue(.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                        If Not IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), String.Empty).Equals(String.Empty) Then
                            If Not Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")).Equals("") Then
                                info = DB.RunSql(DelSQL)
                                deleteDocument(GrdView)
                                If info Then
                                    oLogDeletion.AddLogEntryToDatabase()    'tonytest
                                End If
                            End If
                        End If
                        .DeleteRow(.FocusedRowHandle)
                        If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                    End If
                End With
            End If


        End With

    End Sub

    Private Sub TabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabControl.SelectedPageChanged
        'get the previous tab
        PrevTab = Me.TabControl.SelectedTabPage.Tag
        getSelectedView()
        LoadSub()
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

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "ViewData"
                ViewData()
            Case "SelectRecord"
                SelectRecord(param(1), param(2))
        End Select
    End Sub

    Private Sub SelectRecord(Group As String, PKey As String)
        Select Case Group
            Case "SYSTRAVELDOC"
                TabControl.SelectedTabPage = TabControl.TabPages(0)
                With TravelDocView
                    .FocusedRowHandle = .LocateByValue("PKey", PKey)
                End With
            Case "SYSLICCERT"
                TabControl.SelectedTabPage = TabControl.TabPages(1)
                With LicCertView
                    .FocusedRowHandle = .LocateByValue("PKey", PKey)
                End With
            Case "SYSMEDCERT"
                TabControl.SelectedTabPage = TabControl.TabPages(2)
                With MedicalView
                    .FocusedRowHandle = .LocateByValue("PKey", PKey)
                End With
            Case "SYSCOMPDEF"
                TabControl.SelectedTabPage = TabControl.TabPages(3)
                CompanyDefinedView.FocusedRowHandle = CompanyDefinedView.LocateByValue("PKey", PKey)
        End Select
    End Sub

#End Region

#Region "Company Defined"

    Private Function SaveCompanyDefined(ByVal _CompanyId As String) As ArrayList
        Dim query As New ArrayList
        Dim docstr As String = ""
        Dim count As Integer = 0
        With Me.CompanyDefinedView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    Dim dateIssued As String = ChangeToSQLDate(.GetRowCellValue(i, "DateIssue"))
                    Dim dateExpiry As String = ChangeToSQLDate(.GetRowCellValue(i, "DateExpiry"))
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Company Defined", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyComCompanyDefined").ToString.Replace("'", "''") & " : " & .GetRowCellValue(.FocusedRowHandle, "Number").ToString.Replace("'", "''"), FormName, strID)
                    If IfNull(.GetRowCellValue(i, "PKey"), "").Equals(CStr(i)) Then
                        query.Add("INSERT INTO dbo.tblDocument(" & _
                                  "FKeyIDNbr,FKeyDocument," & _
                                  "Number, DateIssue, DateExpiry," & _
                                  "IssuedBy, LastUpdatedBy) " & _
                                  "VALUES(" & _
                                  "'" & strID & "'" & _
                                  ",'" & .GetRowCellValue(i, "FKeyComCompanyDefined") & "'" & _
                                  ",'" & .GetRowCellValue(i, "Number") & "'" & _
                                  "," & dateIssued & "" & _
                                  "," & dateExpiry & "" & _
                                  ",'" & .GetRowCellValue(i, "IssuedBy") & "'" & _
                                  ",'" & LastUpdatedBy & "')")
                        type = "Inserted"
                    Else 'It is updated. 
                        query.Add("UPDATE dbo.tblDocument SET " & _
                                  "FKeyIDNbr = '" & strID & "'," & _
                                  "FKeyDocument = '" & .GetRowCellValue(i, "FKeyComCompanyDefined") & "'," & _
                                  "Number = '" & CleanInput(.GetRowCellValue(i, "Number")) & "'," & _
                                  "DateIssue = " & dateIssued & "," & _
                                  "DateExpiry = " & dateExpiry & ", " & _
                                  "IssuedBy = '" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "', " & _
                                  "LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                                  " WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        type = "Updated"
                    End If
                    '=================== Document Images ===================================
                    .BeginUpdate()
                    For x As Integer = 0 To .GetRelationCount(i) - 1
                        Dim wasExpanded As Boolean = .GetMasterRowExpandedEx(i, x)
                        If Not wasExpanded Then
                            .SetMasterRowExpandedEx(i, x, True)
                        End If
                        Dim child As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(.GetDetailView(i, x), DevExpress.XtraGrid.Views.Grid.GridView)
                        With child
                            .CloseEditForm()
                            .UpdateCurrentRow()
                            Dim childRH As Integer
                            For childRH = 0 To .RowCount - 1
                                If .GetRowCellValue(childRH, "Edited") Then
                                    'Insert
                                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, CleanInput(.GetRowCellValue(childRH, "Description")), FormName, ) 'neil 'tony20160719
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Company Defined (Image)", 0, System.Environment.MachineName, CleanInput(.GetRowCellValue(childRH, "Description")).ToString.Replace("'", "''"), FormName, strID) 'neil add strID
                                    If IfNull(.GetRowCellValue(childRH, "PKey"), "") = "" Then
                                        query.Add("INSERT INTO dbo.tblDocImage(FKeyIDNbr,FKeyCrewDocumentID,Description,FilePath,LastUpdatedBy)" & _
                                                  "VALUES(" & _
                                                  "'" & strID & "'" & _
                                                  ",'" & CleanInput(.GetRowCellValue(childRH, "FKeyCrewDocumentID")) & "'" & _
                                                  ",'" & CleanInput(.GetRowCellValue(childRH, "Description")) & "'" & _
                                                  "," & GetFilePathFileName(childRH, child) & _
                                                  ",'" & CleanInput(LastUpdatedBy) & "')")
                                    Else
                                        'update
                                        query.Add("UPDATE dbo.tblDocImage SET " & _
                                                  "Description = '" & CleanInput(.GetRowCellValue(childRH, "Description")) & "'" & _
                                                  ",FilePath =" & GetFilePathFileName(childRH, child) & _
                                                  ",FKeyCrewDocumentID='" & CleanInput(.GetRowCellValue(childRH, "FKeyCrewDocumentID")) & "'" & _
                                                  ",DateUpdated = getdate()" & _
                                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                                 "WHERE PKey = '" & CleanInput(IfNull(.GetRowCellValue(childRH, "PKey"), "")) & "'")
                                    End If
                                    If (Not IfNull(.GetRowCellValue(childRH, "FilePath"), "").ToString.Equals(IfNull(.GetRowCellValue(childRH, "FileName"), ""))) And Not IfNull(.GetRowCellValue(childRH, "FilePath"), "").ToString.Equals("") Then
                                        docstr = IfNull(.GetRowCellValue(childRH, "FilePath"), "") & "|" & _
                                                 IfNull(.GetRowCellValue(childRH, "FileName"), "")
                                        count = count + 1
                                        DocumentList.Add(New Dictionary(Of Integer, String)() From {{count, docstr}})
                                    End If
                                End If
                            Next
                        End With
                    Next
                    .EndUpdate()
                    ''============= SUB Document ====================================================
                End If
            Next
            Return query
        End With
    End Function

#End Region

#Region "Travel Documents"

    Private Function SaveTravelDoc(ByVal _CompanyID As String) As ArrayList
        Dim query As New ArrayList
        Dim DocStr As String = ""
        Dim count As Integer = 0
        With Me.TravelDocView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    Dim dateIssued As String = ChangeToSQLDate(.GetRowCellValue(i, "DateIssue"))
                    Dim dateExpiry As String = ChangeToSQLDate(.GetRowCellValue(i, "DateExpiry"))

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument"), FormName, strID) 'neil   'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Document", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument").ToString.Replace("'", "''") & " : " & .GetRowCellValue(.FocusedRowHandle, "Number").ToString.Replace("'", "''"), FormName, strID)
                    If IfNull(.GetRowCellValue(i, "PKey"), "").Equals(CStr(i)) Then
                        query.Add("INSERT INTO dbo.tblDocument(" & _
                                  "FKeyIDNbr," & _
                                  "FKeyDocument," & _
                                  "FileTag," & _
                                  "Number," & _
                                  "DateIssue," & _
                                  "DateExpiry," & _
                                  "IssuedBy," & _
                                  "IssuedPlace," & _
                                  "FKeyCntry," & _
                                  "Remarks," & _
                                  "isActive," & _
                                  "LastUpdatedBy)" & _
                                   "VALUES(" & _
                                   "'" & strID & "'" & _
                                   ",'" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                   ",'" & .GetRowCellValue(i, "FileTag") & "'" & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "Number")) & "'" & _
                                   "," & dateIssued & _
                                   "," & dateExpiry & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "'" & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "IssuedPlace")) & "'" & _
                                   "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                                   ",'" & IfNull(.GetRowCellValue(i, "isActive"), "1") & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                        type = "Inserted"
                    Else
                        'Neil query.Add("UPDATE dbo.tblDocument SET " & _
                        '          "FileTag = '" & .GetRowCellValue(i, "FileTag") & "'" & _
                        '          ",FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                        '          ",Number = '" & CleanInput(.GetRowCellValue(i, "Number")) & "'" & _
                        '          ",DateIssue = " & dateIssued & _
                        '          ",DateExpiry = " & dateExpiry & _
                        '          ",IssuedBy = '" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "'" & _
                        '          ",IssuedPlace = '" & CleanInput(.GetRowCellValue(i, "IssuedPlace")) & "'" & _
                        '          ",isActive = '" & .GetRowCellValue(i, "isActive") & "'" & _
                        '          ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                        '          ",Remarks = '" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                        '          ",DateUpdated = (getdate())" & _
                        '          ",LastUpdatedBy = '" & .GetRowCellValue(i, "LastUpdatedBy") & "'" & _
                        '          " WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        query.Add("UPDATE dbo.tblDocument SET " & _
                                 "FileTag = '" & .GetRowCellValue(i, "FileTag") & "'" & _
                                 ",FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                 ",Number = '" & CleanInput(.GetRowCellValue(i, "Number")) & "'" & _
                                 ",DateIssue = " & dateIssued & _
                                 ",DateExpiry = " & dateExpiry & _
                                 ",IssuedBy = '" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "'" & _
                                 ",IssuedPlace = '" & CleanInput(.GetRowCellValue(i, "IssuedPlace")) & "'" & _
                                 ",isActive = '" & .GetRowCellValue(i, "isActive") & "'" & _
                                 ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                                 ",Remarks = '" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                                 ",DateUpdated = (getdate())" & _
                                 ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                 " WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        type = "Updated"
                    End If


                    '=================== Document Images ===================================
                    .BeginUpdate()
                    For x As Integer = 0 To .GetRelationCount(i) - 1
                        Dim wasExpanded As Boolean = .GetMasterRowExpandedEx(i, x)
                        If Not wasExpanded Then
                            .SetMasterRowExpandedEx(i, x, True)
                        End If
                        Dim child As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(.GetDetailView(i, x), DevExpress.XtraGrid.Views.Grid.GridView)
                        With child
                            .CloseEditForm()
                            .UpdateCurrentRow()
                            Dim childRH As Integer
                            For childRH = 0 To .RowCount - 1
                                If .GetRowCellValue(childRH, "Edited") Then
                                    'Insert
                                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, CleanInput(.GetRowCellValue(childRH, "Description")), FormName, ) 'neil 'tony20160719
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Document (Image)", 0, System.Environment.MachineName, CleanInput(.GetRowCellValue(childRH, "Description")).ToString.Replace("'", "''"), FormName, strID) 'neil add strID
                                    If IfNull(.GetRowCellValue(childRH, "PKey"), "") = "" Then
                                        query.Add("INSERT INTO dbo.tblDocImage(FKeyIDNbr,FKeyCrewDocumentID,Description,FilePath,LastUpdatedBy)" & _
                                                  "VALUES(" & _
                                                  "'" & strID & "'" & _
                                                  ",'" & CleanInput(.GetRowCellValue(childRH, "FKeyCrewDocumentID")) & "'" & _
                                                  ",'" & CleanInput(.GetRowCellValue(childRH, "Description")) & "'" & _
                                                  "," & GetFilePathFileName(childRH, child) & _
                                                  ",'" & CleanInput(LastUpdatedBy) & "')")
                                    Else
                                        'update
                                        query.Add("UPDATE dbo.tblDocImage SET " & _
                                                  "Description = '" & CleanInput(.GetRowCellValue(childRH, "Description")) & "'" & _
                                                  ",FilePath =" & GetFilePathFileName(childRH, child) & _
                                                  ",FKeyCrewDocumentID='" & CleanInput(.GetRowCellValue(childRH, "FKeyCrewDocumentID")) & "'" & _
                                                  ",DateUpdated = getdate()" & _
                                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                                 "WHERE PKey = '" & CleanInput(IfNull(.GetRowCellValue(childRH, "PKey"), "")) & "'")
                                    End If
                                    If (Not IfNull(.GetRowCellValue(childRH, "FilePath"), "").ToString.Equals(IfNull(.GetRowCellValue(childRH, "FileName"), ""))) And Not IfNull(.GetRowCellValue(childRH, "FilePath"), "").ToString.Equals("") Then
                                        DocStr = IfNull(.GetRowCellValue(childRH, "FilePath"), "") & "|" & _
                                                 IfNull(.GetRowCellValue(childRH, "FileName"), "")
                                        count = count + 1
                                        DocumentList.Add(New Dictionary(Of Integer, String)() From {{count, DocStr}})
                                    End If
                                End If
                            Next
                        End With
                    Next
                    .EndUpdate()
                    '============= SUB Document ====================================================
                End If
            Next
        End With
        Return query
    End Function

    Private Sub TravelDocView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles TravelDocView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                'Marks Actitive the Document if newly Added
                .SetRowCellValue(e.RowHandle, "Edited", True)
                If .GetRowCellValue(e.RowHandle, "PKey").Equals(System.DBNull.Value) And .GetRowCellValue(e.RowHandle, "isActive").Equals(System.DBNull.Value) Then
                    If Not e.Column.FieldName.Equals("isActive") Then
                        .SetRowCellValue(e.RowHandle, "isActive", True)
                    End If
                End If

                UpdateDateExpiry(sender, e)
            End If
        End With
    End Sub

    Private Sub UpdateDateExpiry(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, Optional WithCountry As Boolean = True)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            Select Case e.Column.FieldName.ToString
                Case "DateIssue", "FKeyDocument", "FKeyCntry"

                    Try
                        If Not .GetRowCellValue(.FocusedRowHandle, "DateIssue").Equals(DBNull.Value) Then
                            Dim Cntry As String = ""
                            Dim DocCode As String = .GetRowCellValue(.FocusedRowHandle, "FKeyDocument")
                            Dim DateIssue As Date = .GetRowCellValue(.FocusedRowHandle, "DateIssue")
                            If WithCountry Then
                                Cntry = IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCntry"), "")
                            End If

                            If WithCountry Then
                                .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetDateExpiry(DocCode, DateIssue, Cntry))
                            Else
                                .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetDateExpiryNoCountry(DocCode, DateIssue))
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Failed to update dateexpiry." & vbNewLine & "Error: " & ex.Message)
                    End Try
                    

            End Select
        End With
    End Sub

    Private Sub TravelDocView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles TravelDocView.CustomUnboundColumnData
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

            If e.Column.FieldName = "File_Name" AndAlso e.IsGetData Then
                e.Value = strID & "_" & ft & "_" & di
            End If
        End With
    End Sub

    Private Sub TravelDocView_GotFocus(sender As Object, e As System.EventArgs) Handles TravelDocView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            'AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Travel Document")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub TravelDocView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles TravelDocView.InitNewRow
        Dim CView As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        CView.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        CView.SetRowCellValue(e.RowHandle, "FKeyIDNbr", strID) 'Crew ID
        CView.SetRowCellValue(e.RowHandle, "PKey", _view.RowCount)
        SubAddMode = True
    End Sub

    Private Sub TravelDocView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles TravelDocView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub TravelDocView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles TravelDocView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub TravelDocView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TravelDocView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.TravelDocView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub TravelDocView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles TravelDocView.RowCellStyle
        'Required FieldsNames
        Dim strRequiredFieldName As String = "FKeyDocument;DateIssue;Number;"
        ViewRowCellStyle(sender, e, strRequiredFieldName)
    End Sub

    Private Sub TravelDocView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles TravelDocView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub TravelDocView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles TravelDocView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Documents Travel Document"
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

    Private Sub TravelDocView_ShownEditor(sender As Object, e As System.EventArgs) Handles TravelDocView.ShownEditor
        SetMinMaxDateValidation(sender, e, "DateIssue", "DateExpiry")
        stopnaba = True
    End Sub

    Private Sub TravelDocView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles TravelDocView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FKeyDocument As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyDocument")
        Dim DateIssue As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateIssue")
        Dim tsNumber As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Number")

        With view
            'Validate LicCert
            If .GetRowCellValue(e.RowHandle, FKeyDocument) IsNot System.DBNull.Value And .GetRowCellValue(e.RowHandle, FKeyDocument) IsNot Nothing Then
                .SetRowCellValue(e.RowHandle, "FileTag", getFileTag(.GetRowCellValue(e.RowHandle, FKeyDocument)))
            ElseIf .GetRowCellValue(e.RowHandle, FKeyDocument) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyDocument) Is Nothing Then
                .SetColumnError(FKeyDocument, "Please select Travel Document.")
                e.Valid = False
            Else
                .SetColumnError(FKeyDocument, "")
            End If

            'Number
            If .GetRowCellValue(e.RowHandle, tsNumber) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, tsNumber) Is Nothing Then
                .SetColumnError(tsNumber, "Please Enter Number.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, tsNumber).Equals("") Then
                    .SetColumnError(tsNumber, "Please Enter Number.")
                    e.Valid = False
                Else
                    .SetColumnError(tsNumber, "")
                End If
            End If

            'Validate DateIssue
            If .GetRowCellValue(e.RowHandle, DateIssue) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, DateIssue) Is Nothing Then
                .SetColumnError(DateIssue, "Please Enter Issued Date.")
                e.Valid = False
            Else
                .SetColumnError(DateIssue, "")
            End If

            'DateExpiry
            If .FocusedColumn.FieldName.Equals("DateExpiry") Then
                If Not .GetFocusedRowCellValue("DateIssue").Equals(System.DBNull.Value) And Not .GetFocusedRowCellValue("DateExpiry").Equals(System.DBNull.Value) Then
                    'If CDate(e.Value) >= CDate(.GetFocusedRowCellValue("DateIssue")) Then
                    '    .SetFocusedRowCellValue(.FocusedColumn, e.Value)
                    If CDate(.GetFocusedRowCellValue("DateExpiry")) >= CDate(.GetFocusedRowCellValue("DateIssue")) Then
                        .SetColumnError(.Columns("DateExpiry"), String.Empty)
                        .SetFocusedRowCellValue(.FocusedColumn, .GetFocusedRowCellValue("DateExpiry"))
                    Else
                        .SetColumnError(.Columns("DateExpiry"), "Invalid Date")
                    End If
                Else
                    .SetColumnError(.Columns("DateIssue"), "Invalid Date")
                End If
            End If

            If SubAddMode Then
                DocumentValidation(view, tsNumber, DateIssue, e)
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

    Private Sub TravelDocView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles TravelDocView.ValidatingEditor
        '<!-- edited by tony20170918, transferred to cellvaluechanged
        'SetDateExpiry(sender, e)
        '-->
        ViewValidatingEditor(sender, e)
    End Sub

    'Validates Number And DateIssued Fields only
    Private Sub DocumentValidation(_view As DevExpress.XtraGrid.Views.Grid.GridView, tsNumber As DevExpress.XtraGrid.Columns.GridColumn, DateIssue As DevExpress.XtraGrid.Columns.GridColumn, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)
        Dim _Number As String = ""
        Dim _dateIssued As New Date
        Dim _AllowDup As Boolean = False

        Try
            With _view
                _Number = IfNull(.GetRowCellValue(e.RowHandle, "Number"), "")
                _dateIssued = IIf(.GetRowCellValue(e.RowHandle, "DateIssue").Equals(System.DBNull.Value), _dateIssued, .GetRowCellValue(e.RowHandle, "DateIssue"))

                _AllowDup = CBool(DB.DLookUp("AllowDuplicate", "tblAdmDocument", "0", "PKey='" & (IfNull(.GetRowCellValue(e.RowHandle, "FKeyDocument"), "")) & "'"))
                If Not IsNothing(_Number) And Not IsNothing(_dateIssued) Then
                    If Not _Number.Equals("") And Not _dateIssued.Equals(#12:00:00 AM#) Then
                        If _AllowDup And DB.HasDuplicate("tbldocument", "[FKeyDocument]='" & (IfNull(.GetRowCellValue(e.RowHandle, "FKeyDocument"), "")) & "'" & _
                          "AND [Number]='" & _Number & "'" & _
                          "AND [DateIssue]=" & ChangeToSQLDate(_dateIssued) & _
                          "AND [PKey]<>'" & .GetRowCellValue(e.RowHandle, "PKey") & "'" & _
                          "AND [FKeyIDNbr] = '" & strID & "'") Then

                            .SetColumnError(DateIssue, "Document Already Exist")
                            .SetColumnError(tsNumber, "Document Already Exist")
                            e.Valid = False
                        End If

                    End If

                End If
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Function getFileTag(ByVal _id As String) As String
        Return DB.DLookUp("FileTag", "dbo.tblAdmDocument", "0", "PKey='" & _id & "'")
    End Function


#Region "Travel Document Images Sub"

    Private Sub TravelDocImageView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles TravelDocImageView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                TryCast(view.ParentView, DevExpress.XtraGrid.Views.Grid.GridView).SetRowCellValue(view.SourceRowHandle, "Edited", True)
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub TravelDocImageView_GotFocus(sender As Object, e As System.EventArgs) Handles TravelDocImageView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            'AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Travel Document Images")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub TravelDocImageView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles TravelDocImageView.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = view.ParentView 'Master View
        With view
            If e.Column.FieldName = "FileName" AndAlso e.IsGetData Then
                e.Value = MView.GetRowCellValue(view.SourceRowHandle, "File_Name") & "_" & e.ListSourceRowIndex.ToString
            End If
        End With
    End Sub

    Private Sub TravelDocImageView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles TravelDocImageView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub TravelDocImageView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles TravelDocImageView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub TravelDocImageView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles TravelDocImageView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(View.ParentView, DevExpress.XtraGrid.Views.Grid.GridView)
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "FKeyCrewDocumentID", MView.GetRowCellValue(MView.SourceRowHandle, "PKey")) 'Crew Document ID
        'SubAddMode = True
    End Sub

    Private Sub TravelDocImageView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles TravelDocImageView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub TravelDocImageView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles TravelDocImageView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FilePath As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FilePath")
        Dim Desc As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Description")

        With view

            'Number
            If .GetRowCellValue(e.RowHandle, FilePath) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FilePath) Is Nothing Then
                .SetColumnError(Desc, "Please select a file.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, FilePath) = "" Then
                    .SetColumnError(Desc, "Please select a file.")
                    e.Valid = False
                Else
                    .SetColumnError(Desc, "")
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

#End Region

#Region "Certificates"


    Private Function SaveLicCert(ByVal _CompanyID As String) As ArrayList
        Dim query As New ArrayList
        Dim DocStr As String = ""
        Dim count As Integer = 0
        With Me.LicCertView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    Dim dateIssued As String = ChangeToSQLDate(.GetRowCellValue(i, "DateIssue"))
                    Dim dateExpiry As String = ChangeToSQLDate(.GetRowCellValue(i, "DateExpiry"))
                    'Dim filePath As String = GetFilePathFileName(LicCertView)

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument"), FormName, strID) 'neil   'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Certificate", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument").ToString.Replace("'", "''") & " : " & .GetRowCellValue(.FocusedRowHandle, "Number").ToString.Replace("'", "''"), FormName, strID)

                    If IfNull(.GetRowCellValue(i, "PKey"), "").Equals(CStr(i)) Then
                        query.Add("INSERT INTO dbo.tblDocument(" & _
                                  "FKeyIDNbr," & _
                                  "FileTag, " & _
                                  "FKeyDocument," & _
                                  "Number," & _
                                  "DateIssue," & _
                                  "DateExpiry," & _
                                  "IssuedBy," & _
                                  "IssuedPlace," & _
                                  "FKeyCntry," & _
                                  "Remarks," & _
                                  "FilePath," & _
                                  "FKeyCertCapacity," & _
                                  "CertRegulation," & _
                                  "FKeyCertLimit," & _
                                  "isActive," & _
                                  "HLicense," & _
                                  "CertAuthority," & _
                                  "LastUpdatedBy)" & _
                                   "VALUES(" & _
                                   "'" & strID & "'" & _
                                   ",'" & .GetRowCellValue(i, "FileTag") & "'" & _
                                   ",'" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "Number")) & "'" & _
                                   "," & dateIssued & _
                                   "," & dateExpiry & _
                                   ",'" & CleanInput(IfNull(.GetRowCellValue(i, "IssuedBy"), "")) & "'" & _
                                   ",'" & CleanInput(IfNull(.GetRowCellValue(i, "IssuedPlace"), "")) & "'" & _
                                   "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                                   "," & GetFilePathFileName(i, LicCertView) & _
                                   "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCertCapacity"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCertCapacity") & "'", "NULL") & "" & _
                                   ",'" & .GetRowCellValue(i, "CertRegulation") & "'" & _
                                   "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCertLimit"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCertLimit") & "'", "NULL") & "" & _
                                   ",'" & .GetRowCellValue(i, "isActive") & "'" & _
                                   ",'" & .GetRowCellValue(i, "HLicense") & "'" & _
                                   "," & IIf(IfNull(.GetRowCellValue(i, "CertAuthority"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "CertAuthority") & "'", "NULL") & "" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        'query.Add("UPDATE dbo.tblDocument SET " & _
                        '          "FileTag = '" & .GetRowCellValue(i, "FileTag") & "'" & _
                        '          ",FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                        '          ",Number = '" & CleanInput(.GetRowCellValue(i, "Number")) & "'" & _
                        '          ",DateIssue = " & dateIssued & _
                        '          ",DateExpiry = " & dateExpiry & _
                        '          ",IssuedBy = '" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "'" & _
                        '          ",IssuedPlace = '" & CleanInput(.GetRowCellValue(i, "IssuedPlace")) & "'" & _
                        '          ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                        '          ",Remarks = '" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                        '          ",FKeyCertCapacity = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCertCapacity"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCertCapacity") & "'", "NULL") & "" & _
                        '          ",CertRegulation = '" & .GetRowCellValue(i, "CertRegulation") & "'" & _
                        '          ",FKeyCertLimit = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCertLimit"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCertLimit") & "'", "NULL") & "" & _
                        '          ",isActive = '" & .GetRowCellValue(i, "isActive") & "'" & _
                        '          ",HLicense = '" & .GetRowCellValue(i, "HLicense") & "'" & _
                        '          ",CertAuthority = '" & .GetRowCellValue(i, "CertAuthority") & "'" & _
                        '          ",DateUpdated = (getdate())" & _
                        '          ",LastUpdatedBy = '" & .GetRowCellValue(i, "LastUpdatedBy") & "'" & _
                        '          " WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        query.Add("UPDATE dbo.tblDocument SET " & _
                                    "FileTag = '" & .GetRowCellValue(i, "FileTag") & "'" & _
                                    ",FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                    ",Number = '" & CleanInput(.GetRowCellValue(i, "Number")) & "'" & _
                                    ",DateIssue = " & dateIssued & _
                                    ",DateExpiry = " & dateExpiry & _
                                    ",IssuedBy = '" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "'" & _
                                    ",IssuedPlace = '" & CleanInput(.GetRowCellValue(i, "IssuedPlace")) & "'" & _
                                    ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                                    ",Remarks = '" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                                    ",FKeyCertCapacity = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCertCapacity"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCertCapacity") & "'", "NULL") & "" & _
                                    ",CertRegulation = '" & .GetRowCellValue(i, "CertRegulation") & "'" & _
                                    ",FKeyCertLimit = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCertLimit"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCertLimit") & "'", "NULL") & "" & _
                                    ",isActive = '" & .GetRowCellValue(i, "isActive") & "'" & _
                                    ",HLicense = '" & .GetRowCellValue(i, "HLicense") & "'" & _
                                    ",CertAuthority = '" & .GetRowCellValue(i, "CertAuthority") & "'" & _
                                    ",DateUpdated = (getdate())" & _
                                    ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                    " WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")

                    End If

                    .BeginUpdate()
                    For x As Integer = 0 To .GetRelationCount(i) - 1
                        Dim wasExpanded As Boolean = .GetMasterRowExpandedEx(i, x)
                        If Not wasExpanded Then
                            .SetMasterRowExpandedEx(i, x, True)
                        End If
                        Dim child As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(.GetDetailView(i, x), DevExpress.XtraGrid.Views.Grid.GridView)
                        With child
                            .CloseEditForm()
                            .UpdateCurrentRow()
                            Dim childRH As Integer
                            For childRH = 0 To .RowCount - 1
                                If .GetRowCellValue(childRH, "Edited") Then
                                    'Insert
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Certificate (Image)", 0, System.Environment.MachineName, CleanInput(.GetRowCellValue(childRH, "Description")).ToString.Replace("'", "''"), FormName, ) 'tony20160719
                                    If IfNull(.GetRowCellValue(childRH, "PKey"), "") = "" Then
                                        query.Add("INSERT INTO dbo.tblDocImage(FKeyIDNbr,FKeyCrewDocumentID,Description,FilePath,LastUpdatedBy)" & _
                                                  "VALUES(" & _
                                                  "'" & strID & "'" & _
                                                  ",'" & CleanInput(.GetRowCellValue(childRH, "FKeyCrewDocumentID")) & "'" & _
                                                  ",'" & CleanInput(.GetRowCellValue(childRH, "Description")) & "'" & _
                                                  "," & GetFilePathFileName(childRH, child) & _
                                                  ",'" & CleanInput(LastUpdatedBy) & "')")
                                    Else
                                        'update
                                        query.Add("UPDATE dbo.tblDocImage SET " & _
                                                  "Description = '" & CleanInput(.GetRowCellValue(childRH, "Description")) & "'" & _
                                                  ",FilePath =" & GetFilePathFileName(childRH, child) & _
                                                  ",FKeyCrewDocumentID='" & CleanInput(.GetRowCellValue(childRH, "FKeyCrewDocumentID")) & "'" & _
                                                  ",DateUpdated = getdate()" & _
                                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                                 "WHERE PKey = '" & CleanInput(IfNull(.GetRowCellValue(childRH, "PKey"), "")) & "'")
                                    End If

                                    If (Not IfNull(.GetRowCellValue(childRH, "FilePath"), "").ToString.Equals(IfNull(.GetRowCellValue(childRH, "FileName"), ""))) And Not IfNull(.GetRowCellValue(childRH, "FilePath"), "").ToString.Equals("") Then
                                        DocStr = IfNull(.GetRowCellValue(childRH, "FilePath"), "") & "|" & _
                                                 IfNull(.GetRowCellValue(childRH, "FileName"), "")
                                        count = count + 1
                                        DocumentList.Add(New Dictionary(Of Integer, String)() From {{count, DocStr}})
                                    End If
                                End If
                            Next
                        End With
                    Next
                    .EndUpdate()
                End If
            Next
        End With
        Return query
    End Function

    Private Sub LicCertView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles LicCertView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                'Marks Actitive the Document if newly Added
                .SetRowCellValue(e.RowHandle, "Edited", True)
                If .GetRowCellValue(e.RowHandle, "PKey").Equals(System.DBNull.Value) And .GetRowCellValue(e.RowHandle, "isActive").Equals(System.DBNull.Value) Then
                    If Not e.Column.FieldName.Equals("isActive") Then
                        .SetRowCellValue(e.RowHandle, "isActive", True)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub LicCertView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles LicCertView.CustomUnboundColumnData
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

            If e.Column.FieldName = "File_Name" AndAlso e.IsGetData Then
                e.Value = strID & "_" & ft & "_" & di
            End If
        End With
    End Sub

    Private Sub LicCertView_GotFocus(sender As Object, e As System.EventArgs) Handles LicCertView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Certificate")
            'Else
            '    focusedView = Nothing
            '    SetDeleteCaption(Name, "Delete Crew")
        End If
    End Sub

    Private Sub LicCertView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles LicCertView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "FKeyIDNbr", strID) 'Crew ID
        View.SetRowCellValue(e.RowHandle, "PKey", View.RowCount) 'Temporary PKey
        SubAddMode = True
    End Sub

    Private Sub LicCertView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles LicCertView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub LicCertView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles LicCertView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub LicCertView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LicCertView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.LicCertView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub LicCertView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles LicCertView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
        strRequiredFieldName = "FKeyDocument;DateIssue;Number;"
        ViewRowCellStyle(sender, e, strRequiredFieldName)
    End Sub

    Private Sub LicCertView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles LicCertView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub LicCertView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles LicCertView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Documents Certificates"
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

    Private Sub LicCertView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles LicCertView.ValidatingEditor
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With views
            If .FocusedColumn.FieldName.Equals("FKeyDocument") Then
                .SetRowCellValue(.FocusedRowHandle, "FKeyCertCapacity", System.DBNull.Value)
                If Not IsNothing(e.Value) Then
                    .SetRowCellValue(.FocusedRowHandle, "FKeyDocument", e.Value)
                Else
                    e.Valid = False
                End If
            End If
        End With
        SetDateExpiry(sender, e)
        ViewValidatingEditor(sender, e)

        '    Dim AllowDup As Boolean = False
        '    If .FocusedColumn.FieldName.Equals("FKeyDocument") Then
        '        AllowDup = CBool(DB.DLookUp("AllowDuplicate", "tblAdmDocument", "0", "PKey='" & e.Value & "'"))

        '        If Not AllowDup Then
        '            For i As Integer = 0 To .DataRowCount - 1
        '                If i <> (.FocusedRowHandle) Then
        '                    If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
        '                        e.Valid = False
        '                        e.ErrorText = "Already in use."
        '                    End If
        '                End If
        '            Next
        '        End If
        '    End If

        'End With

    End Sub

    Private Sub LicCertView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles LicCertView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Course As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyDocument")
        Dim tsNumber As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Number")
        Dim DateIssue As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateIssue")

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

            'Number
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

            'DateExpiry
            If .FocusedColumn.FieldName.Equals("DateExpiry") Then
                If Not .GetFocusedRowCellValue("DateIssue").Equals(System.DBNull.Value) And Not .GetFocusedRowCellValue("DateExpiry").Equals(System.DBNull.Value) Then
                    'If CDate(e.Value) >= CDate(.GetFocusedRowCellValue("DateIssue")) Then
                    '    .SetFocusedRowCellValue(.FocusedColumn, e.Value)
                    If CDate(.GetFocusedRowCellValue("DateExpiry")) >= CDate(.GetFocusedRowCellValue("DateIssue")) Then
                        .SetColumnError(.Columns("DateExpiry"), String.Empty)
                        .SetFocusedRowCellValue(.FocusedColumn, .GetFocusedRowCellValue("DateExpiry"))
                    Else
                        .SetColumnError(.Columns("DateExpiry"), "Invalid Date")
                    End If
                Else
                    .SetColumnError(.Columns("DateIssue"), "Invalid Date")
                End If
            End If

            If SubAddMode Then
                DocumentValidation(view, tsNumber, DateIssue, e)
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

    Private Sub LicCertView_ShownEditor(sender As Object, e As System.EventArgs) Handles LicCertView.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        With view
            If .FocusedColumn.FieldName.Equals("FKeyCertCapacity") Then
                ReloadCapcity(view)
            End If
        End With

        SetMinMaxDateValidation(sender, e, "DateIssue", "DateExpiry")
        stopnaba = True
    End Sub

    Private Sub LicCertView_HiddenEditor(sender As Object, e As System.EventArgs) Handles LicCertView.HiddenEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "FKeyCertCapacity" Then
            If Not DataViewCapacity Is Nothing Then
                DataViewCapacity.Dispose()
                DataViewCapacity = Nothing
            End If
        End If
    End Sub

    Private Function getRegulation(_id As String) As String
        Return DB.DLookUp("FileTag", "dbo.tblAdmDocument", "0", "PKey='" & _id & "'")
    End Function

    Private Sub RefreshCapacity()
        tblCapacity = DB.CreateTable("SELECT * FROM dbo.tblAdmCapacity ORDER BY Name ASC")
        Me.LicCertCapacity.DataSource = tblCapacity
        tblCapacityMap = DB.CreateTable("SELECT * FROM dbo.LicCertCap_Map ORDER BY Name ASC ")
    End Sub

    Private Sub ReloadCapcity(_view As DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            If (.FocusedColumn.FieldName.Equals("FKeyCertCapacity")) And (TypeOf (.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                DataViewCapacity = New DataView(tblCapacityMap)
                'DataViewCapacity.RowFilter = "FKeyDocument = '" & .GetRowCellValue(.FocusedRowHandle, "FKeyDocument") & "'"
                DataViewCapacity.RowFilter = "FKeyDocument = '" & .GetRowCellValue(.FocusedRowHandle, "FKeyDocument") & "' or PKey = '" & .GetRowCellValue(.FocusedRowHandle, "FKeyCertCapacity") & "'" 'neil.20170829
                edit.Properties.DataSource = DataViewCapacity
                If DataViewCapacity.Count < 0 Then
                    .SetFocusedRowCellValue("FKeyCertCapacity", "")
                End If
            End If
        End With
    End Sub

#Region "LicCertSub"

    Private Sub LicCertDocImageView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles LicCertDocImageView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                TryCast(view.ParentView, DevExpress.XtraGrid.Views.Grid.GridView).SetRowCellValue(view.SourceRowHandle, "Edited", True)
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub LicCertDocImageView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles LicCertDocImageView.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = view.ParentView 'Master View
        With view
            If e.Column.FieldName = "FileName" AndAlso e.IsGetData Then
                e.Value = MView.GetRowCellValue(view.SourceRowHandle, "File_Name") & "_" & e.ListSourceRowIndex.ToString
            End If
        End With
    End Sub

    Private Sub LicCertDocImageView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles LicCertDocImageView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub LicCertDocImageView_GotFocus(sender As Object, e As System.EventArgs) Handles LicCertDocImageView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            'AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Certificate Image")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub LicCertDocImageView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles LicCertDocImageView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub LicCertDocImageView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles LicCertDocImageView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(View.ParentView, DevExpress.XtraGrid.Views.Grid.GridView)
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "FKeyCrewDocumentID", MView.GetRowCellValue(MView.SourceRowHandle, "PKey")) 'Crew Document ID
        'SubAddMode = True
    End Sub

    Private Sub LicCertDocImageView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles LicCertDocImageView.RowCellStyle
        ViewRowCellStyle(sender, e, "")
    End Sub

    Private Sub LicCertDocImageView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles LicCertDocImageView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FilePath As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FilePath")
        Dim Desc As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Description")

        With view
            'Number
            If .GetRowCellValue(e.RowHandle, FilePath) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FilePath) Is Nothing Then
                .SetColumnError(Desc, "Please select a file.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, FilePath) = "" Then
                    .SetColumnError(Desc, "Please select a file.")
                    e.Valid = False
                Else
                    .SetColumnError(Desc, "")
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

#End Region

#Region "Medical Certificate"

    Private Function SaveMedCert(ByVal _CompanyID As String) As ArrayList
        Dim query As New ArrayList
        Dim DocStr As String = ""
        Dim count As Integer = 0
        With Me.MedicalView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    Dim dateIssued As String = ChangeToSQLDate(.GetRowCellValue(i, "DateIssue"))
                    Dim dateExpiry As String = ChangeToSQLDate(.GetRowCellValue(i, "DateExpiry"))

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument"), FormName, strID) 'neil   'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument").ToString.Replace("'", "''") & " : " & .GetRowCellValue(.FocusedRowHandle, "Number").ToString.Replace("'", "''"), FormName, strID)

                    If IfNull(.GetRowCellValue(i, "PKey"), "").Equals(CStr(i)) Then
                        query.Add("INSERT INTO dbo.tblDocument(" & _
                                  "FKeyIDNbr," & _
                                  "FileTag, " & _
                                  "FKeyDocument," & _
                                  "Number," & _
                                  "DateIssue," & _
                                  "DateExpiry," & _
                                  "IssuedBy," & _
                                  "IssuedPlace," & _
                                  "FKeyCntry," & _
                                  "isActive," & _
                                  "Remarks," & _
                                  "LastUpdatedBy)" & _
                                   "VALUES(" & _
                                   "'" & strID & "'" & _
                                   ",'" & .GetRowCellValue(i, "FileTag") & "'" & _
                                   ",'" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                   ",'" & .GetRowCellValue(i, "Number") & "'" & _
                                   "," & dateIssued & _
                                   "," & dateExpiry & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "'" & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "IssuedPlace")) & "'" & _
                                   "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                                   ",'" & .GetRowCellValue(i, "isActive") & "'" & _
                                   ",'" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        'query.Add("UPDATE dbo.tblDocument SET " & _
                        '          "FileTag = '" & .GetRowCellValue(i, "FileTag") & "'" & _
                        '          ",FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                        '          ",Number = '" & .GetRowCellValue(i, "Number") & "'" & _
                        '          ",DateIssue = " & dateIssued & _
                        '          ",DateExpiry =" & dateExpiry & _
                        '          ",IssuedBy = '" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "'" & _
                        '          ",IssuedPlace = '" & CleanInput(.GetRowCellValue(i, "IssuedPlace")) & "'" & _
                        '          ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                        '          ",isActive = '" & .GetRowCellValue(i, "isActive") & "'" & _
                        '          ",Remarks = '" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                        '          ",DateUpdated = (getdate())" & _
                        '          ",LastUpdatedBy = '" & .GetRowCellValue(i, "LastUpdatedBy") & "'" & _
                        '          " WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")

                        query.Add("UPDATE dbo.tblDocument SET " & _
                               "FileTag = '" & .GetRowCellValue(i, "FileTag") & "'" & _
                               ",FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                               ",Number = '" & .GetRowCellValue(i, "Number") & "'" & _
                               ",DateIssue = " & dateIssued & _
                               ",DateExpiry =" & dateExpiry & _
                               ",IssuedBy = '" & CleanInput(.GetRowCellValue(i, "IssuedBy")) & "'" & _
                               ",IssuedPlace = '" & CleanInput(.GetRowCellValue(i, "IssuedPlace")) & "'" & _
                               ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                               ",isActive = '" & .GetRowCellValue(i, "isActive") & "'" & _
                               ",Remarks = '" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                               ",DateUpdated = (getdate())" & _
                               ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                               " WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")

                    End If
                    '=================== Document Images ===================================
                    .BeginUpdate()
                    For x As Integer = 0 To .GetRelationCount(i) - 1
                        Dim wasExpanded As Boolean = .GetMasterRowExpandedEx(i, x)
                        If Not wasExpanded Then
                            .SetMasterRowExpandedEx(i, x, True)
                        End If
                        Dim child As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(.GetDetailView(i, x), DevExpress.XtraGrid.Views.Grid.GridView)
                        With child
                            .CloseEditForm()
                            .UpdateCurrentRow()
                            Dim childRH As Integer
                            For childRH = 0 To .RowCount - 1
                                If .GetRowCellValue(childRH, "Edited") Then
                                    'Insert
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical (Image)", 0, System.Environment.MachineName, CleanInput(.GetRowCellValue(childRH, "Description")).ToString.Replace("'", "''"), FormName, )
                                    If IfNull(.GetRowCellValue(childRH, "PKey"), "") = "" Then
                                        query.Add("INSERT INTO dbo.tblDocImage(FKeyIDNbr,FKeyCrewDocumentID,Description,FilePath,LastUpdatedBy)" & _
                                                  "VALUES(" & _
                                                  "'" & strID & "'" & _
                                                  ",'" & CleanInput(.GetRowCellValue(childRH, "FKeyCrewDocumentID")) & "'" & _
                                                  ",'" & CleanInput(.GetRowCellValue(childRH, "Description")) & "'" & _
                                                  "," & GetFilePathFileName(childRH, child) & _
                                                  ",'" & CleanInput(LastUpdatedBy) & "')")
                                    Else
                                        'update
                                        query.Add("UPDATE dbo.tblDocImage SET " & _
                                                  "Description = '" & CleanInput(.GetRowCellValue(childRH, "Description")) & "'" & _
                                                  ",FilePath =" & GetFilePathFileName(childRH, child) & _
                                                  ",FKeyCrewDocumentID='" & CleanInput(.GetRowCellValue(childRH, "FKeyCrewDocumentID")) & "'" & _
                                                  ",DateUpdated = getdate()" & _
                                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                                 "WHERE PKey = '" & CleanInput(IfNull(.GetRowCellValue(childRH, "PKey"), "")) & "'")
                                    End If
                                    If (Not IfNull(.GetRowCellValue(childRH, "FilePath"), "").ToString.Equals(IfNull(.GetRowCellValue(childRH, "FileName"), ""))) And Not IfNull(.GetRowCellValue(childRH, "FilePath"), "").ToString.Equals("") Then
                                        DocStr = IfNull(.GetRowCellValue(childRH, "FilePath"), "") & "|" & _
                                                 IfNull(.GetRowCellValue(childRH, "FileName"), "")
                                        count = count + 1
                                        DocumentList.Add(New Dictionary(Of Integer, String)() From {{count, DocStr}})
                                    End If
                                End If
                            Next
                        End With
                    Next
                    .EndUpdate()
                    '============= SUB Document ====================================================
                End If
            Next
        End With
        Return query
    End Function

    Private Sub MedicalView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MedicalView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                'Marks Actitive the Document if newly Added
                .SetRowCellValue(e.RowHandle, "Edited", True)
                If .GetRowCellValue(e.RowHandle, "PKey").Equals(System.DBNull.Value) And .GetRowCellValue(e.RowHandle, "isActive").Equals(System.DBNull.Value) Then
                    If Not e.Column.FieldName.Equals("isActive") Then
                        .SetRowCellValue(e.RowHandle, "isActive", True)
                    End If
                End If

                UpdateDateExpiry(sender, e, False)

            End If
        End With
    End Sub

    Private Sub MedicalView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles MedicalView.CustomUnboundColumnData
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

            If e.Column.FieldName = "File_Name" AndAlso e.IsGetData Then
                e.Value = strID & "_" & ft & "_" & di
            End If
        End With
    End Sub

    Private Sub MedicalView_GotFocus(sender As Object, e As System.EventArgs) Handles MedicalView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            'AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Medical Certificate")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub MedicalView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MedicalView.InitNewRow
        Dim CView As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        CView.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        CView.SetRowCellValue(e.RowHandle, "FKeyIDNbr", strID) 'Crew ID
        CView.SetRowCellValue(e.RowHandle, "PKey", _view.RowCount)
        SubAddMode = True
    End Sub

    Private Sub MedicalView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MedicalView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MedicalView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles MedicalView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MedicalView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MedicalView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.MedicalView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub MedicalView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MedicalView.RowCellStyle
        Dim strRequiredFieldName As String = "FKeyDocument;DateIssue;Number;"
        ViewRowCellStyle(sender, e, strRequiredFieldName)
    End Sub

    Private Sub MedicalView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MedicalView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MedicalView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles MedicalView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Documents Medical Certificates"
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

    Private Sub MedicalView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles MedicalView.ValidatingEditor
        ViewValidatingEditor(sender, e)

        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            With _view
                Select Case .FocusedColumn.FieldName
                    '<!-- edited by tony20170918, transferred to cellvaluechanged
                    'Case "FKeyDocument"
                    '    Dim DocCode As String = e.Value
                    '    If Not .GetRowCellValue(.FocusedRowHandle, "DateIssue").Equals(System.DBNull.Value) Then
                    '        Dim DateIssue As Date = .GetRowCellValue(.FocusedRowHandle, "DateIssue")
                    '        .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetMedicalDateExpiry(DocCode, DateIssue))
                    '    End If
                    'Case "DateIssue"
                    '    Dim DateIssue As Date = e.Value
                    '    If Not DateIssue.Equals(System.DBNull.Value) And Not .GetRowCellValue(.FocusedRowHandle, "FKeyDocument").Equals(System.DBNull.Value) Then
                    '        Dim DocCode As String = .GetRowCellValue(.FocusedRowHandle, "FKeyDocument")
                    '        .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetMedicalDateExpiry(DocCode, DateIssue))
                    '    End If
                    '-->
                End Select
            End With
            ViewValidatingEditor(sender, e)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MedicalView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MedicalView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Course As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyDocument")
        Dim tsNumber As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Number")
        Dim DateIssue As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateIssue")
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

            'Number
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

            'DateExpiry
            If .FocusedColumn.FieldName.Equals("DateExpiry") Then
                If Not .GetFocusedRowCellValue("DateIssue").Equals(System.DBNull.Value) And Not .GetFocusedRowCellValue("DateExpiry").Equals(System.DBNull.Value) Then
                    'If CDate(e.Value) >= CDate(.GetFocusedRowCellValue("DateIssue")) Then
                    '    .SetFocusedRowCellValue(.FocusedColumn, e.Value)
                    If CDate(.GetFocusedRowCellValue("DateExpiry")) >= CDate(.GetFocusedRowCellValue("DateIssue")) Then
                        .SetColumnError(.Columns("DateExpiry"), String.Empty)
                        .SetFocusedRowCellValue(.FocusedColumn, .GetFocusedRowCellValue("DateExpiry"))
                    Else
                        .SetColumnError(.Columns("DateExpiry"), "Invalid Date")
                    End If
                Else
                    .SetColumnError(.Columns("DateIssue"), "Invalid Date")
                End If
            End If

            If SubAddMode Then
                DocumentValidation(view, tsNumber, DateIssue, e)
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

    Private Function GetMedicalDateExpiry(DocumentCode As String, DateIssue As Date)
        Dim retval As Object = System.DBNull.Value
        Dim strValidity() As String
        Dim xYear As Integer = 0
        Dim xMonth As Integer = 0
        Dim xWeek As Integer = 0
        Dim xDays As Integer = 0
        Dim val As String = 0

        val = DB.DLookUp("Validity", "DocValidityMap", "", "PKey='" & DocumentCode & "'")

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

#Region "Medical Images Sub"

    Private Sub MedicalImageView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MedicalImageView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                TryCast(view.ParentView, DevExpress.XtraGrid.Views.Grid.GridView).SetRowCellValue(view.SourceRowHandle, "Edited", True)
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub MedicalImageView_GotFocus(sender As Object, e As System.EventArgs) Handles MedicalImageView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            'AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Medical Images")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub MedicalImageView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles MedicalImageView.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = view.ParentView 'Master View
        With view
            If e.Column.FieldName = "FileName" AndAlso e.IsGetData Then
                e.Value = MView.GetRowCellValue(view.SourceRowHandle, "File_Name") & "_" & e.ListSourceRowIndex.ToString
            End If
        End With
    End Sub

    Private Sub MedicalImageView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MedicalImageView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MedicalImageView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MedicalImageView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MedicalImageView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MedicalImageView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(View.ParentView, DevExpress.XtraGrid.Views.Grid.GridView)
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "FKeyCrewDocumentID", MView.GetRowCellValue(MView.SourceRowHandle, "PKey")) 'Crew Document ID
        'SubAddMode = True
    End Sub

    Private Sub MedicalImageView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MedicalImageView.RowCellStyle
        ViewRowCellStyle(sender, e, "")
    End Sub

    Private Sub MedicalImageView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MedicalImageView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FilePath As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FilePath")
        Dim Desc As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Description")

        With view
            'Number
            If .GetRowCellValue(e.RowHandle, FilePath) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FilePath) Is Nothing Then
                .SetColumnError(Desc, "Please select a file.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, FilePath) = "" Then
                    .SetColumnError(Desc, "Please select a file.")
                    e.Valid = False
                Else
                    .SetColumnError(Desc, "")
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

#End Region

#Region "Functions"

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
                                    'e.ErrorText = "Already in use."
                                    .SetColumnError(.FocusedColumn, "Already in use.")
                                Else
                                    .SetColumnError(.FocusedColumn, "")
                                End If
                            End If
                        Next
                    End If
                ElseIf .FocusedColumn.FieldName.Equals("DateExpiry") Then
                    If Not IsNothing(.GetFocusedRowCellValue("DateIssue")) Then
                        '<!-- tony20170918
                        '   to whoever coded this, why is the below if condition has invalid date columnerror if e.value (dateexpiry) is greater than or equal than the dateissue?
                        'If CDate(e.Value) >= CDate(.GetFocusedRowCellValue("DateIssue")) Then
                        If CDate(e.Value) >= CDate(.GetFocusedRowCellValue("DateIssue")) Then
                            '.SetColumnError(.Columns("DateExpiry"), "Invalid Date")
                            '-->
                            .SetFocusedRowCellValue(.FocusedColumn, e.Value)
                            e.Valid = True
                        Else
                            e.Valid = False
                            .SetColumnError(.Columns("DateExpiry"), "Invalid Date")
                        End If
                    Else
                        e.Valid = False
                        .SetColumnError(.Columns("DateIssue"), "Invalid Date")
                    End If
                Else
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
            Case "TravelDoc" 'Travel Documents
                view = Me.TravelDocView
            Case "LicCert" 'Certificates`
                view = Me.LicCertView
            Case "Medical" 'Medical
                view = Me.MedicalView
            Case "CompanyDefined"
                view = Me.CompanyDefinedView
        End Select

        Dim filePath As String = ""

        If Not IsNothing(view) Then
            Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = view.GetDetailView(view.FocusedRowHandle, 0)
            Dim fName As String = ""

            If Not IsNothing(vw) Then
                fName = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "FilePath"), "")
            End If

            If Not fName.Equals("") Then
                filePath = GenerateCrewFilePathDocument(strID, fName)
            End If

        End If

        Try
            System.Diagnostics.Process.Start(filePath)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        End Try

    End Sub

    'Create Buttons for file add
    Private Sub CreateButtons()
        'Travel
        Dim travelBtn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repBtnEditTravelDoc
        With travelBtn
            .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                                  "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                                  Nothing, Nothing, Nothing, Nothing))
            .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            AddHandler .ButtonPressed, AddressOf repButtonClick
        End With

        'Medical FilePath Button
        Dim MedCert As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repBtnEditMed
        With MedCert
            .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                                  "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                                  Nothing, Nothing, Nothing, Nothing))
            .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            AddHandler .ButtonPressed, AddressOf repButtonClick
        End With

        'Certificate FilePath Button
        Dim CertBtn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repBtnEditCert
        With CertBtn
            .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                                  "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                                  Nothing, Nothing, Nothing, Nothing))
            .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            AddHandler .ButtonPressed, AddressOf repButtonClick
        End With

        'Company Defined FilePath Button
        Dim CompDefBtn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = rptBtnCompDefined
        With CompDefBtn
            .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                      "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                      Nothing, Nothing, Nothing, Nothing))
            .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            AddHandler .ButtonPressed, AddressOf repButtonClick
        End With

    End Sub

    'Repository Button Click Event
    Private Sub repButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim _Parentview As DevExpress.XtraGrid.Views.Grid.GridView = focusedView.ParentView
        Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim bIndex As Integer = btn.Properties.Buttons.IndexOf(e.Button)
        'If _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey") = Nothing Then Return

        If Not IsNothing(_Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey")) Then
            If Not _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                If Not _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey").Equals(CStr(_Parentview.FocusedRowHandle)) Then
                    Select Case bIndex
                        Case 0 'Browse Button
                            Dim odMain As New System.Windows.Forms.OpenFileDialog
                            odMain.Filter = MPS4Functions.AttachDocument.GetAttachDocFilter()
                            If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                If btn.Text.Length = 0 Then
                                    btn.Text = odMain.SafeFileName
                                End If
                                focusedView.SetFocusedRowCellValue("FilePath", odMain.FileName.ToString)
                                BRECORDUPDATEDs = True
                            End If
                    End Select
                Else
                    MsgBox("Save First the Record(s).", MsgBoxStyle.Information, GetAppName)
                End If
            End If
        End If



    End Sub

    Private Sub AllowFilePathBtn(ByVal btn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, Optional ByVal value As Boolean = True)
        For i As Integer = 0 To btn.Buttons.Count - 1
            btn.Buttons(i).Enabled = value
        Next
        btn.ReadOnly = Not value
    End Sub

    Private Sub getSelectedView()
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "TravelDoc" 'Travel Document
                'Me.TravelDocView.Focus()
                SetDeleteCaption(Name, "Delete Travel Document")
            Case "LicCert" 'Certificates
                'Me.LicCertView.Focus()
                SetDeleteCaption(Name, "Delete Certificate")
            Case "Medical" 'Medical
                'Me.MedicalView.Focus()
                SetDeleteCaption(Name, "Delete Medical Certificate")
            Case "CompanyDefined"
                SetDeleteCaption(Name, "Delete Company Defined")
        End Select
    End Sub

#End Region

    Private Sub CrewSubDocImage(MainTblSQL As String, DocumentGroup As String, GridMain As DevExpress.XtraGrid.GridControl, _MainView As DevExpress.XtraGrid.Views.Grid.GridView, _SubView As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            Dim CrewDocDataSet As New DataSet
            Dim CrewDocument As New DataTable, CrewDocImage As New DataTable
            CrewDocument = DB.CreateTable(MainTblSQL)
            _MainView.OptionsDetail.AllowExpandEmptyDetails = True
            With CrewDocDataSet
                .Tables.Add(CrewDocument)
                .Tables(0).TableName = "CrewDoc"
                Dim CDUnq As UniqueConstraint = New UniqueConstraint(New DataColumn() {CrewDocument.Columns("PKey")}, True)
                .Tables("CrewDoc").Constraints.Add(CDUnq)
                GridMain.DataSource = .Tables("CrewDoc")
                CrewDocImage = DB.CreateTable("SELECT *, CAST(0 AS BIT) AS Edited FROM dbo.frmDocImage WHERE FKeyIDNbr='" & strID & "' AND FKeyDocGroup ='" & DocumentGroup & "'")
                .Tables.Add(CrewDocImage)
                .Tables(1).TableName = "CrewDocImg"
                Dim clmForeign As ForeignKeyConstraint = New ForeignKeyConstraint(New DataColumn() {CrewDocument.Columns("PKey")}, New DataColumn() {CrewDocImage.Columns("FKeyCrewDocumentID")})
                .Tables("CrewDocImg").Constraints.Add(clmForeign)
                .Relations.Add("DocImgRel", .Tables("CrewDoc").Columns("PKey"), .Tables("CrewDocImg").Columns("FKeyCrewDocumentID"))
                GridMain.LevelTree.Nodes.Add("DocImgRel", _SubView)
                _SubView.ViewCaption = "Document Images"
                _SubView.OptionsView.ShowGroupPanel = False
                _SubView.OptionsCustomization.AllowFilter = False
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub repFKeyDocument_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFKeyDocument.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub rtdFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rtdFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub rtdDateEdit_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rtdDateEdit.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub LicCertType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles LicCertType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub LicCertCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles LicCertCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub LicCertDateTime_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles LicCertDateTime.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub LicCertCapacity_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles LicCertCapacity.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub LicCertLimit_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles LicCertLimit.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub MedType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles MedType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub MedCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles MedCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub MedDate_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles MedDate.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub ResetControlOnEdit()
        ResetGridViewEdits(New DevExpress.XtraGrid.Views.Grid.GridView() {TravelDocView, LicCertView, MedicalView})
        RefreshData()
        'BRECORDUPDATEDs = False
    End Sub

    Private Sub MedicalView_ShownEditor(sender As Object, e As System.EventArgs) Handles MedicalView.ShownEditor
        SetMinMaxDateValidation(sender, e, "DateIssue", "DateExpiry")
        stopnaba = True
    End Sub

    Private Sub TravelDocGrid_Click(sender As Object, e As System.EventArgs) Handles TravelDocGrid.Click
        stopnaba = True
    End Sub

    Private Sub TravelDocGrid_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TravelDocGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub MedicalGrid_Click(sender As Object, e As System.EventArgs) Handles MedicalGrid.Click
        stopnaba = True
    End Sub

    Private Sub MedicalGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MedicalGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub LicCertGrid_Click(sender As Object, e As System.EventArgs) Handles LicCertGrid.Click
        stopnaba = True
    End Sub

    Private Sub LicCertGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LicCertGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub CompanyDefinedImageView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CompanyDefinedImageView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                TryCast(view.ParentView, DevExpress.XtraGrid.Views.Grid.GridView).SetRowCellValue(view.SourceRowHandle, "Edited", True)
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub CompanyDefinedView_GotFocus(sender As Object, e As System.EventArgs) Handles CompanyDefinedView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            'AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Company Defined")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub CompanyDefinedView_InitNewRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CompanyDefinedView.InitNewRow
        Dim CView As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        CView.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        CView.SetRowCellValue(e.RowHandle, "FKeyIDNbr", strID) 'Crew ID
        CView.SetRowCellValue(e.RowHandle, "PKey", _view.RowCount)
        SubAddMode = True
    End Sub

    Private Sub CompanyDefinedView_CellValueChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CompanyDefinedView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                'Marks Actitive the Document if newly Added
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'If .GetRowCellValue(e.RowHandle, "PKey").Equals(System.DBNull.Value) And .GetRowCellValue(e.RowHandle, "isActive").Equals(System.DBNull.Value) Then
                '    If Not e.Column.FieldName.Equals("isActive") Then
                '        .SetRowCellValue(e.RowHandle, "isActive", True)
                '    End If
                'End If
            End If
        End With
    End Sub

    Private Sub CompanyDefinedGrid_Click(sender As Object, e As System.EventArgs) Handles CompanyDefinedGrid.Click
        stopnaba = True
    End Sub

    Private Sub CompanyDefinedGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CompanyDefinedGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub CompanyDefinedView_ShownEditor(sender As Object, e As System.EventArgs) Handles CompanyDefinedView.ShownEditor
        SetMinMaxDateValidation(sender, e, "DateIssue", "DateExpiry")
        stopnaba = True
    End Sub

    Private Sub CompanyDefinedView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles CompanyDefinedView.CustomUnboundColumnData
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

            If e.Column.FieldName = "File_Name" AndAlso e.IsGetData Then
                e.Value = strID & "_" & ft & "_" & di
            End If
        End With
    End Sub

    Private Sub CompanyDefinedView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CompanyDefinedView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CompanyDefinedView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles CompanyDefinedView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CompanyDefinedView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CompanyDefinedView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.CompanyDefinedView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub CompanyDefinedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CompanyDefinedView.RowCellStyle
        Dim strRequiredFieldName As String = "FKeyComCompanyDefined"
        ViewRowCellStyle(sender, e, strRequiredFieldName)
    End Sub

    Private Sub CompanyDefinedView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CompanyDefinedView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CompanyDefinedImageView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles CompanyDefinedImageView.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = view.ParentView 'Master View
        With view
            If e.Column.FieldName = "FileName" AndAlso e.IsGetData Then
                e.Value = MView.GetRowCellValue(view.SourceRowHandle, "File_Name") & "_" & e.ListSourceRowIndex.ToString
            End If
        End With
    End Sub

    Private Sub CompanyDefinedImageView_GotFocus(sender As Object, e As System.EventArgs) Handles CompanyDefinedImageView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            'AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Company Defined")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub RepButton_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles riDateEdit.ButtonClick, RepCompDefined.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

End Class

