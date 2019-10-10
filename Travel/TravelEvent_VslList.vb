Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class TravelEvent_VslList

    Public Overrides Sub RefreshData()
        Dim dt As New DataTable
        Dim cFilterString As String = GetUserVslFilterString(, "PKey")
        dt = DB.CreateTable("SELECT PKey, Name FROM tblAdmVsl WHERE VslStat = 1 " & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " ORDER BY Name")
        Maingrid.DataSource = dt
    End Sub

    Private Sub MainView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles Mainview.BeforeLeaveRow
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not bDraggable Then
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
        End If
    End Sub

    Public Overrides Function GetID() As String
        If Mainview.RowCount > 0 Then
            Return Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "PKey")
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
            RowHandle = Mainview.LocateByValue(0, Col, id)
            RowHandle = IIf(RowHandle < 0, 0, RowHandle)
            MainView.FocusedRowHandle = RowHandle
            MainView.TopRowIndex = RowHandle
        Catch ex As Exception
        End Try
    End Sub
End Class
