Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class GovtReceipts
#Region "Property"

    Private _Period As String = ""
    Public Property Period() As String
        Get
            Return _Period
        End Get
        Set(ByVal value As String)
            _Period = value
        End Set
    End Property

    Private _RefNo As String = ""
    Public Property RefNo() As String
        Get
            Return _RefNo
        End Get
        Set(ByVal value As String)
            _RefNo = value
        End Set
    End Property

    Private _Vessel As String = ""
    Public Property Vessel() As String
        Get
            Return _Vessel
        End Get
        Set(ByVal value As String)
            _Vessel = value
        End Set
    End Property

    Private _Principal As String = ""
    Public Property Principal() As String
        Get
            Return _Principal
        End Get
        Set(ByVal value As String)
            _Principal = value
        End Set
    End Property

    Private _FKeyPayID As String = ""
    Public Property FKeyPayID() As String
        Get
            Return _FKeyPayID
        End Get
        Set(ByVal value As String)
            _FKeyPayID = value
        End Set
    End Property

    Private _FKeyPayIDs As String() = Nothing
    Public Property FKeyPayIDs() As String()
        Get
            Return _FKeyPayIDs
        End Get
        Set(ByVal value As String())
            _FKeyPayIDs = value
        End Set
    End Property

#End Region

    'Dim LastUpdatedBy As String = "LastUpdatedBy"
    Dim FormName As String = "Payroll: Government Receipts"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Private Sub InitControl()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        repGovtReceipt.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmGovtReceipt ORDER BY Name, SortCode")
    End Sub

    Private Sub LoadSub()
        MainGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.view_Pay_GovtReceipt WHERE FKeyPayID = '" & FKeyPayID & "'")
    End Sub

    Public Overrides Sub RefreshData()
        LayoutControl1.AllowCustomization = False
        SetEditCaption(Name, "Add/Edit")
        txtRefNo.Text = RefNo
        txtPeriod.Text = Period
        txtPrincipal.Text = Principal
        txtVessel.Text = Vessel
        InitControl()
        LoadSub()
        MakeReadOnlyListener(LayoutControlGroup3)
        EditSubAllowGrid(MainView, False)
        EditCheck(Name, False)
        BRECORDUPDATEDs = False

    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        EditSubAllowGrid(MainView, isEditdable, True)
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        GroupControl1.Focus()
        If BRECORDUPDATEDs Then
            Dim info As Boolean = False
            If Not IsNothing(FKeyPayIDs) Then
                info = SaveGovReceiptsMulti()
            Else
                info = SaveGovReceipts()
            End If
            If info Then
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                RefreshData()
            Else
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Exclamation, GetAppName)
            End If
        End If
    End Sub

    Private Function SaveGovReceipts() As Boolean
        Dim retVal As Boolean = False
        'MainView.CancelUpdateCurrentRow()
        MainView.UpdateCurrentRow()
        If Not MainView.HasColumnErrors Then
            Dim tobeInserted As Boolean = False
            Dim sqlConn As New SqlClient.SqlConnection(MPSDB.GetConnectionString)
            Dim sqlTran As SqlClient.SqlTransaction = Nothing
            Dim dv As DataView = MainView.DataSource
            Dim query As String = ""

            Try
                sqlConn.Open()
                sqlTran = sqlConn.BeginTransaction
                dv.RowFilter = "Edited = True" 'Filter For the dataview
                For Each dr As DataRowView In dv
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = sqlConn
                        cmd.Transaction = sqlTran
                        If dr("PKey").Equals(System.DBNull.Value) Then
                            query = "INSERT INTO dbo.tblPay_GovtReceipt" & _
                                       "(FKeyPayID," & _
                                       "FKeyGovtReceipt," & _
                                       "ReceiptNumber," & _
                                       "DatePaid," & _
                                       "Amt," & _
                                       "CollectingBank," & _
                                       "LastUpdatedBy," & _
                                       "DateUpdated)" & _
                                       "VALUES(" & _
                                        "@FKeyPayID," & _
                                        "@FKeyGovtReceipt," & _
                                        "@ReceiptNumber," & _
                                        "@DatePaid," & _
                                        "@Amt," & _
                                        "@CollectingBank," & _
                                        "@LastUpdatedBy," & _
                                        "getDate())"
                            With cmd.Parameters
                                .AddWithValue("@FKeyPayID", FKeyPayID)
                                .AddWithValue("@FKeyGovtReceipt", dr("FKeyGovtReceipt").ToString)
                                .AddWithValue("@ReceiptNumber", dr("ReceiptNumber"))
                                .AddWithValue("@DatePaid", dr("DatePaid"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CollectingBank", dr("CollectingBank"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                        Else
                            query = "UPDATE dbo.tblPay_GovtReceipt SET " & _
                                        " FKeyGovtReceipt = @FKeyGovtReceipt, " & _
                                        " ReceiptNumber = @ReceiptNumber, " & _
                                        " DatePaid = @DatePaid, " & _
                                        " Amt = @Amt, " & _
                                        " CollectingBank = @CollectingBank, " & _
                                        " LastUpdatedBy = @LastUpdatedBy, " & _
                                        " DateUpdated = getDate() " & _
                                        " WHERE PKey = @PKey"
                            With cmd.Parameters
                                .AddWithValue("@PKey", dr("PKey"))
                                .AddWithValue("@FKeyGovtReceipt", dr("FKeyGovtReceipt"))
                                .AddWithValue("@ReceiptNumber", dr("ReceiptNumber"))
                                .AddWithValue("@DatePaid", dr("DatePaid"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CollectingBank", dr("CollectingBank"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                        End If
                        cmd.CommandText = query
                        tobeInserted = (cmd.ExecuteNonQuery > 0)
                    End Using
                    If tobeInserted Then
                        sqlTran.Commit()
                        BRECORDUPDATEDs = False
                        retVal = True
                    End If
                Next

            Catch ex As Exception
                sqlTran.Rollback()
                BRECORDUPDATEDs = True
                retVal = False
            End Try
        End If
        Return retVal
    End Function

    Private Function SaveGovReceiptsMulti() As Boolean
        Dim retVal As Boolean = False
        MainView.UpdateCurrentRow()
        If Not MainView.HasColumnErrors Then
            Dim tobeInserted As Boolean = False
            Dim sqlConn As New SqlClient.SqlConnection(MPSDB.GetConnectionString)
            Dim sqlTran As SqlClient.SqlTransaction = Nothing
            Dim dv As DataView = MainView.DataSource
            Dim query As String = ""

            Try
                sqlConn.Open()
                sqlTran = sqlConn.BeginTransaction
                dv.RowFilter = "Edited = True" 'Filter For the dataview

                For Each id As String In FKeyPayIDs
                    For Each dr As DataRowView In dv

                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tblPay_GovtReceipt", _
                            "FKeyPayID='" & id & "' AND FKeyGovtReceipt='" & dr("FKeyGovtReceipt").ToString & "'", _
                            "<< Delete Payroll Data - " & FormName & " >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & ">", _
                            LastUpdatedBy)
                        '-->
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            query = "DELETE FROM dbo.tblPay_GovtReceipt WHERE FKeyPayID='" & id & "' AND FKeyGovtReceipt='" & dr("FKeyGovtReceipt").ToString & "'"
                            cmd.CommandText = query
                            tobeInserted = (cmd.ExecuteNonQuery > 0)
                        End Using
                        If tobeInserted Then
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If

                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran

                            query = "INSERT INTO dbo.tblPay_GovtReceipt" & _
                                       "(FKeyPayID," & _
                                       "FKeyGovtReceipt," & _
                                       "ReceiptNumber," & _
                                       "DatePaid," & _
                                       "Amt," & _
                                       "CollectingBank," & _
                                       "LastUpdatedBy," & _
                                       "DateUpdated)" & _
                                       "VALUES(" & _
                                        "@FKeyPayID," & _
                                        "@FKeyGovtReceipt," & _
                                        "@ReceiptNumber," & _
                                        "@DatePaid," & _
                                        "@Amt," & _
                                        "@CollectingBank," & _
                                        "@LastUpdatedBy," & _
                                        "getDate())"
                            With cmd.Parameters
                                .AddWithValue("@FKeyPayID", id)
                                .AddWithValue("@FKeyGovtReceipt", dr("FKeyGovtReceipt").ToString)
                                .AddWithValue("@ReceiptNumber", dr("ReceiptNumber"))
                                .AddWithValue("@DatePaid", dr("DatePaid"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CollectingBank", dr("CollectingBank"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            cmd.CommandText = query
                            tobeInserted = (cmd.ExecuteNonQuery > 0)
                        End Using

                    Next
                Next

                If tobeInserted Then
                    sqlTran.Commit()
                    BRECORDUPDATEDs = False
                    retVal = True
                End If


            Catch ex As Exception
                sqlTran.Rollback()
                BRECORDUPDATEDs = True
                retVal = False
            End Try
        End If
        Return retVal
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        'Return MyBase.CheckValidateFields(showMsg)
        GroupControl1.Focus()
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If MainView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else

                flag = True
                ALLOWNEXTS = flag
                SaveData() '
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = False
        If MsgBox("Are you sure want to delete '" & MainView.GetFocusedRowCellDisplayText("FKeyGovtReceipt") & " - " & MainView.GetFocusedRowCellDisplayText("ReceiptNumber") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed("dbo.tblPay_GovtReceipt", MainView.GetFocusedRowCellValue("PKey")) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Government Receipts", 10, System.Environment.MachineName, "Payroll Government Receipts", FormName)
                clsAudit.saveAuditPreDelDetails(Me.TableName, MainView.GetFocusedRowCellValue("PKey"), LastUpdatedBy) 'neil
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()

                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tblPay_GovtReceipt", _
                    "PKey IN ('" & MainView.GetFocusedRowCellValue("PKey") & "')", _
                    "<< Delete Payroll Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM dbo.tblPay_GovtReceipt WHERE PKey='" & MainView.GetFocusedRowCellValue("PKey") & "' ")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    RefreshData()
                    BRECORDUPDATEDs = False
                Else
                    MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Exclamation, GetAppName)
                    BRECORDUPDATEDs = False
                End If
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If
        End If
    End Sub

    Public Sub ValidateRequiredFields(ByRef sender As Object, ByRef e As ValidateRowEventArgs, colName As String, errMessage As String)
        Dim view As GridView = TryCast(sender, GridView)
        Dim column As DevExpress.XtraGrid.Columns.GridColumn = view.Columns(colName)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If view.GetRowCellValue(e.RowHandle, column) Is DBNull.Value Or view.GetRowCellValue(e.RowHandle, column) Is Nothing Then
                e.Valid = False
                view.SetColumnError(column, errMessage)
                view.FocusedColumn = view.VisibleColumns(0)
            Else
                e.Valid = True
            End If
        End If
    End Sub

#Region "Govt Receipts"
    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.MainView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub MainView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyPayID"), FKeyPayID)
        View.SetRowCellValue(e.RowHandle, View.Columns("ReceiptNumber"), "")
        View.SetRowCellValue(e.RowHandle, View.Columns("Amt"), "0")
        View.SetRowCellValue(e.RowHandle, View.Columns("CollectingBank"), "")
    End Sub

    Private Sub MainView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MainView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MainView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            MainView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        'ViewRowCellStyle(sender, e, "FKeyCntry;Validity;")
    End Sub

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MainView.RowUpdated
        'BRECORDUPDATEDs = True
    End Sub


    'Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
    '    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '    Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")
    '    Dim Validity As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Validity")

    '    With view
    '        AllowSaving(Name, False)
    '        'Validate Country
    '        If .GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
    '            .SetColumnError(Cntry, "Please select Country.")
    '            AllowSaving(Name, False)
    '            e.Valid = False
    '        Else
    '            .SetColumnError(Cntry, "")
    '        End If

    '        ''Validate
    '        'If .GetRowCellValue(e.RowHandle, Validity) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Validity) Is Nothing Then
    '        '    .SetColumnError(Validity, "Please Enter Validity.")
    '        '    AllowSaving(Name, False)
    '        '    e.Valid = False
    '        'Else
    '        '    If IsNothing(.GetRowCellValue(e.RowHandle, Validity)) Then
    '        '        .SetColumnError(Validity, "Please Enter Validity.")
    '        '        AllowSaving(Name, False)
    '        '        e.Valid = False
    '        '    Else
    '        '        .SetColumnError(Validity, "")
    '        '    End If
    '        'End If

    '        'clear errors
    '        If Not .HasColumnErrors Then
    '            e.Valid = True
    '            .ClearColumnErrors()
    '            AllowSaving(Name, True)
    '        End If
    '    End With
    'End Sub

#End Region

    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyGovtReceipt", "Please select type of receipt.")
        ValidateRequiredFields(sender, e, "DatePaid", "Please provide date.")
    End Sub
End Class
