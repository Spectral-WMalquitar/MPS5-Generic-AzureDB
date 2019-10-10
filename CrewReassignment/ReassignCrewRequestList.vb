Public Class ReassignCrewRequestList

    Public Overrides Sub RefreshData()
        Dim cSQL As String = "SELECT     t.*, u.name as RequestedByName " & _
                            "FROM       [dbo].[tblCrewReassign] t LEFT JOIN " & _
                            "           [dbo].[MSysSec_Users] u ON t.requestedby = u.id " & _
                            "WHERE      HideFromList = 0 " & _
                            "           AND t.RequestedBy = " & USER_ID & " " & _
                            "           AND t.HideFromList = 0 " & _
                            "ORDER BY   DateRequested Desc"
        Dim dt As New DataTable
        dt = DB.CreateTable(cSQL)
        '"WHERE t.PKey IN (SELECT FKeyReassignID FROM [dbo].[tblCrewReassignCrews] WHERE isConfirmed = 0) " & _
        '"AND t.RequestedBy = " & USER_ID & " ORDER BY DateRequested Desc")
        Maingrid.DataSource = dt
    End Sub

    Public Overrides Function GetID() As String
        If Mainview.RowCount > 0 Then
            Return Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "PKey")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetDesc() As String
        If MainView.RowCount > 0 Then
            Return Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "Description")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, _columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try
    End Function

    Private Sub Mainview_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles Mainview.BeforeLeaveRow
        Dim AllowN As Boolean
        If BRECORDUPDATEDs Then
            If Not bRecordDeleted Then
                AllowN = bContent.CheckValidateFields()
                If AllowN Then
                    e.Allow = True
                Else
                    If ALLOWNEXTS Then
                        e.Allow = True
                    Else
                        e.Allow = False
                    End If
                End If
            Else
                e.Allow = True
            End If
        Else
            e.Allow = True
        End If
    End Sub

    Private Sub MainView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mainview.Click
        bAddMode = False
        SelectionChange(Name)
        Mainview.RefreshRow(Mainview.FocusedRowHandle)
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Mainview.FocusedRowChanged
        If Mainview.FocusedRowHandle >= 0 Then
            SelectionChange(Name)
        End If
    End Sub

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = Mainview.Columns("PKey")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
            MainView.TopRowIndex = RowHandle
        Catch ex As Exception
        End Try
    End Sub
End Class
