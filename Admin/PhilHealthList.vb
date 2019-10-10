Public Class PhilHealthList
    Public Overrides Sub SaveLayout()
        MPS4.SaveLayout(DB, Me.MainView, USER_ID, BaseControl, Name)
    End Sub

    Public Overrides Sub SetListLayout(ByVal _ObjectID As String)
        GetLayout(DB, Me.MainView, USER_ID, _ObjectID, Name)
    End Sub

    Public Overrides Sub initList(_USERID As Integer, _ObjectID As String)
        GetLayout(DB, Me.MainView, _USERID, _ObjectID, Name)
    End Sub

    Public Overrides Sub HideSelection()
        bAddMode = True
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles MainView.BeforeLeaveRow
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

    Private Sub MainView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainView.Click
        bAddMode = False
        SelectionChange(Name)
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.FocusedRowHandle >= 0 Then
            SelectionChange(Name)
        End If
    End Sub

    Private Sub MainView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) And e.Button = Windows.Forms.MouseButtons.Right Then
            CellRightClick(Name)
        End If
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Public Overrides Sub RefreshData()
        Dim nRow As Integer = -1
        If MainView.RowCount > 0 Then
            nRow = MainView.FocusedRowHandle
        End If

        SetGridLayout(Me.MainView)
        'put data
        bListSelect = "SELECT * FROM dbo.frmPhilHealth " & strFilter & " ORDER BY Salary ASC,SalaryTo ASC"
        Me.MainGrid.DataSource = DB.CreateTable(bListSelect)

        If MainView.RowCount > 0 Then
            MainView.FocusedRowHandle = nRow
            MainView.SelectRow(nRow)
        End If
        bDisableSelectionEvent = False
    End Sub

    Public Overrides Function GetID() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetDesc() As String
        If MainView.RowCount > 0 Then
            Return "Last Updated by: " & MainView.GetRowCellValue(MainView.FocusedRowHandle, "LastUpdatedBy") & " on " & CDate(MainView.GetRowCellValue(MainView.FocusedRowHandle, "DateUpdated")).ToString("yyyy-MMM-dd HH:mm:ss")
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

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("PKey")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MainView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyData = Windows.Forms.Keys.Down Then
            MainView.MoveNext()
            e.Handled = True
        ElseIf e.KeyData = Windows.Forms.Keys.Up Then
            MainView.MovePrev()
            e.Handled = True
        End If
    End Sub

    Public Overrides Sub SetFilter(ByVal _criteria As String)
        'MainView.ActiveFilterString = _criteria
        'strFilter = _criteria
        strFilter = IIf(_criteria <> "" And Not IsNothing(_criteria), " WHERE " & _criteria, "")
    End Sub

    Public Overrides Sub ClearFilter()
        bDisableSelectionEvent = True
        MainView.ClearColumnsFilter()
        MainView.RefreshData()
        bDisableSelectionEvent = False
        strFilter = ""
    End Sub

End Class
