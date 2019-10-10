Public Class PayScale

#Region "Easy Edit"
    Private FormName As String = "Wage Scale"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName)
#End Region

    Dim ObjFocusedView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
    Dim dict As New Dictionary(Of String, Integer), dictDateType As New Dictionary(Of String, Integer)
    Dim currentWRankID As String, currentRnkFocusRow As Integer
    Dim alrdyAsk As Boolean
    Dim isEditing As Boolean
    Dim OrigActiveVal As Integer

    Private Property int32 As Object

    ' Private Property lkuInfoDateType As Object

    Public Overrides Sub RefreshData()
        TableName = "tbladmwscale"

        MyBase.RefreshData()
        'SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        'SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        'Remove this Code if Permission in Already Established
        '======================================================
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        'SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteCaption(Name, "Delete Wage Scale")
        '======================================================
        strRequiredFields = "txtName;cboFKeyCurr;cboRateType;cboFKeyWScalCalendar"
        If Not bLoaded Then
            initControls()
            'AddEditListener(Me.LayoutControl1.Root)
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtAbbrv.Text = Trim(IfNull(blList.GetFocusedRowData("Abbrv"), ""))
            Me.cboFKeyWScalCalendar.EditValue = IfNull(blList.GetFocusedRowData("FKeyWScalCalendar"), "")
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.cboFKeyCurr.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyCurr"), ""))
            Me.cboRateType.EditValue = blList.GetFocusedRowData("RateType")
            'MsgBox(Trim(IfNull(blList.GetFocusedRowData("RateType"), "")))
            Me.txtDateAct.Text = Trim(IfNull(blList.GetFocusedRowData("DateAct"), ""))
            Me.txtDateInact.Text = Trim(IfNull(blList.GetFocusedRowData("DateInact"), ""))
            Me.chkActive.Checked = IfNull(blList.GetFocusedRowData("Active"), 0)
            OrigActiveVal = IfNull(blList.GetFocusedRowData("Active"), 0)
            'Me.cboFKeyBank.EditValue = Trim(IfNull(blList.GetFocusedRowData("BankCode"), ""))
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            BRECORDUPDATEDs = False
            EnableSubButtons(False)
        End If
        AddEditListener(Me.LayoutControl1.Root)

        'ClearFields(Me.LayoutControl1.Root, True)
        'set the header of the GroupControl
        'Me.header.Text = "Edit Rank Group Details - " & Me.txtName.Text
        Call RefreshDataRank()
        Call RefreshDataEarn()
        Call RefreshDataDed()
        Call RefreshDataInfo()
        Call RefreshDataEmpe()
        Call RefreshDataEmpr()

        isEditing = False
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        'neil 20160507 SetSaveCaption(Name, "Apply")
        txtName.Focus()
        isEditing = True
        If isEditdable Then
            ' AllowDeletionSub(Name, True)
            AllowDeletion(Name, True)
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            EditDataRank(True)
            If getCurrentRank() <> "" Then
                EditDataEarn(True)
                EditDataDed(True)
                EditDataInfo(True)
                EditDataEmpe(True)
                EditDataEmpr(True)
            End If
        Else
            'AllowDeletionSub(Name, False)
            AllowDeletion(Name, False)
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            EditDataRank(False)
            EditDataEarn(False)
            EditDataDed(False)
            EditDataInfo(False)
            EditDataEmpe(False)
            EditDataEmpr(False)
        End If
        EnableSubButtons(isEditdable)
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()

        strID = ""
        Dim tempDT As DataTable, tempEarDT As DataTable, tempDedDT As DataTable, tempInfoDT As DataTable, tempEmpeDT As DataTable
        Dim tempEmprDT As DataTable

        'tempDT = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited,CAST(0 as BIT) AS isDelete FROM dbo.tblAdmWscaleRank WHERE FKeyWScale='" & strID & "'")
        tempDT = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited FROM dbo.tblAdmWscaleRank " & _
                                "INNER Join " & _
                                "tblAdmRank ON tblAdmWscaleRank.FKeyRank = tblAdmRank.PKey " & _
                                "WHERE FKeyWScale='" & strID & "' order by tblAdmRank.SortCode")
        Me.GrdRank.DataSource = tempDT

        'tempEarDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited,CAST(0 as BIT) AS isDelete FROM tblAdmWScaleOnb " &
        '                           "WHERE FKeyWScaleRank='" & currentWRankID & "'") ' ORDER BY tblAdmWageOnb.Name ")
        tempEarDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleOnb " &
                                  "WHERE FKeyWScaleRank='" & currentWRankID & "'")
        '"WHERE (((tblAdmWageOnb.WageType)=1) AND ((tblAdmWageOnb.Prorata)='true')) and FKeyWScaleRank='" & currentWRankID & "'  ORDER BY tblAdmWageOnb.Name ")
        Me.GrdEarn.DataSource = tempEarDT

        tempDedDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited  FROM tblAdmWScaleOnb " &
                                   "WHERE FKeyWScaleRank='" & currentWRankID & "'") '  ORDER BY tblAdmWageOnb.Name ")
        '"WHERE (((tblAdmWageOnb.WageType)=2) AND ((tblAdmWageOnb.Prorata)='true')) and FKeyWScaleRank='" & currentWRankID & "'  ORDER BY tblAdmWageOnb.Name ")
        Me.GrdDed.DataSource = tempDedDT

        tempInfoDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleInfo " &
                                   "WHERE FKeyWScaleRank='" & currentWRankID & "'") '  ORDER BY tblAdmWScaleInfo.Name ")
        'tempInfoDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleInfo " )
        Me.GrdInfo.DataSource = tempInfoDT

        tempEmpeDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleAsh " &
                                   "WHERE FKeyWScaleRank='" & currentWRankID & "'") '  ORDER BY tblAdmWScaleInfo.Name ")
        'tempInfoDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleInfo " )
        Me.GrdEmpe.DataSource = tempEmpeDT

        tempEmprDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleAshEmp " &
                                   "WHERE FKeyWScaleRank='" & currentWRankID & "'") '  ORDER BY tblAdmWScaleInfo.Name ")
        'tempInfoDT = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleInfo " )
        Me.GrdEmpr.DataSource = tempEmprDT

        Call subRefreshEarnDtSource()
        Call subRefreshDedDtSource()
        Call subRefreshInfoDtSource()
        Call subRefreshEmpeDtSource()
        Call subRefreshEmprDtSource()

        'Call AddDataRank()
        'Call AddDataEarn()
        'Call AddDataDed()
        'Call AddDataInfo()
        'Call AddDataEmpe()
        'Call AddDataEmpr()



        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowSaving(Name, True) 'Enable save button 
            AllowEditing(Name, False) 'Allow Edit Button
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            currentWRankID = ""
            strDesc = "New Record"
            'Me.txtAbbrv.Focus()
            txtName.Focus()
            txtName.BackColor = SEL_COLOR
            'Me.txtAbbrv.BackColor = SEL_COLOR
            'get the max SortCode
            'Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            BRECORDUPDATEDs = False
        End If

        'With Me.RankView
        '    .OptionsBehavior.ReadOnly = False
        '    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
        '    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
        '    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        '    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        'End With
        EnableSubButtons(False)
    End Sub

    Public Overrides Sub SaveData()
        Dim query As New ArrayList, info As Boolean = False
        Dim type As String = ""
        Dim id As String = ""
        Dim delsql As String = "", pkeyList As String = ""
        'Dim qanswer As Integer

        'neil 20160525
        Call manualValidateEditor()
        If RankView.HasColumnErrors Or EarnView.HasColumnErrors Or DedView.HasColumnErrors Or
                EmpeView.HasColumnErrors Or EmprView.HasColumnErrors Then
            Exit Sub
        End If
        'neil end

        id = strID
        Dim iGetRet As Integer = 0

        If Me.chkActive.Checked = False And OrigActiveVal = 1 Then
            Call isWageScaleInUse(id, iGetRet)
        End If

        If iGetRet = 0 Then
          
        Else
            'edited by tony20170221
            'MsgBox("Cannot change status to Inactive. Wage scale already in-use.", MsgBoxStyle.Information, GetAppName)
            MsgBox("Cannot set wage scale to inactive because it is assigned to a crew/s that is planned/onboard .", MsgBoxStyle.Information, GetAppName)
            '---> end tony
            Me.chkActive.Checked = True
            'Exit Sub
        End If
        'qanswer = MsgBox("This will change records. Are you sure you want to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, GetAppName)

        'If qanswer = MsgBoxResult.Yes Then
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboFKeyCurr, cboRateType, cboFKeyWScalCalendar}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil   'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    BRECORDUPDATEDs = False
                    'blList.RefreshData()
                    'blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
                    id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                    type = "Inserted"
                End If
            Else
                'id = strID
                'Dim iGetRet As Integer = 0

                'If Me.chkActive.Checked = False And OrigActiveVal = 1 Then
                '    Call isWageScaleInUse(id, iGetRet)
                'End If

                ''Exit Sub

                'If iGetRet = 0 Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv}, "PKey<>'" & id & "'") Then
                    Exit Sub
                Else
                    query.Add(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=(getdate()) ", "PKey='" & id & "'"))
                    'info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
                    BRECORDUPDATEDs = False
                    'blList.RefreshData()
                    type = "Updated"
                End If
                'Else
                '    'edited by tony20170221
                '    'MsgBox("Cannot change status to Inactive. Wage scale already in-use.", MsgBoxStyle.Information, GetAppName)
                '    MsgBox("Cannot set wage scale to inactive because it is assigned to a crew/s that is planned/onboard .", MsgBoxStyle.Information, GetAppName)
                '    '---> end tony
                '    Me.chkActive.Checked = True
                '    'Exit Sub
                'End If

            End If
            'bAddMode = False
            'RefreshData()
            'If info Then
            '    MsgBox("Record " & type)
            'End If

            With Me.RankView
                '.CloseEditForm()
                .CloseEditor()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then
                        'If .GetRowCellValue(i, "isDelete") Then
                        '    currentPkey = IfNull(.GetRowCellValue(i, "PKey"), "")
                        '    If currentPkey <> "" Then
                        '        pkeyList = pkeyList & "'" & currentPkey & "',"
                        '    End If
                        'Elseif

                        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.Text & " / " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank"), FormName) 'neil    'tony20160719
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale Rank", 10, System.Environment.MachineName, Me.txtName.Text & " / " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank"), FormName)

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmWscaleRank ( " & _
                                      "FKeyWScale," & _
                                      "FKeyRank, " & _
                                      "LOC, " & _
                                      "LOCDays, " & _
                                      "LOCRem, " & _
                                      "YrsServ, " & _
                                      "Description, " & _
                                      "LastUpdatedBy)" & _
                                      "VALUES('" & id & "', " & _
                                      "'" & .GetRowCellValue(i, "FKeyRank") & "', " & _
                                       IfNull(.GetRowCellValue(i, "LOC"), 0) & ", " & _
                                       IfNull(.GetRowCellValue(i, "LOCDays"), 0) & ", " & _
                                      "'" & .GetRowCellValue(i, "LOCRem") & "', " & _
                                       IfNull(.GetRowCellValue(i, "YrsServ"), 0) & ", " & _
                                      "'" & .GetRowCellValue(i, "Description") & "', " & _
                                      "'" & LastUpdatedBy & "')")
                        Else
                            id = strID
                            query.Add("UPDATE dbo.tblAdmWscaleRank " & _
                                      "SET FKeyRank='" & .GetRowCellValue(i, "FKeyRank") & "'" & _
                                      ", LOC=" & IfNull(.GetRowCellValue(i, "LOC"), 0) & _
                                      ", LOCDays=" & IfNull(.GetRowCellValue(i, "LOCDays"), 0) & _
                                      ", LOCRem='" & .GetRowCellValue(i, "LOCRem") & "'" & _
                                      ", YrsServ=" & IfNull(.GetRowCellValue(i, "YrsServ"), 0) & _
                                      ", Description='" & .GetRowCellValue(i, "Description") & "'" & _
                                      ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                      ",DateUpdated=(getdate())" & _
                                      "WHERE FKeyWScale='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next
                'If Len(pkeyList) > 1 Then
                '    query.Add("delete from tbladmwscalerank where PKey in (" & Mid(pkeyList, 1, Len(pkeyList) - 1) & ")")
                '    currentPkey = ""
                'End If
            End With

            With Me.EarnView
                '.CloseEditForm()
                .CloseEditor()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then
                        'If .GetRowCellValue(i, "isDelete") Then
                        '    currentPkey = IfNull(.GetRowCellValue(i, "PKey"), "")
                        '    If currentPkey <> "" Then
                        '        pkeyList = pkeyList & "'" & currentPkey & "',"
                        '    End If
                        'ElseIf

                        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName,
                        '                                         Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / Earnings", FormName) 'neil   'tony20160719
                        Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / " & .GetRowCellDisplayText(i, "FKeyWageOnb")
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Onboard Earnings", 10, System.Environment.MachineName, cDataDescription, FormName)

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmWscaleOnb ( " & _
                                      "FKeyWScaleRank," & _
                                      "FKeyWageOnb, " & _
                                      "WageType, " & _
                                      "Amt, " & _
                                      "DateType, " & _
                                      "FKeyCurr, " & _
                                      "Formula, " & _
                                      "Prorata, " & _
                                      "Accum, " & _
                                      "LastUpdatedBy)" & _
                                      "VALUES('" & .GetRowCellValue(i, "FKeyWScaleRank") & "', " & _
                                      "'" & .GetRowCellValue(i, "FKeyWageOnb") & "', " & _
                                      "1, " & _
                                       IfNull(.GetRowCellValue(i, "Amt"), 0.0) & ", " & _
                                      "'" & .GetRowCellValue(i, "DateType") & "', " & _
                                      IfValNull(.GetRowCellValue(i, "FKeyCurr"), "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "Null") & ", " & _
                                      "'" & .GetRowCellValue(i, "Formula") & "', " & _
                                       "'" & .GetRowCellValue(i, "Prorata") & "', " & _
                                        "'" & .GetRowCellValue(i, "Accum") & "', " & _
                                      "'" & LastUpdatedBy & "')")
                        Else
                            query.Add("UPDATE dbo.tblAdmWscaleOnb " & _
                                      "SET FKeyWageOnb='" & .GetRowCellValue(i, "FKeyWageOnb") & "'" & _
                                      ", Amt=" & IfNull(.GetRowCellValue(i, "Amt"), 0.0) & _
                                      ", DateType='" & .GetRowCellValue(i, "DateType") & "'" & _
                                      ", FKeyCurr=" & IfValNull(.GetRowCellValue(i, "FKeyCurr"), "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "Null") & _
                                      ", Formula='" & .GetRowCellValue(i, "Formula") & "'" & _
                                      ", Prorata='" & .GetRowCellValue(i, "Prorata") & "'" & _
                                      ", Accum='" & .GetRowCellValue(i, "Accum") & "'" & _
                                      ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                      ",DateUpdated=(getdate())" & _
                                      "WHERE FKeyWScaleRank='" & .GetRowCellValue(i, "FKeyWScaleRank") & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next
                'If Len(pkeyList) > 1 Then
                '    query.Add("delete from tblAdmWscaleOnb where PKey in (" & Mid(pkeyList, 1, Len(pkeyList) - 1) & ")")
                '    currentPkey = ""
                'End If
            End With

            With Me.DedView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then

                        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName,
                        '                                         Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / Deductions", FormName) 'neil
                        Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / " & .GetRowCellDisplayText(i, "FKeyWageOnb")
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Onboard Deductions", 10, System.Environment.MachineName, cDataDescription, FormName)

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmWscaleOnb ( " & _
                                      "FKeyWScaleRank," & _
                                      "FKeyWageOnb, " & _
                                      "WageType, " & _
                                      "Amt, " & _
                                      "DateType, " & _
                                      "FKeyCurr, " & _
                                      "Formula, " & _
                                      "Prorata, " & _
                                      "Accum, " & _
                                      "LastUpdatedBy)" & _
                                      "VALUES('" & .GetRowCellValue(i, "FKeyWScaleRank") & "', " & _
                                      "'" & .GetRowCellValue(i, "FKeyWageOnb") & "', " & _
                                      "2, " & _
                                       IfNull(.GetRowCellValue(i, "Amt"), 0.0) & ", " & _
                                      "'" & .GetRowCellValue(i, "DateType") & "', " & _
                                     IfValNull(.GetRowCellValue(i, "FKeyCurr"), "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "Null") & ", " & _
                                      "'" & .GetRowCellValue(i, "Formula") & "', " & _
                                       "'" & .GetRowCellValue(i, "Prorata") & "', " & _
                                        "'" & .GetRowCellValue(i, "Accum") & "', " & _
                                      "'" & LastUpdatedBy & "')")
                        Else
                            query.Add("UPDATE dbo.tblAdmWscaleOnb " & _
                                      "SET FKeyWageOnb='" & .GetRowCellValue(i, "FKeyWageOnb") & "'" & _
                                      ", Amt=" & IfNull(.GetRowCellValue(i, "Amt"), 0.0) & _
                                      ", DateType='" & .GetRowCellValue(i, "DateType") & "'" & _
                                      ", FKeyCurr=" & IfValNull(.GetRowCellValue(i, "FKeyCurr"), "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "Null") & _
                                      ", Formula='" & .GetRowCellValue(i, "Formula") & "'" & _
                                      ", Prorata='" & .GetRowCellValue(i, "Prorata") & "'" & _
                                      ", Accum='" & .GetRowCellValue(i, "Accum") & "'" & _
                                      ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                      ",DateUpdated=(getdate())" & _
                                      "WHERE FKeyWScaleRank='" & .GetRowCellValue(i, "FKeyWScaleRank") & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next
            End With

            With Me.InfoView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then

                        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName,
                        '                                     Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / Wage Info", FormName) 'neil
                        Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / " & .GetRowCellDisplayText(i, "FKeyWageInfo")
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Wage Information", 10, System.Environment.MachineName, cDataDescription, FormName)

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmWscaleInfo ( " & _
                                      "FKeyWScaleRank," & _
                                      "FKeyWageInfo, " & _
                                      "DateType, " & _
                                      "Int, " & _
                                      "Den, " & _
                                      "Prd, " & _
                                      "LastUpdatedBy)" & _
                                      "VALUES('" & .GetRowCellValue(i, "FKeyWScaleRank") & "', " & _
                                      "'" & .GetRowCellValue(i, "FKeyWageInfo") & "', " & _
                                      "'" & .GetRowCellValue(i, "DateType") & "', " & _
                                      IfNull(.GetRowCellValue(i, "Int"), 0) & ", " & _
                                      "'" & .GetRowCellValue(i, "Den") & "', " & _
                                      "'" & .GetRowCellValue(i, "Prd") & "', " & _
                                      "'" & LastUpdatedBy & "')")
                        Else
                            query.Add("UPDATE dbo.tblAdmWscaleInfo " & _
                                      "SET FKeyWageInfo='" & .GetRowCellValue(i, "FKeyWageInfo") & "'" & _
                                      ", Int=" & IfNull(.GetRowCellValue(i, "Int"), 0) & _
                                      ", DateType='" & .GetRowCellValue(i, "DateType") & "'" & _
                                      ", Den='" & .GetRowCellValue(i, "Den") & "'" & _
                                      ", Prd='" & .GetRowCellValue(i, "Prd") & "'" & _
                                      ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                      ",DateUpdated=(getdate())" & _
                                      "WHERE FKeyWScaleRank='" & .GetRowCellValue(i, "FKeyWScaleRank") & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next
            End With

            With Me.EmpeView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then

                        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName,
                        '                            Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / Employee Contribution", FormName) 'neil
                        Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / " & .GetRowCellDisplayText(i, "FKeyWageAsh")
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Employee Contribution", 10, System.Environment.MachineName, cDataDescription, FormName)

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmWscaleAsh ( " & _
                                      "FKeyWScaleRank," & _
                                      "FKeyWageAsh, " & _
                                      "WageType, " & _
                                      "Amt, " & _
                                      "DateType, " & _
                                      "FKeyCurr, " & _
                                      "Formula, " & _
                                      "LastUpdatedBy)" & _
                                      "VALUES('" & .GetRowCellValue(i, "FKeyWScaleRank") & "', " & _
                                      "'" & .GetRowCellValue(i, "FKeyWageAsh") & "', " & _
                                      "2, " & _
                                      IfNull(.GetRowCellValue(i, "Amt"), 0.0) & ", " & _
                                      "'" & .GetRowCellValue(i, "DateType") & "', " & _
                                     IfValNull(.GetRowCellValue(i, "FKeyCurr"), "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "Null") & ", " & _
                                      "'" & .GetRowCellValue(i, "Formula") & "', " & _
                                      "'" & LastUpdatedBy & "')")
                        Else
                            query.Add("UPDATE dbo.tblAdmWscaleAsh " & _
                                      "SET FKeyWageAsh='" & .GetRowCellValue(i, "FKeyWageAsh") & "'" & _
                                      ", Amt=" & IfNull(.GetRowCellValue(i, "Amt"), 0.0) & _
                                      ", DateType='" & .GetRowCellValue(i, "DateType") & "'" & _
                                      ", FKeyCurr=" & IfValNull(.GetRowCellValue(i, "FKeyCurr"), "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "Null") & _
                                      ", Formula='" & .GetRowCellValue(i, "Formula") & "'" & _
                                      ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                      ",DateUpdated=(getdate())" & _
                                      "WHERE FKeyWScaleRank='" & .GetRowCellValue(i, "FKeyWScaleRank") & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next
            End With

            With Me.EmprView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then

                        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName,
                        '                         Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / Employer Contribution", FormName) 'neil
                        Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " / " & .GetRowCellDisplayText(i, "FKeyWageAshEmp")
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Employer Contribution", 10, System.Environment.MachineName, cDataDescription, FormName)

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmWscaleAshEmp ( " & _
                                      "FKeyWScaleRank," & _
                                      "FKeyWageAshEmp, " & _
                                      "Amt, " & _
                                      "DateType, " & _
                                      "FKeyCurr, " & _
                                      "Formula, " & _
                                      "LastUpdatedBy)" & _
                                      "VALUES('" & .GetRowCellValue(i, "FKeyWScaleRank") & "', " & _
                                      "'" & .GetRowCellValue(i, "FKeyWageAshEmp") & "', " & _
                                      IfNull(.GetRowCellValue(i, "Amt"), 0.0) & ", " & _
                                      "'" & .GetRowCellValue(i, "DateType") & "', " & _
                                      IfValNull(.GetRowCellValue(i, "FKeyCurr"), "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "Null") & ", " & _
                                      "'" & .GetRowCellValue(i, "Formula") & "', " & _
                                      "'" & LastUpdatedBy & "')")
                        Else
                            query.Add("UPDATE dbo.tblAdmWscaleAshEmp " & _
                                      "SET FKeyWageAshEmp='" & .GetRowCellValue(i, "FKeyWageAshEmp") & "'" & _
                                      ", Amt=" & IfNull(.GetRowCellValue(i, "Amt"), 0.0) & _
                                      ", DateType='" & .GetRowCellValue(i, "DateType") & "'" & _
                                      ", FKeyCurr=" & IfValNull(.GetRowCellValue(i, "FKeyCurr"), "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "Null") & _
                                      ", Formula='" & .GetRowCellValue(i, "Formula") & "'" & _
                                      ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                      ",DateUpdated=(getdate())" & _
                                      "WHERE FKeyWScaleRank='" & .GetRowCellValue(i, "FKeyWScaleRank") & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next
            End With

            info = DB.RunSqls(query)
            BRECORDUPDATEDs = False
            alrdyAsk = True

            blList.RefreshData()

            If info Then
                blList.SetSelection(id)
                RefreshData()
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
            End If

        End If
        'ElseIf qanswer = MsgBoxResult.No Then
        '    RefreshData()
        'Else
        'End If
    End Sub

    Public Overrides Sub DeleteData()
        If IsNothing(ObjFocusedView) Then
            Call DeleteMain()
        Else
            Call DeleteSubTable()
        End If

        'Dim info As Boolean = False

        'If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then
        '    If DB.isDeleteAllowed(Me.TableName, strID) Then
        '        clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
        '        info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
        '        blList.RefreshData()
        '        If info Then
        '            ClearFields(Me.LayoutControl1.Root, False)
        '            MsgBox(GetMessage("Deleted"), MsgBoxStyle.Information, GetAppName)
        '            RefreshData()
        '        End If
        '    Else
        '        MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Information, GetAppName)
        '    End If

        'End If

    End Sub

    Private Function DeleteMain() As Boolean

        Dim info As Boolean = False


        Try
            If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then
                If DB.isDeleteAllowed(Me.TableName, strID) Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)

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
                    blList.RefreshData()
                    If info Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        ClearFields(Me.LayoutControl1.Root, False)
                        MsgBox(GetMessage("Deleted"), MsgBoxStyle.Information, GetAppName)
                        RefreshData()
                    End If
                Else
                    MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Information, GetAppName)
                End If

            End If
        Catch
            Return False
        End Try

        Return True
    End Function

    Function DeleteSubTable() As Boolean
        Dim info As Boolean
        Dim id As String = ""
        Dim delsql As String = ""

        'Select Case param(0)
        '    'Case "DeleteOther"
        '    '   DeleteSubItem()
        '    'Case "Preview"
        '    '    Preview()

        'End Select

        'MsgBox(ObjFocusedView.Name)


        Try

            If Not ObjFocusedView Is Nothing Then
                If (ObjFocusedView.IsFocusedView) Then
                    'Dim primeKey As String
                    ' If MsgBox("Select Yes to continue deletion of selected record.", vbYesNo + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Yes Then
                    With ObjFocusedView
                        id = strID
                        Select Case .Name
                            Case "EarnView"
                                'primeKey = "FKeyWageOnb"
                                If MsgBox("Are you sure want to delete " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageOnb") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                                    Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(Me.RankView.FocusedRowHandle, "FKeyRank") & " / " & ObjFocusedView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageOnb")
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Onboard Earnings", 10, System.Environment.MachineName, cDataDescription, FormName)

                                    delsql = "delete from tbladmwscaleonb where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                                    clsAudit.saveAuditPreDelDetails("tbladmwscaleonb", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                                    '<!--added by tony20180922 : Log Deletion
                                    oLogDeletion.Init()
                                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                        FormName, _
                                        "Admin", _
                                        "tbladmwscaleonb", _
                                        "PKey IN ('" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "')", _
                                        "<< Delete Admin Data - " & FormName & " - Onboard Earning >>", _
                                        LogDeletion.DeletionType.Manual, _
                                        "Manually Deleted in <" & FormName & "- Onboard Earning>", _
                                        GetUserName())
                                    '-->
                                    info = DB.RunSql(delsql)
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    Call subRefreshEarnDtSource()
                                    Call EditDataEarn(True)
                                    'MsgBox(ObjFocusedView.GetFocusedRowCellValue("PKey"))
                                End If
                            Case "DedView"
                                'primeKey = "FKeyWageOnb"
                                If MsgBox("Are you sure want to delete " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageOnb") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                                    Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(Me.RankView.FocusedRowHandle, "FKeyRank") & " / " & ObjFocusedView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageOnb")
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Onboard Deductions", 10, System.Environment.MachineName, cDataDescription, FormName)

                                    delsql = "delete from tbladmwscaleonb where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                                    clsAudit.saveAuditPreDelDetails("tbladmwscaleonb", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                                    '<!--added by tony20180922 : Log Deletion
                                    oLogDeletion.Init()
                                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                        FormName, _
                                        "Admin", _
                                        "tbladmwscaleonb", _
                                        "PKey IN ('" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "')", _
                                        "<< Delete Admin Data - " & FormName & " - Onboard Deduction >>", _
                                        LogDeletion.DeletionType.Manual, _
                                        "Manually Deleted in <" & FormName & "- Onboard Deduction>", _
                                        GetUserName())
                                    '-->
                                    info = DB.RunSql(delsql)
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    Call subRefreshDedDtSource()
                                    Call EditDataDed(True)
                                End If
                            Case "RankView"
                                'primeKey = "FKeyRank"
                                If MsgBox("Are you sure want to delete " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                                    If DB.isDeleteAllowed(Me.TableName, ObjFocusedView.GetFocusedRowCellValue("PKey")) Then
                                        Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(Me.RankView.FocusedRowHandle, "FKeyRank")
                                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale Rank", 10, System.Environment.MachineName, cDataDescription, FormName)

                                        delsql = "delete from tbladmwscalerank where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                                        clsAudit.saveAuditPreDelDetails("tbladmwscalerank", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                                        '<!--added by tony20180922 : Log Deletion
                                        oLogDeletion.Init()
                                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                            FormName, _
                                            "Admin", _
                                            "tbladmwscalerank", _
                                            "PKey IN ('" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "')", _
                                            "<< Delete Admin Data - " & FormName & " - Rank >>", _
                                            LogDeletion.DeletionType.Manual, _
                                            "Manually Deleted in <" & FormName & "- Rank>", _
                                            GetUserName())
                                        '-->
                                        info = DB.RunSql(delsql)
                                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                        Dim tempDT As DataTable
                                        tempDT = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited FROM dbo.tblAdmWscaleRank WHERE FKeyWScale='" & strID & "'")
                                        Me.GrdRank.DataSource = tempDT
                                        Me.GrdRank.RefreshDataSource()
                                        'Call EditDataRank(True)
                                        'MsgBox(ObjFocusedView.GetFocusedRowCellValue("PKey"))
                                    Else
                                        MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Information, GetAppName)
                                    End If
                                End If
                            Case "InfoView"
                                'primeKey = "FKeyRank"
                                If MsgBox("Are you sure want to delete " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageInfo") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                                    Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(Me.RankView.FocusedRowHandle, "FKeyRank") & " / " & ObjFocusedView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageInfo")
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Wage Information", 10, System.Environment.MachineName, cDataDescription, FormName)

                                    delsql = "delete from tbladmwscaleinfo where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                                    clsAudit.saveAuditPreDelDetails("tbladmwscaleinfo", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                                    '<!--added by tony20180922 : Log Deletion
                                    oLogDeletion.Init()
                                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                        FormName, _
                                        "Admin", _
                                        "tbladmwscaleinfo", _
                                        "PKey IN ('" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "')", _
                                        "<< Delete Admin Data - " & FormName & " - Other Info >>", _
                                        LogDeletion.DeletionType.Manual, _
                                        "Manually Deleted in <" & FormName & "- Other Info>", _
                                        GetUserName())
                                    '-->
                                    info = DB.RunSql(delsql)
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    Call subRefreshInfoDtSource()
                                    Call EditDataInfo(True)
                                    'MsgBox(ObjFocusedView.GetFocusedRowCellValue("PKey"))
                                End If
                            Case "EmpeView"
                                If MsgBox("Are you sure want to delete " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageAsh") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                                    Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(Me.RankView.FocusedRowHandle, "FKeyRank") & " / " & ObjFocusedView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageAsh")
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Employees Contribution", 10, System.Environment.MachineName, cDataDescription, FormName)

                                    delsql = "delete from tbladmwscaleAsh where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                                    clsAudit.saveAuditPreDelDetails("tbladmwscaleAsh", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                                    '<!--added by tony20180922 : Log Deletion
                                    oLogDeletion.Init()
                                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                        FormName, _
                                        "Admin", _
                                        "tbladmwscaleAsh", _
                                        "PKey IN ('" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "')", _
                                        "<< Delete Admin Data - " & FormName & " - Employee Contribution >>", _
                                        LogDeletion.DeletionType.Manual, _
                                        "Manually Deleted in <" & FormName & "- Employee Contribution>", _
                                        GetUserName())
                                    '-->
                                    info = DB.RunSql(delsql)
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    Call subRefreshEmpeDtSource()
                                    Call EditDataEmpe(True)
                                End If
                            Case "EmprView"
                                If MsgBox("Are you sure want to delete " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageAshEmp") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                                    Dim cDataDescription As String = Me.txtName.Text & " / " & Me.RankView.GetRowCellDisplayText(Me.RankView.FocusedRowHandle, "FKeyRank") & " / " & ObjFocusedView.GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageAshEmp")
                                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Wage Scale - Employers Contribution", 10, System.Environment.MachineName, cDataDescription, FormName)

                                    delsql = "delete from tbladmwscaleAshEmp where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                                    clsAudit.saveAuditPreDelDetails("tbladmwscaleAshEmp", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                                    '<!--added by tony20180922 : Log Deletion
                                    oLogDeletion.Init()
                                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                        FormName, _
                                        "Admin", _
                                        "tbladmwscaleAshEmp", _
                                        "PKey IN ('" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "')", _
                                        "<< Delete Admin Data - " & FormName & " - Employer Contribution >>", _
                                        LogDeletion.DeletionType.Manual, _
                                        "Manually Deleted in <" & FormName & "- Employer Contribution>", _
                                        GetUserName())
                                    '-->
                                    info = DB.RunSql(delsql)
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    Call subRefreshEmprDtSource()
                                    Call EditDataEmpr(True)
                                End If
                        End Select

                        'info = DB.RunSql(delsql)
                        'blList.RefreshData()
                        'blList.SetSelection(id)
                        'RefreshData()
                        'EditData()
                    End With
                    ' End If
                End If
            End If
        Catch
            Return False
        End Try

        Return True
    End Function

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        'Dim dict As New Dictionary(Of String, Integer)

        'Dim rtype(,) As String = {{"d", "d"}, {"g", "er"}}
        'Me.cboRateType.Properties.DisplayMember = "Column"
        'Me.cboRateType.Properties.ValueMember = "Column"
        'Me.cboRateType.Properties.DataSource = rtype

        '1;"Departed / Arrived";2;"Signed On / Off"
        dictDateType.Add("Departed / Arrived", 1)
        dictDateType.Add("Signed On / Off", 2)

        Me.LayoutControl1.AllowCustomization = False
        Me.cboFKeyCurr.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.frmAdmWscaleListCurr ORDER BY Name ASC")
        Me.cboFKeyWScalCalendar.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWScaleCalendar ORDER BY Name")
        dict.Add("Monthly", 1)
        dict.Add("Daily", 2)
        'Me.cboRateType.Properties.DisplayMember = "Key"
        'Me.cboRateType.Properties.ValueMember = "Value"
        Me.cboRateType.Properties.DataSource = New BindingSource(dict, Nothing)
        'Me.cboRateType.Properties.Columns("value").Visible = False

        Me.lkuFKeyRank.DataSource = DB.CreateTable("SELECT * FROM dbo.tbladmrank order by sortcode")
        'Me.lkuFKeyWageOnb.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageOnb WHERE (((tblAdmWageOnb.WageType)=1) AND ((tblAdmWageOnb.Prorata)='true')) ORDER BY tblAdmWageOnb.Name")
        'Me.lkuFKeyWageDed.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageOnb WHERE (((tblAdmWageOnb.WageType)=2) AND ((tblAdmWageOnb.Prorata)='true')) ORDER BY tblAdmWageOnb.Name")
        Me.lkuFKeyWageOnb.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageOnb WHERE ((tblAdmWageOnb.WageType)=1) ORDER BY tblAdmWageOnb.Name")
        Me.lkuFKeyWageDed.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageOnb WHERE ((tblAdmWageOnb.WageType)=2) ORDER BY tblAdmWageOnb.Name")

        Me.lkuEarFKeyCurr.DataSource = DB.CreateTable("SELECT * FROM dbo.frmAdmWscaleListCurr ORDER BY Name ASC")
        Me.lkuDedFKeyCurr.DataSource = DB.CreateTable("SELECT * FROM dbo.frmAdmWscaleListCurr ORDER BY Name ASC")

        Me.lkuEarDateType.DataSource = New BindingSource(dictDateType, Nothing)
        Me.lkuDedDateType.DataSource = New BindingSource(dictDateType, Nothing)

        '-------------------
        'info
        '-------------------
        Me.lkuInfoDateType.DataSource = New BindingSource(dictDateType, Nothing)
        Me.lkuFKeyWageInfo.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageInfo ORDER BY tblAdmWageInfo.Name")
        Me.lkuInfoDen.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageDen ORDER BY tblAdmWageDen.Name")
        Me.lkuInfoPrd.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWagePrd ORDER BY tblAdmWagePrd.Name")

        '-------------------
        'Employee
        '-------------------
        Me.lkuEmpeCurr.DataSource = DB.CreateTable("SELECT * FROM dbo.frmAdmWscaleListCurr ORDER BY Name ASC")
        Me.lkuEmpeWageAsh.DataSource = DB.CreateTable("SELECT * FROM tblAdmWageAsh WHERE (((tblAdmWageAsh.WageType)=2)) ORDER BY tblAdmWageAsh.Name")
        Me.lkuEmpeDateType.DataSource = New BindingSource(dictDateType, Nothing)

        '------------------
        'Employer
        '------------------
        Me.lkuEmprCurr.DataSource = DB.CreateTable("SELECT * FROM dbo.frmAdmWscaleListCurr ORDER BY Name ASC")
        Me.lkuEmprWageAshEmp.DataSource = DB.CreateTable("SELECT * FROM tblAdmWageAshEmp ORDER BY tblAdmWageAshEmp.Name")
        Me.lkuEmprDateType.DataSource = New BindingSource(dictDateType, Nothing)

        '------------------
        'Copy Wage Scale Rank & Update Wage Scale buttons
        '------------------
        EnableSubButtons(False)
    End Sub

    Private Sub LoadSub()
        BRECORDUPDATEDs = False
        Dim dtRank As DataTable
        'dtRank = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited,CAST(0 as BIT) AS isDelete FROM dbo.tblAdmWscaleRank WHERE FKeyWScale='" & strID & "'")
        dtRank = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited FROM dbo.tblAdmWscaleRank " & _
                               "INNER Join " & _
                               "tblAdmRank ON tblAdmWscaleRank.FKeyRank = tblAdmRank.PKey " & _
                               "WHERE FKeyWScale='" & strID & "' order by SortCode")
        Me.GrdRank.DataSource = dtRank

        Call RefreshAllSubTab(True) '20160524

    End Sub

    'Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
    '    Dim info As Boolean = False
    '    Dim delsql As String = "", currentPkey As String, pkeyList As String = ""


    '    'MsgBox(Me.RankView.RowCount)
    '    With Me.RankView
    '        '.CloseEditForm()
    '        .CloseEditor()
    '        .UpdateCurrentRow()
    '        For i As Integer = 0 To .RowCount - 1
    '            If .GetRowCellValue(i, "isDelete") Then
    '                currentPkey = IfNull(.GetRowCellValue(i, "PKey"), "")
    '                If currentPkey <> "" Then
    '                    pkeyList = pkeyList & currentPkey & ","
    '                End If
    '            End If
    '        Next
    '    End With

    '    MsgBox(pkeyList)
    '    'delsql = "delete from tbladmwscalerank where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
    '    'info = DB.RunSql(delsql)

    '    'Dim tempDT As DataTable
    '    'tempDT = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited FROM dbo.tblAdmWscaleRank WHERE FKeyWScale='" & strID & "'")
    '    'Me.GrdRank.DataSource = tempDT
    '    'Me.GrdRank.RefreshDataSource()

    '    'info = DB.RunSqls(query)
    'End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Dim info As Boolean
        Dim id As String = ""
        Dim delsql As String = ""

        Select Case param(0)
            'Case "DeleteOther"
            '   DeleteSubItem()
            'Case "Preview"
            '    Preview()

        End Select

        'MsgBox(ObjFocusedView.Name)
        If Not ObjFocusedView Is Nothing Then
            If (ObjFocusedView.IsFocusedView) Then
                'Dim primeKey As String
                If MsgBox("Select Yes to continue deletion of selected record.", vbYesNo + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Yes Then

                    id = strID
                    Select Case ObjFocusedView.Name
                        Case "EarnView"
                            'primeKey = "FKeyWageOnb"
                            delsql = "delete from tbladmwscaleonb where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                            clsAudit.saveAuditPreDelDetails("tbladmwscaleonb", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                            info = DB.RunSql(delsql)
                            Call subRefreshEarnDtSource()
                            Call EditDataEarn(True)
                            'MsgBox(ObjFocusedView.GetFocusedRowCellValue("PKey"))
                        Case "DedView"
                            'primeKey = "FKeyWageOnb"
                            delsql = "delete from tbladmwscaleonb where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                            clsAudit.saveAuditPreDelDetails("tbladmwscaleonb", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                            info = DB.RunSql(delsql)
                            Call subRefreshDedDtSource()
                            Call EditDataDed(True)
                        Case "RankView"
                            'primeKey = "FKeyRank"
                            delsql = "delete from tbladmwscalerank where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                            clsAudit.saveAuditPreDelDetails("tbladmwscalerank", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                            info = DB.RunSql(delsql)
                            Dim tempDT As DataTable
                            tempDT = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited FROM dbo.tblAdmWscaleRank WHERE FKeyWScale='" & strID & "'")
                            Me.GrdRank.DataSource = tempDT
                            Me.GrdRank.RefreshDataSource()
                            'Call EditDataRank(True)
                            'MsgBox(ObjFocusedView.GetFocusedRowCellValue("PKey"))
                        Case "InfoView"
                            'primeKey = "FKeyRank"
                            delsql = "delete from tbladmwscaleinfo where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                            clsAudit.saveAuditPreDelDetails("tbladmwscaleinfo", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                            info = DB.RunSql(delsql)
                            Call subRefreshInfoDtSource()
                            Call EditDataInfo(True)
                            'MsgBox(ObjFocusedView.GetFocusedRowCellValue("PKey"))
                        Case "EmpeView"
                            delsql = "delete from tbladmwscaleAsh where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                            clsAudit.saveAuditPreDelDetails("tbladmwscaleAsh", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                            info = DB.RunSql(delsql)
                            Call subRefreshEmpeDtSource()
                            Call EditDataEmpe(True)
                        Case "EmprView"
                            delsql = "delete from tbladmwscaleAshEmp where PKey ='" & ObjFocusedView.GetFocusedRowCellValue("PKey") & "'"
                            clsAudit.saveAuditPreDelDetails("tbladmwscaleAshEmp", ObjFocusedView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                            info = DB.RunSql(delsql)
                            Call subRefreshEmprDtSource()
                            Call EditDataEmpr(True)
                    End Select

                    'info = DB.RunSql(delsql)
                    'blList.RefreshData()
                    'blList.SetSelection(id)
                    'RefreshData()
                    'EditData()
                End If
            End If
        End If
    End Sub


    Private Sub DeleteSubItem()
        'If MsgBox("Are you sure want to delete " & IIf(ContactView.GetRowCellDisplayText(ContactView.FocusedRowHandle, "Country") = "", "the Item", ContactView.GetRowCellDisplayText(ContactView.FocusedRowHandle, "Country")) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        'If IfNull(ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey"), "") <> "" Then
        '    DB.RunSql("DELETE FROM dbo.tblAdmPortAgentContacts WHERE PKey='" & ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey") & "'")
        'End If
        'ContactView.DeleteRow(ContactView.FocusedRowHandle)
        'If ContactView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
        'End If
    End Sub

    Private Sub TabOnb_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabOnb.SelectedPageChanged
        If Not isEditing Then
            Select Case Me.TabOnb.SelectedTabPageIndex
                Case 0
                    Call subRefreshEarnDtSource()
                Case 1
                    Call subRefreshDedDtSource()
                Case 2
                    Call subRefreshInfoDtSource()
            End Select
        End If

    End Sub


#Region "WSRank"
    'Private Function queryAddRank(isEdited As Boolean) As String
    '    Dim tempReturn As String



    '    Return tempReturn
    'End Function
    Private Sub RefreshDataRank()
        Me.RankView.OptionsBehavior.ReadOnly = True
        Me.RankView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
        Me.RankView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
        Me.RankView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
        Me.RankView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        'Me.RankView.Columns("isDelete").Visible = False
    End Sub

    Private Sub EditDataRank(parB As Boolean)
        If parB Then
            Me.RankView.OptionsBehavior.ReadOnly = False
            Me.RankView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.RankView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.RankView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            Me.RankView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            'Me.RankView.Columns("isDelete").Visible = True
        Else
            Me.RankView.OptionsBehavior.ReadOnly = True
            Me.RankView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.RankView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.RankView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.RankView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            'Me.RankView.Columns("isDelete").Visible = False
        End If
    End Sub

    Private Sub AddDataRank()
        Me.RankView.OptionsBehavior.ReadOnly = False
        Me.RankView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
        Me.RankView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
        Me.RankView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        Me.RankView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub rankview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RankView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.RankView
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'BRECORDUPDATEDs = True
                '.SetRowCellValue(e.RowHandle, "FKeyCntry", strID)
            End With
        End If
    End Sub

    Private Sub rankview_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RankView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub


    Private Sub RankView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles RankView.FocusedRowChanged
        Dim currentSel As Int32

        currentSel = Me.RankView.FocusedRowHandle
        'MyBase.EditData()
        'MsgBox(isEditdable)

        If isEditing Then

            If NotSaveYet(Me.EarnView) Or NotSaveYet(Me.DedView) Or NotSaveYet(Me.InfoView) Or
                    NotSaveYet(Me.EmpeView) Or NotSaveYet(Me.EmprView) Then
                If Not alrdyAsk Then
                    If MsgBox("There are Pay Items that are not yet saved. Disregard?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then

                        Call RefreshAllSubTab(True)

                        If getCurrentRank() = "" Then
                            Call EditDataEarn(False)
                            Call EditDataDed(False)
                            Call EditDataInfo(False)
                            Call EditDataEmpe(False)
                            Call EditDataEmpr(False)
                        Else
                            Call EditDataEarn(True)
                            Call EditDataDed(True)
                            Call EditDataInfo(True)
                            Call EditDataEmpe(True)
                            Call EditDataEmpr(True)
                        End If

                        'isEditing = False
                        alrdyAsk = True
                    Else
                        alrdyAsk = True
                        Me.RankView.FocusedRowHandle = currentRnkFocusRow 'this line will trigger this function again
                        'Call RefreshAllSubTab(True)

                        If getCurrentRank() = "" Then
                            Call EditDataEarn(False)
                            Call EditDataDed(False)
                            Call EditDataInfo(False)
                            Call EditDataEmpe(False)
                            Call EditDataEmpr(False)
                        Else
                            Call EditDataEarn(True)
                            Call EditDataDed(True)
                            Call EditDataInfo(True)
                            Call EditDataEmpe(True)
                            Call EditDataEmpr(True)
                        End If
                        alrdyAsk = False
                    End If
                Else
                    ' Call RefreshAllSubTab()
                End If
            Else
                If getCurrentRank() = "" Then
                    Call EditDataEarn(False)
                    Call EditDataDed(False)
                    Call EditDataInfo(False)
                    Call EditDataEmpe(False)
                    Call EditDataEmpr(False)
                Else
                    Call EditDataEarn(True)
                    Call EditDataDed(True)
                    Call EditDataInfo(True)
                    Call EditDataEmpe(True)
                    Call EditDataEmpr(True)
                End If

                Call RefreshAllSubTab(True)
            End If

        Else
            Call RefreshAllSubTab(True)
        End If

    End Sub


    Private Sub rankview_GotFocus(sender As Object, e As System.EventArgs) Handles RankView.GotFocus
        'ObjFocusedView = Me.RankView
        Call changeDeleteCaption(sender, "Remove Rank")
    End Sub

    Private Sub rankview_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RankView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyWScale"), strID)
        'View.SetRowCellValue(e.RowHandle, View.Columns("isDelete"), False)
        SubAddMode = True
    End Sub

    Private Sub rankview_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles RankView.InvalidRowException
        'neil 20160524 e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub rankview_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles RankView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            RankView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub rankview_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles RankView.RowCellStyle
        Call rowcellStyle(RankView, e, "FKeyRank")
    End Sub

    Private Sub RankView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles RankView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub RankView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles RankView.ShowingPopupEditForm
        Call showingPopUpForm(e, "Pay Scale Ranks")
    End Sub

    Private Sub RankView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles RankView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Rnk As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyRank")
        'MsgBox(view.GetRowCellValue(e.RowHandle, Rnk))
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If view.GetRowCellValue(e.RowHandle, Rnk) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Rnk) Is Nothing Then
                e.Valid = False
                view.SetColumnError(Rnk, "Please select Rank")
                view.FocusedColumn = view.VisibleColumns(0)
            End If
        End If
    End Sub
#End Region

#Region "WS_ONB_EARN"

    Private Sub subRefreshEarnDtSource()
        Dim dtEarn As DataTable, colval As String

        If Not IsNothing(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)) Then
            colval = Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey").ToString

            If Not IsDBNull(colval) Then
                currentWRankID = colval 'Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey")
                'dtEarn = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited,CAST(0 as BIT) AS isDelete FROM tblAdmWScaleOnb " &
                dtEarn = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleOnb " &
                                       "INNER JOIN tblAdmWageOnb ON tblAdmWScaleOnb.FKeyWageOnb = tblAdmWageOnb.PKey " &
                                       "WHERE ((tblAdmWScaleOnb.WageType)=1) and FKeyWScaleRank='" & currentWRankID & "' ORDER BY tblAdmWageOnb.SortCode,tblAdmWageOnb.Name")
                '"WHERE (((tblAdmWScaleOnb.WageType)=1) AND ((tblAdmWageOnb.Prorata)='true')) and FKeyWScaleRank='" & currentWRankID & "' ORDER BY tblAdmWageOnb.SortCode")
                Me.GrdEarn.DataSource = dtEarn
                'MsgBox(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey"))
            Else
                Me.GrdEarn.DataSource = Nothing
            End If
        Else
            Me.GrdEarn.DataSource = Nothing
        End If
    End Sub


    Private Sub RefreshDataEarn()
        Me.EarnView.OptionsBehavior.ReadOnly = True
        Me.EarnView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
        Me.EarnView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
        Me.EarnView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
        Me.EarnView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        'Me.EarnView.Columns("isDelete").Visible = False
    End Sub

    Private Sub EditDataEarn(parB As Boolean)
        If parB Then
            Me.EarnView.OptionsBehavior.ReadOnly = False
            Me.EarnView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.EarnView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.EarnView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            Me.EarnView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            'Me.EarnView.Columns("isDelete").Visible = True
        Else
            Me.EarnView.OptionsBehavior.ReadOnly = True
            Me.EarnView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.EarnView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.EarnView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.EarnView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            'Me.EarnView.Columns("isDelete").Visible = False
        End If
    End Sub

    Private Sub AddDataEarn()
        Me.EarnView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
        Me.EarnView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
        Me.EarnView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        Me.EarnView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub earnview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EarnView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.EarnView
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'BRECORDUPDATEDs = True
                '.SetRowCellValue(e.RowHandle, "FKeyCntry", strID)
                currentRnkFocusRow = Me.RankView.FocusedRowHandle
                alrdyAsk = False
            End With
        End If
    End Sub

    Private Sub earnview_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EarnView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EarnView_EditFormShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs) Handles EarnView.EditFormShowing
        If getCurrentRank() = "" Then
            MsgBox("Please add/save Rank first before entering Pay Items", MsgBoxStyle.Exclamation, GetAppName)
            e.Allow = False
        End If
    End Sub

    Private Sub earnview_GotFocus(sender As Object, e As System.EventArgs) Handles EarnView.GotFocus
        'ObjFocusedView = Me.EarnView
        Call changeDeleteCaption(sender, "Remove Earning Item")
    End Sub

    Private Sub earnview_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EarnView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender

        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyWScaleRank"), currentWRankID)
        View.SetRowCellValue(e.RowHandle, View.Columns("isDelete"), False)
        currentRnkFocusRow = Me.RankView.FocusedRowHandle
        alrdyAsk = False
    End Sub

    Private Sub earnview_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles EarnView.InvalidRowException
        'neil 20160524 e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub earnview_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles EarnView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            EarnView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub earnview_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EarnView.RowCellStyle
        Call rowcellStyle(EarnView, e, "FKeyWageOnb")
    End Sub

    Private Sub earnview_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles EarnView.RowUpdated
        BRECORDUPDATEDs = True
        'Dim xx As Integer
        'xx = e.RowHandle
        'If (e.Row("fkeycurr").ToString = "") Then
        '    Me.EarnView.FocusedRowHandle = xx
        '    Me.EarnView.FocusedColumn = EarnView.VisibleColumns(2)
        'End If
        'MsgBox(e.Row("FKeyWageOnb").ToString = "")

    End Sub

    Private Sub EarnView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles EarnView.ShowingPopupEditForm
        Call showingPopUpForm(e, "Pay Scale Earnings Onboard")
    End Sub

    Private Sub earnview_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles EarnView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim wonb As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyWageOnb")
        Dim curr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCurr")
        Dim dType As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateType")
        Dim isvalid As Boolean = True

        'MsgBox(view.GetRowCellValue(e.RowHandle, wonb))
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            'If getCurrentRank() <> "" Then
            If view.GetRowCellValue(e.RowHandle, wonb) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, wonb) Is Nothing Then
                isvalid = False
                view.SetColumnError(wonb, "Please select Wage Item")
                view.FocusedColumn = view.VisibleColumns(0)
            End If
            If view.GetRowCellValue(e.RowHandle, curr) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, curr) Is Nothing Then
                isvalid = False
                view.SetColumnError(curr, "Please select currency")
                view.FocusedColumn = view.VisibleColumns(2)
            End If
            If view.GetRowCellValue(e.RowHandle, dType) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, dType) Is Nothing Then
                isvalid = False
                view.SetColumnError(dType, "Please select Start/End Date type")
                view.FocusedColumn = view.VisibleColumns(3)
            End If
            'Else
            'MsgBox("Please add/save Rank first before entering Pay Items", MsgBoxStyle.Exclamation)
            'End If
        End If
        e.Valid = isvalid
    End Sub

    Private Sub EarnView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles EarnView.ValidatingEditor
        Call SValidatingEditor(e, EarnView, "FKeyWageOnb")
    End Sub

    'Private Sub lkuFKeyWageOnb_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles lkuFKeyWageOnb.EditValueChanging
    '    If Not e.NewValue Is System.DBNull.Value Then
    '        If isAlreadySelected(e.NewValue, IfNull(Me.EarnView.GetFocusedRowCellValue("PKey"), ""), EarnView, "FKeyWageOnb") Then
    '            MsgBox("Item already in the list/selected. Please select other item.", MsgBoxStyle.Information)
    '            e.NewValue = String.Empty
    '        End If
    '    End If
    'End Sub



