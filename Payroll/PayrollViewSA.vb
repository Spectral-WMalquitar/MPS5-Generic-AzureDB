Imports System.Windows.Forms

Public Class PayrollViewSA

#Region "Declaration"

    Private RptControl As PayrollReportControl
    Dim frmPayrollList As frmPayrollList
    Dim SelectedView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

    Dim clsgridflout As New clsGridFlyOut
#Region "DataTable"
    Dim tblPrin As New DataTable, tblVsl As New DataTable
    Dim tblRef As New DataTable
    Dim tblCrewList As New DataTable
    Dim tblmpo As New DataTable
    Dim tblAllot As New DataTable
    Dim tblAllotWage As New DataTable
    Dim SAPayDT As New DataSet
#End Region

    Private Sub GenerateTableValues()
        Dim sqlconn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlconn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlconn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_GetMPO_LIST"
                cmd.Parameters.AddWithValue("@MCode", cboPeriod.EditValue)

                Using sqladp As New SqlClient.SqlDataAdapter(cmd)
                    SAPayDT = New DataSet()
                    sqladp.Fill(SAPayDT, "SAPay")
                    With SAPayDT
                        .Tables(0).TableName = "MPO"
                        tblmpo = .Tables("MPO")
                        .Tables(1).TableName = "Allot"
                        tblAllot = .Tables("Allot")
                        .Tables(2).TableName = "AllotWage"
                        tblAllotWage = .Tables("AllotWage")
                    End With
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If sqlconn.State = ConnectionState.Open Then
                sqlconn.Close()
            End If
        End Try

    End Sub

    Private Sub CreateSADataSet()

        GenerateTableValues()
        If tblmpo.Rows.Count > 0 And tblAllot.Rows.Count > 0 And tblAllotWage.Rows.Count > 0 Then
            With SAPayDT
                If Not SAPayDT.Relations.Contains("MPO_Allot_Rel") And Not SAPayDT.Relations.Contains("Allot_Wages_Rel") Then
                    .Relations.Add("MPO_Allot_Rel", .Tables("MPO").Columns("PKey"), .Tables("Allot").Columns("FKeyMPO")) 'Relationship for MPO and Allot
                    .Relations.Add("Allot_Wages_Rel", .Tables("Allot").Columns("PKey"), .Tables("AllotWage").Columns("FKeyMPOAllot")) 'Relationship of Allow and wages
                End If
            End With
            If SAPayDT.Tables("Allot").Rows.Count > 0 Then
                AllotGrid.DataSource = SAPayDT.Tables("Allot")
            Else
                AllotGrid.DataSource = SAPayDT.Tables("Allot").Clone
            End If

            If SAPayDT.Tables("AllotWage").Select("WageType=1").Length > 0 Then
                EarnGrid.DataSource = SAPayDT.Tables("AllotWage").Select("WageType=1").CopyToDataTable
            Else
                EarnGrid.DataSource = SAPayDT.Tables("AllotWage").Clone
            End If
            If SAPayDT.Tables("AllotWage").Select("WageType=2").Length > 0 Then
                DedGrid.DataSource = SAPayDT.Tables("AllotWage").Select("WageType=2").CopyToDataTable
            Else
                DedGrid.DataSource = SAPayDT.Tables("AllotWage").Clone
            End If
        Else
            tblAllot = Nothing
            tblAllotWage = Nothing
            tblmpo = Nothing
        End If

    End Sub

#Region "Layout Constants"
    Private Const Layout_S1 As Integer = 294
    Private Const Layout_S2 As Integer = 299
    Private Const Layout_S3 As Integer = 283
#End Region

#End Region

