Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class GoBack
    Friend dtMainview, dtMainviewSub As New DataTable
    Dim _deleteid As String
    Dim clsAudit As New clsAudit 'neil
    Dim strFilter, strStatFilter As String
    Dim downHitInfo As GridHitInfo = Nothing
    Dim ds As New DataSet

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If bLoaded = False Then
            SetSaveCaption(Name, "Go Back")
            blList.Draggable(True)

            'Create columns for Mainview's datatable
            InitData()
            'Create columns for DetailView(Activity List) datatable
            InitSubData()
            'Initiate Relations between Mainview and DetailView
            initRelations()
            'Apply ashore only filter
            InitFilter()

            Maingrid.DataSource = ds.Tables("dtMainview")
            Maingrid.ForceInitialize()
            Mainview.OptionsDetail.AllowExpandEmptyDetails = False

            Dim gView As New DevExpress.XtraGrid.Views.Grid.GridView(Maingrid)
            Maingrid.LevelTree.Nodes.Add("ActivityHistory", gView) 'iakda ang gView bilang isang antas ng MainGrid
            gView.ViewCaption = "Previous Status"
            gView.PopulateColumns(ds.Tables("dtMainviewSub")) 'igaya ang mga haligi ng gView sa dtMainviewSub
            gView.OptionsView.ShowGroupPanel = False
            gView.OptionsCustomization.AllowFilter = False
            gView.OptionsBehavior.Editable = False
            gView.OptionsBehavior.ReadOnly = True
            gView.OptionsMenu.EnableColumnMenu = False
            gView.Columns("ActGrpID").VisibleIndex = -1
            gView.Columns("ActGrpID").OptionsColumn.ShowInCustomizationForm = False

            'Set audittrail's connection string
            clsAudit.propSQLConnStr = DB.GetConnectionString
            BRECORDUPDATEDs = False
            bLoaded = True
        End If
    End Sub

    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim msg As String = ""
        Dim strIDNbr As String = ""
        Dim strUpdatedBy As String = ""

        If checkRequiredFields() = True Then
            'BRECORDUPDATEDs = False
            Exit Sub
        End If

        If MsgBox("Are you sure you want go back to previous activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
            Exit Sub
        End If

        Dim cWhereCond As String = "" 'added by tony20180922 : Log Deletion
        For i As Integer = 0 To Mainview.RowCount - 1
            If DB.DLookUp("PKey", "tblMedHistory", "", "FKeyActivityID = '" & getRowCellValue(i, "CurrActID") & "'") <> "" Then
                If MsgBox(getRowCellValue(i, "Crew") & " has existing Medical History in his current activity." & Environment.NewLine & "Medical history will be deleted. Do want to continue restoring this crew's previous status?" _
                          , MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbYes Then
                    Dim strMedHisDeletedBy As String = strUpdatedBy.Replace("DESC_HERE", "Medical history deleted during Go Back.")
                    clsAudit.saveAuditPreDelDetails("tblMedHistory", getRowCellValue(i, "CurrActID"), strMedHisDeletedBy)
                    sqls.Add("DELETE FROM tblMedHistory WHERE FKeyActivityID = '" & getRowCellValue(i, "CurrActID") & "'")
                    cWhereCond = cWhereCond & IIf(IfNull(cWhereCond, "").Length > 0, ", ", "") & _
                        "'" & getRowCellValue(i, "CurrActID") & "'"
                Else
                    Mainview.SelectRow(i)
                    Continue For
                End If
            End If

            strIDNbr = getRowCellValue(i, "IDNbr").ToString
            strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "INSERT_ACT_HERE", 0, System.Environment.MachineName, "DESC_HERE", "Activity", strIDNbr)

            strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Go Back to Previous Status")
            Dim strDeletedBy As String = strUpdatedBy.Replace("DESC_HERE", "Deleted current activity.")
            clsAudit.saveAuditPreDelDetails("tblActivity", getRowCellValue(i, "CurrActID"), strDeletedBy)

            sqls.Add("EXEC SP_GOBACK @CurrActID = '" & getRowCellValue(i, "CurrActID") & "', " & _
                     "@ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "', " & _
                     "@LastUpdatedBy = '" & strUpdatedBy & "'")

            Mainview.SelectRow(i)
            msg = "Previous activity restored."
        Next

        If sqls.Count > 0 Then
            If MPSDB.RunSqls(sqls, True) = True Then
                '<!--added by tony20180922 : Log Deletion
                If IfNull(cWhereCond, "").Length > 0 Then
                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        "Activity - Go Back To Previous", _
                        "Crewing", _
                        "tblMedHistory", _
                        "PKey IN (" & cWhereCond & ")", _
                        "<< Delete Crew Data - Activity - Go Back To Previous >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Activity - Go Back To Previous>", _
                        GetUserName())
                    oLogDeletion.AddLogEntryToDatabase()
                    '-->
                End If
                MsgBox(msg, MsgBoxStyle.Information, GetAppName() & " - Activity")
                Mainview.DeleteSelectedRows()
                'forceRefresh(True)
                blList.RefreshData()
                BRECORDUPDATEDs = False
                InitFilter()
            End If
        End If
    End Sub

    Private Sub initRelations()
        ds.Tables.Add(dtMainview)
        ds.Tables.Add(dtMainviewsub)

        ds.Tables(0).TableName = "dtMainview"
        ds.Tables(1).TableName = "dtMainviewSub"

        Dim clmUnique As UniqueConstraint = New UniqueConstraint(New DataColumn() {dtMainview.Columns("ActGrpID")}, True)
        Dim clmForeign As ForeignKeyConstraint = New ForeignKeyConstraint(New DataColumn() {dtMainview.Columns("ActGrpID")}, New DataColumn() {dtMainviewsub.Columns("ActGrpID")})

        ds.Tables("dtMainview").Constraints.Add(clmUnique)
        ds.Tables("dtMainviewSub").Constraints.Add(clmForeign)

        ds.Relations.Add("ActivityHistory", ds.Tables("dtMainview").Columns("ActGrpID"), ds.Tables("dtMainviewSub").Columns("ActGrpID"))
    End Sub

    Private Sub InitSubData()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActGrpID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Status"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Rank"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Vessel"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateSign-on"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateSign-off"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActivityStartDate"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActivityEndDate"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)
    End Sub

    Private Sub InitFilter()
        strStatFilter = "(StatCode<>'')"
        If strCrewListFilter <> "" Then
            If strStatFilter <> "" Then
                strFilter = "(" & strStatFilter & " AND " & Replace(strCrewListFilter, "''", "'") & ")"
            Else
                strFilter = "(" & strStatFilter & ")"
            End If
        Else
            strFilter = strStatFilter
        End If
        strBContentFilter = strStatFilter
        blList.SetFilter(strFilter)
    End Sub

    Private Sub InitData()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
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
        ccolumn.ColumnName = "Crew"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Rank"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Status"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Vessel"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActDateStart"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)
    End Sub

    Public Overrides Sub DeleteData()
        Dim i As Integer = 0
        While i < Mainview.RowCount
            If _deleteid.Contains(";" & Mainview.GetRowCellValue(i, "IDNbr") & ";") Then
                Mainview.DeleteRow(i)
                i = -1
            End If
            i += 1
        End While
        _deleteid = ""
        Mainview.RefreshData()
        Mainview.ClearSelection()
        If Mainview.RowCount > 0 Then
            Mainview.FocusedRowHandle = 0
            Mainview.SelectRow(0)
        End If
        If Mainview.RowCount = 0 Then AllowSaving(Name, False)
    End Sub

