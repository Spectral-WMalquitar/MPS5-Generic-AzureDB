Public Class frmConflictCrewList
    Dim _CrewList As New DataTable
    Public vcrewname As String = ""
    Public vidnbr As String = ""

    Public Sub New(CrewList As DataTable, Optional exceptCrewKey As String = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        If Not exceptCrewKey Is Nothing Then
            Dim dv = New DataView(CrewList)
            dv.RowFilter = "IDNbr <> '" & exceptCrewKey & "'"
            Me.gridConflictList.DataSource = dv
        Else
            _CrewList = CrewList
            Me.gridConflictList.DataSource = _CrewList
        End If


    End Sub

   
    Private Sub ConflictListView_DoubleClick(sender As Object, e As System.EventArgs) Handles ConflictListView.DoubleClick
        Dim crewfullname As String

        crewfullname = Me.ConflictListView.GetRowCellDisplayText(Me.ConflictListView.FocusedRowHandle, "LName") & " ," & _
                       Me.ConflictListView.GetRowCellDisplayText(Me.ConflictListView.FocusedRowHandle, "FName") & " " & _
                       Me.ConflictListView.GetRowCellDisplayText(Me.ConflictListView.FocusedRowHandle, "MName")

        vidnbr = Me.ConflictListView.GetRowCellDisplayText(Me.ConflictListView.FocusedRowHandle, "IDNbr")
        vcrewname = crewfullname
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        Dim crewfullname As String

        crewfullname = Me.ConflictListView.GetRowCellDisplayText(Me.ConflictListView.FocusedRowHandle, "LName") & " ," & _
                       Me.ConflictListView.GetRowCellDisplayText(Me.ConflictListView.FocusedRowHandle, "FName") & " " & _
                       Me.ConflictListView.GetRowCellDisplayText(Me.ConflictListView.FocusedRowHandle, "MName")

        vidnbr = Me.ConflictListView.GetRowCellDisplayText(Me.ConflictListView.FocusedRowHandle, "IDNbr")
        vcrewname = crewfullname
        Me.Close()
    End Sub
End Class