#End Region

#Region "WS_ONB_DED"

    Private Sub subRefreshDedDtSource()
        Dim dt As DataTable, colval As String

        If Not IsNothing(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)) Then
            colval = Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey").ToString

            If Not IsDBNull(colval) Then
                currentWRankID = colval 'Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey")
                dt = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited FROM tblAdmWScaleOnb " &
                                       "INNER JOIN tblAdmWageOnb ON tblAdmWScaleOnb.FKeyWageOnb = tblAdmWageOnb.PKey " &
                                       "WHERE ((tblAdmWScaleOnb.WageType)=2) and FKeyWScaleRank='" & currentWRankID & "' ORDER BY tblAdmWageOnb.SortCode,tblAdmWageOnb.Name")
                '"WHERE (((tblAdmWScaleOnb.WageType)=2) AND ((tblAdmWageOnb.Prorata)='true')) and FKeyWScaleRank='" & currentWRankID & "' ORDER BY tblAdmWageOnb.SortCode")
                Me.GrdDed.DataSource = dt
                'MsgBox(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey"))
            Else
                Me.GrdDed.DataSource = Nothing
            End If
        Else
            Me.GrdDed.DataSource = Nothing
        End If
    End Sub


    Private Sub RefreshDataDed()
        Me.DedView.OptionsBehavior.ReadOnly = True
        Me.DedView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
        Me.DedView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
        Me.DedView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
        Me.DedView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub EditDataDed(parB As Boolean)
        If parB Then
            Me.DedView.OptionsBehavior.ReadOnly = False
            Me.DedView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.DedView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.DedView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            Me.DedView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Else
            Me.DedView.OptionsBehavior.ReadOnly = True
            Me.DedView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.DedView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.DedView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.DedView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        End If
    End Sub

    Private Sub AddDataDed()
        Me.DedView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
        Me.DedView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
        Me.DedView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        Me.DedView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub dedview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DedView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.DedView
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'BRECORDUPDATEDs = True
                '.SetRowCellValue(e.RowHandle, "FKeyCntry", strID)
                currentRnkFocusRow = Me.RankView.FocusedRowHandle
                alrdyAsk = False
            End With
        End If
    End Sub

    Private Sub dedview_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DedView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub dedview_GotFocus(sender As Object, e As System.EventArgs) Handles DedView.GotFocus
        'ObjFocusedView = Me.DedView
        Call changeDeleteCaption(sender, "Remove Deduction Item")
    End Sub

    Private Sub dedview_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DedView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyWScaleRank"), currentWRankID)
        currentRnkFocusRow = Me.RankView.FocusedRowHandle
        alrdyAsk = False
    End Sub

    Private Sub dedview_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles DedView.InvalidRowException
        'neil 20160524 e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub dedview_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DedView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            DedView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub DedView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DedView.ValidatingEditor
        Call SValidatingEditor(e, DedView, "FKeyWageOnb")
    End Sub

    Private Sub dedview_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DedView.RowCellStyle
        Call rowcellStyle(DedView, e, "FKeyWageOnb")
    End Sub

    Private Sub dedview_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles DedView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub dedview_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DedView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim wonb As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyWageOnb")
        Dim curr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCurr")
        Dim dType As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateType")
        Dim isvalid As Boolean = True

        'MsgBox(view.GetRowCellValue(e.RowHandle, wonb))
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If view.GetRowCellValue(e.RowHandle, wonb) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, wonb) Is Nothing Then
                isvalid = False
                view.SetColumnError(wonb, "Please select Wage Item")
                view.FocusedColumn = view.VisibleColumns(0)
            End If

            If view.GetRowCellValue(e.RowHandle, curr) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, curr) Is Nothing Then
                isvalid = False
                view.SetColumnError(curr, "Please select currency")
                view.FocusedColumn = view.VisibleColumns(2)
            End If

            If view.GetRowCellValue(e.RowHandle, dType) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, dType) Is Nothing Then
                isvalid = False
                view.SetColumnError(dType, "Please select Start/End Date type")
                view.FocusedColumn = view.VisibleColumns(3)
            End If
        End If


        e.Valid = isvalid
    End Sub

    Private Sub dedView_EditFormShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs) Handles DedView.EditFormShowing
        If getCurrentRank() = "" Then
            MsgBox("Please add/save Rank first before entering Pay Items", MsgBoxStyle.Exclamation, GetAppName)
            e.Allow = False
        End If
    End Sub

    'Private Sub lkuFKeyWageDed_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles lkuFKeyWageDed.EditValueChanging
    '    If Not e.NewValue Is System.DBNull.Value Then
    '        If isAlreadySelected(e.NewValue, IfNull(Me.DedView.GetFocusedRowCellValue("PKey"), ""), DedView, "FKeyWageOnb") Then
    '            MsgBox("Item already in the list/selected. Please select other item.", MsgBoxStyle.Information)
    '            e.NewValue = String.Empty
    '        End If
    '    End If
    'End Sub

    Private Sub DedView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles DedView.ShowingPopupEditForm
        Call showingPopUpForm(e, "Pay Scale Deductions Onboard")
    End Sub

