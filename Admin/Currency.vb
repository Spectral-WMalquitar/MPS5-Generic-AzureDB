Public Class Currency

#Region "Easy Edit"
    Private FormName As String = "Admin Currency Details" '"Admin Fleet Manager"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region


    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString
        Me.LayoutControl1.AllowCustomization = False
        Me.cboFKeyCntry.Properties.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.CntryList ORDER BY Name ASC")
    End Sub


    Public Overrides Sub RefreshData()
        TableName = "tblAdmCurr"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Currency Details - " & strDesc)
        strRequiredFields = "txtName;txtSymbol;cboFKeyCntry"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            Me.txtSymbol.Text = Trim(IfNull(blList.GetFocusedRowData("Symbol"), ""))
            Me.cboFKeyCntry.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyCntry"), ""))
            Me.txtRemarks.Text = Trim(IfNull(blList.GetFocusedRowData("Remarks"), ""))
            Me.chkRef.Checked = IfNull(blList.GetFocusedRowData("Ref"), False)
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
        RemoveEditListener(Me.chkRef, False)

    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowSaving(Name, True) 'Enable save button 
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            'get the max SortCode
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            BRECORDUPDATEDs = False
        End If
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
        End If
    End Sub

    Private Sub CheckRef(ByVal _id As String)
        Dim withRefID As String = ""
        Dim withRefName As String = "", NewRefName As String = ""
        Dim result As Boolean = False

        withRefID = DB.DLookUp("PKey", Me.TableName, "", "Ref='True'")
        withRefName = DB.DLookUp("Name", Me.TableName, "", "PKey='" & withRefID & "'")
        NewRefName = DB.DLookUp("Name", Me.TableName, "", "PKey='" & _id & "'")

        If withRefID = "" Then
            DB.RunSql("UPDATE dbo.tblAdmCurr SET Ref='True' WHERE PKey='" & _id & "'")
        Else
            If (chkRef.Checked = True) And withRefID <> strID Then
                If MsgBox("Are you sure you want to change the Referential Currency: '" & withRefName & "' to '" & NewRefName & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                    DB.RunSql("UPDATE dbo.tblAdmCurr SET Ref='False' WHERE PKey='" & withRefID & "'")
                    DB.RunSql("UPDATE dbo.tblAdmCurr SET Ref='True' WHERE PKey='" & _id & "'")
                End If
            End If
        End If
    End Sub

    Public Overrides Sub SaveData()
        Dim type As String = "", info As Boolean = False, id As String = ""
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtSymbol, cboFKeyCntry}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Currency", 10, System.Environment.MachineName, txtName.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSymbol}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    BRECORDUPDATEDs = False
                    'get the last inserted Record
                    id = DB.GetLastInsertedItem("PKey", Me.TableName)
                    CheckRef(id)
                    blList.RefreshData()
                    blList.SetSelection(id)
                    type = "Inserted"
                End If

            Else
                id = strID
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSymbol}, "PKey<>'" & id & "'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & id & "'"))
                    CheckRef(id)
                    type = "Updated"
                    BRECORDUPDATEDs = False
                End If
            End If
            blList.RefreshData()
            If info Then
                RefreshData()
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
            End If
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtSymbol, cboFKeyCntry}) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSymbol}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSymbol}, "PKey<>'" & strID & "'") Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
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

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Currency", 10, System.Environment.MachineName, txtName.EditValue, FormName)

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
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    ClearFields(Me.LayoutControl1.Root, False)
                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    blList.RefreshData()
                    RefreshData()
                    BRECORDUPDATEDs = False
                End If
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If
        End If
    End Sub

    Private Sub cboFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
