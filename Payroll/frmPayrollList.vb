Public Class frmPayrollList
    Private WithEvents UCFilter As PayrollFilter
    Private _PayType As String = String.Empty
    Dim sec As New clsSecurity

    Private ALLOW_DELETION As Boolean = False

    Public RefreshCallingForm As Boolean = False

    Public Sub New(PayType As String)

        ' This call is required by the designer.
        InitializeComponent()
        _PayType = PayType

        'Dim strCaption As String = String.Empty
        'Select Case PayType
        '    Case "ONB"
        '        strCaption = "Onboard Payroll"
        '        rpgGovtRcpt.Visible = False
        '    Case "HA"
        '        strCaption = "Home Allotment"
        '        rpgGovtRcpt.Visible = True
        '    Case "MPO"
        '        strCaption = "Speciall Allotment"
        '        rpgGovtRcpt.Visible = False
        'End Select
        'Me.Text = "Processed Payroll List - " & strCaption

        '' Add any initialization after the InitializeComponent() call.

        'UCFilter = New PayrollFilter(_PayType)
        'UCFilter.Dock = Windows.Forms.DockStyle.Fill
        'SplitContainerControl1.Panel1.Controls.Add(UCFilter)
        'SplitContainerControl1.IsSplitterFixed = False
        'SplitContainerControl1.Panel1.Height = UCFilter.Size.Height
        'SplitContainerControl1.IsSplitterFixed = True
        'SplitContainerControl1.SplitterPosition = UCFilter.Height() + 5
        'LoadData()
        ''added by tony20170703
        'InitViewBarItem()
        ''end tony
        'rpgGREditingOptions.Visible = False

        ''tonytest
        'sec.propSQLConnStr = MPSDB.GetConnectionString
        'Select Case PayType
        '    Case "HA"
        '        Try
        '            ALLOW_DELETION = sec.hasNoDeletePermission("PayrollViewHA", USER_ID).Equals(0)
        '        Catch ex As Exception
        '            ALLOW_DELETION = False
        '        End Try

        '    Case "ONB"
        '        Try
        '            ALLOW_DELETION = sec.hasNoDeletePermission("PayrollViewONB", USER_ID).Equals(0)
        '        Catch ex As Exception
        '            ALLOW_DELETION = False
        '        End Try

        '    Case "MPO"
        '        Try
        '            ALLOW_DELETION = sec.hasNoDeletePermission("PayrollViewSA", USER_ID).Equals(0)
        '        Catch ex As Exception
        '            ALLOW_DELETION = False
        '        End Try
        'End Select
        'ShowEditingOptions()
        RefreshData()

    End Sub

    Private Sub RefreshData()
        Dim strCaption As String = String.Empty
        Select Case _PayType
            Case "ONB"
                strCaption = "Onboard Payroll"
                rpgGovtRcpt.Visible = False
            Case "HA"
                strCaption = "Home Allotment"
                rpgGovtRcpt.Visible = True
            Case "MPO"
                strCaption = "Speciall Allotment"
                rpgGovtRcpt.Visible = False
        End Select
        Me.Text = "Processed Payroll List - " & strCaption
        header.Text = strCaption & IIf(strCaption.Length > 0, " ", "") & "Payroll List"

        ' Add any initialization after the InitializeComponent() call.

        UCFilter = New PayrollFilter(_PayType)
        UCFilter.Dock = Windows.Forms.DockStyle.Fill
        SplitContainerControl1.Panel1.Controls.Add(UCFilter)
        UCFilter.LayoutControl1.AllowCustomization = False
        SplitContainerControl1.IsSplitterFixed = False
        SplitContainerControl1.Panel1.Height = UCFilter.Size.Height
        SplitContainerControl1.IsSplitterFixed = True
        SplitContainerControl1.SplitterPosition = UCFilter.Height() + 5
        LoadData()
        'added by tony20170703
        InitViewBarItem()
        'end tony
        rpgGREditingOptions.Visible = False

        'tonytest
        sec.propSQLConnStr = MPSDB.GetConnectionString
        Select Case _PayType
            Case "HA"
                Try
                    ALLOW_DELETION = sec.hasNoDeletePermission("PayrollViewHA", USER_ID).Equals(0)
                Catch ex As Exception
                    ALLOW_DELETION = False
                End Try

            Case "ONB"
                Try
                    ALLOW_DELETION = sec.hasNoDeletePermission("PayrollViewONB", USER_ID).Equals(0)
                Catch ex As Exception
                    ALLOW_DELETION = False
                End Try

            Case "MPO"
                Try
                    ALLOW_DELETION = sec.hasNoDeletePermission("PayrollViewSA", USER_ID).Equals(0)
                Catch ex As Exception
                    ALLOW_DELETION = False
                End Try
        End Select
        ShowEditingOptions()
        SetMultipleSelection(MultipleSelectionType.None)
        btnSelectMultiple.Down = False
    End Sub

    Private Sub InitViewBarItem()
        Dim dt As New DataTable
        Dim col As DataColumn
        col = New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Name"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        dt.Rows.Add(New Object() {"ALL", "All"})
        dt.Rows.Add(New Object() {"LOCKED", "Locked Only"})
        dt.Rows.Add(New Object() {"UNLOCKED", "Unlocked Only"})

        repView.DataSource = dt
        repView.DropDownRows = dt.Rows.Count
        cboView.EditValue = "ALL"
    End Sub

    Private Sub LoadData()


        Dim tblList As New DataView(MPSDB.CreateTable(UCFilter.getStrPayListQuery()))
        Dim crewFilter As String = IIf(Trim(GetUserFilterString(, "", "FKeyPrincipal", "")).Length > 0, "  " & GetUserFilterString(, "", "FKeyPrincipal", ""), "")

        tblList.RowFilter = crewFilter
        If tblList.Count > 0 Then
            MainGrid.DataSource = tblList.ToTable
        Else
            MainGrid.DataSource = tblList.ToTable.Clone
        End If
    End Sub

    Private Sub ChangedPeriod(ByVal sender As Object, ByVal e As EventArgs) Handles UCFilter.cboPeriodChanged
        'tonytest MainView.ActiveFilter.NonColumnFilter = GridFilterString()
        MainView.ActiveFilterString = GridFilterString()
    End Sub

    Private Sub ChangePrincipal(ByVal sender As Object, ByVal e As EventArgs) Handles UCFilter.cboPrinCode
        'MainView.ActiveFilter.NonColumnFilter = GridFilterString()
        MainView.ActiveFilterString = GridFilterString()
    End Sub

    Private Sub ChangedVsl(ByVal sender As Object, ByVal e As EventArgs) Handles UCFilter.cboVslChanged
        'MainView.ActiveFilter.NonColumnFilter = GridFilterString()
        MainView.ActiveFilterString = GridFilterString()
    End Sub

    Private Sub ChangeRefNum(ByVal sender As Object, ByVal e As EventArgs) Handles UCFilter.cboRefNumChanged
        'MainView.ActiveFilter.NonColumnFilter = GridFilterString()
        MainView.ActiveFilterString = GridFilterString()
    End Sub

    Private Function GridFilterString() As String
        Dim retVal As String = String.Empty
        Dim strPeriod As String = IIf(UCFilter.PayPeriod <= 0, String.Empty, UCFilter.PayPeriod),
            strPrincipal As String = UCFilter.PayPrincipal,
            strVslCode As String = UCFilter.strGetSelectedVsl,
            strRefNo As String = UCFilter.strGetSelectRefNo

        If Trim(strPeriod).Length > 0 Then
            strPeriod = " MCode = " & UCFilter.PayPeriod
        Else
            strPeriod = String.Empty
        End If
        If Trim(strPrincipal).Length > 0 Then
            strPrincipal = " FKeyPrincipal = '" & UCFilter.PayPrincipal & "' "
        Else
            strPrincipal = String.Empty
        End If
        If Trim(strVslCode).Length > 0 Then
            strVslCode = UCFilter.strGetSelectedVsl
        End If
        If Trim(strRefNo).Length > 0 Then
            strRefNo = UCFilter.strGetSelectRefNo
        End If

        If Trim(strPeriod).Length > 0 Then
            retVal = strPeriod & _
                IIf(Trim(strPrincipal).Length > 0, " AND " & strPrincipal, String.Empty) & _
                IIf(Trim(strVslCode).Length > 0, " AND " & strVslCode, String.Empty) & _
                IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
        Else
            If Trim(strPrincipal).Length > 0 Then
                retVal = IIf(Trim(strPrincipal).Length > 0, strPrincipal, String.Empty) & _
                       IIf(Trim(strVslCode).Length > 0, " AND " & strVslCode, String.Empty) & _
                       IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
            Else
                If Trim(strVslCode).Length > 0 Then
                    retVal = IIf(Trim(strVslCode).Length > 0, strVslCode, String.Empty) & _
                        IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
                Else
                    If Trim(strRefNo).Length > 0 Then
                        retVal = IIf(Trim(strRefNo).Length > 0, strRefNo, String.Empty)
                    Else
                        retVal = String.Empty
                    End If
                End If
            End If
        End If

        If CURRENT_MULTI_LOCKUNLOCK_MODE = MultipleSelectionType.Lock Then
            retVal = retVal & IIf(IfNull(retVal, "").Length > 0, " AND ", "") & _
                     "isLocked = false"
        ElseIf CURRENT_MULTI_LOCKUNLOCK_MODE = MultipleSelectionType.Unlock Then
            retVal = retVal & IIf(IfNull(retVal, "").Length > 0, " AND ", "") & _
                     "isLocked = true"
        End If
        Return retVal
    End Function

    Private Sub MainView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles MainView.CustomDrawRowIndicator
        If MainView.GetRowCellValue(e.RowHandle, "isLocked") And e.RowHandle >= 0 Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)
            e.Graphics.DrawImage(My.Resources.Lock_16x16, New System.Drawing.RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))
            e.Handled = True
        End If

    End Sub

    Private Sub MainView_DoubleClick(sender As Object, e As System.EventArgs) Handles MainView.DoubleClick
        If CURRENT_MULTI_LOCKUNLOCK_MODE = MultipleSelectionType.None Then
            GetSelectedDetails()
            Me.Close()
        End If
    End Sub

    Private Sub GetSelectedDetails()
        With MainView
            'UCFilter.PayPeriod = .GetFocusedRowCellValue("MCode")
            'UCFilter.PayPrincipal = .GetFocusedRowCellValue("FKeyPrincipal")
            'UCFilter.PayVessels = .GetFocusedRowCellValue("FKeyVsl")
            'UCFilter.PayPayIDCodes = .GetFocusedRowCellValue("PKey")
            'UCFilter.ReferenceNumbers = .GetFocusedRowCellValue("RefNo")
            ApplyFilter = True
            PayPeriod = .GetFocusedRowCellValue("MCode")
            PayPrincipal = .GetFocusedRowCellValue("FKeyPrincipal")
            PayVessel = .GetFocusedRowCellValue("FKeyVsl")
            PayPayID = .GetFocusedRowCellValue("PKey")
            PayRefNo = .GetFocusedRowCellValue("RefNo")
            'UCFilter.ReferenceNumbers = .GetFocusedRowCellValue("RefNo")

        End With
    End Sub

    Private Sub cmdApply_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdApply.ItemClick
        GetSelectedDetails()
        Me.Close()
    End Sub

    Private Sub cmdClearFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClearFilter.ItemClick
        UCFilter.ClearFilterControls() 'Clear Filter Controls
        cboView.EditValue = "ALL"
    End Sub