#End Region

#Region "WS_INFO"

    Private Sub subRefreshInfoDtSource()
        Dim dt As DataTable, colval As String

        If Not IsNothing(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)) Then
            colval = Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey").ToString

            If Not IsDBNull(colval) Then
                currentWRankID = colval 'Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey")
                dt = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited " &
                                    "FROM tblAdmWScaleInfo INNER JOIN tblAdmWageInfo ON tblAdmWScaleInfo.FKeyWageInfo = tblAdmWageInfo.PKey " &
                                    "where FKeyWScaleRank='" & currentWRankID & "' " &
                                    "ORDER BY tblAdmWageInfo.SortCode, tblAdmWageInfo.Name")

                Me.GrdInfo.DataSource = dt
                'MsgBox(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey"))
            Else
                Me.GrdInfo.DataSource = Nothing
            End If
        Else
            Me.GrdInfo.DataSource = Nothing
        End If
    End Sub


    Private Sub RefreshDataInfo()
        Me.InfoView.OptionsBehavior.ReadOnly = True
        Me.InfoView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
        Me.InfoView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
        Me.InfoView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
        Me.InfoView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub EditDataInfo(parB As Boolean)
        If parB Then
            Me.InfoView.OptionsBehavior.ReadOnly = False
            Me.InfoView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.InfoView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.InfoView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            Me.InfoView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Else
            Me.InfoView.OptionsBehavior.ReadOnly = True
            Me.InfoView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.InfoView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.InfoView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.InfoView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        End If
    End Sub

    Private Sub AddDataInfo()
        Me.InfoView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
        Me.InfoView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
        Me.InfoView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        Me.InfoView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub InfoView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles InfoView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.InfoView
                'Added by Calvhin 20170208
                If e.Column.FieldName = "FKeyWageInfo" Then
                    If e.Value = "SYSPAYLD" Then
                        .SetRowCellValue(e.RowHandle, "Den", "MAIN10MOKF6AE6H")
                        .SetRowCellValue(e.RowHandle, "Prd", "MAIN1PIT9PYICUC")
                        .SetRowCellValue(e.RowHandle, "DateType", "2")
                    End If
                End If
                'End Calvhin

                .SetRowCellValue(e.RowHandle, "Edited", True)
                'BRECORDUPDATEDs = True
                '.SetRowCellValue(e.RowHandle, "FKeyCntry", strID)
                currentRnkFocusRow = Me.RankView.FocusedRowHandle
                alrdyAsk = False
            End With
        End If
    End Sub

    Private Sub InfoView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles InfoView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub InfoView_GotFocus(sender As Object, e As System.EventArgs) Handles InfoView.GotFocus
        ' ObjFocusedView = Me.InfoView
        Call changeDeleteCaption(sender, "Remove Wage Info Item")
    End Sub

    Private Sub InfoView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles InfoView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyWScaleRank"), currentWRankID)
        currentRnkFocusRow = Me.RankView.FocusedRowHandle
        alrdyAsk = False
    End Sub

    Private Sub InfoView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles InfoView.InvalidRowException
        'neil 20160524 e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub InfoView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles InfoView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            InfoView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub InfoView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles InfoView.RowCellStyle
        Call rowcellStyle(InfoView, e, "FKeyWageInfo")
    End Sub

    Private Sub InfoView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles InfoView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub InfoView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles InfoView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim grdcol As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyWageInfo")
        Dim dType As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateType")

        'MsgBox(view.GetRowCellValue(e.RowHandle, grdcol))
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If view.GetRowCellValue(e.RowHandle, grdcol) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, grdcol) Is Nothing Then
                e.Valid = False
                view.SetColumnError(grdcol, "Please select Wage Item")
                view.FocusedColumn = view.VisibleColumns(0)
            End If
            If view.GetRowCellValue(e.RowHandle, dType) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, dType) Is Nothing Then
                e.Valid = False
                view.SetColumnError(dType, "Please select Start/End Date type")
                view.FocusedColumn = view.VisibleColumns(3)
            End If
        End If
    End Sub

    Private Sub InfoView_EditFormShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs) Handles InfoView.EditFormShowing
        If getCurrentRank() = "" Then
            MsgBox("Please add/save Rank first before entering Pay Items", MsgBoxStyle.Exclamation, GetAppName)
            e.Allow = False
        End If
    End Sub

    Private Sub InfoView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles InfoView.ShowingPopupEditForm
        Call showingPopUpForm(e, "Pay Scale Wage Information")
    End Sub

    Private Sub InfoView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles InfoView.ValidatingEditor
        Call SValidatingEditor(e, InfoView, "FKeyWageInfo")
    End Sub

    'Private Sub lkuFKeyWageInfo_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles lkuFKeyWageInfo.EditValueChanging
    '    If Not e.NewValue Is System.DBNull.Value Then
    '        If isAlreadySelected(e.NewValue, IfNull(Me.InfoView.GetFocusedRowCellValue("PKey"), ""), InfoView, "FKeyWageInfo") Then
    '            MsgBox("Item already in the list/selected. Please select other item.", MsgBoxStyle.Information)
    '            e.NewValue = String.Empty
    '        End If
    '    End If
    'End Sub


