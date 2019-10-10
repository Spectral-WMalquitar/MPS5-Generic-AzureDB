Imports System.Drawing
Imports System.Windows.Forms

Public Class PayrollProcessSA

    Dim LastUpdatedBy As String = "LastUP"
    Private tblPrin As New DataTable
    Private tblAgent As New DataTable
    Private tblVsl As New DataTable
    Private CrewID As String = ""

    Dim CrewDT As DataTable
    Dim tblAllotName As DataTable
    Dim tblCurr As New DataTable
    Dim tblWageONB As New DataTable
    Dim tblWageASH As New DataTable
    Dim TKey As Long = 0

    Dim tblBranch As New DataTable, tblBank As New DataTable
    Dim DataViewAllotName As DataView, DataViewBranch As DataView

    Dim tblMPO As DataTable, tblMPO_allot As DataTable, tblMPO_wages As DataTable
    Dim isRecordSaved As Boolean = False

    Dim clsgridflout As New clsGridFlyOut

    Private Sub ClearForm()
        cboPeriod.EditValue = Nothing
        txtDateCreated.Text = Date.Now
        txtRef.Text = Nothing
        CrewGrid.DataSource = Nothing
        cboPrincipal.EditValue = Nothing
        cboAgent.EditValue = Nothing
        cboVessel.EditValue = Nothing
        AllotmentGrid.DataSource = Nothing
        EarnGrid.DataSource = Nothing
        DedGrid.DataSource = Nothing

        CrewDT = New DataTable
        tblAllotName = New DataTable
        tblMPO = New DataTable
        tblMPO_allot = New DataTable
        tblMPO_wages = New DataTable
        TKey = 0
        tblBranch = New DataTable
        tblBank = New DataTable
        DataViewAllotName = New DataView
        DataViewBranch = New DataView

    End Sub

    Private Sub initControls()
        LayoutControl4.AllowCustomization = False
        ClearForm()
        InitTables()
        tblCurr = DB.CreateTable("SELECT * FROM dbo.tblAdmCurr ORDER BY Name")
        repAllotFKeyCurr.DataSource = tblCurr
        repCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name")
        repERFKeyCurr.DataSource = tblCurr
        'Filter
        '========================================================
        Dim prinFilter As String = IIf(GetUserFilterString(, , "PKey").Length > 0, " WHERE " & GetUserFilterString(, , "PKey"), "")
        tblPrin = DB.CreateTable("SELECT * FROM dbo.PrincipalList " & prinFilter & " ORDER BY Name")
        tblVsl = DB.CreateTable("SELECT * FROM dbo.VslList ORDER BY Name")
        tblAgent = DB.CreateTable("SELECT * FROM dbo.ManAgentList ORDER BY Name")
        cboPrincipal.Properties.DataSource = tblPrin
        cboAgent.Properties.DataSource = tblAgent
        cboVessel.Properties.DataSource = tblVsl
        cboPeriod.Properties.DataSource = GetPayPeriods("MONTH", 36, 3)
        '========================================================

        'Wages
        'tblWageONB = DB.CreateTable("SELECT * FROM dbo.tblAdmWageOnb ORDER BY Name, SortCode")
        tblWageASH = DB.CreateTable("SELECT * FROM dbo.tblAdmWageAsh ORDER BY Name, SortCode")
        '========================================================
        'Earning
        'repEarnWage.DataSource = tblWageONB.Select("WageType=1").CopyToDataTable
        repEarnWage.DataSource = tblWageASH.Select("WageType=1").CopyToDataTable
        repEarnFKeyCurr.DataSource = tblCurr

        'Deduction
        'repDEDWage.DataSource = tblWageONB.Select("WageType=2").CopyToDataTable
        repDEDWage.DataSource = tblWageASH.Select("WageType=2").CopyToDataTable
        repDedCurr.DataSource = tblCurr
        '========================================================

        InitAllotView() 'init ALlottee View
        InitExRateTable() 'Init ExRate Table

        SetProcessedPayrollListVisibility(Name, True)

    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        GroupControl.Focus()



        SetCalculatePayCaption(Name, "Calculate Pay")
        SetPayrollListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        TKey = 0
        'strRequiredFields = "cboPeriod;txtRef;txtDateCreated"
        initControls()
        txtDateCreated.Text = Date.Now.ToString("dd-MMM-yyyy")
        RequiredControls = {cboPeriod, txtRef, txtDateCreated}
        AddEditListener(LayoutControlGroup5)
        BRECORDUPDATEDs = False
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetCalculatePayVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        AllowCalculatePay(Name, True)
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0)
            Case "RunPayroll"
                RunPayroll()
            Case "CLEARFILTER"
                ClearForm()

        End Select

    End Sub

    Private Function SaveSpecialAllot() As Boolean
        ShowCustomLoadScreen(GetType(PayrollWaitForm))
        Dim retval As Boolean = False

        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTrans As SqlClient.SqlTransaction = Nothing
        Dim EarnDV As DataView = EarnView.DataSource
        Dim DedDV As DataView = DedView.DataSource
        Dim valid As Boolean = False
        Dim strMPOID As String = ""
        Try
            sqlConn.Open()
            sqlTrans = sqlConn.BeginTransaction
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTrans
                cmd.CommandText = "INSERT INTO dbo.tblmpo(MCode,RefNo,DateCreated,DateUpdated,LastUpdatedBy) VALUES(@MCode,@RefNo,@DateCreated,GETDATE(),@LastUpdatedBy)"
                With cmd.Parameters
                    .AddWithValue("@MCode", cboPeriod.EditValue)
                    .AddWithValue("@RefNo", txtRef.Text)
                    .AddWithValue("@DateCreated", txtDateCreated.Text)
                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                End With
                valid = cmd.ExecuteNonQuery().Equals(1)
            End Using
            'get MPO ID
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandText = "SELECT [PKey] FROM mps.dbo.tblmpo WHERE ID=IDENT_CURRENT('tblmpo')"
                cmd.Transaction = sqlTrans
                strMPOID = cmd.ExecuteScalar()
                If strMPOID <> "" Then
                    valid = True
                Else
                    valid = False
                End If
            End Using
            If valid Then
                With AllotmentView
                    For index = 0 To AllotmentView.RowCount - 1
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTrans
                            cmd.CommandText = "INSERT INTO dbo.tblmpo_Allot(" & _
                                        "FKeyMPO" & _
                                        ",FKeyIDNbr" & _
                                        ",ActID" & _
                                        ",AllotName" & _
                                        ",FKeyRemittanceID" & _
                                        ",AcctName" & _
                                        ",AcctNbr" & _
                                        ",FKeyCurr" & _
                                        ",FKeyBank" & _
                                        ",FKeyBranch" & _
                                        ",BranchCntryCode" & _
                                        ",FKeyPrincipal" & _
                                        ",FKeyVsl" & _
                                        ",DateUpdated" & _
                                        ",LastUpdatedBy)" & _
                                        " VALUES(" & _
                                        "@FKeyMPO," & _
                                        "@FKeyIDNbr," & _
                                        "@ActID," & _
                                        "@AllotName," & _
                                        "@FKeyRemittanceID," & _
                                        "@AcctName," & _
                                        "@AcctNbr," & _
                                        "@FKeyCurr," & _
                                        "@FKeyBank," & _
                                        "@FKeyBranch," & _
                                        "@BranchCntryCode," & _
                                        "@FKeyPrincipal," & _
                                        "@FKeyVsl," & _
                                        "Getdate()," & _
                                        "@LastUpdatedBy)"
                            With cmd.Parameters
                                .AddWithValue("@FKeyMPO", strMPOID)
                                .AddWithValue("@FKeyIDNbr", AllotmentView.GetRowCellValue(index, "FKeyIDNbr"))
                                .AddWithValue("@ActID", AllotmentView.GetRowCellValue(index, "ActID"))
                                .AddWithValue("@AllotName", AllotmentView.GetRowCellValue(index, "AllotName"))
                                .AddWithValue("@FKeyRemittanceID", AllotmentView.GetRowCellValue(index, "FKeyRemittanceID"))
                                .AddWithValue("@AcctName", AllotmentView.GetRowCellValue(index, "AcctName"))
                                .AddWithValue("@AcctNbr", AllotmentView.GetRowCellValue(index, "AcctNbr"))
                                .AddWithValue("@FKeyCurr", AllotmentView.GetRowCellValue(index, "FKeyCurr"))
                                .AddWithValue("@FKeyBank", AllotmentView.GetRowCellValue(index, "FKeyBank"))
                                .AddWithValue("@FKeyBranch", AllotmentView.GetRowCellValue(index, "FKeyBranch"))
                                .AddWithValue("@BranchCntryCode", AllotmentView.GetRowCellValue(index, "BranchCntryCode"))
                                .AddWithValue("@FKeyPrincipal", AllotmentView.GetRowCellValue(index, "FKeyPrincipal"))
                                .AddWithValue("@FKeyVsl", AllotmentView.GetRowCellValue(index, "FKeyVsl"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            valid = cmd.ExecuteNonQuery().Equals(1)
                        End Using

                        'Get Allot ID
                        Dim strMPO_Allot As String = ""
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.CommandText = "SELECT [PKey] FROM mps.dbo.tblmpo_allot WHERE ID=IDENT_CURRENT('tblmpo_allot')"
                            cmd.Transaction = sqlTrans
                            strMPO_Allot = cmd.ExecuteScalar()
                            If strMPO_Allot <> "" Then
                                valid = True
                            Else
                                valid = False
                            End If
                        End Using
                        If valid Then
                            'Insert Earning MPO Wages
                            '---------------------------------------------------------
                            EarnDV.Sort = "TKey"
                            EarnDV.RowFilter = "TKey='" & .GetRowCellValue(index, "TKey") & "' AND FKeyIDNbr='" & .GetRowCellValue(index, "FKeyIDNbr") & "'"
                            If EarnDV.Count > 0 Then
                                For Each drv As DataRowView In EarnDV
                                    'MsgBox(drv.Row("FKeyWages"))
                                    Using cmd As New SqlClient.SqlCommand
                                        cmd.Connection = sqlConn
                                        cmd.Transaction = sqlTrans
                                        cmd.CommandText = "INSERT INTO dbo.tblmpo_wage(FKeyMPOAllot,FKeyWages,WageType,FKeyCurr,Amt,cAmt,ExRate)" & _
                                            "VALUES(@FKeyMPOAllot,@FKeyWages,@WageType,@FKeyCurr,@Amt,@cAmt,@ExRate)"
                                        With cmd.Parameters
                                            .AddWithValue("@FKeyMPOAllot", strMPO_Allot)
                                            .AddWithValue("@FKeyWages", drv.Row("FKeyWages"))
                                            .AddWithValue("@WageType", drv.Row("WageType"))
                                            .AddWithValue("@FKeyCurr", drv.Row("FKeyCurr"))
                                            .AddWithValue("@Amt", drv.Row("Amt"))
                                            .AddWithValue("@cAmt", drv.Row("cAmt"))
                                            .AddWithValue("@ExRate", drv.Row("ExRate"))
                                        End With
                                        cmd.ExecuteNonQuery().Equals(1)
                                    End Using
                                Next
                            End If

                            '---------------------------------------------------------
                            'Insert Deduction MPO Wages
                            '---------------------------------------------------------
                            DedDV.Sort = "TKey"
                            DedDV.RowFilter = "TKey='" & .GetRowCellValue(index, "TKey") & "' AND FKeyIDNbr='" & .GetRowCellValue(index, "FKeyIDNbr") & "'"
                            If DedDV.Count > 0 Then
                                For Each drv As DataRowView In DedDV
                                    Using cmd As New SqlClient.SqlCommand
                                        cmd.Connection = sqlConn
                                        cmd.Transaction = sqlTrans
                                        cmd.CommandText = "INSERT INTO dbo.tblmpo_wage(FKeyMPOAllot,FKeyWages,WageType,FKeyCurr,Amt,cAmt,ExRate)" & _
                                            "VALUES(@FKeyMPOAllot,@FKeyWages,@WageType,@FKeyCurr,@Amt,@cAmt,@ExRate)"
                                        With cmd.Parameters
                                            .AddWithValue("@FKeyMPOAllot", strMPO_Allot)
                                            .AddWithValue("@FKeyWages", drv.Row("FKeyWages"))
                                            .AddWithValue("@WageType", drv.Row("WageType"))
                                            .AddWithValue("@FKeyCurr", drv.Row("FKeyCurr"))
                                            .AddWithValue("@Amt", drv.Row("Amt"))
                                            .AddWithValue("@cAmt", drv.Row("cAmt"))
                                            .AddWithValue("@ExRate", drv.Row("ExRate"))
                                        End With
                                        cmd.ExecuteNonQuery().Equals(1)
                                    End Using
                                Next
                            End If
                            '---------------------------------------------------------
                        End If

                    Next
                End With
            End If
            If valid Then
                sqlTrans.Commit()
                retval = True
            End If
        Catch ex As Exception
            sqlTrans.Rollback()
            MsgBox(ex.Message)
            retval = False
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try

        CloseCustomLoadScreen()
        Return retval
    End Function

    Private Function SaveSpecialAllot2() As Boolean
        ShowCustomLoadScreen(GetType(PayrollWaitForm))
        Dim retVal As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Dim isQueryOkay As Boolean = False
        'generateData
        Dim MPO_Allot As DataTable = TryCast(AllotmentView.DataSource, DataView).ToTable(True,
                                                                        New String() {"FKeyIDNbr",
                                                                                    "ActID",
                                                                                    "AllotName",
                                                                                    "FKeyRemittanceID",
                                                                                    "AcctName",
                                                                                    "AcctNbr",
                                                                                    "FKeyCurr",
                                                                                    "FKeyBank",
                                                                                    "FKeyBranch",
                                                                                    "BranchCntryCode",
                                                                                    "FKeyPrincipal",
                                                                                    "FKeyVsl",
                                                                                    "TKey"})

        Dim MPO_Wages As DataTable = New DataView(EarnGrid.DataSource).ToTable(True,
                                                                   New String() {"TKey",
                                                                                "FKeyWages",
                                                                                "WageType",
                                                                                "FKeyCurr",
                                                                                "Amt",
                                                                                "cAmt",
                                                                                "ExRate"})
        MPO_Wages.Merge(New DataView(DedGrid.DataSource).ToTable(True,
                                                               New String() {"TKey",
                                                                            "FKeyWages",
                                                                            "WageType",
                                                                            "FKeyCurr",
                                                                            "Amt",
                                                                            "cAmt",
                                                                            "ExRate"}))
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_Pay_Process_SA"
                With cmd.Parameters
                    .AddWithValue("@MCode", cboPeriod.EditValue)
                    .AddWithValue("@RefNo", txtRef.Text)
                    .AddWithValue("@DateCreated", CDate(txtDateCreated.EditValue).ToString("yyyy-MM-dd"))
                    .AddWithValue("@MPO_Allot", MPO_Allot)
                    .AddWithValue("@MPO_Wages", MPO_Wages)
                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                End With
                isQueryOkay = (cmd.ExecuteNonQuery > 0)
            End Using

            If isQueryOkay Then
                sqlTran.Commit()
                retVal = True
            Else
                retVal = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            sqlTran.Rollback()
            retVal = False
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        CloseCustomLoadScreen()
        Return retVal
    End Function

    Private Function CreateMPOWages() As DataTable
        Dim retval As New DataTable
        With retval.Columns
            .Add("PKey", GetType(String))
            .Add("FKeyMPOAllot", GetType(String))
            .Add("FKeyIDNbr", GetType(String))
            .Add("FKeyWages", GetType(String))
            .Add("WageType", GetType(Integer))
            .Add("FKeyCurr", GetType(String))
            .Add("Amt", GetType(String))
            .Add("cAmt", GetType(String))
            .Add("ExRate", GetType(String))
            .Add("TKey", GetType(Long))
        End With
        Return retval
    End Function

    'load Crew List
    Private Sub LoadCrewList()
        Dim DateFrom As String = ChangeToSQLDate(NumCodeToDate(cboPeriod.EditValue, 1))
        Dim DateTo As String = ChangeToSQLDate(NumCodeToDate(cboPeriod.EditValue, GetDaysOfMonth(NumCodeToDate(cboPeriod.EditValue, 1))))
        Dim crewFilter As String = IIf(Trim(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")).Length > 0, " AND " & GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt"), "")
        CrewDT = DB.CreateTable("SELECT * FROM CrewActivityInRange(" & DateFrom & "," & DateTo & ") WHERE inRange = 1 AND FKeyStatCode = 'SYSONB' " & crewFilter & " ORDER BY VslName ASC,Crew ASC, DateSON DESC")
        CrewGrid.DataSource = CrewDT
    End Sub

    'Load Allotee
    Private Sub LoadAllottee()
        AllotmentGrid.DataSource = CreateAllotListDT()
        LoadWages()
    End Sub

    'Initialize Tables
    Private Sub InitTables()
        tblMPO_allot = CreateAllotListDT()
        tblMPO_wages = CreateWagesDT()
        AllotmentGrid.DataSource = tblMPO_allot 'Allotment Table
        EarnGrid.DataSource = tblMPO_wages.Copy
        DedGrid.DataSource = tblMPO_wages.Copy
    End Sub

    'Initialize Wages
    Private Sub InitWages()
        AllotmentView.GetFocusedRow()
    End Sub

    'Load Wages
    Private Sub LoadWages()
        'Earnings
        '========================================================
        'If tblMPO_wages.Rows.Count - 1 > 0 Then
        '    EarnGrid.DataSource = tblMPO_wages.Select("WageType=1").CopyToDataTable 'Earnings Table
        'End If
        EarnView.ActiveFilterString = "FKeyIDNbr = '" & AllotFocusedIDNbr() & "' AND TKey='" & AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "TKey") & "' AND WageType = 1"
        '========================================================

        'Deductions
        '========================================================
        'DedGrid.DataSource = DB.CreateTable("SELECT * FROM ")
        DedView.ActiveFilterString = "FKeyIDNbr = '" & AllotFocusedIDNbr() & "' AND TKey='" & AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "TKey") & "' AND WageType = 2"

        '========================================================

    End Sub