#Region "Property"

    Private _PayID As String
    Public Property PayPayID() As String
        Get
            Return _PayID
        End Get
        Set(ByVal value As String)
            _PayID = value
        End Set
    End Property

    Private _Period As Object
    Public Property PayPeriod() As Object
        Get
            Return _Period
        End Get
        Set(ByVal value As Object)
            _Period = value
        End Set
    End Property

    Private _PayPrincipal As String
    Public Property PayPrincipal() As String
        Get
            Return _PayPrincipal
        End Get
        Set(ByVal value As String)
            _PayPrincipal = value
        End Set
    End Property

    Private _PayVessel As String
    Public Property PayVessel() As String
        Get
            Return _PayVessel
        End Get
        Set(ByVal value As String)
            _PayVessel = value
        End Set
    End Property

    Private _RefNo As String
    Public Property PayRefNo() As String
        Get
            Return _RefNo
        End Get
        Set(ByVal value As String)
            _RefNo = value
        End Set
    End Property


    Private _ApplyFilter As Boolean = False
    Public Property ApplyFilter() As Boolean
        Get
            Return _ApplyFilter
        End Get
        Set(ByVal value As Boolean)
            _ApplyFilter = value
        End Set
    End Property

#End Region

#Region "Gov Receiepts"
    Private WithEvents UC_GovtReceipts As GovtReceipts

    Private Sub GovtRcpt_DownChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GovtRcpt.DownChanged
        Dim btn As DevExpress.XtraBars.BarButtonItem = TryCast(sender, DevExpress.XtraBars.BarButtonItem)
        If BRECORDUPDATEDs Then
            UC_GovtReceipts.CheckValidateFields()
        End If
        LoadGovtReceipts(btn.Down)

    End Sub

    Private Sub GovtRcptMulti_DownChanged(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GovtRcptMulti.DownChanged
        If GovtRcptMulti.Down Then
            SetMultipleSelection(MultipleSelectionType.Rcpt)
        Else
            SetMultipleSelection(MultipleSelectionType.None)
        End If
        rpgGREditingOptions.Visible = Not GovtRcptMulti.Down
        rpgPayLock.Visible = Not GovtRcptMulti.Down
        rpgPayFilter.Visible = Not GovtRcptMulti.Down
    End Sub

    Private Sub LoadGovtReceipts(value As Boolean)

        If value Then
            UCFilter.SendToBack()
            UC_GovtReceipts = New GovtReceipts
            UC_GovtReceipts.Dock = Windows.Forms.DockStyle.Fill
            SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
            SplitContainerControl1.Panel2.Controls.Add(UC_GovtReceipts)
            LoadGovtReceiptsDetails()
            UC_GovtReceipts.RefreshData() ' Refresh Data
            UC_GovtReceipts.BringToFront()
            rpgGREditingOptions.Visible = True
            rpgPayFilter.Visible = False
            rpgPayLock.Visible = False
            CURRENT_FORM_MODE = FormMode.GovReceipts

            GovtRcptMulti.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

            If GovtRcptMulti.Down Then
                UC_GovtReceipts.LayoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Dim rowHandles As Integer() = MainView.GetSelectedRows
                Dim pkeys As New ArrayList
                For Each rowHandle In rowHandles
                    pkeys.Add(MainView.GetRowCellValue(rowHandle, "PKey"))
                Next
                UC_GovtReceipts.FKeyPayIDs = pkeys.ToArray(GetType(String))
            Else
                UC_GovtReceipts.LayoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If
        Else
            SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
            rpgGREditingOptions.Visible = False
            rpgPayFilter.Visible = True
            rpgPayLock.Visible = True
            With UC_GovtReceipts
                .SendToBack()
                .Dispose()
            End With
            With UCFilter
                .BringToFront()
            End With
            CURRENT_FORM_MODE = FormMode.PayrollList

            GovtRcptMulti.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            GovtRcptMulti.Down = False
        End If

        ShowEditingOptions()

    End Sub

    Private Sub LoadGovtReceiptsDetails()
        With MainView
            UC_GovtReceipts.DB = MPSDB
            If GovtRcptMulti.Down Then
                UC_GovtReceipts.Principal = ""
                UC_GovtReceipts.Vessel = ""
                UC_GovtReceipts.Period = ""
                UC_GovtReceipts.RefNo = ""
                UC_GovtReceipts.FKeyPayID = ""
            Else
                UC_GovtReceipts.Principal = .GetFocusedRowCellValue("AdmPrinName")
                UC_GovtReceipts.Vessel = .GetFocusedRowCellValue("VslName")
                UC_GovtReceipts.Period = .GetFocusedRowCellValue("Period")
                UC_GovtReceipts.RefNo = .GetFocusedRowCellValue("RefNo")
                UC_GovtReceipts.FKeyPayID = .GetFocusedRowCellValue("PKey")
            End If
        End With


    End Sub

    Private Sub cmdEdit_DownChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdEdit.DownChanged
        'If BRECORDUPDATEDs Then
        '    UC_GovtReceipts.CheckValidateFields()
        'End If
        UC_GovtReceipts.isEditdable = cmdEdit.Down
        UC_GovtReceipts.EditData()
    End Sub

    Private Sub EditBtnDown(sender As String, value As Boolean) Handles UC_GovtReceipts.EditDown
        cmdEdit.Down = value
    End Sub

    Private Sub EditButtonCaption(sender As String, value As String) Handles UC_GovtReceipts.CustomEditCaption
        cmdEdit.Caption = value
    End Sub

    Private Sub cndSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
        UC_GovtReceipts.SaveData()
    End Sub

    Private Sub cmdDelete_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDelete.ItemClick
        If CURRENT_FORM_MODE = FormMode.GovReceipts Then
            UC_GovtReceipts.DeleteData()
        ElseIf CURRENT_FORM_MODE = FormMode.PayrollList Then
            DeletePayroll()
        End If
    End Sub

    Private Sub DeletePayroll()


        If IfNull(MainView.GetFocusedRowCellValue("PKey"), "").Length > 0 Then

            Dim payrolldesc As String = ""
            Select Case _PayType
                Case "HA"
                    payrolldesc = "Home Allotment"

                Case "ONB"
                    payrolldesc = "Onboard"

                Case "MPO"
                    payrolldesc = "Special Allotment"
            End Select

            Dim strDescrip As String '= "Are you sure you want to delete the " & cboPeriod.Text & " Payroll with Reference of : " & cboRefNo.Text & "?"
            strDescrip = "Are you sure you want to delete the following Payroll?" & vbCrLf & DeletePayrollDesc()

            If MsgBox(strDescrip, MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                Try
                    Dim selectedrefno As String = MainView.GetFocusedRowCellValue("RefNo")

                    'audit code transfer inside function GetSelectedRefNo
                    Dim clsAudit As New clsAudit
                    clsAudit.propSQLConnStr = MPSDB.GetConnectionString

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "View / Edit Payroll " & payrolldesc, 0, System.Environment.MachineName, "Period : " & MainView.GetFocusedRowCellValue("Period") & " \ Ref no. : " & MainView.GetFocusedRowCellValue("RefNo") & " \ Vessel : " & MainView.GetFocusedRowCellValue("VslName"), "View / Edit Payroll " & payrolldesc)
                    clsAudit.saveAuditPreDelDetails("tblPay", IfNull(MainView.GetFocusedRowCellValue("PKey"), ""), LastUpdatedBy) 'neil

                    'info = DB.RunSql("DELETE dbo.tblPay " & GetSelectedRefNo())
                    info = False
                    If _PayType = "HA" Or _PayType = "ONB" Then
                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            "Payroll", _
                            "Crewing", _
                            "tblPay", _
                            "PKey IN ('" & ChangeToSQLString(IfNull(MainView.GetFocusedRowCellValue("PKey"), "")) & "')", _
                            "<< Delete Payroll Data - " & IIf(_PayType = "HA", "Home Allotment ", IIf(_PayType = "ONB", "Onboard ", "")) & "Payroll >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & IIf(_PayType = "HA", "Home Allotment ", IIf(_PayType = "ONB", "Onboard ", "")) & "Payroll>", _
                            GetUserName())
                        '-->
                        info = MPSDB.RunSql("DELETE dbo.tblPay WHERE PKey = " & ChangeToSQLString(IfNull(MainView.GetFocusedRowCellValue("PKey"), "")))
                    ElseIf _PayType = "MPO" Then
                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            "Payroll", _
                            "Crewing", _
                            "tblmpo", _
                            "PKey IN ('" & ChangeToSQLString(IfNull(MainView.GetFocusedRowCellValue("PKey"), "")) & "')", _
                            "<< Delete Payroll Data - Special Allotment >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <Payroll - Special Allotment>", _
                            GetUserName())
                        '-->
                        info = MPSDB.RunSql("DELETE dbo.tblmpo WHERE PKey = " & ChangeToSQLString(IfNull(MainView.GetFocusedRowCellValue("PKey"), "")))
                    End If

                    If info Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                        bLoaded = False
                        RefreshCallingForm = True
                        RefreshData()
                    Else
                        MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                    End If
                Catch ex As Exception
                    MsgBox("Delete payroll failed. Please contact your system administrator for assistance.", MsgBoxStyle.Critical)
                End Try

            End If
        Else
            MsgBox("Failed to retrieve payroll to delete. Please contact your system administrator for assistance.", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Function DeletePayrollDesc() As String
        Dim str As New System.Text.StringBuilder

        Dim payrolldesc As String = ""
        Select Case _PayType
            Case "HA"
                payrolldesc = "Home Allotment"

            Case "ONB"
                payrolldesc = "Onboard"

            Case "MPO"
                payrolldesc = "Special Allotment"
        End Select

        str.AppendLine(vbTab & "Type: " & payrolldesc)
        str.AppendLine(vbTab & "Period: " & MainView.GetFocusedRowCellValue("Period"))
        str.AppendLine(vbTab & "RefNo: " & MainView.GetFocusedRowCellValue("RefNo"))
        str.AppendLine(vbTab & "Vessel: " & MainView.GetFocusedRowCellValue("VslName"))

        Return str.ToString
    End Function
#End Region

#Region "Payroll Lock"


    Private Sub MainView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles MainView.FocusedRowObjectChanged
        Dim vi As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If vi.RowCount > 0 Then
            cmdLockUnlockPayroll.Enabled = True
            If vi.GetRowCellValue(e.FocusedRowHandle, "isLocked") Then
                cmdLockUnlockPayroll.Glyph = My.Resources.Unlock300x300
                cmdLockUnlockPayroll.Caption = "Unlock Payroll"
            Else
                cmdLockUnlockPayroll.Glyph = My.Resources.Lock300x300
                cmdLockUnlockPayroll.Caption = "Lock Payroll"
            End If
        Else
            cmdLockUnlockPayroll.Glyph = My.Resources.Lock300x300
            cmdLockUnlockPayroll.Caption = "Lock / Unlock Payroll"
            cmdLockUnlockPayroll.Enabled = False
        End If

        EnableDeletion()
    End Sub

    Private Sub cmdLockUnlockPayroll_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdLockUnlockPayroll.ItemClick
        If CURRENT_MULTI_LOCKUNLOCK_MODE = MultipleSelectionType.None Then
            Dim focusedKey As String
            If MainView.RowCount > 0 Then
                focusedKey = MainView.GetFocusedRowCellValue("PKey")
                Dim frmPayLock As New fdlgPayrollLock(MPSDB, MainView.GetFocusedRow, _PayType)
                frmPayLock.ShowDialog(Me)
                LoadData()
                Dim rowhandle As Integer = MainView.LocateByValue("PKey", focusedKey)
                If rowhandle > 0 Then MainView.FocusedRowHandle = rowhandle
            End If

        ElseIf CURRENT_MULTI_LOCKUNLOCK_MODE = MultipleSelectionType.Lock Or CURRENT_MULTI_LOCKUNLOCK_MODE = MultipleSelectionType.Unlock Then
            If MainView.SelectedRowsCount = 0 Then
                MsgBox("There are no payrolls selected.", MsgBoxStyle.Information)

            Else
                Dim PayList As New List(Of fdlgPayrollLock_Multiple.PayrollRecord)
                Dim rec As fdlgPayrollLock_Multiple.PayrollRecord
                Dim focusedkey As String
                focusedkey = MainView.GetFocusedRowCellValue("PKey")
                For Each rh As Integer In MainView.GetSelectedRows
                    rec = New fdlgPayrollLock_Multiple.PayrollRecord
                    rec.PKey = MainView.GetRowCellValue(rh, "PKey")
                    rec.MCode = MainView.GetRowCellValue(rh, "MCode")
                    rec.PrincipalName = MainView.GetRowCellValue(rh, "PrinName")
                    rec.VesselName = MainView.GetRowCellValue(rh, "Vessel")
                    rec.RefNo = MainView.GetRowCellValue(rh, "RefNo")
                    'payPKeyList.Add(MainView.GetRowCellValue(rowhandle, "PKey"))
                    PayList.Add(rec)
                Next

                Dim frmPayrollLock As New fdlgPayrollLock_Multiple(MPSDB, PayList, _PayType, CURRENT_MULTI_LOCKUNLOCK_MODE)
                frmPayrollLock.ShowDialog()
                LoadData()
                Dim rowhandle As Integer = MainView.LocateByValue("PKey", focusedKey)
                If rowhandle > 0 Then MainView.FocusedRowHandle = rowhandle
                SetMultipleSelection(MultipleSelectionType.None)
            End If


        End If

    End Sub


#End Region

    Private Sub cboView_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboView.EditValueChanged
        Dim lockFilter As String = IIf(cboView.EditValue = "ALL", "", IIf(cboView.EditValue = "LOCKED", "isLocked = true", IIf(cboView.EditValue = "UNLOCKED", "isLocked = false", "")))
        MainView.ActiveFilterString = lockFilter
    End Sub

    Private Sub cboView_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cboView.ItemClick
        Dim lockFilter As String = IIf(cboView.EditValue = "ALL", "", IIf(cboView.EditValue = "LOCKED", "isLocked = true", IIf(cboView.EditValue = "UNLOCKED", "isLocked = false", "")))
        MainView.ActiveFilterString = lockFilter
    End Sub

    'Private Sub RefreshListView(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs)
    '    Dim lockFilter As String = IIf(cboView.EditValue = "ALL", "", IIf(cboView.EditValue = "LOCKED", "isLocked <> 0", IIf(cboView.EditValue = "UNLOCKED", "isLocked = 0", "")))
    '    MainView.ActiveFilterString = lockFilter
    '    'crewFilter = IIf(IfNull(crewFilter, "").Length > 0 And IfNull(lockFilter, "").Length > 0, " AND ", "") & lockFilter
    'End Sub

    '/* ADDED BY TONY20180716 */
    Private CURRENT_FORM_MODE As FormMode = FormMode.PayrollList

    Private Enum FormMode
        PayrollList = 1
        GovReceipts = 2
    End Enum

    Private Sub ShowEditingOptions()
        Select Case CURRENT_FORM_MODE
            Case FormMode.GovReceipts
                rpgGREditingOptions.Visible = True
                cmdEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                cmdDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            Case FormMode.PayrollList
                cmdEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                If ALLOW_DELETION Then
                    cmdDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Else
                    cmdDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                End If
                rpgGREditingOptions.Visible = ALLOW_DELETION
        End Select

        EnableDeletion()
    End Sub

    Private Sub EnableDeletion()
        Select Case CURRENT_FORM_MODE
            Case FormMode.PayrollList
                Dim vi As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(MainView, DevExpress.XtraGrid.Views.Grid.GridView)
                Try
                    If vi.RowCount > 0 Then
                        cmdDelete.Enabled = Not vi.GetRowCellValue(vi.FocusedRowHandle, "isLocked")
                    Else
                        cmdDelete.Enabled = False
                    End If
                Catch ex As Exception
                    cmdDelete.Enabled = False
                End Try

            Case FormMode.GovReceipts
                Try
                    cmdDelete.Enabled = UC_GovtReceipts.MainView.RowCount > 0
                Catch ex As Exception
                    cmdDelete.Enabled = False
                End Try

        End Select


    End Sub
    '/* END TONY */

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.FocusedRowHandle = e.RowHandle Then
            MainView.Appearance.FocusedRow.BackColor = SEL_COLOR
        End If
    End Sub

    Private CURRENT_MULTI_LOCKUNLOCK_MODE As MultipleSelectionType
    Public Enum MultipleSelectionType
        None = 0
        Lock = 1
        Unlock = 2
        Rcpt = 3
    End Enum

    Private Sub SetMultipleSelection(mode As MultipleSelectionType)
        CURRENT_MULTI_LOCKUNLOCK_MODE = mode
        Select Case mode
            Case MultipleSelectionType.Lock, MultipleSelectionType.Unlock
                With MainView.OptionsSelection
                    .MultiSelect = True
                    .MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
                    .ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True
                    .ShowCheckBoxSelectorInGroupRow = DefaultBoolean.True
                End With

                Dim cFilter As String
                If mode = MultipleSelectionType.Lock Then
                    cFilter = "isLocked = false"
                ElseIf mode = MultipleSelectionType.Unlock Then
                    cFilter = "isLocked = true"
                Else
                    cFilter = ""
                End If

                'cFilter = cFilter & IIf(IfNull(cFilter, "").Length > 0 And IfNull(GridFilterString(), "").Length > 0, " AND ", "") & _
                '    GridFilterString()

                MainView.ActiveFilterString = GridFilterString()
            Case MultipleSelectionType.Rcpt
                With MainView.OptionsSelection
                    .MultiSelect = True
                    .MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
                    .ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True
                    .ShowCheckBoxSelectorInGroupRow = DefaultBoolean.True
                End With

            Case Else
                With MainView.OptionsSelection
                    .MultiSelect = False
                    .MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
                    .ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True
                    .ShowCheckBoxSelectorInGroupRow = DefaultBoolean.True
                End With
                btnSelectMultiple.Down = False
                MainView.ActiveFilterString = GridFilterString()
        End Select

        cmdApply.Enabled = (mode = MultipleSelectionType.None)
        cmdCancelLockUnlockMultiple.Enabled = (mode = MultipleSelectionType.Lock Or mode = MultipleSelectionType.Unlock)
        cmdDelete.Enabled = (mode = MultipleSelectionType.None)
    End Sub

    Private Sub btnLockMultiple_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnLockMultiple.ItemClick
        SetMultipleSelection(MultipleSelectionType.Lock)
    End Sub

    Private Sub btnUnlockMultiple_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUnlockMultiple.ItemClick
        SetMultipleSelection(MultipleSelectionType.Unlock)
    End Sub

    Private Sub cmdCancelLockUnlockMultiple_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancelLockUnlockMultiple.ItemClick
        SetMultipleSelection(MultipleSelectionType.None)
    End Sub

End Class