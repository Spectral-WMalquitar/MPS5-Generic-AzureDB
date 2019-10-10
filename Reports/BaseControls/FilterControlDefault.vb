Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FilterControlDefault

#Region "Declarations"
    Private FilterFieldsTable As DataTable

    Dim bIsReapplyFilterAfterClearAll As Boolean = True

    Public ReportUserDataFilter As New ReportUserDataFilterClass

    Public Class ReportUserDataFilterClass
        Public Enabled As Boolean = False
        Public AgentFieldName As String = ""
        Public PrinFieldName As String = ""
        Public FleetFieldName As String = ""
        Public VslFieldName As String = ""

        Public Function GetFilterCondition() As String
            Dim ReturnValue As String = ""

            If Enabled Then
                If VslFieldName.Length > 0 Then
                    ReturnValue = GetUserVslFilterString(, VslFieldName)
                Else
                    ReturnValue = GetUserFilterString(, AgentFieldName, PrinFieldName, FleetFieldName)
                End If
            End If

            Return ReturnValue
        End Function

    End Class

    Private Structure ItemListFields
        Const PKey As String = "PKey"
        Const Name As String = "Name"
    End Structure

#Region "Tooltip Variables"
    Dim nFilterTooltipRowHandlePrev As Integer = -1
#End Region

#End Region
    'Dim SavedFilterOptionValues As Object

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()

        If Not bIsLoaded Then
            '####################################################################################################################################################################################################################################
            'SET CONTENT TYPE TO 'GridControl'.
            'THIS IS SET TO 'UserControl' BY DEFAULT
            ContentType = ContentTypeEnum.GridControl

            '####################################################################################################################################################################################################################################
            'LOAD THE GRIDFILTER DATASOURCE
            LoadGridFilterSource()

            bIsLoaded = True
        End If

    End Sub

    Sub LoadGridFilterSource()
        GridFilter.DataSource = Nothing

        '####################################################################################################################################################################################################################################
        'LOADS THE FILTER GRID DATA SOURCE
        Dim cCriteria As String = BuildCriteriaString(ReportGroup, ReportObjectID)

        If cCriteria.Length = 0 Then Exit Sub

        Dim cCriteria2 As String = ""
        If Not AdditionalFilterOptions Is Nothing Then
            cCriteria2 = BuildCriteriaString(AdditionalFilterOptions.Group, AdditionalFilterOptions.ObjectID)
        End If

        Dim cSQL As String = ""
        If cCriteria.Length > 0 Then
            If cCriteria2.Length = 0 Then
                cSQL = AssembleFilterOptionSourceSQL(cCriteria)
            Else
                cSQL = AssembleFilterOptionSourceSQL(cCriteria, cCriteria2)
            End If
            FilterFieldsTable = MPSDB.CreateTable(cSQL)

            LoadFilterOptionDefaultValues()

            GridFilter.DataSource = FilterFieldsTable

        End If
    End Sub

    Private Sub LoadFilterOptionDefaultValues()
        Dim cDisplayValue As String = ""
        Dim cValue As String = ""
        For Each row As DataRow In FilterFieldsTable.Rows

            Try
                If Not IfNull(row("DefaultValue"), "").Equals("") Then

                    cValue = row("DefaultValue")

                    If IfNull(row(FilterOptionFilterFields.ControlType), "") = FilterOptionControlType.ComboBox Then
                        cDisplayValue = getDisplayValueFromRowSource(IfNull(row(FilterOptionFilterFields.RowSource), "").ToString, IfNull(row(FilterOptionFilterFields.RowSourceType), "").ToString, IfNull(row(FilterOptionFilterFields.RowSourceValueField), "").ToString, cValue, IfNull(row(FilterOptionFilterFields.RowSourceDisplayField), "").ToString)

                        If Not IfNull(cDisplayValue, "").Equals("") And Not IfNull(cValue, "").Equals("") Then
                            row(FilterOptionFilterFields.Value) = cValue
                            row(FilterOptionFilterFields.DisplayValue) = cDisplayValue
                        End If

                    Else
                        row(FilterOptionFilterFields.Value) = cValue
                        row(FilterOptionFilterFields.DisplayValue) = cValue
                    End If


                End If
            Catch ex As Exception
                LogErrors(ex.Message)
            End Try
            
        Next
    End Sub

    Function BuildCriteriaString(_ReportGroup As String, _ReportObjectID As String) As String
        Dim ReturnValue As String = ""
        If IfNull(_ReportGroup, "").ToString.Length > 0 Then
            ReturnValue = "ReportGroup = '" & _ReportGroup & "'"

            If IfNull(_ReportObjectID, "").ToString.Length > 0 Then
                ReturnValue = ReturnValue & " AND FKeyReportObjectID = '" & _ReportObjectID & "'"
            End If
        End If

        Return ReturnValue

    End Function

    Function AssembleFilterOptionSourceSQL(cCriteria As String) As String
        Dim ReturnValue As String
        ReturnValue = "SELECT      opt.PKey, " & _
               "            opt.FKeyFilterOption, " & _
               "            opt.ReportKeyFilterField, " & _
               "            admopt.ValueFieldType, " & _
               "            opt.Caption, " & _
               "            opt.SortCode, " & _
               "            admopt.ControlType, " & _
               "            opt.Operator, " & _
               "            admopt.RowSourceType, " & _
               "            CASE WHEN len(isnull(opt.ComboBoxCustomRowSource,'')) > 0 THEN opt.ComboBoxCustomRowSource ELSE admopt.RowSource END as RowSource, " & _
               "            CASE WHEN len(isnull(opt.CustomRowSourceKeyField,'')) > 0 THEN opt.CustomRowSourceKeyField ELSE admopt.RowSourceValueField END as RowSourceValueField, " & _
               "            CASE WHEN len(isnull(opt.CustomRowSourceDisplayField,'')) > 0 THEN opt.CustomRowSourceDisplayField ELSE admopt.RowSourceDisplayField END as RowSourceDisplayField, " & _
               "            admopt.RowSourceSortField, " & _
               "            opt.ApplyToReportSource, " & _
               "            opt.isRowSourceHasUserDataFilter, " & _
               "            admopt.AgentFieldName, " & _
               "            admopt.PrinFieldName, " & _
               "            admopt.FleetFieldName, " & _
               "            admopt.VslFieldName, " & _
               "            '' as DisplayValue, " & _
               "            '' as Value, " & _
               "            opt.DefaultValue " & _
               "FROM        dbo." & tblNameReportsOptions & " opt INNER JOIN " & _
               "            dbo.MSysAdmFilterOption admopt ON opt.FKeyFilterOption = admopt.ObjectID " & _
               "WHERE       admopt.OptionType = 'FILTER' " & _
               "            " & IIf(cCriteria.Length > 0, "AND " & cCriteria & " ", "") & _
               "ORDER BY    opt.sortcode, opt.Caption"

        Return ReturnValue
    End Function

    Function AssembleFilterOptionSourceSQL(cCriteria As String, cCriteria2 As String) As String
        Dim ReturnValue As String
        Dim cSQL1 As String
        Dim cSQL2 As String

        cSQL1 = "SELECT      1 as GroupNo, " & _
               "            opt.PKey, " & _
               "            opt.FKeyFilterOption, " & _
               "            opt.ReportKeyFilterField, " & _
               "            admopt.ValueFieldType, " & _
               "            opt.Caption, " & _
               "            opt.SortCode, " & _
               "            admopt.ControlType, " & _
               "            opt.Operator, " & _
               "            admopt.RowSourceType, " & _
               "            CASE WHEN len(isnull(opt.ComboBoxCustomRowSource,'')) > 0 THEN opt.ComboBoxCustomRowSource ELSE admopt.RowSource END as RowSource, " & _
               "            CASE WHEN len(isnull(opt.CustomRowSourceKeyField,'')) > 0 THEN opt.CustomRowSourceKeyField ELSE admopt.RowSourceValueField END as RowSourceValueField, " & _
               "            CASE WHEN len(isnull(opt.CustomRowSourceDisplayField,'')) > 0 THEN opt.CustomRowSourceDisplayField ELSE admopt.RowSourceDisplayField END as RowSourceDisplayField, " & _
               "            admopt.RowSourceSortField, " & _
               "            opt.ApplyToReportSource, " & _
               "            opt.isRowSourceHasUserDataFilter, " & _
               "            admopt.AgentFieldName, " & _
               "            admopt.PrinFieldName, " & _
               "            admopt.FleetFieldName, " & _
               "            admopt.VslFieldName, " & _
               "            '' as DisplayValue, " & _
               "            '' as Value, " & _
               "            opt.DefaultValue " & _
               "FROM        dbo." & tblNameReportsOptions & " opt INNER JOIN " & _
               "            dbo.MSysAdmFilterOption admopt ON opt.FKeyFilterOption = admopt.ObjectID " & _
               "WHERE       admopt.OptionType = 'FILTER' " & _
               "            " & IIf(cCriteria.Length > 0, "AND " & cCriteria & " ", "")

        cSQL2 = "SELECT      2 as GroupNo, " & _
               "            opt.PKey, " & _
               "            opt.FKeyFilterOption, " & _
               "            opt.ReportKeyFilterField, " & _
               "            admopt.ValueFieldType, " & _
               "            opt.Caption, " & _
               "            opt.SortCode, " & _
               "            admopt.ControlType, " & _
               "            opt.Operator, " & _
               "            admopt.RowSourceType, " & _
               "            CASE WHEN len(isnull(opt.ComboBoxCustomRowSource,'')) > 0 THEN opt.ComboBoxCustomRowSource ELSE admopt.RowSource END as RowSource, " & _
               "            CASE WHEN len(isnull(opt.CustomRowSourceKeyField,'')) > 0 THEN opt.CustomRowSourceKeyField ELSE admopt.RowSourceValueField END as RowSourceValueField, " & _
               "            CASE WHEN len(isnull(opt.CustomRowSourceDisplayField,'')) > 0 THEN opt.CustomRowSourceDisplayField ELSE admopt.RowSourceDisplayField END as RowSourceDisplayField, " & _
               "            admopt.RowSourceSortField, " & _
               "            opt.ApplyToReportSource, " & _
               "            opt.isRowSourceHasUserDataFilter, " & _
               "            admopt.AgentFieldName, " & _
               "            admopt.PrinFieldName, " & _
               "            admopt.FleetFieldName, " & _
               "            admopt.VslFieldName, " & _
               "            '' as DisplayValue, " & _
               "            '' as Value " & _
               "FROM        dbo." & tblNameReportsOptions & " opt INNER JOIN " & _
               "            dbo.MSysAdmFilterOption admopt ON opt.FKeyFilterOption = admopt.ObjectID " & _
               "WHERE       admopt.OptionType = 'FILTER' " & _
               "            " & IIf(cCriteria.Length > 0, "AND " & cCriteria & " ", "")

        ReturnValue = "SELECT * FROM (" & cSQL1 & " UNION " & cSQL2 & ") t ORDER BY GroupNo, opt.sortcode, opt.Caption"
        Return ReturnValue
    End Function

    Private Sub ReloadSavedFilterOptionValues()
        Dim _value As Object
        Dim dt As DataTable = TryCast(GridFilter.DataSource, DataTable)
        Dim _row As DataRow
        Dim rowhandle As Integer

        For i As Integer = 0 To dt.Rows.Count - 1
            _row = dt.Rows(i)
            _value = SavedFilterOptionValues.SavedGridControlValues.GetValue(IfNull(_row(FilterOptionFilterFields.FKeyFilterOption), ""), _
                                                                             IfNull(_row(FilterOptionFilterFields.RowSource), ""), _
                                                                             IfNull(_row(FilterOptionFilterFields.RowSourceValueField), ""), _
                                                                             IfNull(_row(FilterOptionFilterFields.Caption), ""))

            If _value Is Nothing Then GoTo NEXT_ROW
            If IfNull(_value, "").Equals("") Then GoTo NEXT_ROW

            Select Case _row(FilterOptionFilterFields.ControlType)
                Case FilterOptionControlType.ComboBox
                    Dim cRowSource As String = IfNull(_row(FilterOptionFilterFields.RowSource), "")
                    Dim cRowSourceType As String = IfNull(_row(FilterOptionFilterFields.RowSourceType), "")
                    Dim cRowSourceDisplayField As String = IfNull(_row(FilterOptionFilterFields.RowSourceDisplayField), "")
                    Dim cRowSourceValueField As String = IfNull(_row(FilterOptionFilterFields.RowSourceValueField), "")
                    Select Case _row(FilterOptionFilterFields.RowSourceType)
                        Case RowSoureType.SQL, RowSoureType.Query, RowSoureType.PredefinedDataSource
                            If cRowSource.Length > 0 And _
                               cRowSourceDisplayField.Length > 0 And _
                               cRowSourceValueField.Length > 0 Then

                                Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

                                With GridFilterView
                                    rowhandle = .LocateByValue(FilterOptionFilterFields.Caption, _row(FilterOptionFilterFields.Caption))
                                    If rowhandle >= 0 Then
                                        .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, _value)
                                        .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, cDisplayValue)
                                    End If
                                End With

                            Else
                                GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
                                GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
                            End If
                        Case RowSoureType.ItemList
                            If cRowSource.Length > 0 Then

                                cRowSourceValueField = ItemListFields.PKey
                                cRowSourceDisplayField = ItemListFields.Name
                                Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

                                With GridFilterView
                                    rowhandle = .LocateByValue(FilterOptionFilterFields.Caption, _row(FilterOptionFilterFields.Caption))
                                    If rowhandle >= 0 Then
                                        .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, _value)
                                        .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, cDisplayValue)
                                    End If
                                End With

                            Else
                                GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
                                GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
                            End If
                    End Select


                Case FilterOptionControlType.DateEdit
                    If IsDate(_value) Then
                        With GridFilterView
                            rowhandle = .LocateByValue(FilterOptionFilterFields.Caption, _row(FilterOptionFilterFields.Caption))
                            If rowhandle >= 0 Then
                                .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, _value)
                                .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, Format(CDate(_value), REPORT_DATE_FORMAT))
                            End If
                        End With
                    End If
                Case Else
                    With GridFilterView
                        rowhandle = .LocateByValue(FilterOptionFilterFields.Caption, _row(FilterOptionFilterFields.Caption))
                        If rowhandle >= 0 Then
                            .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, _value)
                            .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, _value)
                        End If
                    End With

            End Select