#Region "Drag N'Drop"

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

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragDrop
        Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
        If Not xtbl Is Nothing Then
            strFilter = strStatFilter
            Try
                For Each nrow In xtbl.Rows
                    If DB.DLookUp("PKey", "tblCASeaman", "", "ActID = '" & nrow("CurrActID") & "'") <> "" Then
                        MsgBox(nrow("Crew") & " cannot go back to previous status, cash advance has been made for this activity.")
                    ElseIf DB.DLookUp("COUNT(PKey) as Nbr", "tblActivityGroup", 0, "FKeyIDNbr = '" & IfNull(nrow("IDNbr"), "") & "'") = 1 Then
                        If DB.DLookUp("COUNT(PKey) as Nbr", "tblActivity", 0, "FKeyActivityGroupID = '" & IfNull(nrow("ActGrpID"), "") & "'") = 1 Then
                            MsgBox(nrow("Crew") & " , has no previous status, it is not possible to go back to a previous status.")
                        End If
                    Else
                        Dim temptbl As New DataTable
                        Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("Crew"), nrow("RankName"), nrow("StatName"), nrow("VslName"), nrow("ActDateStart")}
                        dtMainview.Rows.Add(xrow)

                        temptbl = DB.CreateTable("SELECT FKeyActivityGroupID as ActGrpID, StatName as [Status], RankName as [Rank], VslName as [Vessel], CONVERT(VARCHAR(15),DateSON,106) as [DateSign-on], CONVERT(VARCHAR(15),DateSOFF,106) as [DateSign-off],CONVERT(VARCHAR(15),ActDateStart,106) as ActivityStartDate, CONVERT(VARCHAR(15),ActDateEnd,106) as ActivityEndDate FROM tblActivity WHERE FKeyActivityGroupID = '" & nrow("ActGrpID") & "' ORDER BY ActDateStart DESC")
                        For Each nsub In temptbl.Rows
                            Dim xsub() As Object = {nsub("ActGrpID"), nsub("Status"), nsub("Rank"), nsub("Vessel"), nsub("DateSign-on"), nsub("DateSign-off"), nsub("ActivityStartDate"), nsub("ActivityEndDate")}
                            dtMainviewSub.Rows.Add(xsub)
                        Next
                    End If
                Next
            Catch ex As Exception
                LogErrors(ex.Message)
                'MsgBox(ex.Message)
            End Try

            For Each nrow In dtMainview.Rows
                strFilter = strFilter & " AND IDNbr <> '" & nrow("IDNbr") & "'"
                strBContentFilter = strFilter
            Next

            If strCrewListFilter <> "" Then
                'strFilter = "(" & strFilter & " AND " & strCrewListFilter & ")"
                strFilter = "(" & strFilter & " AND " & Replace(strCrewListFilter, "''", "'") & ")"
            End If

            Mainview.RefreshData()
            If Mainview.RowCount > 0 Then
                Mainview.SelectRow(0)
                BRECORDUPDATEDs = True
                AllowSaving(Name, True)
            Else
                BRECORDUPDATEDs = False
            End If
            blList.SetFilter(strFilter)
        End If
    End Sub

    Private Sub MainGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
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

        For Each xrow In Mainview.GetSelectedRows
            Mainview.GetDataRow(xrow).ClearErrors()
            _deleteid = _deleteid & Mainview.GetRowCellValue(xrow, "IDNbr") & ";"
            ntbl.ImportRow(Mainview.GetDataRow(xrow))
        Next

        If (Mainview.RowCount) - (Mainview.GetSelectedRows.Count) = 0 Then
            BRECORDUPDATEDs = False
        End If

        Return ntbl
    End Function

