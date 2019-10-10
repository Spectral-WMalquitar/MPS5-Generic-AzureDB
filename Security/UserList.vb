Public Class UserList
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

    Private Sub MainView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) And e.Button = Windows.Forms.MouseButtons.Right Then
            CellRightClick(Name)
        End If
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.RowHandle = MainView.FocusedRowHandle And Not bAddMode Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Public Overrides Sub RefreshData()
        Dim nRow As Integer = -1
        If MainView.RowCount > 0 Then
            nRow = MainView.FocusedRowHandle
        End If
        'put data
        'Me.MainGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.tblSec_Users ORDER BY Name ASC")
        Dim list As New DataTable
        With list
            .Columns.Add("ID", System.Type.GetType("System.Int64"))
            .Columns.Add("Name", System.Type.GetType("System.String"))
            .Columns.Add("Password", System.Type.GetType("System.String"))
            .Columns.Add("GroupID", System.Type.GetType("System.Int64"))
            .Columns.Add("GroupName", System.Type.GetType("System.String"))
            '.Columns.Add("vLastCheck", System.Type.GetType("System.DateTime"))
            '.Columns.Add("vCompName", System.Type.GetType("System.String"))
            '.Columns.Add("vPKey", System.Type.GetType("System.String"))

            '<!-- added by tony20171124
            .Columns.Add("FullName", System.Type.GetType("System.String"))
            .Columns.Add("Description", System.Type.GetType("System.String"))
            .Columns.Add("EmployeeID", System.Type.GetType("System.String"))
            .Columns.Add("ContactInfo", System.Type.GetType("System.String"))
            '-->

        End With
        Try
            With DB
                .BeginReader("SELECT * FROM dbo.frmLogIn where Name <> 'Administrator' ORDER BY Name")

                If DB.RecordCount > 0 Then
                    AllowFLog(Name, True)
                Else
                    AllowFLog(Name, False)
                End If
                While .Read

                    If .ReaderItem("Check") = AES_Decrypt(.ReaderItem("SecUser"), .ReaderItem("Check")) Then
                        Dim row As DataRow = list.NewRow
                        row("ID") = .ReaderItem("ID") 'UserID
                        row("Name") = .ReaderItem("Name") 'UserName
                        row("Password") = .ReaderItem("Password") 'Password
                        row("GroupID") = .ReaderItem("GroupID")
                        row("GroupName") = .ReaderItem("GroupName")

                        '<!-- added by tony20171124
                        row("FullName") = .ReaderItem("FullName")
                        row("Description") = .ReaderItem("Description")
                        row("EmployeeID") = .ReaderItem("EmployeeID")
                        row("ContactInfo") = .ReaderItem("ContactInfo")
                        '-->

                        'row("vLastCheck") = .ReaderItem("vLastCheck")
                        'row("vCompName") = .ReaderItem("vCompName")
                        'row("vPKey") = .ReaderItem("vPKey")

                        list.Rows.Add(row)
                    End If
                End While

                .CloseReader()
            End With
        Catch ex As Exception
            DB.CloseReader()
            'MsgBox(ex.Message)
        End Try
        Me.MainGrid.DataSource = list

        If MainView.RowCount > 0 Then
            MainView.FocusedRowHandle = nRow
            MainView.SelectRow(nRow)
        End If
        bDisableSelectionEvent = False
    End Sub

    Public Overrides Function GetID() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "ID")
        Else
            Return ""
        End If
    End Function

    'Public Overrides Function GetDesc() As String
    '    'If MainView.RowCount > 0 Then
    '    '    Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "Name")
    '    'Else
    '    '    Return ""
    '    'End If
    'End Function

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, _columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try

    End Function

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            Dim intID As Long
            intID = id
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("ID")
            RowHandle = MainView.LocateByValue(0, Col, intID)
            MainView.FocusedRowHandle = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MainView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown

        If e.KeyData = Windows.Forms.Keys.Down Or e.KeyData = Windows.Forms.Keys.Up Then
            If e.KeyData = Windows.Forms.Keys.Down Then
                MainView.MoveNext()
                e.Handled = True
            ElseIf e.KeyData = Windows.Forms.Keys.Up Then
                MainView.MovePrev()
                e.Handled = True
            End If
            bAddMode = False
            SelectionChange(Name)
            MainView.RefreshRow(MainView.FocusedRowHandle)
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

    Public Overrides Function GetDesc() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "Name")
        Else
            Return ""
        End If
    End Function

End Class
