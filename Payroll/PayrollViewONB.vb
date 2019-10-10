Imports System.Windows.Forms

Public Class PayrollViewONB

#Region "Declaration"

    Private DS_Pay_ONB As New DataSet
    Private tblPay As DataTable
    Private tblPayCrew_ONB As DataTable
    Private tblPay_ONB As DataTable
    Private tblPayInfo As DataTable
    Private tblPayExRate As DataTable
    Dim isPayRollList As Boolean = False

    Private tblEarnings As DataTable
    Private tblEarnings_A As DataTable
    Private tblDeduction As DataTable
    Dim tbladmCurr As DataTable

    Private RptControl As PayrollReportControl
    'neil com/out Dim LastUpdatedBy As String = "LastUpdatedBy"
    Dim SelectedView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
    Dim frmPayrollList As frmPayrollList

    Dim clsgridflout As New clsGridFlyOut

    Private FormName As String = "View / Edit Payroll Onboard Payroll"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil


#Region "Layout Const"
    Private Const Layout_S1 As Integer = 355
    Private Const Layout_S2 As Integer = 364
    Private Const Layout_S3 As Integer = 636
    Private Const Layout_S5 As Integer = 312
#End Region

#End Region

#Region "Initializations"


#Region "Clear DataTable"

    Private Sub ClearDT()
        tblPay = New DataTable
        tblPayCrew_ONB = New DataTable
        tblPay_ONB = New DataTable
        tblpayinto = New DataTable
    End Sub

    Private Sub ClearDataSet()
        'If Not isDSEmpty(DS_Pay_ONB) Then
        DS_Pay_ONB.Clear()
        DS_Pay_ONB.Relations.Clear()
        For Each dt As DataTable In DS_Pay_ONB.Tables
            dt.Constraints.Clear()
        Next
        DS_Pay_ONB.Tables.Clear()
        'End If

    End Sub

    Private Sub ClearViews()
        'CrewListGrid.DataSource = tblPayCrew_ONB.Clone
        'ExRateGrid.DataSource = tblPayExRate.Clone
        'EarnGrid.DataSource = tblPay_ONB.Clone
        'AccumGrid.DataSource = tblPay_ONB.Clone
        'DedGrid.DataSource = tblPay_ONB.Clone
        'PayInfoGrid.DataSource = tblPayInfo.Clone

        CrewListGrid.DataSource = Nothing
        ExRateGrid.DataSource = Nothing
        EarnGrid.DataSource = Nothing
        AccumGrid.DataSource = Nothing
        DedGrid.DataSource = Nothing
        PayInfoGrid.DataSource = Nothing
    End Sub

    Private Sub ClearFilter()
        cboPeriod.EditValue = Nothing
        cboPrincipal.EditValue = Nothing
        For index = 0 To cboVessel.Properties.Items.Count - 1
            cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
        Next
    End Sub

    Private Function isDSEmpty(DS As DataSet) As Boolean
        Dim retVal As Boolean = True
        For Each dt As DataTable In DS.Tables
            If dt.Rows.Count <> 0 Then
                retVal = False
            End If
        Next
        Return retVal
    End Function

#End Region

    Private Sub InitControls()
        RequiredControls = {cboPeriod, cboPrincipal, cboVessel, cboRefNo}
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl2.AllowCustomization = False
        frmPayrollList = New frmPayrollList("ONB")
        Me.TabbedControlGroup1.SelectedTabPageIndex = 0

        cboPeriod.Properties.DataSource = GetPayPeriods("MONTH", 60, 3)
        cboVessel.Properties.DataSource = InitDTVessel()
        cboPrincipal.Properties.DataSource = InitDTPrincipal()

        tbladmCurr = DB.CreateTable("SELECT PKey,Name,Symbol FROM dbo.tblAdmCurr ORDER BY Name")
        repEOnbFKeyCurr.DataSource = tbladmCurr
        repDONBFKeyCurr.DataSource = tbladmCurr
        repERFKeyCurr.DataSource = tbladmCurr
        repAccumFKeyCurr.DataSource = tbladmCurr

        InitPayrollOnbControls()
        IntPayInfoControls()

        SplitContainerControl2.SplitterPosition = SplitContainerControl1.Height * 0.8   '<-- added by tony20171006 - the exchange rate grid should auto adjust its height

        'Init Reports
        InitReportControls() 'Added by Tony20161019

        ClearViews()
        ClearFilter()

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil

        SetProcessedPayrollListVisibility(Name, True)

    End Sub

    Private Sub InitPayrollOnbControls()
        Dim tbladmOnb As DataTable = DB.CreateTable("SELECT PKey,Name,WageType FROM dbo.tblAdmWageOnb ORDER BY Name")
        repEarnOnb.DataSource = tbladmOnb.Select("WageType =1").CopyToDataTable
        repEAccum.DataSource = tbladmOnb.Select("WageType =1").CopyToDataTable
        repDedOnb.DataSource = tbladmOnb.Select("WageType =2").CopyToDataTable
    End Sub

    Private Sub IntPayInfoControls()
        repOPrd.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmWagePrd ORDER BY Name")
        repODen.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmWageDen ORDER BY Name")
        repPayInfo.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmWageInfo ORDER BY Name")
    End Sub

    Private Function InitDTVessel() As DataTable
        Dim cTbl As New DataTable
        Dim vslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, " WHERE " & GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
        cTbl = DB.CreateTable("SELECT * FROM dbo.VslList " & vslFilter & "ORDER BY Name")
        Return cTbl
    End Function

    Private Function InitDTPrincipal() As DataTable
        Dim ctbl As DataTable
        Dim prinFilter As String = IIf(GetUserFilterString(, , "PKey").Length > 0, " WHERE " & GetUserFilterString(, , "PKey"), "")
        ctbl = DB.CreateTable("SELECT * FROM dbo.PrincipalList " & prinFilter & " ORDER BY Name ")
        Return ctbl
    End Function

    Private Sub InitDataSet(MCode As Integer)
        ClearDataSet()
        Dim sqlCon As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlCon.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlCon
                cmd.CommandText = "SP_PayView_ONB"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Period", MCode)
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(DS_Pay_ONB, "PayONB_ALL")
                    With DS_Pay_ONB
                        .Tables(0).TableName = "Pay"
                        tblPay = .Tables("Pay")
                        .Tables(1).TableName = "Crew_ONB"
                        tblPayCrew_ONB = .Tables("Crew_ONB") 'tblPayCrew_ONB
                        .Tables(2).TableName = "PayONB"
                        tblPay_ONB = .Tables("PayONB") 'tblPay_ONB
                        .Tables(3).TableName = "PayInfo"
                        tblPayInfo = .Tables("PayInfo") 'tblPayInfo
                        .Tables(4).TableName = "PayExRate"
                        tblPayExRate = .Tables("PayExRate") 'tblPayExRate
                    End With
                End Using
                SetupDataSet()
                InitDetails()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
        End Try

    End Sub


    Private Sub RefreshDataSet()
        'Throw New NotImplementedException
        BRECORDUPDATEDs = False
        Dim MCode As Integer = cboPeriod.EditValue
        'ClearMajorControls()
        'ClearPayCrewDetails()

        'Clear Controls Below
        'cboPrincipal.EditValue = Nothing
        'ClearCheckLookUp(cboVessel)
        'ClearCheckLookUp(cboRefNo)
        'Clear Controls Below END

        InitDataSet(MCode)
        LoadSelectedItems(GetPayCrewOnbID)
        'cboRefNo.Properties.DataSource = InitRefNoDT()
    End Sub


    Private Sub InitReportControls()    'Added by Tony20161019
        'Dim payRepCtr As New PayrollReportControl(DB, Name)
        RptControl = New PayrollReportControl(DB, Name)
        SplitContainerControl5.Panel1.Controls.Clear()
        SplitContainerControl5.Panel1.Controls.Add(RptControl)
        RptControl.Dock = Windows.Forms.DockStyle.Fill

        If RptControl.ReportViewCount > 0 Then
            SetPreviewReportEnabled(Name, True)
        Else
            SetPreviewReportEnabled(Name, False)
        End If

        'Added by Tony20161019 - This loads the Reports Filter Options class and make it as a Signatory Object
        LoadSignatoryControl(PanelControl_Signatories)

        'tony20170118
        SetQuickReportsVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetQuickReportsCaption(Name, "View Quick Reports")
        SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        SetPreviewReportEnabled(Name, False)
        'end tony
    End Sub

    Private Sub SetupDataSet()
        If tblPay.Rows.Count > 0 And
            tblPayCrew_ONB.Rows.Count > 0 And
            tblPay_ONB.Rows.Count > 0 And
            tblPayInfo.Rows.Count > 0 And
            tblPayExRate.Rows.Count > 0 Then
            With DS_Pay_ONB
                If Not .Relations.Contains("R_Pay") And
                    Not .Relations.Contains("R_Crew_Onb") And
                    Not .Relations.Contains("R_ONB") And
                    Not .Relations.Contains("R_Info") And
                    Not .Relations.Contains("R_ExRate") Then
                    .Relations.Add("R_Pay", .Tables("Pay").Columns("PKey"), .Tables("Crew_ONB").Columns("FKeyPayID"))
                    .Relations.Add("R_Crew_Onb", .Tables("Crew_ONB").Columns("PKey"), .Tables("PayONB").Columns("FKeyPayCrewONB"))
                    .Relations.Add("R_Info", .Tables("Crew_ONB").Columns("PKey"), .Tables("PayInfo").Columns("PayCrewONB"))
                    .Relations.Add("R_ExRate", .Tables("Pay").Columns("PKey"), .Tables("PayExRate").Columns("FKeyPay"))
                End If
            End With

        End If
    End Sub

    Private Function InitRefNoDT() As DataTable
        Dim retVal As DataTable
        Dim dvRef As New DataView(tblPay)
        'retVal = dvRef.ToTable(True, New String() {"RefNo", "FKeyPrincipal", "FKeyVsl"})
        retVal = tblPay
        Return retVal
    End Function

    Private Sub InitDetails()
        InitCrewList()
        InitPayOnb()
        InitPayInfo()
        InitPayExRate()
    End Sub

    Private Sub InitCrewList()

        CrewListGrid.DataSource = tblPayCrew_ONB

        'neil test codes
        'Dim dt2 As New DataTable
        'Dim dview As DataView
        'dview = tblPayCrew_ONB.DefaultView
        'dview.RowFilter = "RefNo = '" & frmPayrollList.PayRefNo & "'"
        'dt2 = dview.ToTable()
        'CrewListGrid.DataSource = dt2
        'CrewListView.ActiveFilter.NonColumnFilter = "RefNo = '" & frmPayrollList.PayRefNo & "'"
        'neil end

        CrewListView.Columns("RankSort").SortIndex = 0
        CrewListView.Columns("RankSort").SortOrder = ColumnSortOrder.Ascending
        CrewListView.Columns("CrewName").SortIndex = 1
        CrewListView.Columns("CrewName").SortOrder = ColumnSortOrder.Ascending
    End Sub

    Private Sub InitPayOnb()
        'Earning
        If tblPay_ONB.Select("WageType=1").Length > 0 Then
            'Earnings not Accumulating
            If tblPay_ONB.Select("WageType=1 AND Accum=0").Length > 0 Then
                EarnGrid.DataSource = tblPay_ONB.Select("WageType=1 AND Accum=0").CopyToDataTable
            Else
                EarnGrid.DataSource = tblPay_ONB.Clone
            End If

            'Accumulating Balance
            If tblPay_ONB.Select("WageType=1 AND Accum=1").Length > 0 Then
                AccumGrid.DataSource = tblPay_ONB.Select("WageType=1 AND Accum=1").CopyToDataTable
            Else
                AccumGrid.DataSource = tblPay_ONB.Clone
            End If
        Else
            EarnGrid.DataSource = tblPay_ONB.Clone
            AccumGrid.DataSource = tblPay_ONB.Clone
        End If

        'Deductions
        If tblPay_ONB.Select("WageType=2").Length > 0 Then
            DedGrid.DataSource = tblPay_ONB.Select("WageType=2").CopyToDataTable
        Else
            DedGrid.DataSource = tblPay_ONB.Clone
        End If
    End Sub

    Private Sub InitPayInfo()
        PayInfoGrid.DataSource = tblPayInfo
    End Sub

    Private Sub InitPayExRate()
        ExRateGrid.DataSource = tblPayExRate
    End Sub