NEXT_ROW:
        Next

        'For i As Integer = 0 To GridFilterView.RowCount - 1
        '    With GridFilterView
        '        _value = SavedFilterOptionValues.SavedGridControlValues.GetValue(.GetRowCellValue(i, "ControlType"), _
        '                                                                         .GetRowCellValue(i, "RowSource"), _
        '                                                                         .GetRowCellValue(i, "RowSourceValueField"), _
        '                                                                         .GetRowCellValue(i, "Caption"))

        '        'Dim cRowSource As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSource), "")
        '        'Dim cRowSourceType As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceType), "")
        '        'Dim cRowSourceDisplayField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceDisplayField), "")
        '        'Dim cRowSourceValueField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceValueField), "")

        '        'If cRowSource.Length > 0 And _
        '        '                           cRowSourceDisplayField.Length > 0 And _
        '        '                           cRowSourceValueField.Length > 0 Then

        '        '    Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

        '        'End If
        '        Select Case .GetRowCellValue(i, FilterOptionFilterFields.ControlType)
        '            Case FilterOptionControlType.ComboBox
        '                Dim cRowSource As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSource), "")
        '                Dim cRowSourceType As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceType), "")
        '                Dim cRowSourceDisplayField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceDisplayField), "")
        '                Dim cRowSourceValueField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceValueField), "")
        '                Select Case .GetRowCellValue(i, FilterOptionFilterFields.RowSourceType)
        '                    Case RowSoureType.SQL, RowSoureType.Query, RowSoureType.PredefinedDataSource
        '                        If cRowSource.Length > 0 And _
        '                           cRowSourceDisplayField.Length > 0 And _
        '                           cRowSourceValueField.Length > 0 Then

        '                            Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

        '                            .SetRowCellValue(i, FilterOptionFilterFields.Value, _value)
        '                            .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, cDisplayValue)
        '                        Else
        '                            GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
        '                            GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
        '                        End If
        '                    Case RowSoureType.ItemList
        '                        If cRowSource.Length > 0 Then

        '                            cRowSourceValueField = ItemListFields.PKey
        '                            cRowSourceDisplayField = ItemListFields.Name
        '                            Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

        '                            .SetRowCellValue(i, FilterOptionFilterFields.Value, _value)
        '                            .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, cDisplayValue)
        '                        Else
        '                            GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
        '                            GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
        '                        End If
        '                End Select


        '            Case FilterOptionControlType.DateEdit
        '                If IsDate(_value) Then
        '                    .SetRowCellValue(i, FilterOptionFilterFields.Value, _value)
        '                    .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, Format(CDate(_value), REPORT_DATE_FORMAT))
        '                End If
        '            Case Else
        '                .SetRowCellValue(i, FilterOptionFilterFields.Value, _value)
        '                .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, _value)

        '        End Select
        '    End With
        'Next
    End Sub

    Private Sub ReloadSavedFilterOptionValues(ByRef dt As DataTable)
        Dim _value As Object
        Dim _row As DataRow

        For i As Integer = 0 To dt.Rows.Count - 1
            _row = dt.Rows(i)
            _value = SavedFilterOptionValues.SavedGridControlValues.GetValue(IfNull(_row("ControlType"), ""), _
                                                                             IfNull(_row("RowSource"), ""), _
                                                                             IfNull(_row("RowSourceValueField"), ""))
            If Not IsDBNull(_value) Then
                Select Case _row(FilterOptionFilterFields.ControlType)
                    Case FilterOptionControlType.ComboBox
                        Dim cRowSource As String = IfNull(_row(FilterOptionFilterFields.RowSource), "")
                        Dim cRowSourceType As String = IfNull(_row(FilterOptionFilterFields.RowSourceType), "")
                        Dim cRowSourceDisplayField As String = IfNull(_row(FilterOptionFilterFields.RowSourceDisplayField), "")
                        Dim cRowSourceValueField As String = IfNull(_row(FilterOptionFilterFields.RowSourceValueField), "")
                        Select Case _row(FilterOptionFilterFields.RowSourceType)
                            Case RowSoureType.SQL, RowSoureType.Query, RowSoureType.PredefinedDataSource
                                If cRowSource.Length > 0 And _
                                   cRowSourceDisplayField.Length > 0 And _
                                   cRowSourceValueField.Length > 0 Then

                                    Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

                                    _row(FilterOptionFilterFields.Value) = _value
                                    _row(FilterOptionFilterFields.DisplayValue) = cDisplayValue
                                Else
                                    GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
                                    GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
                                End If
                            Case RowSoureType.ItemList
                                If cRowSource.Length > 0 Then

                                    cRowSourceValueField = ItemListFields.PKey
                                    cRowSourceDisplayField = ItemListFields.Name
                                    Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

                                    _row(FilterOptionFilterFields.Value) = _value
                                    _row(FilterOptionFilterFields.DisplayValue) = cDisplayValue
                                Else
                                    GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
                                    GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
                                End If
                        End Select


                    Case FilterOptionControlType.DateEdit
                        If IsDate(_value) Then
                            _row(FilterOptionFilterFields.Value) = _value
                            _row(FilterOptionFilterFields.DisplayValue) = Format(CDate(_value), REPORT_DATE_FORMAT)
                        End If
                    Case Else
                        _row(FilterOptionFilterFields.Value) = _value
                        _row(FilterOptionFilterFields.DisplayValue) = _value

                End Select
            End If
        Next

        ApplyFilterToPrintSelection()

        'For i As Integer = 0 To GridFilterView.RowCount - 1
        '    With GridFilterView
        '        _value = SavedFilterOptionValues.SavedGridControlValues.GetValue(.GetRowCellValue(i, "ControlType"), _
        '                                                                         .GetRowCellValue(i, "RowSource"), _
        '                                                                         .GetRowCellValue(i, "RowSourceValueField"))

        '        'Dim cRowSource As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSource), "")
        '        'Dim cRowSourceType As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceType), "")
        '        'Dim cRowSourceDisplayField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceDisplayField), "")
        '        'Dim cRowSourceValueField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceValueField), "")

        '        'If cRowSource.Length > 0 And _
        '        '                           cRowSourceDisplayField.Length > 0 And _
        '        '                           cRowSourceValueField.Length > 0 Then

        '        '    Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

        '        'End If
        '        Select Case .GetRowCellValue(i, FilterOptionFilterFields.ControlType)
        '            Case FilterOptionControlType.ComboBox
        '                Dim cRowSource As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSource), "")
        '                Dim cRowSourceType As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceType), "")
        '                Dim cRowSourceDisplayField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceDisplayField), "")
        '                Dim cRowSourceValueField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceValueField), "")
        '                Select Case .GetRowCellValue(i, FilterOptionFilterFields.RowSourceType)
        '                    Case RowSoureType.SQL, RowSoureType.Query, RowSoureType.PredefinedDataSource
        '                        If cRowSource.Length > 0 And _
        '                           cRowSourceDisplayField.Length > 0 And _
        '                           cRowSourceValueField.Length > 0 Then

        '                            Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

        '                            .SetRowCellValue(i, FilterOptionFilterFields.Value, _value)
        '                            .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, cDisplayValue)
        '                        Else
        '                            GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
        '                            GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
        '                        End If
        '                    Case RowSoureType.ItemList
        '                        If cRowSource.Length > 0 Then

        '                            cRowSourceValueField = ItemListFields.PKey
        '                            cRowSourceDisplayField = ItemListFields.Name
        '                            Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

        '                            .SetRowCellValue(i, FilterOptionFilterFields.Value, _value)
        '                            .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, cDisplayValue)
        '                        Else
        '                            GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
        '                            GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
        '                        End If
        '                End Select


        '            Case FilterOptionControlType.DateEdit
        '                If IsDate(_value) Then
        '                    .SetRowCellValue(i, FilterOptionFilterFields.Value, _value)
        '                    .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, Format(CDate(_value), REPORT_DATE_FORMAT))
        '                End If
        '            Case Else
        '                .SetRowCellValue(i, FilterOptionFilterFields.Value, _value)
        '                .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, _value)

        '        End Select
        '    End With
        'Next
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0)
            Case "COUNTROWS"
                MsgBox(GridFilterView.RowCount)

            Case "LOAD_DEFAULT_VALUES"
                LoadFilterOptionDefaultValues()

        End Select
    End Sub

    Public Overrides Sub ApplyFilterToPrintSelection()
        '### Description: Applies filter to the Print Selection and Selected
        Dim bFlag As Boolean

        For i As Integer = 0 To GridFilterView.RowCount - 1
            Try

                Dim fldName = GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.FieldName)
                isFieldInSelectionGridView(fldName, bFlag)

                If bFlag Then

                    Dim fldValueTmp = GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.Value)
                    Dim fldOperator = GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.Operator)
                    Dim fldType = GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.FieldType)

                    Dim cCondition As String = ArrangeFilterCondition(fldName, fldValueTmp, fldType, fldOperator)

                    If cCondition.ToString.Length > 0 Then ApplyFilterToPrintSelectionByFieldName(fldName, cCondition)

                End If

            Catch
                'do nothing
            End Try

        Next
    End Sub

    Public Sub ApplyFilterByFieldName(ByVal cFieldName As Integer)
        '####################################################################################################################################################################################################################################
        '### Description: Applies filter to the Print Selection and Selected based o a particular entry (by index) from the GridFilter
        For i As Integer = 0 To GridFilterView.RowCount - 1
            If GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.FieldName) = cFieldName Then
                Dim fldValueTmp = GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.Value)
                Dim fldOperator = GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.Operator)
                Dim fldType = GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.FieldType)

                Dim cCondition As String = ArrangeFilterCondition(cFieldName, fldValueTmp, fldType, fldOperator)

                If cCondition.ToString.Length > 0 Then ApplyFilterToPrintSelectionByFieldName(cFieldName, cCondition)
                Exit For
            End If

        Next


    End Sub

    Public Sub ApplyFilterByRowIndex(ByVal nRowIndex As Integer)
        '####################################################################################################################################################################################################################################
        '### Description: Applies filter to the Print Selection and Selected based o a particular entry (by index) from the GridFilter
        Dim fldName = IIf(IsDBNull(GridFilterView.GetRowCellValue(nRowIndex, FilterOptionFilterFields.FieldName)), "", GridFilterView.GetRowCellValue(nRowIndex, FilterOptionFilterFields.FieldName))
        Dim fldValueTmp = GridFilterView.GetRowCellValue(nRowIndex, FilterOptionFilterFields.Value)
        Dim fldOperator = GridFilterView.GetRowCellValue(nRowIndex, FilterOptionFilterFields.Operator)
        Dim fldType = GridFilterView.GetRowCellValue(nRowIndex, FilterOptionFilterFields.FieldType)

        Dim cCondition As String = ArrangeFilterCondition(fldName, fldValueTmp, fldType, fldOperator)

        If cCondition.ToString.Length > 0 Then ApplyFilterToPrintSelectionByFieldName(fldName, cCondition)
    End Sub

    Private Function ArrangeFilterCondition(ByVal cFieldName, ByVal oValue, ByVal cFieldType, ByVal cOperator) As String
        '####################################################################################################################################################################################################################################
        '### Description: Arranges the filter condition into a where clause statement 
        Dim cRetval As String = ""
        Dim oFldValue As New Object
        Try

            If cFieldName.ToString.Length > 0 And Not oValue Is Nothing And cFieldType.ToString.Length > 0 Then
                If cOperator.ToString.Length = 0 Then cOperator = "="
                Select Case cFieldType
                    Case FilterOptionDataType.String
                        If oValue.ToString.Length > 0 Then
                            oFldValue = "'" & IIf(UCase(cOperator) = "LIKE", "%", "") & oValue & IIf(UCase(cOperator) = "LIKE", "%", "") & "'"
                            'Else
                            '    oFldValue = "NULL"
                            '    cOperator = "is"
                        End If
                    Case FilterOptionDataType.Numeric, FilterOptionDataType.Bool
                        If oValue.ToString.Length > 0 Then
                            oFldValue = IfNull(oValue, 0)
                        Else
                            oFldValue = 0
                        End If
                    Case FilterOptionDataType.Date, FilterOptionDataType.DateTime
                        If IsDate(oValue) Then
                            oFldValue = ChangeToSQLDate(oValue)
                        Else
                            oFldValue = "NULL"
                            cOperator = "is"
                        End If
                    Case Else
                        oFldValue = ""
                End Select

                '####################################################################################################################################################################################################################################
                If cFieldName.ToString.Length > 0 And oFldValue.ToString.Length > 0 Then
                    cRetval = cFieldName & " " & IIf(cOperator.ToString.Length > 0, cOperator, " = " & " ") & oFldValue
                End If

            End If

        Catch ex As Exception
            'do nothing
            cRetval = ""
        End Try
        Return cRetval
    End Function

    Public Overrides Function GetFilterValue(ByVal cCaption As String, Optional ByVal ReturnWhat As GetFilterReturnWhat = GetFilterReturnWhat.EditValue, Optional ByVal quoted As Boolean = False) As Object
        '####################################################################################################################################################################################################################################
        '### Description: Gets the filter value from the GridFilter Data Source based on the fieldname parameter
        Dim ReturnValue = ""

        Try
            Dim handle As Integer = GridFilterView.LocateByValue(FilterOptionFilterFields.Caption, cCaption)
            If handle >= 0 Then
                If ReturnWhat = GetFilterReturnWhat.DisplayValue Then
                    If Not IsDBNull(GridFilterView.GetRowCellValue(handle, FilterOptionFilterFields.DisplayValue)) Then ReturnValue = GridFilterView.GetRowCellValue(handle, FilterOptionFilterFields.DisplayValue)
                ElseIf ReturnWhat = GetFilterReturnWhat.EditValue Then
                    If Not IsDBNull(GridFilterView.GetRowCellValue(handle, FilterOptionFilterFields.Value)) Then ReturnValue = GridFilterView.GetRowCellValue(handle, FilterOptionFilterFields.Value)
                End If
            End If
        Catch ex As Exception

        End Try
        If quoted Then
            If Not IsNothing(ReturnValue) Then
                ReturnValue = ReturnValue.Replace(" ", "").Replace(",", "','")
                ReturnValue = IIf(ReturnValue.Length <> 0, "'" & ReturnValue & "'", "")
            End If
        End If
        Return ReturnValue
    End Function

    Public Overrides Function GetFilterValue(ByVal cCaption As String, ByVal cFieldName As String)
        '####################################################################################################################################################################################################################################
        '### Description: Gets the filter value from the GridFilter Data Source based on the fieldname parameter
        Dim ReturnValue = ""
        Dim cRowSource As String
        Dim cRowSourceType As String
        Dim cRowSourceDisplayField As String, cRowSourceValueField As String


        Try
            If cFieldName.Length = 0 Then GoTo RETURN_AND_EXIT

            Dim RowHandle As Integer = -1
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridFilterView.Columns("Caption")
            RowHandle = GridFilterView.LocateByValue(0, Col, cCaption)

            If RowHandle >= 0 Then

                With GridFilterView
                    If Not .GetRowCellValue(RowHandle, FilterOptionFilterFields.Caption) Is DBNull.Value And _
                           .GetRowCellValue(RowHandle, FilterOptionFilterFields.Caption) = cCaption Then

                        cRowSource = .GetRowCellValue(RowHandle, FilterOptionFilterFields.RowSource)
                        cRowSourceType = .GetRowCellValue(RowHandle, FilterOptionFilterFields.RowSourceType)

                        Dim dt As DataTable = CreateFilterLookUpEditRepositoryDataTable(cRowSourceType, cRowSource)

                        If dt Is Nothing Then GoTo RETURN_AND_EXIT
                        If dt.Rows.Count = 0 Then GoTo RETURN_AND_EXIT

                        Dim cKeyFilter As String = ""
                        If .GetRowCellValue(RowHandle, FilterOptionFilterFields.RowSourceType) = RowSoureType.ItemList Then
                            cRowSourceDisplayField = ItemListFields.Name
                            cRowSourceValueField = ItemListFields.PKey

                            Dim cValueFieldType As String = IfNull(.GetRowCellValue(RowHandle, FilterOptionFilterFields.RowSourceType), "")
                            cKeyFilter = cRowSourceValueField & " = " & _
                                         IIf(cValueFieldType = "STRING", "'", "") & _
                                         .GetRowCellValue(RowHandle, FilterOptionFilterFields.Value) & _
                                         IIf(cValueFieldType = "STRING", "'", "")
                        Else
                            cRowSourceDisplayField = .GetRowCellValue(RowHandle, FilterOptionFilterFields.RowSourceDisplayField)
                            cRowSourceValueField = .GetRowCellValue(RowHandle, FilterOptionFilterFields.RowSourceValueField)

                            If cRowSourceDisplayField.Length > 0 And cRowSourceValueField.Length > 0 Then
                                cKeyFilter = cRowSourceValueField & " = '" & .GetRowCellValue(RowHandle, FilterOptionFilterFields.Value) & "'"
                            End If
                        End If

                        If cKeyFilter.Length > 0 Then
                            Dim dr() As DataRow = Nothing
                            dr = dt.Select(cKeyFilter)

                            If dr.Length > 0 Then ReturnValue = dr(0)(cFieldName)

                        End If

                    End If
                End With
            End If
        Catch ex As Exception

        End Try

