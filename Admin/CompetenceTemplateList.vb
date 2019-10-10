Public Class CompetenceTemplateList
    Public Overrides Sub SaveLayout()
        MPS4.SaveLayout(DB, Me.MainView, USER_ID, BaseControl, Name)
    End Sub

    Public Overrides Sub SetListLayout(ByVal objectid As String)
        GetLayout(DB, Me.MainView, USER_ID, objectid, Name)
    End Sub

    Public Overrides Sub initList(userid As Integer, objectid As String)
        GetLayout(DB, Me.MainView, userid, objectid, Name)
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
        CheckUserSession(DB, USER_SESSION)

        If MainView.RowCount > 0 Then
            nRow = MainView.FocusedRowHandle
        End If

        SetGridLayout(Me.MainView)

        bListSelect = "SELECT PKey, Name as 'Name', CheckListName as 'CheckListName'," & _
                      "CareerPlanName as 'CareerPlanName', SortCode " & _
                      "FROM dbo.tblAdmComp " & strFilter & " ORDER BY Name ASC,SortCode ASC"
        'put data
        Me.MainGrid.DataSource = DB.CreateTable(bListSelect)


        If MainView.RowCount > 0 Then
            MainView.FocusedRowHandle = nRow
            MainView.SelectRow(nRow)
        End If
        bDisableSelectionEvent = False

        '<!-- tony20171222
        If Not bLoaded Then
            InitGridBandForRecordCount(GridBand1)
            bLoaded = True
        End If
        ShowRecordCountOnGridBand(MainView, GridBand1)
        '-->

        'PopulateTempTableForCrewRanks()
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
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "Name")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetFocusedRowData(ByVal columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, columnname)
        Catch ex As Exception
            LogErrors("--Error Generated in GetFocusedRowData() method in CompetenceTemplateList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetFocusedRowData() method in CompetenceTemplateList.vb - End--")

            Return System.DBNull.Value
        End Try

    End Function

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim i As Integer = 0
            Dim column As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("PKey")
            i = MainView.LocateByValue(0, column, id)
            MainView.FocusedRowHandle = i
        Catch ex As Exception
            LogErrors("--Error Generated in SetSelection() method in CompetenceTemplateList.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetSelection() method in CompetenceTemplateList.vb - End--")

            MessageBox.Show(ex.Message)
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

    Public Overrides Sub SetFilter(ByVal criteria As String)
        'MainView.ActiveFilterString = _criteria
        'strFilter = _criteria
        strFilter = IIf(criteria <> "" And Not IsNothing(criteria), " WHERE " & criteria, "")
    End Sub

    Public Overrides Sub ClearFilter()
        bDisableSelectionEvent = True
        MainView.ClearColumnsFilter()
        MainView.RefreshData()
        bDisableSelectionEvent = False
        strFilter = ""
    End Sub
    Private Sub MainGrid_Click(sender As System.Object, e As System.EventArgs) Handles MainGrid.Click

    End Sub


    Private Sub PopulateTempTableForCrewRanks()

        Dim listOfCrews As New ArrayList
        Dim crews As DataTable = DB.CreateTable("SELECT PKey FROM dbo.tblCrewInfo")
        For Each crewRow In crews.Rows
            listOfCrews.Add(crewRow("PKey"))
        Next


        Dim listOfRandomRanks As New ArrayList(listOfCrews.Count)
        Dim ranks As DataTable = DB.CreateTable("SELECT PKey FROM dbo.tblAdmRank")

        For Each rankRow In ranks.Rows
            listOfRandomRanks.Add(rankRow("PKey"))
        Next

        For k = 0 To listOfCrews.Count - 1
            DB.RunSql("INSERT INTO temp_tblCrewInfo_Ranks (FKeyCrewInfo, FKeyRank) VALUES ('" & listOfCrews(k).ToString() & "','" & listOfRandomRanks(k).ToString() & "')")
        Next
    End Sub
End Class
