Imports DevExpress.XtraGrid.Columns
Imports Reports
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI

Imports DevExpress.XtraReports.Parameters

Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class Audit

    Const MPS = 0
    Dim clsA As New clsAudit
    Dim clsSec As New clsSecurity
    Dim iRecBatch As Integer = 0
    Dim CURRENT_BATCH_INDEX As Integer

    Dim MainReport As rptAudit
    Dim MainReport_NoSub As rptAudit_NoSub
    Dim childReport As rptAudit_sub

    Dim dtParentReport As New DataTable, dtChildReport As New DataTable

    Dim ctempconnstr As String = ""

    Dim ccrewid As String = "<NOCRITERIA>", ccrewname As String = "<NOCRITERIA>",
             cupdatedby As String = "<NOCRITERIA>",
             ddatefrom As Date = Nothing, ddateto As Date = Nothing,
             cscreen As String = "<NOCRITERIA>", smodulecode As String = Nothing,
             irecordstart As Long = 1, irowcount As Long = 25  'imodulecode As Integer = MPS,

    '//// for report
    Dim r_ccrewid As String = "<NOCRITERIA>", r_ccrewname As String = "<NOCRITERIA>",
               r_cupdatedby As String = "<NOCRITERIA>",
               r_ddatefrom As Date = Nothing, r_ddateto As Date = Nothing,
               r_cscreen As String = "<NOCRITERIA>", r_smodulecode As String = Nothing

    Dim iRecRetCnt As Long = 0

    Dim clsgridflout As New clsGridFlyOut

    Private Sub Audit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Me.txtRecCount.EditValue = 25
    End Sub

    Private Sub initControls()
        GridViewDetails.Columns("flddesc").FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        GridViewDetails.ActiveFilterString = "flddesc <> 'dateupdated' and flddesc <> 'lastupdatedby'"
        'Dim dt As New DataTable

        'clsSec.get_any_fr_db("select name from MSysSec_Users where Name <> 'Administrator'", dt)
        'Me.txtUpdatedBy.Properties.DataSource = dt
    End Sub

    Public Overrides Sub RefreshData()
        ' MyBase.RefreshData()
        Me.txtCrew.EditValue = Nothing
        Me.txtCrewName.EditValue = Nothing

        Dim dt As New DataTable

        clsSec.propSQLConnStr = DB.GetConnectionString
        clsSec.get_any_fr_db("select name from MSysSec_Users", dt)
        Me.txtUpdatedBy.Properties.DataSource = dt
        Me.txtUpdatedBy.EditValue = Nothing
        Me.dteStart.EditValue = DateAdd(DateInterval.Day, -5, Date.Today)
        Me.dteEnd.EditValue = Date.Today
        Me.txtScreen.EditValue = Nothing
        Me.txtRecCount.EditValue = 25

        'SetAuditRefreshVisibility(Name, True)
    End Sub

    Function isPrepInputs() As Boolean

        Try

            If Not txtCrew.EditValue Is Nothing Then
                ccrewid = txtCrew.EditValue
            Else
                ccrewid = Nothing
            End If

            If Not txtCrewName.EditValue Is Nothing Then
                ccrewname = txtCrewName.EditValue
            Else
                ccrewname = Nothing
            End If

            If Not txtUpdatedBy.EditValue Is Nothing Then
                cupdatedby = txtUpdatedBy.EditValue
            Else
                cupdatedby = Nothing
            End If

            If Not dteStart.EditValue Is Nothing Then
                ddatefrom = dteStart.EditValue
            Else
                ddatefrom = DateAdd(DateInterval.Day, -5, Date.Today)
            End If

            If Not dteEnd.EditValue Is Nothing Then
                ddateto = dteEnd.EditValue
            Else
                ddateto = Date.Today
            End If

            If Not Me.cboAppMod.EditValue Is Nothing Then
                smodulecode = cboAppMod.EditValue
            Else
                smodulecode = Nothing
            End If

            'If txtRecCount.EditValue Is Nothing Then
            irowcount = txtRecCount.EditValue
            'End If

            Return True
        Catch
            Return False
        End Try
    End Function

    Public Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click

        'Call resetBar()
        '' iRecBatch = 0

        'If isPrepInputs() Then
        '    iRecBatch = 1
        '    If RefreshGrid(iRecRetCnt, ccrewid, ccrewname, cupdatedby, ddatefrom, ddateto,
        '                   cscreen, smodulecode, iRecBatch - 1, irowcount, , True) Then
        '    End If
        'End If

        'If iRecRetCnt = 0 Then
        '    Me.lblOf.Text = "of 0"
        'ElseIf iRecRetCnt < irowcount Then
        '    Me.lblOf.Text = "of " & iRecBatch
        '    '    Me.btnNext.Enabled = False
        '    '    Me.btnPrevious.Enabled = False
        '    'Else
        '    '    Me.btnNext.Enabled = True
        '    '    Me.btnPrevious.Enabled = True
        'End If

        ''If iRecRetCnt > 0 Then
        'Call setBarButtons(irowcount, iRecBatch, iRecRetCnt)

        'If iRecRetCnt > 0 Then
        '    Me.txtCurrentBatch.EditValue = iRecBatch
        'Else
        '    Me.txtCurrentBatch.EditValue = 0
        'End If
        '' End If

        Call DataRefresh()
    End Sub

    Public Overrides Sub DataRefresh()
        Call resetBar()
        ' iRecBatch = 0

        If isPrepInputs() Then
            iRecBatch = 1
            If RefreshGrid(iRecRetCnt, ccrewid, ccrewname, cupdatedby, ddatefrom, ddateto,
                           cscreen, smodulecode, iRecBatch - 1, irowcount, , True) Then
            End If
        End If

        If iRecRetCnt = 0 Then
            Me.lblOf.Text = "of 0"
        ElseIf iRecRetCnt < irowcount Then
            Me.lblOf.Text = "of " & iRecBatch
            '    Me.btnNext.Enabled = False
            '    Me.btnPrevious.Enabled = False
            'Else
            '    Me.btnNext.Enabled = True
            '    Me.btnPrevious.Enabled = True
        End If

        'If iRecRetCnt > 0 Then
        Call setBarButtons(irowcount, iRecBatch, iRecRetCnt)

        If iRecRetCnt > 0 Then
            Me.txtCurrentBatch.EditValue = iRecBatch
        Else
            Me.txtCurrentBatch.EditValue = 0
        End If
        ' End If
    End Sub


    Function RefreshGrid(ByRef iRecRetCnt As Long, Optional p_ccrewid As String = "<NOCRITERIA>", Optional p_ccrewname As String = "<NOCRITERIA>",
                         Optional p_cupdatedby As String = "<NOCRITERIA>", Optional p_ddatefrom As Date = Nothing,
                         Optional p_ddateto As Date = Nothing, Optional p_cscreen As String = "<NOCRITERIA>",
                         Optional p_smoduleName As String = Nothing, Optional p_irecordstart As Long = 0,
                         Optional p_irowcount As Long = 25, Optional exmsg As String = "", Optional btnApplyClick As Boolean = False) As Boolean

        Dim ret As Boolean, r_imodulecode As Integer

        Dim dt As New DataTable, cProcRet As String, dtChild As New DataTable, dtParent As New DataTable

        'add your column here
        Dim array() As String = {"AuditLogID", "CrewID", "crewname", "ScreenCaption", "ActionDescrip", "DataDescrip", "RecordName", "UserName", _
                                  "TableName", "PKeyValue", "ComputerName", "ModuleCode", "Dateupdated", "SiteID"}


        If p_ddateto = Nothing Then
            p_ddateto = Now
        End If
        If p_ddatefrom = Nothing Then
            p_ddatefrom = DateAdd(DateInterval.Day, -5, Now)
        End If

        r_imodulecode = getModuleCode(p_smoduleName)

        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(WaitForm1))

        Try
            ctempconnstr = Replace(DB.GetConnectionString, "Database=MPS", "Database=MPS4A")

            clsA.propSQLConnStr = ctempconnstr
            cProcRet = clsA.getAuditData(dt, p_ccrewid, p_ccrewname, p_cupdatedby, p_ddatefrom, p_ddateto, p_cscreen, r_imodulecode, p_irecordstart, p_irowcount)
            If cProcRet = "" Then
                If dt.Rows.Count > 0 Then
                    Me.GridAudit.DataSource = Nothing
                    'Me.GridAudit.DataSource = dt


                    '///////////////////// TEST
                    dtChild = dt.Copy '.Select("FieldName <> 'dateupdated' and FieldName <> 'lastupdatedby'")

                    'remove columns not needed for parent table
                    dt.Columns.Remove("flddesc")
                    dt.Columns.Remove("OldValue")
                    dt.Columns.Remove("NewValue")

                    'remove columns not needed for child table
                    dtChild.Columns.Remove("CrewID")
                    dtChild.Columns.Remove("crewname")
                    dtChild.Columns.Remove("DataDescrip")
                    dtChild.Columns.Remove("ScreenCaption")
                    dtChild.Columns.Remove("ActionDescrip")
                    dtChild.Columns.Remove("UserName")
                    dtChild.Columns.Remove("TableName")
                    dtChild.Columns.Remove("ComputerName")
                    dtChild.Columns.Remove("ModuleCode")
                    dtChild.Columns.Remove("Dateupdated")
                    dtChild.Columns.Remove("SiteID")
                    dtChild.Columns.Remove("refTable")
                    dtChild.Columns.Remove("OldValue")
                    dtChild.Columns.Remove("NewValue")
                    dtChild.Columns.Remove("AuditDetailID")
                    dtChild.Columns.Remove("RecordName")
                    dtChild.Columns.Remove("PKeyValue")
                    dtChild.Columns.Remove("PKeyField")

                    dtChild.Columns("OldValueName").Caption = "Old Value"
                    dtChild.Columns("NewValueName").Caption = "New Value"
                    dtChild.Columns("flddesc").Caption = "Field"

                    dtParent = dt.DefaultView.ToTable(True, array) 'select distinct records
                    iRecRetCnt = dtParent.Rows.Count

                    Dim parentColumn As DataColumn = dtParent.Columns("AuditLogID")
                    Dim childColumn As DataColumn = dtChild.Columns("AuditLogID")

                    Dim ds As New DataSet

                    'Dim dv As DataView
                    'dv = dtChild.DefaultView
                    'dv.RowFilter = "[Fieldname] <> 'lastupdatedby'"

                    'Dim dtchild2 As DataTable
                    'dtchild2 = dv.ToTable
                    ds.Tables.Add(dtParent)
                    ds.Tables.Add(dtChild)

                    'ds.Tables(2).DefaultView.RowFilter = "Field <> 'Lastupdatedby'"

                    Dim drRelate As DataRelation

                    drRelate = New DataRelation("Log Details", parentColumn, childColumn)

                    ds.Relations.Add(drRelate)

                    Me.GridAudit.DataSource = dtParent 'ds.Tables(dttest.TableName)
                    ' Me.GridAudit.ForceInitialize()

                    'GridViewDetails.Columns("FieldName").FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
                    'GridViewDetails.ActiveFilterString = "Field <> 'dateupdated' and Field <> 'lastupdatedby'"

                    'GridViewDetails.Columns("[Field]").FilterInfo = New ColumnFilterInfo("[Field] <> 'dateupdated' and [Field] <> 'lastupdatedby'")

                    'GridViewDetails.Columns("Field").FilterInfo = New ColumnFilterInfo("FieldName <> 'dateupdated' and FieldName <> 'lastupdatedby'")

                    Me.GridViewLog.Columns("AuditLogID").Visible = False
                    Me.GridViewDetails.Columns("AuditLogID").Visible = False
                    'Me.GridViewDetails.PopulateColumns(dtCopy)
                    'Me.GridViewDetails.Columns("AuditLogID").Visible = False

                    Me.GridViewLog.BestFitColumns()
                    '//////////////////////////

                    '/// For Report
                    'dtParentReport.Clear()
                    'dtChildReport.Clear()
                    dtParentReport = Nothing
                    dtChildReport = Nothing
                    dtParentReport = dtParent
                    dtChildReport = dtChild

                Else
                    MsgBox("End of Record/No Record(s) found", MsgBoxStyle.Information, GetAppName)

                    ''/// For Report
                    ''dtParentReport.Clear()
                    ''dtChildReport.Clear()
                    'dtParentReport = Nothing
                    'dtChildReport = Nothing

                    If btnApplyClick Then
                        Me.GridAudit.DataSource = Nothing
                    End If
                    iRecRetCnt = 0
                End If
            Else
                ' MsgBox("Error: " & cProcRet)
            End If

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
            ret = True
        Catch ex As Exception
            'DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm() Then

            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
            exmsg = ex.Message
            ret = False
        End Try
        Return ret
    End Function

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        Dim iRecRetCnt As Long

        'If isPrepInputs() Then
        iRecBatch = iRecBatch + 1
        If RefreshGrid(iRecRetCnt, ccrewid, ccrewname, cupdatedby, ddatefrom, ddateto,
                       cscreen, smodulecode, ((iRecBatch * irowcount) - (irowcount - 1)) - 1, irowcount) Then
        End If
        'End If

        If iRecRetCnt < irowcount And iRecRetCnt <> 0 Then
            '    Me.btnNext.Enabled = False
            ' Me.layCurrentBatch.Text = "of " & iRecBatch
            Me.lblOf.Text = "of " & iRecBatch
        ElseIf iRecRetCnt = 0 Then
            'Me.btnNext.Enabled = True
            iRecBatch = iRecBatch - 1
            'Me.layCurrentBatch.Text = "of " & iRecBatch
            Me.lblOf.Text = "of " & iRecBatch
        End If


        'If iRecBatch <= 1 Then
        '    Me.btnPrevious.Enabled = False
        'Else
        '    Me.btnPrevious.Enabled = True
        'End If

        Call setBarButtons(irowcount, iRecBatch, iRecRetCnt)

        Me.txtCurrentBatch.EditValue = iRecBatch
    End Sub

    Private Sub btnPrevious_Click(sender As System.Object, e As System.EventArgs) Handles btnPrevious.Click
        Dim iRecRetCnt As Long

        'If isPrepInputs() Then
        If iRecBatch > 1 Then
            iRecBatch = iRecBatch - 1
        End If
        If RefreshGrid(iRecRetCnt, ccrewid, ccrewname, cupdatedby, ddatefrom, ddateto,
                       cscreen, smodulecode, ((iRecBatch * irowcount) - (irowcount - 1)) - 1, irowcount) Then
        End If
        'End If

        'Me.btnNext.Enabled = True


        'If iRecRetCnt < irowcount Then
        '    Me.btnNext.Enabled = False
        'Else
        '    Me.btnNext.Enabled = True
        'End If

        'If iRecBatch <= 1 Or irowcount = 0 Then
        '    Me.btnPrevious.Enabled = False
        'Else
        '    Me.btnPrevious.Enabled = True
        'End If

        Call setBarButtons(irowcount, iRecBatch, iRecRetCnt)
        Me.txtCurrentBatch.EditValue = iRecBatch
    End Sub


    Private Sub GridViewLog_MasterRowExpanded(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles GridViewLog.MasterRowExpanded
        Dim gridvmaster As DevExpress.XtraGrid.Views.Grid.GridView = sender
        Dim griddetail As DevExpress.XtraGrid.Views.Grid.GridView = gridvmaster.GetDetailView(e.RowHandle, e.RelationIndex)
        griddetail.OptionsView.ColumnAutoWidth = False
        griddetail.BestFitColumns()

        griddetail.Columns("AuditLogID").Visible = False

        griddetail.ActiveFilterString = "[flddesc] != 'LastupdatedBy' and [flddesc] != 'DateUpdated' and [flddesc] is not null"
        griddetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        griddetail.OptionsView.ShowFooter = False
        griddetail.BestFitColumns()

    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        'Me.txtCrew.EditValue = Nothing
        'Me.txtCrewName.EditValue = Nothing
        'Me.txtUpdatedBy.EditValue = Nothing
        'Me.dteStart.EditValue = DateAdd(DateInterval.Day, -5, Now)
        'Me.dteEnd.EditValue = Date.Today
        'Me.txtScreen.EditValue = Nothing
        'Me.txtRecCount.EditValue = 25
        Call RefreshData()
    End Sub

    Sub resetBar()
        Me.iRecBatch = 0
        'Me.layCurrentBatch.Text = "of ..."
        Me.lblOf.Text = "of ..."
        Me.txtCurrentBatch.EditValue = 0
    End Sub

    Sub setBarButtons(iBatchRecCount As Integer, ibatchNo As Integer, iDBReturnRowCount As Integer, Optional ByVal itotalBatchNo As Integer = 0)

        Me.btnNext.Enabled = False
        Me.btnPrevious.Enabled = False

        If iDBReturnRowCount < iBatchRecCount Then
            Me.btnNext.Enabled = False
        Else
            Me.btnNext.Enabled = True
        End If

        If ibatchNo > 1 Then
            Me.btnPrevious.Enabled = True
        Else
            Me.btnPrevious.Enabled = False
        End If


    End Sub

    Private Sub txtCurrentBatch_Validated(sender As Object, e As System.EventArgs) Handles txtCurrentBatch.Validated
        'Dim tempCurrBatch As Integer

        'tempCurrBatch = Me.txtCurrentBatch.EditValue

        'If tempCurrBatch <> 0 Then

        '    If isPrepInputs() Then
        '        If RefreshGrid(iRecRetCnt, ccrewid, ccrewname, cupdatedby, ddatefrom, ddateto,
        '                       cscreen, , (tempCurrBatch * irowcount) - (irowcount - 1), irowcount) Then
        '        End If
        '    End If


        '    'possible record count return: 0 / < irowcount / = irowcount,
        '    'possible entered batch number: 0 / > total batch count(w/c could be known or not yet) / < total batch 

        '    If iRecRetCnt < irowcount And iRecRetCnt <> 0 Then
        '        Me.lblOf.Text = "of " & tempCurrBatch
        '        iRecBatch = tempCurrBatch 'set global var
        '    ElseIf iRecRetCnt = 0 Then '0 means end of record or no record at all
        '        If tempCurrBatch = 1 Then
        '            iRecBatch = 0
        '            Me.lblOf.Text = "of 0"
        '        Else
        '            Me.lblOf.Text = "of " & iRecBatch
        '        End If
        '    ElseIf iRecRetCnt = irowcount Then
        '        iRecBatch = tempCurrBatch 'set global var
        '    End If

        '    If iRecRetCnt > 1 Then
        '        Call setBarButtons(irowcount, tempCurrBatch, iRecRetCnt)
        '    End If

        'End If
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



    Private Sub GridViewLog_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridViewLog.RowCellStyle
        Call rowcellStyle(Me.GridViewLog, e)
    End Sub

    Private Sub GridViewDetails_MasterRowExpanding(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs) Handles GridViewDetails.MasterRowExpanding
        MsgBox("test")
    End Sub

    Private Sub GridViewDetails_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridViewDetails.RowCellStyle
        Call rowcellStyle(Me.GridViewDetails, e)
    End Sub

    Private Sub txtCurrentBatch_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCurrentBatch.KeyUp
        'MsgBox(e.KeyCode)
        If e.KeyCode = Keys.Enter Then
            Dim tempCurrBatch As Integer

            tempCurrBatch = Me.txtCurrentBatch.EditValue

            If tempCurrBatch <> 0 Then

                If isPrepInputs() Then
                    If RefreshGrid(iRecRetCnt, ccrewid, ccrewname, cupdatedby, ddatefrom, ddateto,
                                   cscreen, , (tempCurrBatch * irowcount) - (irowcount - 1) - 1, irowcount) Then
                    End If
                End If


                'possible record count return: 0 / < irowcount / = irowcount,
                'possible entered batch number: 0 / > total batch count(w/c could be known or not yet) / < total batch 

                If iRecRetCnt < irowcount And iRecRetCnt <> 0 Then
                    ' Me.lblOf.Text = "of " & tempCurrBatch
                    iRecBatch = tempCurrBatch 'set global var
                ElseIf iRecRetCnt = 0 Then '0 means end of record or no record at all
                    If tempCurrBatch = 1 Then
                        iRecBatch = 0
                        ' Me.lblOf.Text = "of 0"
                    Else
                        ' Me.lblOf.Text = "of " & iRecBatch
                    End If
                ElseIf iRecRetCnt = irowcount Then
                    iRecBatch = tempCurrBatch 'set global var
                End If

                If iRecRetCnt > 1 Then
                    Call setBarButtons(irowcount, tempCurrBatch, iRecRetCnt)
                End If

            End If
        End If
    End Sub

    Private Sub txtUpdatedBy_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtUpdatedBy.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
            Me.txtUpdatedBy.EditValue = Nothing
        End If
    End Sub


    Private Sub txtRecCount_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtRecCount.KeyUp
        If e.KeyCode = Keys.Enter Then
            Call btnApply_Click(sender, e)
        End If
    End Sub

    Private Sub cboAppMod_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboAppMod.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
            Me.cboAppMod.EditValue = Nothing
        End If
    End Sub

    Function getModuleCode(AppModName As String) As Integer

        Dim r_imodulecode As Integer = 1001

        Select Case AppModName
            Case "Crewing"
                r_imodulecode = 0
            Case "Admin"
                r_imodulecode = 10
            Case Nothing
                r_imodulecode = 999
        End Select

        Return r_imodulecode
    End Function



    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Dim ermsg As String = ""
        Select Case param(0)
            Case "PREVIEWREPORT"
                ' MsgBox(param(1))
                If param(1) = True Then 'with details
                    If isPrepInputs_rpt() Then
                        If GenerateRPTData(r_ccrewid, r_ccrewname, r_cupdatedby, r_ddatefrom, r_ddateto,
                               r_cscreen, r_smodulecode, , , ermsg, 1) Then
                            Call viewReport(dtParentReport, dtChildReport)
                        Else
                            MsgBox(ermsg)
                        End If
                    End If
                ElseIf param(1) = False Then
                    If isPrepInputs_rpt() Then
                        If GenerateRPTData(r_ccrewid, r_ccrewname, r_cupdatedby, r_ddatefrom, r_ddateto,
                               r_cscreen, r_smodulecode, , , ermsg, 1) Then
                            Call viewReport(dtParentReport)
                        Else
                            MsgBox(ermsg)
                        End If
                    End If
                End If

        End Select
    End Sub

    '/////////////////////////////////////////////// FOR REPORT //////////////////////////////////////
#Region "REPORT"
    Function isPrepInputs_rpt() As Boolean

        Try

            If Not txtCrew.EditValue Is Nothing Then
                r_ccrewid = txtCrew.EditValue
            Else
                r_ccrewid = Nothing
            End If

            If Not txtCrewName.EditValue Is Nothing Then
                r_ccrewname = txtCrewName.EditValue
            Else
                r_ccrewname = Nothing
            End If

            If Not txtUpdatedBy.EditValue Is Nothing Then
                r_cupdatedby = txtUpdatedBy.EditValue
            Else
                r_cupdatedby = Nothing
            End If

            If Not dteStart.EditValue Is Nothing Then
                r_ddatefrom = dteStart.EditValue
            Else
                r_ddatefrom = "01-jan-1990"
            End If

            If Not dteEnd.EditValue Is Nothing Then
                r_ddateto = dteEnd.EditValue
            Else
                r_ddateto = Date.Today
            End If

            If Not Me.cboAppMod.EditValue Is Nothing Then
                r_smodulecode = cboAppMod.EditValue
            Else
                r_smodulecode = Nothing
            End If

            irowcount = txtRecCount.EditValue

            Return True
        Catch
            Return False
        End Try
    End Function

    Function GenerateRPTData(Optional p_ccrewid As String = "<NOCRITERIA>", Optional p_ccrewname As String = "<NOCRITERIA>",
                       Optional p_cupdatedby As String = "<NOCRITERIA>", Optional p_ddatefrom As Date = Nothing,
                       Optional p_ddateto As Date = Nothing, Optional p_cscreen As String = "<NOCRITERIA>",
                       Optional p_smoduleName As String = Nothing, Optional p_irecordstart As Long = 0,
                       Optional p_irowcount As Long = 25, Optional ByRef exmsg As String = "", Optional p_byPassRecCnt As Integer = 0) As Boolean

        Dim ret As Boolean, r_imodulecode As Integer

        Dim dt As New DataTable, cProcRet As String, dtChild As New DataTable, dtParent As New DataTable

        'add your column here
        Dim array() As String = {"AuditLogID", "CrewID", "crewname", "ScreenCaption", "ActionDescrip", "DataDescrip", "RecordName", "UserName", _
                                  "TableName", "PKeyValue", "ComputerName", "ModuleCode", "Dateupdated", "SiteID", "AuditDetailID"}
        'Dim ctempconnstr As String

        'If p_ddateto = Nothing Then
        '    p_ddateto = Now
        'End If
        'If p_ddatefrom = Nothing Then
        '    'p_ddatefrom = DateAdd(DateInterval.Day, -5, Now)
        '    p_ddatefrom = "01-jan-1990"
        'End If

        r_imodulecode = getModuleCode(p_smoduleName)

        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(WaitForm1))

        Try
            If ctempconnstr = "" Then
                ctempconnstr = Replace(DB.GetConnectionString, "Database=MPS", "Database=MPS4A")
                clsA.propSQLConnStr = ctempconnstr
            End If
            cProcRet = clsA.getAuditData(dt, p_ccrewid, p_ccrewname, p_cupdatedby, p_ddatefrom, p_ddateto, p_cscreen, r_imodulecode, p_irecordstart, p_irowcount, p_byPassRecCnt)
            If cProcRet = "" Then
                If dt.Rows.Count > 0 Then
                    'Me.GridAudit.DataSource = Nothing

                    '///////////////////// TEST
                    dtChild = dt.Copy '.Select("FieldName <> 'dateupdated' and FieldName <> 'lastupdatedby'")

                    'remove columns not needed for parent table
                    dt.Columns.Remove("flddesc")
                    dt.Columns.Remove("OldValue")
                    dt.Columns.Remove("NewValue")

                    'remove columns not needed for child table
                    dtChild.Columns.Remove("CrewID")
                    dtChild.Columns.Remove("crewname")
                    dtChild.Columns.Remove("DataDescrip")
                    dtChild.Columns.Remove("ScreenCaption")
                    dtChild.Columns.Remove("ActionDescrip")
                    dtChild.Columns.Remove("UserName")
                    dtChild.Columns.Remove("TableName")
                    dtChild.Columns.Remove("ComputerName")
                    dtChild.Columns.Remove("ModuleCode")
                    dtChild.Columns.Remove("Dateupdated")
                    dtChild.Columns.Remove("SiteID")
                    dtChild.Columns.Remove("refTable")
                    dtChild.Columns.Remove("OldValue")
                    dtChild.Columns.Remove("NewValue")
                    dtChild.Columns.Remove("AuditDetailID")
                    dtChild.Columns.Remove("RecordName")
                    dtChild.Columns.Remove("PKeyValue")
                    dtChild.Columns.Remove("PKeyField")

                    dtChild.Columns("OldValueName").Caption = "Old Value"
                    dtChild.Columns("NewValueName").Caption = "New Value"
                    dtChild.Columns("flddesc").Caption = "Field"

                    dtParent = dt.DefaultView.ToTable(True, array) 'select distinct records
                    'iRecRetCnt = dtParent.Rows.Count

                    Dim parentColumn As DataColumn = dtParent.Columns("AuditLogID")
                    Dim childColumn As DataColumn = dtChild.Columns("AuditLogID")

                    Dim ds As New DataSet

                    ds.Tables.Add(dtParent)
                    ds.Tables.Add(dtChild)

                    'Dim drRelate As DataRelation

                    'drRelate = New DataRelation("Log Details", parentColumn, childColumn)

                    'ds.Relations.Add(drRelate)

                    'Me.GridAudit.DataSource = dtParent 'ds.Tables(dttest.TableName)


                    'Me.GridViewLog.Columns("AuditLogID").Visible = False
                    'Me.GridViewDetails.Columns("AuditLogID").Visible = False

                    'Me.GridViewLog.BestFitColumns()
                    '//////////////////////////

                    '/// For Report
                    'dtParentReport.Clear()
                    'dtChildReport.Clear()
                    dtParentReport = Nothing
                    dtChildReport = Nothing
                    dtParentReport = dtParent
                    dtChildReport = dtChild

                Else
                    'MsgBox("End of Record/No Record(s) found", MsgBoxStyle.Information, GetAppName)
                    'MsgBox(cProcRet, MsgBoxStyle.Exclamation, GetAppName)
                    'dtParentReport.Clear()
                    'dtChildReport.Clear()
                    dtParentReport = Nothing
                    dtChildReport = Nothing

                    'If btnApplyClick Then
                    '    Me.GridAudit.DataSource = Nothing
                    'End If
                    'iRecRetCnt = 0
                End If
            Else
                ' MsgBox("Error: " & cProcRet)
                MsgBox(cProcRet, MsgBoxStyle.Exclamation, GetAppName)
                dtParentReport = Nothing
                dtChildReport = Nothing
            End If

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
            ret = True
        Catch ex As Exception
            'DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm() Then

            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
            exmsg = ex.Message
            ret = False
        End Try

        Return ret
    End Function

    Sub viewReport(parentDt As DataTable, childDt As DataTable)

        Dim prv As New AuditReportViewer

        'Dim childReport As New rptAudit_sub
        childReport = New rptAudit_sub
        MainReport = New rptAudit

        Dim repPrintTool As New DevExpress.XtraReports.UI.ReportPrintTool(MainReport)

        If Not parentDt Is Nothing Then
            If parentDt.Rows.Count = 0 Then
                MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
                Exit Sub
            End If
        Else
            MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
            Exit Sub
        End If

        MainReport.subrep.ReportSource = childReport
        MainReport.txtCompany.Text = DB.GetConfig("NAME")
        MainReport.txtCoyAdd.Text = DB.GetConfig("ADDR")

        MainReport.DataSource = parentDt

        With MainReport
            Reports.basReports.BindData(.celSeamanID, "Text", Nothing, "CrewID")
            Reports.basReports.BindData(.celSeamanName, "Text", Nothing, "crewname")
            Reports.basReports.BindData(.celScreenCaption, "Text", Nothing, "ScreenCaption")
            Reports.basReports.BindData(.celAction, "Text", Nothing, "ActionDescrip")
            Reports.basReports.BindData(.celDescription, "Text", Nothing, "DataDescrip")
            Reports.basReports.BindData(.celRecordKeyword, "Text", Nothing, "RecordName")
            Reports.basReports.BindData(.celDateUpdated, "Text", Nothing, "Dateupdated", "{0:dd-MMM-yyyy}")
            Reports.basReports.BindData(.celUsername, "Text", Nothing, "UserName")
            Reports.basReports.BindData(.celComputerName, "Text", Nothing, "ComputerName")
            Reports.basReports.BindData(.celAuditLogID, "Text", Nothing, "AuditLogID")
            Reports.basReports.BindData(.celAuditDetailID, "Text", Nothing, "AuditDetailID")

            .lblDates.Text = assemblefltrDates(r_ddatefrom, r_ddateto)
            .lblFilter.Text = assemblefltrString(r_cupdatedby, r_ccrewname, r_smodulecode)

            AddHandler .Detail.BeforePrint, AddressOf mainDetailBand_BeforePrint
        End With

        childReport.DataSource = childDt

        With childReport
            Reports.basReports.BindData(.celField, "Text", Nothing, "flddesc")
            Reports.basReports.BindData(.celNewValue, "Text", Nothing, "NewValueName")
            Reports.basReports.BindData(.celOldValue, "Text", Nothing, "OldValueName")
            Reports.basReports.BindData(.celAuditLogID, "Text", Nothing, "AuditLogID")
            'AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
        End With

        prv.DocumentViewer1.DocumentSource = MainReport


        prv.ShowDialog()

        prv = Nothing


    End Sub

    Sub viewReport(parentDt As DataTable)

        Dim prv As New AuditReportViewer
        'Dim childReport As New rptAudit_sub

        MainReport_NoSub = New rptAudit_NoSub

        Dim repPrintTool As New DevExpress.XtraReports.UI.ReportPrintTool(MainReport_NoSub)

        If Not parentDt Is Nothing Then
            If parentDt.Rows.Count = 0 Then
                MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
                Exit Sub
            End If
        Else
            MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
            Exit Sub
        End If

        MainReport_NoSub.DataSource = parentDt
        MainReport_NoSub.txtCompany.Text = DB.GetConfig("NAME")
        MainReport_NoSub.txtCoyAdd.Text = DB.GetConfig("ADDR")

        With MainReport_NoSub
            Reports.basReports.BindData(.celSeamanID, "Text", Nothing, "CrewID")
            Reports.basReports.BindData(.celSeamanName, "Text", Nothing, "crewname")
            Reports.basReports.BindData(.celScreenCaption, "Text", Nothing, "ScreenCaption")
            Reports.basReports.BindData(.celAction, "Text", Nothing, "ActionDescrip")
            Reports.basReports.BindData(.celDescription, "Text", Nothing, "DataDescrip")
            Reports.basReports.BindData(.celRecordKeyword, "Text", Nothing, "RecordName")
            Reports.basReports.BindData(.celDateUpdated, "Text", Nothing, "Dateupdated", "{0:dd-MMM-yyyy}")
            Reports.basReports.BindData(.celUsername, "Text", Nothing, "UserName")
            Reports.basReports.BindData(.celComputerName, "Text", Nothing, "ComputerName")
            Reports.basReports.BindData(.celAuditLogID, "Text", Nothing, "AuditLogID")

            .lblDates.Text = assemblefltrDates(r_ddatefrom, r_ddateto)
            .lblFilter.Text = assemblefltrString(r_cupdatedby, r_ccrewname, r_smodulecode)
        End With

        prv.DocumentViewer1.DocumentSource = MainReport_NoSub


        prv.ShowDialog()

        prv = Nothing


    End Sub

    Private Sub mainDetailBand_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        If MainReport.GetCurrentColumnValue("AuditDetailID").ToString = "" Then
            ' MainReport.tblSubTitle.Visible = False
            'MainReport.tblSubTitle.CanShrink = True
            AddHandler MainReport.XrTableRow3.BeforePrint, AddressOf subtitle_BeforePrint
            AddHandler childReport.BeforePrint, AddressOf subtitle_BeforePrint
        Else
            ' MainReport.tblSubTitle.Visible = True
            AddHandler MainReport.XrTableRow3.BeforePrint, AddressOf subtitle2_BeforePrint
            AddHandler childReport.BeforePrint, AddressOf SetDetailBand_BeforePrint
        End If

    End Sub

    Private Sub subtitle_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        e.Cancel = True
    End Sub
    Private Sub subtitle2_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        e.Cancel = False
    End Sub

    Private Sub SetDetailBand_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString = "AuditLogID='" & MainReport.GetCurrentColumnValue("AuditLogID").ToString & "' and flddesc != 'lastupdatedby' and flddesc != 'DateUpdated' and flddesc is not null"
        If TryCast(sender, DevExpress.XtraReports.UI.XtraReport).RowCount < 1 Then
            '    MainReport.tblSubTitle.Visible = False
        Else
            '    MainReport.tblSubTitle.Visible = True
        End If
        e.Cancel = False
    End Sub

    Function assemblefltrString(Optional fltrby As String = "", Optional seaman As String = "", Optional applicationMod As String = "") As String
        Dim ret As String = ""

        Dim fltstring As String, addquit As Boolean = False, cnt As Integer = 0

        fltstring = "Filtered By: "

        If fltrby <> "" Then
            fltstring = fltstring & "User = ‘" & fltrby & "’"
            addquit = True
            cnt = 1
        End If

        If seaman <> "" Then
            If addquit Then
                fltstring = fltstring & ", "
            End If
            fltstring = fltstring & "Seaman name = '" & seaman & "’"
            addquit = True
            cnt = cnt + 1
        End If

        If applicationMod <> "" Then
            If addquit Then
                fltstring = fltstring & ", "
            End If
            fltstring = fltstring & "Application Module = ‘" & applicationMod & "’"
            cnt = cnt + 1
        End If

        If cnt = 0 Then
            fltstring = fltstring & "None"
        End If

        ret = fltstring

        Return ret
    End Function

    Function assemblefltrDates(Optional p_dtStart As Date = Nothing, Optional p_dtEnd As Date = Nothing) As String
        Dim ret As String = "", tempstr As String = ""

        If IsDate(Me.dteStart.EditValue) And IsDate(Me.dteEnd.EditValue) Then
            tempstr = "from " & Format(p_dtStart, "dd-MMM-yyyy") & " to " & Format(p_dtEnd, "dd-MMM-yyyy")
        End If

        If IsDate(Me.dteStart.EditValue) And Not IsDate(Me.dteEnd.EditValue) Then
            tempstr = "since " & Format(p_dtStart, "dd-MMM-yyyy")
        End If

        If Not IsDate(Me.dteStart.EditValue) And IsDate(Me.dteEnd.EditValue) Then
            tempstr = "until " & Format(p_dtEnd, "dd-MMM-yyyy")
        End If

        ret = tempstr
        Return ret
    End Function