RETURN_AND_EXIT:
        Return ReturnValue
    End Function

    Public Overrides Sub SetFilterValue(ByVal cControlName As String, ByVal value As Object)
        Try
            Dim rowHandle As Integer = GridFilterView.LocateByValue("TableFieldName", cControlName)
            If rowHandle <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                GridFilterView.SetRowCellValue(rowHandle, "Value", value)
            End If
        Catch
            'do nothing
        End Try
    End Sub

    Public Overrides Function GetWhereString(Optional param() As Object = Nothing, Optional ListOfExcemptedFilterOptionsByCaption As List(Of String) = Nothing) As String
        '####################################################################################################################################################################################################################################
        '### Description: Gets the complete where clause string based on the values selected from the GridFilter
        Dim cRetval As String = ""
        Dim tmpVal As String = ""

        Try
            With GridFilterView
                For i As Integer = 0 To .RowCount - 1

                    If Not IsNothing(ListOfExcemptedFilterOptionsByCaption) Then
                        If ListOfExcemptedFilterOptionsByCaption.Count > 0 Then
                            If ListOfExcemptedFilterOptionsByCaption.Contains(.GetRowCellValue(i, FilterOptionFilterFields.Caption).ToString()) Then GoTo NEXT_FILTER_OPTION_ROW
                        End If
                    End If

                    '####################################################################################################################################################################################################################################
                    'CHECKS IF FILTER OPTION ROW IS APPLICABLE TO THE REPORT DATA SOURCE, GOES TO THE NEXT ROW IF NOT
                    If .GetRowCellValue(i, FilterOptionFilterFields.ApplyToReportSource) = 0 Then GoTo NEXT_FILTER_OPTION_ROW

                    '####################################################################################################################################################################################################################################
                    tmpVal = ""

                    If Len(.GetRowCellValue(i, FilterOptionFilterFields.Value).ToString()) > 0 And _
                       Len(.GetRowCellValue(i, FilterOptionFilterFields.Operator).ToString()) > 0 And _
                       Len(.GetRowCellValue(i, FilterOptionFilterFields.FieldName).ToString()) > 0 Then

                        '####################################################################################################################################################################################################################################
                        'GETS THE VALUE
                        Select Case UCase(.GetRowCellValue(i, FilterOptionFilterFields.FieldType))
                            Case FilterOptionDataType.String
                                tmpVal = "'" & _
                                         IIf(UCase(.GetRowCellValue(i, FilterOptionFilterFields.Operator).ToString()) = "LIKE", "%", "") & _
                                         .GetRowCellValue(i, FilterOptionFilterFields.Value).ToString() & _
                                         IIf(UCase(.GetRowCellValue(i, FilterOptionFilterFields.Operator).ToString()) = "LIKE", "%", "") & _
                                         "'"
                            Case FilterOptionDataType.Numeric, FilterOptionDataType.Bool, "INTEGER"
                                tmpVal = .GetRowCellValue(i, FilterOptionFilterFields.Value).ToString()
                            Case FilterOptionDataType.Date, FilterOptionDataType.DateTime
                                If IsDate(.GetRowCellValue(i, FilterOptionFilterFields.Value)) Then
                                    tmpVal = ChangeToSQLDate(.GetRowCellValue(i, FilterOptionFilterFields.Value))
                                End If
                        End Select

                        '####################################################################################################################################################################################################################################
                        'ARRANGES THE VALUE INTO WHERE CLAUSE
                        cRetval = cRetval & _
                                  IIf(cRetval.Length > 0, " AND ", "") & _
                                  .GetRowCellValue(i, FilterOptionFilterFields.FieldName).ToString() & " " & _
                                  .GetRowCellValue(i, FilterOptionFilterFields.Operator).ToString() & " " & _
                                  tmpVal
                    End If

