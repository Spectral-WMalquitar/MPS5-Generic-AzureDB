Public Class ReassignCrewConfirm

#Region "Declarations"
    Private FormName As String = "Crew Reassignment Transfer Confirmation"

    'Private LastUpdatedBy As String = GetUserName() & "<" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Private _userdatafilter As String

    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

    Private Enum ActionStatus
        None = 0
        Approve = 1
        Reject = 2
    End Enum

    Private Structure MainViewFields
        Const IDNbr As String = "IDNbr"
        Const ActionCode As String = "ActionCode"
        Const EffectivityDate As String = "EffectivityDate"
        Const ActionRemarks As String = "ActionRemarks"
        Const RecentActivityDate As String = "RecentActivityDate"
        Const isNowOnboard As String = "isNowOnboard"
    End Structure
#End Region

#Region "Initialization"

    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        'Repository ITEMS

        '-- Create DataSource of Repository `repAction`
        Dim dt As New DataTable
        dt.Columns.Add("ActionCode", Type.GetType("System.Int32"))

        dt.Columns.Add("Action", Type.GetType("System.String"))

        dt.Rows.Add({ActionStatus.None, "None"})
        dt.Rows.Add({ActionStatus.Approve, "Approve"})
        dt.Rows.Add({ActionStatus.Reject, "Reject"})
        repAction.DataSource = dt
        '---------------------------------------------------------------------------------------------------------------------------
    End Sub
#End Region

