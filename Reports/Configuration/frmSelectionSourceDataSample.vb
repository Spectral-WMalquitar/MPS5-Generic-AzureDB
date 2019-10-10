Public Class frmSelectionSourceDataSample

    Public SelectionSource As New SelectionSourceStructure

    Public Structure SelectionSourceStructure
        Public Code As Object
        Public SQLScript As Object
        Public OrderBy As Object
        Public Type As Object
        Public AgentFieldName As Object
        Public PrincipalFieldName As Object
        Public FleetFieldName As Object
        Public VesselFieldName As Object
        Public Description As Object

        Public DisplayValueField As Object
    End Structure

    Public Sub New(oSelectionSource As SelectionSourceStructure)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SelectionSource = oSelectionSource
        SetupDetails()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetupDetails()
    End Sub

    Private Sub SetupDetails()
        Me.txtSelectionSource.Text = SelectionSource.Code

        Dim dtActualDataSource As New DataTable
        Dim cSQL As String = ""
        If SelectionSource.Type = "OBJ" Then
            cSQL = "SELECT * FROM " & SelectionSource.SQLScript
        ElseIf SelectionSource.Type = "SQL" Then
            cSQL = SelectionSource.SQLScript
        End If

        dtActualDataSource = MPSDB.CreateTable(cSQL)

        Dim dtDisplayValueFields As New DataTable
        dtDisplayValueFields.Columns.Clear()
        Dim ccolumn As New DataColumn
        ccolumn.ColumnName = "FieldName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtDisplayValueFields.Columns.Add(ccolumn)

        For Each columns As DataColumn In dtActualDataSource.Columns
            dtDisplayValueFields.Rows.Add(New Object() {columns.ColumnName})
        Next

        PrintSelectionGrid.DataSource = dtActualDataSource
        cboDisplayValueField.Properties.DataSource = dtDisplayValueFields
        cboDisplayValueField.EditValue = SelectionSource.DisplayValueField
        colDisplayField.FieldName = IfNull(cboDisplayValueField.EditValue, "")

        ActualDataSourceGrid.DataSource = dtActualDataSource

    End Sub

    Private Sub cboDisplayValueField_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboDisplayValueField.EditValueChanged
        colDisplayField.FieldName = IfNull(cboDisplayValueField.EditValue, "")
    End Sub
End Class