#Region "Initialization"

    Private Sub InitControls()
        Try
            LayoutControl1.AllowCustomization = False
            LayoutControl2.AllowCustomization = False
            frmPayrollList = New frmPayrollList("MPO")

            'Principal
            Dim PrinFlter As String = IIf(GetUserFilterString(, , "PKey", ).Length > 0, " WHERE " & GetUserFilterString(, , "PKey", ), "")
            tblPrin = DB.CreateTable("SELECT * FROM dbo.PrincipalList " & PrinFlter & " ORDER BY Name")
            cboPrincipal.Properties.DataSource = tblPrin
            'Vessel
            tblVsl = DB.CreateTable("SELECT * FROM dbo.VslList ORDER BY Name")
            cboVsl.Properties.DataSource = tblVsl
            'Period
            'cboPeriod.Properties.DataSource = GetPayPeriods()
            cboPeriod.Properties.DataSource = GetPayPeriods("MONTH", 60, 3)

            'Allottee Details
            repFKeyCntry.DataSource = DB.CreateTable("SELECT * FROM CntryList ORDER BY Name")
            repBranch.DataSource = DB.CreateTable("SELECT * FROM dbo.frmBranchList ORDER BY Name")
            repFKeyBank.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmBank ORDER BY Name")
            Dim tblCurr As DataTable = DB.CreateTable("SELECT * FROM dbo.tblAdmCurr ORDER BY Symbol")
            repFKeyCurr.DataSource = tblCurr

            'Allottee Wages
            Dim tblWages As DataTable
            tblWages = DB.CreateTable("SELECT * FROM dbo.tblAdmWageAsh ORDER BY Name, SortCode")
            repEarn.DataSource = tblWages.Select("WageType=1").CopyToDataTable
            repDedWages.DataSource = tblWages.Select("WageType=2").CopyToDataTable
            repDedCurr.DataSource = tblCurr
            repEarnCurr.DataSource = tblCurr

            EarnGrid.DataSource = CreateWagesDT()
            DedGrid.DataSource = CreateWagesDT()

            'Init Reports 
            InitReportControls()

            SetProcessedPayrollListVisibility(Name, True)

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try


    End Sub

    Private Function InitRefNo() As DataTable
        Dim retVal As New DataTable
        Dim dvRef As New DataView(tblCrewList)
        'retVal = dvRef.ToTable(True, New String() {"MpoID", "RefNo", "FKeyPrincipal", "FKeyVsl"})
        If Not IsNothing(tblCrewList) Then
            If tblCrewList.Rows.Count > 0 Then
                retVal = dvRef.ToTable(True, New String() {"MpoID", "RefNo", "FKeyPrincipal", "FKeyVsl"})
            Else
                retVal = Nothing
            End If
        End If

        Return retVal
    End Function

    Private Function CreateWagesDT() As DataTable
        Dim retval As New DataTable
        With retval.Columns
            '.Add("TKey", GetType(Long))
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

    Private Sub ClearObject()
        'tblCrewList = New DataTable
        'tblmpo = New DataTable
        'tblAllot = New DataTable
        'tblAllotWage = New DataTable
        cboPeriod.EditValue = Nothing
        cboPrincipal.EditValue = Nothing
        'cboVsl.EditValue = Nothing
        cboRefNum.EditValue = Nothing
        CrewListGrid.DataSource = Nothing
        AllotGrid.DataSource = Nothing
        EarnGrid.DataSource = Nothing
        DedGrid.DataSource = Nothing
        ClearFields(LayoutControlGroup4, False)
        ClearFields(LayoutControlGroup10, False)
        CrewListView.ActiveFilter.Clear()

    End Sub

    Private Sub ClearVslList()
        cboVsl.EditValue = Nothing
        ClearCrewList()
    End Sub

    Private Sub ClearCrewList()
        'CrewListGrid.DataSource = Nothing
        'ClearPayrollDetails()
    End Sub

    Private Sub ClearPayrollDetails()
        ClearFields(LayoutControlGroup4, False) 'clear Payroll Details
        ClearFields(LayoutControlGroup10, False) 'Clear Crew Details
        ClearAllot()
    End Sub

    Private Sub ClearAllot()
        AllotGrid.DataSource = Nothing
        EarnGrid.DataSource = Nothing
        DedGrid.DataSource = Nothing
    End Sub

    Private Sub InitReportControls()
        'Dim payRepCtr As New PayrollReportControl(DB, Name)
        RptControl = New PayrollReportControl(DB, Name)
        SplitContainerControl3.Panel1.Controls.Clear()
        SplitContainerControl3.Panel1.Controls.Add(RptControl)
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
        SplitContainerControl2.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        SetPreviewReportEnabled(Name, False)
        'end tony
    End Sub

#End Region

#Region "Sub Form Details"

    Private Sub LoadCrewList()
        Dim DateFrom As String = ChangeToSQLDate(NumCodeToDate(cboPeriod.EditValue, 1))
        Dim DateTo As String = ChangeToSQLDate(NumCodeToDate(cboPeriod.EditValue, GetDaysOfMonth(NumCodeToDate(cboPeriod.EditValue, 1))))
        Dim crewFilter As String = IIf(Trim(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")).Length > 0, " AND " & GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt"), "")
        CreateSADataSet()
        If Not IsNothing(tblAllot) Then
            tblCrewList = New DataView(tblAllot).ToTable(True, New String() {"MpoID", "FKeyIDNbr", "CrewName", "FKeyVsl", "VesselName", "FKeyPrincipal", "PrincipalName", "FKeyRank", "RankName", "RankSort", "RefNo", "MCode", "WageScaleRank", "isLocked"})
            CrewListGrid.DataSource = tblCrewList
            With CrewListView
                .BeginSort()
                .Columns("RankSort").SortIndex = 0
                .Columns("RankSort").SortOrder = ColumnSortOrder.Ascending
                .Columns("CrewName").SortIndex = 1
                .Columns("CrewName").SortOrder = ColumnSortOrder.Ascending
                .EndSort()
            End With
        End If

        'EdiDeleteAllow(CrewListView)

    End Sub

    Private Sub LoadWages()
        EarnView.ActiveFilter.NonColumnFilter = "FKeyMPOAllot='" & IfNull(AllotView.GetFocusedRowCellValue("PKey"), "") & "'"
        DedView.ActiveFilter.NonColumnFilter = "FKeyMPOAllot='" & IfNull(AllotView.GetFocusedRowCellValue("PKey"), "") & "'"
    End Sub

    Private Sub LoadAllotteeDetails()
        'Allottee Details
        '-------------------------------------
        Dim nRow As Integer = -1
        If AllotView.RowCount > 0 Then
            nRow = AllotView.FocusedRowHandle
        End If
        AllotView.ActiveFilter.NonColumnFilter = "FKeyMPO='" & IfNull(CrewListView.GetFocusedRowCellValue("MpoID"), "") & "' AND FKeyIDNbr ='" & IfNull(CrewListView.GetFocusedRowCellValue("FKeyIDNbr"), "") & "'"
        If AllotView.RowCount > 0 Then
            AllotView.FocusedRowHandle = nRow
            AllotView.SelectRow(nRow)
        End If
        '-------------------------------------
        LoadWages()
    End Sub

#End Region

