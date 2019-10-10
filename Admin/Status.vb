Public Class Status

    Dim KPIAssembly As System.Reflection.Assembly
    Private WithEvents KPIControl As New BaseControl.BaseControl

#Region "Easy Edit"
    Private FormName As String = "Admin System Status"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Private LayoutControlGroupList As New List(Of DevExpress.XtraLayout.LayoutControlGroup)     'added by tony20170222
    Dim bAlwaysShowRepatriation As Boolean = Nothing
#End Region


    Public Overrides Sub RefreshData()
        TableName = "tblAdmStat"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Status Details - " & strDesc)
        strRequiredFields = "txtName;cboStatType"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), 0))
            Me.cboStatType.EditValue = Trim(IfNull(blList.GetFocusedRowData("StatType"), ""))
            Me.chkRepat.Checked = CBool(Trim(IfNull(blList.GetFocusedRowData("Repat"), "0")))
            Me.chkIncludeMedHistory.Checked = CBool(Trim(IfNull(blList.GetFocusedRowData("IncludeMedHistory"), "0")))
            Me.chkDefAshStat.Checked = CBool(Trim(IfNull(blList.GetFocusedRowData("DefAshStat"), "0")))

            Me.chkRetentionRateTermination.Checked = CBool(Trim(IfNull(blList.GetFocusedRowData("RetentionRateTermination"), "0")))

            If IfNull(blList.GetFocusedRowData("RetentionRateTerminationType"), "").Equals(RetentionRateTerminationType.Beneficial) Or _
                        IfNull(blList.GetFocusedRowData("RetentionRateTerminationType"), "").Equals(RetentionRateTerminationType.Unavoidable) Or _
                        IfNull(blList.GetFocusedRowData("RetentionRateTerminationType"), "").Equals(RetentionRateTerminationType.NotApplicable) Then
                Me.cboRetentionRateTerminationType.EditValue = IfNull(blList.GetFocusedRowData("RetentionRateTerminationType"), "")
            Else
                Me.cboRetentionRateTerminationType.EditValue = Nothing
            End If

            Me.rgEarn.EditValue = blList.GetFocusedRowData("LeaveType") 'Added by calvhin 20170209

            MakeReadOnlyListener_ToAllGroups()      'edited by tony20170222
            rgEarn.ReadOnly = True 'Added by calvhin 20170209
            BRECORDUPDATEDs = False
        End If
        AddEditListener_ToAllGroups()               'edited by tony20170222
        If Mid(Trim(IfNull(blList.GetFocusedRowData("PKey"), "")), 1, 3) = "SYS" Then
            RemoveEditListener(Me.txtName)
            RemoveEditListener(Me.cboStatType)
            AllowDeletion(Name, Not CheckIsSystemRecord())
        End If

    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener_ToAllGroups()        'edited by tony20170222
            rgEarn.ReadOnly = False                     'Added by calvhin 20170209
        Else
            MakeReadOnlyListener_ToAllGroups()          'edited by tony20170222
            rgEarn.ReadOnly = True                      'Added by calvhin 20170209
        End If
        AllowDeletion(Name, Not CheckIsSystemRecord())
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        AddEditListener_ToAllGroups()                   'edited by tony20170222
        RemoveReadOnlyListener_ToAllGroups()            'edited by tony20170222
        rgEarn.EditValue = "None"                       'Added by calvhin 20170209
        rgEarn.ReadOnly = False                         'Added by calvhin 20170209
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
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

    Public Overrides Sub SaveData()
        Dim Type As String = "", info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboStatType}) Then
            'added by tony20170418
            If chkRetentionRateTermination.Checked Then
                If cboRetentionRateTerminationType.EditValue Is Nothing Then
                    MsgBox("The status is set as a Retention Rate Termination but a type is not specified.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If IfNull(cboRetentionRateTerminationType.EditValue, "").Equals("") Then
                    MsgBox("The status is set as a Retention Rate Termination but a type is not specified.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil	'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "System Status", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
            If MPSDB.DLookUp("COUNT(*)", "tblAdmStat", 0, "DefAshStat = 1") = 1 And chkDefAshStat.CheckState = Windows.Forms.CheckState.Checked Then
                Dim xtemp As Boolean = DB.RunSql("UPDATE tblAdmStat SET DefAshStat = 0")
            End If
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                    Exit Sub
                Else
                    'info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy, LeaveType", "'" & LastUpdatedBy & "', '" & rgEarn.EditValue & "'"))
                    'edited by tony20170418
                    'info = DB.RunSql(GenerateInsertScript(LayoutControlGroupList, 3, Me.TableName, "LastUpdatedBy, LeaveType", "'" & LastUpdatedBy & "', '" & rgEarn.EditValue & "'"))
                    'info = DB.RunSql(GenerateInsertScript(LayoutControlGroupList, 3, Me.TableName, "LastUpdatedBy, LeaveType, RetentionRateTermination, RetentionRateTerminationType", "'" & LastUpdatedBy & "', '" & rgEarn.EditValue & "', " & IIf(chkRetentionRateTermination.Checked, 1, 0) & ", " & IIf(Not chkRetentionRateTermination.Checked, "NULL", IIf(chkRetentionRateBeneficiaryTermination.Checked, "'BENEFICIARY'", IIf(chkRetentionRateUnavoidableTermination.Checked, "'UNAVOIDABLE'", "NULL"))), New String() {"chkRetentionRateBeneficiaryTermination", "chkRetentionRateUnavoidableTermination", "chkRetentionRateTermination"}))
                    info = DB.RunSql(GenerateInsertScript(LayoutControlGroupList, 3, Me.TableName, "LastUpdatedBy, LeaveType, RetentionRateTermination, RetentionRateTerminationType", "'" & LastUpdatedBy & "', '" & rgEarn.EditValue & "', " & IIf(chkRetentionRateTermination.Checked, 1, 0) & ", " & IIf(chkRetentionRateTermination.Checked, "'" & cboRetentionRateTerminationType.EditValue & "'", "NULL"), New String() {"cboRetentionRateTerminationType", "chkRetentionRateTermination"}))
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    'get the last inserted Record
                    blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
                    Type = "Inserted"
                End If
            Else
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey <>'" & strID & "'") Then
                    Exit Sub
                Else
                    'info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate())", "PKey='" & strID & "'"))
                    'Dim qUpd As String = GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()), LeaveType = '" & rgEarn.EditValue & "'", "PKey='" & strID & "'")
                    'edited by tony20170418
                    'Dim qUpd As String = GenerateUpdateScript(LayoutControlGroupList, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()), LeaveType = '" & rgEarn.EditValue & "'", "PKey='" & strID & "'")
                    'Dim qUpd As String = GenerateUpdateScript(LayoutControlGroupList, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()), LeaveType = '" & rgEarn.EditValue & "', RetentionRateTermination = " & IIf(chkRetentionRateTermination.Checked, 1, 0) & ", RetentionRateTerminationType = " & IIf(Not chkRetentionRateTermination.Checked, "NULL", IIf(chkRetentionRateBeneficiaryTermination.Checked, "'BENEFICIARY'", IIf(chkRetentionRateUnavoidableTermination.Checked, "'UNAVOIDABLE'", "NULL"))), "PKey='" & strID & "'", New String() {"chkRetentionRateBeneficiaryTermination", "chkRetentionRateUnavoidableTermination", "chkRetentionRateTermination"})
                    Dim qUpd As String = GenerateUpdateScript(LayoutControlGroupList, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()), LeaveType = '" & rgEarn.EditValue & "', RetentionRateTermination = " & IIf(chkRetentionRateTermination.Checked, 1, 0) & ", RetentionRateTerminationType = " & IIf(chkRetentionRateTermination.Checked, "'" & cboRetentionRateTerminationType.EditValue & "'", "NULL"), "PKey='" & strID & "'", New String() {"cboRetentionRateTerminationType", "chkRetentionRateTermination"})
                    info = UpdateRelatedAdminName(strID, TableName, qUpd)
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    Type = "Updated"
                End If
            End If
            bAddMode = False
            MsgBox(GetMessage(Type, info), MsgBoxStyle.Information, GetAppName)
            If info Then
                RefreshData()
            End If
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboStatType}, showMsg) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
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

        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "System Status", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
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

    'fill lookupEdits
    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        cboStatType.Properties.DataSource = GetStatType()
        cboRetentionRateTerminationType.Properties.DataSource = GetRetentionRateTerminationType()

        'add all layoutcontrolgroups to list of those that are to be toggled enable/disable
        With LayoutControlGroupList
            .Add(Me.LayoutControl1.Root)
            .Add(Me.LayoutControlGroup_Activity)
            .Add(Me.LayoutControlGroup_Manpower)
            .Add(Me.LayoutControlGroup_MedHistory)
            .Add(Me.LayoutControlGroup_RetentionRate)
        End With

        showHideRetentionRateControlGroup()

        ShowHideRepatriation()

        SetTerminationTypeVisibility()

        cboRetentionRateTerminationType.Properties.BestFit()
        Dim width As Integer = 0
        For Each column As DevExpress.XtraEditors.Controls.LookUpColumnInfo In cboRetentionRateTerminationType.Properties.Columns
            width = width + column.Width
            cboRetentionRateTerminationType.Properties.PopupWidth = width + 4
        Next
    End Sub

    Private Sub cboStatType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboStatType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboStatType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboStatType.EditValueChanged
        If Me.cboStatType.EditValue = 2 Then    'SIGN OFF REASON
            Me.LayoutControlItem_MedHisPopup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.LayoutControlItem_DefaultNextActSOff.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'added by tony20170221
            Me.LayoutControlGroup_MedHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.lblMedicalStatusNote.Text = "Note: If checked, this initiates to show the Medical History pop up entry form when crews are signed off with this status selected as sign off reason."
            Me.LayoutControlGroup_Activity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'end tony
            'Added by Calvhin 20170209
            rgEarn.EditValue = "Earn"
            rgEarn.ReadOnly = True
            'End Calvhin
        ElseIf Me.cboStatType.EditValue = 3 Then    'ASHORE STATUS
            'edited by tony20180709 Me.LayoutControlItem_MedHisPopup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Me.LayoutControlItem_MedHisPopup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.LayoutControlItem_DefaultNextActSOff.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            'added by tony20170221
            'edited by tony20180709 Me.LayoutControlGroup_MedHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Me.LayoutControlGroup_MedHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.lblMedicalStatusNote.Text = "Note: If checked, this initiates to show the Medical History pop up entry form when crews are signed off with this status selected as next activity."
            Me.LayoutControlGroup_Activity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            'end tony
            'Added by Calvhin 20170209
            rgEarn.EditValue = "None"
            rgEarn.ReadOnly = False
            'End Calvhin
        Else
            Me.LayoutControlItem_MedHisPopup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Me.LayoutControlItem_DefaultNextActSOff.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'added by tony20170221
            Me.LayoutControlGroup_MedHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Me.LayoutControlGroup_Activity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'end tony
            'Added by Calvhin 20170209
            rgEarn.EditValue = "Earn"
            rgEarn.ReadOnly = True
            'End Calvhin
        End If

        showHideRetentionRateControlGroup()
    End Sub

    Private Sub chkTermination_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkRetentionRateTermination.CheckedChanged
        SetTerminationTypeVisibility()
    End Sub

    Private Sub SetTerminationTypeVisibility()
        If chkRetentionRateTermination.Checked Then
            LayoutControlItemTerminationType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItemTerminationType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Function CheckIsSystemRecord() As Boolean
        Return IfNull(blList.GetFocusedRowData("isSysRecord"), False)
    End Function


