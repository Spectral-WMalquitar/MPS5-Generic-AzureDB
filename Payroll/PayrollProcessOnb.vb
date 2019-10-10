Imports System.Windows.Forms
Imports System.Drawing

Public Class PayrollProcessOnb
    ''' <summary>
    ''' Payroll Process Onboard
    ''' </summary>
    ''' <remarks>
    ''' You cannot add a vessel when using Add Crew To Payroll
    ''' </remarks>
    ''' 
#Region "Declarations"
    Dim _SDateFrom As String = ""
    Dim _SDateTo As String = ""
    Dim tblCrewList As DataTable
    Dim tblVsl As DataTable
    Dim BaseEdits As DevExpress.XtraEditors.BaseEdit() = Nothing
    Dim LtblCrewList As List(Of String)
    Dim strRefCurr As String = String.Empty
    Dim tblPay As DataTable
    Dim srcGridControl As DevExpress.XtraGrid.GridControl

    Dim SFKeyPrincipal As String = String.Empty
    Dim SPeriod As Integer = 0
    Dim SRefNo As String = String.Empty

    Dim msgClearSelection As MsgBoxResult
    Dim isBuildData As Boolean = False

    Dim clsAudit As New clsAudit 'neil
    Dim txtrefno As String = ""
   
#End Region

#Region "Initialize"

    Private Sub InitControl()
        ClearControls()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetCalculatePayVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        cboPeriod.Properties.DataSource = GetPayPeriods("MONTH", 36, 3)
        cboPrincipal.Properties.DataSource = LoadPrincipal() 'Load Principal
        tblVsl = LoadVessel()
        Dim AgentFilter As String = IIf(GetUserFilterString(, "PKey", ).Length > 0, " WHERE " & GetUserFilterString(, "PKey", ), "")
        cboAgent.Properties.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.AgentList " & AgentFilter & " ORDER BY Name")
        cboNat.Properties.DataSource = DB.CreateTable("SELECT PKey,Nat AS Name,SortCode FROM dbo.tblAdmCntry ORDER BY Nat")
        repERFKeyCurr.DataSource = DB.CreateTable("SELECT PKey,Name,Symbol FROM dbo.tblAdmCurr ORDER BY Name")
        ExRateGrid.DataSource = InitExRateDT()
        GetPayType = 0

        clsAudit.propSQLConnStr = MPSDB.GetConnectionString

        SetProcessedPayrollListVisibility(Name, True)

    End Sub

    Private _GetPayType As Integer = 0
    Private Property GetPayType() As Integer

        Get
            _GetPayType = rdgPayType.SelectedIndex
            Return _GetPayType
        End Get

        Set(ByVal value As Integer)

            If value = 0 Then 'New
                RequiredControls = {cboPeriod, txtRef, txtDateCreated, cboPrincipal}
                lciNewRefNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciAddRefNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                BaseEdits = {cboPeriod, txtRef, txtDateCreated, cboPrincipal}
                VslView.OptionsBehavior.ReadOnly = False
                txtDateCreated.ReadOnly = False
                cboPrincipal.ReadOnly = False
            ElseIf value = 1 Then 'Add Crew  
                RequiredControls = {cboPeriod, cboRefNum, txtDateCreated, cboPrincipal}
                lciNewRefNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciAddRefNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                BaseEdits = {cboPeriod, cboRefNum, cboPrincipal}
                ExRateView.OptionsBehavior.ReadOnly = True
                txtDateCreated.ReadOnly = True
                cboPrincipal.ReadOnly = True
            End If
            rdgPayType.SelectedIndex = value
            _GetPayType = value
            AddEditListener(LayoutControlGroup7)
            ControlValidations()
        End Set

    End Property

    Private Sub LoadRefNum(MCode As Integer)
        'Dim prinFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal").Length > 0, " AND " & GetUserFilterString(, , "FKeyPrincipal"), "")
        Dim RefFilter As String = IIf(GetUserVslFilterString(, "FKeyVsl").Length > 0, " AND " & GetUserVslFilterString(, "FKeyVsl"), "")
        tblPay = DB.CreateTable("SELECT * FROM dbo.tblPay WHERE MCode = " & MCode & " AND Paytype = 'ONB' " & RefFilter)
        cboRefNum.Properties.DataSource = tblPay
    End Sub

    Private Function LoadPrincipal() As DataTable
        Dim prinFilter As String = IIf(GetUserFilterString(, , "PKey").Length > 0, " WHERE " & GetUserFilterString(, , "PKey"), "")
        Return DB.CreateTable("SELECT * FROM dbo.PrincipalList " & prinFilter & " ORDER BY Name ")
    End Function

    Private Function LoadVessel() As DataTable
        Dim vslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, " WHERE " & GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
        Return DB.CreateTable("SELECT * FROM dbo.VslList " & vslFilter & " ORDER BY Name")
    End Function

    Private Sub ClearControls()
        'ClearFields(LayoutControlGroup7, False)
        BRECORDUPDATEDs = False
        cboPrincipal.EditValue = Nothing
        cboRefNum.EditValue = Nothing
        cboRefNum.Properties.DataSource = Nothing
        txtDateCreated.EditValue = Date.Now
        txtRef.Text = Nothing
        cboPeriod.EditValue = Nothing
        ExRateGrid.DataSource = Nothing
        ClearCrewList()
        BRECORDUPDATEDs = False
    End Sub

    Private Sub ClearCrewList()
        InitializePayCrew()
        CrewListGrid.DataSource = Nothing
        tblCrewList = Nothing
        DELCrewList = Nothing
    End Sub

    Private Function InitExRateDT() As DataTable
        Dim ctable As New DataTable
        ctable.Columns.Add("FKeyCurr", GetType(String))
        ctable.Columns.Add("ExRate", GetType(String))
        Return ctable
    End Function

    Private Sub InitLoadCrewList(DateStart As String, PrinCode As String)
        'tblCrewList = DB.CreateTable("EXEC SP_PAY_ONB_CrewList '" & DateStart & "', '" & DateEnd & "'")
        Dim cTbl As New DataTable
        Dim sqlconn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlconn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlconn
                cmd.CommandText = "SP_PAY_ONB_CrewList"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@DateStart", _SDateFrom)
                    .AddWithValue("@PrinCode", PrinCode)

                End With
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(cTbl)
                End Using

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlconn.State = ConnectionState.Open Then sqlconn.Close()
        End Try

        Dim crewFilter As String = IIf(Trim(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")).Length > 0, "  " & GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt"), "")
        Dim DV As New DataView(cTbl)
        DV.RowFilter = crewFilter
        If DV.Count > 0 Then
            tblCrewList = DV.ToTable
        Else
            tblCrewList = DV.ToTable.Clone
        End If

    End Sub

    Private Sub InitLoadCrewListByVessel(DateStart As String, VslList As DataTable)
        'tblCrewList = DB.CreateTable("EXEC SP_PAY_ONB_CrewList '" & DateStart & "', '" & DateEnd & "'")
        Dim cTbl As New DataTable
        Dim sqlconn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlconn.Open()
            Using cmd As New SqlClient.SqlCommand
                'cmd.Connection = sqlconn
                'cmd.CommandText = "SP_PAY_ONB_CrewList"
                'cmd.CommandType = CommandType.StoredProcedure
                'With cmd.Parameters
                '    .AddWithValue("@DateStart", _SDateFrom)
                '    .AddWithValue("@PrinCode", PrinCode)

                'End With
                'Using adp As New SqlClient.SqlDataAdapter(cmd)
                '    adp.Fill(cTbl)
                'End Using

                cmd.Connection = sqlconn
                cmd.CommandText = "SP_PAY_ONB_CrewList_ByVessel"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@DateStart", _SDateFrom)
                    .AddWithValue("@VslList", VslList)

                End With
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(cTbl)
                End Using

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlconn.State = ConnectionState.Open Then sqlconn.Close()
        End Try

        Dim crewFilter As String = IIf(Trim(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")).Length > 0, "  " & GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt"), "")
        Dim DV As New DataView(cTbl)
        DV.RowFilter = crewFilter
        If DV.Count > 0 Then
            tblCrewList = DV.ToTable
        Else
            tblCrewList = DV.ToTable.Clone
        End If

    End Sub

    Private Sub InitializePayCrew()

        Dim PayCrewtbl As New DataTable
        'PayCrewtbl = TryCast(CrewListGrid.DataSource, DataTable).Clone
        For Each dc As DevExpress.XtraGrid.Columns.GridColumn In CrewListView.Columns
            PayCrewtbl.Columns.Add(dc.FieldName)
        Next

        Dim strCrewFilter As String = getSelectedVesel(VslView)
        Dim withPayCrewFilter As String = ""
        Dim strFilter As String = ""

        If strCrewFilter.Equals("") Then
            PayCrewGrid.DataSource = PayCrewtbl
        Else

            If PayCrewView.RowCount > 0 Then
                withPayCrewFilter = " AND " & FilterPayList()
            Else
                withPayCrewFilter = ""
            End If
            strFilter = strCrewFilter & withPayCrewFilter

            'If tblCrewList.Rows.Count > 0 Then
            If IsNothing(PayCrewGrid.DataSource) Then
                PayCrewGrid.DataSource = PayCrewtbl
            End If
            If PayCrewGrid.DataSource.Select(strFilter).Length > 0 Then

                PayCrewGrid.DataSource = CType(PayCrewGrid.DataSource, DataTable).Select(strFilter).CopyToDataTable
                Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = CrewListGrid.DefaultView
                SortCrewList(_v)
            Else
                PayCrewGrid.DataSource = PayCrewtbl
            End If
            'Else
            '    PayCrewGrid.DataSource = PayCrewtbl
            'End If

            'PayCrewGrid.DataSource = PayCrewtbl
        End If

        ExRateGrid.DataSource = InitExRateDT() 'Clear Data Source
    End Sub

    Private Sub SetRefCurrency()
        Dim refCurr As String = String.Empty
        refCurr = DB.DLookUp("Symbol", "tbladmCurr", String.Empty, "Ref<>0")
        strRefCurr = DB.DLookUp("PKey", "tbladmCurr", String.Empty, "Ref<>0")
        lcgExRate.Text = "5. Exchange Rate: per 1 " & refCurr
    End Sub

#End Region

#Region "MainFunction"

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        lciApplyFilter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        SetPayrollListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetCalculatePayCaption(Name, "Calculate Pay")
        If Not bLoaded Then
            'txtDateCreated.Text = Date.Now.ToString("dd-MMM-yyyy")
            'GetPayType = 0
            bLoaded = True
        End If
        InitControl()
        'tony20180907 VslGrid.Enabled = False
        SetSelectionMode(SelectionMode.Vessel)  'added by tony20180907
        SetRefCurrency()
        BRECORDUPDATEDs = False
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0)
            Case "RunPayroll"
                RunPayroll()
            Case "CLEARFILTER"
                ClearFilter()
        End Select
    End Sub

#Region "Run Payroll"

    Private Sub RunPayroll()
        Me.GroupControl1.Focus()
        If MsgBox("Do you want to continue to calculate payroll?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MessageBoxIcon.Question, GetAppName) = MsgBoxResult.Yes Then
            Dim info As Boolean = False
            If ValidatePayOnb() Then
                info = ProcessONBPayroll()
                If info Then

                    Dim auditlogid As Long
                    clsAudit.saveAuditLog("Process Onboard Payroll", USER_NAME, auditlogid, System.Environment.MachineName, 0,
                                   , , , , "Period : " & NumCodeToDate(cboPeriod.EditValue, 1).ToString("yyyy-MM-dd") & " \ Ref No. : " & Me.txtRef.Text, "MPS Crewing", Date.Now) 'neil

                    BRECORDUPDATEDs = False
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                    RefreshData()
                Else
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Critical, GetAppName)
                    BRECORDUPDATEDs = True
                End If
            End If
        End If
    End Sub

    Private Function ProcessONBPayroll() As Boolean
        ShowCustomLoadScreen(GetType(PayrollWaitForm))
        Dim toBeInserted As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction

            'Pay Crews
            Dim tblPayCrew As New DataTable
            If PayCrewView.DataRowCount > 0 Then
                tblPayCrew = TryCast(PayCrewView.DataSource, DataView).ToTable(True, New String() {"ActID", "IDNbr", "FKeyVslCode", "FkeyWScaleCode", "FKeyWScaleRankCode"})
            Else
                tblPayCrew = TryCast(PayCrewView.DataSource, DataView).ToTable.Clone
            End If

            'ExRate
            Dim tblPayExRates As New DataTable
            If ExRateView.DataRowCount > 0 Then
                tblPayExRates = TryCast(ExRateView.DataSource, DataView).ToTable(True, New String() {"FKeyCurr", "ExRate"})
            Else
                tblPayExRates = TryCast(ExRateView.DataSource, DataView).ToTable.Clone
            End If

            'RefNum
            Dim txtRefNum As String = ""
            If GetPayType = 0 Then
                PayType = 0
                txtRefNum = txtRef.Text
            ElseIf GetPayType = 1 Then
                PayType = 1
                'tonytest txtRefNum = cboRefNum.EditValue
                Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(cboRefNum, DevExpress.XtraEditors.LookUpEdit)
                txtRefNum = editor.GetColumnValue("RefNo")
            End If

            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandText = "SP_ProcessPayONB"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@ProcessType", IIf(GetPayType = 0, False, True))
                    .AddWithValue("@PeriodDateStart", NumCodeToDate(cboPeriod.EditValue, 1).ToString("yyyy-MM-dd"))
                    .AddWithValue("@DateCreated", txtDateCreated.Text)
                    .AddWithValue("@RefNo", IIf(GetPayType = 0, txtRef.EditValue, txtRefNum))
                    .AddWithValue("@FKeyPrincipal", cboPrincipal.EditValue)
                    .AddWithValue("@tblPayCrew", tblPayCrew)
                    .AddWithValue("@tblExRate", tblPayExRates)
                    'neil .AddWithValue("@LastUpdatedBy",  "LastUpdatedBY")
                    .AddWithValue("@LastUpdatedBy", "")
                End With
                toBeInserted = (cmd.ExecuteNonQuery > 0)
            End Using

            If toBeInserted Then
                sqlTran.Commit()
            End If
        Catch ex As Exception
            toBeInserted = False
            sqlTran.Rollback()
            MsgBox(ex.Message)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        CloseCustomLoadScreen()
        Return toBeInserted
    End Function

    'Add Crew to Existing Payroll
    Private Function ProcessAddCrewPayONB() As Boolean
        Dim RetVal As Boolean = False
        Dim toBeInserted As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Try

            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandText = ""
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters

                End With
                toBeInserted = (cmd.ExecuteNonQuery > 0)
            End Using
            If toBeInserted Then
                RetVal = True
                sqlTran.Commit()
            End If
        Catch ex As Exception
            RetVal = False
            sqlTran.Rollback()
            MsgBox(ex.Message, vbCritical, GetAppName)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try


        Return RetVal
    End Function

    Private Function ValidatePayOnb() As Boolean
        Dim retval As Boolean = False
        If ValidateFields(RequiredControls) And ValidateExRate() And PayCrewView.DataRowCount > 0 And ValidatePayCrewVesselReferenceNumber() Then
            retval = True
        End If


        Return retval
    End Function

    Private Function ValidatePayCrewVesselReferenceNumber() As Boolean
        Dim retVal As Boolean = True

        Dim dv As New DataView
        Dim dt As New DataTable
        Dim strVslList As String = String.Empty
        Dim vslCode As String = ""

        dv = PayCrewView.DataSource
        If dv.Count > 0 Then
            dt = dv.ToTable(True, New String() {"FKeyVslCode", "Vessel"})
            For index = 0 To dt.Rows.Count - 1
                vslCode = dt.Rows(index)("FKeyVslCode")
                Dim PayID As String = ""
                PayID = DB.DLookUp("PKey", "tblPay", "", "FKeyVsl='" & vslCode & "' AND RefNo ='" & txtRef.Text & "' AND MCode='" & cboPeriod.EditValue & "' AND PayType='ONB'")

                If PayID.Trim.Length > 0 Then
                    'retVal = False
                    strVslList = dt.Rows(index)("Vessel").ToString & vbCrLf & strVslList
                End If
            Next
            If strVslList.Trim.Length > 0 Then
                retVal = False
                MsgBox("Unable to process Payroll. The payroll details of the following vessel(s) exist : " & vbCrLf & strVslList & vbCrLf & _
                       "Please use [Add Payroll].", MsgBoxStyle.Exclamation, GetAppName)
            End If
        Else
            dt = Nothing
        End If
        Return retVal
    End Function


    Private Function ValidateExRate() As Boolean
        Dim retVal As Boolean = False
        With ExRateView
            If .DataRowCount > 0 Then
                For index = 0 To .DataRowCount - 1
                    If IsNothing(.GetRowCellValue(index, "FKeyCurr")) Then
                        retVal = False
                    ElseIf IfNull(.GetRowCellValue(index, "FKeyCurr"), "").Equals("") Then
                        retVal = False
                    Else
                        retVal = True
                    End If
                    If IsNothing(.GetRowCellValue(index, "ExRate")) Then
                        retVal = False
                    ElseIf IfNull(.GetRowCellValue(index, "ExRate"), CDbl(0)) <= 0.0 Then
                        retVal = False
                    Else
                        retVal = True
                    End If

                    If Not retVal Then
                        Exit For
                    End If
                Next

                If Not retVal Then
                    MsgBox("Invalid Exchange Rate", MsgBoxStyle.Critical, GetAppName)
                End If
            Else
                retVal = False
                MsgBox("Exchange Rate is not populated", MsgBoxStyle.Critical, GetAppName)
            End If
        End With
        Return retVal
    End Function
#End Region


#End Region

#Region "Filter"

    Private Sub FilterVessel(PrinCode As String)
        VslView.ActiveFilterString = String.Empty
        Dim dv As New DataView(tblVsl)
        dv.RowFilter = "FKeyPrincipal='" & PrinCode & "'"
        VslGrid.DataSource = dv
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        SPeriod = Nothing
        SFKeyPrincipal = Nothing
        If Not IsNothing(LookUpEd.EditValue) Then
            cboPrincipal.EditValue = Nothing
            EnableDisableVslView()
            'tonytest
            ''If GetPayType = 1 Then 'load only when Add payroll Type
            ''    LoadRefNum(LookUpEd.EditValue)
            ''End If

            If GetPayType = 0 Then
                ClearCrewList()
            ElseIf GetPayType = 1 Then
                'tonytest cboRefNum.Properties.DataSource = InitRefNo(LookUpEd.EditValue)
                'tonytest CheckVessel(LookUpEd.EditValue)
                LoadRefNum_AddCrewToPayroll(LookUpEd.EditValue)
                cboRefNum.Properties.DataSource = InitRefNo_AddCrewToPayroll(LookUpEd.EditValue)
            End If
        End If


        InitSelectionMode()

    End Sub

    Private Sub cboPrincipal_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPrincipal.EditValueChanged
        Dim _l As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If Not IsNothing(_l.EditValue) Or Not Trim(_l.EditValue).Equals("") Then
            'ClearSelectionVslView()
            EnableDisableVslView()
            FilterVessel(_l.EditValue)
        Else
            VslGrid.DataSource = Nothing
            CrewListGrid.DataSource = Nothing
            'InitializePayCrew()
        End If


        InitSelectionMode()
    End Sub

    Private Sub EnableDisableVslView()
        '[tony20180907]: removed enabling/disabling of vessel view as the vessel selection is now by default. and build data is done after the selection of vessel which will then after disables the vessel grid
        Exit Sub
        PayCrewGrid.DataSource = Nothing
        InitializePayCrew()
        'ClearCrewList()
        VslView.ClearSelection()
        If Not IsNothing(cboPeriod.EditValue) And Not IsNothing(cboPrincipal.EditValue) Then
            If cboPrincipal.EditValue.Equals(SFKeyPrincipal) And cboPeriod.EditValue.Equals(SPeriod) Then
                If GetPayType.Equals(1) Then
                    If Not IsNothing(cboRefNum.EditValue) Then
                        If cboRefNum.EditValue.Equals(SRefNo) Then
                            VslGrid.Enabled = True
                            ExRateGrid.Enabled = True
                            isBuildData = True
                        Else
                            VslGrid.Enabled = False
                            ExRateGrid.Enabled = False
                            isBuildData = False
                        End If
                    Else
                        isBuildData = False
                        VslGrid.Enabled = False
                        ExRateGrid.Enabled = True
                    End If
                Else
                    If IsNothing(SRefNo) Then
                        'isBuildData = True
                        'VslGrid.Enabled = True
                        isBuildData = False
                        VslGrid.Enabled = False
                    Else
                        If txtRef.Text.Equals(SRefNo) Then
                            isBuildData = True
                            VslGrid.Enabled = True
                        Else
                            isBuildData = False
                            VslGrid.Enabled = False
                        End If
                    End If
                End If
            Else
                isBuildData = False
                VslGrid.Enabled = False
            End If
        Else
            isBuildData = False
            VslGrid.Enabled = False
            ExRateGrid.Enabled = True
        End If

    End Sub

    Private Sub ClearSelectionVslView()
        'For index = 0 To VslView.RowCount - 1
        '    If VslView.IsRowSelected(index) Then
        '        VslView.UnselectRow(index)
        '    End If
        'Next
        VslView.ClearSelection()

    End Sub

    Private Function getSelectedVesel(_View As DevExpress.XtraGrid.Views.Grid.GridView) As String
        Dim retval As String = "", PKey As String = ""
        If rdgPayType.SelectedIndex = 0 Then
            With _View
                If .SelectedRowsCount() > 0 Then
                    For index As Integer = 0 To .SelectedRowsCount() - 1
                        PKey = PKey & "'" & .GetRowCellValue(.GetSelectedRows(index), "PKey") & "'" & ","
                    Next
                    PKey = PKey.Substring(0, Len(PKey) - 1)
                    retval = "FKeyVslCode IN(" & PKey & ")"
                Else
                    retval = ""
                End If
            End With

        ElseIf rdgPayType.SelectedIndex = 1 Then
            Try
                Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(cboRefNum, DevExpress.XtraEditors.LookUpEdit)
                Dim value As Object = editor.GetColumnValue("FKeyVsl")

                If IfNull(value, "").Length > 0 Then
                    retval = "FKeyVslCode IN('" & value & "')"
                End If

            Catch ex As Exception
                'do nothing

            End Try
        End If

        Return retval
    End Function

#End Region

#Region "LoadSub"

    Private Sub LoadCrewList()
        Dim strCrewFilter As String = getSelectedVesel(VslView)
        Dim withPayCrewFilter As String = ""
        Dim strFilter As String = ""
        If strCrewFilter.Equals("") Then
            CrewListGrid.DataSource = tblCrewList.Clone
        Else
            If PayCrewView.RowCount > 0 Then
                withPayCrewFilter = " AND " & FilterCrewList()
            Else
                withPayCrewFilter = ""
            End If
            strFilter = strCrewFilter & withPayCrewFilter

            Dim dv As New DataView(tblCrewList)
            dv.RowFilter = strFilter
            CrewListGrid.DataSource = dv.ToTable
            Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = CrewListGrid.DefaultView
            SortCrewList(_v)
            'If tblCrewList.Rows.Count > 0 Then
            '    If tblCrewList.Select(strFilter).Length > 0 Then
            '        CrewListGrid.DataSource = tblCrewList.Select(strFilter).CopyToDataTable
            '        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = CrewListGrid.DefaultView
            '        SortCrewList(_v)
            '    Else
            '        CrewListGrid.DataSource = tblCrewList.Clone
            '    End If
            'Else
            '    CrewListGrid.DataSource = tblCrewList.Clone
            'End If

        End If
    End Sub

    Private Sub SortCrewList(_view As DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            'Sorting
            .BeginSort()
            Try
                .ClearSorting()
                .Columns("Vessel").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                .Columns("Crew").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                .Columns("RankName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Finally
                .EndSort()
            End Try
        End With
    End Sub

#End Region

#Region "CrewList"
    Private downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo

    Private Sub CrewListView_DoubleClick(sender As Object, e As System.EventArgs) Handles CrewListView.DoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            Dim dt As DataTable = TryCast(view.GridControl.DataSource, DataTable).Clone
            Dim row As DataRow = dt.NewRow
            row.ItemArray = view.GetDataRow(info.RowHandle).ItemArray
            dt.Rows.Add(row)

            PayrollFunctions.TransferAll(srcGridControl, _
                             PayCrewGrid, _
                             dt, _
                             tblCrewList, True, , PayrollFunctions.PayProcessCrewTransferMethod.DoubleClick)

        End If
    End Sub

    Private Sub CrewListView_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListView.MouseDown
        srcGridControl = CrewListGrid
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

    Private Sub CrewListView_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListView.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)
            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
                view.GridControl.DoDragDrop(view.Name, DragDropEffects.All)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub CrewListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewListView.RowCellStyle
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            ValidateRows("ToolTip", _view, e)
        End With
    End Sub

    Private Sub ValidateRows(ColumnName As String, _view As DevExpress.XtraGrid.Views.Grid.GridView, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        With _view
            If .GetRowCellValue(e.RowHandle, ColumnName).Equals(System.DBNull.Value) Then
                e.Appearance.BackColor = Color.LightPink
            ElseIf Not IfNull(.GetRowCellValue(e.RowHandle, ColumnName).ToString().Trim(), "").Equals("") Then
                e.Appearance.BackColor = Color.LightPink
            End If
        End With
    End Sub

    Private Function GetDragData(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView) As DataTable
        Dim result As New DataTable

        For Each dc As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
            result.Columns.Add(dc.FieldName)
        Next

        Dim selection() As Integer = view.GetSelectedRows()
        If selection Is Nothing Then
            Return Nothing
        End If

        Dim count As Integer = selection.Length - 1
        For index = 0 To count
            If Not view.IsGroupRow(selection(index)) Then
                Dim nRow As DataRow
                nRow = result.NewRow
                For Each dc As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
                    nRow(dc.FieldName) = view.GetRowCellValue(selection(index), dc.FieldName)
                Next
                result.Rows.Add(nRow)
            End If
        Next

        Return result
    End Function

    Private Sub CrewListGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles CrewListGrid.DragDrop
        PayrollFunctions.TransferAll(srcGridControl, _
                                     CrewListGrid, _
                                     TryCast(e.Data.GetData(GetType(DataTable)), DataTable), _
                                     tblCrewList, False)
    End Sub

    Private Sub CrewListGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles CrewListGrid.DragOver
        Dim control As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(control.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

        'Not view.IsGroupRow(downHitInfo.RowHandle) : Disables the Drag and drop to Group Row
        If e.Data.GetDataPresent(GetType(DataTable)) AndAlso Not view.IsGroupRow(downHitInfo.RowHandle) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub cmdSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdSelectAll.Click
        CrewListView.SelectAll()
        PayrollFunctions.TransferAll(CrewListGrid, _
                                     PayCrewGrid, _
                                     CrewListGrid.DataSource, _
                                     tblCrewList, True, False)
    End Sub

#End Region

#Region "Pay Crew List"

    Private Function FilterPayList() As String
        Dim retVal As String = ""
        Dim str As String = ""
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = PayCrewView

        For index = 0 To (_view.DataRowCount - 1)
            str = "'" & _view.GetRowCellValue(index, "ActID") & "'," & str
        Next

        str = str.Substring(0, Len(str) - 1)

        retVal = "ActID IN(" & str & ")"

        Return retVal
    End Function

    Private Function FilterCrewList() As String
        Dim retVal As String = ""
        Dim str As String = ""
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = PayCrewView

        For index = 0 To (_view.DataRowCount - 1)
            str = "'" & _view.GetRowCellValue(index, "ActID") & "'," & str
        Next

        str = str.Substring(0, Len(str) - 1)

        retVal = "ActID NOT IN(" & str & ")"

        Return retVal
    End Function

    Private Sub PayCrewGrid_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles PayCrewGrid.DragDrop
        PayrollFunctions.TransferAll(srcGridControl, _
                             PayCrewGrid, _
                             TryCast(e.Data.GetData(GetType(DataTable)), DataTable), _
                             tblCrewList, True)

        'Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        'Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grid.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim table As DataTable = CType(grid.DataSource, DataTable)
        'Dim dT As DataTable = TryCast(e.Data.GetData(GetType(DataTable)), DataTable)
        'Dim DTCrewWithError As DataTable = dT.Clone

        'If Not _view.Name.Equals(downHitInfo.View.Name) Then
        '    'For Each dr As DataRow In dT.Rows
        '    '    Dim nRow As DataRow
        '    '    nRow = table.NewRow()

        '    '    For Each dc As DevExpress.XtraGrid.Columns.GridColumn In PayCrewView.Columns
        '    '        nRow(dc.FieldName) = dr(dc.FieldName)
        '    '    Next

        '    '    table.Rows.Add(nRow)
        '    '    For Each dRow As DataRow In tblCrewList.Rows
        '    '        If dRow.Equals(dr) Then
        '    '            dRow.Delete()
        '    '        End If
        '    '    Next
        '    'Next
        '    ''DeleteSelectCrewInTblCrewList() 'Delete in the DataTable = tblCrewList
        '    'CrewListView.DeleteSelectedRows()

        '    For Each dr As DataRow In dT.Rows
        '        If Trim(IfNull(dr("ToolTip"), "")).Equals("") Then
        '            Dim nRow As DataRow
        '            nRow = table.NewRow()

        '            For Each dc As DevExpress.XtraGrid.Columns.GridColumn In PayCrewView.Columns
        '                nRow(dc.FieldName) = dr(dc.FieldName)
        '            Next
        '            table.Rows.Add(nRow)
        '            For Each dRow As DataRow In tblCrewList.Rows
        '                If dRow.Equals(dr) Then
        '                    dRow.Delete()
        '                End If
        '            Next
        '            CrewListView.DeleteRow(CrewListView.LocateByValue("ActID", dr("ActID")))

        '        Else
        '            Dim nRowWithError As DataRow
        '            nRowWithError = DTCrewWithError.NewRow
        '            nRowWithError.ItemArray = TryCast(dr.ItemArray.Clone, Object())
        '            DTCrewWithError.Rows.Add(nRowWithError)
        '        End If
        '    Next

        '    'Sort Grid
        '    _view.SortInfo.ClearAndAddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() { _
        '       New DevExpress.XtraGrid.Columns.GridColumnSortInfo(_view.Columns("Vessel"), DevExpress.Data.ColumnSortOrder.Ascending), _
        '       New DevExpress.XtraGrid.Columns.GridColumnSortInfo(_view.Columns("Crew"), DevExpress.Data.ColumnSortOrder.Ascending), _
        '       New DevExpress.XtraGrid.Columns.GridColumnSortInfo(_view.Columns("RankName"), DevExpress.Data.ColumnSortOrder.Ascending) _
        '    }, 1)
        '    With _view
        '        .BeginSort()
        '        Try
        '            .ClearSorting()
        '            .Columns("Crew").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        '            .Columns("Vessel").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        '            .Columns("RankName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        '        Finally
        '            .EndSort()
        '        End Try
        '    End With

        'End If
        'If DTCrewWithError.Rows.Count > 0 Then
        '    If MsgBox("Some of the dragged crew(s) contained error(s) and cannot be added to the Payroll list." & vbCrLf & _
        '              "Would you like to view the error details?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, GetAppName) = MsgBoxResult.Yes Then
        '        Dim frmError As New frmPayCrewError(DTCrewWithError)
        '        frmError.ShowDialog()
        '    End If
        'End If

    End Sub

    Private Sub PayCrewGrid_DragOver(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles PayCrewGrid.DragOver
        Dim control As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(control.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.Data.GetDataPresent(GetType(DataTable)) AndAlso Not view.IsGroupRow(downHitInfo.RowHandle) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub cmdPaySelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdPaySelectAll.Click
        PayCrewView.SelectAll()
        PayrollFunctions.TransferAll(PayCrewGrid, _
                                     CrewListGrid, _
                                     PayCrewGrid.DataSource, _
                                     tblCrewList, False, False)
    End Sub

    Private Sub PayCrewView_DoubleClick(sender As Object, e As System.EventArgs) Handles PayCrewView.DoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            Dim dt As DataTable = TryCast(view.GridControl.DataSource, DataTable).Clone
            Dim row As DataRow = dt.NewRow
            row.ItemArray = view.GetDataRow(info.RowHandle).ItemArray
            dt.Rows.Add(row)

            PayrollFunctions.TransferAll(srcGridControl, _
                     CrewListGrid, _
                     dt, _
                     tblCrewList, False, , PayrollFunctions.PayProcessCrewTransferMethod.DoubleClick)

        End If
    End Sub

    Private Sub PayCrewView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PayCrewView.MouseDown
        srcGridControl = PayCrewGrid
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

    Private Sub PayCrewView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PayCrewView.MouseMove
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

#Region "VslList"

    'Dim SelectedVsls() As Integer
    Dim SelectedVsls As New List(Of Integer)
    Dim tsetSVsl As New List(Of Integer)

    Private Function BuildIndex(table As DataTable, keyColumnFieldName As String) As List(Of String)
        Dim index As New List(Of String)(table.Rows.Count)
        For Each row As DataRow In table.Rows
            index.Add(IfNull(row(keyColumnFieldName), ""))
        Next
        index.Sort()
        Return index
    End Function

    Private Function ItemExists(Lindex As List(Of String), key As String) As Boolean
        Dim index As Integer = Lindex.BinarySearch(key)
        If index >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub VslView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles VslView.SelectionChanged
        'commented out by tony201809077 : Crew List selection are now done after vessels are selected and not during the vessel selection
        'tony20180907 LoadSelection(sender, e)
    End Sub

    Private Function ValidateVslRefNo(vslViewRowHandle As Integer, _VslView As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim retval As Boolean = False
        Dim refNum As String = "", vslCode As String = ""
        Dim PayID As String = ""
        vslCode = IfNull(_VslView.GetRowCellValue(vslViewRowHandle, "PKey"), "")
        refNum = IfNull(txtRef.Text, "")

        PayID = DB.DLookUp("PKey", "tblPay", "", "FKeyVsl='" & vslCode & "' AND RefNo ='" & refNum & "' AND MCode='" & cboPeriod.EditValue & "' AND PayType= 'ONB'")
        If PayID.Trim.Length > 0 Then
            retval = False
            MsgBox("Unable to select the Vessel. Payroll with the same details already exist.", MsgBoxStyle.Exclamation, GetAppName)
        Else
            retval = True
        End If
        Return retval
    End Function

    Private Function ValidatePayrollDetails() As Boolean
        Dim retVal As Boolean = True
        For Each ctr As DevExpress.XtraEditors.BaseEdit In RequiredControls
            If IsNothing(ctr.EditValue) Then
                retVal = False
                Exit For
            Else
                If ctr.EditValue.ToString.Trim.Equals("") Or Not (ctr.EditValue.ToString.Trim.Length > 0) Then
                    retVal = False
                    Exit For
                End If
            End If
        Next
        Return retVal
    End Function


#End Region

    Private Sub rdgPayType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rdgPayType.SelectedIndexChanged
        SFKeyPrincipal = ""
        GetPayType = rdgPayType.EditValue
        VslGrid.Enabled = False
        ClearControls()
        PayCrewGrid.DataSource = Nothing
        ClearEverything()
        InitSelectionMode()
    End Sub

    Private Sub cboRefNum_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboRefNum.EditValueChanged
        'Dim dt As DataTable = TryCast(cboRefNum.Properties.DataSource, DataView).ToTable
        Dim _l As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        EnableDisableVslView()
        If Not IsNothing(_l.EditValue) Then
            'txtDateCreated.Text = tblPay.Select("PKey = '" & _l.EditValue & "'").First().Item("DateCreated").ToString()
            'cboPrincipal.EditValue = tblPay.Select("PKey = '" & _l.EditValue & "'").First().Item("FKeyPrincipal").ToString()
            'CheckVessel(cboPeriod.EditValue, cboRefNum.EditValue)
            ''CheckVessel()
            ''LoadPayExRate(_l.EditValue)

            ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Building Data")
            ClearSelection()

            RefnoSelected(_l.EditValue)
            CloseCustomLoadScreen()
        Else
            _l.Properties.DataSource = Nothing
        End If
        SetSelectionMode(SelectionMode.AddCrewToPayroll)
    End Sub

    Private Sub LoadPayExRate(FKeyPayID As String)
        ExRateGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.tblPayExRate WHERE FKeyPay='" & FKeyPayID & "'")
    End Sub

    Private Sub CheckVessel()
        VslView.ClearSelection()
        Dim strFilter As String = ""
        If tblPay.Rows.Count > 0 Then
            Dim dv As New DataView(tblPay)
            dv.RowFilter = "RefNo='" & cboRefNum.Text & "'"
            For Each dr As DataRowView In dv
                strFilter = "'" & dr("FKeyVsl").ToString() & "'," & strFilter
            Next
            strFilter = strFilter.Substring(0, Len(strFilter) - 1)
            strFilter = "PKey IN(" & strFilter & ")"
        End If
        VslView.ActiveFilter.NonColumnFilter = strFilter
    End Sub

    Private Sub ExRateView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ExRateView.InitNewRow
        BRECORDUPDATEDs = True
    End Sub

    Private Sub PayCrewView_RowCountChanged(sender As Object, e As System.EventArgs) Handles PayCrewView.RowCountChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.DataRowCount > 0 Then
            BRECORDUPDATEDs = True
            AllowCalculatePay(Name, True)
        Else
            BRECORDUPDATEDs = False
            AllowCalculatePay(Name, False)
        End If
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidatePayOnb() Then
                flag = True
                ALLOWNEXTS = flag
                RunPayroll()
            Else
                flag = False
                ALLOWNEXTS = flag
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

#Region "ExRate"

    Private Function GetPayExRate() As DataTable
        Dim ctbl As New DataTable, ctblOut As New DataTable

        Dim tblPayCrew As DataTable '= TryCast(PayCrewView.DataSource, DataView).ToTable
        If PayCrewView.DataRowCount > 0 Then
            tblPayCrew = TryCast(PayCrewView.DataSource, DataView).ToTable(True, New String() {"ActID", "IDNbr", "FKeyVslCode", "FkeyWScaleCode", "FKeyWScaleRankCode"})
        Else
            tblPayCrew = TryCast(PayCrewView.DataSource, DataView).ToTable.Clone
        End If
        Dim sqlcon As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlcon.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlcon
                cmd.CommandText = "SELECT * FROM dbo.FN_GetONB_ExRate(@DateStart,@tblPayCrew)"
                With cmd.Parameters
                    .AddWithValue("@DateStart", NumCodeToDate(cboPeriod.EditValue, 1).ToString("yyyy-MM-dd"))
                End With
                Dim sqlParam As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@tblPayCrew", tblPayCrew)
                With sqlParam
                    .SqlDbType = SqlDbType.Structured
                    .TypeName = "Type_tblPayCrew_ONB"
                End With
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(ctbl)
                End Using

                Dim ExRateDV As DataView = ExRateView.DataSource
                If Not IsNothing(ExRateDV) Then
                    If ExRateDV.Count > 0 Then
                        ExRateDV.Sort = "FKeyCurr"
                        Dim strExRateFilter As String = String.Empty
                        For Each drv In ExRateDV
                            strExRateFilter = "'" & drv("FKeyCurr") & "'," & strExRateFilter
                        Next
                        If Len(Trim(strExRateFilter)) > 0 Then
                            strExRateFilter = strExRateFilter.Substring(0, Len(strExRateFilter) - 1)
                            strExRateFilter = " FKeyCurr IN(" & strExRateFilter & ")"
                            If ctbl.Select(strExRateFilter).Length > 0 Then
                                For Each drv_ As DataRow In ctbl.Select(strExRateFilter)
                                    ExRateDV.Find(drv_("FKeyCurr"))
                                    Dim xRow As DataRowView() = ExRateDV.FindRows(drv_("FKeyCurr"))
                                    drv_("ExRate") = IfNull(xRow(0)("ExRate"), CDbl(0.0))
                                Next
                            End If
                            ctblOut = ctbl
                        End If
                    End If
                Else
                    ctblOut = ctbl
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
        End Try
        Return ctbl
    End Function

    Private Sub cmdExRate_Click(sender As System.Object, e As System.EventArgs) Handles cmdExRate.Click
        If PayCrewView.DataRowCount > 0 Then
            If ExRateView.DataRowCount > 0 Then
                'If MsgBox("Do you want to overwrite the existing Exchange Rates?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Yes Then
                ExRateGrid.DataSource = GetPayExRate()
                'End If
            Else
                ExRateGrid.DataSource = GetPayExRate()
            End If
        Else
            ExRateGrid.DataSource = Nothing
        End If
    End Sub

    Private Function IsRefCurr(view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal row As Integer) As Boolean
        Try
            Dim val As String = view.GetRowCellValue(row, "FKeyCurr")
            Return (val = strRefCurr)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ExRateView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ExRateView.RowCellStyle
        Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ViewRowCellStyle(sender, e)
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

    Private Sub ClearFilter()
        'Throw New NotImplementedException
        ClearControls()
    End Sub

    Private Sub ControlValidations() Handles cboPeriod.EditValueChanged, cboPrincipal.EditValueChanged
        If IsNothing(cboPeriod.EditValue) Then
            cboPrincipal.Enabled = False
        Else
            If Len(cboPeriod.EditValue) <= 0 Then
                cboPrincipal.Enabled = False
            Else
                cboPrincipal.Enabled = True
            End If
        End If

    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As System.Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        Dim grd As DevExpress.XtraGrid.GridControl = TryCast(e.SelectedControl, DevExpress.XtraGrid.GridControl)
        If Not IsNothing(grd) Then
            Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = grd.GetViewAt(e.ControlMousePosition)
            If Not IsNothing(_view) Then
                Dim gridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = _view.CalcHitInfo(e.ControlMousePosition)
                Dim rowIndex As Integer = gridHitInfo.RowHandle
                Dim strToolTip = ""
                If rowIndex >= 0 Then
                    strToolTip = _view.GetRowCellValue(rowIndex, "ToolTip").ToString.Trim()
                    Dim toolTipArg As SuperToolTipSetupArgs = New SuperToolTipSetupArgs
                    toolTipArg.Contents.Text = strToolTip
                    e.Info = New ToolTipControlInfo()
                    e.Info.SuperTip = New SuperToolTip()
                    e.Info.Object = strToolTip
                    e.Info.ToolTipType = ToolTipType.SuperTip
                    e.Info.SuperTip.Setup(toolTipArg)
                End If

            End If

        End If
    End Sub

    Private Sub cboPrincipal_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboPrincipal.EditValueChanging
        If BRECORDUPDATEDs Then
            If Not IsNothing(PayCrewView.DataSource) Then
                If TryCast(PayCrewView.DataSource, DataView).Count > 0 Then
                    ClearSelectionVslView()
                    If msgClearSelection.Equals(MsgBoxResult.Yes) Then
                        InitializePayCrew()
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboAgent_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboAgent.ButtonPressed
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboAgent_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboAgent.EditValueChanged
        FilterCrewlistAgentNat()
    End Sub

    Private Sub cboNat_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboNat.ButtonPressed
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboNat_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboNat.EditValueChanged
        FilterCrewlistAgentNat()
    End Sub

    Private Sub FilterCrewlistAgentNat()
        Dim agentftr As String = String.Empty, natFtr As String = String.Empty, strFinalFilter As String = String.Empty
        If cboAgent.EditValue = Nothing Then
            agentftr = ""
        Else
            agentftr = " FKeyAgentCode = '" & cboAgent.EditValue & "' "
        End If

        If cboNat.EditValue = Nothing Then
            natFtr = ""
        Else
            natFtr = " NatCode = '" & cboNat.EditValue & "' "
        End If

        If agentftr.Trim.Length > 0 Then
            If natFtr.Trim.Length > 0 Then
                strFinalFilter = agentftr & " AND " & natFtr
            Else
                strFinalFilter = agentftr
            End If
        Else
            If natFtr.Trim.Length > 0 Then
                strFinalFilter = natFtr
            Else
                strFinalFilter = ""
            End If

        End If
        CrewListView.ActiveFilter.NonColumnFilter = strFinalFilter
    End Sub


    Private Sub cmdApplyFilter_Click(sender As System.Object, e As System.EventArgs) Handles cmdApplyFilter.Click
        ShowCustomLoadScreen(GetType(MPS4.Waitform))
        If IIf(GetPayType.Equals(0), isValidNoPeriod(cboPeriod.EditValue, IIf(GetPayType.Equals(1), cboRefNum.Text, txtRef.Text)), True) Then
            DeleteTempPayLock()
            SelectRefreshAction(VslView)
            If PayCrewView.RowCount < 1 Then
                If ValidateFields(RequiredControls) Then
                    'cboPeriod
                    SFKeyPrincipal = cboPrincipal.EditValue
                    SPeriod = cboPeriod.EditValue
                    SRefNo = IIf(GetPayType.Equals(1), cboRefNum.EditValue, txtRef.Text)
                    _SDateFrom = NumCodeToDate(SPeriod, 1).ToString("yyyy-MM-dd")
                    _SDateTo = NumCodeToDate(SPeriod, GetDaysOfMonth(NumCodeToDate(SPeriod, 1))).ToString("yyyy-MM-dd")

                    InitLoadCrewList(_SDateFrom, SFKeyPrincipal)
                    'cboPrincipal
                    EnableDisableVslView()
                    VslGrid.DataSource = LoadVessel()
                    FilterVessel(cboPrincipal.EditValue)

                    'InitializePayCrew()

                    If GetPayType.Equals(1) Then
                        CheckVessel()
                        LoadPayExRate(cboRefNum.EditValue)
                    End If
                End If
            End If
        Else
            MsgBox("The Reference Number already exists, Please use [Add Crew to Payroll] instead.", MsgBoxStyle.Exclamation, GetAppName)
            SPeriod = Nothing
            SRefNo = Nothing
            EnableDisableVslView()
        End If


        CloseCustomLoadScreen()




        'ShowCustomLoadScreen(GetType(Waitform))
        'If IIf(GetPayType.Equals(0), isValidNoPeriod(cboPeriod.EditValue, IIf(GetPayType.Equals(1), cboRefNum.Text, txtRef.Text)), True) Then
        '    DeleteTempPayLock()
        '    SelectRefreshAction(VslView)
        '    If PayCrewView.RowCount < 1 Then
        '        If ValidateFields(RequiredControls) Then
        '            SFKeyPrincipal = cboPrincipal.EditValue
        '            SPeriod = cboPeriod.EditValue
        '            SRefNo = IIf(GetPayType.Equals(1), cboRefNum.EditValue, txtRef.Text)
        '            EnableDisableVslView()
        '            GenerateCrewList(CDate(ChangeToSQLDate(SPeriod, 1).Replace("'", "")), SFKeyPrincipal)
        '            FilterVessel(SFKeyPrincipal)

        '            If GetPayType.Equals(1) Then
        '                tblPayExRateTbl = GetPayExRateTbl(cboRefNum.EditValue)
        '                ExRateGrid.DataSource = tblPayExRateTbl
        '                VslView.ActiveFilter.NonColumnFilter = "RefNo ='" & cboRefNum.EditValue & "'"
        '            End If
        '        End If
        '    End If
        'Else
        '    MsgBox("The Reference Number already exists, Please use [Add Crew to Payroll] instead.", MsgBoxStyle.Exclamation, GetAppName)
        '    SPeriod = Nothing
        '    SRefNo = Nothing
        '    EnableDisableVslView()
        'End If
        'CloseCustomLoadScreen()

    End Sub

    Private Sub selectVslViewValues(_tsetSVsl As List(Of Integer))
        'Throw New NotImplementedException
        For index = 0 To _tsetSVsl.Count - 1
            VslView.SelectRow(_tsetSVsl(index))
        Next
        tsetSVsl = New List(Of Integer)
    End Sub

    Private Sub cboPeriod_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboPeriod.EditValueChanging
        If BRECORDUPDATEDs Then
            If Not IsNothing(PayCrewView.DataSource) Then
                If TryCast(PayCrewView.DataSource, DataView).Count > 0 Then
                    ClearSelectionVslView()
                    If msgClearSelection.Equals(MsgBoxResult.Yes) Then
                        InitializePayCrew()
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub



#Region "Payroll Selection Lock"

    Dim PayrollLockType As String = "ONB"

    Private Sub LoadSelection(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs)
        Cursor = Cursors.WaitCursor
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim ExistInSelection As Boolean
        LtblCrewList = BuildIndex(TryCast(PayCrewView.DataSource, DataView).ToTable, "FKeyVslCode")

        If e.Action = System.ComponentModel.CollectionChangeAction.Refresh Then
            If VslView.GetSelectedRows.Length = VslView.RowCount Then
                SelectedVsls = New List(Of Integer)(_view.GetSelectedRows.AsEnumerable)
                SelectRefreshAction(_view)
            Else
                If IsNothing(SelectedVsls) Then
                    SelectedVsls = New List(Of Integer)(_view.GetSelectedRows.AsEnumerable)
                    SelectRefreshAction(_view)
                Else

                    If PayCrewView.RowCount > 0 Then
                        tsetSVsl = New List(Of Integer)
                        For index = 0 To SelectedVsls.Count - 1
                            If ItemExists(LtblCrewList, _view.GetRowCellValue(SelectedVsls(index), "PKey")) Then
                                If SelectedVsls.Count > 1 Then
                                    strMsg = "Do you want to remove the crew(s) of the following vessel(s) in crew(s) to be processed?:  " & vbCrLf
                                    Dim strvslList As String = String.Empty
                                    For index1 = 0 To SelectedVsls.Count - 1
                                        If ItemExists(LtblCrewList, _view.GetRowCellValue(SelectedVsls(index1), "PKey")) Then
                                            strvslList = strvslList & "[" & VslView.GetRowCellDisplayText(SelectedVsls(index1), "Name") & "]" & vbCrLf
                                            tsetSVsl.Add(SelectedVsls(index1))
                                        End If
                                    Next
                                    strMsg = strMsg & strvslList
                                Else
                                    strMsg = "Do you want to clear the Crew(s) to be processed?"
                                    tsetSVsl = SelectedVsls
                                End If
                                msgClearSelection = MsgBox(strMsg, MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName())
                                If msgClearSelection = MsgBoxResult.Yes Then
                                    LoadCrewList()
                                    InitializePayCrew()
                                    Exit For
                                Else
                                    Exit For
                                End If
                            End If
                        Next
                        SelectRefreshAction(_view)
                        SelectedVsls = tsetSVsl
                    Else
                        SelectRefreshAction(_view)
                    End If
                End If
            End If
        ElseIf e.Action = System.ComponentModel.CollectionChangeAction.Add Then
            Dim strVslCode As String = _view.GetRowCellValue(e.ControllerRow, "PKey")
            If Not CheckIsInUse(FKeyVsl:=strVslCode) Then
                InsertTempPayLock(FKeyVsl:=strVslCode)
            Else
                _view.UnselectRow(e.ControllerRow)
            End If
        ElseIf e.Action = System.ComponentModel.CollectionChangeAction.Remove Then
            Dim strVslCode As String = _view.GetRowCellValue(e.ControllerRow, "PKey")
            DeleteTempPayLock(strVslCode)
        End If

        If PayCrewView.RowCount > 0 Then

            If e.Action = System.ComponentModel.CollectionChangeAction.Remove Then
                SelectedVsls = SelectedVsls
                ExistInSelection = Array.Exists(SelectedVsls.ToArray, Function(x) x.Equals(e.ControllerRow))
                If ExistInSelection Then
                    If ItemExists(LtblCrewList, _view.GetFocusedRowCellValue("PKey")) Then
                        If SelectedVsls.Count > 0 Then
                            strMsg = "Do you want to remove the crew(s) from this vessel [" & VslView.GetRowCellDisplayText(e.ControllerRow, "Name") & "]?"
                        Else
                            strMsg = "Do you want to clear the Crew(s) to be processed?"
                        End If
                        If MsgBox(strMsg, MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
                            LoadCrewList()
                            InitializePayCrew()
                        Else
                            _view.SelectRow(_view.FocusedRowHandle)
                        End If
                    Else
                        LoadCrewList()
                    End If
                End If
            ElseIf e.Action = System.ComponentModel.CollectionChangeAction.Add Then
                If tsetSVsl.Count > 0 Then
                    SelectedVsls = tsetSVsl
                Else
                    SelectedVsls = New List(Of Integer)(_view.GetSelectedRows.AsEnumerable)
                End If
                ExistInSelection = Array.Exists(SelectedVsls.ToArray, Function(x) x.Equals(e.ControllerRow))
                If ExistInSelection Then
                    LoadCrewList()
                End If
            ElseIf e.Action = System.ComponentModel.CollectionChangeAction.Refresh Then
                selectVslViewValues(tsetSVsl)
                LoadCrewList()
            End If
        Else
            SelectedVsls = New List(Of Integer)(_view.GetSelectedRows.AsEnumerable)
            LoadCrewList()
        End If
        Cursor = Cursors.Default

    End Sub

    Private Function InsertTempPayLock(FKeyVsl As String) As Boolean
        Dim retval As Boolean = False
        Dim sqlCon As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim Period As Integer = IfNull(cboPeriod.EditValue, 0)
        Try
            sqlCon.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlCon
                cmd.CommandText = "INSERT INTO dbo.Temp_PayLock(MCode,FKeyVslCode,PayType,USERNAME,UserID) VALUES(@MCode,@FKeyVslCode,@PayType,@USERNAME,@UserID)"
                With cmd.Parameters
                    .AddWithValue("@MCode", Period)
                    .AddWithValue("@FKeyVslCode", FKeyVsl)
                    .AddWithValue("@PayType", PayrollLockType)
                    .AddWithValue("@UserID", USER_ID)
                    .AddWithValue("@USERNAME", USER_NAME)
                End With
                retval = cmd.ExecuteNonQuery > 0
            End Using
        Catch ex As Exception
            retval = False
        Finally
            If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
        End Try
        Return retval
    End Function


    Private Function DeleteTempPayLock(Optional FKeyVsl As String = "") As Boolean
        Dim retval As Boolean = False
        Dim sqlCon As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim Period As Integer = IfNull(cboPeriod.EditValue, 0)
        Try
            sqlCon.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlCon
                If Trim(FKeyVsl).Length > 0 Then
                    cmd.CommandText = "DELETE FROM dbo.Temp_PayLock WHERE MCode = @MCode AND FKeyVslCode = @FKeyVslCode AND UserID= @UserID AND PayType=@PayType"
                    With cmd.Parameters
                        .AddWithValue("@MCode", Period)
                        .AddWithValue("@FKeyVslCode", FKeyVsl)
                        .AddWithValue("@PayType", PayrollLockType)
                        .AddWithValue("@UserID", USER_ID)
                    End With
                    retval = cmd.ExecuteNonQuery > 0
                Else
                    'Delete Payroll Related to User
                    cmd.CommandText = "DELETE FROM dbo.Temp_PayLock WHERE UserID= @UserID AND PayType=@PayType"
                    With cmd.Parameters
                        .AddWithValue("@MCode", Period)
                        .AddWithValue("@PayType", PayrollLockType)
                        .AddWithValue("@UserID", USER_ID)
                    End With
                    retval = cmd.ExecuteNonQuery > 0
                End If
            End Using
        Catch ex As Exception
            retval = False
            MsgBox(ex.Message)
        Finally
            If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
        End Try
        Return retval
    End Function

    Private Function GetVslInUsed(Optional FKeyVsl As String = "") As DataTable
        Dim retval As New DataTable
        Dim sqlCon As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim Period As Integer = IfNull(cboPeriod.EditValue, 0)

        Try
            sqlCon.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlCon
                If Trim(FKeyVsl).Length > 0 Then
                    cmd.CommandText = "SELECT * FROM dbo.Temp_Paylock WHERE UserID <> @UserID AND MCode= @MCode AND FKeyVslCode=@FKeyVslCode AND PayType=@PayType"
                    With cmd.Parameters
                        .AddWithValue("@MCode", Period)
                        .AddWithValue("@FKeyVslCode", FKeyVsl)
                        .AddWithValue("@PayType", PayrollLockType)
                        .AddWithValue("@UserID", USER_ID)
                    End With
                Else
                    cmd.CommandText = "SELECT * FROM dbo.Temp_Paylock WHERE UserID <> @UserID AND MCode= @MCode AND PayType=@PayType"
                    With cmd.Parameters
                        .AddWithValue("@MCode", Period)
                        .AddWithValue("@PayType", PayrollLockType)
                        .AddWithValue("@UserID", USER_ID)
                    End With
                End If

                Using adm As New SqlClient.SqlDataAdapter(cmd)
                    adm.Fill(retval)
                End Using
            End Using
        Catch ex As Exception
        Finally
            If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
        End Try
        Return retval
    End Function

    Private Function CheckIsInUse(FKeyVsl As String, Optional isMsgShow As Boolean = True) As Boolean
        Dim retval As Boolean = False
        Dim tblVslInUsedBy As New DataTable
        Try
            tblVslInUsedBy = GetVslInUsed(FKeyVsl)
            Dim strVslName As String = String.Empty
            If tblVslInUsedBy.Rows.Count > 0 Then
                If isMsgShow Then
                    For Each dr As DataRow In tblVslInUsedBy.Rows
                        Dim vslCode As String = dr("FKeyVslCode")
                        Dim vslName = (From a As DataRowView In TryCast(VslView.DataSource, DataView)
                                       Where a.Item("PKey") = vslCode
                                       Select a("Name")).FirstOrDefault()
                        strVslName = strVslName & vslName & " is currently selected by user [" & dr("USERNAME") & "] for payroll process. " & vbCrLf
                    Next
                    MsgBox("Unable to select the vessel(s): " & vbCrLf & strVslName, MsgBoxStyle.Exclamation, GetAppName())
                End If
                retval = True
            Else
                retval = False
            End If
        Catch ex As Exception
            retval = False
            MsgBox(ex.Message)
        Finally
        End Try
        Return retval
    End Function

    Private Sub SelectRefreshAction(view As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim getSelectedRows As Integer() = view.GetSelectedRows
        Dim FkeyVslCode As String = String.Empty
        Dim vslListDictionary As New Dictionary(Of String, String)
        Dim UserListDictionary As New Dictionary(Of String, String)
        Dim vslList As New List(Of String)
        'Dim vslList As New Dictionary(Of String, String)

        Dim ctbl As New DataTable
        If getSelectedRows.Count > 0 Then
            ctbl = GetVslInUsed()
            For index = 0 To getSelectedRows.Count - 1
                FkeyVslCode = view.GetRowCellValue(getSelectedRows(index), "PKey")

                Dim isUsedCount = (From a As DataRow In ctbl.Rows
                            Where (a("FKeyVslCode") = FkeyVslCode And
                            a("MCode") = IfNull(cboPeriod.EditValue, 0) And
                            a("UserID") <> USER_ID)
                            Select (a("FKeyVslCode"))).Count()
                If isUsedCount > 0 Then
                    Dim UserName = (From a As DataRow In ctbl.Rows
                          Where (a("FKeyVslCode") = FkeyVslCode And
                          a("MCode") = IfNull(cboPeriod.EditValue, 0) And
                          a("UserID") <> USER_ID)
                          Select (a("USERNAME"))).FirstOrDefault
                    UserListDictionary.Add(FkeyVslCode, UserName) 'User Name

                    Dim strVslName = (From a As DataRowView In TryCast(VslView.DataSource, DataView)
                                      Where a("PKey") = FkeyVslCode
                                      Select a("Name")).FirstOrDefault()
                    vslListDictionary.Add(FkeyVslCode, strVslName) 'Vsl Name

                    vslList.Add(FkeyVslCode) 'VslList that is in use
                Else
                    InsertTempPayLock(FkeyVslCode)
                End If
            Next

            If vslListDictionary.Count > 0 Then
                Dim strVslUser As String = String.Empty
                For index = 0 To vslList.Count - 1
                    strVslUser = vslListDictionary(vslList(index)) & " is currently is use by " & UserListDictionary(vslList(index)) & vbCrLf & strVslUser
                Next
                MsgBox("The Vessel(s) is used: " & vbCrLf & strVslUser, MsgBoxStyle.Exclamation, GetAppName())
                view.ClearSelection()
            End If
        Else
            DeleteTempPayLock()
        End If

    End Sub

    Private Sub PayrollProcessOnb_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        DeleteTempPayLock()
    End Sub

#End Region

    Private Function isValidNoPeriod(MCode As Integer, strRefNo As Object) As Object
        Dim retVal As Boolean = False
        Dim sqlconn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlconn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlconn
                cmd.CommandText = "SELECT COUNT(*) FROM dbo.tblPay WHERE PayType='ONB' AND MCode=@MCode AND RefNo=@RefNo"
                With cmd.Parameters
                    .AddWithValue("@MCode", MCode)
                    .AddWithValue("@RefNo", strRefNo)
                End With
                retVal = (cmd.ExecuteScalar <= 0)
            End Using
        Catch ex As Exception
            retVal = False
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlconn.State = ConnectionState.Open Then sqlconn.Close()
        End Try

        Return retVal
    End Function

    Private Sub txtRef_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtRef.EditValueChanging
        If isBuildData Then
            If Not IsNothing(e.NewValue) Then
                If Not e.NewValue.Equals(SRefNo) Then
                    If MsgBox("You are about to change the Reference Number, this will clear all your crew list. Do you want to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        e.Cancel = False
                        EnableDisableVslView()
                        isBuildData = False
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

#Region "Revised Processing Approach"
    'following functions and events are added by tony20180907

    Private Sub cmdBuildData_Click(sender As Object, e As System.EventArgs) Handles cmdBuildData.Click
        'ShowCustomLoadScreen(GetType(MPS4.Waitform))
        'If IIf(GetPayType.Equals(0), isValidNoPeriod(cboPeriod.EditValue, IIf(GetPayType.Equals(1), cboRefNum.Text, txtRef.Text)), True) Then
        '    DeleteTempPayLock()
        '    SelectRefreshAction(VslView)
        '    If ValidateFields(RequiredControls) Then
        '        SPeriod = cboPeriod.EditValue
        '        SRefNo = IIf(GetPayType.Equals(1), cboRefNum.EditValue, txtRef.Text)
        '        GenerateCrewListByVessel(CDate(ChangeToSQLDate(SPeriod, 1).Replace("'", "")), GetVslList())
        '        LoadCrewList()

        '        If GetPayType.Equals(1) Then
        '            tblPayExRateTbl = GetPayExRateTbl(cboRefNum.EditValue)
        '            ExRateGrid.DataSource = tblPayExRateTbl
        '            VslView.ActiveFilter.NonColumnFilter = "RefNo ='" & cboRefNum.EditValue & "'"
        '        End If

        '        Application.DoEvents()
        '        PayrollFunctions.TransferAll(CrewListGrid, _
        '                         PayCrewGrid, _
        '                         CrewListGrid.DataSource, _
        '                         tblCrewList, True, False)
        '    End If

        '    SetSelectionMode(SelectionMode.Crew)
        '    lcgCrewSelection.Enabled = True

        'Else
        '    MsgBox("The Reference Number already exists, Please use [Add Crew to Payroll] instead.", MsgBoxStyle.Exclamation, GetAppName)
        '    SPeriod = Nothing
        '    SRefNo = Nothing
        '    EnableDisableVslView()
        'End If
        'CloseCustomLoadScreen()

        ShowCustomLoadScreen(GetType(MPS4.Waitform))
        If IIf(GetPayType.Equals(0), isValidNoPeriod(cboPeriod.EditValue, IIf(GetPayType.Equals(1), cboRefNum.Text, txtRef.Text)), True) Then
            DeleteTempPayLock()
            SelectRefreshAction(VslView)
            If ValidateFields(RequiredControls) Then
                'cboPeriod
                SFKeyPrincipal = cboPrincipal.EditValue
                SPeriod = cboPeriod.EditValue
                SRefNo = IIf(GetPayType.Equals(1), cboRefNum.EditValue, txtRef.Text)
                _SDateFrom = NumCodeToDate(SPeriod, 1).ToString("yyyy-MM-dd")
                _SDateTo = NumCodeToDate(SPeriod, GetDaysOfMonth(NumCodeToDate(SPeriod, 1))).ToString("yyyy-MM-dd")

                InitLoadCrewListByVessel(_SDateFrom, GetVslList())
                'cboPrincipal
                EnableDisableVslView()
                'VslGrid.DataSource = LoadVessel()
                'tony20180907 FilterVessel(cboPrincipal.EditValue)
                LoadCrewList()

                'InitializePayCrew()

                If GetPayType.Equals(1) Then
                    CheckVessel()
                    LoadPayExRate(cboRefNum.EditValue)
                End If

                Application.DoEvents()
                CrewListView.SelectAll()
                PayrollFunctions.TransferAll(CrewListGrid, _
                                             PayCrewGrid, _
                                             CrewListGrid.DataSource, _
                                             tblCrewList, True, False)
            End If

            SetSelectionMode(SelectionMode.Crew)

        Else
            MsgBox("The Reference Number already exists, Please use [Add Crew to Payroll] instead.", MsgBoxStyle.Exclamation, GetAppName)
            SPeriod = Nothing
            SRefNo = Nothing
            EnableDisableVslView()
        End If


        CloseCustomLoadScreen()
    End Sub

    Private Sub ClearSelection()
        ExRateGrid.DataSource = Nothing
        ClearCrewList()
        SetSelectionMode(SelectionMode.Vessel)
    End Sub

    Private Enum SelectionMode
        Crew = 1
        Vessel = 2
        AddCrewToPayroll = 3
    End Enum

    Private Sub SetSelectionMode(SelectionMode As SelectionMode)
        Dim isEnable As Boolean
        'CREW SELECTION
        isEnable = (SelectionMode = PayrollProcessOnb.SelectionMode.Crew) Or (SelectionMode = PayrollProcessOnb.SelectionMode.AddCrewToPayroll)
        lcgCrewSelection.Enabled = isEnable
        CrewListGrid.Enabled = isEnable
        cboAgent.Enabled = isEnable
        cboNat.Enabled = isEnable
        cmdSelectAll.Enabled = isEnable
        PayCrewGrid.Enabled = isEnable
        cmdPaySelectAll.Enabled = isEnable
        cmdExRate.Enabled = isEnable
        ExRateGrid.Enabled = isEnable

        'VESSEL SELECTION
        lcgVslSelection.Enabled = (SelectionMode = PayrollProcessOnb.SelectionMode.Vessel)
        VslGrid.Enabled = (SelectionMode = PayrollProcessOnb.SelectionMode.Vessel)

        'EX RATE
        cmdExRate.Enabled = (SelectionMode = PayrollProcessOnb.SelectionMode.Crew)
    End Sub

    Private Function GetVslList() As DataTable
        Dim ReturnValue As New DataTable
        Dim col As New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        ReturnValue.Columns.Add(col)

        Try
            For Each i As Integer In VslView.GetSelectedRows()
                ReturnValue.Rows.Add(VslView.GetRowCellValue(i, "PKey"))

            Next
        Catch ex As Exception
            LogErrors("Pay HA GetVslList(): Failed to loop through each selected vessels. [" & ex.Message & "]")
        End Try

        Return ReturnValue
    End Function

    Private Sub GenerateCrewListByVessel(Period As DateTime, VslList As DataTable)
        Dim cTable As New DataTable
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandText = "SP_PAY_ONB_CrewList_ByVessel"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@DateStart", Period.ToString("yyyy-MM-dd"))
                    .AddWithValue("@VslList", VslList)
                End With

                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(cTable)
                End Using
            End Using


        Catch ex As Exception
            MsgBox("An error occurred while building the data.", MsgBoxStyle.Exclamation, GetAppName())
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try


        Dim crewFilter As String = IIf(Trim(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")).Length > 0, "  " & GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt"), "")
        Dim DV As New DataView(cTable)
        DV.RowFilter = crewFilter
        If DV.Count > 0 Then
            tblCrewList = DV.ToTable
        Else
            tblCrewList = DV.ToTable.Clone
        End If
    End Sub

    Private Sub cmdRefreshSelection_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefreshSelection.Click
        If PayCrewView.RowCount > 0 Then
            If MsgBox("There are crews already selected to be processed in the payroll." & vbNewLine & vbNewLine & "Do you want to continue to reset the selection?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Reset Selection") = MsgBoxResult.No Then Exit Sub
        End If

        If GetPayType.Equals(0) Then        'NEW PAYROLL
            ClearSelection()
            ClearPayCrew()

        ElseIf GetPayType.Equals(1) Then    'ADD CREW TO PAYROLL
            ClearEverything()
        End If
        
        InitSelectionMode()
    End Sub

    Private Sub ClearPayCrew()

        Dim PayCrewtbl As New DataTable
        For Each dc As DevExpress.XtraGrid.Columns.GridColumn In CrewListView.Columns
            PayCrewtbl.Columns.Add(dc.FieldName)
        Next

        Dim strCrewFilter As String = getSelectedVesel(VslView)
        Dim withPayCrewFilter As String = ""
        Dim strFilter As String = ""

        If strCrewFilter.Equals("") Then
            PayCrewGrid.DataSource = PayCrewtbl
        Else

            If PayCrewView.RowCount > 0 Then
                withPayCrewFilter = " AND " & FilterPayList()
            Else
                withPayCrewFilter = ""
            End If
            strFilter = strCrewFilter & withPayCrewFilter

            PayCrewGrid.DataSource = PayCrewtbl
        End If
        ExRateGrid.DataSource = InitExRateDT()
    End Sub

    Private Sub CheckVessel(Period As Integer, RefNo As String)
        VslView.ClearSelection()
        Dim strFilter As String = ""
        For Each dr As DataRow In DB.CreateTable("SELECT * FROM dbo.tblPay WHERE PayType='HA' AND MCode= " & Period & " AND RefNo = '" & RefNo & "'").Rows
            strFilter = "'" & dr("FKeyVsl").ToString() & "'," & strFilter
        Next
        If strFilter.Length > 0 Then
            strFilter = strFilter.Substring(0, Len(strFilter) - 1)
            strFilter = "PKey IN(" & strFilter & ")"
            'Dim dv As DataView = TryCast(VslView.DataSource, DataView)
            Dim dv As New DataView(tblVsl)
            dv.RowFilter = strFilter
            VslGrid.DataSource = dv
            'VslView.ActiveFilter.NonColumnFilter = strFilter
        Else
            VslGrid.DataSource = Nothing
            'VslView.ActiveFilter.NonColumnFilter = strFilter
        End If

    End Sub

    Private Sub FilterVesselByRefNo(Optional PrinCode As String = "", Optional RefNo As String = "")

        Dim dvVsl As New DataView(tblVsl)
        If GetPayType = 0 Then
            dvVsl.RowFilter = "FKeyPrincipal='" & PrinCode & "'"
            VslGrid.DataSource = dvVsl.ToTable
        ElseIf GetPayType = 1 Then
            InitAddTblVslByRefNo(PrinCode, RefNo)
            'ExRateGrid.DataSource = tblPayExRateTbl
        End If


    End Sub

    Private Sub InitAddTblVslByRefNo(Optional PrinCode As String = "", Optional RefNo As String = "")
        Dim vslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
        Dim str As String = " SELECT vsl.*,pay.PKey As FKeyPay,pay.RefNo,pay.DateCreated " & _
            " FROM dbo.VslList vsl " & _
            " INNER JOIN dbo.tblPay pay ON vsl.PKey IN(pay.FKeyVsl) " & _
            " WHERE pay.Paytype = 'HA' AND pay.MCode = " & cboPeriod.EditValue & " AND vsl.FKeyPrincipal = '" & PrinCode & "' AND pay.RefNo = '" & RefNo & "' ORDER BY Name "
        Dim _tblVsl As DataTable
        _tblVsl = DB.CreateTable(str)
        If _tblVsl.Rows.Count > 0 Then
            If _tblVsl.Select(vslFilter).Length > 0 Then
                _tblVsl = DB.CreateTable(str).Select(vslFilter).CopyToDataTable
                VslGrid.DataSource = _tblVsl
            Else
                _tblVsl = DB.CreateTable(str).Clone
                VslGrid.DataSource = _tblVsl
            End If
        Else
            _tblVsl = DB.CreateTable(str).Clone
            VslGrid.DataSource = _tblVsl
        End If

    End Sub

    Private Function InitRefNo_AddCrewToPayroll(Period As Integer) As DataTable
        Dim cTable As New DataTable
        cTable = DB.CreateTable("SELECT concat(Refno, ' - ', VslName) as PayDesc, PKey as PayID, * FROM dbo.tblPay WHERE MCode = " & Period & " AND PayType='ONB' AND isLocked = 0")
        Dim dvRef As New DataView(cTable)
        dvRef.Sort = "VslName"
        cTable = dvRef.ToTable(True, New String() {"PayDesc", "PayID", "FKeyVsl", "RefNo"})
        Return cTable
    End Function

    Private Function GetVslListFromSelectedRefNo() As DataTable
        Dim ReturnValue As New DataTable
        Dim col As New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        ReturnValue.Columns.Add(col)

        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(cboRefNum, DevExpress.XtraEditors.LookUpEdit)
            Dim value As Object = editor.GetColumnValue("FKeyVsl")

            If IfNull(value, "").Length > 0 Then
                ReturnValue.Rows.Add(New Object() {value})
            End If
        Catch ex As Exception
            LogErrors("Pay ONB GetVslListFromSelectedRefNo(): Failed to loop through each selected vessels. [" & ex.Message & "]")
        End Try

        Return ReturnValue
    End Function

    Private Sub RefnoSelected(PayID As String)
        Dim tblPayExRateTbl As New DataTable
        If GetPayType.Equals(1) Then
            Try
                tblPayExRateTbl = DB.CreateTable("SELECT * FROM dbo.tblPayExRate er INNER JOIN dbo.tblPay p ON p.PKey = er.FKeyPay WHERE p.PKey= '" & PayID & "'")
            Catch ex As Exception
                tblPayExRateTbl = Nothing
            End Try
        End If

        Dim dRow As DataRow = tblPayExRateTbl.Select("FKeyPay = '" & PayID & "'").FirstOrDefault
        If Not dRow Is Nothing Then
            cboPrincipal.EditValue = dRow.Item("FKeyPrincipal")
            txtDateCreated.EditValue = dRow.Item("DateCreated")
        End If

        ExRateGrid.DataSource = tblPayExRateTbl
        VslGrid.DataSource = Nothing
        'CheckVessel(cboPeriod.EditValue, LookUpEd.EditValue)

        GenerateCrewListByVessel(CDate(ChangeToSQLDate(cboPeriod.EditValue, 1).Replace("'", "")), GetVslListFromSelectedRefNo())
        LoadCrewList()

        Application.DoEvents()
        PayrollFunctions.TransferAll(CrewListGrid, _
                         PayCrewGrid, _
                         CrewListGrid.DataSource, _
                         tblCrewList, True, False)

    End Sub

    Private Sub LoadRefNum_AddCrewToPayroll(MCode As Integer)
        'Dim prinFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal").Length > 0, " AND " & GetUserFilterString(, , "FKeyPrincipal"), "")
        Dim RefFilter As String = IIf(GetUserVslFilterString(, "FKeyVsl").Length > 0, " AND " & GetUserVslFilterString(, "FKeyVsl"), "")
        tblPay = DB.CreateTable("SELECT * FROM dbo.tblPay WHERE MCode = " & MCode & " AND Paytype = 'ONB' " & RefFilter)
    End Sub

    Private Sub InitSelectionMode()
        If GetPayType = 1 Then
            SetSelectionMode(SelectionMode.AddCrewToPayroll)
        Else
            SetSelectionMode(SelectionMode.Vessel)
        End If
    End Sub

    Private Sub ClearEverything()
        ClearFields(lcgCrewsIncluded, False)
        cboPeriod.EditValue = Nothing
        cboPrincipal.EditValue = Nothing
        txtRef.Text = Nothing
        cboRefNum.EditValue = Nothing
        cboRefNum.Properties.DataSource = Nothing
        txtDateCreated.EditValue = Date.Now
        VslGrid.DataSource = Nothing
        ExRateGrid.DataSource = Nothing
        ClearCrewList()
    End Sub
#End Region
End Class