#Region "Filters"

    Private Sub cboPeriod_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriod.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
        End If
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        Dim _lookup As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        cboPrincipal.EditValue = Nothing
        cboVsl.EditValue = Nothing
        cboRefNum.EditValue = Nothing
        If Not IsNothing(_lookup.EditValue) Then
            LoadCrewList()
            cboRefNum.Properties.DataSource = InitRefNo()
        Else
            ClearObject()
        End If

    End Sub

    Private Sub cboPrincipal_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPrincipal.ButtonPressed
        Dim _lookup As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            If Not IsNothing(_lookup.EditValue) Then
                LoadCrewList()
            Else
                ClearVslList()
            End If
            _lookup.EditValue = Nothing
            cboRefNum.Properties.DataSource = InitRefNo()
        End If

    End Sub

    Private Sub cboPrincipal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPrincipal.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        cboVsl.EditValue = Nothing
        cboRefNum.EditValue = Nothing
        If Not IsNothing(LookUpEd.EditValue) Then
            If Not LookUpEd.EditValue.Equals("") Then
                Dim dv As New DataView(tblVsl)
                dv.RowFilter = "FKeyPrincipal='" & LookUpEd.EditValue & "'"
                cboVsl.Properties.DataSource = dv

                Dim drv As New DataView(InitRefNo)
                drv.RowFilter = "FKeyPrincipal='" & LookUpEd.EditValue & "'"
                cboRefNum.Properties.DataSource = drv
            End If
        Else
            cboVsl.Properties.DataSource = tblVsl
            ClearVslList()
        End If
        CrewListView.ActiveFilter.NonColumnFilter = IIf(Len(IfNull(LookUpEd.EditValue, "")) > 0, "FKeyPrincipal='" & LookUpEd.EditValue & "'", "")

    End Sub

    Private Sub cboVsl_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboVsl.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
        End If
    End Sub

    Private Sub cboVsl_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVsl.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        cboRefNum.EditValue = Nothing
        If Not IsNothing(LookUpEd.EditValue) Then
            If Not LookUpEd.EditValue.Equals("") Then
                Dim drv As New DataView(InitRefNo)
                drv.RowFilter = "FKeyVsl='" & LookUpEd.EditValue & "'"
                cboRefNum.Properties.DataSource = drv
            End If
        Else
            cboRefNum.Properties.DataSource = InitRefNo()
            cboVsl.Properties.DataSource = Nothing
            ClearCrewList()
        End If
        CrewListView.ActiveFilter.NonColumnFilter = IIf(Len(IfNull(LookUpEd.EditValue, "")) > 0, "FKeyVsl='" & LookUpEd.EditValue & "'", "")
    End Sub

    Private Sub cboRefNum_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRefNum.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
        End If
    End Sub

    Private Sub cboRefNum_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboRefNum.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        CrewListView.ActiveFilter.NonColumnFilter = IIf(Len(IfNull(LookUpEd.EditValue, "")) > 0, "MpoID='" & LookUpEd.EditValue & "'", "")
    End Sub

#End Region

#Region "Crew List"

    Private Sub GenerateSelectCrewDetails()
        With CrewListView
            'Crew List
            SAtxtPeriod.Text = NumCodeToDate(cboPeriod.EditValue, 1).ToString("MMMM-yyyy")
            SAcboPrincipal.Text = IfNull(.GetFocusedRowCellValue("PrincipalName"), "")
            SAcboVsl.Text = IfNull(.GetFocusedRowCellValue("VesselName"), "")
            SAcboRefNum.Text = IfNull(.GetFocusedRowCellValue("RefNo"), "")
            SAtxtDateCreated.Text = IfNull(.GetFocusedRowCellValue("DateCreated"), "")

            'Crew Details
            SAtxtCrewName.Text = IfNull(.GetFocusedRowCellValue("CrewName"), "")
            'SAtxtCompID.Text = IfNull(.GetFocusedRowCellValue("COIDNbr"), "")
            txtWageScaleName.Text = IfNull(.GetFocusedRowCellValue("WageScaleName"), "")
            SAcboRank.Text = IfNull(.GetFocusedRowCellValue("RankName"), "")
            txtWageScaleName.Text = IfNull(.GetFocusedRowCellValue("WageScaleRank"), "")
            'Allottee Details
            LoadAllotteeDetails()

        End With


    End Sub

    Private Sub CrewListView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles CrewListView.FocusedRowObjectChanged
        GenerateSelectCrewDetails()
        PayrollLock()
    End Sub

    Private Sub CrewListView_GotFocus(sender As Object, e As System.EventArgs) Handles CrewListView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Crew")
    End Sub

    Private Sub CrewListView_LostFocus(sender As Object, e As System.EventArgs) Handles CrewListView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub
#End Region

#Region "Allottee"

    Private Sub AllotView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AllotView.CellValueChanged
        Dim _vw As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _vw.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub AllotView_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles AllotView.FocusedColumnChanged
        Dim _View As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _View.RowCount > 0 Then
            If e.PrevFocusedColumn.FieldName.Equals("FKeyCurr") Then
                If MsgBox("Changing the Bank Currency will modify the exchange rate of the allottee earnings and deductions? " & _
                          vbCrLf & "Are you sure you want to continue?", vbQuestion + vbDefaultButton2 + vbYesNo, GetAppName()) = MsgBoxResult.Yes Then
                    RefreshWagesExRate(_View.GetFocusedRowCellValue("FKeyIDNbr"), _View.GetFocusedRowCellValue("PKey"))
                End If
            End If
        End If

    End Sub

    Private Sub AllotView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles AllotView.FocusedRowChanged
        LoadWages()
    End Sub

    Private Sub AllotView_GotFocus(sender As Object, e As System.EventArgs) Handles AllotView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Allotee")
    End Sub

    Private Sub AllotView_LostFocus(sender As Object, e As System.EventArgs) Handles AllotView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub AllotView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AllotView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#Region "Wages"

    Private Sub RefreshWagesExRate(FKeyIDNbr As String, MPO_Allot_ID As String)
        'Earnigns
        For index = 0 To EarnView.RowCount
            EarnView.SetRowCellValue(index, "ExRate", 0)
            EarnView.SetRowCellValue(index, "FKeyCurr", AllotView.GetFocusedRowCellValue("FKeyCurr"))
        Next

        'Deductions
        For index = 0 To DedView.RowCount
            DedView.SetRowCellValue(index, "ExRate", 0)
            DedView.SetRowCellValue(index, "FKeyCurr", AllotView.GetFocusedRowCellValue("FKeyCurr"))
        Next

    End Sub