NEXT_FILTER_OPTION_ROW:
                Next

            End With
        Catch ex As Exception

        End Try

        Return cRetval

    End Function

#Region "Apply/Clear Filter Procedures"
    Public Overrides Sub ClearFilterValue(cFieldName As String)
        '####################################################################################################################################################################################################################################
        '### Description: Clears the Filter Option Value (Row Value)
        Dim rowhandle As Integer

        With GridFilterView
            '####################################################################################################################################################################################################################################
            'Tries to locate row from field name column based on fieldname parameter
            Try
                rowhandle = .LocateByValue(FilterOptionFilterFields.FieldName, cFieldName)
                If rowhandle > 0 Then
                    .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, Nothing)
                    .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, Nothing)
                End If

            Catch ex As Exception

            End Try

            '####################################################################################################################################################################################################################################
            'Tries to locate row from caption column based on fieldname parameter, just to be sure
            Try
                rowhandle = .LocateByValue(FilterOptionFilterFields.Caption, cFieldName)
                If rowhandle > 0 Then
                    .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, Nothing)
                    .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, Nothing)
                End If

            Catch ex As Exception

            End Try

        End With
    End Sub

    Public Overrides Sub ClearFilterValueAll(Optional isReapplyFilter As Boolean = True)
        '####################################################################################################################################################################################################################################
        '### Description: Clears the value of all rows/filter options

        bIsReapplyFilterAfterClearAll = isReapplyFilter
        With GridFilterView
            For i As Integer = 0 To .RowCount - 1
                Try
                    .SetRowCellValue(i, FilterOptionFilterFields.Value, Nothing)
                    .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, Nothing)
                Catch ex As Exception

                End Try
            Next
        End With

        bIsReapplyFilterAfterClearAll = True
    End Sub

    Public Sub ClearSelectedFilter()
        OpenReportWaitForm()
        Try
            GridFilterView.SetFocusedRowCellValue(FilterOptionFilterFields.DisplayValue, Nothing)
            GridFilterView.SetFocusedRowCellValue(FilterOptionFilterFields.Value, Nothing)
            CallClearSelectionListFilter()
            ApplyFilterToPrintSelection()
        Catch ex As Exception
            LogErrors("Failed to clear selected filter. Error: " & ex.Message)
        End Try
        CloseReportWaitForm()
    End Sub
