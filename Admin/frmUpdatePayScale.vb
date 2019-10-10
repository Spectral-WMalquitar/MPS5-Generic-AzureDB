Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmUpdatePayScale

    Dim _PayScaleCode As String = String.Empty
    Dim tblPayScale As New DataTable
    Dim tblPayScaleRank As New DataTable
    Dim tblVsl As New DataTable
    Dim tblCrewList As New DataTable
    Dim tblCrewList2 As New DataTable
    Dim clsAudit As New clsAudit 'added by calvhin 20170109
    Dim strUpdatedBy As String = ""
    Dim LastUpdatedBy As String = String.Empty



    Public Sub New(PayScaleCode As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        beiUpdateType.EditValue = 0
        beiStartDate.Enabled = False 'added by calvhin 20170109
        _PayScaleCode = PayScaleCode
        cmdApply.Enabled = False
        InitControls()
    End Sub

    Private Sub InitControls()

        beiOnBoard.EditValue = True
        beiAshore.EditValue = False

        Dim vslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", ).Length > 0, " WHERE " & GetUserFilterString(, , "FKeyPrincipal", ), "")
        tblVsl = MPSDB.CreateTable("SELECT PKey,Name,FKeyPrincipal FROM dbo.VslList " & vslFilter & " ORDER BY Name,SortCode")
        repVsl.DataSource = tblVsl

        Dim prinFilter As String = IIf(GetUserFilterString(, , "PKey").Length > 0, " WHERE " & GetUserFilterString(, , "PKey"), "")
        repPrincipal.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.PrincipalList " & prinFilter & " ORDER BY Name")

        Dim AgentFilter As String = IIf(GetUserFilterString(, "PKey", ).Length > 0, " WHERE " & GetUserFilterString(, "PKey", ), "")
        repAgent.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.AgentList " & AgentFilter & " ORDER BY Name")

        tblPayScale = MPSDB.CreateTable("SELECT PKey,Name,Abbrv FROM dbo.tblAdmWscale WHERE Active <> 0 ORDER BY Name")
        tblPayScaleRank = MPSDB.CreateTable("SELECT wsr.PKey,wsr.FKeyRank,r.Name,r.SortCode,wsr.FKeyWScale,wsr.YrsServ,CONCAT(ws.Abbrv,' - ',r.Name,' - ',wsr.YrsServ) AS RankNameSen FROM dbo.tblAdmWscaleRank wsr INNER join dbo.tblAdmRank r ON wsr.FKeyRank = r.PKey INNER JOIN dbo.tblAdmWscale ws ON wsr.FKeyWScale= ws.PKey ORDER BY r.name ASC,r.SortCode ASC")

        cboFromPayScale.Properties.DataSource = tblPayScale
        cboFromPayScale.EditValue = _PayScaleCode

        'cboToPayScale.Properties.DataSource = tblPayScale
        cboToPayScale.Properties.DataSource = GetNewWageScaleDataSource()

        If IfNull(cboToPayScale.EditValue, "").Trim.Length > 0 Then
            'UpdateCrewListView.OptionsBehavior.Editable = True
            UpdateCrewListGrid.Enabled = True
        Else
            UpdateCrewListGrid.Enabled = False
            'UpdateCrewListView.OptionsBehavior.Editable = False
        End If

    End Sub

    Function GetNewWageScaleDataSource() As Object
        Dim filteredPayScale As New DataView(tblPayScale)
        If IfNull(cboFromPayScale.EditValue, "").Equals("").ToString.Length > 0 Then
            filteredPayScale.RowFilter = "PKey <> '" & cboFromPayScale.EditValue & "'"
            Return filteredPayScale
        Else
            Return tblPayScale
        End If
    End Function

    Sub RefreshNewWageScaleDataSource()
        cboToPayScale.Properties.DataSource = GetNewWageScaleDataSource()
        If Not IfNull(cboFromPayScale.EditValue, "").Equals("") And Not IfNull(cboToPayScale.EditValue, "").Equals("") Then
            If cboToPayScale.EditValue = cboFromPayScale.EditValue Then
                cboToPayScale.EditValue = ""
            End If
        End If
    End Sub

    Private Function LoadCrewListWageScale(PayScaleCode As String) As DataTable
        Dim strFilter As String = IIf(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", ).Length > 0, " AND " & GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", ), "")
        Return MPSDB.CreateTable("SELECT * FROM dbo.[view_Adm_UpdateWScale_CrewList] WHERE FkeyWScaleCode = '" & cboFromPayScale.EditValue & "'  " & strFilter & " ORDER BY VslName, Crew")
    End Function

    Private Sub cboFromPayScale_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboFromPayScale.EditValueChanged
        Dim lookUp As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        RefreshNewWageScaleDataSource()
        tblCrewList = LoadCrewListWageScale(lookUp.EditValue)
        tblCrewList2 = LoadCrewListWageScale(lookUp.EditValue)
        CrewListGrid.DataSource = tblCrewList
        UpdateCrewListGrid.DataSource = tblCrewList.Clone
    End Sub

    Private Sub repPrincipal_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repPrincipal.ButtonPressed
        Dim repLook As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            repLook.EditValue = Nothing
        End If
    End Sub

    Private Sub repPrincipal_EditValueChanged(sender As Object, e As System.EventArgs) Handles repPrincipal.EditValueChanged
        Dim repLook As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        FilterVsl(IfNull(repLook.EditValue, String.Empty))
        GenerateCrewListFilterString(IfNull(repLook.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(beiVessel.EditValue, ""))
    End Sub

    Private Sub FilterVsl(PrinCode As String)
        Dim dv As New DataView(tblVsl)
        If PrinCode.Trim.Length > 0 Then
            dv.RowFilter = "FKeyPrincipal ='" & PrinCode & "'"
        Else
            dv.RowFilter = String.Empty
        End If
        repVsl.DataSource = dv
    End Sub

    Private Sub GenerateCrewListFilterString(Optional PrinCode As String = "", Optional AgentCode As String = "",
                                             Optional VslCode As String = "",
                                             Optional OnboardValue As Boolean = True,
                                             Optional AshoreValue As Boolean = False)
        Dim retVal As String = String.Empty
        Dim _PrinCode As String = ""
        Dim _AgentCode As String = ""
        Dim _VslCode As String = ""
        Dim _Onboard As String = String.Empty
        Dim _Ashore As String = String.Empty
        Dim _Status As String = String.Empty

        'PrinCode
        If IfNull(PrinCode, String.Empty).Trim.Length > 0 Then
            _PrinCode = " FKeyPrinCode = '" & PrinCode & "' "
        Else
            _PrinCode = String.Empty
        End If
        'Agent Code
        If IfNull(AgentCode, String.Empty).Trim.Length > 0 Then
            _AgentCode = " FKeyAgentCode = '" & AgentCode & "' "
        Else
            _AgentCode = String.Empty
        End If
        'Vsl Code
        If IfNull(VslCode, String.Empty).Trim.Length > 0 Then
            _VslCode = " FKeyVslCode = '" & VslCode & "' "
        Else
            _VslCode = String.Empty
        End If

        If IfNull(OnboardValue, False) Then
            _Onboard = "StatType = 1"
        Else
            _Onboard = String.Empty
        End If

        If IfNull(AshoreValue, False) Then
            _Ashore = "StatType <> 1"
        Else
            _Ashore = String.Empty
        End If

        If IfNull(_Onboard, String.Empty).Trim.Length > 0 Then
            _Status = IIf(Trim(_Onboard).Length > 0, _Onboard, String.Empty) & _
                      IIf(Trim(_Ashore).Length > 0, " OR " & _Ashore, String.Empty)

        Else
            If IfNull(_Ashore, String.Empty).Trim.Length > 0 Then
                _Status = IIf(Trim(_Ashore).Length > 0, _Ashore, String.Empty)
            Else
                _Status = String.Empty
            End If
        End If

        If Trim(_PrinCode).Length > 0 Then
            retVal = IIf(Trim(_PrinCode).Length > 0, _PrinCode, String.Empty) & _
                   IIf(Trim(_AgentCode).Length > 0, " AND " & _AgentCode, String.Empty) & _
                   IIf(Trim(_Status).Length > 0, " AND " & _Status, String.Empty) & _
                   IIf(Trim(_VslCode).Length > 0, " AND " & _VslCode, String.Empty)
        Else
            If Trim(_AgentCode).Length > 0 Then
                retVal = IIf(Trim(_AgentCode).Length > 0, _AgentCode, String.Empty) & _
                        IIf(Trim(_Status).Length > 0, " AND " & _Status, String.Empty) & _
                        IIf(Trim(_VslCode).Length > 0, " AND " & _VslCode, String.Empty)
            Else
                If Trim(_Status).Length > 0 Then
                    retVal = IIf(Trim(_Status).Length > 0, _Status, String.Empty) & _
                         IIf(Trim(_VslCode).Length > 0, " AND " & _VslCode, String.Empty)
                Else
                    If Trim(_VslCode).Length > 0 Then
                        retVal = IIf(Trim(_VslCode).Length > 0, _VslCode, String.Empty)
                    Else
                        retVal = String.Empty
                    End If
                End If

            End If
        End If

        CrewListView.ActiveFilter.NonColumnFilter = retVal
    End Sub

    Private Sub repVsl_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repVsl.ButtonPressed
        Dim repLook As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            repLook.EditValue = Nothing
        End If
    End Sub

    Private Sub repVsl_EditValueChanged(sender As Object, e As System.EventArgs) Handles repVsl.EditValueChanged
        Dim repLook As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(repLook.EditValue, ""), IfNull(beiOnBoard.EditValue, True), IfNull(beiAshore.EditValue, False))
    End Sub

    Private Sub repAgent_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repAgent.ButtonPressed
        Dim repLook As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            repLook.EditValue = Nothing
        End If
    End Sub

    Private Sub repAgent_EditValueChanged(sender As Object, e As System.EventArgs) Handles repAgent.EditValueChanged
        Dim repLook As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(repLook.EditValue, ""), IfNull(beiVessel.EditValue, ""), IfNull(beiOnBoard.EditValue, True), IfNull(beiAshore.EditValue, False))
    End Sub

    Private Sub cmdClearFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClearFilter.ItemClick
        beiAgent.EditValue = Nothing
        beiPrincipal.EditValue = Nothing
        beiVessel.EditValue = Nothing
    End Sub

    Private Sub cmdCrewSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdCrewSelectAll.Click
        If UpdateCrewListGrid.Enabled Then
            CrewListView.SelectAll()
            SelectDragDrop(CrewListGrid, UpdateCrewListGrid)
        End If

    End Sub

    Private Sub cmdUpdateCrewSelect_Click(sender As System.Object, e As System.EventArgs) Handles cmdUpdateCrewSelect.Click
        If UpdateCrewListGrid.Enabled Then
            UpdateCrewListView.SelectAll()
            SelectDragDrop(UpdateCrewListGrid, CrewListGrid)
        End If
    End Sub

    Private Sub beiAgent_EditValueChanged(sender As Object, e As System.EventArgs) Handles beiAgent.EditValueChanged
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(beiVessel.EditValue, ""), IfNull(beiOnBoard.EditValue, True), IfNull(beiAshore.EditValue, False))
    End Sub

    Private Sub beiPrincipal_EditValueChanged(sender As Object, e As System.EventArgs) Handles beiPrincipal.EditValueChanged
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(beiVessel.EditValue, ""), IfNull(beiOnBoard.EditValue, True), IfNull(beiAshore.EditValue, False))
    End Sub

    Private Sub beiVessel_EditValueChanged(sender As Object, e As System.EventArgs) Handles beiVessel.EditValueChanged
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(beiVessel.EditValue, ""), IfNull(beiOnBoard.EditValue, True), IfNull(beiAshore.EditValue, False))
    End Sub

    Private Sub beiOnBoard_EditValueChanged(sender As Object, e As System.EventArgs) Handles beiOnBoard.EditValueChanged
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(beiVessel.EditValue, ""), IfNull(beiOnBoard.EditValue, True), IfNull(beiAshore.EditValue, False))
    End Sub

    Private Sub beiAshore_EditValueChanged(sender As Object, e As System.EventArgs) Handles beiAshore.EditValueChanged
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(beiVessel.EditValue, ""), IfNull(beiOnBoard.EditValue, True), IfNull(beiAshore.EditValue, False))
    End Sub

    Private Sub repAsh_EditValueChanged(sender As Object, e As System.EventArgs) Handles repAsh.EditValueChanged
        Dim repChk As DevExpress.XtraEditors.CheckEdit = TryCast(sender, DevExpress.XtraEditors.CheckEdit)
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(beiVessel.EditValue, ""), IfNull(beiOnBoard.EditValue, True), IfNull(repChk.EditValue, False))
    End Sub

    Private Sub repONB_EditValueChanged(sender As Object, e As System.EventArgs) Handles repONB.EditValueChanged
        Dim repChk As DevExpress.XtraEditors.CheckEdit = TryCast(sender, DevExpress.XtraEditors.CheckEdit)
        GenerateCrewListFilterString(IfNull(beiPrincipal.EditValue, ""), IfNull(beiAgent.EditValue, ""), IfNull(beiVessel.EditValue, ""), IfNull(repChk.EditValue, True), IfNull(beiAshore.EditValue, False))
    End Sub

