Public Class Biodata
#Region "Functions"


    'get the FileTag
    Private Function getFileTag(ByVal _id As String) As String
        Return DB.DLookUp("FileTag", "dbo.tblAdmDocument", "0", "PKey='" & _id & "'")
    End Function

    'View Data
    Private Sub ViewData()

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "NatInfo" 'Travel Documents
                view = Me.NatInfoView
                'Case "LicCert" 'Certificates
                '    view = Me.LicCertView
                'Case "Educ" 'Education
                '    view = Me.EducView
                'Case "Medical" 'Medical
                '    view = Me.MedicalView
                'Case "Training"
                '    view = Me.TrainingSub

        End Select
        Dim filePath As String = ""

        'If Not IsNothing(view) Then
        '    Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = view.GetDetailView(view.FocusedRowHandle, 0)
        '    Dim fName As String = ""

        '    If Not IsNothing(vw) Then
        '        fName = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "FilePath"), "")
        '    End If

        '    filePath = GenerateCrewFilePath(fName)

        'End If

        'Try
        '    System.Diagnostics.Process.Start(filePath)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        'End Try


        If Not IsNothing(view) Then
            Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = view.GetDetailView(view.FocusedRowHandle, 0)
            Dim fName As String = ""

            If Not IsNothing(vw) Then
                fName = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "FilePath"), "")
            End If

            If Not fName.Equals("") Then
                filePath = GenerateCrewFilePath(fName)
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
        'National Information
        Dim NatInfoBtn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repNatInfoBtnEdt
        NatInfoBtn.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                                          "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                                          Nothing, Nothing, Nothing, Nothing))
        'NatInfoBtn.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
        '                                                                  "Delete", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
        '                                                                  Nothing, Nothing, Nothing, Nothing))
        NatInfoBtn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        AddHandler NatInfoBtn.ButtonPressed, AddressOf repButtonClick

    End Sub

    'Repository Button Clicked
    Private Sub repButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim _Parentview As DevExpress.XtraGrid.Views.Grid.GridView = focusedView.ParentView
        Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim bIndex As Integer = btn.Properties.Buttons.IndexOf(e.Button)
        If Not _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
            If Not _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey").Equals(CStr(_Parentview.FocusedRowHandle)) Then
                Select Case bIndex
                    Case 1 'Browse Button
                        Dim odMain As New System.Windows.Forms.OpenFileDialog
                        odMain.Filter = MPS4Functions.AttachDocument.GetAttachDocFilter()
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

#End Region 'Function

#Region "Data Source"
    'generate Company ID
    Private Function getCOIDNo() As String
        Return Trim(IfNull(blList.GetFocusedRowData("COIDNo"), ""))
    End Function

    'get the Old Comnpany Id
    'Private Function getOldCOIDNo() As String
    '    Return Trim(IfNull(blList.GetFocusedRowData("OldCOIDNo"), ""))
    'End Function

   
#End Region

    Dim is_clicked As Boolean = False, photo_changed As Boolean = False, photo_path As String
    Dim FormName As String = "Crew Biodata"
    'Dim LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Dim tabChanged As Boolean = False 'if tab is changed
    Dim PrevTab As String = "" 'the previous tab Tag
    Dim id As String = strID
    Dim picview As Integer
    Dim viewFocus As String
    Dim type As String = "" 'Used for message
    Dim ctrlList As DevExpress.XtraEditors.TextEdit() 'Require Controls List
    Dim DocumentList As New List(Of Dictionary(Of Integer, String))()
    Dim strPhotoPath As String = ""

    Dim clsgridflout As New clsGridFlyOut
    Dim stopnaba As Boolean = False
    Dim clsCrewConflict As New clsCrewConflict