#End Region

#Region "GridFilter Events"
    Private Sub GridFilterView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridFilterView.CellValueChanged
        '####################################################################################################################################################################################################################################
        '### Description: Applies filter to the Print Selection once a filter is selected
        Dim bApplyFilter As Boolean = False

        If Not bIsReapplyFilterAfterClearAll Then Exit Sub

        If UsedBy = ReportFilterOptionUser.Report Then
            bApplyFilter = (e.RowHandle >= 0 And Not ReportSelection.bClearFilterButtonIsClicked)

        ElseIf UsedBy = ReportFilterOptionUser.KPI Then
            bApplyFilter = (e.RowHandle >= 0)
        End If

        If bApplyFilter Then ApplyFilterByRowIndex(e.RowHandle)

    End Sub

    Private Sub GridFilterView_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridFilterView.CustomRowCellEditForEditing
        '####################################################################################################################################################################################################################################
        '### Description: This changes the reposiotry of the value column to the type of repository a filter option is defined
        Dim Gv As GridView = sender
        Dim cControlType As String = IfNull(Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.ControlType)), "").ToString()
        Dim cRowSource As String = IfNull(Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.RowSource)), "").ToString()
        Dim cRowSourceType As String = IfNull(Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.RowSourceType)), "").ToString()
        Dim cDisplayField As String = IfNull(Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.RowSourceDisplayField)), "").ToString()
        Dim cValueField As String = IfNull(Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.RowSourceValueField)), "").ToString()
        Dim cSortField As String = IfNull(Gv.GetRowCellValue(e.RowHandle, FilterOptionFilterFields.RowSourceSortField), "").ToString()

        '####################################################################################################################################################################################################################################
        If e.Column.FieldName <> FilterOptionFilterFields.DisplayValue Then Return


        '####################################################################################################################################################################################################################################
        Select Case cControlType
            Case FilterOptionControlType.ComboBox
                '####################################################################################################################################################################################################################################
                'SETS UP THE USER DATA FILTER IF APPLIES
                ReportUserDataFilter = New ReportUserDataFilterClass
                ReportUserDataFilter.Enabled = Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.isRowSourceHasUserDataFilter))

                If ReportUserDataFilter.Enabled Then
                    With ReportUserDataFilter
                        If IfNull(Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.AgentFieldName)), "").ToString.Length > 0 Then .AgentFieldName = Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.AgentFieldName))
                        If IfNull(Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.PrinFieldName)), "").ToString.Length > 0 Then .PrinFieldName = Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.PrinFieldName))
                        If IfNull(Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.FleetFieldName)), "").ToString.Length > 0 Then .FleetFieldName = Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.FleetFieldName))
                        If IfNull(Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.VslFieldName)), "").ToString.Length > 0 Then .VslFieldName = Gv.GetFocusedRowCellValue(Gv.Columns(FilterOptionFilterFields.VslFieldName))
                    End With
                End If

                e.RepositoryItem = CreateFilterLookUpEditRepository(cControlType, cRowSource, cRowSourceType, cDisplayField, cValueField, cSortField)


            Case FilterOptionControlType.DateEdit
                Dim rep As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
                rep.EditFormat.FormatString = REPORT_DATE_FORMAT
                rep.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
                rep.Mask.EditMask = REPORT_DATE_FORMAT   'System.Globalization.DateTimeFormat5Info.CurrentInfo.ShortDatePattern()
                rep.Mask.UseMaskAsDisplayFormat = True

                e.RepositoryItem = rep

                'Add Clear Button
                Dim editorButton As New DevExpress.XtraEditors.Controls.EditorButton
                editorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear
                editorButton.Caption = "CLEAR"
                rep.Buttons.Add(editorButton)

                AddHandler rep.ButtonClick, AddressOf repLookupEdit_ButtonClick

                AddHandler rep.EditValueChanged, AddressOf CustomDateEdit_EditValueChanged

            Case FilterOptionControlType.CheckBox
                Dim rep As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
                e.RepositoryItem = rep
                AddHandler rep.EditValueChanged, AddressOf CustomRepositoryItem_EditValueChanged

            Case Else 'FilterOptionControlType.TextBox
                Dim rep As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
                e.RepositoryItem = rep
                AddHandler rep.EditValueChanged, AddressOf CustomRepositoryItem_EditValueChanged


        End Select
    End Sub