#End Region

#Region "Main Functions"

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        SelectedView = Nothing
        SetPayrollListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetCalculatePayCaption(Name, "Reprocess Crew")
        SetDeleteCaption(Name, "Delete Payroll")
        AllowCalculatePay(Name, False)
        InitControls()
        MakeReadOnlyListener(lcgPayrollDetails)
        MakeReadOnlyListener(lcgCrewDetails)
        MakeReadOnlyListener(lcgPayOnb)
        EditSubAllowGrid(Me.ExRateView, False)
        EditSubAllowGrid(Me.EarnView, False)
        EditSubAllowGrid(Me.AccumView, False)
        EditSubAllowGrid(Me.CrewListView, False)
        EditSubAllowGrid(Me.DedView, False)
        EditSubAllowGrid(Me.PayInfoView, False)

        SetRibbonPageGroupVisibility(Name, "rpgPayrollReportOptions", True) 'neil 20160914
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neil 20160913
        SetClearFilterVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'neil 
        SetShowListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'fords
        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        EdiDeleteAllow(CrewListView)
        PayrollLock()

    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        EditSubAllowGrid(Me.CrewListView, isEditdable, False)
        EditSubAllowGrid(Me.PayInfoView, isEditdable, False)
        EditSubAllowGrid(Me.ExRateView, isEditdable, False)
        EditSubAllowGrid(Me.ExRateView, isEditdable, True) 'neil test
        EditSubAllowGrid(Me.EarnView, isEditdable, True)
        EditSubAllowGrid(Me.DedView, isEditdable, True)
        EditSubAllowGrid(Me.AccumView, isEditdable, False)
        EdiDeleteAllow(CrewListView)
        If CrewListView.RowCount > 0 Then
            AllowCalculatePay(Name, isEditdable)
        Else
            AllowCalculatePay(Name, False)
        End If

    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0)
            Case "RunPayroll"
                RunPayroll() 'ReProcess Crew
            Case "PayrollList"
                frmPayrollList = New frmPayrollList("ONB")
                frmPayrollList.ShowDialog(Me)
                If frmPayrollList.RefreshCallingForm Then cboPeriod.EditValue = Nothing
                GetSelectedPay()
            Case "CLEARFILTER"
                ClearControlEverything()
                ClearPayCrewDetails()

            Case "PREVIEWREPORT"
                ShowPayReports()

            Case "VIEWQUICKREPORTS"
                If SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1 Then
                    SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                    SetQuickReportsCaption(Name, "Hide Quick Reports")
                    SetPreviewReportEnabled(Name, True)
                Else
                    SplitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
                    SetQuickReportsCaption(Name, "View Quick Reports")
                    SetPreviewReportEnabled(Name, False)
                End If
        End Select
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        GroupControl1.Focus()
        Dim payCrewID As String = String.Empty
        If BRECORDUPDATEDs Then
            payCrewID = GetPayCrewOnbID()
            Dim info As Boolean = False
            If ValidatePayViewONB() Then
                info = SaveEditONB()
                If info Then
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                    'RefreshData()
                    RefreshDataSet()
                    SetPayCrewListSelection(payCrewID)
                    BRECORDUPDATEDs = False
                    EditCheck(Name, False)
                Else
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                End If
            End If
        End If
    End Sub

    Private Function SaveEditONB() As Boolean
        Dim RetVal As Boolean = True
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction
            'Update/Insert tblPay_ONB
            RetVal = SavePayONB(sqlConn, sqlTran)
            'Update ExRate
            RetVal = SaveExRate(sqlConn, sqlTran, RetVal)

            If RetVal Then
                BRECORDUPDATEDs = Not RetVal
                sqlTran.Commit()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            RetVal = False
            sqlTran.Rollback()
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return RetVal
    End Function

    Private Function SaveExRate(sqlConn As SqlClient.SqlConnection, sqlTran As SqlClient.SqlTransaction, PreviousRetValue As Boolean) As Boolean
        'Please remember that there is a trigger in the database [tblPayExRate] that updates the [CAmt] OF the Items Here
        'Trigger Name: [TG_Pay_UpdateExRate]
        Dim retVal As Boolean = PreviousRetValue
        'Updated ExchangeRate   
        Dim ExRateDV As New DataView
        ExRateDV = ExRateView.DataSource
        ExRateDV.RowFilter = "Edited = 'True'"
        If ExRateDV.Count > 0 Then
            For Each dr As DataRowView In ExRateDV
                'neil co out
                'Using cmd As New SqlClient.SqlCommand()
                '    cmd.Connection = sqlConn
                '    cmd.Transaction = sqlTran
                '    cmd.CommandText = "UPDATE dbo.tblPayExRate SET ExRate = " & dr("ExRate") & _
                '            " WHERE FKeyPay = '" & dr("FKeyPay") & "' " & _
                '            " AND FKeyCurr = '" & dr("FKeyCurr") & "' "
                '    retVal = (cmd.ExecuteNonQuery > 0)
                'End Using
                Dim roww As DataRow = dr.DataView(0).Row
                'If IfNull(dr("FKeyPay"), "").Equals("New") Then 'neil
                If roww.RowState = DataRowState.Added Then
                    Using cmd As New SqlClient.SqlCommand()
                        cmd.Connection = sqlConn
                        cmd.Transaction = sqlTran
                        cmd.CommandText = "Insert into dbo.tblPayExRate (ExRate,FKeyPay,FKeyCurr) values (" & dr("ExRate") & ",'" & _
                            dr("FKeyPay") & "','" & dr("FKeyCurr") & "')"
                        retVal = (cmd.ExecuteNonQuery > 0)
                    End Using
                Else
                    Using cmd As New SqlClient.SqlCommand()
                        cmd.Connection = sqlConn
                        cmd.Transaction = sqlTran
                        cmd.CommandText = "UPDATE dbo.tblPayExRate SET ExRate = " & dr("ExRate") & _
                                " WHERE FKeyPay = '" & dr("FKeyPay") & "' " & _
                                " AND FKeyCurr = '" & dr("FKeyCurr") & "' "
                        retVal = (cmd.ExecuteNonQuery > 0)
                    End Using
                End If

            Next
        End If
        Return retVal
    End Function

    Private Function ValidatePayViewONB() As Boolean
        Dim retval As Boolean = False

        For Each dr As DataRowView In ExRateView.DataSource
            If IfNull(dr("ExRate"), 0) <= 0 Then
                retval = False
                MsgBox("Invalid exchange rate values.", MsgBoxStyle.Critical, GetAppName)
                'Exit For
                Return retval
            Else
                retval = True
            End If
        Next
        Return retval
    End Function

    Private Function SavePayONB(sqlConn As SqlClient.SqlConnection, sqlTran As SqlClient.SqlTransaction) As Boolean
        Dim retval As Boolean = False
        Try
            Dim EarnDV As New DataView
            EarnDV = EarnView.DataSource
            EarnDV.RowFilter = "Edited='True' AND WageType=1 "
            If EarnDV.Count > 0 Then
                For Each dr As DataRowView In EarnDV
                    If dr("Edited").Equals(True) Then

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Payroll Onboard Payroll", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text, "View / Edit Payroll Onboard Payroll", strID)

                        If IfNull(dr("PKey"), "").Equals("") Then
                            'Insert
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.Transaction = sqlTran
                                cmd.CommandText = " INSERT INTO dbo.tblPay_ONB( " & _
                                    " FKeyPayCrewONB, " & _
                                    " FKeyWageOnb, " & _
                                    " WageType, " & _
                                    " FullAmt, " & _
                                    " FKeyCurr, " & _
                                    " ExRate, " & _
                                    " Amt, " & _
                                    " CAmt, " & _
                                    " DateStart, " & _
                                    " DateEnd, " & _
                                    " Prorata, " & _
                                    " LastUpdatedBy) " & _
                                    " VALUES(" & _
                                    " @FKeyPayCrewONB, " & _
                                    " @FKeyWageOnb, " & _
                                    " @WageType, " & _
                                    " @FullAmt, " & _
                                    " @FKeyCurr, " & _
                                    " @ExRate, " & _
                                    " @Amt, " & _
                                    " @CAmt, " & _
                                    " @DateStart, " & _
                                    " @DateEnd, " & _
                                    " @Prorata, " & _
                                    " @LastUpdatedBy)"
                                With cmd.Parameters
                                    .AddWithValue("@FKeyPayCrewONB", dr("FKeyPayCrewONB"))
                                    .AddWithValue("@FKeyWageOnb", dr("FKeyWageOnb"))
                                    .AddWithValue("@WageType", dr("WageType"))
                                    .AddWithValue("@FullAmt", IfNull(dr("FullAmt"), 0.0))
                                    .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                    .AddWithValue("@ExRate", dr("ExRate"))
                                    .AddWithValue("@Amt", dr("Amt"))
                                    .AddWithValue("@CAmt", dr("CAmt"))
                                    .AddWithValue("@DateStart", dr("DateStart"))
                                    .AddWithValue("@DateEnd", dr("DateEnd"))
                                    .AddWithValue("@Prorata", IfNull(dr("Prorata"), False))
                                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                                End With
                                retval = (cmd.ExecuteNonQuery() > 0)
                            End Using
                        Else
                            'Updated
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.Transaction = sqlTran
                                cmd.CommandText = " UPDATE dbo.tblPay_ONB SET " & _
                                    " FKeyWageOnb =  @FKeyWageOnb, " & _
                                    " FKeyCurr = @FKeyCurr, " & _
                                    " Amt = @Amt, " & _
                                    " CAmt = @CAmt, " & _
                                    " DateStart = @DateStart, " & _
                                    " DateEnd = @DateEnd, " & _
                                    " Prorata = @Prorata, " & _
                                    " DateUpdated = Getdate(), " & _
                                    " LastUpdatedBy = @LastUpdatedBy " & _
                                    " WHERE PKey = @PKey "
                                With cmd.Parameters
                                    .AddWithValue("@PKey", dr("PKey"))
                                    .AddWithValue("@FKeyWageOnb", dr("FKeyWageOnb"))
                                    .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                    .AddWithValue("@Amt", dr("Amt"))
                                    .AddWithValue("@CAmt", dr("CAmt"))
                                    .AddWithValue("@DateStart", dr("DateStart"))
                                    .AddWithValue("@DateEnd", dr("DateEnd"))
                                    .AddWithValue("@Prorata", IfNull(dr("Prorata"), False))
                                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                                End With
                                retval = (cmd.ExecuteNonQuery > 0)
                            End Using
                        End If
                    End If
                Next
            End If

            'Deduction
            Dim DedDV As New DataView
            DedDV = DedView.DataSource
            DedDV.RowFilter = "Edited='True' AND WageType=2 "
            If DedDV.Count > 0 Then
                For Each dr As DataRowView In DedDV
                    If dr("Edited").Equals(True) Then
                        If IfNull(dr("PKey"), "").Equals("") Then
                            'Insert
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.Transaction = sqlTran
                                cmd.CommandText = " INSERT INTO dbo.tblPay_ONB( " & _
                                    " FKeyPayCrewONB, " & _
                                    " FKeyWageOnb, " & _
                                    " WageType, " & _
                                    " FullAmt, " & _
                                    " FKeyCurr, " & _
                                    " ExRate, " & _
                                    " Amt, " & _
                                    " CAmt, " & _
                                    " DateStart, " & _
                                    " DateEnd, " & _
                                    " Prorata, " & _
                                    " LastUpdatedBy) " & _
                                    " VALUES(" & _
                                    " @FKeyPayCrewONB, " & _
                                    " @FKeyWageOnb, " & _
                                    " @WageType, " & _
                                    " @FullAmt, " & _
                                    " @FKeyCurr, " & _
                                    " @ExRate, " & _
                                    " @Amt, " & _
                                    " @CAmt, " & _
                                    " @DateStart, " & _
                                    " @DateEnd, " & _
                                    " @Prorata, " & _
                                    " @LastUpdatedBy)"
                                With cmd.Parameters
                                    .AddWithValue("@FKeyPayCrewONB", dr("FKeyPayCrewONB"))
                                    .AddWithValue("@FKeyWageOnb", dr("FKeyWageOnb"))
                                    .AddWithValue("@WageType", dr("WageType"))
                                    .AddWithValue("@FullAmt", IfNull(dr("FullAmt"), 0.0))
                                    .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                    .AddWithValue("@ExRate", dr("ExRate"))
                                    .AddWithValue("@Amt", dr("Amt"))
                                    .AddWithValue("@CAmt", dr("CAmt"))
                                    .AddWithValue("@DateStart", dr("DateStart"))
                                    .AddWithValue("@DateEnd", dr("DateEnd"))
                                    .AddWithValue("@Prorata", IfNull(dr("Prorata"), False))
                                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                                End With
                                retval = (cmd.ExecuteNonQuery() > 0)
                            End Using
                        Else
                            'Updated
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.Transaction = sqlTran
                                cmd.CommandText = " UPDATE dbo.tblPay_ONB SET " & _
                                    " FKeyWageOnb =  @FKeyWageOnb, " & _
                                    " FKeyCurr = @FKeyCurr, " & _
                                    " Amt = @Amt, " & _
                                    " CAmt = @CAmt, " & _
                                    " DateStart = @DateStart, " & _
                                    " DateEnd = @DateEnd, " & _
                                    " Prorata = @Prorata, " & _
                                    " DateUpdated = Getdate(), " & _
                                    " LastUpdatedBy = @LastUpdatedBy " & _
                                    " WHERE PKey = @PKey "
                                With cmd.Parameters
                                    .AddWithValue("@PKey", dr("PKey"))
                                    .AddWithValue("@FKeyWageOnb", dr("FKeyWageOnb"))
                                    .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                    .AddWithValue("@Amt", dr("Amt"))
                                    .AddWithValue("@CAmt", dr("CAmt"))
                                    .AddWithValue("@DateStart", dr("DateStart"))
                                    .AddWithValue("@DateEnd", dr("DateEnd"))
                                    .AddWithValue("@Prorata", dr("Prorata"))
                                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                                End With
                                retval = (cmd.ExecuteNonQuery > 0)
                            End Using
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            retval = False
            sqlTran.Rollback()
            MsgBox(ex.Message)
            'Finally
            '    If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return retval
    End Function

    Private Function SavePayInfo(sqlConn As SqlClient.SqlConnection, sqlTran As SqlClient.SqlTransaction) As Boolean
        Dim retval As Boolean = True
        Try
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandText = ""
                retval = (cmd.ExecuteNonQuery > 0)

            End Using
        Catch ex As Exception
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return retval
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        'Return MyBase.CheckValidateFields(showMsg)
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If EarnView.HasColumnErrors() Or DedView.HasColumnErrors Or PayInfoView.HasColumnErrors Or AccumView.HasColumnErrors Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidatePayViewONB() Then
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData()
                Else
                    flag = False
                    ALLOWNEXTS = flag
                End If
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshDataSet()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = False
        If Not IsNothing(SelectedView) Then
            Select Case SelectedView.Name
                Case EarnView.Name, DedView.Name, AccumView.Name
                    With SelectedView
                        If MsgBox("Are you sure you want to delete the payment " & .GetFocusedRowCellDisplayText("FKeyWageOnb") & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Onboard Payroll", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text & " \ payment: " & .GetFocusedRowCellDisplayText("FKeyWageOnb"), FormName) 'neil
                            clsAudit.saveAuditPreDelDetails("tblPay_ONB", .GetFocusedRowCellValue("PKey"), LastUpdatedBy)
                            '<!--added by tony20180922 : Log Deletion
                            Dim oLogDeletion As New LogDeletion
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                FormName, _
                                "Crewing", _
                                "tblPay_ONB", _
                                "PKey IN ('" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "')", _
                                "<< Delete Payroll Data - Onboard Payroll >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Onboard Payroll>", _
                                GetUserName())
                            '-->

                            info = DB.RunSql("DELETE dbo.tblPay_ONB WHERE PKey='" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "'")
                            If info Then
                                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                .DeleteRow(.FocusedRowHandle)
                                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                                RefreshDataSet()
                            Else
                                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                            End If
                        End If
                    End With
                Case ExRateView.Name 'neil
                    With SelectedView
                        If MsgBox("Are you sure you want to delete the currency " & .GetFocusedRowCellDisplayText("FKeyCurr") & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Onboard Payroll", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ currency: " & .GetFocusedRowCellDisplayText("FKeyCurr"), FormName) 'neil
                            clsAudit.saveAuditPreDelDetails("tblPayExRate", .GetFocusedRowCellValue("FKeyPay"), LastUpdatedBy)
                            '<!--added by tony20180922 : Log Deletion
                            Dim oLogDeletion As New LogDeletion
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                FormName, _
                                "Crewing", _
                                "tblPayExRate", _
                                "PKey IN ('" & IfNull(.GetFocusedRowCellValue("FKeyPay"), "") & "')", _
                                "<< Delete Payroll Data - Onboard Payroll Ex Rate >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Onboard Payroll Ex Rate>", _
                                GetUserName())
                            '-->

                            info = DB.RunSql("DELETE dbo.tblPayExRate WHERE FKeyPay='" & IfNull(.GetFocusedRowCellValue("FKeyPay"), "") & "' and FKeyCurr = '" & IfNull(.GetFocusedRowCellValue("FKeyCurr"), "") & "'")
                            If info Then
                                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                .DeleteRow(.FocusedRowHandle)
                                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                                RefreshDataSet()
                            Else
                                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                            End If
                        End If
                    End With
                Case CrewListView.Name
                    With SelectedView
                        Dim selRH As Integer() = .GetSelectedRows
                        Dim CrewNameDesc As String = String.Empty


                        For index = 0 To selRH.Length - 1
                            CrewNameDesc = .GetRowCellDisplayText(selRH(index), "CrewName") & "," & vbCrLf & CrewNameDesc
                        Next
                        If Trim(CrewNameDesc.Length) > 0 Then
                            CrewNameDesc = CrewNameDesc.Substring(0, Len(Trim(CrewNameDesc)) - 3)
                        End If

                        If MsgBox("Are you sure you want to delete Crew(s) " & vbCrLf & CrewNameDesc & "", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                            Dim cWhereCond As String = ""
                            'info = DB.RunSql("DELETE dbo.tblPayCrew_ONB WHERE PKey='" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "'")
                            For index = 0 To .SelectedRowsCount - 1

                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew From Payroll", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew: " & .GetRowCellDisplayText(selRH(index), "CrewName"), FormName) 'neil
                                clsAudit.saveAuditPreDelDetails("tblPayCrew_ONB", .GetRowCellValue(selRH(index), "PKey"), LastUpdatedBy)

                                info = DB.RunSql("DELETE dbo.tblPayCrew_ONB WHERE PKey='" & IfNull(.GetRowCellValue(selRH(index), "PKey"), "") & "'")
                                If info Then
                                    cWhereCond = cWhereCond & IIf(IfNull(cWhereCond, "").Length > 0, ", ", "") & _
                                        "'" & IfNull(.GetRowCellValue(selRH(index), "PKey"), "") & "'"
                                End If
                                'CrewNameDesc = .GetRowCellDisplayText(selRH(index), "CrewName") & "," & vbCrLf
                            Next

                            If info Then
                                If IfNull(cWhereCond, "").Length > 0 Then

                                    '<!--added by tony20180922 : Log Deletion
                                    Dim oLogDeletion As New LogDeletion
                                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                        "Onboard Payroll", _
                                        "Crewing", _
                                        "tblPayCrew_ONB", _
                                        "PKey IN (" & cWhereCond & ")", _
                                        "<< Delete Payroll Data - Onboard Payroll - Crew >>", _
                                        LogDeletion.DeletionType.Manual, _
                                        "Manually Deleted in <Onboard Payroll - Crew>", _
                                        GetUserName())
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    '-->
                                End If
                                '.DeleteRow(.FocusedRowHandle)
                                .DeleteSelectedRows()
                                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                                RefreshDataSet()
                            Else
                                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                            End If
                        End If
                    End With
            End Select
        Else
            Dim strDescrip As String '= "Are you sure you want to delete the " & cboPeriod.Text & " Payroll with Reference of : " & cboRefNo.Text & "?"
            strDescrip = "Are you sure you want to delete the following Payroll with Reference No of:" & vbCrLf & DeletePayrollDesc()

            If ValidateDeletePayroll() Then
                If MsgBox(strDescrip, MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                    Dim lockedrefs As String = "", allrefs As String = "", cleanAllrefs As String = ""

                    allrefs = GetSelectedRefNo(False, lockedrefs, cleanAllrefs)

                    'neil commented out 
                    'If Len(GetSelectedRefNo.Trim) > 0 Then
                    '    info = DB.RunSql("DELETE dbo.tblPay " & GetSelectedRefNo())
                    'End If
                    'If info Then
                    '    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                    '    bLoaded = False
                    '    RefreshData()
                    'Else
                    '    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                    'End If

                    If lockedrefs.Trim.Length > 0 Then
                        If MsgBox("Some Payroll can not be deleted because of being locked." & _
                                  vbCrLf & "Following Payroll below." & vbCrLf & vbCrLf & lockedrefs & _
                                  vbCrLf & vbCrLf & "Do you wish to continue?", MsgBoxStyle.Question + vbYesNo, GetAppName) = MsgBoxResult.Yes Then

                            If Len(allrefs.Trim) > 0 Then
                                savePredel("tblpay", cleanAllrefs)
                                '<!--added by tony20180922 : Log Deletion
                                Dim oLogDeletion As New LogDeletion
                                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                    "View Home Allotment Payroll", _
                                    "Crewing", _
                                    "tblPay", _
                                    allrefs.Replace("WHERE ", ""), _
                                    "<< Delete Crew Data - Home Allotment Payroll>>", _
                                    LogDeletion.DeletionType.Manual, _
                                    "Manually Deleted in <Home Allotment Payroll>", _
                                    GetUserName())
                                '-->
                                info = DB.RunSql("DELETE dbo.tblPay " & allrefs)
                                If info Then
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                                    bLoaded = False
                                    RefreshData()
                                Else
                                    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                                End If
                            Else
                                MsgBox("No Payroll available for deleting.", vbInformation)
                            End If
                        Else

                        End If
                    Else
                        If Len(allrefs.Trim) > 0 Then
                            savePredel("tblpay", cleanAllrefs)
                            '<!--added by tony20180922 : Log Deletion
                            Dim oLogDeletion As New LogDeletion
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "View Home Allotment Payroll", _
                                "Crewing", _
                                "tblPay", _
                                allrefs.Replace("WHERE ", ""), _
                                "<< Delete Crew Data - Home Allotment Payroll>>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Home Allotment Payroll>", _
                                GetUserName())
                            '-->

                            info = DB.RunSql("DELETE dbo.tblPay " & allrefs)
                            If info Then
                                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                                bLoaded = False
                                RefreshData()
                            Else
                                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                            End If
                        Else
                            MsgBox("No Payroll available for deleting.", vbInformation)
                        End If
                    End If

                End If
            End If

        End If


    End Sub



    Private Function GetPayLogDelWhereCond(Optional incLocked As Boolean = False,
                                      Optional ByRef lockedrefs As String = "",
                                      Optional ByRef cleanallrefs As String = "") As String
        Dim retVal As String = ""
        Dim retlockedref As String = ""

        'For index = 0 To cboRefNo.Properties.Items.Count - 1
        '    'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
        '    If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
        '        retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal
        '    End If
        'Next

        If incLocked Then
            For index = 0 To cboRefNo.Properties.Items.Count - 1
                'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
                If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                    retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal
                End If
            Next
        Else

            Dim tempdt As DataView = cboRefNo.Properties.DataSource
            Dim tempdt2 As New DataView
            tempdt2.Table = tempdt.Table.Copy
            tempdt2.RowFilter = ("isLocked = False")
            tempdt2.Sort = ("PKey")

            For index = 0 To cboRefNo.Properties.Items.Count - 1
                'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
                If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                    If tempdt2.FindRows(cboRefNo.Properties.Items(index).Value).Count > 0 Then
                        retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal
                    Else
                        retlockedref = "[" & cboRefNo.Properties.Items(index).Description & "]," & vbCrLf & retlockedref
                    End If
                End If
            Next
        End If

        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            cleanallrefs = retVal
            retVal = "PKey IN( " & retVal & " ) AND PayType = 'ONB' "
        Else
            retVal = String.Empty
        End If

        If retlockedref.Length > 0 Then
            retlockedref = Trim(retlockedref)
            retlockedref = retlockedref.Substring(0, Len(retlockedref) - 1)
        End If
        lockedrefs = retlockedref
        Return retVal
    End Function

    Function savePredel(tblname As String, delimitedpkeys As String) As Boolean
        Dim retval As Boolean = True, refs() As String

        Try
            refs = Replace(delimitedpkeys, "'", "").Split(",")

            Dim indirefs As String

            For Each indirefs In refs
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Onboard Payroll", 0, System.Environment.MachineName, "Ref: " & indirefs, FormName) 'neil
                clsAudit.saveAuditPreDelDetails(tblname, indirefs, LastUpdatedBy)
            Next
        Catch
            retval = False
        End Try

        Return retval
    End Function

    Private Function DeletePayrollDesc() As String
        Dim retVal As String = String.Empty
        For index = 0 To cboRefNo.Properties.Items.Count - 1
            'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
            If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                retVal = "[" & cboRefNo.Properties.Items(index).Description & "]," & vbCrLf & retVal
            End If
        Next
        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(Trim(retVal)) - 3)
        End If

        Return retVal
    End Function

    Private Function ValidateDeletePayroll()
        Dim retval As Boolean = False
        For Each ctr As DevExpress.XtraEditors.BaseEdit In RequiredControls
            If IsNothing(ctr.EditValue) Then
                retval = False
                'MsgBox("Please fill up required fields.", MsgBoxStyle.Exclamation, GetAppName)
                MsgBox("Please select a " & ctr.ToolTip, MsgBoxStyle.Exclamation, GetAppName)
                ctr.BackColor = INVALID_COLOR
                Exit For
            ElseIf (IfNull(ctr.EditValue, String.Empty).Equals(String.Empty)) Then
                retval = False
                'MsgBox("Please fill up required fields.", MsgBoxStyle.Exclamation, GetAppName)
                MsgBox("Please select a " & ctr.ToolTip, MsgBoxStyle.Exclamation, GetAppName)
                ctr.BackColor = INVALID_COLOR
                Exit For
            Else
                ctr.BackColor = REQUIRED_COLOR
                retval = True
            End If

        Next
        Return retval
    End Function

    Private Function GetSelectedRefNo(Optional incLocked As Boolean = False,
                                      Optional ByRef lockedrefs As String = "",
                                      Optional ByRef cleanallrefs As String = "") As String
        Dim retVal As String = ""
        Dim retlockedref As String = ""

        'For index = 0 To cboRefNo.Properties.Items.Count - 1
        '    'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
        '    If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
        '        retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal
        '    End If
        'Next

        If incLocked Then
            For index = 0 To cboRefNo.Properties.Items.Count - 1
                'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
                If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                    retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal
                End If
            Next
        Else

            Dim tempdt As DataView = cboRefNo.Properties.DataSource
            Dim tempdt2 As New DataView
            tempdt2.Table = tempdt.Table.Copy
            tempdt2.RowFilter = ("isLocked = False")
            tempdt2.Sort = ("PKey")

            For index = 0 To cboRefNo.Properties.Items.Count - 1
                'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
                If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                    If tempdt2.FindRows(cboRefNo.Properties.Items(index).Value).Count > 0 Then
                        retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal
                    Else
                        retlockedref = "[" & cboRefNo.Properties.Items(index).Description & "]," & vbCrLf & retlockedref
                    End If
                End If
            Next
        End If

        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            cleanallrefs = retVal
            retVal = " WHERE PKey IN( " & retVal & " ) AND PayType = 'ONB' "
        Else
            retVal = String.Empty
        End If

        If retlockedref.Length > 0 Then
            retlockedref = Trim(retlockedref)
            retlockedref = retlockedref.Substring(0, Len(retlockedref) - 1)
        End If
        lockedrefs = retlockedref
        Return retVal
    End Function

