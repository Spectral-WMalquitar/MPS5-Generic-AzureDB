Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class PlanningList

    Public Shared PKeySelected As Integer
    Public Shared ChangedPkeySelected As Integer

    Public Overrides Sub RefreshData()
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim cFilterString As String = GetUserVslFilterString(, "[Planning_Events].[FKeyVessel]")
        Dim val As Boolean = CBool(GetUserSetting("ShowAllPlannings", "False"))

        If val Then
            sql = "SELECT *, IIF(CrewCnt <> CrewWithAct, 'PLANNED', 'COMPLETED') AS PlanStatus FROM [Planning_Events] WHERE (PlanType <> 'RETURN') AND Remarks NOT IN ('Created in Joining', 'Created on Returning') " & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " ORDER BY PlannedDateSON ASC"
        Else
            sql = "SELECT *, IIF(CrewCnt <> CrewWithAct, 'PLANNED', 'COMPLETED') AS PlanStatus FROM [Planning_Events] WHERE (CrewCnt <> CrewWithAct) AND  (PlanType <> 'RETURN') AND Remarks NOT IN ('Created in Joining', 'Created on Returning') " & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " ORDER BY PlannedDateSON ASC"
        End If

        dt = DB.CreateTable(sql)
        Maingrid.DataSource = dt

        Mainview.BeginSort()
        Try
            Mainview.ClearGrouping()
            Mainview.Columns("PlanStatus").GroupIndex = 0
            Mainview.Columns("PlanStatus").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            Mainview.Columns("PlanStatus").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        Finally
            Mainview.EndSort()
        End Try
        Mainview.ExpandAllGroups()
        MainView_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Public Overrides Function GetID() As String
        If Mainview.RowCount > 0 Then
            Return Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "PKey")
        Else
            Return ""
        End If
    End Function

    Private Sub MainView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles Mainview.BeforeLeaveRow
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not bDraggable Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                If Not bRecordDeleted Then
                    AllowN = bContent.CheckValidateFields()
                    If AllowN Then
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

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, _columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try
    End Function

    Private Sub MainView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mainview.Click
        bAddMode = False
        SelectionChange(Name)
        Mainview.RefreshRow(Mainview.FocusedRowHandle)
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Mainview.FocusedRowChanged
        If Mainview.DataRowCount <> 0 And Mainview.IsGroupRow(Mainview.FocusedRowHandle) Then
            Mainview.ExpandGroupRow(Mainview.FocusedRowHandle)
            'Mainview.MoveNext()
        End If
        If Mainview.FocusedRowHandle >= 0 Then
            SelectionChange(Name)
            'Added WLM
            PKeySelected = Mainview.FocusedRowHandle
        End If
    End Sub

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = Mainview.Columns("PKey")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
            MainView.TopRowIndex = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PlanningList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Mainview.FocusedRowHandle = IIf(ChangedPkeySelected < 0, 0, ChangedPkeySelected)
    End Sub

    Private Sub Mainview_GroupRowExpanded(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles Mainview.GroupRowExpanded
        If Mainview.DataRowCount <> 0 And Mainview.IsGroupRow(Mainview.FocusedRowHandle) Then
            Mainview.MoveNext()
        End If
    End Sub
End Class
