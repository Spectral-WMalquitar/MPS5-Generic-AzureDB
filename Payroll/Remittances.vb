Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class Remittances
    Dim isRecordCanBeSaved As Boolean = True
    Dim dtRelationship As New DataTable
    Dim dtTypeAllot As New DataTable
    Dim dtCity As New DataTable
    Dim dtState As New DataTable
    Dim dtCntry As New DataTable
    Dim dtBank As New DataTable
    Dim dtBranch As New DataTable
    Dim dtAccType As New DataTable
    Dim dtCurrency As New DataTable
    Dim dtAllottee As New DataTable
    Dim dtAllotment As New DataTable
    Dim dtOtherEarning As New DataTable
    Dim dtOtherDeduction As New DataTable
    Dim dtAdmWageAsh As New DataTable
    Dim arrEditedAllot As New ArrayList
    Dim arrEditedEarnings As New ArrayList
    Dim arrEditedDeductions As New ArrayList
    Dim CrewID As String = ""
    Dim isAllotteeEdited As Boolean
    Dim isAllotTypeEdited As Boolean
    Dim LastUpdatedBy As String
    Dim strDeleteCap As String
    Dim dDefaultPeriod As Date
    Dim frmViewRel As frmRelatives
    Dim payfunc As New PayrollFunctions
    Dim isSaving As Boolean = False
    Dim clsAudit As New clsAudit

