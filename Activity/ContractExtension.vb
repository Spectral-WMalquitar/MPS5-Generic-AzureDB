Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class ContractExtension

#Region "Declarations"

    Dim downHitInfo As GridHitInfo = Nothing
    Dim dtMainview As New DataTable
    Dim dtCancelExt As New DataTable
    Dim _deleteid As String
    Dim strFilterMain As String
    Dim strFilterCrewSelected As String
    Dim strLastUpdated As String = ""
    Dim clsAudit As New clsAudit
    Dim isNewDateEdited As Boolean = False
    Dim selectedView As GridView

    Dim clsActDoc As New clsActivityDocs_temptbl("ContractExtension", MPSDB)

#End Region

#Region "Overridables"

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        Select Case TabbedControlGroup1.SelectedTabPage.Name
            Case "tabExtend"
                ExtendContracts()
                strFilterCrewSelected = ""
            Case "tabCancel"
                CancelContracts()
                strFilterCrewSelected = " AND (ContractExtensions <> 0) "
        End Select
        forceRefresh(True)
        getCrewListDataTable(blList.bListSelect, "Automatic") 'Refresh CrewList
        blList.ExecCustomFunction(New Object() {"RefreshList"})
        blList.RefreshData()
        blList.SetFilter(strFilterMain & strFilterCrewSelected)
        AllowSaving(Name, False)
        BRECORDUPDATEDs = False
    End Sub

    Public Overrides Sub DeleteData()
        Dim i As Integer = 0
        While i < selectedView.RowCount
            If _deleteid.Contains(";" & selectedView.GetRowCellValue(i, "IDNbr") & ";") Then
                selectedView.DeleteRow(i)
                i = -1
            End If
            i += 1
        End While
        _deleteid = ""
        selectedView.RefreshData()
        selectedView.ClearSelection()
        If selectedView.RowCount > 0 Then
            selectedView.FocusedRowHandle = 0
            selectedView.SelectRow(0)
        End If
        If selectedView.RowCount = 0 Then AllowSaving(Name, False)
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        SetActivityActivityDocsRpgVisibility(Name, True)
        EditSubAllowGrid(gvCancel, False, False)
        If IsNothing(selectedView) Then
            TabbedControlGroup1.SelectedTabPage = tabExtend
            selectedView = Mainview
        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Dim ermsg As String = "", tempvPKey As Integer = 0
        'MsgBox("test")
        Select Case param(0)
            Case "ACTIVITYDOCS"
                'MsgBox(Me.SeaServView.GridControl.ContainsFocus)
                'MsgBox(mainview.Name)
                'Dim _CurrActId As String = IfNull(Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "ActID"), "")
                Mainview.PostEditor()

                Dim crewId As String = IfNull(Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "IDNbr"), "")
                Dim dson As Date = IIf(Mainview.GetRowCellDisplayText(Mainview.FocusedRowHandle, "DateSON") = "",
                                                      Nothing, Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "DateSON"))

                'Dim row As System.Data.DataRow = Mainview.GetDataRow(Mainview.FocusedRowHandle)

                Dim vslname As String = Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "VslName")

                If crewId = "" Or crewId Is DBNull.Value Then
                    MsgBox("Please select Crew.", vbExclamation)
                    Exit Select
                End If

                If Not IsDate(dson) Or dson = Nothing Then
                    MsgBox("Please enter Date of Promotion.", vbExclamation)
                    Exit Select
                End If

                'If vslname = "" Or vslname Is Nothing Then
                '    MsgBox("Please select Vessel.", vbExclamation)
                '    Exit Select
                'End If

                'If crewId <> "" And Not crewId Is DBNull.Value And _
                '        IsDate(Me.deDateSON.EditValue) And _
                '        vslname <> "" And Not vslname Is Nothing Then
                ' MsgBox(_CurrActId)

                ' If _CurrActID <> "" Then
                Dim activitydocsfrm As New frmActivityDocs(clsActDoc, crewId, dson, vslname, , Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "Crew"))
                activitydocsfrm.ShowDialog()
                'Else
                'End If
                'Else
                'End If

        End Select
    End Sub

