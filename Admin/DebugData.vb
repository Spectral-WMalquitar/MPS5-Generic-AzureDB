Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid

Public Class DebugData

#Region "Declarations"
    Dim dtMPS5Tables As DataTable
    Dim dtCrewStat, dtCrewVsl, dtPayrollType, dtAppType, dtCrewName, dtCrewSelection, dtCrewSelected, dtCrewRecordType, dtPaySelection, dtPaySelected, dtUserName As New DataTable
    Dim folderPath As String
    Dim fileName As String
    Dim filePath As String
    Dim file As System.IO.StreamWriter

    Dim crewFrom As Date
    Dim crewTo As Date

#End Region

#Region "Overrides"
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If Not bLoaded Then
            InitData()
            InitControls()
            AllowSaving(Name, True)
            SetSaveCaption(Name, "Export")
        End If
    End Sub

    Public Overrides Sub SaveData()
        Select Case TabbedControlGroup1.SelectedTabPageIndex
            Case 0
                If IsNothing(cboCrewFrom.EditValue) Or IsNothing(cboCrewTo.EditValue) Then
                    MsgBox("Select date From and To.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
                    Exit Sub
                End If
                If dtCrewSelected.Rows.Count = 0 Then
                    MsgBox("Select atleast 1 crew.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
                    Exit Sub
                End If
                crewFrom = cboCrewFrom.EditValue
                crewTo = cboCrewTo.EditValue

            Case 1
                If dtPaySelected.Rows.Count = 0 Then
                    MsgBox("Select atleast 1 payroll.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
                    Exit Sub
                End If
            Case 2
                Exit Sub
        End Select

        SelectPath()
        If folderPath = "" Then
            MsgBox("Operation cancelled.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
            Exit Sub
        End If

        'CREATE TEXT FILE
        fileName = MPSDB.Settings("LOCATION_ID") & "_" & Format(DateTime.Now, "yyyyMMdd") & "_" & USER_NAME & ".txt"
        filePath = folderPath & "\" & fileName
        If System.IO.File.Exists(filePath) Then
            System.IO.File.Delete(filePath)
        End If
        System.IO.File.Create(filePath).Dispose()
        file = My.Computer.FileSystem.OpenTextFileWriter(filePath, True)

        file.WriteLine("USE MPS")
        'DISABLE DATA INTEGRITY CHECKING
        file.WriteLine("EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'")
        'DELETE ALL ROW OF ALL TABLE
        file.WriteLine("EXEC sp_msforeachtable 'DELETE FROM ?'")
        'file.WriteLine("EXEC sp_msforeachtable 'DBCC CHECKIDENT (''?'', RESEED, 0)'")
        'ENABLE DATA INTEGRITY CHECKING
        file.WriteLine("EXEC sp_msforeachtable 'ALTER TABLE ? WITH NOCHECK CHECK CONSTRAINT ALL'")

        'START INSERT QUIRIES HERE
        StartExport()

        'Export done
        file.Close()
        MsgBox("Operation successful.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, GetAppName)
    End Sub

#End Region

#Region "Functions/Subs"
    Private Sub InitData()
        Dim col As DataColumn

        col = New DataColumn("PKey", GetType(String))
        dtCrewStat.Columns.Add(col)
        col = New DataColumn("Name", GetType(String))
        dtCrewStat.Columns.Add(col)
        dtCrewStat.Rows.Add({"1", "ONBOARD"})
        dtCrewStat.Rows.Add({"3", "ASHORE"})

        dtCrewVsl = MPSDB.CreateTable("SELECT PKey, Name FROM tblAdmVsl WHERE VslStat = 1 ORDER BY Name")

        col = New DataColumn("PKey", GetType(String))
        dtPayrollType.Columns.Add(col)
        col = New DataColumn("Name", GetType(String))
        dtPayrollType.Columns.Add(col)
        dtPayrollType.Rows.Add({"1", "ONBOARD PAYROLL"})
        dtPayrollType.Rows.Add({"2", "ASHORE PAYROLL"})
        dtPayrollType.Rows.Add({"3", "SPECIAL ALLOTMENT"})

        col = New DataColumn("PKey", GetType(String))
        dtAppType.Columns.Add(col)
        col = New DataColumn("Name", GetType(String))
        dtAppType.Columns.Add(col)
        dtAppType.Rows.Add({"1", "CREWING"})
        dtAppType.Rows.Add({"2", "ADMIN"})

        dtCrewName = MPSDB.CreateTable("SELECT ci.PKey IDNbr, dbo.AssembleName(LName,FName,MName,1,1,0,0,0) AS Name, ca.StatName, ca.StatType, ca.FKeyVslCode FROM Current_Activites ca INNER JOIN tblCrewInfo ci ON ca.FKeyIDNbr = ci.PKey")
        dtCrewSelection = dtCrewName.Copy
        dtCrewSelected = dtCrewName.Copy
        dtCrewSelected.Clear()
        dtCrewRecordType = MPSDB.CreateTable("SELECT *, 1 AS isSelected FROM MSystblDebugData WHERE RecordGroup = 'CREW' ORDER BY SortCode")

        dtPaySelection = MPSDB.CreateTable(
            "SELECT p.PKey AS PayID, dbo.ChangeMCodeToPeriod(p.MCode, DEFAULT) AS Period, p.VslName AS Vessel, 'Onboard' AS Payroll, 1 AS PayType FROM tblPay p INNER JOIN tblPayCrew_ONB po ON p.PKey = po.FKeyPayID GROUP BY p.PKey, p.MCode, p.VslName" &
            " UNION " &
            "SELECT p.PKey AS PayID, dbo.ChangeMCodeToPeriod(p.MCode, DEFAULT) AS Period, p.VslName AS Vessel, 'Allotment' AS Payroll, 2 AS PayType FROM tblPay p INNER JOIN tblPayCrew_HA pa ON p.PKey = pa.FKeyPayID GROUP BY p.PKey, p.MCode, p.VslName" &
            " UNION " &
            "SELECT PKey AS PayID, dbo.ChangeMCodeToPeriod(MCode, DEFAULT) AS Period, 'SPECIAL' AS Vessel, 'Allotment' AS Payroll, 3 AS PayType FROM tblmpo GROUP BY PKey, MCode"
            )
        dtPaySelected = dtPaySelection.Copy
        dtPaySelected.Clear()

        dtUserName = MPSDB.CreateTable("SELECT ID AS PKey, Name FROM MSysSec_Users")
    End Sub

    Private Sub InitControls()
        cboCrewStatus.Properties.DataSource = dtCrewStat
        cboCrewVsl.Properties.DataSource = dtCrewVsl
        gcCrewSelection.DataSource = dtCrewSelection
        gcCrewSelected.DataSource = dtCrewSelected
        gcCrewSpecs.DataSource = dtCrewRecordType

        cboPayrollType.Properties.DataSource = dtPayrollType
        gcPayrollSelection.DataSource = dtPaySelection
        gcPayrollSelected.DataSource = dtPaySelected

        cboAppType.Properties.DataSource = dtAppType
        cboCrewName.Properties.DataSource = dtCrewName
        cboUserName.Properties.DataSource = dtUserName

        SetUpGrid(gcCrewSelection)
        SetUpGrid(gcCrewSelected)
        SetUpGrid(gcPayrollSelection)
        SetUpGrid(gcPayrollSelected)
    End Sub

    Private Sub CheckAllSpecs(val As Integer)
        For cnt As Integer = 0 To dtCrewRecordType.Rows.Count - 1
            dtCrewRecordType(cnt)("isSelected") = val
        Next
    End Sub

    Private Sub SelectPath()
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = DialogResult.OK Then
            folderPath = fbd.SelectedPath
        End If
    End Sub

    Private Function FieldNames(dtTable As DataTable) As String ', Optional specificFields As String = ""
        Dim fields As String = ""
        'If specificFields <> "" Then
        '    fields = "[" & specificFields.Replace(",", "],[") & "]"
        'Else
        For cnt As Integer = 0 To dtTable.Columns.Count - 1
            fields = fields & "[" & dtTable.Columns(cnt).ColumnName & "]"
            fields = fields & IIf(cnt = dtTable.Columns.Count - 1, "", ",")
        Next
        'End If
        Return fields
    End Function

    Private Function FieldValues(dtTable As DataTable, index As Integer) As String ', Optional specificFields As String = ""
        Dim values As String = ""
        For cnt As Integer = 0 To dtTable.Columns.Count - 1
            If IsDBNull(dtTable(index)(cnt)) Then
                values = values & "NULL"
            Else
                values = values & "'" & CleanInput(dtTable(index)(cnt).ToString) & "'"
            End If
            values = values & IIf(cnt = dtTable.Columns.Count - 1, "", ",")
        Next
        Return values
    End Function

    Private Function IsIdentity(tableName As String, columnName As String)
        Dim dtTemp As DataTable = MPSDB.CreateTable("SELECT COLUMNPROPERTY(OBJECT_ID('" & tableName & "'), '" & columnName & "', 'isIdentity')")

        If dtTemp.Rows.Count > 0 Then
            If dtTemp(0)(0) <> 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function HasIdentity(dtTable As DataTable)
        For cnt As Integer = 0 To dtTable.Columns.Count - 1
            If IsIdentity(dtTable.TableName, dtTable.Columns(cnt).ColumnName) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Export_Table(tableName As String, Optional specificFields As String = "", Optional tableQuery As String = "", Optional parentFKey As String = "", Optional parentVals As String = "", Optional filter As String = "", Optional dateFilter As String = "")
        Dim dtTemp As DataTable
        Dim sqlValues As String = ""
        Dim fNames As String = ""

        'construct sql
        Dim sql As String = "SELECT "
        sql = sql & IIf(specificFields <> "", specificFields, "*")
        If tableQuery <> "" Then
            sql = tableQuery
        Else
            sql = sql & " FROM " & tableName
        End If

        Dim sqlWhere As String = ""
        If filter <> "" Then
            sqlWhere = " WHERE " & filter '& " AND " & parentFKey & " IN (" & parentVals & ")"
            sqlWhere = sqlWhere & IIf(parentFKey <> "", " AND " & parentFKey & " IN (" & parentVals & ")", "")
        ElseIf parentFKey <> "" Then
            sqlWhere = " WHERE " & parentFKey & " IN (" & parentVals & ")"
        End If

        If sqlWhere <> "" Then
            sqlWhere = sqlWhere & IIf(dateFilter <> "", " AND " & dateFilter, "")
        Else
            sqlWhere = IIf(dateFilter <> "", " WHERE " & dateFilter, "")
        End If

        dtTemp = MPSDB.CreateTable(sql & sqlWhere)
        dtTemp.TableName = tableName

        If dtTemp.Rows.Count <> 0 Then
            fNames = FieldNames(dtTemp)
            If HasIdentity(dtTemp) Then
                file.WriteLine("SET IDENTITY_INSERT " & tableName & " ON")
            End If

            For cntRow As Integer = 0 To dtTemp.Rows.Count - 1
                sqlValues = "INSERT INTO " & tableName & " (" & fNames & ") VALUES (" & FieldValues(dtTemp, cntRow) & ")"
                file.WriteLine(sqlValues)
            Next

            If HasIdentity(dtTemp) Then
                file.WriteLine("SET IDENTITY_INSERT " & tableName & " OFF")
            End If
        End If
    End Sub

    Private Sub Export_Tables(tablesList As DataTable, fieldName As String, criteria As String, sort As String)
        Dim tableName As String = ""
        Dim dtTables As DataTable

        dtTables = tablesList.Select(criteria).CopyToDataTable
        dtTables.DefaultView.Sort = sort
        dtTables = dtTables.DefaultView.ToTable
        If dtTables.Rows.Count = 0 Then Exit Sub

        For cnt As Integer = 0 To dtTables.Rows.Count - 1
            tableName = dtTables(cnt)(fieldName)
            Export_Table(tableName)
        Next
    End Sub

    Private Sub StartExport()
        dtMPS5Tables = MPSDB.CreateTable("SELECT OrderNo, TableName FROM MSysTableHierarchy ORDER BY OrderNo ASC")

        'MSys and Admin tables
        Export_Tables(dtMPS5Tables, "TableName", "TableName LIKE 'MSys%' OR TableName LIKE 'tblAdm%'", "OrderNo ASC")
        'Required tables
        Dim tblReq As DataTable = MPSDB.CreateTable("SELECT TableName FROM MSystblDebugDataTables WHERE FKeyDebugData = 'STI000000000000' ORDER BY SortCode")
        For cnt As Integer = 0 To tblReq.Rows.Count - 1
            Export_Table(tblReq(cnt)("TableName").ToString)
        Next
        Select Case TabbedControlGroup1.SelectedTabPageIndex
            Case 0
                ExportCrew()
            Case 1
                ExportPayroll()
            Case 2
                'ExportAudit()
        End Select
    End Sub

    Private Sub ExportCrew()
        'collect tables to export
        Dim fKeyDebugData As String = ""
        Dim tmpdtCrewRecordType As DataTable = dtCrewRecordType.Select("isSelected <> 0").CopyToDataTable
        For cnt As Integer = 0 To tmpdtCrewRecordType.Rows.Count - 1
            fKeyDebugData = fKeyDebugData & "'" & tmpdtCrewRecordType(cnt)("PKey") & "'"
            fKeyDebugData = fKeyDebugData & IIf(cnt = tmpdtCrewRecordType.Rows.Count - 1, "", ",")
        Next
        Dim tables As DataTable = MPSDB.CreateTable("SELECT DISTINCT h.OrderNo, t.TableName, t.TableQuery, t.ParentFKey, t.Filter, t.DateColumn " &
                                                    "FROM MSystblDebugDataTables t INNER JOIN " &
                                                        "MSystblDebugData c ON t.FKeyDebugData = c.PKey INNER JOIN " &
                                                        "MSysTableHierarchy h ON h.TableName = t.TableName " &
                                                    "WHERE FKeyDebugData IN (" & fKeyDebugData & ") " &
                                                    "ORDER BY h.OrderNo")
        'concat all crewID
        Dim _idnbrs As String = ""
        For cnt As Integer = 0 To dtCrewSelected.Rows.Count - 1
            _idnbrs = _idnbrs & "'" & dtCrewSelected(cnt)("IDNbr") & "'"
            _idnbrs = _idnbrs & IIf(cnt = dtCrewSelected.Rows.Count - 1, "", ",")
        Next

        Dim dateFilter As String = ""

        For cnt As Integer = 0 To tables.Rows.Count - 1

            dateFilter = ""
            If Not IsDBNull(tables(cnt)("DateColumn")) Then
                dateFilter = tables(cnt)("DateColumn") & " BETWEEN " & ChangeToSQLDate(cboCrewFrom.EditValue) & " AND " & ChangeToSQLDate(cboCrewTo.EditValue)
            End If

            Export_Table(IfNull(tables(cnt)("TableName"), ""),
                         "",
                         IfNull(tables(cnt)("TableQuery"), ""),
                         IfNull(tables(cnt)("ParentFKey"), ""),
                         _idnbrs,
                         IfNull(tables(cnt)("Filter"), ""),
                         dateFilter)
        Next

        Dim drs As DataRow() = tables.Select("TableName='tblCrewInfo'")
        If drs.Count = 0 Then
            'export selected columns only : ID,PKey,COIDNo,LName,FName,MName,IDFromPrevDB
            Export_Table("tblCrewInfo",
                         "ID,PKey,COIDNo,LName,FName,MName,IDFromPrevDB",
                         "",
                         "PKey",
                         _idnbrs,
                         "",
                         "")
        End If

        dateFilter = "DateDep BETWEEN " & ChangeToSQLDate(cboCrewFrom.EditValue) & " AND " & ChangeToSQLDate(cboCrewTo.EditValue)
        Export_Table("tblActivityGroup",
                     "",
                     "",
                     "FKeyIDNbr",
                     _idnbrs,
                     "",
                     dateFilter)

        dateFilter = "ActDateStart BETWEEN " & ChangeToSQLDate(cboCrewFrom.EditValue) & " AND " & ChangeToSQLDate(cboCrewTo.EditValue)
        Export_Table("tblActivity",
                     "",
                     "SELECT a.* FROM tblActivity a INNER JOIN tblActivityGroup g ON a.FKeyActivityGroupID = g.PKey",
                     "FKeyIDNbr",
                     _idnbrs,
                     "",
                     dateFilter)
    End Sub

    Private Sub ExportPayroll()
        'concat all crewID
        Dim _payIDs As String = ""
        For cnt As Integer = 0 To dtPaySelected.Rows.Count - 1
            _payIDs = _payIDs & "'" & dtPaySelected(cnt)("PayID") & "'"
            _payIDs = _payIDs & IIf(cnt = dtPaySelected.Rows.Count - 1, "", ",")
        Next

        Dim tblPayTables As DataTable = MPSDB.CreateTable("SELECT * FROM MSystblDebugDataTables WHERE FKeyDebugData = 'STI000000000020' ORDER BY SortCode")
        For cnt As Integer = 0 To tblPayTables.Rows.Count - 1
            Export_Table(tblPayTables(cnt)("TableName").ToString,
                         "",
                         tblPayTables(cnt)("TableQuery").ToString,
                         tblPayTables(cnt)("ParentFKey").ToString,
                         _payIDs,
                         "",
                         "")
        Next

    End Sub

#End Region

#Region "DragDrop Events"
    Private downHitInfo As GridHitInfo = Nothing

    Public Sub SetUpGrid(ByVal grid As GridControl)
        grid.AllowDrop = True
        AddHandler grid.DragOver, AddressOf grid_DragOver
        AddHandler grid.DragDrop, AddressOf grid_DragDrop
        Dim view As GridView = TryCast(grid.MainView, GridView)
        view.OptionsBehavior.Editable = False
        AddHandler view.MouseMove, AddressOf view_MouseMove
        AddHandler view.MouseDown, AddressOf view_MouseDown
    End Sub

    Private Sub view_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        downHitInfo = Nothing
        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left AndAlso hitInfo.RowHandle >= 0 Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub view_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                Dim row As DataRow = view.GetDataRow(downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub grid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub grid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim grid As GridControl = TryCast(sender, GridControl)
        Dim table As DataTable = TryCast(grid.DataSource, DataTable)
        Dim row As DataRow = TryCast(e.Data.GetData(GetType(DataRow)), DataRow)
        If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
            table.ImportRow(row)
            row.Delete()
            dtCrewSelection.AcceptChanges()
            dtCrewSelected.AcceptChanges()
            dtPaySelection.AcceptChanges()
            dtPaySelected.AcceptChanges()
        End If
    End Sub

#End Region

#Region "Controls events"
    Private Sub cboCrewFilter_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboCrewStatus.EditValueChanged, cboCrewVsl.EditValueChanged
        Dim filter As String = ""
        filter = IIf(IsNothing(cboCrewStatus.EditValue), "", "StatType = " & cboCrewStatus.EditValue)
        filter = filter & IIf(IsNothing(cboCrewVsl.EditValue), "", IIf(filter = "", "", " AND ") & " FKeyVslCode = '" & cboCrewVsl.EditValue & "'")

        dtCrewSelection.DefaultView.RowFilter = filter
    End Sub

    Private Sub btnSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectAll.Click
        gvCrewSelection.OptionsSelection.MultiSelect = True
        gvCrewSelection.SelectAll()

        For Each row As Integer In gvCrewSelection.GetSelectedRows()
            dtCrewSelected.ImportRow(gvCrewSelection.GetDataRow(row))
        Next

        gvCrewSelection.DeleteSelectedRows()
        gvCrewSelection.OptionsSelection.MultiSelect = False

        dtCrewSelection.AcceptChanges()
        dtCrewSelected.AcceptChanges()
    End Sub

    Private Sub btnDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnDeselectAll.Click
        gvCrewSelected.OptionsSelection.MultiSelect = True
        gvCrewSelected.SelectAll()

        For Each row As Integer In gvCrewSelected.GetSelectedRows()
            dtCrewSelection.ImportRow(gvCrewSelected.GetDataRow(row))
        Next

        gvCrewSelected.DeleteSelectedRows()
        gvCrewSelected.OptionsSelection.MultiSelect = False

        dtCrewSelection.AcceptChanges()
        dtCrewSelected.AcceptChanges()
    End Sub

    Private Sub cboPayrollType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPayrollType.EditValueChanged
        If IsNothing(cboPayrollType.EditValue) Then
            dtPaySelection.DefaultView.RowFilter = ""
        Else
            dtPaySelection.DefaultView.RowFilter = "PayType = " & cboPayrollType.EditValue '& " AND NOT PayID IN (" & payrollFilter & ")"
        End If
    End Sub

    Private Sub cbo_Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPayrollType.Properties.ButtonClick, cboCrewStatus.Properties.ButtonClick, cboCrewVsl.Properties.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub btnCheckAll_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckAll.Click
        CheckAllSpecs(1)
    End Sub

    Private Sub btnUncheckAll_Click(sender As System.Object, e As System.EventArgs) Handles btnUncheckAll.Click
        CheckAllSpecs(0)
    End Sub

#End Region

End Class
