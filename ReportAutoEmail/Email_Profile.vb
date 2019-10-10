Public Class Email_Profile

#Region "Easy Edit"
    Private FormName As String = "Email Report Template"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Dim isEditOn As Boolean
    Dim info As Boolean = True
    Dim selectedList As DevExpress.XtraEditors.ListBoxControl
    Dim content As New EmailBaseSetting

    Public Overrides Sub RefreshData()
        TableName = "tblUserEmailProfile"
        MyBase.RefreshData()

        isEditdable = False
        isEditOn = False
        BRECORDUPDATEDs = False

        If Not bLoaded Then
            RequiredControls = {txtProfile, cboFrom, txtSubject}
            initControls()
            bLoaded = True
        End If

        AllowSaving(Name, True)
        SetRibbonPageGroupVisibility(Name, "rpgReportEditOptions", False)
        SetRibbonPageGroupVisibility(Name, "rpgReportOptions", False)

        ClearControls()
        toggleEnable.EditValue = False

        cboProfiles.Properties.DataSource = MPSDB.CreateTable("SELECT *  FROM " & TableName & " WHERE FKeyUserID='" & USER_ID & "'")
        cboProfiles.EditValue = strID
        loadData()
        cmdAddProfile.Text = "New Profile"
        cmdEditProfile.Text = "Edit Profile"
        cboProfiles.ReadOnly = False
        cmdAddProfile.Enabled = True
        cmdEditProfile.Enabled = True
        cmdDelProfile.Enabled = True
        cmdSave.Enabled = False
        MakeControlsEditable(False)
        cboRptType.EditValue = 0
    End Sub

    Private Function AllowSaveProfile() As Boolean
        Dim retVal As Boolean = True

        If content.GetIntervals.ToString.Split(";").Count = 0 Then 'exec option is empty
            MsgBox("Please specify a valid execution command.", MsgBoxStyle.Exclamation, GetAppName)
            retVal = False
        ElseIf TemplateToView.RowCount <= 0 Then
            MsgBox("Must have selected atleast one report.", MsgBoxStyle.Exclamation, GetAppName)
            retVal = False
        ElseIf IsNothing(cboFrom.EditValue) Or cboFrom.EditValue = "" Then
            MsgBox("Specify an email address for the sender", MsgBoxStyle.Exclamation, GetAppName)
        ElseIf lbcTo.Items.Count = 0 Then 'check recipient
            MsgBox("No Recipient specified.", MsgBoxStyle.Exclamation, GetAppName)
            retVal = False
        ElseIf Trim(txtSubject.Text).Length = 0 Then
            MsgBox("Please specify a valid email to add.", MsgBoxStyle.Exclamation, GetAppName)
        End If

        Return retVal
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtProfile, cboExecType, cboFrom, txtSubject}) Then
                If AllowSaveProfile() Then
                    If bAddMode Then
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtProfile}) Then
                            flag = False
                            ALLOWNEXTS = flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            'SaveData()
                            cmdSave_Click(Nothing, Nothing)
                        End If
                    Else
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtProfile}, "PKey<>'" & strID & "'") Then
                            flag = False
                            ALLOWNEXTS = flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            'SaveData()
                            cmdSave_Click(Nothing, Nothing)
                        End If
                    End If
                Else
                    flag = False
                    ALLOWNEXTS = flag
                End If
            Else
                flag = False
                ALLOWNEXTS = flag
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Private Sub loadData()
        If (Not IsNothing(strID)) And (strID <> "") Then
            EnableEditListener(False)

            Dim row As DataRowView = CType(cboProfiles.Properties.GetDataSourceRowByKeyValue(strID), DataRowView)

            ClearControls()
            
            txtProfile.Text = row("Name")
            toggleEnable.EditValue = row("EnableProfile")
            cboExecType.EditValue = CInt(row("ExecType"))
            timeExecTime.EditValue = CDate(row("ExecTime"))
            content.SetIntervals(row("Intervals"))

            cboFrom.EditValue = row("FKeyEmailAdd")
            SetEmailList(lbcTo, row("EmailTo"))
            SetEmailList(lbcCc, row("EmailCc"))
            SetEmailList(lbcBcc, row("EmailBcc"))
            txtSubject.Text = row("EmailSubject")
            memoMsg.Text = row("EmailMsg")

            LoadReports()
        End If

        EnableEditListener(True)

        BRECORDUPDATEDs = False
    End Sub

    Private Sub EnableEditListener(value As Boolean)

        If value Then
            'profile
            AddEditListener(Me.lcSub.Root)
            'settings
            AddEditListener(Me.lcSettings.Root)
            'email
            AddEditListener(Me.lcEmail.Root)

        Else
            'profile
            RemoveEditListener(Me.lcSub.Root)
            'settings
            RemoveEditListener(Me.lcSettings.Root)
            'email
            RemoveEditListener(Me.lcEmail.Root)
        End If
        content.EnableEditListener(value)

        RemoveEditListener(cboProfiles, False)
        RemoveEditListener(cboExecType, False)
        RemoveEditListener(cboRptType, False)
        RemoveEditListener(cboRecipient, False)
        RemoveEditListener(txtEmailAdd, False)
    End Sub

    Private Sub MakeControlsEditable(editable As Boolean)
        txtProfile.ReadOnly = Not editable
        toggleEnable.ReadOnly = Not editable
        If Not editable Then
            'profile
            MakeReadOnlyListener(Me.lcSub.Root)
            'settings
            MakeReadOnlyListener(Me.lcSettings.Root)
            'reports
            MakeReadOnlyListener(Me.lcReports.Root)
            'email
            MakeReadOnlyListener(Me.lcEmail.Root)
        Else
            'profile
            RemoveReadOnlyListener(Me.lcSub.Root)
            'settings
            RemoveReadOnlyListener(Me.lcSettings.Root)
            'reports
            RemoveReadOnlyListener(Me.lcReports.Root)
            'email
            RemoveReadOnlyListener(Me.lcEmail.Root)
        End If
        content.MakeControlsEditable(editable)
        lbcTo.Enabled = editable
        lbcCc.Enabled = editable
        lbcBcc.Enabled = editable

        EditSubAllowGrid(TemplateFromView, False, False)
        EditSubAllowGrid(TemplateToView, False, False)

    End Sub

    Private Sub initControls()
        Dim dtExecType As New DataTable
        dtExecType.Columns.Add("PKey", GetType(Integer))
        dtExecType.Columns.Add("Name", GetType(String))
        dtExecType.Rows.Add(1, "Daily")
        dtExecType.Rows.Add(2, "Weekly")
        dtExecType.Rows.Add(3, "Monthly")
        dtExecType.Rows.Add(4, "Quarterly")
        dtExecType.Rows.Add(5, "Semi Annual")
        dtExecType.Rows.Add(6, "Annually")
        cboExecType.Properties.DataSource = dtExecType
        cboExecType.EditValue = 1

        Dim dtRptType As New DataTable
        dtRptType.Columns.Add("PKey", GetType(Integer))
        dtRptType.Columns.Add("Name", GetType(String))
        dtRptType.Rows.Add(0, "ALL")
        dtRptType.Rows.Add(1, "Reports")
        dtRptType.Rows.Add(2, "KPI")
        cboRptType.Properties.DataSource = dtRptType
        cboRptType.EditValue = 0

        cboFrom.Properties.DataSource = MPSDB.CreateTable("SELECT *  FROM tblUserEmailConfig WHERE FKeyUserID='" & USER_ID & "'")

        Dim dtRecipient As New DataTable
        dtRecipient.Columns.Add("PKey", GetType(Integer))
        dtRecipient.Columns.Add("Name", GetType(String))
        dtRecipient.Rows.Add(1, "To")
        dtRecipient.Rows.Add(2, "Cc")
        dtRecipient.Rows.Add(3, "Bcc")
        cboRecipient.Properties.DataSource = dtRecipient
        cboRecipient.EditValue = 1

        selectedList = lbcTo
    End Sub

    Private Sub ClearControls()
        'ClearFields(Me.lcMain.Root, False)
        ClearFields(Me.lcgSub, False)
        content.ClearControls()
        ClearFields(Me.lcgEmail, False)
        lbcTo.Items.Clear()
        lbcCc.Items.Clear()
        lbcBcc.Items.Clear()

        TemplateFromGrid.DataSource = Nothing
        TemplateToGrid.DataSource = Nothing
    End Sub

    Private Sub LoadReports()
        If IsNothing(cboRptType.EditValue) Then Exit Sub
        Dim rptType As String = IIf(cboRptType.EditValue = 2, " AND (RptType = 'KPI') ", IIf(cboRptType.EditValue = 1, " AND (RptType = 'REPORT') ", ""))
        Dim query As String

        'selected reports
        If TemplateToView.RowCount = 0 Then
            query = "SELECT * FROM view_EmailProfileReports WHERE (UserID = '" & USER_ID & "') AND (FKeyEmailProfile = '" & strID & "')"
            TemplateToGrid.DataSource = MPSDB.CreateTable(query)
        End If

        'available reports
        'If Not IsNothing(TemplateToGrid.DataSource) Then Exit Sub
        Dim pkeys As String = GetPKeyList(TemplateToGrid.DataSource)
        Dim pkeyCrit As String = IIf(pkeys.Length <> 0, " AND (Not (PKey IN (" & pkeys & "))) ", "")
        query = "SELECT * FROM view_EmailProfileReports WHERE (UserID = '" & USER_ID & "') AND (FKeyEmailProfile <> '" & strID & "' OR FKeyEmailProfile IS NULL) " & pkeyCrit & rptType
        TemplateFromGrid.DataSource = MPSDB.CreateTable(query).DefaultView.ToTable(True, {"PKey", "RptType", "GroupName", "ReportName", "TemplateName"})


        With TemplateToView
            .SortInfo.ClearAndAddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(.Columns("RptType"), DevExpress.Data.ColumnSortOrder.Descending), _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(.Columns("GroupName"), DevExpress.Data.ColumnSortOrder.Ascending), _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(.Columns("ReportName"), DevExpress.Data.ColumnSortOrder.Ascending), _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(.Columns("TemplateName"), DevExpress.Data.ColumnSortOrder.Ascending) _
                }, 1)

            '.BeginSort()
            'Try
            '    .ClearSorting()
            '    .Columns("Crew").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            '    .Columns("Vessel").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            '    .Columns("RankName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            'Finally
            '    .EndSort()
            'End Try
        End With

        With TemplateFromView
            .SortInfo.ClearAndAddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(.Columns("RptType"), DevExpress.Data.ColumnSortOrder.Descending), _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(.Columns("GroupName"), DevExpress.Data.ColumnSortOrder.Ascending), _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(.Columns("ReportName"), DevExpress.Data.ColumnSortOrder.Ascending), _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(.Columns("TemplateName"), DevExpress.Data.ColumnSortOrder.Ascending) _
                }, 1)

        End With
        TemplateFromView.ExpandAllGroups()
        TemplateToView.ExpandAllGroups()

    End Sub

    Private Function GetPKeyList(dTable As DataTable) As String
        Dim tempDT As DataTable = dTable
        Dim retVal As String = ""

        If tempDT.Rows.Count > 0 Then
            For i As Integer = 0 To tempDT.Rows.Count - 1
                retVal = retVal & "'" & tempDT.Rows(i)("PKey").ToString & "',"
            Next
            retVal = retVal.Substring(0, retVal.Length - 1)
        End If
        Return retVal
    End Function

    Private Sub SaveReports()
        MPSDB.RunSql("DELETE FROM tblUserEmailProfileReports WHERE FKeyEmailProfile='" & strID & "'")

        'If TemplateToView.RowCount <= 0 Then Exit Sub

        ''collects all PKey and delete all not in collection
        'Dim pkeys As String = ""
        'For cnt As Integer = 0 To TemplateToView.RowCount
        '    If IfNull(TemplateToView.GetRowCellValue(cnt, "PKey"), "") <> "" Then
        '        pkeys = "'" & TemplateToView.GetRowCellValue(cnt, "PKey") & "',"
        '    End If
        'Next
        'If pkeys.Length <> 0 Then
        '    pkeys = pkeys.Substring(0, pkeys.Length - 1)
        'End If
        'MPSDB.RunSql("DELETE FROM tblUserEmailProfileReports WHERE NOT FKeyEmailProfile IN (" & pkeys & ")")

        'save records
        For cnt As Integer = 0 To TemplateToView.DataRowCount - 1
            'If IfNull(TemplateToView.GetRowCellValue(cnt, "PKey"), "") = "" Then
            MPSDB.RunSql("INSERT INTO tblUserEmailProfileReports (DateUpdated, LastUpdatedBy, FKeyEmailProfile, FKeyOptTemplate) " & _
                         "VALUES (" & ChangeToSQLDate(DateTime.Now) & ", '" & LastUpdatedBy & "', '" & strID & "', '" & TemplateToView.GetRowCellValue(cnt, "PKey") & "')")
            'End If
        Next
    End Sub

    Private Function IsSettingsModified() As Boolean
        Dim retVal As Boolean = False

        If (Not IsNothing(strID)) And (strID <> "") Then

            Dim row As DataRowView = CType(cboProfiles.Properties.GetDataSourceRowByKeyValue(strID), DataRowView)

            If CInt(row("ExecType")) <> cboExecType.EditValue Then
                retVal = True
            ElseIf row("Intervals") <> content.GetIntervals() Then
                retVal = True
            End If

        End If

        Return retVal
    End Function

    Private Sub SetEmailList(listBoxEdit As DevExpress.XtraEditors.ListBoxControl, value As String)
        listBoxEdit.Items.Clear()
        listBoxEdit.Items.AddRange(value.Split(";"))
    End Sub

    Private Function GetEmailList(listBoxEdit As DevExpress.XtraEditors.ListBoxControl)
        Dim retVal As String = ""
        If listBoxEdit.Items.Count <> 0 Then
            For Each item As String In listBoxEdit.Items
                retVal = retVal & item & ";"
            Next
            retVal = retVal.Substring(0, retVal.Length - 1)
        End If
        Return retVal
    End Function