#Region "Earnings"

    Private Sub EarnView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EarnView.CellValueChanged
        Dim _vw As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _vw.SetRowCellValue(e.RowHandle, "Edited", True)
            If e.Column.FieldName.Equals("FKeyWages") Then
                _vw.SetRowCellValue(e.RowHandle, "FKeyCurr", AllotView.GetRowCellValue(AllotView.FocusedRowHandle, "FKeyCurr"))
                _vw.SetRowCellValue(e.RowHandle, "FKeyMPOAllot", AllotView.GetRowCellValue(AllotView.FocusedRowHandle, "PKey"))
                _vw.SetRowCellValue(e.RowHandle, "Amt", 0)
                _vw.SetRowCellValue(e.RowHandle, "cAmt", 0)
                _vw.SetRowCellValue(e.RowHandle, "ExRate", 1)
            End If
        End If
    End Sub

    Private Sub EarnView_GotFocus(sender As Object, e As System.EventArgs) Handles EarnView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Earning")
    End Sub

    Private Sub EarnView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EarnView.InitNewRow
        Dim _View As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _View
            _View.SetRowCellValue(e.RowHandle, "Edited", True)
            _View.SetRowCellValue(e.RowHandle, "FKeyMPOAllot", AllotView.GetRowCellValue(AllotView.FocusedRowHandle, "PKey"))
            .SetRowCellValue(e.RowHandle, "FKeyIDNbr", AllotView.GetRowCellValue(AllotView.FocusedRowHandle, "FKeyIDNbr"))
            .SetRowCellValue(e.RowHandle, "WageType", 1) 'Earnings: WageType = 1 ; Deduction: WageType=2
        End With
    End Sub

    Private Sub EarnView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles EarnView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EarnView_LostFocus(sender As Object, e As System.EventArgs) Handles EarnView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub EarnView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EarnView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr,FKeyWages,ExRate,Amt")
    End Sub

    Private Sub EarnView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles EarnView.ValidatingEditor
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _view.RowCount > 0 Then
            If _view.FocusedColumn.FieldName.Equals("ExRate") Then
                Dim CAmt As Double = IfNull(_view.GetFocusedRowCellValue("Amt"), 0) * IfNull(e.Value, 0)
                _view.SetFocusedRowCellValue("cAmt", CAmt)
            End If
            If _view.FocusedColumn.FieldName.Equals("Amt") Then
                Dim CAmt As Double = IfNull(_view.GetFocusedRowCellValue("ExRate"), 0) * IfNull(e.Value, 0)
                _view.SetFocusedRowCellValue("cAmt", CAmt)
            End If
        End If

    End Sub

#End Region