#Region "Filter Option - LookupEdit Repository"
    Function CreateFilterLookUpEditRepository(ByVal cControlType As String, ByVal cRowSource As String, ByVal cRowSourceType As String, ByVal cDisplayField As String, ByVal cValueField As String, Optional cSortField As String = "") As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim ReturnValue As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        ReturnValue.NullText = ""

        Select Case cRowSourceType
            Case RowSoureType.Query, RowSoureType.SQL
                'IF COMBOBOX FILTEROPTION SOURCE IS UNFILTERED/NOT FROM STORED PROCEDURE

                If cRowSource.ToString.Length = 0 Or cDisplayField.ToString.Length = 0 Or cValueField.ToString.Length = 0 Then GoTo EXIT_AND_RETURN
                Dim dt As DataTable = CreateFilterLookUpEditRepositoryDataTable(cRowSourceType, cRowSource, , cSortField)

                ReturnValue.DataSource = dt
                ReturnValue.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cValueField, "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cDisplayField, "Name")})
                ReturnValue.DisplayMember = cDisplayField
                ReturnValue.ValueMember = cDisplayField
                ReturnValue.NullText = ""

            Case RowSoureType.PredefinedDataSource
                'IF COMBOBOX FILTEROPTION SOURCE IS FILTERED/FROM STORED PROCEDURE

                If cRowSource.ToString.Length = 0 Or cDisplayField.ToString.Length = 0 Or cValueField.ToString.Length = 0 Then GoTo EXIT_AND_RETURN

                Dim dt As DataTable = CreateFilterLookUpEditRepositoryDataTable(cRowSourceType, cRowSource)

                ReturnValue.DataSource = dt
                ReturnValue.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cValueField, "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cDisplayField, "Name")})
                ReturnValue.DisplayMember = cDisplayField
                ReturnValue.ValueMember = cDisplayField
                ReturnValue.NullText = ""


            Case RowSoureType.ItemList
                Dim dt As DataTable = changeItemListToDT(cRowSource)

                If dt Is Nothing Then Exit Select
                If dt.Rows.Count = 0 Then Exit Select

                cDisplayField = ItemListFields.Name
                cValueField = ItemListFields.PKey

                ReturnValue.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cValueField, "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cDisplayField, "Name")})

                ReturnValue.DataSource = dt
                ReturnValue.DisplayMember = cDisplayField
                ReturnValue.ValueMember = cDisplayField
                ReturnValue.NullText = ""


            Case Else

        End Select

EXIT_AND_RETURN:

        If Not ReturnValue Is Nothing Then
            ReturnValue.ShowFooter = True
            ReturnValue.ShowHeader = False

            'Add Clear Button
            Dim editorButton As New DevExpress.XtraEditors.Controls.EditorButton
            editorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear
            editorButton.Caption = "CLEAR"
            ReturnValue.Buttons.Add(editorButton)

            AddHandler ReturnValue.ButtonClick, AddressOf repLookupEdit_ButtonClick

            'Add EditValueChanged Event
            AddHandler ReturnValue.EditValueChanged, AddressOf CustomLookUpEdit_EditValueChanged
        End If
        Return ReturnValue
    End Function

    Function CreateFilterLookUpEditRepositoryDataTable(ByVal cRowSourceType As String, ByVal cRowSource As String, Optional bApplyUserDataFilter As Boolean = True, Optional cSortByFieldName As String = "") As DataTable
        Dim ReturnValue As DataTable = Nothing
        Dim cCondition As String = ""

        Select Case cRowSourceType
            Case RowSoureType.SQL, RowSoureType.Query
                If cRowSource.ToString.Length = 0 Then GoTo RETURN_AND_EXIT

                Dim dt As DataTable = Nothing
                If cRowSourceType = RowSoureType.SQL Then
                    dt = MPSDB.CreateTable(cRowSource)
                ElseIf cRowSourceType = RowSoureType.Query Then
                    dt = MPSDB.CreateTable("SELECT * FROM [" & cRowSource & "]")
                End If

                If IsNothing(dt) Then Exit Select

                If bApplyUserDataFilter Then
                    cCondition = ReportUserDataFilter.GetFilterCondition()
                    If cCondition.Length > 0 Then
                        Dim dv As DataView = New DataView(dt)
                        dv.RowFilter = cCondition
                        ReturnValue = dv.ToTable
                    Else
                        ReturnValue = dt
                    End If
                Else
                    ReturnValue = dt
                End If

                If Not IfNull(cSortByFieldName, "").Equals("") Then
                    Dim dv As DataView = New DataView(ReturnValue)
                    Try
                        dv.Sort = cSortByFieldName
                        ReturnValue = dv.ToTable
                    Catch
                    End Try
                End If

            Case RowSoureType.PredefinedDataSource
                If cRowSource.ToString.Length = 0 Then GoTo RETURN_AND_EXIT
                ReturnValue = getPredefDataSource(cRowSource)

            Case RowSoureType.ItemList
                ReturnValue = changeItemListToDT(cRowSource)

        End Select

RETURN_AND_EXIT:
        Return ReturnValue
    End Function
#End Region

    Private Sub GridFilterView_DataSourceChanged(sender As Object, e As System.EventArgs) Handles GridFilterView.DataSourceChanged
        If GridFilterView.RowCount > 0 Then
            ReloadSavedFilterOptionValues()
        End If
    End Sub

    Private Sub GridFilterView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles GridFilterView.KeyDown
        If e.KeyCode = Keys.Escape Then
            '####################################################################################################################################################################################################################################
            'Clears the filter if Escape button is pressed
            ClearSelectedFilter()
        End If
    End Sub

    Private Function changeItemListToDT(cItemList As String) As DataTable
        Dim itemList As String = cItemList
        Dim arrItemList As String()
        arrItemList = itemList.Split(";")

        If (arrItemList.GetUpperBound(0) + 1) Mod 2 <> 0 Then GoTo RETURN_NOTHING
        Dim dt As New DataTable

        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = ItemListFields.PKey
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = ItemListFields.Name
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        For j As Integer = 0 To arrItemList.GetUpperBound(0) Step 2
            dt.Rows.Add(New Object() {arrItemList(j), arrItemList(j + 1)})

        Next

        Return dt

        Exit Function
RETURN_NOTHING:
        Return Nothing
    End Function