#End Region

#Region "WS_ASH_EMPE"

    Private Sub subRefreshEmpeDtSource()
        Dim dtEmpe As DataTable, colval As String

        If Not IsNothing(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)) Then
            colval = Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey").ToString

            If Not IsDBNull(colval) Then
                currentWRankID = colval 'Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey")
                dtEmpe = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited " &
                                        "FROM tblAdmWScaleAsh INNER JOIN tblAdmWageAsh ON tblAdmWScaleAsh.FKeyWageAsh = tblAdmWageAsh.PKey " &
                                        "WHERE (tblAdmWScaleAsh.WageType = 2) " &
                                        "and FKeyWScaleRank='" & currentWRankID & "' ORDER BY tblAdmWageAsh.SortCode,tblAdmWageAsh.Name")
                Me.GrdEmpe.DataSource = dtEmpe
                ' MsgBox(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey"))
            Else
                Me.GrdEmpe.DataSource = Nothing
            End If
        Else
            Me.GrdEmpe.DataSource = Nothing
        End If
    End Sub


    Private Sub RefreshDataEmpe()
        Me.EmpeView.OptionsBehavior.ReadOnly = True
        Me.EmpeView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
        Me.EmpeView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
        Me.EmpeView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
        Me.EmpeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub EditDataEmpe(parB As Boolean)
        If parB Then
            Me.EmpeView.OptionsBehavior.ReadOnly = False
            Me.EmpeView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.EmpeView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.EmpeView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            Me.EmpeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Else
            Me.EmpeView.OptionsBehavior.ReadOnly = True
            Me.EmpeView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.EmpeView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.EmpeView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.EmpeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        End If
    End Sub

    Private Sub AddDataEmpe()
        Me.EmpeView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
        Me.EmpeView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
        Me.EmpeView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        Me.EmpeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub EmpeView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EmpeView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.EmpeView
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'BRECORDUPDATEDs = True
                '.SetRowCellValue(e.RowHandle, "FKeyCntry", strID)
                currentRnkFocusRow = Me.RankView.FocusedRowHandle
                alrdyAsk = False
            End With
        End If
    End Sub

    Private Sub EmpeView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EmpeView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EmpeView_GotFocus(sender As Object, e As System.EventArgs) Handles EmpeView.GotFocus
        'ObjFocusedView = Me.EmpeView
        Call changeDeleteCaption(sender, "Remove Employee's Contribution Item")
    End Sub

    Private Sub EmpeView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EmpeView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyWScaleRank"), currentWRankID)
        currentRnkFocusRow = Me.RankView.FocusedRowHandle
        alrdyAsk = False
        'View.SetRowCellValue(e.RowHandle, View.Columns("Amt"), 0)
    End Sub

    Private Sub EmpeView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles EmpeView.InvalidRowException
        'neil 20160524 e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub EmpeView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles EmpeView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            EmpeView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub EmpeView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EmpeView.RowCellStyle
        Call rowcellStyle(EmpeView, e, "FKeyWageAsh")
    End Sub

    Private Sub EmpeView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles EmpeView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EmpeView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles EmpeView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim grdCol As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyWageAsh")
        Dim curr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCurr")
        Dim dType As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateType")
        Dim isvalid As Boolean = True

        'MsgBox(view.GetRowCellValue(e.RowHandle, grdCol))
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If view.GetRowCellValue(e.RowHandle, grdCol) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, grdCol) Is Nothing Then
                isvalid = False
                view.SetColumnError(grdCol, "Please select Wage Item")
                view.FocusedColumn = view.VisibleColumns(0)
            End If

            If view.GetRowCellValue(e.RowHandle, curr) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, curr) Is Nothing Then
                isvalid = False
                view.SetColumnError(curr, "Please select currency")
                view.FocusedColumn = view.VisibleColumns(2)

            End If

            If view.GetRowCellValue(e.RowHandle, dType) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, dType) Is Nothing Then
                isvalid = False
                view.SetColumnError(dType, "Please select Start/End Date type")
                view.FocusedColumn = view.VisibleColumns(3)
            End If
        End If
        e.Valid = isvalid
    End Sub

    Private Sub EmpeView_EditFormShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs) Handles EmpeView.EditFormShowing
        If getCurrentRank() = "" Then
            MsgBox("Please add/save Rank first before entering Pay Items", MsgBoxStyle.Exclamation, GetAppName)
            e.Allow = False
        End If
    End Sub

    Private Sub EmpeView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles EmpeView.ShowingPopupEditForm
        Call showingPopUpForm(e, "Pay Scale Employee Contributions")
    End Sub

    Private Sub EmpeView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles EmpeView.ValidatingEditor
        Call SValidatingEditor(e, EmpeView, "FKeyWageAsh")
    End Sub

    'Private Sub lkuEmpewageash_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles lkuFKeyWageInfo.EditValueChanging
    '    If Not e.NewValue Is System.DBNull.Value Then
    '        If isAlreadySelected(e.NewValue, IfNull(Me.EarnView.GetFocusedRowCellValue("PKey"), ""), EmpeView, "FKeyWageAsh") Then
    '            MsgBox("Item already in the list/selected. Please select other item.", MsgBoxStyle.Information)
    '            e.NewValue = String.Empty
    '        End If
    '    End If
    'End Sub