#Region "Main"
    Private Sub LoadSub()
        Dim dt As DataTable
        Dim subFilterJoin As String = ""
        Dim _selectionFilter As String = ""
        Dim _selectedFilter As String = ""
        Dim cSQL As String = ""
        Dim cWhere As String = ""
        Dim isCurrentUserAdmin As Boolean = False
        Dim clsSecurity = New Utilities.clsSecurity

        '-- Gets the crew data filterstring
        _userdatafilter = GetUserFilterString(, "rcrew.FKeyAgentCode", "rcrew.FKeyPrinCode", "rcrew.FKeyFlt")
        '---------------------------------------------------------------------------------------------------------------------------

        '-- Assembles data source criteria
        cWhere = IIf(_userdatafilter.Length > 0, _userdatafilter, "")
        cWhere = cWhere & IIf(cWhere.Length > 0, " AND ", "") & "rcrew.actioncode = 0"
        cWhere = IIf(cWhere.Length > 0, "WHERE " & cWhere, "")
        '---------------------------------------------------------------------------------------------------------------------------

        'CREATE SOURCE OF MAIN GRID
        cSQL = "SELECT      CAST(0 AS BIT) AS Edited, " & _
               "            CAST(Null AS Date) AS EffectivityDate, " & _
               "            r.[description], " & _
               "            r.requestedby, " & _
               "            users.name as RequestedByName, " & _
               "            Format(r.daterequested, 'dd-MMM-yyyy') as DateRequested, " & _
               "            rcrew.*, " & _
               "            ragent.name as ReassignToAgentName, " & _
               "            rvsl.name as ReassignToVslName, " & _
               "            r.[description] + ' (' + Cast(format(r.daterequested, 'dd-MMM-yyyy') as varchar) + ')' as GroupColumn, " & _
               "            CASE WHEN ca.FKeyStatCode = 'SYSONB' AND ag.SOFFStat is null THEN Cast(1 AS BIT) ELSE Cast(0 AS BIT) END as isNowOnboard " & _
               "FROM        [dbo].[view_ReassignCrewList] rcrew INNER JOIN " & _
               "            [dbo].[tblCrewReassign] r ON rcrew.fkeyreassignid = r.pkey INNER JOIN " & _
               "            [dbo].[Current_Activites] ca ON rcrew.IDNbr = ca.FKeyIDNbr INNER JOIN " & _
               "            [dbo].[tblActivityGroup] ag ON ca.fkeyactivitygroupid = ag.pkey LEFT JOIN " & _
               "            [dbo].[MSysSec_Users] users ON r.requestedby = users.id LEFT JOIN " & _
               "            [dbo].[tbladmcompany] ragent ON rcrew.ReassignToAgent = ragent.pkey LEFT JOIN " & _
               "            [dbo].[tbladmvsl] rvsl ON rcrew.reassigntovsl = rvsl.pkey " & _
                            cWhere & _
               "ORDER BY   DateRequested desc"

        'cSQL = "SELECT      CAST(0 AS BIT) AS Edited, " & _
        '       "            CAST(Null AS Date) AS EffectivityDate, " & _
        '       "            r.[description], " & _
        '       "            r.requestedby, " & _
        '       "            users.name as RequestedByName, " & _
        '       "            Format(r.daterequested, 'dd-MMM-yyyy') as DateRequested, " & _
        '       "            rcrew.[ReassignPKey], " & _
        '       "            rcrew.[FKeyReassignID], " & _
        '       "            rcrew.[IDNbr], " & _
        '       "            rcrew.[CrewName], " & _
        '       "            rcrew.[Rank], " & _
        '       "            rcrew.[FKeyAgentCode], " & _
        '       "            rcrew.[AgentName], " & _
        '       "            rcrew.[FKeyPrinCode], " & _
        '       "            rcrew.[PrinName], " & _
        '       "            rcrew.[FKeyFlt], " & _
        '       "            rcrew.[FltName], " & _
        '       "            rcrew.[ReassignToAgent], " & _
        '       "            rcrew.[ReassignToVsl], " & _
        '       "            rcrew.[ActionCode], " & _
        '       "            rcrew.[ActionAppliedBy], " & _
        '       "            rcrew.[Remarks], " & _
        '       "            concat(CASE WHEN ca.FKeyStatCode = 'SYSONB' AND ag.SOFFStat is null THEN '(Crew is now already onboard)' ELSE Null END, rcrew.[ActionRemarks]) as ActionRemarks, " & _
        '       "            rcrew.[RecentActivityStat], " & _
        '       "            rcrew.[RecentActivityDate], " & _
        '       "            rcrew.[RecentActivity]," & _
        '       "            ragent.name as ReassignToAgentName, " & _
        '       "            rvsl.name as ReassignToVslName, " & _
        '       "            r.[description] + ' (' + Cast(format(r.daterequested, 'dd-MMM-yyyy') as varchar) + ')' as GroupColumn, " & _
        '       "            CASE WHEN ca.FKeyStatCode = 'SYSONB' AND ag.SOFFStat is null THEN Cast(1 AS BIT) ELSE Cast(0 AS BIT) END as isNowOnboard " & _
        '       "            " & _
        '       "FROM        [dbo].[view_ReassignCrewList] rcrew INNER JOIN              " & _
        '       "            [dbo].[tblCrewReassign] r ON rcrew.fkeyreassignid = r.pkey INNER JOIN        " & _
        '       "            [dbo].[Current_Activites] ca ON rcrew.IDNbr = ca.FKeyIDNbr INNER JOIN        " & _
        '       "            [dbo].[tblActivityGroup] ag ON ca.fkeyactivitygroupid = ag.pkey LEFT JOIN    " & _
        '       "            [dbo].[MSysSec_Users] users ON r.requestedby = users.id LEFT JOIN             " & _
        '       "            [dbo].[tbladmcompany] ragent ON rcrew.ReassignToAgent = ragent.pkey LEFT JOIN   " & _
        '       "            [dbo].[tbladmvsl] rvsl ON rcrew.reassigntovsl = rvsl.pkey                       " & _
        '                    cWhere & _
        '       "            " & _
        '       "ORDER BY	DateRequested desc	"

        dt = DB.CreateTable(cSQL)
        Me.MainGrid.DataSource = dt
        '---------------------------------------------------------------------------------------------------------------------------

        MainView.Columns("GroupColumn").Group()
        MainView.ExpandAllGroups()
    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblCrewReassign"
        MyBase.RefreshData()
        SetEditOptionsVisibility(Me.Name, True)
        SetHideCrewReassignmentRequestVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetViewRecordSumEnabled(Name, False)
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Crew Reassignment Confirmation")
        strRequiredFields = "txtDescription;txtDateRequested"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If

        LoadSub()

        AllowSaving(Name, False)
        AllowEditSubGrid(MainView, False)
        BRECORDUPDATEDs = False
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            header.Focus()
            AllowSaving(Name, True)
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            'Sub
            AllowEditSubGrid(MainView)
        Else
            AllowSaving(Name, False)
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'Sub
            AllowEditSubGrid(MainView,False)
        End If
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim query As New ArrayList, id As String = "", cSQL As String = ""

        Dim dt As DataTable = TryCast(MainGrid.DataSource, DataTable)
        If BRECORDUPDATEDs Then
            If isValidAllInSub() Then
                For i As Integer = 0 To MainView.DataRowCount - 1
                    If MainView.GetRowCellValue(i, "Edited") = "1" Then

                        With MainView
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Confirmation", 0, System.Environment.MachineName, "user [" & USER_NAME.ToString.Replace("'", "''") & "] " & LCase(.GetRowCellDisplayText(i, "ActionCode").ToString.Replace("'", "''")) & "ed reassignment request for crew [" & .GetRowCellDisplayText(i, "ReassignPKey").ToString.Replace("'", "''") & "].", FormName, .GetRowCellValue(i, "IDNbr")) 'tony20161013

                            cSQL = "UPDATE dbo.tblcrewreassigncrews " & _
                                      "SET " & _
                                      "ActionCode = " & .GetRowCellValue(i, "ActionCode") & ", " & _
                                      "ActionAppliedBy = " & USER_ID & ", " & _
                                      "ActionAppliedByName = '" & USER_NAME & "', " & _
                                      "ActionRemarks = " & IIf(.GetRowCellValue(i, "ActionRemarks").ToString.Length > 0, "'" & .GetRowCellValue(i, "ActionRemarks") & "'", "Null") & ", " & _
                                      "DateApproved = getdate(), " & _
                                      "isReadNotification = 0, " & _
                                      "LastUpdatedBy = '" & Me.LastUpdatedBy & "' " & _
                                      "WHERE PKey = '" & .GetRowCellValue(i, "ReassignPKey") & "'"
                            query.Add(cSQL)

                            If MainView.GetRowCellValue(i, "ActionCode") = 1 Then
                                Dim cEffectivityDate = MainView.GetRowCellValue(i, "EffectivityDate")

                                '-- UPDATES THE EFFECTIVITY DATE
                                cSQL = "UPDATE dbo.tblcrewreassigncrews " & _
                                      "SET " & _
                                      "EffectivityDate = " & ChangeToSQLDate(cEffectivityDate) & " " & _
                                      "WHERE PKey = '" & .GetRowCellValue(i, "ReassignPKey") & "'"
                                query.Add(cSQL)

                                '-- CREATES NEXT ACTIVITY
                                cSQL = "DECLARE @tmp DATETIME " & _
                                          "SET @tmp = GETDATE() EXEC SP_REASSIGN_CREW " & _
                                          "@IDNbr = '" & .GetRowCellValue(i, "IDNbr") & "', " & _
                                          "@ReassignToAgent = '" & .GetRowCellValue(i, "ReassignToAgent") & "', " & _
                                          "@ReassignToVsl = '" & .GetRowCellValue(i, "ReassignToVsl") & "', " & _
                                          "@DateStart = " & ChangeToSQLDate(cEffectivityDate) & ", " & _
                                          "@LastUpdatedBy = '" & USER_NAME & "', " & _
                                          "@RequestedBy = '" & .GetRowCellValue(i, "RequestedByName") & "', " & _
                                          "@ApprovedBy = '" & USER_NAME & "', " & _
                                          "@DateApproved = @tmp"
                                query.Add(cSQL)
                            End If
                        End With
                    End If
                Next
                BRECORDUPDATEDs = False
                If DB.RunSqls(query) Then
                    RefreshData()
                    MsgBox(GetMessage("Updated"), MsgBoxStyle.Information, GetAppName)
                End If
            End If


        Else
            MsgBox("No changes have been made.", vbInformation)
            Me.RefreshData()
        End If

        RemoveEditListener(LayoutControl1.Root)
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If MainView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else
                flag = True
                ALLOWNEXTS = flag
                SaveData() '
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Private Function isValidAllInSub() As Boolean
        '## Description: Validates if all in sub grid are assigned with an Agent and Vessel
        Dim bValid As Boolean = True

        For i As Integer = 0 To MainView.DataRowCount - 1
            Try
                bValid = isValidMainViewRow(i)
                If Not bValid Then Exit For
            Catch ex As Exception
                Exit For
            End Try

        Next

        Return bValid
    End Function

    Private Function isValidMainViewRow(ByVal nRow As Integer) As Boolean
        Dim bValid As Boolean = True
        Try

            With MainView

                If IsDBNull(.GetRowCellValue(nRow, MainViewFields.ActionCode)) = True Then
                    .GetDataRow(nRow).SetColumnError(MainViewFields.ActionCode, "Must select Action to apply.")
                    AllowSaving(Name, False)
                    bValid = False
                Else
                    Select Case .GetRowCellValue(nRow, MainViewFields.ActionCode)
                        Case ActionStatus.None
                            .GetDataRow(nRow).SetColumnError(MainViewFields.EffectivityDate, "")
                            .GetDataRow(nRow).SetColumnError(MainViewFields.ActionRemarks, "")
                        Case ActionStatus.Approve
                            'If IsDBNull(.GetRowCellValue(nRow, MainViewFields.EffectivityDate)) Then
                            If .GetRowCellValue(nRow, MainViewFields.isNowOnboard) Then
                                .GetDataRow(nRow).SetColumnError(MainViewFields.ActionCode, "Cannot approve reassignment. Crew is already onboard.")
                                AllowSaving(Name, False)
                                bValid = False
                            ElseIf IsDBNull(.GetRowCellValue(nRow, MainViewFields.EffectivityDate)) Then
                                .GetDataRow(nRow).SetColumnError(MainViewFields.EffectivityDate, "Must set the Effectivity Date.")
                                AllowSaving(Name, False)
                                bValid = False
                            Else
                                If Not IsDBNull(.GetRowCellValue(nRow, MainViewFields.RecentActivityDate)) Then
                                    If (CType(.GetRowCellValue(nRow, MainViewFields.EffectivityDate), Date) <= CType(.GetRowCellValue(nRow, MainViewFields.RecentActivityDate), Date)) Then
                                        .GetDataRow(nRow).SetColumnError(MainViewFields.EffectivityDate, "Effectivty Date must be later than the recent activity.")
                                        AllowSaving(Name, False)
                                        bValid = False
                                    Else
                                        .GetDataRow(nRow).SetColumnError(MainViewFields.EffectivityDate, "")
                                    End If
                                Else
                                    .GetDataRow(nRow).SetColumnError(MainViewFields.EffectivityDate, "")
                                End If
                            End If
                        Case ActionStatus.Reject
                            .GetDataRow(nRow).SetColumnError(MainViewFields.EffectivityDate, "")
                            .GetDataRow(nRow).SetColumnError(MainViewFields.ActionRemarks, "")
                    End Select
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If bValid Then AllowSaving(Name, True)

        Return bValid
    End Function

    Public Overrides Sub ExecCustomFunction(param() As Object)
        Select Case param(0)
            Case "ViewRecordSum"
                ViewRecordSum()
        End Select
    End Sub

    Private Sub ViewRecordSum()
        Try
            clsReassignCrew.ViewRecordSum(Trim(IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "IDNbr"), "")))
        Catch ex As Exception
            MsgBox("Unable to open record summary. Please contact your system provider.", vbInformation)
        End Try
    End Sub

