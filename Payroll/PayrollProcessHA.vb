﻿Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class PayrollProcessHA

#Region "Declaration"
    Dim tblCrewList As New DataTable
    Dim tblVsl As New DataTable
    Dim tblPay As New DataTable
    Dim _SDateFrom As String = ""
    Dim isCrewReload As Boolean = True
    Dim LtblCrewList As List(Of String)
    Dim tblExrate As DataTable
    Dim tblPayExRateTbl As DataTable
    Dim strRefCurr As String = String.Empty
    Dim srcGridControl As DevExpress.XtraGrid.GridControl

    Dim SFKeyPrincipal As String = Nothing
    Dim SRefNo As String = Nothing
    Dim SPeriod As Integer = Nothing

    Dim msgClearSelection As MsgBoxResult

    Dim isBuildData As Boolean = False

    Dim clsAudit As New clsAudit 'neil
    Dim txtrefno As String = ""

#End Region

#Region "Initialize"

    'Dim LastUpdatedBy = "LastUpdatedBY"

    Dim LastUpdatedBy As String = ""

    Private Sub InitControls()
        ClearEverything()
        cboPeriod.Properties.DataSource = GetPayPeriods("MONTH", 36, 3)
        repERFKeyCurr.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCurr ORDER BY Name")

        Dim AgentFilter As String = IIf(GetUserFilterString(, "PKey", ).Length > 0, " WHERE " & GetUserFilterString(, "PKey", ), "")
        cboAgent.Properties.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.AgentList " & AgentFilter & " ORDER BY Name")
        cboNat.Properties.DataSource = DB.CreateTable("SELECT PKey,Nat AS Name,SortCode FROM dbo.tblAdmCntry ORDER BY Nat")

        Dim prinFilter As String = IIf(GetUserFilterString(, , "PKey").Length > 0, " WHERE " & GetUserFilterString(, , "PKey"), "")
        tblPrin = DB.CreateTable("SELECT * FROM dbo.PrincipalList " & prinFilter & " ORDER BY Name")
        cboPrincipal.Properties.DataSource = tblPrin

        Dim vslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, " WHERE " & GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
        tblVsl = DB.CreateTable("SELECT * FROM dbo.VslList " & vslFilter & "ORDER BY Name")
        'VslGrid.DataSource = tblVsl


        'Select Payroll Type to New
        GetPayType = 0
        'InitializePayCrew() 'initialize PayCrew Table

        clsAudit.propSQLConnStr = MPSDB.GetConnectionString

        SetProcessedPayrollListVisibility(Name, True)
    End Sub

    Private Sub InitializePayCrew()

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
        End If
        ExRateGrid.DataSource = InitExRateDT()
    End Sub

    Private Function InitRefNo(Period As Integer) As DataTable
        Dim cTable As New DataTable
        cTable = DB.CreateTable("SELECT * FROM dbo.tblPay WHERE MCode = " & Period & " AND PayType='HA'")
        Dim dvRef As New DataView(cTable)
        cTable = dvRef.ToTable(True, New String() {"RefNo"})
        Return cTable
    End Function

    Private Sub GenerateCrewList(Period As DateTime, PrinCode As String)
        Dim cTable As New DataTable
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandText = "SP_PAY_HA_CrewList"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@DateStart", Period.ToString("yyyy-MM-dd"))
                    .AddWithValue("@PrinCode", PrinCode)
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

    Private Function InitExRateDT() As DataTable
        Dim ctable As New DataTable
        ctable.Columns.Add("FKeyCurr", GetType(String))
        ctable.Columns.Add("ExRate", GetType(String))
        Return ctable
    End Function

    Private Function GetPayExRateTbl(RefNo As String) As DataTable
        Dim cTbl As New DataTable
        cTbl = DB.CreateTable("SELECT * FROM dbo.tblPayExRate er INNER JOIN dbo.tblPay p ON p.PKey = er.FKeyPay WHERE p.RefNo= '" & RefNo & "'")
        Return cTbl
    End Function

    Private Sub FilterExRatePay(FKeyPay As String)
        If ExRateView.DataRowCount > 0 Then
            ExRateView.ActiveFilter.NonColumnFilter = "FKeyPay='" & FKeyPay & "'"
        End If
    End Sub

    Private Sub InitAddTblVsl(Optional PrinCode As String = "")
        Dim vslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
        Dim str As String = " SELECT vsl.*,pay.PKey As FKeyPay,pay.RefNo,pay.DateCreated " & _
            " FROM dbo.VslList vsl " & _
            " INNER JOIN dbo.tblPay pay ON vsl.PKey IN(pay.FKeyVsl) " & _
            " WHERE pay.Paytype = 'HA' AND pay.MCode = " & cboPeriod.EditValue & " AND vsl.FKeyPrincipal = '" & PrinCode & "' ORDER BY Name "
        tblVsl = DB.CreateTable(str)
        If tblVsl.Rows.Count > 0 Then
            If tblVsl.Select(vslFilter).Length > 0 Then
                tblVsl = DB.CreateTable(str).Select(vslFilter).CopyToDataTable
                VslGrid.DataSource = tblVsl
            Else
                tblVsl = DB.CreateTable(str).Clone
                VslGrid.DataSource = tblVsl
            End If
        Else
            tblVsl = DB.CreateTable(str).Clone
            VslGrid.DataSource = tblVsl
        End If

    End Sub

    Private Sub SetRefCurrency()
        Dim refCurr As String = String.Empty
        refCurr = DB.DLookUp("Symbol", "tbladmCurr", String.Empty, "Ref<>0")
        strRefCurr = DB.DLookUp("PKey", "tbladmCurr", String.Empty, "Ref<>0")
        lcgExRate.Text = "5. Exchange Rate: per 1 " & refCurr
    End Sub

