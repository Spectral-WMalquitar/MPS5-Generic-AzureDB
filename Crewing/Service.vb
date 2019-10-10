Imports DevExpress.XtraEditors

Public Class Service

    Dim PrevTab As String = ""
    Dim tabChanged As Boolean = False
    'Dim LastUpdatedBy As String = GetUserName()
    Dim FormName As String = "Crew Service" 'neil
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Dim tblAdmStat As New DataTable

    Dim clsgridflout As New clsGridFlyOut

    Private Sub initControls()
        'temporary_OtherSeav()
        Me.LayoutControl1.AllowCustomization = False
        Me.TabControl.SelectedTabPageIndex = 0
        'Other SeaServ
        tblAdmStat = DB.CreateTable("SELECT Name,PKey,StatType FROM dbo.tblAdmStat WHERE StatType<>2 ORDER BY Name")
        repOthSOFFStat.DataSource = DB.CreateTable("SELECT PKey, Name,StatType FROM dbo.tblAdmStat WHERE StatType=2")
        repVslType.DataSource = DB.CreateTable("SELECT Name FROM dbo.tblAdmVslType ORDER BY Name")
        repStatName.DataSource = tblAdmStat
        repOthRankName.DataSource = DB.CreateTable("SELECT Name FROM dbo.tblAdmRank ORDER BY SortCode,Name")
        repOthPort.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmPort ORDER BY Name")
        repVslTypeName.DataSource = DB.CreateTable("SELECT Name FROM dbo.tblAdmVslType ORDER BY Name")

        'edited by: tony20160229; Apply user-data filtering
        'unfiltered: Me.repVsl.DataSource = DB.CreateTable("SELECT Name FROM dbo.tblAdmVsl UNION SELECT Vessel as Name FROM Crewlist_Activities_Other ORDER BY Name ASC")
        Dim userdatafilterstring As String = GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt")

        Me.SearepStat.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmStat ORDER BY Name,SortCode ASC")

        clsAudit.propSQLConnStr = DB.GetConnectionString
    End Sub

    Private Sub LoadSub()
        Dim userdatafilterstring As String = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
        Select Case TabControl.SelectedTabPage.Tag
            Case "SeaAct"
                SetEditOptionsVisibility(Name, False)
                Me.SeaServGrid.DataSource = DB.CreateTable("SELECT caa.*,ws.WageScale as WScaleRankName,CAST(0 AS BIT) AS Edited FROM [Crewlist_Activities_All] caa LEFT JOIN dbo.WAGESCALE ws ON caa.FKeyWScaleRankCode = ws.WScaleRankCode  WHERE  IDNbr='" & strID & "' AND ActivityType='SEA' " & _
                                                           "ORDER BY DateStarted DESC")
                'IIf(userdatafilterstring.Length > 0, "AND " & userdatafilterstring & " ", "") & _
                SetActivityDocsRpgVisibility(Name, True)
            Case "AshAct"
                SetEditOptionsVisibility(Name, False)
                Me.AshGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM Crewlist_Activities_All WHERE  IDNbr='" & strID & "' AND ActivityType='ASHORE' " & _
                                                       "ORDER BY DateStarted DESC")
                'IIf(userdatafilterstring.Length > 0, "AND " & userdatafilterstring & " ", "") & _
                SetActivityDocsRpgVisibility(Name, True)
            Case "OthAct1"
                'other sea service
                SetEditOptionsVisibility(Name, True)
                Me.OtherGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 as BIT) AS Edited,CAST('' as VARCHAR(30)) AS ActivityType FROM Crewlist_Activities_Other WHERE IDNbr='" & strID & "' ORDER BY ActDateStart DESC")
                'Me.OthSeaGrid.DataSource = DB.CreateTable("SELECT * ,CAST(0 AS BIT) AS Edited FROM [dbo].[Crew_ActivityList_Complete] WHERE IDNbr='" & strID & "' ORDER BY ActDateStart ASC")
                SetActivityDocsRpgVisibility(Name, True)
            Case "ServSum"
                SetEditOptionsVisibility(Name, False)
                SetActivityDocsRpgVisibility(Name, False)
                loadServSum()
            Case "CrewLeaveDay"
                'Added By Calvhin 20170213
                SetEditOptionsVisibility(Name, False)
                SetActivityDocsRpgVisibility(Name, False)
                Dim dt As DataTable = DB.CreateTable("SELECT * FROM [frmLeaveDays_Datasource] WHERE IDNbr = '" & strID & "' ORDER BY ActDateStart DESC")
                LDGrid.DataSource = dt
                If dt.Rows.Count > 0 Then
                    txtTotalDays.EditValue = dt.Compute("SUM(LDEarn)", "")
                    txtTotalPay.EditValue = dt.Compute("SUM(LPEarn)", "")
                    txtConsumedDays.EditValue = dt.Compute("SUM(LDConsumed)", "")
                    txtConsumedPay.EditValue = dt.Compute("SUM(LPConsumed)", "")
                    txtRemainingDays.EditValue = (txtTotalDays.EditValue - txtConsumedDays.EditValue)
                    txtRemainingPay.EditValue = (txtTotalPay.EditValue - txtConsumedPay.EditValue)
                End If
                'End Calvhin
            Case Else
                SetActivityDocsVisibility(Name, False)
        End Select
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        SetEditCaption(Name, "Add/Edit")
        SetEditOptionsVisibility(Name, True)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPrintListCaption(Name, "Print Biodata")
        SetPrintBiodataVisiblity(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        setSelectedView()
        If Not bLoaded Then 'Prevent lookup edit to reload data source 
            initControls()
            LoadSub()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            'AddData()
        Else
            LoadSub()
            'EditSubAllowGrid(Me.OtherView, False) 'other SEAServ(original)
            EditSubAllowGrid(Me.OtherView, False) 'other SEAServ
            EditSubAllowGrid(Me.SeaServView, False)
            EditSubAllowGrid(Me.AshView, False)
            header.Text = "Activity History - " & blList.GetDesc 'ADded by Calvhin 20170213
            BRECORDUPDATEDs = False
        End If
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        header.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, True)
            EditSubAllowGrid(Me.OtherView, isEditdable) 'original
            'EditSubAllowGrid(Me.OthSeaView, True)
            'EditSubAllowGrid(Me.SeaServView, True)
            'EditSubAllowGrid(Me.AshView, True)
        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            EditSubAllowGrid(Me.OtherView, isEditdable) 'original
            'EditSubAllowGrid(Me.OthSeaView, False)
            'EditSubAllowGrid(Me.SeaServView, False)
            'EditSubAllowGrid(Me.AshView, False)
            AllowDeletion(Name, False)
        End If
    End Sub

    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {}) Then

            Select Case IIf(tabChanged, PrevTab, Me.TabControl.SelectedTabPage.Tag)
                Case "OthAct1" 'Other Activity
                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "<TO_REPLACE>", FormName, strID) 'neil  'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Other Sea Service", 0, System.Environment.MachineName, "<TO_REPLACE>", FormName, strID)
                    'info = SaveCrewOtherService(strID, OtherView, LastUpdatedBy)
                    info = SaveOtherService()
            End Select
            tabChanged = False
            BRECORDUPDATEDs = False
            blList.RefreshData()
            If info Then
                blList.SetSelection(strID)
                RefreshData()
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
            Else
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName())
            End If
        End If
    End Sub



    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If OthSeaView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
                'Else
                '    If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, showMsg) Then
                '        If bAddMode Then
                '            'If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                '            '    flag = False
                '            '    ALLOWNEXTS = flag
                '            'Else
                '            flag = True
                '            ALLOWNEXTS = flag
                '            SaveData() '
                '            'End If
                '        Else
                '            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & strID & "'") Then
                '                flag = False
                '                ALLOWNEXTS = flag
            Else
                flag = True
                ALLOWNEXTS = flag
                SaveData() '
            End If
            '        End If
            '    Else
            '        flag = False
            '        ALLOWNEXTS = flag
            '    End If
            'End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Overrides Sub DeleteData()
        Dim subDesc As String = ""
        Dim info As Boolean = False

        With Me.OtherView
            subDesc = .GetRowCellDisplayText(.FocusedRowHandle, "VslName")
            Dim _CurrActId As String = IfNull(.GetRowCellValue(.FocusedRowHandle, "ActID"), "")
            Dim _GroupActID As String = IfNull(.GetRowCellValue(.FocusedRowHandle, "ActGroupID"), "")
            If MsgBox("Are you sure want to delete the '" & subDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                If Not _GroupActID.Equals("") Then

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil	'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Other Sea Service", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil
                    clsAudit.saveAuditPreDelDetails("tblActivity", _CurrActId, LastUpdatedBy) 'neil


                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletionActGrp As New LogDeletion
                    oLogDeletionActGrp.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblActivityGroup", _
                        "PKey IN ('" & _GroupActID & "')", _
                        "<< Delete Crew Data - " & FormName & " - Other Sea Service >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & "- Other Sea Service>", _
                        GetUserName())
                    '-->

                    info = DB.RunSql("DELETE FROM dbo.tblActivityGroup WHERE PKey='" & _GroupActID & "' AND FKeyIDNbr ='" & strID & "'")
                    If info Then
                        oLogDeletionActGrp.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If


                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletionAct As New LogDeletion
                    oLogDeletionAct.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblActivity", _
                        "FKeyActivityGroupID IN ('" & _GroupActID & "')", _
                        "<< Delete Crew Data - " & FormName & " - Other Sea Service >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & "- Other Sea Service>", _
                        GetUserName())
                    '-->
                    info = DB.RunSql("DELETE FROM dbo.tblActivity WHERE FKeyActivityGroupID= '" & _GroupActID & "' AND PKey='" & _CurrActId & "'")
                    If info Then
                        oLogDeletionAct.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                End If
                .DeleteRow(.FocusedRowHandle)
                If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
            End If
        End With

    End Sub

    Private Sub TabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabControl.SelectedPageChanged
        PrevTab = Me.TabControl.SelectedTabPage.Tag
        LoadSub()
        Call setSelectedView()
    End Sub

    Private Sub TabControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangingEventArgs) Handles TabControl.SelectedPageChanging
        If BRECORDUPDATEDs Then
            'If MsgBox("Would you like to save the changes you made on " & GetDesc() & "?", MsgBoxStyle.YesNo, strCaption) = MsgBoxResult.Yes Then
            '    tabChanged = True
            '    SaveData()
            'Else
            '    RefreshData()
            'End If

            Dim msgans As Integer
            msgans = MsgBox("Would you like to save the changes you made on " & GetDesc() & "?", MsgBoxStyle.YesNoCancel, strCaption)
            'If MsgBox("Would you like to save the changes you made on " & e.PrevPage.Text & "?", MsgBoxStyle.YesNoCancel, strCaption) = MsgBoxResult.Yes Then
            If msgans = MsgBoxResult.Yes Then
                tabChanged = True
                SaveData()
            ElseIf msgans = MsgBoxResult.No Then
                RefreshData()
                'ElseIf MsgBoxResult.Cancel Then
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#Region "Sea Activity"

    Private Sub SeaServView_GotFocus(sender As Object, e As System.EventArgs) Handles SeaServView.GotFocus
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        focusedView = SeaServView
    End Sub

    Private Sub SeaServView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles SeaServView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.SeaServView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub SeaServView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles SeaServView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
        With view
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
#End Region