#End Region

#Region "Crew List"

#Region "Filters"

    'Period
    Private Sub cboPeriod_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriod.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
            FilterCrewList()
        End If
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        Dim _l As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        ClearMajorControls()
        ClearPayCrewDetails()


        'If Not isPayRollList Then  'Clear Controls
        cboPrincipal.EditValue = Nothing
        ClearCheckLookUp(cboVessel)
        ClearCheckLookUp(cboRefNo)
        'End If 'Clear Controls END


        InitDataSet(_l.EditValue)
        cboRefNo.Properties.DataSource = InitRefNoDT()

    End Sub

    Private Sub ClearMajorControls()
        ClearCheckLookUp(cboVessel)
        ClearCheckLookUp(cboRefNo)
        cboPrincipal.EditValue = Nothing
    End Sub

    'Principal
    Private Sub cboPrincipal_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPrincipal.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
            FilterCrewList()
        End If
    End Sub

    Private Sub cboPrincipal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPrincipal.EditValueChanged
        Dim _l As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim prinCode As String = ""
        'If Not isPayRollList Then
        ClearCheckLookUp(cboVessel)
        ClearCheckLookUp(cboRefNo)
        'End If
        If Not IsNothing(_l.EditValue) Then
            If Not IfNull(_l.EditValue, "").Equals("") Then
                prinCode = " FKeyPrincipal='" & _l.EditValue & "' "
            Else
                prinCode = ""
            End If
            CrewListView.ActiveFilter.NonColumnFilter = prinCode
        End If
        FilterVslList(_l.EditValue) 'filter Vsl Combobox
        FilterRefNoList()
    End Sub

    Private Sub FilterVslList(Optional Princode As String = "")
        Dim dv As New DataView(InitDTVessel)
        If Not IfNull(Princode, "").Equals("") Then
            dv.RowFilter = "FKeyPrincipal = '" & Princode & "'"
        Else
            dv.RowFilter = String.Empty
        End If

        If dv.Count < 10 And dv.Count > 0 Then
            cboVessel.Properties.DropDownRows = dv.Count + 1
        ElseIf dv.Count > 0 And dv.Count > 10 Then
            cboVessel.Properties.DropDownRows = 10 + 1
        End If
        cboVessel.Properties.DataSource = dv.ToTable
    End Sub

    'Vessel
    Private Sub cboVessel_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboVessel.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.CheckedComboBoxEdit = TryCast(sender, DevExpress.XtraEditors.CheckedComboBoxEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            For index = 0 To ctr.Properties.Items.Count - 1
                ctr.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
            Next
        End If
    End Sub

    Private Sub cboVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVessel.EditValueChanged
        Dim lookupEd As DevExpress.XtraEditors.CheckedComboBoxEdit = TryCast(sender, DevExpress.XtraEditors.CheckedComboBoxEdit)
        Dim VslFilter As String = ""
        ClearCheckLookUp(cboRefNo)
        FilterCrewList()
        FilterRefNoList() 'filter RefNo

    End Sub

    Private Function GetVesselFilter() As String
        Dim retVal As String = ""
        For index = 0 To cboVessel.Properties.Items.Count - 1
            If cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                retVal = "'" & cboVessel.Properties.Items(index).Value & "'," & retVal
            End If
        Next
        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            retVal = " FKeyVsl IN( " & retVal & " ) "
        End If

        Return retVal
    End Function

    Private Sub FilterRefNoList()
        Dim dv As New DataView(InitRefNoDT)
        Dim PrinCode As String = IfNull(cboPrincipal.EditValue, String.Empty)
        'ClearCheckLookUp(cboVessel)

        'Principal
        Dim strPrinFilter As String = String.Empty
        If Not IfNull(PrinCode, "").Equals("") Then
            'dv.RowFilter = "FKeyPrincipal = '" & PrinCode & "'"
            strPrinFilter = "FKeyPrincipal = '" & PrinCode & "'"
        Else
            strPrinFilter = String.Empty
        End If

        'Vessel
        Dim Vslcode As String = GetVesselFilter()
        Dim strVslFilter As String = String.Empty
        If Not IfNull(Vslcode, "").Equals("") Then
            strVslFilter = " " & Vslcode & " "
        Else
            'dv.RowFilter = String.Empty
            strVslFilter = String.Empty
        End If

        Dim strFilterRef As String = String.Empty
        If strPrinFilter.Trim.Length > 0 Then
            strFilterRef = IIf(strVslFilter.Trim.Length > 0, strPrinFilter & " AND " & strVslFilter, strPrinFilter)
        Else
            If strVslFilter.Trim.Length > 0 Then
                strFilterRef = strVslFilter
            Else
                strFilterRef = String.Empty
            End If
        End If

        dv.RowFilter = strFilterRef
        If dv.Count < 10 And dv.Count > 0 Then
            cboRefNo.Properties.DropDownRows = dv.Count + 1
        ElseIf dv.Count > 0 And dv.Count > 10 Then
            cboRefNo.Properties.DropDownRows = 10 + 1
        End If
        cboRefNo.Properties.DataSource = dv
    End Sub

    Private Sub cboRefNo_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRefNo.ButtonPressed
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ClearCheckLookUp(sender)
        End If
    End Sub

    Private Sub ClearCheckLookUp(sender As Object)
        Dim ctr As DevExpress.XtraEditors.CheckedComboBoxEdit = TryCast(sender, DevExpress.XtraEditors.CheckedComboBoxEdit)
        For index = 0 To ctr.Properties.Items.Count - 1
            ctr.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
        Next
    End Sub

    'RefNo
    Private Sub cboRefNo_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboRefNo.EditValueChanged
        FilterCrewList()
    End Sub

    Private Function FilterStrReferenceNumber() As String
        Dim retVal As String = ""
        For index = 0 To cboRefNo.Properties.Items.Count - 1
            'cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
            If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal
            End If
        Next
        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            retVal = "FKeyPayID IN( " & retVal & " )"
        End If
        Return retVal
    End Function

    Private Sub FilterCrewList()
        Try
            'Principal Filter
            Dim strPrincipal As String = String.Empty
            If IfNull(cboPrincipal.EditValue, String.Empty).Equals(String.Empty) Then
                strPrincipal = String.Empty
            Else
                strPrincipal = "FKeyPrincipal='" & cboPrincipal.EditValue & "'"
            End If

            'VslFilter
            Dim strVslFilter As String = String.Empty
            If Len(GetVesselFilter.Trim) > 0 Then
                strVslFilter = GetVesselFilter()
            Else
                strVslFilter = String.Empty
            End If

            'RefNumber Filter
            Dim strRefNoFilter As String = String.Empty
            If Len(FilterStrReferenceNumber.Trim) > 0 Then
                strRefNoFilter = FilterStrReferenceNumber()
            Else
                strRefNoFilter = String.Empty
            End If

            Dim strFilter As String = String.Empty
            If (Not strVslFilter.Equals(String.Empty)) Then
                'strFilter = strVslFilter
                If Not strRefNoFilter.Equals(String.Empty) Then
                    strFilter = strVslFilter & " AND " & strRefNoFilter
                Else
                    strFilter = strVslFilter
                End If

            Else
                If Not strRefNoFilter.Equals(String.Empty) Then
                    strFilter = strRefNoFilter
                Else
                    strFilter = String.Empty
                End If
            End If
            If Len(strFilter) > 0 Then
                If Len(strPrincipal) > 0 Then
                    strFilter = strFilter & " AND " & strPrincipal
                End If
            Else
                If Len(strPrincipal) > 0 Then
                    strFilter = strPrincipal
                End If
            End If

            CrewListView.ActiveFilter.NonColumnFilter = strFilter
            CrewListView.BeginSort()
            CrewListView.Columns("RankSort").SortIndex = 0
            CrewListView.Columns("RankSort").SortOrder = ColumnSortOrder.Ascending
            CrewListView.Columns("CrewName").SortIndex = 1
            CrewListView.Columns("CrewName").SortOrder = ColumnSortOrder.Ascending
            CrewListView.EndSort()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub LoadSubItems()
        FilterCrewList()

    End Sub

#End Region

#Region "GetIDS"

    Private Function GetPayCrewOnbID() As String
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("PKey"), "")
        Return retVal
    End Function

    Private Function GetPayID() As String
        Dim retval As String = ""
        retval = IfNull(CrewListView.GetFocusedRowCellValue("FKeyPayID"), "")
        Return retval
    End Function

    Private Function GetPrevBal() As Double
        Dim retval As Double = 0
        retval = IfNull(CrewListView.GetFocusedRowCellValue("PreviousBalance"), CDbl(0))
        Return retval
    End Function