#Region "Biodata"
    'Initialize Controls
    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        Me.TabControl.SelectedTabPage = tabNameAndRank
        'blList.PicView = CInt(DB.DLookUp("PicViewStyle", "tblUserLayout", "0", "FKeyIDNbr='" & USER_ID & "' AND ObjectID='Biodata'"))
        picSize(GetUserSetting("Layout_BiodataPicView", "0"))
        Dim tblCntry As DataTable = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC, SortCode ASC")

        'Name and Rank
        Me.cboFKeyRank.Properties.DataSource = DB.CreateTable("SELECT PKey,Name,Abbrv FROM dbo.tblAdmRank Order By SortCode, Name ASC")
        cboSexCode.Properties.DataSource = GetSex()
        cboNatCode.Properties.DataSource = tblCntry
        cboFKeyCivilStat.Properties.DataSource = getCivilStatus()
        cboLangAbilityCode.Properties.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tbladmLang ORDER BY Name") 'SortCode")
        cboHireStatCode.Properties.DataSource = GetHireStat()
        cboLangLevelCode.Properties.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRate ORDER BY SortCode")
        'unfiltered: cboFKeyAgent.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.ManAgentList")
        cboFKeyAgent.Properties.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Agent)
        cboFKeyWageScale.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWscale ORDER BY Name,SortCode ASC")
        cboEmpTypeCode.Properties.DataSource = getEmpType()

        'Address Tab
        ReloadCntry()
        ReloadProvince()
        ReloadCity()
        repAddrStat.DataSource = GetAddStat()
        repFKeyAirport.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmAirport ORDER BY Name ASC")
        'repFKeyCntry.DataSource = tblCntry

        'National Infromation Tab
        repFKeyNatInfo.DataSource = DB.CreateTable("SELECT * FROM dbo.DocumentList WHERE FKeyDocGroup='SYSNATINFO' ORDER BY Name ASC")
        rNIFKeyCntry.DataSource = tblCntry
        AddUnboundColumn(Me.NatInfoView, NatInfoGrid, "File_Name", "File Name", False) 'add unbound Column
        AddUnboundColumn(Me.NatInfoImages, NatInfoGrid, "FileName", "FileName", False)


        'Former Company
        rFCFKeyRank.DataSource = DB.CreateTable("SELECT * FROM dbo.RankList ORDER BY SortCode ASC, Name ASC")

        'Initialize Repository 
        CreateButtons()

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
    End Sub

    'Load data in the Sub tables/menu etc.
    Private Sub LoadSub()
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "NameRank"
                RefreshWageScaleRank()
                'Name and Rank
                Dim tblNameRank As DataTable
                'tblNameRank = DB.CreateTable("SELECT *,FORMAT(DOB,'MM/dd/yyyy','en-US') AS FDOB FROM dbo.tblCrewInfo WHERE PKey='" & strID & "'")
                tblNameRank = DB.CreateTable("SELECT *,FORMAT(DOB,'MM/dd/yyyy','en-US') AS FDOB FROM dbo.frm_RecordSum WHERE FKeyIDNbr='" & strID & "'")
                For Each Items In tblNameRank.Rows
                    Me.txtCOIDNo.Text = IfNull(Items("COIDNo"), "")
                    Me.txtLName.Text = IfNull(Items("LName"), "")
                    Me.txtFName.Text = IfNull(Items("FName"), "")
                    Me.txtMName.Text = IfNull(Items("MName"), "")
                    Me.txtNickName.Text = IfNull(Items("NickName"), "")
                    Me.cboSexCode.EditValue = IfNull(Items("SexCode"), "")
                    Me.cboDOB.Text = Trim(IfNull(Items("FDOB"), ""))
                    Me.txtPOB.Text = Trim(IfNull(Items("POB"), ""))
                    Me.txtReligion.Text = Trim(IfNull(Items("Religion"), ""))
                    Me.cboNatCode.EditValue = Trim(IfNull(Items("NatCode"), ""))
                    Me.cboFKeyCivilStat.EditValue = Trim(IfNull(Items("FKeyCivilStat"), ""))
                    Me.cboLangAbilityCode.EditValue = Trim(IfNull(Items("LangAbilityCode"), ""))
                    Me.cboLangLevelCode.EditValue = Trim(IfNull(Items("LangLevelCode"), ""))
                    Me.cboHireStatCode.EditValue = CType(IfNull(Items("HireStatCode"), 0), Int16)
                    Me.cboEmpTypeCode.EditValue = CType(Trim(IfNull(Items("EmpTypeCode"), "")), String)
                    Me.txtTeleFax.Text = Trim(IfNull(Items("TeleFax"), ""))
                    Me.txtPhone.Text = Trim(IfNull(Items("Phone"), ""))
                    Me.txtEmail.Text = Trim(IfNull(Items("Email"), ""))
                    strPhotoPath = IfNull(Items("PhotoPath"), "")
                    'GetCrewPhoto(Me.CrewPhoto, strID, strPhotoPath) 'Photo Path
                    Me.txtVslName.EditValue = CType(Trim(IfNull(Items("VslName"), "")), String)
                    Me.txtPrinName.EditValue = CType(Trim(IfNull(Items("PrinName"), "")), String)
                    Me.cboFKeyRank.EditValue = Trim(IfNull(Items("FKeyRankCode"), ""))
                    Me.cboFKeyAgent.EditValue = Trim(IfNull(Items("FKeyAgentCode"), ""))

                    Me.txtHeight.EditValue = Trim(IfNull(Items("Height"), ""))
                    Me.txtWeight.EditValue = Trim(IfNull(Items("Weight"), ""))

                    '<!-- added by tony20171125
                    'edited by tony20180505
                    '   added Blood, HairColor, EyeColor, BMI
                    Dim dt As DataTable = MPSDB.CreateTable("SELECT ShoeSize, CoverallSize, PoloSize, PantsSize, Blood, HairColor, EyeColor FROM dbo.tblcrewinfo WHERE PKey = '" & strID & "'")
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        Me.txtShoeSize.EditValue = Trim(IfNull(row("ShoeSize"), ""))
                        Me.txtCoverallSize.EditValue = Trim(IfNull(row("CoverallSize"), ""))
                        Me.txtPoloSize.EditValue = Trim(IfNull(row("PoloSize"), ""))
                        Me.txtPantsSize.EditValue = Trim(IfNull(row("PantsSize"), ""))

                        '<!-- added by tony20180505
                        Me.txtBlood.EditValue = Trim(IfNull(row("Blood"), ""))
                        Me.txtHairColor.EditValue = Trim(IfNull(row("HairColor"), ""))
                        Me.txtEyeColor.EditValue = Trim(IfNull(row("EyeColor"), ""))
                        RefreshBMIField()
                        '-->
                    Else
                        Me.txtShoeSize.EditValue = ""
                        Me.txtCoverallSize.EditValue = ""
                        Me.txtPoloSize.EditValue = ""
                        Me.txtPantsSize.EditValue = ""
                    End If
                    '-->

                Next
                Me.cboFKeyWageScale.EditValue = IfNull(blList.GetFocusedRowData("FkeyWScaleCode"), "")
                Me.cboFKeyWageScaleRank.EditValue = IfNull(blList.GetFocusedRowData("FKeyWScaleRankCode"), "")
                'below code inserted by tony20170712
                GetCrewPhoto(Me.CrewPhoto, strID, strPhotoPath) 'GET CREW PHOTO
            Case "Addr"
                'Address Tab
                Me.AddrGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_Addr WHERE FKeyIDNbr = '" & strID & "'")
                EditSubAllowGrid(AddrView, False)

            Case "NatInfo"
                'National Information
                'Me.NatInfoGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCrew_NatInfo WHERE FKeyIDNbr = '" & strID & "' ORDER BY Document ASC")
                CrewSubDocImage("SELECT * FROM dbo.frmCrew_NatInfo WHERE FKeyIDNbr = '" & strID & "' ORDER BY Document ASC",
                                "SYSNATINFO", NatInfoGrid, NatInfoView, NatInfoImages)
                EditSubAllowGrid(Me.NatInfoView, False)
            Case "Comments"
                'Comments
                Dim tblComment As DataTable
                tblComment = DB.CreateTable("SELECT * FROM dbo.frmCrew_Comment WHERE FKeyIDNbr = '" & strID & "' ORDER BY ComDate DESC")
                Me.CommentGrid.DataSource = tblComment
                EditSubAllowGrid(CommentView, False)
            Case "FormerComp"
                'Former Company
                Dim tblPrevCo As DataTable
                tblPrevCo = DB.CreateTable("SELECT * FROM dbo.frmCrew_PrevCo WHERE FKeyIDNbr = '" & strID & "'")
                Me.FormerCompGrid.DataSource = tblPrevCo
                EditSubAllowGrid(FormerCompView, False)
            Case "CrewConflict"
                'Conflict Crew
                Dim tblCrewConflict As DataTable
                tblCrewConflict = DB.CreateTable("Select *,CAST(0 AS bit) AS Edited from dbo.tblCrewConflict WHERE FKeyIDNbr = '" & strID & "' ORDER BY CConflictName")
                Me.gridCrewConflict.DataSource = tblCrewConflict
                EditSubAllowGrid(CrewConflictView, False)

        End Select
        'EditData()
        BRECORDUPDATEDs = False
    End Sub

    'Refresh
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        'AllowSaving(Name, False)
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Personal Information Details - " & strDesc)
        TableName = "tblCrewInfo"
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetPrintBiodataVisiblity(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        getSelectedView()
        id = strID

        'Editable Required Controls
        strRequiredFields = "txtLName;txtFName;cboSexCode;cboDOB;cboNatCode;cboFKeyCivilStat;cboHireStatCode;cboFKeyRank;cboFKeyAgent;txtPOB;"
        ctrlList = {txtLName, txtFName, cboSexCode, cboDOB, txtPOB, cboNatCode, cboFKeyCivilStat, cboHireStatCode, cboFKeyRank, cboFKeyAgent}


        SetAddCaption(Name, "Add New Crew")
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPrintListCaption(Name, "Print Biodata")
        SetDeleteCaption(Name, "Delete Crew")

        If Not bLoaded Then 'Prevent lookup edit to reload data source 
            bLoaded = True
            initControls()
            Me.TabControl.SelectedTabPageIndex = 0 'Select the First Tab in Loading
            PrevTab = Me.TabControl.SelectedTabPage.Tag
            'LoadSub()  'commented out by tony20170712, redundant to the one found on below
        End If

        If blList.GetID() = "" Then
            'AddData()
            AllowEditing(Name, False)
            ClearContent()
            TabControl.SelectedTabPageIndex = 0
        Else
            AllowEditing(Name, True)
            LoadSub()
            MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgActInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo})
            BRECORDUPDATEDs = False
        End If

        'added by tony20170712, inserted previous codes into procedure: UpdateListeners()
        UpdateListeners()
        'below code commented out by tony20170712, moved in LoadSub -> NameAndRank Case
        'GetCrewPhoto(Me.CrewPhoto, strID, strPhotoPath) 'GET CREW PHOTO


        'isEditdable = False
        AllowDeletion(Name, True)
        setButtonEdit(False)
        getSelectedView()
        ClearViewError(New DevExpress.XtraGrid.Views.Grid.GridView() {AddrView, NatInfoView, FormerCompView, CommentView, CrewConflictView})


        EditSubAllowGrid(NatInfoView, False)
        EditSubAllowGrid(NatInfoImages, False)
        AllowFilePathBtn(repNatInfoBtnEdt, False)

        EditSubAllowGrid(CrewConflictView, False)
        repCrewConflict.Buttons(0).Enabled = False
        repCrewConflict.Buttons(1).Enabled = False
    End Sub

    Private Sub UpdateListeners()
        'added by tony20170712
        AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgActInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo})
        If Not bAddMode Then
            RemoveEditListener(txtPrinName)
            RemoveEditListener(txtVslName)
            RemoveEditListener(cboFKeyWageScale)
            RemoveEditListener(cboFKeyWageScaleRank)
            RemoveEditListener(txtBMI)
        Else
            For Each item As DevExpress.XtraEditors.TextEdit In ctrlList
                ReadOnlyListener(item, True)
            Next
            MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgActInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo})
        End If
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim CompanyID As String = Trim(IfNull(blList.GetFocusedRowData("COIDNo"), ""))
        Dim info As Boolean = False
        Dim query As New ArrayList
        type = ""

        Select Case IIf(tabChanged, PrevTab, Me.TabControl.SelectedTabPage.Tag)
            Case "NameRank" 'Name and Rank
                'If ValidateFields(ctrlList) Then
                '    If bAddMode Then
                '        Dim InstCriteria As String = "LName='" & txtLName.Text & "' AND FName = '" & txtFName.Text & "'" & _
                '                                    "MName='" & txtMName.Text & "' AND DOB= '" & ChangeToSQLDate(CDate(cboDOB.Text).ToString("yyyy-MM-dd")) & "'"
                '        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtLName, txtMName, txtFName, cboDOB}, InstCriteria) Then
                '            Exit Sub
                '        Else
                '            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtCOIDNo}) Then
                '                Exit Sub
                '            Else
                '                info = SaveNewCrew()
                '                type = "Inserted"
                '            End If
                '        End If
                '    Else
                '        id = strID
                '        Dim UPDCriteria As String = " PKey <> '" & strID & "' AND LName='" & txtLName.Text & "' AND FName = '" & txtFName.Text & "'" & _
                '                                    "MName='" & txtMName.Text & "' AND DOB= '" & ChangeToSQLDate(CDate(cboDOB.Text).ToString("yyyy-MM-dd")) & "'"
                '        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtLName, txtMName, txtFName, cboDOB}, UPDCriteria) Then
                '            Exit Sub
                '        Else
                '            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtCOIDNo}, "PKey<>'" & strID & "'") Then
                '                Exit Sub
                '            Else
                '                'info = DB.RunSql(GenerateUpdateScript(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgLangInfo, lcgEmpInfo}, 3, "tblCrewInfo", "LastUpdatedBy='" & Me.LastUpdatedBy & "' , DateUpdated=(getdate()) ,PhotoPath='" & photo_path & "'", "  PKey='" & id & "'"))
                '                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, Me.txtLName.EditValue & ", " & Me.txtFName.EditValue & ", " & Me.txtMName.EditValue, FormName, strID) 'neil 'tony20160719
                '                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Biodata", 0, System.Environment.MachineName, Me.txtLName.EditValue & ", " & Me.txtFName.EditValue & ", " & Me.txtMName.EditValue, FormName, strID)
                '                'Dim qupd As String = GenerateUpdateScript(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgLangInfo, lcgEmpInfo}, 3, "tblCrewInfo", "LastUpdatedBy='" & LastUpdatedBy & "' , DateUpdated=(getdate()) ,PhotoPath='" & photo_path & "'", "  PKey='" & id & "'")
                '                Dim qupd As String = GenerateUpdateScript(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgLangInfo, lcgEmpInfo}, 3, "tblCrewInfo", "LastUpdatedBy='" & LastUpdatedBy & "' , DateUpdated=(getdate()) ", "  PKey='" & id & "'")
                '                info = UpdateActivityCrewDetails(id, TableName, qupd)
                '                SaveCrewImage(id)
                '                BRECORDUPDATEDs = False
                '                type = "Updated"
                '            End If
                '        End If
                '        'info = DB.RunSql(GenerateUpdateScript(Me.TabPage1, 3, "tblCrewInfo", "LastUpdatedBy='" & Me.LastUpdatedBy & "' , DateUpdated=(getdate()) ", "  PKey='" & id & "'"))

                '    End If
                '    'blList.RefreshData()
                '    blList.ExecCustomFunction(New Object() {"ForceRefresh"})
                '    blList.SetSelection(id)
                '    photo_path = ""
                '    If info Then
                '        RefreshData()
                '        MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
                '        Exit Sub
                '    Else
                '        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                '    End If
                'End If

                If ValidateBiodata() Then
                    If bAddMode Then
                        info = SaveNewCrew()
                        type = "Inserted"
                    Else
                        id = strID
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Biodata", 0, System.Environment.MachineName, Me.txtLName.EditValue & ", " & Me.txtFName.EditValue & ", " & Me.txtMName.EditValue, FormName, strID)
                        Dim qupd As String = GenerateUpdateScript(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo}, 3, "tblCrewInfo", "LastUpdatedBy='" & LastUpdatedBy & "' , DateUpdated=(getdate()) ", "  PKey='" & id & "'")
                        info = UpdateActivityCrewDetails(id, TableName, qupd)
                        SaveCrewImage(id)
                        BRECORDUPDATEDs = False
                        type = "Updated"
                    End If

                    blList.ExecCustomFunction(New Object() {"ForceRefresh"})
                    'blList.SetSelection(id)
                    photo_path = ""
                    If info Then
                        'RefreshData()
                        MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
                        Exit Sub
                    Else
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                    End If

                End If

            Case "Addr" 'Address
                If Not AddrView.HasColumnErrors Then
                    info = DB.RunTransaction(SaveAddr())
                    If info Then
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                        RefreshData()
                    Else
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                    End If
                Else
                    MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
                End If
            Case "NatInfo" 'National Information
                If Not NatInfoView.HasColumnErrors Then
                    info = DB.RunTransaction(SaveNatInfo(CompanyID))
                    If info Then
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                        RefreshData()
                    Else
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                    End If
                Else
                    MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
                End If
                DocumentLink()

            Case "Comments" 'Comments
                If Not CommentView.HasColumnErrors Then
                    info = DB.RunTransaction(SaveComments(CompanyID))
                    If info Then
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                        RefreshData()
                    Else
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                    End If
                Else
                    MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
                End If
            Case "FormerComp" 'Former Company
                If Not FormerCompView.HasColumnErrors Then
                    info = DB.RunTransaction(SavePrevCo())
                    If info Then
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                        RefreshData()
                    Else
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                    End If
                Else
                    MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
                End If
            Case "CrewConflict"
                If Not CrewConflictView.HasColumnErrors Then
                    Dim errstring As String = ""
                    errstring = SaveCrewConflict()
                    If errstring = "" Then
                        MsgBox(GetMessage("Saved", True), MsgBoxStyle.Information, GetAppName)
                        RefreshData()
                    Else
                        MsgBox(GetMessage("Saved", False), MsgBoxStyle.Critical, GetAppName)
                    End If
                Else
                    MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
                End If

        End Select
        tabChanged = False

    End Sub


    Private Function ValidateBiodata() As Boolean
        Dim retVal As Boolean = True

        Select Case IIf(tabChanged, PrevTab, Me.TabControl.SelectedTabPage.Tag)
            Case "NameRank" 'Name and Rank
                If ValidateFields(ctrlList) Then
                    'retVal = True
                    If txtLName.Tag = 1 Or txtFName.Tag = 1 Or txtMName.Tag = 1 Or cboDOB.Tag = 1 Then
                        If bAddMode Then
                            Dim InstCriteria As String = "LName='" & txtLName.Text & "' AND FName = '" & txtFName.Text & "'" & _
                                "MName='" & txtMName.Text & "' AND DOB= '" & ChangeToSQLDate(CDate(cboDOB.Text).ToString("yyyy-MM-dd")) & "'"
                            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtLName, txtMName, txtFName, cboDOB}, InstCriteria) Then
                                retVal = False
                            Else
                                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtCOIDNo}) Then
                                    retVal = False
                                Else
                                    retVal = True
                                End If
                            End If
                        Else
                            Dim UPDCriteria As String = " PKey <> '" & strID & "' AND LName='" & txtLName.Text & "' AND FName = '" & txtFName.Text & "'" & _
                                                  "MName='" & txtMName.Text & "' AND DOB= '" & ChangeToSQLDate(CDate(cboDOB.Text).ToString("yyyy-MM-dd")) & "'"
                            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtLName, txtMName, txtFName, cboDOB}, UPDCriteria) Then
                                retVal = False
                            Else
                                retVal = True
                            End If

                        End If

                    Else
                        If txtCOIDNo.Tag = 1 Then
                            If bAddMode Then
                                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtCOIDNo}) Then
                                    retVal = False
                                Else
                                    retVal = True
                                End If
                            Else
                                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtCOIDNo}, "PKey<>'" & strID & "'") Then
                                    retVal = False
                                Else
                                    retVal = True
                                End If
                            End If
                        Else
                            retVal = True
                        End If

                    End If
                Else
                    retVal = False
                End If

            Case Else
                If focusedView.HasColumnErrors Then
                    retVal = False
                Else
                    retVal = True
                End If

        End Select



        Return retVal
    End Function


    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then

            Select Case IIf(tabChanged, PrevTab, Me.TabControl.SelectedTabPage.Tag)
                Case "NameRank" 'Name and Rank
                    If ValidateBiodata() Then
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    Else
                        flag = False
                        ALLOWNEXTS = flag
                    End If

                    'If ValidateFields(ctrlList, showMsg) Then
                    '    If bAddMode Then
                    '        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtLName, txtMName, txtFName, cboDOB}) Then
                    '            flag = False
                    '            ALLOWNEXTS = flag
                    '        Else
                    '            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtCOIDNo}) Then

                    '                flag = False
                    '                ALLOWNEXTS = flag
                    '            Else
                    '                flag = True
                    '                ALLOWNEXTS = flag
                    '                SaveData() '
                    '            End If
                    '        End If
                    '    Else
                    '        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtLName, txtMName, txtFName, txtCOIDNo}, "PKey<>'" & id & "'") Then
                    '            flag = False
                    '            ALLOWNEXTS = flag
                    '        Else
                    '            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtCOIDNo}, "COIDNo<>'" & txtCOIDNo.Text & "'") Then
                    '                flag = False
                    '                ALLOWNEXTS = flag
                    '            Else
                    '                flag = True
                    '                ALLOWNEXTS = flag
                    '                SaveData() '
                    '            End If
                    '        End If
                    '    End If
                    'Else
                    'flag = False
                    'ALLOWNEXTS = flag
                    'End If
                Case Else
                    If Not IsNothing(focusedView) Then
                        If focusedView.HasColumnErrors Then
                            'If AddrView.HasColumnErrors Or NatInfoView.HasColumnErrors Or CommentView.HasColumnErrors Or FormerCompView.HasColumnErrors Then
                            flag = False
                            ALLOWNEXTS = flag
                            Return flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            SaveData()
                        End If
                    End If
            End Select

        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
        'If Not bAddMode Then
        setButtonEdit(True)
        Me.TabControl.SelectedTabPageIndex = 0
        bAddMode = True
        Utilities.CREWINFO = New Utilities.CrewDetail() 'New Class
        'ClearFields(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgActInfo, lcgLangInfo, lcgEmpInfo}, False)
        AllowDeletion(Name, False) 'Disable Delete button
        AllowEditing(Name, False)
        bAddMode = True
        blList.HideSelection()
        strID = ""
        strDesc = "New Record"
        Me.header.Text = strDesc
        Me.txtLName.Focus()
        Me.txtLName.BackColor = SEL_COLOR
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "NameRank" 'Name and Rank
                RemoveReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgActInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo})
                ClearFields(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgActInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo}, False)
                RemoveEditListener(txtPrinName)
                RemoveEditListener(txtVslName)
                RemoveEditListener(txtBMI)
                MakeReadOnlyListener(txtBMI)

                GetCrewPhoto(Me.CrewPhoto, "", "")
                Me.cboFKeyWageScale.Enabled = False
                Me.cboFKeyWageScaleRank.Enabled = False

            Case "Addr" 'Address Tab
                AllowRepositoryBtnEdit(repState, True)
            Case "NatInfo" 'National Informationl
                AllowFilePathBtn(repNatInfoBtnEdt, True)
            Case "Comments" 'Comments
            Case "FormerComp" 'Former Company
        End Select
        BRECORDUPDATEDs = False
        'End If


    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        header.Focus()
        getSelectedView()

        If isEditdable Then
            setButtonEdit(isEditdable)
            'Editable Required Controls
            ctrlList = {txtLName, txtFName, cboSexCode, cboDOB, cboNatCode, cboFKeyCivilStat, cboHireStatCode, txtPOB}
            strRequiredFields = "txtLName;txtFName;cboSexCode;cboDOB;cboNatCode;cboFKeyCivilStat;cboHireStatCode;txtPOB;"
            RemoveReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo})
            RemoveEditListener(txtVslName)
            RemoveEditListener(txtPrinName)
            RemoveEditListener(txtBMI)
            MakeReadOnlyListener(txtBMI)
        Else
            ResetControlOnEdit()
            setButtonEdit(isEditdable)
            AllowAddition(Name, True)
            MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgActInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo})

        End If

        AllowDeletion(Name, isEditdable)
        EditSubAllowGrid(Me.AddrView, isEditdable)
        EditSubAllowGrid(Me.NatInfoView, isEditdable)
        EditSubAllowGrid(Me.NatInfoImages, isEditdable)

        EditSubAllowGrid(Me.CommentView, isEditdable)
        EditSubAllowGrid(Me.FormerCompView, isEditdable)
        EditSubAllowGrid(Me.CrewConflictView, isEditdable)

        repCrewConflict.Buttons(0).Enabled = isEditdable
        repCrewConflict.Buttons(1).Enabled = isEditdable

        AllowFilePathBtn(repNatInfoBtnEdt, isEditdable)
        AllowRepositoryBtnEdit(repCity, isEditdable)
        AllowRepositoryBtnEdit(repState, isEditdable)
    End Sub

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
        If MsgBox("Are you sure, you want to delete Crew '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            'If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
            'info = DB.RunSql("DELETE FROM dbo.tblCrewInfo WHERE PKey='" & strID & "'")

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete Crew", 0, System.Environment.MachineName, "", FormName) 'neil
            clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy)

            info = DeleteCrew(strID) 'will delete Crew With only Applicant Service
            If info Then
                ClearFields(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgActInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo}, False)
                MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                blList.ExecCustomFunction(New Object() {"ForceRefresh"})
                RefreshData()
                BRECORDUPDATEDs = False
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If

        End If
    End Sub

    'Private Function DeleteCrew(_strID As String) As Boolean
    '    Dim retval As Boolean = False
    '    'DB.BeginReader("EXEC SP_DELETECREW '" & _strID & "'")
    '    'While DB.Read()
    '    '    retval = DB.ReaderItem("isDeleted")
    '    'End While
    '    'DB.CloseReader()
    '    Return retval
    'End Function

    'Delete Sub Item
    Private Sub DeleteSubTable()

        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "Deleted in Biodata / " & Me.TabControl.SelectedTabPage.Tag, FormName, strID) 'neil


        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "Addr" 'Address
                If MsgBox("Are you sure want to delete the Selected Address?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If IfNull(AddrView.GetRowCellValue(AddrView.FocusedRowHandle, "PKey"), "") <> "" Then
                        Dim cAuditDesc As String = ConcatWithSpaces(New Object() {IfNull(AddrView.GetRowCellValue(AddrView.FocusedRowHandle, "Bldg").ToString.Replace("'", "''"), "") & _
                                                                                  IfNull(AddrView.GetRowCellValue(AddrView.FocusedRowHandle, "St").ToString.Replace("'", "''"), "") & _
                                                                                  IfNull(AddrView.GetRowCellValue(AddrView.FocusedRowHandle, "PartofCity").ToString.Replace("'", "''"), "") & _
                                                                                  IfNull(AddrView.GetRowCellDisplayText(AddrView.FocusedRowHandle, "FKeyCity").ToString.Replace("'", "''"), "") & _
                                                                                  IfNull(AddrView.GetRowCellDisplayText(AddrView.FocusedRowHandle, "FKeyProvince").ToString.Replace("'", "''"), "") & _
                                                                                 IfNull(AddrView.GetRowCellDisplayText(AddrView.FocusedRowHandle, "FKeyCntry").ToString.Replace("'", "''"), "")})
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Address", 0, System.Environment.MachineName, cAuditDesc, FormName, strID)
                        clsAudit.saveAuditPreDelDetails("tblAddr", AddrView.GetRowCellValue(AddrView.FocusedRowHandle, "PKey"), LastUpdatedBy)
                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tblAddr", _
                            "PKey IN ('" & strID & "')", _
                            "<< Delete Crew Data - " & FormName & " - Address >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & "- Address>", _
                            GetUserName())
                        '-->
                        DB.RunSql("DELETE FROM dbo.tblAddr WHERE PKey='" & AddrView.GetRowCellValue(AddrView.FocusedRowHandle, "PKey") & "'")
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    AddrView.DeleteRow(AddrView.FocusedRowHandle)
                    If AddrView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                End If
            Case "NatInfo" 'National Information
                Dim GrdView As New DevExpress.XtraGrid.Views.Grid.GridView
                Dim info As Boolean = False, FNames As New ArrayList
                Dim subDesc As String = "", subtblcount As Integer = 0
                Dim DelSQL As String = "", PKey As String = ""
                With focusedView
                    Select Case .Name
                        Case NatInfoView.Name
                            GrdView = focusedView
                            PKey = IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")
                            subDesc = .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument")

                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "National Information", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument") & " : " & .GetRowCellValue(.FocusedRowHandle, "Number"), FormName, strID)
                            clsAudit.saveAuditPreDelDetails("tblDocument", PKey, LastUpdatedBy) 'neil
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                FormName, _
                                "Crewing", _
                                "tblDocument", _
                                "PKey IN ('" & PKey & "')", _
                                "<< Delete Crew Data - " & FormName & " - Nat Info >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <" & FormName & "- Nat Info>", _
                                GetUserName())
                            '-->

                            DelSQL = "DELETE FROM dbo.tblDocument WHERE PKey='" & PKey & "'"

                            'get the FileNames of the Child Table
                            DB.BeginReader("SELECT * FROM dbo.tblDocImage WHERE FKeyCrewDocumentID ='" & PKey & "'")
                            subtblcount = DB.RecordCount()
                            If subtblcount > 0 Then
                                While DB.Read
                                    FNames.Add(CStr(DB.ReaderItem("FilePath")))
                                End While
                            End If
                            DB.CloseReader()

                        Case NatInfoImages.Name
                            Dim _MainView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(.ParentView, DevExpress.XtraGrid.Views.Grid.GridView)
                            Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = _MainView.GetDetailView(_MainView.FocusedRowHandle, 0)
                            GrdView = vw
                            PKey = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "PKey"), "")
                            subDesc = IfNull(vw.GetRowCellDisplayText(vw.FocusedRowHandle, "Description"), "NewRecord")
                            If Not PKey.Equals(String.Empty) Then
                                clsAudit.saveAuditPreDelDetails("tblDocImage", PKey, LastUpdatedBy) 'neil
                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "National Information - Images", 0, System.Environment.MachineName, vw.GetRowCellDisplayText(vw.FocusedRowHandle, "Description") & " : " & vw.GetRowCellValue(vw.FocusedRowHandle, "FilePath") & " : " & subDesc, FormName, strID)
                                '<!--added by tony20180922 : Log Deletion
                                oLogDeletion.Init()
                                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                    FormName, _
                                    "Crewing", _
                                    "tblDocImage", _
                                    "PKey IN ('" & PKey & "')", _
                                    "<< Delete Crew Data - " & FormName & " - Nat Info Scanned Image >>", _
                                    LogDeletion.DeletionType.Manual, _
                                    "Manually Deleted in <" & FormName & "- Nat Info Scanned Image>", _
                                    GetUserName())
                                '-->
                                DelSQL = "DELETE FROM dbo.tblDocImage WHERE PKey='" & PKey & "'"
                            End If

                    End Select

                    If Not PKey.Equals(String.Empty) Then
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
                        End With
                    End If
                End With
            Case "Comments" 'Comments
                If MsgBox("Are you sure want to delete the Selected Comment?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If IfNull(CommentView.GetRowCellValue(CommentView.FocusedRowHandle, "PKey"), "") <> "" Then

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Comment", 0, System.Environment.MachineName, CommentView.GetRowCellValue(CommentView.FocusedRowHandle, "Comment").ToString.Replace("'", "''"), FormName, strID)
                        clsAudit.saveAuditPreDelDetails("tblComment", CommentView.GetRowCellValue(CommentView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tblComment", _
                            "PKey IN ('" & CommentView.GetRowCellValue(CommentView.FocusedRowHandle, "PKey") & "')", _
                            "<< Delete Crew Data - " & FormName & " - Comment >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & " - Comment>", _
                            GetUserName())
                        '-->

                        DB.RunSql("DELETE FROM dbo.tblComment WHERE PKey='" & CommentView.GetRowCellValue(CommentView.FocusedRowHandle, "PKey") & "'")
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    CommentView.DeleteRow(CommentView.FocusedRowHandle)
                    If CommentView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                End If
            Case "FormerComp" 'Former Company
                If MsgBox("Are you sure want to delete '" & FormerCompView.GetRowCellDisplayText(FormerCompView.FocusedRowHandle, "CoName") & "' ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If IfNull(FormerCompView.GetRowCellValue(FormerCompView.FocusedRowHandle, "PKey"), "") <> "" Then

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Former Company", 0, System.Environment.MachineName, FormerCompView.GetRowCellValue(FormerCompView.FocusedRowHandle, "CoName").ToString.Replace("'", "''"), FormName, strID)
                        clsAudit.saveAuditPreDelDetails("tblPrevCo", FormerCompView.GetRowCellValue(FormerCompView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tblPrevCo", _
                            "PKey IN ('" & FormerCompView.GetRowCellValue(FormerCompView.FocusedRowHandle, "PKey") & "')", _
                            "<< Delete Crew Data - " & FormName & " - Former Company >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & " - Former Company>", _
                            GetUserName())
                        '-->

                        DB.RunSql("DELETE FROM dbo.tblPrevCo WHERE PKey='" & FormerCompView.GetRowCellValue(FormerCompView.FocusedRowHandle, "PKey") & "'")
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    FormerCompView.DeleteRow(FormerCompView.FocusedRowHandle)
                    If FormerCompView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                End If

            Case "CrewConflict" 'Conflict Crew
                If MsgBox("Are you sure want to delete '" & CrewConflictView.GetRowCellDisplayText(CrewConflictView.FocusedRowHandle, "CConflictName") & "' ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If IfNull(CrewConflictView.GetRowCellValue(CrewConflictView.FocusedRowHandle, "PKey"), "") <> "" Then
                        Dim currentcrewfull As String

                        currentcrewfull = Trim(IfNull(blList.GetFocusedRowData("LName"), "")) & ", " & _
                                          Trim(IfNull(blList.GetFocusedRowData("FName"), "")) & " " & _
                                          Trim(IfNull(blList.GetFocusedRowData("MName"), ""))

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Conflict with Crew", 0, System.Environment.MachineName, currentcrewfull & " / " & CrewConflictView.GetRowCellValue(CrewConflictView.FocusedRowHandle, "CConflictName").ToString.Replace("'", "''"), FormName, strID)
                        clsAudit.saveAuditPreDelDetails("tblCrewConflict", CrewConflictView.GetRowCellValue(CrewConflictView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tblCrewConflict", _
                            "bindKey IN ('" & CrewConflictView.GetRowCellValue(CrewConflictView.FocusedRowHandle, "bindKey") & "')", _
                            "<< Delete Crew Data - " & FormName & " - Crew Conflict >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & " - Crew Conflict>", _
                            GetUserName())
                        '-->

                        DB.RunSql("DELETE FROM dbo.tblCrewConflict WHERE bindKey='" & CrewConflictView.GetRowCellValue(CrewConflictView.FocusedRowHandle, "bindKey") & "'")
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    CrewConflictView.DeleteRow(CrewConflictView.FocusedRowHandle)
                    If CrewConflictView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                End If
        End Select
        'RefreshData()  'commented out by tony20170417 - this is so multiple records can be deleted at a time without the need to click the Edit button again
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        AllowSaving(Name, False)
        Select Case param(0)
            Case "ViewData"
                ViewData()
            Case "ClearContent"
                ClearContent()
            Case "SelectRecord"
                SelectRecord(param(1), param(2))
        End Select
    End Sub

    Private Sub ClearContent()
        strID = ""
        Me.header.Text = "Personal Information Details"
        ClearFields(Me.tabNameAndRank, False)
        LoadSub()
    End Sub

    Private Sub SelectRecord(Group As String, PKey As String)
        Select Case Group
            Case "SYSNATINFO"
                TabControl.SelectedTabPage = TabControl.TabPages(2)
                With NatInfoView
                    .FocusedRowHandle = .LocateByValue("PKey", PKey)
                End With
        End Select
    End Sub

#End Region

#Region "Name and Ranks"

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = "Image File (*.jpg)|*.jpg"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            photo_changed = True
            photo_path = odMain.FileName
            Try
                CrewPhoto.Image.Dispose()
            Catch ex As Exception
            End Try
            CrewPhoto.Image = New System.Drawing.Bitmap(odMain.FileName)
            'AllowSaving(Name, (bPermission And 4) > 0)
            BRECORDUPDATEDs = True
            cmdDeletePhoto.Enabled = True
        End If
    End Sub

    Private Sub cmdDeletePhoto_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeletePhoto.Click
        If MsgBox("Are you sure you want to delete crew Image?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
            Try
                Dim _path = GetCrewPhotoPath(strID, strPhotoPath)
                If Not IsNothing(_path) Then
                    Kill(_path)
                End If
                CrewPhoto.Image = Nothing
                MsgBox("Image Deleted", MsgBoxStyle.Information, GetAppName())
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName())
            End Try
        End If
    End Sub

    Private Function SaveNewCrew() As Boolean
        Dim info As Boolean = False
        'Dim ids As String = ""
        Dim qCrewDetails As String = ""
        Dim qActivity As String = ""
        Dim CrewInfos As New Utilities.CrewDetail
        'If bAddMode Then

        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, Me.txtLName.EditValue & ", " & Me.txtFName.EditValue & ", " & Me.txtMName.EditValue, FormName, strID) 'neil 'tony20160719
        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "New Crew", 0, System.Environment.MachineName, Me.txtLName.EditValue & ", " & Me.txtFName.EditValue & ", " & Me.txtMName.EditValue, FormName, strID)
        Dim CrewName As String = AssembleName(IfNull(Me.txtLName.EditValue, ""), IfNull(Me.txtFName.EditValue, ""), IfNull(Me.txtMName.EditValue, ""), False, True, True, False, False)
        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "New Crew", 0, System.Environment.MachineName, CrewName, FormName, strID)

        Dim LastUpdatedBy_Act As String = clsAudit.AssembleLastUBy(USER_NAME, "New Crew (Activity Initialization)", 0, System.Environment.MachineName, CrewName, FormName, strID)

        With CrewInfos
            .ActGroupID = IfNull(blList.GetFocusedRowData("ActGrpID"), "")
            .ActID = IfNull(blList.GetFocusedRowData("ActGrpID"), "")
            .RankName = cboFKeyRank.Text
            .AgentName = cboFKeyAgent.Text
            .AgentCode = cboFKeyAgent.EditValue.ToString
            .WScaleCode = cboFKeyWageScale.EditValue.ToString
            .WScaleRankCode = cboFKeyWageScaleRank.EditValue.ToString
            .LastUpdatedBy = LastUpdatedBy_Act
            .RankCode = cboFKeyRank.EditValue.ToString
            '.PhotoPath = photo_path

            '<!-- added by tony20171125
            .ShoeSize = txtShoeSize.Text.ToString
            .CoverallSize = txtCoverallSize.Text.ToString
            .PoloSize = txtPoloSize.Text.ToString
            .PantsSize = txtPantsSize.Text.ToString
            '-->

            '<!-- added by tony20180505
            .Blood = txtBlood.Text.ToString
            .HairColor = txtHairColor.Text.ToString
            .EyeColor = txtEyeColor.Text.ToString
            .BMI = txtBMI.Text.ToString
            '-->
        End With
        qCrewDetails = GenerateInsertScript(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewInfo, lcgLangInfo, lcgEmpInfo, lcgSizes, lcgBodyInfo}, 3, "tblCrewInfo", "LastUpdatedBy", "'" & LastUpdatedBy & "'")

        id = DB.SaveNewCrew(qCrewDetails, CrewInfos)
        SaveCrewImage(id)
        BRECORDUPDATEDs = False
        If id <> "" Then
            GenerateCompanyID(id)
            info = True
            type = "Inserted"
            Dim IDToFocusOn As String = id
            blList.ExecCustomFunction(New Object() {"ForceRefresh"})
            blList.SetSelection(IDToFocusOn)
        Else
            info = False
        End If
        Return info
    End Function

    Private Sub cboFKeyWageScale_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboFKeyWageScale.EditValueChanged
        'If bAddMode Then
        RefreshWageScaleRank()
        'End If
    End Sub

    Private Sub RefreshWageScaleRank()
        If Not IsNothing(cboFKeyWageScale.EditValue) Then
            cboFKeyWageScaleRank.Properties.DataSource = DB.CreateTable("SELECT PKey,Name,Abbrv,FKeyRank FROM dbo.WScaleRankList WHERE FKeyWScale ='" & cboFKeyWageScale.EditValue.ToString & "' ORDER BY SortCode ASC")
            If Not IsNothing(cboFKeyRank.EditValue) And Not IsNothing(cboFKeyWageScaleRank.Properties.DataSource) Then
                'cboFKeyWageScaleRank.Text = cboFKeyRank.Text 'Original Code
                cboFKeyWageScaleRank.EditValue = cboFKeyRank.EditValue
            End If
        Else
            cboFKeyWageScaleRank.Properties.DataSource = Nothing
        End If
    End Sub

    Private Sub SaveCrewImage(id As String)
        If photo_changed Then
            If Not IsNothing(photo_path) Then
                If Not photo_path.Equals("") Then
                    'Kill(photo_path)
                    Me.CrewPhoto.Image = Nothing
                    Dim PhotoPath As String = IfNull(CopyCrewImage(photo_path, id), "")
                    DB.RunSql("UPDATE dbo.tblCrewInfo SET PhotoPath='" & PhotoPath & "' WHERE PKey='" & id & "'")
                End If
            End If
        End If
    End Sub

    Private Sub GetCrewPhoto(_PictureEdit As DevExpress.XtraEditors.PictureEdit, _CrewIDNbr As String, FileName As String)
        Try
            'CrewPhoto.Image = New System.Drawing.Bitmap(Trim(IfNull(Items("PhotoPath"), "")))
            'Dim _path = GetCrewPhotoPath(_CrewIDNbr, strPhotoPath)
            photo_path = GetCrewPhotoPath(_CrewIDNbr, strPhotoPath)
            _PictureEdit.Image = ImageFromStream(photo_path)
        Catch ex As Exception
            _PictureEdit.Image = Nothing
        End Try
    End Sub

    'Private Function GetCrewPhotoPath(_CrewIDNbr As String)
    '    Dim retval As String = Nothing
    '    Try
    '        Dim ImagePath As String = FOLDERDIRECTORY & "\" & _CrewIDNbr & "\" & _CrewIDNbr & "_IMAGE"
    '        'Dim FileName As String = _CrewIDNbr & "_IMAGE"
    '        If System.IO.File.Exists(ImagePath & ".jpg") Then
    '            ImagePath = ImagePath & ".jpg"
    '        ElseIf System.IO.File.Exists(ImagePath & ".png") Then
    '            ImagePath = ImagePath & ".png"
    '        Else
    '            ImagePath = Nothing
    '        End If
    '        retval = ImagePath
    '    Catch ex As Exception
    '        retval = Nothing
    '    End Try
    '    Return retval
    'End Function

    Private Function GetCrewPhotoPath(_CrewIDNbr As String, FileName As String)
        Dim retval As String = Nothing
        Try
            Dim ImagePath As String = FOLDERDIRECTORY & "\" & _CrewIDNbr & "\" & FileName
            'Dim FileName As String = _CrewIDNbr & "_IMAGE"
            'If System.IO.File.Exists(ImagePath & ".jpg") Then
            '    ImagePath = ImagePath & ".jpg"
            'ElseIf System.IO.File.Exists(ImagePath & ".png") Then
            '    ImagePath = ImagePath & ".png"
            'Else
            '    ImagePath = Nothing
            'End If
            retval = ImagePath
        Catch ex As Exception
            retval = Nothing
        End Try
        Return retval
    End Function

#End Region

#Region "Address"
    Dim checkRowIndex As Integer = -1
    Dim City As DataTable = Nothing
    Dim Province As DataTable = Nothing
    Dim cCity As DataView, cProvince As DataView

    'Reload Province Repository
    Private Sub ReloadProvince()
        With Me.AddrView
            Province = DB.CreateTable("SELECT * FROM tblAdmProvince ORDER BY Name ASC")
            Me.repState.DataSource = Province
        End With

    End Sub

    'Reload City Repository
    Private Sub ReloadCity()
        With Me.AddrView
            City = DB.CreateTable("SELECT * FROM tblAdmCity ORDER BY Name ASC")
            Me.repCity.DataSource = City
        End With
    End Sub

    'Reload City Repository
    Private Sub ReloadCntry()
        Me.repFKeyCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC, SortCode ASC")
        Me.AddrView.SetRowCellValue(Me.AddrView.FocusedRowHandle, "FKeyProvince", "")
    End Sub

    Private Sub AddrView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AddrView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim currRow As Integer = view.FocusedRowHandle

        If e.Column.FieldName = "AddrStat" Or e.Column.FieldName = "PayAddr" Then
            If CType(view.DataSource, DataView).ToTable.Select("(AddrStat = 1)").Count > 1 Then
                If MsgBoxResult.Yes = MsgBox("Found an existing Current Address." & vbNewLine & "Do you want to replace the existing?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, GetAppName) Then
                    For cnt As Integer = 0 To view.RowCount
                        view.SetRowCellValue(cnt, "AddrStat", 2)
                    Next cnt
                    view.SetRowCellValue(currRow, "AddrStat", 1)
                Else
                    view.SetRowCellValue(currRow, "AddrStat", 2)
                End If
            End If

            If CType(view.DataSource, DataView).ToTable.Select("(PayAddr = 1)").Count > 1 Then
                If MsgBoxResult.Yes = MsgBox("Found an existing Payroll Address." & vbNewLine & "Do you want to replace the existing?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, GetAppName) Then
                    For cnt As Integer = 0 To view.RowCount
                        view.SetRowCellValue(cnt, "PayAddr", 0)
                    Next cnt
                    view.SetRowCellValue(currRow, "PayAddr", 1)
                Else
                    view.SetRowCellValue(currRow, "PayAddr", 0)
                End If
            End If
        End If

        If e.Column.FieldName.ToString <> "Edited" Then
            Me.AddrView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If

    End Sub

    Private Sub AddrView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AddrView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyIDNbr"), strID)
        SubAddMode = True
    End Sub

    Private Sub AddrView_GotFocus(sender As Object, e As System.EventArgs) Handles AddrView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Address")
        Else
            focusedView = Nothing
        End If
    End Sub

    Private Sub AddrView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles AddrView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub AddrView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles AddrView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.AddrView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub AddrView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AddrView.RowCellStyle
        If Me.AddrView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.AddrView.GetRowCellValue(e.RowHandle, "Edited") And Me.AddrView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.AddrView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.AddrView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub AddrView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles AddrView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    'PopUp Edit Form
    Private Sub AddrView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles AddrView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Biodata Address"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
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

    'Validation
    Private Sub AddrView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles AddrView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")
        Dim City As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCity")
        Dim Prov As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyProvince")
        Dim Street As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("St")
        Dim AddrStat As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("AddrStat")
        Dim PayAddr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("PayAddr")
        Dim CConflictName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("CConflictName")

        With view
            'Country
            If .GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
                .SetColumnError(Cntry, "Please Select Country.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, Cntry) = "" Then
                    .SetColumnError(Cntry, "Please Select Country.")
                    e.Valid = False
                Else
                    .SetColumnError(Cntry, "")
                End If
            End If

            'Street
            If .GetRowCellValue(e.RowHandle, Street) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Street) Is Nothing Then
                .SetColumnError(Street, "Please Enter Street.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, Street) = "" Then
                    .SetColumnError(Street, "Please Enter Street.")
                    e.Valid = False
                Else
                    .SetColumnError(Street, "")
                End If
            End If

            'City
            If .GetRowCellValue(e.RowHandle, City) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, City) Is Nothing Then
                .SetColumnError(City, "Please Select City.")
                e.Valid = False
            Else
                .SetColumnError(City, "")
            End If

            'Province
            If .GetRowCellValue(e.RowHandle, Prov) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Prov) Is Nothing Then
                .SetColumnError(Prov, "Please Select Province.")
                e.Valid = False
            Else
                .SetColumnError(Prov, "")
            End If

            'Address Status
            If .GetRowCellValue(e.RowHandle, AddrStat) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, AddrStat) Is Nothing Then
                .SetColumnError(AddrStat, "Please Select Address Status.")
                e.Valid = False
            Else
                .SetColumnError(AddrStat, "")
            End If

            '<!-- edited by tony20170918
            'this should not go here
            'If .GetRowCellValue(e.RowHandle, CConflictName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, CConflictName) Is Nothing Then
            '    .SetColumnError(CConflictName, "Please Select Crew.")
            '    e.Valid = False
            'Else
            '    .SetColumnError(CConflictName, "")
            'End If
            '-->

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                BRECORDUPDATEDs = True
            End If
        End With

    End Sub

    Private Function SaveAddr() As ArrayList
        Dim query As New ArrayList
        With Me.AddrView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellValue(i, "Bldg"), FormName, strID) 'neil 'tony20160719
                    Dim cAuditDesc As String = ConcatWithSpaces(New Object() {.GetRowCellValue(i, "Bldg").ToString.Replace("'", "''") & _
                                                                         .GetRowCellValue(i, "St").ToString.Replace("'", "''") & _
                                                                         .GetRowCellValue(i, "PartofCity").ToString.Replace("'", "''") & _
                                                                         .GetRowCellDisplayText(i, "FKeyCity").ToString.Replace("'", "''") & _
                                                                         .GetRowCellDisplayText(i, "FKeyProvince").ToString.Replace("'", "''") & _
                                                                         .GetRowCellDisplayText(i, "FKeyCntry").ToString.Replace("'", "''")})
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Address", 0, System.Environment.MachineName, cAuditDesc, FormName, strID)
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblAddr(FKeyIDNbr,Bldg,St,PartofCity,FKeyCity,FKeyProvince,FKeyCntry,PostCode,FKeyAirport,Phone,Telefax,Email,AddrStat,PayAddr,LastUpdatedBy)" & _
                                   "VALUES('" & strID & "'" & _
                                   ",'" & (.GetRowCellValue(i, "Bldg")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "St")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "PartofCity")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "FKeyCity")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "FKeyProvince")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "FKeyCntry")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "PostCode")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "FKeyAirport")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "Phone")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "Telefax")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "Email")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "AddrStat")) & "'" & _
                                   ",'" & (.GetRowCellValue(i, "PayAddr")) & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                        type = "Inserted"
                    Else
                        query.Add("UPDATE dbo.tblAddr SET " & _
                                  "Bldg = '" & (.GetRowCellValue(i, "Bldg")) & "'" & _
                                  ",St = '" & (.GetRowCellValue(i, "St")) & "'" & _
                                  ",PartofCity = '" & (.GetRowCellValue(i, "PartofCity")) & "'" & _
                                  ",FKeyProvince = '" & (.GetRowCellValue(i, "FKeyProvince")) & "'" & _
                                  ",FKeyCity = '" & (.GetRowCellValue(i, "FKeyCity")) & "'" & _
                                  ",FKeyCntry = '" & (.GetRowCellValue(i, "FKeyCntry")) & "'" & _
                                  ",PostCode = '" & (.GetRowCellValue(i, "PostCode")) & "'" & _
                                  ",FKeyAirport = '" & (.GetRowCellValue(i, "FKeyAirport")) & "'" & _
                                  ",Phone = '" & (.GetRowCellValue(i, "Phone")) & "'" & _
                                  ",Telefax = '" & (.GetRowCellValue(i, "Telefax")) & "'" & _
                                  ",Email = '" & (.GetRowCellValue(i, "Email")) & "'" & _
                                  ",AddrStat = '" & (.GetRowCellValue(i, "AddrStat")) & "'" & _
                                  ",PayAddr = '" & (.GetRowCellValue(i, "PayAddr")) & "'" & _
                                  ",DateUpdated =(getdate())" & _
                                  ",LastUpdatedBy = '" & (LastUpdatedBy) & "'" & _
                                  " WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        type = "Updated"
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub repCntry_EditValueChanged(sender As Object, e As System.EventArgs) Handles repFKeyCntry.EditValueChanged
        Dim txt As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        'MsgBox(txt.EditValue)
        RepoProvince(Me.AddrView)
        RepoCity(Me.AddrView)

        AddrView.SetFocusedRowCellValue("FKeyProvince", System.DBNull.Value)
        AddrView.SetFocusedRowCellValue("FKeyCity", System.DBNull.Value)
    End Sub

    Private Sub RepoProvince(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView)
        'view.SetFocusedRowCellValue("FKeyCntry", "") 'Clear City
        If view.FocusedColumn.FieldName = "FKeyProvince" And (TypeOf (view.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
            Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            cProvince = New DataView(Province)
            cProvince.RowFilter = "FKeyCntry ='" & view.GetRowCellValue(view.FocusedRowHandle, "FKeyCntry") & "'"
            edit.Properties.DataSource = cProvince
            If cProvince.Count < 0 Then
                view.SetFocusedRowCellValue("FKeyCity", System.DBNull.Value)
            End If
        End If
    End Sub

    Private Sub RepoCity(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "FKeyCity" And (TypeOf (view.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
            Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            cCity = New DataView(City)
            cCity.RowFilter = "FKeyProvince ='" & view.GetRowCellValue(view.FocusedRowHandle, "FKeyProvince") & "'"
            edit.Properties.DataSource = cCity
            If cCity.Count < 0 Then
                edit.Properties.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub AddrView_HiddenEditor(sender As Object, e As System.EventArgs) Handles AddrView.HiddenEditor
        'For Province
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "FKeyProvince" Then
            If Not cProvince Is Nothing Then
                cProvince.Dispose()
                cProvince = Nothing
            End If
        End If

        'for City
        If view.FocusedColumn.FieldName = "FKeyCity" Then
            If Not cCity Is Nothing Then
                cCity.Dispose()
                cCity = Nothing
            End If
        End If
    End Sub

    Private Sub AddrView_ShownEditor(sender As System.Object, e As System.EventArgs) Handles AddrView.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        RepoProvince(view)
        RepoCity(view)
    End Sub

    'Add New Province | State Button
    Private Sub repState_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repState.ButtonClick
        ClearLookUpEdit(sender, e)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus Then
            Dim cntry As String = ""
            Dim Kcntry As String = ""
            Dim info As Boolean = False
            With Me.AddrView
                cntry = Trim(IfNull(.GetRowCellDisplayText(.FocusedRowHandle, "FKeyCntry"), ""))
                Kcntry = Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCntry"), ""))
            End With
            If Kcntry <> "" And cntry <> "" Then
                Dim strstate As String = MPSInputDialog("ADD State | Province ?", "Add")
                If strstate <> "" Then
                    AddrView.SetFocusedRowCellValue("FKeyProvince", strstate)
                End If
                If strstate <> "" Then
                    If MsgBox("Are you sure you want to Add Province in " & cntry & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        info = DB.RunSql("INSERT INTO dbo.tblAdmProvince(FKeyCntry,Name,LastUpdatedBy) VALUES('" & Kcntry & "','" & strstate & "','" & LastUpdatedBy & "')")
                    End If
                End If
                ReloadProvince()
            End If
        End If
    End Sub

    'Add New City Button
    Private Sub repCity_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCity.ButtonClick
        ClearLookUpEdit(sender, e)
        If e.Button.Index = 1 Then
            Dim province As String = ""
            Dim kProvince As String = ""
            With Me.AddrView
                province = Trim(IfNull(.GetRowCellDisplayText(.FocusedRowHandle, "FKeyProvince"), ""))
                kProvince = Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyProvince"), ""))
            End With
            If kProvince <> "" And province <> "" Then
                Dim strCity As String = MPSInputDialog("Add City?", "Add")
                If strCity <> "" Then
                    AddrView.SetFocusedRowCellValue("FKeyCity", strCity)
                End If
                If strCity <> "" Then
                    If MsgBox("Are you sure you want to Add City in " & province & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        DB.RunSql("INSERT INTO dbo.tblAdmCity(FKeyProvince,Name,LastUpdatedBy) VALUES('" & kProvince & "','" & strCity & "','" & LastUpdatedBy & "')")
                    End If
                End If
            End If
            ReloadCity()
        End If
    End Sub
#End Region

#Region "National Infromation"

    Private Function SaveNatInfo(ByVal _CompanyID As String) As ArrayList
        Dim query As New ArrayList
        Dim DocStr As String = ""
        Dim count As Integer = 0
        With Me.NatInfoView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                Dim dateIssued As String = ChangeToSQLDate(.GetRowCellValue(i, "DateIssue"))
                Dim dateExpiry As String = ChangeToSQLDate(.GetRowCellValue(i, "DateExpiry"))
                'Dim filePath As String = GetFilePathFileName(NatInfoView)
                If .GetRowCellValue(i, "Edited") Then
                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellValue(i, "Number"), FormName, strID) 'neil   'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "National Information", 0, System.Environment.MachineName, .GetRowCellDisplayText(i, "FKeyDocument") & " : " & .GetRowCellValue(i, "Number"), FormName, strID)
                    'If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                    If IfNull(.GetRowCellValue(i, "PKey"), "").Equals(CStr(i)) Then
                        query.Add("INSERT INTO dbo.tblDocument(" & _
                                                     "FKeyIDNbr" & _
                                                     ",FileTag" & _
                                                     ",FKeyDocument" & _
                                                     ",Number" & _
                                                     ",DateIssue" & _
                                                     ",DateExpiry" & _
                                                     ",FKeyCntry" & _
                                                     ",IssuedBy" & _
                                                     ",Remarks" & _
                                                     ",FilePath" & _
                                                     ",LastUpdatedBy)" & _
                                                      "VALUES(" & _
                                                      "'" & strID & "'" & _
                                                      ",'" & .GetRowCellValue(i, "FileTag") & "'" & _
                                                      ",'" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                                      ",'" & .GetRowCellValue(i, "Number") & "'" & _
                                                      "," & dateIssued & _
                                                      "," & dateExpiry & _
                                                      "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & _
                                                      ",'" & .GetRowCellValue(i, "IssuedBy") & "'" & _
                                                      ",'" & .GetRowCellValue(i, "Remarks") & "'" & _
                                                      "," & GetFilePathFileName(i, NatInfoView) & _
                                                      ",'" & LastUpdatedBy & "')")
                        type = "Inserted"
                    Else
                        query.Add("UPDATE dbo.tblDocument SET " & _
                                  "FileTag = '" & .GetRowCellValue(i, "FileTag") & "'" & _
                                   ",FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                   ",Number = '" & .GetRowCellValue(i, "Number") & "'" & _
                                   ",DateIssue = " & dateIssued & _
                                   ",DateExpiry = " & dateExpiry & _
                                   ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & _
                                   ",IssuedBy = '" & .GetRowCellValue(i, "IssuedBy") & "'" & _
                                   ",Remarks = '" & .GetRowCellValue(i, "Remarks") & "'" & _
                                   ",FilePath = " & GetFilePathFileName(i, NatInfoView) & _
                                   ",DateUpdated = (getdate())" & _
                                   ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                   "WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
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
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, CleanInput(.GetRowCellValue(childRH, "Description")), FormName, strID) 'neil
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

    Private Sub NatInfoView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles NatInfoView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.NatInfoView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub NatInfoView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles NatInfoView.CustomUnboundColumnData
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

    Private Sub NatInfoView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles NatInfoView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        With View
            .SetRowCellValue(e.RowHandle, .Columns("Edited"), True)
            .SetRowCellValue(e.RowHandle, .Columns("FKeyIDNbr"), strID)
            '.SetRowCellValue(e.RowHandle, .Columns("FKeyCntry"), getNatCode())
            .SetRowCellValue(e.RowHandle, "PKey", .RowCount)
        End With
        SubAddMode = True
    End Sub

    Private Sub NatInfoView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles NatInfoView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub NatInfoView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles NatInfoView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.NatInfoView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub NatInfoView_GotFocus(sender As Object, e As System.EventArgs) Handles NatInfoView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete National Information")
        End If
    End Sub

    Private Sub NatInfoView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles NatInfoView.RowCellStyle
        If Me.NatInfoView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.NatInfoView.GetRowCellValue(e.RowHandle, "Edited") And Me.NatInfoView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.NatInfoView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.NatInfoView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub NatInfoView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles NatInfoView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub NatInfoView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles NatInfoView.ValidatingEditor
        SetDateExpiry(sender, e)

        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'With view

        '    If .FocusedColumn.FieldName = "FKeyDocument" Then
        '        Dim Cntry As String = IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCntry"), "NULL")
        '        Dim DocCode As String = e.Value
        '        'Dim DateIssue As Date = IfNull(.GetRowCellValue(.FocusedRowHandle, "DateIssue"), "")
        '        If Not Cntry.Equals("NULL") And Not .GetRowCellValue(.FocusedRowHandle, "DateIssue").Equals(System.DBNull.Value) Then
        '            Dim DateIssue As Date = .GetRowCellValue(.FocusedRowHandle, "DateIssue")
        '            .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetDateExpiry(DocCode, DateIssue, Cntry))
        '        End If
        '    End If

        '    If .FocusedColumn.FieldName = "DateIssue" Then
        '        Dim Cntry As String = IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCntry"), "NULL")
        '        Dim DateIssue As Date = e.Value
        '        If Not Cntry.Equals("NULL") And Not .GetRowCellValue(.FocusedRowHandle, "FKeyDocument").Equals(System.DBNull.Value) Then
        '            Dim DocCode As String = .GetRowCellValue(.FocusedRowHandle, "FKeyDocument")
        '            .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetDateExpiry(DocCode, DateIssue, Cntry))
        '        End If
        '    End If

        '    If .FocusedColumn.FieldName = "FKeyCntry" Then
        '        Dim Cntry As String = e.Value
        '        If Not .GetRowCellValue(.FocusedRowHandle, "FKeyDocument").Equals(System.DBNull.Value) And Not .GetRowCellValue(.FocusedRowHandle, "DateIssue").Equals(System.DBNull.Value) Then
        '            Dim DocCode As String = .GetRowCellValue(.FocusedRowHandle, "FKeyDocument")
        '            Dim DateIssue As Date = .GetRowCellValue(.FocusedRowHandle, "DateIssue")
        '            .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetDateExpiry(DocCode, DateIssue, Cntry))
        '        End If
        '    End If
        'End With
    End Sub

    Private Sub NatInfoView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles NatInfoView.ValidateRow
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
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim Course As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyDocument")
        'Dim DateIssue As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateIssue")
        'Dim tsNumber As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Number")
        'With view
        '    'Validate LicCert
        '    If .GetRowCellValue(e.RowHandle, Course) IsNot System.DBNull.Value And .GetRowCellValue(e.RowHandle, Course) IsNot Nothing Then
        '        .SetRowCellValue(e.RowHandle, "FileTag", getFileTag(.GetRowCellValue(e.RowHandle, Course)))
        '    ElseIf .GetRowCellValue(e.RowHandle, Course) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Course) Is Nothing Then
        '        .SetColumnError(Course, "Please select Travel Document.")
        '        e.Valid = False
        '    Else
        '        .SetColumnError(Course, "")
        '    End If

        '    'Number
        '    If .GetRowCellValue(e.RowHandle, tsNumber) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, tsNumber) Is Nothing Then
        '        .SetColumnError(tsNumber, "Please Enter Number.")
        '        e.Valid = False
        '    Else
        '        If .GetRowCellValue(e.RowHandle, tsNumber) = "" Then
        '            .SetColumnError(tsNumber, "Please Enter Number.")
        '            e.Valid = False
        '        Else
        '            .SetColumnError(tsNumber, "")
        '        End If
        '    End If

        '    'Validate DateIssue
        '    If .GetRowCellValue(e.RowHandle, DateIssue) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, DateIssue) Is Nothing Then
        '        .SetColumnError(DateIssue, "Please Enter Issued Date.")
        '        e.Valid = False
        '    Else
        '        .SetColumnError(DateIssue, "")
        '    End If

        '    'clear errors
        '    If Not .HasColumnErrors Then
        '        e.Valid = True
        '        .ClearColumnErrors()
        '    Else
        '        BRECORDUPDATEDs = True
        '    End If
        'End With
    End Sub

    Private Sub NatInfoImages_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles NatInfoImages.ValidatingEditor
        SetDateExpiry(sender, e)
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With views
            Dim AllowDup As Boolean = False
            If .FocusedColumn.FieldName.Equals("FKeyDocument") Then
                AllowDup = CBool(DB.DLookUp("AllowDuplicate", "tblAdmDocument", "0", "PKey='" & e.Value & "'"))
                If Not AllowDup Then
                    For i As Integer = 0 To .DataRowCount - 1
                        If i <> (.FocusedRowHandle) Then
                            If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
                                e.Valid = False
                                e.ErrorText = "Already in use."
                            End If
                        End If
                    Next
                End If
            End If
        End With
    End Sub

    Private Sub NatInfoView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles NatInfoView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Biodata National Information"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
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

#Region "National Info Images"

    Private Sub NatInfoImages_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles NatInfoImages.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                TryCast(view.ParentView, DevExpress.XtraGrid.Views.Grid.GridView).SetRowCellValue(view.SourceRowHandle, "Edited", True)
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub NatInfoImages_GotFocus(sender As Object, e As System.EventArgs) Handles NatInfoImages.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete National Info Images")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub NatInfoImages_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles NatInfoImages.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = view.ParentView 'Master View
        With view
            If e.Column.FieldName = "FileName" AndAlso e.IsGetData Then
                e.Value = MView.GetRowCellValue(view.SourceRowHandle, "File_Name") & "_" & e.ListSourceRowIndex.ToString
            End If
        End With
    End Sub

    Private Sub NatInfoImages_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles NatInfoImages.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub NatInfoImages_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles NatInfoImages.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub NatInfoImages_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles NatInfoImages.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(View.ParentView, DevExpress.XtraGrid.Views.Grid.GridView)
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "FKeyCrewDocumentID", MView.GetRowCellValue(MView.SourceRowHandle, "PKey")) 'Crew Document ID
        'SubAddMode = True
    End Sub

    Private Sub NatInfoImages_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles NatInfoImages.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub NatInfoImages_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles NatInfoImages.ValidateRow
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

#End Region

#Region "Comments"

    Private Function SaveComments(ByVal _CompanyID As String) As ArrayList
        Dim query As New ArrayList
        With Me.CommentView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellValue(i, "ComDate"), FormName, strID) 'neil   'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Comment", 0, System.Environment.MachineName, Mid(.GetRowCellValue(i, "Comment").ToString.Replace("'", "''"), 1, 35) & "...", FormName, strID)
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblComment(FKeyIDNbr,Comment,ComDate,ComBy,FilePath,LastUpdatedBy)" & _
                                   "VALUES('" & strID & "'" & _
                                   ",'" & .GetRowCellValue(i, "Comment").ToString.Replace("'", "''") & "'" & _
                                   "," & ChangeToSQLDate(.GetRowCellValue(i, "ComDate")) & _
                                   ",'" & .GetRowCellValue(i, "ComBy") & "'" & _
                                   ",'" & .GetRowCellValue(i, "FilePath") & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblComment SET " & _
                                  "Comment = '" & .GetRowCellValue(i, "Comment").ToString.Replace("'", "''") & "'" & _
                                  ",ComDate = " & ChangeToSQLDate(.GetRowCellValue(i, "ComDate")) & _
                                  ",ComBy = '" & .GetRowCellValue(i, "ComBy") & "'" & _
                                  ",FilePath = '" & .GetRowCellValue(i, "FilePath") & "'" & _
                                  ",DateUpdated =(getdate())" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub CommentView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CommentView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            If e.Column.FieldName.ToString <> "ComBy" Then
                If e.Column.FieldName.ToString <> "ComDate" Then
                    Me.CommentView.SetRowCellValue(e.RowHandle, "Edited", True)
                    Me.CommentView.SetRowCellValue(e.RowHandle, "ComDate", Date.Now)
                    Me.CommentView.SetRowCellValue(e.RowHandle, "ComBy", USER_NAME)
                End If
            End If
        End If
    End Sub

    Private Sub CommentView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CommentView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyIDNbr"), strID)
        View.SetRowCellValue(e.RowHandle, View.Columns("ComBy"), USER_NAME)
        SubAddMode = True
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
        ViewRowCellStyle(sender, e, "")
    End Sub

    Private Sub CommentView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CommentView.RowUpdated
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        BRECORDUPDATEDs = True

    End Sub

    Private Sub CommentView_GotFocus(sender As Object, e As System.EventArgs) Handles CommentView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Comment")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
        End If
    End Sub

    Private Sub CommentView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles CommentView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Biodata Comments"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
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

#End Region

#Region "Former Company"
    Private Function SavePrevCo() As ArrayList
        Dim query As New ArrayList
        With Me.FormerCompView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellValue(i, "CoName"), FormName, strID) 'neil   'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Former Company", 0, System.Environment.MachineName, .GetRowCellValue(i, "CoName").ToString.Replace("'", "''"), FormName, strID)
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblPrevCo(FKeyIDNbr,FKeyRank,YrFrom,YrTo,CoName,CoAddr,CoPhone,Rem,LastUpdatedBy)" & _
                                   "VALUES('" & strID & "'" & _
                                   ",'" & .GetRowCellValue(i, "FKeyRank") & "'" & _
                                   ",'" & .GetRowCellValue(i, "YrFrom") & "'" & _
                                   ",'" & .GetRowCellValue(i, "YrTo") & "'" & _
                                   ",'" & .GetRowCellValue(i, "CoName") & "'" & _
                                   ",'" & .GetRowCellValue(i, "CoAddr") & "'" & _
                                   ",'" & .GetRowCellValue(i, "CoPhone") & "'" & _
                                   ",'" & .GetRowCellValue(i, "Rem") & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblPrevCo SET " & _
                                  "FKeyRank = '" & .GetRowCellValue(i, "FKeyRank") & "'" & _
                                  ",YrFrom = '" & .GetRowCellValue(i, "YrFrom") & "'" & _
                                  ",YrTo = '" & .GetRowCellValue(i, "YrTo") & "'" & _
                                  ",CoName = '" & .GetRowCellValue(i, "CoName") & "'" & _
                                  ",CoAddr = '" & .GetRowCellValue(i, "CoAddr") & "'" & _
                                  ",CoPhone = '" & .GetRowCellValue(i, "CoPhone") & "'" & _
                                  ",Rem = '" & .GetRowCellValue(i, "Rem") & "'" & _
                                  ",DateUpdated = (getdate())" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub FormerCompView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles FormerCompView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.FormerCompView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub FormerCompView_GotFocus(sender As Object, e As System.EventArgs) Handles FormerCompView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Former Company")
        Else
            focusedView = Nothing
            'SetDeleteCaption(Name, "Delete Crew")
        End If
    End Sub


    Private Sub FormerCompView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles FormerCompView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyIDNbr"), strID)
    End Sub

    Private Sub FormerCompView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles FormerCompView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub FormerCompView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles FormerCompView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.FormerCompView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub FormerCompView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles FormerCompView.RowCellStyle
        If Me.FormerCompView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.FormerCompView.GetRowCellValue(e.RowHandle, "Edited") And Me.FormerCompView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.FormerCompView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.FormerCompView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub FormerCompView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles FormerCompView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub FormerCompView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FormerCompView.ShowingEditor
        stopnaba = True
    End Sub

    Private Sub FormerCompView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles FormerCompView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Biodata Former Company"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
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

    Private Sub FormerCompView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles FormerCompView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'insert validation here
    End Sub
#End Region

    Private Sub TabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabControl.SelectedPageChanged
        PrevTab = Me.TabControl.SelectedTabPage.Tag
        getSelectedView()
        LoadSub()
        UpdateListeners()   'added by tony20170712
        EditCheck(Name, False)
    End Sub

    Private Sub TabControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangingEventArgs) Handles TabControl.SelectedPageChanging
        If BRECORDUPDATEDs Then
            'If MsgBox("Would you like to save the changes you made on " & e.PrevPage.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, strCaption) = MsgBoxResult.Yes Then
            '    tabChanged = True
            '    SaveData()
            'Else
            '    RefreshData()
            'End If

            Dim msgans As Integer
            msgans = MsgBox("Would you like to save the changes you made on " & e.PrevPage.Text & "?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, strCaption)
            If msgans = MsgBoxResult.Yes Then
                tabChanged = True
                SaveData()
            ElseIf msgans = MsgBoxResult.No Then
                RefreshData()
            Else
                e.Cancel = True
            End If
        ElseIf bAddMode Then
            'bAddMode = False
            'RefreshData()
            If BRECORDUPDATEDs Then
                MsgBox("You must save the Name and Rank data first before switching and editing other information", MsgBoxStyle.Information)
            End If
            e.Cancel = True
            End If
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

    'Change view Button
    Private Sub cmdChangeView_Click(sender As System.Object, e As System.EventArgs) Handles cmdChangeView.Click
        Dim x As Integer = blList.PicView
        If (Not x < 0) And (Not x >= 5) Then
            x = x + 1
            blList.PicView = x
        Else
            x = 0
            blList.PicView = x
        End If

        picSize(blList.PicView)

    End Sub

    Private Sub cboFKeyRank_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyRank.EditValueChanged
        Dim cbo As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)

        If bAddMode Then
            If Not IsNothing(cboFKeyWageScaleRank.Properties.DataSource) Then
                cboFKeyWageScaleRank.Text = cbo.Text
            End If
        End If
    End Sub

    Private Sub setButtonEdit(value As Boolean)
        cmdBrowse.Enabled = value
        cmdDeletePhoto.Enabled = value
    End Sub

    Private Sub getSelectedView()
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "NameRank"
                'SetDeleteCaption(Name, "Delete Crew")
                SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                'AllowDeletion(Name, True)
                focusedView = Nothing
                SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            Case "Addr"
                SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                'Me.AddrView.Focus()
                SetDeleteCaption(Name, "Delete Address")
                focusedView = AddrView
                AllowDeletion(Name, False)
                SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            Case "NatInfo"
                'Me.NatInfoView.Focus()
                SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetDeleteCaption(Name, "Delete National Information")
                focusedView = NatInfoView
                AllowDeletion(Name, False)
                SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            Case "Comments"
                'Me.CommentView.Focus()
                SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetDeleteCaption(Name, "Delete Comment")
                focusedView = CommentView
                AllowDeletion(Name, False)
                SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            Case "FormerComp"
                SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                'Me.FormerCompView.Focus()
                SetDeleteCaption(Name, "Delete Former Company")
                focusedView = FormerCompView
                AllowDeletion(Name, False)
                SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            Case "CrewConflict"
                SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                'Me.FormerCompView.Focus()
                SetDeleteCaption(Name, "Delete Crew Conflict with")
                focusedView = CrewConflictView
                AllowDeletion(Name, False)
                'SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

                'Dim dt As New DataTable
                'clsCrewConflict.CrewConflict_getConflict(dt, "EMSI627INH46S4", MPSDB.GetConnectionString)

        End Select
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
            str1 = DocumentList(index).Item(index + 1)
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
                Dim strLink As String = ExportCrewDocToPdf(_SourceFile, _IDNbr, _FileTag, _DateIssue)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try
    End Sub

    Private Sub AllowFilePathBtn(ByVal btn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, Optional ByVal value As Boolean = True)
        For i As Integer = 0 To btn.Buttons.Count - 1
            btn.Buttons(i).Enabled = value
        Next
    End Sub

    'will remove errors in Edit Forms
    Private Sub ClearViewError(views As DevExpress.XtraGrid.Views.Grid.GridView())
        For Each _view In views
            _view.CloseEditForm()
            _view.CancelUpdateCurrentRow()
        Next
    End Sub

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

    Public Function UpdateActivityCrewDetails(PKeyValue As String, TableName As String, MainUpdQuery As String) As Boolean
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim retval As Boolean = False
        Dim sqlTrans As SqlClient.SqlTransaction = Nothing
        Dim AllowUpdate As Boolean = False, isMainUpdated As Boolean = False
        Try
            sqlConn.Open()
            sqlTrans = sqlConn.BeginTransaction()
            'update Admin Table
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = sqlConn
                cmd.CommandText = MainUpdQuery
                cmd.Transaction = sqlTrans
                isMainUpdated = (cmd.ExecuteNonQuery().Equals(1))
            End Using

            If isMainUpdated Then
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTrans
                    cmd.CommandText = "EXEC dbo.SP_UpdateActivity '" & TableName & "', '" & PKeyValue & "'"
                    AllowUpdate = (cmd.ExecuteNonQuery() >= 0)
                End Using
                If AllowUpdate Then
                    sqlTrans.Commit()
                    retval = True
                Else
                    retval = False
                End If
            End If
        Catch ex As Exception
            sqlTrans.Rollback()
            retval = False
        Finally
            sqlConn.Close()
        End Try
        Return retval
    End Function

#Region "LookUpEdit Button Clicked"

    Private Sub cboSexCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboSexCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboDOB_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboDOB.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboFKeyCivilStat_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyCivilStat.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboNatCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboNatCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboHireStatCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboHireStatCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboEmpTypeCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboEmpTypeCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboFKeyRank_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyRank.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboFKeyAgent_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyAgent.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboFKeyWageScale_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyWageScale.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboFKeyWageScaleRank_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyWageScaleRank.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboLangAbilityCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboLangAbilityCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboLangLevelCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboLangLevelCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repAddrStat_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repAddrStat.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repFKeyAirport_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFKeyAirport.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repFKeyNatInfo_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFKeyNatInfo.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub rNIDateEdit_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rNIDateEdit.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub rNIFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rNIFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub RepositoryItemDateEdit1_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemDateEdit1.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub rFCFKeyRank_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles rFCFKeyRank.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

#End Region

    'Private Sub NatInfoView_LostFocus(sender As Object, e As System.EventArgs) Handles NatInfoView.LostFocus
    '    If isEditdable Or bAddMode Then
    '        AllowDeletion(Name, False)
    '        focusedView = Nothing
    '        SetDeleteCaption(Name, "Delete Crew")
    '    End If

    'End Sub

    'Private Sub AddrView_LostFocus(sender As Object, e As System.EventArgs) Handles AddrView.LostFocus
    '    If isEditdable Or bAddMode Then
    '        AllowDeletion(Name, False)
    '        focusedView = Nothing
    '        SetDeleteCaption(Name, "Delete Crew")
    '    End If

    'End Sub
    'Private Sub CommentView_LostFocus(sender As Object, e As System.EventArgs) Handles CommentView.LostFocus
    '    If isEditdable Or bAddMode Then
    '        AllowDeletion(Name, False)
    '        focusedView = Nothing
    '        SetDeleteCaption(Name, "Delete Crew")
    '    End If

    'End Sub
    'Private Sub FormerCompView_LostFocus(sender As Object, e As System.EventArgs) Handles FormerCompView.LostFocus
    '    If isEditdable Or bAddMode Then
    '        AllowDeletion(Name, False)
    '        focusedView = Nothing
    '        SetDeleteCaption(Name, "Delete Crew")
    '    End If

    'End Sub

    Private Sub ResetControlOnEdit()
        ResetGridViewEdits(New DevExpress.XtraGrid.Views.Grid.GridView() {NatInfoView, AddrView, CommentView, FormerCompView, CrewConflictView})
        RefreshData()
    End Sub

    Public Overrides Sub applyCrewFilter(ByVal param() As Object)
        RefreshData()
    End Sub

    Private Sub AddrGrid_Click(sender As Object, e As System.EventArgs) Handles AddrGrid.Click
        stopnaba = True
    End Sub


    Private Sub AddrGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles AddrGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub FormerCompGrid_Click(sender As Object, e As System.EventArgs) Handles FormerCompGrid.Click
        stopnaba = True
    End Sub

    Private Sub FormerCompGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles FormerCompGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub NatInfoGrid_Click(sender As Object, e As System.EventArgs) Handles NatInfoGrid.Click
        stopnaba = True
    End Sub

    Private Sub NatInfoGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NatInfoGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub AddrView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AddrView.ShowingEditor
        stopnaba = True
    End Sub

    Private Sub NatInfoView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NatInfoView.ShowingEditor
        stopnaba = True
    End Sub

#Region "Crew Conflict"

    Dim vidnbr As String = ""

    Private Sub repCrewConflict_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCrewConflict.ButtonClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = Me.gridCrewConflict.FocusedView

        If IfNull(view.GetRowCellValue(view.FocusedRowHandle, "PKey"), "") <> "" Then
            MsgBox("You cannot change Crew Name.", vbExclamation)
            Exit Sub
        End If

        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
            Me.CrewConflictView.SetRowCellValue(Me.CrewConflictView.FocusedRowHandle, colConflictIDNbr, System.DBNull.Value)
            Me.CrewConflictView.SetRowCellValue(Me.CrewConflictView.FocusedRowHandle, colCrewConflictName, System.DBNull.Value)
            vidnbr = ""
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            'Me.CrewConflictView.ClearColumnErrors()
            Dim conflictlist As New frmConflictCrewList(blList.getBListDatasource, id)

            vidnbr = ""
            conflictlist.ShowDialog()
            'Me.CrewConflictView.SetFocusedValue("test mo lang")
            vidnbr = conflictlist.vidnbr

            If findingrid(vidnbr, "FKeyIDNbrConflict", Me.CrewConflictView, Me.CrewConflictView.FocusedRowHandle, False) Then
                MsgBox("Crew already inlcuded in the list.", vbInformation)
                vidnbr = ""
            Else
                If conflictlist.vidnbr <> "" And conflictlist.vidnbr <> Nothing Then
                    'If Not view.IsNewItemRow(view.FocusedRowHandle) And view.GetRow(view.FocusedRowHandle) Is System.DBNull.Value Then
                    'End If
                    'MsgBox(view.GetRow(view.FocusedRowHandle) Is System.DBNull.Value)
                    'MsgBox(view.IsNewItemRow(view.FocusedRowHandle))
                    'MsgBox(view.GetRowCellValue(view.FocusedRowHandle, "Edited") Is Nothing)
                    If view.GetRowCellValue(view.FocusedRowHandle, "Edited") Is Nothing Then
                        CrewConflictView.AddNewRow()
                    End If
                    'End If
                    Me.CrewConflictView.SetRowCellValue(Me.CrewConflictView.FocusedRowHandle, colConflictIDNbr, conflictlist.vidnbr)
                    Me.CrewConflictView.SetRowCellValue(Me.CrewConflictView.FocusedRowHandle, colCrewConflictName, conflictlist.vcrewname)
                End If
            End If

        Else

        End If
    End Sub

    Function findingrid(tosearch As String, colname As String, ByRef gridmo As DevExpress.XtraGrid.Views.Grid.GridView, excemptedRow As Integer, _
                        Optional FindNotResolvedOnly As Boolean = True) As Boolean
        Dim found As Boolean = False

        If gridmo.RowCount > 0 Then
            With gridmo
                For i As Integer = 0 To gridmo.RowCount - 1
                    If i <> excemptedRow Then
                        If .GetRowCellValue(i, colname) = tosearch Then
                            If FindNotResolvedOnly Then
                                If .GetRowCellValue(i, "isResolved") = 0 Then 'found and currently not yet resolved
                                    found = True
                                    Exit For
                                End If
                            Else
                                found = True
                                Exit For
                            End If
                        End If
                    End If
                Next
            End With
        End If
        Return found
    End Function

    Private Sub repCrewConflict_Click(sender As Object, e As System.EventArgs) Handles repCrewConflict.Click
        ' MsgBox("click")
    End Sub

    Private Sub repCrewConflict_DoubleClick(sender As Object, e As System.EventArgs) Handles repCrewConflict.DoubleClick
        'Dim conflictlist As New frmConflictCrewList(blList.getBListDatasource)

        'conflictlist.ShowDialog()
        ''Me.CrewConflictView.SetFocusedValue("test mo lang")
        'CrewConflictView.AddNewRow()

        'If conflictlist.vidnbr <> "" Then
        '    Me.CrewConflictView.SetRowCellValue(Me.CrewConflictView.FocusedRowHandle, colConflictIDNbr, conflictlist.vidnbr)
        '    Me.CrewConflictView.SetRowCellValue(Me.CrewConflictView.FocusedRowHandle, colCrewConflictName, conflictlist.vcrewname)
        'End If

    End Sub

    Private Sub repCrewConflict_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles repCrewConflict.KeyDown
        '' MsgBox("KeyDown")
        'Dim conflictlist As New frmConflictCrewList(blList.getBListDatasource)

        'conflictlist.ShowDialog()
        ''Me.CrewConflictView.SetFocusedValue("test mo lang")
        'CrewConflictView.AddNewRow()

        'If conflictlist.vidnbr <> "" And conflictlist.vidnbr <> Nothing Then
        '    Me.CrewConflictView.SetRowCellValue(Me.CrewConflictView.FocusedRowHandle, colConflictIDNbr, conflictlist.vidnbr)
        '    Me.CrewConflictView.SetRowCellValue(Me.CrewConflictView.FocusedRowHandle, colCrewConflictName, conflictlist.vcrewname)
        'End If

    End Sub

    Private Sub CrewConflictView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CrewConflictView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.CrewConflictView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
         BRECORDUPDATEDs = True
    End Sub

    Private Sub CrewConflictView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CrewConflictView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        With View
            .SetRowCellValue(e.RowHandle, .Columns("Edited"), True)
            .SetRowCellValue(e.RowHandle, .Columns("FKeyIDNbr"), strID)
            .SetRowCellValue(e.RowHandle, .Columns("isResolved"), 0)
        End With
        SubAddMode = True
        vidnbr = ""
    End Sub

    Private Sub CrewConflictView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CrewConflictView.RowUpdated

    End Sub

    Private Sub CrewConflictView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CrewConflictView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim crewconflict As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("CConflictName")

        With view
            If (.GetRowCellValue(e.RowHandle, crewconflict) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, crewconflict) Is Nothing) And (vidnbr = "") Then
                .SetColumnError(crewconflict, "Please Select Crew.")
                e.Valid = False
            Else
                .SetColumnError(crewconflict, "")
            End If

            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                BRECORDUPDATEDs = True
            End If

        End With
    End Sub


    Private Function SaveCrewConflict() As String
        'Dim query As New ArrayList
        Dim retval As String = "", currentcrewfull As String

        'currentcrewfull = Me.txtLName.EditValue & ", " & Me.txtFName.EditValue & " " & Me.txtMName.EditValue
        currentcrewfull = Trim(IfNull(blList.GetFocusedRowData("LName"), "")) & ", " & _
        Trim(IfNull(blList.GetFocusedRowData("FName"), "")) & " " & _
        Trim(IfNull(blList.GetFocusedRowData("MName"), ""))

        clsCrewConflict.propSQLConnStr = MPSDB.GetConnectionString

        With Me.CrewConflictView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Conflict with", 0, System.Environment.MachineName,
                                                              currentcrewfull & " - " & .GetRowCellValue(i, "CConflictName") & " / " & .GetRowCellValue(i, "Reason").ToString.Replace("'", "''"), FormName, strID)
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then

                        retval = retval & clsCrewConflict.CrewConflict_add(strID, _
                                                          .GetRowCellValue(i, "Reason").ToString.Replace("'", "''"), _
                                                          .GetRowCellValue(i, "FKeyIDNbrConflict"), _
                                                          .GetRowCellValue(i, "CConflictName"), _
                                                           currentcrewfull, _
                                                          .GetRowCellValue(i, "isResolved"), _
                                                         LastUpdatedBy, , , False)
                    Else
                     
                        retval = retval & clsCrewConflict.CrewConflict_edit(.GetRowCellValue(i, "bindKey"), _
                                                          .GetRowCellValue(i, "Reason").ToString.Replace("'", "''"), _
                                                          .GetRowCellValue(i, "isResolved"), _
                                                         LastUpdatedBy, , , False)

                    End If
                End If
            Next

            clsCrewConflict.closeConn()

        End With
        Return retval 'query
    End Function

    'Private Sub repIsResolved_EditValueChanged(sender As Object, e As System.EventArgs) Handles repIsResolved.EditValueChanged
    '    With Me.CrewConflictView
    '        .SetRowCellValue(CrewConflictView.FocusedRowHandle, .Columns("Edited"), True)
    '    End With
    'End Sub

    Private Sub repIsResolved_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles repIsResolved.EditValueChanging
        If e.NewValue = 0 Then
            If findingrid(Me.CrewConflictView.GetFocusedRowCellValue("FKeyIDNbrConflict"), "FKeyIDNbrConflict", Me.CrewConflictView, Me.CrewConflictView.FocusedRowHandle, False) Then
                MsgBox("Cannot update, list cannot have the same Crew with the same unresolved state.", vbExclamation)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub CrewConflictView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewConflictView.RowCellStyle
        If Me.CrewConflictView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.CrewConflictView.GetRowCellValue(e.RowHandle, "Edited") And Me.CrewConflictView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.CrewConflictView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.CrewConflictView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
        ViewRowCellStyle(sender, e, "")
    End Sub
