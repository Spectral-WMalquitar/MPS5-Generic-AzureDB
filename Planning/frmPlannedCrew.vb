Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmPlannedCrew
    Dim plannedcrewDT As New DataTable
    Dim downHitInfo As GridHitInfo
    Dim portDT, rankDT, wscaleDT As DataTable
    Public accepted As Boolean = False

    Public Sub New(ByVal VslCode As String, ByVal Vessel As String, ByVal dtPort As DataTable, ByVal dtRank As DataTable, ByVal dtWScale As DataTable)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = Vessel
        WScaleEdit.DataSource = dtWScale
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleCode"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WageScale"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleRankCode"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("rn"))
        WScaleEdit.DisplayMember = "WageScale"
        WScaleEdit.Columns("WScaleCode").Visible = False
        WScaleEdit.Columns("WScaleRankCode").Visible = False
        WScaleEdit.Columns("rn").Visible = False

        PortEdit.DataSource = dtPort
        RankEdit.DataSource = dtRank

        genericDateEdit.EditMask = "dd-MMM-yyyy"
        genericDateEdit.Mask.UseMaskAsDisplayFormat = True
        MainGrid.DataSource = MPSDB.CreateTable("SELECT * FROM [frmPlannedCrew_Datasource] WHERE FKeyPlannedVsl = '" & VslCode & "'")
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
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

    Public Sub SetFilter(ByVal _criteria As String)
        MainView.ActiveFilterString = _criteria.Replace("(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB') AND ", "")
    End Sub

    Private Sub MainView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseDown
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

    Private Sub MainView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseMove
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

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragDrop
        Try
            Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
            Dim row As DataRow
            If Not xtbl Is Nothing Then
                For Each row In xtbl.Rows
                    Dim xfilter As String = MainView.ActiveFilterString
                    xfilter = xfilter.Replace(xfilter.Substring(xfilter.IndexOf(row("IDNbr"), 0) - 17, 17 + CType(row("IDNbr"), String).Length + 1), "")
                    MainView.ActiveFilterString = xfilter
                    'AcceptDragObject(Name)
                    accepted = True
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MainGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Function GetSelectedRows() As DataTable
        Dim _tbl As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Crew"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CurrActID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActGrpID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "VslName"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "RankName"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "StatName"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FkeyRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedWScaleRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedDateSON"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedPlaceSON"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyPlannedVsl"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedToRelieveID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        For Each xrow In MainView.GetSelectedRows
            _tbl.ImportRow(MainView.GetDataRow(xrow))
        Next

        Return _tbl
    End Function
End Class