#End Region

#Region "WS_ASH_EMPR"

    Private Sub subRefreshEmprDtSource()
        Dim dtEmpr As DataTable, colval As String

        If Not IsNothing(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)) Then
            colval = Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey").ToString

            If Not IsDBNull(colval) Then
                currentWRankID = colval 'Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey")
                dtEmpr = DB.CreateTable("SELECT *,CAST(0 as bit) As Edited " &
                                        "FROM tblAdmWScaleAshEmp INNER JOIN tblAdmWageAshEmp ON tblAdmWScaleAshEmp.FKeyWageAshEmp = tblAdmWageAshEmp.PKey " &
                                        "where FKeyWScaleRank='" & currentWRankID & "' ORDER BY tblAdmWageAshEmp.SortCode,tblAdmWageAshEmp.Name")
                Me.GrdEmpr.DataSource = dtEmpr
                ' MsgBox(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey"))
            Else
                Me.GrdEmpr.DataSource = Nothing
            End If
        Else
            Me.GrdEmpr.DataSource = Nothing
        End If
    End Sub


    Private Sub RefreshDataEmpr()
        Me.EmprView.OptionsBehavior.ReadOnly = True
        Me.EmprView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
        Me.EmprView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
        Me.EmprView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
        Me.EmprView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub EditDataEmpr(parB As Boolean)
        If parB Then
            Me.EmprView.OptionsBehavior.ReadOnly = False
            Me.EmprView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.EmprView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.EmprView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            Me.EmprView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Else
            Me.EmprView.OptionsBehavior.ReadOnly = True
            Me.EmprView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.EmprView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.EmprView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.EmprView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        End If
    End Sub

    Private Sub AddDataEmpr()
        Me.EmprView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
        Me.EmprView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
        Me.EmprView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        Me.EmprView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub EmprView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EmprView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.EmprView
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'BRECORDUPDATEDs = True
                '.SetRowCellValue(e.RowHandle, "FKeyCntry", strID)
                currentRnkFocusRow = Me.RankView.FocusedRowHandle
                alrdyAsk = False
            End With
        End If
    End Sub

    Private Sub EmprView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EmprView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EmprView_GotFocus(sender As Object, e As System.EventArgs) Handles EmprView.GotFocus
        'ObjFocusedView = Me.EmprView
        Call changeDeleteCaption(sender, "Remove Employer's Contribution Item")
    End Sub

    Private Sub EmprView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EmprView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyWScaleRank"), currentWRankID)
        currentRnkFocusRow = Me.RankView.FocusedRowHandle
        alrdyAsk = False
        'View.SetRowCellValue(e.RowHandle, View.Columns("Amt"), 0)
    End Sub

    Private Sub EmprView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles EmprView.InvalidRowException
        'neil 20160524 e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub EmprView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles EmprView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            EmprView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub EmprView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EmprView.RowCellStyle
        Call rowcellStyle(EmprView, e, "FKeyWageAshEmp")
    End Sub

    Private Sub EmprView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles EmprView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EmprView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles EmprView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim grdCol As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyWageAshEmp")
        Dim curr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCurr")
        Dim dType As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateType")
        Dim isvalid As Boolean = True

        'MsgBox(view.GetRowCellValue(e.RowHandle, grdCol))
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If view.GetRowCellValue(e.RowHandle, grdCol) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, grdCol) Is Nothing Then
                isvalid = False
                view.SetColumnError(grdCol, "Please select Wage Item")
                view.FocusedColumn = view.VisibleColumns(0)
            End If

            If view.GetRowCellValue(e.RowHandle, curr) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, curr) Is Nothing Then
                isvalid = False
                view.SetColumnError(curr, "Please select currency")
                view.FocusedColumn = view.VisibleColumns(2)
            End If

            If view.GetRowCellValue(e.RowHandle, dType) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, dType) Is Nothing Then
                isvalid = False
                view.SetColumnError(dType, "Please select Start/End Date type")
                view.FocusedColumn = view.VisibleColumns(3)
            End If
        End If
        e.Valid = isvalid
    End Sub

    Private Sub EmprView_EditFormShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs) Handles EmprView.EditFormShowing
        If getCurrentRank() = "" Then
            MsgBox("Please add/save Rank first before entering Pay Items", MsgBoxStyle.Exclamation, GetAppName)
            e.Allow = False
        End If
    End Sub

    Private Sub EmprView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles EmprView.ShowingPopupEditForm
        Call showingPopUpForm(e, "Pay Scale Employer Contributions")
    End Sub

    Private Sub EmprView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles EmprView.ValidatingEditor
        Call SValidatingEditor(e, EmprView, "FKeyWageAshEmp")
    End Sub

    'Private Sub lkuEmprWageAshEmp_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles lkuFKeyWageInfo.EditValueChanging
    '    If Not e.NewValue Is Nothing Then
    '        If isAlreadySelected(e.NewValue, IfNull(Me.EmprView.GetFocusedRowCellValue("PKey"), ""), EmprView, "FKeyWageAshEmp") Then
    '            MsgBox("Item already in the list/selected. Please select other item.", MsgBoxStyle.Information)
    '            e.NewValue = String.Empty
    '        End If
    '    End If
    'End Sub