#End Region

#Region "Load Sub"

    Private Sub FilterVessel(Optional PrinCode As String = "")

        Dim dvVsl As New DataView(tblVsl)
        If GetPayType = 0 Then
            dvVsl.RowFilter = "FKeyPrincipal='" & PrinCode & "'"
            VslGrid.DataSource = dvVsl.ToTable
        ElseIf GetPayType = 1 Then
            InitAddTblVsl(PrinCode)
            'ExRateGrid.DataSource = tblPayExRateTbl
        End If


    End Sub

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

    Public Sub LoadCrewList()
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

            If tblCrewList.Rows.Count > 0 Then
                If tblCrewList.Select(strFilter).Length > 0 Then
                    CrewListGrid.DataSource = tblCrewList.Select(strFilter).CopyToDataTable
                    Dim _v As DevExpress.XtraGrid.Views.Grid.GridView = CrewListGrid.DefaultView
                    SortCrewList(_v)
                Else
                    CrewListGrid.DataSource = tblCrewList.Clone
                End If
            Else
                CrewListGrid.DataSource = tblCrewList.Clone
            End If

        End If
    End Sub

    Private Function GetPayID(VslCode As String, RefNo As String) As String
        Dim retval As String = ""
        For Each dRowView As DataRowView In VslView.DataSource
            If dRowView("PKey").ToString.Equals(VslCode) And dRowView("RefNo").Equals(RefNo) Then
                retval = IfNull(dRowView("FKeyPay"), "")
                Exit For
            Else
                retval = ""
            End If
        Next

        Return retval
    End Function

    Private Function GetPayDateCreated(VslCode As String, RefNo As String) As String
        Dim retval As String = ""
        For Each dRowView As DataRowView In VslView.DataSource
            If dRowView("PKey").ToString.Equals(VslCode) And dRowView("RefNo").Equals(RefNo) Then
                retval = IfNull(dRowView("DateCreated"), "")
                Exit For
            Else
                retval = ""
            End If
        Next
        Return retval
    End Function

    Private Sub GeneratePayIDinCrewList(dt As DataTable)
        If Not dt.Columns.Contains("FKeyPay") Then
            dt.Columns.Add("FKeyPay", GetType(String))
        End If

        If Not dt.Columns.Contains("DateCreated") Then
            dt.Columns.Add("DateCreated", GetType(String))
        End If

        If Not dt.Columns.Contains("RefNo") Then
            dt.Columns.Add("RefNo", GetType(String))
        End If

        For Each dr As DataRow In dt.Rows
            dr("FKeyPay") = IfNull(GetPayID(IfNull(dr("FKeyVslCode"), ""), IfNull(cboRefNum.EditValue, "")), "")
            dr("DateCreated") = IfNull(GetPayDateCreated(IfNull(dr("FKeyVslCode"), ""), IfNull(cboRefNum.EditValue, "")), "")
            dr("RefNo") = cboRefNum.EditValue

        Next

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

    Private Sub ClearCrewList()
        InitializePayCrew()
        CrewListGrid.DataSource = Nothing
        tblCrewList = Nothing
        DELCrewList = Nothing
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        SPeriod = Nothing
        SFKeyPrincipal = Nothing
        SRefNo = Nothing
        If Not IsNothing(LookUpEd.EditValue) Then
            _SDateFrom = ChangeToSQLDate(cboPeriod.EditValue, 1)
            EnableDisableVslView()
            If GetPayType = 0 Then
                ClearCrewList()
            ElseIf GetPayType = 1 Then
                'tonytest cboRefNum.Properties.DataSource = InitRefNo(LookUpEd.EditValue)
                'tonytest CheckVessel(LookUpEd.EditValue)
                cboRefNum.Properties.DataSource = InitRefNo_AddCrewToPayroll(LookUpEd.EditValue)
            End If

            'If GetPayType = 0 Then
            '    dvVsl.RowFilter = "FKeyPrincipal='" & PrinCode & "'"
            '    VslGrid.DataSource = dvVsl.ToTable
            'ElseIf GetPayType = 1 Then
            '    InitAddTblVsl(PrinCode)
            '    'ExRateGrid.DataSource = tblPayExRateTbl
            'End If
        Else
            'VslGrid.DataSource = Nothing
            VslGrid.DataSource = tblVsl.Clone
            ClearCrewList()
        End If
        cboPrincipal.EditValue = Nothing
        VslGrid.DataSource = Nothing
        ClearSelection()

        InitSelectionMode()

        'FilterVessel()
    End Sub

    Private Sub cboPrincipal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPrincipal.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If Not IsNothing(LookUpEd.EditValue) Then
            If Not LookUpEd.EditValue.Equals("") Then
                EnableDisableVslView()
                If GetPayType = 0 Then
                    VslGrid.DataSource = tblVsl
                    VslView.ActiveFilter.NonColumnFilter = "FKeyPrincipal='" & LookUpEd.EditValue & "'"
                End If
                
            End If
        Else
            If GetPayType = 0 Then
                VslGrid.DataSource = tblVsl
                CrewListGrid.DataSource = Nothing
            End If
            
        End If
        ClearSelection()
        InitSelectionMode()
    End Sub

    Private Sub rdgPayType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rdgPayType.SelectedIndexChanged
        SFKeyPrincipal = String.Empty
        ClearEverything()
        GetPayType = rdgPayType.EditValue
        SetSelectionMode(SelectionMode.Vessel)

        InitSelectionMode()

    End Sub

