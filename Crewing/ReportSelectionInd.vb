Imports Reports
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Drawing

Public Class ReportSelectionInd

    Dim isadmin As Integer
    Dim crewIDNbr As String = ""
    Dim clsSec As New clsSecurity
    Dim sql_reportlist As String
    Dim ReportsTable As New System.Data.DataTable()

    Dim A_REPORT_HAS_BEEN_SELECTED As Boolean = False

#Region "Declarations"
    Dim extAssembly As System.Reflection.Assembly

    Public WithEvents oFilterOption As New Reports.BaseFilterOption
#End Region

    Public Sub New(IDNbr As String)
        InitializeComponent()
        crewIDNbr = IDNbr
        Me.LayoutControlGroup1.Text += " - "
        Me.LayoutControlGroup1.Text += MPSDB.DLookUp("dbo.AssembleName(LName, FName, MName, 1, 1, 0 ,0 ,0) AS CrewName", "tblCrewInfo", "", "PKey='" & crewIDNbr & "'")
    End Sub

    ' PREVIEW
    Private Sub cmdPreview_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdPreview.ItemClick
        PreviewPrintReport()
    End Sub

    ' CANCEL
    Private Sub cmdCancel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancel.ItemClick
        Me.Close()
    End Sub

    Private Sub ReportSelectionInd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        clsSec.propSQLConnStr = MPSDB.GetConnectionString


        ReportsTable = New System.Data.DataTable()
        sql_reportlist = clsSec.get_reports(USER_ID, ReportsTable, "INDIVIDUAL")

        If ReportsTable.Rows.Count > 0 Then
            clsFeature.filterTableByFeature(ReportsTable, COMPANYID, FEATUREKEY) 'neil

            Me.ReportListGrid.DataSource = ReportsTable.Select("ShowInPopUp=1").CopyToDataTable
            Reports.ReportSelection.SortViewByColumn(ReportListView, "Caption")
            ReportListView.SelectRow(0)
        End If


        ReportsTable = New System.Data.DataTable()
        sql_reportlist = clsSec.get_reports(USER_ID, ReportsTable, "INDIVIDUAL GOVERNMENT REPORT")


        If ReportsTable.Rows.Count > 0 Then
            clsFeature.filterTableByFeature(ReportsTable, COMPANYID, FEATUREKEY) 'neil

            Me.ReportListGridGovt.DataSource = ReportsTable.Select("ShowInPopUp=1").CopyToDataTable
            Reports.ReportSelection.SortViewByColumn(ReportListViewGovt, "Caption")
            ReportListViewGovt.SelectRow(0)

        End If

        ShowFilterOptions()

        If CInt(MPSDB.GetConfig("RPT_GOVT")) = 0 Then ' check if feature is available
            tabReportGovt.PageVisible = False
        Else
            clsSec.isUserAdmin(USER_ID, isadmin)
            If isadmin = 0 Then
                If clsSec.hasNoViewPermission(tabReportGovt.Name, USER_ID, False) Then
                    tabReportGovt.PageVisible = False
                Else
                    tabReportGovt.PageVisible = True
                End If
            End If
        End If
    End Sub

    Private Sub ReportListView_RowStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        If e.RowHandle = ReportListView.FocusedRowHandle Then
            e.Appearance.BackColor = System.Drawing.Color.Yellow
        End If
    End Sub

    Private Sub ReportListViewGovt_RowStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        If e.RowHandle = ReportListViewGovt.FocusedRowHandle Then
            e.Appearance.BackColor = System.Drawing.Color.Yellow
        End If
    End Sub

    Private Sub ReportListView_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ReportListGrid.DoubleClick
        'Dim oSender As New GridView
        'Try
        '    oSender = DirectCast(sender, GridView)
        '    If oSender.FocusedRowHandle >= 0 Then
        '        Dim p As Point = oSender.GridControl.PointToClient(Control.MousePosition)
        '        Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
        '        If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
        '            'Load Template
        '            ShowSortOptions()
        '            PreviewPrintReport()
        '        End If
        '    End If
        'Catch ex As Exception
        '    LogErrors("Failed to load selected template '" & oSender.GetRowCellValue(oSender.FocusedRowHandle, "Name") & "'." & Chr(13) & "Error: " & ex.Message)
        '    MsgBox("Failed to load selected template '" & oSender.GetRowCellValue(oSender.FocusedRowHandle, "Name") & "'." & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        ''ShowSortOptions()
        ''PreviewPrintReport()
    End Sub

    Private Sub PreviewPrintReport()
        '### Description: Preview the Report. This procedure also includes the generating of datasource and filter.
        If Not A_REPORT_HAS_BEEN_SELECTED Then
            MsgBox("Please select a report to preview.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If crewIDNbr = "" Then
            MsgBox("There is no selected record(s) to preview. Please try again.", vbInformation)
            Exit Sub
        End If

        tabReports.Focus()

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'CREATES THE DETAILS OF THE REPORT TO BE BUILT
        Dim REPORT_DETAIL As New ReportDetail

        With REPORT_DETAIL
            Dim oReportInfo As New ReportInfo(GetSelectedReportItem("ObjectID"), GetSelectedReportItem("ReportGroup"))
            .ReportInfo = New ReportInfo(GetSelectedReportItem("ObjectID"), GetSelectedReportItem("ReportGroup"))
            .FieldSorting = " Crew "
            .PresentRecord = New PresentRecord()
            .PresentRecord.ConditionString = " IDNbr='" & crewIDNbr & "' "
            .PresentRecord.SelectionList = "('" & crewIDNbr & "')"
            .PresentRecord.Table.Rows.Add(New Object() {crewIDNbr})
            .FilterOption = oFilterOption

            'If tabReports.SelectedTabPageIndex = 0 Then
            oSortOption = New BaseSortOption
            oSortOption.RefreshData(Trim(IfNull(GetSelectedReportItem("SortFields"), "")))
            'End If
            .SortOption = oSortOption
            .DB = MPSDB
        End With

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        BuildReport(REPORT_DETAIL)
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function GetSelectedReportItem(ByVal cField As String) As Object
        '### Description: Gets Selected Report from the Report List Selection
        Try
            Select Case tabReports.SelectedTabPageIndex
                Case 0
                    Return ReportListView.GetDataRow(ReportListView.FocusedRowHandle).Item(cField).ToString()
                Case 1
                    Return ReportListViewGovt.GetDataRow(ReportListViewGovt.FocusedRowHandle).Item(cField).ToString()
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub ReportListGridGovt_Click(sender As System.Object, e As System.EventArgs) Handles ReportListGridGovt.Click
        'Dim oSender As New GridView
        'Try
        '    oSender = DirectCast(sender, GridView)
        '    If oSender.FocusedRowHandle >= 0 Then
        '        Dim p As Point = oSender.GridControl.PointToClient(Control.MousePosition)
        '        Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
        '        If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
        '            'Load Template
        '            ShowSortOptions()
        '            PreviewPrintReport()
        '        End If
        '    End If
        'Catch ex As Exception
        '    LogErrors("Failed to load selected template '" & oSender.GetRowCellValue(oSender.FocusedRowHandle, "Name") & "'." & Chr(13) & "Error: " & ex.Message)
        '    MsgBox("Failed to load selected template '" & oSender.GetRowCellValue(oSender.FocusedRowHandle, "Name") & "'." & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        ''ShowFilterOptions()
        ''ShowSortOptions()
    End Sub

    'GOVT REPORT
    Private tblNameReportsOptions As String = "MSystblReportFilterOptions"
    Dim FilterFieldsTable As DataTable
    Dim bClearFilterButtonIsClicked As Boolean
    Const REPORT_DATE_FORMAT As String = "dd-MMM-yyyy"

    Enum ReportOptionsMode As Integer
        Show = 1
        Clear = 2
    End Enum

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFocusedRowReportData(ByVal _columnname As String) As Object
        '### Description: Gets the cell value of a selected column from the focused row in the Report List 
        Try
            Return ReportListViewGovt.GetRowCellValue(ReportListViewGovt.FocusedRowHandle, _columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try

    End Function

    Sub ShowFilterOptions()
        '### Description: Shows the Filter Options
        '####################################################################################################################################################################################################################################
        ClearFilterOptions()

        '####################################################################################################################################################################################################################################
        'Load Filter Option Control
        Dim rptOptions As String() = Nothing

        Dim cReportDll As String = ""
        Dim cReportClass As String = ""
        'Dim cReportParam As String = ""

        If GetSelectedReportItem("ObjectID").ToString.Length = 0 Then Exit Sub
        '####################################################################################################################################################################################################################################
        'IDENTIFIES THE DLL AND CLASS TO BE LOADED
        If GetSelectedReportItem("ReportFilterOptionClass").ToString.Length > 0 And GetSelectedReportItem("ReportFilterOptionDLL").ToString.Length > 0 Then
            'IF REPORT USES CUSTOM FORM AS FILTER OPTIONS
            cReportDll = GetSelectedReportItem("ReportFilterOptionDLL")
            cReportClass = GetSelectedReportItem("ReportFilterOptionClass")

        ElseIf GetSelectedReportItem("ReportFilterOptions").ToString.Length > 0 Then
            'IF REPORT USES PRE-DEFINED FILTER OPTIONS
            cReportDll = "Reports"
            cReportClass = "FilterControlDefault"
        End If

        '####################################################################################################################################################################################################################################
        If cReportDll.Length > 0 And cReportClass.Length > 0 Then
            'LOADS THE FILTER OPTION FOR THE REPORT
            extAssembly = System.Reflection.Assembly.Load(cReportDll)
            oFilterOption = extAssembly.CreateInstance(cReportDll & "." & cReportClass, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)

            If Not oFilterOption Is Nothing Then
                'ADDS THE FILTER OPTION OBJECT IN THE PRINT SELECTION FORM
                oFilterOption.ReportObjectID = GetSelectedReportItem("ObjectID").ToString
                oFilterOption.ReportGroup = GetSelectedReportItem("ReportGroup").ToString

                Panel_FilterOption.Controls.Add(oFilterOption)
                oFilterOption.Dock = DockStyle.Fill
                oFilterOption.RefreshData()
            End If
        End If

    End Sub
    Public WithEvents oSortOption As New Reports.BaseSortOption

    Sub ShowSortOptions()
        '####################################################################################################################################################################################################################################
        '### Description: Shows sort options

        '####################################################################################################################################################################################################################################
        'CLEARS THE SORT OPTIONS CONTROL FROM THE FORM
        Try
            ClearSortOptions()
        Catch ex As Exception

        End Try

        '####################################################################################################################################################################################################################################
        'LOADS SORT OPTIONS CLASS
        oSortOption = New BaseSortOption
        oSortOption.RefreshData(Trim(IfNull(GetSelectedReportItem("SortFields"), "")))

    End Sub

    Public Sub ClearSortOptions(Optional ByVal ShowErrorMsg As Boolean = False)
        '####################################################################################################################################################################################################################################
        'CLEARS THE SORT OPTIONS CLASS/CONTROL
        Try
            oSortOption.Dispose()
        Catch ex As Exception
            If ShowErrorMsg Then MsgBox(ex.Message)
        End Try
    End Sub

    Sub ClearFilterOptions()
        '####################################################################################################################################################################################################################################
        '### Description: Clears the Filter Options Control in the form
        Try
            oFilterOption.Dispose()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

#Region "Filter Options Events, Functions and Procedures"

    'Private Sub GridFilterView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridFilterViewGovt.CellValueChanged
    '    If GridFilterViewGovt.FocusedRowHandle >= 0 And Not bClearFilterButtonIsClicked Then
    '        ApplyFilter(GridFilterViewGovt.FocusedRowHandle)
    '    End If
    'End Sub

    'Private Sub GridFilterDateView_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)
    '    Dim Gv As GridView = sender
    '    Dim cControlType As String = Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.ControlType)).ToString()
    '    Dim cRowSource As String = Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.RowSource)).ToString()
    '    Dim cRowSourceType As String = Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.RowSourceType)).ToString()
    '    Dim cDisplayField As String = Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.RowSourceDisplayField)).ToString()
    '    Dim cValueField As String = Gv.GetRowCellValue(e.RowHandle, Gv.Columns(FilterOptionFilterFields.RowSourceValueField)).ToString()

    '    If e.Column.FieldName <> FilterOptionFilterFields.DisplayValue Then Return

    '    Select Case cControlType
    '        Case FilterOptionControlType.ComboBox
    '            Dim rep As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    '            rep.ShowFooter = False
    '            rep.ShowHeader = False

    '            Select Case cRowSourceType
    '                Case FilterOptionRowSoureType.Query, FilterOptionRowSoureType.SQL
    '                    'IF COMBOBOX FILTEROPTION SOURCE IS UNFILTERED/NOT FROM STORED PROCEDURE

    '                    If cRowSource.ToString.Length = 0 Or cDisplayField.ToString.Length = 0 Or cValueField.ToString.Length = 0 Then Exit Sub 'GoTo SET_OBJ_TO_TEXTBOXCELL

    '                    rep.DataSource = MPSDB.CreateTable(cRowSource)
    '                    rep.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cValueField, "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cDisplayField, "Name")})
    '                    rep.DisplayMember = cDisplayField
    '                    rep.ValueMember = cDisplayField
    '                    rep.NullText = ""
    '                    e.RepositoryItem = rep
    '                    AddHandler rep.EditValueChanged, AddressOf CustomLookUpEdit_EditValueChanged

    '                Case FilterOptionRowSoureType.PredefinedDataSource
    '                    'IF COMBOBOX FILTEROPTION SOURCE IS FILTERED/FROM STORED PROCEDURE

    '                    If cRowSource.ToString.Length = 0 Or cDisplayField.ToString.Length = 0 Or cValueField.ToString.Length = 0 Then Exit Sub 'GoTo SET_OBJ_TO_TEXTBOXCELL
    '                    Dim dt As New DataTable
    '                    dt = getPredefDataSource(cRowSource)
    '                    rep.DataSource = dt
    '                    rep.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cValueField, "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cDisplayField, "Name")})
    '                    rep.DisplayMember = cDisplayField
    '                    rep.ValueMember = cDisplayField
    '                    rep.NullText = ""

    '                    e.RepositoryItem = rep
    '                    AddHandler rep.EditValueChanged, AddressOf CustomLookUpEdit_EditValueChanged

    '                Case FilterOptionRowSoureType.ItemList
    '                    Dim dt As New DataTable

    '                    dt = changeItemListToDT(cRowSource)
    '                    If dt Is Nothing Then Exit Select

    '                    cDisplayField = "Name"
    '                    cValueField = "PKey"

    '                    rep.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cValueField, "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(cDisplayField, "Name")})

    '                    rep.DataSource = dt
    '                    rep.DisplayMember = cDisplayField
    '                    rep.ValueMember = cDisplayField
    '                    rep.NullText = ""

    '                    e.RepositoryItem = rep
    '                    AddHandler rep.EditValueChanged, AddressOf CustomLookUpEdit_EditValueChanged

    '            End Select

    '        Case FilterOptionControlType.DateEdit
    '            Dim rep As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
    '            rep.EditFormat.FormatString = REPORT_DATE_FORMAT
    '            rep.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
    '            rep.Mask.EditMask = REPORT_DATE_FORMAT   'System.Globalization.DateTimeFormat5Info.CurrentInfo.ShortDatePattern()
    '            rep.Mask.UseMaskAsDisplayFormat = True

    '            e.RepositoryItem = rep
    '            AddHandler rep.EditValueChanged, AddressOf CustomDateEdit_EditValueChanged

    '        Case FilterOptionControlType.CheckBox
    '            Dim rep As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
    '            'If dr.Item("DefaultValue").ToString.Length > 0 Then
    '            '    Try
    '            '        checkboxCell.Value = dr.Item("DefaultValue")
    '            '    Catch ex As Exception
    '            '        'MsgBox(ex.Message)
    '            '    End Try
    '            'Else
    '            '    checkboxCell.Value = 0
    '            'End If
    '            e.RepositoryItem = rep
    '            AddHandler rep.EditValueChanged, AddressOf CustomRepositoryItem_EditValueChanged

    '        Case Else 'FilterOptionControlType.TextBox
    '            Dim rep As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    '            e.RepositoryItem = rep
    '            AddHandler rep.EditValueChanged, AddressOf CustomRepositoryItem_EditValueChanged


    '    End Select

    'End Sub

    '    Private Function changeItemListToDT(cItemList As String) As DataTable
    '        Dim itemList As String = cItemList
    '        Dim arrItemList As String()
    '        arrItemList = itemList.Split(";")

    '        If (arrItemList.GetUpperBound(0) + 1) Mod 2 <> 0 Then GoTo RETURN_NOTHING
    '        Dim dt As New DataTable

    '        Dim ccolumn As DataColumn

    '        ccolumn = New DataColumn
    '        ccolumn.ColumnName = "PKey"
    '        ccolumn.DataType = System.Type.GetType("System.String")
    '        dt.Columns.Add(ccolumn)

    '        ccolumn = New DataColumn
    '        ccolumn.ColumnName = "Name"
    '        ccolumn.DataType = System.Type.GetType("System.String")
    '        dt.Columns.Add(ccolumn)

    '        For j As Integer = 0 To arrItemList.GetUpperBound(0) Step 2
    '            dt.Rows.Add(New Object() {arrItemList(j), arrItemList(j + 1)})

    '        Next

    '        Return dt

    '        Exit Function
    'RETURN_NOTHING:
    '        Return Nothing
    '    End Function

    'Private Sub CustomLookUpEdit_EditValueChanged(sender As Object, e As System.EventArgs)
    '    Dim rep As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    '    rep = TryCast(sender, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
    '    Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
    '    Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
    '    If GridFilterViewGovt.GetRowCellValue(GridFilterViewGovt.FocusedRowHandle, FilterOptionFilterFields.ControlType) = FilterOptionControlType.ComboBox And GridFilterViewGovt.GetRowCellValue(GridFilterViewGovt.FocusedRowHandle, FilterOptionFilterFields.RowSourceType) = FilterOptionRowSoureType.ItemList Then
    '        'if combobox and uses itemlist, set value to value index
    '        GridFilterViewGovt.SetRowCellValue(GridFilterViewGovt.FocusedRowHandle, FilterOptionFilterFields.Value, row.Item(0))
    '    Else
    '        GridFilterViewGovt.SetRowCellValue(GridFilterViewGovt.FocusedRowHandle, FilterOptionFilterFields.Value, row.Item(GridFilterViewGovt.GetRowCellValue(GridFilterViewGovt.FocusedRowHandle, FilterOptionFilterFields.RowSourceValueField)))
    '    End If
    'End Sub

    'Private Sub CustomRepositoryItem_EditValueChanged(sender As Object, e As System.EventArgs)
    '    GridFilterViewGovt.SetRowCellValue(GridFilterViewGovt.FocusedRowHandle, FilterOptionFilterFields.Value, sender.EditValue)
    'End Sub

    'Private Sub CustomDateEdit_EditValueChanged(sender As Object, e As System.EventArgs)
    '    GridFilterViewGovt.SetRowCellValue(GridFilterViewGovt.FocusedRowHandle, FilterOptionFilterFields.Value, sender.editvalue)
    '    GridFilterViewGovt.SetRowCellValue(GridFilterViewGovt.FocusedRowHandle, FilterOptionFilterFields.DisplayValue, Format(sender.editvalue, REPORT_DATE_FORMAT))
    'End Sub

    'Private Function getDisplayValueFromRowSource(ByVal cRowSource As String, ByVal cRowSourceType As String, ByVal cRowSourceKeyField As String, ByVal cRowSourceKeyFieldValue As String, ByVal cRowSourceDisplayField As String) As String
    '    Dim retval As String = ""
    '    Dim dt As DataTable
    '    Dim dr() As DataRow = Nothing

    '    Select Case cRowSourceType
    '        Case FilterOptionRowSoureType.Query, FilterOptionRowSoureType.SQL
    '            dt = MPSDB.CreateTable(cRowSource)
    '            dr = dt.Select(cRowSourceKeyField & " = '" & cRowSourceKeyFieldValue & "'")

    '        Case FilterOptionRowSoureType.PredefinedDataSource
    '            dt = getPredefDataSource(cRowSource)
    '            dr = dt.Select(cRowSourceKeyField & " = '" & cRowSourceKeyFieldValue & "'")

    '        Case FilterOptionRowSoureType.ItemList
    '            dt = changeItemListToDT(cRowSource)
    '            dr = dt.Select("PKey = '" & cRowSourceKeyFieldValue & "'")

    '        Case Else
    '            retval = cRowSourceKeyFieldValue

    '    End Select

    '    If Not dr Is Nothing Then
    '        retval = dr(0)(cRowSourceDisplayField)
    '    End If

    '    Return retval
    'End Function

#End Region

    Private Sub ReportListView_Click(sender As Object, e As System.EventArgs) Handles ReportListView.Click
        A_REPORT_HAS_BEEN_SELECTED = True
    End Sub

    Private Sub ReportListView_DoubleClick1(sender As Object, e As System.EventArgs) Handles ReportListView.DoubleClick
        Dim oSender As New GridView
        Try
            oSender = DirectCast(sender, GridView)
            If oSender.FocusedRowHandle >= 0 Then
                Dim p As Point = oSender.GridControl.PointToClient(Control.MousePosition)
                Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
                If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
                    'Load Template
                    ShowSortOptions()
                    PreviewPrintReport()
                End If
            End If
        Catch ex As Exception
            LogErrors("Failed to load selected template '" & oSender.GetRowCellValue(oSender.FocusedRowHandle, "Name") & "'." & Chr(13) & "Error: " & ex.Message)
            MsgBox("Failed to load selected template '" & oSender.GetRowCellValue(oSender.FocusedRowHandle, "Name") & "'." & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ReportListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ReportListView.RowCellStyle
        If e.RowHandle = ReportListView.FocusedRowHandle And A_REPORT_HAS_BEEN_SELECTED Then
            e.Appearance.BackColor = System.Drawing.Color.Yellow
        End If
    End Sub

    Private Sub ReportListViewGovt_Click(sender As Object, e As System.EventArgs) Handles ReportListViewGovt.Click
        A_REPORT_HAS_BEEN_SELECTED = True
        Dim oSender As New GridView
        Try
            oSender = DirectCast(sender, GridView)
            If oSender.FocusedRowHandle >= 0 Then
                Dim p As Point = oSender.GridControl.PointToClient(Control.MousePosition)
                Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
                If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
                    'Load Template
                    ShowFilterOptions()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReportListViewGovt_DoubleClick(sender As Object, e As System.EventArgs) Handles ReportListViewGovt.DoubleClick
        Dim oSender As New GridView
        Try
            oSender = DirectCast(sender, GridView)
            If oSender.FocusedRowHandle >= 0 Then
                Dim p As Point = oSender.GridControl.PointToClient(Control.MousePosition)
                Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
                If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
                    'Load Template
                    ShowSortOptions()
                    PreviewPrintReport()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReportListViewGovt_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ReportListViewGovt.RowCellStyle
        If e.RowHandle = ReportListViewGovt.FocusedRowHandle And A_REPORT_HAS_BEEN_SELECTED Then
            e.Appearance.BackColor = System.Drawing.Color.Yellow
        End If
    End Sub

End Class