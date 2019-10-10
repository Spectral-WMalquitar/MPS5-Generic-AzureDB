Imports System.Windows.Forms

Public Class PayrollViewHA

#Region "Declarations"
    'Dim tblCrewList As New DataTable
    Dim isPayRollList As Boolean = False
    Dim tblPrincipal As New DataTable
    Dim tblVsl As New DataTable
    Dim tblAdmCurr As New DataTable
    Dim tblWageAsh As New DataTable
    Dim tblAdmCntry As New DataTable

    Dim DS As New DataSet
    Dim tblPay_HA As New DataTable
    Dim tblCrewHA As New DataTable
    Dim tblPayAllot As New DataTable
    Dim tblPayAsh As New DataTable
    Dim tblPayAshEmp As New DataTable
    Dim tblExRate As New DataTable

    Dim SelectedView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

    Private RptControl As PayrollReportControl
    Dim LastUpdatedBy As String '= "LastUpdatedBY"

    Dim _frmPayrollList As frmPayrollList

    Dim strRefCurr As String = String.Empty

    Dim clsgridflout As New clsGridFlyOut
    Dim clsAudit As New clsAudit

#Region "Layot Contants"
    Private Const Layout_S1 As Integer = 350
    Private Const Layout_S2 As Integer = 352
    Private Const Layout_S3 As Integer = 628
    Private Const Layout_S5 As Integer = 313
#End Region
#End Region

#Region "Initialize"

    Private Function InitDTVessel() As DataTable
        Dim cTbl As New DataTable
        Dim vslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, " WHERE " & GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
        cTbl = DB.CreateTable("SELECT * FROM dbo.VslList " & vslFilter & "ORDER BY Name")
        Return cTbl
    End Function

    Private Sub InitControls()
        ClearFields(LayoutControlGroup_CrewListCriteria, False)
        LayoutControl1.AllowCustomization = False
        LayoutControl2.AllowCustomization = False
        TabbedControlGroup3.SelectedTabPageIndex = 0 'Select the First Tab on Init Load
        _frmPayrollList = New frmPayrollList("HA")
        cboPeriod.Properties.DataSource = GetPayPeriods("MONTH", 60, 3)
        tblAdmCurr = DB.CreateTable("SELECT * FROM dbo.tblAdmCurr ORDER BY Name")
        tblAdmCntry = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name")

        Dim prinFilter As String = IIf(GetUserFilterString(, , "PKey").Length > 0, " WHERE " & GetUserFilterString(, , "PKey"), "")
        tblPrincipal = DB.CreateTable("SELECT * FROM dbo.PrincipalList " & prinFilter & " ORDER BY Name")
        cboPrincipal.Properties.DataSource = tblPrincipal

        Dim vslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, " WHERE " & GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
        tblVsl = DB.CreateTable("SELECT * FROM dbo.VslList " & vslFilter & "ORDER BY Name")
        cboVessel.Properties.DataSource = InitDTVessel()
        repERFKeyCurr.DataSource = tblAdmCurr 'ExRate Currency
        TabbedControlGroup1.SelectedTabPageIndex = 0

        InitControlsAllottee()
        InitControlsAsh()
        InitControlsAshEmp()

        SplitContainerControl2.SplitterPosition = SplitContainerControl1.Height * 0.8   '<-- added by tony20171006 - the exchange rate grid should auto adjust its height

        'Init Reports 
        InitReportControls()

        clsAudit.propSQLConnStr = DB.GetConnectionString

        SetProcessedPayrollListVisibility(Name, True)


    End Sub

    Private Sub InitControlsAllottee()
        repAllotBank.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmBank ORDER BY Name")
        repAllotBranch.DataSource = DB.CreateTable("SELECT * FROM dbo.FrmBranchList ORDER BY Name")
        repAllotCntry.DataSource = tblAdmCntry
        repAllotFKeyCurr.DataSource = tblAdmCurr
    End Sub

    Private Sub InitControlsAsh()
        tblWageAsh = DB.CreateTable("SELECT * FROM dbo.tblAdmWageAsh ORDER BY Name")
        repEarnAsh.DataSource = tblWageAsh.Select("WageType=1").CopyToDataTable
        repDedAsh.DataSource = tblWageAsh.Select("WageType=2").CopyToDataTable
        repAmortWagesAsh.DataSource = tblWageAsh.Select("WageType=2").CopyToDataTable
        repEAshFKeyCurr.DataSource = tblAdmCurr
        repDAshFKeyCurr.DataSource = tblAdmCurr
        repAmortFKeyCurr.DataSource = tblAdmCurr

    End Sub

    Private Sub InitControlsAshEmp()
        repAshEmp.DataSource = DB.CreateTable("SELECT * FROM dbo.tbladmWageAshEmp ORDER BY Name")
        repAshEmpFKeyCurr.DataSource = tblAdmCurr
        'repAshEmpFKeyCurr.DataSource = ExRateView.DataSource
    End Sub

    Private Function InitRefNo() As DataTable
        Dim retVal As DataTable
        Dim dvRef As New DataView(tblPay_HA)
        retVal = tblPay_HA
        Return retVal
    End Function

    Private Sub GenerateDataSet(MCode As Integer)
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandText = "SP_PayHA_LIST"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@MCode", MCode)
                'Fill Tables
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(DS, "PayHA")
                    With DS
                        .Tables(0).TableName = "Pay"
                        tblPay_HA = .Tables("Pay")
                        .Tables(1).TableName = "HA"
                        tblCrewHA = .Tables("HA") 'Pay Crew Ha
                        .Tables(2).TableName = "PayAllot"
                        tblPayAllot = .Tables("PayAllot") 'tblPay_Allot
                        .Tables(3).TableName = "PayAsh"
                        tblPayAsh = .Tables("PayAsh") 'tblPayAsh
                        .Tables(4).TableName = "AshEmp"
                        tblPayAshEmp = .Tables("AshEmp") 'tblPayAshEmp
                        .Tables(5).TableName = "PayExRate"
                        tblExRate = .Tables("PayExRate") 'tblPayExRate
                    End With
                End Using
            End Using
            SetUpdDataSet() 'Set Relations
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try

    End Sub

#Region "Manual Refresh Of DataSet"

    Private Sub RefreshDataSet()
        BRECORDUPDATEDs = False
        Dim MCode As Integer = cboPeriod.EditValue
        ClearDS()
        GenerateDataSet(MCode)
        LoadSubItems()
    End Sub

#End Region


    Private Sub SetUpdDataSet()
        If tblCrewHA.Rows.Count > 0 And
            tblPayAllot.Rows.Count > 0 And
            tblPayAsh.Rows.Count > 0 And
            tblPayAshEmp.Rows.Count > 0 And
            tblExRate.Rows.Count > 0 Then
            With DS
                If Not .Relations.Contains("R_Pay_CrewHA") And
                    Not .Relations.Contains("R_CrewHa_Allot") And
                    Not .Relations.Contains("R_Ash_Allot") And
                    Not .Relations.Contains("R_CrewHA_AshEmp") And
                    Not .Relations.Contains("R_Pay_ExRate") Then
                    .Relations.Add("R_Pay_CrewHA", .Tables("Pay").Columns("PKey"), .Tables("HA").Columns("FKeyPayID"))
                    .Relations.Add("R_CrewHa_Allot", .Tables("HA").Columns("PKey"), .Tables("PayAllot").Columns("FKeyPayCrewHA"))
                    .Relations.Add("R_Ash_Allot", .Tables("PayAllot").Columns("PKey"), .Tables("PayAsh").Columns("FKeyPayAllotID"))
                    .Relations.Add("R_CrewHA_AshEmp", .Tables("HA").Columns("PKey"), .Tables("AshEmp").Columns("FKeyPayCrewHA"))
                    .Relations.Add("R_Pay_ExRate", .Tables("Pay").Columns("PKey"), .Tables("PayExRate").Columns("FKeyPay"))
                End If
            End With
        End If

    End Sub

    Private Sub InitReportControls()
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

#End Region

#Region "Clear Controls"

    Private Sub ClearSourceOfEverything()
        ClearCrewList()
        ClearVessel()
        ClearPrincipal()
        ClearExRate()
        ClearDS()
    End Sub

    Private Sub ClearCrewList()
        'tblCrewList = New DataTable()
        LoadSubItems()
    End Sub
    Private Sub ClearVessel()
        'tblVsl = New DataTable()
        tblVsl.Clear()
        ClearCheckLookUp(cboVessel)
        ClearCrewList()
    End Sub
    Private Sub ClearPrincipal()
        'tblPrincipal = New DataTable()
        tblPrincipal.Clear()
    End Sub
    Private Sub ClearExRate()
        'tblExRate = New DataTable()
        tblExRate.Clear()
    End Sub

    Private Sub ClearDS()
        DS.Clear()
        DS.Relations.Clear()
        For Each dt As DataTable In DS.Tables
            dt.Constraints.Clear()
        Next
        DS.Tables.Clear()
        ClearControls()

    End Sub

    Private Sub ClearControls()
        ClearFields(lcgCrewDetails, False)
        ClearFields(lcgPayrollDetails, False)
    End Sub

    'Clear Principal
    Private Sub cboPrincipal_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPrincipal.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)

        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
            LoadSubItems()
        End If
    End Sub

    'Clear Vessel
    Private Sub cboVessel_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboVessel.ButtonPressed
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

    'Clear Period
    Private Sub cboPeriod_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriod.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
            cboPrincipal.EditValue = Nothing
            ClearCheckLookUp(cboVessel)
            ClearCheckLookUp(cboRefNo)
        End If
    End Sub

    Private Sub cboRefNo_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRefNo.ButtonPressed
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ClearCheckLookUp(sender)
        End If
    End Sub

#End Region