#Region "Ashore Activity"

    Private Sub AshView_GotFocus(sender As Object, e As System.EventArgs) Handles AshView.GotFocus
        focusedView = AshView
    End Sub
    Private Sub AshView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AshView.RowCellStyle, LDView.RowCellStyle 'LDView.RowCellStyle  Added By calvhin 20170213
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
        With view
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
#End Region

#Region "Other Activity"
    'Private Function SaveOther(_id As String) As ArrayList
    '    Dim query As New ArrayList
    '    'With Me.OthSeaView'Temp
    '    With Me.OtherView
    '        .CloseEditForm()
    '        .UpdateCurrentRow()
    '        For i As Integer = 0 To .RowCount - 1
    '            If .GetRowCellValue(i, "Edited") Then
    '                Dim _CurrActId As String = IfNull(.GetRowCellValue(i, "ActID"), "")
    '                Dim _GroupActID As String = IfNull(.GetRowCellValue(i, "ActGrpID"), "")
    '                'Dim _ActivityType As String = IfNull(.GetRowCellValue(i, "ActivityType"), "")
    '                Dim _DateEnded As Date = .GetRowCellValue(i, "DateEnded")
    '                'Dim _DateArr As String = IfNull(.GetRowCellValue(i, "DateArr"), "")
    '                Dim _PlaceDep As String = IfNull(.GetRowCellValue(i, "PlaceDep"), "")
    '                'Dim _PlaceArr As String = IfNull(.GetRowCellValue(i, "PlaceArr"), "")
    '                Dim _LOC As Integer = IfNull(.GetRowCellValue(i, "LOC"), "0")
    '                ''Dim _FKeyVslCode As String = IfNull(.GetRowCellValue(i, "FKeyVslCode"), .GetRowCellDisplayText(i, "FKeyVslCode"))
    '                'Dim _VslName As String = IfNull(.GetRowCellValue(i, "VslName"), .GetRowCellDisplayText(i, "VslName"))
    '                'Dim _FKeyAgentCode As String = IfNull(.GetRowCellValue(i, "FKeyAgentCode"), .GetRowCellDisplayText(i, "FKeyAgentCode"))
    '                'Dim _FKeySatCode As String = IfNull(.GetRowCellValue(i, "FKeyStatCode"), .GetRowCellDisplayText(i, "FKeyStatCode"))
    '                Dim _DateSOn As Date = .GetRowCellValue(i, "DateSOn")
    '                'Dim _DateSOFF As String = IfNull(.GetRowCellValue(i, "DateSOff"), "")
    '                Dim _PlaceSOn As String = IfNull(.GetRowCellValue(i, "PlaceSOn"), "")
    '                'Dim _PlaceSOFF As String = IfNull(.GetRowCellValue(i, "PlaceSOff"), "")
    '                ''Dim _FKeyWSRankCode As String = IfNull(.GetRowCellValue(i, "FKeyWScaleRankCode"), IfNull(.GetRowCellDisplayText(i, "FKeyWScaleRankCode"), "NULL"))
    '                'Dim _FKeyWSRankCode As String = "NULL"
    '                'Dim _RelievedID As String = IfNull(.GetRowCellValue(i, "Remarks"), "")
    '                Dim _Remarks As String = IfNull(.GetRowCellValue(i, "RelievedID"), "")
    '                'Dim _LOCDays As Integer = IfNull(.GetRowCellValue(i, "LOCDays"), 0)
    '                'Dim _FKeyRankCode As String = IfNull(.GetRowCellValue(i, "FKeyRankCode"), .GetRowCellDisplayText(i, "FKeyRankCode"))
    '                'Dim _IsCompServ As String = IfNull(.GetRowCellValue(i, "IsCompServ"), "0")
    '                'Dim _FKeyPrinCode As String = IfNull(.GetRowCellValue(i, "FKeyPrinCode"), .GetRowCellDisplayText(i, "FKeyPrinCode"))
    '                'Dim _FKeyFltMgr As String = IfNull(.GetRowCellValue(i, "FKeyFltMgrCode"), .GetRowCellDisplayText(i, "FKeyFltMgrCode"))
    '                ''For Original
    '                Dim _VesselName As String = IfNull(.GetRowCellDisplayText(i, "Vessel"), "")
    '                Dim _StatName As String = IfNull(.GetRowCellDisplayText(i, "Status"), "")
    '                Dim _Rank As String = IfNull(.GetRowCellDisplayText(i, "Rank"), "")
    '                '==================
    '                If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
    '                    'old
    '                    query.Add(SaveOtherActivity(_id, _GroupActID, _CurrActId, _VesselName, _Rank, _StatName, _DateEnded, _PlaceDep, _LOC, _DateSOn, _PlaceSOn, _Remarks))
    '                    ' TEMP = query.Add(AmendActivity(_id,
    '                    '                        _GroupActID,
    '                    '                        _CurrActId,
    '                    '                        _ActivityType,
    '                    '                        DateDep,
    '                    '                        _DateArr,
    '                    '                        _PlaceDep,
    '                    '                        _PlaceArr,
    '                    '                        _LOC,
    '                    '                        _VslName,
    '                    '                        _FKeyAgentCode,
    '                    '                        _FKeySatCode,
    '                    '                        _DateSOn,
    '                    '                        _DateSOFF,
    '                    '                        _PlaceSOn,
    '                    '                        _PlaceSOFF,
    '                    '                        _FKeyWSRankCode,
    '                    '                        _RelievedID,
    '                    '                        _Remarks,
    '                    '                        LastUpdatedBy,
    '                    '                        _LOCDays,
    '                    '                        _FKeyRankCode,
    '                    '                        _IsCompServ,
    '                    '                        _FKeyPrinCode,
    '                    '                        _FKeyFltMgr))
    '                Else
    '                    'old
    '                    query.Add(SaveOtherActivity(_id, _GroupActID, _CurrActId, _VesselName, _Rank, _StatName, _DateEnded, _PlaceDep, _LOC, _DateSOn, _PlaceSOn, _Remarks))
    '                    ' TEMP = query.Add(AmendActivity(_id,
    '                    '     _GroupActID,
    '                    '     _CurrActId,
    '                    '     _ActivityType,
    '                    '     DateDep,
    '                    '     _DateArr,
    '                    '     _PlaceDep,
    '                    '     _PlaceArr,
    '                    '     _LOC,
    '                    '     _VslName,
    '                    '     _FKeyAgentCode,
    '                    '     _FKeySatCode,
    '                    '     _DateSOn,
    '                    '     _DateSOFF,
    '                    '     _PlaceSOn,
    '                    '     _PlaceSOFF,
    '                    '     _FKeyWSRankCode,
    '                    '     _RelievedID,
    '                    '     _Remarks,
    '                    '     LastUpdatedBy,
    '                    '     _LOCDays,
    '                    '     _FKeyRankCode,
    '                    '     _IsCompServ,
    '                    '     _FKeyPrinCode,
    '                    '     _FKeyFltMgr))
    '                End If
    '            End If
    '        Next
    '    End With
    '    Return query
    'End Function

    ''ProcessType: TRUE = Update  ; FALSE = Insert
    'Private Function SaveOtherActivity(_IDNbr As String, _GroupActID As String, _CurrActID As String, _VesselName As String, _Rank As String,
    '                                   _StatName As String, _DateEnded As Date, _PlaceDep As String, _LOC As Integer, _DateSOn As Date, _PlaceSOn As String, _Remarks As String) As String
    '    Return "EXEC [dbo].[SP_OTHER_ACTIVITY] '" & _IDNbr & "','" & _GroupActID & "','" & _CurrActID & "','" & _VesselName & "','" & _Rank & "'," & _
    '        "'" & _StatName & "'," & ChangeToSQLDate(_DateEnded) & ",'" & _PlaceDep & "','" & _LOC & "'," & ChangeToSQLDate(_DateSOn) & ",'" & _PlaceSOn & "','" & _Remarks.Replace("'", "''") & "','" & LastUpdatedBy & "'"
    'End Function

    Private Sub SaveCrewOtherActivity(id As String)
        SaveCrewOtherService(id, OtherView)
    End Sub

    Private Sub OtherView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles OtherView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.OtherView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub OtherView_GotFocus(sender As Object, e As System.EventArgs) Handles OtherView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            ' focusedView = view
            SetDeleteCaption(Name, "Delete Other Service")
            'Else
            '    focusedView = Nothing
            '    SetDeleteCaption(Name, "Delete Crew")
        End If
        focusedView = view
    End Sub

    Private Sub OtherView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles OtherView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "IDNbr", strID) 'Crew ID
        SubAddMode = True
    End Sub

    Private Sub OtherView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles OtherView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub OtherView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles OtherView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.OtherView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub OtherView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles OtherView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ViewRowCellStyle(sender, e, "")

    End Sub

    Private Sub OtherView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles OtherView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub OtherView_ShownEditor(sender As Object, e As System.EventArgs) Handles OtherView.ShownEditor
        SetMinMaxDateValidation(sender, e, "DateSOn", "DateSOff")
        SetMinMaxDateValidation(sender, e, "ActDateStart", "ActDateEnd")
        stopnaba = True
    End Sub

    Private Sub OtherView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles OtherView.ValidateRow
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim DateEnd As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateEnded")
        'Dim DateStart As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateStarted")
        'With view
        '    If .GetRowCellValue(e.RowHandle, DateEnd) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, DateEnd) Is Nothing Then
        '        .SetColumnError(DateEnd, "Please Enter Date Ended.")
        '        e.Valid = False
        '    Else
        '        If .GetRowCellValue(e.RowHandle, DateEnd).Equals("") Then
        '            .SetColumnError(DateEnd, "Please Enter Date Ended.")
        '            e.Valid = False
        '        Else
        '            .SetColumnError(DateEnd, "")
        '        End If
        '    End If

        '    'Date Start
        '    If .GetRowCellValue(e.RowHandle, DateStart) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, DateStart) Is Nothing Then
        '        .SetColumnError(DateStart, "Please Enter Date Start.")
        '        e.Valid = False
        '    Else
        '        If .GetRowCellValue(e.RowHandle, DateStart).Equals("") Then
        '            .SetColumnError(DateStart, "Please Enter Date Start.")
        '            e.Valid = False
        '        Else
        '            .SetColumnError(DateStart, "")
        '        End If
        '    End If

        '    'clear errors
        '    If Not .HasColumnErrors Then
        '        e.Valid = True
        '        .ClearColumnErrors()
        '    Else
        '        BRECORDUPDATEDs = True
        '    End If
        'End With
    End Sub


    Private Sub OtherView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles OtherView.ValidatingEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName.Equals("StatName") Then
            view.SetRowCellValue(view.FocusedRowHandle, "ActivityType", GetActivityType(e.Value))
            view.SetFocusedValue(e.Value)
        End If

    End Sub
