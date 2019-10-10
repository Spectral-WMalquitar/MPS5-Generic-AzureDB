Public Class PayrollFunctions
    Public Function dateToPeriod(ByVal dDate As Date) As Integer
        Dim nRes As String
        nRes = Year(dDate)
        nRes = nRes & Month(dDate).ToString("00")
        Return Val(nRes)
    End Function


#Region "Transfer Crew List"
    Public Enum PayProcessCrewTransferMethod
        DragAndDrop = 1
        DoubleClick = 2
    End Enum

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'PANSAMATAGALAN LANG, ADJUST IF YOU MUST
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Shared Sub TransferAll(gridFrom As DevExpress.XtraGrid.GridControl, gridTo As DevExpress.XtraGrid.GridControl, dtToTransfer As DataTable, tblCrewList As DataTable, groupData As Boolean, Optional showErrList As Boolean = True, Optional PayProcessCrewTransferMethod As PayProcessCrewTransferMethod = PayProcessCrewTransferMethod.DragAndDrop)
        'Try
        Dim viewFrom As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(gridFrom.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim viewTo As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(gridTo.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim DTCrewWithError As New DataTable

        If IsNothing(dtToTransfer) Then Exit Sub

        DTCrewWithError = dtToTransfer.Clone 'gridFrom.DataSource.Clone

        If Not viewFrom.Name.Equals(viewTo.Name) Then

            dtToTransfer.AcceptChanges()

            For Each dr As DataRow In dtToTransfer.Rows

                If Trim(IfNull(dr("ToolTip"), "")).Equals("") Then
                    Dim nRow As DataRow
                    nRow = gridTo.DataSource.NewRow()

                    For Each dc As DevExpress.XtraGrid.Columns.GridColumn In viewTo.Columns
                        nRow(dc.FieldName) = dr(dc.FieldName)
                    Next
                    gridTo.DataSource.Rows.Add(nRow)
                Else
                    Dim nRowWithError As DataRow
                    nRowWithError = DTCrewWithError.NewRow
                    nRowWithError.ItemArray = TryCast(dr.ItemArray.Clone, Object())
                    DTCrewWithError.Rows.Add(nRowWithError)
                End If

            Next

            dtToTransfer.AcceptChanges()

            For Each dr As DataRow In dtToTransfer.Rows
                If Trim(IfNull(dr("ToolTip"), "")).Equals("") Then
                    For Each dRow As DataRow In tblCrewList.Rows
                        If dRow.Equals(dr) Then
                            dRow.Delete()
                        End If
                    Next
                    viewFrom.DeleteRow(viewFrom.LocateByValue("ActID", dr("ActID")))
                End If
            Next

            dtToTransfer.AcceptChanges()

            If groupData Then
                'Sort Grid
                viewTo.SortInfo.ClearAndAddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(viewTo.Columns("Vessel"), DevExpress.Data.ColumnSortOrder.Ascending), _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(viewTo.Columns("Crew"), DevExpress.Data.ColumnSortOrder.Ascending), _
                   New DevExpress.XtraGrid.Columns.GridColumnSortInfo(viewTo.Columns("RankName"), DevExpress.Data.ColumnSortOrder.Ascending) _
                }, 1)
            End If

            With viewTo
                .BeginSort()
                Try
                    .ClearSorting()
                    .Columns("Crew").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    .Columns("Vessel").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    .Columns("RankName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                Finally
                    .EndSort()
                End Try
            End With

        End If


        Dim cMsg As String = ""
        Select Case PayProcessCrewTransferMethod
            Case PayProcessCrewTransferMethod.DragAndDrop
                cMsg = "Some of the dragged crew(s) contains error(s) and cannot be added to the Payroll list." & vbCrLf & vbCrLf & _
                       "Would you like to view the error details?"

            Case PayProcessCrewTransferMethod.DoubleClick
                cMsg = "The selected crew contains error(s) and cannot be added to the Payroll list." & vbCrLf & vbCrLf & _
                       "Would you like to view the error details?"

        End Select
        If DTCrewWithError.Rows.Count > 0 And showErrList And IfNull(cMsg, "").Equals("").ToString.Length > 0 Then
            If MsgBox(cMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                Dim frmError As New frmPayCrewError(DTCrewWithError)
                frmError.isExpandView = True
                frmError.bbiExpand.EditValue = True
                frmError.MainView.Focus()
                frmError.ShowDialog()
            End If
        End If

        'Catch ex As Exception
        '    MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, GetAppName)
        'End Try

    End Sub

#End Region

End Class
