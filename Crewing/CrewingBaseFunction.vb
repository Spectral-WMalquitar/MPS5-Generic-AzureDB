Module CrewingBaseFunction

    'Set the DateExpiry Column of the table with validity
    Public Sub SetDateExpiry(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Try
            Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            With _view
                Select Case .FocusedColumn.FieldName
                    Case "FKeyDocument"
                        Dim Cntry As String = IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCntry"), "NULL")
                        Dim DocCode As String = e.Value
                        'Dim DateIssue As Date = IfNull(.GetRowCellValue(.FocusedRowHandle, "DateIssue"), "")
                        If Not Cntry.Equals("NULL") And Not .GetRowCellValue(.FocusedRowHandle, "DateIssue").Equals(System.DBNull.Value) Then
                            Dim DateIssue As Date = .GetRowCellValue(.FocusedRowHandle, "DateIssue")
                            .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetDateExpiry(DocCode, DateIssue, Cntry))
                        End If
                    Case "DateIssue"
                        Dim DateIssue As Date = e.Value
                        If Not DateIssue.Equals(System.DBNull.Value) And Not .GetRowCellValue(.FocusedRowHandle, "FKeyDocument").Equals(System.DBNull.Value) Then
                            Dim Cntry As String = IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCntry"), "NULL")
                            Dim DocCode As String = .GetRowCellValue(.FocusedRowHandle, "FKeyDocument")
                            .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetDateExpiry(DocCode, DateIssue, Cntry))
                        End If
                    Case "FKeyCntry"
                        Dim Cntry As String = e.Value
                        If Not .GetRowCellValue(.FocusedRowHandle, "FKeyDocument").Equals(System.DBNull.Value) And Not .GetRowCellValue(.FocusedRowHandle, "DateIssue").Equals(System.DBNull.Value) Then
                            Dim DocCode As String = .GetRowCellValue(.FocusedRowHandle, "FKeyDocument")
                            Dim DateIssue As Date = .GetRowCellValue(.FocusedRowHandle, "DateIssue")
                            .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetDateExpiry(DocCode, DateIssue, Cntry))
                        End If

                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
End Module
