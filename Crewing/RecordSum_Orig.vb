Public Class RecordSum_Orig
    'Initialize Controls
    Dim is_clicked As Boolean = False, photo_changed As Boolean = False, photo_path As String
    Dim FormName As String = "Record Summary"
    'Dim LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Dim tabChanged As Boolean = False 'if tab is changed
    Dim PrevTab As String = ""
    Dim id As String = strID
    Dim selectedForArchive As Integer = 0

    Dim isLoadedFromCrewReassignment As Boolean = False 'Added by Tony20161025

    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        If Not isLoadedFromCrewReassignment Then Me.TabControl.SelectedTabPageIndex = 0 'Edited by Tony20161025
        picSize(GetUserSetting("Layout_BiodataPicView", "0"))
        'Dim tblCntry As DataTable = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC")
        repAddrStat.DataSource = GetAddStat()
        'repFKeyCntry.DataSource = tblCntry
        'travelCntry.DataSource = tblCntry
        'repMedCntry.DataSource = tblCntry
        'rNIFKeyCntry.DataSource = tblCntry
        'repAddrCity.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCity ORDER By Name ASC")
        'repAddrProv.DataSource = DB.CreateTable("SELECT * from dbo.tblAdmProvince ORDER BY Name ASC")
        'repRelRel.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRel ORDER BY Name ASC")
        'repRelSexCode.DataSource = GetSex()
        'Training Repository
        'Me.repTrainingCourse.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourse ORDER BY Name ASC")
        'Me.repTrainingCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCntry ORDER BY Name ASC")
        'Me.repTrainingCourseStat.DataSource = getCouseStatus()
        'Me.repTrainingCourseType.DataSource = getCourseType()
        'Me.repTrainingCourseInst.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourseInst ORDER BY Name ASC")
        'Me.repTrainingDoc.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCourseDocList")
        'Me.repTrainingLimit.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmLimit ORDER BY Name ASC")
        'Me.repTrainingCapacity.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCapacity ORDER BY Name ASC, SortCode ASC")
        'Me.repCurrency.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmCurr ORDER BY Name ASC")
    End Sub

    'Load data in the Sub tables/menu etc.
    Private Sub LoadSub()

        Try
            If tabChanged = False Then 'Prevent from loading crew info if when selected tab changed -Calvhin 20170113
                If Not isLoadedFromCrewReassignment Then blList.GetID() 'Edited by Tony20161026
                'Crew Information
                '===================================================
                Dim tblNameRank As New DataTable
                If (SelectedTab.Equals("ArchiveCrews")) Then
                    ClearData()
                    tblNameRank = DB.CreateTable("SELECT * FROM dbo.view_RecordSum_Arc WHERE FKeyIDNbr='" & strID & "'")
                    frmCrewMain.rpgViewArchivedReport.Visible = False
                Else
                    tblNameRank = DB.CreateTable("SELECT * FROM dbo.frm_RecordSum WHERE FKeyIDNbr='" & strID & "'")
                End If

                If tblNameRank Is Nothing Then
                    ClearData()
                    Return
                End If

                If tblNameRank.Rows.Count > 0 Then
                    For Each Items In tblNameRank.Rows
                        Me.txtCOIDNo.Text = Trim(IfNull(Items("COIDNo"), ""))
                        Me.txtHeight.EditValue = Trim(IfNull(Items("Height"), ""))
                        Me.txtWeight.EditValue = Trim(IfNull(Items("Weight"), ""))
                        Me.txtTeleFax.Text = Trim(IfNull(Items("TeleFax"), ""))
                        Me.txtPhone.Text = Trim(IfNull(Items("Phone"), ""))
                        Me.txtEmail.Text = Trim(IfNull(Items("Email"), ""))
                        Me.txtAirport.Text = Trim(IfNull(Items("Airport"), ""))

                        '<!--tony20160409
                        Me.txtNatCode.Text = Trim(IfNull(Items("Nat"), ""))

                        Me.txtRank.Text = Trim(IfNull(Items("RankName"), ""))
                        Me.txtManAgent.EditValue = Trim(IfNull(Items("AgentName"), ""))
                        GetCrewPhoto(Me.CrewPhoto, strID)
                        Me.txtLName.Text = Trim(IfNull(Items("LName"), ""))
                        Me.txtFName.Text = Trim(IfNull(Items("FName"), ""))
                        Me.txtMName.Text = Trim(IfNull(Items("MName"), ""))
                        Me.txtDOB.Text = Trim(IfNull(Items("DOB"), ""))

                        Me.txtStatus.Text = Trim(IfNull(Items("StatName"), ""))
                        Me.txtVsl.Text = Trim(IfNull(Items("VslName"), ""))
                        'Me.txtPrinName.Text = Trim(IfNull(Items("PrinName"), ""))
                        '-->
                    Next
                Else
                    ClearData()
                End If
            End If


            Select Case Me.TabControl.SelectedTabPage.Tag
                Case "Comments"
                    'Comments
                    Me.CommentGrid.DataSource = DB.CreateTable("SELECT * FROM " & IIf(SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "") & "dbo.tblComment WHERE FKeyIDNbr = '" & strID & "' ORDER BY DateUpdated DESC")
                Case "TravelDoc"
                    'Travel Documents
                    Me.TravelDocGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_TravelDoc" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strID & "' ORDER BY DateIssue DESC,Document ASC")
                Case "LicCert"
                    'Certificates
                    Me.CertGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_LicCert" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strID & "'  ORDER BY DateIssue DESC,Document ASC")
                Case "MedCert"
                    'Medical Certificates
                    Me.MedCertGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_MedCert" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strID & "'  ORDER BY DateIssue DESC,Document ASC")
                Case "Course"
                    Me.TrainingView.Focus()
                    IniTrainingViewRepositories()
                    CreateTrainingSubGrid()
                Case "NatInfo"
                    'National Information
                    Me.NatInfoGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_NatInfo" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strID & "'  ORDER BY DateIssue DESC,Document ASC")
                Case "Addr"
                    Me.AddrGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_Addr" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strID & "'")
                Case "Relatives"
                    Me.RelativeGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_Allottee" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr='" & strID & "'")
                Case "Activity"
                    Me.ActivityGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_Activity" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strID & "'")
                Case "SeaService"
                    Me.SeaServGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM Crewlist_Activities_All" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE  IDNbr='" & strID & "' AND ActivityType='SEA' " & _
                                               "ORDER BY DateStarted DESC")
                Case "OtherSeaService"
                    Me.OtherGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 as BIT) AS Edited FROM Crewlist_Activities_Other WHERE IDNbr='" & strID & "' ORDER BY ActDateStart DESC")
            End Select
            tabChanged = False 'Added By Calvhin

        Catch ex As Exception
            ClearData()
        End Try
    End Sub

    Private Sub IniTrainingViewRepositories()
        Me.repTrainingCourse.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourse ORDER BY Name ASC")
        Me.repTrainingCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCntry ORDER BY Name ASC")
        Me.repTrainingCourseStat.DataSource = getCouseStatus()
        Me.repTrainingCourseType.DataSource = getCourseType()
        Me.repTrainingCourseInst.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourseInst ORDER BY Name ASC")
        Me.repTrainingDoc.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCourseDocList")
        Me.repTrainingLimit.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmLimit ORDER BY Name ASC")
        Me.repTrainingCapacity.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCapacity ORDER BY Name ASC, SortCode ASC")
        Me.repCurrency.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmCurr ORDER BY Name ASC")
    End Sub

    'Refresh
    Public Overrides Sub RefreshData()
        'ButtonConfig()

        selectedForArchive = CrewList.selectedCrewForArchive


        If Not bLoaded Then 'Prevent lookup edit to reload data source 
            'Moved from outside this "If" -Calvhin 20170113
            strRequiredFields = "txtLName;txtFName;cboSexCode;cboDOB;cboNatCode;cboFKeyCivilStat;cboHireStatCode"
            MyBase.RefreshData()
            SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetPrintBiodataVisiblity(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetPrintListCaption(Name, "Print Biodata")
            SetEditOptionsVisibility(Name, False)
            'End Calvhin

            initControls()
            'LoadSub()
            bLoaded = True
        End If
        'If blList.GetID() = "" Then
        '    AddData()
        'Else
        '    LoadSub()
        '    MakeReadOnlyListener(Me.CrewInfo)
        '    BRECORDUPDATEDs = False
        'End If
        'edited by tony20161219
        If Not IsNothing(blList) Then
            strID = blList.GetID()
            If strID = "" Then 'Before:  blList.GetID() = "" - Calvhin 20170113
                'AddData()
            Else
                tabChanged = False
                LoadSub()
                MakeReadOnlyListener(Me.CrewInfo)
                BRECORDUPDATEDs = False
            End If
        Else
            tabChanged = False
            LoadSub()
            MakeReadOnlyListener(Me.CrewInfo)
            BRECORDUPDATEDs = False
        End If
        'end tony
        EditSubAllowGrid(Me.TrainingView, False)
        EditSubAllowGrid(Me.TrainingSub, False)
        ''Put Security Here
        'Select Case Me.TabControl.SelectedTabPage.Tag
        '    Case "Comments" 'Comments
        '        SetEditOptionsVisibility(Name, True)
        '        SetEditCaption(Name, "Add Comment")
        '    Case Else
        '        SetEditOptionsVisibility(Name, False)
        'End Select
    End Sub

    'Load (Used By Crew Reassignment form)
    Public Sub LoadData(ByVal cIDNbr As String)
        'ButtonConfig()
        'Me.header.Text = IIf(strDesc = "New Record", strDesc, "Record Summary - " & strDesc)
        isLoadedFromCrewReassignment = True
        strID = cIDNbr
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPrintBiodataVisiblity(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetPrintListCaption(Name, "Print Biodata")
        SetEditOptionsVisibility(Name, False)

        If Not bLoaded Then 'Prevent lookup edit to reload data source 
            initControls()
            'LoadSub()
            bLoaded = True
        End If
        LoadSub()
        MakeReadOnlyListener(Me.CrewInfo)
        BRECORDUPDATEDs = False

        EditSubAllowGrid(Me.TrainingView, False)
        EditSubAllowGrid(Me.TrainingSub, False)
    End Sub

    'Save
    Public Overrides Sub SaveData()
        'Me.header.Focus()
        'Dim info As Boolean = False

        'If ValidateFields(New DevExpress.XtraEditors.TextEdit() {}) Then
        '    Select Case IIf(tabChanged, PrevTab, Me.TabControl.SelectedTabPage.Tag)
        '        Case "Comments" 'Comments
        '            info = DB.RunSqls(SaveComments())
        '    End Select
        '    tabChanged = False

        '    If info Then
        '        MsgBox("Record Inserted")
        '        blList.RefreshData()
        '        blList.SetSelection(id)
        '        RefreshData()
        '    End If
        'End If
    End Sub

    'Edit Data
    Public Overrides Sub EditData()
        'MyBase.EditData()
        'If isEditdable Then
        '    Select Case Me.TabControl.Tag
        '        Case "Comments"
        '            EditSubAllowGrid(CommentView, isEditdable)
        '            CommentView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        '        Case Else

        '    End Select
        'Else
        '    Select Case Me.TabControl.Tag
        '        Case "Comments"
        '            EditSubAllowGrid(CommentView, isEditdable)
        '            CommentView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        '        Case Else

        '    End Select
        'End If
    End Sub

    Public Overrides Sub DeleteData()
        'MyBase.DeleteData()
        'Dim info As Boolean = False
        'If MsgBox("Are you sure, you want to delete Crew '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
        '    If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
        '        info = DB.RunSql("DELETE FROM dbo.tblComment WHERE PKey='" & strID & "'")
        '        If info Then
        '            ClearFields(Me.LayoutControl1.Root, False)
        '            MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
        '            RefreshData()
        '            blList.RefreshData()
        '            BRECORDUPDATEDs = False
        '        End If
        '    Else
        '        MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
        '        BRECORDUPDATEDs = False
        '    End If
        'End If
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        AllowSaving(Name, False)
        Select Case param(0)
            Case "DeleteOther"
                'DeleteSubItem()
            Case "ViewData"
                ViewData()
            Case "ClearContent"
                ClearContent()
            Case "LoadData"
                LoadData(param(1))
            Case "InitTabs"
                InitTabs(param(1))
        End Select
    End Sub

    Private Sub ViewData()
        Dim view As New DevExpress.XtraGrid.Views.Grid.GridView
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "TravelDoc" 'National Information
                view = Me.TravelDocView
            Case "LicCert"
                view = Me.CertView
            Case "MedCert"
                view = Me.MedCertView
            Case "Course"
                'view = Me.CourseView
            Case "NatInfo"
                view = Me.NatInfoView
            Case Else
                view = Nothing
        End Select

        If Not IsNothing(view) Then
            With view
                Dim filePath As String = ""
                If .FocusedRowHandle >= 0 Then filePath = GenerateCrewFilePath(.GetRowCellValue(.FocusedRowHandle, "FileName").ToString)
                Try
                    System.Diagnostics.Process.Start(filePath)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
                End Try
            End With
        End If
    End Sub

    Private Sub ClearContent()
        strID = ""
        Me.header.Text = "Record Summary"
        ClearFields(Me.CrewInfo, False)
        LoadSub()
    End Sub

#Region "Comments"
    Private Function SaveComments() As ArrayList
        Dim query As New ArrayList
        With Me.CommentView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblComment(FKeyIDNbr,Comment,ComDate,ComBy,FilePath,LastUpdatedBy)" & _
                                   "VALUES('" & strID & "'" & _
                                   ",'" & .GetRowCellValue(i, "Comment") & "'" & _
                                   ",'" & .GetRowCellValue(i, "ComDate") & "'" & _
                                   ",'" & .GetRowCellValue(i, "ComBy") & "'" & _
                                   ",'" & .GetRowCellValue(i, "FilePath") & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblComment SET " & _
                                  "Comment = '" & .GetRowCellValue(i, "Comment") & "'" & _
                                  ",ComDate = '" & .GetRowCellValue(i, "ComDate") & "'" & _
                                  ",ComBy = '" & .GetRowCellValue(i, "ComBy") & "'" & _
                                  ",FilePath = '" & .GetRowCellValue(i, "FilePath") & "'" & _
                                  ",DateUpdated = '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub CommentView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CommentView.CellValueChanged
        BRECORDUPDATEDs = True
        bAddMode = True
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.CommentView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub CommentView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CommentView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyIDNbr"), strID)
        View.SetRowCellValue(e.RowHandle, View.Columns("ComBy"), GetUserName)
    End Sub

    Private Sub CommentView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CommentView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CommentView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CommentView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.CommentView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub CommentView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CommentView.RowCellStyle
        If Me.CommentView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.CommentView.GetRowCellValue(e.RowHandle, "Edited") And Me.CommentView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.CommentView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.CommentView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub CommentView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CommentView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'insert validations here
    End Sub

#End Region

#Region "Training / Course"
    Dim dtMain As New DataTable 'Main Table (Course)
    Dim dtSub As New DataTable 'Sub Table (LicCert)
    'Create Sub Grid
    Private Sub CreateTrainingSubGrid()
        Dim ds2 As New DataSet
        Try
            dtMain = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_Training" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr='" & strID & "' ORDER BY Course ASC")
            dtSub = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_Training_SubDoc" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr='" & strID & "'")

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
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return
        End Try
    End Sub

    Private Sub TrainingView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles TrainingView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#Region "Sub Training"
    Private Sub TrainingSub_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles TrainingSub.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub
#End Region

#End Region

#Region "Travel Documents"
    Private Sub TravelDocView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles TravelDocView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub
#End Region

#Region "Certificates"
    Private Sub CertView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CertView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub
#End Region

#Region "Medical Certificate"
    Private Sub MedCertView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MedCertView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub
#End Region

#Region "National Information"
    Private Sub NatInfoView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles NatInfoView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub
#End Region

#Region "Address"
    Private Sub AddrView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AddrView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub
#End Region

#Region "Relatives"
    Private Sub RelativeView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles RelativeView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub
#End Region

    Private Sub TabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabControl.SelectedPageChanged
        If BRECORDUPDATEDs Then
            If MsgBox("Would you like to save the changes you made on " & GetDesc() & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                tabChanged = True
                SaveData()
            Else
                RefreshData()
            End If
        Else
            tabChanged = True 'Added By Calvhin
            LoadSub()
        End If
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "NameRank" 'NameRank
                SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                SetEditCaption(Name, "Edit")
            Case Else
                SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetEditCaption(Name, "Add/Edit")
        End Select
    End Sub

    Private Sub GetCrewPhoto(_PictureEdit As DevExpress.XtraEditors.PictureEdit, _CrewIDNbr As String)
        Try
            'CrewPhoto.Image = New System.Drawing.Bitmap(Trim(IfNull(Items("PhotoPath"), "")))
            Dim _path = GetCrewPhotoPath(_CrewIDNbr)
            If Not IsNothing(_path) Then
                _PictureEdit.Image = ImageFromStream(_path)
            Else
                _PictureEdit.Image = Nothing
            End If
        Catch ex As Exception
            _PictureEdit.Image = Nothing
        End Try
    End Sub

    Private Function GetCrewPhotoPath(_CrewIDNbr As String)
        Dim retval As String = Nothing
        Try
            Dim ImagePath As String = FOLDERDIRECTORY & "\" & _CrewIDNbr & "\" & _CrewIDNbr & "_IMAGE"
            'Dim FileName As String = _CrewIDNbr & "_IMAGE"
            If System.IO.File.Exists(ImagePath & ".jpg") Then
                ImagePath = ImagePath & ".jpg"
            ElseIf System.IO.File.Exists(ImagePath & ".png") Then
                ImagePath = ImagePath & ".png"
            Else
                ImagePath = Nothing
            End If
            retval = ImagePath
        Catch ex As Exception
            retval = Nothing
        End Try
        Return retval
    End Function

    Private Sub getSelectedView()
        'Select Case Me.TabControl.SelectedTabPage.Tag
        '    Case "NameRank"
        '        SetDeleteCaption(Name, "Delete Crew")
        '        AllowDeletion(Name, True)
        '        focusedView = Nothing
        '    Case "Addr"
        '        'Me.AddrView.Focus()
        '        SetDeleteCaption(Name, "Delete Address")
        '        focusedView = AddrView
        '    Case "NatInfo"
        '        'Me.NatInfoView.Focus()
        '        SetDeleteCaption(Name, "Delete National Information")
        '        focusedView = NatInfoView
        '    Case "Comments"
        '        'Me.CommentView.Focus()
        '        SetDeleteCaption(Name, "Delete Comment")
        '        focusedView = CommentView
        '    Case "FormerComp"
        '        'Me.FormerCompView.Focus()
        '        SetDeleteCaption(Name, "Delete Former Company")
        '        focusedView = FormerCompView
        'End Select
        'If Not IsNothing(focusedView) Then
        '    focusedView.Focus()

        'End If
    End Sub

    Private Sub picSize(ByVal view As Integer)
        'While (Not view > 5) Or (Not view < 0)
        Select Case view
            Case 0 'default
                Me.CrewPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
            Case 1
                Me.CrewPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
            Case 2
                Me.CrewPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip
            Case 3
                Me.CrewPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.StretchHorizontal
            Case 4
                Me.CrewPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.StretchVertical
            Case 5
                Me.CrewPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
                'Case Else
                '    view = 0
        End Select
        'End While

    End Sub

#Region "Crew Reassignment"
    Private Sub InitTabs(Optional ByVal nMode As String = "CREWLIST")
        Select Case nMode
            Case "CREWREASSIGNMENT"
                lcgAddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never     'hide address
                lcgRelatives.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never    'hide relatives
                lcgActivity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                TabControl.SelectedTabPage = lcgActivity
        End Select
    End Sub
#End Region

    Private Sub header_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles header.MouseMove

    End Sub

    Public Overrides Sub ClearData()
        Me.txtCOIDNo.Text = ""
        Me.txtNatCode.Text = ""
        Me.txtHeight.EditValue = ""
        Me.txtWeight.EditValue = ""
        Me.txtTeleFax.Text = ""
        Me.txtPhone.Text = ""
        Me.txtEmail.Text = ""
        Me.txtAirport.Text = ""
    End Sub
End Class