#Region "Custom Repository Events"
    Private Sub CustomLookUpEdit_EditValueChanged(sender As Object, e As System.EventArgs)
        Dim rep As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        rep = TryCast(sender, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)

        Try

            If row Is Nothing Then
                GridFilterView.SetRowCellValue(GridFilterView.FocusedRowHandle, FilterOptionFilterFields.Value, Nothing)
            Else
                If GridFilterView.GetRowCellValue(GridFilterView.FocusedRowHandle, FilterOptionFilterFields.ControlType) = FilterOptionControlType.ComboBox And GridFilterView.GetRowCellValue(GridFilterView.FocusedRowHandle, FilterOptionFilterFields.RowSourceType) = RowSoureType.ItemList Then
                    'if combobox and uses itemlist, set value to value index
                    GridFilterView.SetRowCellValue(GridFilterView.FocusedRowHandle, FilterOptionFilterFields.Value, row.Item(0))
                    SaveInSavedFilterOptionValues(GridFilterView.FocusedRowHandle, row.Item(0))

                Else
                    GridFilterView.SetFocusedRowCellValue(FilterOptionFilterFields.Value, row.Item(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.RowSourceValueField)).ToString)
                    SaveInSavedFilterOptionValues(GridFilterView.FocusedRowHandle, row.Item(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.RowSourceValueField)).ToString)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CustomRepositoryItem_EditValueChanged(sender As Object, e As System.EventArgs)
        GridFilterView.SetRowCellValue(GridFilterView.FocusedRowHandle, FilterOptionFilterFields.Value, sender.EditValue)
        SaveInSavedFilterOptionValues(GridFilterView.FocusedRowHandle, sender.EditValue)
    End Sub

    Private Sub CustomDateEdit_EditValueChanged(sender As Object, e As System.EventArgs)
        GridFilterView.SetRowCellValue(GridFilterView.FocusedRowHandle, FilterOptionFilterFields.Value, sender.editvalue)
        GridFilterView.SetRowCellValue(GridFilterView.FocusedRowHandle, FilterOptionFilterFields.DisplayValue, Format(sender.editvalue, REPORT_DATE_FORMAT))
        SaveInSavedFilterOptionValues(GridFilterView.FocusedRowHandle, sender.EditValue)
    End Sub

    Private Sub repLookupEdit_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear And e.Button.Caption = "CLEAR" And GridFilterView.GetFocusedRowCellValue("Value").ToString.Length > 0 Then
            ClearLookUpEdit(sender, e)
            ClearSelectedFilter()
            SavedFilterOptionValues.SavedGridControlValues.Remove(IfNull(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.FKeyFilterOption), ""), _
                                                                  IfNull(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.RowSource), ""), _
                                                                  IfNull(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.RowSourceValueField), ""), _
                                                                  IfNull(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.Caption), ""))
        End If
    End Sub

    Private Sub SaveInSavedFilterOptionValues(cFKeyFilterOption As Object, cRowSource As Object, cRowSourceValueField As Object, cCaption As Object, _value As Object)
        SavedFilterOptionValues.SavedGridControlValues.Save(IfNull(cFKeyFilterOption, ""), _
                                                            IfNull(cRowSource, ""), _
                                                            IfNull(cRowSourceValueField, ""), _
                                                            IfNull(cCaption, ""), _
                                                            _value)
    End Sub

    Private Sub SaveInSavedFilterOptionValues(rowhandle As Integer, _value As Object)
        SavedFilterOptionValues.SavedGridControlValues.Save(IfNull(GridFilterView.GetRowCellValue(rowhandle, FilterOptionFilterFields.FKeyFilterOption), ""), _
                                                            IfNull(GridFilterView.GetRowCellValue(rowhandle, FilterOptionFilterFields.RowSource), ""), _
                                                            IfNull(GridFilterView.GetRowCellValue(rowhandle, FilterOptionFilterFields.RowSourceValueField), ""), _
                                                            IfNull(GridFilterView.GetRowCellValue(rowhandle, FilterOptionFilterFields.Caption), ""), _
                                                            _value)
    End Sub

#End Region


#End Region

#Region "KPI-Related"
    Public Overrides Function GetConditionDescForKPI() As String
        Dim ReturnValue As String = ""
        GridFilterView.FocusedRowHandle = -1
        With GridFilterView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, FilterOptionFilterFields.Value).ToString.Length > 0 Then
                    ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, "; ", "") & _
                                  .GetRowCellValue(i, FilterOptionFilterFields.Caption) & ": " & .GetRowCellValue(i, FilterOptionFilterFields.DisplayValue)
                End If
            Next
        End With

        Return ReturnValue
    End Function
#End Region