#End Region

#Region "Validation"
    Private Function checkRequiredFields() As Boolean
        Dim res As Boolean = False
        Return res
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If checkRequiredFields() Or Mainview.HasColumnErrors = True Then
                flag = False
                ALLOWNEXTS = flag
            Else
                flag = True
                ALLOWNEXTS = flag
                SaveData() '
            End If
        ElseIf res = MsgBoxResult.No Then
            BRECORDUPDATEDs = False
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function
#End Region

    Private Sub GoBack_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        strBContentFilter = ""
        _deleteid = Nothing
        clsAudit = Nothing
        strFilter = Nothing
        strStatFilter = Nothing
        downHitInfo = Nothing

        dtMainview.Dispose()
        dtMainviewSub.Dispose()
        ds.Dispose()
    End Sub

    Private Function getRowCellValue(row As Integer, columnName As String)
        Try
            Return IfNull(Mainview.GetRowCellValue(row, columnName), "")
        Catch ex As Exception
            Return ""
        End Try
    End Function

#Region "Save/Load Layout"
    Public Overrides Sub SaveMainContentLayout()
        MyBase.SaveMainContentLayout()
        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
        Mainview.SaveLayoutToXml(strLayoutPath & Me.Name & "_Mainview.xml")
        LayoutControl1.SaveLayoutToXml(strLayoutPath & Me.Name & "_Layout.xml")
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        Try
            MyBase.LoadMainContentLayout()
            Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
            Mainview.RestoreLayoutFromXml(strLayoutPath & Me.Name & "_Mainview.xml")
            LayoutControl1.RestoreLayoutFromXml(strLayoutPath & Me.Name & "_Layout.xml")
        Catch ex As Exception
            'Wala talagang laman to. Para pag wala syang nakita default lang. :D
        End Try
    End Sub
#End Region

End Class
