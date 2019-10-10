Public Class frmPopupDetails

    Private Const ROW_HEIGHT As Double = 40

    Public Enum TypeOfRecordToShow
        ContactDetails = 1
        TravelDocuments = 2
        'FlightDetails = 3
    End Enum

    Public Sub New(pTypeOfRecordToShow As TypeOfRecordToShow, data As DataRow)
        InitializeComponent()

        SetupFields(pTypeOfRecordToShow)

        SetupData(pTypeOfRecordToShow, data)

        If pTypeOfRecordToShow = TypeOfRecordToShow.ContactDetails Then Me.Height = 270
        If pTypeOfRecordToShow = TypeOfRecordToShow.TravelDocuments Then Me.Height = 480

    End Sub

    Private Sub SetupFields(pTypeOfRecordToShow As TypeOfRecordToShow)
        DetailsVGrid.Rows.Clear()

        Select Case pTypeOfRecordToShow
            Case TypeOfRecordToShow.ContactDetails
                AddRow(DetailsVGrid, New VGridRow("rowCelphone", "Mobile No.", "Celphone"))
                AddRow(DetailsVGrid, New VGridRow("rowPhone", "Phone No.", "Phone"))
                AddRow(DetailsVGrid, New VGridRow("rowEmail", "Email", "Email"))

            Case TypeOfRecordToShow.TravelDocuments
                'PASSPORT
                Dim catRow_PP As New DevExpress.XtraVerticalGrid.Rows.CategoryRow
                catRow_PP.Properties.Caption = "Passport"
                catRow_PP.Appearance.Font = New System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Bold)
                catRow_PP.Appearance.ForeColor = System.Drawing.Color.Blue

                Dim v As New List(Of VGridRow)
                v.Add(New VGridRow("rowPPNo", "Passport No.", "PPNo"))
                v.Add(New VGridRow("rowPPIssueDate", "Issue Date", "PPIssueDate"))
                v.Add(New VGridRow("rowPPExpiryDate", "Expiry Date", "PPExpiryDate"))
                v.Add(New VGridRow("rowPPPlaceIssue", "Issue Place", "PPPlaceIssue"))
                AddChildRows(catRow_PP, v)

                'SEAMAN'S BOOK
                Dim catRow_SB As New DevExpress.XtraVerticalGrid.Rows.CategoryRow
                catRow_SB.Properties.Caption = "Seaman's Book"
                catRow_SB.Appearance.Font = New System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Bold)
                catRow_SB.Appearance.ForeColor = System.Drawing.Color.Blue
                v = New List(Of VGridRow)
                v.Add(New VGridRow("rowSBNo", "Seaman's Book No.", "SBNo"))
                v.Add(New VGridRow("rowSBIssueDate", "Issue Date", "SBIssueDate"))
                v.Add(New VGridRow("rowSBExpiryDate", "Expiry Date", "SBExpiryDate"))
                v.Add(New VGridRow("rowSBPlaceIssue", "Issue Place", "SBPlaceIssue"))
                AddChildRows(catRow_SB, v)

                'VISA
                Dim catRow_Visa As New DevExpress.XtraVerticalGrid.Rows.CategoryRow
                catRow_Visa.Properties.Caption = "Visa"
                catRow_Visa.Appearance.Font = New System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Bold)
                catRow_Visa.Appearance.ForeColor = System.Drawing.Color.Blue
                AddChildRow(catRow_Visa, New VGridRow("rowVisa", "Visa", "Visa"))

                'MAIN VGRIDCONTROL
                DetailsVGrid.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {catRow_PP, catRow_SB, catRow_Visa})
        End Select

        DetailsVGrid.RecordWidth = 150
    End Sub

    Private Sub SetupData(pTypeOfRecordToShow As TypeOfRecordToShow, data As DataRow)
        If IsNothing(data) Then Exit Sub

        Me.txtCrewName.EditValue = data("CrewName")
        Me.txtCrewName.ReadOnly = True
        Me.DetailsVGrid.OptionsBehavior.Editable = False

        Select Case pTypeOfRecordToShow
            Case TypeOfRecordToShow.ContactDetails
                With DetailsVGrid
                    .SetCellValue(FindVGridRow(DetailsVGrid, "CelPhone"), DetailsVGrid.FocusedRecord, data("CelPhone"))
                    .SetCellValue(FindVGridRow(DetailsVGrid, "Phone"), DetailsVGrid.FocusedRecord, data("Phone"))
                    .SetCellValue(FindVGridRow(DetailsVGrid, "Email"), DetailsVGrid.FocusedRecord, data("Email"))
                End With

            Case TypeOfRecordToShow.TravelDocuments
                With DetailsVGrid
                    .SetCellValue(FindVGridRow(DetailsVGrid, "PPNo"), DetailsVGrid.FocusedRecord, data("PPNo"))
                    .SetCellValue(FindVGridRow(DetailsVGrid, "PPIssueDate"), DetailsVGrid.FocusedRecord, data("PPIssueDate"))
                    .SetCellValue(FindVGridRow(DetailsVGrid, "PPExpiryDate"), DetailsVGrid.FocusedRecord, data("PPExpiryDate"))
                    .SetCellValue(FindVGridRow(DetailsVGrid, "PPPlaceIssue"), DetailsVGrid.FocusedRecord, data("PPPlaceIssue"))

                    .SetCellValue(FindVGridRow(DetailsVGrid, "SBNo"), DetailsVGrid.FocusedRecord, data("SBNo"))
                    .SetCellValue(FindVGridRow(DetailsVGrid, "SBIssueDate"), DetailsVGrid.FocusedRecord, data("SBIssueDate"))
                    .SetCellValue(FindVGridRow(DetailsVGrid, "SBExpiryDate"), DetailsVGrid.FocusedRecord, data("SBExpiryDate"))
                    .SetCellValue(FindVGridRow(DetailsVGrid, "SBPlaceIssue"), DetailsVGrid.FocusedRecord, data("SBPlaceIssue"))

                    .SetCellValue(FindVGridRow(DetailsVGrid, "Visa"), DetailsVGrid.FocusedRecord, data("Visa"))

                End With
        End Select
    End Sub