#End Region

#Region "Service Summary"

    Private Sub loadServSum()
        Dim crewServSum_Rank As New DataTable
        Dim crewServSum_Type As New DataTable
        Dim cSQL As String
        Me.txtDays.Text = MPSDB.GetConfig("DAYS_IN_MONTH")

        'LOAD SERVICE SUMMARY BY RANK
        cSQL = " SELECT * FROM frmCrew_ServSumRank WHERE IDNbr = '" & blList.GetID() & "'"
        crewServSum_Rank = MPSDB.CreateTable(cSQL)
        ServSumRankGrid.DataSource = crewServSum_Rank
        With ServSumRankView
            .BeginSort()
            Try
                .ClearSorting()
                .Columns("RankSort").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Finally
                .EndSort()
            End Try
        End With

        'LOAD SERVICE SUMMARY BY TYPE
        cSQL = " SELECT * FROM frmCrew_ServSumType WHERE IDNbr = '" & blList.GetID() & "'"
        crewServSum_Type = MPSDB.CreateTable(cSQL)
        ServSumGrpGrid.DataSource = crewServSum_Type
        With ServSumGrpView
            .BeginSort()
            Try
                .ClearSorting()
                .Columns("SortNo").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Finally
                .EndSort()
            End Try
        End With


    End Sub