#Region "Filters"

    Private Sub cboPeriod_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboPeriod.EditValueChanging
        If AllotmentView.RowCount > 0 Then
            If Not isRecordSaved Then
                'If MsgBox("Do you want to disregard changes?", vbYesNo + vbDefaultButton2 + vbQuestion, GetAppName) = MsgBoxResult.No Then
                If MsgBox("Do you want to save changes?", MessageBoxIcon.Question + vbYesNo + vbDefaultButton2 + vbQuestion, GetAppName) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            Else
                isRecordSaved = False
            End If
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        LoadCrewList()
        LoadAllottee()
    End Sub

    Private Sub ClearLookupValueClicked(sender As DevExpress.XtraEditors.LookUpEdit, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            sender.EditValue = Nothing
        End If
    End Sub

    Private Sub cboPrincipal_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPrincipal.ButtonClick
        ClearLookupValueClicked(sender, e)
    End Sub

    Private Sub cboPrincipal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPrincipal.EditValueChanged
        CrewView.ActiveFilterString = ""
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If Not IsNothing(LookUpEd.EditValue) Then
            cboVessel.EditValue = Nothing
            cboAgent.EditValue = Nothing
            cboAgent.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.AgentList ORDER BY Name")
            If tblVsl.Select("FKeyPrincipal='" & IfNull(LookUpEd.EditValue, "") & "'").Length > 0 Then
                cboVessel.Properties.DataSource = tblVsl.Select("FKeyPrincipal='" & IfNull(LookUpEd.EditValue, "") & "'").CopyToDataTable()
            Else
                cboVessel.Properties.DataSource = tblVsl
            End If
        Else
            cboAgent.Properties.DataSource = tblAgent
            cboVessel.Properties.DataSource = tblVsl
        End If
        CrewView.ActiveFilter.NonColumnFilter = IIf(Len(IfNull(LookUpEd.EditValue, "")) > 0, "FKeyPrinCode='" & IfNull(LookUpEd.EditValue, "") & "'", "")

    End Sub

    Private Sub cboAgent_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboAgent.ButtonClick
        ClearLookupValueClicked(sender, e)
    End Sub

    Private Sub cboAgent_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboAgent.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        CrewView.ActiveFilter.NonColumnFilter = IIf(Len(IfNull(LookUpEd.EditValue, "")) > 0, "[FKeyAgentCode] ='" & IfNull(LookUpEd.EditValue, "") & "'", "")
        If tblVsl.Select("FKeyPrincipal='" & IfNull(cboPrincipal.EditValue, "") & "'").Length > 0 Then
            tblVsl.Select("FKeyPrincipal='" & IfNull(cboPrincipal.EditValue, "") & "'").CopyToDataTable()
        Else
            tblVsl.Clone()
        End If
    End Sub

    Private Sub cboVessel_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboVessel.ButtonClick
        ClearLookupValueClicked(sender, e)
    End Sub

    Private Sub cboVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVessel.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        CrewView.ActiveFilter.NonColumnFilter = IIf(Len(IfNull(LookUpEd.EditValue, "")) > 0, "[FKeyVslCode]='" & IfNull(LookUpEd.EditValue, "") & "'", "")
    End Sub

#End Region

#Region "Crew List"

    Private downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
    'Crew List Datatable
    Private Sub CrewView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewView.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub CrewView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewView.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

#End Region

#Region "Allotment"

    Private Sub InitAllotView()
        'reporsitory for Allotee
        '========================================================
        'tblAllotName = DB.CreateTable("SELECT PKey,(LName + ', ' +FName + ' ' + MName) AS Name,FKeyIDNbr FROM dbo.tblRemittance WHERE FKeyIDNbr ='" & IfNull(AllotmentView.GetFocusedRowCellValue("FKeyIDNbr"), "") & "'")
        tblAllotName = DB.CreateTable("SELECT (LName + ', ' +FName + ' ' + MName) AS Name, * FROM dbo.tblRemittance")
        DataViewAllotName = New DataView(tblAllotName)
        repAllotName.DataSource = DataViewAllotName.ToTable(False, New String() {"Name", "FKeyIDNbr", "PKey", "AcctName", "AcctNbr", "FKeyCurrency", "FKeyBank", "FKeyBranch"})

        'Branch
        tblBranch = DB.CreateTable("SELECT * FROM dbo.FrmBranchList ORDER BY Name")
        DataViewBranch = New DataView(tblBranch)
        repSearchLookUpBranch.DataSource = tblBranch

        'Bank
        tblBank = DB.CreateTable("SELECT * FROM dbo.tblAdmBank ORDER BY Name")
        repFKeyBank.DataSource = tblBank
        '========================================================

    End Sub

    Private Function CreateAllotListDT() As DataTable
        Dim retval As New DataTable
        With retval.Columns
            .Add("Crew", GetType(String))
            .Add("FKeyIDNbr", GetType(String))
            .Add("FkeyWScaleCode", GetType(String))
            .Add("ActID", GetType(String))
            .Add("PKey", GetType(String))
            .Add("AllotName", GetType(String))
            .Add("FKeyRemittanceID", GetType(String))
            .Add("AcctName", GetType(String))
            .Add("AcctNbr", GetType(String))
            .Add("FKeyCurr", GetType(String))
            .Add("FKeyBank", GetType(String))
            .Add("FKeyBranch", GetType(String))
            .Add("BranchCntryCode", GetType(String))
            .Add("FKeyMPO", GetType(String))
            .Add("FKeyPrincipal", GetType(String))
            .Add("FKeyVsl", GetType(String))
            .Add("TKey", GetType(Long))
        End With
        Return retval
    End Function

    Private Function GetDragData(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView) As DataTable
        Dim selection() As Integer = view.GetSelectedRows()
        If selection Is Nothing Then
            Return Nothing
        End If
        Dim count As Integer = selection.Length
        Dim result As DataTable = CreateAllotListDT()
        For i As Integer = 0 To count - 1
            TKey = TKey + 1
            Dim nRow As DataRow
            nRow = result.NewRow()
            nRow("Crew") = view.GetRowCellValue(selection(i), view.Columns("Crew"))
            nRow("FKeyIDNbr") = view.GetRowCellValue(selection(i), view.Columns("IDNbr"))
            nRow("FkeyWScaleCode") = view.GetRowCellValue(selection(i), view.Columns("FkeyWScaleCode"))
            nRow("ActID") = view.GetRowCellValue(selection(i), view.Columns("ActID"))
            nRow("FKeyPrincipal") = view.GetRowCellValue(selection(i), view.Columns("FKeyPrinCode"))
            nRow("FKeyVsl") = view.GetRowCellValue(selection(i), view.Columns("FKeyVslCode"))
            nRow("TKey") = TKey
            result.Rows.Add(nRow)
        Next i
        Return result
    End Function

    Private Sub AllotmentGrid_Click(sender As Object, e As System.EventArgs) Handles AllotmentGrid.Click
        stopnaba = True
    End Sub

    Private Sub AllotmentGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles AllotmentGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim dT As DataTable = TryCast(e.Data.GetData(GetType(DataTable)), DataTable)
        For Each dr As DataRow In dT.Rows
            Dim nRow As DataRow
            nRow = table.NewRow()
            nRow("Crew") = dr("Crew")
            nRow("FKeyIDNbr") = dr("FKeyIDNbr")
            nRow("FkeyWScaleCode") = dr("FkeyWScaleCode")
            nRow("ActID") = dr("ActID")
            nRow("TKey") = dr("TKey")
            nRow("FKeyPrincipal") = dr("FKeyPrincipal")
            nRow("FKeyVsl") = dr("FKeyVsl")
            table.Rows.Add(nRow)
        Next
    End Sub

    Private Sub AllotmentGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles AllotmentGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    'New Allottee in LookupEdit
    Private Sub repAllotName_ProcessNewValue(sender As System.Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles repAllotName.ProcessNewValue
        'CType(tblAllotName, DataTable).Rows.Add(New Object() {System.DBNull.Value, e.DisplayValue.ToString})
        Dim nRv As DataRowView = DataViewAllotName.AddNew()
        nRv("PKey") = System.DBNull.Value
        nRv("Name") = e.DisplayValue.ToString()
        nRv("FKeyIDNbr") = System.DBNull.Value
        nRv("AcctName") = System.DBNull.Value
        nRv("AcctNbr") = System.DBNull.Value
        nRv("FKeyCurrency") = GetRefCurrency()
        nRv("FKeyBank") = System.DBNull.Value
        nRv("FKeyBranch") = System.DBNull.Value

        nRv.EndEdit()
        e.Handled = True
    End Sub

    Private Sub SetAllotDetails(AllotName As String)
        If Not IsNothing(AllotName) Then
            Dim xrow As DataRowView()
            DataViewAllotName.Sort = "Name"
            xrow = DataViewAllotName.FindRows(AllotName)
            With AllotmentView
                .SetRowCellValue(.FocusedRowHandle, "FKeyRemittanceID", xrow(0)("PKey")) 'Remittance ID
                .SetRowCellValue(.FocusedRowHandle, "Name", xrow(0)("Name")) 'AcctName
                .SetRowCellValue(.FocusedRowHandle, "AcctName", IfNull(xrow(0)("AcctName"), AllotName)) 'Acct Name
                .SetRowCellValue(.FocusedRowHandle, "AcctNbr", xrow(0)("AcctNbr")) 'Acct Number
                .SetRowCellValue(.FocusedRowHandle, "FKeyCurr", xrow(0)("FKeyCurrency")) 'Currency
                .SetRowCellValue(.FocusedRowHandle, "FKeyBank", xrow(0)("FKeyBank")) 'Bank
                .SetRowCellValue(.FocusedRowHandle, "FKeyBranch", xrow(0)("FKeyBranch")) 'Branch
            End With
        End If

    End Sub

    Private Sub AllotmentView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AllotmentView.CellValueChanged
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName.Equals("AllotName") Then
            With _view
                '.SetRowCellValue(e.RowHandle, "AcctName", e.Value)
                SetAllotDetails(e.Value)
            End With
        End If
        If e.Column.FieldName.Equals("FKeyBranch") Then
            With _view
                .SetRowCellValue(e.RowHandle, "BranchCntryCode", System.DBNull.Value)
                If Not e.Value.Equals(System.DBNull.Value) Then
                    Dim value As String = TryCast(tblBranch, DataTable).Select("PKey='" & e.Value & "'")(0)("BranchCntryCode").ToString
                    .SetRowCellValue(e.RowHandle, "BranchCntryCode", value)
                End If
            End With

        End If
        If e.Column.FieldName.Equals("FKeyCurr") Then
            AddNewCurrency(IfNull(e.Value, ""))

            If Not _view.ActiveEditor.EditValue.Equals(System.DBNull.Value) And Not _view.ActiveEditor.OldEditValue.Equals(System.DBNull.Value) Then
                If _view.ActiveEditor.EditValue <> _view.ActiveEditor.OldEditValue Then
                    RecomputeAmountChangeAllotteeCurr()
                End If
            End If
        End If
    End Sub

    Private Function AllotFocusedIDNbr() As String
        Return IfNull(AllotmentView.GetFocusedRowCellValue("FKeyIDNbr"), "")
    End Function

    Private Sub ReloadAllotName(_view As DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            If .FocusedColumn.FieldName.Equals("AllotName") And (TypeOf (.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                DataViewAllotName = New DataView(edit.Properties.DataSource)
                DataViewAllotName.RowFilter = "FKeyIDNbr='" & .GetRowCellValue(.FocusedRowHandle, "FKeyIDNbr") & "' OR FKeyIDNbr IS NULL"
                edit.Properties.DataSource = DataViewAllotName
                If DataViewAllotName.Count < 0 Then
                    .SetFocusedRowCellValue("AllotName", System.DBNull.Value)
                End If
            End If
        End With
    End Sub

    Private Sub ReloadBranch(_view As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            With _view
                If .FocusedColumn.FieldName.Equals("FKeyBranch") And (TypeOf (.ActiveEditor) Is DevExpress.XtraEditors.SearchLookUpEdit) Then
                    Dim edit As DevExpress.XtraEditors.SearchLookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
                    DataViewBranch = New DataView(tblBranch)
                    DataViewBranch.RowFilter = "FKeyBank='" & .GetRowCellValue(.FocusedRowHandle, "FKeyBank") & "'"
                    edit.Properties.DataSource = DataViewBranch
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Private Sub AllotmentView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles AllotmentView.FocusedRowChanged
    '    LoadWages()
    'End Sub

    Private Sub AllotmentView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles AllotmentView.FocusedRowObjectChanged
        LoadWages()
    End Sub

    Private Sub AllotmentView_HiddenEditor(sender As Object, e As System.EventArgs) Handles AllotmentView.HiddenEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If view.FocusedColumn.FieldName.Equals("AllotName") Then 'Allotment
            If Not DataViewAllotName Is Nothing Then
                DataViewAllotName.Dispose()
                DataViewAllotName = Nothing
            End If
        ElseIf view.FocusedColumn.FieldName.Equals("FKeyBranch") Then 'Branch
            If Not DataViewBranch Is Nothing Then
                DataViewBranch.Dispose()
                DataViewBranch = Nothing
            End If
        End If


    End Sub

    Private Sub AllotmentView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles AllotmentView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub AllotmentView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles AllotmentView.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

            Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
            If info.InRow OrElse info.InRowCell Then
                AllotmentView.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub AllotmentView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles AllotmentView.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub AllotmentView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles AllotmentView.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub AllotmentView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AllotmentView.RowCellStyle
        ViewRowCellStyle(sender, e, "AllotName;AcctNbr;AcctName;FKeyCurr;FKeyBank;FKeyBranch;")
    End Sub

    Private Sub AllotmentView_RowCountChanged(sender As Object, e As System.EventArgs) Handles AllotmentView.RowCountChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.RowCount > 0 Then
            AllowCalculatePay(Name, True)
            EditSubAllowGrid(EarnView, True)
            EditSubAllowGrid(DedView, True)
            EditSubAllowGrid(ExRateView, True)

        Else
            AllowCalculatePay(Name, False)
            EditSubAllowGrid(EarnView, False)
            EditSubAllowGrid(DedView, False)
            EditSubAllowGrid(ExRateView, False)
        End If
    End Sub

    Private Sub AllotmentView_ShownEditor(sender As Object, e As System.EventArgs) Handles AllotmentView.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If .FocusedColumn.FieldName.Equals("AllotName") Then
                ReloadAllotName(view)
            ElseIf .FocusedColumn.FieldName.Equals("FKeyBranch") Then
                ReloadBranch(view)
            End If
        End With
        stopnaba = True
    End Sub

    Private Sub AllotmentView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles AllotmentView.ValidateRow
        Dim _vw As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        With _vw
            'AllotName -------------------------------------------------------------
            Dim AllotName As DevExpress.XtraGrid.Columns.GridColumn = .Columns("AllotName")
            If .GetRowCellValue(e.RowHandle, AllotName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, AllotName) Is Nothing Then
                .SetColumnError(AllotName, "Invalid Input.")
                e.Valid = False
            ElseIf .GetRowCellValue(e.RowHandle, "AllotName").Equals("") Then
                .SetColumnError(AllotName, "Invalid Input.")
                e.Valid = False
            Else
                .SetColumnError(AllotName, "")
            End If

            'AcctName -------------------------------------------------------------
            Dim AcctName As DevExpress.XtraGrid.Columns.GridColumn = .Columns("AcctName")
            If .GetRowCellValue(e.RowHandle, AcctName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, AcctName) Is Nothing Then
                .SetColumnError(AcctName, "Invalid Input.")
                e.Valid = False
            ElseIf .GetRowCellValue(e.RowHandle, "AcctName").Equals("") Then
                .SetColumnError(AcctName, "Invalid Input.")
                e.Valid = False
            Else
                .SetColumnError(AcctName, "")
            End If

            'AcctNbr -------------------------------------------------------------
            Dim AcctNbr As DevExpress.XtraGrid.Columns.GridColumn = .Columns("AcctNbr")
            If .GetRowCellValue(e.RowHandle, AcctNbr) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, AcctNbr) Is Nothing Then
                .SetColumnError(AcctNbr, "Invalid Input.")
                e.Valid = False
            ElseIf .GetRowCellValue(e.RowHandle, "AcctNbr").Equals("") Then
                .SetColumnError(AcctNbr, "Invalid Input.")
                e.Valid = False
            Else
                .SetColumnError(AcctNbr, "")
            End If

            'FKeyCurr -------------------------------------------------------------
            Dim FKeyCurr As DevExpress.XtraGrid.Columns.GridColumn = .Columns("FKeyCurr")
            If .GetRowCellValue(e.RowHandle, FKeyCurr) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyCurr) Is Nothing Then
                .SetColumnError(FKeyCurr, "Invalid Input.")
                e.Valid = False
            ElseIf .GetRowCellValue(e.RowHandle, "FKeyCurr").Equals("") Then
                .SetColumnError(FKeyCurr, "Invalid Input.")
                e.Valid = False
            Else
                .SetColumnError(FKeyCurr, "")
            End If

            'FKeyBank -------------------------------------------------------------
            Dim FKeyBank As DevExpress.XtraGrid.Columns.GridColumn = .Columns("FKeyBank")
            If .GetRowCellValue(e.RowHandle, FKeyBank) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyBank) Is Nothing Then
                .SetColumnError(FKeyBank, "Invalid Input.")
                e.Valid = False
            ElseIf .GetRowCellValue(e.RowHandle, "FKeyBank").Equals("") Then
                .SetColumnError(FKeyBank, "Invalid Input.")
                e.Valid = False
            Else
                .SetColumnError(FKeyBank, "")
            End If

            'FKeyBranch -------------------------------------------------------------
            Dim FKeyBranch As DevExpress.XtraGrid.Columns.GridColumn = .Columns("FKeyBranch")
            If .GetRowCellValue(e.RowHandle, FKeyBranch) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyBranch) Is Nothing Then
                .SetColumnError(FKeyBranch, "Invalid Input.")
                e.Valid = False
            ElseIf .GetRowCellValue(e.RowHandle, "FKeyBranch").Equals("") Then
                .SetColumnError(FKeyBranch, "Invalid Input.")
                e.Valid = False
            Else
                .SetColumnError(FKeyBranch, "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                'BRECORDUPDATEDs = True
            End If
        End With
    End Sub

    Private Sub AllotmentView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles AllotmentView.ValidatingEditor
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            Dim strRequiredField As String = "AllotName;AcctName;AcctNbr;FKeyCurr;FKeyBank;FKeyBranch"

            ''AcctName same as AllotName
            'If .FocusedColumn.FieldName.Equals("AllotName") Then
            '    e.Valid = True
            '    .SetRowCellValue(.FocusedRowHandle, "AcctName", e.Value)
            'End If

            If InStr(1, strRequiredField, .FocusedColumn.FieldName) Then

                If IsNothing(e.Value) Then
                    e.Valid = False
                    .SetColumnError(.FocusedColumn, "Invalid Input.")
                ElseIf e.Value.Equals(System.DBNull.Value) Then
                    e.Valid = False
                    .SetColumnError(.FocusedColumn, "Invalid Input.")
                ElseIf e.Value.Equals("") Then
                    e.Valid = False
                    .SetColumnError(.FocusedColumn, "Invalid Input.")
                Else
                    .SetColumnError(.FocusedColumn, "")
                End If
            End If
        End With
    End Sub

#End Region

#Region "Wages"


    Private Function CreateWagesDT() As DataTable
        Dim retval As New DataTable
        With retval.Columns
            .Add("TKey", GetType(Long))
            .Add("FKeyMPOAllot", GetType(String))
            .Add("FKeyIDNbr", GetType(String))
            .Add("FKeyWages", GetType(String))
            .Add("WageType", GetType(Integer))
            .Add("FKeyCurr", GetType(String))
            .Add("ExRate", GetType(Double))
            .Add("Amt", GetType(Double))
            .Add("cAmt", GetType(Double))
            .Add("Edited", GetType(Boolean))
        End With
        Return retval
    End Function

    Private Function GetAllotteeBankCurrency(TKey As String) As String
        Dim dv As DataView = AllotmentView.DataSource
        dv.Sort = "TKey"
        Dim dvRowView As DataRowView() = dv.FindRows(TKey)
        AllotmentView.FindRow(TKey)
        Return dvRowView(0)("FKeyCurr")
    End Function

#Region "Earnings"

    Private Sub EarnView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EarnView.CellValueChanged
        Dim _vw As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _vw.SetRowCellValue(e.RowHandle, "Edited", True)
            If e.Column.FieldName.Equals("FKeyWages") Then
                'neil co out   _vw.SetRowCellValue(e.RowHandle, "FKeyCurr", IfNull(AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "FKeyCurr"), strRefCurr))
            End If

        End If
    End Sub

    Private Function GetExRateValue(FKeyCurr As String) As Double
        Return IfNull(ExRateView.GetRowCellValue(ExRateView.LocateByValue(0, ExRateView.Columns("FKeyCurr"), FKeyCurr), "ExRate"), CDbl(0.0))
    End Function

    Private Sub EarnView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EarnView.InitNewRow
        Dim _View As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _View
            .SetRowCellValue(e.RowHandle, "TKey", AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "TKey"))
            .SetRowCellValue(e.RowHandle, "FKeyIDNbr", AllotFocusedIDNbr())
            'neil co out .SetRowCellValue(e.RowHandle, "Amt", CDbl(0))
            .SetRowCellValue(e.RowHandle, "WageType", 1) 'Earnings: WageType = 1 ; Deduction: WageType=2
        End With
    End Sub

    Private Sub EarnView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles EarnView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        MsgBox("Please correct/enter data", vbExclamation)
    End Sub



    Private Sub EarnView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles EarnView.KeyDown
        If e.KeyCode = Keys.Delete Then
            EarnView.DeleteSelectedRows()
        End If
    End Sub

    Private Sub EarnView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EarnView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr;")
    End Sub

    Private Sub EarnView_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles EarnView.RowDeleted

    End Sub

    Private Sub EarnView_ShownEditor(sender As Object, e As System.EventArgs) Handles EarnView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
    End Sub

    Private Sub EarnView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles EarnView.ValidateRow
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'neil co out WagesValidateRow(sender, e)

        If IsDBNull(_view.GetRowCellValue(_view.FocusedRowHandle, "FKeyWages")) Then
            e.Valid = False
            _view.SetColumnError(_view.Columns("FKeyWages"), "Please select a wage item")
        End If

        If IsDBNull(_view.GetRowCellValue(_view.FocusedRowHandle, "FKeyCurr")) Then
            e.Valid = False
            _view.SetColumnError(_view.Columns("FKeyCurr"), "Please select a currency")
        End If

        If IsDBNull(AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "FKeyCurr")) Then
            e.Valid = False
            _view.SetColumnError(_view.Columns("Amt"), "Allottee's bank currecny is not set.")
        Else
            With _view

                ' If .FocusedColumn.FieldName = "ExRate" Or .FocusedColumn.FieldName = "FKeyWages" Or .FocusedColumn.FieldName = "Amt" Then
                'Dim ExRate As Double = IfNull(.GetRowCellValue(e.RowHandle, "ExRate"), 1)
                Dim ExRate As Double = IfNull(GetExRateValue(IfNull(.GetRowCellValue(e.RowHandle, "FKeyCurr"), "")), 1)
                Dim Amt As Double = IfNull(.GetRowCellValue(e.RowHandle, "Amt"), 0)
                'Dim cAmt As Double = Amt * ExRate
                Dim cAmt As Double
                Try
                    cAmt = ConvertAmount(Amt, IfNull(.GetRowCellValue(e.RowHandle, "FKeyCurr"), ""), AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "FKeyCurr"), TryCast(ExRateGrid.DataSource, DataTable), "FKeyCurr", "ExRate")
                Catch ex As Exception
                    cAmt = 0
                    LogErrors("Process Special Allotment - Add Earning. Error: " & ex.Message)
                End Try
                '.SetRowCellValue(e.RowHandle, "Amt", Amt)
                .SetRowCellValue(e.RowHandle, "cAmt", cAmt)
                .SetRowCellValue(e.RowHandle, "ExRate", ExRate)
                ' End If


            End With
        End If

    End Sub

    Private Sub EarnView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles EarnView.ValidatingEditor
        Dim _vw As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)



        'neil co out
        'If _vw.FocusedColumn.FieldName.Equals("Amt") Then
        '    If IsNothing(_vw.GetFocusedRowCellValue("FKeyCurr")) Then
        '        e.Valid = False
        '        _vw.SetColumnError(_vw.FocusedColumn, "Please select a currency")
        '    Else
        '        If _vw.GetFocusedRowCellValue("FKeyCurr").ToString.Trim.Length > 0 Then
        '            'neil co out
        '            '_vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.FocusedColumn, e.Value)
        '            '_vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.Columns("cAmt"), CalculateConvertedAmount(ExRateView.DataSource, e.Value, _vw.GetFocusedRowCellValue("FKeyCurr"), GetAllotteeBankCurrency(_vw.GetFocusedRowCellValue("TKey"))))
        '            'e.Valid = True
        '        Else
        '            e.Valid = False
        '            _vw.SetColumnError(_vw.FocusedColumn, "Please select a currency")
        '        End If

        '    End If
        'ElseIf _vw.FocusedColumn.FieldName.Equals("FKeyCurr") Then
        '    If IsNothing(_vw.GetFocusedRowCellValue("FKeyCurr")) Then
        '        e.Valid = False
        '        _vw.SetColumnError(_vw.FocusedColumn, "Please select a currency")
        '    Else
        '        If _vw.GetFocusedRowCellValue("FKeyCurr").ToString.Trim.Length > 0 Then
        '            'neil co out
        '            '_vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.FocusedColumn, e.Value)
        '            '_vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.Columns("ExRate"), GetExRateValue(e.Value))
        '            '_vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.Columns("cAmt"), CalculateConvertedAmount(ExRateView.DataSource, _vw.GetFocusedRowCellValue("Amt"), e.Value, GetAllotteeBankCurrency(_vw.GetFocusedRowCellValue("TKey"))))

        '            e.Valid = True
        '        Else
        '            e.Valid = False
        '            _vw.SetColumnError(_vw.FocusedColumn, "Please select a currency")
        '        End If

        '    End If
        'End If
    End Sub

