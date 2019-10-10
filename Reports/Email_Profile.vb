Public Class Email_Profile

#Region "Easy Edit"
    Private FormName As String = "Email Report Template"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Dim info As Boolean = True

    Dim selectedList As DevExpress.XtraEditors.ListBoxControl

    Public Overrides Sub RefreshData()
        TableName = "tblUserEmailProfile"
        MyBase.RefreshData()

        isEditdable = False
        BRECORDUPDATEDs = False

        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If

        SetRibbonPageGroupVisibility(Name, "rpgReportEditOptions", False)
        SetRibbonPageGroupVisibility(Name, "rpgReportOptions", False)

        ClearControls()

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
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Information + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtProfile, cboExecType, cboFrom}) Then
                If lbcTo.Items.Count <> 0 Then
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
                    MsgBox("No Recipient specified.", MsgBoxStyle.Exclamation, GetAppName)
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
            txtProfile.Text = row("Name")
            cboExecType.EditValue = CInt(row("ExecType"))
            SetIntervals(cboExecType.EditValue, row("Intervals"))
            SetExecTime(CInt(row("ExecType")), CDate(row("ExecTime")))
            cboFrom.EditValue = row("FKeyEmailAdd")
            SetEmailList(lbcTo, row("EmailTo"))
            SetEmailList(lbcBcc, row("EmailCc"))
            SetEmailList(lbcCc, row("EmailBcc"))
            txtSubject.Text = row("EmailSubject")
            memoMsg.Text = row("EmailMsg")

            LoadReports()
        End If

        EnableEditListener(True)

        BRECORDUPDATEDs = False
    End Sub

    Private Sub EnableEditListener(value As Boolean)
        If value Then
            'settings
            AddEditListener(Me.LayoutControlGroup6)
            'tabs
            AddEditListener(Me.LayoutControlGroup2)
            AddEditListener(Me.LayoutControlGroup3)
            AddEditListener(Me.LayoutControlGroup4)
            'reports
            AddEditListener(Me.LayoutControlGroup5)
            'email
            AddEditListener(Me.LayoutControlGroup8)
            AddEditListener(lbcTo)
            AddEditListener(lbcCc)
            AddEditListener(lbcBcc)

        Else
            'settings
            RemoveEditListener(Me.LayoutControlGroup6)
            'tabs
            RemoveEditListener(Me.LayoutControlGroup2)
            RemoveEditListener(Me.LayoutControlGroup3)
            RemoveEditListener(Me.LayoutControlGroup4)
            'reports
            RemoveEditListener(Me.LayoutControlGroup5)
            'email
            RemoveEditListener(Me.LayoutControlGroup8)

        End If

        RemoveEditListener(cboProfiles, False)
        RemoveEditListener(cboExecType, False)
        RemoveEditListener(cboRptType, False)
        RemoveEditListener(cboRecipient, False)
        RemoveEditListener(txtEmailAdd, False)
    End Sub

    Private Sub MakeControlsEditable(editable As Boolean)
        'MakeReadOnlyListener(Me.LayoutControlGroup1)
        txtProfile.ReadOnly = Not editable
        If Not editable Then
            'settings
            MakeReadOnlyListener(Me.LayoutControlGroup6)
            'tabs
            MakeReadOnlyListener(Me.LayoutControlGroup2)
            MakeReadOnlyListener(Me.LayoutControlGroup3)
            MakeReadOnlyListener(Me.LayoutControlGroup4)
            'reports
            MakeReadOnlyListener(Me.LayoutControlGroup5)
            'email
            MakeReadOnlyListener(Me.LayoutControlGroup8)
        Else
            'settings
            RemoveReadOnlyListener(Me.LayoutControlGroup6)
            'tabs
            RemoveReadOnlyListener(Me.LayoutControlGroup2)
            RemoveReadOnlyListener(Me.LayoutControlGroup3)
            RemoveReadOnlyListener(Me.LayoutControlGroup4)
            'reports
            RemoveReadOnlyListener(Me.LayoutControlGroup5)
            'email
            RemoveReadOnlyListener(Me.LayoutControlGroup8)
        End If
        lbcTo.Enabled = editable
        lbcCc.Enabled = editable
        lbcBcc.Enabled = editable

        EditSubAllowGrid(TemplateFromView, False, False)
        EditSubAllowGrid(TemplateToView, False, False)

    End Sub

    Private Sub initControls()
        tabControlExec.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False

        Dim dtExecTime As New DataTable
        dtExecTime.Columns.Add("PKey", GetType(Integer))
        dtExecTime.Columns.Add("Name", GetType(String))
        dtExecTime.Rows.Add(1, "Daily")
        dtExecTime.Rows.Add(2, "Weekly")
        dtExecTime.Rows.Add(3, "Monthly")
        cboExecType.Properties.DataSource = dtExecTime
        cboExecType.EditValue = 1

        Dim dtDays As New DataTable
        dtDays.Columns.Add("PKey", GetType(Integer))
        dtDays.Columns.Add("Name", GetType(String))
        For cnt As Integer = 1 To 31
            dtDays.Rows.Add(cnt, NumberToOrdinal(cnt))
        Next
        cboDays.Properties.DataSource = dtDays
        cboDays.EditValue = 1

        Dim dtRptType As New DataTable
        dtRptType.Columns.Add("PKey", GetType(Integer))
        dtRptType.Columns.Add("Name", GetType(String))
        dtRptType.Rows.Add(1, "Reports")
        dtRptType.Rows.Add(2, "KPI")
        cboRptType.Properties.DataSource = dtRptType
        cboRptType.EditValue = 1

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
        'ClearFields(Me.LayoutControlGroup9, False)
        ClearFields(Me.LayoutControlGroup1, False)
        ClearFields(Me.LayoutControlGroup2, False)
        ClearFields(Me.LayoutControlGroup3, False)
        ClearFields(Me.LayoutControlGroup4, False)
        ClearFields(Me.LayoutControlGroup8, False)
        lbcTo.Items.Clear()
        lbcCc.Items.Clear()
        lbcBcc.Items.Clear()

        TemplateFromGrid.DataSource = Nothing
        TemplateToGrid.DataSource = Nothing
    End Sub

    Private Sub LoadReports()
        If IsNothing(cboRptType.EditValue) Then Exit Sub
        Dim rptType As String = IIf(cboRptType.EditValue = 2, "KPI", "REPORT")
        Dim query As String
        'available reports
        query = "SELECT * FROM view_EmailProfileReports WHERE (RptType = '" & rptType & "') AND (UserID = '" & USER_ID & "') AND (FKeyEmailProfile <> '" & strID & "' OR FKeyEmailProfile IS NULL)"
        TemplateFromGrid.DataSource = MPSDB.CreateTable(query)

        'selected reports
        'query = "SELECT * FROM view_EmailProfileReports WHERE (RptType = '" & rptType & "') AND (UserID = '" & USER_ID & "') AND (FKeyEmailProfile = '" & strID & "')"
        If Not IsNothing(TemplateToGrid.DataSource) Then Exit Sub
        If TemplateToView.RowCount > 0 Then Exit Sub
        query = "SELECT * FROM view_EmailProfileReports WHERE (UserID = '" & USER_ID & "') AND (FKeyEmailProfile = '" & strID & "')"
        TemplateToGrid.DataSource = MPSDB.CreateTable(query)

    End Sub

    Private Sub SaveReports()
        MPSDB.RunSql("DELETE FROM tblUserEmailProfileReports WHERE FKeyEmailProfile='" & strID & "'")

        If TemplateToView.RowCount <= 0 Then Exit Sub
        For cnt As Integer = 0 To TemplateToView.RowCount
            MPSDB.RunSql("INSERT INTO tblUserEmailProfileReports (DateUpdated, LastUpdatedBy, FKeyEmailProfile, FKeyOptTemplate) " & _
                         "VALUES (" & ChangeToSQLDate(DateTime.Now) & ", '" & LastUpdatedBy & "', '" & strID & "', '" & TemplateToView.GetRowCellValue(cnt, "PKey") & "')")
        Next
    End Sub