#End Region

    Private Function AmendActivity(_IDNbr As String, _GroupID As String, _CurActID As String, _ActivityType As String, _DateDep As String,
                                   _DateArr As String, _PlaceDep As String, _PlaceArr As String, _LOC As Integer, _FKeyVslCode As String,
                                   _FKeyAgentCode As String, _FKeyStatCode As String, _DateSOn As String, _DateSOFF As String,
                                   _PlaceSOn As String, _PlaceSOFF As String, _FKeyWScaleRankCode As String, _RelievedID As String,
                                   _Remarks As String, _LastUpdatedBy As String, _LOCDAYS As Integer,
                                   _FKeyRankCode As String, _IsCompServ As String, _FKeyPrinCode As String,
                                   _FKeyFltMgrCode As String) As String
        Dim retval As String = ""
        retval = "EXEC [dbo].[SP_AMENDACT] " & _
                "'" & _IDNbr & "'," & _
                "'" & _GroupID & "'," & _
                "'" & _CurActID & "'," & _
                "'" & _ActivityType & "'," & _
                "" & ChangeToSQLDate(_DateDep) & "," & _
                "" & ChangeToSQLDate(_DateArr) & "," & _
                "'" & CleanInput(_PlaceDep) & "'," & _
                "'" & CleanInput(_PlaceArr) & "'," & _
                "'" & CleanInput(_LOC) & "'," & _
                "'" & CleanInput(_FKeyVslCode) & "'," & _
                "'" & CleanInput(_FKeyAgentCode) & "'," & _
                "'" & CleanInput(_FKeyStatCode) & "'," & _
                "" & ChangeToSQLDate(_DateSOn) & "," & _
                "" & ChangeToSQLDate(_DateSOFF) & "," & _
                "'" & CleanInput(_PlaceSOn) & "'," & _
                "'" & CleanInput(_PlaceSOFF) & "'," & _
                "" & CleanInput(_FKeyWScaleRankCode) & "," & _
                "'" & CleanInput(_RelievedID) & "'," & _
                "'" & CleanInput(_Remarks) & "'," & _
                "'" & (_LastUpdatedBy) & "'," & _
                "" & _LOCDAYS & "," & _
                "'" & CleanInput(_FKeyRankCode) & "'," & _
                "'" & _IsCompServ & "'," & _
                "'" & CleanInput(_FKeyPrinCode) & "'," & _
                "'" & CleanInput(_FKeyFltMgrCode) & "'"
        Return retval
    End Function

    Private Sub OthSeaView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles OthSeaView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.OthSeaView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub OthSeaView_GotFocus(sender As Object, e As System.EventArgs) Handles OthSeaView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Other Service")
            'Else
            '    focusedView = Nothing
            '    SetDeleteCaption(Name, "Delete Crew")
        End If
    End Sub

    Private Sub OthSeaView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles OthSeaView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        SubAddMode = True
    End Sub

    Private Sub OthSeaView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles OthSeaView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub OthSeaView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles OthSeaView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.OthSeaView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub OthSeaView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles OthSeaView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ViewRowCellStyle(sender, e, "")
    End Sub

    Private Sub OthSeaView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles OthSeaView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    ''Temporary Code
    'Private Sub temporary_OtherSeav()

    '    'edited by: tony20160229; Apply user-data filtering
    '    repSignOffStat.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmStat WHERE StatType=2 ORDER BY Name,SortCode ASC")
    '    'repVslCode.DataSource = DB.CreateTable("SELECT PKey,Name,Abbrv FROM dbo.tblAdmVsl ORDER BY Name ASC") 'original
    '    'unfiltered: repVslName.DataSource = DB.CreateTable("SELECT * FROM dbo.VslList_Act ORDER BY Name ASC")
    '    repVslName.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.VesselActOnly)
    '    repVslType.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslType ORDER BY Name ASC")
    '    'unfiltered: repPrinCode.DataSource = DB.CreateTable("SELECT PKey, Name FROM dbo.PrincipalList ORDER BY Name ASC")
    '    repPrinCode.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Principal)
    '    'unfiltered: repAgentCode.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.ManAgentList ORDER BY Name ASC"
    '    repAgentCode.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Agent)
    '    repFltMgr.DataSource = DB.CreateTable("SELECT PKey, Name FROM dbo.MgrFltList ORDER BY Name ASC")
    '    repFKeyRank.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRank ORDER BY Name")
    '    repFKeyPort.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmPort ORDER BY Name")
    '    repActType.DataSource = getActivityType()
    '    repFKeyStatCode.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmStat WHERE StatType<>2 ORDER BY Name,SortCode ASC")
    '    repIsComp.DataSource = getIsCompServ()

    '    With OthSeaView
    '        .BeginSort()
    '        Try
    '            .ClearGrouping()
    '            .Columns("ActGrpID").GroupIndex = 0
    '            .Columns("ActGrpID").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
    '            .Columns("ActDateStart").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
    '            .Columns("ActDateStart").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
    '        Finally
    '            .EndSort()
    '        End Try
    '    End With
    'End Sub

    'Private Function getActivityType() As DataTable
    '    Dim ctable As New DataTable
    '    ctable.Columns.Add("PKey", System.Type.GetType("System.String"))
    '    ctable.Columns.Add("Name", System.Type.GetType("System.String"))
    '    ctable.Rows.Add("SEA", "SEA")
    '    ctable.Rows.Add("ASHORE", "ASHORE")
    '    ctable.Rows.Add("OTHER", "OTHER")
    '    Return ctable
    'End Function
    'Private Function getIsCompServ() As DataTable
    '    Dim ctable As New DataTable
    '    ctable.Columns.Add("PKey", System.Type.GetType("System.String"))
    '    ctable.Columns.Add("Name", System.Type.GetType("System.String"))
    '    ctable.Rows.Add("1", "Not In MPS")
    '    ctable.Rows.Add("0", "MPS")
    '    Return ctable
    'End Function
    'Private Sub repVslName_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles repVslName.ProcessNewValue
    '    Dim Row As DataRow

    '    Dim Edit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

    '    Edit = CType(sender, DevExpress.XtraEditors.LookUpEdit).Properties



    '    If e.DisplayValue = Edit.NullText OrElse e.DisplayValue = String.Empty Then Exit Sub

    '    Row = Edit.DataSource.NewRow()

    '    Row("Name") = e.DisplayValue

    '    Edit.DataSource.Rows.Add(Row)

    '    e.Handled = True

    '    'If e.Handled Then
    '    '    Properties.DataAdapter.FilterPrefix = String.Empty
    '    '    Dim newEditValue As Object = Properties.GetKeyValueByDisplayValue(e.DisplayValue)
    '    '    Properties.RemoveDisplayValue(newEditValue)
    '    '    EditValue = newEditValue
    '    'End If
    'End Sub

    'Private Sub DeleteOther()

    'End Sub

    Private Sub temporary_OtherSeav()
        Throw New NotImplementedException
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If MsgBox("Do you want to change the equivalence of a month?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Ok Then
            MPSDB.SaveConfig("DAYS_IN_MONTH", Me.txtDays.Text)
            loadServSum()
        Else
            Me.txtDays.Text = MPSDB.GetConfig("DAYS_IN_MONTH")
        End If
    End Sub

    Private Sub SeaServView_ShownEditor(sender As Object, e As System.EventArgs) Handles SeaServView.ShownEditor
        SetMinMaxDateValidation(sender, e, "DateStarted", "DateEnded")
        stopnaba = True
    End Sub

    Private Sub AshView_ShownEditor(sender As Object, e As System.EventArgs) Handles AshView.ShownEditor
        SetMinMaxDateValidation(sender, e, "DateStarted", "DateEnded")
        stopnaba = True
    End Sub


#Region "Functions"

    Private Function GetActivityType(StatName As String) As String
        Dim dr() As DataRow = tblAdmStat.Select("Name = '" & StatName & "'")
        Dim retval As String = String.Empty
        Select Case IfNull(dr(0)("StatType").ToString, String.Empty)
            Case "1", 1
                retval = "SEA"
            Case "3", 3
                retval = "ASHORE"
        End Select
        Return retval
    End Function


    Private Function SaveOtherService() As Boolean
        Dim retval As Boolean = False
        Dim sqlcon As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Dim toBeInserted As Boolean = False

        Try
            sqlcon.Open()
            sqlTran = sqlcon.BeginTransaction
            With OtherView
                .CloseEditForm()
                .UpdateCurrentRow()
                For cRowHandle As Integer = 0 To .RowCount - 1
                    Dim strActGroupID As String = String.Empty
                    If .GetRowCellValue(cRowHandle, "Edited") Then

                        If IfNull(.GetRowCellValue(cRowHandle, "ActGroupID"), String.Empty).Equals(String.Empty) Then
                            'Insert Activity Group
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlcon
                                cmd.Transaction = sqlTran
                                Dim query As String = " INSERT  dbo.tblActivityGroup(" & _
                                        " FKeyIDNbr,ActivityType," & _
                                        " COIDNbr,LName," & _
                                        " FName,MName," & _
                                        " DOB,NatCode," & _
                                        " NatName,DateDep," & _
                                        " DateArr,PlaceDep," & _
                                        " PlaceArr,SOFFStat," & _
                                        " LOC,LOCDays,IsCompServ) " & _
                                        " SELECT " & _
                                            " tCrew.PKey,@ActivityType," & _
                                            " tCrew.COIDNo,tCrew.LName," & _
                                            " tCrew.FName,tCrew.MName," & _
                                            " tcrew.DOB,tCrew.NatCode," & _
                                            " tcntry.Name, @DateDep," & _
                                            " @DateArr, @PlaceDep," & _
                                            " @PlaceArr,@SOFFStat," & _
                                            "@LOC,@LOCDays,0 " & _
                                        " FROM dbo.tblCrewInfo tCrew" & _
                                        " INNER JOIN dbo.tblAdmCntry tcntry ON tcrew.NatCode = tcntry.PKey" & _
                                        " WHERE tCrew.PKey = @IDNbr"
                                cmd.CommandText = query
                                With cmd.Parameters
                                    'edited by tony20180424
                                    '   related to OtherView_InitNewRow. the .SetRowCellValue procedure to column "ActivityType" does not work which means no value is set to the column.
                                    '   therefore what happens is that when .GetRowCellValue gets DBNull when getting the value of column "ActivityType"
                                    '.AddWithValue("@ActivityType", OtherView.GetRowCellValue(cRowHandle, "ActivityType"))
                                    .AddWithValue("@ActivityType", "SEA")
                                    'end tony
                                    .AddWithValue("@DateDep", OtherView.GetRowCellValue(cRowHandle, "ActDateDep"))
                                    .AddWithValue("@DateArr", OtherView.GetRowCellValue(cRowHandle, "ActDateArr"))
                                    .AddWithValue("@PlaceDep", OtherView.GetRowCellValue(cRowHandle, "PlaceSOff"))
                                    .AddWithValue("@PlaceArr", OtherView.GetRowCellValue(cRowHandle, "PlaceSOn"))
                                    .AddWithValue("@SOFFStat", OtherView.GetRowCellValue(cRowHandle, "SOFFStat"))
                                    .AddWithValue("@IDNbr", strID)
                                    .AddWithValue("@LOC", OtherView.GetRowCellValue(cRowHandle, "LOC"))
                                    .AddWithValue("@LOCDays", OtherView.GetRowCellValue(cRowHandle, "LOCDays"))
                                End With
                                toBeInserted = (cmd.ExecuteNonQuery().Equals(1))
                            End Using

                            'get the id of the Inserted Row
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlcon
                                cmd.CommandText = "SELECT [PKey] FROM mps.dbo.tblActivityGroup WHERE ID=IDENT_CURRENT('tblActivityGroup')"
                                cmd.Transaction = sqlTran
                                strActGroupID = cmd.ExecuteScalar()
                            End Using

                            'insert Activity
                            If Not strActGroupID.Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlcon
                                    cmd.Transaction = sqlTran
                                    cmd.CommandText = "INSERT INTO dbo.tblActivity( " & _
                                        " FKeyActivityGroupID,VslName," & _
                                        " DeadWt,	GrossTon," & _
                                        " EngType,EngPower," & _
                                        " YrBuilt,Auxillaries," & _
                                        " PrinName,AgentName," & _
                                        " FltMgrName,StatName," & _
                                        " ActDateEnd,ActDateStart," & _
                                        " RankName,DateSOff," & _
                                        " DateSOn,PlaceSOn," & _
                                        " PlaceSOff,Remarks," & _
                                        " VslTypeName,FltName," & _
                                        " IMONo," & _
                                        " LastUpdatedBy)" & _
                                        " VALUES(" & _
                                        " @strActGroupID , @VslName ," & _
                                        " @DeadWt , @GrossTon ," & _
                                        " @EngType , @EngPower , " & _
                                        " @YrBuilt , @Auxillaries ," & _
                                        " @PrinName, @AgentName ," & _
                                        " @FltMgrName , @StatName ," & _
                                        " @DateSOff , @DateSOn ," & _
                                        " @RankName , @DateSOff ," & _
                                        " @DateSOn , @PlaceSOn ," & _
                                        " @PlaceSOff , @Remarks ," & _
                                        " @VslTypeName , @FltName ," & _
                                        " @IMONo ," & _
                                        " @LastUpdatedBy)"  '" & LastUpdatedBy.Replace("<TO_REPLACE>", .GetRowCellValue(cRowHandle, "VslName")).ToString.Replace("'", "''") & "')"
                                    With cmd.Parameters
                                        .AddWithValue("@strActGroupID", strActGroupID)
                                        .AddWithValue("@VslName", OtherView.GetRowCellValue(cRowHandle, "VslName"))
                                        .AddWithValue("@DeadWt", OtherView.GetRowCellValue(cRowHandle, "DeadWt"))
                                        .AddWithValue("@GrossTon", OtherView.GetRowCellValue(cRowHandle, "GrossTon"))
                                        .AddWithValue("@EngType", OtherView.GetRowCellValue(cRowHandle, "EngType"))
                                        .AddWithValue("@EngPower", OtherView.GetRowCellValue(cRowHandle, "EngPower"))
                                        .AddWithValue("@YrBuilt", OtherView.GetRowCellValue(cRowHandle, "YrBuilt"))
                                        .AddWithValue("@Auxillaries", OtherView.GetRowCellValue(cRowHandle, "Auxillaries"))
                                        .AddWithValue("@PrinName", OtherView.GetRowCellValue(cRowHandle, "PrinName"))
                                        .AddWithValue("@AgentName", OtherView.GetRowCellValue(cRowHandle, "AgentName"))
                                        .AddWithValue("@FltMgrName", OtherView.GetRowCellValue(cRowHandle, "FltMgrName"))
                                        .AddWithValue("@StatName", OtherView.GetRowCellValue(cRowHandle, "StatName"))
                                        .AddWithValue("@DateSOff", OtherView.GetRowCellValue(cRowHandle, "ActDateSOff"))
                                        .AddWithValue("@DateSOn", OtherView.GetRowCellValue(cRowHandle, "ActDateSOn"))
                                        .AddWithValue("@RankName", OtherView.GetRowCellValue(cRowHandle, "RankName"))
                                        .AddWithValue("@PlaceSOn", OtherView.GetRowCellValue(cRowHandle, "PlaceSOn"))
                                        .AddWithValue("@PlaceSOff", OtherView.GetRowCellValue(cRowHandle, "PlaceSOff"))
                                        .AddWithValue("@Remarks", OtherView.GetRowCellValue(cRowHandle, "Remarks"))
                                        .AddWithValue("@VslTypeName", OtherView.GetRowCellValue(cRowHandle, "VslTypeName"))
                                        .AddWithValue("@FltName", OtherView.GetRowCellValue(cRowHandle, "FltName"))
                                        .AddWithValue("@IMONo", OtherView.GetRowCellValue(cRowHandle, "IMONo"))
                                        .AddWithValue("@LastUpdatedBy", LastUpdatedBy.Replace("<TO_REPLACE>", OtherView.GetRowCellValue(cRowHandle, "VslName")).ToString.Replace("'", "''"))
                                    End With
                                    toBeInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            Else
                                retval = False
                            End If
                        Else 'Update Other Service
                            If Not IfNull(.GetRowCellValue(cRowHandle, "ActGroupID"), "").Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlcon
                                    cmd.Transaction = sqlTran
                                    cmd.CommandText = "UPDATE dbo.tblActivityGroup" & _
                                            " SET SOFFStat= @SOFFStat " & _
                                            " , DateDep= @DateDep " & _
                                            " , DateArr= @DateArr " & _
                                            " , PlaceDep= @PlaceDep " & _
                                            " , LOC= @LOC " & _
                                            " , LOCDays= @LOCDays " & _
                                            " , ActivityType= @ActivityType " & _
                                            " , IsCompServ= 0 " & _
                                            " WHERE PKey = @ActGroupID"
                                    With cmd.Parameters
                                        .AddWithValue("@SOFFStat", OtherView.GetRowCellValue(cRowHandle, "SOFFStat"))
                                        .AddWithValue("@ActGroupID", OtherView.GetRowCellValue(cRowHandle, "ActGroupID"))
                                        .AddWithValue("@ActivityType", OtherView.GetRowCellValue(cRowHandle, "ActivityType"))
                                        .AddWithValue("@DateDep", OtherView.GetRowCellValue(cRowHandle, "ActDateDep"))
                                        .AddWithValue("@DateArr", OtherView.GetRowCellValue(cRowHandle, "ActDateArr"))
                                        .AddWithValue("@PlaceArr", OtherView.GetRowCellValue(cRowHandle, "PlaceSOff"))
                                        .AddWithValue("@PlaceDep", OtherView.GetRowCellValue(cRowHandle, "PlaceSOn"))
                                        .AddWithValue("@LOC", OtherView.GetRowCellValue(cRowHandle, "LOC"))
                                        .AddWithValue("@LOCDays", OtherView.GetRowCellValue(cRowHandle, "LOCDays"))

                                    End With
                                    toBeInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            End If
                            If Not IfNull(.GetRowCellValue(cRowHandle, "ActID"), "").Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlcon
                                    cmd.Transaction = sqlTran
                                    cmd.CommandText = "UPDATE dbo.tblActivity" & _
                                            " SET VslName=@VslName" & _
                                            " ,DeadWt= @DeadWt" & _
                                            " ,GrossTon=@GrossTon" & _
                                            " ,EngType=@EngType " & _
                                            " ,EngPower=@EngPower" & _
                                            " ,YrBuilt=@YrBuilt " & _
                                            " ,Auxillaries=@Auxillaries " & _
                                            " ,PrinName=@PrinName" & _
                                            " ,AgentName=@AgentName" & _
                                            " ,FltMgrName=@FltMgrName" & _
                                            " ,StatName=@StatName" & _
                                            " ,ActDateEnd=@ActDateEnd" & _
                                            " ,ActDateStart=@ActDateStart" & _
                                            " ,RankName=@RankName" & _
                                            " ,DateSOff=@DateSOff" & _
                                            " ,DateSOn=@DateSOn" & _
                                            " ,PlaceSOn=@PlaceSOn" & _
                                            " ,PlaceSOff=@PlaceSOff" & _
                                            " ,Remarks=@Remarks" & _
                                            " ,VslTypeName=@VslTypeName" & _
                                            " ,FltName=@FltName" & _
                                            " ,IMONo=@IMONo" & _
                                            " ,LastUpdatedBy=@LastUpdatedBy" & _
                                            " ,DateUpdated=(getdate())" & _
                                            " WHERE PKey = @ActID "
                                    With cmd.Parameters
                                        .AddWithValue("@VslName", OtherView.GetRowCellValue(cRowHandle, "VslName"))
                                        .AddWithValue("@DeadWt", OtherView.GetRowCellValue(cRowHandle, "DeadWt"))
                                        .AddWithValue("@GrossTon", OtherView.GetRowCellValue(cRowHandle, "GrossTon"))
                                        .AddWithValue("@EngType", OtherView.GetRowCellValue(cRowHandle, "EngType"))
                                        .AddWithValue("@EngPower", OtherView.GetRowCellValue(cRowHandle, "EngPower"))
                                        .AddWithValue("@YrBuilt", OtherView.GetRowCellValue(cRowHandle, "YrBuilt"))
                                        .AddWithValue("@Auxillaries", OtherView.GetRowCellValue(cRowHandle, "Auxillaries"))
                                        .AddWithValue("@PrinName", OtherView.GetRowCellValue(cRowHandle, "PrinName"))
                                        .AddWithValue("@AgentName", OtherView.GetRowCellValue(cRowHandle, "AgentName"))
                                        .AddWithValue("@FltMgrName", OtherView.GetRowCellValue(cRowHandle, "FltMgrName"))
                                        .AddWithValue("@StatName", OtherView.GetRowCellValue(cRowHandle, "StatName"))
                                        .AddWithValue("@ActDateEnd", OtherView.GetRowCellValue(cRowHandle, "ActDateEnd"))
                                        .AddWithValue("@ActDateStart", OtherView.GetRowCellValue(cRowHandle, "ActDateStart"))
                                        .AddWithValue("@DateSOff", OtherView.GetRowCellValue(cRowHandle, "ActDateSOff"))
                                        .AddWithValue("@DateSOn", OtherView.GetRowCellValue(cRowHandle, "ActDateSOn"))
                                        .AddWithValue("@RankName", OtherView.GetRowCellValue(cRowHandle, "RankName"))
                                        .AddWithValue("@PlaceSOn", OtherView.GetRowCellValue(cRowHandle, "PlaceSOn"))
                                        .AddWithValue("@PlaceSOff", OtherView.GetRowCellValue(cRowHandle, "PlaceSOff"))
                                        .AddWithValue("@Remarks", OtherView.GetRowCellValue(cRowHandle, "Remarks"))
                                        .AddWithValue("@IMONo", OtherView.GetRowCellValue(cRowHandle, "IMONo"))
                                        .AddWithValue("@VslTypeName", OtherView.GetRowCellValue(cRowHandle, "VslTypeName"))
                                        .AddWithValue("@FltName", OtherView.GetRowCellValue(cRowHandle, "FltName"))
                                        .AddWithValue("@LastUpdatedBy", LastUpdatedBy.Replace("<TO_REPLACE>", OtherView.GetRowCellValue(cRowHandle, "VslName")).ToString)
                                        .AddWithValue("@ActID", OtherView.GetRowCellValue(cRowHandle, "ActID"))
                                    End With
                                    toBeInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            Else
                                retval = False
                            End If
                        End If
                    End If
                Next
            End With
            If toBeInserted Then
                sqlTran.Commit()
                retval = True
            Else
                retval = False
            End If
        Catch ex As Exception
            sqlTran.Rollback()
            retval = False
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
        End Try
        Return retval
    End Function


#End Region

    Dim stopnaba As Boolean = False

    Private Sub AshGrid_Click(sender As Object, e As System.EventArgs) Handles AshGrid.Click
        stopnaba = True
    End Sub

    Private Sub AshGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles AshGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub SeaServGrid_Click(sender As Object, e As System.EventArgs) Handles SeaServGrid.Click
        stopnaba = True
    End Sub

    Private Sub SeaServGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SeaServGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub OtherGrid_Click(sender As Object, e As System.EventArgs) Handles OtherGrid.Click
        stopnaba = True
    End Sub

    Private Sub OtherGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles OtherGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Dim ermsg As String = "", tempvPKey As Integer = 0
        'MsgBox("test")
        Select Case param(0)
            Case "ACTIVITYDOCS"
                'MsgBox(Me.SeaServView.GridControl.ContainsFocus)
                'MsgBox(focusedView.Name)
                Dim _CurrActId As String = IfNull(focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ActID"), "")
                ' MsgBox(_CurrActId)

                If _CurrActId <> "" Then
                    Dim activitydocsfrm As New frmActivityDocs(_CurrActId, strID, focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "DateStarted"),
                                                               IfNull(focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "Vessel"), ""), , blList.GetDesc)
                    activitydocsfrm.ShowDialog()
                Else
                    MsgBox("No Activity to Attach Document to.", vbInformation)
                End If

        End Select
    End Sub

    Private Sub setSelectedView()
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "SeaAct"
                focusedView = SeaServView
            Case "AshAct"
                focusedView = AshView
            Case "OthAct1"
                focusedView = OtherView
            Case Else
                focusedView = Nothing
        End Select
    End Sub
End Class
