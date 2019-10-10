Imports System.Drawing

Public Class ReassignCrewNotification

#Region "Declarations"
    Private dtNotification As New DataTable

    Enum NotificationGroupNo
        PendingRequest = 1
        ApprovedOrRejected = 2
    End Enum

    Enum CrewReassignmentStatus
        Pending = 0
        Approved = 1
        Rejected = 2
    End Enum

    'Public GotoHistoryIsClicked As Boolean = False

#End Region

#Region "Initialization"
    Public Overrides Sub Refresh()
        initControls()              'initializes the repository controls
        initNotificationTable()     'Gnitializes the Notification Data Table
        'edited by tony20170608
        'getCrewRequestPending()     'Get the list of Pending Request(s)
        'getCrewRequestApproved()    'Get the list of Approved/Rejected Request(s)

        Dim _userfilterstring As String = GetUserFilterString(, "CrewFKeyAgent", "CrewFKeyPrin", "CrewFKeyFlt")

        dtNotification = New DataTable
        dtNotification = MPSDB.CreateTable("EXEC SP_CrewReassignment_NotificationList  " & USER_ID & ", '" & _userfilterstring.Replace("'", "''") & "'")
        'end tony

        '-- Shows Notification form if there are update status to notify to user
        If dtNotification.Rows.Count > 0 Then
            MainGrid.DataSource = dtNotification

            MainView.Columns("GroupNo").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            MainView.Columns("CrewReassignmentDate").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            MainView.Columns("Crew").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            MainView.Columns("GroupDesc").Group()
            MainView.ExpandAllGroups()

            Me.ShowDialog()
        End If
        '---------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl3.AllowCustomization = False

        '-- CREATE DATA SOURCE OF REPOSITORY ITEM `repVsl`
        repVsl.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmvsl ORDER BY Name")
        '---------------------------------------------------------------------------------------------------------------------------

        '-- CREATE DATA SOURCE OF REPOSITORY ITEM `repAgent`
        repAgent.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmcompany WHERE isManAgent <> 0 ORDER BY Name")
        '---------------------------------------------------------------------------------------------------------------------------

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
        repStatus.DataSource = dt
        '---------------------------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub getCrewRequestPending()
        '## Description: Get the list of Pending Request(s)

        '-- Gets the crew data filterstring
        Dim _userfilterstring As String = GetUserFilterString(, "CrewFKeyAgent", "CrewFKeyPrin", "CrewFKeyFlt")
        '---------------------------------------------------------------------------------------------------------------------------

        '-- Formulate query condition
        Dim cWhere As String = ""
        If _userfilterstring.Length > 0 Then cWhere = _userfilterstring

        cWhere = cWhere & IIf(cWhere.Length > 0, " AND ", "") & "GroupNo = " & NotificationGroupNo.PendingRequest
        cWhere = cWhere & IIf(cWhere.Length > 0, " AND ", "") & "RequestedBy <> " & USER_ID
        cWhere = IIf(cWhere.Length > 0, "WHERE ", "") & cWhere
        '---------------------------------------------------------------------------------------------------------------------------

        '-- Create data table
        Dim cSQL As String = "SELECT * FROM view_ReassignNotification " & _
                             cWhere & _
                             "ORDER BY GroupNo, CrewReassignmentDate desc"

        Dim dtTemp As DataTable = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------

        '-- Adds Pending Request in Notification data table
        For i As Integer = 0 To dtTemp.Rows.Count - 1
            dtNotification.ImportRow(dtTemp.Rows(i))
        Next
        '---------------------------------------------------------------------------------------------------------------------------

    End Sub

    Private Sub getCrewRequestApproved()
        '## Description: Get the list of Approved/Rejected Request(s)

        '-- create data table
        Dim cSQL As String = "SELECT * FROM view_ReassignNotification " & _
                             "WHERE RequestedBy = " & USER_ID & " " & _
                             "AND GroupNo = " & NotificationGroupNo.ApprovedOrRejected & " " & _
                             "ORDER BY GroupNo, CrewReassignmentDate desc"

        Dim dtTemp As DataTable = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------

        '-- Adds Approved/Rejected Request in Notification data table
        For i As Integer = 0 To dtTemp.Rows.Count - 1
            dtNotification.ImportRow(dtTemp.Rows(i))
        Next
        '---------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub initNotificationTable()
        '## Description: Initializes the Notification Data Table
        Dim ccolumn As DataColumn
        '-- Column: GroupNo
        ccolumn = New DataColumn
        ccolumn.ColumnName = "GroupNo"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: GroupDesc
        ccolumn = New DataColumn
        ccolumn.ColumnName = "GroupDesc"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: CrewReassignmentDate
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CrewReassignmentDate"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: NotificationDesc
        ccolumn = New DataColumn
        ccolumn.ColumnName = "NotificationDesc"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: PKey
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: Crew
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Crew"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: ReassignToAgent
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ReassignToAgent"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: ReassignToVsl
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ReassignToVsl"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: ActionCode
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActionCode"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: RequestedConfirmedBy
        ccolumn = New DataColumn
        ccolumn.ColumnName = "RequestedConfirmedBy"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtNotification.Columns.Add(ccolumn)

        '-- Column: Remarks
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Remarks"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtNotification.Columns.Add(ccolumn)
    End Sub
#End Region

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        RunDoNotShowAgain()
        Me.Close()
    End Sub

    Private Sub RunDoNotShowAgain()
        Dim query As New ArrayList, cSQL As String = ""

        If Me.chkDoNotShowAgain.EditValue = True Then

            For i As Integer = 0 To MainView.DataRowCount - 1
                With MainView
                    'cSQL = "UPDATE tblCrewReassignCrews SET IsReadNotification = 1 WHERE PKey = '" & .GetRowCellValue(i, "PKey") & "'"
                    'query.Add(cSQL)
                    query.Add("INSERT INTO dbo.tblCrewReassignNotif(FKeyCrewReassignCrews, UserID, isRead, DateRead) VALUES('" & .GetRowCellValue(i, "PKey") & "', " & USER_ID & ", 1, getdate())")
                End With
            Next

            MPSDB.RunSqls(query)

        End If
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If e.Column.FieldName = "ActionCode" Or e.Column.FieldName = "RequestedConfirmedBy" Then
            Dim nStatus As Integer = CInt(IfNull(View.GetRowCellValue(e.RowHandle, View.Columns("ActionCode")), 0))
            changeCrewReassignmentStatusColor(nStatus, e)
        Else
            changeCrewReassignmentStatusColor(-1, e)
        End If
    End Sub

    Public Sub changeCrewReassignmentStatusColor(nStatus As Integer, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Select Case nStatus
            Case CrewReassignmentStatus.Pending, -1
                e.Appearance.BackColor = Color.White
                e.Appearance.ForeColor = Color.Black
            Case CrewReassignmentStatus.Approved
                e.Appearance.BackColor = Color.Green
                e.Appearance.ForeColor = Color.White
            Case CrewReassignmentStatus.Rejected
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
        End Select
    End Sub

    Private Sub cmdGotoConfirmation_Click(sender As System.Object, e As System.EventArgs) Handles cmdGotoConfirmation.Click
        RunDoNotShowAgain()
        CrewReassignmentOpenConfirmation = True
        Me.Close()
    End Sub
End Class