#Region "Controls Event"

    Private Sub cboProfiles_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboProfiles.EditValueChanged
        strID = cboProfiles.EditValue
        loadData()
    End Sub

    Private Sub cmdAddProfile_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddProfile.Click
        isEditdable = True
        bAddMode = True
        BRECORDUPDATEDs = False
        If cmdAddProfile.Text = "Cancel" Then
            RefreshData()
        Else
            strID = Nothing
            MakeControlsEditable(True)
            ClearFields(Me.LayoutControlGroup9, False)
            ClearControls()
            EnableEditListener(False)
            cboExecType.EditValue = 1
            cboDays.EditValue = 1
            txtInterval.EditValue = 1
            cboRptType.EditValue = 1
            cboRecipient.EditValue = 1
            EnableEditListener(True)
            cboProfiles.ReadOnly = True
            cmdAddProfile.Enabled = True
            cmdEditProfile.Enabled = False
            cmdDelProfile.Enabled = False
            cmdSave.Enabled = True
            cmdAddProfile.Text = "Cancel"
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
        Dim flag As Boolean = False
        Dim Type As String = "", info As Boolean = False
        Dim query As String = ""
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtProfile, cboExecType, cboFrom}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil	'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, FormName, 10, System.Environment.MachineName, txtEmailAdd.EditValue, FormName)
            If lbcTo.Items.Count <> 0 Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtProfile}) Then
                        Exit Sub
                    Else
                        query = "INSERT INTO " & TableName & " (Name, ExecType, ExecTime, Intervals, FKeyEmailAdd, EmailFrom, EmailTo, EmailCc, EmailBcc, EmailSubject, EmailMsg, DateUpdated, LastUpdatedBy, FKeyUserID) " & _
                                " VALUES ('" & txtProfile.Text & "'" & _
                                        ",'" & cboExecType.EditValue & "'" & _
                                        "," & ChangeToSQLDate(GetExecTime()) & "" & _
                                        ",'" & GetIntervals() & "'" & _
                                        ",'" & cboFrom.EditValue & "'" & _
                                        ",'" & cboFrom.Text & "'" & _
                                        ",'" & GetEmailList(lbcTo) & "'" & _
                                        ",'" & GetEmailList(lbcCc) & "'" & _
                                        ",'" & GetEmailList(lbcBcc) & "'" & _
                                        ",'" & txtSubject.Text & "'" & _
                                        ",'" & memoMsg.Text & "'" & _
                                        "," & ChangeToSQLDate(Date.Now) & "" & _
                                        ",'" & LastUpdatedBy & "'" & _
                                        ",'" & USER_ID & "'" & _
                                        ")"
                        info = DB.RunSql(query)
                        SaveReports()
                        BRECORDUPDATEDs = False
                        'get the last inserted Record
                        strID = DB.GetLastInsertedItem("PKey", Me.TableName)
                        Type = "Inserted"
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtProfile}, "PKey<>'" & strID & "'") Then
                        Exit Sub
                    Else
                        query = "UPDATE " & TableName & " SET " & _
                                    "Name='" & txtProfile.Text & "'" & _
                                    ",ExecType='" & cboExecType.EditValue & "'" & _
                                    ",ExecTime=" & ChangeToSQLDate(GetExecTime()) & "" & _
                                    ",Intervals='" & GetIntervals() & "'" & _
                                    ",FKeyEmailAdd='" & cboFrom.EditValue & "'" & _
                                    ",EmailFrom='" & cboFrom.Text & "'" & _
                                    ",EmailTo='" & GetEmailList(lbcTo) & "'" & _
                                    ",EmailCc='" & GetEmailList(lbcCc) & "'" & _
                                    ",EmailBcc='" & GetEmailList(lbcBcc) & "'" &
                                    ",EmailSubject='" & txtSubject.Text & "'" & _
                                    ",EmailMsg='" & memoMsg.Text & "'" & _
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
                MsgBox("No Recipient specified.", MsgBoxStyle.Exclamation, GetAppName)
                flag = False
                ALLOWNEXTS = flag
                Exit Sub
            End If
        End If
        bAddMode = False
        RefreshData()
        If info Then
            MsgBox(GetMessage(Type, info), MsgBoxStyle.Information, GetAppName)
        End If
    End Sub

    Private Sub cboExecType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboExecType.EditValueChanged
        Select Case cboExecType.EditValue
            Case 1
                tabControlExec.SelectedTabPage = tabPageDaily
            Case 2
                tabControlExec.SelectedTabPage = tabPageWeekly
            Case 3
                tabControlExec.SelectedTabPage = tabPageMonthly
        End Select
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        If Not isEditdable Then Exit Sub
        If Trim(txtEmailAdd.Text).Length = 0 Then
            MsgBox("Please specify a valid email to add.", vbInformation, GetAppName)
        ElseIf IsNothing(cboRecipient.EditValue) Then
            MsgBox("Please specify the destination.", vbInformation, GetAppName)
        Else
            Select Case cboRecipient.EditValue
                Case 1
                    lbcTo.Items.Add(txtEmailAdd.Text)
                Case 2
                    lbcCc.Items.Add(txtEmailAdd.Text)
                Case 3
                    lbcBcc.Items.Add(txtEmailAdd.Text)
            End Select
        End If
    End Sub

    Private Sub cmdRemove_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemove.Click
        If Not isEditdable Then Exit Sub
        If selectedList.Items.Count <> 0 Then
            selectedList.Items.Remove(selectedList.SelectedItem)
        End If
    End Sub

    Private Sub ListBoxControlEvent_Click(sender As System.Object, e As System.EventArgs) Handles lbcTo.Click, lbcCc.Click, lbcBcc.Click
        selectedList = CType(sender, DevExpress.XtraEditors.ListBoxControl)
    End Sub

    Private Sub cboRptType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboRptType.EditValueChanged
        LoadReports()
    End Sub