#End Region

    Private Sub LoadSelectedItems(PayCrewOnbID As String)
        Dim PayID As String = GetPayID()
        LoadPayrollDetails(PayCrewOnbID) 'Payroll Details
        LoadPayCrewDetails(PayCrewOnbID) 'Pay Crew Details
        LoadPayExRate(PayID) 'ExRate
        LoadPayONB(PayCrewOnbID) 'Pay_ONB
        LoadPayInfo(PayCrewOnbID) 'PayINFO
    End Sub

    Private Sub LoadPayrollDetails(PayCrewID As String)
        txtPeriod.Text = IfNull(cboPeriod.Text, "")
        txtRefNo.Text = IfNull(CrewListView.GetFocusedRowCellValue("RefNo"), "")
        txtDateCreated.Text = IfNull(CrewListView.GetFocusedRowCellValue("DateCreated"), "")
        txtVsl.Text = IfNull(CrewListView.GetFocusedRowCellValue("VslName"), "")
        txtPrincipal.Text = IfNull(CrewListView.GetFocusedRowCellValue("PrincipalName"), "")
    End Sub

    Private Sub LoadPayCrewDetails(PayCrewID As String)
        txtCrewName.Text = IfNull(CrewListView.GetFocusedRowCellValue("CrewName"), "")
        txtRank.Text = IfNull(CrewListView.GetFocusedRowCellValue("RankName"), "")
        txtStatus.Text = IfNull(CrewListView.GetFocusedRowCellValue("Status"), "")
        txtWageScaleName.Text = IfNull(CrewListView.GetFocusedRowCellValue("WageScaleName"), "")
    End Sub

    Private Sub ClearPayCrewDetails()
        txtCrewName.Text = Nothing
        txtRank.Text = Nothing
        txtStatus.Text = Nothing
        txtWageScaleName.Text = Nothing
        txtPeriod.Text = Nothing
        txtRefNo.Text = Nothing
        txtDateCreated.Text = Nothing
        txtVsl.Text = Nothing
        txtPrincipal.Text = Nothing

        txtTotalEarn.Text = "0.0"
        txtTotalDed.Text = "0.0"
        txtBalDue.Text = "0.0"
        txtPrevMon.Text = "0.0"
    End Sub

    Private Sub CrewListView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles CrewListView.FocusedRowObjectChanged
        LoadSelectedItems(GetPayCrewOnbID)
        PayrollLock()
    End Sub

    'Private Sub CrewListView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles CrewListView.FocusedRowChanged
    '    'If CrewListView.DataRowCount > 0 Then
    '    LoadSelectedItems(GetPayCrewOnbID)
    '    'End If
    'End Sub

    Private Sub CrewListView_GotFocus(sender As Object, e As System.EventArgs) Handles CrewListView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Crew from Payroll")
    End Sub

    Private Sub CrewListView_LostFocus(sender As Object, e As System.EventArgs) Handles CrewListView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    'Private Sub CrewListView_FocusedRowLoaded(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles CrewListView.FocusedRowLoaded
    '    If CrewListView.DataRowCount > 0 Then
    '        LoadSelectedItems(GetPayCrewOnbID)
    '    End If
    'End Sub

    Private Sub CrewListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewListView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub


#End Region

#Region "Ex Rate"

    Private Sub LoadPayExRate(PayID As String)
        ExRateView.ActiveFilter.NonColumnFilter = "FKeyPay ='" & PayID & "'"
    End Sub

    Private Sub ExRateView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ExRateView.CellValueChanged
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _v.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub ExRateView_GotFocus(sender As Object, e As System.EventArgs) Handles ExRateView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Currency")
    End Sub

    Private Sub ExRateView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ExRateView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _v
            .SetRowCellValue(e.RowHandle, "FKeyPay", GetPayID())
            .SetRowCellValue(e.RowHandle, "Edited", True)
        End With
    End Sub

    Private Sub ExRateView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles ExRateView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub ExRateView_LostFocus(sender As Object, e As System.EventArgs) Handles ExRateView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub ExRateView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ExRateView.RowCellStyle
        ViewRowCellStyle(sender, e, "ExRate;FKeyCurr")
    End Sub


#End Region

#Region "Pay Onboard"

    Private Function FilterCurrencyTable() As DataTable
        Dim ctbl As New DataTable
        Dim strFilter As String = ""
        Dim dv As DataView = ExRateView.DataSource
        dv.RowFilter = "FKeyPay = '" & GetPayID() & "'"


        'If Not IsNothing(ExRateGrid.DataSource) Then
        If dv.Count > 0 Then
            For Each dr As DataRowView In dv
                strFilter = "'" & dr("FKeyCurr") & "'," & strFilter
            Next
            strFilter = strFilter.Substring(0, Len(strFilter) - 1)
            strFilter = "PKey IN (" & strFilter & ")"
            If tbladmCurr.Select(strFilter).Length > 0 Then
                ctbl = tbladmCurr.Select(strFilter).CopyToDataTable
            Else
                ctbl = tbladmCurr
            End If
        End If
        'End If

        Return ctbl
    End Function

    Private Sub ReloadRepositoryCurr(_view As DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            If .FocusedColumn.FieldName.Equals("FKeyCurr") And (TypeOf (.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                edit.Properties.DataSource = FilterCurrencyTable()
            End If
        End With
    End Sub

    Private Sub LoadPayONB(PayCrewID As String)
        LoadEarning(PayCrewID)
        LoadAccumEarn(PayCrewID)
        LoadDeduction(PayCrewID)
        txtPrevMon.Text = GetPrevBal()
        GetBalanceDue()
    End Sub

    Private Sub GetBalanceDue()
        txtBalDue.Text = CDbl(IfNull(txtPrevMon.Text, CDbl(0))) + (CDbl(IfNull(txtTotalEarn.Text, CDbl(0))) - CDbl(IfNull(txtTotalDed.Text, CDbl(0)))) 'With Deduction
    End Sub

    Private Function GetDateStart() As Date
        Return CDate(CrewListView.GetFocusedRowCellValue("DateStart")).ToString("yyyy-MM-dd")
    End Function

    Private Function GetDateEnd() As Date
        Return CDate(CrewListView.GetFocusedRowCellValue("DateEnd")).ToString("yyyy-MM-dd")
    End Function

    Private Sub ViewValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            With _view
                If e.Value.Equals(Nothing) Or e.Value.Equals(System.DBNull.Value) Then
                    e.Valid = False
                    .SetColumnError(.FocusedColumn, "Invalid Input.")
                Else
                    If IfNull(Trim(e.Value), "").Equals("") Then
                        e.Valid = False
                        .SetColumnError(.FocusedColumn, "Invalid Input.")
                    Else
                        .SetColumnError(.FocusedColumn, "")
                    End If
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

#Region "Earning"

    Private Sub LoadEarning(PayCrewID As String)
        EarnView.ActiveFilter.NonColumnFilter = "FKeyPayCrewONB= '" & PayCrewID & "'"
        With EarnView
            .BeginSort()
            .Columns("FKeyWageOnb").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            .Columns("FKeyWageOnb").SortOrder = ColumnSortOrder.Ascending
            .EndSort()
        End With
        SumEarnings(PayCrewID)
    End Sub

    Private Sub SumEarnings(PayCrewID As String)
        If Not IsNothing(tblPay_ONB) Then
            Dim dt As DataTable = tblPay_ONB
            If dt.Rows.Count > 0 Then
                txtTotalEarn.Text = Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayCrewONB= '" & PayCrewID & "' AND WageType = 1 And Accum = 0 "), CDbl(0)), 2, MidpointRounding.AwayFromZero)
            End If
        End If
    End Sub

    Private Sub EarnView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EarnView.CellValueChanged
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _v.SetRowCellValue(e.RowHandle, "Edited", True)
        End If

        '<!-- added by tony20171023
        If e.Column.FieldName.Equals("FKeyCurr") Then
            If _v.GetRowCellValue(_v.FocusedRowHandle, "Amt").Equals(DBNull.Value) Then
                _v.SetRowCellValue(_v.FocusedRowHandle, "Amt", 0)
            End If
            UpdateAmountAfterCurrChange(_v, IfNull(_v.GetRowCellValue(_v.FocusedRowHandle, "Amt"), 0))

        ElseIf e.Column.FieldName.Equals("FKeyWageOnb") Then
            If _v.GetRowCellValue(_v.FocusedRowHandle, "Amt").Equals(DBNull.Value) Then
                _v.SetRowCellValue(_v.FocusedRowHandle, "Amt", 0)
            End If
        End If
        '-->
    End Sub

    Private Sub EarnView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EarnView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        With _v
            .SetRowCellValue(e.RowHandle, "FKeyPayCrewONB", GetPayCrewOnbID)
            .SetRowCellValue(e.RowHandle, "WageType", 1)
            .SetRowCellValue(e.RowHandle, "FullAmt", 0.0)
            .SetRowCellValue(e.RowHandle, "Prorata", False)
            .SetRowCellValue(e.RowHandle, "Accum", False)
            '.SetRowCellValue(e.RowHandle, "PreviousBalance", 0.0)
            '.SetRowCellValue(e.RowHandle, "ForwardingBalance", 0.0)
            '.SetRowCellValue(e.RowHandle, "WageRecID", String.Empty)

            '<!-- edited by tony20171024
            'Set DateStart and DateEnd
            'If .FocusedColumn.FieldName.Equals("FKeyWageOnb") Then
            _v.SetRowCellValue(e.RowHandle, "DateStart", GetDateStart)
            _v.SetRowCellValue(e.RowHandle, "DateEnd", GetDateEnd)
            'End If
            '-->

            'Set Full Amount
            If .FocusedColumn.FieldName.Equals("Amt") Then
                _v.SetRowCellValue(e.RowHandle, "FullAmt", .GetRowCellValue(e.RowHandle, "Amt"))
            End If

        End With
    End Sub



    Private Sub EarnView_GotFocus(sender As Object, e As System.EventArgs) Handles EarnView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Payment")
    End Sub

    Private Sub EarnView_LostFocus(sender As Object, e As System.EventArgs) Handles EarnView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub EarnView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles EarnView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub EarnView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EarnView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr,DateStarted,DateEnd,Amt,FKeyWageOnb")
    End Sub

    Private Sub EarnView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles EarnView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EarnView_ShownEditor(sender As Object, e As System.EventArgs) Handles EarnView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
    End Sub

    Private Sub EarnView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles EarnView.ValidateRow
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        With _V
            'Amount
            If .GetRowCellValue(e.RowHandle, "Amt") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "Amt") Is Nothing Then
                .SetColumnError(.Columns("Amt"), "Invalid Amount")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("Amt"), "")
            End If
            'FKeyCurr
            If .GetRowCellValue(e.RowHandle, "FKeyCurr") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "Amt") Is Nothing Then
                .SetColumnError(.Columns("FKeyCurr"), "Invalid Currency")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("FKeyCurr"), "")
            End If


            'DateStart
            If .GetRowCellValue(e.RowHandle, "DateStart") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "DateStart") Is Nothing Then
                .SetColumnError(.Columns("DateStart"), "Invalid Date")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("DateStart"), "")
            End If

            'DateEnd
            If .GetRowCellValue(e.RowHandle, "DateEnd") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "DateEnd") Is Nothing Then
                .SetColumnError(.Columns("DateEnd"), "Invalid Date")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("DateEnd"), "")
            End If

            'FKeyWageOnb
            If .GetRowCellValue(e.RowHandle, "FKeyWageOnb") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "FKeyWageOnb") Is Nothing Then
                .SetColumnError(.Columns("FKeyWageOnb"), "Invalid Wage Type")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("FKeyWageOnb"), "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub

    Private Sub EarnView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles EarnView.ValidatingEditor
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetExRate(sender, e) 'Set ExRate
        If _V.FocusedColumn.FieldName.Equals("Amt") Then
            Dim dv As DataView = ExRateView.DataSource
            dv.Sort = "FKeyCurr"
            Dim xrow As DataRowView() = dv.FindRows(GetRefCurrency)
            Dim Amt As Double = 0, ExRate As Double = 0, RefAmt As Double = 0, RefExRate As Double = 0
            Amt = CDbl(e.Value)
            ExRate = CDbl(IfNull(_V.GetFocusedRowCellValue("ExRate"), 0))
            RefExRate = CDbl(xrow(0)("ExRate"))
            RefAmt = Amt / ExRate
            _V.SetFocusedRowCellValue("CAmt", RefAmt * RefExRate)
            _V.SetFocusedRowCellValue("FullAmt", Amt)
        End If

        ViewValidatingEditor(sender, e)
    End Sub

    Private Function SetExRate(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) As Double
        Dim retval As Double = 0
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If _V.FocusedColumn.FieldName.Equals("FKeyCurr") Then
            Dim dv As DataView = ExRateView.DataSource
            dv.RowFilter = "FKeyPay = '" & GetPayID() & "'"
            dv.Sort = "FKeyCurr"
            'Dim xrow As DataRowView() = dv.FindRows(e.Value)
            'Dim ExRate As Double = xrow(0)("ExRate")
            Dim drExRate As DataRow = dv.ToTable.Select("FKeyPay='" & GetPayID() & "' AND FKeyCurr = '" & e.Value & "'").FirstOrDefault
            Dim ExRate As Double = drExRate.Item("ExRate")
            _V.SetFocusedRowCellValue("ExRate", ExRate)
        End If

        If _V.FocusedColumn.FieldName.Equals("Amt") Then
            Dim dv As DataView = ExRateView.DataSource
            dv.Sort = "FKeyCurr"
            'Dim xrow As DataRowView() = dv.FindRows(GetRefCurrency)
            Dim drExRate As DataRow = dv.ToTable.Select("FKeyPay='" & GetPayID() & "' AND FKeyCurr = '" & GetRefCurrency() & "'").FirstOrDefault
            Dim Amt As Double = 0, ExRate As Double = 0, RefAmt As Double = 0, RefExRate As Double = 0
            Amt = CDbl(e.Value)
            ExRate = CDbl(IfNull(_V.GetFocusedRowCellValue("ExRate"), 1))
            RefExRate = CDbl(drExRate.Item("ExRate"))
            RefAmt = Amt / ExRate
            _V.SetFocusedRowCellValue("CAmt", RefAmt * RefExRate)
        End If
        Return retval
    End Function