#End Region


    Sub RefreshAllSubTab(Optional Allba As Boolean = False)
        If Allba Then
            Call subRefreshEarnDtSource()
            Call subRefreshDedDtSource()
            Call subRefreshInfoDtSource()
            Call subRefreshEmpeDtSource()
            Call subRefreshEmprDtSource()
        Else
            Select Case Me.TabOnb.SelectedTabPageIndex
                Case 0
                    Call subRefreshEarnDtSource()
                Case 1
                    Call subRefreshDedDtSource()
                Case 2
                    Call subRefreshInfoDtSource()
            End Select

            Select Case Me.TabAsh.SelectedTabPageIndex
                Case 0
                    Call subRefreshEmpeDtSource()
                Case 1
                    Call subRefreshEmprDtSource()
            End Select
        End If

    End Sub

    Private Function getCurrentRank() As String
        Dim colval As String
        If Not IsNothing(Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)) Then
            colval = Me.RankView.GetDataRow(Me.RankView.FocusedRowHandle)("PKey").ToString
        Else
            colval = ""
        End If

        Return colval
    End Function

    Private Sub TabAsh_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabAsh.SelectedPageChanged
        If Not isEditing Then
            Select Case Me.TabAsh.SelectedTabPageIndex
                Case 0
                    Call subRefreshEmpeDtSource()
                Case 1
                    Call subRefreshEmprDtSource()
            End Select
        End If
    End Sub

    Private Function NotSaveYet(gview As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim ret As Boolean = False
        For i As Integer = 0 To gview.DataRowCount - 1
            If gview.GetRowCellValue(i, "PKey") Is System.DBNull.Value Or gview.GetRowCellValue(i, "Edited") = True Then
                ret = True
                Exit For
            End If
        Next
        Return ret
    End Function

    Public Function IfValNull(ByVal x As Object, ByVal trueval As String, falseval As String) As String
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return falseval
        Else
            Return trueval
        End If
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Function isAlreadySelected(valtocheck As Object, sPKey As String, gview As DevExpress.XtraGrid.Views.Grid.GridView, colname As String) As Boolean
        Dim tempret As Boolean, cnt As Integer

        For i As Integer = 0 To gview.DataRowCount - 1
            If gview.GetRowCellValue(i, colname) = valtocheck And gview.GetRowCellValue(i, "PKey") <> sPKey Then
                cnt = cnt + 1
                tempret = True
                Exit For
            End If
            'If cnt = 2 Then
            '    tempret = True
            '    Exit For
            'End If
        Next
        Return tempret
    End Function

    Sub showingPopUpForm(e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs, editFormTxt As String)
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = editFormTxt
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

    Sub rowcellStyle(gview As DevExpress.XtraGrid.Views.Grid.GridView, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs, _
                      Optional strRequiredFieldName As String = "")
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        'Dim strRequiredFieldName As String = ""
        'strRequiredFieldName = "FKeyCourse;CourseStatus;DateIssue;"
        With gview
            If InStr(1, strRequiredFieldName, e.Column.FieldName) > 0 Then
                e.Appearance.BackColor = REQUIRED_COLOR
                If .GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
                    e.Appearance.BackColor = SEL_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") And .FocusedRowHandle = e.RowHandle Then
                    e.Appearance.BackColor = EDITED_FOCUSED_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") Then
                    e.Appearance.BackColor = EDITED_COLOR
                ElseIf e.RowHandle = .FocusedRowHandle Then
                    e.Appearance.BackColor = SEL_COLOR
                End If
            ElseIf .IsRowSelected(e.RowHandle) Then
                e.Appearance.BackColor = SEL_COLOR
                e.Appearance.ForeColor = System.Drawing.Color.Black
            End If
        End With

    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel, GetAppName)
        If res = MsgBoxResult.Yes Then
            If RankView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboFKeyCurr, cboRateType, cboFKeyWScalCalendar}, showMsg) Then
                    If bAddMode Then
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
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
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
            isEditing = False
        End If
        Return flag
    End Function

    Sub SValidatingEditor(e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs, views As DevExpress.XtraGrid.Views.Grid.GridView, _
                          strRequiredFieldName As String)
        'Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'check for duplicate within the gridview
        With views
            'Dim strRequiredFieldName As String = "FKeyWageOnb"
            If InStr(1, strRequiredFieldName, .FocusedColumn.FieldName) > 0 Then
                For i = 0 To .DataRowCount - 1
                    If i <> .FocusedRowHandle Then
                        If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
                            e.Valid = False
                            e.ErrorText = "Already in use"
                        End If
                    End If

                Next
            End If

        End With
    End Sub

    Private Sub chkActive_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkActive.CheckedChanged
        '   MsgBox(Me.chkActive.Checked)
    End Sub

    Private Sub chkActive_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkActive.CheckStateChanged
        'MsgBox(Me.chkActive.Checked)
    End Sub

    Private Sub chkActive_Click(sender As Object, e As System.EventArgs) Handles chkActive.Click
        Debug.Print(Me.chkActive.Checked)
    End Sub

    Private Sub DedView_LostFocus(sender As Object, e As System.EventArgs) Handles DedView.LostFocus

    End Sub

    Private Sub DedView_StartGrouping(sender As Object, e As System.EventArgs) Handles DedView.StartGrouping

    End Sub

    Sub manualValidateEditor()
        'neil 20160524

        For Each column As DevExpress.XtraGrid.Columns.GridColumn In RankView.Columns
            RankView.FocusedColumn = column
            RankView.ValidateEditor()
        Next

        For Each column As DevExpress.XtraGrid.Columns.GridColumn In EarnView.Columns
            EarnView.FocusedColumn = column
            EarnView.ValidateEditor()
        Next

        For Each column As DevExpress.XtraGrid.Columns.GridColumn In DedView.Columns
            DedView.FocusedColumn = column
            DedView.ValidateEditor()
        Next

        For Each column As DevExpress.XtraGrid.Columns.GridColumn In EmpeView.Columns
            EmpeView.FocusedColumn = column
            EmpeView.ValidateEditor()
        Next

        For Each column As DevExpress.XtraGrid.Columns.GridColumn In EmprView.Columns
            EmprView.FocusedColumn = column
            EmprView.ValidateEditor()
        Next

        RankView.UpdateCurrentRow()
        EarnView.UpdateCurrentRow()
        DedView.UpdateCurrentRow()
        EmpeView.UpdateCurrentRow()
        EmprView.UpdateCurrentRow()
        'end
    End Sub

    Sub changeDeleteCaption(sender As Object, delcaption As String)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            ObjFocusedView = view
            SetDeleteCaption(Name, delcaption)
        Else
            ObjFocusedView = Nothing
            SetDeleteCaption(Name, "Delete Wage Scale")
        End If
    End Sub


    Private Sub cboFKeyCurr_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyCurr.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboFKeyWScalCalendar_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyWScalCalendar.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboRateType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRateType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub txtDateAct_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDateAct.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub txtDateInact_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDateInact.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuFKeyRank_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuFKeyRank.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuFKeyWageOnb_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuFKeyWageOnb.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuEarFKeyCurr_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuEarFKeyCurr.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuEarDateType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuEarDateType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuFKeyWageDed_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuFKeyWageDed.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuDedFKeyCurr_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuDedFKeyCurr.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuDedDateType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuDedDateType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuFKeyWageInfo_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuFKeyWageInfo.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuInfoDen_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuInfoDen.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuInfoPrd_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuInfoPrd.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuInfoDateType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuInfoDateType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuEmpeWageAsh_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuEmpeWageAsh.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuEmpeCurr_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuEmpeCurr.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuEmpeDateType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuEmpeDateType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuEmprWageAshEmp_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuEmprWageAshEmp.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuEmprDateType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuEmprDateType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuEmprCurr_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuEmprCurr.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuFKeyWageOnb_EditValueChanged(sender As Object, e As System.EventArgs) Handles lkuFKeyWageOnb.EditValueChanged
       
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        Dim value As Object = row("prorata")
        Dim value2 As Object = row("accum")
        'MsgBox(value)
        'MsgBox(value2)
        Me.EarnView.SetFocusedRowCellValue("Prorata", value)
        Me.EarnView.SetFocusedRowCellValue("Accum", value2)
       
    End Sub


    Private Sub lkuFKeyWageDed_EditValueChanged(sender As Object, e As System.EventArgs) Handles lkuFKeyWageDed.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        Dim value As Object = row("prorata")
        Dim value2 As Object = row("accum")
        'MsgBox(value)
        'MsgBox(value2)
        Me.DedView.SetFocusedRowCellValue("Prorata", value)
        Me.DedView.SetFocusedRowCellValue("Accum", value2)
    End Sub


