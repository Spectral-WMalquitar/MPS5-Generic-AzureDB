Public Class PhilHealth

#Region "Easy Edit"
    Private FormName As String = "Admin PhilHealth"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region


    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
    End Sub


    Public Overrides Sub RefreshData()
        TableName = "tblMCR"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Philhealth Contribution Table")
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        strRequiredFields = "txtSalary;txtSalaryTo;txtSalCredit;txtMCREmployer;txtMCREmployee;"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtSalary.Text = Trim(IfNull(blList.GetFocusedRowData("Salary"), ""))
            Me.txtSalaryTo.Text = Trim(IfNull(blList.GetFocusedRowData("SalaryTo"), ""))
            Me.txtSalCredit.Text = Trim(IfNull(blList.GetFocusedRowData("SalCredit"), ""))
            Me.txtMCREmployer.Text = Trim(IfNull(blList.GetFocusedRowData("MCREmployer"), ""))
            Me.txtMCREmployee.Text = Trim(IfNull(blList.GetFocusedRowData("MCREmployee"), ""))
            Me.txtRate.Text = Trim(IfNull(blList.GetFocusedRowData("Rate"), ""))
            ApplyROnlyListener()
            BRECORDUPDATEDs = False
        End If
        ApplyListener()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveROnlyListener()
        If Not bAddMode Then
            ClearFields(Me.layCtrlSalaryRange, False)
            ClearFields(Me.layCtrlSalCred, False)
            ClearFields(Me.layCtrlPhilHealth, False)
            AllowSaving(Name, True) 'Enable save button 
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.txtSalary.Focus()
            Me.txtSalary.BackColor = SEL_COLOR
            BRECORDUPDATEDs = False
        End If
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
    Public Overrides Sub SaveData()
        Dim type As String = "", info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryTo, txtSalCredit, txtMCREmployer, txtMCREmployee}) Then
            'LASTUPDATED BY FORMAT
            'getusername() & <Description><FormName>
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtSalary.EditValue, FormName) 'neil 'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Philhealth", 10, System.Environment.MachineName, Me.txtSalary.EditValue & " to " & Me.txtSalaryTo.EditValue, FormName)

            If bAddMode Then
                If Not IsRangeValid(CDbl(txtSalary.Text), CDbl(txtSalaryTo.Text), DB, Me.TableName, "Salary", "SalaryTo") Then
                    Exit Sub
                Else
                    info = DB.RunSql("INSERT INTO dbo." & Me.TableName & " (Salary,SalaryTo,SalCredit,MCREmployer,MCREmployee,DateUpdated,LastUpdatedBy,Rate) VALUES (" & Me.txtSalary.EditValue & "," & Me.txtSalaryTo.EditValue & "," & Me.txtSalCredit.EditValue & "," & Me.txtMCREmployer.EditValue & "," & Me.txtMCREmployee.EditValue & ",GETDATE(),'" & LastUpdatedBy & "', " & IfNull(Me.txtRate.EditValue, CDbl(0)) & ")")
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    'get the last inserted Record
                    blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
                    type = "Inserted"
                End If
            Else
                If Not IsRangeValid(CDbl(txtSalary.Text), CDbl(txtSalaryTo.Text), DB, Me.TableName, "Salary", "SalaryTo", , "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    info = DB.RunSql("UPDATE dbo." & Me.TableName & " SET Salary=" & txtSalary.EditValue & ",SalaryTo=" & txtSalaryTo.EditValue & ",SalCredit=" & txtSalCredit.EditValue & ",MCREmployer=" & txtMCREmployer.EditValue & ",MCREmployee=" & txtMCREmployee.EditValue & ",LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=GETDATE(), Rate = " & IfNull(Me.txtRate.EditValue, CDbl(0)) & " WHERE PKey='" & strID & "'")
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    blList.SetSelection(strID)
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
        'If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalCredit, txtMCREmployer, txtMCREmployee}) Then
        '    'LASTUPDATED BY FORMAT
        '    'getusername() & <Description><FormName>
        '    If bAddMode Then
        '        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryTo}) Then
        '            Exit Sub
        '        Else
        '            info = DB.RunSql("INSERT INTO dbo." & Me.TableName & " (Salary,SalaryTo,SalCredit,MCREmployer,MCREmployee,DateUpdated,LastUpdatedBy) VALUES (" & Me.txtSalary.EditValue & "," & Me.txtSalaryTo.EditValue & "," & Me.txtSalCredit.EditValue & "," & Me.txtMCREmployer.EditValue & "," & Me.txtMCREmployee.EditValue & ",GETDATE(),'" & LastUpdatedBy & "')")
        '            BRECORDUPDATEDs = False
        '            blList.RefreshData()
        '            'get the last inserted Record
        '            blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
        '            type = "Inserted"
        '        End If
        '    Else
        '        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryTo}) Then
        '            Exit Sub
        '        Else
        '            info = DB.RunSql("UPDATE dbo." & Me.TableName & " SET Salary=" & txtSalary.EditValue & ",SalaryTo=" & txtSalaryTo.EditValue & ",SalCredit=" & txtSalCredit.EditValue & ",MCREmployer=" & txtMCREmployer.EditValue & ",MCREmployee=" & txtMCREmployee.EditValue & ",LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=GETDATE() WHERE PKey='" & strID & "'")
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
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryTo}) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryTo}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtSalary, txtSalaryTo}, "PKey<>'" & strID & "'") Then
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

        If MsgBox("Are you sure want to delete the item?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Philhealth", 10, System.Environment.MachineName, Me.txtSalary.EditValue & " to " & Me.txtSalaryTo.EditValue, FormName)

                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
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

    'Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        OnRightClick(Name)
    '    End If
    'End Sub

    Private Sub ApplyListener()
        AddEditListener(Me.layCtrlSalaryRange)
        AddEditListener(Me.layCtrlSalCred)
        AddEditListener(Me.layCtrlPhilHealth)
        AddEditListener(Me.layCtrlPhilHealthFixedAmount)
        AddEditListener(Me.layCtrlPhilHealthPercentage)
    End Sub

    Private Sub RemoveListener()
        RemoveEditListener(Me.layCtrlSalaryRange)
        RemoveEditListener(Me.layCtrlSalCred)
        RemoveEditListener(Me.layCtrlPhilHealth)
        RemoveEditListener(Me.layCtrlPhilHealthFixedAmount)
        RemoveEditListener(Me.layCtrlPhilHealthPercentage)
    End Sub

    Private Sub ApplyROnlyListener()
        MakeReadOnlyListener(Me.layCtrlSalaryRange)
        MakeReadOnlyListener(Me.layCtrlSalCred)
        MakeReadOnlyListener(Me.layCtrlPhilHealth)
        MakeReadOnlyListener(Me.layCtrlPhilHealthFixedAmount)
        MakeReadOnlyListener(Me.layCtrlPhilHealthPercentage)
    End Sub

    Private Sub RemoveROnlyListener()
        RemoveReadOnlyListener(Me.layCtrlSalaryRange)
        RemoveReadOnlyListener(Me.layCtrlSalCred)
        RemoveReadOnlyListener(Me.layCtrlPhilHealth)
        RemoveReadOnlyListener(Me.layCtrlPhilHealthFixedAmount)
        RemoveReadOnlyListener(Me.layCtrlPhilHealthPercentage)
    End Sub


    Private Sub txtMCREmployer_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtMCREmployer.EditValueChanging
        If bAddMode Or isEditdable Then
            If e.NewValue <> 0 And IfNull(txtRate.EditValue, CDbl(0)) <> 0 Then
                If MsgBox("You are setting a fixed contribution amount. The rate will be automatically set to 0." & vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    txtRate.EditValue = 0
                End If
            End If
        End If
    End Sub

    Private Sub txtMCREmployee_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtMCREmployee.EditValueChanging
        If bAddMode Or isEditdable Then
            If e.NewValue <> 0 And IfNull(txtRate.EditValue, CDbl(0)) <> 0 Then
                If MsgBox("You are setting a fixed contribution amount. The rate will be automatically set to 0." & vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    txtRate.EditValue = 0
                End If
            End If
        End If
    End Sub

    Private Sub txtRate_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtRate.EditValueChanging
        If bAddMode Or isEditdable Then
            If e.NewValue <> 0 And (IfNull(txtMCREmployee.EditValue, 0) <> 0 Or IfNull(txtMCREmployer.EditValue, 0) <> 0) Then
                If MsgBox("You are setting the rate percentage. The fixed contribution amounts will be automatically set to 0." & vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    txtMCREmployee.EditValue = 0
                    txtMCREmployer.EditValue = 0
                End If
            End If
        End If
    End Sub
End Class
