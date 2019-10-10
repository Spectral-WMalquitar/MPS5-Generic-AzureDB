Imports Utilities

Public Class AdmKPI

#Region "Declarations"
    Private FormName As String = "Admin KPI Parameters"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
    Private SaveDataSubHasError As Boolean = False

    Private StatType As New StatTypeClass

    Private Structure AdmKPITab
        Const ActivityStatus As String = "grpActivityStatus"
        Const RetRateTermimationStatus As String = "grpRetTermStatus"
    End Structure

    Private Structure TerminationType
        Const BeneficiaryCode = "BENEFICIARY"
        Const BeneficiaryName = "Beneficiary Termination"
        Const BeneficiaryStatField = "RetentionRateBeneficiaryTermination"
        Const UnavoidableCode = "UNAVOIDABLE"
        Const UnavoidableName = "Unavoidable Termination"
        Const UnavoidableStatField = "RetentionRateUnavoidableTermination"
        Const NotApplicableCode = "NA"
        Const NotApplicableName = "Not Applicable"
    End Structure

#Region "Class"
#Region "StatType"
    Private Class StatTypeIdentity
        Public Code As Integer
        Public Name As String
    End Class

    Private Class StatTypeClass
        Public Onboard As New StatTypeIdentity
        Public SignOffReason As New StatTypeIdentity
        Public AshoreStatus As New StatTypeIdentity

        Public Sub New()
            Onboard.Code = 1
            Onboard.Name = "Onboard"

            SignOffReason.Code = 2
            SignOffReason.Name = "Sign Off Reason"

            AshoreStatus.Code = 3
            AshoreStatus.Name = "Ashore Status"
        End Sub
    End Class
#End Region
#End Region

#End Region

    Public Overrides Sub RefreshData()
        TableName = "MSysRptDataMapping"
        MyBase.RefreshData()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

        If Not bLoaded Then
            initControls()
            TabAdmKPI.SelectedTabPageIndex = 0
            bLoaded = True
        End If

        LoadSub()


        GridStatusView.OptionsBehavior.ReadOnly = True
        GridRetStatView.OptionsBehavior.ReadOnly = True

        MakeReadOnlyListener(Me.LayoutControl1.Root)
        AllowAddition(Name, False)
        AllowDeletion(Name, False)
        BRECORDUPDATEDs = False

    End Sub

    Private Sub initControls()
        Dim dt As DataTable
        'Dim cSQL As String
        Dim ccolumn As DataColumn

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False

        '========================================================================================================================================================================================================================================================================
        'Admin Status Repository
        dt = New DataTable
        dt = MPSDB.CreateTable("SELECT * FROM dbo.tbladmstat ORDER BY Name")
        repAdmStat.DataSource = dt

        '========================================================================================================================================================================================================================================================================
        'Status Type Reporsitory
        dt = New DataTable

        'add columns to dt
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        'dt.Rows.Add(New Object() {1, "Onboard"})
        'dt.Rows.Add(New Object() {2, "Sign Off Reason"})
        'dt.Rows.Add(New Object() {3, "Ashore Activity"})
        dt.Rows.Add(New Object() {StatType.Onboard.Code, StatType.Onboard.Name})
        dt.Rows.Add(New Object() {StatType.SignOffReason.Code, StatType.SignOffReason.Name})
        dt.Rows.Add(New Object() {StatType.AshoreStatus.Code, StatType.AshoreStatus.Name})

        repStatType.DataSource = dt
        repRetStatType.DataSource = dt

        '========================================================================================================================================================================================================================================================================
        'Termination Type Reporsitory
        dt = New DataTable

        'add columns to dt
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        dt.Rows.Add(New Object() {TerminationType.NotApplicableCode, TerminationType.NotApplicableName})
        dt.Rows.Add(New Object() {TerminationType.BeneficiaryCode, TerminationType.BeneficiaryName})
        dt.Rows.Add(New Object() {TerminationType.UnavoidableCode, TerminationType.UnavoidableName})

        repRetTerminationType.DataSource = dt
    End Sub

    Private Sub LoadSub()
        Dim dt As DataTable
        Dim cSQL As String

        '========================================================================================================================================================================================================================================================================
        'GridStatus DataSource
        dt = New DataTable
        cSQL = "SELECT Cast(0 as bit) as Edited, map.*, stat.StatType " & _
               "FROM dbo.MSysrptdatamapping map LEFT JOIN dbo.tbladmstat stat ON map.CriteriaFieldValue = stat.PKey " & _
               "WHERE map.UseForKPI = 1 AND map.TableName = 'tbladmstat' ORDER BY Name "

        dt = MPSDB.CreateTable(cSQL)

        GridStatus.DataSource = dt

        '========================================================================================================================================================================================================================================================================
        'GridRetStat DataSource
        dt = New DataTable
        cSQL = "SELECT	Cast(0 as bit) as Edited, " & _
               "        *, " & _
               "        CASE WHEN RetentionRateTerminationType is null THEN 'NA' ELSE RetentionRateTerminationType END as TerminationType " & _
               "FROM    dbo.tbladmstat WHERE StatType = " & StatType.SignOffReason.Code & " OR StatType = " & StatType.AshoreStatus.Code & " " & _
               "ORDER BY Name"
        '"		,CASE WHEN RetentionRateBeneficiaryTermination = 1 THEN 'BENEFICIARY' ELSE CASE WHEN RetentionRateBeneficiaryTermination  = 1 THEN 'UNAVOIDABLE' ELSE 'NA' END END as TerminationTypeB " & _

        dt = MPSDB.CreateTable(cSQL)

        GridRetStat.DataSource = dt
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            'SetGridViewEditable(GridStatusView, True)
            If TabAdmKPI.SelectedTabPageName = AdmKPITab.ActivityStatus Then GridStatusView.OptionsBehavior.ReadOnly = False
            If TabAdmKPI.SelectedTabPageName = AdmKPITab.RetRateTermimationStatus Then GridRetStatView.OptionsBehavior.ReadOnly = False
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Else
            'SetGridViewEditable(GridStatusView, False)
            If TabAdmKPI.SelectedTabPageName = AdmKPITab.ActivityStatus Then GridStatusView.OptionsBehavior.ReadOnly = True
            If TabAdmKPI.SelectedTabPageName = AdmKPITab.RetRateTermimationStatus Then GridRetStatView.OptionsBehavior.ReadOnly = True
            MakeReadOnlyListener(Me.LayoutControl1.Root)
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            If TabAdmKPI.SelectedTabPageName = AdmKPITab.ActivityStatus Then
                gv = CType(GridStatusView, DevExpress.XtraGrid.Views.Grid.GridView)
            ElseIf TabAdmKPI.SelectedTabPageName = AdmKPITab.RetRateTermimationStatus Then
                gv = CType(GridRetStatView, DevExpress.XtraGrid.Views.Grid.GridView)
            End If

            If Not IsNothing(gv) Then
                If gv.HasColumnErrors() Then
                    flag = False
                    ALLOWNEXTS = flag
                Else
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData()
                End If
            Else
                RefreshData()
                flag = False
                ALLOWNEXTS = True
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

