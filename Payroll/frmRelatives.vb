Public Class frmRelatives
    Dim baseRemit As New Remittances
    Public isCopyPressed As Boolean = False

    Public Sub New(ByVal relDT As DataTable, ByVal cityDT As DataTable, ByVal provinceDT As DataTable, ByVal cntryDT As DataTable, ByVal relationDT As DataTable)
        InitializeComponent()
        Maingrid.DataSource = relDT
        cityEdit.DataSource = cityDT
        stateEdit.DataSource = provinceDT
        cntryEdit.DataSource = cntryDT
    End Sub

    Private Sub btnCopy_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCopy.ItemClick
        isCopyPressed = True
        Me.Close()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Hide()
    End Sub
End Class