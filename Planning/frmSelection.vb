Public Class frmSelection

    Public ApplyFilter As Boolean = False

    Public CurrentMode As String = ""
    Public Enum SelectionMode
        None = 0
        Vessel = 1
        Rank = 2
    End Enum

    Private ListOfSelectionCriteria As New List(Of SelectionCriteria)
    Private oSelectionCriteria As SelectionCriteria

    Private Class SelectionCriteria
        Public Mode As String = ""
        Public FieldNameToCompareWith As String = ""
        Public Condition As String = ""
        Public DataSource As DataTable = Nothing
    End Class

    'Public Class SelectionSourceClass
    '    Public DataSource As DataTable = Nothing
    '    Public ValueMember As String = ""
    '    Public DisplayMember As String = ""
    'End Class

    Private _Selection As SelectionMode
    Public Property Selection As SelectionMode

        Get
            Return _Selection
        End Get
        Set(value As SelectionMode)
            _Selection = value
        End Set
    End Property

    Public Condition As String = ""
    'Public FieldNameToCompareWith As String

    'Private Function GetPredefinedData(SelMode As SelectionMode) As SelectionSourceClass
    '    Dim returnValue As SelectionSourceClass = Nothing

    '    Select Case SelMode
    '        Case SelectionMode.Vessel
    '            returnValue.DataSource = USER_INFO.FilteredVesselActiveOnlyDT
    '            returnValue.DisplayMember = "Name"
    '            returnValue.ValueMember = "PKey"

    '        Case SelectionMode.Rank
    '            returnValue.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmrank ORDER BY Name")
    '            returnValue.DisplayMember = "Name"
    '            returnValue.ValueMember = "PKey"

    '        Case Else
    '            Return Nothing

    '    End Select
    'End Function

    'Public Sub New(SelectionMode As SelectionMode)
    '    InitializeComponent()

    '    Selection = SelectionMode
    'End Sub

    'Public Sub RefreshData()
    '    Dim dt As New DataTable

    '    Select Case Selection
    '        Case SelectionMode.None
    '            dt = Nothing

    '        Case SelectionMode.Vessel
    '            dt = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmvsl ORDER BY Name")

    '        Case SelectionMode.Rank
    '            dt = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmrank ORDER BY Name")

    '    End Select


    '    MainGrid.DataSource = dt

    'End Sub

    Public Sub LoadData(SelectionMode As SelectionMode)
        Dim dt As DataTable

        Try
            Select Case SelectionMode
                Case frmSelection.SelectionMode.Rank
                    oSelectionCriteria = InitSelectionCriteria("RANK")
                    dt = oSelectionCriteria.DataSource
                    colPKey.FieldName = "PKey"
                    colName.FieldName = "Name"

                Case frmSelection.SelectionMode.Vessel
                    oSelectionCriteria = InitSelectionCriteria("VESSEL")
                    dt = oSelectionCriteria.DataSource
                    colPKey.FieldName = "PKey"
                    colName.FieldName = "Name"

                Case Else
                    dt = Nothing
            End Select

            If Not IsNothing(dt) Then
                AddSelectedColumnTodDataSourceObject(dt)

            End If
            MainGrid.DataSource = dt

        Catch ex As Exception
            MainGrid.DataSource = Nothing
        End Try

    End Sub

    Private Function InitSelectionCriteria(cMode As String) As SelectionCriteria
        Dim currSelectionCriteria As SelectionCriteria = Nothing

        Dim cCondition As String = ""

        Try
            cCondition = GetUserSetting("LTP_SEL_" & cMode)
        Catch
            cCondition = ""
        End Try

        'CHECKS IF EXISTS IN FLOATING SOURCE
        currSelectionCriteria = ListOfSelectionCriteria.Find(Function(o As SelectionCriteria) o.Mode = cMode)
        If currSelectionCriteria Is Nothing Then
            currSelectionCriteria = New SelectionCriteria

            With currSelectionCriteria
                .Mode = cMode

                Select Case cMode
                    Case "RANK"
                        .DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmrank ORDER BY Name")
                        .FieldNameToCompareWith = "adm.PKey"

                    Case "VESSEL"
                        .DataSource = USER_INFO.FilteredVesselActiveOnlyDT
                        .FieldNameToCompareWith = "adm.PKey"

                    Case Else
                        .DataSource = Nothing
                End Select

            End With

            ListOfSelectionCriteria.Add(currSelectionCriteria)

        Else
            currSelectionCriteria.Condition = cCondition
        End If


        Return currSelectionCriteria

    End Function

    'Private Module SelectedVesselRankCondition
    '    Public Sub Load(cMode As String)
    '        Dim cCondition As String = GetUserSetting("LTP_SEL_" & cMode)
    '    End Sub

    '    Public Sub Save(cMode As String, cCondition As String)
    '        SaveUserSetting("LTP_SEL_", IfNull(cCondition, ""))
    '    End Sub
    'End Class

    Public Sub LoadData(DataSource As DataTable, DisplayField As String, ValueField As String)

        If Not IsNothing(DataSource) Then AddSelectedColumnTodDataSourceObject(DataSource)
        MainGrid.DataSource = DataSource
        colPKey.FieldName = DisplayField
        colName.FieldName = ValueField

        Try
            MainGrid.DataSource = DataSource
            colPKey.FieldName = DisplayField
            colName.FieldName = ValueField
        Catch ex As Exception
            MainGrid.DataSource = Nothing
        End Try

    End Sub