#Region "Copy Wage Scale Rank"

    Private Sub cmdCopyRank_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopyRank.Click
        Dim info As Boolean = False
        If MsgBox("Are you sure you want to copy Rank '" & RankView.GetFocusedRowCellDisplayText("FKeyRank") & "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then
            info = CopyWageScaleRank(RankView.GetFocusedRowCellValue("PKey"))
            If info Then
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
            Else
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
            End If
            RefreshData()
        End If
    End Sub

    Private Function CopyWageScaleRank(WageScaleRankCode As String) As Boolean
        Dim retVal As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandText = "SP_Adm_CopyWScaleRank"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@FKeyWScale", strID)
                    .AddWithValue("@FKeyWScaleRank", WageScaleRankCode)
                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                End With
                retVal = (cmd.ExecuteNonQuery > 0)
            End Using
            If retVal Then
                sqlTran.Commit()
            End If
        Catch ex As Exception
            retVal = False
            sqlTran.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return retVal
    End Function


#End Region

    Private Sub cmdUpdatePayScale_Click(sender As System.Object, e As System.EventArgs) Handles cmdUpdatePayScale.Click
        Dim frmUpdatePS As New frmUpdatePayScale(strID)
        frmUpdatePS.ShowDialog(Me)
        blList.SetSelection(frmUpdatePS.cboFromPayScale.EditValue)
    End Sub

    Private Sub InfoView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles InfoView.ShowingEditor
        'Added by Calvhin 20170208
        With InfoView
            If .FocusedColumn.FieldName = "Den" Or .FocusedColumn.FieldName = "Prd" Or .FocusedColumn.FieldName = "DateType" Then
                If .GetFocusedRowCellValue("FKeyWageInfo") = "SYSPAYLD" Then
                    e.Cancel = True
                End If
            End If
        End With
        'End Calvhin
    End Sub

    Private Sub EnableSubButtons(_value As Boolean)
        cmdCopyRank.Enabled = _value
        cmdUpdatePayScale.Enabled = _value
    End Sub
End Class