#Region "Controls Event"

    Private Sub cboProfiles_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboProfiles.EditValueChanged
        strID = cboProfiles.EditValue
        loadData()
    End Sub

    Private Sub cmdAddProfile_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddProfile.Click
        Dim emailcnt As Integer = 0
        emailcnt = MPSDB.DLookUp("COUNT(*)", "tblUserEmailConfig", 0, "FKeyUserID = " & USER_ID)
        If emailcnt = 0 Then
            MsgBox("Please create an Email Account first before you proceed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, GetAppName())
            Exit Sub
        End If
        isEditdable = True
        bAddMode = True
        BRECORDUPDATEDs = False

        If cmdAddProfile.Text = "Cancel" Then
            RefreshData()
        Else
            isEditOn = True
            strID = Nothing
            MakeControlsEditable(True)
            ClearFields(Me.lcgMain, False)
            ClearControls()
            EnableEditListener(False)
            toggleEnable.EditValue = True
            cboExecType.EditValue = 1
            cboRptType.EditValue = 0
            cboRecipient.EditValue = 1
            EnableEditListener(True)
            cboProfiles.ReadOnly = True
            cmdAddProfile.Enabled = True
            cmdEditProfile.Enabled = False
            cmdDelProfile.Enabled = False
            cmdSave.Enabled = True
            cmdAddProfile.Text = "Cancel"
            LoadReports()
        End If
    End Sub

    Private Sub cmdEditProfile_Click(sender As System.Object, e As System.EventArgs) Handles cmdEditProfile.Click
        If IsNothing(cboProfiles.EditValue) Or cboProfiles.EditValue = "" Then
            MsgBox("No Profile selected to edit.", vbOKOnly + MsgBoxStyle.Information, GetAppName)
        Else
            isEditdable = True
            bAddMode = False
            BRECORDUPDATEDs = False
            If cmdEditProfile.Text = "Cancel" Then
                RefreshData()
            Else
                isEditOn = True
                MakeControlsEditable(True)
                cboProfiles.ReadOnly = True
                cmdDelProfile.Enabled = False
                cmdAddProfile.Enabled = False
                cmdEditProfile.Enabled = True
                cmdDelProfile.Enabled = False
                cmdSave.Enabled = True
                cmdEditProfile.Text = "Cancel"
            End If
        End If
    End Sub

    Private Sub cmdDelProfile_Click(sender As System.Object, e As System.EventArgs) Handles cmdDelProfile.Click
        If IsNothing(cboProfiles.EditValue) Or cboProfiles.EditValue = "" Then
            MsgBox("No Profile selected to delete.", vbOKOnly + MsgBoxStyle.Information, GetAppName)
        Else
            If MsgBox("Do you want to delete the selected item?", vbYesNo + vbQuestion, GetAppName) = MsgBoxResult.Yes Then
                info = MPSDB.RunSql("DELETE FROM " & TableName & " WHERE PKey='" & strID & "'")
                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, GetAppName)
                strID = Nothing
                RefreshData()
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Dim isNextDate As Boolean = False
        Dim flag As Boolean = False
        Dim Type As String = "", info As Boolean = False
        Dim query As String = ""
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtProfile, cboExecType, cboFrom, txtSubject}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil	'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, FormName, 10, System.Environment.MachineName, txtEmailAdd.EditValue, FormName)
            If AllowSaveProfile() Then

                Dim nextDate As Date = ReportAutoEmail.GetDateNextSend(cboExecType.EditValue, content.GetIntervals, Date.Now, False)
                If nextDate < Date.Now And CInt(Format(timeExecTime.EditValue, "HHmmss")) < CInt(Format(Date.Now, "HHmmss")) Then
                    isNextDate = True
                Else
                    isNextDate = False
                End If

                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtProfile}) Then
                        Exit Sub
                    Else
                        query = "INSERT INTO " & TableName & " (Name, ExecType, ExecTime, Intervals, EnableProfile, FKeyEmailAdd, EmailFrom, EmailTo, EmailCc, EmailBcc, EmailSubject, EmailMsg, FKeyUserID, " & _
                                    " DateLastSent, DateNextSend, LastDateFrom, LastDateTo, DateUpdated, LastUpdatedBy) " & _
                                " VALUES ('" & txtProfile.Text & "'" & _
                                        ",'" & cboExecType.EditValue & "'" & _
                                        "," & ChangeToSQLDate(timeExecTime.EditValue) & "" & _
                                        ",'" & content.GetIntervals() & "'" & _
                                        ",'" & toggleEnable.EditValue & "'" & _
                                        ",'" & cboFrom.EditValue & "'" & _
                                        ",'" & cboFrom.Text & "'" & _
                                        ",'" & GetEmailList(lbcTo) & "'" & _
                                        ",'" & GetEmailList(lbcCc) & "'" & _
                                        ",'" & GetEmailList(lbcBcc) & "'" & _
                                        ",'" & txtSubject.Text & "'" & _
                                        ",'" & memoMsg.Text & "'" & _
                                        ",'" & USER_ID & "'" & _
                                        ",NULL" & _
                                        "," & ChangeToSQLDate(ReportAutoEmail.GetDateNextSend(cboExecType.EditValue, content.GetIntervals, Date.Now, isNextDate)) & _
                                        "," & ChangeToSQLDate(ReportAutoEmail.GetDateCoverage(cboExecType.EditValue, content.GetIntervals, Date.Now, Date.Now, isNextDate)("FROM")) & _
                                        "," & ChangeToSQLDate(ReportAutoEmail.GetDateCoverage(cboExecType.EditValue, content.GetIntervals, Date.Now, Date.Now, isNextDate)("TO")) & _
                                        "," & ChangeToSQLDate(Date.Now) & "" & _
                                        ",'" & LastUpdatedBy & "'" & _
                                        ")"
                        info = DB.RunSql(query)
                        BRECORDUPDATEDs = False
                        'get the last inserted Record
                        strID = DB.GetLastInsertedItem("PKey", Me.TableName)
                        SaveReports()
                        Type = "Inserted"
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtProfile}, "PKey<>'" & strID & "'") Then
                        Exit Sub
                    Else
                        query = "UPDATE " & TableName & " SET " & _
                                    "Name='" & txtProfile.Text & "'" & _
                                    ",ExecType='" & cboExecType.EditValue & "'" & _
                                    ",ExecTime=" & ChangeToSQLDate(timeExecTime.EditValue) & "" & _
                                    ",Intervals='" & content.GetIntervals() & "'" & _
                                    ",EnableProfile='" & toggleEnable.EditValue & "'" & _
                                    ",FKeyEmailAdd='" & cboFrom.EditValue & "'" & _
                                    ",EmailFrom='" & cboFrom.Text & "'" & _
                                    ",EmailTo='" & GetEmailList(lbcTo) & "'" & _
                                    ",EmailCc='" & GetEmailList(lbcCc) & "'" & _
                                    ",EmailBcc='" & GetEmailList(lbcBcc) & "'" &
                                    ",EmailSubject='" & txtSubject.Text & "'" & _
                                    ",EmailMsg='" & memoMsg.Text & "'" & _
                                    IIf(IsSettingsModified(), ",DateNextSend=" & ChangeToSQLDate(ReportAutoEmail.GetDateNextSend(cboExecType.EditValue, content.GetIntervals, Date.Now, isNextDate)), "") & _
                                    IIf(IsSettingsModified(), ",LastDateFrom=" & ChangeToSQLDate(ReportAutoEmail.GetDateCoverage(cboExecType.EditValue, content.GetIntervals, Date.Now, Date.Now, isNextDate)("FROM")), "") & _
                                    IIf(IsSettingsModified(), ",LastDateTo=" & ChangeToSQLDate(ReportAutoEmail.GetDateCoverage(cboExecType.EditValue, content.GetIntervals, Date.Now, Date.Now, isNextDate)("TO")), "") & _
                                    ",DateUpdated=" & ChangeToSQLDate(DateTime.Now) & "" & _
                                    ",LastUpdatedBy='" & LastUpdatedBy & "'" & _
                                " WHERE PKey='" & strID & "'"
                        info = DB.RunSql(query)
                        SaveReports()
                        BRECORDUPDATEDs = False
                        Type = "Updated"
                    End If
                End If
            Else
                flag = False
                ALLOWNEXTS = flag
                Exit Sub
            End If
            bAddMode = False
            RefreshData()
        End If
        If info Then
            MsgBox(GetMessage(Type, info), MsgBoxStyle.Information, GetAppName)
        End If
    End Sub

    Private Sub cboExecType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboExecType.EditValueChanged
        content.Dispose()
        Select Case cboExecType.EditValue
            Case 1
                content = New EmailSetting_Daily
            Case 2
                content = New EmailSetting_Weekly
            Case 3
                content = New EmailSetting_Monthly
            Case 4
                content = New EmailSetting_Quarterly
            Case 5
                content = New EmailSetting_BiAnnual
            Case 6
                content = New EmailSetting_Annually
        End Select
        panelSettings.Controls.Clear()
        panelSettings.Controls.Add(content)
        content.Dock = DockStyle.Fill
        content.initControls()
        content.MakeControlsEditable(isEditOn)
        content.EnableEditListener(isEditOn)
        BRECORDUPDATEDs = True
    End Sub


    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        If Not isEditdable Then Exit Sub
        If Trim(txtEmailAdd.Text).Length = 0 Then
            MsgBox("Please specify a valid email to add.", MsgBoxStyle.Exclamation, GetAppName)
        ElseIf IsNothing(cboRecipient.EditValue) Then
            MsgBox("Please specify the destination.", MsgBoxStyle.Exclamation, GetAppName)
        Else
            Select Case cboRecipient.EditValue
                Case 1
                    lbcTo.Items.Add(txtEmailAdd.Text)
                Case 2
                    lbcCc.Items.Add(txtEmailAdd.Text)
                Case 3
                    lbcBcc.Items.Add(txtEmailAdd.Text)
            End Select
            txtEmailAdd.Text = ""
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub cmdRemove_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemove.Click
        If Not isEditdable Then Exit Sub
        If selectedList.Items.Count <> 0 Then
            selectedList.Items.Remove(selectedList.SelectedItem)
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub ListBoxControlEvent_Click(sender As System.Object, e As System.EventArgs) Handles lbcTo.Click, lbcCc.Click, lbcBcc.Click
        selectedList = CType(sender, DevExpress.XtraEditors.ListBoxControl)
    End Sub

    Private Sub cboRptType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboRptType.EditValueChanged
        LoadReports()
    End Sub

    Private Sub cmdSendTest_Click(sender As System.Object, e As System.EventArgs) Handles cmdSendTest.Click
        Dim subFolder As String = "EmailAttachment_TEST"
        If IsNothing(strID) Or strID = "" Then
            If bAddMode Then
                MsgBox("Please save new Profile before Sending", MsgBoxStyle.Exclamation, GetAppName)
            Else
                MsgBox("Select Profile to test", MsgBoxStyle.Exclamation, GetAppName)
            End If
        ElseIf IsNothing(cboFrom.EditValue) Or cboFrom.EditValue = "" Then
            MsgBox("Specify an email address for the sender", MsgBoxStyle.Exclamation, GetAppName)
        ElseIf lbcTo.Items.Count <= 0 Then
            MsgBox("Specify valid email address(es) that will recieve the test email", MsgBoxStyle.Exclamation, GetAppName)
        Else
            If MsgBox("Do you want to continue to send email?", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, GetAppName) = MsgBoxResult.Ok Then
                ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Sending Email . . .")
                If ReportAutoEmail.CreateExportDirectory(subFolder) Then
                    Dim path As String = ReportAutoEmail.GetExportDirectory() & "\" & subFolder & "\TestAttachment.txt"

                    If Not IO.File.Exists(path) Then
                        Using sw As IO.StreamWriter = IO.File.CreateText(path)
                            sw.WriteLine("This is a test email attachment.")
                        End Using
                    End If

                    Dim success As Boolean = True
                    Dim addMsg As String = ""
                    Dim dtConfig As DataTable
                    'get the SMTP config of the sender
                    dtConfig = MPSDB.CreateTable("SELECT TOP 1 * FROM tblAdmSMTPConfig aSMTP INNER JOIN tblUserEmailConfig uEmail ON aSMTP.PKey = uEmail.FKeySMTPAcct WHERE uEmail.PKey='" & cboFrom.EditValue & "'")
                    'sends then deletes the export folder
                    success = ReportAutoEmail.SendMailByCK(dtConfig.Rows(0).Item("SMTPHost"), CInt(dtConfig.Rows(0).Item("SMTPPort")), CBool(dtConfig.Rows(0).Item("UseSSL")), CBool(dtConfig.Rows(0).Item("UseTLS")), dtConfig.Rows(0).Item("SMTPUsername"), dtConfig.Rows(0).Item("SMTPPassword"), _
                                        cboFrom.Text, GetEmailList(lbcTo), ReportAutoEmail.MAIL_TEST_SUBJECT, ReportAutoEmail.MAIL_TEST_MSG, ReportAutoEmail.GetExportDirectory() & "\" & subFolder, "", "", , addMsg)
                    CloseCustomLoadScreen()
                    ReportAutoEmail.ShowMailMsg(success, True, addMsg)
                    ReportAutoEmail.DeleteExportDirectory()
                End If
            End If
        End If
    End Sub

    Private Sub cmdSendManual_Click(sender As System.Object, e As System.EventArgs) Handles cmdSendManual.Click
        If IsNothing(strID) Or strID = "" Then 'new profile or none selected
            If bAddMode Then
                MsgBox("Please save new Profile before Sending", MsgBoxStyle.Exclamation, GetAppName)
            Else
                MsgBox("Select Profile to send manually", MsgBoxStyle.Exclamation, GetAppName)
            End If
        ElseIf BRECORDUPDATEDs Then
            MsgBox("Please save any changes before sending.", MsgBoxStyle.Exclamation, GetAppName)
        ElseIf AllowSaveProfile() Then
            If MsgBox("Do you want to continue to send email?", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, GetAppName) = MsgBoxResult.Ok Then
                ReportAutoEmail.StartAutoSendingEmail(True, True, strID)
            End If
        End If

    End Sub

#End Region

#Region "grid FROM and TO"
    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
    Dim srcGridControl As DevExpress.XtraGrid.GridControl
    Dim dtToTransfer As DataTable

    'transfer data from one grid to another
    Private Sub TransferGridToGridData(gridFrom As DevExpress.XtraGrid.GridControl, gridTo As DevExpress.XtraGrid.GridControl, dtToTransfer As DataTable, PKey As String)
        'Try
        Dim viewFrom As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(gridFrom.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim viewTo As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(gridTo.MainView, DevExpress.XtraGrid.Views.Grid.GridView)

        If IsNothing(dtToTransfer) Then Exit Sub

        If Not viewFrom.Name.Equals(viewTo.Name) Then

            dtToTransfer.AcceptChanges()

            For Each dr As DataRow In dtToTransfer.Rows

                Dim nRow As DataRow
                nRow = gridTo.DataSource.NewRow()

                For Each dc As DevExpress.XtraGrid.Columns.GridColumn In viewTo.Columns
                    nRow(dc.FieldName) = dr(dc.FieldName)
                Next
                gridTo.DataSource.Rows.Add(nRow)

            Next

            dtToTransfer.AcceptChanges()

            For Each dr As DataRow In dtToTransfer.Rows
                viewFrom.DeleteRow(viewFrom.LocateByValue(PKey, dr(PKey)))
                'viewFrom.DeleteSelectedRows()
            Next

            dtToTransfer.AcceptChanges()

        End If

    End Sub

    ''convert dragged data to DataTable
    'Private Function ConvertSelectedRowToDT(grid As DevExpress.XtraGrid.GridControl) As DataTable
    '    Dim dTable As DataTable = CType(grid.DataSource, DataTable).Clone
    '    Dim dRow As DataRow
    '    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grid.MainView, DevExpress.XtraGrid.Views.Grid.GridView)

    '    For Each cnt As Integer In view.GetSelectedRows
    '        dRow = dTable.NewRow()
    '        For Each dc As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
    '            dRow(dc.FieldName) = view.GetDataRow(cnt)(dc.FieldName)
    '        Next
    '        dTable.Rows.Add(dRow)
    '    Next

    '    Return dTable
    'End Function

    'get the DataTable value of dragged data

    Private Function GetDragData(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView) As DataTable
        Dim result As New DataTable

        For Each dc As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
            result.Columns.Add(dc.FieldName)
        Next

        Dim selection() As Integer = view.GetSelectedRows()
        If selection Is Nothing Then
            Return Nothing
        End If

        Dim count As Integer = selection.Length - 1
        For index = 0 To count
            If Not view.IsGroupRow(selection(index)) Then
                Dim nRow As DataRow
                nRow = result.NewRow
                For Each dc As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
                    nRow(dc.FieldName) = view.GetRowCellValue(selection(index), dc.FieldName)
                Next
                result.Rows.Add(nRow)
            End If
        Next

        Return result
    End Function

    'add all
    Private Sub cmdSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdSelectAll.Click
        If Not isEditdable Then Exit Sub
        TemplateFromView.SelectAll()
        dtToTransfer = TemplateFromGrid.DataSource
        TransferGridToGridData(TemplateFromGrid, TemplateToGrid, dtToTransfer, "PKey")
        BRECORDUPDATEDs = True
    End Sub

    'remove all
    Private Sub cmdDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeselectAll.Click
        If Not isEditdable Then Exit Sub
        TemplateToView.SelectAll()
        dtToTransfer = TemplateToGrid.DataSource
        TransferGridToGridData(TemplateToGrid, TemplateFromGrid, dtToTransfer, "PKey")
        BRECORDUPDATEDs = True
    End Sub

    'get downHitInfo
    Private Sub TemplateFromView_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TemplateFromView.MouseDown
        If Not isEditdable Then Exit Sub
        srcGridControl = TemplateFromGrid
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

    'handles rect icon in mouse
    Private Sub TemplateFromView_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TemplateFromView.MouseMove
        If Not isEditdable Then Exit Sub
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
                'view.GridControl.DoDragDrop(view, DragDropEffects.All)
                view.GridControl.DoDragDrop(view.Name, DragDropEffects.All)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    'handles dropped data
    Private Sub TemplateFromGrid_DragOver(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TemplateFromGrid.DragOver
        If Not isEditdable Then Exit Sub
        Dim control As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(control.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.Data.GetDataPresent(GetType(DataTable)) AndAlso Not view.IsGroupRow(downHitInfo.RowHandle) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    'handles dropped data
    Private Sub TemplateFromGrid_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TemplateFromGrid.DragDrop
        If Not isEditdable Then Exit Sub
        If srcGridControl.Name = TemplateFromGrid.Name Then Exit Sub
        TransferGridToGridData(TemplateToGrid, _
                               TemplateFromGrid, _
                               TryCast(e.Data.GetData(GetType(DataTable)), DataTable), _
                               "PKey")
        BRECORDUPDATEDs = True
    End Sub

    'get downHitInfo
    Private Sub TemplateToView_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TemplateToView.MouseDown
        If Not isEditdable Then Exit Sub
        srcGridControl = TemplateToGrid
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

    'handles rect icon in mouse
    Private Sub TemplateToView_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TemplateToView.MouseMove
        If Not isEditdable Then Exit Sub
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    'handles rect icon in mouse
    Private Sub TemplateToGrid_DragOver(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TemplateToGrid.DragOver
        If Not isEditdable Then Exit Sub
        Dim control As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(control.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.Data.GetDataPresent(GetType(DataTable)) AndAlso Not view.IsGroupRow(downHitInfo.RowHandle) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    'handles dropped data
    Private Sub TemplateToGrid_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TemplateToGrid.DragDrop
        If Not isEditdable Then Exit Sub
        If srcGridControl.Name = TemplateToGrid.Name Then Exit Sub
        TransferGridToGridData(TemplateFromGrid, _
                               TemplateToGrid, _
                               TryCast(e.Data.GetData(GetType(DataTable)), DataTable), _
                               "PKey")
        BRECORDUPDATEDs = True
    End Sub

#End Region

End Class
