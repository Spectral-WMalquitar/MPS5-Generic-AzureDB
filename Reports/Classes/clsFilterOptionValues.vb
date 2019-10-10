Public Class clsFilterOptionValues

    Public Enum FilterOptionContentType
        GridControl = 1 'Uses Grid
        UserControl = 2
    End Enum

    Public SavedGridControlValues As New GridControlValues
    Public SavedUserControlValues As New UserControlValues

#Region "Object Classes"
    '####################################################################################################################################################################################################################################
    'This Class is used to store filter option values which content type is user control
    Public Class UserControlValues
#Region "Sub Classes"
        Public Class CustomUserControlClass
            Public ControlObject As New ControlObjectClass
            Public FilterOption As New BaseFilterOption

            Public Sub New(cObjectDLL As String, cObjectClass As String, _FilterOption As BaseFilterOption)
                ControlObject.ObjectDLL = cObjectDLL
                ControlObject.ObjectClass = cObjectClass
                FilterOption = _FilterOption
            End Sub
        End Class
#End Region

        'Private CustomUserControlList As List(Of BaseFilterOption)
        Private CustomUserControlList As New List(Of CustomUserControlClass)
        'Public SavedValues As DataTable

        'Private Structure SavedUserControlValueFields
        '    Const ObjectDLL As String = "ObjectDLL"
        '    Const ObjectClass As String = "ObjectClass"
        '    Const ControlName As String = "ControlName"
        '    Const Value As String = "Value"
        'End Structure

        'Public Sub New()
        '    SavedValues = New DataTable
        '    Dim ccolumn As DataColumn

        '    ccolumn = New DataColumn
        '    ccolumn.ColumnName = SavedUserControlValueFields.ObjectDLL
        '    ccolumn.DataType = System.Type.GetType("System.String")
        '    SavedValues.Columns.Add(ccolumn)

        '    ccolumn = New DataColumn
        '    ccolumn.ColumnName = SavedUserControlValueFields.ObjectClass
        '    ccolumn.DataType = System.Type.GetType("System.String")
        '    SavedValues.Columns.Add(ccolumn)

        '    ccolumn = New DataColumn
        '    ccolumn.ColumnName = SavedUserControlValueFields.ControlName
        '    ccolumn.DataType = System.Type.GetType("System.String")
        '    SavedValues.Columns.Add(ccolumn)

        '    ccolumn = New DataColumn
        '    ccolumn.ColumnName = SavedUserControlValueFields.Value
        '    ccolumn.DataType = System.Type.GetType("System.Object")
        '    SavedValues.Columns.Add(ccolumn)

        'End Sub

        Public Sub Save(_FilterOption As BaseFilterOption)

            For i As Integer = 0 To CustomUserControlList.Count - 1
                If CustomUserControlList(i).ControlObject.ObjectDLL = _FilterOption.ControlObject.ObjectDLL And _
                    CustomUserControlList(i).ControlObject.ObjectClass = _FilterOption.ControlObject.ObjectClass Then
                    CustomUserControlList.RemoveAt(i)
                    Exit For
                End If
            Next

            CustomUserControlList.Add(New CustomUserControlClass(_FilterOption.ControlObject.ObjectDLL, _FilterOption.ControlObject.ObjectClass, _FilterOption))
        End Sub

        'Public Sub Save(cObjectDLL As String, cObjectClass As String, cControlName As String, _value As Object)
        '    Dim row As DataRow()
        '    row = SavedValues.Select(SavedUserControlValueFields.ObjectDLL & " = '" & cObjectDLL & "' AND " & _
        '                             SavedUserControlValueFields.ObjectClass & " = '" & cObjectClass & "' AND " & _
        '                             SavedUserControlValueFields.ControlName & " = '" & cControlName & "'")
        '    If row.Count > 0 Then
        '        row(0)(SavedUserControlValueFields.Value) = _value
        '    End If
        'End Sub

        Public Function GetValue(cObjectDLL As String, cObjectClass As String) As BaseFilterOption
            Dim ReturnValue As BaseFilterOption = Nothing

            For Each obj As CustomUserControlClass In CustomUserControlList
                If obj.ControlObject.ObjectClass = cObjectClass And obj.ControlObject.ObjectDLL = cObjectDLL Then
                    ReturnValue = obj.FilterOption
                    Exit For
                End If
            Next

            Return ReturnValue
        End Function

        Public Sub Clear()
            CustomUserControlList.Clear()
        End Sub
    End Class

    '####################################################################################################################################################################################################################################
    'This Class is used to store filter option values which content type is gridcontrol
    Public Class GridControlValues

        Private Structure SavedGridValueFields
            Public Const FKeyFilterOption As String = "FKeyFilterOption"
            Public Const RowSource As String = "RowSource"
            Public Const KeyField As String = "KeyField"
            Public Const Caption As String = "Caption"
            Public Const Value As String = "Value"
        End Structure

        Public SavedValues As DataTable

        Public Sub New()
            SavedValues = New DataTable
            Dim ccolumn As DataColumn

            ccolumn = New DataColumn
            ccolumn.ColumnName = SavedGridValueFields.FKeyFilterOption
            ccolumn.DataType = System.Type.GetType("System.String")
            SavedValues.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = SavedGridValueFields.RowSource
            ccolumn.DataType = System.Type.GetType("System.String")
            SavedValues.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = SavedGridValueFields.KeyField
            ccolumn.DataType = System.Type.GetType("System.String")
            SavedValues.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = SavedGridValueFields.Caption
            ccolumn.DataType = System.Type.GetType("System.String")
            SavedValues.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = SavedGridValueFields.Value
            ccolumn.DataType = System.Type.GetType("System.Object")
            SavedValues.Columns.Add(ccolumn)
        End Sub


        Public Sub Save(cFKeyFilterOption As String, cRowSource As String, cKeyField As String, cCaption As String, _value As Object)
            Dim rows As DataRow()
            Dim rowindex As Integer
            Dim _RowSource As String, _Caption As String
            Try
                _RowSource = cRowSource
                _RowSource = _RowSource.Replace("'", "''")
                _RowSource = _RowSource.Replace("""", """""")
                _Caption = cCaption
                _Caption = _Caption.Replace("'", "''")
                _Caption = _Caption.Replace("""", """""")
                rows = SavedValues.Select(SavedGridValueFields.FKeyFilterOption & " = '" & cFKeyFilterOption & "' AND " & SavedGridValueFields.RowSource & " = '" & _RowSource & "' AND " & SavedGridValueFields.KeyField & " = '" & cKeyField & "' AND Caption = '" & _Caption & "'")
                If rows.Length > 0 Then
                    rowindex = SavedValues.Rows.IndexOf(rows(0))

                    SavedValues.Rows(rowindex).Item(SavedGridValueFields.Value) = _value
                Else
                    Dim newrow As DataRow = SavedValues.NewRow
                    With newrow
                        .Item(SavedGridValueFields.FKeyFilterOption) = cFKeyFilterOption
                        .Item(SavedGridValueFields.RowSource) = cRowSource
                        .Item(SavedGridValueFields.KeyField) = cKeyField
                        .Item(SavedGridValueFields.Caption) = cCaption
                        .Item(SavedGridValueFields.Value) = _value
                    End With
                    SavedValues.Rows.Add(newrow)
                End If
            Catch ex As Exception
                LogErrors("Failed to Save: " & ex.Message)
            End Try
        End Sub

        Public Function GetValue(cFKeyFilterOption As String, cRowSource As String, cKeyField As String) As Object
            Dim ReturnValue As Object = ""
            Dim _RowSource As String
            Try
                _RowSource = cRowSource
                _RowSource = _RowSource.Replace("'", "''")
                _RowSource = _RowSource.Replace("""", """""")
                Dim cCondition As String = SavedGridValueFields.FKeyFilterOption & " = '" & cFKeyFilterOption & "' AND " & SavedGridValueFields.RowSource & " = '" & _RowSource & "' AND " & SavedGridValueFields.KeyField & " = '" & cKeyField & "'"
                ReturnValue = GetValueFromSavedValueDT(cCondition)
            Catch ex As Exception
                ReturnValue = ""
                LogErrors("Failed to GetValue: " & ex.Message)
            End Try
            Return ReturnValue
        End Function

        Public Function GetValue(cFKeyFilterOption As String, cRowSource As String, cKeyField As String, cCaption As String) As Object
            Dim ReturnValue As Object = ""
            Dim cCondition As String = ""
            Try
                cRowSource = cRowSource.Replace("'", "''")
                cRowSource = cRowSource.Replace("""", """""")
                cCaption = cCaption.Replace("'", "''")
                cCaption = cCaption.Replace("""", """""")
                If cFKeyFilterOption.Length > 0 And cRowSource.Length > 0 And cKeyField.Length > 0 Then
                    If cCaption.Length > 0 Then
                        cCondition = SavedGridValueFields.FKeyFilterOption & " = '" & cFKeyFilterOption & "' AND " & SavedGridValueFields.RowSource & " = '" & cRowSource & "' AND " & SavedGridValueFields.KeyField & " = '" & cKeyField & "' AND Caption = '" & cCaption & "'"
                    Else
                        cCondition = SavedGridValueFields.FKeyFilterOption & " = '" & cFKeyFilterOption & "' AND " & SavedGridValueFields.RowSource & " = '" & cRowSource & "' AND " & SavedGridValueFields.KeyField & " = '" & cKeyField & "'"
                    End If
                ElseIf cFKeyFilterOption.Length > 0 And cRowSource.Length = 0 And cKeyField.Length = 0 And cCaption.Length > 0 Then
                    cCondition = SavedGridValueFields.FKeyFilterOption & " = '" & cFKeyFilterOption & "' AND Caption = '" & cCaption & "'"
                End If
                ReturnValue = GetValueFromSavedValueDT(cCondition)

            Catch ex As Exception
                ReturnValue = ""
                LogErrors("Failed to GetValue: " & ex.Message)
            End Try
            Return ReturnValue
        End Function

        Public Function GetValue(cCaption As String) As Object
            Dim ReturnValue As Object = ""
            Try
                cCaption = cCaption.Replace("'", "''")
                cCaption = cCaption.Replace("""", """""")
                Dim cCondition As String = SavedGridValueFields.Caption & " = '" & cCaption & "'"
                ReturnValue = GetValueFromSavedValueDT(cCondition)
            Catch ex As Exception
                ReturnValue = ""
                LogErrors("Failed to GetValue: " & ex.Message)
            End Try
            Return ReturnValue
        End Function

        Public Sub Clear()
            SavedValues.Rows.Clear()
        End Sub

        Public Sub Remove(cFKeyFilterOption As String, cRowSource As String, cKeyField As String, cCaption As String)
            Dim cCondition As String = ""
            cRowSource = cRowSource.Replace("'", "''")
            cRowSource = cRowSource.Replace("""", """""")
            cCaption = cCaption.Replace("'", "''")
            cCaption = cCaption.Replace("""", """""")
            If cFKeyFilterOption.Length > 0 And cRowSource.Length > 0 And cKeyField.Length > 0 Then
                If cCaption.Length > 0 Then
                    cCondition = SavedGridValueFields.FKeyFilterOption & " = '" & cFKeyFilterOption & "' AND " & SavedGridValueFields.RowSource & " = '" & cRowSource & "' AND " & SavedGridValueFields.KeyField & " = '" & cKeyField & "' AND Caption = '" & cCaption & "'"
                Else
                    cCondition = SavedGridValueFields.FKeyFilterOption & " = '" & cFKeyFilterOption & "' AND " & SavedGridValueFields.RowSource & " = '" & cRowSource & "' AND " & SavedGridValueFields.KeyField & " = '" & cKeyField & "'"
                End If
            ElseIf cFKeyFilterOption.Length > 0 And cRowSource.Length = 0 And cKeyField.Length = 0 And cCaption.Length > 0 Then
                cCondition = SavedGridValueFields.FKeyFilterOption & " = '" & cFKeyFilterOption & "' AND Caption = '" & cCaption & "'"
            End If

            RemoveFromSavedValueDT(cCondition)
        End Sub


#Region "Reference to SavedValue DT"
        Private Function GetValueFromSavedValueDT(cCondition As String) As Object
            Dim ReturnValue As Object = ""
            Dim rows As DataRow()
            If cCondition.Length > 0 Then
                rows = SavedValues.Select(cCondition)
                If rows.Length > 0 Then
                    ReturnValue = rows(0)("Value")
                End If
            End If
            Return ReturnValue
        End Function

        Private Function RemoveFromSavedValueDT(cCondition As String) As Object
            Dim ReturnValue As Object = ""
            Dim rows As DataRow()
            Dim rowindex As Integer
            If cCondition.Length > 0 Then
                rows = SavedValues.Select(cCondition)
                rowindex = SavedValues.Rows.IndexOf(rows(0))
                SavedValues.Rows(rowindex).Delete()
            End If
            Return ReturnValue
        End Function
#End Region
    End Class

#End Region

    Public Sub Clear()
        SavedGridControlValues.Clear()
        'commented out by tony20180108 - GridOption User Control should not be cleared or removed.
        'SavedUserControlValues.Clear()
        'end tony
    End Sub

End Class
