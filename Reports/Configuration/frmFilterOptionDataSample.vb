Public Class frmFilterOptionDataSample

    Public FilterOptionData As New FilterOptionDataStructure

    Public Structure FilterOptionDataStructure
        Public ObjecID As Object
        Public Description As Object
        Public OptionType As Object
        Public ValueFieldType As Object
        Public ControlType As Object
        Public RowSource As Object
        Public RowSourceType As Object
        Public RowSourceValueField As Object
        Public RowSourceDisplayField As Object
        Public RowSourceSortField As Object

        Public FilterCaption As Object
        'Public DisplayValueField As Object
    End Structure

    Public Sub New(oFilterOptionData As FilterOptionDataStructure)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FilterOptionData = oFilterOptionData
        SetupDetails()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetupDetails()
    End Sub

    Private Sub SetupDetails()
        Me.txtObjectID.Text = FilterOptionData.ObjecID

        Dim dtActualDataSource As New DataTable
        Dim cSQL As String = ""
        Dim ccolumn As New DataColumn
        If FilterOptionData.RowSourceType = "QUERY" Then
            cSQL = "SELECT * FROM " & FilterOptionData.RowSource
            dtActualDataSource = MPSDB.CreateTable(cSQL)
        ElseIf FilterOptionData.RowSourceType = "SQL" Then
            cSQL = FilterOptionData.RowSource
            dtActualDataSource = MPSDB.CreateTable(cSQL)
        ElseIf FilterOptionData.RowSourceType = "ITEMLIST" Then
            Dim arr() As String = FilterOptionData.RowSource.ToString.Split(";")

            ccolumn = New DataColumn
            ccolumn.ColumnName = "PKey"
            ccolumn.DataType = System.Type.GetType("System.String")
            dtActualDataSource.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = "Name"
            ccolumn.DataType = System.Type.GetType("System.String")
            dtActualDataSource.Columns.Add(ccolumn)

            Dim tmpPKey As String = ""
            For i As Integer = 0 To arr.GetUpperBound(0)
                If IfNull(tmpPKey, "").Length > 0 Then
                    dtActualDataSource.Rows.Add(New Object() {tmpPKey, arr(i)})
                    tmpPKey = ""
                Else
                    tmpPKey = arr(i)
                End If
                
            Next
        End If


        Dim dtDisplayValueFields As New DataTable
        dtDisplayValueFields.Columns.Clear()
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FieldName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtDisplayValueFields.Columns.Add(ccolumn)

        For Each columns As DataColumn In dtActualDataSource.Columns
            dtDisplayValueFields.Rows.Add(New Object() {columns.ColumnName})
        Next

        '<!-- Setup Filter Option Grid
        Dim dtFilterOption As New DataTable
        dtFilterOption.Columns.Clear()
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FilterBy"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFilterOption.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FilterValue"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFilterOption.Columns.Add(ccolumn)
        dtFilterOption.Rows.Add(New Object() {FilterOptionData.FilterCaption, DBNull.Value})

        PrintSelectionGrid.DataSource = dtFilterOption
        '-->

        repLookupEdit.DataSource = dtActualDataSource

        repLookupEdit.Columns.Clear()
        Dim col As New DevExpress.XtraEditors.Controls.LookUpColumnInfo
        For Each r As DataColumn In dtActualDataSource.Columns
            col = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
            col.FieldName = r.ColumnName
            col.Visible = (col.FieldName = FilterOptionData.RowSourceDisplayField)
            repLookupEdit.Columns.Add(col)
        Next

        repLookupEdit.DisplayMember = FilterOptionData.RowSourceDisplayField
        repLookupEdit.ValueMember = FilterOptionData.RowSourceValueField

        cboDisplayValueField.Properties.DataSource = dtDisplayValueFields
        cboDisplayValueField.EditValue = FilterOptionData.RowSourceDisplayField
        colFilterValue.FieldName = IfNull(cboDisplayValueField.EditValue, "")

        ActualDataSourceGrid.DataSource = dtActualDataSource

    End Sub

    Private Sub cboDisplayValueField_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboDisplayValueField.EditValueChanged
        repLookupEdit.DisplayMember = IfNull(cboDisplayValueField.EditValue, "")
    End Sub
End Class