#Region "Save Data"
    'Save Data
    Public Overrides Sub SaveData()
        Dim query As New ArrayList
        Dim info As Boolean = False

        SaveDataSubHasError = False
        Me.header.Focus()
        Try
            Select Case TabAdmKPI.SelectedTabPageName
                Case AdmKPITab.ActivityStatus
                    SaveData_ActivityStatus(query)

                Case AdmKPITab.RetRateTermimationStatus
                    SaveData_RetRateTerminationStatus(query)

            End Select

            BRECORDUPDATEDs = False

            If Not SaveDataSubHasError Then
                If query.Count > 0 Then
                    info = DB.RunSqls(query)
                    If info Then
                        RefreshData()
                        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                    End If
                Else
                    MsgBox("No changes made.", MsgBoxStyle.Information)
                End If
            End If

        Catch ex As Exception
            LogErrors("Failed to save KPI Activity Status Parameters")
            LogErrors("Error : " & ex.Message)
            MsgBox("Failed to save KPI Activity Status Parameters." & Chr(13) & Chr(13) & "Error : " & ex.Message, MsgBoxStyle.Exclamation, "KPI - Activity Status")
        End Try

    End Sub

    Private Sub SaveData_ActivityStatus(ByRef query As ArrayList)
        Dim info As Boolean = False
        Try
            With Me.GridStatusView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Admin KPI Parameters - Activity Status", 10, System.Environment.MachineName, .GetRowCellDisplayText(i, "PKey"), FormName)
                        query.Add("UPDATE dbo.MSysRptDataMapping SET CriteriaFieldValue = '" & .GetRowCellValue(i, "CriteriaFieldValue") & "' WHERE PKey = '" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                Next

            End With
        Catch ex As Exception
            LogErrors("Failed to initialize save query list for KPI Activity Status Parameters - Activity Status")
            LogErrors("Error : " & ex.Message)
            MsgBox("Failed to initialize save query list for KPI Activity Status Parameters - Activity Status" & Chr(13) & Chr(13) & "Error : " & ex.Message, MsgBoxStyle.Exclamation, "KPI - Activity Status")
            SaveDataSubHasError = True
        End Try
    End Sub

    Private Sub SaveData_RetRateTerminationStatus(ByRef query As ArrayList)
        Dim info As Boolean = False
        'Dim cTerminationTypeFld As String
        Try
            With Me.GridRetStatView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Admin KPI Parameters - Retention Rate Termination Status", 10, System.Environment.MachineName, .GetRowCellValue(i, "Name"), FormName)

                        'cTerminationTypeFld = ""
                        'If .GetRowCellValue(i, "TerminationType") = TerminationType.BeneficiaryCode Then
                        '    cTerminationTypeFld = TerminationType.BeneficiaryStatField
                        'ElseIf .GetRowCellValue(i, "TerminationType") = TerminationType.BeneficiaryCode Then
                        '    cTerminationTypeFld = TerminationType.UnavoidableStatField
                        'End If
                        'query.Add("UPDATE dbo.tbladmstat " & _
                        '          "SET RetentionRateTermination = " & IIf(.GetRowCellValue(i, "RetentionRateTermination"), 1, 0) & " " & _
                        '          IIf(cTerminationTypeFld.Length > 0, ", " & cTerminationTypeFld & " = 1 ", "") & _
                        '          "WHERE PKey = '" & .GetRowCellValue(i, "PKey") & "'")

                        query.Add("UPDATE dbo.tbladmstat " & _
                                  "SET  RetentionRateTermination = " & IIf(.GetRowCellValue(i, "RetentionRateTermination"), 1, 0) & ", " & _
                                  "     RetentionRateTerminationType = " & IIf(.GetRowCellValue(i, "TerminationType") = TerminationType.NotApplicableCode, "Null", "'" & .GetRowCellValue(i, "TerminationType") & "'") & " " & _
                                  "WHERE PKey = '" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                Next

            End With
        Catch ex As Exception
            LogErrors("Failed to initialize save query list for KPI Activity Status Parameters - Retention Rate Termination Status")
            LogErrors("Error : " & ex.Message)
            MsgBox("Failed to initialize save query list for KPI Activity Status Parameters - Retention Rate Termination Status" & Chr(13) & Chr(13) & "Error : " & ex.Message, MsgBoxStyle.Exclamation, "KPI - Activity Status")
            SaveDataSubHasError = True
        End Try
    End Sub

#End Region

#Region "Grid And Repository Events"
#Region "Grid Events"
    Private Sub GridStatusView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridStatusView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub GridRetStatView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridRetStatView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub GridStatusView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridStatusView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub GridRetStatView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridRetStatView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub GridRetStatView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridRetStatView.RowCellStyle
        If e.Column.FieldName = "RetentionRateTermination" Or e.Column.FieldName = "TerminationType" Then
            e.Appearance.BackColor = REQUIRED_COLOR
        End If
    End Sub

    Private Sub GridRetStatView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridRetStatView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim gCol As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyDocument")

        With view
            'Validate Count as Termination
            If (.GetRowCellValue(e.RowHandle, "TerminationType") = TerminationType.BeneficiaryCode Or .GetRowCellValue(e.RowHandle, "TerminationType") = TerminationType.UnavoidableCode) _
                And Not .GetRowCellValue(e.RowHandle, "RetentionRateTermination") Then
                gCol = view.Columns("RetentionRateTermination")
                .SetColumnError(gCol, "Must be set to ""Count as Termination"" if a Termination Type is specified.")
                e.Valid = False
            Else
                .SetColumnError(gCol, "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                BRECORDUPDATEDs = True
            End If
        End With
    End Sub
#End Region

#Region "Repository Events"
    Private Sub repAdmStat_EditValueChanged(sender As Object, e As System.EventArgs) Handles repAdmStat.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        'Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        'Dim value As Object = row("StatType")
        GridStatusView.SetRowCellValue(GridStatusView.FocusedRowHandle, "StatType", editor.GetColumnValue("StatType"))
    End Sub

    Private Sub repAdmStat_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles repAdmStat.EditValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub repAdmStat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles repAdmStat.KeyDown
        If e.KeyCode = Keys.Delete Then
            CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = vbNull
        End If
    End Sub

    Private Sub repRetTerminationType_EditValueChanged(sender As Object, e As System.EventArgs) Handles repRetTerminationType.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)

        Select Case editor.GetColumnValue("PKey")
            Case TerminationType.NotApplicableCode
                GridRetStatView.SetRowCellValue(GridRetStatView.FocusedRowHandle, "RetentionRateTermination", False)
            Case TerminationType.BeneficiaryCode, TerminationType.UnavoidableCode
                GridRetStatView.SetRowCellValue(GridRetStatView.FocusedRowHandle, "RetentionRateTermination", True)
        End Select
    End Sub

    Private Sub repRetTermination_EditValueChanged(sender As Object, e As System.EventArgs) Handles repRetTermination.EditValueChanged
        Dim editor As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
        If Not editor.Checked Then
            GridRetStatView.SetRowCellValue(GridRetStatView.FocusedRowHandle, "TerminationType", TerminationType.NotApplicableCode)
        End If
    End Sub

    Private Sub repRetTerminationType_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles repRetTerminationType.KeyDown
        If e.KeyCode = Keys.Delete Then
            CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = vbNull
        End If
    End Sub
#End Region

#End Region

    Private Sub TabAdmKPI_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabAdmKPI.SelectedPageChanged
        RefreshData()
    End Sub

    Private Sub GridStatusView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridStatusView.RowCellStyle
        If e.Column.FieldName = "CriteriaFieldValue" Or e.Column.FieldName = "StatType" Then
            e.Appearance.BackColor = REQUIRED_COLOR
        End If
    End Sub
End Class