#End Region

#Region "Accumulating"

    Private Sub LoadAccumEarn(PayCrewID As String)
        AccumView.ActiveFilter.NonColumnFilter = "FKeyPayCrewONB= '" & PayCrewID & "'"
        With AccumView
            .BeginSort()
            .Columns("FKeyWageOnb").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            .Columns("FKeyWageOnb").SortOrder = ColumnSortOrder.Ascending
            .EndSort()
        End With
        SumAccum(PayCrewID)
    End Sub

    Private Sub AccumView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AccumView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub SumAccum(PayCrewID As String)
        If Not IsNothing(tblPay_ONB) Then
            Dim dt As DataTable = tblPay_ONB
            If dt.Rows.Count > 0 Then
                'txtTotalAccumBal.Text = Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayCrewONB= '" & PayCrewID & "' AND WageType = 1 And Accum = 1 "), CDbl(0)), 2, MidpointRounding.AwayFromZero)
                txtTotalAccumBal.Text = Math.Round(IfNull(dt.Compute("SUM(CAmt) + SUM(PreviousBalance)", "FKeyPayCrewONB= '" & PayCrewID & "' AND WageType = 1 And Accum = 1 "), CDbl(0)), 2, MidpointRounding.AwayFromZero)
            End If
        End If
    End Sub