#End Region

#Region "Control Enabling Procedures/Functions"

    Public Sub AllowEditSubGrid(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, Optional ByVal value As Boolean = True, Optional ByVal EnableGrid As Boolean = True)
        With view
            .CancelUpdateCurrentRow()
            If value Then
                .OptionsBehavior.ReadOnly = False
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                .GridControl.AllowDrop = True
            Else
                .OptionsBehavior.ReadOnly = True
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            End If
        End With

        view.GridControl.Enabled = EnableGrid
        view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

#End Region

#Region "MainView Events"

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.FieldName.ToString = "Edited" Or e.Column.FieldName.ToString = MainViewFields.EffectivityDate Or e.Column.FieldName.ToString = MainViewFields.ActionRemarks Then

        Else
            MainView.SetRowCellValue(e.RowHandle, "Edited", 1)
            BRECORDUPDATEDs = True

            If MainView.GetRowCellValue(e.RowHandle, MainViewFields.ActionCode) = ActionStatus.Reject Then
                MainView.SetRowCellValue(e.RowHandle, MainViewFields.EffectivityDate, DBNull.Value)
            ElseIf MainView.GetRowCellValue(e.RowHandle, MainViewFields.ActionCode) = ActionStatus.None Then
                MainView.SetRowCellValue(e.RowHandle, MainViewFields.ActionRemarks, DBNull.Value)
            End If
        End If
    End Sub

    Private Sub MainView_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles MainView.CustomRowCellEdit
        If e.Column.FieldName = MainViewFields.EffectivityDate Then
            If MainView.GetRowCellValue(MainView.FocusedRowHandle, MainViewFields.ActionCode) = ActionStatus.Reject Or _
                MainView.GetRowCellValue(MainView.FocusedRowHandle, MainViewFields.ActionCode) = ActionStatus.None Then
                'Dim rep As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
                'rep.EditFormat.FormatString = "dd-MMM-yyyy"
                'rep.EditFormat.FormatString = "dd-MMM-yyyy"
                e.RepositoryItem = repDateEdit_ReadOnly
            Else
                e.RepositoryItem = repEffectivityDate
            End If
        ElseIf e.Column.FieldName = MainViewFields.ActionRemarks Then
            If MainView.GetRowCellValue(MainView.FocusedRowHandle, MainViewFields.ActionCode) = ActionStatus.None Then
                e.RepositoryItem = repTextEdit_ReadOnly
            Else
                e.RepositoryItem = Nothing
            End If
        End If
    End Sub

    Private Sub MainView_GotFocus(sender As Object, e As System.EventArgs) Handles MainView.GotFocus
        SetViewRecordSumEnabled(Name, True)
    End Sub

    Private Sub MainView_LostFocus(sender As Object, e As System.EventArgs) Handles MainView.LostFocus
        SetViewRecordSumEnabled(Name, False)
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.Column.FieldName = MainViewFields.ActionCode Or
                e.Column.FieldName = MainViewFields.EffectivityDate Or
                    e.Column.FieldName = MainViewFields.ActionRemarks Then

            If MainView.OptionsBehavior.ReadOnly Then
                e.Appearance.BackColor = System.Drawing.Color.White
            Else
                e.Appearance.BackColor = REQUIRED_COLOR 'System.Drawing.Color.Yellow
            End If
        End If
    End Sub

    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
        isValidMainViewRow(MainView.FocusedRowHandle)
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

   
End Class
