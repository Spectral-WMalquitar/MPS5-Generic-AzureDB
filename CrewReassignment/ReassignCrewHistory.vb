Public Class ReassignCrewHistory

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        initControls()              'initializes the repository controls
        LoadSub()
    End Sub

    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl2.AllowCustomization = False
        Me.LayoutControl3.AllowCustomization = False
        SetAddVisibility(Me.Name, BarItemVisibility.Never)
        SetEditVisibility(Me.Name, BarItemVisibility.Never)
        SetSaveVisibility(Me.Name, BarItemVisibility.Never)
        SetDeleteVisibility(Me.Name, BarItemVisibility.Never)
        SetHideCrewReassignmentRequestVisibility(Me.Name, BarItemVisibility.Never)

        SetEditOptionsVisibility(Me.Name, False)
        '-- MAKE VIEWS READ ONLY
        RequestView.OptionsBehavior.ReadOnly = True
        ConfirmView.OptionsBehavior.ReadOnly = True

        ''-- CREATE DATA SOURCE OF REPOSITORY ITEM `repVsl`
        'repVsl.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmvsl ORDER BY Name")
        ''---------------------------------------------------------------------------------------------------------------------------

        ''-- CREATE DATA SOURCE OF REPOSITORY ITEM `repAgent`
        'repAgent.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmcompany WHERE isManAgent <> 0 ORDER BY Name")
        ''---------------------------------------------------------------------------------------------------------------------------

        '-- CREATE DATA SOURCE OF REPOSITORY ITEM `repStatus`
        Dim dt As New DataTable
        Dim ccolumn As DataColumn
        '-- Column: PKey
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dt.Columns.Add(ccolumn)

        '-- Column: Name
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        dt.Rows.Add({0, "Pending"})
        dt.Rows.Add({1, "Approved"})
        dt.Rows.Add({2, "Rejected"})
        rRepAction.DataSource = dt
        cRepAction.DataSource = dt
        '---------------------------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub LoadSub()
        Dim cSQL As String
        Dim dt As DataTable

        cSQL = "SELECT      [GroupNo] " & _
               "            ,[CrewReassignmentDate] " & _
               "            ,[Crew] " & _
               "            ,'' as Rank " & _
               "            ,[ReassignToAgentName] " & _
               "            ,[ReassignToVslName] " & _
               "            ,[Remarks] " & _
               "            ,[ActionCode] " & _
               "            ,[ActionAppliedByName] " & _
               "            ,'' as ActionRemarks " & _
               "            ,[EffectivityDate] " & _
               "FROM        [MPS].[dbo].[view_ReassignReqConfList] " & _
               "WHERE       [RequestedBy] = " & USER_ID & " " & _
               "            AND [GroupNo] = " & ReassignCrewNotification.NotificationGroupNo.PendingRequest

        dt = DB.CreateTable(cSQL)
        RequestGrid.DataSource = dt
        RequestView.Columns("CrewReassignmentDate").SortOrder = ColumnSortOrder.Descending
        RequestView.Columns("Crew").SortOrder = ColumnSortOrder.Ascending

        cSQL = "SELECT      [GroupNo] " & _
               "            ,[Crew] " & _
               "            ,'' as Rank " & _
               "            ,[ReassignToAgentName] " & _
               "            ,[ReassignToVslName] " & _
               "            ,'' as [Remarks] " & _
               "            ,[RequestedByName] " & _
               "            ,[CrewReassignmentDate] " & _
               "            ,[ActionCode] " & _
               "            ,'' as ActionRemarks " & _
               "            ,[EffectivityDate] " & _
               "FROM        [MPS].[dbo].[view_ReassignReqConfList] " & _
               "WHERE       [ActionAppliedBy] = " & USER_ID & " " & _
               "            AND [ActionCode] <> 0 " & _
               "            AND [GroupNo] = " & ReassignCrewNotification.NotificationGroupNo.ApprovedOrRejected

        dt = DB.CreateTable(cSQL)
        ConfirmGrid.DataSource = dt
        ConfirmView.Columns("CrewReassignmentDate").SortOrder = ColumnSortOrder.Descending
        ConfirmView.Columns("Crew").SortOrder = ColumnSortOrder.Ascending
    End Sub

    Private Sub RequestView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles RequestView.RowCellStyle
        'Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        'If e.Column.FieldName = "ActionCode" Then
        '    Dim nStatus As Integer = CInt(IfNull(View.GetRowCellValue(e.RowHandle, View.Columns("ActionCode")), 0))
        '    clsReassignCrew.changeCrewReassignmentStatusColor(nStatus, e)
        'Else
        '    clsReassignCrew.changeCrewReassignmentStatusColor(-1, e)
        'End If

        If e.Column.FieldName = "ActionCode" Or e.Column.FieldName = "ActionAppliedByName" Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Select Case CInt(IfNull(View.GetRowCellValue(e.RowHandle, View.Columns("ActionCode")), 0))
                Case clsReassignCrew.CrewReassignmentStatus.Pending
                    e.Appearance.BackColor = System.Drawing.Color.White
                    e.Appearance.ForeColor = System.Drawing.Color.Black
                Case clsReassignCrew.CrewReassignmentStatus.Approved
                    e.Appearance.BackColor = System.Drawing.Color.Green
                    e.Appearance.ForeColor = System.Drawing.Color.White
                Case clsReassignCrew.CrewReassignmentStatus.Rejected
                    e.Appearance.BackColor = System.Drawing.Color.Red
                    e.Appearance.ForeColor = System.Drawing.Color.White
                Case Else
                    e.Appearance.BackColor = System.Drawing.Color.White
                    e.Appearance.ForeColor = System.Drawing.Color.Black
            End Select
        Else
            e.Appearance.BackColor = System.Drawing.Color.White
            e.Appearance.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Private Sub ConfirmView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ConfirmView.RowCellStyle
        'Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        'If e.Column.FieldName = "ActionCode" Then
        '    Dim nStatus As Integer = CInt(IfNull(View.GetRowCellValue(e.RowHandle, View.Columns("ActionCode")), 0))
        '    clsReassignCrew.changeCrewReassignmentStatusColor(nStatus, e)
        'Else
        '    clsReassignCrew.changeCrewReassignmentStatusColor(-1, e)
        'End If

        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If e.Column.FieldName = "ActionCode" Then
            Select Case CInt(IfNull(View.GetRowCellValue(e.RowHandle, View.Columns("ActionCode")), 0))
                Case clsReassignCrew.CrewReassignmentStatus.Pending
                    e.Appearance.BackColor = System.Drawing.Color.White
                    e.Appearance.ForeColor = System.Drawing.Color.Black
                Case clsReassignCrew.CrewReassignmentStatus.Approved
                    e.Appearance.BackColor = System.Drawing.Color.Green
                    e.Appearance.ForeColor = System.Drawing.Color.White
                Case clsReassignCrew.CrewReassignmentStatus.Rejected
                    e.Appearance.BackColor = System.Drawing.Color.Red
                    e.Appearance.ForeColor = System.Drawing.Color.White
                Case Else
                    e.Appearance.BackColor = System.Drawing.Color.White
                    e.Appearance.ForeColor = System.Drawing.Color.Black

            End Select
        End If

    End Sub
End Class
