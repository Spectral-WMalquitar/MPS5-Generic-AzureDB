Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

Public Class BaseSortOption

    '**********************************************************************************************************
    'Notes:
    '   1. To clear the value of ALL sort options, call ClearSortValueAll
    '   2. To clear the value of SPECIFIC sort options control, use ClearSortValue(<field name>)
    '
#Region "Declarations"
    Public bIsLoaded As Boolean = False

    Public SortFields As String = ""

    Public SortDataSource As New DataTable

    '####################################################################################################################################################################################################################################
    'VARIABLE TO HANDLE DRAG AND DROP IN SELECTION AND SELECTED GRIDS
    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle
    Private fromIndexMovable As Boolean
    Private dragIndexMovable As Boolean
    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

#End Region

#Region "Main"

    Public Overridable Sub RefreshData()
        If Not bIsLoaded Then
            InitControls()
        End If

        LoadSub()

    End Sub

    Public Overridable Sub RefreshData(cSortFields As String)
        SortFields = Trim(IfNull(cSortFields, ""))

        If Not bIsLoaded Then
            InitControls()
            LoadSub()
        End If
    End Sub

    Public Overridable Sub InitControls()
        '####################################################################################################################################################################################################################################
        'POPULATES DATASOURCE OF `SortOrder` REPOSITORY
        Dim dt As New DataTable

        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        dt.Rows.Add(New Object() {SortOptionSortCode.None, "None"})
        dt.Rows.Add(New Object() {SortOptionSortCode.Ascending, "Ascending"})
        dt.Rows.Add(New Object() {SortOptionSortCode.Descending, "Descending"})
        repSortOrder.DataSource = dt
    End Sub

    Public Overridable Sub LoadSub()
        SortDataSource = New DataTable

        Dim ccolumn As DataColumn
        Dim row As String()

        If SortFields.Length > 0 Then

            ccolumn = New DataColumn
            ccolumn.ColumnName = SortOptionFields.FieldName.ToString
            ccolumn.DataType = System.Type.GetType("System.String")
            SortDataSource.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = SortOptionFields.Caption.ToString
            ccolumn.DataType = System.Type.GetType("System.String")
            SortDataSource.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = SortOptionFields.SortOrder.ToString
            ccolumn.DataType = System.Type.GetType("System.String")
            SortDataSource.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = SortOptionFields.isMovable.ToString
            ccolumn.DataType = System.Type.GetType("System.String")
            SortDataSource.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = SortOptionFields.DefaultSortOrder.ToString
            ccolumn.DataType = System.Type.GetType("System.String")
            SortDataSource.Columns.Add(ccolumn)

            Try
                Dim fields As String() = SortFields.Split(";")
                Dim fieldParam As String()
                Dim isMovable As Integer = 0

                For i As Integer = 0 To fields.GetUpperBound(0)
                    Try
                        fieldParam = fields(i).Split("~")

                        If fieldParam.GetUpperBound(0) > 1 Then
                            If fieldParam.GetUpperBound(0) > 2 Then
                                If CInt(fieldParam(3)) = 1 Then
                                    isMovable = 0
                                Else
                                    isMovable = 1
                                End If
                            Else
                                isMovable = 1
                            End If
                            Dim cSortValue As String = IIf(fieldParam(2) <> SortOptionSortCode.Ascending And fieldParam(2) <> SortOptionSortCode.Descending, "NONE", fieldParam(2))
                            row = New String() {fieldParam(0), fieldParam(1), cSortValue, isMovable, cSortValue}

                            SortDataSource.Rows.Add(row)
                        End If
                    Catch ex As Exception
                        Dim errMSg As String = ex.Message
                        LogErrors("Arranging Filter Options...")
                        LogErrors("[" & fields(i) & "]" & errMSg)
                    End Try
                Next

                GridSort.DataSource = SortDataSource

            Catch ex As Exception
                Dim errMSg As String = ex.Message
                LogErrors("Showing Filter Options...")
                LogErrors(errMSg)
            End Try

        End If
    End Sub

    Public Overridable Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "1"

            Case "2"

            Case "3"

        End Select
    End Sub

    Public Overridable Function GetSortString(Optional param() As Object = Nothing) As String
        '### Description: Gets the sorting string (ORDER BY clause) from the Sort Fields block
        Dim cRetval As String

        cRetval = ""

        With GridSortView
            For i As Integer = 0 To .RowCount - 1
                If Not IsDBNull(.GetRowCellValue(i, SortOptionFields.SortOrder)) Then
                    If .GetRowCellValue(i, SortOptionFields.SortOrder) = SortOptionSortCode.Ascending Or .GetRowCellValue(i, SortOptionFields.SortOrder) = SortOptionSortCode.Descending Then
                        cRetval = cRetval & IIf(cRetval.Length > 0, ", ", "") & .GetRowCellValue(i, SortOptionFields.FieldName) & _
                                  IIf(.GetRowCellValue(i, SortOptionFields.SortOrder) = SortOptionSortCode.Descending, " Desc", "")
                    End If
                End If
            Next
        End With

        Return cRetval
    End Function