#Region "Views"
    Private downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
#Region "Crew List View"

    Private Sub CrewListView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListView.MouseDown
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

    Private Sub CrewListView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListView.MouseMove
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

    Private Sub CrewListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewListView.RowCellStyle
        ViewRowCellStyle(sender, e)
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
        SelectDragDrop(UpdateCrewListGrid, TryCast(sender, DevExpress.XtraGrid.GridControl))
    End Sub

    Private Sub SelectDragDrop(GridFrom As DevExpress.XtraGrid.GridControl, GridTo As DevExpress.XtraGrid.GridControl)
        Dim dT As DataTable = GetDragData(GridFrom.MainView)

        If Not GridFrom.MainView.Name.Equals(GridTo.MainView.Name) Then
            For Each dr As DataRow In dT.Rows
                Dim nRow As DataRow

                'nRow = table.NewRow()
                nRow = GridTo.DataSource.NewRow()
                For Each dc As DevExpress.XtraGrid.Columns.GridColumn In CrewListView.Columns
                    If dc.FieldName = "FKeyWScaleRankCode" Then
                        nRow(dc.FieldName) = GetWageScaleRankCode(GridTo.MainView.Name, IfNull(dr("FKeyWScaleRankCode"), ""), dr("Pkey"))
                    Else
                        nRow(dc.FieldName) = dr(dc.FieldName)
                    End If
                Next
                GridTo.DataSource.Rows.Add(nRow)
                For Each dRow As DataRow In TryCast(GridFrom.DataSource, DataTable).Rows
                    If dRow.Equals(dr) Then
                        dRow.Delete()
                    End If
                Next
                TryCast(GridFrom.MainView, DevExpress.XtraGrid.Views.Grid.GridView).DeleteRow(TryCast(GridFrom.MainView, DevExpress.XtraGrid.Views.Grid.GridView).LocateByValue("Pkey", dr("Pkey")))
            Next

            With TryCast(GridTo.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
                .BeginSort()
                Try
                    .ClearSorting()
                    .Columns("VslName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    .Columns("Crew").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    .Columns("RankName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                Finally
                    .EndSort()
                End Try
            End With
        End If
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


#End Region

#Region "Update Crew List"

    Private Sub UpdateCrewListView_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles UpdateCrewListView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub UpdateCrewListView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UpdateCrewListView.MouseDown
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

    Private Sub UpdateCrewListView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UpdateCrewListView.MouseMove
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

    Private Sub UpdateCrewListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles UpdateCrewListView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub UpdateCrewListView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles UpdateCrewListView.ValidateRow
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'If _view.FocusedColumn().FieldName.Equals("FKeyWScaleRankCode") Then
        If IfNull(_view.GetRowCellValue(e.RowHandle, "FKeyWScaleRankCode"), "").Trim.Length < 0 Then
            e.Valid = False
            _view.SetColumnError(_view.Columns("FKeyWScaleRankCode"), "Invali Wage Scale Rank Code", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
        Else
            e.Valid = True
            _view.SetColumnError(_view.Columns("FKeyWScaleRankCode"), "")
        End If
        'End If
    End Sub

    Private Sub ClearGridViewColumn(GridView As DevExpress.XtraGrid.Views.Grid.GridView, ColumnName As String)
        For index = 0 To GridView.RowCount
            GridView.SetRowCellValue(index, GridView.Columns(ColumnName), System.DBNull.Value)
        Next
    End Sub

    Private Sub UpdateCrewListView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles UpdateCrewListView.ValidatingEditor
        Dim _View As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _View.FocusedColumn.FieldName.Equals("FKeyWScaleRankCode") Then
            If IfNull(e.Value, "").Trim.Length > 0 Then
                e.Valid = True
                _View.SetColumnError(_View.FocusedColumn, "")

            Else
                e.Valid = False
                _View.SetColumnError(_View.FocusedColumn, "Invalid Wage Scale Rank", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
            End If
        End If
    End Sub

    Private Sub UpdateCrewListGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles UpdateCrewListGrid.DragDrop
        SelectDragDrop(CrewListGrid, TryCast(sender, DevExpress.XtraGrid.GridControl))
    End Sub

    Private Sub UpdateCrewListGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles UpdateCrewListGrid.DragOver
        Dim control As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(control.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.Data.GetDataPresent(GetType(DataTable)) AndAlso Not view.IsGroupRow(downHitInfo.RowHandle) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

#End Region


#End Region

    Private Function ValidateUpdatePayScale()
        Dim retval As Boolean = True
        If IfNull(cboFromPayScale.EditValue, "").Equals("") Or IfNull(cboToPayScale.EditValue, "").Equals("") Then
            MsgBox("Please select a new pay scale.", MsgBoxStyle.Critical, GetAppName)
            retval = False
            Return retval
        End If
        If Not IfNull(cboFromPayScale.EditValue, "").Equals("") And Not IfNull(cboToPayScale.EditValue, "").Equals("") Then
            If cboFromPayScale.EditValue = cboToPayScale.EditValue Then
                MsgBox("Former and selected new wage scale must not be the same.", MsgBoxStyle.Critical, GetAppName)
                retval = False
                Return retval
            End If
        End If
        If UpdateCrewListView.DataRowCount <= 0 Then
            'retval = False
            MsgBox("Please drag a crew(s) to be updated.", MsgBoxStyle.Critical, GetAppName)
            retval = False
            Return retval
        End If
        Return retval
    End Function

    Private Sub cmdApply_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdApply.ItemClick
        Dim info As Boolean = False

        If ValidateUpdatePayScale() And isValidUpdatedPayScaleRank() Then
            Select Case beiUpdateType.EditValue
                Case 0 'Change Wage Scale Only
                    If MsgBox("You are about to change the Wage Scale of the selected crew(s) from '" & cboFromPayScale.Properties.GetDisplayText(cboFromPayScale.EditValue) & "' to '" & cboToPayScale.Properties.GetDisplayText(cboToPayScale.EditValue) & "'." & vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                    info = ChangeWageScaleOnly()
                Case 1 'Change PayScale With Activity
                    If MsgBox("You are about to change the Wage Scale of the selected crew(s) from '" & cboFromPayScale.Properties.GetDisplayText(cboFromPayScale.EditValue) & "' to '" & cboToPayScale.Properties.GetDisplayText(cboToPayScale.EditValue) & "'. This will also generate a 'Changed Wage Scale' activity for each crew." & vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                    'Added By Calvhin 20170109
                    CrewListView.Focus()
                    If beiStartDate.EditValue = Nothing Then
                        MsgBox("Please input Effectivity Date.", MsgBoxStyle.Information, GetAppName() & " - Change Wage Scale")
                        Exit Sub
                    End If
                    With UpdateCrewListView
                        Dim sqls As New ArrayList
                        Dim strWScaleRank As String = ""
                        For i As Integer = 0 To UpdateCrewListView.DataRowCount - 1
                            If AllowChangeWScale(i)(0) = False Then
                                strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Changed Wage Scale.", 0, System.Environment.MachineName, "DESC_HERE", "Activity", .GetRowCellValue(i, "FKeyIDNbr"))
                                sqls.Add("EXEC [dbo].[SP_CHANGEWSCALE] @CurrActID ='" & .GetRowCellValue(i, "Pkey") & "', @ActGrpID ='" & .GetRowCellValue(i, "FKeyActivityGroupID") & "', @NewFKeyWScale ='" & cboToPayScale.EditValue & "', @FKeyRank ='" & .GetRowCellValue(i, "FKeyRankCode") & "', @StartDate =" & ChangeToSQLDate(beiStartDate.EditValue) & ", @LastUpdatedBy='" & strUpdatedBy & "'")
                                UpdateCrewListView.SelectRow(i)
                            Else
                                MsgBox("Please fix invalid input(s)", MsgBoxStyle.Information, GetAppName() & "Change Wage Scale")
                                Exit Sub
                            End If
                        Next
                        info = MPSDB.RunSqls(sqls)
                    End With
                    'end calvhin
            End Select

            If info Then
                If beiUpdateType.EditValue = 1 Then UpdateCrewListView.DeleteSelectedRows()
                MsgBox("Crew(s) updated.", MsgBoxStyle.Information, GetAppName)
                Me.Close()
            Else
                MsgBox("Unable to update crew(s)." & IIf(MPSDB.ErrorMessage.Length > 0, vbNewLine & vbNewLine & "Error:" & vbNewLine & MPSDB.ErrorMessage.ToString, ""), _
                            MsgBoxStyle.Information, _
                            GetAppName)
            End If
        Else
            MsgBox("This list contains Crew(s) with invalid Wage Scale Rank.", MsgBoxStyle.Exclamation, GetAppName())
        End If
    End Sub

    Private Function ChangeWageScaleOnly() As Boolean
        Dim retVal As Boolean = False
        Dim sqlCon As New SqlClient.SqlConnection(MPSDB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Dim tblUpdateCrewList As New DataTable
        tblUpdateCrewList = TryCast(UpdateCrewListView.DataSource, DataView).ToTable(True, New String() {"FKeyIDNbr", "Pkey", "FKeyActivityGroupID", "FkeyWScaleCode", "FKeyWScaleRankCode", "LOC"})

        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical Certificate", 10, System.Environment.MachineName, txtName.EditValue, FormName)
        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Update using Update Wage Scale Form (Wage Scale Only)", 10, System.Environment.MachineName, "Pay Scale and Pay Scale Rank", "Update Wage Scale")
        Try
            sqlCon.Open()
            sqlTran = sqlCon.BeginTransaction
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlCon
                cmd.Transaction = sqlTran
                cmd.CommandText = "SP_Adm_ChangeWageScaleOnly"
                cmd.CommandType = CommandType.StoredProcedure

                With cmd.Parameters
                    .AddWithValue("@tblCrewList", tblUpdateCrewList)
                    .AddWithValue("@New_FKeyWScaleCode", cboToPayScale.EditValue)
                    .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                End With
                retVal = (cmd.ExecuteNonQuery > 0)
            End Using

            If retVal Then
                sqlTran.Commit()
                retVal = True
            Else
                retVal = False
            End If
        Catch ex As Exception
            retVal = False
            sqlTran.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try


        Return retVal
    End Function

    'added by calvhin 20170109
    Private Sub RepositoryItemRadioGroup1_EditValueChanged(sender As Object, e As System.EventArgs) Handles RepositoryItemRadioGroup1.EditValueChanged
        Dim cntrl As DevExpress.XtraEditors.RadioGroup = TryCast(sender, DevExpress.XtraEditors.RadioGroup)
        If cntrl.EditValue = 1 Then
            beiStartDate.Enabled = True
        Else
            beiStartDate.EditValue = Nothing
            beiStartDate.Enabled = False
        End If
    End Sub

    Private Function AllowChangeWScale(ByVal rHandle As Integer) As ArrayList
        With UpdateCrewListView
            Dim arrRes As New ArrayList
            Dim currAct As Columns.GridColumn = .Columns("CurrActID")
            Dim hasErr As Boolean = False
            Dim strMsg As String = ""
            Dim CurrAct_StartDate As Date

            If beiUpdateType.EditValue = 1 Then
                If .GetRowCellValue(rHandle, "FKeyStatCode") = "SYSSICKONB" Then
                    strMsg = "Cannot promote sick onboard crew. Please end sick onboard status first."
                    hasErr = True
                End If
            End If

            'Dim strWScale As String = MPSDB.DLookUp("PKey", "tblAdmWScaleRank", "", "FKeyWScale = '" & IfNull(cboToPayScale.EditValue, "") & "' AND FKeyRank = '" & .GetRowCellValue(rHandle, "FKeyRankCode") & "'")
            'If strWScale = "" Then
            '    strMsg = "Rank is currently not included in the selected wagescale."
            '    hasErr = True
            'End If

            If Not IsNothing(beiStartDate.EditValue) And beiUpdateType.EditValue = 1 Then
                CurrAct_StartDate = MPSDB.DLookUp("ActDateStart", "tblActivity", "", "Pkey='" & .GetRowCellValue(rHandle, "Pkey") & "'")
                If beiStartDate.EditValue <= CurrAct_StartDate Then
                    strMsg = "Effectivity date must be later than the previous activity."
                    hasErr = True
                End If
            End If


            'Earlsan Code for Invalid WageScale Rank
            If IfNull(.GetRowCellValue(rHandle, "FKeyWScaleRankCode"), "").Trim.Length <= 0 Then
                strMsg = "Invalid Wage Scale Rank."
                hasErr = True
            End If

            arrRes.Add(hasErr)
            arrRes.Add(strMsg)
            Return arrRes
        End With
    End Function

    Private Sub UpdateCrewListView_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles UpdateCrewListView.CustomDrawRowIndicator
        Dim view As Views.Grid.GridView = CType(sender, Views.Grid.GridView)
        Dim currAct As Columns.GridColumn = view.Columns("Pkey")
        Dim hasError As Boolean = False

        If e.Info.IsRowIndicator AndAlso e.RowHandle >= 0 Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)

            Dim rec As Rectangle = e.Bounds
            Dim img As Image = New System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"))
            rec.Inflate(-1, -1)
            Dim x1 As Integer = rec.X + (rec.Width - img.Width) / 2
            Dim y1 As Integer = rec.Y + (rec.Height - img.Height) / 2
            Dim strMsg As String = ""

            'Show "X" image on row indicator if theres an invalid input
            'Go To Definition of "AllowChangeWScale" to see validations
            If AllowChangeWScale(e.RowHandle)(0) = True Then
                e.Graphics.DrawImageUnscaled(img, x1, y1)
                e.Handled = True
            End If


        End If
    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If Not e.SelectedControl Is UpdateCrewListGrid Then Return
        Dim info As ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As GridView = UpdateCrewListGrid.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells
        If hi.HitTest = GridHitTest.RowIndicator Then
            'An object that uniquely identifies a row indicator cell
            Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
            Dim text As String = AllowChangeWScale(hi.RowHandle)(1)
            info = New ToolTipControlInfo(o, text)
        End If
        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub
    'end calvhin

    Private Sub beiUpdateType_EditValueChanged(sender As Object, e As System.EventArgs) Handles beiUpdateType.EditValueChanged
        UpdateCrewListGrid.Focus()
    End Sub

    Private Sub cboToPayScale_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboToPayScale.Validating
        e.Cancel = Not isSelectedWageScalesValid()
    End Sub

    Function isSelectedWageScalesValid() As Boolean
        If cboFromPayScale.EditValue = cboToPayScale.EditValue Then
            MsgBox("Former and selected new wage scale must not be the same.", MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub cboFromPayScale_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboFromPayScale.Validating
        e.Cancel = Not isSelectedWageScalesValid()
    End Sub

    Private Sub UpdateCrewListView_ShownEditor(sender As Object, e As System.EventArgs) Handles UpdateCrewListView.ShownEditor
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            If .FocusedColumn.FieldName.Equals("FKeyWScaleRankCode") And (TypeOf (.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                edit.Properties.DataSource = FilterPayScaleRank(cboToPayScale.EditValue)
            End If
        End With
    End Sub

    Private Function FilterPayScaleRank(FKeyPayScale As String) As DataTable
        Dim dv As New DataView(tblPayScaleRank)
        dv.RowFilter = "FKeyWScale= '" & FKeyPayScale & "'"
        Return dv.ToTable
    End Function

    Private Sub cboToPayScale_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboToPayScale.EditValueChanged
        If IfNull(TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue, "").Trim.Length > 0 Then
            UpdateCrewListGrid.Enabled = True
        Else
            UpdateCrewListGrid.Enabled = False
        End If

        Dim dv As New DataView(tblPayScaleRank)
        dv.RowFilter = "FKeyWScale IN('" & cboToPayScale.EditValue & "','" & cboFromPayScale.EditValue & "')"
        repFKeyWScaleRank.DataSource = dv
        ClearGridViewColumn(UpdateCrewListView, "FKeyWScaleRankCode")
    End Sub

    Private Function GetWageScaleRankCode(GridViewFromName As String, FromWageScaleRank As String, ActID As String) As Object
        'This Validates the dragged item by FKeyRank and YrsServ and will Return Nothing or the corresponding values.

        Dim strWageRank As String = String.Empty
        If GridViewFromName.Equals(UpdateCrewListView.Name) Then
            Dim FromRankCode As String = (From dr As DataRow In tblPayScaleRank.Rows
                                Where dr("PKey") = FromWageScaleRank
                                Select dr("FKeyRank")).FirstOrDefault()
            Dim FromYrServ As Integer = (From dr As DataRow In tblPayScaleRank.Rows
                                            Where dr("PKey") = FromWageScaleRank
                                            Select dr("YrsServ")).FirstOrDefault()
            strWageRank = (From dr As DataRow In tblPayScaleRank.Rows
                            Where (dr("FKeyRank") = FromRankCode _
                            And dr("YrsServ") = FromYrServ _
                            And dr("FKeyWScale") = cboToPayScale.EditValue)
                            Select dr("PKey")).FirstOrDefault()


        Else
            Dim dt As DataTable = tblCrewList2.Copy
            strWageRank = (From dr As DataRow In dt.Rows
                           Where dr("Pkey") = ActID
                           Select dr("FKeyWScaleRankCode")).FirstOrDefault()
        End If
        Return strWageRank
    End Function

    Private Function isValidUpdatedPayScaleRank(FocusedRowHandle As Integer) As Boolean
        Dim retVal As Boolean = True
        With UpdateCrewListView
            If IfNull(.GetRowCellValue(FocusedRowHandle, "FKeyWScaleRankCode"), "").Trim.Length <= 0 Then
                retVal = False
                .SetColumnError(.Columns("FKeyWScaleRankCode"), "Invalid Wage Scale Rank", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
            Else
                .SetColumnError(.Columns("FKeyWScaleRankCode"), "")
            End If
        End With
            Return retVal
    End Function

    Private Function isValidUpdatedPayScaleRank() As Boolean
        Dim retVal As Boolean = True
        With UpdateCrewListView
            For index = 0 To .RowCount - 1
                If IfNull(.GetRowCellValue(index, "FKeyWScaleRankCode"), "").Trim.Length <= 0 Then
                    retVal = False
                    Return False
                    '.SetColumnError(.Columns("FKeyWScaleRankCode"), "Invalid Wage Scale Rank", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
                Else
                    '.SetColumnError(.Columns("FKeyWScaleRankCode"), "")
                    retVal = True
                    'Return True
                End If
            Next
        End With
        Return retVal
    End Function

    Private Sub UpdateCrewListView_RowCountChanged(sender As Object, e As System.EventArgs) Handles UpdateCrewListView.RowCountChanged
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If _V.RowCount > 0 Then
            cmdApply.Enabled = True
        Else
            cmdApply.Enabled = False
        End If
    End Sub
End Class
