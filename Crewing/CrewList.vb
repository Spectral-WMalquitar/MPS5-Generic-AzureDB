Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraScheduler
Imports System.Linq
Imports DevExpress.XtraSplashScreen
Imports System.Threading

Public Class CrewList

    Private Structure ForDeletion
        Public crewID As String
        Public crewName As String
        Public hasPayroll As Boolean
    End Structure


    Dim secPermission As New clsSecurity
    Dim downHitInfo As GridHitInfo
    Dim dt As New DataTable
    Dim allow As Boolean = True
    Dim userdatafilter As String
    Dim expDocDays As Integer = 0
    Dim isActivated As Boolean = False
    Dim selectedCrewID As New System.Text.StringBuilder("")
    Dim GridCheckMarksSelection As MPS5.DevExpress.XtraGrid.Selection.GridCheckMarksSelection

    Dim selectedCrewName As String = ""

    Public Shared SelectedGroupID As String
    Public Shared CrewCurrentRank As String
    Public Shared selectedCrewForArchive As Integer = 0

    'removed by tony20170725 - "I forgot what this is for!"
    'Dim isFormInitialized As Boolean = False    'Added by Tony20161014 
    Dim toBeDeleted As New HashSet(Of ForDeletion)

    Dim expDueDateDays As Integer = 30

    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = ""
    Dim _controlMousePointer As Point
    Dim strContent As String = ""


    Public Overrides Sub HideSelection()
        bAddMode = True
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles MainView.BeforeLeaveRow
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not bDraggable Then
            If BRECORDUPDATEDs Then
                If Not bRecordDeleted Then
                    If bContent.CheckValidateFields() Then
                        e.Allow = True
                    Else
                        If ALLOWNEXTS Then
                            e.Allow = True
                        Else
                            e.Allow = False
                        End If
                    End If
                Else
                    e.Allow = True
                End If
            Else
                e.Allow = True
            End If
        End If
    End Sub

    Private Sub MainView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainView.Click
        bAddMode = False
        'SelectionChange(Name)
        'MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        isRefreshingData = True     'Added by Tony20161014
        ShowCustomLoadScreen(GetType(MPS4.Waitform), "Loading...")
        expDueDateDays = CInt(GetUserSetting("DueDateExpDays", "30"))
        SetGridLayout(Me.MainView)
        Me.MainGrid.ForceInitialize()
        bDisableSelectionEvent = True
        'PrepareData()
        initControl()
        bDisableSelectionEvent = False
        ApplyCrewListViewSort(MainView)
        ApplyCrewListFindText(MainView)
        Dim toprowindex = MainView.TopRowIndex
        SetSelection(selectedID)
        PrepareData()
        'MainView.TopRowIndex = toprowindex
        CheckPrintCustomPOEAContractPermission()
        isRefreshingData = False    'Added by Tony20161014
        CloseCustomLoadScreen()
    End Sub

    Private Sub CheckPrintCustomPOEAContractPermission()
        Dim sec As New clsSecurity
        sec.propSQLConnStr = MPSDB.GetConnectionString
        If sec.hasNoViewPermission("PrintCustomPOEAContract", USER_ID) Then
            PrintPOEAContract.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Else
            PrintPOEAContract.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
    End Sub

    Public Overrides Sub DeleteArchivedCrew()
        MyBase.DeleteArchivedCrew()
        toBeDeleted.Clear()
        Dim count As Integer = GridCheckMarksSelection.SelectedCount
        If SelectedTab.Equals("ArchiveCrews") And count > 0 Then
            Dim res As DialogResult = MessageBox.Show("Are you sure you want to permanently delete the selected crew" & IIf(count > 1, "s", "") & "?", "Delete Archived Crews", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                With MainView
                    For i As Integer = 0 To .RowCount - 1
                        If GridCheckMarksSelection.IsRowSelected(i) Then
                            Dim crewForDeletion As New ForDeletion
                            crewForDeletion.crewID = .GetRowCellValue(i, "IDNbr")
                            crewForDeletion.crewName = .GetRowCellValue(i, "FName") & " " & .GetRowCellValue(i, "LName")
                            crewForDeletion.hasPayroll = CrewHasPayroll(.GetRowCellValue(i, "IDNbr"))
                            toBeDeleted.Add(crewForDeletion)
                        End If
                    Next
                End With
                If MessageBox.Show(FormatMessageForDeletion() & Environment.NewLine & " Do you want to proceed in deleting selected crews? ", "Delete Crew",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    DeleteCrewsInArchive()
                End If
            End If
        Else
            MessageBox.Show("Please select a crew(s) you want to delete.", "Delete Crew", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DeleteCrewsInArchive()
        Try
            Dim archive = New MPSArchiveUtil()
            SplashScreenManager.ShowForm(GetType(Waitform))
            SplashScreenManager.Default.SetWaitFormDescription("Deleting crews in Archive ..")
            archive.SetConnectionsDetails(MPS4BasicFunctions.SQLServer, MPS4BasicFunctions.SQLID, MPS4BasicFunctions.SQLPW, "MPSARC")

            selectedCrewName = ""

            If archive.RunDeleteCrewInArchive(GetSelectedCrewID()) Then

                Dim retlogid As Long, array_idnbr() As String, array_crew() As String

                array_idnbr = selectedCrewID.ToString.Split(",")
                array_crew = selectedCrewName.Split(";")
                For i As Integer = 0 To array_crew.Count - 1
                    If array_crew(i) <> "" Then
                        clsAudit.saveAuditLog("Delete Crew from Archive", USER_NAME, retlogid, System.Environment.MachineName, 0, _
                                              , , , Replace(array_idnbr(i), "'", ""), _
                                              "Crew : " & Replace(array_crew(i), ";", ""), "Record Summary", _
                                              getServerDateTime)
                    End If
                Next

                MessageBox.Show("Crews successfully deleted from Archive active.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SetAllSelected(False)
                RefreshData()
            Else
                MessageBox.Show("There is a problem while deleting the crews in Archive.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in RunSetToActiveProcess() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in RunSetToActiveProcess() method in CrewList.vb - End--")
            MessageBox.Show(ex.Message)
        Finally
            'SplashScreenManager.CloseForm()
        End Try

        Try
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            'do nothing
        End Try
    End Sub

    Private Function FormatMessageForDeletion() As String

        Dim withPayroll As String = ""
        Dim withoutPayroll As String = ""


        For Each _crew As ForDeletion In toBeDeleted
            If _crew.hasPayroll Then
                withPayroll &= "- " & _crew.crewName & Environment.NewLine
            Else
                withoutPayroll &= "- " & _crew.crewName & Environment.NewLine
            End If

        Next

        If withPayroll.Length > 0 Then
            withPayroll = "The following crew does have an existing payroll : " & Environment.NewLine & Environment.NewLine & withPayroll
        End If

        If withoutPayroll.Length > 0 Then
            withoutPayroll = "The following crew do not have an existing payroll : " & Environment.NewLine & Environment.NewLine & withoutPayroll
        End If


        Return withPayroll & Environment.NewLine & Environment.NewLine & withoutPayroll
    End Function

    Public Function CrewHasPayroll(crewID As String) As Boolean
        Dim retVal As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CrewHasPayroll"
                With cmd.Parameters
                    .AddWithValue("@CrewID", crewID)
                End With
                retVal = cmd.ExecuteScalar()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return retVal

    End Function

    Private Sub PrepareData()
        If GetUserSetting("DocExpDays") <> "" Then
            expDocDays = Val(GetUserSetting("DocExpDays"))
        End If
        userdatafilter = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
        PopulateData()
    End Sub

    Private Sub MainViewn_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Public Overrides Function GetID() As String
        Return IIf(MainView.RowCount > 0, MainView.GetRowCellValue(MainView.FocusedRowHandle, "IDNbr"), "")
    End Function

    Public Overrides Function GetDesc() As String
        'edited by tony20180427
        'Return IIf(MainView.RowCount > 0, MainView.GetRowCellValue(MainView.FocusedRowHandle, "LName") & " " & MainView.GetRowCellValue(MainView.FocusedRowHandle, "FName"), "")
        If MainView.RowCount > 0 Then
            Return AssembleName(IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "LName"), ""), _
                                IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "FName"), ""), _
                                IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "MName"), "")) & _
                            " - " & IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "RankName"), "")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, _columnname)
        Catch ex As Exception
            LogErrors("--Error Generated in GetFocusedRowData() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetFocusedRowData() method in CrewList.vb - End--")

            Return System.DBNull.Value
        End Try

    End Function

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("IDNbr")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
            MainView.TopRowIndex = RowHandle
        Catch ex As Exception
            LogErrors("--Error Generated in SetSelection() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetSelection() method in CrewList.vb - End--")

        End Try
    End Sub

    Private Sub MainView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyData = Windows.Forms.Keys.Down Then
            MainView.MoveNext()
            e.Handled = True
        ElseIf e.KeyData = Windows.Forms.Keys.Up Then
            MainView.MovePrev()
            e.Handled = True
        End If
    End Sub

    Public Overrides Sub SetFilter(ByVal _criteria As String)
        Try
            Dim nRowNbr As Integer = MainView.FocusedRowHandle
            If bDraggable Then MainView.OptionsSelection.MultiSelect = False
            MainView.ActiveFilterString = _criteria
            strFilter = _criteria
            ActivateArchive()
            MainView.FocusedRowHandle = nRowNbr
            If bDraggable Then MainView.OptionsSelection.MultiSelect = True
        Catch ex As Exception
            LogErrors("--Error Generated in SetFilter() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetFilter() method in CrewList.vb - End--")

            If bDraggable Then MainView.OptionsSelection.MultiSelect = True
        End Try

        'UNCOMMENT LINES BELOW IF YOU WANT TO HIDE DATEDUE IN CREWLIST IF ITS IN SIGNON, PROMOTE, TRANSFER AND ASHORE ACTIVITY
        If MAIN_CONTENT = "SignOn" Or MAIN_CONTENT = "AshoreActivity" Then
            MainView.Columns("DueDate").Visible = False
        Else
            MainView.Columns("DueDate").Visible = True
        End If
    End Sub

    Public Overrides Sub ClearFilter()
        bDisableSelectionEvent = True
        MainView.ClearColumnsFilter()
        MainView.RefreshData()
        bDisableSelectionEvent = False
        strFilter = ""
        ActivateArchive()
    End Sub

    Private Sub setActivityCrewList()
        For i As Integer = 0 To MainView.Columns.Count - 1
            If MainView.Columns(i).Name = "colLName" Or MainView.Columns(i).Name = "colFName" Or MainView.Columns(i).Name = "colMName" Then
                MainView.Columns(i).Visible = True
            Else
                MainView.Columns(i).Visible = False
            End If
        Next
    End Sub

    Private Sub MainView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As System.Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) And e.Button = Windows.Forms.MouseButtons.Right Then
            CellRightClick(Name)
        End If
    End Sub

    Private Sub MainView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If SelectedTab.Equals("ArchiveCrews") Then
                RecordSum.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Biodata.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Document.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Training.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                MedicalHis.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Service.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Relative.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Appraisal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            ElseIf MAIN_CONTENT = "LTP" Then
                RecordSum.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Biodata.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Document.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Training.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                MedicalHis.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Service.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Relative.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Appraisal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                AddComment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                PrintBio.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                LTPCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'Added by calvhin 20170202
                ViewAct.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'Added by calvhin 20170213
                ViewExpDocs.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'Added by calvhin 20170213
            Else
                RecordSum.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Biodata.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Document.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Training.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                MedicalHis.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Service.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Relative.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Appraisal.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                ViewAct.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'Added by calvhin 20170213
                ViewExpDocs.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'Added by calvhin 20170213
                LTPCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'Added by calvhin 20170202
            End If

            rightClickMenu.ShowPopup(MousePosition)
        Else
            rightClickMenu.HidePopup()
            If bDraggable Then
                Dim view As GridView = CType(sender, GridView)
                downHitInfo = Nothing
                Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
                If Not (Control.ModifierKeys = Keys.Control Or Control.ModifierKeys = Keys.None Or Control.ModifierKeys = Keys.Shift) Then
                    Exit Sub
                End If
                If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
                    downHitInfo = hitInfo
                End If
            End If
        End If
    End Sub

    Private Sub MainView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseMove
        If bDraggable Then

            Dim view As GridView = CType(sender, GridView)
            If e.Button = MouseButtons.Left And Not downHitInfo Is Nothing Then

                Dim dragSize As Size = SystemInformation.DragSize
                Dim DragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

                If Not DragRect.Contains(New Point(e.X, e.Y)) Then
                    If MAIN_CONTENT = "LTP" Then
                        view.GridControl.DoDragDrop(GetDragDataForLTP(MainView), DragDropEffects.All)
                    Else
                        view.GridControl.DoDragDrop(GetSelectedRows(), DragDropEffects.Move)
                    End If
                    downHitInfo = Nothing
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
                End If
            End If
        End If
    End Sub

    Public Overrides Sub Draggable(ByVal value As Boolean)
        bDraggable = value
        bDisableSelectionEvent = value
        MainView.OptionsSelection.MultiSelect = value
        MainView.SelectRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragDrop
        Try
            If bDraggable Then
                Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
                Dim row As DataRow
                If Not xtbl Is Nothing Then
                    For Each row In xtbl.Rows
                        Dim xfilter As String = MainView.ActiveFilterString
                        xfilter = xfilter.Replace(xfilter.Substring(xfilter.IndexOf(row("IDNbr"), 0) - 17, 17 + CType(row("IDNbr"), String).Length + 1), "")
                        MainView.ActiveFilterString = xfilter
                        AcceptDragObject(Name)
                    Next
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in MainGrid_DragDrop() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in MainGrid_DragDrop() method in CrewList.vb - End--")

        End Try
    End Sub

    Private Sub MainGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragOver
        If bDraggable Then
            If e.Data.GetDataPresent(GetType(DataTable)) Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Function GetDragDataForLTP(ByVal view As GridView) As SchedulerDragData
        Dim selection As Integer() = view.GetSelectedRows()
        If selection Is Nothing Then
            Return Nothing
        End If

        Dim appointments As AppointmentBaseCollection = New AppointmentBaseCollection()
        Dim count As Integer = selection.Length
        Dim i As Integer = 0
        Do While i < count
            Dim rowIndex As Integer = selection(i)
            Dim apt As New Appointment
            apt.Subject = CStr(view.GetRowCellValue(rowIndex, "Crew"))
            apt.Description = CStr(view.GetRowCellValue(rowIndex, "IDNbr"))
            apt.LabelId = 2
            apt.Duration = TimeSpan.FromDays(180)
            appointments.Add(apt)
            i += 1
        Loop

        Return New SchedulerDragData(appointments, 0)
    End Function

    Private Function GetSelectedRows() As DataTable
        Dim _tbl As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn

        'comment out by fords 20171107 : set _tbl structure same as MainGrid.DataSource (see other note below)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "IDNbr"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "Crew"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "ActGrpID"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "CurrActID"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "VslName"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "RankName"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "StatName"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "FkeyRankCode"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "PlannedRank"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "PlannedWScaleRank"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "PlannedDateSON"
        'ccolumn.DataType = System.Type.GetType("System.DateTime")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "PlannedPlaceSON"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "FKeyPlannedVsl"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "PlannedToRelieveID"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)

        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "FKeyWScaleRankCode"
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)

        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "ActDateStart"
        'ccolumn.DataType = System.Type.GetType("System.DateTime")
        '_tbl.Columns.Add(ccolumn)

        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "FKeyStatCode"  'datasource shows StatCode
        'ccolumn.DataType = System.Type.GetType("System.String")
        '_tbl.Columns.Add(ccolumn)

        _tbl = CType(MainGrid.DataSource, DataTable).Copy
        _tbl.Clear()

        'Specify other column(s) needed for DragDrop
        'PlanEventCrewID = dummy column for SignOn form
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlanEventCrewID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        For Each xrow In MainView.GetSelectedRows
            _tbl.ImportRow(MainView.GetDataRow(xrow))
        Next

        Return _tbl
    End Function

    Private Sub MainView_RowCountChanged(sender As Object, e As System.EventArgs) Handles MainView.RowCountChanged
        'GridBand1.Caption = "Crew Count: " & MainView.RowCount
        GridBand1.Caption = "Crew Count: " & MainView.DataRowCount
        If MainView.RowCount = 0 Then
            SelectionChange(Name)
        End If
    End Sub


    Public Overrides Sub SaveLayout()

        SaveUserSetting("Layout_BiodataPicView", PicView)
        MPS4.SaveLayout(DB, Me.MainView, USER_ID, BaseControl, Name)

    End Sub

    Public Overrides Sub SetListLayout(ByVal _ObjectID As String)
        GetLayout(DB, Me.MainView, USER_ID, _ObjectID, Name)
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "SETTOPROWINDEX"
                MainView.TopRowIndex = param(1)
            Case "SortCrew_ASC"
                SortCrew_ASC(MainView)
            Case "SortCrew_DESC"
                SortCrew_DESC(MainView)
            Case "SortRank_ASC"
                SortRank_ASC(MainView)
            Case "SortRank_DESC"
                SortRank_DESC(MainView)
            Case "CrewList_Filter"
                isRefreshingData = True 'Added by Tony20161014
                ShowCustomLoadScreen(GetType(MPS4.Waitform), "Loading...")
                ClearDtCrewList()
                CrewList_Filter(MainView)
                'PopulateData()
                PrepareData()
                CloseCustomLoadScreen()
                isRefreshingData = False 'Added by Tony20161014
            Case "CLEAR_FILTER"
            Case "ForceRefresh"
                forceRefresh()
            Case "SetFocusedRank"
                Dim RowHandle As Integer = 0
                Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns(param(2))
                RowHandle = MainView.LocateByValue(0, Col, param(1))
                MainView.FocusedRowHandle = RowHandle
                MainView.TopRowIndex = RowHandle
            Case "RefreshList"
                ClearDtCrewList()
                RefreshData()
            Case "GetCrewList"
                dtCrewList = TryCast(MainView.DataSource, DataView).ToTable(True, New String() {"IDNbr"})

            Case "SON_DraggedOutPlannedCrew"
                'this section added by tony20170607
                DraggedOutPlannedCrew(TryCast(param(1), System.Windows.Forms.DragEventArgs))
        End Select
        If Not IsNothing(bContent) Then
            Try
                If MainView.DataRowCount > 0 Then
                    selectedID = MainView.GetFocusedRowCellValue("IDNbr") 'Added By Calvhin 20160413
                    SetSelection(selectedID)
                Else
                    bContent.ExecCustomFunction(New Object() {"ClearContent"})
                End If
            Catch ex As Exception
                LogErrors("--Error Generated in ExecCustomFunction() method in CrewList.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in ExecCustomFunction() method in CrewList.vb - End--")

                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub initControl()
        If MAIN_CONTENT <> "LTP" Then repStatCode.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmStat")
        isActivated = False
        secPermission.propSQLConnStr = MPSDB.GetConnectionString()

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
    End Sub

    Public Overrides Function getBListDatasource()
        Return dt
    End Function

    Private Sub rightClick_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarManager1.ItemClick
        If e.Item.Name <> "AddComment" And e.Item.Name <> "PrintBio" Then
            Select Case e.Item.Name
                Case "LTPCopy"
                    Dim apt As New Appointment
                    apt.Subject = MainView.GetFocusedRowCellValue("Crew")
                    apt.Description = MainView.GetFocusedRowCellValue("IDNbr")
                    apt.LabelId = 2
                    copiedApt = apt
                Case "ViewAct"
                    RaiseCustomEvent(Name, New Object() {e.Item.Name, GetID(), GetDesc()})
                Case "ViewExpDocs"
                    RaiseCustomEvent(Name, New Object() {e.Item.Name, GetID(), GetDesc()})
                Case "TravInfo"
                    Try
                        Dim dt As DataTable = DB.CreateTable("SELECT TOP 1 * FROM view_CrewPopupDetails WHERE PKey = '" & selectedID & "'")
                        If IsNothing(dt) Then Exit Sub
                        If dt.Rows.Count = 0 Then Exit Sub
                        'CLIPBOARD CONTENT
                        strContent = ""
                        strContent = strContent & "Crew Information" & vbNewLine
                        strContent = strContent & "Company ID       : " & dt(0)("COIDNo") & vbNewLine
                        strContent = strContent & "Name             : " & dt(0)("Crew") & vbNewLine
                        strContent = strContent & "Rank             : " & dt(0)("Rank") & vbNewLine
                        strContent = strContent & "Nationality      : " & dt(0)("Nat") & vbNewLine
                        strContent = strContent & "Date of Birth    : " & dt(0)("DOB") & vbNewLine
                        strContent = strContent & "Place of Birth   : " & dt(0)("POB") & vbNewLine
                        strContent = strContent & vbNewLine
                        strContent = strContent & "Passport" & vbNewLine &
                                                  "Number           : " & dt(0)("PPNum") & vbNewLine &
                                                  "Date Issue       : " & dt(0)("PPDI") & vbNewLine &
                                                  "Date Expiry      : " & dt(0)("PPDE") & vbNewLine &
                                                  "Place Issued     : " & dt(0)("PPIP") & vbNewLine
                        strContent = strContent & vbNewLine
                        strContent = strContent & "Seaman's Book" & vbNewLine &
                                                  "Number           : " & dt(0)("SBNum") & vbNewLine &
                                                  "Date Issue       : " & dt(0)("SBDI") & vbNewLine &
                                                  "Date Expiry      : " & dt(0)("SBDE")
                        'LOAD CONTENT
                        txtCOIDNo.EditValue = dt(0)("COIDNo")
                        txtCrew.EditValue = dt(0)("Crew")
                        txtRank.EditValue = dt(0)("Rank")
                        txtNat.EditValue = dt(0)("Nat")
                        txtDOB.EditValue = dt(0)("DOB")
                        txtPOB.EditValue = dt(0)("POB")
                        txtPPNum.EditValue = dt(0)("PPNum")
                        txtPPIssue.EditValue = dt(0)("PPDI")
                        txtPPExpiry.EditValue = dt(0)("PPDE")
                        txtPPPlace.EditValue = dt(0)("PPIP")
                        txtSBNum.EditValue = dt(0)("SBNum")
                        txtSBIssue.EditValue = dt(0)("SBDI")
                        txtSBExpiry.EditValue = dt(0)("SBDE")

                        fpMain.ShowBeakForm(_controlMousePointer, True, Me)
                    Catch ex As Exception
                        MsgBox("Encounted an error while loading data." & vbNewLine & "Please contact your Administrator.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName())
                    End Try

                Case "PrintPOEAContract"
                    Try
                        Dim f As New frmPopupPrintPOEAContract(selectedID)

                        f.ShowDialog()
                    Catch ex As Exception
                        MsgBox("There is no selected record(s) crew. Please try again.", vbInformation)
                    End Try

                Case Else
                    RaiseCustomEvent(Name, New Object() {"GoTo", e.Item.Name, "Crew"})
            End Select
        Else
            Dim CrewID As String = GetID()
            If e.Item.Name = "PrintBio" Then
                Try
                    Dim frmRptSel As New ReportSelectionInd(CrewID)
                    frmRptSel.ShowDialog(Me)
                Catch ex As Exception
                    LogErrors("--Error Generated in rightClick_ItemClick() method in CrewList.vb - Start --")
                    LogErrors(ex.Message)
                    LogErrors("--Error Generated in rightClick_ItemClick() method in CrewList.vb - End--")

                    MsgBox("There is no selected record(s) to preview. Please try again.", vbInformation)
                End Try
            Else
                Dim commentDT As New DataTable
                commentDT = DB.CreateTable("SELECT *, '' as Remarks FROM dbo.frmCrew_Comment WHERE FKeyIDNbr = '" & CrewID & "' ORDER BY ComDate DESC")

                Dim cCrewName = AssembleName(IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "LName"), ""), _
                                             IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "FName"), ""), _
                                             IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "MName"), ""))
                Dim frm As New frmCrewComments(commentDT, CrewID, cCrewName)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub MainView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles MainView.PopupMenuShowing
        selectedID = MainView.GetRowCellValue(e.HitInfo.RowHandle, "IDNbr")
        _controlMousePointer = Control.MousePosition
    End Sub

    Private Sub forceRefresh()
        'Throw New NotImplementedException
        'getCrewListDataTable(bListSelect, "Automatic") 'Refresh CrewList 'removed by calvhin 20170120, redundant
        ClearDtCrewList()
        RefreshData()
    End Sub

    Public Sub AssignGridMarkSelection()
        If (GridCheckMarksSelection Is Nothing) Then
            GridCheckMarksSelection = New MPS5.DevExpress.XtraGrid.Selection.GridCheckMarksSelection(MainView)
        ElseIf (GridCheckMarksSelection.View Is Nothing) Then
            GridCheckMarksSelection = New MPS5.DevExpress.XtraGrid.Selection.GridCheckMarksSelection(MainView)
        End If
        selectedCrewForArchive = GridCheckMarksSelection.SelectedCount
    End Sub

    Public Sub ValidatePermission()

        Dim retVal As Integer = 1
        Dim isAdmin As String = secPermission.isUserAdmin(USER_ID, retVal)


        If retVal = 1 Then
            frmCrewMain.bbiStartArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            frmCrewMain.DeleteCrew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            frmCrewMain.rpgArchiveProcess.Visible = True
            AssignGridMarkSelection()
        Else
            If SelectedTab.Equals("Archive") Then
                If secPermission.hasNoUpdatePermission("CrewListArchive", USER_ID) = 1 Then
                    frmCrewMain.bbiStartArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Else
                    frmCrewMain.bbiStartArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    AssignGridMarkSelection()
                End If
            ElseIf SelectedTab.Equals("ArchiveCrews") Then
                If secPermission.hasNoUpdatePermission("ArchivedCrews", USER_ID) = 1 Then
                    frmCrewMain.rpgArchiveProcess.Visible = False
                Else
                    frmCrewMain.rpgArchiveProcess.Visible = True
                    AssignGridMarkSelection()
                End If

                If secPermission.hasNoDeletePermission("ArchivedCrews", USER_ID) = 1 Then
                    frmCrewMain.DeleteCrew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Else
                    frmCrewMain.DeleteCrew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                End If
            End If
        End If
    End Sub

    Public Overrides Sub ActivateArchive()

        If SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews") Then
            If (Not isActivated) Then
                isActivated = True
                PopulateData()
                MainView.ExpandAllGroups()
                ValidatePermission()
                MainView.Columns("DueDate").Visible = False
                MainView.Columns("DateSOff").Visible = True
            End If
        Else
            If (isActivated) Then
                PopulateData()
                selectedCrewForArchive = 0
                frmCrewMain.bbiStartArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                MainView.Columns("DueDate").Visible = True
                MainView.Columns("DateSOff").Visible = False
                isActivated = False
            End If
            If Not (GridCheckMarksSelection Is Nothing) Then
                Try
                    GridCheckMarksSelection.View = Nothing
                Catch ex As Exception
                    LogErrors("--Error Generated in ActivateArchive() method in CrewList.vb - Start --")
                    LogErrors(ex.Message)
                    LogErrors("--Error Generated in ActivateArchive() method in CrewList.vb - End--")
                End Try
            End If
        End If
    End Sub

    Public Sub PopulateData()

        expDocDays = IIf(GetUserSetting("DocExpDays") <> "", Val(GetUserSetting("DocExpDays")), 0)
        userdatafilter = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")

        If SelectedTab.Equals("Archive") Then
            userdatafilter = FormatCriteriaInArchive(IIf(userdatafilter.Trim().Length > 0, userdatafilter & " AND [StatType] = 3 ", " [StatType] = 3 "))
            bListSelect = "EXEC [SP_Crewlist_Activities] @ExpDocDays = " & expDocDays & ", @ExpContractDays = " & expDueDateDays & ", @userdatafilterstring = '" & userdatafilter & "'"
            Me.MainGrid.DataSource = MPSDB.CreateTable(bListSelect)
        ElseIf SelectedTab.Equals("ArchiveCrews") Then
            Dim archiveFilter As String = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
            bListSelect = "EXEC [SP_Archived_Crewlist_Activities] @ExpDocDays = " & expDocDays & ", @userdatafilterstring = '" & Replace(archiveFilter, "'", "''") & "'"
            dt = MPSDB.CreateTable(bListSelect)
            Me.MainGrid.DataSource = dt
            If (dt.Rows.Count > 0) Then
                frmCrewMain.bbiStartTransferToActive.Enabled = True
            Else
                frmCrewMain.bbiStartTransferToActive.Enabled = False
            End If
        Else
            Try
                userdatafilter = FormatCriteriaInArchive(userdatafilter)
                bListSelect = "EXEC [SP_Crewlist_Activities] @ExpDocDays = " & expDocDays & ", @ExpContractDays = " & expDueDateDays & ", @userdatafilterstring = '" & userdatafilter & "'"
                dt = CrewList_Datasource(DB, expDocDays, expDueDateDays, userdatafilter)
                Me.MainGrid.DataSource = dt
                Try
                    MainView.Columns("DueDate").Visible = True
                    MainView.Columns("DateSOff").Visible = False
                Catch ex As Exception
                End Try
            Catch ex As Exception
                LogErrors("--Error Generated in PopulateDate() method in CrewList.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in PopulateDate() method in CrewList.vb - End--")

                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Public Function FormatCriteriaInArchive(ByVal originalCriteria As String) As String

        Dim retVal As String = ""
        Dim criteriaMonthsAshore As String = ""

        If (strCrewListFilter.Trim().Length > 0) Then
            If (originalCriteria.Trim().Length > 0) Then
                retVal = strCrewListFilter.Replace("''", "'").Replace("'", "''") + " AND " + Replace(originalCriteria, "'", "''")
            Else
                retVal = strCrewListFilter.Replace("''", "'").Replace("'", "''")
            End If
        Else
            retVal = Replace(originalCriteria, "'", "''")
        End If

        If Not MonthsAshore.Equals("0") And Not MonthsAshore.Equals("") Then
            If retVal.Contains(MonthsAshoreCriteria + MonthsAshore) Then
                retVal = retVal.Replace(MonthsAshoreCriteria + MonthsAshore, "").Trim()
                strCrewListFilter = strCrewListFilter.Replace(MonthsAshoreCriteria + MonthsAshore, "").Trim()
            End If

            If retVal.Trim().StartsWith("AND") Then
                retVal = retVal.Substring(3).Trim()
            End If

            If strCrewListFilter.Trim().StartsWith("AND") Then
                strCrewListFilter = strCrewListFilter.Substring(3).Trim()
            End If

            If SelectedTab.Equals("Archive") Then
                criteriaMonthsAshore = IIf(retVal.Trim.Length > 0, " AND " + MonthsAshoreCriteria + MonthsAshore, "")
            End If
        Else
            criteriaMonthsAshore = ""
        End If

        Return retVal & criteriaMonthsAshore

    End Function

    Public Sub SetGridReadOnlyProperties(controlGrid As GridView, Optional isReadOnly As Boolean = True)
        With controlGrid
            Select Case isReadOnly
                Case True
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                    .OptionsBehavior.ReadOnly = True
                Case Else
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                    .OptionsBehavior.ReadOnly = False
            End Select
        End With
    End Sub

    Public Overrides Sub SetAllSelected(status As Boolean)
        'Include all crews in Archive. 
        If status Then
            GridCheckMarksSelection.SelectAll()
        Else
            GridCheckMarksSelection.ClearSelection()
        End If
    End Sub

    Public Overrides Sub RunSetToArchiveProcess()

        Dim count As Integer = GridCheckMarksSelection.SelectedCount
        Dim archiveResult As Boolean = False
        Dim message = "You are about to archive " & count & " selected crew" & IIf(count > 1, "s", "") & ". Proceed? "

        If count = 0 Then
            MessageBox.Show("No crew selected for archiving.", "Crew Archiving", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        ElseIf count > 1000 Then
            MessageBox.Show("You can only archive a maximum of 1000 crews at a time. Please uncheck/deselect some of the crews to be archived.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            If DialogResult.Yes = MessageBox.Show(message, "Crew Archiving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Try
                    Dim archive = New MPSArchiveUtil()
                    Waitform.SetCaption("Archiving Selected Crews...")
                    SplashScreenManager.ShowForm(GetType(Waitform))

                    selectedCrewName = ""

                    archiveResult = archive.RunTransferToArchive(GetSelectedCrewID())
                    If archiveResult = True Then

                        Dim retlogid As Long, array_idnbr() As String, array_crew() As String

                        array_idnbr = selectedCrewID.ToString.Split(",")
                        array_crew = selectedCrewName.Split(";")
                        For i As Integer = 0 To array_crew.Count - 1
                            If array_crew(i) <> "" Then
                                clsAudit.saveAuditLog("Transfer to Archive", USER_NAME, retlogid, System.Environment.MachineName, 0, _
                                                      , , , Replace(array_idnbr(i), "'", ""), _
                                                      "Crew : " & Replace(array_crew(i), ";", ""), "Record Summary", _
                                                      getServerDateTime)
                            End If
                        Next

                        AddToLogTransfer(TransferType.TransferToArchive, array_idnbr)
                        selectedCrewID.Clear()  'added by tony20180116

                        MessageBox.Show("Crew/s successfully transfered to archive.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        SetAllSelected(False)
                        RefreshData()
                    Else
                        MessageBox.Show("There is a problem while archiving selected crews.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    LogErrors("--Error Generated in RunSetToArchiveProcess() method in CrewList.vb - Start --")
                    LogErrors(ex.Message)
                    LogErrors("--Error Generated in RunSetToArchiveProcess() method in CrewList.vb - End--")

                    MessageBox.Show(ex.Message)
                Finally
                    Try
                        SplashScreenManager.CloseForm()
                    Catch ex As Exception
                        LogErrors("--Error Calling SplashScreenManager.CloseForm() in RunSetToArchiveProcess() method in CrewList.vb - Start --")
                        LogErrors(ex.Message)
                        LogErrors("--Error Calling SplashScreenManager.CloseForm() in RunSetToArchiveProcess() method in CrewList.vb - End--")
                    End Try
                End Try
            End If
        End If

    End Sub

    Private Sub AddToLogTransfer(oTransferType As TransferType, ArrayIDNbr() As String)
        Dim SelectedCrewID As New System.Text.StringBuilder
        Dim LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Transfer to " & IIf(oTransferType = TransferType.TransferToArchive, TransferTypeTableValue.TransferToArchive, IIf(oTransferType = TransferType.TransferBackToActive, TransferTypeTableValue.TransferBackToActive, "[Undefined]")), 0, System.Environment.MachineName, "", "Crew Transfer")

        For i As Integer = 0 To ArrayIDNbr.GetUpperBound(0) - 1
            SelectedCrewID.Append(IIf(i > 0, ", ", "") & ArrayIDNbr(i))
        Next

        Dim WhereCond As String
        If SelectedCrewID.Length > 0 Then
            WhereCond = "PKey IN (" & SelectedCrewID.ToString & ")"
        Else
            WhereCond = "PKey IN ('')"
        End If
        WhereCond = WhereCond.Replace("'", "''")
        Dim cSQL As String = "INSERT INTO dbo.tblLog_Transfer( TransferType, WhereCond, DateUpdated, LastUpdatedBy) VALUES(" & IIf(oTransferType = TransferType.TransferToArchive, "'" & TransferTypeTableValue.TransferToArchive & "'", IIf(oTransferType = TransferType.TransferBackToActive, "'" & TransferTypeTableValue.TransferBackToActive & "'", "NULL")) & ", '" & WhereCond & "', getdate(), '" & LastUpdatedBy & "') "
        MPSDB.RunSql(cSQL)
    End Sub


    Public Function GetSelectedCrewID() As String
        With MainView
            For i As Integer = 0 To .RowCount - 1
                'GridCheckMarksSelection.IsRowSelected(i)
                If GridCheckMarksSelection.IsRowSelected(i) Then
                    'selectedCrewID += ("'" + .GetRowCellValue(i, "IDNbr") & "',")
                    selectedCrewID.Append("'" + .GetRowCellValue(i, "IDNbr") & "',")
                    selectedCrewName = selectedCrewName & .GetRowCellDisplayText(i, "LName") & "," & _
                                        .GetRowCellDisplayText(i, "FName") & " " & .GetRowCellDisplayText(i, "MName") & ";" 'neil
                End If
            Next
        End With
        Return IIf(selectedCrewID.Length <= 0, "", selectedCrewID.ToString().Substring(0, selectedCrewID.Length - 1))
    End Function

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        Try
            selectedCrewForArchive = GridCheckMarksSelection.SelectedCount
            bContent.RefreshData()
        Catch ex As Exception
            LogErrors("--Error Generated in MainView_CellValueChanged() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in MainView_CellValueChanged() method in CrewList.vb - End--")

        End Try
    End Sub

    Public Overrides Sub RunSetToActiveProcess()
        MyBase.RunSetToArchiveProcess()
        Dim count As Integer = GridCheckMarksSelection.SelectedCount
        Dim archiveResult As Boolean = False
        Dim message = "You are about to set to active " & count & " crew" & IIf(count > 1, "s", "") & ". Proceed? "

        If count = 0 Then
            MessageBox.Show("No crew selected to be transfer to Active.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        ElseIf count > 1000 Then
            MessageBox.Show("You can only archive a maximum of 1000 crews at a time. Please uncheck/deselect some of the crews to be archived.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            If DialogResult.Yes = MessageBox.Show(message, "Archive Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Try
                    Dim archive = New MPSArchiveUtil()
                    SplashScreenManager.ShowForm(GetType(Waitform))
                    SplashScreenManager.Default.SetWaitFormDescription("Processing crews to active ..")
                    archive.SetConnectionsDetails(MPS4BasicFunctions.SQLServer, MPS4BasicFunctions.SQLID, MPS4BasicFunctions.SQLPW, "MPSARC")

                    selectedCrewName = ""

                    archiveResult = archive.RunTrasferToActive(GetSelectedCrewID())
                    If archiveResult = True Then

                        Dim retlogid As Long, array_idnbr() As String, array_crew() As String

                        array_idnbr = selectedCrewID.ToString.Split(",")
                        array_crew = selectedCrewName.Split(";")
                        For i As Integer = 0 To array_crew.Count - 1
                            If array_crew(i) <> "" Then
                                clsAudit.saveAuditLog("Transfer to Active", USER_NAME, retlogid, System.Environment.MachineName, 0, _
                                                      , , , Replace(array_idnbr(i), "'", ""), _
                                                      "Crew : " & Replace(array_crew(i), ";", ""), "Record Summary", _
                                                      getServerDateTime)
                            End If
                        Next

                        AddToLogTransfer(TransferType.TransferBackToActive, array_idnbr)
                        selectedCrewID.Clear() 'added by tony20180116
                        MessageBox.Show("Crew" & IIf(count > 1, "s", "") & " successfully transfered to active.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        SetAllSelected(False)
                        RefreshData()
                    Else
                        MessageBox.Show("There is a problem while setting the crews to active", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    LogErrors("--Error Generated in RunSetToActiveProcess() method in CrewList.vb - Start --")
                    LogErrors(ex.Message)
                    LogErrors("--Error Generated in RunSetToActiveProcess() method in CrewList.vb - End--")

                    MessageBox.Show(ex.Message)
                Finally
                    Try
                        SplashScreenManager.CloseForm()
                    Catch ex As Exception
                        LogErrors("--Error Calling SplashScreenManager.CloseForm() in RunSetToActiveProcess() method in CrewList.vb - Start --")
                        LogErrors(ex.Message)
                        LogErrors("--Error Calling SplashScreenManager.CloseForm() in RunSetToActiveProcess() method in CrewList.vb - End--")
                    End Try
                End Try
            End If
        End If

    End Sub

    Private Sub MainView_EndSorting(sender As System.Object, e As System.EventArgs) Handles MainView.EndSorting
        SaveCrewListViewSort(MainView)
    End Sub

    Private Sub GetSelectedID() 'Added by Tony20161014
        Try
            If isRefreshingData Then
                selectedID = IIf(IfNull(selectedID, "").Equals(""), IfNull(MainView.GetFocusedRowCellValue("IDNbr"), String.Empty), selectedID)

                bSkipGetSelectedID = True
                SetSelection(selectedID)
                bSkipGetSelectedID = False
            Else
                selectedID = IfNull(MainView.GetFocusedRowCellValue("IDNbr"), String.Empty)
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in GetSelectedID() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetSelectedID() method in CrewList.vb - End--")

            MsgBox("Error when getting the selected crew's id. " & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub MainView_ColumnFilterChanged(sender As System.Object, e As System.EventArgs) Handles MainView.ColumnFilterChanged
        SaveCrewListFindText(MainView)
    End Sub

    Private Sub CrewList_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Public Sub LTPSetDB(ByVal mpsdb As SQLDB)
        DB = mpsdb
    End Sub

    Private Sub DraggedOutPlannedCrew(e As System.Windows.Forms.DragEventArgs)
        Try
            If bDraggable Then
                Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
                Dim row As DataRow
                If Not xtbl Is Nothing Then
                    For Each row In xtbl.Rows
                        Dim xfilter As String = MainView.ActiveFilterString
                        xfilter = xfilter.Replace(xfilter.Substring(xfilter.IndexOf(row("IDNbr"), 0) - 17, 17 + CType(row("IDNbr"), String).Length + 1), "")
                        SetFilter(xfilter)
                        AcceptDragObject(Name)
                    Next
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in MainGrid_DragDrop() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in MainGrid_DragDrop() method in CrewList.vb - End--")

        End Try
    End Sub

    Private Sub MainView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles MainView.FocusedRowObjectChanged
        Try
            If MainView.FocusedRowHandle >= 0 Then
                SelectionChange(Name)
                SelectedGroupID = MainView.GetRowCellValue(e.FocusedRowHandle, "ActGrpID").ToString()
                CrewCurrentRank = MainView.GetRowCellValue(e.FocusedRowHandle, "FKeyRankCode").ToString()
                If Not bSkipGetSelectedID Then GetSelectedID()
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in MainView_FocusedRowChanged() method in CrewList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in MainView_FocusedRowChanged() method in CrewList.vb - End--")
        End Try
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        fpMain.HideBeakForm(True)
    End Sub

    Private Sub cmdCopyToClip_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopyToClip.Click
        Try
            Clipboard.SetText(strContent, TextDataFormat.Text)
        Catch ex As Exception
        End Try
    End Sub
End Class