#End Region

#Region "Report Selection Events"

    Public Overridable Function GetSortValue(ByVal cFieldName As String) As String
        '####################################################################################################################################################################################################################################
        'GET SORT VALUE OF A SPECIFIC FIELD FROM THE SORT OPTIONS
        'Returns: ASC if ascending; DESC if descending; empty string if none
        Dim objValue = Nothing
        Dim ReturnValue = ""
        Dim oControl As New Control

        Try
            With GridSortView
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, SortOptionFields.FieldName) = cFieldName Then

                        Try
                            ReturnValue = .GetRowCellValue(i, SortOptionFields.SortOrder)
                        Catch ex As Exception

                        End Try

                        Exit For

                    End If

                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo RETURN_AND_EXIT
        End Try

        ReturnValue = IIf(ReturnValue = SortOptionSortCode.None, "", ReturnValue)
        Return ReturnValue
        Exit Function
RETURN_AND_EXIT:
        Return ReturnValue
    End Function

    Public Overridable Function GetSortValueCode(ByVal cFieldName As String) As Integer
        '####################################################################################################################################################################################################################################
        'GET SORT VALUE OF A SPECIFIC FIELD FROM THE SORT OPTIONS
        'Returns: 1 if ascending; 2 if descending; 0 if none
        Dim ReturnValue As Integer = 0
        Dim oControl As New Control

        Try
            With GridSortView
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, SortOptionFields.FieldName) = cFieldName Then

                        Try
                            Select Case .GetRowCellValue(i, SortOptionFields.SortOrder)
                                Case SortOptionSortCode.Ascending
                                    ReturnValue = 1
                                Case SortOptionSortCode.Descending
                                    ReturnValue = 2
                            End Select
                        Catch ex As Exception

                        End Try
                        Exit For

                    End If

                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo RETURN_AND_EXIT
        End Try

        Return ReturnValue
        Exit Function
RETURN_AND_EXIT:
        Return ReturnValue
    End Function

    Public Overridable Sub ClearSortValueAll()
        '####################################################################################################################################################################################################################################
        'CLEARS VALUES OF ALL THE SORT OPTIONS FIELDS
        With GridSortView
            For i As Integer = 0 To .RowCount - 1
                Try
                    .SetRowCellValue(i, SortOptionFields.SortOrder, SortOptionSortCode.None)
                Catch ex As Exception

                End Try
            Next
        End With
    End Sub

    Public Overridable Sub ClearSortValue(ByVal cFieldName As String)
        '####################################################################################################################################################################################################################################
        'CLEARS VALUES OF SPECIFIC SORT OPTIONS FIELDS
        With GridSortView
            For i As Integer = 0 To .RowCount - 1
                Try
                    If .GetRowCellValue(i, SortOptionFields.FieldName) = cFieldName Then
                        .SetRowCellValue(i, SortOptionFields.SortOrder, SortOptionSortCode.None)
                        Exit For
                    End If
                Catch ex As Exception

                End Try
            Next
        End With
    End Sub

#Region "Reset Sort Option Value(s)"
    Public Overridable Sub ResetSortValueAll()
        '####################################################################################################################################################################################################################################
        'RESET VALUES OF ALL THE SORT OPTIONS FIELDS
        Dim arrSortFields() As String
        arrSortFields = SortFields.Split(";")

        With GridSortView
            For i As Integer = 0 To .RowCount - 1
                Try
                    .SetRowCellValue(i, SortOptionFields.SortOrder, .GetRowCellValue(i, SortOptionFields.DefaultSortOrder))
                Catch ex As Exception

                End Try
            Next
        End With
    End Sub

    Public Overridable Sub ResetSortValue(ByVal cFieldName As String)
        '####################################################################################################################################################################################################################################
        'CLEARS VALUES OF SPECIFIC SORT OPTIONS FIELDS
        With GridSortView
            For i As Integer = 0 To .RowCount - 1
                Try
                    If .GetRowCellValue(i, SortOptionFields.FieldName) = cFieldName Then
                        .SetRowCellValue(i, SortOptionFields.SortOrder, .GetRowCellValue(i, SortOptionFields.DefaultSortOrder))
                        Exit For
                    End If
                Catch ex As Exception

                End Try
            Next
        End With
    End Sub
#End Region

#End Region

#Region "Report Building Events"
    Public Overridable Function GetSortDataSource() As DataTable
        Return SortDataSource
    End Function
#End Region