#Region "KPI Retention Rate"
    Private Sub showHideRetentionRateControlGroup()
        Select Case cboStatType.EditValue
            Case StatusType.Ashore, StatusType.SignOffReason
                LayoutControlGroup_RetentionRate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Case Else
                LayoutControlGroup_RetentionRate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Select
    End Sub
#End Region

#Region "Enable/Disable Sub Controls"
    Sub AddEditListener_ToAllGroups()
        For Each obj As DevExpress.XtraLayout.LayoutControlGroup In LayoutControlGroupList
            AddEditListener(obj)
        Next
    End Sub
    Sub MakeReadOnlyListener_ToAllGroups()
        For Each obj As DevExpress.XtraLayout.LayoutControlGroup In LayoutControlGroupList
            MakeReadOnlyListener(obj)
        Next
    End Sub

    Sub RemoveReadOnlyListener_ToAllGroups()
        For Each obj As DevExpress.XtraLayout.LayoutControlGroup In LayoutControlGroupList
            RemoveReadOnlyListener(obj)
        Next
    End Sub
#End Region

#Region "Repatriation" 'an Elburg-specific control
    Sub ShowHideRepatriation()
        If IsNothing(bAlwaysShowRepatriation) Then
            Dim cRepatriation = MPSDB.GetConfig("HAS_ADMSTAT_REPATRIATION")
            If IsNothing(cRepatriation) Then
                bAlwaysShowRepatriation = False
            Else
                bAlwaysShowRepatriation = IfNull(cRepatriation, "").Equals("1")
            End If
        End If

        If bAlwaysShowRepatriation Then
            Me.LayoutControlGroup_Manpower.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            Me.LayoutControlGroup_Manpower.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub
#End Region

End Class
