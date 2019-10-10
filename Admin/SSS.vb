Public Class SSS
#Region "Easy Edit"
    Private FormName As String = "Remittance Receipt"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Private Sub ApplyListener()
        AddEditListener(Me.LayoutControlGroup2)
        AddEditListener(Me.LayoutControlGroup3)
        AddEditListener(Me.LayoutControlGroup4)
    End Sub

    Private Sub RemoveListener()
        RemoveEditListener(Me.LayoutControlGroup2)
        RemoveEditListener(Me.LayoutControlGroup3)
        RemoveEditListener(Me.LayoutControlGroup4)
    End Sub

    Private Sub ApplyROnlyListener()
        MakeReadOnlyListener(Me.LayoutControlGroup2)
        MakeReadOnlyListener(Me.LayoutControlGroup3)
        MakeReadOnlyListener(Me.LayoutControlGroup4)
    End Sub

    Private Sub RemoveROnlyListener()
        RemoveReadOnlyListener(Me.LayoutControlGroup2)
        RemoveReadOnlyListener(Me.LayoutControlGroup3)
        RemoveReadOnlyListener(Me.LayoutControlGroup4)
    End Sub

    Private Sub ClearItems()
        ClearFields(Me.LayoutControlGroup2, False)
        ClearFields(Me.LayoutControlGroup3, False)
        ClearFields(Me.LayoutControlGroup4, False)
    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblSSS"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "SSS Contribution Table")
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        strRequiredFields = "txtSalary;txtSalaryTo;txtSalCredit;txtSSEmployee;txtSSEmployer;txtECEmployer;txtSalaryto"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtSalaryto.Text = Trim(IfNull(blList.GetFocusedRowData("SalaryTo"), ""))
            Me.txtSalary.Text = Trim(IfNull(blList.GetFocusedRowData("Salary"), ""))
            Me.txtSalCredit.Text = Trim(IfNull(blList.GetFocusedRowData("SalCredit"), ""))
            Me.txtSSEmployee.Text = Trim(IfNull(blList.GetFocusedRowData("SSEmployee"), ""))
            Me.txtSSEmployer.Text = Trim(IfNull(blList.GetFocusedRowData("SSEmployer"), ""))
            Me.txtECEmployer.Text = Trim(IfNull(blList.GetFocusedRowData("ECEmployer"), ""))
            ApplyROnlyListener()
            BRECORDUPDATEDs = False
        End If
        ApplyListener()
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtSalary.Focus()
        If isEditdable Then
            RemoveROnlyListener()
        Else
            ApplyROnlyListener()
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveROnlyListener()
        If Not bAddMode Then
            ClearItems()
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            Me.txtSalary.Focus()
            Me.txtSalary.BackColor = SEL_COLOR
            BRECORDUPDATEDs = False
        End If
    End Sub

    Public Overrides Sub SaveData()
        Dim type As String = "", info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryto, txtSalCredit, txtSSEmployer, txtECEmployer, txtSSEmployee}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtSalary.EditValue, FormName) 'neil	'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "SSS", 10, System.Environment.MachineName, Me.txtSalary.EditValue & " to " & Me.txtSalaryto.EditValue, FormName)
            If bAddMode Then
                If Not IsRangeValid(CDbl(txtSalary.Text), CDbl(txtSalaryto.Text), DB, Me.TableName, "Salary", "SalaryTo") Or CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalCredit}) Then
                    Exit Sub
                Else
                    'Insert Statement Here
                    info = DB.RunSql("INSERT INTO dbo." & Me.TableName & _
                          "(SalaryTo " & _
                          ",Salary" & _
                         ",SalCredit" & _
                          ",SSEmployee" & _
                          ",SSEmployer" & _
                          ",ECEmployer" & _
                          ",DateUpdated" & _
                         ",LastUpdatedBy)" & _
                         "VALUES(" & _
                         "'" & Me.txtSalaryto.Text & "'" & _
                         ",'" & Me.txtSalary.Text & "'" & _
                         ",'" & Me.txtSalCredit.Text & "'" & _
                         ",'" & Me.txtSSEmployee.Text & "'" & _
                         ",'" & Me.txtSSEmployer.Text & "'" & _
                         ",'" & Me.txtECEmployer.Text & "'" & _
                         ",GETDATE()" & _
                         ",'" & LastUpdatedBy & "')")
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
                    type = "Inserted"
                End If
            Else
                If Not IsRangeValid(CDbl(txtSalary.Text), CDbl(txtSalaryto.Text), DB, Me.TableName, "Salary", "SalaryTo", "OVERLAP", "PKey<>'" & strID & "'") Or CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalCredit}, "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    'Update Statement Here
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControlGroup2, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControlGroup3, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControlGroup4, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
                    'info = DB.RunSql("UPDATE dbo")
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    type = "Updated"
                End If
            End If
            bAddMode = False
            RefreshData()
            If info Then
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
            End If
        End If
        'Dim type As String = "", info As Boolean = False
        'If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryto}) Then
        '    If bAddMode Then
        '        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryto, txtSalCredit, txtSSEmployee, txtSSEmployer, txtECEmployer, txtSalaryto}) Then
        '            Exit Sub
        '        Else
        '            'Insert Statement Here
        '            info = DB.RunSql("INSERT INTO dbo." & Me.TableName & _
        '                              "(SalaryTo " & _
        '                              ",Salary" & _
        '                             ",SalCredit" & _
        '                              ",SSEmployee" & _
        '                              ",SSEmployer" & _
        '                              ",ECEmployer" & _
        '                              ",DateUpdated" & _
        '                             ",LastUpdatedBy)" & _
        '                             "VALUES(" & _
        '                             "'" & Me.txtSalaryto.Text & "'" & _
        '                             ",'" & Me.txtSalary.Text & "'" & _
        '                             ",'" & Me.txtSalCredit.Text & "'" & _
        '                             ",'" & Me.txtSSEmployee.Text & "'" & _
        '                             ",'" & Me.txtSSEmployer.Text & "'" & _
        '                             ",'" & Me.txtECEmployer.Text & "'" & _
        '                             ",GETDATE()" & _
        '                             ",'" & LastUpdatedBy & "')")
        '            BRECORDUPDATEDs = False
        '            blList.RefreshData()
        '            blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
        '            type = "Inserted"
        '        End If
        '    Else
        '        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryto}, "PKey<>'" & strID & "'") Then
        '            Exit Sub
        '        Else
        '            'Update Statement Here
        '            info = DB.RunSql(GenerateUpdateScript(Me.LayoutControlGroup2, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
        '            info = DB.RunSql(GenerateUpdateScript(Me.LayoutControlGroup3, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
        '            info = DB.RunSql(GenerateUpdateScript(Me.LayoutControlGroup4, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
        '            'info = DB.RunSql("UPDATE dbo")
        '            BRECORDUPDATEDs = False
        '            blList.RefreshData()
        '            type = "Updated"
        '        End If
        '    End If
        '    bAddMode = False
        '    RefreshData()
        '    If info Then
        '        MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
        '    End If
        'End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryto}, showMsg) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryto}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryto}, "PKey<>'" & strID & "'") Then
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
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "SSS", 10, System.Environment.MachineName, Me.txtSalary.EditValue & " to " & Me.txtSalaryto.EditValue, FormName)
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

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
    End Sub

End Class