#Region "Related to Selected Column"
    Private Sub AddSelectedColumnTodDataSourceObject(ByRef DataSourceObject As DataTable)
        If DataSourceObject.Columns("Selected") Is Nothing Then
            Dim col As New DataColumn
            col.ColumnName = "Selected"
            col.DataType = System.Type.GetType("System.Boolean")
            DataSourceObject.Columns.Add(col)

            For i As Integer = 0 To DataSourceObject.Rows.Count - 1
                DataSourceObject.Rows(i).Item("Selected") = False
            Next


        End If
    End Sub

    Private Sub SelectItemsInGridSelectedByUser(oGridView As DevExpress.XtraGrid.Views.Grid.GridView, FieldNameToCompareWith As String, Condition As String)
        If IfNull(Condition, "").Length > 0 Then
            Dim dv As DataView = New DataView(oGridView.DataSource)
            dv.RowFilter = FieldNameToCompareWith & " IN (" & Condition & ")"

            Dim dvToSearchIn As DataView = New DataView(oGridView.DataSource)

            '<!-- commented out by tony20181016 - produces warning: Unused local variable: 'rowindex'.
            'Dim rowindex As Integer
            'end tony-->
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = oGridView.Columns(colPKey.Name)

            'For i As Integer = 0 To dv.Count - 1
            '    rowindex = oGridView.LocateByValue(0, Col, dv(i).Item(colPKey.FieldName))
            '    oGridView.SetRowCellValue(
            'Next

            For i As Integer = 0 To oGridView.RowCount - 1

            Next
        End If
    End Sub

#End Region

    Public Function ConstructCondition(FieldNameToCompareWith As String) As String
        Dim returnvalue As String = ConstructCondition()

        If IfNull(returnvalue, "").Length > 0 Then
            returnvalue = FieldNameToCompareWith & " IN (" & returnvalue & ") AND " & FieldNameToCompareWith & " is not null "
        End If

        Return returnvalue
    End Function


    Public Function ConstructCondition() As String
        Dim returnvalue As String = ""
        '' Create an empty list.
        'Dim Rows As New ArrayList()
        '' Add the selected rows to the list.
        'Dim I As Integer
        'For I = 0 To MainView.SelectedRowsCount() - 1
        '    If (MainView.GetSelectedRows()(I) >= 0) Then
        '        Rows.Add(MainView.GetDataRow(MainView.GetSelectedRows()(I)))
        '    End If
        'Next
        'Try

        '    For I = 0 To Rows.Count - 1
        '        Dim Row As DataRow = CType(Rows(I), DataRow)
        '        ' Change the field value.
        '        returnvalue = returnvalue & IIf(Len(IfNull(returnvalue, "")) > 0, ", ", "") & _
        '                  "'" & Row(colPKey.FieldName) & "'"

        '    Next

        'Finally

        'End Try

        'If IfNull(returnvalue, "").Length > 0 Then
        '    returnvalue = FieldNameToCompareWith & " IN (" & returnvalue & ") "
        'End If
        'Return returnvalue



        'new approach

        If Not IsNothing(MainGrid.DataSource) Then
            Dim dv As DataView = New DataView(MainGrid.DataSource)
            dv.RowFilter = "Selected = true"
            If dv.Count > 0 Then
                For dvctr As Integer = 0 To dv.Count - 1
                    returnvalue = returnvalue & IIf(Len(IfNull(returnvalue, "")) > 0, ", ", "") & _
                          "'" & dv(dvctr).Item(colPKey.FieldName) & "'"
                Next

            End If
        End If

        'If IfNull(returnvalue, "").Length > 0 Then
        '    returnvalue = FieldNameToCompareWith & " IN (" & returnvalue & ") AND " & FieldNameToCompareWith & " is not null "
        'End If
        Return returnvalue
    End Function

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Condition = ConstructCondition(oSelectionCriteria.FieldNameToCompareWith)
        MsgBox(Condition)
        ApplyFilter = True
        'Dim currSelectionCriteria As SelectionCriteria

        'currSelectionCriteria = ListOfSelectionCriteria.Find(Function(o As SelectionCriteria) o.Mode = CurrentMode)
        'If IsNothing(currSelectionCriteria) Then
        '    currSelectionCriteria = New SelectionCriteria
        '    With currSelectionCriteria
        '        .Mode = CurrentMode
        '        .FieldNameToCompareWith = FieldNameToCompareWith
        '        .Condition = Condition
        '    End With

        '    ListOfSelectionCriteria.Add(currSelectionCriteria)

        'Else
        '    currSelectionCriteria.Condition = Condition
        'End If

        Me.Hide()
    End Sub

    Public Function getCondition(cMode As String)
        '<!-- edited by tony20181016 - produces warning: Function 'getCondition' doesn't return a value on all code paths.
        Return ""
        '-->
    End Function

    Private Sub cmdSelectAllShown_Click(sender As System.Object, e As System.EventArgs) Handles cmdSelectAllShown.Click
        MainView.BeginDataUpdate()
        For i As Integer = 0 To Me.MainView.DataRowCount - 1
            MainView.SetRowCellValue(i, "Selected", True)
        Next
        MainView.EndDataUpdate()
    End Sub

    Private Sub cmdDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeselectAll.Click
        Dim dt As DataTable = Nothing

        Try
            dt = TryCast(MainGrid.DataSource, DataTable)
        Catch ex As Exception
            dt = Nothing
        End Try

        If Not dt Is Nothing Then
            MainView.BeginDataUpdate()
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("Selected") = False
            Next
            MainView.EndDataUpdate()
        End If

        MainGrid.DataSource = dt
    End Sub



    Private Sub frmSelection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ApplyFilter = False
        MainView.ApplyFindFilter("")

    End Sub
End Class