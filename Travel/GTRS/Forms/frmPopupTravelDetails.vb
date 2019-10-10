Public Class frmPopupTravelDetails
    Public Sub New(CrewName As String, bdGrid As DevExpress.XtraGrid.GridControl)

        ' This call is required by the designer.
        InitializeComponent()
        PanelControl1.Controls.Add(bdGrid)
        bdGrid.Dock = DockStyle.Fill
        Me.txtCrewName.EditValue = CrewName
        Me.txtCrewName.ReadOnly = True
        '' Add any initialization after the InitializeComponent() call.

        'Dim grid As DevExpress.XtraGrid.GridControl = bdGrid

        'Dim dv As New DataView(TryCast(bdGrid.DataSource, DataTable))
        'If IfNull(PassengerID, "").Length > 0 Then
        '    dv.RowFilter = "PassengerID = '" & PassengerID & "'"
        '    If dv.Count > 0 Then
        '        PanelControl1.Controls.Add(grid)
        '        grid.Dock = DockStyle.Fill
        '        Exit Sub
        '    End If
        'End If

        'If IfNull(FKeyCrew, "").Length > 0 Then
        '    dv.RowFilter = "FKeyCrew = '" & FKeyCrew & "'"
        '    If dv.Count > 0 Then
        '        PanelControl1.Controls.Add(grid)
        '        grid.Dock = DockStyle.Fill
        '        Exit Sub
        '    End If
        'End If

        'Dim dt As DataTable = TryCast(grid.DataSource, DataTable).Clone
        'dt.Rows.Clear()

    End Sub
End Class