#Region "Deductions"

    Private Sub DedView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DedView.CellValueChanged
        Dim _vw As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not e.Column.FieldName.Equals("Edited") Then
            _vw.SetRowCellValue(e.RowHandle, "Edited", True)
            If e.Column.FieldName.Equals("FKeyWages") Then
                _vw.SetRowCellValue(e.RowHandle, "FKeyCurr", AllotView.GetRowCellValue(AllotView.FocusedRowHandle, "FKeyCurr"))
                _vw.SetRowCellValue(e.RowHandle, "FKeyMPOAllot", AllotView.GetRowCellValue(AllotView.FocusedRowHandle, "PKey"))
                _vw.SetRowCellValue(e.RowHandle, "Amt", 0)
                _vw.SetRowCellValue(e.RowHandle, "cAmt", 0)
                _vw.SetRowCellValue(e.RowHandle, "ExRate", 1)
            End If
        End If
    End Sub

    Private Sub DedView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DedView.InitNewRow
        Dim _View As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _View
            _View.SetRowCellValue(e.RowHandle, "Edited", True)
            _View.SetRowCellValue(e.RowHandle, "FKeyMPOAllot", AllotView.GetRowCellValue(AllotView.FocusedRowHandle, "PKey"))
            .SetRowCellValue(e.RowHandle, "FKeyIDNbr", AllotView.GetRowCellValue(AllotView.FocusedRowHandle, "FKeyIDNbr"))
            .SetRowCellValue(e.RowHandle, "WageType", 2) 'Earnings: WageType = 1 ; Deduction: WageType=2
        End With
    End Sub

    Private Sub DedView_GotFocus(sender As Object, e As System.EventArgs) Handles DedView.GotFocus
        SelectedView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        SetDeleteCaption(Name, "Delete Deduction")
    End Sub

    Private Sub DedView_LostFocus(sender As Object, e As System.EventArgs) Handles DedView.LostFocus
        SelectedView = Nothing
        SetDeleteCaption(Name, "Delete Payroll")
    End Sub

    Private Sub DedView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles DedView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub DedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DedView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr,FKeyWages,ExRate,Amt")
    End Sub

    Private Sub DedView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DedView.ValidatingEditor
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _view.RowCount > 0 Then
            If _view.FocusedColumn.FieldName.Equals("ExRate") Then
                Dim CAmt As Double = IfNull(_view.GetFocusedRowCellValue("Amt"), 0) * IfNull(e.Value, 0)
                _view.SetFocusedRowCellValue("cAmt", CAmt)
            End If
            If _view.FocusedColumn.FieldName.Equals("Amt") Then
                Dim CAmt As Double = IfNull(_view.GetFocusedRowCellValue("ExRate"), 0) * IfNull(e.Value, 0)
                _view.SetFocusedRowCellValue("cAmt", CAmt)
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Main Functions"

    'Refresh
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        SetCalculatePayVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPayrollListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        TabbedControlGroup2.SelectedTabPageIndex = 0 'Default Select the Earning Tab
        SetDeleteCaption(Name, "Delete Payroll")
        AllowCalculatePay(Name, False)
        ClearObject()

        SetRibbonPageGroupVisibility(Name, "rpgPayrollReportOptions", True) 'neil 20160914
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetClearFilterVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'neil 
        SetShowListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'fords
        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

        AllowPrintPreview(Name, True)
        'If Not bLoaded Then
        InitControls()
        '    bLoaded = True
        'End If
        ControlValidations()
        MakeReadOnlyListener(LayoutControlGroup4)
        MakeReadOnlyListener(LayoutControlGroup10)
        EditSubAllowGrid(AllotView, False, False)
        EditSubAllowGrid(EarnView, False)
        EditSubAllowGrid(DedView, False)
        EdiDeleteAllow(CrewListView)
        BRECORDUPDATEDs = False
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            RemoveReadOnlyListener(LayoutControlGroup4)
            RemoveReadOnlyListener(LayoutControlGroup10)
        Else
            MakeReadOnlyListener(LayoutControlGroup4)
            MakeReadOnlyListener(LayoutControlGroup10)
        End If
        EditSubAllowGrid(AllotView, isEditdable, False)
        EditSubAllowGrid(EarnView, isEditdable)
        EditSubAllowGrid(DedView, isEditdable)
        EdiDeleteAllow(CrewListView)
        'AllowDeletion(Name, isEditdable)

    End Sub

    'Save
    Public Overrides Sub SaveData()
        GroupControl1.Focus()
        Dim payCrewID As String = String.Empty
        If BRECORDUPDATEDs Then
            Dim info As Boolean = False
            payCrewID = GetMPOCrewID()
            If ValidatePayroll() Then

                info = SavEditedSpecialAllotment()
            End If
            If info Then
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName())
                'RefreshData()
                GenerateTableValues()
                SetPayCrewListSelection(payCrewID)
                BRECORDUPDATEDs = False
                EditCheck(Name, False)
            Else
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Exclamation, GetAppName())
            End If
        End If
    End Sub

    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()

    End Sub

    'Custom Function
    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case (param(0))
            Case "PREVIEWREPORT"
                ShowPayReports()
            Case "CLEARFILTER"
                ClearObject()
            Case "PayrollList"
                frmPayrollList = New frmPayrollList("MPO")
                frmPayrollList.ShowDialog(Me)
                If frmPayrollList.RefreshCallingForm Then cboPeriod.EditValue = Nothing
                GetSelectedPay()

            Case "VIEWQUICKREPORTS"
                If SplitContainerControl2.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1 Then
                    SplitContainerControl2.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                    SetQuickReportsCaption(Name, "Hide Quick Reports")
                    SetPreviewReportEnabled(Name, True)
                Else
                    SplitContainerControl2.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
                    SetQuickReportsCaption(Name, "View Quick Reports")
                    SetPreviewReportEnabled(Name, False)
                End If
        End Select

    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        'Return MyBase.CheckValidateFields(showMsg)
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If EarnView.HasColumnErrors() Or DedView.HasColumnErrors Or EarnView.HasColumnErrors Then
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
            'RefreshDataSet()
            'GenerateTableValues()
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Private Function ValidatePayroll() As Boolean
        Dim retval As Boolean = False

        If AllotView.HasColumnErrors Or EarnView.HasColumnErrors Or DedView.HasColumnErrors Then
            retval = False
        Else
            retval = True
        End If
        Return retval
    End Function


#End Region