#End Region

#Region "Deduction"

    Private Sub DedView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DedView.CellValueChanged
        Dim _vw As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _vw.SetRowCellValue(e.RowHandle, "Edited", True)
            If e.Column.FieldName.Equals("FKeyWages") Then
                'neil co out _vw.SetRowCellValue(e.RowHandle, "FKeyCurr", AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "FKeyCurr"))
            End If
        End If
    End Sub

    Private Sub DedView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DedView.InitNewRow
        Dim _View As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _View
            .SetRowCellValue(e.RowHandle, "TKey", AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "TKey"))
            .SetRowCellValue(e.RowHandle, "FKeyIDNbr", AllotFocusedIDNbr())
            'neil co out .SetRowCellValue(e.RowHandle, "Amt", CDbl(0))
            .SetRowCellValue(e.RowHandle, "WageType", 2) 'Earnings: WageType = 1 ; Deduction: WageType=2
        End With
    End Sub

    Private Sub DedView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles DedView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        MsgBox("Please correct/enter data", vbExclamation)
    End Sub

    Private Sub DedView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DedView.KeyDown
        If e.KeyCode = Keys.Delete Then
            DedView.DeleteSelectedRows()
        End If
    End Sub

    Private Sub DedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DedView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr;")
    End Sub

    Private Sub DedView_ShownEditor(sender As Object, e As System.EventArgs) Handles DedView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
    End Sub

    Private Sub DedView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DedView.ValidateRow
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'neil co out WagesValidateRow(sender, e)

        If IsDBNull(_view.GetRowCellValue(_view.FocusedRowHandle, "FKeyWages")) Then
            e.Valid = False
            _view.SetColumnError(_view.Columns("FKeyWages"), "Please select a wage item")
        End If

        If IsDBNull(_view.GetRowCellValue(_view.FocusedRowHandle, "FKeyCurr")) Then
            e.Valid = False
            _view.SetColumnError(_view.Columns("FKeyCurr"), "Please select a currency")
        End If

        'With _view
        '    Dim ExRate As Double = IfNull(GetExRateValue(IfNull(.GetRowCellValue(e.RowHandle, "FKeyCurr"), "")), 1)
        '    Dim Amt As Double = IfNull(.GetRowCellValue(e.RowHandle, "Amt"), 0)
        '    Dim cAmt As Double = Amt * ExRate
        '    '.SetRowCellValue(e.RowHandle, "Amt", Amt)
        '    .SetRowCellValue(e.RowHandle, "cAmt", cAmt)
        '    .SetRowCellValue(e.RowHandle, "ExRate", ExRate)
        'End With

        If IsDBNull(AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "FKeyCurr")) Then
            e.Valid = False
            _view.SetColumnError(_view.Columns("Amt"), "Allottee's bank currecny is not set.")
        Else
            With _view

                ' If .FocusedColumn.FieldName = "ExRate" Or .FocusedColumn.FieldName = "FKeyWages" Or .FocusedColumn.FieldName = "Amt" Then
                'Dim ExRate As Double = IfNull(.GetRowCellValue(e.RowHandle, "ExRate"), 1)
                Dim ExRate As Double = IfNull(GetExRateValue(IfNull(.GetRowCellValue(e.RowHandle, "FKeyCurr"), "")), 1)
                Dim Amt As Double = IfNull(.GetRowCellValue(e.RowHandle, "Amt"), 0)
                'Dim cAmt As Double = Amt * ExRate
                Dim cAmt As Double
                Try
                    cAmt = ConvertAmount(Amt, IfNull(.GetRowCellValue(e.RowHandle, "FKeyCurr"), ""), AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "FKeyCurr"), TryCast(ExRateGrid.DataSource, DataTable), "FKeyCurr", "ExRate")
                Catch ex As Exception
                    cAmt = 0
                    LogErrors("Process Special Allotment - Add Earning. Error: " & ex.Message)
                End Try
                '.SetRowCellValue(e.RowHandle, "Amt", Amt)
                .SetRowCellValue(e.RowHandle, "cAmt", cAmt)
                .SetRowCellValue(e.RowHandle, "ExRate", ExRate)
                ' End If


            End With
        End If
    End Sub

    Private Sub DedView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DedView.ValidatingEditor
        Dim _vw As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'neil co out
        'If _vw.FocusedColumn.FieldName.Equals("Amt") Then
        '    If IsNothing(_vw.GetFocusedRowCellValue("FKeyCurr")) Then
        '        e.Valid = False
        '        _vw.SetColumnError(_vw.FocusedColumn, "Please select a currency")
        '    Else
        '        If _vw.GetFocusedRowCellValue("FKeyCurr").ToString.Trim.Length > 0 Then
        '            _vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.FocusedColumn, e.Value)
        '            _vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.Columns("cAmt"), CalculateConvertedAmount(ExRateView.DataSource, e.Value, _vw.GetFocusedRowCellValue("FKeyCurr"), GetAllotteeBankCurrency(_vw.GetFocusedRowCellValue("TKey"))))
        '            e.Valid = True
        '        Else
        '            e.Valid = False
        '            _vw.SetColumnError(_vw.FocusedColumn, "Please select a currency")
        '        End If

        '    End If
        'ElseIf _vw.FocusedColumn.FieldName.Equals("FKeyCurr") Then
        '    If IsNothing(_vw.GetFocusedRowCellValue("FKeyCurr")) Then
        '        e.Valid = False
        '        _vw.SetColumnError(_vw.FocusedColumn, "Please select a currency")
        '    Else
        '        If _vw.GetFocusedRowCellValue("FKeyCurr").ToString.Trim.Length > 0 Then
        '            _vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.FocusedColumn, e.Value)
        '            _vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.Columns("ExRate"), GetExRateValue(e.Value))
        '            _vw.SetRowCellValue(_vw.FocusedRowHandle, _vw.Columns("cAmt"), CalculateConvertedAmount(ExRateView.DataSource, _vw.GetFocusedRowCellValue("Amt"), e.Value, GetAllotteeBankCurrency(_vw.GetFocusedRowCellValue("TKey"))))
        '            e.Valid = True
        '        Else
        '            e.Valid = False
        '            _vw.SetColumnError(_vw.FocusedColumn, "Please select a currency")
        '        End If

        '    End If
        'End If
    End Sub