#End Region

#Region "GET/SET"

    Private Sub SetIntervals(type As Integer, value As String)
        If value.Length = 0 Then Exit Sub

        Dim vals As String()
        vals = value.Split(";")
        Select Case type
            Case 1 'daily
                chkMon.Checked = CBool(vals(0))
                chkTue.Checked = CBool(vals(1))
                chkWed.Checked = CBool(vals(2))
                chkThu.Checked = CBool(vals(3))
                chkFri.Checked = CBool(vals(4))
                chkSat.Checked = CBool(vals(5))
                chkSun.Checked = CBool(vals(6))
            Case 2 'weekly
                optMon.Checked = CBool(vals(0))
                optTue.Checked = CBool(vals(1))
                optWed.Checked = CBool(vals(2))
                optThu.Checked = CBool(vals(3))
                optFri.Checked = CBool(vals(4))
                optSat.Checked = CBool(vals(5))
                optSun.Checked = CBool(vals(6))
            Case 3 'monthly
                cboDays.EditValue = CInt(vals(0))
                txtInterval.Text = CInt(vals(1))
        End Select
    End Sub

    Private Function GetIntervals() As String
        Dim retVal As String = ""
        Select Case cboExecType.EditValue
            Case 1 'daily
                retVal = CInt(chkMon.Checked) & ";" & CInt(chkTue.Checked) & ";" & CInt(chkWed.Checked) & ";" & CInt(chkThu.Checked) & ";" & CInt(chkFri.Checked) & ";" & CInt(chkSat.Checked) & ";" & CInt(chkSun.Checked)
            Case 2 'weekly
                retVal = CInt(optMon.Checked) & ";" & CInt(optTue.Checked) & ";" & CInt(optWed.Checked) & ";" & CInt(optThu.Checked) & ";" & CInt(optFri.Checked) & ";" & CInt(optSat.Checked) & ";" & CInt(optSun.Checked)
            Case 3 'monthly
                retVal = cboDays.EditValue & ";" & txtInterval.EditValue
        End Select
        Return retVal
    End Function

    Private Sub SetExecTime(type As Integer, value As String)
        Select Case type
            Case 1
                timeDay.EditValue = CDate(value)
            Case 2
                timeWeek.EditValue = CDate(value)
            Case 3
                timeMonth.EditValue = CDate(value)
        End Select
    End Sub

    Private Function GetExecTime() As DateTime
        Dim retVal As DateTime
        Select Case cboExecType.EditValue
            Case 1
                retVal = timeDay.EditValue
            Case 2
                retVal = timeWeek.EditValue
            Case 3
                retVal = timeMonth.EditValue
        End Select
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

