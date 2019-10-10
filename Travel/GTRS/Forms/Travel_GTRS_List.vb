Imports DevExpress.XtraEditors.Repository

Public Class Travel_GTRS_List

    Private RecordFilter As String
    Dim clsAudit As New clsAudit 'neil

    Private Const RECORD_FILTER_DEFAULT_VALUE As String = "SHOWALL"

    Private Enum BookingType
        All = 1
        RegularBooking = 2
        BookedWithGTravel = 3
    End Enum

    Private Enum CompletedBooking
        All = 1
        CompletedOnly = 2
        NotCompletedOnly = 3
    End Enum

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
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender
        Dim p As System.Drawing.Point = view.GridControl.PointToClient(Control.MousePosition)
        Dim hi As ViewInfo.GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
        If hi.HitTest = ViewInfo.GridHitTest.Row OrElse hi.HitTest = ViewInfo.GridHitTest.RowCell Then
            bAddMode = False
            SelectionChange(Name)
            MainView.RefreshRow(MainView.FocusedRowHandle)
        End If
    End Sub

    Private Sub MainView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As System.Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) And e.Button = Windows.Forms.MouseButtons.Right Then
            CellRightClick(Name)
        End If
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        'ViewRowCellStyle(sender, e)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.RowHandle = view.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
            e.Appearance.ForeColor = GRID_SELFONTCOLOR

        Else

            If view.GetRowCellValue(e.RowHandle, "isUnread") Then
                e.Appearance.BackColor = System.Drawing.Color.Yellow
                e.Appearance.ForeColor = GRID_SELFONTCOLOR
            End If

        End If

        If e.Column.FieldName = "BookingStatusLabel" Then

            With view


                If view.GetRowCellValue(e.RowHandle, "BookingStatus") = TravelBookingStatus.Booked.Key Then
                    e.Appearance.BackColor = System.Drawing.Color.ForestGreen
                    e.Appearance.ForeColor = System.Drawing.Color.White

                ElseIf view.GetRowCellValue(e.RowHandle, "BookingStatus") = TravelBookingStatus.Canceled.Key Then
                    e.Appearance.BackColor = System.Drawing.Color.Firebrick
                    e.Appearance.ForeColor = System.Drawing.Color.White
                End If




            End With

        End If

    End Sub

    Public Overrides Sub RefreshData()
        Dim nRow As Integer = -1
        If MainView.RowCount > 0 Then
            nRow = MainView.FocusedRowHandle
        End If

        If Not bLoaded Then
            clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
            'SET IDENTIFIER ICONS
            checkEditBooked.PictureChecked = My.Resources.Booked
            checkEditCompleted.PictureChecked = My.Resources.Travel_Completed
            checkEditBookedWithGTravel.PictureChecked = My.Resources.BookedWithGTravel

            InitListFilter()
            bLoaded = True
        End If

        SetGridLayout(Me.MainView)
        bListSelect = "SELECT tb.*, format(getdate(), 'dd-MMM-yyyy') as TravelDateLabel, Cast(CASE WHEN BookingStatus = '" & TravelBookingStatus.Booked.Key & "' THEN 1 ELSE 0 END as bit) as isBooked, dbo.isvalidguid(tb.TravelRequestID) BookedWithGTravel, bs.Name BookingStatusLabel FROM dbo.tblTravelBooking tb LEFT JOIN dbo.tbladmBookingStatus bs ON tb.BookingStatus = bs.pkey ORDER BY TravelDate Desc, VslName ASC"
        'tonytest Me.MainGrid.DataSource = ""
        Me.MainGrid.DataSource = DB.CreateTable(bListSelect)
        MainGrid.ForceInitialize()
        ApplyRecordFilter()

        If MainView.RowCount > 0 Then
            MainView.FocusedRowHandle = nRow
            MainView.SelectRow(nRow)

            MainView.ClearSorting()
            MainView.Columns("TravelDate").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            MainView.Columns("VslName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        End If
        bDisableSelectionEvent = False

    End Sub

    Private Sub InitListFilter()
        Dim dt As New DataTable
        Dim col As New DataColumn


        'FILTER RECORDS
        'col.ColumnName = "PKey"
        'col.DataType = System.Type.GetType("System.Int32")
        'dt.Columns.Add(col)
        'col = New DataColumn
        'col.ColumnName = "Name"
        'col.DataType = System.Type.GetType("System.String")
        'dt.Columns.Add(col)

        'dt.Rows.Add(New Object() {RecordFilterValue.ShowAll, "Show All"})
        'dt.Rows.Add(New Object() {RecordFilterValue.ShowPendingRequestsOnly, "Show Pending Requests Only"})
        'dt.Rows.Add(New Object() {RecordFilterValue.ShowBookedAndCompleted, "Show Booked and Completed"})
        'dt.Rows.Add(New Object() {RecordFilterValue.ShowBookedAndNotCompleted, "Show Booked and NOT Completed"})

        dt = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmbookingstatus ORDER BY Name")
        Dim newrow As DataRow = dt.NewRow
        newrow("PKey") = "SHOWALL"
        newrow("Name") = "Show All"
        dt.Rows.InsertAt(newrow, 0)

        Dim _filter As Object = GetUserSetting(UserSettingCode.Travel.RecordFilter)
        If IfNull(_filter, "").Equals("") Or Not IsNumeric(_filter) Then
            RecordFilter = RECORD_FILTER_DEFAULT_VALUE  ' RecordFilterValue.ShowAll
        Else
            RecordFilter = IfNull(_filter, 1)
        End If

        cboRecordFilter.Properties.DataSource = dt
        cboRecordFilter.EditValue = RecordFilter
        cboRecordFilter.Properties.DropDownRows = dt.Rows.Count

        'BOOKING TYPE
        dt = New DataTable
        col = New DataColumn

        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.Int32")
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "Name"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        dt.Rows.Add(New Object() {BookingType.All, "All Types"})
        dt.Rows.Add(New Object() {BookingType.RegularBooking, "Regular Booking Only"})
        dt.Rows.Add(New Object() {BookingType.BookedWithGTravel, "Booked with GTravel Only"})

        cboBookingType.Properties.DataSource = dt
        cboBookingType.EditValue = GetUserSetting(UserSettingCode.Travel.ShowBookingType, 1)

        'TRAVEL COMPLETED
        dt = New DataTable
        col = New DataColumn

        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.Int32")
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "Name"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        dt.Rows.Add(New Object() {CompletedBooking.All, "Show All"})
        dt.Rows.Add(New Object() {CompletedBooking.CompletedOnly, "Show All Completed Booking Only"})
        dt.Rows.Add(New Object() {CompletedBooking.NotCompletedOnly, "Show All Booking That Are Not Yet Completed"})

        cboCompleted.Properties.DataSource = dt
        cboCompleted.EditValue = GetUserSetting(UserSettingCode.Travel.ShowCompletedTravel, 1)
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
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "VslName") & " / " & Format(MainView.GetRowCellValue(MainView.FocusedRowHandle, "TravelDate"), "dd-MMM-yyyy")
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
        MainView.ActiveFilterString = _criteria
        strFilter = _criteria
    End Sub

    Public Overrides Sub ClearFilter()
        bDisableSelectionEvent = True
        MainView.ClearColumnsFilter()
        MainView.RefreshData()
        bDisableSelectionEvent = False
        strFilter = ""
    End Sub


    Private Sub StatusToolTip_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles StatusToolTip.GetActiveObjectInfo

        If e.SelectedControl Is MainGrid Then
            Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = MainView.CalcHitInfo(e.ControlMousePosition)
            If info.InRowCell AndAlso (info.Column.Name = "isBooked" Or info.Column.Name = "isCompleted" Or info.Column.Name = "BookedWithGTravel") Then
                Dim row As DataRow = MainView.GetDataRow(info.RowHandle)

                Dim text As String = ""
                If info.Column.Name = "isBooked" Then
                    If row("isBooked") Then text = "Booked"
                ElseIf info.Column.Name = "isCompleted" Then
                    If row("isCompleted") Then text = "Completed"
                ElseIf info.Column.Name = "BookedWithGTravel" Then
                    If row("BookedWithGTravel") Then text = "Booked with GTravel"
                End If

                If text <> "" Then

                    Dim cellKey As String = String.Format("{0} - {1}", info.RowHandle, info.Column)
                    e.Info = New DevExpress.Utils.ToolTipControlInfo(cellKey, text)
                End If

            ElseIf info.InColumnPanel Then
                Dim text As String = ""
                Select Case info.Column.Name
                    Case "isBooked"
                        text = "Identifies if booking is tagged as 'Booked'"
                    Case "isCompleted"
                        text = "Identifies if booking is tagged as 'Completed'"
                    Case "BookedWithGTravel"
                        text = "Identifies if travel information is booked by GTravel"
                End Select

                If text <> "" Then
                    Dim cellKey As String = String.Format("{0} - {1}", info.RowHandle, info.Column)
                    e.Info = New DevExpress.Utils.ToolTipControlInfo(cellKey, text)
                End If
            End If
        End If



    End Sub

    Private Sub cboRecordFilter_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRecordFilter.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            cboRecordFilter.ClosePopup()
            cboRecordFilter.EditValue = RECORD_FILTER_DEFAULT_VALUE
        End If
    End Sub

    Private Sub cboRecordFilter_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboRecordFilter.EditValueChanged
        RecordFilter = cboRecordFilter.EditValue
        SaveUserSetting(UserSettingCode.Travel.RecordFilter, cboRecordFilter.EditValue)
        ApplyRecordFilter()
    End Sub

    Private Sub ApplyRecordFilter()
        Dim FilterString As String = ""
        'Select Case cboRecordFilter.EditValue
        '    Case RecordFilterValue.ShowAll
        '        FilterString = ""

        '    Case RecordFilterValue.ShowPendingRequestsOnly
        '        FilterString = "isBooked = false"

        '    Case RecordFilterValue.ShowBookedAndCompleted
        '        FilterString = "isBooked = true AND isCompleted = true"

        '    Case RecordFilterValue.ShowBookedAndNotCompleted
        '        FilterString = "isBooked = true AND isCompleted = false"

        '    Case Else
        '        FilterString = ""
        'End Select

        If cboRecordFilter.EditValue.Equals(RECORD_FILTER_DEFAULT_VALUE) Then
            FilterString = ""
        Else
            FilterString = "BookingStatus = '" & cboRecordFilter.EditValue & "'"
        End If

        Select Case cboBookingType.EditValue
            Case BookingType.All

            Case BookingType.BookedWithGTravel
                FilterString = FilterString & IIf(IfNull(FilterString, "").Length > 0, " AND ", "") & "BookedWithGTravel = true"

            Case BookingType.RegularBooking
                FilterString = FilterString & IIf(IfNull(FilterString, "").Length > 0, " AND ", "") & "BookedWithGTravel = false"

        End Select

        Select Case cboCompleted.EditValue
            Case CompletedBooking.All

            Case CompletedBooking.CompletedOnly
                FilterString = FilterString & IIf(IfNull(FilterString, "").Length > 0, " AND ", "") & "isCompleted = true"

            Case CompletedBooking.NotCompletedOnly
                FilterString = FilterString & IIf(IfNull(FilterString, "").Length > 0, " AND ", "") & "isCompleted = false"

        End Select

        MainView.ActiveFilterString = FilterString
    End Sub

    Private Sub MainView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles MainView.FocusedRowObjectChanged
        'edited by tony20180508
        'problem is that if filtered with non-record at all, the maincontent does not refresh
        'If MainView.FocusedRowHandle >= 0 Then
        '    SelectionChange(Name)
        'End If
        SelectionChange(Name)
        UpdateUnreadData(MainView.FocusedRowHandle)
    End Sub

    Private Sub cboBookingType_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboBookingType.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            cboBookingType.ClosePopup()
            cboBookingType.EditValue = CInt(BookingType.All)
        End If
    End Sub

    Private Sub cboBookingType_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboBookingType.EditValueChanged
        SaveUserSetting(UserSettingCode.Travel.ShowBookingType, cboBookingType.EditValue)
        ApplyRecordFilter()
    End Sub

    Private Sub MainView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles MainView.CustomDrawRowIndicator
        If IfNull(MainView.GetRowCellValue(e.RowHandle, "BookingStatusLabel"), "").Equals(TravelBookingStatus.NewRequest.Value) Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)
            e.Graphics.DrawImage(My.Resources.New_Request, New System.Drawing.RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))
            e.Handled = True
        End If
    End Sub

    Private Sub UpdateUnreadData(Rowhandle As Integer)
        If MainView.GetRowCellValue(Rowhandle, "isUnread") Then
            Dim LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "Read Responded Travel Request", 10, System.Environment.MachineName, "Travel Date:" & Format(MainView.GetRowCellValue(Rowhandle, "TravelDate"), "dd-MMM-yyyy"), "Travel Booking") 'neil
            MPSDB.RunSql("UPDATE dbo.tbltravelbooking SET isUnread = 0, DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & GetID() & "'")
            MainView.SetRowCellValue(Rowhandle, "isUnread", False)
        End If
    End Sub

    Private Sub cboCompleted_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboCompleted.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            cboCompleted.ClosePopup()
            cboCompleted.EditValue = CInt(BookingType.All)
        End If
    End Sub

    Private Sub cboCompleted_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboCompleted.EditValueChanged
        SaveUserSetting(UserSettingCode.Travel.ShowCompletedTravel, cboCompleted.EditValue)
        ApplyRecordFilter()
    End Sub
End Class

