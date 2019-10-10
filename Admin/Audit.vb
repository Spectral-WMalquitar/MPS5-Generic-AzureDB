Public Class Audit

    Const MPS = 0
    Dim clsA As New clsAudit
    Dim iRecBatch As Integer = 0
    Dim CURRENT_BATCH_INDEX As Integer

    Dim ccrewid As String = "<NOCRITERIA>", ccrewname As String = "<NOCRITERIA>",
             cupdatedby As String = "<NOCRITERIA>",
             ddatefrom As Date = Nothing, ddateto As Date = Nothing,
             cscreen As String = "<NOCRITERIA>", imodulecode As Integer = MPS,
             irecordstart As Long = 1, irowcount As Long = 25
    Dim iRecRetCnt As Long

    Private Sub Audit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Me.txtRecCount.EditValue = 25
    End Sub

    Private Sub initControls()

    End Sub

    Public Overrides Sub RefreshData()
        Me.txtCrew.EditValue = Nothing
        Me.txtCrewName.EditValue = Nothing
        Me.txtUpdatedBy.EditValue = Nothing
        Me.dteStart.EditValue = DateAdd(DateInterval.Day, -5, Now)
        Me.dteEnd.EditValue = Date.Today
        Me.txtScreen.EditValue = Nothing
        Me.txtRecCount.EditValue = 25

    End Sub

    Function isPrepInputs() As Boolean

        Try

            If Not txtCrew.EditValue Is Nothing Then
                ccrewid = txtCrew.EditValue
            End If

            If Not txtCrewName.EditValue Is Nothing Then
                ccrewname = txtCrewName.EditValue
            End If

            If Not txtUpdatedBy.EditValue Is Nothing Then
                cupdatedby = txtUpdatedBy.EditValue
            End If

            If Not dteStart.EditValue Is Nothing Then
                ddatefrom = dteStart.EditValue
            End If

            If Not dteEnd.EditValue Is Nothing Then
                ddateto = dteEnd.EditValue
            End If

            'If txtRecCount.EditValue Is Nothing Then
            irowcount = txtRecCount.EditValue
            'End If

            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click



        Call resetBar()
        ' iRecBatch = 0

        If isPrepInputs() Then
            iRecBatch = 1
            If RefreshGrid(iRecRetCnt, ccrewid, ccrewname, cupdatedby, ddatefrom, ddateto,
                           cscreen, , iRecBatch, irowcount) Then
            End If
        End If

        If iRecRetCnt < irowcount Then
            Me.lblOf.Text = "of " & iRecBatch
            '    Me.btnNext.Enabled = False
            '    Me.btnPrevious.Enabled = False
            'Else
            '    Me.btnNext.Enabled = True
            '    Me.btnPrevious.Enabled = True
        End If

        If iRecRetCnt > 1 Then
            Call setBarButtons(irowcount, iRecBatch, iRecRetCnt)

            Me.txtCurrentBatch.EditValue = iRecBatch
        End If
    End Sub

    Function RefreshGrid(ByRef iRecRetCnt As Long, Optional ccrewid As String = "<NOCRITERIA>", Optional ccrewname As String = "<NOCRITERIA>",
                         Optional cupdatedby As String = "<NOCRITERIA>", Optional ddatefrom As Date = Nothing,
                         Optional ddateto As Date = Nothing, Optional cscreen As String = "<NOCRITERIA>",
                         Optional imodulecode As Integer = 0, Optional irecordstart As Long = 1,
                         Optional irowcount As Long = 25, Optional exmsg As String = "") As Boolean

        Dim ret As Boolean

        Dim dt As New DataTable, cProcRet As String, dtCopy As New DataTable, dttest As New DataTable

        'add your column here
        Dim array() As String = {"AuditLogID", "CrewID", "crewname", "ScreenCaption", "ActionDescrip", "UserName", _
                                  "TableName", "ComputerName", "ModuleCode", "Dateupdated", "SiteID"}
        Dim ctempconnstr As String

        If ddateto = Nothing Then
            ddateto = Now
        End If
        If ddatefrom = Nothing Then
            ddatefrom = DateAdd(DateInterval.Day, -5, Now)
        End If

        'DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(WaitForm1))

        Try
            ctempconnstr = Replace(DB.GetConnectionString, "Database=MPS", "Database=MPS4A")

            clsA.propSQLConnStr = ctempconnstr
            cProcRet = clsA.getAuditData(dt, ccrewid, ccrewname, cupdatedby, ddatefrom, ddateto, cscreen, , irecordstart, irowcount)
            If cProcRet = "" Then
                If dt.Rows.Count > 0 Then
                    Me.GridAudit.DataSource = Nothing
                    'Me.GridAudit.DataSource = dt


                    '///////////////////// TEST
                    dtCopy = dt.Copy

                    'remove columns not needed for parent table
                    dt.Columns.Remove("flddesc")
                    dt.Columns.Remove("OldValue")
                    dt.Columns.Remove("NewValue")

                    'remove columns not needed for child table
                    dtCopy.Columns.Remove("CrewID")
                    dtCopy.Columns.Remove("crewname")
                    dtCopy.Columns.Remove("DataDescrip")
                    dtCopy.Columns.Remove("ScreenCaption")
                    dtCopy.Columns.Remove("ActionDescrip")
                    dtCopy.Columns.Remove("UserName")
                    dtCopy.Columns.Remove("TableName")
                    dtCopy.Columns.Remove("ComputerName")
                    dtCopy.Columns.Remove("ModuleCode")
                    dtCopy.Columns.Remove("Dateupdated")
                    dtCopy.Columns.Remove("SiteID")
                    dtCopy.Columns.Remove("refTable")
                    dtCopy.Columns.Remove("OldValue")
                    dtCopy.Columns.Remove("NewValue")
                    dtCopy.Columns.Remove("AuditDetailID")
                    dtCopy.Columns("OldValueName").Caption = "Old Value"
                    dtCopy.Columns("NewValueName").Caption = "New Value"
                    dtCopy.Columns("flddesc").Caption = "Field"

                    dttest = dt.DefaultView.ToTable(True, array) 'select distinct records
                    iRecRetCnt = dttest.Rows.Count

                    Dim parentColumn As DataColumn = dttest.Columns("AuditLogID")
                    Dim childColumn As DataColumn = dtCopy.Columns("AuditLogID")

                    Dim ds As New DataSet

                    ds.Tables.Add(dttest)
                    ds.Tables.Add(dtCopy)

                    Dim drRelate As DataRelation

                    drRelate = New DataRelation("Log Details", parentColumn, childColumn)

                    ds.Relations.Add(drRelate)

                    Me.GridAudit.DataSource = dttest 'ds.Tables(dttest.TableName)
                    ' Me.GridAudit.ForceInitialize()

                    Me.GridViewLog.Columns("AuditLogID").Visible = False
                    Me.GridViewDetails.Columns("AuditLogID").Visible = False
                    'Me.GridViewDetails.PopulateColumns(dtCopy)
                    'Me.GridViewDetails.Columns("AuditLogID").Visible = False

                    Me.GridViewLog.BestFitColumns()
                    '//////////////////////////
          
                Else
                    MsgBox("End of Record/No Record(s) found", MsgBoxStyle.Information, GetAppName)
                    Me.GridAudit.DataSource = Nothing
                End If
            Else
                ' MsgBox("Error: " & cProcRet)
            End If

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
            ret = True
        Catch ex As Exception
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
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
                       cscreen, , (iRecBatch * irowcount) - (irowcount - 1), irowcount) Then
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
                       cscreen, , (iRecBatch * irowcount) - (irowcount - 1), irowcount) Then
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
                                   cscreen, , (tempCurrBatch * irowcount) - (irowcount - 1), irowcount) Then
                    End If
                End If


                'possible record count return: 0 / < irowcount / = irowcount,
                'possible entered batch number: 0 / > total batch count(w/c could be known or not yet) / < total batch 

                If iRecRetCnt < irowcount And iRecRetCnt <> 0 Then
                    Me.lblOf.Text = "of " & tempCurrBatch
                    iRecBatch = tempCurrBatch 'set global var
                ElseIf iRecRetCnt = 0 Then '0 means end of record or no record at all
                    If tempCurrBatch = 1 Then
                        iRecBatch = 0
                        Me.lblOf.Text = "of 0"
                    Else
                        Me.lblOf.Text = "of " & iRecBatch
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
End Class
