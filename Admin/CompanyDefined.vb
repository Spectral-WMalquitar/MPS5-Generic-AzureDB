
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Public Class CompanyDefined

#Region "Easy Edit"
    Private FormName As String = "Company Defined Types"
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
    Private documentGroupKey As String = ""
#End Region

    Private Sub InitControls()
        LayoutControl1.AllowCustomization = False
        LayoutControlGroup1.AllowCustomizeChildren = False

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
    End Sub

    Public Overrides Sub DeleteData()
        DeleteMain()
    End Sub

    ' START: Adding manual deletion for data - 2016-01-07.
    Private Sub DeleteMain()
        Dim info As Boolean = False
        Dim recordsToDelete As New ArrayList


        If MessageBox.Show("Are you sure want to delete the '" & strDesc & "'?", "Delete Company Defined item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            recordsToDelete.Add("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Company Defined", 10, System.Environment.MachineName, txtName.EditValue, FormName)
            clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
            '<!--added by tony20180922 : Log Deletion
            oLogDeletion.Init()
            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                FormName, _
                "Admin", _
                TableName, _
                "PKey IN ('" & strID & "')", _
                "<< Delete Admin Data - " & FormName & " >>", _
                LogDeletion.DeletionType.Manual, _
                "Manually Deleted in <" & FormName & ">", _
                GetUserName())
            '-->
            info = DB.RunSqls(recordsToDelete)
            blList.RefreshData()
            RefreshData()
            If info Then
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                MessageBox.Show("Company Defined item successfully deleted.", GetAppName(), MessageBoxButtons.OK, MessageBoxIcon.Information)
                RefreshData()
            End If
        End If
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        TableName = "tblAdmDocument"

        If Not bLoaded Then
            InitControls()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            Me.txtBufferNo.Text = Trim(IfNull(blList.GetFocusedRowData("BufferNo"), ""))
            Me.txtFileTag.Text = Trim(IfNull(blList.GetFocusedRowData("FileTag"), ""))
            Me.documentGroupKey = Trim(IfNull(blList.GetFocusedRowData("FKeyDocGroup"), ""))
            BRECORDUPDATEDs = False
        End If

        AddEditListener(Me.LayoutControl1.Root)
        MakeReadOnlyListener(Me.LayoutControl1.Root)
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            txtName.Focus()
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Else
            txtName.Focus()
        End If
    End Sub

    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)

        If Not bAddMode Then
            strID = ""
            strDesc = "New Record"
            bAddMode = True
            BRECORDUPDATEDs = False
            ClearFields(Me.LayoutControl1.Root, False)
            AllowSaving(Name, True)      'Enable Save button 
            AllowDeletion(Name, False)   'Disable Delete button
            blList.HideSelection()
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            '<!-- added by tony20171124
            Try
                Me.txtFileTag.Text = GenerateFileTag(MPSDB)
            Catch ex As Exception
            End Try
            '-->
        End If
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()

        Dim type As String = ""
        Dim info As Boolean = False
        Dim id As String = ""
        Me.header.Focus()
        Dim query As String = ""

        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag, txtBufferNo}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Company Defined", 10, System.Environment.MachineName, txtName.EditValue, FormName)
            If bAddMode Then
                'info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                query = "INSERT INTO tblAdmDocument (Name, FKeyDocGroup, BufferNo, FileTag, LastUpdatedBy, SortCode ) " & _
                                      "VALUES ('" & CleanInput(txtName.Text) & "', 'SYSCOMPDEF', " & txtBufferNo.Text & ", '" & CleanInput(txtFileTag.Text) & "', '" & LastUpdatedBy & "', " & txtSortCode.Text & " )"
                info = DB.RunSql(query)
                BRECORDUPDATEDs = False
                id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                type = "Added."
            Else
                id = strID
                query = "UPDATE tblAdmDocument SET " & _
                        "Name = '" & CleanInput(txtName.Text) & "'," & _
                        "BufferNo =" & txtBufferNo.Text & ", " & _
                        "FileTag = '" & CleanInput(txtFileTag.Text) & "'," & _
                        "LastUpdatedBy = '" & LastUpdatedBy & "', " & _
                        "SortCode  = " & txtSortCode.Text & " " & _
                        "WHERE PKey = '" & id & "' "
                info = DB.RunSql(query)
                'info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & id & "'"))
                BRECORDUPDATEDs = False
                type = "Updated."
            End If
        End If

        blList.RefreshData()            'Refresh the main list.
        blList.SetSelection(id)         'Point to the newly-added competence.
        RefreshData()                   'Refresh all sub-data.
        If info Then
            MessageBox.Show("Records has been successfully " & type, "Manage Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then

            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtSortCode}, showMsg) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSortCode}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData() '
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData() '
                    End If
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
End Class