#Region "Editing Save Functions"

    Private Function SaveWages(sqlConn As SqlClient.SqlConnection, sqlTrans As SqlClient.SqlTransaction, _
                            WageDRV As DataRowView, _
                            _strID As String) As Boolean

        Dim retVal As Boolean = False
        Try
            If IfNull(WageDRV.Row("PKey"), "").Equals("") Then
                'Insert Record
                'Updated Record
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTrans
                    cmd.CommandText = "INSERT INTO dbo.tblmpo_wage( " & _
                        " [FKeyMPOAllot] " & _
                        ",[FKeyWages] " & _
                        ",[WageType] " & _
                        ",[FKeyCurr] " & _
                        ",[Amt] " & _
                        ",[cAmt] " & _
                        ",[ExRate] " & _
                        ") VALUES( " & _
                        " @FKeyMPOAllot " & _
                        " ,@FKeyWages " & _
                        " ,@WageType " & _
                        " ,@FKeyCurr " & _
                        " ,@Amt " & _
                        " ,@cAmt " & _
                        " ,@ExRate )"
                    With cmd.Parameters
                        '.AddWithValue("@PKey", IfNull(_View.GetRowCellValue(rowHandle, "PKey"), ""))
                        .AddWithValue("@FKeyMPOAllot", IfNull(_strID, ""))
                        .AddWithValue("@FKeyWages", IfNull(WageDRV.Row("FKeyWages"), ""))
                        .AddWithValue("@WageType", IfNull(WageDRV.Row("WageType"), ""))
                        .AddWithValue("@FKeyCurr", IfNull(WageDRV.Row("FKeyCurr"), ""))
                        .AddWithValue("@Amt", IfNull(WageDRV.Row("Amt"), ""))
                        .AddWithValue("@cAmt", IfNull(WageDRV.Row("cAmt"), ""))
                        .AddWithValue("@ExRate", IfNull(WageDRV.Row("ExRate"), ""))
                    End With
                    retVal = cmd.ExecuteNonQuery().Equals(1)
                End Using
            Else
                'Updated Record
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTrans
                    cmd.CommandText = "UPDATE dbo.tblmpo_wage SET " & _
                        " [FKeyMPOAllot]=@FKeyMPOAllot " & _
                        " ,[FKeyWages]=@FKeyWages " & _
                        " ,[WageType]=@WageType " & _
                        " ,[FKeyCurr]=@FKeyCurr " & _
                        " ,[Amt]=@Amt " & _
                        " ,[cAmt]=@cAmt " & _
                        " ,[ExRate]=@ExRate " & _
                        " WHERE [PKey] = @PKey"
                    With cmd.Parameters
                        .AddWithValue("@PKey", IfNull(WageDRV.Row("PKey"), ""))
                        .AddWithValue("@FKeyMPOAllot", IfNull(WageDRV.Row("FKeyMPOAllot"), ""))
                        .AddWithValue("@FKeyWages", IfNull(WageDRV.Row("FKeyWages"), ""))
                        .AddWithValue("@WageType", IfNull(WageDRV.Row("WageType"), ""))
                        .AddWithValue("@FKeyCurr", IfNull(WageDRV.Row("FKeyCurr"), ""))
                        .AddWithValue("@Amt", IfNull(WageDRV.Row("Amt"), ""))
                        .AddWithValue("@cAmt", IfNull(WageDRV.Row("cAmt"), ""))
                        .AddWithValue("@ExRate", IfNull(WageDRV.Row("ExRate"), ""))
                    End With
                    retVal = cmd.ExecuteNonQuery().Equals(1)
                End Using
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            retVal = False
        End Try

        Return retVal
    End Function

    Private Function SaveAllottee(sqlConn As SqlClient.SqlConnection, sqlTrans As SqlClient.SqlTransaction, _
                                  AllotDRV As DataRowView) As Boolean
        Dim retVal As Boolean = False
        Try

            'Updated Record
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTrans
                cmd.CommandText = "UPDATE dbo.tblmpo_allot SET " & _
                    " [AcctName]=@AcctName " & _
                    " ,[AcctNbr]=@AcctNbr " & _
                    " ,[FKeyCurr]=@FKeyCurr " & _
                    " ,[FKeyBank]=@FKeyBank " & _
                    " ,[FKeyBranch]=@FKeyBranch " & _
                    " ,[BranchCntryCode]=@BranchCntryCode " & _
                    "WHERE [PKey] = @PKey"
                With cmd.Parameters
                    .AddWithValue("@PKey", IfNull(AllotDRV.Row("PKey"), ""))
                    .AddWithValue("@AcctName", IfNull(AllotDRV.Row("AcctName"), ""))
                    .AddWithValue("@AcctNbr", IfNull(AllotDRV.Row("AcctNbr"), ""))
                    .AddWithValue("@FKeyCurr", IfNull(AllotDRV.Row("FKeyCurr"), ""))
                    .AddWithValue("@FKeyBank", IfNull(AllotDRV.Row("FKeyBank"), ""))
                    .AddWithValue("@FKeyBranch", IfNull(AllotDRV.Row("FKeyBranch"), ""))
                    .AddWithValue("@BranchCntryCode", IfNull(AllotDRV.Row("BranchCntryCode"), ""))
                End With
                retVal = cmd.ExecuteNonQuery().Equals(1)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            retVal = False
        End Try
        Return retVal
    End Function

    Private Function SavEditedSpecialAllotment() As Boolean
        Dim retval As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString())
        Dim sqlTrans As SqlClient.SqlTransaction = Nothing
        Dim tobeInserted As Boolean = False
        Try
            sqlConn.Open()
            sqlTrans = sqlConn.BeginTransaction

            Dim AllotDV As DataView = AllotView.DataSource
            For Each AllotDRV As DataRowView In AllotDV
                If AllotDRV.Row("Edited").Equals(True) Then
                    'SaveAllotte
                    tobeInserted = SaveAllottee(sqlConn, sqlTrans, AllotDRV)
                End If

                'Earnings
                Dim EarnDV As DataView = EarnView.DataSource
                EarnDV.Sort = "FKeyMPOAllot"
                EarnDV.RowFilter = "FKeyMPOAllot='" & AllotDRV.Row("PKey") & "'"
                If EarnDV.Count > 0 Then
                    For Each EarnDRV As DataRowView In EarnDV
                        If EarnDRV.Row("Edited") Then
                            tobeInserted = SaveWages(sqlConn, sqlTrans, EarnDRV, IfNull(AllotDRV.Row("PKey"), ""))

                        End If
                    Next
                End If

                'Deductions
                Dim DedDV As DataView = DedView.DataSource
                DedDV.Sort = "FKeyMPOAllot"
                DedDV.RowFilter = "FKeyMPOAllot='" & AllotDRV.Row("PKey") & "'"
                If DedDV.Count > 0 Then
                    For Each DedDRV As DataRowView In DedDV
                        If DedDRV.Row("Edited") Then
                            tobeInserted = SaveWages(sqlConn, sqlTrans, DedDRV, IfNull(AllotDRV.Row("PKey"), ""))
                        End If
                    Next
                End If
            Next


            If tobeInserted Then
                sqlTrans.Commit()
                retval = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            sqlTrans.Rollback()
            retval = False
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try

        Return retval
    End Function

#End Region

#Region "Reports"

    'Show Pay Reports
    Private Sub ShowPayReports()
        'Throw New NotImplementedException
        RptControl.ShowPayrollReport(cboPeriod.EditValue, cboPrincipal.EditValue, cboVsl.EditValue, cboRefNum.EditValue)
    End Sub