#Region "Drag and Drop"
    Private Function GridSortFieldMovable(ByVal Index As Integer, Optional DoNotShowMessage As Boolean = False) As Boolean
        Dim bRetval As Boolean = True

        If fromIndexMovable <> dragIndexMovable Then
            If Not DoNotShowMessage Then
                MsgBox("Rearranging the order of this sort field is not allowed because the report is grouped by this field.", MsgBoxStyle.Exclamation)
            End If
            bRetval = False
        End If

        Return bRetval
    End Function

    Private Sub GridSort_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridSort.DragDrop
        Dim p As Point = GridSort.PointToClient(New Point(e.X, e.Y))

        If Not GridSortFieldMovable(fromIndex) Then Exit Sub
        Try
            If Not GridSortFieldMovable(dragIndex) Then Exit Sub
            If (e.Effect = DragDropEffects.Move) Then
                Dim dragRow As DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)

                If dragIndex < 0 Then dragIndex = GridSortView.DataRowCount - 1
                Dim rowFrom As DataRow = GridSortView.GetDataRow(fromIndex)
                Dim rowDest As DataRow = GridSortView.GetDataRow(dragIndex)

                'Dim rowTemp As Object() = rowFrom.ItemArray
                'rowFrom.ItemArray = rowDest.ItemArray
                'rowDest.ItemArray = rowTemp

                Dim dt As DataTable = CType(GridSort.DataSource, DataTable)

                If (dragIndex > -1 And fromIndex > -1) And _
                    ((dragIndex - fromIndex) = 1 Or (fromIndex - dragIndex) = 1) Then
                    Dim rowTemp As Object() = rowFrom.ItemArray
                    rowFrom.ItemArray = rowDest.ItemArray
                    rowDest.ItemArray = rowTemp

                    GridSortView.FocusedRowHandle = dragIndex
                Else
                    Dim newRow As DataRow = dt.NewRow
                    'dt.Rows.InsertAt(newRow, dragIndex)
                    'Dim newlyAddedRow As DataRow = dt.Rows(dragIndex)
                    'newlyAddedRow.ItemArray = rowFrom.ItemArray
                    'dt.Rows.RemoveAt(fromIndex + IIf(dragIndex < fromIndex, 1, 0))

                    'GridSort.DataSource = dt

                    'GridSortView.FocusedRowHandle = dragIndex + IIf(dragIndex > fromIndex, -1, 0)
                    Dim newPos As Integer = dragIndex + IIf(dragIndex > fromIndex, 1, 0)
                    dt.Rows.InsertAt(newRow, newPos)
                    Dim newlyAddedRow As DataRow = dt.Rows(newPos)
                    newlyAddedRow.ItemArray = rowFrom.ItemArray
                    dt.Rows.RemoveAt(fromIndex + IIf(dragIndex < fromIndex, 1, 0))

                    GridSort.DataSource = dt

                    GridSortView.FocusedRowHandle = dragIndex '+ IIf(dragIndex > fromIndex, -1, 0)
                End If
                
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridSort_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridSort.DragOver
        If e.Data.GetDataPresent(GetType(GridHitInfo)) Then
            Dim downHitInfo As GridHitInfo = TryCast(e.Data.GetData(GetType(GridHitInfo)), GridHitInfo)
            If downHitInfo Is Nothing Then
                Return
            End If

            Dim grid As DevExpress.XtraGrid.GridControl = TryCast(sender, DevExpress.XtraGrid.GridControl)
            Dim view As GridView = TryCast(grid.MainView, GridView)
            Dim hitInfo As GridHitInfo = view.CalcHitInfo(grid.PointToClient(New Point(e.X, e.Y)))
            If hitInfo.InRow AndAlso hitInfo.RowHandle <> downHitInfo.RowHandle AndAlso hitInfo.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                e.Effect = DragDropEffects.Move
                dragIndex = hitInfo.RowHandle
                dragIndexMovable = view.GetDataRow(dragIndex).Item(SortOptionFields.isMovable)
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Sub GridSortView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridSortView.MouseDown
        Dim view As GridView = TryCast(sender, GridView)
        downHitInfo = Nothing
        Try
            Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
            fromIndex = hitInfo.RowHandle
            If fromIndex >= 0 Then
                fromIndexMovable = view.GetDataRow(fromIndex).Item(SortOptionFields.isMovable)
            Else
                fromIndexMovable = 0
            End If
            If Control.ModifierKeys <> Keys.None Then
                Return
            End If
            If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                downHitInfo = hitInfo
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridSortView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridSortView.MouseMove
        Dim view As GridView = TryCast(sender, GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
            dragIndex = hitInfo.RowHandle
            dragIndexMovable = view.GetDataRow(dragIndex).Item(SortOptionFields.isMovable)

            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width \ 2, downHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)

            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                view.GridControl.DoDragDrop(downHitInfo, DragDropEffects.All)
                downHitInfo = Nothing
            End If
        End If
    End Sub

    Private Sub GridSort_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridSort.MouseMove
        Try
            If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
                If (dragRect <> Rectangle.Empty _
                AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                    GridSort.DoDragDrop(GridSortView.GetRow(fromIndex), _
                                             DragDropEffects.Move)
                End If
            End If
        Catch ex As Exception
            'do nothing
        End Try
    End Sub
#End Region

#Region "Templates-Related"
    Public Overridable Function SaveSortOptionValuesToTemplate(ByVal cTemplatePKey As String) As Boolean
        Dim bSuccess As Boolean = False
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A PASSED TEMPLATE PKEY PARAMETER
            If cTemplatePKey.Length > 0 Then
                With GridSortView
                    For i As Integer = 0 To .DataRowCount - 1
                        Try
                            bSuccess = MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                  "VALUES ('" & cTemplatePKey & "', '" & .GetRowCellValue(i, SortOptionFields.FieldName) & "', '" & ReportTemplateContentType.Sort & "', '" & .GetRowCellValue(i, SortOptionFields.SortOrder) & "', " & i & ")")
                        Catch ex As Exception
                            LogErrors("Inserting sorting [" & .GetRowCellValue(i, SortOptionFields.FieldName) & " = " & .GetRowCellValue(i, SortOptionFields.SortOrder) & "] into report template with key [" & cTemplatePKey & "] failed.")
                            LogErrors("Error: " & ex.Message)
                        End Try
                    Next
                End With

            Else
                '####################################################################################################################################################################################################################################
                'IF THERE IS NO PASSED TemplatePKey PARAMETER
                bSuccess = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function

    Public Overridable Function HasSortOptionTemplateValues(ByVal TemplateKey As String) As Boolean
        Dim ReturnVavlue As Boolean = False
        Try
            MPSDB.BeginReader("SELECT * FROM dbo.MSystblRepOptTemplateValues WHERE FKeyTemplate = '" & TemplateKey & "' AND OptionsType = '" & ReportTemplateContentType.Sort & "'")
            ReturnVavlue = MPSDB.HasRows
        Catch ex As Exception
            ReturnVavlue = False
        End Try

        Return ReturnVavlue
    End Function

    Public Overridable Sub LoadSortOptionTemplateValues(ByVal TemplateKey As String)
        Dim templateItems As DataTable = CreateReportTemplateValuesDT(TemplateKey, ReportTemplateContentType.Sort)
        If templateItems.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To GridSortView.DataRowCount - 1
            Dim row As DataRow = templateItems.Select("OptionsObjectID = '" & GridSortView.GetRowCellValue(i, SortOptionFields.FieldName) & "'").FirstOrDefault()
            Try

                If Not row Is Nothing Then
                    Dim cValueFromTemplate = row("Value")

                    If IsDBNull(cValueFromTemplate) Or cValueFromTemplate.ToString.Length = 0 Then
                        GridSortView.SetRowCellValue(i, SortOptionFields.SortOrder, SortOptionSortCode.None)
                    Else
                        GridSortView.SetRowCellValue(i, SortOptionFields.SortOrder, cValueFromTemplate)
                    End If

                    'Dim nTemplateRowHandle As Integer = IfNull(row.Item(SortOptionFields.SortOrder.ToString), 0)
                    Dim nTemplateRowHandle As Integer = IfNull(row.Item("SortCode"), 0)
                    Dim rowFrom As DataRow = GridSortView.GetDataRow(i)
                    Dim rowDest As DataRow = GridSortView.GetDataRow(nTemplateRowHandle)

                    Dim rowTemp As Object() = rowFrom.ItemArray
                    rowFrom.ItemArray = rowDest.ItemArray
                    rowDest.ItemArray = rowTemp
                Else
                    GridSortView.SetRowCellValue(i, SortOptionFields.SortOrder, SortOptionSortCode.None)
                End If
            Catch ex As Exception

            End Try

        Next
    End Sub

    Public Overridable Function HasSortValuesToSave() As Boolean
        Dim bSuccess As Boolean = False
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A TEMPLATE PKEY PARAMETER PASSED

            With GridSortView
                For i As Integer = 0 To .DataRowCount - 1
                    If .GetRowCellValue(i, SortOptionFields.SortOrder) = SortOptionSortCode.Ascending Or .GetRowCellValue(i, SortOptionFields.SortOrder) = SortOptionSortCode.Descending Then
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

#Region "Clear LookUpEdit Value"
    Private Sub repSortOrder_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repSortOrder.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Try
                GridSortView.SetRowCellValue(GridSortView.FocusedRowHandle, SortOptionFields.SortOrder, SortOptionSortCode.None)
            Catch ex As Exception

            End Try
        End If
    End Sub
#End Region
End Class