#Region "Template-related"
    Public Overrides Function SaveFilterOptionValuesToTemplate(ByVal cTemplatePKey As String) As Boolean
        '####################################################################################################################################################################################################################################
        'Description: Saves the Filter values to the templates

        Dim bSuccess As Boolean = False
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A TEMPLATE PKEY PARAMETER PASSED
            If cTemplatePKey.Length > 0 Then
                With GridFilterView
                    For i As Integer = 0 To .DataRowCount - 1
                        If .GetRowCellValue(i, "Value").ToString.Length > 0 Then
                            bSuccess = MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                      "VALUES ('" & cTemplatePKey & "', '" & .GetRowCellValue(i, FilterOptionFilterFields.OptionsObjectID) & "', 'FILTER', '" & .GetRowCellValue(i, FilterOptionFilterFields.Value) & "',0)")

                            If Not bSuccess Then
                                MsgBox("There is an error when saving the template. Please see error log or contact your system administrator for assistance.", vbInformation)
                                GoTo RETURN_AND_EXIT
                            End If
                        End If
                    Next
                End With
            Else
                '####################################################################################################################################################################################################################################
                'IF THERE IS NO TEMPLATE PKEY PARAMETER PASSED
                bSuccess = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess

    End Function

    Public Overrides Sub LoadFilterOptionTemplateValues(TemplateKey As String)
        '####################################################################################################################################################################################################################################
        'Description: Loads the Filter values from the selected template
        Dim templateItems As New DataTable
        templateItems = MPSDB.CreateTable("SELECT * FROM dbo.MSystblRepOptTemplateValues WHERE FKeyTemplate = '" & TemplateKey & "'")
        If templateItems.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To GridFilterView.DataRowCount - 1
            Dim row As DataRow = templateItems.Select("OptionsObjectID = '" & GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.OptionsObjectID) & "' AND OptionsType = 'FILTER'").FirstOrDefault()
            Try

                If Not row Is Nothing Then
                    Dim cValueFromTemplate = row(FilterOptionFilterFields.Value)
                    SetFilterOptionValueColumnManual(i, cValueFromTemplate)
                    'With GridFilterView

                    '    Select Case .GetRowCellValue(i, FilterOptionFilterFields.ControlType)
                    '        Case FilterOptionControlType.ComboBox
                    '            Dim cRowSource As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSource), "")
                    '            Dim cRowSourceType As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceType), "")
                    '            Dim cRowSourceDisplayField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceDisplayField), "")
                    '            Dim cRowSourceValueField As String = IfNull(.GetRowCellValue(i, FilterOptionFilterFields.RowSourceValueField), "")
                    '            Select Case .GetRowCellValue(i, FilterOptionFilterFields.RowSourceType)
                    '                Case RowSoureType.SQL, RowSoureType.Query, RowSoureType.PredefinedDataSource
                    '                    If cRowSource.Length > 0 And _
                    '                       cRowSourceDisplayField.Length > 0 And _
                    '                       cRowSourceValueField.Length > 0 Then

                    '                        Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, cValueFromTemplate, cRowSourceDisplayField)

                    '                        .SetRowCellValue(i, FilterOptionFilterFields.Value, cValueFromTemplate)
                    '                        .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, cDisplayValue)
                    '                    Else
                    '                        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
                    '                        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
                    '                    End If
                    '                Case RowSoureType.ItemList
                    '                    If cRowSource.Length > 0 Then

                    '                        cRowSourceValueField = ItemListFields.PKey
                    '                        cRowSourceDisplayField = ItemListFields.Name
                    '                        Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, cValueFromTemplate, cRowSourceDisplayField)

                    '                        .SetRowCellValue(i, FilterOptionFilterFields.Value, cValueFromTemplate)
                    '                        .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, cDisplayValue)
                    '                    Else
                    '                        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
                    '                        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
                    '                    End If
                    '            End Select


                    '        Case FilterOptionControlType.DateEdit
                    '            If IsDate(cValueFromTemplate) Then
                    '                .SetRowCellValue(i, FilterOptionFilterFields.Value, cValueFromTemplate)
                    '                .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, Format(CDate(cValueFromTemplate), REPORT_DATE_FORMAT))
                    '            End If
                    '        Case Else
                    '            .SetRowCellValue(i, FilterOptionFilterFields.Value, cValueFromTemplate)
                    '            .SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, cValueFromTemplate)

                    '    End Select
                    'End With

                Else
                    'commented out by tony20170105
                    'Select Case GridFilterView.GetRowCellValue(i, FilterOptionFilterFields.FieldType)
                    '    Case FilterOptionDataType.Numeric, FilterOptionDataType.Bool
                    '        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, 0)
                    '        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, 0)
                    '    Case FilterOptionDataType.String
                    '        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, "")
                    '        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, "")
                    '    Case Else
                    '        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.Value, Nothing)
                    '        GridFilterView.SetRowCellValue(i, FilterOptionFilterFields.DisplayValue, Nothing)
                    'End Select
                    'end tony
                End If
            Catch ex As Exception

            End Try

        Next

        GridFilter.Refresh()
    End Sub

    Public Sub SetFilterOptionValueColumnManual(rowhandle As Integer, _value As Object)
        If rowhandle < 0 Then Exit Sub

        With GridFilterView

            Select Case .GetRowCellValue(rowhandle, FilterOptionFilterFields.ControlType)
                Case FilterOptionControlType.ComboBox
                    Dim cRowSource As String = IfNull(.GetRowCellValue(rowhandle, FilterOptionFilterFields.RowSource), "")
                    Dim cRowSourceType As String = IfNull(.GetRowCellValue(rowhandle, FilterOptionFilterFields.RowSourceType), "")
                    Dim cRowSourceDisplayField As String = IfNull(.GetRowCellValue(rowhandle, FilterOptionFilterFields.RowSourceDisplayField), "")
                    Dim cRowSourceValueField As String = IfNull(.GetRowCellValue(rowhandle, FilterOptionFilterFields.RowSourceValueField), "")
                    Select Case .GetRowCellValue(rowhandle, FilterOptionFilterFields.RowSourceType)
                        Case RowSoureType.SQL, RowSoureType.Query, RowSoureType.PredefinedDataSource
                            If cRowSource.Length > 0 And _
                               cRowSourceDisplayField.Length > 0 And _
                               cRowSourceValueField.Length > 0 Then

                                Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

                                .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, _value)
                                .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, cDisplayValue)
                            Else
                                GridFilterView.SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, "")
                                GridFilterView.SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, "")
                            End If
                        Case RowSoureType.ItemList
                            If cRowSource.Length > 0 Then

                                cRowSourceValueField = ItemListFields.PKey
                                cRowSourceDisplayField = ItemListFields.Name
                                Dim cDisplayValue As String = getDisplayValueFromRowSource(cRowSource, cRowSourceType, cRowSourceValueField, _value, cRowSourceDisplayField)

                                .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, _value)
                                .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, cDisplayValue)
                            Else
                                GridFilterView.SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, "")
                                GridFilterView.SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, "")
                            End If
                    End Select


                Case FilterOptionControlType.DateEdit
                    If IsDate(_value) Then
                        .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, _value)
                        .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, Format(CDate(_value), REPORT_DATE_FORMAT))
                    End If
                Case Else
                    .SetRowCellValue(rowhandle, FilterOptionFilterFields.Value, _value)
                    .SetRowCellValue(rowhandle, FilterOptionFilterFields.DisplayValue, _value)

            End Select
        End With
    End Sub

    Private Function getDisplayValueFromRowSource(ByVal cRowSource As String, ByVal cRowSourceType As String, ByVal cRowSourceKeyField As String, ByVal cRowSourceKeyFieldValue As String, ByVal cRowSourceDisplayField As String) As String
        '####################################################################################################################################################################################################################################
        '### Description: Gets the Display value(column) of the selected rowsource
        Dim retval As String = ""
        Dim dt As DataTable
        Dim dr() As DataRow = Nothing


        dt = CreateFilterLookUpEditRepositoryDataTable(cRowSourceType, cRowSource, False)

        If cRowSourceType = RowSoureType.ItemList Then
            If IfNull(cRowSourceKeyField, "").Length = 0 Then cRowSourceKeyField = "PKey"
            If IfNull(cRowSourceDisplayField, "").Length = 0 Then cRowSourceDisplayField = "Name"
        End If

        If Not IsNothing(dt) Then
            If dt.Rows.Count > 0 Then
                dr = dt.Select(cRowSourceKeyField & " = '" & cRowSourceKeyFieldValue & "'")
            End If
        End If
        'Select Case cRowSourceType
        '    Case RowSoureType.Query, RowSoureType.SQL
        '        dt = MPSDB.CreateTable(cRowSource)
        '        dr = dt.Select(cRowSourceKeyField & " = '" & cRowSourceKeyFieldValue & "'")

        '    Case RowSoureType.PredefinedDataSource
        '        dt = getPredefDataSource(cRowSource)
        '        dr = dt.Select(cRowSourceKeyField & " = '" & cRowSourceKeyFieldValue & "'")

        '    Case RowSoureType.ItemList
        '        dt = changeItemListToDT(cRowSource)
        '        dr = dt.Select("PKey = '" & cRowSourceKeyFieldValue & "'")

        '    Case Else
        '        retval = cRowSourceKeyFieldValue

        'End Select

        If Not IsNothing(dr) Then
            If dr.Length > 0 Then
                retval = dr(0)(cRowSourceDisplayField)
            End If
        End If

        Return retval
    End Function

    Public Overrides Function HasFilterValuesToSave() As Boolean
        '####################################################################################################################################################################################################################################
        '### Description: Checks if there are any sselection made
        Dim bSuccess As Boolean = False
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A TEMPLATE PKEY PARAMETER PASSED

            With GridFilterView
                For i As Integer = 0 To .DataRowCount - 1
                    If .GetRowCellValue(i, "Value").ToString.Length > 0 Then
                        bSuccess = True
                        GoTo RETURN_AND_EXIT
                    End If
                Next
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function
#End Region

#Region "Filter Grid Tooltip"
    Private Sub GridFilter_MouseLeave(sender As Object, e As System.EventArgs)
        clearFilterTooltip()
    End Sub

    Private Sub GridFilterView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        Console.WriteLine(hitInfo.RowHandle)

        Dim nRowHandle As Integer = hitInfo.RowHandle

        If nRowHandle < 0 Then
            clearFilterTooltip()
        Else
            If hitInfo.Column.FieldName <> FilterOptionFilterFields.DisplayValue Then
                clearFilterTooltip()
            ElseIf nFilterTooltipRowHandlePrev <> nRowHandle Then
                showFilterTooltip(nRowHandle)
            End If
        End If
    End Sub

    Private Sub clearFilterTooltip()
        ToolTipController1.HideHint()
        nFilterTooltipRowHandlePrev = -1
    End Sub

    Private Sub showFilterTooltip(ByVal nRowHandle As Integer)

        Dim cTooltipDesc As String = ""
        Dim obj As Object = Nothing

        nFilterTooltipRowHandlePrev = nRowHandle
        ToolTipController1.HideHint()


        If GridFilterView.GetRowCellValue(nRowHandle, FilterOptionFilterFields.FieldName).ToString.Length > 0 Then
            cTooltipDesc = cTooltipDesc & IIf(cTooltipDesc.Length > 0, " and ", "") & "the report selection"
        End If

        If (GridFilterView.GetRowCellValue(nRowHandle, FilterOptionFilterFields.ApplyToReportSource).ToString = "1") Then
            cTooltipDesc = cTooltipDesc & IIf(cTooltipDesc.Length > 0, " and ", "") & "the report data source"
        End If

        If cTooltipDesc.Length > 0 Then
            cTooltipDesc = "This filter applies to " & cTooltipDesc & "."
            ToolTipController1.ShowHint(cTooltipDesc, DevExpress.Utils.ToolTipLocation.RightCenter)
        End If

        'If GridFilterView.GetRowCellValue(nRowHandle, FilterOptionFilterFields.FieldName).ToString.Length > 0 Then
        '    obj = GridSelectionView.Columns(GridFilterView.GetRowCellValue(nRowHandle, FilterOptionFilterFields.FieldName))
        'End If

        'If Not obj Is Nothing Then
        '    cTooltipDesc = cTooltipDesc & IIf(cTooltipDesc.Length > 0, " and ", "") & "the report selection"
        'End If

        'If (GridFilterView.GetRowCellValue(nRowHandle, FilterOptionFilterFields.ApplyToReportSource).ToString = "1") Then
        '    cTooltipDesc = cTooltipDesc & IIf(cTooltipDesc.Length > 0, " and ", "") & "the report data source"
        'End If

        'If cTooltipDesc.Length > 0 Then
        '    cTooltipDesc = "This filter applies to " & cTooltipDesc & "."
        '    ToolTipController1.ShowHint(cTooltipDesc, DevExpress.Utils.ToolTipLocation.RightCenter)
        'End If

    End Sub
#End Region
End Class