#End Region

#Region "Deduction"

    Private Sub LoadDeduction(PayCrewID As String)
        DedView.ActiveFilter.NonColumnFilter = "FKeyPayCrewONB='" & PayCrewID & "'"
        With DedView
            .BeginSort()
            .Columns("FKeyWageOnb").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            .Columns("FKeyWageOnb").SortOrder = ColumnSortOrder.Ascending
            .EndSort()
        End With
        SumDeduction(PayCrewID)

    End Sub

    Private Sub SumDeduction(PayCrewID As String)
        If Not IsNothing(tblPay_ONB) Then
            Dim dt As DataTable = tblPay_ONB
            If dt.Rows.Count > 0 Then
                txtTotalDed.Text = Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayCrewONB= '" & PayCrewID & "' AND WageType = 2 "), CDbl(0)), 2, MidpointRounding.AwayFromZero)
            End If
        End If
    End Sub

    Private Sub DedView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DedView.CellValueChanged
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _v.SetRowCellValue(e.RowHandle, "Edited", True)
        End If

        '<!-- added by tony20171023
        If e.Column.FieldName.Equals("FKeyCurr") Then
            If _v.GetRowCellValue(_v.FocusedRowHandle, "Amt").Equals(DBNull.Value) Then
                _v.SetRowCellValue(_v.FocusedRowHandle, "Amt", 0)
            End If
            UpdateAmountAfterCurrChange(_v, IfNull(_v.GetRowCellValue(_v.FocusedRowHandle, "Amt"), 0))

        ElseIf e.Column.FieldName.Equals("FKeyWageOnb") Then
            If _v.GetRowCellValue(_v.FocusedRowHandle, "Amt").Equals(DBNull.Value) Then
                _v.SetRowCellValue(_v.FocusedRowHandle, "Amt", 0)
            End If
        End If
        '-->
    End Sub

    Private Sub DedView_GotFocus(sender As Object, e As System.EventArgs) Handles DedView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Deduction")
    End Sub

    Private Sub DedView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DedView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _v
            .SetRowCellValue(e.RowHandle, "FKeyPayCrewONB", GetPayCrewOnbID)
            .SetRowCellValue(e.RowHandle, "WageType", 2)
            .SetRowCellValue(e.RowHandle, "FullAmt", 0.0)
            .SetRowCellValue(e.RowHandle, "Prorata", False)
            .SetRowCellValue(e.RowHandle, "Accum", False)

            '.SetRowCellValue(e.RowHandle, "PreviousBalance", 0.0)
            '.SetRowCellValue(e.RowHandle, "ForwardingBalance", 0.0)
            '.SetRowCellValue(e.RowHandle, "WageRecID", String.Empty)


            'Set DateStart and DateEnd
            'If .FocusedColumn.FieldName.Equals("FKeyWageOnb") Then
            _v.SetRowCellValue(e.RowHandle, "DateStart", GetDateStart)
            _v.SetRowCellValue(e.RowHandle, "DateEnd", GetDateEnd)
            'End If

            'Set Full Amount
            'If .FocusedColumn.FieldName.Equals("Amt") Then
            'End If
        End With
    End Sub

    Private Sub DedView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles DedView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub DedView_LostFocus(sender As Object, e As System.EventArgs) Handles DedView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub DedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DedView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr,DateStarted,DateEnd,Amt,FKeyWageOnb")

    End Sub

    Private Sub DedView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles DedView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub DedView_ShownEditor(sender As Object, e As System.EventArgs) Handles DedView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
    End Sub

    Private Sub DedView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DedView.ValidateRow
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        With _V
            'Amount
            If .GetRowCellValue(e.RowHandle, "Amt") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "Amt") Is Nothing Then
                .SetColumnError(.Columns("Amt"), "Invalid Amount")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("Amt"), "")
            End If
            'FKeyCurr
            If .GetRowCellValue(e.RowHandle, "FKeyCurr") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "Amt") Is Nothing Then
                .SetColumnError(.Columns("FKeyCurr"), "Invalid Currency")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("FKeyCurr"), "")
            End If


            'DateStart
            If .GetRowCellValue(e.RowHandle, "DateStart") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "DateStart") Is Nothing Then
                .SetColumnError(.Columns("DateStart"), "Invalid Date")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("DateStart"), "")
            End If

            'DateEnd
            If .GetRowCellValue(e.RowHandle, "DateEnd") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "DateEnd") Is Nothing Then
                .SetColumnError(.Columns("DateEnd"), "Invalid Date")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("DateEnd"), "")
            End If

            'FKeyWageOnb
            If .GetRowCellValue(e.RowHandle, "FKeyWageOnb") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "FKeyWageOnb") Is Nothing Then
                .SetColumnError(.Columns("FKeyWageOnb"), "Invalid Wage Type")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("FKeyWageOnb"), "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub

    Private Sub DedView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DedView.ValidatingEditor
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        SetExRate(sender, e) 'Set ExRate

        'If _V.FocusedColumn.FieldName.Equals("FKeyCurr") Then
        '    Dim dv As DataView = ExRateView.DataSource
        '    dv.Sort = "FKeyCurr"
        '    Dim xrow As DataRowView() = dv.FindRows(e.Value)
        '    Dim ExRate As Double = xrow(0)("ExRate")
        '    _V.SetFocusedRowCellValue("ExRate", ExRate)
        'End If

        If _V.FocusedColumn.FieldName.Equals("Amt") Then
            Dim dv As DataView = ExRateView.DataSource
            dv.Sort = "FKeyCurr"
            Dim xrow As DataRowView() = dv.FindRows(GetRefCurrency)
            Dim Amt As Double = 0, ExRate As Double = 0, RefAmt As Double = 0, RefExRate As Double = 0
            Amt = CDbl(e.Value)
            ExRate = CDbl(_V.GetFocusedRowCellValue("ExRate"))
            RefExRate = CDbl(xrow(0)("ExRate"))
            RefAmt = Amt / ExRate
            _V.SetFocusedRowCellValue("CAmt", RefAmt * RefExRate)
            _V.SetFocusedRowCellValue("FullAmt", Amt)
        End If

        ViewValidatingEditor(sender, e)
    End Sub


#End Region

#End Region

#Region "PayInfo"

    Private Sub LoadPayInfo(PayCrewID As String)
        PayInfoView.ActiveFilter.NonColumnFilter = "PayCrewONB='" & PayCrewID & "'"
        With PayInfoView
            .BeginSort()
            .Columns("FKeyWageInfo").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            .Columns("FKeyWageInfo").SortOrder = ColumnSortOrder.Ascending
            .EndSort()
        End With
    End Sub

    Private Sub PayInfoView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles PayInfoView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#Region "Re-Process Payroll"

    Private Function GetCrewName() As String
        Return IfNull(CrewListView.GetFocusedRowCellValue("CrewName") & " - " &
                      CrewListView.GetFocusedRowCellValue("RankName"), "")
    End Function