#End Region

    Private Sub GetSelectedPay()
        If frmPayrollList.ApplyFilter Then
            cboPeriod.EditValue = frmPayrollList.PayPeriod
            cboPrincipal.EditValue = frmPayrollList.PayPrincipal
            cboVsl.EditValue = frmPayrollList.PayVessel
            cboRefNum.Properties.DataSource = InitRefNo()
            cboRefNum.EditValue = frmPayrollList.PayPayID
        End If
    End Sub

    Private Sub ControlValidations() Handles cboPeriod.EditValueChanged, cboPrincipal.EditValueChanged, cboVsl.EditValueChanged, cboRefNum.EditValueChanged
        If IsNothing(cboPeriod.EditValue) Then
            cboPrincipal.Enabled = False
            cboVsl.Enabled = False
            cboRefNum.Enabled = False
        Else
            If Len(cboPeriod.EditValue) <= 0 Then
                cboPrincipal.Enabled = False
                cboVsl.Enabled = False
                cboRefNum.Enabled = False
            Else
                cboPrincipal.Enabled = True
                cboVsl.Enabled = True
                cboRefNum.Enabled = True
            End If
        End If
    End Sub

#Region "Delete"

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = False

        If Not IsNothing(SelectedView) Then
            With SelectedView
                Select Case SelectedView.Name
                    Case AllotView.Name
                        If MsgBox("Are you sure you want to delete Allottee? [" & .GetFocusedRowCellDisplayText("AllotName") & " - " & .GetFocusedRowCellDisplayText("AllotName") & "] ?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + vbYesNo, GetAppName) = MsgBoxResult.Yes Then
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "Special Allotment", _
                                "Crewing", _
                                "tblmpo_allot", _
                                "PKey IN ('" & .GetFocusedRowCellValue("PKey") & "')", _
                                "<< Delete Crew Data - Special Allotment >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Special Allotment>", _
                                GetUserName())
                            '-->
                            info = DB.RunSql("DELETE FROM dbo.tblmpo_allot WHERE PKey = '" & .GetFocusedRowCellValue("PKey") & "'")
                            If info Then
                                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                .DeleteRow(.FocusedRowHandle)
                            End If
                        End If

                    Case EarnView.Name
                        If MsgBox("Are you sure you want to delete Earning -  " & .GetFocusedRowCellDisplayText("FKeyWages") & " ?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + vbYesNo, GetAppName) = MsgBoxResult.Yes Then

                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "Special Allotment", _
                                "Crewing", _
                                "tblmpo_wage", _
                                "PKey IN ('" & .GetFocusedRowCellValue("PKey") & "')", _
                                "<< Delete Crew Data - Special Allotment - Earning >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Special Allotment - Earning>", _
                                GetUserName())
                            '-->
                            info = DB.RunSql("DELETE FROM dbo.tblmpo_wage WHERE PKey = '" & .GetFocusedRowCellValue("PKey") & "'")
                            If info Then
                                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                .DeleteRow(.FocusedRowHandle)
                            End If
                        End If
                    Case DedView.Name
                        If MsgBox("Are you sure you want to delete Deduction -  " & .GetFocusedRowCellDisplayText("FKeyWages") & " ?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + vbYesNo, GetAppName) = MsgBoxResult.Yes Then
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "Special Allotment", _
                                "Crewing", _
                                "tblmpo_wage", _
                                "PKey IN ('" & .GetFocusedRowCellValue("PKey") & "')", _
                                "<< Delete Crew Data - Special Allotment - Deduction >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Special Allotment - Deduction>", _
                                GetUserName())
                            '-->
                            info = DB.RunSql("DELETE FROM dbo.tblmpo_wage WHERE PKey = '" & .GetFocusedRowCellValue("PKey") & "'")
                            If info Then
                                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                .DeleteRow(.FocusedRowHandle)
                            End If
                        End If
                    Case CrewListView.Name
                        If MsgBox("Are you sure you want to delete Crew? [" & .GetFocusedRowCellDisplayText("CrewName") & "] ?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + vbYesNo, GetAppName) = MsgBoxResult.Yes Then
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                "Special Allotment", _
                                "Crewing", _
                                "tblmpo_allot", _
                                "PKey IN ('" & .GetFocusedRowCellValue("PKey") & "')", _
                                "<< Delete Crew Data - Special Allotment - Allottee >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <Special Allotment - Allottee>", _
                                GetUserName())
                            '-->
                            info = DB.RunSql("DELETE FROM dbo.tblmpo_allot WHERE FKeyIDNbr = '" & .GetFocusedRowCellValue("FKeyINbr") & "' AND FKeyMPO ='" & .GetFocusedRowCellValue("MpoID") & "'")
                            If info Then
                                .DeleteRow(.FocusedRowHandle)
                            End If
                        End If
                    Case Else
                        info = False
                End Select

            End With
            If info Then
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName())
                GenerateTableValues()
            Else
                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName())

            End If


        Else

            'Delete Payroll
            If MsgBox("Are you sure you want to delete Payroll " & cboPeriod.Text & " - " & cboRefNum.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + vbYesNo, GetAppName) = MsgBoxResult.Yes Then
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    "Special Allotment", _
                    "Crewing", _
                    "tblmpo", _
                    "PKey IN ('" & cboRefNum.EditValue & "')", _
                    "<< Delete Crew Data - Special Allotment >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <Special Allotment>", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM dbo.tblmpo WHERE PKey = '" & cboRefNum.EditValue & "'")
            End If

            If info Then
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName())
                RefreshData()
            Else
                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Critical, GetAppName())

            End If

        End If


    End Sub

#End Region