#End Region

    Private Sub WagesValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'With _view
        '    If .FocusedColumn.FieldName = "ExRate" Or .FocusedColumn.FieldName = "FKeyWages" Or .FocusedColumn.FieldName = "Amt" Then
        '        Dim ExRate As Double = IfNull(.GetRowCellValue(e.RowHandle, "ExRate"), 1)
        '        Dim Amt As Double = IfNull(.GetRowCellValue(e.RowHandle, "Amt"), 0)
        '        Dim cAmt As Double = Amt * ExRate
        '        .SetRowCellValue(e.RowHandle, "FKeyCurr", .GetRowCellValue(e.RowHandle, "FKeyCurr"))
        '        .SetRowCellValue(e.RowHandle, "Amt", Amt)
        '        .SetRowCellValue(e.RowHandle, "cAmt", cAmt)
        '        .SetRowCellValue(e.RowHandle, "ExRate", ExRate)
        '    End If
        'End With


    End Sub

#End Region

    Private Sub repCntry_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles repCntry.ParseEditValue
        Try
            e.Value = Convert.ToString(e.Value)
            e.Handled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try
    End Sub


    Dim InvalidMessage As String = String.Empty
    Private Sub RunPayroll()
        GroupControl.Focus()
        If MsgBox("Do you want to continue to calculate payroll?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MessageBoxIcon.Question, GetAppName) = MsgBoxResult.Yes Then
            If ValidateFields(RequiredControls) Then
                If Not AllotHasNULL() Then
                    'isRecordSaved = SaveSpecialAllot()
                    isRecordSaved = SaveSpecialAllot2()
                    If isRecordSaved Then
                        MsgBox(GetMessage("Saved", isRecordSaved), MsgBoxStyle.Information, GetAppName)
                        RefreshData()
                        BRECORDUPDATEDs = False
                    Else
                        MsgBox(GetMessage("Saved", isRecordSaved), MsgBoxStyle.Information, GetAppName)
                    End If
                Else
                    MsgBox(InvalidMessage, MsgBoxStyle.Critical, GetAppName)
                End If
            End If
        End If
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(RequiredControls) Then
                If Not AllotHasNULL() Then
                    flag = True
                    ALLOWNEXTS = flag
                    RunPayroll()
                Else
                    flag = False
                    ALLOWNEXTS = flag
                End If
            Else
                flag = False
                ALLOWNEXTS = True
            End If

        ElseIf res = MsgBoxResult.No Then
            isRecordSaved = True 'neil to avoid asking again "Do you want to save changes?"
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Private Function AllotHasNULL() As Boolean
        Dim retVal As Boolean = True
        If AllotmentView.RowCount > 0 Then
            For Each dCol As DevExpress.XtraGrid.Columns.GridColumn In AllotmentView.VisibleColumns
                Dim dt As New DataTable
                dt = TryCast(AllotmentView.DataSource, DataView).ToTable
                If dt.Select("[" & dCol.FieldName & "] IS NULL").Length > 0 Then
                    InvalidMessage = "Unable to proceed, Incomplete Data"
                    Return True
                    Exit For
                Else
                    retVal = False
                End If
            Next
            If WagesHasError() Or isNotValidExRateTable() Then
                retVal = True
            Else
                retVal = False
            End If

        Else
            retVal = False
        End If

        Return retVal
    End Function

    Private Function isNotValidExRateTable() As Boolean
        'Check if it has ExRate with 0 value
        If (From d As DataRow In TryCast(ExRateGrid.DataSource, DataTable).Copy.Rows Where d("ExRate") = 0 Select d).Count > 0 Then
            InvalidMessage = "Invalid currency exchange rate(s)"
            Return True
        Else
            Return False
        End If
    End Function

    Private Function WagesHasError() As Boolean
        Dim retval As Boolean = False
        Dim EarnDV As DataView = EarnView.DataSource
        Dim DedDV As DataView = DedView.DataSource
        Dim hasError As Boolean = True
        With AllotmentView
            For index = 0 To .RowCount - 1
                EarnDV.Sort = "TKey"
                EarnDV.RowFilter = "TKey=" & .GetRowCellValue(index, "TKey") & " AND FKeyIDNbr='" & .GetRowCellValue(index, "FKeyIDNbr") & "'"
                DedDV.Sort = "TKey"
                DedDV.RowFilter = "TKey=" & .GetRowCellValue(index, "TKey") & " AND FKeyIDNbr='" & .GetRowCellValue(index, "FKeyIDNbr") & "'"
                If EarnDV.Count <= 0 And DedDV.Count <= 0 Then
                    .Appearance.Row.BackColor = INVALID_COLOR
                    'neil co out InvalidMessage = "Invalid allottee details"
                    InvalidMessage = "Invalid allotment details"
                    hasError = False
                End If
                If Not hasError Then
                    retval = True
                End If
            Next
        End With

        Return retval

    End Function

    Private Sub ConvertValues(FKeyCurrency As String, ExRate As Double)

    End Sub

#Region "ExRate"

    Private strRefCurr As String = String.Empty

    Private Sub InitExRateTable()
        strRefCurr = GetRefCurrency(0)
        Dim dt As New DataTable
        Dim FKeyCurrCol As DataColumn = New DataColumn
        With FKeyCurrCol
            .ColumnName = "ID"
            .DataType = GetType(Long)
            .AutoIncrement = True
            .AutoIncrementSeed = 0
            .AutoIncrementStep = 1
        End With
        dt.Columns.Add(FKeyCurrCol)
        dt.Columns.Add("FKeyCurr", GetType(String))
        dt.Columns.Add("ExRate", GetType(Double))
        Dim nRow As DataRow
        nRow = dt.NewRow()
        nRow("FKeyCurr") = strRefCurr
        nRow("ExRate") = 1.0
        dt.Rows.Add(nRow)
        ExRateGrid.DataSource = dt
        With ExRateView
            .BeginSort()
            .Columns("ID").SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
            .Columns("ID").SortOrder = ColumnSortOrder.Ascending
            .EndSort()
        End With

    End Sub

    Private Function IsRefCurr(view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal row As Integer) As Boolean
        Try
            Dim val As String = view.GetRowCellValue(row, "FKeyCurr")
            Return (val = strRefCurr)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ExRateView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ExRateView.CellValueChanged
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName.Equals("ExRate") Then
            Dim dt As DataTable = TryCast(EarnGrid.DataSource, DataTable).Copy
            dt.Merge(TryCast(DedGrid.DataSource, DataTable).Copy)
            For Each dr As DataRow In dt.Rows
                dr("Exrate") = e.Value
                '<!-- edited by tony20171009
                'dr("cAmt") = CalculateConvertedAmount(ExRateView.DataSource, IfNull(dr("Amt"), CDbl(0)), dr("FKeyCurr"), GetAllotteeBankCurrency(dr("TKey")))
                dr("cAmt") = ConvertAmount(dr("Amt"), dr("FKeyCurr"), GetAllotteeBankCurrency(dr("TKey")), TryCast(ExRateGrid.DataSource, DataTable), "FKeyCurr", "ExRate")
                '-->
            Next
            Dim dvEarn As New DataView(dt)
            dvEarn.RowFilter = "WageType = 1"
            EarnGrid.DataSource = dvEarn.ToTable

            Dim dvDed As New DataView(dt)
            dvDed.RowFilter = "WageType = 2"
            DedGrid.DataSource = dvDed.ToTable
            LoadWages()

        End If


    End Sub

    Private Sub ExRateView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ExRateView.ShowingEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _v.FocusedColumn.FieldName = "ExRate" AndAlso IsRefCurr(_v, _v.FocusedRowHandle) Then
            e.Cancel = True
        End If
        If _v.FocusedColumn.FieldName = "FKeyCurr" Then
            If IsRefCurr(_v, _v.FocusedRowHandle) Then
                e.Cancel = True
            Else
                If Not IsNothing(_v.GetFocusedRowCellValue("FKeyCurr")) Then
                    If isCurrencyUsed(IfNull(_v.GetFocusedRowCellValue("FKeyCurr"), "")) Then
                        e.Cancel = True
                    Else
                        e.Cancel = False
                    End If
                    'Check if the currency is used
                End If
            End If
        End If
    End Sub

    Private Function isCurrencyUsed(FKeyCurr As String) As Boolean
        'Dim retval As Boolean = False

        If (From dEarn As DataRow In TryCast(EarnGrid.DataSource, DataTable).Rows Where IfNull(dEarn("FKeyCurr"), "") = FKeyCurr Select dEarn).Count > 0 Then
            Return True
        ElseIf (From dDed As DataRow In TryCast(DedGrid.DataSource, DataTable).Rows Where IfNull(dDed("FKeyCurr"), "") = FKeyCurr Select dDed).Count > 0 Then
            Return True
        ElseIf (From allot As DataRow In TryCast(AllotmentGrid.DataSource, DataTable).Rows Where IfNull(allot("FKeyCurr"), "") = FKeyCurr Select allot).Count > 0 Then
            Return True
        Else
            Return False
        End If


        'Return retval
    End Function

    Private Sub AddNewCurrency(FkeyCurr As String)
        If ExRateView.LocateByValue("FKeyCurr", FkeyCurr) < 0 Then
            ExRateView.AddNewRow()
            Dim newRowHandle As Integer = ExRateView.FocusedRowHandle
            Dim nRow As Object = ExRateView.GetRow(newRowHandle)
            ExRateView.SetRowCellValue(newRowHandle, ExRateView.Columns("FKeyCurr"), FkeyCurr)
            ExRateView.SetRowCellValue(newRowHandle, ExRateView.Columns("ExRate"), 0.0)
            ExRateView.UpdateCurrentRow()
        End If

    End Sub

#End Region

    Private Sub ReloadRepositoryCurr(_view As DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            If .FocusedColumn.FieldName.Equals("FKeyCurr") And (TypeOf (.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                Dim dt = From dr As DataRow In tblCurr.Rows
                         Join exr As DataRow In TryCast(ExRateView.DataSource, DataView).ToTable.Rows On dr("PKey") Equals exr("FKeyCurr")
                         Select Name = dr("Name"),
                            PKey = dr("PKey"),
                            Symbol = dr("Symbol")
                edit.Properties.DataSource = dt
            End If
        End With
    End Sub

    Dim stopnaba As Boolean = False

    Private Sub AllotmentGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles AllotmentGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub CrewGrid_Click(sender As Object, e As System.EventArgs) Handles CrewGrid.Click
        stopnaba = True
    End Sub

    Private Sub CrewGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles CrewGrid.DragDrop
        If Not IsNothing(downHitInfo) Then
            If downHitInfo.View.Name = AllotmentView.Name And downHitInfo.View.SelectedRowsCount > 0 Then
                AllotmentView.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub CrewGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles CrewGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub CrewGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub CrewView_ShownEditor(sender As Object, e As System.EventArgs) Handles CrewView.ShownEditor
        stopnaba = True
    End Sub


#Region "Update Converted Amount After Currency is changed"
    'Created by: Tony
    'Date:       2017-10-07
    'Remarks :   This procedure is called everytime the allottee's bank currency is changed.
    '            What it does is that it recomputes the converted amount in the Earn and Ded View based on the allottee's newly changed bank currency
    Private Sub RecomputeAmountChangeAllotteeCurr()
        Dim _viewlist As New List(Of DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Amt As Double
        Dim ExRate As Double

        _viewlist.Add(EarnView)
        _viewlist.Add(DedView)
        For Each _view As DevExpress.XtraGrid.Views.Grid.GridView In _viewlist
            With _view

                For i As Integer = 0 To _view.RowCount - 1
                    ExRate = IfNull(GetExRateValue(IfNull(.GetRowCellValue(i, "FKeyCurr"), "")), 1)
                    Amt = IfNull(.GetRowCellValue(i, "Amt"), 0)
                    'Dim cAmt As Double = Amt * ExRate
                    Dim cAmt As Double
                    Try
                        cAmt = ConvertAmount(Amt, IfNull(.GetRowCellValue(i, "FKeyCurr"), ""), AllotmentView.GetRowCellValue(AllotmentView.FocusedRowHandle, "FKeyCurr"), TryCast(ExRateGrid.DataSource, DataTable), "FKeyCurr", "ExRate")
                    Catch ex As Exception
                        cAmt = 0
                        LogErrors("Process Special Allotment - Add Earning. Error: " & ex.Message)
                    End Try
                    '.SetRowCellValue(e.RowHandle, "Amt", Amt)
                    .SetRowCellValue(i, "cAmt", cAmt)
                    .SetRowCellValue(i, "ExRate", ExRate)
                    ' End If
                Next

            End With
        Next

    End Sub
#End Region
End Class
