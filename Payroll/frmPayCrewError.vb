Public Class frmPayCrewError 
    Private DTPayCrewError As New DataTable
    Dim DSPayCrewError As New DataSet
    'Dim isExpandView As Boolean = True

    Private _isExpandView As Boolean
    Public Property isExpandView() As Boolean
        Get
            Return _isExpandView
        End Get
        Set(ByVal value As Boolean)
            ExpandAllRows(MainView, value)
            _isExpandView = value
        End Set
    End Property

    Public Sub New(PayCrewError As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DTPayCrewError = PayCrewError
        GenerateSubTable()
        isExpandView = False
        bbiExpand.EditValue = isExpandView
    End Sub

    Private Sub GenerateSubTable()
        Dim dT As New DataTable
        dT.Columns.Add("ActID", GetType(String))
        dT.Columns.Add("ErrorMsg", GetType(String))

        For Each dr As DataRow In DTPayCrewError.Rows
            Dim nRowDT As DataRow
            Dim strToolTip() As String = dr("ToolTip").ToString().Split(".")
            For index = 0 To strToolTip.Count - 1
                If Not  String.IsNullOrWhiteSpace(strToolTip(index)) Then
                    nRowDT = dT.NewRow
                    nRowDT("ActID") = dr("ActID")
                    nRowDT("ErrorMsg") = Trim(strToolTip(index).Replace(vbCrLf, String.Empty))
                    dT.Rows.Add(nRowDT)
                End If
            Next
        Next
        With DSPayCrewError
            .Tables.Add(DTPayCrewError)
            .Tables.Add(dT)
            .Tables(0).TableName = "Main"
            .Tables(1).TableName = "Errors"

            'Add Relationship
            If Not .Relations.Contains("Errors") Then
                .Relations.Add("Errors", .Tables(0).Columns("ActID"), .Tables(1).Columns("ActID"))
            End If

        End With

        MainGrid.DataSource = DSPayCrewError.Tables(0)
        MainGrid.LevelTree.Nodes.Add("Errors", ErrorsView)
        'ExpandAllRows(MainView, _isExpandView)

    End Sub

    Public Sub ExpandAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView, value As Boolean)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, value)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RepositoryItemCheckEdit1.EditValueChanging
        isExpandView = e.NewValue
    End Sub

    'Close Button
    Private Sub BarButtonItem1_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub ErrorsView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ErrorsView.RowCellStyle
        If e.Column.FieldName = "ErrorMsg" Then
            e.Appearance.BackColor = System.Drawing.Color.LightPink
        End If
    End Sub
End Class