#Region "Find VGridRow"

    Private Function FindVGridRowByRowName(vgrid As DevExpress.XtraVerticalGrid.VGridControl, RowName As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim ReturnValue As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
        Dim tempRow As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For i As Integer = 0 To vgrid.Rows.Count - 1
            tempRow = vgrid.Rows(i)
            If tempRow.ChildRows.Count > 0 Then
                tempRow = FindVGridRowByRowNameFromChildRow(vgrid.Rows(i), RowName)
                If Not IsNothing(tempRow) Then
                    If tempRow.Name = RowName Then
                        ReturnValue = tempRow
                        Exit For
                    End If
                End If
            Else
                If tempRow.Name = RowName Then
                    ReturnValue = tempRow
                    Exit For
                End If
            End If

        Next

        Return ReturnValue
    End Function

    Private Function FindVGridRowByRowNameFromChildRow(Row As DevExpress.XtraVerticalGrid.Rows.BaseRow, RowName As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim ReturnValue As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
        Dim tempRow As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For i As Integer = 0 To Row.ChildRows.Count - 1
            tempRow = Row.ChildRows(i)
            If tempRow.ChildRows.Count > 0 Then
                tempRow = FindVGridRowByRowNameFromChildRow(Row.ChildRows(i), RowName)
            End If

            If Not IsNothing(tempRow) Then
                If tempRow.Name = RowName Then
                    ReturnValue = tempRow
                    Exit For
                End If
            End If
        Next

        Return ReturnValue
    End Function

    Private Function FindVGridRow(vgrid As DevExpress.XtraVerticalGrid.VGridControl, FieldName As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim ReturnValue As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
        Dim tempRow As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For i As Integer = 0 To vgrid.Rows.Count - 1
            tempRow = vgrid.Rows(i)
            If tempRow.ChildRows.Count > 0 Then
                tempRow = FindVGridRowFromChildRow(vgrid.Rows(i), FieldName)
                If Not IsNothing(tempRow) Then
                    If tempRow.Properties.FieldName = FieldName Then
                        ReturnValue = tempRow
                        Exit For
                    End If
                End If
            Else
                If tempRow.Properties.FieldName = FieldName Then
                    ReturnValue = tempRow
                    Exit For
                End If
            End If

        Next

        Return ReturnValue
    End Function

    Private Function FindVGridRowFromChildRow(Row As DevExpress.XtraVerticalGrid.Rows.BaseRow, FieldName As String) As DevExpress.XtraVerticalGrid.Rows.BaseRow
        Dim ReturnValue As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
        Dim tempRow As DevExpress.XtraVerticalGrid.Rows.BaseRow
        For i As Integer = 0 To Row.ChildRows.Count - 1
            tempRow = Row.ChildRows(i)
            If tempRow.ChildRows.Count > 0 Then
                tempRow = FindVGridRowFromChildRow(Row.ChildRows(i), FieldName)
            End If

            If Not IsNothing(tempRow) Then
                If tempRow.Properties.FieldName = FieldName Then
                    ReturnValue = tempRow
                    Exit For
                End If
            End If
        Next

        Return ReturnValue
    End Function

#End Region

#Region "Adding Rows"


    Public Structure VGridRow
        Public Name As String
        Public Caption As String
        Public FieldName As String

        Public Sub New(pName As String, pCaption As String, pFieldName As String)
            Name = pName
            Caption = pCaption
            FieldName = pFieldName
        End Sub
    End Structure

    Private Sub AddChildRow(ByRef sender As DevExpress.XtraVerticalGrid.Rows.CategoryRow, RowItem As VGridRow)
        Dim row As DevExpress.XtraVerticalGrid.Rows.EditorRow
        row = New DevExpress.XtraVerticalGrid.Rows.EditorRow
        row.Name = RowItem.Name
        row.Height = 40
        row.Appearance.Options.UseTextOptions = True
        row.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        row.Properties.Caption = RowItem.Caption
        row.Properties.FieldName = RowItem.FieldName
        'row.Properties.ReadOnly = True

        sender.ChildRows.Add(row)
    End Sub

    Private Sub AddChildRows(ByRef sender As DevExpress.XtraVerticalGrid.Rows.CategoryRow, RowItems As List(Of VGridRow))
        For Each item As VGridRow In RowItems
            AddChildRow(sender, item)
        Next
    End Sub

    Private Sub AddRow(ByRef sender As DevExpress.XtraVerticalGrid.VGridControl, RowItem As VGridRow)
        Dim row As New DevExpress.XtraVerticalGrid.Rows.EditorRow
        row.Name = RowItem.Name
        row.Height = 40
        row.Appearance.Options.UseTextOptions = True
        row.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        row.Properties.FieldName = RowItem.FieldName
        row.Properties.Caption = RowItem.Caption
        'row.Properties.ReadOnly = True

        DetailsVGrid.Rows.Add(row)
    End Sub

#End Region
End Class