#End Region

#Region "GRID FROM to TO"
    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
    Dim srcGridControl As DevExpress.XtraGrid.GridControl
    Dim dtToTransfer As DataTable

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

    Private Function ConvertSelectedRowToDT(grid As DevExpress.XtraGrid.GridControl) As DataTable
        Dim dTable As DataTable = CType(grid.DataSource, DataTable).Clone
        Dim dRow As DataRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grid.MainView, DevExpress.XtraGrid.Views.Grid.GridView)

        For Each cnt As Integer In view.GetSelectedRows
            dRow = dTable.NewRow()
            For Each dc As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
                dRow(dc.FieldName) = view.GetDataRow(cnt)(dc.FieldName)
            Next
            dTable.Rows.Add(dRow)
        Next

        Return dTable
    End Function

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

    Private Sub cmdTransferAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdTransferAll.Click
        If Not isEditdable Then Exit Sub
        TemplateFromView.SelectAll()
        dtToTransfer = TemplateFromGrid.DataSource
        TransferGridToGridData(TemplateFromGrid, TemplateToGrid, dtToTransfer, "PKey")
    End Sub

    Private Sub cmdRetrieveAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdRetrieveAll.Click
        If Not isEditdable Then Exit Sub
        TemplateToView.SelectAll()
        dtToTransfer = TemplateToGrid.DataSource
        TransferGridToGridData(TemplateToGrid, TemplateFromGrid, dtToTransfer, "PKey")
    End Sub

    Private Sub cmdTransfer_Click(sender As System.Object, e As System.EventArgs) Handles cmdTransfer.Click
        If Not isEditdable Then Exit Sub
        dtToTransfer = ConvertSelectedRowToDT(TemplateFromGrid)
        TransferGridToGridData(TemplateFromGrid, TemplateToGrid, dtToTransfer, "PKey")
    End Sub

    Private Sub cmdRetrieve_Click(sender As System.Object, e As System.EventArgs) Handles cmdRetrieve.Click
        If Not isEditdable Then Exit Sub
        dtToTransfer = ConvertSelectedRowToDT(TemplateToGrid)
        TransferGridToGridData(TemplateToGrid, TemplateFromGrid, dtToTransfer, "PKey")
    End Sub

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

    Private Sub TemplateFromGrid_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TemplateFromGrid.DragDrop
        If Not isEditdable Then Exit Sub
        If srcGridControl.Name = TemplateFromGrid.Name Then Exit Sub
        TransferGridToGridData(TemplateToGrid, _
                               TemplateFromGrid, _
                               TryCast(e.Data.GetData(GetType(DataTable)), DataTable), _
                               "PKey")
    End Sub

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

    Private Sub TemplateToGrid_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles TemplateToGrid.DragDrop
        If Not isEditdable Then Exit Sub
        If srcGridControl.Name = TemplateToGrid.Name Then Exit Sub
        TransferGridToGridData(TemplateFromGrid, _
                               TemplateToGrid, _
                               TryCast(e.Data.GetData(GetType(DataTable)), DataTable), _
                               "PKey")
    End Sub

#End Region

End Class