#Region "Overridables"
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        Me.LayoutControl1.AllowCustomization = False
        'Me.LayoutControl2.AllowCustomization = False
        'Me.LayoutControl3.AllowCustomization = False
        'Me.LayoutControl4.AllowCustomization = False

        If bLoaded = False Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 0
            tabEarnDed.SelectedTabPageIndex = 0

            Try
                gvAllottee.Columns("WAllotSorting").SortOrder = ColumnSortOrder.Ascending
                gvAllottee.Columns("Fullname").SortOrder = ColumnSortOrder.Ascending

            Catch ex As Exception

            End Try
            AllowAddition(Name, True)
            AllowEditing(Name, True)
            AllowSaving(Name, False)
            AllowDeletion(Name, True)

            SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)

            SetAddCaption(Name, "Add")
            SetSaveCaption(Name, "Save")
            SetEditCaption(Name, "Edit")

            initDatatables()
            initAllotmentDT()
            initOtherEarningsDT()
            initOtherDeductionsDT()
            blList.Draggable(False)
            clsAudit.propSQLConnStr = DB.GetConnectionString
            bLoaded = True
        End If

        CrewID = blList.GetID()
        dtAllottee = DB.CreateTable("SELECT * FROM [tblRemittance] WHERE FKeyIDNbr = '" & CrewID & "' ORDER BY LName, FName")

        editAddModeControls(True)
        defaultControls()
        gcAllottee.DataSource = dtAllottee
        gcAllotment.DataSource = dtAllotment
        gcOtherDeduction.DataSource = dtOtherDeduction
        gcOtherEarnings.DataSource = dtOtherEarning
        gvAllottee_FocusedRowChanged(Nothing, Nothing)
        bAddMode = False
        isEditdable = False
        isAllotteeEdited = False
        isAllotTypeEdited = False
        BRECORDUPDATEDs = False
        isSaving = False

        RemoveEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup_AlloteeDetails, LayoutControlGroup_BankDetails}, False)
        AllowEditing(Name, gvAllottee.RowCount > 0)
        'gcAllottee.Focus()
    End Sub

    Public Overrides Sub AddData()
        AllowEditing(Name, False)
        AllowDeletion(Name, False)
        AllowSaving(Name, True)

        txtFName.EditValue = Nothing
        txtLName.EditValue = Nothing
        txtMName.EditValue = Nothing
        lueRelationship.EditValue = Nothing
        'edited by tony20180711 
        'lueTypeOfAllot.EditValue = Nothing
        lueTypeOfAllot.EditValue = "None"
        txtTelNo.EditValue = Nothing
        txtStreet.EditValue = Nothing
        txtPartOfCity.EditValue = Nothing
        lueCity.EditValue = Nothing
        lueState.EditValue = Nothing
        lueCountry.EditValue = Nothing
        txtEmail.EditValue = Nothing
        txtMobileNo.EditValue = Nothing
        txtRemarks.EditValue = Nothing

        lueBankBranch.EditValue = Nothing
        txtAccName.EditValue = Nothing
        txtAccNo.EditValue = Nothing
        lueAccType.EditValue = Nothing
        lueCurrency.EditValue = Nothing
        chkDeduct.EditValue = False

        getDefaultPeriod()

        'dtAllotment.Clear()
        'dtOtherEarning.Clear()
        'dtOtherDeduction.Clear()
        gvAllotment.OptionsSelection.MultiSelect = True
        gvOtherEarnings.OptionsSelection.MultiSelect = True
        gvOtherDeduction.OptionsSelection.MultiSelect = True

        gvAllotment.SelectAll()
        gvAllotment.DeleteSelectedRows()

        gvOtherEarnings.SelectAll()
        gvOtherEarnings.DeleteSelectedRows()

        gvOtherDeduction.SelectAll()
        gvOtherDeduction.DeleteSelectedRows()


        gvAllotment.OptionsSelection.MultiSelect = False
        gvOtherEarnings.OptionsSelection.MultiSelect = False
        gvOtherDeduction.OptionsSelection.MultiSelect = False
        'dtAllotment = DB.CreateTable("SELECT PKey, Amt, 'FKeyCurr' as FKeyCurr, dbo.periodToDate(StartPeriod) AS StartPeriod FROM tblRemitAllot WHERE FKeyRemittanceID = 'Dummy0983836'")
        'dtOtherEarning = DB.CreateTable("SELECT * FROM REMITTANCE_OTHER_EARNINGS WHERE FKeyRemittanceID = 'Dummy0983836'")
        'dtOtherDeduction = DB.CreateTable("SELECT * FROM REMITTANCE_OTHER_DEDUCTIONS WHERE FKeyRemittanceID = 'Dummy0983836'")

        arrEditedEarnings.Clear()
        arrEditedAllot.Clear()
        arrEditedDeductions.Clear()
        bAddMode = True
        editAddModeControls(False)
        AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup_AllotteeInfo, LayoutControlGroup_AddrInfo, LayoutControlGroup_BankDetails})

    End Sub


    Private Function ValidationRemittance() As Boolean
        Dim retval As Boolean = True
        If gvOtherDeduction.HasColumnErrors Or gvOtherEarnings.HasColumnErrors Or gvAllotment.HasColumnErrors Then
            MsgBox("Please input valid record.", MsgBoxStyle.Information, GetAppName() & " - Remittances")
            retval = False
            Return retval
        End If

        If CheckRequiredFields() = True Then
            MsgBox("Please insert data on the required fields.", MsgBoxStyle.Information, GetAppName() & " - Remittances")
            retval = False
            Return retval
        End If

        '////////// neil add
        Dim tempdt As DataView '= gvAllotment.DataSource
        Dim tempret As Boolean = True

        'For i As Integer = 0 To gvAllotment.RowCount - 1
        '    If Not IsNothing(gvAllotment.GetDataRow(i)) Then
        '        If gvAllotment.GetDataRow(i).HasErrors Then
        '            tempret = False
        '            Exit For
        '        End If
        '    End If
        'Next

        tempdt = gvAllotment.DataSource
        For i As Integer = 0 To tempdt.Count - 1
            If tempdt.Item(i).Row.HasErrors Then
                tempret = False
                Exit For
            End If
        Next
        tempdt = gvOtherEarnings.DataSource
        For i As Integer = 0 To tempdt.Count - 1
            If tempdt.Item(i).Row.HasErrors Then
                tempret = False
                Exit For
            End If
        Next
        tempdt = gvOtherDeduction.DataSource
        For i As Integer = 0 To tempdt.Count - 1
            If tempdt.Item(i).Row.HasErrors Then
                tempret = False
                Exit For
            End If
        Next

        If tempret = False Then
            MsgBox("Please correct the invalid value.", MsgBoxStyle.Exclamation, GetAppName() & " - Remittances")
            retval = False
            Return retval
        End If
        '////////////////////////////

        'Check if deduction and primary already exists in other allottee.
        For i As Integer = 0 To gvAllottee.RowCount - 1
            'if editting, skip the focused record.
            If isEditdable And i = gvAllottee.FocusedRowHandle Then Continue For

            'check if already deducting on another allottee
            If chkDeduct.EditValue = True And gvAllottee.GetRowCellValue(i, "IsDedEeShare") = chkDeduct.EditValue Then
                If MsgBox("Are you sure you want to deduct on this allottee?." & Environment.NewLine & "Currently Deducting on: " & gvAllottee.GetRowCellValue(i, "Fullname"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName() & " - Remittances") = MsgBoxResult.Yes Then
                    strUpdateIsDedEeShare = gvAllottee.GetRowCellValue(i, "PKey")
                    dtAllottee.Rows(i)("IsDedEeShare") = False
                Else
                    retval = False
                    Return retval
                End If
            End If

            'check if has primary
            If IfNull(lueTypeOfAllot.EditValue, "") = "Primary" And IfNull(gvAllottee.GetRowCellValue(i, "WAllot"), "") = "Primary" Then
                If MsgBox("Are you sure you want to set this allottee as Primary?." & Environment.NewLine & "Current Primary: " & gvAllottee.GetRowCellValue(i, "Fullname"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName() & " - Remittances") = MsgBoxResult.Yes Then
                    strUpdateTypeAllot = gvAllottee.GetRowCellValue(i, "PKey")
                    dtAllottee.Rows(i)("WAllot") = DBNull.Value
                    gvAllotment.SetRowCellValue(i, "WAllot", "")
                Else
                    retval = False
                    Return retval
                End If
            End If
        Next
        Return retval
    End Function


    Public Overrides Sub SaveData()
        Dim dtAllotteeNewRow As New DataTable
        Dim dtAllotmentNewRow As New DataTable
        Dim strRemitID, strAllotID, strEarnID As String
        Dim strUpdateIsDedEeShare As String = ""
        Dim strUpdateTypeAllot As String = ""
        Dim sql As String


        'neil comment out txtLName.Focus()
        If Not ValidationRemittance() Then
            isRecordCanBeSaved = False
            Exit Sub
        Else 'neil
            isRecordCanBeSaved = True
        End If

        Me.txtLName.Focus()

        isSaving = True
        If bAddMode Then strRemitID = "" Else strRemitID = gvAllottee.GetFocusedRowCellValue("PKey")
        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "ACT_DESC", 0, System.Environment.MachineName, "DATA_DESC", "Remittance", "")
        'Add or update allottee details
        If isAllotteeEdited = True Then
            sql = "EXECUTE [dbo].[REMITTANCE_INSERT/UPDATE] " & _
           "@FKeyIDNbr='" & CrewID & "', @PKey='" & strRemitID & "', " & _
           "@FName='" & txtFName.EditValue & "', @MName='" & txtMName.EditValue & "', " & _
           "@LName='" & txtLName.EditValue & "', @FKeyRel='" & lueRelationship.EditValue & "', " & _
           "@TypeOfAllot = '" & lueTypeOfAllot.EditValue & "', @TelNo='" & txtTelNo.EditValue & "', " & _
           "@Street='" & txtStreet.EditValue & "', @PartOfCity='" & txtPartOfCity.EditValue & "', " & _
           "@FKeyCity='" & lueCity.EditValue & "', @FKeyCntry='" & lueCountry.EditValue & "', " & _
           "@Email='" & txtEmail.EditValue & "', @MobileNo='" & txtMobileNo.EditValue & "', " & _
           "@Remarks='" & txtRemarks.EditValue & "', @FKeyBank='" & lueBankBranch.Properties.View.GetFocusedRowCellValue("FKeyBank") & "', " & _
           "@FKeyBranch='" & lueBankBranch.EditValue & "', @AccNo='" & txtAccNo.EditValue & "', " & _
           "@AccType='" & lueAccType.EditValue & "', @FKeyCurrency='" & lueCurrency.EditValue & "', " & _
           "@AccName='" & txtAccName.EditValue & "',@IsDedEeShare =" & chkDeduct.EditValue & " , " & _
           "@FKeyProvince = '" & lueState.EditValue & "', @LastUpdatedBy='" & LastUpdatedBy & "', @SexCode = " & IfNull(cboSexCode.EditValue, 0)
            dtAllotteeNewRow = DB.CreateTable(sql)
            strRemitID = dtAllotteeNewRow.Rows(0).Item("PKey")
            'corrected by tony20170410
            'If strUpdateIsDedEeShare <> "" Then DB.RunSql("UPDATE tblRemittance SET IsDedEeShare = 0 WHERE PKey = '" & strUpdateIsDedEeShare & "'")
            'If strUpdateTypeAllot <> "" Then DB.RunSql("UPDATE tblRemittance SET WAllot = NULL WHERE PKey = '" & strUpdateTypeAllot & "'")
            If strUpdateIsDedEeShare <> "" Then DB.RunSql("UPDATE tblRemittance SET IsDedEeShare = 0 WHERE PKey = '" & strRemitID & "'")
            If strUpdateTypeAllot <> "" Then DB.RunSql("UPDATE tblRemittance SET WAllot = NULL WHERE PKey = '" & strRemitID & "'")
            'end tony

            If bAddMode = False Then
                For i As Integer = dtAllottee.Rows.Count - 1 To 0 Step -1
                    If strRemitID = dtAllottee.Rows(i).Item("PKey") Then
                        dtAllottee.Rows.Remove(dtAllottee(i))
                        Exit For
                    End If
                Next
            End If



            dtAllottee.ImportRow(dtAllotteeNewRow.Rows(0))
            'gvAllottee.Columns("LName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        End If
        BRECORDUPDATEDs = False
        isSaving = False
        'Add or update Remittance allotment
        If arrEditedAllot.Count > 0 Then
            For i As Integer = 0 To arrEditedAllot.Count - 1
                strAllotID = IfNull(gvAllotment.GetRowCellValue(arrEditedAllot(i), "PKey"), "")
                sql = "EXECUTE [dbo].[REMITTANCE_RemitAllot_INSERT/UPDATE] " & _
                  " @PKey = '" & strAllotID & "'" & _
                  ",@FKeyRemittanceID ='" & strRemitID & "'" & _
                  ",@Amt = " & gvAllotment.GetRowCellValue(arrEditedAllot(i), "Amt") & _
                  ",@FKeyCurr = '" & gvAllotment.GetRowCellValue(arrEditedAllot(i), "FKeyCurr") & "'" & _
                  ",@StartPeriod = " & payfunc.dateToPeriod(gvAllotment.GetRowCellValue(arrEditedAllot(i), "StartPeriod")) & _
                  ",@LastUpdatedBy = '" & LastUpdatedBy & "'"
                dtAllotmentNewRow = DB.CreateTable(sql)
            Next
            arrEditedAllot.Clear()
        End If

        'If na edit yung Other Earnings
        Dim sqls As New ArrayList
        If arrEditedEarnings.Count > 0 Then
            Dim nRHandle As Integer
            For e As Integer = 0 To arrEditedEarnings.Count - 1
                nRHandle = arrEditedEarnings(e)
                strEarnID = IfNull(gvOtherEarnings.GetRowCellValue(arrEditedEarnings(e), "PKey"), "")
                sqls.Add("EXECUTE [dbo].[REMITTANCE_OtherEarnings_INSERT/UPDATE] " & _
                           " @PKey = '" & strEarnID & "' " & _
                           ",@FKeyRemittanceID ='" & strRemitID & "'" & _
                           ",@FKeyWageAshID ='" & gvOtherEarnings.GetRowCellValue(nRHandle, "FKeyWageAshID") & "'" & _
                           ",@FKeyCurr ='" & gvOtherEarnings.GetRowCellValue(nRHandle, "FKeyCurr") & "'" & _
                           ",@Amt =" & gvOtherEarnings.GetRowCellValue(nRHandle, "Amt") & _
                           ",@DateStart =" & ChangeToSQLDate(gvOtherEarnings.GetRowCellValue(nRHandle, "DateStart").ToString) & _
                           ",@DateEnd =" & ChangeToSQLDate(gvOtherEarnings.GetRowCellValue(nRHandle, "DateEnd")) & _
                           ",@WageType = 1" & _
                           ",@LastUpdatedBy='" & LastUpdatedBy & "'" & _
                           ",@Remarks = '" & gvOtherEarnings.GetRowCellValue(nRHandle, "Remarks") & "'")
            Next
            arrEditedEarnings.Clear()
        End If

        'If na edit yung Other Earnings
        If arrEditedDeductions.Count > 0 Then
            Dim nRHandle As Integer
            For e As Integer = 0 To arrEditedDeductions.Count - 1
                nRHandle = arrEditedDeductions(e)
                strEarnID = IfNull(gvOtherDeduction.GetRowCellValue(nRHandle, "PKey"), "")
                sqls.Add("EXECUTE [dbo].[REMITTANCE_OtherEarnings_INSERT/UPDATE] " & _
                           " @PKey = '" & strEarnID & "' " & _
                           ",@FKeyRemittanceID ='" & strRemitID & "'" & _
                           ",@FKeyWageAshID ='" & gvOtherDeduction.GetRowCellValue(nRHandle, "FKeyWageAshID") & "'" & _
                           ",@FKeyCurr ='" & gvOtherDeduction.GetRowCellValue(nRHandle, "FKeyCurr") & "'" & _
                           ",@Amt =" & gvOtherDeduction.GetRowCellValue(nRHandle, "Amt") & _
                           ",@DateStart =" & ChangeToSQLDate(gvOtherDeduction.GetRowCellValue(nRHandle, "DateStart").ToString) & _
                           ",@DateEnd =" & ChangeToSQLDate(gvOtherDeduction.GetRowCellValue(nRHandle, "DateEnd")) & _
                           ",@WageType = 2" & _
                           ",@LastUpdatedBy='" & LastUpdatedBy & "'" & _
                           ",@Remarks = '" & gvOtherEarnings.GetRowCellValue(nRHandle, "Remarks") & "'")
            Next
            arrEditedEarnings.Clear()
        End If

        If DB.RunSqls(sqls) = True Then
            MsgBox(GetMessage("Saved", True), MsgBoxStyle.Information, GetAppName)
            SetSelection(strRemitID)
        End If
        isAllotteeEdited = False
        isAllotTypeEdited = False
        defaultControls()

        refreshChildGrids() 'neil
    End Sub

    Public Overrides Sub EditData()

        If BRECORDUPDATEDs Then
            Exit Sub
        End If

        If isEditdable = False Then
            AllowAddition(Name, True)
            AllowDeletion(Name, True)
            AllowSaving(Name, False)
            editAddModeControls(True)
            clearGvErrors()
            refreshChildGrids()

            RemoveEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup_AllotteeInfo, LayoutControlGroup_AddrInfo, LayoutControlGroup_BankDetails}, False)

        Else
            AllowAddition(Name, False)
            AllowDeletion(Name, False)
            AllowSaving(Name, True)
            editAddModeControls(False)
            AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup_AllotteeInfo, LayoutControlGroup_AddrInfo, LayoutControlGroup_BankDetails})

        End If

        getDefaultPeriod()
        isEditdable = True
        arrEditedEarnings.Clear()
        arrEditedAllot.Clear()
        arrEditedDeductions.Clear()
    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()


        If gvAllottee.RowCount = 0 Then
            MessageBox.Show("There's no record to delete.", "MPS5 - Remittances", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Select Case strDeleteCap
            Case "Delete Allottee"
                If MsgBox("This will also delete all Allotment, Other earnings and deductions." & Environment.NewLine & _
                            "Do you still want to continue deleting """ & gvAllottee.GetFocusedRowCellValue("Fullname") & """?", MsgBoxStyle.YesNo, "MPS5 - Remittances") = MsgBoxResult.Yes Then
                    Dim strDeletedBy As String = clsAudit.AssembleLastUBy(USER_NAME, strDeleteCap, 0, System.Environment.MachineName, "Deleted Remittance", "Remittance", "")
                    clsAudit.saveAuditPreDelDetails("tblRemittance", IfNull(gvAllottee.GetFocusedRowCellValue("PKey"), ""), strDeletedBy)
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        "Remittances", _
                        "Crewing", _
                        "tblRemittance", _
                        "PKey IN ('" & IfNull(gvAllottee.GetFocusedRowCellValue("PKey"), "") & "')", _
                        "<< Delete Crew Data - Remittances - Allottee >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Remittances - Allottee>", _
                        GetUserName())
                    '-->
                    DB.RunSql("DELETE FROM tblRemittance WHERE PKey = '" & IfNull(gvAllottee.GetFocusedRowCellValue("PKey"), "") & "'")
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    gvAllottee.DeleteRow(gvAllottee.FocusedRowHandle)
                    RefreshData()
                End If
            Case "Delete Allotment"
                If MsgBox("Are you sure you want to delete allotment for this period """ & gvAllotment.GetFocusedRowCellDisplayText("StartPeriod") & """?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "MPS5 - Remittances") = MsgBoxResult.Yes Then
                    Dim strDeletedBy As String = clsAudit.AssembleLastUBy(USER_NAME, strDeleteCap, 0, System.Environment.MachineName, "Deleted Allotment", "Remittance", "")
                    clsAudit.saveAuditPreDelDetails("tblRemitAllot", IfNull(gvAllotment.GetFocusedRowCellValue("PKey"), ""), strDeletedBy)
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        "Remittances", _
                        "Crewing", _
                        "tblRemitAllot", _
                        "PKey IN ('" & IfNull(gvAllotment.GetFocusedRowCellValue("PKey"), "") & "')", _
                        "<< Delete Crew Data - Remittances - Allotment >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Remittances - Allotment>", _
                        GetUserName())
                    '-->
                    DB.RunSql("DELETE FROM tblRemitAllot WHERE PKey = '" & IfNull(gvAllotment.GetFocusedRowCellValue("PKey"), "") & "'")
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    gvAllotment.DeleteRow(gvAllotment.FocusedRowHandle)
                End If
            Case "Delete Other Earning"
                If MsgBox("Are you sure you want to delete """ & gvOtherEarnings.GetFocusedRowCellDisplayText("FKeyWageAshID") & """?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "MPS5 - Remittances") = MsgBoxResult.Yes Then
                    Dim strDeletedBy As String = clsAudit.AssembleLastUBy(USER_NAME, strDeleteCap, 0, System.Environment.MachineName, "Deleted Other Earning", "Remittance", "")
                    clsAudit.saveAuditPreDelDetails("tblRemitOtherWage", IfNull(gvOtherEarnings.GetFocusedRowCellValue("PKey"), ""), strDeletedBy)
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        "Remittances", _
                        "Crewing", _
                        "tblRemitOtherWage", _
                        "PKey IN ('" & IfNull(gvOtherEarnings.GetFocusedRowCellValue("PKey"), "") & "')", _
                        "<< Delete Crew Data - Remittances - Other Earning >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Remittances - Other Earning>", _
                        GetUserName())
                    '-->
                    DB.RunSql("DELETE FROM [tblRemitOtherWage] WHERE PKey = '" & IfNull(gvOtherEarnings.GetFocusedRowCellValue("PKey"), "") & "'")
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    gvOtherEarnings.DeleteRow(gvOtherEarnings.FocusedRowHandle)
                End If
            Case "Delete Other Deduction"
                If MsgBox("Are you sure you want to delete """ & gvOtherDeduction.GetFocusedRowCellDisplayText("FKeyWageAshID") & """?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "MPS5 - Remittances") = MsgBoxResult.Yes Then
                    Dim strDeletedBy As String = clsAudit.AssembleLastUBy(USER_NAME, strDeleteCap, 0, System.Environment.MachineName, "Deleted Other Deduction", "Remittance", "")
                    clsAudit.saveAuditPreDelDetails("tblRemitOtherWage", IfNull(gvOtherDeduction.GetFocusedRowCellValue("PKey"), ""), strDeletedBy)
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        "Remittances", _
                        "Crewing", _
                        "tblRemitOtherWage", _
                        "PKey IN ('" & IfNull(gvOtherDeduction.GetFocusedRowCellValue("PKey"), "") & "')", _
                        "<< Delete Crew Data - Remittances - Other Deduction >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Remittances - Other Deduction>", _
                        GetUserName())
                    '-->
                    DB.RunSql("DELETE FROM [tblRemitOtherWage] WHERE PKey = '" & IfNull(gvOtherDeduction.GetFocusedRowCellValue("PKey"), "") & "'")
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    gvOtherDeduction.DeleteRow(gvOtherDeduction.FocusedRowHandle)
                End If
        End Select
    End Sub
#End Region

    Private Sub initDatatables()
        dtRelationship = DB.CreateTable("SELECT PKey, Name From tblAdmRel ORDER BY Name")
        dtCity = DB.CreateTable("SELECT PKey, Name, FKeyProvince From tblAdmCity ORDER BY Name")
        dtState = DB.CreateTable("SELECT Name, PKey, FKeyCntry FROM tblAdmProvince ORDER BY Name")
        dtCntry = DB.CreateTable("SELECT PKey, Name From tblAdmCntry ORDER By Name")
        dtBank = DB.CreateTable("SELECT PKey, Name From tblAdmBank ORDER BY Name")
        dtBranch = DB.CreateTable("SELECT * FROM [BANK_BRANCHES] ORDER BY BranchName")
        dtCurrency = DB.CreateTable("SELECT PKey, Name, Symbol From tblAdmCurr ORDER BY Ref desc, Name")
        dtAdmWageAsh = DB.CreateTable("SELECT PKey, Name, WageType From tblAdmWageAsh WHERE PKey <> 'SYSPAYALLOT' ORDER BY Name")

        lueRelationship.Properties.DataSource = dtRelationship
        lueCity.Properties.DataSource = dtCity
        lueState.Properties.DataSource = dtState
        lueCountry.Properties.DataSource = dtCntry
        lueCurrency.Properties.DataSource = dtCurrency
        ECurrencyEdit.DataSource = dtCurrency
        DCurrencyEdit.DataSource = dtCurrency
        aCurrEdit.DataSource = dtCurrency
        WageAshEEdit.DataSource = dtAdmWageAsh.Select("WageType = 1").CopyToDataTable
        WageAshDEdit.DataSource = dtAdmWageAsh.Select("WageType = 2").CopyToDataTable

        SetupBankBranchLookupEdit()

        Dim cClm As DataColumn
        cClm = New DataColumn
        cClm.ColumnName = "TypeofAllot"
        cClm.DataType = System.Type.GetType("System.String")
        dtTypeAllot.Columns.Add(cClm)

        cClm = New DataColumn
        cClm.ColumnName = "AccType"
        cClm.DataType = System.Type.GetType("System.String")
        dtAccType.Columns.Add(cClm)

        dtTypeAllot.Rows.Add(New Object() {"Primary"})
        dtTypeAllot.Rows.Add(New Object() {"Secondary"})
        dtTypeAllot.Rows.Add(New Object() {"None"}) 'added by tony20180711

        dtAccType.Rows.Add(New Object() {"Savings"})
        dtAccType.Rows.Add(New Object() {"Current"})

        lueTypeOfAllot.Properties.DataSource = dtTypeAllot
        lueAccType.Properties.DataSource = dtAccType

        'added by tony20170410
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {"1", "Male"}
        ctable.Rows.Add(crow)
        crow(0) = "2"
        crow(1) = "Female"
        ctable.Rows.Add(crow)
        cboSexCode.Properties.DataSource = ctable
    End Sub

    Private Sub SetupBankBranchLookupEdit()
        Dim repCtl As DevExpress.XtraEditors.SearchLookUpEdit = lueBankBranch

        repCtl.Properties.View.Columns.Clear()

        Dim gcol As DevExpress.XtraGrid.Columns.GridColumn
        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "FKeyBank"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "Bank"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = True
        gcol.Width = 20
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "FKeyBranch"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "BranchName"
        gcol.FieldName = gcol.Name
        gcol.Caption = "Branch Name"
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "BankBranchName"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        With repCtl.Properties
            .ValueMember = "FKeyBranch"
            .DisplayMember = "BankBranchName"
            .NullText = String.Empty
            .ShowFooter = False
            .AppearanceFocused.BackColor = EDITED_FOCUSED_COLOR
        End With

        lueBankBranch.Properties.DataSource = DB.CreateTable("SELECT b.PKey FKeyBank, b.Abbrv Bank, br.PKey FKeyBranch, br.name as BranchName, concat(isnull(b.abbrv,''), ' - ', isnull(br.name,'')) BankBranchName FROM dbo.tblAdmBank b LEFT JOIN dbo.tblAdmBranch br ON b.PKey = br.FKeyBank ORDER BY concat(isnull(b.abbrv,''), ' - ', isnull(br.name,''))")

    End Sub

    Private Function getFocusedAllotteeData(ByVal clm As String)
        Return gvAllottee.GetFocusedRowCellValue(clm)
    End Function

    Private Function getFocusedEarningData(ByVal clm As String)
        Return gvOtherEarnings.GetFocusedRowCellValue(clm)
    End Function

    Private Sub gvAllottee_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles gvAllottee.BeforeLeaveRow
        Exit Sub
        'If BRECORDUPDATEDs Then
        '    'If Not ValidationRemittance() Then

        '    '///////// neil add
        '    Dim NoErrors As Boolean = False
        '    'For i As Integer = 0 To gvAllotment.RowCount - 1
        '    '    If Not IsNothing(gvAllotment.GetDataRow(i)) Then
        '    '        If gvAllotment.GetDataRow(i).HasErrors Then
        '    '            haserrors = True
        '    '            Exit For
        '    '        End If
        '    '    End If
        '    'Next

        '    Dim tempdt As DataView = gvAllotment.DataSource

        '    For i As Integer = 0 To tempdt.Count - 1
        '        If tempdt.Item(i).Row.HasErrors Then
        '            NoErrors = False
        '            Exit For
        '        End If
        '    Next

        '    If NoErrors = True Then
        '        If MsgBox("Changes will be disregarded, Continue?", vbQuestion + vbYesNo) = MsgBoxResult.Yes Then
        '            gvAllotment.CancelUpdateCurrentRow()
        '        Else
        '            e.Allow = False
        '        End If
        '    Else
        '        If CheckValidateFields() Then
        '            e.Allow = True
        '        Else
        '            e.Allow = False
        '        End If
        '        'Else
        '        '    e.Allow = False
        '        'End If
        '    End If
        '    '///////////////

        '    '///// neil commented out
        '    'If CheckValidateFields() Then
        '    '    e.Allow = True
        '    'Else
        '    '    e.Allow = False
        '    'End If
        '    ''Else
        '    ''    e.Allow = False
        '    ''End If
        '    '/////////////////
        'Else
        '    e.Allow = True
        'End If

    End Sub

    Private Sub gvAllottee_Click(sender As Object, e As System.EventArgs) Handles gvAllottee.GotFocus
        If Not strDeleteCap = "Delete Allottee" Then
            strDeleteCap = "Delete Allottee"
            SetDeleteCaption(Name, strDeleteCap)
        End If
        AllowDeletion(Name, CType(sender, GridView).RowCount <> 0)
    End Sub

    Private Sub gvAllottee_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gvAllottee.CustomUnboundColumnData
        If e.Column.FieldName = "Fullname" Then
            Dim nRow As Integer = gvAllottee.GetRowHandle(e.ListSourceRowIndex)
            e.Value = gvAllottee.GetRowCellValue(nRow, "LName") & ", " & gvAllottee.GetRowCellValue(nRow, "FName")
        End If
    End Sub

    Private Sub gvAllottee_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvAllottee.FocusedRowChanged
        If isSaving = True Then Exit Sub ' ORiginal
        'If isSaving Then CheckValidateFields()

        txtLName.EditValue = getFocusedAllotteeData("LName")
        txtFName.EditValue = getFocusedAllotteeData("FName")
        txtMName.EditValue = getFocusedAllotteeData("MName")
        lueRelationship.EditValue = getFocusedAllotteeData("FKeyRel")
        lueTypeOfAllot.EditValue = getFocusedAllotteeData("WAllot")
        txtTelNo.EditValue = getFocusedAllotteeData("Phone")
        txtStreet.EditValue = getFocusedAllotteeData("St")
        txtPartOfCity.EditValue = getFocusedAllotteeData("PartofCity")
        lueCity.EditValue = getFocusedAllotteeData("FKeyCity")
        lueState.EditValue = getFocusedAllotteeData("FKeyProvince")
        lueCountry.EditValue = getFocusedAllotteeData("FKeyCntry")
        txtEmail.EditValue = getFocusedAllotteeData("Email")
        txtMobileNo.EditValue = getFocusedAllotteeData("Mobile")
        txtRemarks.EditValue = getFocusedAllotteeData("Remarks")
        lueBankBranch.EditValue = getFocusedAllotteeData("FKeyBranch")
        txtAccName.EditValue = getFocusedAllotteeData("AcctName")
        txtAccNo.EditValue = getFocusedAllotteeData("AcctNbr")
        lueAccType.EditValue = getFocusedAllotteeData("AcctType")
        lueCurrency.EditValue = getFocusedAllotteeData("FKeyCurrency")
        chkDeduct.EditValue = getFocusedAllotteeData("IsDedEeShare")
        cboSexCode.EditValue = getFocusedAllotteeData("SexCode")

        refreshChildGrids()
        '///////////////// commented out transfer to refreshChildGrids()
        'Dim strRemitID As String = getFocusedAllotteeData("PKey")
        'Dim dtTemp As DataTable
        'dtAllotment.Rows.Clear()
        'dtTemp = New DataTable
        'dtTemp = DB.CreateTable("SELECT PKey, Amt, FKeyCurr, dbo.periodToDate(StartPeriod) AS StartPeriod FROM tblRemitAllot WHERE FKeyRemittanceID = '" & strRemitID & "' ")
        'If dtTemp.Rows.Count > 0 Then
        '    For Each rNew As DataRow In dtTemp.Rows
        '        dtAllotment.ImportRow(rNew)
        '    Next
        'End If
        'gcAllotment.DataSource = dtAllotment

        'dtOtherEarning.Rows.Clear()
        'dtTemp = New DataTable
        'dtTemp = DB.CreateTable("SELECT * FROM REMITTANCE_OTHER_EARNINGS WHERE FKeyRemittanceID = '" & strRemitID & "'")
        'If dtTemp.Rows.Count > 0 Then
        '    For Each rNew As DataRow In dtTemp.Rows
        '        dtOtherEarning.ImportRow(rNew)
        '    Next
        'End If
        'gcOtherEarnings.DataSource = dtOtherEarning

        'dtOtherDeduction.Rows.Clear()
        'dtTemp = New DataTable
        'dtTemp = DB.CreateTable("SELECT * FROM REMITTANCE_OTHER_DEDUCTIONS WHERE FKeyRemittanceID = '" & strRemitID & "'")
        'If dtTemp.Rows.Count > 0 Then
        '    For Each rNew As DataRow In dtTemp.Rows
        '        dtOtherDeduction.ImportRow(rNew)
        '    Next
        'End If
        'gcOtherDeduction.DataSource = dtOtherDeduction
        '///////////////// 

        bAddMode = False
        isEditdable = False
        BRECORDUPDATEDs = False
        defaultControls()
    End Sub

    Private Sub initOtherEarningsDT()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtOtherEarning.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyWageAshID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtOtherEarning.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyCurr"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtOtherEarning.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Amt"
        ccolumn.DataType = System.Type.GetType("System.Double")
        dtOtherEarning.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateStart"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtOtherEarning.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateEnd"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtOtherEarning.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Remarks"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtOtherEarning.Columns.Add(ccolumn)

        gcOtherEarnings.DataSource = dtOtherEarning
    End Sub

    Private Sub initOtherDeductionsDT()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtOtherDeduction.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyWageAshID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtOtherDeduction.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyCurr"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtOtherDeduction.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Amt"
        ccolumn.DataType = System.Type.GetType("System.Double")
        dtOtherDeduction.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateStart"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtOtherDeduction.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateEnd"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtOtherDeduction.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Remarks"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtOtherDeduction.Columns.Add(ccolumn)

        gcOtherDeduction.DataSource = dtOtherDeduction
    End Sub

    Private Sub editAddModeControls(ByVal bol As Boolean)
        LayoutControlItem25.Visibility = bol

        txtFName.ReadOnly = bol
        txtLName.ReadOnly = bol
        txtMName.ReadOnly = bol
        lueRelationship.ReadOnly = bol
        lueTypeOfAllot.ReadOnly = bol
        txtTelNo.ReadOnly = bol
        txtStreet.ReadOnly = bol
        txtPartOfCity.ReadOnly = bol
        lueCity.ReadOnly = bol
        lueState.ReadOnly = bol
        lueCountry.ReadOnly = bol
        txtEmail.ReadOnly = bol
        txtMobileNo.ReadOnly = bol
        txtRemarks.ReadOnly = bol
        cboSexCode.ReadOnly = bol

        lueBankBranch.ReadOnly = bol
        txtAccName.ReadOnly = bol
        txtAccNo.ReadOnly = bol
        lueAccType.ReadOnly = bol
        lueCurrency.ReadOnly = bol

        chkDeduct.ReadOnly = bol

        btnUserCrewAddr.Enabled = Not bol

        gvAllotment.OptionsBehavior.AllowAddRows = Not bol
        gvAllotment.OptionsBehavior.ReadOnly = bol
        gvAllotment.OptionsBehavior.Editable = Not bol

        gvOtherEarnings.OptionsBehavior.AllowAddRows = Not bol
        gvOtherEarnings.OptionsBehavior.ReadOnly = bol
        gvOtherEarnings.OptionsBehavior.Editable = Not bol

        gvOtherDeduction.OptionsBehavior.AllowAddRows = Not bol
        gvOtherDeduction.OptionsBehavior.ReadOnly = bol
        gvOtherDeduction.OptionsBehavior.Editable = Not bol

        If bAddMode Or isEditdable Then
            gvAllotment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            gvOtherEarnings.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            gvOtherDeduction.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Else
            gvAllotment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            gvOtherEarnings.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            gvOtherDeduction.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        End If
    End Sub

    Private Sub SetSelection(ByVal id As String)
        Try
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = gvAllottee.Columns("PKey")
            RowHandle = gvAllottee.LocateByValue(0, Col, id)
            gvAllottee.FocusedRowHandle = RowHandle
            gvAllottee.TopRowIndex = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lueTypeOfAllot_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lueTypeOfAllot.ButtonClick
        If bAddMode Or isEditdable Then
            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
                'edited by tony20180711
                'lueTypeOfAllot.EditValue = Nothing
                lueTypeOfAllot.EditValue = "None"
            End If
        End If
    End Sub

    Private Sub lueCountry_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles lueCountry.CloseUp
        Try
            If Not IsNothing(e.Value) Then
                lueState.Properties.DataSource = dtState.Select("FKeyCntry = '" & e.Value & "'").CopyToDataTable
            End If
        Catch ex As InvalidOperationException
            lueState.Properties.DataSource = Nothing
        End Try
    End Sub

    Private Sub lueState_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles lueState.CloseUp
        Try
            If Not IsNothing(e.Value) Then
                lueCity.Properties.DataSource = dtCity.Select("FKeyProvince = '" & e.Value & "'").CopyToDataTable
            End If
        Catch ex As InvalidOperationException
            lueCity.Properties.DataSource = Nothing
        End Try
    End Sub

    Private Sub lueRelationship_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lueRelationship.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            lueRelationship.EditValue = DBNull.Value
        End If
    End Sub

    Private Sub allotteeDetails_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtLName.EditValueChanged, txtAccName.EditValueChanged, txtAccNo.EditValueChanged, txtEmail.EditValueChanged, txtFName.EditValueChanged, txtMName.EditValueChanged, txtMobileNo.EditValueChanged, txtPartOfCity.EditValueChanged, txtRemarks.EditValueChanged, txtStreet.EditValueChanged, txtTelNo.EditValueChanged, lueAccType.EditValueChanged, lueCity.EditValueChanged, lueCountry.EditValueChanged, lueCurrency.EditValueChanged, lueRelationship.EditValueChanged, chkDeduct.EditValueChanged
        If bAddMode Or isEditdable Then

            isAllotteeEdited = True
            BRECORDUPDATEDs = True
            AllowSaving(Name, True)

        End If
    End Sub

    Private Sub lueTypeOfAllot_EditValueChanged(sender As Object, e As System.EventArgs) Handles lueTypeOfAllot.EditValueChanged
        If bAddMode Or isEditdable Then
            isAllotteeEdited = True
            BRECORDUPDATEDs = True
            chkDeduct.EditValue = IfNull(lueTypeOfAllot.EditValue, "") = "Primary"
        End If
    End Sub

    Private Sub initAllotmentDT()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtAllotment.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Amt"
        ccolumn.DataType = System.Type.GetType("System.Double")
        dtAllotment.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "StartPeriod"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtAllotment.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyCurr"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtAllotment.Columns.Add(ccolumn)

        gcAllotment.DataSource = dtAllotment
    End Sub

    Private Sub defaultControls()
        bAddMode = False
        isEditdable = False
        editAddModeControls(True)
        AllowAddition(Name, True)
        AllowEditing(Name, True)
        AllowSaving(Name, False)
        AllowDeletion(Name, False)
        SetDeleteCaption(Name, "Delete Allottee")
        strDeleteCap = "Delete Allottee"
        If gvAllottee.IsFocusedView Then
            AllowDeletion(Name, gvAllottee.RowCount <> 0)
        End If
        EditCheck(Name, False)

        lueCity.Properties.DataSource = dtCity
        lueState.Properties.DataSource = dtState
    End Sub

    Private Sub gvAllotment_Click(sender As Object, e As System.EventArgs) Handles gvAllotment.Click
        strDeleteCap = "Delete Allotment"
        SetDeleteCaption(Name, strDeleteCap)
        AllowDeletion(Name, CType(sender, GridView).RowCount <> 0)
    End Sub

    Private Sub gvOtherEarnings_Click(sender As Object, e As System.EventArgs) Handles gvOtherEarnings.Click
        strDeleteCap = "Delete Other Earning"
        SetDeleteCaption(Name, strDeleteCap)
        AllowDeletion(Name, CType(sender, GridView).RowCount <> 0)
    End Sub

    Private Sub gvOtherDeduction_Click(sender As Object, e As System.EventArgs) Handles gvOtherEarnings.Click
        strDeleteCap = "Delete Other Deduction"
        SetDeleteCaption(Name, strDeleteCap)
        AllowDeletion(Name, CType(sender, GridView).RowCount <> 0)
    End Sub

    Private Sub gvAllotment_GotFocus(sender As Object, e As System.EventArgs) Handles gvAllotment.GotFocus
        'If Not strDeleteCap = "Delete Allotment" Then
        Dim delcap As String = ""
        GetDeleteCaption(Name, delcap)
        'If Not strDeleteCap = "Delete Allotment" Then
        If Not delcap = "Delete Allotment" Then
            strDeleteCap = "Delete Allotment"
            SetDeleteCaption(Name, strDeleteCap)
        End If
        AllowDeletion(Name, CType(sender, GridView).RowCount <> 0)
    End Sub

    Private Sub gvOtherEarnings_GotFocus(sender As Object, e As System.EventArgs) Handles gvOtherEarnings.GotFocus
        If Not strDeleteCap = "Delete Other Earning" Then
            strDeleteCap = "Delete Other Earning"
            SetDeleteCaption(Name, strDeleteCap)
        End If
        AllowDeletion(Name, CType(sender, GridView).RowCount <> 0)
    End Sub

    Private Sub gvOtherDeduction_GotFocus(sender As Object, e As System.EventArgs) Handles gvOtherDeduction.GotFocus
        If Not strDeleteCap = "Delete Other Deduction" Then
            strDeleteCap = "Delete Other Deduction"
            SetDeleteCaption(Name, strDeleteCap)
        End If
        AllowDeletion(Name, CType(sender, GridView).RowCount <> 0)
    End Sub

#Region "Insert rowhandle in their respective arrays when grids are updated."
    Private Sub gvAllotment_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvAllotment.CellValueChanged
        If bAddMode Or isEditdable Then
            If Not e.RowHandle < 0 Then
                If arrEditedAllot.Contains(e.RowHandle) = False Then
                    arrEditedAllot.Add(e.RowHandle)
                End If
            Else
                If e.Column.FieldName = "Amt" Then
                    'neil comment out  gvAllotment.SetRowCellValue(e.RowHandle, "StartPeriod", dDefaultPeriod)
                End If
            End If
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub gvOtherEarnings_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvOtherEarnings.CellValueChanged
        If bAddMode Or isEditdable Then
            If Not e.RowHandle < 0 Then
                If arrEditedEarnings.Contains(e.RowHandle) = False Then
                    arrEditedEarnings.Add(e.RowHandle)
                End If
                BRECORDUPDATEDs = True
            End If
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub gvOtherDeduction_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvOtherDeduction.CellValueChanged
        If bAddMode Or isEditdable Then
            If Not e.RowHandle < 0 Then
                If arrEditedDeductions.Contains(e.RowHandle) = False Then
                    arrEditedDeductions.Add(e.RowHandle)
                End If
                BRECORDUPDATEDs = True
            End If
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub gvAllotment_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gvAllotment.InvalidRowException, gvOtherDeduction.InvalidRowException, gvOtherEarnings.InvalidRowException
        'neil e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
        If MsgBox("Please correct the invalid value", vbExclamation + MsgBoxStyle.OkOnly) = System.Windows.Forms.DialogResult.OK Then
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
            AllowSaving(Name, True)
            'Else
            '    AllowSaving(Name, False)
        End If

    End Sub

    Private Sub gvAllotment_RowCountChanged(sender As Object, e As System.EventArgs) Handles gvAllotment.RowCountChanged
        If bAddMode Or isEditdable Then
            If arrEditedAllot.Contains(gvAllotment.RowCount - 1) = False Then
                If Not (gvAllotment.RowCount - 1) < 0 Then
                    arrEditedAllot.Add(gvAllotment.RowCount - 1)
                End If
                'neil commented out BRECORDUPDATEDs = True
            End If
        End If
    End Sub

    Private Sub gvOtherEarnings_RowCountChanged(sender As Object, e As System.EventArgs) Handles gvOtherEarnings.RowCountChanged
        If bAddMode Or isEditdable Then
            If arrEditedEarnings.Contains(gvOtherEarnings.RowCount - 1) = False Then
                If Not (gvOtherEarnings.RowCount - 1) < 0 Then
                    arrEditedEarnings.Add(gvOtherEarnings.RowCount - 1)
                End If
                'neil commented out BRECORDUPDATEDs = True
            End If
        End If
    End Sub

    Private Sub gvOtherDeduction_RowCountChanged(sender As Object, e As System.EventArgs) Handles gvOtherDeduction.RowCountChanged
        If bAddMode Or isEditdable Then
            If arrEditedDeductions.Contains(gvOtherDeduction.RowCount - 1) = False Then
                If Not (gvOtherDeduction.RowCount - 1) < 0 Then
                    arrEditedDeductions.Add(gvOtherDeduction.RowCount - 1)
                End If
                'neil commented out BRECORDUPDATEDs = True
            End If
        End If
    End Sub
#End Region

#Region "Validations"
    Private Function CheckRequiredFields() As Boolean
        'If txtLName.Text = "" Then
        If IfNull(txtLName.EditValue, "") = "" Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 0
            txtLName.Focus()
            Return True
        End If

        'If txtFName.Text = "" Then
        If IfNull(txtFName.EditValue, "") = "" Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 0
            txtFName.Focus()
            Return True
        End If

        'If lueCurrency.Text = "" Then
        If IfNull(lueCurrency.EditValue, "") = "" Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 1
            lueCurrency.Focus()
            Return True
        End If

        'If txtAccName.Text = "" Then
        If IfNull(txtAccName.EditValue, "") = "" Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 1
            txtAccName.Focus()
            Return True
        End If

        'If txtAccName.Text = "" Then
        If IfNull(txtAccName.EditValue, "") = "" Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 1
            txtAccName.Focus()
            Return True
        End If

        'If txtAccNo.Text = "" Then
        If IfNull(txtAccNo.EditValue, "") = "" Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 1
            txtAccNo.Focus()
            Return True
        End If

        'If lueAccType.Text = "" Then
        If IfNull(lueAccType.EditValue, "") = "" Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 1
            lueAccType.Focus()
            Return True
        End If

        'If cboSexCode.Text = "" Then
        If IfNull(cboSexCode.EditValue, "") = "" Then
            tabAllotteeBankDetails.SelectedTabPageIndex = 0
            cboSexCode.Focus()
            Return True
        End If


        'Removed Validations for Address
        'If lueState.Text = "" Then
        '    lueState.Focus()
        '    Return True
        'End If

        'If txtPartOfCity.Text = "" Then
        '    txtPartOfCity.Focus()
        '    Return True
        'End If

        'If lueCountry.Text = "" Then
        '    lueCountry.Focus()
        '    Return True
        'End If

        'If lueCity.Text = "" Then
        '    lueCity.Focus()
        '    Return True
        'End If

        If gvAllotment.DataRowCount > 0 Or gvAllotment.FocusedRowHandle < 0 Then
            For i As Integer = 0 To gvAllotment.DataRowCount - 1
                For Each clm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In gvAllotment.Columns
                    If clm.Tag = "Required" Then
                        If IsDBNull(gvAllotment.GetRowCellValue(i, clm)) = True Then
                            Return True
                        End If
                    End If
                Next
            Next
        ElseIf gvAllotment.FocusedRowHandle < 0 Then
            For Each clm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In gvAllotment.Columns
                If clm.Tag = "Required" Then
                    If IsDBNull(gvAllotment.GetRowCellValue(gvAllotment.FocusedRowHandle, clm)) = True Then
                        Return True
                    End If
                End If
            Next
        End If
        If gvOtherDeduction.DataRowCount > 0 Or gvOtherDeduction.FocusedRowHandle < 0 Then
            For i As Integer = 0 To gvOtherDeduction.DataRowCount - 1
                For Each clm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In gvOtherDeduction.Columns
                    If clm.Tag = "Required" Then
                        If IsDBNull(gvOtherDeduction.GetRowCellValue(i, clm)) = True Then
                            Return True
                        End If
                    End If
                Next
            Next
        ElseIf gvOtherDeduction.FocusedRowHandle < 0 Then
            For Each clm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In gvOtherDeduction.Columns
                If clm.Tag = "Required" Then
                    If IsDBNull(gvOtherDeduction.GetRowCellValue(gvOtherDeduction.FocusedRowHandle, clm)) = True Then
                        Return True
                    End If
                End If
            Next
        End If

        If gvOtherEarnings.DataRowCount > 0 Then
            For i As Integer = 0 To gvOtherEarnings.DataRowCount - 1
                For Each clm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In gvOtherEarnings.Columns
                    If clm.Tag = "Required" Then
                        If IsDBNull(gvOtherEarnings.GetRowCellValue(i, clm)) = True Then
                            Return True
                        End If
                    End If
                Next
            Next
        ElseIf gvOtherEarnings.FocusedRowHandle < 0 Then
            For Each clm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In gvOtherEarnings.Columns
                If clm.Tag = "Required" Then
                    If IsDBNull(gvOtherEarnings.GetRowCellValue(gvOtherEarnings.FocusedRowHandle, clm)) = True Then
                        Return True
                    End If
                End If
            Next
        End If


        Return False
    End Function

    Private Sub views_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvAllotment.ValidateRow, gvOtherDeduction.ValidateRow, gvOtherEarnings.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = TryCast(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        Dim tdate1 As Date, tdate2 As Date

        For Each clm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In view.Columns
            If clm.Tag = "Required" Then
                If IsDBNull(view.GetRowCellValue(e.RowHandle, clm)) = True Then
                    e.Valid = False
                    view.GetDataRow(e.RowHandle).SetColumnError(clm.FieldName, "This field cannot be empty.")
                    AllowSaving(Name, False)
                    Exit Sub
                Else
                    If clm.FieldName = "Amt" Then
                        If view.GetRowCellValue(e.RowHandle, clm) <= 0 Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError(clm.FieldName, "Amount must be greater than zero.")
                            AllowSaving(Name, False)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Next

        Select Case view.Name
            Case "gvAllotment"

                'neil
                view.GetDataRow(e.RowHandle).ClearErrors()

                If IsDBNull(view.GetRowCellValue(e.RowHandle, "StartPeriod")) = False And IsDBNull(view.GetRowCellValue(e.RowHandle, "FKeyCurr")) = False Then
                    For i As Integer = 0 To view.RowCount - 1
                        If i <> e.RowHandle Then

                            'If view.GetRowCellValue(e.RowHandle, "StartPeriod") = view.GetRowCellValue(i, "StartPeriod") And view.GetRowCellValue(e.RowHandle, "FKeyCurr") = view.GetRowCellValue(i, "FKeyCurr") Then
                            '    e.Valid = False
                            '    view.GetDataRow(e.RowHandle).SetColumnError("StartPeriod", "Can't allow duplicate start period with the same currency.")
                            '    AllowSaving(Name, False)
                            '    Exit Sub
                            'End If

                            tdate1 = view.GetRowCellValue(e.RowHandle, "StartPeriod")
                            tdate2 = view.GetRowCellValue(i, "StartPeriod")

                            If (tdate1.Month = tdate2.Month And tdate1.Year = tdate2.Year) And view.GetRowCellValue(e.RowHandle, "FKeyCurr") = view.GetRowCellValue(i, "FKeyCurr") Then
                                e.Valid = False
                                view.GetDataRow(e.RowHandle).SetColumnError("StartPeriod", "Can't allow duplicate start period with the same currency.")
                                AllowSaving(Name, False)
                                Exit Sub
                            End If

                        End If
                    Next
                End If
            Case Else
                If IsDBNull(view.GetRowCellValue(e.RowHandle, "DateStart")) = False And IsDBNull(view.GetRowCellValue(e.RowHandle, "FKeyWageAshID")) = False And IsDBNull(view.GetRowCellValue(e.RowHandle, "FKeyCurr")) = False Then
                    For i As Integer = 0 To view.RowCount - 1
                        If i <> e.RowHandle Then
                            If view.GetRowCellValue(e.RowHandle, "DateStart") = view.GetRowCellValue(i, "DateStart") And view.GetRowCellValue(e.RowHandle, "FKeyCurr") = view.GetRowCellValue(i, "FKeyCurr") And view.GetRowCellValue(e.RowHandle, "FKeyWageAshID") = view.GetRowCellValue(i, "FKeyWageAshID") Then
                                e.Valid = False
                                view.GetDataRow(e.RowHandle).SetColumnError("FKeyWageAshID", "Can't allow duplicate start period with the same currency.")
                                AllowSaving(Name, False)
                                Exit Sub
                            End If
                        End If
                    Next
                End If
        End Select

        view.GetDataRow(e.RowHandle).ClearErrors()
        AllowSaving(Name, True)
    End Sub

#End Region

    Private Sub btnUserCrewAddr_Click(sender As System.Object, e As System.EventArgs) Handles btnUserCrewAddr.Click
        If Not isEditdable Then Exit Sub
        Dim dtCrewAddr As New DataTable
        dtCrewAddr = DB.CreateTable("SELECT TOP 1 St, PartofCity, FKeyCity, FKeyProvince, FKeyCntry FROM tblAddr WHERE FKeyIDNbr = '" & CrewID & "' AND AddrStat = 1")
        If dtCrewAddr.Rows.Count > 0 Then
            txtStreet.EditValue = dtCrewAddr.Rows(0)("St")
            txtPartOfCity.EditValue = dtCrewAddr.Rows(0)("PartofCity")
            lueCity.EditValue = dtCrewAddr.Rows(0)("FKeyCity")
            lueState.EditValue = dtCrewAddr.Rows(0)("FKeyProvince")
            lueCountry.EditValue = dtCrewAddr.Rows(0)("FKeyCntry")
        Else
            MsgBox("Crew does not have an address.", MsgBoxStyle.Information, GetAppName() & " - Remittances")
        End If
    End Sub

    Private Sub getDefaultPeriod()
        Dim strCurrAct As String = ""
        strCurrAct = blList.GetFocusedRowData("CurrActID")
        Try
            dDefaultPeriod = DB.CreateTable("SELECT TOP 1 ActDateStart FROM tblActivity WHERE PKey = '" & strCurrAct & "'").Rows(0)(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnViewRelatives_Click(sender As System.Object, e As System.EventArgs) Handles btnViewRelatives.Click
        Dim relDt As New DataTable
        relDt = DB.CreateTable("SELECT LName, FName, MName, Addr, FKeyCntry, Phone, Telefax, Email, FKeyRel FROM tblAllottee WHERE FKeyIDNbr = '" & CrewID & "' ORDER By LName, FName")
        If relDt.Rows.Count > 0 Then
            frmViewRel = New frmRelatives(relDt, dtCity, dtState, dtCntry, dtRelationship)
            With frmViewRel
                .ShowDialog()
                If .isCopyPressed Then
                    txtLName.EditValue = .Mainview.GetFocusedRowCellValue("LName")
                    txtFName.EditValue = .Mainview.GetFocusedRowCellValue("FName")
                    txtMName.EditValue = .Mainview.GetFocusedRowCellValue("MName")
                    txtTelNo.EditValue = .Mainview.GetFocusedRowCellValue("Telefax")
                    txtMobileNo.EditValue = .Mainview.GetFocusedRowCellValue("Phone")
                    txtEmail.EditValue = .Mainview.GetFocusedRowCellValue("Email")
                    txtStreet.EditValue = .Mainview.GetFocusedRowCellValue("Addr")
                    lueCity.EditValue = .Mainview.GetFocusedRowCellValue("FKeyCity")
                    lueCountry.EditValue = .Mainview.GetFocusedRowCellValue("FKeyCntry")
                    lueRelationship.EditValue = .Mainview.GetFocusedRowCellValue("FKeyRel")
                    If Not lueCountry.EditValue = Nothing Then lueState.Properties.DataSource = dtState.Select("FKeyCntry = '" & lueCountry.EditValue & "'").CopyToDataTable
                End If
            End With
        Else
            MessageBox.Show("Crew currentry have no relatives record.", "MPS5 - Remittances", MessageBoxButtons.OK)
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False

        '///////////// Neil Commented out
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel, GetAppName)
        If res = MsgBoxResult.Yes Then
            SaveData()
            If isRecordCanBeSaved Then
                flag = True
                ALLOWNEXTS = True
            Else
                flag = False
                'neil comment out ALLOWNEXTS = True
                ALLOWNEXTS = False
            End If
        ElseIf res = MsgBoxResult.No Then
            'RefreshData()
            'neil comment out flag = False
            clearGvErrors()
            flag = True
            ALLOWNEXTS = True
            BRECORDUPDATEDs = False
        End If
        '//////////////////////
        ''/////////// neil add
        'Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel, GetAppName)
        'If res = MsgBoxResult.Yes Then
        '    SaveData()
        'Else
        '    BRECORDUPDATEDs = False
        '    clearGvAllotErrors()
        'End If
        ''///////////////////

        Return flag
    End Function

#Region "Save/Load Layout"
    'Public Overrides Sub SaveMainContentLayout()
    '    MyBase.SaveMainContentLayout() 'this will create a path for layouts if path does not exist
    '    Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\" 'layout path saved on local app layout folder
    '    Dim strSplitterPositions As String
    '    strSplitterPositions = SplitContainerControl1.SplitterPosition & ";" & SplitContainerControl2.SplitterPosition & ";" & SplitContainerControl3.SplitterPosition & ";" & SplitContainerControl4.SplitterPosition 'concut splittercontainer positions
    '    Dim wtr As System.IO.StreamWriter = System.IO.File.CreateText(strLayoutPath & "Remittance_SplitterPositions.txt") 'create a text file in local app layout folter that will contain the splittercontainer positions
    '    Using wtr
    '        wtr.WriteLine(strSplitterPositions) 'write strSplitterPositions in the text file created
    '    End Using
    'End Sub

    'Public Overrides Sub LoadMainContentLayout()
    '    Try
    '        MyBase.LoadMainContentLayout() 'this do nothing "YET", no future plans for this :D
    '        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\" 'again get the local app layout folder..
    '        Dim rdr As System.IO.StreamReader = System.IO.File.OpenText(strLayoutPath & "Remittance_SplitterPositions.txt") 'open the text file that contains splitter positions
    '        Using rdr
    '            Dim nSplitterPositions() As String = rdr.ReadLine().ToString.Split(";") 'get the splitter positions insert in an array
    '            SplitContainerControl1.SplitterPosition = nSplitterPositions(0) 'assign the splitter position from text file to splitter
    '            SplitContainerControl2.SplitterPosition = nSplitterPositions(1)
    '            SplitContainerControl3.SplitterPosition = nSplitterPositions(2) 'assign the splitter position from text file to splitter
    '            SplitContainerControl4.SplitterPosition = nSplitterPositions(3)
    '        End Using
    '    Catch ex As Exception

    '    End Try
    'End Sub
#End Region

    Private LName As String = String.Empty, FName As String = String.Empty, MName As String = String.Empty
    Private Sub txtLName_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtLName.EditValueChanged
        'txtLName.EditValueChanging, txtFName.EditValueChanging, txtMName.EditValueChanging,

        LName = TryCast(sender, DevExpress.XtraEditors.TextEdit).Text
        'txtAccName.Text = LName & " " & FName & " " & MName
        Dim str As New System.Text.StringBuilder
        str.Append(FName)
        str.Append(IIf(str.Length > 0, " ", "") & MName)
        str.Append(IIf(str.Length > 0, " ", "") & LName)
        txtAccName.Text = str.ToString
    End Sub

    Private Sub txtFName_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtFName.EditValueChanged
        FName = TryCast(sender, DevExpress.XtraEditors.TextEdit).Text
        'txtAccName.Text = FName & " " & MName & " " & LName
        Dim str As New System.Text.StringBuilder
        str.Append(FName)
        str.Append(IIf(str.Length > 0, " ", "") & MName)
        str.Append(IIf(str.Length > 0, " ", "") & LName)
        txtAccName.Text = str.ToString
    End Sub

    Private Sub txtMName_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtMName.EditValueChanged
        MName = TryCast(sender, DevExpress.XtraEditors.TextEdit).Text
        'txtAccName.Text = LName & " " & FName & " " & MName
        Dim str As New System.Text.StringBuilder
        str.Append(FName)
        str.Append(IIf(str.Length > 0, " ", "") & MName)
        str.Append(IIf(str.Length > 0, " ", "") & LName)
        txtAccName.Text = str.ToString
    End Sub

    'Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As System.EventArgs) Handles XtraTabControl1.SelectedPageChanged
    '    Select Case XtraTabControl1.SelectedTabPageIndex
    '        Case 0 'Earnings
    '            strDeleteCap = "Delete Other Earning"
    '            SetDeleteCaption(Name, strDeleteCap)
    '            AllowDeletion(Name, gvOtherEarnings.RowCount <> 0)
    '        Case 1 'Deduction
    '            strDeleteCap = "Delete Other Deduction"
    '            SetDeleteCaption(Name, strDeleteCap)
    '            AllowDeletion(Name, gvOtherDeduction.RowCount <> 0)
    '    End Select
    'End Sub

    Private Sub gvAllotment_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles gvAllotment.KeyDown

        'If e.KeyCode = Keys.Escape Then
        '    If gvAllotment.FocusedRowModified Or gvAllotment.EditingValueModified Then
        '        gvAllotment.GetDataRow(gvAllotment.FocusedRowHandle).ClearErrors()
        '        AllowSaving(Name, True)
        '    End If
        'End If

        'clearGvErrors()
    End Sub

    Sub clearGvErrors()
        If gvAllotment.FocusedRowModified Or gvAllotment.EditingValueModified Then

            gvAllotment.GetDataRow(gvAllotment.FocusedRowHandle).ClearErrors()
            gvAllotment.CloseEditForm()
            gvAllotment.CancelUpdateCurrentRow()
            AllowSaving(Name, True)

        End If

        If gvOtherEarnings.FocusedRowModified Or gvOtherEarnings.EditingValueModified Then

            gvOtherEarnings.GetDataRow(gvOtherEarnings.FocusedRowHandle).ClearErrors()
            gvOtherEarnings.CloseEditForm()
            gvOtherEarnings.CancelUpdateCurrentRow()
            AllowSaving(Name, True)

        End If

        If gvOtherDeduction.FocusedRowModified Or gvOtherDeduction.EditingValueModified Then

            gvOtherDeduction.GetDataRow(gvOtherDeduction.FocusedRowHandle).ClearErrors()
            gvOtherDeduction.CloseEditForm()
            gvOtherDeduction.CancelUpdateCurrentRow()
            AllowSaving(Name, True)

        End If
    End Sub

    Sub refreshChildGrids()

        Dim strRemitID As String = getFocusedAllotteeData("PKey")
        Dim dtTemp As DataTable
        dtAllotment.Rows.Clear()
        dtTemp = New DataTable
        dtTemp = DB.CreateTable("SELECT PKey, Amt, FKeyCurr, dbo.periodToDate(StartPeriod) AS StartPeriod FROM tblRemitAllot WHERE FKeyRemittanceID = '" & strRemitID & "' ")
        If dtTemp.Rows.Count > 0 Then
            For Each rNew As DataRow In dtTemp.Rows
                dtAllotment.ImportRow(rNew)
            Next
        End If
        gcAllotment.DataSource = dtAllotment

        dtOtherEarning.Rows.Clear()
        dtTemp = New DataTable
        dtTemp = DB.CreateTable("SELECT * FROM REMITTANCE_OTHER_EARNINGS WHERE FKeyRemittanceID = '" & strRemitID & "'")
        If dtTemp.Rows.Count > 0 Then
            For Each rNew As DataRow In dtTemp.Rows
                dtOtherEarning.ImportRow(rNew)
            Next
        End If
        gcOtherEarnings.DataSource = dtOtherEarning

        dtOtherDeduction.Rows.Clear()
        dtTemp = New DataTable
        dtTemp = DB.CreateTable("SELECT * FROM REMITTANCE_OTHER_DEDUCTIONS WHERE FKeyRemittanceID = '" & strRemitID & "'")
        If dtTemp.Rows.Count > 0 Then
            For Each rNew As DataRow In dtTemp.Rows
                dtOtherDeduction.ImportRow(rNew)
            Next
        End If
        gcOtherDeduction.DataSource = dtOtherDeduction

    End Sub

    Private Sub tabEarnDed_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles tabEarnDed.SelectedPageChanged
        Select Case tabEarnDed.SelectedTabPageIndex
            Case 0 'Earnings
                strDeleteCap = "Delete Other Earning"
                SetDeleteCaption(Name, strDeleteCap)
                AllowDeletion(Name, gvOtherEarnings.RowCount <> 0)
            Case 1 'Deduction
                strDeleteCap = "Delete Other Deduction"
                SetDeleteCaption(Name, strDeleteCap)
                AllowDeletion(Name, gvOtherDeduction.RowCount <> 0)
        End Select
    End Sub

    Private Sub cboSexCode_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboSexCode.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            cboSexCode.EditValue = DBNull.Value
        End If
    End Sub

    Private Sub gvAllotment_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles gvAllotment.InitNewRow
        gvAllotment.SetFocusedRowCellValue("FKeyCurr", "SYSCUUSD")
        gvAllotment.SetFocusedRowCellValue("StartPeriod", DateSerial(Year(getServerDateTime()), Month(getServerDateTime()), 1))
    End Sub

    Private Sub lueTypeOfAllot_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles lueTypeOfAllot.EditValueChanging
        If isEditdable Or bAddMode Then
            If IfNull(e.NewValue, "") = "Primary" Then
                If hasAlreadySelectedAPrimaryAllottee(gvAllottee.FocusedRowHandle) Then
                    MsgBox("Unable to set this as Primary Allottee because there is an already existing one.", MsgBoxStyle.Exclamation, GetAppName())
                    e.Cancel = True
                End If
            End If
        End If
        
    End Sub

    Private Function hasAlreadySelectedAPrimaryAllottee(currRowHandle As Integer) As Boolean
        For i As Integer = 0 To gvAllottee.RowCount - 1
            If i <> currRowHandle Then
                If IfNull(gvAllottee.GetRowCellValue(i, "WAllot"), "").Equals("Primary") Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Sub lueBankBranch_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lueBankBranch.ButtonClick
        If bAddMode Or isEditdable Then
            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
                lueBankBranch.EditValue = DBNull.Value
            ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Redo Then
                SetupBankBranchLookupEdit()
            End If
        End If
    End Sub

    Private Sub lueBankBranch_EditValueChanged(sender As Object, e As System.EventArgs) Handles lueBankBranch.EditValueChanged
        If bAddMode Or isEditdable Then

            isAllotteeEdited = True
            BRECORDUPDATEDs = True
            AllowSaving(Name, True)

        End If
    End Sub

    Private Sub cboSexCode_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboSexCode.EditValueChanged
        If bAddMode Or isEditdable Then
            isAllotteeEdited = True
            BRECORDUPDATEDs = True
            AllowSaving(Name, True)
        End If
    End Sub
End Class