#Region "Layout"
    Public Overrides Sub SaveMainContentLayout()
        SaveUserSetting(Me.Name & SplitContainerControl1.Name & "_LAYOUT", SplitContainerControl1.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl2.Name & "_LAYOUT", SplitContainerControl2.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl3.Name & "_LAYOUT", SplitContainerControl3.SplitterPosition.ToString)
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        SplitContainerControl1.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl1.Name & "_LAYOUT", Layout_S1))
        SplitContainerControl2.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl2.Name & "_LAYOUT", Layout_S2))
        SplitContainerControl3.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl3.Name & "_LAYOUT", Layout_S3))
    End Sub

    Public Overrides Sub ResetMainContentLayout()
        SplitContainerControl1.SplitterPosition = Layout_S1
        SplitContainerControl2.SplitterPosition = Layout_S2
        SplitContainerControl3.SplitterPosition = Layout_S3
        SaveMainContentLayout()
    End Sub

#End Region



    'Private Sub CrewListView_RowCountChanged(sender As Object, e As System.EventArgs) Handles CrewListView.RowCountChanged
    '    EdiDeleteAllow(sender)
    'End Sub

    Private Sub EdiDeleteAllow(sender As Object)
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _v.RowCount > 0 Then
            AllowEditing(Name, True)
            AllowDeletion(Name, True)
        Else
            AllowEditing(Name, False)
            AllowDeletion(Name, False)
        End If
        PayrollLock()
    End Sub

    Private Function GetMPOCrewID() As String
        Return IfNull(CrewListView.GetFocusedRowCellValue("MpoID"), "")
    End Function

    Private Sub SetPayCrewListSelection(ID As String)
        Try
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = CrewListView.Columns("PKey")
            RowHandle = CrewListView.LocateByValue(0, Col, ID)
            CrewListView.FocusedRowHandle = RowHandle
        Catch ex As Exception
        End Try
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

                EditSubAllowGrid(EarnView, False)
                EditSubAllowGrid(DedView, False)
                EditSubAllowGrid(AllotView, False, False)

            Else
                txtPayStatus.Text = "Unlocked"
                AllowCalculatePay(Name, True)
                AllowEditing(Name, True)
                AllowSaving(Name, isEditdable)
                AllowDeletion(Name, True)
                txtPayStatus.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                txtPayStatus.Properties.Appearance.ForeColor = System.Drawing.Color.Green


                EditSubAllowGrid(EarnView, isEditdable)
                EditSubAllowGrid(DedView, isEditdable)
                EditSubAllowGrid(AllotView, isEditdable, False)
            End If
        End If
    End Sub


#End Region

    Dim stopnaba As Boolean = False

    Private Sub AllotGrid_Click(sender As Object, e As System.EventArgs) Handles AllotGrid.Click
        stopnaba = True
    End Sub

    Private Sub AllotGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles AllotGrid.MouseMove
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

    Private Sub DedGrid_Click(sender As Object, e As System.EventArgs) Handles DedGrid.Click
        stopnaba = True
    End Sub

    Private Sub DedGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DedGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

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
        AddHandler DedGrid.MouseMove, AddressOf clsgridflout.AddFlyOutEvent
        AddHandler EarnGrid.MouseMove, AddressOf clsgridflout.AddFlyOutEvent
        AddHandler CrewListGrid.MouseMove, AddressOf clsgridflout.AddFlyOutEvent

        AddHandler DedGrid.MouseClick, AddressOf clsgridflout.RemoveFlyOutEvent
        AddHandler EarnGrid.MouseClick, AddressOf clsgridflout.RemoveFlyOutEvent
        AddHandler CrewListGrid.MouseClick, AddressOf clsgridflout.RemoveFlyOutEvent
    End Sub

    Private Sub CrewListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewListView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub CrewListView_ShownEditor(sender As Object, e As System.EventArgs) Handles CrewListView.ShownEditor
        stopnaba = True
    End Sub

    Private Sub EarnView_ShownEditor(sender As Object, e As System.EventArgs) Handles EarnView.ShownEditor
        stopnaba = True
    End Sub

    Private Sub AllotView_ShownEditor(sender As Object, e As System.EventArgs) Handles AllotView.ShownEditor
        stopnaba = True
    End Sub

    Private Sub DedView_ShownEditor(sender As Object, e As System.EventArgs) Handles DedView.ShownEditor
        stopnaba = True
    End Sub

    Private Sub AllotView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles AllotView.ValidateRow
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

            Dim Addr As DevExpress.XtraGrid.Columns.GridColumn = .Columns("Addr")
            If .GetRowCellValue(e.RowHandle, Addr) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Addr) Is Nothing Then
                .SetColumnError(Addr, "Must not be blank.")
                e.Valid = False
            ElseIf .GetRowCellValue(e.RowHandle, "Addr").Equals("") Then
                .SetColumnError(Addr, "Must not be blank.")
                e.Valid = False
            Else
                .SetColumnError(Addr, "")
            End If

            Dim ZipCode As DevExpress.XtraGrid.Columns.GridColumn = .Columns("ZipCode")
            If .GetRowCellValue(e.RowHandle, ZipCode) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, ZipCode) Is Nothing Then
                .SetColumnError(ZipCode, "Must not be blank.")
                e.Valid = False
            ElseIf .GetRowCellValue(e.RowHandle, "ZipCode").Equals("") Then
                .SetColumnError(ZipCode, "Must not be blank.")
                e.Valid = False
            Else
                .SetColumnError(ZipCode, "")
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

    Private Sub AllotView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles AllotView.ValidatingEditor
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            Dim strRequiredField As String = "AllotName;AcctName;AcctNbr;FKeyCurr;FKeyBank;FKeyBranch;Addr;ZipCode"

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
End Class
