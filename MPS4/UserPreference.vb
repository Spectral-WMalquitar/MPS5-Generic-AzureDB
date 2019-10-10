Public Class UserPreference
    Private Sub initControl()
        cboRefresh.Properties.DataSource = getRefeshSource()
        LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never  'added by tony20170621 - do not need 'Refresh Settings' anymore 
        lcgCrewListItems.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never 'added by tony20170621 - do not need Crew List Items

    End Sub

    Public Overrides Sub RefreshData()
        If Not bLoaded Then
            initControl()
            cboRefresh.EditValue = getUserRefreshRate()
            'chkActivity.EditValue = CType(IfNull(GetUserSetting("ShowAct"), "False"), Boolean)
            'chkExpDoc.EditValue = CType(IfNull(GetUserSetting("ShowExpDocs"), "False"), Boolean)
            'txtDays.Text = CType(IfNull(GetUserSetting("DocExpDays"), "0"), Integer)
            Dim strDueDateExpDays As String = GetUserSetting("DueDateExpDays")
            Dim strShowAct As String = GetUserSetting("ShowAct")
            Dim strShowExpDoc As String = GetUserSetting("ShowExpDocs")
            Dim strShowPlanning As String = GetUserSetting("ShowPlanning")
            Dim strDocExpDays As String = GetUserSetting("DocExpDays")
            Dim strLocPlusDays As String = DB.DLookUp("TextValue", "tblConfig", "", "Code='EXPIRY_BUFFER'")
            Dim strExpDocsAlert As String = GetUserSetting("ExpDocsAlert")
            Dim strUseCrewCmpl As String = GetUserSetting("UseCrewCmpl") 'Added by calvhin_20170314
            Dim strtxtCourseRetakeDueDays As String = GetUserSetting("DueCourseToRetakeInDays") 'Added by tony20180115

            txtDaysDueContract.Text = CType(IIf(strDueDateExpDays.Equals(""), "0", strDueDateExpDays), Integer)
            chkActivity.EditValue = CType(IIf(strShowAct.Equals(""), "False", strShowAct), Boolean)
            chkPlanning.EditValue = CType(IIf(strShowPlanning.Equals(""), "False", strShowPlanning), Boolean)
            chkExpDoc.EditValue = CType(IIf(strShowExpDoc.Equals(""), "False", strShowExpDoc), Boolean)
            txtDays.Text = CType(IIf(strDocExpDays.Equals(""), "0", strDocExpDays), Integer)
            'removed by tony20170621 - do not need anymore txtLOCDays.Text = CType(IIf(strLocPlusDays.Equals(""), "0", strLocPlusDays), Integer)
            chkExpDocAlert.EditValue = CType(IIf(strExpDocsAlert.Equals(""), "False", strExpDocsAlert), Boolean)
            chkUseCrewCmpl.EditValue = CType(IIf(strUseCrewCmpl.Equals(""), "False", strUseCrewCmpl), Boolean) 'Added by calvhin_20170314

            txtCourseRetakeDueDays.Text = CType(IIf(strtxtCourseRetakeDueDays.Equals(""), "0", strtxtCourseRetakeDueDays), Integer)
            bLoaded = True
            AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewList, lcgExpDoc, lcgCrewListItems, LCGLTP, lcgContractDue, lgcRepeatCourseTraining})
        End If
        BRECORDUPDATEDs = False

        AddHandler txtDays.EditValueChanging, AddressOf ExpDocSettings_EditValueChanging
        'removed by tony20170621 - do not need anymore AddHandler txtLOCDays.EditValueChanging, AddressOf ExpDocSettings_EditValueChanging
        AddHandler chkExpDocAlert.EditValueChanging, AddressOf ExpDocSettings_EditValueChanging
    End Sub

    Public Overrides Sub SaveData()
        Me.header.Focus()
        If BRECORDUPDATEDs Then
            SaveUserSetting("DueDateExpDays", txtDaysDueContract.EditValue)
            SaveUserSetting("RefreshRate", cboRefresh.EditValue)
            SaveUserSetting("DocExpDays", txtDays.EditValue)
            SaveUserSetting("ExpDocsAlert", chkExpDocAlert.EditValue)
            SaveUserSetting("ShowAct", chkActivity.EditValue)
            SaveUserSetting("ShowExpDocs", chkExpDoc.EditValue)
            SaveUserSetting("ShowPlanning", chkPlanning.EditValue)
            SaveUserSetting("UseCrewCmpl", chkUseCrewCmpl.EditValue) 'Added by calvhin_20170314
            SaveUserSetting("DueCourseToRetakeInDays", txtCourseRetakeDueDays.Text) 'Added by tony20180118
            'removed by tony20170621 - do not need anymore DB.RunSql("UPDATE tblConfig SET TextValue = '" & txtLOCDays.EditValue & "' WHERE Code = 'EXPIRY_BUFFER'")
            USER_INFO.RefreshMode = cboRefresh.EditValue
            MsgBox(GetMessage("Saved", True), MsgBoxStyle.Information, GetAppName())
            BRECORDUPDATEDs = False
        End If
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            flag = True
            ALLOWNEXTS = flag
            SaveData()
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    'Get User RefreshRate
    Private Function getUserRefreshRate() As String
        Dim retval As String = ""
        retval = GetUserSetting("RefreshRate")

        If retval.Equals("") Then
            retval = REFRESHRATE 'Default RefreshRate
        End If

        Return retval
    End Function

#Region "DataSources"
    Private Function getRefeshSource() As DataTable
        Dim retTable As New DataTable
        'retTable.Columns.Add("PKey", System.Type.GetType("System.String"))
        retTable.Columns.Add("Name", System.Type.GetType("System.String"))
        With retTable.Rows
            .Add("Automatic")
            .Add("Manual")
        End With
        Return retTable
    End Function
#End Region

    Private Sub ExpDocSettings_EditValueChanging(sender As System.Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        Dim val As Boolean
        Dim strOverrideExpDoc As String = DB.DLookUp("TextValue", "tblConfig", "", "Code='OVERRIDE_EXPDOC'")
        val = CType(IIf(strOverrideExpDoc.Equals(""), "False", strOverrideExpDoc), Boolean)
        If val Then
            MsgBox("The Administrator has assigned a default configuration. Overriding of this setting is disabled.", vbInformation, GetAppName)
            e.Cancel = True
        End If
    End Sub

End Class