#End Region

    Private Sub RunPayroll()
        GroupControl1.Focus()
        Dim PayCrewActID As String = String.Empty
        If CrewListView.RowCount > 0 Then
            If MsgBox("Are you sure you want to Reprocess Crew " & GetCrewName() & "?", MsgBoxStyle.Question + MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                PayCrewActID = GetPayCrewActID()
                Dim info As Boolean = True
                info = ReprocessCrew()
                If info Then
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                    bLoaded = False
                    'cboPeriod.EditValue = Nothing
                    'RefreshData()
                    RefreshDataSet()
                    SetSelectionReProcessedCrew(PayCrewActID)
                Else
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                End If
            End If
        Else
            MsgBox("Please select a Crew to reprocess.", MsgBoxStyle.Information, GetAppName)
        End If


    End Sub

    Private Sub SetSelectionReProcessedCrew(id As String)
        Try
            Dim rowHandle As Integer = 0
            rowHandle = CrewListView.LocateByValue(0, CrewListView.Columns("ActID"), id)
            CrewListView.FocusedRowHandle = rowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetPayCrewActID() As String
        Return IfNull(CrewListView.GetFocusedRowCellValue("ActID"), "")
    End Function

    Private Function ReprocessCrew() As Boolean
        ShowCustomLoadScreen(GetType(PayrollWaitForm))
        Dim retval As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction
            'Dim tblPayCrewDT As DataTable = TryCast(PayCrewView.DataSource, DataView).ToTable(True, New String() {"ActID", "IDNbr", "FKeyVslCode", "FkeyWScaleCode", "FKeyWScaleRankCode"})

            Dim SelCrew() As Integer = CrewListView.GetSelectedRows
            For index = 0 To SelCrew.Count - 1
                'Delete Pay Crew
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTran
                    cmd.CommandText = "DELETE FROM dbo.tblPayCrew_ONB WHERE PKey = '" & CrewListView.GetRowCellValue(SelCrew(index), "PKey") & "' "
                    retval = (cmd.ExecuteNonQuery > 0)
                End Using
            Next

            Dim ExRateDT As DataTable = TryCast(ExRateView.DataSource, DataView).ToTable(True, New String() {"FKeyCurr", "ExRate"})
            Dim DTs As DataTable = TryCast(CrewListView.DataSource, DataView).ToTable(True, New String() {"ActID",
                                                                                              "FKeyIDNbr",
                                                                                              "FKeyWScaleCode",
                                                                                              "FKeyWscalRankCode",
                                                                                              "FKeyPayID",
                                                                                              "FKeyVsl",
                                                                                              "RefNo",
                                                                                              "FKeyPrincipal"}).Clone
            For index = 0 To SelCrew.Count - 1
                Dim dr As DataRow = DTs.NewRow
                With CrewListView
                    dr("ActID") = .GetRowCellValue(SelCrew(index), "ActID")
                    dr("FKeyIDNbr") = .GetRowCellValue(SelCrew(index), "FKeyIDNbr")
                    dr("FKeyWScaleCode") = .GetRowCellValue(SelCrew(index), "FKeyWScaleCode")
                    dr("FKeyWscalRankCode") = .GetRowCellValue(SelCrew(index), "FKeyWscalRankCode")
                    dr("FKeyPayID") = .GetRowCellValue(SelCrew(index), "FKeyPayID")
                    dr("FKeyVsl") = .GetRowCellValue(SelCrew(index), "FKeyVsl")
                    dr("RefNo") = .GetRowCellValue(SelCrew(index), "RefNo")
                    dr("FKeyPrincipal") = .GetRowCellValue(SelCrew(index), "FKeyPrincipal")
                End With
                DTs.Rows.Add(dr)
            Next

            For Each crewDR As DataRow In New DataView(DTs).ToTable(True, New String() {"FKeyPayID", "FKeyVsl", "RefNo", "FKeyPrincipal"}).Rows
                Dim CrewlistDTV As DataView = New DataView(DTs)
                Dim RefNo As String = String.Empty
                Dim FKeyPrincipal As String = String.Empty
                Dim tblPayCrewDT As New DataTable

                With CrewlistDTV
                    .RowFilter = "FKeyPayID='" & crewDR.Item("FKeyPayID").ToString & "'"
                    RefNo = crewDR.Item("RefNo").ToString
                    FKeyPrincipal = crewDR.Item("FKeyPrincipal").ToString
                    tblPayCrewDT = CrewlistDTV.ToTable(True, New String() {"ActID", "FKeyIDNbr", "FKeyVsl", "FKeyWScaleCode", "FKeyWscalRankCode"})
                End With

                'Reprocess Crew
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTran
                    cmd.CommandText = "SP_ProcessPayONB"
                    cmd.CommandType = CommandType.StoredProcedure
                    With cmd.Parameters
                        .AddWithValue("@ProcessType", True)
                        .AddWithValue("@PeriodDateStart", NumCodeToDate(cboPeriod.EditValue, 1))
                        .AddWithValue("@DateCreated", txtDateCreated.Text)
                        .AddWithValue("@RefNo", RefNo)
                        .AddWithValue("@FKeyPrincipal", FKeyPrincipal)
                        .AddWithValue("@tblPayCrew", tblPayCrewDT)
                        .AddWithValue("@tblExRate", ExRateDT)
                        .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                    End With
                    retval = (cmd.ExecuteNonQuery > 0)
                End Using
            Next

            If retval Then
                sqlTran.Commit()
            End If
        Catch ex As Exception
            sqlTran.Rollback()
            retval = False
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try

        CloseCustomLoadScreen()
        Return retval
    End Function

    Private Sub GetSelectedPay()
        If frmPayrollList.ApplyFilter Then
            RefreshDataSet()
            cboPeriod.EditValue = frmPayrollList.PayPeriod
            cboPrincipal.EditValue = frmPayrollList.PayPrincipal
            cboVessel.SetEditValue(frmPayrollList.PayVessel)
            cboVessel.RefreshEditValue()
            FilterRefNoList()
            cboRefNo.SetEditValue(frmPayrollList.PayPayID)
            cboRefNo.RefreshEditValue()

            FilterCrewList() 'neil
        End If
        PayrollLock()
    End Sub

    Private Sub ClearControlEverything()
        'Throw New NotImplementedException
        cboPeriod.EditValue = Nothing
        cboPrincipal.EditValue = Nothing
        ClearCheckLookUp(cboVessel)
        ClearCheckLookUp(cboRefNo)
    End Sub

#Region "Reportings"

    'Show Pay Reports
    Private Sub ShowPayReports()
        'Throw New NotImplementedException
        RptControl.ShowPayrollReport(cboPeriod.EditValue, cboPrincipal.EditValue, cboVessel.EditValue, cboRefNo.EditValue)
    End Sub

#End Region

    Private Sub ControlValidations() Handles cboPeriod.EditValueChanged, cboPrincipal.EditValueChanged, cboVessel.EditValueChanged, cboRefNo.EditValueChanged
        If IsNothing(cboPeriod.EditValue) Then
            cboPrincipal.Enabled = False
            cboVessel.Enabled = False
            cboRefNo.Enabled = False
        Else
            If Len(cboPeriod.EditValue) <= 0 Then
                cboPrincipal.Enabled = False
                cboVessel.Enabled = False
                cboRefNo.Enabled = False
            Else
                cboPrincipal.Enabled = True
                cboVessel.Enabled = True
                cboRefNo.Enabled = True
            End If
        End If



    End Sub

#Region "Layout Saving"

    Public Overrides Sub SaveMainContentLayout()
        SaveUserSetting(Me.Name & SplitContainerControl1.Name & "_LAYOUT", SplitContainerControl1.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl2.Name & "_LAYOUT", SplitContainerControl2.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl3.Name & "_LAYOUT", SplitContainerControl3.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl5.Name & "_LAYOUT", SplitContainerControl5.SplitterPosition.ToString)
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        'MyBase.LoadMainContentLayout()
        SplitContainerControl1.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl1.Name & "_LAYOUT", Layout_S1.ToString))
        SplitContainerControl2.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl2.Name & "_LAYOUT", Layout_S2.ToString))
        SplitContainerControl3.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl3.Name & "_LAYOUT", Layout_S3.ToString))
        SplitContainerControl5.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl5.Name & "_LAYOUT", Layout_S5.ToString))
    End Sub

    Public Overrides Sub ResetMainContentLayout()
        'MyBase.ResetMainContentLayout()
        SplitContainerControl1.SplitterPosition = Layout_S1
        SplitContainerControl2.SplitterPosition = Layout_S2
        SplitContainerControl3.SplitterPosition = Layout_S3
        SplitContainerControl5.SplitterPosition = Layout_S5
        SaveMainContentLayout()
    End Sub

#End Region

    Private Sub CrewListView_RowCountChanged(sender As Object, e As System.EventArgs) Handles CrewListView.RowCountChanged
        EdiDeleteAllow(sender)
    End Sub

    Private Sub EdiDeleteAllow(sender As Object)
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _v.RowCount > 0 Then
            AllowEditing(Name, True)
            AllowDeletion(Name, True)
        Else
            AllowEditing(Name, False)
            AllowDeletion(Name, False)
        End If
    End Sub

#Region "Payroll Lock Feature"
    Private Sub PayrollLock()
        If CrewListView.RowCount > 0 Then
            If CrewListView.GetFocusedRowCellValue("isLocked") Then
                txtPayStatus.Text = "Locked"
                txtPayStatus.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                txtPayStatus.Properties.Appearance.ForeColor = System.Drawing.Color.Red
                AllowCalculatePay(Name, False)
                AllowEditing(Name, False)
                AllowDeletion(Name, False)
                AllowSaving(Name, False)


                EditSubAllowGrid(Me.ExRateView, False)
                EditSubAllowGrid(Me.EarnView, False)
                'EditSubAllowGrid(Me.AccumView, False)
                EditSubAllowGrid(Me.CrewListView, False)
                EditSubAllowGrid(Me.DedView, False)
                EditSubAllowGrid(Me.PayInfoView, False)

            Else
                txtPayStatus.Text = "Unlocked"
                AllowCalculatePay(Name, isEditdable)
                AllowEditing(Name, True)
                AllowSaving(Name, isEditdable)
                AllowDeletion(Name, True)
                txtPayStatus.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                txtPayStatus.Properties.Appearance.ForeColor = System.Drawing.Color.Green

                EditSubAllowGrid(Me.ExRateView, isEditdable, False)
                EditSubAllowGrid(Me.EarnView, isEditdable)
                'EditSubAllowGrid(Me.AccumView, isEditdable)
                EditSubAllowGrid(Me.CrewListView, isEditdable)
                EditSubAllowGrid(Me.DedView, isEditdable)
                EditSubAllowGrid(Me.PayInfoView, isEditdable)

            End If
        End If
    End Sub
#End Region

    Private Sub SetPayCrewListSelection(ID As String)
        Try
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = CrewListView.Columns("PKey")
            RowHandle = CrewListView.LocateByValue(0, Col, ID)
            CrewListView.FocusedRowHandle = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Dim stopnaba As Boolean = False

    Private Sub CrewListGrid_Click(sender As Object, e As System.EventArgs) Handles CrewListGrid.Click
        stopnaba = True
    End Sub

    Private Sub CrewListGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'AddHandler CrewListGrid.MouseMove, AddressOf clsgridflout.AddFlyOutEvent

        'AddHandler CrewListGrid.MouseClick, AddressOf clsgridflout.RemoveFlyOutEvent
    End Sub

    Private Sub EarnView_LeftCoordChanged(sender As Object, e As System.EventArgs) Handles EarnView.LeftCoordChanged

    End Sub

    Private Sub ExRateView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles ExRateView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CrewListView_ShownEditor(sender As Object, e As System.EventArgs) Handles CrewListView.ShownEditor
        stopnaba = True
    End Sub

    Sub UpdateAmountAfterCurrChange(_v As DevExpress.XtraGrid.Views.Grid.GridView, nAmount As Double)
        Dim dv As DataView = ExRateView.DataSource
        dv.Sort = "FKeyCurr"
        Dim Amt As Double = 0, ExRate As Double = 0, RefAmt As Double = 0, RefExRate As Double = 0
        Amt = CDbl(nAmount)
        ExRate = CDbl(IfNull(_v.GetFocusedRowCellValue("ExRate"), 1))
        RefAmt = Amt / ExRate
        _v.SetFocusedRowCellValue("CAmt", Amt * ExRate)
    End Sub
End Class