#Region "Filter"

    Private Sub ClearGrid()
        EarnGrid.DataSource = Nothing
        DedGrid.DataSource = Nothing
        AllotteeGrid.DataSource = Nothing
        CrewListGrid.DataSource = Nothing
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        ClearDS()
        ClearGrid()
        GenerateDataSet(IfNull(LookUpEd.EditValue, 0))
        ControlValidations()
        'If Not isPayRollList Then  'Clear Controls
        cboPrincipal.EditValue = Nothing
        ClearCheckLookUp(cboVessel)
        ClearCheckLookUp(cboRefNo)
        'End If 'Clear Controls END
        LoadSubItems()
        cboRefNo.Properties.DataSource = InitRefNo()


    End Sub

    Private Sub cboVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVessel.EditValueChanged
        Dim lookupEd As DevExpress.XtraEditors.CheckedComboBoxEdit = TryCast(sender, DevExpress.XtraEditors.CheckedComboBoxEdit)
        ClearCheckLookUp(cboRefNo)
        ControlValidations()
        GetVesselFilter()
        'If Not IfNull(lookupEd.EditValue, "").Equals("") Then
        '    'Filter ReferenceNumber By Vessel
        '    Dim dvRef As New DataView(InitRefNo)
        '    dvRef.RowFilter = GetVesselFilter()
        '    cboRefNo.Properties.DataSource = dvRef
        '    cboRefNo.Properties.DropDownRows = 10
        'Else
        '    cboRefNo.Properties.DataSource = InitRefNo()
        '    cboRefNo.Properties.DropDownRows = 10
        'End If
        FilterCrewList()
        FilterRefNo()
    End Sub

    Private Sub cboPrincipal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPrincipal.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        ControlValidations()
        If Not isPayRollList Then
            ClearCheckLookUp(cboVessel)
            ClearCheckLookUp(cboRefNo)
        End If

        cboVessel.Properties.DataSource = tblVsl
        FilterVslList(LookUpEd.EditValue) 'filter Vsl Combobox
        FilterCrewList()
        FilterRefNo()
    End Sub

    Private Sub AllotteeView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles AllotteeView.FocusedRowChanged
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        LoadAllotteeOnChange(_v)
    End Sub
    Private Sub AllotteeView_FocusedRowLoaded(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles AllotteeView.FocusedRowLoaded
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        LoadAllotteeOnChange(_v)
    End Sub

    Private Sub LoadAllotteeOnChange(GView As DevExpress.XtraGrid.Views.Grid.GridView)
        If GView.DataRowCount > 0 Then
            lciBasicWage.Text = IfNull("Basic Wage [" & GView.GetFocusedRowCellDisplayText("FKeyBasicCurr") & "]", "Basic Wage")
            FilterAsh()
            FilterAshEmp()
        End If
    End Sub

    'Private Sub CrewListView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles CrewListView.FocusedRowChanged
    '    CrewListViewChange()
    '    PayrollLock()
    'End Sub

    Private Sub FilterAllottee()
        AllotteeView.ActiveFilter.NonColumnFilter = "FKeyPayCrewHA ='" & GetCrewPayID() & "' "
        With AllotteeView
            .BeginSort()
            .Columns("WAllot").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            .Columns("WAllot").SortOrder = ColumnSortOrder.Ascending
            .EndSort()
        End With
        FilterAsh()
    End Sub

    Private Sub FilterAsh()
        EarnView.ActiveFilter.NonColumnFilter = "FKeyPayAllotID = '" & GetPayAllotID() & "'" 'Earnings
        DedView.ActiveFilter.NonColumnFilter = "FKeyPayAllotID = '" & GetPayAllotID() & "'" 'Deduction
        AmortView.ActiveFilter.NonColumnFilter = "FKeyPayAllotID = '" & GetPayAllotID() & "'" 'Amortization
    End Sub

    Private Sub FilterAshEmp()
        PayAshEmpView.ActiveFilter.NonColumnFilter = " FKeyPayCrewHA = '" & GetCrewPayID() & "' "
    End Sub

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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FilterRefNo()
        Dim dv As New DataView(InitRefNo)
        Dim PrinCode As String = IfNull(cboPrincipal.EditValue, String.Empty)

        'Principal
        Dim strPrinFilter As String = String.Empty
        If Not IfNull(PrinCode, "").Equals("") Then
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

    Private Sub cboRefNo_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboRefNo.EditValueChanged
        ControlValidations()
        Dim lookupEd As DevExpress.XtraEditors.CheckedComboBoxEdit = TryCast(sender, DevExpress.XtraEditors.CheckedComboBoxEdit)
        'If Not IfNull(lookupEd.EditValue, "").Equals("") Then
        FilterCrewList()
        'End If
    End Sub

    Private Sub FilterExRate()
        ExRateView.ActiveFilter.NonColumnFilter = "FKeyPay='" & GetPayID() & "'"
    End Sub

    Private Function GetVesselFilter(Optional VslList As String = "") As String
        Dim retVal As String = ""

        If IfNull(VslList, "").Trim.Length <= 0 Then
            For index = 0 To cboVessel.Properties.Items.Count - 1
                'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
                If cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                    retVal = "'" & cboVessel.Properties.Items(index).Value & "'," & retVal
                End If
            Next

        Else
            retVal = VslList
        End If

        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            retVal = "FKeyVsl IN( " & retVal & " )"
        End If
        Return retVal
    End Function

#End Region

#Region "LoadSub"

    Private Sub LoadSubItems()
        LoadCrewList()
        LoadPayAllot()
        LoadExRate()
        LoadAshEmp()
        LoadPayAsh()

        LoadAllotteeTotals(GetPayAllotID)
    End Sub

    Private Sub LoadCrewList()
        CrewListGrid.DataSource = tblCrewHA
        CrewListView.Columns("RankSort").SortIndex = 0
        CrewListView.Columns("RankSort").SortOrder = ColumnSortOrder.Ascending
        CrewListView.Columns("CrewName").SortIndex = 1
        CrewListView.Columns("CrewName").SortOrder = ColumnSortOrder.Ascending
        'cboRefNo.Properties.DataSource = InitRefNo()
    End Sub

    Private Sub LoadPayAllot()
        AllotteeGrid.DataSource = tblPayAllot
    End Sub

    Private Sub LoadPayAsh()
        If tblPayAsh.Rows.Count > 0 Then
            'Earnings
            If tblPayAsh.Select("WageType=1  AND WageRecID IS NULL").Length > 0 Then 'Earnings
                EarnGrid.DataSource = tblPayAsh.Select("WageType=1 AND WageRecID IS NULL").CopyToDataTable
                With EarnView
                    .BeginSort()
                    .Columns("FKeyWageAsh").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
                    .Columns("FKeyWageAsh").SortOrder = ColumnSortOrder.Ascending
                    .EndSort()
                End With
            Else
                EarnGrid.DataSource = tblPayAsh.Clone
            End If
            'Deduction
            If tblPayAsh.Select("WageType=2 AND WageRecID IS NULL").Length > 0 Then 'Deductions
                DedGrid.DataSource = tblPayAsh.Select("WageType=2 AND WageRecID IS NULL").CopyToDataTable
                With DedView
                    .BeginSort()
                    .Columns("FKeyWageAsh").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
                    .Columns("FKeyWageAsh").SortOrder = ColumnSortOrder.Ascending
                    .EndSort()
                End With
            Else
                DedGrid.DataSource = tblPayAsh.Clone
            End If
            'Amortizations
            If tblPayAsh.Select("WageType=2 AND WageRecID IS NOT NULL").Length > 0 Then 'Amortizations
                AmortGrid.DataSource = tblPayAsh.Select("WageType=2 AND WageRecID IS NOT NULL").CopyToDataTable
                With AmortView
                    .BeginSort()
                    .Columns("FKeyWageAsh").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
                    .Columns("FKeyWageAsh").SortOrder = ColumnSortOrder.Ascending
                    .EndSort()
                End With
            Else
                AmortGrid.DataSource = tblPayAsh.Clone
            End If

        End If
    End Sub

    Private Sub LoadAshEmp()
        'If tblPayAshEmp.Rows.Count > 0 Then
        PayAshEmpGrid.DataSource = tblPayAshEmp
        With PayAshEmpView
            .BeginSort()
            .Columns("FKeyWageAshEmp").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            .Columns("FKeyWageAshEmp").SortOrder = ColumnSortOrder.Ascending
            .EndSort()
        End With
        'End If
    End Sub

    Private Sub LoadExRate()
        ExRateGrid.DataSource = tblExRate
    End Sub

    Private Function GetPayID() As String
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("FKeyPayID"), "")
        Return retVal
    End Function 'Get selected Pay ID

    Private Function GetCrewPayID() As String
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("PKey"), "")
        Return retVal
    End Function 'Get selected tblPayCrewHA ID

    Private Function GetCrewName() As String
        Dim strCrewName As String = String.Empty
        Dim SelCrewCount As Integer() = CrewListView.GetSelectedRows
        For index = 0 To SelCrewCount.Count - 1
            If index < 30 Then
                strCrewName = CrewListView.GetRowCellValue(SelCrewCount(index), "CrewName") & "," & vbCrLf & strCrewName
                strCrewName = strCrewName.TrimEnd.Substring(0, Len(strCrewName.TrimEnd) - 1)
            Else
                strCrewName = strCrewName & "[...]"
            End If
        Next
        Return strCrewName
    End Function 'Get selected tblPayCrewHA ID

    Private Function GetPayAllotID() As String
        Dim retVal As String = ""
        retVal = IfNull(AllotteeView.GetFocusedRowCellValue("PKey"), "")
        Return retVal
    End Function

    Private Function GetPayCrewHAID() As String
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("PKey"), "")
        Return retVal
    End Function

    Private Function GetPayCrewHAActID() As String
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("ActID"), "")
        Return retVal
    End Function

    Private Function GetPayCrewHAIDNbr() As String
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("FKeyIDNbr"), "")
        Return retVal
    End Function

    Private Function GetPayCrewHAFKeyWageScale() As String
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("FKeyWScaleCode"), "")
        Return retVal
    End Function

    Private Function GetPayCrewHAFKeyWageScaleRank() As String
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("FKeyWscalRankCode"), "")
        Return retVal
    End Function

    Private Function GetPayPeriod() As Integer
        Dim retVal As String = ""
        retVal = IfNull(CrewListView.GetFocusedRowCellValue("MCode"), 0)
        Return retVal
    End Function

#End Region