#End Region

    Private Sub ExtendContracts()
        Dim sqls As New ArrayList
        With Mainview
            If .RowCount > 0 Then
                If MsgBox("Warning: Planning Events that have conflict with the new date due will be deleted." & Environment.NewLine & "Are you sure you want to Extend Contract/s?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
                    Exit Sub
                End If

                If checkRequiredFields() = True Then
                    MessageBox.Show("Please insert valid Extended LOC and Extended LOCDays.", GetAppName() & " - Activity", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                For i As Integer = 0 To .RowCount - 1
                    strLastUpdated = clsAudit.AssembleLastUBy(USER_NAME, "Contract Extended", 0, System.Environment.MachineName, "Contract Extended - " & .GetRowCellValue(i, "ExtLOC") & "M " & IfNull(.GetRowCellValue(i, "ExtLOCDays"), 0) & "D", Name, .GetRowCellValue(i, "IDNbr"))
                    sqls.Add("EXEC [dbo].[SP_CONTRACT_EXTENSION] @ActGrpID = '" & .GetRowCellValue(i, "ActGrpID") & "', @CurrActID = '" & .GetRowCellValue(i, "CurrActID") & "'," & _
                             "@ExtLOC = " & IfNull(.GetRowCellValue(i, "ExtLOC"), 0) & ", @ExtLOCDays = " & IfNull(.GetRowCellValue(i, "ExtLOCDays"), 0) & ", @DateEffect = " & ChangeToSQLDate(.GetRowCellValue(i, "DateEffect")) & ", @Remarks = '" & CleanInput(IfNull(.GetRowCellValue(i, "Remarks"), "")) & "', @LastUpdatedBy  = '" & strLastUpdated & "'," & _
                             "@IDNbr = '" & .GetRowCellValue(i, "IDNbr") & "',@activitykeyOut = @activitykeyOut output, @crewidnbrOut = @crewidnbrOut output")

                    ' clsActDoc.updateDateIssue(.GetRowCellValue(i, "IDNbr"), Mainview.GetRowCellValue(i, "DateSON"))
                Next

                Dim colname As New ArrayList, dt As New DataTable
                colname.Add("activitykeyOut") '/// should be the same name as in the sql without the @ sign. pls check above
                colname.Add("crewidnbrOut") '/// should be the same name as in the sql without the @ sign. pls check above

                DB.RunSqls(sqls, colname, dt)

                If dt.Rows.Count > 0 Then '//save image doc per
                    For Each row As DataRow In dt.Rows
                        clsActDoc.saveDtToDb(row("activitykeyOut"), row("crewidnbrOut"))
                    Next
                End If

            End If
        End With

        MsgBox("Successfully Extended Contract/s.", MsgBoxStyle.Information, GetAppName() & " - Activity")
        'forceRefresh(True)
        Mainview.SelectAll()
        Mainview.DeleteSelectedRows()
    End Sub

    Private Sub CancelContracts()
        Dim sqls As New ArrayList
        Dim extLOC As Integer
        Dim extLOCDays As Integer
        Dim cWhereCond As String = ""

        With gvCancel
            If .RowCount > 0 Then
                For i As Integer = 0 To .RowCount - 1
                    strLastUpdated = clsAudit.AssembleLastUBy(USER_NAME, "Contract Cancelled", 0, System.Environment.MachineName, "Contract Cancelled - " & .GetRowCellValue(i, "LOCExt") & "M " & IfNull(.GetRowCellValue(i, "LOCDaysExt"), 0) & "D", Name, .GetRowCellValue(i, "IDNbr"))
                    DB.BeginReader("SELECT TOP 1 ce.LOCExt, ce.LOCDaysExt " &
                                   " FROM tblContractExt ce " &
                                   " WHERE ce.PKey = '" & .GetRowCellValue(i, "ContractExtID") & "'")
                    While DB.Read
                        extLOC = IfNull(DB.ReaderItem("LOCExt"), 0)
                        extLOCDays = IfNull(DB.ReaderItem("LOCDaysExt"), 0)
                    End While
                    DB.CloseReader()
                    sqls.Add("UPDATE tblActivityGroup SET EXTLOC = EXTLOC - " & extLOC & ", EXTLOCDays = EXTLOCDays - " & extLOCDays & " WHERE FKeyIDNbr = '" & .GetRowCellValue(i, "IDNbr") & "' AND PKey = '" & .GetRowCellValue(i, "ActGrpID") & "'")
                    sqls.Add("DELETE FROM tblContractExt WHERE PKey = '" & .GetRowCellValue(i, "ContractExtID") & "'")
                    cWhereCond = cWhereCond & IIf(IfNull(cWhereCond, "").Length > 0, ", ", "") & _
                        "'" & .GetRowCellValue(i, "ContractExtID") & "'"
                Next

                '<!--added by tony20180922 : Log Deletion
                Dim oLogDeletion As New LogDeletion
                If IfNull(cWhereCond, "").Length > 0 Then
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        "Activity - Contract Extension", _
                        "Crewing", _
                        "tblContractExt", _
                        "PKey IN (" & cWhereCond & ")", _
                        "<< Delete Crew Data - Activity - Contract Extension >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Activity - Contract Extension>", _
                        GetUserName())
                    '-->
                End If

                If DB.RunSqls(sqls) Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                End If
            End If
        End With

        MsgBox("Contract Extension Cancelled.", MsgBoxStyle.Information, GetAppName() & " - Activity")

        gvCancel.SelectAll()
        gvCancel.DeleteSelectedRows()
    End Sub

#Region "Drag N'Drop"

    Private Sub Mainview_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Mainview.CellValueChanging
        AllowSaving(Name, False)
    End Sub

    Private Sub Mainview_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles Mainview.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MainView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Mainview.MouseDown
        Dim view As GridView = CType(sender, GridView)

        downHitInfo = Nothing

        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))

        If Not (Control.ModifierKeys = Keys.Control Or Control.ModifierKeys = Keys.None Or Control.ModifierKeys = Keys.Shift) Then
            Exit Sub
        End If

        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub MainView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Mainview.MouseMove
        Dim view As GridView = CType(sender, GridView)

        If e.Button = MouseButtons.Left And Not downHitInfo Is Nothing Then

            Dim dragSize As Size = SystemInformation.DragSize

            Dim DragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not DragRect.Contains(New Point(e.X, e.Y)) Then

                view.GridControl.DoDragDrop(GetSelectedRows(), DragDropEffects.Move)

                downHitInfo = Nothing

                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Function GetSelectedRows() As DataTable
        Dim ntbl As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        ntbl.Columns.Add(ccolumn)
        _deleteid = ";"

        For Each xrow In selectedView.GetSelectedRows
            selectedView.GetDataRow(xrow).ClearErrors()
            _deleteid = _deleteid & selectedView.GetRowCellValue(xrow, "IDNbr") & ";"
            ntbl.ImportRow(selectedView.GetDataRow(xrow))
        Next

        If (selectedView.RowCount) - (selectedView.GetSelectedRows.Count) = 0 Then
            BRECORDUPDATEDs = False
        End If

        Return ntbl
    End Function

    Private Sub MainGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragDrop
        Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
        If Not xtbl Is Nothing Then
            Dim extDateDue As Date
            Dim dateSON As Date
            Dim defLOC As Integer
            Dim defLOCDays As Integer
            Dim strPlanDetails As String = ""
            Dim VslName As String = ""

            Try
                For Each nrow In xtbl.Rows
                    If DB.DLookUp("FKeyStatCode", "tblActivity", "", "PKey = '" & IfNull(nrow("CurrActID"), "") & "'") = "SYSSICKONB" Then
                        MsgBox("Cannot extend contract of sick onboard crew, " & nrow("Crew") & ". Please end sick onboard status first.")
                    Else
                        extDateDue = DB.CreateTable("SELECT dbo.GET_EXTDATEDUE('" & IfNull(nrow("ActGrpID"), "") & "')").Rows(0)(0)
                        strPlanDetails = IfNull(nrow("PlannedDateSON"), "")

                        DB.BeginReader("SELECT TOP 1 a.DateSON, ag.LOC, ag.LOCDays, a.VslName FROM tblActivity a LEFT JOIN tblActivityGroup ag  ON a.FKeyActivityGroupID = ag.PKey WHERE a.PKey = '" & IfNull(nrow("CurrActID"), "") & "'")
                        While DB.Read
                            dateSON = DB.ReaderItem("DateSON")
                            defLOC = IfNull(DB.ReaderItem("LOC"), 0)
                            defLOCDays = IfNull(DB.ReaderItem("LOCDays"), 0)
                            VslName = IfNull(DB.ReaderItem("VslName"), "")
                        End While
                        DB.CloseReader()

                        If strPlanDetails <> "" Then strPlanDetails = CDate(strPlanDetails).ToString("dd-MMM-yyyy")
                        Dim xrow() As Object = {nrow("IDNbr"), nrow("Crew"), extDateDue.ToString("dd-MMM-yyyy"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("RankName"), strPlanDetails, dateSON, defLOC, defLOCDays, VslName}
                        dtMainview.Rows.Add(xrow)
                    End If
                Next
            Catch ex As Exception
                LogErrors(ex.Message)
                'MsgBox(ex.Message)
            End Try

            For Each nrow In dtMainview.Rows
                strFilterCrewSelected = strFilterCrewSelected & " AND IDNbr <> '" & nrow("IDNbr") & "'"
            Next

            Mainview.RefreshData()
            If Mainview.RowCount > 0 Then
                Mainview.SelectRow(0)
                AllowSaving(Name, True)
                BRECORDUPDATEDs = True
            End If

            blList.SetFilter(strFilterMain & strFilterCrewSelected)
            AllowSaving(Name, True)
        End If
    End Sub

    Private Sub gcCancel_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles gcCancel.DragDrop
        Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
        If Not xtbl Is Nothing Then
            Dim extDateDue As Date
            Dim dateSON As Date
            Dim extLOC As Integer
            Dim extLOCDays As Integer
            '<!-- edited by tony20181016 - produces warning: Variable 'contractExtID' is used before it has been assigned a value.
            Dim contractExtID As String = ""
            '-->

            Try
                For Each nrow In xtbl.Rows
                    DB.BeginReader("SELECT TOP 1 a.DateSON, ag.EXTLOC, ag.EXTLOCDays, dbo.GET_EXTDATEDUE(ag.PKey) as DateDue, ce.PKey AS ContractExtID " &
                                   " FROM tblActivity a " &
                                   " INNER JOIN tblActivityGroup ag  ON a.FKeyActivityGroupID = ag.PKey " &
                                   " INNER JOIN tblContractExt ce ON ce.FKeyActivityID = a.PKey " &
                                   " WHERE a.PKey = '" & IfNull(nrow("CurrActID"), "") & "'" &
                                   " ORDER BY ce.DateEffect DESC ")
                    While DB.Read
                        dateSON = DB.ReaderItem("DateSON")
                        extLOC = IfNull(DB.ReaderItem("EXTLOC"), 0)
                        extLOCDays = IfNull(DB.ReaderItem("EXTLOCDays"), 0)
                        extDateDue = DB.ReaderItem("DateDue")
                        contractExtID = IfNull(DB.ReaderItem("ContractExtID"), "")
                    End While
                    DB.CloseReader()

                    Dim xrow() As Object = {nrow("IDNbr"), nrow("Crew"), extDateDue, IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("RankName"), dateSON, extLOC, extLOCDays, contractExtID}
                    dtCancelExt.Rows.Add(xrow)
                Next
            Catch ex As Exception
                LogErrors(ex.Message)
                'MsgBox(ex.Message)
            End Try

            For Each nrow In dtCancelExt.Rows
                strFilterCrewSelected = strFilterCrewSelected & " AND IDNbr <> '" & nrow("IDNbr") & "'"
            Next

            gvCancel.RefreshData()
            If gvCancel.RowCount > 0 Then
                gvCancel.SelectRow(0)
                AllowSaving(Name, True)
                BRECORDUPDATEDs = True
            End If

            blList.SetFilter(strFilterMain & strFilterCrewSelected)
            AllowSaving(Name, True)
        End If
    End Sub

    Private Sub gcCancel_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles gcCancel.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub gvCancel_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles gvCancel.MouseMove
        Dim view As GridView = CType(sender, GridView)

        If e.Button = MouseButtons.Left And Not downHitInfo Is Nothing Then

            Dim dragSize As Size = SystemInformation.DragSize

            Dim DragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not DragRect.Contains(New Point(e.X, e.Y)) Then

                view.GridControl.DoDragDrop(GetSelectedRows(), DragDropEffects.Move)

                downHitInfo = Nothing

                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub gvCancel_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles gvCancel.MouseDown
        Dim view As GridView = CType(sender, GridView)

        downHitInfo = Nothing

        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))

        If Not (Control.ModifierKeys = Keys.Control Or Control.ModifierKeys = Keys.None Or Control.ModifierKeys = Keys.Shift) Then
            Exit Sub
        End If

        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