#End Region
    '//////////////////////////////////////////////////////////////////////////////////////////////////

    Private Sub GridAudit_DoubleClick(sender As System.Object, e As System.EventArgs) Handles GridAudit.DoubleClick
        'MsgBox("Sfsdf")

        'Me.GridViewLog.ShowPopupEditForm()
    End Sub

    ' Private Sub GridAudit_Click(sender As System.Object, e As System.EventArgs)
    'GridViewLog.GetShowEditorMode()
    'End Sub

    Private Sub GridAudit_Click_1(sender As System.Object, e As System.EventArgs) Handles GridAudit.Click

    End Sub

    Private Sub GridAudit_MouseHover(sender As Object, e As System.EventArgs) Handles GridAudit.MouseHover

    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If Not e.SelectedControl Is Me.GridAudit Then Return

        Dim info As DevExpress.Utils.ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = Me.GridAudit.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)


        'Display a hint for row indicator cells
        'If hi.HitTest = GridHitTest.RowIndicator Then
        'An object that uniquely identifies a row indicator cell


        Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()

        'Dim text As String = "Row " + hi.RowHandle.ToString()

        Dim temptext As String = ""
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Me.GridViewLog.Columns
            temptext = temptext & col.Caption & " : " & IfNull(Me.GridViewLog.GetRowCellValue(hi.RowHandle, col), "") & vbCrLf
        Next
        Dim text As String = temptext

        'info = New DevExpress.Utils.ToolTipControlInfo(o, text)
        info = New DevExpress.Utils.ToolTipControlInfo(o, text)
        'End If
        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub

    Dim stopnaba As Boolean = False

    Private Sub GridAudit_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles GridAudit.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)

    End Sub

    Private Sub GridAudit_Click(sender As System.Object, e As System.EventArgs) Handles GridAudit.Click
        stopnaba = True
    End Sub

    Private Sub GridViewLog_ShownEditor(sender As Object, e As System.EventArgs) Handles GridViewLog.ShownEditor
        stopnaba = True
    End Sub
End Class