#Region "Main Functions"

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        SetPayrollListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetCalculatePayVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetCalculatePayCaption(Name, "Reprocess Crew")
        AllowCalculatePay(Name, False)
        SetDeleteCaption(Name, "Delete Payroll")
        SelectedView = Nothing
        If Not bLoaded Then
            RequiredControls = {cboPeriod, cboPrincipal, cboVessel, cboRefNo}
            InitControls()
            bLoaded = True
        End If
        SetRefCurrency()
        EditSubAllowGrid(AllotteeView, False)
        EditSubAllowGrid(EarnView, False)
        EditSubAllowGrid(DedView, False)
        EditSubAllowGrid(PayAshEmpView, False)
        EditSubAllowGrid(ExRateView, False)
        MakeReadOnlyListener(lcgCrewDetails)
        MakeReadOnlyListener(lcgPayrollDetails)

        SetRibbonPageGroupVisibility(Name, "rpgPayrollReportOptions", True) 'neil 20160914
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neil 20160913
        SetClearFilterVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'neil 
        SetShowListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'fords
        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

        If CrewListView.DataRowCount <= 0 Then
            AllowEditing(Name, False)
        Else
            AllowEditing(Name, True)
        End If
        EdiDeleteAllow(CrewListView)
        PayrollLock() 'Payroll Lock Function
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        EditSubAllowGrid(AllotteeView, False, False)
        EditSubAllowGrid(EarnView, isEditdable)
        EditSubAllowGrid(DedView, isEditdable)
        EditSubAllowGrid(PayAshEmpView, isEditdable)
        'EditSubAllowGrid(ExRateView, isEditdable)
        EditSubAllowGrid(ExRateView, isEditdable, False)
        EdiDeleteAllow(CrewListView)
        If CrewListView.RowCount > 0 Then
            AllowCalculatePay(Name, isEditdable)
        Else
            AllowCalculatePay(Name, False)
        End If

    End Sub

    Public Overrides Sub SaveData()
        'MyBase.SaveData()
        GroupControl1.Focus()
        Dim payCrewID As String = String.Empty
        If BRECORDUPDATEDs Then
            Dim isInserted As Boolean = False
            payCrewID = GetCrewPayID() 'get the selected Pay Crew ID
            isInserted = SaveEditedHA()
            If isInserted Then
                MsgBox(GetMessage("Saved", isInserted), MsgBoxStyle.Information, GetAppName)
                'RefreshData()
                RefreshDataSet()
                SetPayCrewListSelection(payCrewID) 'Set the Selected Pay Crew ID
                BRECORDUPDATEDs = False
                EditCheck(Name, False)
            Else
                MsgBox(GetMessage("Saved", isInserted), MsgBoxStyle.Critical, GetAppName)
            End If
        End If

    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = False
        If Not IsNothing(SelectedView) Then

            clsAudit.propSQLConnStr = MPSDB.GetConnectionString

            Select Case SelectedView.Name
                'Case ExRateView.Name
                '    With ExRateView
                '        If MsgBox("Are you sure you want to delete Exchange Rate ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                '            info = DB.RunSql("DELETE dbo.tblPayExRate WHERE FKeyPay='" & IfNull(.GetFocusedRowCellValue("FKeyPay"), "") & "' AND FKeyCurr= '" & IfNull(.GetFocusedRowCellValue("FKeyCurr"), "") & "' ")
                '            If info Then
                '                .DeleteRow(.FocusedRowHandle)
                '                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                '            Else
                '                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                '            End If
                '        End If
                '    End With
                Case EarnView.Name
                    With EarnView
                        If MsgBox("Are you sure you want to delete the payment " & .GetFocusedRowCellDisplayText("FKeyWageAsh") & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "View / Edit Payroll Home Allotment", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text, "View / Edit Payroll Home Allotment", strID)
                            clsAudit.saveAuditPreDelDetails("tblPay_Ash", IfNull(.GetFocusedRowCellValue("PKey"), ""), LastUpdatedBy) 'neil
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "View Home Allotment Payroll", _
                                "Crewing", _
                                "tblPay_Ash", _
                                "PKey IN ('" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "')", _
                                "<< Delete Crew Data - Home Allotment Payroll - Earnings >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Home Allotment Payroll - Earnings>", _
                                GetUserName())
                            '-->

                            info = DB.RunSql("DELETE dbo.tblPay_Ash WHERE PKey='" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "'")
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
                Case DedView.Name
                    With DedView
                        If MsgBox("Are you sure you want to delete the deduction " & .GetFocusedRowCellDisplayText("FKeyWageAsh") & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "View / Edit Payroll Home Allotment", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text, "View / Edit Payroll Home Allotment", strID)
                            clsAudit.saveAuditPreDelDetails("tblPay_Ash", IfNull(.GetFocusedRowCellValue("PKey"), ""), LastUpdatedBy) 'neil
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "View Home Allotment Payroll", _
                                "Crewing", _
                                "tblPay_Ash", _
                                "PKey IN ('" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "')", _
                                "<< Delete Crew Data - Home Allotment Payroll - Earnings >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Home Allotment Payroll - Earnings>", _
                                GetUserName())
                            '-->

                            info = DB.RunSql("DELETE dbo.tblPay_Ash WHERE PKey='" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "'")
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
                Case PayAshEmpView.Name
                    With PayAshEmpView
                        If MsgBox("Are you sure you want to delete the Employer's Contribution " & .GetFocusedRowCellDisplayText("FKeyWageAshEmp") & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "View / Edit Payroll Home Allotment", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text, "View / Edit Payroll Home Allotment", strID)
                            clsAudit.saveAuditPreDelDetails("tblPay_AshEmp", IfNull(.GetFocusedRowCellValue("PKey"), ""), LastUpdatedBy) 'neil
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "View Home Allotment Payroll", _
                                "Crewing", _
                                "tblPay_AshEmp", _
                                "PKey IN ('" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "')", _
                                "<< Delete Crew Data - Home Allotment Payroll - Employer Contribution >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Home Allotment Payroll - Employer Contribution>", _
                                GetUserName())
                            '-->

                            info = DB.RunSql("DELETE dbo.tblPay_AshEmp WHERE PKey='" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "'")
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
                Case AllotteeView.Name
                    With AllotteeView
                        If MsgBox("Are you sure you want to delete the Allottee with the Account of " & .GetFocusedRowCellDisplayText("AcctNbr") & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "View / Edit Payroll Home Allotment", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text, "View / Edit Payroll Home Allotment", strID)
                            clsAudit.saveAuditPreDelDetails("tblPay_Allot", IfNull(.GetFocusedRowCellValue("PKey"), ""), LastUpdatedBy) 'neil
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "View Home Allotment Payroll", _
                                "Crewing", _
                                "tblPay_Allot", _
                                "PKey IN ('" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "')", _
                                "<< Delete Crew Data - Home Allotment Payroll - Allottee >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Home Allotment Payroll - Allottee>", _
                                GetUserName())
                            '-->

                            info = DB.RunSql("DELETE dbo.tblPay_Allot WHERE PKey='" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "'")
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

                    With CrewListView
                        Dim selRH As Integer() = .GetSelectedRows
                        Dim CrewNameDesc As String = String.Empty


                        For index = 0 To selRH.Length - 1
                            CrewNameDesc = .GetRowCellDisplayText(selRH(index), "CrewName") & "," & vbCrLf & CrewNameDesc
                        Next
                        If Trim(CrewNameDesc.Length) > 0 Then
                            CrewNameDesc = CrewNameDesc.Substring(0, Len(Trim(CrewNameDesc)) - 3)
                        End If

                        If MsgBox("Are you sure you want to delete Crew(s) Home Allotment? '" & vbCrLf & CrewNameDesc, MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                            'info = DB.RunSql("DELETE dbo.tblPayCrew_HA WHERE PKey='" & IfNull(.GetFocusedRowCellValue("PKey"), "") & "'")
                            Dim cWhereCond As String = ""
                            For index = 0 To .SelectedRowsCount - 1

                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew from Allotment", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text, "View / Edit Payroll Home Allotment", strID)
                                clsAudit.saveAuditPreDelDetails("tblPayCrew_HA", IfNull(.GetFocusedRowCellValue("PKey"), ""), LastUpdatedBy) 'neil

                                info = DB.RunSql("DELETE dbo.tblPayCrew_HA WHERE PKey='" & IfNull(.GetRowCellValue(selRH(index), "PKey"), "") & "'")
                                If info Then
                                    cWhereCond = cWhereCond & IIf(IfNull(cWhereCond, "").Length > 0, ", ", "") & _
                                        "'" & IfNull(.GetRowCellValue(selRH(index), "PKey"), "") & "'"
                                End If
                            Next
                            If info Then
                                If IfNull(cWhereCond, "").Length > 0 Then

                                    '<!--added by tony20180922 : Log Deletion
                                    oLogDeletion.Init()
                                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                        "Home Allotment Payroll", _
                                        "Crewing", _
                                        "tblPayCrew_HA", _
                                        "PKey IN (" & cWhereCond & ")", _
                                        "<< Delete Payroll Data - Home Allotment Payroll - Crew >>", _
                                        LogDeletion.DeletionType.Manual, _
                                        "Manually Deleted in <Home Allotment Payroll - Crew>", _
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
                    Dim selectedrefno As String = GetSelectedRefNo()
                    'If Len(GetSelectedRefNo.Trim) > 0 Then
                    If Len(selectedrefno.Trim) > 0 Then

                        'audit code transfer inside function GetSelectedRefNo
                        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "View / Edit Payroll Home Allotment", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text, "View / Edit Payroll Home Allotment", strID)
                        'clsAudit.saveAuditPreDelDetails("tblPay", IfNull(.GetFocusedRowCellValue("PKey"), ""), LastUpdatedBy) 'neil

                        'info = DB.RunSql("DELETE dbo.tblPay " & GetSelectedRefNo())

                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            "View Home Allotment Payroll", _
                            "Crewing", _
                            "tblPay", _
                            GetPayLogDelWhereCond(), _
                            "<< Delete Crew Data - Home Allotment Payroll>>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <Home Allotment Payroll>", _
                            GetUserName())
                        '-->
                        info = DB.RunSql("DELETE dbo.tblPay " & selectedrefno)
                    End If
                    If info Then
                        MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                        bLoaded = False
                        RefreshData()
                    Else
                        MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName)
                    End If
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
            If EarnView.HasColumnErrors() Or DedView.HasColumnErrors Or PayAshEmpView.HasColumnErrors Or AmortView.HasColumnErrors Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidatePayroll() Then
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

    Private Function ValidatePayroll() As Boolean
        Dim retVal As Boolean = False
        If EarnView.HasColumnErrors Or
            DedView.HasColumnErrors Or
            AmortView.HasColumnErrors Or
            PayAshEmpView.HasColumnErrors Then
            retVal = False
        Else
            retVal = True
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

    Private Function GetSelectedRefNo() As String
        Dim retVal As String = ""
        For index = 0 To cboRefNo.Properties.Items.Count - 1
            'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
            If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal

                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Payroll Home Allotment", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text, "View / Edit Payroll Home Allotment", strID)
                clsAudit.saveAuditPreDelDetails("tblPay", cboRefNo.Properties.Items(index).Value, LastUpdatedBy) 'neil

            End If
        Next
        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            retVal = " WHERE PKey IN( " & retVal & " ) AND PayType = 'HA' "
        Else
            retVal = String.Empty
        End If

        Return retVal
    End Function

    Private Function GetPayLogDelWhereCond() As String
        Dim retVal As String = ""
        For index = 0 To cboRefNo.Properties.Items.Count - 1
            'cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
            If cboRefNo.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                retVal = "'" & cboRefNo.Properties.Items(index).Value & "'," & retVal

                
            End If
        Next
        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            retVal = " PKey IN( " & retVal & " ) AND PayType = 'HA' "
        Else
            retVal = String.Empty
        End If

        Return retVal
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

    Private Function SaveEditedHA() As Boolean
        Dim retval As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Dim toBeInserted As Boolean = False
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction
            GetPayID()

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "View / Edit Payroll Home Allotment", 0, System.Environment.MachineName, "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text, "View / Edit Payroll Home Allotment", strID)

            'Save PayAllot
            toBeInserted = SavePayAllot_Ash(sqlConn, sqlTran, LastUpdatedBy, toBeInserted)

            'Save PayAsh
            toBeInserted = SavePayAsh(sqlConn, sqlTran, LastUpdatedBy, toBeInserted)

            'Save Ash Emp
            toBeInserted = SaveAshEmp(sqlConn, sqlTran, LastUpdatedBy, toBeInserted)


            'Updated ExchangeRate   
            toBeInserted = SaveExRate(sqlConn, sqlTran, toBeInserted)


            If toBeInserted Then
                sqlTran.Commit()
                retval = True
            Else
                retval = False
            End If
        Catch ex As Exception
            retval = False
            sqlTran.Rollback()
            MsgBox(ex.Message)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return retval
    End Function


    Private Function SaveExRate(sqlConn As SqlClient.SqlConnection, sqlTran As SqlClient.SqlTransaction, PreviousRetValue As Boolean) As Boolean
        'Please remember that there is a trigger in the database that updates the CAmt OF the Items Here
        'Trigger Name: [TG_Pay_UpdateExRate]

        Dim retVal As Boolean = PreviousRetValue
        'Updated ExchangeRate   
        Dim ExRateDV As New DataView
        ExRateDV = ExRateView.DataSource
        ExRateDV.RowFilter = "Edited = 'True'"
        If ExRateDV.Count > 0 Then
            For Each dr As DataRowView In ExRateDV

                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "View / Edit Payroll Home Allotment", _
                                                         0, System.Environment.MachineName, _
                                                         "Period : " & Me.txtPeriod.Text & " \ Ref no. : " & Me.txtRefNo.Text & " \ Crew : " & txtCrewName.Text & " \ Currency : " & Me.repERFKeyCurr.GetDisplayText(dr("FKeyCurr")), _
                                                         "Edit Exchange Rate", strID)

                Using cmd As New SqlClient.SqlCommand()
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTran
                    cmd.CommandText = "UPDATE dbo.tblPayExRate SET ExRate = " & dr("ExRate") & _
                            " ,LastupdatedBy = '" & LastUpdatedBy & "'" & _
                            " WHERE FKeyPay = '" & dr("FKeyPay") & "' " & _
                            " AND FKeyCurr = '" & dr("FKeyCurr") & "' "
                    retVal = (cmd.ExecuteNonQuery > 0)
                End Using
            Next
        End If
        Return retVal
    End Function
    'ExecuteCustomFunction
    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0)
            Case "RunPayroll"
                RunPayroll() 'ReProcess Crew
            Case "PREVIEWREPORT"
                ShowPayReports()
            Case "PayrollList"
                _frmPayrollList = New frmPayrollList("HA")
                _frmPayrollList.ShowDialog(Me)
                If _frmPayrollList.RefreshCallingForm Then cboPeriod.EditValue = Nothing
                GetSelectedPay()
            Case "CLEARFILTER"
                ClearFilterControls()
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

    Private Sub GetSelectedPay()
        If _frmPayrollList.ApplyFilter Then
            RefreshDataSet()
            cboPeriod.EditValue = _frmPayrollList.PayPeriod
            cboPrincipal.EditValue = _frmPayrollList.PayPrincipal
            cboVessel.SetEditValue(_frmPayrollList.PayVessel)
            cboVessel.RefreshEditValue()
            GetVesselFilter(_frmPayrollList.PayVessel)
            FilterRefNo()
            cboRefNo.SetEditValue(_frmPayrollList.PayPayID)
            cboRefNo.RefreshEditValue()
            FilterCrewList()
        End If
        PayrollLock()
    End Sub

#Region "Reports"

    'Show Pay Reports
    Private Sub ShowPayReports()
        'Throw New NotImplementedException
        RptControl.ShowPayrollReport(cboPeriod.EditValue, cboPrincipal.EditValue, cboVessel.EditValue, cboRefNo.EditValue, GetSelectedRecordList())
    End Sub

    Private Function GetSelectedRecordList() As String
        'Dim dt As DataView = CType(CrewListView.DataSource, DataView)
        'Dim retVal As String = ""

        'If dt.Count > 0 Then
        '    For Each row As DataRowView In dt
        '        retVal = retVal + "'" + row.Item("FKeyIDNbr") + "',"
        '    Next

        '    retVal = retVal.Substring(0, retVal.Length - 1)
        '    retVal = "(" + retVal + ")"
        'End If
        'If CrewListView.RowCount > 0 Then
        retVal = "('" + CrewListView.GetFocusedRowCellValue("FKeyIDNbr") + "')"
        'Else
        '    retval = ""
        'End If
        Return retVal
    End Function