#End Region

#Region "Frm Allotment"

    'Refresh Data
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        lciApplyFilter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        SetPayrollListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetCalculatePayVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetCalculatePayCaption(Name, "Calculate Pay")
        If Not bLoaded Then
            InitControls()
            bLoaded = True
        End If
        'tonytest VslGrid.Enabled = False
        SetSelectionMode(SelectionMode.Vessel)  'added by tony20180907
        SetRefCurrency()
        BRECORDUPDATEDs = False
    End Sub
    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
    End Sub
    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
    End Sub

    'Save
    'Public Overrides Sub SaveData()
    '    MyBase.SaveData()
    'End Sub

    'ExecuteCustomFunction

    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0)
            Case "RunPayroll"
                RunPayroll()
            Case "CLEARFILTER"
                ClearEverything()
        End Select
    End Sub

#End Region

#Region "Vessel List"

    Dim SelectedVsls As List(Of Integer)
    Dim tsetSVsl As New List(Of Integer)

    Private Sub VslView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles VslView.FocusedRowChanged
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If rdgPayType.SelectedIndex = 1 Then
            If _view.DataRowCount > 0 Then
                FilterExRatePay(IfNull(_view.GetFocusedRowCellValue("FKeyPay"), "")) 'Original
                'FilterExRatePay(IfNull(_view.GetFocusedRowCellValue("RefNo"), ""))
            End If
        End If
    End Sub

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

    'Private Function ValidateVslRefNo(vslViewRowHandle As Integer, _VslView As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
    '    Dim retval As Boolean = True
    '    Dim refNum As String = "", vslCode As String = ""
    '    Dim PayID As String = ""
    '    vslCode = IfNull(_VslView.GetRowCellValue(vslViewRowHandle, "PKey"), "")
    '    refNum = IfNull(txtRef.Text, "")

    '    PayID = DB.DLookUp("PKey", "tblPay", "", "FKeyVsl='" & vslCode & "' AND RefNo ='" & refNum & "' AND MCode='" & cboPeriod.EditValue & "' AND PayType='HA'")
    '    If PayID.Trim.Length > 0 Then
    '        retval = False
    '        MsgBox("Unable to select the Vessel [" & IfNull(_VslView.GetRowCellValue(vslViewRowHandle, "Name"), "") & "]. Payroll with the same details already exist.", MsgBoxStyle.Exclamation, GetAppName)
    '    Else
    '        retval = True
    '    End If
    '    Return retval
    'End Function

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
                PayID = DB.DLookUp("PKey", "tblPay", "", "FKeyVsl='" & vslCode & "' AND RefNo ='" & txtRef.Text & "' AND MCode='" & cboPeriod.EditValue & "' AND PayType='HA'")

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

    Private Sub VslView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles VslView.SelectionChanged

        'commented out by tony201809077 : Crew List selection are now done after vessels are selected and not during the vessel selection
        'LoadSelection(sender, e)





        'Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'SelectedVsls = _view.GetSelectedRows
        'With _view
        '    If IsNothing(SelectedVsls) Then
        '        LoadCrewList()
        '    Else
        '        If Array.Exists(SelectedVsls, Function(value)
        '                                          Return value.Equals(e.ControllerRow)
        '                                      End Function) Then
        '            If PayCrewView.RowCount > 0 Then
        '                LtblCrewList = BuildIndex(TryCast(PayCrewView.DataSource, DataView).ToTable, "FKeyVslCode")
        '                Dim flag As Boolean = False
        '                For i As Integer = 0 To PayCrewView.RowCount() - 1
        '                    flag = ItemExists(LtblCrewList, _view.GetFocusedRowCellValue("PKey"))
        '                Next
        '                If flag Then
        '                    If e.Action = System.ComponentModel.CollectionChangeAction.Remove Then
        '                        Dim strMsg As String
        '                        If SelectedVsls.Length > 1 Then
        '                            strMsg = "Do you want to remove the crew(s) from this vessel [" & VslView.GetRowCellDisplayText(e.ControllerRow, "Name") & "]?"
        '                        Else
        '                            strMsg = "Do you want to clear the Crew(s) to be processed?"
        '                        End If

        '                        If MsgBox(strMsg, MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
        '                            'GetCrewList()
        '                            LoadCrewList()
        '                            InitializePayCrew()
        '                        Else
        '                            _view.SelectRow(e.ControllerRow)
        '                        End If
        '                    End If
        '                Else
        '                    LoadCrewList()
        '                End If
        '            Else
        '                If Not IsNothing(SelectedVsls) Then
        '                    LoadCrewList()
        '                End If
        '            End If
        '        Else
        '            If Not IsNothing(SelectedVsls) Then
        '                LoadCrewList()
        '            End If
        '        End If
        '    End If
        '    SelectedVsls = .GetSelectedRows
        'End With
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