#End Region

#Region "BMI"
    ''' <summary>
    ''' Gets Body Mass Index based on Weight and Height parameters
    ''' Formula: BMI = kg/m2
    ''' </summary>
    ''' <param name="Weight">Weight in Kilograms</param>
    ''' <param name="Height">Height in Meters</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBMI(Weight As Object, Height As Object) As Object
        If Not IfNull(Weight, "").Equals("") And Not IfNull(Height, "").Equals("") Then
            If IsNumeric(Weight) And IsNumeric(Height) Then
                If Weight > 0 And Height > 0 Then
                    Try
                        Dim Height_m As Double = Height * 100
                        Return Weight / (Height_m * Height_m)
                    Catch ex As Exception
                        Return 0
                    End Try
                Else
                    Return 0
                End If
            Else
                Return DBNull.Value

            End If

        Else
            Return DBNull.Value
        End If
    End Function

    Private Sub RefreshBMIField()
        Me.txtBMI.EditValue = GetBMI(txtWeight.EditValue, txtHeight.EditValue)
    End Sub

    Private Sub txtHeight_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtHeight.EditValueChanged
        RefreshBMIField()
    End Sub

    Private Sub txtWeight_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtWeight.EditValueChanged
        RefreshBMIField()
    End Sub
#End Region

    
    
End Class