#End Region

    Private Sub InitData()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Crew"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateDue"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CurrActID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActGrpID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "RankName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlanDetails"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateSON"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "DefLOC"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "DefLOCDays"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "VslName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateEffect"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Remarks"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        'Inputs must not contain value on drop
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ExtLOC"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ExtLOCDays"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "NewDateDue"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)

        Maingrid.DataSource = dtMainview



        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Crew"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateDue"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CurrActID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActGrpID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "RankName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateSON"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "LOCExt"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "LOCDaysExt"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtCancelExt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ContractExtID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCancelExt.Columns.Add(ccolumn)

        gcCancel.DataSource = dtCancelExt

    End Sub

    Private Sub ContractExtension_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        strBContentFilter = ""
        _deleteid = Nothing
        clsAudit = Nothing
        strFilterMain = Nothing
        downHitInfo = Nothing
        strLastUpdated = Nothing

        dtMainview.Dispose()
        dtCancelExt.Dispose()
    End Sub

    Private Sub ContractExtension_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitData()
        If strCrewListFilter <> "" Then
            strFilterMain = "(StatCode IN ('SYSONB', 'SYSSICKONB') AND " & strCrewListFilter & ")"
        Else
            strFilterMain = "(StatCode IN ('SYSONB', 'SYSSICKONB'))"
        End If
        blList.SetFilter(strFilterMain)
        blList.Draggable(True)
    End Sub

    Private Function getNewDateDue(ByVal startDate As Date, ByVal LOC As Integer, Optional ByVal LOCDays As Integer = 0) As Date
        Dim res As Date
        res = DateAdd(DateInterval.Month, LOC, startDate)
        res = DateAdd(DateInterval.Day, LOCDays, res)
        Return res
    End Function

    Private Sub Mainview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Mainview.CellValueChanged
        If e.Column.FieldName = "ExtLOC" And isNewDateEdited = False Then
            If IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "NewDateDue")) Then
                Mainview.SetRowCellValue(e.RowHandle, "NewDateDue", getNewDateDue(Mainview.GetRowCellValue(e.RowHandle, "DateDue"), e.Value))
            Else
                Mainview.SetRowCellValue(e.RowHandle, "NewDateDue", getNewDateDue(Mainview.GetRowCellValue(e.RowHandle, "DateDue"), e.Value, IfNull(Mainview.GetRowCellValue(e.RowHandle, "ExtLOCDays"), 0)))
            End If
        End If
        If e.Column.FieldName = "ExtLOCDays" And isNewDateEdited = False Then
            If IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "NewDateDue")) Then
                Mainview.SetRowCellValue(e.RowHandle, "NewDateDue", getNewDateDue(Mainview.GetRowCellValue(e.RowHandle, "DateDue"), 0, e.Value))
            Else
                Mainview.SetRowCellValue(e.RowHandle, "NewDateDue", getNewDateDue(Mainview.GetRowCellValue(e.RowHandle, "DateDue"), IfNull(Mainview.GetRowCellValue(e.RowHandle, "ExtLOC"), 0), e.Value))
            End If
        End If
        If e.Column.FieldName = "NewDateDue" And isNewDateEdited = True Then
            If Not IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "NewDateDue")) Then
                Mainview.SetRowCellValue(e.RowHandle, "ExtLOC", getLOC(Mainview.GetRowCellValue(e.RowHandle, "DateDue"), Mainview.GetRowCellValue(e.RowHandle, "NewDateDue"), "M"))
                Mainview.SetRowCellValue(e.RowHandle, "ExtLOCDays", getLOC(Mainview.GetRowCellValue(e.RowHandle, "DateDue"), Mainview.GetRowCellValue(e.RowHandle, "NewDateDue"), "D"))
            End If
            isNewDateEdited = False
        End If
        If e.Column.FieldName = "DateEffect" And isNewDateEdited = True Then
            isNewDateEdited = False
        End If
        AllowSaving(Name, True)
    End Sub

    Private Function checkRequiredFields() As Boolean
        Dim res As Boolean = False
        Dim clm, cmln As New DevExpress.XtraGrid.Columns.GridColumn
        For i As Integer = 0 To Mainview.RowCount - 1
            If IsDBNull(Mainview.GetRowCellValue(i, "ExtLOC")) And IsDBNull(Mainview.GetRowCellValue(i, "ExtLOCDays")) Then
                res = True
                Return res
                Exit Function
            End If

            If IfNull(Mainview.GetRowCellValue(i, "ExtLOC"), 0) = 0 And IfNull(Mainview.GetRowCellValue(i, "ExtLOCDays"), 0) = 0 Then
                res = True
                Return res
                Exit Function
            End If

            If IfNull(Mainview.GetRowCellValue(i, "ExtLOC"), 0) < 0 Or IfNull(Mainview.GetRowCellValue(i, "ExtLOCDays"), 0) < 0 Then
                res = True
                Return res
                Exit Function
            End If

            If IsDBNull(Mainview.GetRowCellValue(i, "DateEffect")) Then
                res = True
                Return res
                Exit Function
            End If
        Next
        Return res
    End Function

    Private Sub repDateEdit_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles repDateEdit.CloseUp
        isNewDateEdited = True
    End Sub

    Private Sub Mainview_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles Mainview.ValidateRow
        Dim view As GridView = TryCast(sender, GridView)

        If IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "ExtLOC")) And IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "ExtLOCDays")) Then
            e.Valid = False
            AllowSaving(Name, False)
            Exit Sub
        End If

        If IfNull(Mainview.GetRowCellValue(e.RowHandle, "ExtLOC"), 0) > (IfNull(Mainview.GetRowCellValue(e.RowHandle, "DefLOC"), 0) * 2) Then
            e.Valid = False
            view.GetDataRow(e.RowHandle).SetColumnError("ExtLOC", "LOC Extension cannot be twice larger than the starting LOC(" & IfNull(Mainview.GetRowCellValue(e.RowHandle, "DefLOC"), 0) & ").")
            AllowSaving(Name, False)
            Exit Sub
        End If

        If IfNull(Mainview.GetRowCellValue(e.RowHandle, "ExtLOCDays"), 0) > 31 Then
            e.Valid = False
            view.GetDataRow(e.RowHandle).SetColumnError("ExtLOCDays", "LOC Days Extension cannot be greater than 31.")
            AllowSaving(Name, False)
            Exit Sub
        End If

        If IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "DateEffect")) Then
            e.Valid = False
            view.GetDataRow(e.RowHandle).SetColumnError("DateEffect", "Effectivity Date must be specified.")
            AllowSaving(Name, False)
            Exit Sub
        End If

        view.GetDataRow(e.RowHandle).ClearErrors()
        AllowSaving(Name, True)
    End Sub

    Private Sub NumberEdit_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles NumberEdit.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanging(sender As System.Object, e As DevExpress.XtraLayout.LayoutTabPageChangingEventArgs) Handles TabbedControlGroup1.SelectedPageChanging
        If BRECORDUPDATEDs Then
            Dim res As MsgBoxResult = MsgBox("This will cancel current changes, continue?.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, GetAppName)
            If res = MsgBoxResult.Yes Then
                e.Cancel = False
                selectedView.SelectAll()
                selectedView.DeleteSelectedRows()
                BRECORDUPDATEDs = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As System.Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        strFilterCrewSelected = ""
        Select Case TabbedControlGroup1.SelectedTabPage.Name
            Case "tabExtend"
                selectedView = Mainview
                blList.SetFilter(strFilterMain)
            Case "tabCancel"
                selectedView = gvCancel
                strFilterCrewSelected = " AND (ContractExtensions <> 0) "
                blList.SetFilter(strFilterMain & strFilterCrewSelected)
        End Select
    End Sub

    Private Sub gvCancel_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles gvCancel.PopupMenuShowing
        If Not IsNothing(e.Menu) Then
            e.Menu.Items.Clear()
            e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Contract Extensions", AddressOf ShowContractExtensions))
        End If
    End Sub

    Private Sub ShowContractExtensions()
        Dim dt As DataTable = MPSDB.CreateTable("SELECT ag.LOC, ag.LOCDays, ag.DateDue, ag.EXTLOC, ag.EXTLOCDays, dbo.GET_EXTDATEDUE(ag.Pkey) AS DateDueExt, ce.LOCExt, ce.LOCDaysExt, ce.DateEffect, ce.Remarks " &
                                "FROM tblActivityGroup ag " &
                                    "INNER JOIN tblActivity a ON ag.Pkey = a.FKeyActivityGroupID " &
                                    "INNER JOIN tblContractExt ce ON a.Pkey = ce.FKeyActivityID " &
                                "WHERE a.PKey = '" & gvCancel.GetFocusedRowCellDisplayText("CurrActID") & "' " &
                                "ORDER BY ce.DateEffect DESC")
        Dim contExt As New Crewing.frmContractExtensions(gvCancel.GetFocusedRowCellDisplayText("Crew"),
                                                 gvCancel.GetFocusedRowCellDisplayText("RankName"),
                                                 IfNull(dt(0)("LOC"), 0),
                                                 IfNull(dt(0)("LOCDays"), 0),
                                                 IfNull(dt(0)("DateDue"), DBNull.Value),
                                                 IfNull(dt(0)("EXTLOC"), 0),
                                                 IfNull(dt(0)("EXTLOCDays"), 0),
                                                 IfNull(dt(0)("DateDueExt"), DBNull.Value),
                                                 dt)
        contExt.StartPosition = FormStartPosition.CenterParent
        contExt.ShowDialog()
    End Sub

End Class