#Region "Crew List"

    Private downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo

    Private Sub ValidateRows(ColumnName As String, _view As DevExpress.XtraGrid.Views.Grid.GridView, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        With _view
            If .GetRowCellValue(e.RowHandle, ColumnName).Equals(System.DBNull.Value) Then
                e.Appearance.BackColor = Color.LightPink
                '.SetRowCellValue(e.RowHandle, "HasError", True)
            ElseIf Not IfNull(.GetRowCellValue(e.RowHandle, ColumnName).ToString().Trim(), "").Equals("") Then
                e.Appearance.BackColor = Color.LightPink
                '.SetRowCellValue(e.RowHandle, "HasError", True)
            End If
        End With
    End Sub

    Private Sub CrewListView_DoubleClick(sender As Object, e As System.EventArgs) Handles CrewListView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
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

    Private Sub CrewListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewListView.RowCellStyle
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            ValidateRows("ToolTip", _view, e)
        End With
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
                'view.GridControl.DoDragDrop(view, DragDropEffects.All)
                view.GridControl.DoDragDrop(view.Name, DragDropEffects.All)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
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
        'Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        'Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(grid.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim table As DataTable = CType(grid.DataSource, DataTable)
        'Dim dT As DataTable = TryCast(e.Data.GetData(GetType(DataTable)), DataTable)

        'If Not _view.Name.Equals(downHitInfo.View.Name) Then
        '    For Each dr As DataRow In dT.Rows
        '            Dim nRow As DataRow

        '            nRow = table.NewRow()
        '            For Each dc As DevExpress.XtraGrid.Columns.GridColumn In CrewListView.Columns
        '                nRow(dc.FieldName) = dr(dc.FieldName)
        '            Next
        '            table.Rows.Add(nRow)
        '            For Each dRow As DataRow In tblCrewList.Rows
        '                If dRow.Equals(dr) Then
        '                    dRow.Delete()
        '                End If
        '            Next
        '    Next
        '    PayCrewView.DeleteSelectedRows()
        '    With _view
        '        .BeginSort()
        '        Try
        '            .ClearSorting()
        '            .Columns("Vessel").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        '            .Columns("Crew").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        '            .Columns("RankName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        '        Finally
        '            .EndSort()
        '        End Try
        '    End With
        'End If

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

#Region "PayCrew"

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

        '    ''Sort Grid
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
        Dim view As GridView = CType(sender, GridView)
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

    Private Sub PayCrewView_RowCountChanged(sender As Object, e As System.EventArgs) Handles PayCrewView.RowCountChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.DataRowCount > 0 Then
            BRECORDUPDATEDs = True
            AllowCalculatePay(Name, True)
        Else
            AllowCalculatePay(Name, False)
        End If
    End Sub

#End Region

#Region "Run Payroll"

    Private _PayType As Integer
    Public Property GetPayType() As Integer
        Get
            _PayType = rdgPayType.SelectedIndex
            Return _PayType
        End Get
        Set(ByVal value As Integer)
            If value = 0 Then 'New
                RequiredControls = {cboPeriod, txtRef, txtDateCreated, cboPrincipal}
                lciNewRefNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciAddRefNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ExRateView.OptionsBehavior.ReadOnly = False
                txtDateCreated.ReadOnly = False
                txtDateCreated.Visible = True
                cboPrincipal.ReadOnly = False
            ElseIf value = 1 Then 'Add Crew
                RequiredControls = {cboPeriod, cboRefNum, txtDateCreated, cboPrincipal}
                lciNewRefNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciAddRefNum.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ExRateView.OptionsBehavior.ReadOnly = True
                txtDateCreated.ReadOnly = True
                txtDateCreated.Visible = False
                cboPrincipal.ReadOnly = True
            End If
            rdgPayType.SelectedIndex = value
            _PayType = value
            AddEditListener(LayoutControlGroup8)
            ControlValidations()
        End Set
    End Property

    Private Sub RunPayroll()
        'Throw New NotImplementedException
        GroupControl1.Focus()
        Dim isRunPayroll As Boolean = False
        If MsgBox("Do you want to continue to calculate payroll?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MessageBoxIcon.Question, GetAppName) = MsgBoxResult.Yes Then
            If ValidateHA() Then
                ExRateGrid.DataSource = GetPayExRate() 'Validate ExRate
                isRunPayroll = ProcessHomeAllotment()
                If isRunPayroll Then

                    Dim auditlogid As Long
                    clsAudit.saveAuditLog("Process Home Allotment", USER_NAME, auditlogid, System.Environment.MachineName, 0,
                                   , , , , "Period : " & NumCodeToDate(cboPeriod.EditValue, 1).ToString("yyyy-MM-dd") & " / Ref No. : " & txtrefno, "MPS Crewing", Date.Now) 'neil

                    BRECORDUPDATEDs = False
                    MsgBox(GetMessage("Saved", isRunPayroll), MsgBoxStyle.Information, GetAppName())
                    ClearEverything()
                    bLoaded = False
                    RefreshData()
                Else
                    MsgBox(GetMessage("Saved", isRunPayroll), MsgBoxStyle.Information, GetAppName())
                End If
            End If
        End If

    End Sub

    Private Function ValidateHA() As Boolean
        Dim RetVal As Boolean = True
        If ValidateFields(RequiredControls) Then
            If ValidateExRate() Then
                If ValidatePayrollDetails() Then
                    If ValidatePayCrewVesselReferenceNumber() Then
                        RetVal = True
                    Else
                        RetVal = False
                    End If
                Else
                    RetVal = False
                End If
            Else
                RetVal = False
            End If
        Else
            RetVal = False
        End If
        Return RetVal
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
        'If Not retVal Then
        '    MsgBox("Invalid Exchange Rate", MsgBoxStyle.Critical, GetAppName)
        'End If
        Return retVal
    End Function

    Private Function ProcessHomeAllotment() As Boolean
        ShowCustomLoadScreen(GetType(PayrollWaitForm))

        Dim retVal As Boolean = False
        Dim toBeInserted As Boolean = False
        Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(DB.GetConnectionString())
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Dim PayType As Integer
        Dim txtRefNum As String = ""
        'Dim RefNo As String = String.Empty
        If GetPayType = 0 Then
            PayType = 0
            txtRefNum = txtRef.Text
        ElseIf GetPayType = 1 Then
            PayType = 1
            'tonytest txtRefNum = cboRefNum.EditValue
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(cboRefNum, DevExpress.XtraEditors.LookUpEdit)
            txtRefNum = editor.GetColumnValue("RefNo")
        End If

        txtrefno = txtRefNum 'neil

        Dim ExRateDT As DataTable = TryCast(ExRateView.DataSource, DataView).ToTable(True, New String() {"FKeyCurr", "ExRate"})
        Dim tblPayCrewDT As DataTable = TryCast(PayCrewView.DataSource, DataView).ToTable(True, New String() {"ActID", "IDNbr", "FKeyVslCode", "FkeyWScaleCode", "FKeyWScaleRankCode"})

        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandText = "SP_Pay_Process_HA"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@ProcessType", PayType)
                    .AddWithValue("@PeriodDateStart", NumCodeToDate(cboPeriod.EditValue, 1).ToString("yyyy-MM-dd"))
                    .AddWithValue("@DateCreated", CDate(txtDateCreated.EditValue))
                    .AddWithValue("@RefNo", txtRefNum)
                    .AddWithValue("@FKeyPrincipal", cboPrincipal.EditValue)
                    .AddWithValue("@tblExRate", ExRateDT)
                    .AddWithValue("@tblPayCrew", tblPayCrewDT)
                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                End With
                toBeInserted = (cmd.ExecuteNonQuery > 0)
            End Using


            'Commit Transaction
            If toBeInserted Then
                sqlTran.Commit()
                retVal = True
            End If
        Catch ex As Exception
            sqlTran.Rollback()
            MsgBox(ex.Message)
            retVal = False
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try

        CloseCustomLoadScreen()
        Return retVal
    End Function

#End Region

#Region "Validations"

    Private Sub CheckForPayscale()

    End Sub

#End Region

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
                    'toolTipArg.Title.Text = String.Empty
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

    Private Sub cboRefNum_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboRefNum.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        EnableDisableVslView()
        If Not IsNothing(LookUpEd.EditValue) Then
            'tonytest
            ' ''FilterVessel()
            ''tblPayExRateTbl = GetPayExRateTbl(LookUpEd.EditValue)
            ' ''ExRateGrid.DataSource = tblPayExRateTbl
            ''Dim dRow As DataRow = tblPayExRateTbl.Select("RefNo = '" & LookUpEd.EditValue & "'").FirstOrDefault
            ''If Not dRow Is Nothing Then
            ''    cboPrincipal.EditValue = dRow.Item("FKeyPrincipal")
            ''End If

            ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Building Data")
            ClearSelection()

            RefnoSelected(LookUpEd.EditValue)
            CloseCustomLoadScreen()

        Else
            LookUpEd.Properties.DataSource = Nothing
            VslGrid.DataSource = tblVsl.Clone
        End If

        SetSelectionMode(SelectionMode.AddCrewToPayroll)

    End Sub

    Private Sub CheckVessel(Period As Integer)
        VslView.ClearSelection()
        Dim strFilter As String = ""
        For Each dr As DataRow In DB.CreateTable("SELECT * FROM dbo.tblPay WHERE PayType='HA' AND MCode= " & Period).Rows
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

    Private Sub ExRateView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ExRateView.InitNewRow
        BRECORDUPDATEDs = True
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateHA() Then
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

    Private Sub cmdExRate_Click(sender As System.Object, e As System.EventArgs) Handles cmdExRate.Click
        If PayCrewView.DataRowCount > 0 Then
            'If ExRateView.DataRowCount > 0 Then
            '    If MsgBox("Do you want to overwrite the existing Exchange Rates?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Yes Then
            '        ExRateGrid.DataSource = GetPayExRate()
            '    End If
            'Else
            ExRateGrid.DataSource = GetPayExRate()
            'End If
        Else
            ExRateGrid.DataSource = InitExRateDT()
        End If
    End Sub

    Private Function GetPayExRate() As DataTable
        Dim ctbl As New DataTable, ctblOut As New DataTable
        With ctblOut
            .Columns.Add("FKeyCurr", GetType(String))
            .Columns.Add("ExRate", GetType(Double))
        End With
        Dim tblPayCrew As DataTable '= TryCast(PayCrewView.DataSource, DataView).ToTable
        'If PayCrewView.DataRowCount > 0 Then
        tblPayCrew = TryCast(PayCrewView.DataSource, DataView).ToTable(True, New String() {"ActID", "IDNbr", "FKeyVslCode", "FkeyWScaleCode", "FKeyWScaleRankCode"})
        'Else
        '    tblPayCrew = TryCast(PayCrewView.DataSource, DataView).ToTable.Clone
        'End If
        Dim sqlcon As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlcon.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlcon
                cmd.CommandText = "SELECT * FROM dbo.FN_GetHA_ExRate(@DateStart,@tblPayCrew)"
                With cmd.Parameters
                    .AddWithValue("@DateStart", NumCodeToDate(cboPeriod.EditValue, 1).ToString("yyyy-MM-dd"))
                End With
                Dim sqlParam As SqlClient.SqlParameter = cmd.Parameters.AddWithValue("@tblPayCrew", tblPayCrew)
                With sqlParam
                    .SqlDbType = SqlDbType.Structured
                    .TypeName = "Type_tblPayCrew_HA"
                End With
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(ctbl)
                End Using

                Dim ExRateDV As DataView = ExRateView.DataSource
                'If Not IsNothing(ExRateDV) Then
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
                    'End If
                Else
                    ExRateGrid.DataSource = Nothing
                    ctblOut = ctbl
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
        End Try
        Return ctblOut
    End Function

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

    Private Sub cboPrincipal_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboPrincipal.EditValueChanging
        If BRECORDUPDATEDs Then
            If Not IsNothing(PayCrewView.DataSource) Then
                If TryCast(PayCrewView.DataSource, DataView).Count > 0 Then
                    VslView.ClearSelection()
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
                    SFKeyPrincipal = cboPrincipal.EditValue
                    SPeriod = cboPeriod.EditValue
                    SRefNo = IIf(GetPayType.Equals(1), cboRefNum.EditValue, txtRef.Text)
                    EnableDisableVslView()
                    GenerateCrewList(CDate(ChangeToSQLDate(SPeriod, 1).Replace("'", "")), SFKeyPrincipal)
                    FilterVessel(SFKeyPrincipal)

                    If GetPayType.Equals(1) Then
                        tblPayExRateTbl = GetPayExRateTbl(cboRefNum.EditValue)
                        ExRateGrid.DataSource = tblPayExRateTbl
                        VslView.ActiveFilter.NonColumnFilter = "RefNo ='" & cboRefNum.EditValue & "'"
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
    End Sub

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

    Private Sub selectVslViewValues(_tsetSVsl As List(Of Integer))
        For index = 0 To _tsetSVsl.Count - 1
            VslView.SelectRow(_tsetSVsl(index))
        Next
        tsetSVsl = New List(Of Integer)
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

    Private Sub cboPeriod_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboPeriod.EditValueChanging
        If BRECORDUPDATEDs Then
            If Not IsNothing(PayCrewView.DataSource) Then
                If TryCast(PayCrewView.DataSource, DataView).Count > 0 Then
                    VslView.ClearSelection()
                    If msgClearSelection.Equals(MsgBoxResult.Yes) Then
                        InitializePayCrew()
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

#Region "Payroll Lock"

    Dim PayrollLockType As String = "HA"
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
                        strVslName = strVslName & vslName & " is currently selected by user [" & dr("USERNAME") & "] for payroll process." & vbCrLf
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
                    strVslUser = vslListDictionary(vslList(index)) & " is currently selected by user [" & UserListDictionary(vslList(index)) & "] for payroll process. " & vbCrLf & strVslUser
                Next
                MsgBox("Unable to select the vessel(s): " & vbCrLf & strVslUser, MsgBoxStyle.Exclamation, GetAppName())
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

    Private Function isValidNoPeriod(MCode As Integer, strRefNo As String) As Boolean
        Dim retVal As Boolean = False
        Dim sqlconn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlconn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlconn
                cmd.CommandText = "SELECT COUNT(*) FROM dbo.tblPay WHERE PayType='HA' AND MCode=@MCode AND RefNo=@RefNo"
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
        ShowCustomLoadScreen(GetType(MPS4.Waitform))
        If IIf(GetPayType.Equals(0), isValidNoPeriod(cboPeriod.EditValue, IIf(GetPayType.Equals(1), cboRefNum.Text, txtRef.Text)), True) Then
            DeleteTempPayLock()
            SelectRefreshAction(VslView)
            If ValidateFields(RequiredControls) Then
                SPeriod = cboPeriod.EditValue
                SRefNo = IIf(GetPayType.Equals(1), cboRefNum.EditValue, txtRef.Text)

                GenerateCrewListByVessel(CDate(ChangeToSQLDate(SPeriod, 1).Replace("'", "")), GetVslList())
                LoadCrewList()


                If GetPayType.Equals(1) Then
                    tblPayExRateTbl = GetPayExRateTbl(cboRefNum.EditValue)
                    ExRateGrid.DataSource = tblPayExRateTbl
                    VslView.ActiveFilter.NonColumnFilter = "RefNo ='" & cboRefNum.EditValue & "'"
                End If

                Application.DoEvents()
                PayrollFunctions.TransferAll(CrewListGrid, _
                                 PayCrewGrid, _
                                 CrewListGrid.DataSource, _
                                 tblCrewList, True, False)
            End If

            SetSelectionMode(SelectionMode.Crew)
            lcgCrewSelection.Enabled = True

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
        If rdgPayType.SelectedIndex = 1 Then
            SetSelectionMode(SelectionMode.AddCrewToPayroll)
        Else
            SetSelectionMode(SelectionMode.Vessel)
        End If
    End Sub

    Private Enum SelectionMode
        Crew = 1
        Vessel = 2
        AddCrewToPayroll = 3
    End Enum

    Private Sub SetSelectionMode(SelectionMode As SelectionMode)
        Dim isEnable As Boolean
        'CREW SELECTION
        isEnable = (SelectionMode = PayrollProcessHA.SelectionMode.Crew) Or (SelectionMode = PayrollProcessHA.SelectionMode.AddCrewToPayroll)
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
        lcgVslSelection.Enabled = (SelectionMode = PayrollProcessHA.SelectionMode.Vessel)
        VslGrid.Enabled = (SelectionMode = PayrollProcessHA.SelectionMode.Vessel)

        'EX RATE
        cmdExRate.Enabled = (SelectionMode = PayrollProcessHA.SelectionMode.Crew)
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
                cmd.CommandText = "SP_PAY_HA_CrewList_ByVessel"
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
            VslView.ClearSelection()
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
        cTable = DB.CreateTable("SELECT concat(Refno, ' - ', VslName) as PayDesc, PKey as PayID, * FROM dbo.tblPay WHERE MCode = " & Period & " AND PayType='HA' AND isLocked = 0")
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
            LogErrors("Pay HA GetVslListFromSelectedRefNo(): Failed to loop through each selected vessels. [" & ex.Message & "]")
        End Try

        Return ReturnValue
    End Function

    Private Sub RefnoSelected(PayID As String)


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

    Private Sub InitSelectionMode()
        If GetPayType = 1 Then
            SetSelectionMode(SelectionMode.AddCrewToPayroll)
        Else
            SetSelectionMode(SelectionMode.Vessel)
        End If
    End Sub
#End Region


    Private Sub txtDateCreated_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtDateCreated.EditValueChanged

    End Sub
End Class