#End Region

    Private Function SavePayAllot_Ash(sqlConn As SqlClient.SqlConnection, sqlTran As SqlClient.SqlTransaction, LastUpdatedBy As String, PrevRetVal As Boolean) As Boolean
        Dim retval As Boolean = PrevRetVal

        Dim AllotDV As DataView = AllotteeView.DataSource
        'AllotDV.RowFilter = "FKeyPayCrewHA= '" & PayCrewHA_ID & "'"
        AllotDV.RowFilter = "Edited='True'"
        If AllotDV.Count > 0 Then
            For Each dr As DataRowView In AllotDV
                If dr("Edited").Equals(True) Then
                    If Not IfNull(dr("PKey"), "").Equals("") Then 'Updated Record
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "UPDATE dbo.tblPay_Allot " & _
                                " SET FKeyPayCrewHA= @FKeyPayCrewHA, " & _
                                "AllotteeID= @AllotteeID, " & _
                                "AcctNbr= @AcctNbr, " & _
                                "AcctName= @AcctName, " & _
                                "LName= @LName, " & _
                                "FName= @FName, " & _
                                "MName= @MName, " & _
                                "FKeyBank= @FKeyBank, " & _
                                "BankName= @BankName, " & _
                                "FKeyBranch= @FKeyBranch, " & _
                                "BranchName= @BranchName, " & _
                                "FKeyCntry= @FKeyCntry, " & _
                                "FKeyCurr= @FKeyCurr, " & _
                                "LastUpdatedBy= @LastUpdatedBy " & _
                                " WHERE PKey = @PKey "
                            With cmd.Parameters
                                .AddWithValue("@PKey", dr("PKey"))
                                .AddWithValue("@FKeyPayCrewHA", dr("FKeyPayCrewHA"))
                                .AddWithValue("@AllotteeID", dr("AllotteeID"))
                                .AddWithValue("@AcctNbr", dr("AcctNbr"))
                                .AddWithValue("@AcctName", dr("AcctName"))
                                .AddWithValue("@LName", dr("LName"))
                                .AddWithValue("@FName", dr("FName"))
                                .AddWithValue("@MName", dr("MName"))
                                .AddWithValue("@FKeyBank", dr("FKeyBank"))
                                .AddWithValue("@BankName", dr("BankName"))
                                .AddWithValue("@FKeyBranch", dr("FKeyBranch"))
                                .AddWithValue("@BranchName", dr("BranchName"))
                                .AddWithValue("@FKeyCntry", dr("FKeyCntry"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    End If
                End If
                'retval = SavePayAsh(sqlConn, sqlTran, dr("PKey"), LastUpdatedBy, retval)
            Next
        End If

        'If Not IsNothing(AllotteeView.DataSource) Then
        '    If TryCast(AllotteeView.DataSource, DataView).ToTable.Select("FKeyPayCrewHA= '" & PayCrewHA_ID & "'").Length > 0 Then
        '        For Each dr As DataRowView In AllotteeView.DataSource
        '            If dr("Edited").Equals(True) Then
        '                If Not IfNull(dr("PKey"), "").Equals("") Then 'Updated Record
        '                    Using cmd As New SqlClient.SqlCommand
        '                        cmd.Connection = sqlConn
        '                        cmd.Transaction = sqlTran
        '                        cmd.CommandText = "UPDATE dbo.tblPay_Allot " & _
        '                            " SET FKeyPayCrewHA= @FKeyPayCrewHA, " & _
        '                            "AllotteeID= @AllotteeID, " & _
        '                            "AcctNbr= @AcctNbr, " & _
        '                            "AcctName= @AcctName, " & _
        '                            "LName= @LName, " & _
        '                            "FName= @FName, " & _
        '                            "MName= @MName, " & _
        '                            "FKeyBank= @FKeyBank, " & _
        '                            "BankName= @BankName, " & _
        '                            "FKeyBranch= @FKeyBranch, " & _
        '                            "BranchName= @BranchName, " & _
        '                            "FKeyCntry= @FKeyCntry, " & _
        '                            "FKeyCurr= @FKeyCurr, " & _
        '                            "LastUpdatedBy= @LastUpdatedBy " & _
        '                            " WHERE PKey = @PKey "
        '                        With cmd.Parameters
        '                            .AddWithValue("@PKey", dr("PKey"))
        '                            .AddWithValue("@FKeyPayCrewHA", dr("FKeyPayCrewHA"))
        '                            .AddWithValue("@AllotteeID", dr("AllotteeID"))
        '                            .AddWithValue("@AcctNbr", dr("AcctNbr"))
        '                            .AddWithValue("@AcctName", dr("AcctName"))
        '                            .AddWithValue("@LName", dr("LName"))
        '                            .AddWithValue("@FName", dr("FName"))
        '                            .AddWithValue("@MName", dr("MName"))
        '                            .AddWithValue("@FKeyBank", dr("FKeyBank"))
        '                            .AddWithValue("@BankName", dr("BankName"))
        '                            .AddWithValue("@FKeyBranch", dr("FKeyBranch"))
        '                            .AddWithValue("@BranchName", dr("BranchName"))
        '                            .AddWithValue("@FKeyCntry", dr("FKeyCntry"))
        '                            .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                            .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
        '                        End With
        '                        retval = (cmd.ExecuteNonQuery > 0)
        '                    End Using
        '                End If
        '            End If
        '            retval = SavePayAsh(sqlConn, sqlTran, dr("PKey"), LastUpdatedBy, retval)
        '            'If Not retval Then
        '            '    Exit For
        '            'End If
        '        Next
        '    End If
        'End If
        Return retval
    End Function

    Private Function SavePayAsh(sqlConn As SqlClient.SqlConnection, sqlTran As SqlClient.SqlTransaction, LastUpdatedBy As String, PrevRetValue As Boolean) As Boolean
        Dim retval As Boolean = PrevRetValue
        Dim EarnDT As New DataTable, EarnDTV As New DataView
        Dim DedDT As New DataTable, DedDTV As New DataView

        EarnDTV = EarnView.DataSource
        'EarnDTV.RowFilter = "FKeyPayAllotID= '" & PayAllotID & "' AND WageType=1 AND WageRecID IS NULL"
        EarnDTV.RowFilter = "Edited='True' AND WageType=1 AND WageRecID IS NULL"
        If EarnDTV.Count > 0 Then
            For Each dr As DataRowView In EarnDTV
                If dr("Edited").Equals(True) Then
                    If Not IfNull(dr("PKey"), "").Equals("") Then 'Update Pay Ash
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "UPDATE dbo.tblPay_Ash " & _
                                " SET FKeyPayAllotID = @FKeyPayAllotID," & _
                                "  FKeyWageAsh = @FKeyWageAsh," & _
                                "  WageType = @WageType," & _
                                "  Amt = @Amt," & _
                                "  CAmt = @CAmt," & _
                                "  FKeyCurr = @FKeyCurr," & _
                                "  ExRate = @ExRate," & _
                                "  DateStart = @DateStart," & _
                                "  DateEnd = @DateEnd, " & _
                                "  LastUpdatedBy = @LastUpdatedBy " & _
                                "  WHERE PKey = @PKey"
                            With cmd.Parameters
                                .AddWithValue("@PKey", dr("PKey"))
                                .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
                                .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
                                .AddWithValue("@WageType", dr("WageType"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CAmt", dr("CAmt"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@ExRate", dr("ExRate"))
                                .AddWithValue("@DateStart", dr("DateStart"))
                                .AddWithValue("@DateEnd", dr("DateEnd"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    Else 'Insert Pay Ash
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "INSERT INTO dbo.tblPay_Ash(" & _
                                "FKeyPayAllotID," & _
                                "FKeyWageAsh," & _
                                "WageType," & _
                                "Amt," & _
                                "CAmt," & _
                                "FKeyCurr," & _
                                "ExRate," & _
                                "DateStart," & _
                                "DateEnd, LastUpdatedBy)" & _
                                "VALUES(" & _
                                "@FKeyPayAllotID," & _
                                "@FKeyWageAsh," & _
                                "@WageType," & _
                                "@Amt," & _
                                "@CAmt," & _
                                "@FKeyCurr," & _
                                "@ExRate," & _
                                "@DateStart," & _
                                "@DateEnd," & _
                                "@LastUpdatedBy)"
                            With cmd.Parameters
                                .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
                                .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
                                .AddWithValue("@WageType", dr("WageType"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CAmt", dr("CAmt"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@ExRate", dr("ExRate"))
                                .AddWithValue("@DateStart", dr("DateStart"))
                                .AddWithValue("@DateEnd", dr("DateEnd"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    End If
                End If
            Next
        End If

        'Earning
        'If TryCast(EarnView.DataSource, DataView).ToTable.Select("FKeyPayAllotID= '" & PayAllotID & "' AND WageType=1 AND WageRecID IS NULL").Length > 0 Then
        '    EarnDT = TryCast(EarnView.DataSource, DataView).ToTable.Select("FKeyPayAllotID= '" & PayAllotID & "' AND WageType=1 AND WageRecID IS NULL").CopyToDataTable
        '    EarnDTV = New DataView(EarnDT)
        '    For Each dr As DataRowView In EarnDTV
        '        If dr("Edited").Equals(True) Then
        '            If Not IfNull(dr("PKey"), "").Equals("") Then 'Update Pay Ash
        '                Using cmd As New SqlClient.SqlCommand
        '                    cmd.Connection = sqlConn
        '                    cmd.Transaction = sqlTran
        '                    cmd.CommandText = "UPDATE dbo.tblPay_Ash " & _
        '                        " SET FKeyPayAllotID = @FKeyPayAllotID," & _
        '                        "  FKeyWageAsh = @FKeyWageAsh," & _
        '                        "  WageType = @WageType," & _
        '                        "  Amt = @Amt," & _
        '                        "  CAmt = @CAmt," & _
        '                        "  FKeyCurr = @FKeyCurr," & _
        '                        "  ExRate = @ExRate," & _
        '                        "  DateStart = @DateStart," & _
        '                        "  DateEnd = @DateEnd " & _
        '                        "  WHERE PKey = @PKey"
        '                    With cmd.Parameters
        '                        .AddWithValue("@PKey", dr("PKey"))
        '                        .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
        '                        .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
        '                        .AddWithValue("@WageType", dr("WageType"))
        '                        .AddWithValue("@Amt", dr("Amt"))
        '                        .AddWithValue("@CAmt", dr("CAmt"))
        '                        .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                        .AddWithValue("@ExRate", dr("ExRate"))
        '                        .AddWithValue("@DateStart", dr("DateStart"))
        '                        .AddWithValue("@DateEnd", dr("DateEnd"))
        '                    End With
        '                    retval = (cmd.ExecuteNonQuery > 0)
        '                End Using
        '            Else 'Insert Pay Ash
        '                Using cmd As New SqlClient.SqlCommand
        '                    cmd.Connection = sqlConn
        '                    cmd.Transaction = sqlTran
        '                    cmd.CommandText = "INSERT INTO dbo.tblPay_Ash(" & _
        '                        "FKeyPayAllotID," & _
        '                        "FKeyWageAsh," & _
        '                        "WageType," & _
        '                        "Amt," & _
        '                        "CAmt," & _
        '                        "FKeyCurr," & _
        '                        "ExRate," & _
        '                        "DateStart," & _
        '                        "DateEnd)" & _
        '                        "VALUES(" & _
        '                        "@FKeyPayAllotID," & _
        '                        "@FKeyWageAsh," & _
        '                        "@WageType," & _
        '                        "@Amt," & _
        '                        "@CAmt," & _
        '                        "@FKeyCurr," & _
        '                        "@ExRate," & _
        '                        "@DateStart," & _
        '                        "@DateEnd)"
        '                    With cmd.Parameters
        '                        .AddWithValue("@FKeyPayAllotID", PayAllotID)
        '                        .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
        '                        .AddWithValue("@WageType", dr("WageType"))
        '                        .AddWithValue("@Amt", dr("Amt"))
        '                        .AddWithValue("@CAmt", dr("CAmt"))
        '                        .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                        .AddWithValue("@ExRate", dr("ExRate"))
        '                        .AddWithValue("@DateStart", dr("DateStart"))
        '                        .AddWithValue("@DateEnd", dr("DateEnd"))
        '                    End With
        '                    retval = (cmd.ExecuteNonQuery > 0)
        '                End Using
        '            End If
        '        End If
        '    Next
        'End If

        'Deduction
        DedDTV = DedView.DataSource
        DedDTV.RowFilter = "Edited='True' AND WageType=2 AND WageRecID IS NULL"
        If DedDTV.Count > 0 Then
            For Each dr As DataRowView In DedDTV
                If dr("Edited").Equals(True) Then
                    If Not IfNull(dr("PKey"), "").Equals("") Then
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "UPDATE dbo.tblPay_Ash" & _
                                " SET FKeyPayAllotID = @FKeyPayAllotID," & _
                                "  FKeyWageAsh = @FKeyWageAsh," & _
                                "  WageType = @WageType," & _
                                "  Amt = @Amt," & _
                                "  CAmt = @CAmt," & _
                                "  FKeyCurr = @FKeyCurr," & _
                                "  ExRate = @ExRate," & _
                                "  DateStart = @DateStart," & _
                                "  DateEnd = @DateEnd, " & _
                                "  LastUpdatedBy= @LastUpdatedBy " & _
                                "  WHERE PKey = @PKey"
                            With cmd.Parameters
                                .AddWithValue("@PKey", dr("PKey"))
                                .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
                                .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
                                .AddWithValue("@WageType", dr("WageType"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CAmt", dr("CAmt"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@ExRate", dr("ExRate"))
                                .AddWithValue("@DateStart", dr("DateStart"))
                                .AddWithValue("@DateEnd", dr("DateEnd"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    Else
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "INSERT INTO dbo.tblPay_Ash(" & _
                                "FKeyPayAllotID," & _
                                "FKeyWageAsh," & _
                                "WageType," & _
                                "Amt," & _
                                "CAmt," & _
                                "FKeyCurr," & _
                                "ExRate," & _
                                "DateStart," & _
                                "DateEnd, LastUpdatedBy)" & _
                                "VALUES(" & _
                                "@FKeyPayAllotID," & _
                                "@FKeyWageAsh," & _
                                "@WageType," & _
                                "@Amt," & _
                                "@CAmt," & _
                                "@FKeyCurr," & _
                                "@ExRate," & _
                                "@DateStart," & _
                                "@DateEnd," & _
                                "@LastUpdatedBy)"
                            With cmd.Parameters
                                .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
                                .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
                                .AddWithValue("@WageType", dr("WageType"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CAmt", dr("CAmt"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@ExRate", dr("ExRate"))
                                .AddWithValue("@DateStart", dr("DateStart"))
                                .AddWithValue("@DateEnd", dr("DateEnd"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    End If
                End If
            Next
        End If


        'If TryCast(DedView.DataSource, DataView).ToTable.Select("FKeyPayAllotID= '" & PayAllotID & "' AND WageType=2 AND WageRecID IS NULL").Length > 0 Then
        '    DedDT = TryCast(DedView.DataSource, DataView).ToTable.Select("FKeyPayAllotID= '" & PayAllotID & "' AND WageType=2 AND WageRecID IS NULL").CopyToDataTable
        '    DedDTV = New DataView(DedDT)
        '    For Each dr As DataRowView In DedDTV
        '        If dr("Edited").Equals(True) Then
        '            If Not IfNull(dr("PKey"), "").Equals("") Then
        '                Using cmd As New SqlClient.SqlCommand
        '                    cmd.Connection = sqlConn
        '                    cmd.Transaction = sqlTran
        '                    cmd.CommandText = "UPDATE dbo.tblPay_Ash" & _
        '                        " SET FKeyPayAllotID = @FKeyPayAllotID," & _
        '                        "  FKeyWageAsh = @FKeyWageAsh," & _
        '                        "  WageType = @WageType," & _
        '                        "  Amt = @Amt," & _
        '                        "  CAmt = @CAmt," & _
        '                        "  FKeyCurr = @FKeyCurr," & _
        '                        "  ExRate = @ExRate," & _
        '                        "  DateStart = @DateStart," & _
        '                        "  DateEnd = @DateEnd " & _
        '                        "  WHERE PKey = @PKey"
        '                    With cmd.Parameters
        '                        .AddWithValue("@PKey", dr("PKey"))
        '                        .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
        '                        .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
        '                        .AddWithValue("@WageType", dr("WageType"))
        '                        .AddWithValue("@Amt", dr("Amt"))
        '                        .AddWithValue("@CAmt", dr("CAmt"))
        '                        .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                        .AddWithValue("@ExRate", dr("ExRate"))
        '                        .AddWithValue("@DateStart", dr("DateStart"))
        '                        .AddWithValue("@DateEnd", dr("DateEnd"))
        '                    End With
        '                    retval = (cmd.ExecuteNonQuery > 0)
        '                End Using
        '            Else
        '                Using cmd As New SqlClient.SqlCommand
        '                    cmd.Connection = sqlConn
        '                    cmd.Transaction = sqlTran
        '                    cmd.CommandText = "INSERT INTO dbo.tblPay_Ash(" & _
        '                        "FKeyPayAllotID," & _
        '                        "FKeyWageAsh," & _
        '                        "WageType," & _
        '                        "Amt," & _
        '                        "CAmt," & _
        '                        "FKeyCurr," & _
        '                        "ExRate," & _
        '                        "DateStart," & _
        '                        "DateEnd)" & _
        '                        "VALUES(" & _
        '                        "@FKeyPayAllotID," & _
        '                        "@FKeyWageAsh," & _
        '                        "@WageType," & _
        '                        "@Amt," & _
        '                        "@CAmt," & _
        '                        "@FKeyCurr," & _
        '                        "@ExRate," & _
        '                        "@DateStart," & _
        '                        "@DateEnd)"
        '                    With cmd.Parameters
        '                        .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
        '                        .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
        '                        .AddWithValue("@WageType", dr("WageType"))
        '                        .AddWithValue("@Amt", dr("Amt"))
        '                        .AddWithValue("@CAmt", dr("CAmt"))
        '                        .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                        .AddWithValue("@ExRate", dr("ExRate"))
        '                        .AddWithValue("@DateStart", dr("DateStart"))
        '                        .AddWithValue("@DateEnd", dr("DateEnd"))
        '                    End With
        '                    retval = (cmd.ExecuteNonQuery > 0)
        '                End Using
        '            End If
        '        End If
        '    Next
        'End If

        ''Amortization
        Dim AmortDV As New DataView
        AmortDV = AmortView.DataSource
        AmortDV.RowFilter = "Edited='True' AND WageType=2 AND WageRecID IS NOT NULL"
        If AmortDV.Count > 0 Then
            'For Each dr As DataRowView In DedDTV 'neil commented out
            For Each dr As DataRowView In AmortDV
                If dr("Edited").Equals(True) Then
                    If Not IfNull(dr("PKey"), "").Equals("") Then
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "UPDATE dbo.tblPay_Ash" & _
                                " SET FKeyPayAllotID = @FKeyPayAllotID," & _
                                "  FKeyWageAsh = @FKeyWageAsh," & _
                                "  WageType = @WageType," & _
                                "  Amt = @Amt," & _
                                "  CAmt = @CAmt," & _
                                "  FKeyCurr = @FKeyCurr," & _
                                "  ExRate = @ExRate," & _
                                "  DateStart = @DateStart," & _
                                "  DateEnd = @DateEnd, " & _
                                "  LastUpdatedBy= @LastUpdatedBy " & _
                                "  WHERE PKey = @PKey"
                            With cmd.Parameters
                                .AddWithValue("@PKey", dr("PKey"))
                                .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
                                .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
                                .AddWithValue("@WageType", dr("WageType"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CAmt", dr("CAmt"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@ExRate", dr("ExRate"))
                                .AddWithValue("@DateStart", dr("DateStart"))
                                .AddWithValue("@DateEnd", dr("DateEnd"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    Else
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "INSERT INTO dbo.tblPay_Ash(" & _
                                "FKeyPayAllotID," & _
                                "FKeyWageAsh," & _
                                "WageType," & _
                                "Amt," & _
                                "CAmt," & _
                                "FKeyCurr," & _
                                "ExRate," & _
                                "DateStart," & _
                                "DateEnd, LastUpdatedBy)" & _
                                "VALUES(" & _
                                "@FKeyPayAllotID," & _
                                "@FKeyWageAsh," & _
                                "@WageType," & _
                                "@Amt," & _
                                "@CAmt," & _
                                "@FKeyCurr," & _
                                "@ExRate," & _
                                "@DateStart," & _
                                "@DateEnd," & _
                                "@LastUpdatedBy)"
                            With cmd.Parameters
                                .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
                                .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
                                .AddWithValue("@WageType", dr("WageType"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CAmt", dr("CAmt"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@ExRate", dr("ExRate"))
                                .AddWithValue("@DateStart", dr("DateStart"))
                                .AddWithValue("@DateEnd", dr("DateEnd"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    End If
                End If
            Next
        End If



        'If TryCast(AmortView.DataSource, DataView).ToTable.Select("FKeyPayAllotID= '" & PayAllotID & "' AND WageType=2 AND WageRecID IS NOT NULL").Length > 0 Then
        '    DedDT = TryCast(AmortView.DataSource, DataView).ToTable.Select("FKeyPayAllotID= '" & PayAllotID & "' AND WageType=2 AND WageRecID IS NOT NULL").CopyToDataTable
        '    DedDTV = New DataView(DedDT)
        '    For Each dr As DataRowView In DedDTV
        '        If dr("Edited").Equals(True) Then
        '            If Not IfNull(dr("PKey"), "").Equals("") Then
        '                Using cmd As New SqlClient.SqlCommand
        '                    cmd.Connection = sqlConn
        '                    cmd.Transaction = sqlTran
        '                    cmd.CommandText = "UPDATE dbo.tblPay_Ash" & _
        '                        " SET FKeyPayAllotID = @FKeyPayAllotID," & _
        '                        "  FKeyWageAsh = @FKeyWageAsh," & _
        '                        "  WageType = @WageType," & _
        '                        "  Amt = @Amt," & _
        '                        "  CAmt = @CAmt," & _
        '                        "  FKeyCurr = @FKeyCurr," & _
        '                        "  ExRate = @ExRate," & _
        '                        "  DateStart = @DateStart," & _
        '                        "  DateEnd = @DateEnd " & _
        '                        "  WHERE PKey = @PKey"
        '                    With cmd.Parameters
        '                        .AddWithValue("@PKey", dr("PKey"))
        '                        .AddWithValue("@FKeyPayAllotID", dr("FKeyPayAllotID"))
        '                        .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
        '                        .AddWithValue("@WageType", dr("WageType"))
        '                        .AddWithValue("@Amt", dr("Amt"))
        '                        .AddWithValue("@CAmt", dr("CAmt"))
        '                        .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                        .AddWithValue("@ExRate", dr("ExRate"))
        '                        .AddWithValue("@DateStart", dr("DateStart"))
        '                        .AddWithValue("@DateEnd", dr("DateEnd"))
        '                    End With
        '                    retval = (cmd.ExecuteNonQuery > 0)
        '                End Using
        '            Else
        '                Using cmd As New SqlClient.SqlCommand
        '                    cmd.Connection = sqlConn
        '                    cmd.Transaction = sqlTran
        '                    cmd.CommandText = "INSERT INTO dbo.tblPay_Ash(" & _
        '                        "FKeyPayAllotID," & _
        '                        "FKeyWageAsh," & _
        '                        "WageType," & _
        '                        "Amt," & _
        '                        "CAmt," & _
        '                        "FKeyCurr," & _
        '                        "ExRate," & _
        '                        "DateStart," & _
        '                        "DateEnd)" & _
        '                        "VALUES(" & _
        '                        "@FKeyPayAllotID," & _
        '                        "@FKeyWageAsh," & _
        '                        "@WageType," & _
        '                        "@Amt," & _
        '                        "@CAmt," & _
        '                        "@FKeyCurr," & _
        '                        "@ExRate," & _
        '                        "@DateStart," & _
        '                        "@DateEnd)"
        '                    With cmd.Parameters
        '                        .AddWithValue("@FKeyPayAllotID", PayAllotID)
        '                        .AddWithValue("@FKeyWageAsh", dr("FKeyWageAsh"))
        '                        .AddWithValue("@WageType", dr("WageType"))
        '                        .AddWithValue("@Amt", dr("Amt"))
        '                        .AddWithValue("@CAmt", dr("CAmt"))
        '                        .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                        .AddWithValue("@ExRate", dr("ExRate"))
        '                        .AddWithValue("@DateStart", dr("DateStart"))
        '                        .AddWithValue("@DateEnd", dr("DateEnd"))
        '                    End With
        '                    retval = (cmd.ExecuteNonQuery > 0)
        '                End Using
        '            End If
        '        End If
        '    Next
        'End If

        Return retval
    End Function

    Private Function SaveAshEmp(sqlConn As SqlClient.SqlConnection, sqlTran As SqlClient.SqlTransaction, LastUpdatedBy As String, PrevRetVal As Boolean) As Boolean
        Dim retval As Boolean = PrevRetVal
        Dim PayAshEmpDV As New DataView
        PayAshEmpDV = PayAshEmpView.DataSource
        PayAshEmpDV.RowFilter = "Edited = 'True'"
        If PayAshEmpDV.Count > 0 Then
            For Each dr As DataRowView In PayAshEmpDV
                If dr("Edited").Equals(True) Then
                    If Not IsNothing(dr("PKey")) Then
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "INSERT INTO dbo.tblPay_AshEmp(" & _
                                "FKeyPayCrewHA," & _
                                "FKeyWageAshEmp," & _
                                "FKeyCurr," & _
                                "ExRate," & _
                                "Amt," & _
                                "CAmt," & _
                                "DateStart," & _
                                "DateEnd," & _
                                "LastUpdatedBy)" & _
                                "VALUES(" & _
                                "@FKeyPayCrewHA," & _
                                "@FKeyWageAshEmp," & _
                                "@FKeyCurr," & _
                                "@ExRate," & _
                                "@Amt," & _
                                "@CAmt," & _
                                "@DateStart," & _
                                "@DateEnd," & _
                                "@LastUpdatedBy)"
                            With cmd.Parameters
                                .AddWithValue("@FKeyPayCrewHA", dr("FKeyPayCrewHA"))
                                .AddWithValue("@FKeyWageAshEmp", dr("FKeyWageAshEmp"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@ExRate", dr("ExRate"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CAmt", dr("CAmt"))
                                .AddWithValue("@DateStart", dr("DateStart"))
                                .AddWithValue("@DateEnd", dr("DateEnd"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    Else
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "UPDATE dbo.tblPay_AshEmp  " & _
                                "SET FKeyPayCrewHA = @FKeyPayCrewHA," & _
                                "FKeyWageAshEmp=@FKeyWageAshEmp," & _
                                "FKeyCurr=@FKeyCurr," & _
                                "ExRate=@ExRate," & _
                                "Amt=@Amt," & _
                                "CAmt=@CAmt," & _
                                "DateStart=@DateStart," & _
                                "DateEnd=@DateEnd," & _
                                "DateUpdate= Getdate()," & _
                                "LastUpdatedBy=@LastUpdatedBy" & _
                                "WHERE PKey = @PKey"
                            With cmd.Parameters
                                .AddWithValue("@PKey", dr("PKey"))
                                .AddWithValue("@FKeyPayCrewHA", dr("FKeyPayCrewHA"))
                                .AddWithValue("@FKeyWageAshEmp", dr("FKeyWageAshEmp"))
                                .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
                                .AddWithValue("@ExRate", dr("ExRate"))
                                .AddWithValue("@Amt", dr("Amt"))
                                .AddWithValue("@CAmt", dr("CAmt"))
                                .AddWithValue("@DateStart", dr("DateStart"))
                                .AddWithValue("@DateEnd", dr("DateEnd"))
                                .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                            End With
                            retval = (cmd.ExecuteNonQuery > 0)
                        End Using
                    End If
                End If
            Next
        End If

        'If Not IsNothing(PayAshEmpView.DataSource) Then
        '    For Each dr As DataRowView In PayAshEmpView.DataSource
        '        If dr("Edited").Equals(True) Then
        '            If Not IsNothing(dr("PKey")) Then
        '                Using cmd As New SqlClient.SqlCommand
        '                    cmd.Connection = sqlConn
        '                    cmd.Transaction = sqlTran
        '                    cmd.CommandText = "INSERT INTO dbo.tblPay_AshEmp(" & _
        '                        "FKeyPayCrewHA," & _
        '                        "FKeyWageAshEmp," & _
        '                        "FKeyCurr," & _
        '                        "ExRate," & _
        '                        "Amt," & _
        '                        "CAmt," & _
        '                        "DateStart," & _
        '                        "DateEnd," & _
        '                        "LastUpdatedBy)" & _
        '                        "VALUES(" & _
        '                        "@FKeyPayCrewHA," & _
        '                        "@FKeyWageAshEmp," & _
        '                        "@FKeyCurr," & _
        '                        "@ExRate," & _
        '                        "@Amt," & _
        '                        "@CAmt," & _
        '                        "@DateStart," & _
        '                        "@DateEnd," & _
        '                        "@LastUpdatedBy)"
        '                    With cmd.Parameters
        '                        .AddWithValue("@FKeyPayCrewHA", dr("FKeyWageAshEmp"))
        '                        .AddWithValue("@FKeyWageAshEmp", dr("FKeyWageAshEmp"))
        '                        .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                        .AddWithValue("@ExRate", dr("ExRate"))
        '                        .AddWithValue("@Amt", dr("Amt"))
        '                        .AddWithValue("@CAmt", dr("CAmt"))
        '                        .AddWithValue("@DateStart", dr("DateStart"))
        '                        .AddWithValue("@DateEnd", dr("DateEnd"))
        '                        .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
        '                    End With
        '                    retval = (cmd.ExecuteNonQuery > 0)
        '                End Using
        '            Else
        '                Using cmd As New SqlClient.SqlCommand
        '                    cmd.Connection = sqlConn
        '                    cmd.Transaction = sqlTran
        '                    cmd.CommandText = "UPDATE dbo.tblPay_AshEmp  " & _
        '                        "SET FKeyPayCrewHA = @FKeyPayCrewHA," & _
        '                        "FKeyWageAshEmp=@FKeyWageAshEmp," & _
        '                        "FKeyCurr=@FKeyCurr," & _
        '                        "ExRate=@ExRate," & _
        '                        "Amt=@Amt," & _
        '                        "CAmt=@CAmt," & _
        '                        "DateStart=@DateStart," & _
        '                        "DateEnd=@DateEnd," & _
        '                        "DateUpdate= Getdate()," & _
        '                        "LastUpdatedBy=@LastUpdatedBy" & _
        '                        "WHERE PKey = @PKey"
        '                    With cmd.Parameters
        '                        .AddWithValue("@PKey", dr("PKey"))
        '                        .AddWithValue("@FKeyPayCrewHA", PayCrewHA_ID)
        '                        .AddWithValue("@FKeyWageAshEmp", dr("FKeyWageAshEmp"))
        '                        .AddWithValue("@FKeyCurr", dr("FKeyCurr"))
        '                        .AddWithValue("@ExRate", dr("ExRate"))
        '                        .AddWithValue("@Amt", dr("Amt"))
        '                        .AddWithValue("@CAmt", dr("CAmt"))
        '                        .AddWithValue("@DateStart", dr("DateStart"))
        '                        .AddWithValue("@DateEnd", dr("DateEnd"))
        '                        .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
        '                    End With
        '                    retval = (cmd.ExecuteNonQuery > 0)
        '                End Using
        '            End If
        '        End If
        '    Next
        'End If
        Return retval
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

#End Region

#Region "Views"

#Region "CrewList"

    Private Sub LoadCrewItems()
        With CrewListView
            txtPeriod.Text = NumCodeToDate(.GetFocusedRowCellValue("MCode"), 1).ToString("MMMM-yyyy")
            txtRefNo.Text = IfNull(.GetFocusedRowCellValue("RefNo"), "")
            txtDateCreated.EditValue = IfNull(CDate(.GetFocusedRowCellValue("DateCreated")).ToString("dd-MMM-yyyy"), "")
            txtVsl.Text = IfNull(.GetFocusedRowCellValue("VslName"), "")
            txtPrincipal.Text = IfNull(.GetFocusedRowCellValue("PrincipalName"), "")

            txtCrewName.Text = IfNull(.GetFocusedRowCellValue("CrewName"), "")
            'txtCompanyID.Text = IfNull(.GetFocusedRowCellValue("COIDNo"), "")
            txtWageScaleName.Text = IfNull(.GetFocusedRowCellValue("WageScaleName"), "")
            txtRank.Text = IfNull(.GetFocusedRowCellValue("RankName"), "")
            txtStatus.Text = IfNull(.GetFocusedRowCellValue("Status"), "")
            txtAmtBasic.Text = IfNull(.GetFocusedRowCellValue("AmtBasic"), "0.00")
            'lciBasicWage.Text = IfNull("Basic Wages (" &  & ")", "Basic Wage")
            'lciBasicWage.Text = IIf(.GetFocusedRowCellDisplayText("FKeyBasicCurr").ToString.Length > 0, "Basic Wage (" & .GetFocusedRowCellDisplayText("FKeyBasicCurr") & ")", "Basic Wage")
        End With
    End Sub

    Private Sub ClearCrewItems()
        txtPeriod.Text = Nothing
        txtRefNo.Text = Nothing
        txtDateCreated.EditValue = Nothing
        txtVsl.Text = Nothing
        txtPrincipal.Text = Nothing

        txtCrewName.Text = Nothing
        txtWageScaleName.Text = Nothing
        txtRank.Text = Nothing
        txtStatus.Text = Nothing
    End Sub

    Private Sub CrewListView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles CrewListView.FocusedRowObjectChanged
        CrewListViewChange()
        SetPayReferentialCurrency(CrewListView.GetFocusedRowCellValue("FKeyPayID"))
        LoadTotalAllottee(CrewListView.GetFocusedRowCellValue("PKey"), CrewListView.GetFocusedRowCellValue("FKeyPayCrewHA"))
        PayrollLock()

    End Sub

    Private Sub LoadTotalAllottee(FKeyPayID As String, FKeyPayCrewHA As String)
        Dim totalAllotment As Double = 0, tEarn As Double = 0, tDed As Double = 0
        Dim dv_Allot As New DataView
        'If IsNothing(AllotteeGrid.DataSource) Then
        If tblPayAllot.Rows.Count > 0 Then
            dv_Allot = New DataView(DS.Tables("PayAllot").Copy)
        Else
            dv_Allot = New DataView(AllotteeGrid.DataSource)
        End If
        dv_Allot.RowFilter = "FKeyPayCrewHA = '" & FKeyPayID & "'"

        'lciTotalAllotment.Text = "Total Allotment [" & ExRateView.GetRowCellDisplayText(ExRateView.LocateByValue("ExRate", CDbl(1)), "FKeyCurr") & "]"
        lciTotalAllotment.Text = "Total Allotment [" & strPayRefCurr & "]"


        For Each dr As DataRowView In dv_Allot
            Dim dt As New DataTable
            If IsNothing(EarnGrid.DataSource) Or IsNothing(DedGrid.DataSource) Then
                dt = DS.Tables("PayAsh").Copy
            Else
                dt = TryCast(EarnGrid.DataSource, DataTable).Copy
                dt.Merge(TryCast(DedGrid.DataSource, DataTable).Copy) 'Merge Deduction Table
            End If

            If dt.Rows.Count > 0 Then
                tEarn = tEarn + ConvertToRefAmt(Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayAllotID= '" & dr("PKey") & "' AND WageType = 1 AND WageRecID IS NULL AND FKeyWageAsh='SYSPAYALLOT' "), CDbl(0)), 2, MidpointRounding.AwayFromZero), dr("FKeyCurr"))
                tDed = tDed + ConvertToRefAmt(Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayAllotID= '" & dr("PKey") & "' AND WageType = 2 AND WageRecID IS NULL AND FKeyWageAsh='SYSPAYALLOT' "), CDbl(0)), 2, MidpointRounding.AwayFromZero), dr("FKeyCurr"))
            End If
        Next
        txtAllotment.Text = tEarn - tDed

    End Sub

    Dim strPayRefCurr As String = String.Empty
    Private Sub SetPayReferentialCurrency(FKeyPayID As String)

        Dim refPayCurr As String = (From drPay As DataRow In DS.Tables("Pay").Copy.Rows
                                    Where drPay("PKey") = FKeyPayID
                                    Select drPay("RefCurr")).FirstOrDefault()
        strPayRefCurr = (From tcurr As DataRow In tblAdmCurr.Rows
                      Where tcurr("PKey") = refPayCurr
                      Select tcurr("Symbol")).FirstOrDefault
    End Sub

    Private Function ConvertToRefAmt(Amount As Double, FKeyCurr As String) As Double
        Dim retval As Double = 0
        Dim dv As DataView
        'If IsNothing(ExRateGrid.DataSource) Then
        dv = New DataView(DS.Tables("PayExRate").Copy)
        'Else
        '    dv = New DataView(TryCast(ExRateGrid.DataSource, DataTable))
        'End If
        dv.RowFilter = "FKeyPay = '" & GetPayID() & "'"
        dv.Sort = "FKeyCurr"
        Dim RefAmount As Double = 0
        If dv.Count > 0 Then
            Dim drExRate As DataRow = dv.ToTable.Select(" FKeyCurr='" & FKeyCurr & "'").FirstOrDefault()
            Dim ExRate As Double = IfNull(drExRate.Item("ExRate"), CDbl(1))
            Dim drRefCurr As DataRow = dv.ToTable.Select(" ExRate = 1").FirstOrDefault()
            RefAmount = Amount / ExRate
        End If

        retval = RefAmount
        Return retval
    End Function

    Private Sub LoadAllotteeTotals(FKeyPayAllotID)
        'If Not IsNothing(EarnGrid.DataSource) Or Not IsNothing(DedGrid.DataSource) Then
        Dim dt As DataTable
        If IsNothing(EarnGrid.DataSource) Or IsNothing(DedGrid.DataSource) Then
            dt = (DS.Tables("PayAsh").Copy)
        Else
            dt = TryCast(EarnGrid.DataSource, DataTable).Copy
            dt.Merge(TryCast(DedGrid.DataSource, DataTable).Copy) 'Merge Deduction Table
            dt.Merge(TryCast(AmortGrid.DataSource, DataTable).Copy) 'Merge Amortization Table   '<-- added by tony20171006
        End If


        'If Not IsNothing(tblPayAsh) Then
        If dt.Rows.Count > 0 Then
            txtTotalPayment.Text = Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayAllotID= '" & FKeyPayAllotID & "' AND WageType = 1 AND WageRecID IS NULL "), CDbl(0)), 2, MidpointRounding.AwayFromZero)
            txtTotalDeduction.Text = Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayAllotID= '" & FKeyPayAllotID & "' AND WageType = 2 "), CDbl(0)), 2, MidpointRounding.AwayFromZero)
        Else
            txtTotalPayment.Text = 0.0
            txtTotalDeduction.Text = 0.0
        End If
        'End If
        'End If


    End Sub

    Private Function SumAllotDeductions(FKeyPayAllotID) As Double
        Dim retval As Double = 0
        If Not IsNothing(tblPayAsh) Then
            Dim dt As DataTable = tblPayAsh
            If dt.Rows.Count > 0 Then
                retval = Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayAllotID= '" & FKeyPayAllotID & "' AND WageType = 2 AND WageRecID IS NULL "), CDbl(0)), 2, MidpointRounding.AwayFromZero)
            End If
        End If
        Return retval
    End Function


    Private Sub CrewListViewChange()
        'Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        LoadCrewItems()
        FilterAllottee()
        FilterAshEmp()
        FilterExRate()
    End Sub

    Private Sub CrewListView_GotFocus(sender As Object, e As System.EventArgs) Handles CrewListView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Crew from Payroll")
    End Sub

    Private Sub CrewListView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CrewListView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    End Sub

    Private Sub CrewListView_LostFocus(sender As Object, e As System.EventArgs) Handles CrewListView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub CrewListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewListView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub CrewListView_RowCountChanged(sender As Object, e As System.EventArgs) Handles CrewListView.RowCountChanged
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        EdiDeleteAllow(sender)
        If _v.DataRowCount <= 0 Then
            AllowEditing(Name, False)
            ClearControls()
        Else
            AllowEditing(Name, True)
        End If
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
#End Region

#Region "ExRate"

    Private Sub SetRefCurrency()
        Dim refCurr As String = String.Empty
        refCurr = DB.DLookUp("Symbol", "tbladmCurr", String.Empty, "Ref<>0")
        strRefCurr = DB.DLookUp("PKey", "tbladmCurr", String.Empty, "Ref<>0")
        GroupControl2.Text = "Exchange Rate: per 1 " & refCurr
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
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _v.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub ExRateView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ExRateView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _v
            .SetRowCellValue(e.RowHandle, "FKeyPay", GetPayID)
        End With
    End Sub

    Private Sub ExRateView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ExRateView.RowCellStyle
        ViewRowCellStyle(sender, e, "ExRate")
    End Sub

    Private Sub ExRateView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles ExRateView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub ExRateView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ExRateView.ShowingEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _v.FocusedColumn.FieldName = "ExRate" AndAlso IsRefCurr(_v, _v.FocusedRowHandle) Then
            e.Cancel = True
        End If
        If _v.FocusedColumn.FieldName = "FKeyCurr" AndAlso IsRefCurr(_v, _v.FocusedRowHandle) Then
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "Allottee"

    Private Function GetAllotCurrency() As String
        Return IfNull(AllotteeView.GetFocusedRowCellValue("FKeyCurr"), String.Empty)
    End Function

    Private Sub AllotteeView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AllotteeView.CellValueChanged
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _v.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub AllotteeView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AllotteeView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _v
            .SetRowCellValue(e.RowHandle, "Edited", True)
            .SetRowCellValue(e.RowHandle, "FKeyPayCrewHA", GetCrewPayID)
        End With
    End Sub

    Private Sub AllotteeView_GotFocus(sender As Object, e As System.EventArgs) Handles AllotteeView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Allottee")

    End Sub

    Private Sub AllotteeView_ShownEditor(sender As Object, e As System.EventArgs) Handles AllotteeView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
        stopnaba = True
    End Sub

    Private Sub AllotteeView_LostFocus(sender As Object, e As System.EventArgs) Handles AllotteeView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")

    End Sub

    Private Sub AllotteeView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles AllotteeView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub AllotteeView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AllotteeView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub AllotteeView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles AllotteeView.ValidatingEditor
        ViewValidatingEditor(sender, e)
    End Sub

#End Region

#Region "Ash"

    Private Function SetExRate(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) As Double
        Dim retval As Double = 0
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If _V.FocusedColumn.FieldName.Equals("FKeyCurr") Then
            Dim dv As DataView = ExRateView.DataSource
            dv.RowFilter = "FKeyPay ='" & GetPayID() & "'"
            dv.Sort = "FKeyCurr"
            Dim drExRate As DataRow = dv.ToTable.Select("FKeyPay='" & GetPayID() & "' AND FKeyCurr='" & e.Value & "'").FirstOrDefault()

            Dim xrow As DataRowView() = dv.FindRows(e.Value)
            Dim ExRate As Double = drExRate.Item("ExRate")

            'get Bank Currency
            Dim drBankExRate As DataRow = dv.ToTable.Select("FKeyPay='" & GetPayID() & "' AND FKeyCurr='" & GetAllotCurrency() & "'").FirstOrDefault()
            Dim BankExRate As Double = 0
            BankExRate = drBankExRate.Item("ExRate")

            Dim RefExRate As Double = 1 'Referential Amount (usually 1)
            Dim outExRate As Double = 0
            outExRate = (RefExRate / ExRate) * (BankExRate)
            _V.SetFocusedRowCellValue("ExRate", outExRate)

        End If

        If _V.FocusedColumn.FieldName.Equals("Amt") Then
            'Dim dv As DataView = ExRateView.DataSource
            'dv.Sort = "FKeyCurr"
            'Dim Amt As Double = 0, ExRate As Double = 0, RefAmt As Double = 0, RefExRate As Double = 0
            'Amt = CDbl(e.Value)
            'ExRate = CDbl(IfNull(_V.GetFocusedRowCellValue("ExRate"), 1))
            'RefAmt = Amt / ExRate
            '_V.SetFocusedRowCellValue("CAmt", Amt * ExRate)
            UpdateAmountAfterCurrChange(_V, e.Value)
        End If
        Return retval
    End Function

    Sub UpdateAmountAfterCurrChange(_v As DevExpress.XtraGrid.Views.Grid.GridView, nAmount As Double)
        Dim dv As DataView = ExRateView.DataSource
        dv.Sort = "FKeyCurr"
        Dim Amt As Double = 0, ExRate As Double = 0, RefAmt As Double = 0, RefExRate As Double = 0
        Amt = CDbl(nAmount)
        ExRate = CDbl(IfNull(_v.GetFocusedRowCellValue("ExRate"), 1))
        RefAmt = Amt / ExRate
        _v.SetFocusedRowCellValue("CAmt", Amt * ExRate)
    End Sub


    Private Function GetDateStart() As Date
        Return CDate(CrewListView.GetFocusedRowCellValue("DateStart")).ToString("yyyy-MM-dd")
    End Function

    Private Function GetDateEnd() As Date
        Return CDate(CrewListView.GetFocusedRowCellValue("DateEnd")).ToString("yyyy-MM-dd")
    End Function


#Region "Earning"


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

        ElseIf e.Column.FieldName.Equals("FKeyWageAsh") Then
            If _v.GetRowCellValue(_v.FocusedRowHandle, "Amt").Equals(DBNull.Value) Then
                _v.SetRowCellValue(_v.FocusedRowHandle, "Amt", 0)
            End If
        End If
        '-->
    End Sub

    Private Sub EarnView_GotFocus(sender As Object, e As System.EventArgs) Handles EarnView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Payment")
    End Sub

    Private Sub EarnView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EarnView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _v
            .SetRowCellValue(e.RowHandle, "FKeyPayAllotID", GetPayAllotID)
            .SetRowCellValue(e.RowHandle, "WageType", 1)

            '<-- edited by tony20171023
            'Set DateStart and DateEnd
            Try
                _v.SetRowCellValue(e.RowHandle, "DateStart", GetDateStart)
                _v.SetRowCellValue(e.RowHandle, "DateEnd", GetDateEnd)
            Catch ex As Exception
                LogErrors("Failed to set DateStart and DateEnd on [EarnView.InitNewRow]. Error: " & ex.Message)
            End Try

            'If .FocusedColumn.FieldName.Equals("FKeyWageAsh") Then
            '_v.SetRowCellValue(e.RowHandle, "DateStart", GetDateStart)
            '_v.SetRowCellValue(e.RowHandle, "DateEnd", GetDateEnd)
            'End If
            '-->
        End With
    End Sub

    Private Sub EarnView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles EarnView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction

    End Sub

    Private Sub EarnView_LostFocus(sender As Object, e As System.EventArgs) Handles EarnView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub EarnView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EarnView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr,DateStarted,DateEnd,Amt,FKeyWageAsh")
    End Sub

    Private Sub EarnView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles EarnView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EarnView_ShownEditor(sender As Object, e As System.EventArgs) Handles EarnView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
        stopnaba = True
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

            'FKeyWageAsh
            If .GetRowCellValue(e.RowHandle, "FKeyWageAsh") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "FKeyWageAsh") Is Nothing Then
                .SetColumnError(.Columns("FKeyWageAsh"), "Invalid Wage Type")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("FKeyWageAsh"), "")
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
        SetExRate(sender, e)
        ViewValidatingEditor(sender, e)
    End Sub

#End Region

#Region "Deduction"

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

        ElseIf e.Column.FieldName.Equals("FKeyWageAsh") Then
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
            .SetRowCellValue(e.RowHandle, "FKeyPayAllotID", GetPayAllotID)
            .SetRowCellValue(e.RowHandle, "WageType", 2)

            '<!-- edited by tony20171023
            'Set DateStart and DateEnd
            Try
                _v.SetRowCellValue(e.RowHandle, "DateStart", GetDateStart)
                _v.SetRowCellValue(e.RowHandle, "DateEnd", GetDateEnd)
            Catch ex As Exception
                LogErrors("Failed to set DateStart and DateEnd on [DedView.InitNewRow]. Error: " & ex.Message)
            End Try
            'If .FocusedColumn.FieldName.Equals("FKeyWageAsh") Then
            '_v.SetRowCellValue(e.RowHandle, "DateStart", GetDateStart)
            '_v.SetRowCellValue(e.RowHandle, "DateEnd", GetDateEnd)
            'End If
            '-->
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
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub DedView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles DedView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub DedView_ShownEditor(sender As Object, e As System.EventArgs) Handles DedView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
        stopnaba = True
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

            'FKeyWageAsh
            If .GetRowCellValue(e.RowHandle, "FKeyWageAsh") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "FKeyWageAsh") Is Nothing Then
                .SetColumnError(.Columns("FKeyWageAsh"), "Invalid Wage Type")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("FKeyWageAsh"), "")
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
        SetExRate(sender, e)
        ViewValidatingEditor(sender, e)
    End Sub

#End Region

#Region "Amortization"

    Private Sub AmortView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AmortView.CellValueChanged
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _v.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub AmortView_GotFocus(sender As Object, e As System.EventArgs) Handles AmortView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Amortization")
    End Sub

    Private Sub AmortView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AmortView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _v
            .SetRowCellValue(e.RowHandle, "FKeyPayAllotID", GetPayAllotID)
            .SetRowCellValue(e.RowHandle, "WageType", 2)
        End With
    End Sub

    Private Sub AmortView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles AmortView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub AmortView_LostFocus(sender As Object, e As System.EventArgs) Handles AmortView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")

    End Sub

    Private Sub AmortView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AmortView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub AmortView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles AmortView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub AmortView_ShownEditor(sender As Object, e As System.EventArgs) Handles AmortView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
    End Sub

    Private Sub AmortView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles AmortView.ValidateRow
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

            'FKeyWageAsh
            If .GetRowCellValue(e.RowHandle, "FKeyWageAsh") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "FKeyWageAsh") Is Nothing Then
                .SetColumnError(.Columns("FKeyWageAsh"), "Invalid Wage Type")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("FKeyWageAsh"), "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub

    Private Sub AmortView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles AmortView.ValidatingEditor
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If _V.FocusedColumn.FieldName.Equals("FKeyCurr") Then
            Dim dv As DataView = ExRateView.DataSource
            dv.Sort = "FKeyCurr"
            Dim xrow As DataRowView() = dv.FindRows(e.Value)
            Dim ExRate As Double = xrow(0)("ExRate")
            _V.SetFocusedRowCellValue("ExRate", ExRate)
        End If

        If _V.FocusedColumn.FieldName.Equals("Amt") Then
            Dim dv As DataView = ExRateView.DataSource
            dv.Sort = "FKeyCurr"
            Dim xrow As DataRowView() = dv.FindRows(GetAllotCurrency())
            Dim Amt As Double = 0, ExRate As Double = 0, RefAmt As Double = 0, RefExRate As Double = 0
            Amt = CDbl(e.Value)
            ExRate = CDbl(_V.GetFocusedRowCellValue("ExRate"))
            RefExRate = CDbl(xrow(0)("ExRate"))
            RefAmt = Amt / ExRate
            _V.SetFocusedRowCellValue("CAmt", RefAmt * RefExRate)
        End If
        ViewValidatingEditor(sender, e)
    End Sub

#End Region

#End Region

#Region "AshEmp"

    Private Sub PayAshEmpView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _v.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub PayAshEmpView_GotFocus(sender As Object, e As System.EventArgs)
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Employer's Contribution")
    End Sub

    Private Sub PayAshEmpView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        _v.SetRowCellValue(e.RowHandle, "Edited", True)
        _v.SetRowCellValue(e.RowHandle, "FKeyPayCrewHA", GetCrewPayID)
    End Sub

    Private Sub PayAshEmpView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs)
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub PayAshEmpView_LostFocus(sender As Object, e As System.EventArgs)
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")

    End Sub

    Private Sub PayAshEmpView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub PayAshEmpView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs)
        BRECORDUPDATEDs = True
    End Sub

    Private Sub PayAshEmpView_ShownEditor(sender As Object, e As System.EventArgs)
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
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
        cboVessel.Properties.DataSource = dv
    End Sub

    Private Function FilterCurrencyTable() As DataTable
        'Return ctbl
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
            If tblAdmCurr.Select(strFilter).Length > 0 Then
                ctbl = tblAdmCurr.Select(strFilter).CopyToDataTable
            Else
                ctbl = tblAdmCurr
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

    Private Sub PayAshEmpView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        ViewValidatingEditor(sender, e)
    End Sub

#End Region

#End Region

#Region "Re-Process Crew"

    Private Function ReProcessCrew() As Boolean
        ShowCustomLoadScreen(GetType(PayrollWaitForm))

        Dim toBeInserted As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction

            Dim SelCrew() As Integer = CrewListView.GetSelectedRows


            'Delete tblPayCrew_HA
            For index = 0 To SelCrew.Count - 1
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTran
                    cmd.CommandText = "DELETE FROM dbo.tblPayCrew_HA WHERE PKey = @PayCrewID"
                    With cmd.Parameters
                        .AddWithValue("@PayCrewID", CrewListView.GetRowCellValue(SelCrew(index), "PKey"))
                    End With
                    toBeInserted = (cmd.ExecuteNonQuery > 0)
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

                'ReProcess HOME ALLOTMENT
                If toBeInserted Then
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = sqlConn
                        cmd.Transaction = sqlTran
                        cmd.CommandText = "SP_Pay_Process_HA"
                        cmd.CommandType = CommandType.StoredProcedure
                        With cmd.Parameters
                            .AddWithValue("@ProcessType", 1)
                            .AddWithValue("@PeriodDateStart", NumCodeToDate(cboPeriod.EditValue, 1).ToString("yyyy-MM-dd"))
                            .AddWithValue("@DateCreated", txtDateCreated.Text)
                            .AddWithValue("@RefNo", RefNo)
                            .AddWithValue("@FKeyPrincipal", FKeyPrincipal)
                            .AddWithValue("@tblExRate", ExRateDT)
                            .AddWithValue("@tblPayCrew", tblPayCrewDT)
                            .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                        End With
                        toBeInserted = (cmd.ExecuteNonQuery > 0)
                    End Using
                End If
            Next

            If toBeInserted Then
                sqlTran.Commit()
                retval = True
            End If

        Catch ex As Exception
            retval = False
            sqlTran.Rollback()
            MsgBox(ex.Message)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        CloseCustomLoadScreen()

        Return toBeInserted
    End Function

    Private Sub RunPayroll()
        GroupControl1.Focus()
        Dim PayCrewActID As String = String.Empty

        If CrewListView.GetSelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to reprocess crew(s): " & vbCrLf & GetCrewName(), MsgBoxStyle.Question + MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                PayCrewActID = GetPayCrewHAActID()
                Dim info As Boolean = True
                Dim strLastUpdatedBy As String = "LastUpdatedBy"
                info = ReProcessCrew()
                If info Then
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                    bLoaded = False
                    'cboPeriod.EditValue = Nothing
                    'RefreshData()
                    RefreshDataSet()
                    SetSelectionReProcesCrew(PayCrewActID)
                Else
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                End If
                BRECORDUPDATEDs = Not info
            End If
        Else
            MsgBox("Please select a Crew to reprocess.", MsgBoxStyle.Information, GetAppName)
        End If
    End Sub
    Private Sub SetSelectionReProcesCrew(id As String)
        Try
            Dim rowHandle As Integer = 0
            rowHandle = CrewListView.LocateByValue(0, CrewListView.Columns("ActID"), id)
            CrewListView.FocusedRowHandle = rowHandle
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Private Sub ClearFilterControls()
        'Throw New NotImplementedException
        cboPeriod.EditValue = Nothing
        cboPrincipal.EditValue = Nothing
        ClearCheckLookUp(cboVessel)
        ClearCheckLookUp(cboRefNo)
        ClearCrewItems()
    End Sub

#Region "Control Validations"

    Private Sub ControlValidations() 'sender As Object, e As System.EventArgs) 'Handles cboPeriod.EditValueChanged, cboPrincipal.EditValueChanged, cboVessel.EditValueChanged, cboRefNo.EditValueChanged
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

#End Region

#Region "Layout "
    Public Overrides Sub SaveMainContentLayout()
        'MyBase.SaveMainContentLayout()
        SaveUserSetting(Me.Name & SplitContainerControl1.Name & "_LAYOUT", SplitContainerControl1.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl2.Name & "_LAYOUT", SplitContainerControl2.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl3.Name & "_LAYOUT", SplitContainerControl3.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl5.Name & "_LAYOUT", SplitContainerControl5.SplitterPosition.ToString)
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        'MyBase.LoadMainContentLayout()
        SplitContainerControl1.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl1.Name & "_LAYOUT", Layout_S1))
        SplitContainerControl2.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl2.Name & "_LAYOUT", Layout_S2))
        SplitContainerControl3.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl3.Name & "_LAYOUT", Layout_S3))
        SplitContainerControl5.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl5.Name & "_LAYOUT", Layout_S5))
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

                EditSubAllowGrid(AllotteeView, False)
                EditSubAllowGrid(EarnView, False)
                EditSubAllowGrid(DedView, False)
                EditSubAllowGrid(PayAshEmpView, False)
                EditSubAllowGrid(ExRateView, False)

            Else
                txtPayStatus.Text = "Unlocked"
                AllowCalculatePay(Name, isEditdable)
                AllowEditing(Name, True)
                AllowSaving(Name, isEditdable)
                AllowDeletion(Name, True)
                txtPayStatus.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                txtPayStatus.Properties.Appearance.ForeColor = System.Drawing.Color.Green


                EditSubAllowGrid(AllotteeView, isEditdable)
                EditSubAllowGrid(EarnView, isEditdable)
                EditSubAllowGrid(DedView, isEditdable)
                EditSubAllowGrid(PayAshEmpView, isEditdable)
                EditSubAllowGrid(ExRateView, isEditdable, False)
            End If
        End If
    End Sub
#End Region

    Private Sub AllotteeView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles AllotteeView.FocusedRowObjectChanged
        If AllotteeView.RowCount > 0 Then
            LoadAllotteeTotals(GetPayAllotID)
            lciTotalPayment.Text = "Total Payment [" & AllotteeView.GetFocusedRowCellDisplayText("FKeyCurr") & "]"
            lciTotalDeduction.Text = "Total Deduction [" & AllotteeView.GetFocusedRowCellDisplayText("FKeyCurr") & "]"
            lciTotal.Text = "Total [" & AllotteeView.GetFocusedRowCellDisplayText("FKeyCurr") & "]"
            txtTotal.Text = CDbl(IfNull(txtTotalPayment.Text, CDbl(0))) - CDbl(IfNull(txtTotalDeduction.Text, CDbl(0)))
        Else
            lciTotalPayment.Text = "Total Payment"
            lciTotalDeduction.Text = "Total Deduction"
            lciTotal.Text = "Total "

            txtTotal.Text = 0.0
            txtTotalDeduction.Text = 0.0
            txtTotalPayment.Text = 0.0
        End If
    End Sub

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

    Private Sub AllotteeGrid_Click(sender As Object, e As System.EventArgs) Handles AllotteeGrid.Click
        stopnaba = True
    End Sub

    Private Sub AllotteeGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles AllotteeGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub DedGrid_Click(sender As Object, e As System.EventArgs) Handles DedGrid.Click
        stopnaba = True
    End Sub

    Private Sub DedGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DedGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub EarnGrid_Click(sender As Object, e As System.EventArgs) Handles EarnGrid.Click
        stopnaba = True
    End Sub

    Private Sub EarnGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles EarnGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub CrewListGrid_Click(sender As Object, e As System.EventArgs) Handles CrewListGrid.Click
        stopnaba = True
    End Sub

    Private Sub CrewListGrid_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListGrid.MouseClick
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub CrewListGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'neil com out
        'AddHandler AllotteeGrid.MouseMove, AddressOf clsgridflout.AddFlyOutEvent
        'AddHandler DedGrid.MouseMove, AddressOf clsgridflout.AddFlyOutEvent
        'AddHandler EarnGrid.MouseMove, AddressOf clsgridflout.AddFlyOutEvent
        'AddHandler CrewListGrid.MouseMove, AddressOf clsgridflout.AddFlyOutEvent

        'AddHandler AllotteeGrid.MouseClick, AddressOf clsgridflout.RemoveFlyOutEvent
        'AddHandler DedGrid.MouseClick, AddressOf clsgridflout.RemoveFlyOutEvent
        'AddHandler EarnGrid.MouseClick, AddressOf clsgridflout.RemoveFlyOutEvent
        'AddHandler CrewListGrid.MouseClick, AddressOf clsgridflout.RemoveFlyOutEvent
    End Sub

    Private Sub CrewListView_ShownEditor(sender As Object, e As System.EventArgs) Handles CrewListView.ShownEditor
        stopnaba = True
    End Sub

    Private Sub PayAshEmpView_CellValueChanged1(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles PayAshEmpView.CellValueChanged
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

        ElseIf e.Column.FieldName.Equals("FKeyWageAshEmp") Then
            If _v.GetRowCellValue(_v.FocusedRowHandle, "Amt").Equals(DBNull.Value) Then
                _v.SetRowCellValue(_v.FocusedRowHandle, "Amt", 0)
            End If

        End If
        '-->
    End Sub

    Private Sub PayAshEmpView_GotFocus1(sender As Object, e As System.EventArgs) Handles PayAshEmpView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Employer's Contribution")
    End Sub

    Private Sub PayAshEmpView_InitNewRow1(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles PayAshEmpView.InitNewRow
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _v
            .SetRowCellValue(e.RowHandle, "FKeyPayCrewHA", GetPayCrewHAID())

            'Set DateStart and DateEnd
            Try
                _v.SetRowCellValue(e.RowHandle, "DateStart", GetDateStart)
                _v.SetRowCellValue(e.RowHandle, "DateEnd", GetDateEnd)
            Catch ex As Exception
                LogErrors("Failed to set DateStart and DateEnd on [PayAshEmpView.InitNewRow]. Error: " & ex.Message)
            End Try
        End With
    End Sub

    Private Sub PayAshEmpView_InvalidRowException1(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles PayAshEmpView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub PayAshEmpView_LostFocus1(sender As Object, e As System.EventArgs) Handles PayAshEmpView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub PayAshEmpView_RowCellStyle1(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles PayAshEmpView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr,DateStart,DateEnd,Amt,FKeyWageAshEmp")
    End Sub

    Private Sub PayAshEmpView_RowUpdated1(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles PayAshEmpView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub PayAshEmpView_ShownEditor1(sender As Object, e As System.EventArgs) Handles PayAshEmpView.ShownEditor
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReloadRepositoryCurr(_v)
        stopnaba = True
    End Sub

    Private Sub PayAshEmpView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles PayAshEmpView.ValidateRow
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

            'FKeyWageAsh
            If .GetRowCellValue(e.RowHandle, "FKeyWageAshEmp") Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, "FKeyWageAshEmp") Is Nothing Then
                .SetColumnError(.Columns("FKeyWageAshEmp"), "Invalid Wage Type")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(.Columns("FKeyWageAshEmp"), "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With

    End Sub

    Private Sub PayAshEmpView_ValidatingEditor1(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles PayAshEmpView.ValidatingEditor
        SetExRate(sender, e)
        ViewValidatingEditor(sender, e)
    End Sub

    Private Sub LayoutControlGroup_CrewListCriteria_Click(sender As Object, e As System.EventArgs) Handles LayoutControlGroup_CrewListCriteria.Click
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub LayoutControlItem_Period_Click(sender As Object, e As System.EventArgs) Handles LayoutControlItem_Period.Click
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub LayoutControlItem_Principal_Click(sender As Object, e As System.EventArgs) Handles LayoutControlItem_Principal.Click
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub LayoutControlItem_RefNo_Click(sender As Object, e As System.EventArgs) Handles LayoutControlItem_RefNo.Click
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub LayoutControlItem_Vessel_Click(sender As Object, e As System.EventArgs) Handles LayoutControlItem_Vessel.Click
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub
End Class
