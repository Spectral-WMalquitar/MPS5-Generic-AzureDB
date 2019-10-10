Imports MPS4
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports System.ComponentModel
Imports DevExpress.XtraSplashScreen
Imports System.Timers
Imports System.Threading.Tasks
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors

Public Class ReportSelection

#Region "Properties"
    Public HeaderCaption As String = ""
    Public SelectedReportGroup As String
    Public SelectedReport As String
    Public SelectedMenuPage As String = ""
#End Region

#Region "Declarations"
#Region "Configs and Constants"
    Public Const REFRESH_REPORTLIST_BYSINGLECLICK As Boolean = False
    Private Const FilterRecordsText As String = "2. Filter Records"
    Private Const SelectRecordsText As String = "3. Select Records"
    Private Const SortRecordsText As String = "4. Sort Records"
    Private Const FilterAndSortTemplatesText As String = "Saved Templates"

#End Region
    Public WithEvents oFilterOption As New Reports.BaseFilterOption
    Public WithEvents oSortOption As New Reports.BaseSortOption
    Public WithEvents REPORT_DETAIL As New ReportDetail

    Dim extAssembly As System.Reflection.Assembly

    Dim clsSec As New clsSecurity
    Dim clsAudit As New clsAudit
    Dim LastUpdatedBy As String

    Dim ReportType As String = SelectedTab
    Public oReportInfo As New ReportInfo

    '####################################################################################################################################################################################################################################
    'DATA TABLES
    Dim ReportsTable As New System.Data.DataTable()
    Dim SelectionTable As New System.Data.DataTable()
    Dim FilterFieldsTable As DataTable

    '####################################################################################################################################################################################################################################
    Dim A_REPORT_HAS_BEEN_SELECTED As Boolean = False
    
    '####################################################################################################################################################################################################################################
    'VARIABLES USED TO HANDLE DOUBLE-CLICKING IN THE REPORT LIST GRID
    Public Shared bReportIsClicked As Boolean = False
    Public Shared bReportTemplateIsClicked As Boolean = False
    Public Shared bClearFilterButtonIsClicked As Boolean

    '####################################################################################################################################################################################################################################
    'VARIABLE TO HANDLE DRAG AND DROP IN SELECTION AND SELECTED GRIDS
    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle
    Private fromIndexMovable As Boolean
    Private dragIndexMovable As Boolean
    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

    Enum ShowButtonOption As Integer
        INIT = 1
        SELECTREPORT = 2
        DESELECTREPORT = 3
    End Enum

#End Region

#Region "Initialziation"

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        '####################################################################################################################################################################################################################################
        'Initialize Buttons
        InitControls()

        '####################################################################################################################################################################################################################################
        Try
            If Not bLoaded Then 'IF FIRST LOAD, WILL LOAD REPORTS AVAILABLE FOR SELECTION
                '####################################################################################################################################################################################################################################
                header.Text = HeaderCaption                                     'changes the title of the report group
                
                '####################################################################################################################################################################################################################################
                'CLEARS THE REPORT LIST
                ClearReportList()

                '####################################################################################################################################################################################################################################
                'GETS THE REPORTS TO BE DISPLAYED BASED ON SELECTED REPORT GROUP AND PERMISSION ASSIGNED TO USER
                Dim sql_reportlist As String

                sql_reportlist = clsSec.get_reports(USER_ID, ReportsTable, SelectedReportGroup)

                clsFeature.filterTableByFeature(ReportsTable, COMPANYID, FEATUREKEY) 'neil

                '####################################################################################################################################################################################################################################
                'LOADS THE REPORT LIST
                If ReportsTable.Rows.Count > 0 Then
                    Me.ReportListGrid.DataSource = ReportsTable
                    SortViewByColumn(ReportListView, ReportListFields.SortCode)
                    ReportListView.OptionsSelection.EnableAppearanceFocusedRow = False
                    bLoaded = True
                Else
                    MsgBox("There is no available report for this report group.", vbInformation)
                End If


            Else 'IF NOT FIRST LOAD (REFRESH), WILL REFRESH CONTROLS NECESSARY FOR THE REPORT SELECTED
                '####################################################################################################################################################################################################################################
                'Sets that a report has been selected and which report is selected
                A_REPORT_HAS_BEEN_SELECTED = True
                oReportInfo = New ReportInfo(ReportListView.GetDataRow(ReportListView.FocusedRowHandle))
                SelectedReport = oReportInfo.ObjectID

                '<!-- added by tony20180118
                GridSelectionView.ApplyFindFilter("")
                GridSelectedView.ApplyFindFilter("")
                'end tony -->

                '####################################################################################################################################################################################################################################
                'Enable buttons when a report is selected
                ShowButtons(ShowButtonOption.SELECTREPORT)

                '####################################################################################################################################################################################################################################
                'ENABLES FILTER OPTION, IF APPLIES
                If EnableFilterOptions() Then ShowFilterOptions()

                '####################################################################################################################################################################################################################################
                'ENABLES SORT OPTION, IF APPLIES
                If EnableSortOptions() Then ShowSortOptions()

                '####################################################################################################################################################################################################################################
                'ENABLES SELECTION AND SELECTED GRID, IF APPLIES
                If EnableSelection() Then ShowSelectionList()


                '####################################################################################################################################################################################################################################
                'ENABLES TEMPLATE, IF APPLIES
                If EnableTemplate() Then
                    LoadTemplateList(Me)
                    SetEditOptionsVisibility(ObjectIDContent, True)
                Else
                    SetEditOptionsVisibility(ObjectIDContent, False)
                End If

                '####################################################################################################################################################################################################################################
                'IF SELECTION, FILTER OPTIONS AND SORT OPTIONS ARE ALL DISABLED, IT MEANS REPORT IS AUTO-SHOW REPORT
                'THIS AUTO-OPENS THE REPORT
                If Not LayoutControlGroup_Selection.Enabled And _
                    Not LayoutControlGroup_Sort.Enabled And _
                    Not LayoutControlGroup_Filter.Enabled Then
                    'AUTO-PREVIEW REPORT
                    PreviewPrintReport()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitControls()
        '####################################################################################################################################################################################################################################
        ShowButtons(ShowButtonOption.INIT)                                      'hides/shows and enables/disables necessary ribbon menu buttons
        '####################################################################################################################################################################################################################################
        Me.LayoutControl_ReportSelection.AllowCustomization = False             'disables layout customization property
        '####################################################################################################################################################################################################################################
        'Clears objects in the form
        ClearSelectionList()
        ClearSelectionListFilter()
        ClearTemplateList(GridTemplates)
        ClearFilterOptions()
        ClearSortOptions()

        clsAudit.propSQLConnStr = MPSDB.GetConnectionString

        Me.Refresh()

        '####################################################################################################################################################################################################################################
        ResetOptionsLabels()

        SetProcessedPayrollListVisibility(Name, False)
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub ShowReportsRibbonPageGroup()
        '### Description: Shows necessary ribbonpagegroup based on what type of report is selected
        Select Case SelectedMenuPage
            Case RibbonControlReportPage.Crew
                SetRibbonPageGroupVisibility(Name, ReportOptionsPageGroup.Crew, True)
            Case RibbonControlReportPage.Admin
                SetRibbonPageGroupVisibility(Name, ReportOptionsPageGroup.Admin, True)
            Case RibbonControlReportPage.Payroll
                SetRibbonPageGroupVisibility(Name, ReportOptionsPageGroup.Payroll, True)
            Case RibbonControlReportPage.KPI
                SetRibbonPageGroupVisibility(Name, ReportOptionsPageGroup.KPI, True)
                SetKPIShowTemplateVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        End Select
    End Sub

    Private Sub ReportSelection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsSec.propSQLConnStr = MPSDB.GetConnectionString
    End Sub

    Sub ShowSelectionList()
        '### Description: Populates the `selection` grid and the `selected` grid based on the selected report from the ReportListGrid
        Reports.OpenReportWaitForm()
        Try
            If Not bReportIsClicked Then
                GoTo EXIT_SUB
            End If

            '####################################################################################################################################################################################################################################
            'GETS THE PRINT SELECTION SOURCE 
            Dim sourceErr As String = ""
            SelectionTable.Clear()
            If Not GetSelectionSourceDT(SelectionTable) Then
                'This generates the print selection data source and assign it to the SelectionTable variable
                'will proceed if datasource is generated successfully
                ShowButtons(ShowButtonOption.DESELECTREPORT)
                A_REPORT_HAS_BEEN_SELECTED = False

                'REMOVE FILTER AND SORT OPTIONS
                ClearTemplateList(GridTemplates)
                ClearFilterOptions()
                ClearSortOptions()
                GoTo EXIT_SUB
            End If

            '####################################################################################################################################################################################################################################
            'ASSIGNS THE DATA SOURCE OF THE PRINT SELECTION
            If SelectionTable.Rows.Count = 0 Then
                MsgBox("There are no available record for selection.", vbInformation)
                GoTo EXIT_SUB
            End If
            GridSelection.DataSource = SelectionTable
            GridSelected.DataSource = SelectionTable.Clone

            '####################################################################################################################################################################################################################################
            'CREATES COLUMNS FOR THE SELECTION LIST
            GenerateSelectionGridColumnsFromDt(GridSelectionView, SelectionTable)
            'CREATES COLUMNS FOR THE SELECTED LIST
            GenerateSelectionGridColumnsFromDt(GridSelectedView, SelectionTable)

            '####################################################################################################################################################################################################################################
            'SORT THE SELECTION AND SELECTED GRIDS
            SortSelectionGrid(GridSelectionView)
            SortSelectionGrid(GridSelectedView)

            '####################################################################################################################################################################################################################################
            'TAG FLAG THAT IDENTIFIES A REPORT HAS BEEN SELECTED
            A_REPORT_HAS_BEEN_SELECTED = True

            '####################################################################################################################################################################################################################################
            'SHOW FILTER AND SORT OPTIONS
            'ShowFilterOptions()
            'ShowSortOptions()

            '####################################################################################################################################################################################################################################
            'RESETS THAT A REPORT IS CLICKED
            setReportIsClicked(False)

        Catch ex As Exception
            MsgBox("Unable to generate selection list." & Chr(13) & "(Error no. " & Err.Number & ") " & ex.Message)
            GoTo EXIT_SUB
        End Try

EXIT_SUB:
        CloseReportWaitForm()

    End Sub

    Public Sub ClearFilterOptions()
        '####################################################################################################################################################################################################################################
        '### Description: Clears the Filter Options Control in the form
        Try
            Panel_FilterOption.Controls.Clear()
            'oFilterOption.Dispose()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ClearFilterOptionsValues()
        '####################################################################################################################################################################################################################################
        '### Description: Clears the Filter Options Values
        Try
            oFilterOption.ClearFilterValueAll()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Sub ShowFilterOptions()
        '### Description: Shows the Filter Options
        '####################################################################################################################################################################################################################################
        ClearFilterOptions()

        oFilterOption = New BaseFilterOption
        'oFilterOption = CreateFilterOptionObject(oReportInfo)
        oFilterOption = Reports.FilterOption.Create(oReportInfo)
        If Not oFilterOption Is Nothing Then
            Panel_FilterOption.Controls.Add(oFilterOption)
            oFilterOption.Dock = DockStyle.Fill
        End If
    End Sub


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
        oSortOption = Reports.SortOption.Create(oReportInfo)

        '####################################################################################################################################################################################################################################
        'ADDS SORT OPTIONS CONTROL IN THE PRINT SELECTION FORM
        Panel_SortOption.Controls.Clear()
        Panel_SortOption.Controls.Add(oSortOption)
        oSortOption.Dock = DockStyle.Fill

    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Sub ShowButtons(nMode As ShowButtonOption)
        '####################################################################################################################################################################################################################################
        '### Description: hides/shows and enables/disables necessary ribbon menu buttons
        Try
            Select Case nMode
                Case ShowButtonOption.INIT                     '1 - INIT - Initial
                    'View Options
                    'GoHideRibbonPageGroup()

                    'Button: Show List
                    SetShowListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                    SetShowListEnabled(Name, False)

                    'Button: Preview Report
                    SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                    SetPreviewReportEnabled(Name, False)

                    'Button: Clear Filter
                    SetClearFilterVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                    SetClearFilterCaption(Name, "Clear Filter")

                    'Button: Save Template
                    AllowSaving(Name, False)
                    SetClearFilterEnabled(Name, False)

                    'Button: Load Template
                    SetLoadDataVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                    AllowLoadingTemplate(Name, False)

                    'Button: Export
                    SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

                    'Button: Save Template
                    SetSaveCaption(Name, "Save Template")

                    'Button: Delete Template
                    AllowDeletion(Name, False)
                    SetDeleteCaption(Name, "Delete Template")

                    'Button: View Reports
                    SetQuickReportsVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

                    'Button: Select/Deselect
                    btnDeselectAll.ForeColor = Color.Black
                    btnSelectAll.ForeColor = Color.Black

                    'Layout Control Groups
                    ClearFilterOptions()
                    LayoutControlGroup_Filter.Enabled = False
                    LayoutControlGroup_Sort.Enabled = False
                    LayoutControlGroup_Selection.Enabled = False
                    LayoutControlGroup_Templates.Enabled = False
                    ShowReportsRibbonPageGroup()


                    'From Payroll form
                    SetCalculatePayVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                    SetClearFilterVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)

                Case ShowButtonOption.SELECTREPORT             '2 - SELECTREPORT - When a report is selected
                    'Button: Show List
                    SetShowListEnabled(Name, False)

                    'Button: Preview Report
                    If oReportInfo.UsePreviewButton = True Then
                        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                        SetPreviewReportEnabled(Name, True)
                    Else
                        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                    End If

                    'Button: Clear Filter
                    SetClearFilterEnabled(Name, LayoutControlGroup_Filter.Enabled)

                    'Button: Export
                    If oReportInfo.UseExportButton = True Then
                        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                    Else
                        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                    End If

                    'Button: Save Template
                    AllowSaving(Name, (oReportInfo.UseTemplateList <> 0))
                    'Button: Load Template
                    AllowLoadingTemplate(Name, (oReportInfo.UseTemplateList <> 0))
                    'Button: Delete Template
                    AllowDeletion(Name, (oReportInfo.UseTemplateList <> 0))

                Case ShowButtonOption.DESELECTREPORT           '3 - DESELECTREPORT - When deselecting a report
                    'Button: Show List
                    SetShowListEnabled(Name, True)

                    'Button: Preview Report
                    SetPreviewReportEnabled(Name, False)

                    'Button: Clear Filter
                    SetClearFilterEnabled(Name, False)

                    'Button: Save Template
                    AllowSaving(Name, False)

                    'Button: Load Template
                    AllowLoadingTemplate(Name, False)

                    'Button: Delete Template
                    AllowDeletion(Name, False)

                    'Button: Export
                    SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

                    'Layout Control Groups
                    'setFilterOptionPanel(enumFilterOption.None)
                    LayoutControlGroup_Filter.Enabled = False
                    LayoutControlGroup_Sort.Enabled = False
                    LayoutControlGroup_Selection.Enabled = False
                    LayoutControlGroup_Templates.Enabled = False
            End Select

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        '####################################################################################################################################################################################################################################
        'BUTTONS AND CONTROLS THAT SHOULD BE HIDDEN AS DEFAULT
        SetApplyVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetLoadDataVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)

    End Sub

#Region "Report Clicking Events"
    Sub setReportIsClicked(Optional value As Boolean = True)
        bReportIsClicked = value
    End Sub

    Sub setClearFilterButtonIsClicked(Optional value As Boolean = True)
        bClearFilterButtonIsClicked = value
    End Sub

    Sub setReportTemplateIsClicked(Optional value As Boolean = True)
        bReportTemplateIsClicked = value
    End Sub
#End Region
#End Region

#Region "Enabling Functions/Procedures"
    Private Function EnableFilterOptions() As Boolean
        '####################################################################################################################################################################################################################################
        'CHECKS IF FILTER OPTIONS IS TO BE ENABLED
        Dim bRetval As Boolean = False
        Dim bEnable As Boolean = False
        Try
            '####################################################################################################################################################################################################################################
            'If (oReportInfo.ReportFilterOptionClass.Length > 0 And oReportInfo.ReportFilterOptionDLL.Length > 0) Or _
            '   (oReportInfo.ReportFilterOptions.Length > 0) Then
            '    'IF REPORT USES FILTER OPTIONS
            '    LayoutControlGroup_Filter.Enabled = True
            '    bRetval = True
            '    SetClearFilterEnabled(Name, True)
            'Else
            '    LayoutControlGroup_Filter.Enabled = False
            'End If
            If (oReportInfo.ReportFilterOptionClass.Length > 0 And oReportInfo.ReportFilterOptionDLL.Length > 0) Then
                'IF REPORT USES FILTER OPTIONS
                bEnable = True
            Else
                Dim dt As DataTable = MPSDB.CreateTable("SELECT opt.* FROM dbo." & tblNameReportsOptions & " opt INNER JOIN dbo.MSysAdmFilterOption admopt ON opt.FKeyFilterOption = admopt.ObjectID WHERE admopt.OptionType = 'FILTER' AND opt.FKeyReportObjectID = '" & oReportInfo.ObjectID & "' AND opt.ReportGroup = '" & oReportInfo.ReportGroup & "'")
                If dt.Rows.Count > 0 Then
                    'IF REPORT USES FILTER OPTIONS
                    bEnable = True
                Else
                    bEnable = False
                End If
            End If

        Catch ex As Exception
            'do nothing
        End Try

        Try
            If bEnable Then
                LayoutControlGroup_Filter.Enabled = True
                bRetval = True
                SetClearFilterEnabled(Name, True)
            Else
                LayoutControlGroup_Filter.Enabled = False
            End If
        Catch ex As Exception

        End Try

        LayoutControlGroup_Filter.Text = FilterRecordsText & _
                                         IIf(LayoutControlGroup_Filter.Enabled, "", " - NOT APPLICABLE TO THIS REPORT")

        Return bRetval
    End Function

    Private Function EnableSortOptions() As Boolean
        '####################################################################################################################################################################################################################################
        'CHECKS IF SORT OPTIONS IS TO BE ENABLED
        Dim bRetval As Boolean = False
        Try
            LayoutControlGroup_Sort.Enabled = (oReportInfo.SortFields.Length > 0)
            bRetval = LayoutControlGroup_Sort.Enabled
        Catch ex As Exception
            'do nothing
        End Try

        LayoutControlGroup_Sort.Text = SortRecordsText & _
                                         IIf(LayoutControlGroup_Sort.Enabled, "", " - NOT APPLICABLE TO THIS REPORT")

        Return bRetval
    End Function

    Private Function EnableSelection() As Boolean
        '####################################################################################################################################################################################################################################
        'CHECKS IF DATA SELECTION IS TO BE ENABLED
        Dim bRetval As Boolean = False
        Try
            LayoutControlGroup_Selection.Enabled = (oReportInfo.UseSelectionList <> 0)
            bRetval = LayoutControlGroup_Selection.Enabled
        Catch ex As Exception
            'do nothing
        End Try

        LayoutControlGroup_Selection.Text = SelectRecordsText & _
                                         IIf(LayoutControlGroup_Selection.Enabled, "", " - NOT APPLICABLE TO THIS REPORT")
        Return bRetval
    End Function

    Private Function EnableTemplate() As Boolean
        '####################################################################################################################################################################################################################################
        'CHECKS IF TEMPLATES IS TO BE ENABLED
        Dim bRetval As Boolean = False
        Try
            LayoutControlGroup_Templates.Enabled = (oReportInfo.UseTemplateList <> 0)
            bRetval = LayoutControlGroup_Templates.Enabled
        Catch ex As Exception
            'do nothing
        End Try

        LayoutControlGroup_Templates.Text = FilterAndSortTemplatesText & _
                                         IIf(LayoutControlGroup_Templates.Enabled, "", " - NOT APPLICABLE TO THIS REPORT")
        Return bRetval
    End Function
#End Region

#Region "Report Selection Events, Functions and Procedures"

    Private Sub PreviewPrintReport(Optional ByVal OutputMode As ReportOutputMode = ReportOutputMode.Preview)
        '####################################################################################################################################################################################################################################
        'CHECKS IF FILTER OPTIONS IS TO BE ENABLED
        '### Description: Preview the Report. This procedure also includes the generating of datasource and filter.
        header.Focus()

        '####################################################################################################################################################################################################################################
        'CHECKS IF THE REPORT USES A SELECTION LIST AND IF THERE ARE ANY RECORD(S) SELECTED TO BE PREVIEWED
        If oReportInfo.UseSelectionList <> 0 And Not HasSelectedRecord() Then
            MsgBox("There is no selected record(s) to preview. Please try again.", vbInformation)
            Exit Sub
        End If

        RefreshReportDetail()   'REFRESHES THE REPORT DETAIL CLASS
        REPORT_DETAIL.Output.Mode = OutputMode

        BuildReport(REPORT_DETAIL)

    End Sub


    Sub RefreshReportDetail()
        '####################################################################################################################################################################################################################################
        'ASSIGNS VARIABLES TO REPORT DETAIL CLASS
        REPORT_DETAIL = New ReportDetail
        With REPORT_DETAIL
            .DB = MPSDB                                                                         'Reference to database
            .ReportInfo = oReportInfo
            '.SelectedRecord = GetPrintSelection()                                               'Where condition based on the print selection that can be used to filter the report datasource
            '.SelectedRecordList = GetPrintSelection(, True)                                     'List of Values based on the print selection that can be used to filter the report datasource
            .PresentRecord = New PresentRecord(oReportInfo, GridSelectedView)
            .FilterOption = oFilterOption                                                       'Filter Option Class Object
            .SortOption = oSortOption                                                           'Sort Option Class Object
            .FieldSorting = oSortOption.GetSortString()                                         'ORDER BY statement based on the items from the Sort Option

        End With
    End Sub


    <System.Diagnostics.DebuggerStepThrough()> _
    Sub SelectDeselectAllSelection(nMode As Integer)
        OpenReportWaitForm()
        '####################################################################################################################################################################################################################################
        '### Description: Select/Deselect All selection

        Dim viewSource As DevExpress.XtraGrid.Views.Grid.GridView
        Dim viewDest As DevExpress.XtraGrid.Views.Grid.GridView
        Dim destTable As DataTable

        '####################################################################################################################################################################################################################################
        'GETS WHICH IS DATAVIEW AS SOURCE AND DESTINATION
        Select Case nMode
            Case SelectDeselectAll.SelectAll
                viewSource = CType(GridSelectionView, DevExpress.XtraGrid.Views.Grid.GridView)
                destTable = CType(GridSelected.DataSource, DataTable)
                viewDest = CType(GridSelectedView, DevExpress.XtraGrid.Views.Grid.GridView)
            Case SelectDeselectAll.DeselectAll
                viewSource = CType(GridSelectedView, DevExpress.XtraGrid.Views.Grid.GridView)
                destTable = CType(GridSelection.DataSource, DataTable)
                viewDest = CType(GridSelectionView, DevExpress.XtraGrid.Views.Grid.GridView)
            Case Else
                Exit Sub
        End Select

        '####################################################################################################################################################################################################################################
        'STARTS SELECTING AND DESELECTING
        For i As Integer = (viewSource.DataRowCount - 1) To 0 Step -1
            Dim row As DataRow
            row = viewSource.GetDataRow(i)
            destTable.ImportRow(row)
            row.Delete()
        Next

        '####################################################################################################################################################################################################################################
        'APPLY SORTING
        SortViewByColumn(viewDest, oReportInfo.SelectionDisplayField)

        '####################################################################################################################################################################################################################################
        'FOCUS ON TOP ROW OF SELECTION
        Try
            GridSelectionView.FocusedRowHandle = 0
        Catch ex As Exception

        End Try

        '####################################################################################################################################################################################################################################
        'FOCUS ON TOP ROW OF SELECTED
        Try
            GridSelectedView.FocusedRowHandle = 0
        Catch ex As Exception

        End Try

        CloseReportWaitForm()
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetPrintSelection(Optional UseDisplayField As Boolean = False, Optional WithoutCompareField As Boolean = False) As String
        '####################################################################################################################################################################################################################################
        '### Description: Gets selected items from selection. Places into format: <field> IN ('item1', 'item2', ..... 'itemX')
        Dim cRetval As New System.Text.StringBuilder

        Dim cTemp As String

        cRetval.Clear()

        If oReportInfo.UseSelectionList <> 0 Then
            Try
                For i As Integer = 0 To GridSelectedView.RowCount - 1
                    cTemp = IIf(cRetval.Length > 0, ", ", "") & _
                            "'" & GridSelectedView.GetRowCellValue(i, IIf(UseDisplayField, oReportInfo.SelectionDisplayField, oReportInfo.SelectionKeyField)) & "'"
                    cRetval.Append(cTemp)
                Next

            Catch ex As Exception
                cRetval.Clear()
                'MsgBox(ex.Message)
            End Try

            If cRetval.Length > 0 Then
                If oReportInfo.KeyFilterField.Length > 0 Then
                    Return IIf(Not WithoutCompareField, oReportInfo.KeyFilterField & " IN ", "") & "(" & cRetval.ToString & ")"
                Else
                    Return "true"
                End If
            Else
                Return "false"
            End If
        Else
            Return ""
        End If

    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetPrintSelectionAsTable() As DataTable
        '####################################################################################################################################################################################################################################
        '### Description: Gets selected items from selection. Places into a table with one column, PKey
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("PKey", System.Type.GetType("System.String")))

        If oReportInfo.UseSelectionList <> 0 Then
            Try
                For i As Integer = 0 To GridSelectedView.RowCount - 1
                    dt.Rows.Add(New Object() {GridSelectedView.GetRowCellValue(i, oReportInfo.SelectionKeyField)})
                Next

            Catch ex As Exception
                dt.Rows.Clear()
                'MsgBox(ex.Message)
            End Try

        End If

        Return dt
    End Function

    Sub GenerateSelectionGridColumnsFromDt(ByRef gv As DevExpress.XtraGrid.Views.Grid.GridView, ByRef dt As DataTable)
        '####################################################################################################################################################################################################################################
        'CREATES COLUMNS FOR THE SELECTION/SELECTED LIST
        Dim Column As DevExpress.XtraGrid.Columns.GridColumn
        gv.Columns.Clear()
        For I As Integer = 0 To dt.Columns.Count - 1
            Column = gv.Columns.AddField(SelectionTable.Columns(I).ColumnName)
            If dt.Columns(I).ColumnName = oReportInfo.SelectionKeyField Then
                gv.Columns(I).Name = "Key_Selection"
                Column.Visible = False
            ElseIf dt.Columns(I).ColumnName = oReportInfo.SelectionDisplayField Then
                gv.Columns(I).Name = "Display_Selection"
                Column.Visible = True
            Else
                gv.Columns(I).Name = dt.Columns(I).ColumnName
                Column.Visible = False
            End If
        Next
    End Sub

    Sub SortSelectionGrid(ByRef gv As DevExpress.XtraGrid.Views.Grid.GridView)
        'SORT THE SELECTION AND SELECTED GRIDS
        If oReportInfo.SelectionSortField.Length > 0 Then
            Try
                SortViewByColumn(gv, oReportInfo.SelectionSortField)
            Catch ex As Exception
                SortViewByColumn(gv, 1)
            End Try
        Else
            SortViewByColumn(gv, 1)
        End If
    End Sub

    Function GetSelectionSourceDT(ByRef dt As DataTable) As Boolean
        Dim errMsg As String = ""
        Dim retval As Boolean = False
        If Not LayoutControlGroup_Selection.Enabled Then
            Return False
            Exit Function
        End If
        Select Case oReportInfo.SelectionSourceType
            Case RowSoureType.PredefinedDataSource
                Try
                    If Not IsNothing(SelectedTab) Then
                        If (SelectedTab.Equals("Archive")) Then
                            dt = getPredefDataSource("RPTSEL_CREWLIST_ARC")
                        Else
                            dt = getPredefDataSource(oReportInfo.SelectionSource)
                        End If
                        retval = True
                    Else
                        dt = getPredefDataSource(oReportInfo.SelectionSource)
                        retval = True
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Case RowSoureType.SQL
                Try
                    dt = MPSDB.CreateTable(oReportInfo.SelectionSource)
                    retval = True
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Case RowSoureType.Query, RowSoureType.Object
                Try
                    dt = MPSDB.CreateTable("SELECT * FROM [" & oReportInfo.SelectionSource & "]")
                    retval = True
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
        End Select

        Return retval

    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function HasSelectedRecord() As Boolean
        '####################################################################################################################################################################################################################################
        '### Description: Checks if there are data selected for preview
        Dim bRetval As Boolean

        bRetval = False
        Try
            bRetval = (GridSelectedView.RowCount > 0)
        Catch ex As Exception
            bRetval = False
        End Try
        Return bRetval

    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Shared Sub SortViewByColumn(ByRef oGridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal ColumnName As String, Optional ByVal SortDescending As Boolean = False)
        '####################################################################################################################################################################################################################################
        '### Description: Applies sorting to selection/selected grid (by column name)
        oGridView.BeginSort()
        Try
            If Not SortDescending Then
                oGridView.Columns(ColumnName).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Else
                oGridView.Columns(ColumnName).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            End If
        Catch ex As Exception
            LogErrors("Failed to Sort Data Selection grids by columnname [" & ColumnName & "]")

        End Try

        oGridView.EndSort()
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Shared Sub SortViewByColumn(ByRef oGridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal ColumnIndex As Integer, Optional ByVal SortDescending As Boolean = False)
        '####################################################################################################################################################################################################################################
        '### Description: Applies sorting to selection/selected grid (by column index)
        oGridView.BeginSort()
        Try
            If Not SortDescending Then
                oGridView.Columns(ColumnIndex).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Else
                oGridView.Columns(ColumnIndex).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            End If
        Catch ex As Exception
            LogErrors("Failed to Sort Data Selection grids by columnidex [" & ColumnIndex & "]")
        End Try

        oGridView.EndSort()
    End Sub

    Private Sub ReportListView_Click(sender As Object, e As System.EventArgs) Handles ReportListView.Click
        '### Description: When a row is clicked in the Report List
        '                 The Print Selection and the Report options must be cleared

        'Prepared by Tony20160205
        If REFRESH_REPORTLIST_BYSINGLECLICK Then
            setReportIsClicked()
            RefreshData()
        Else
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim p As Point = view.GridControl.PointToClient(Control.MousePosition)
            Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
            If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
                If ReportListView.GetFocusedRowCellValue(ReportListFields.ObjectID) <> SelectedReport Then
                    ShowButtons(ShowButtonOption.DESELECTREPORT)
                    ReportListView.OptionsSelection.EnableAppearanceFocusedRow = True
                    setReportIsClicked()
                    ClearTemplateList(GridTemplates)
                    ClearFilterOptions()
                    ClearSortOptions()
                    'Application.DoEvents()
                    ClearSelectionList()
                    ResetOptionsLabels()
                Else
                    setReportIsClicked(False)
                End If
            End If

            
        End If
    End Sub

    Private Sub ReportListView_DoubleClick(sender As Object, e As System.EventArgs) Handles ReportListView.DoubleClick
        '### Description: When the Report List is double clicked
        '                 Shows the Print Selection and Repors Options for the selected report.
        If Not REFRESH_REPORTLIST_BYSINGLECLICK Then
            If bReportIsClicked Then
                Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim p As Point = View.GridControl.PointToClient(Control.MousePosition)
                Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
                If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
                    RefreshData()
                End If
            End If
        End If
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub ReportListView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ReportListView.RowCellStyle
        If e.RowHandle = ReportListView.FocusedRowHandle And A_REPORT_HAS_BEEN_SELECTED Then
            e.Appearance.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub btnSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectAll.Click
        '### Description: When Select All is clicked (Print Selection)
        SelectDeselectAllSelection(SelectDeselectAll.SelectAll)
    End Sub

    Private Sub btnDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnDeselectAll.Click
        '### Description: When Deselect All is clicked (Print Selection)
        SelectDeselectAllSelection(SelectDeselectAll.DeselectAll)
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "SHOWLIST"
                RefreshData()
            Case "PREVIEWREPORT"
                PreviewPrintReport(ReportOutputMode.Preview)
            Case "EXPORTREPORT", "EXPORT"
                PreviewPrintReport(ReportOutputMode.Export)
            Case "PRINTREPORT"
                PreviewPrintReport(ReportOutputMode.Print)
            Case "LOADTEMPLATE"
                LoadSelectedReportTemplate()

            Case "CLEARFILTER"
                If A_REPORT_HAS_BEEN_SELECTED Then
                    SavedFilterOptionValues.Clear()             '<--- this clears the filter option values from the floating repo for filter option values
                    setClearFilterButtonIsClicked()             '<--- flag that sets that the Clear Filter button is clicked
                    ClearSelectionListFilter()                  '<--- clears the filter from the selection and selected lists
                    ClearFilterOptionsValues()                  '<--- clears the values in the loaded filter option
                    'ClearSortOptionsValues()                    '<--- clears the sorting in the loaded sort option
                    'DO NOT CLEAR SORT
                    setClearFilterButtonIsClicked(False)        '<--- flag that sets that the Clear Filter button is not clicked

                End If
            Case "APPLYFILTER"
                oFilterOption.ApplyFilterToPrintSelection()

            Case "GENERATE_REPORT_FROM_SELECTED_TEMPLATE"
                GenerateReportFromTemplate(GridRepTemplates.GetFocusedRowCellValue("PKey"))
        End Select
    End Sub

#End Region

#Region "DragAndDrop"

    Private Sub GridSelectionView_DoubleClick(sender As Object, e As System.EventArgs) Handles GridSelectionView.DoubleClick
        Dim osender As DevExpress.XtraGrid.Views.Grid.GridView
        oSender = DirectCast(sender, GridView)
        If oSender.FocusedRowHandle >= 0 Then
            Dim p As Point = oSender.GridControl.PointToClient(Control.MousePosition)
            Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
            If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then

                Dim table As DataTable = TryCast(GridSelected.DataSource, DataTable)
                Dim row As DataRow = TryCast(GridSelectionView.GetDataRow(GridSelectionView.FocusedRowHandle), DataRow)
                Dim RowHandler As Integer = GridSelectionView.FocusedRowHandle

                Dim TopRowIndex As Integer
                Try
                    TopRowIndex = GridSelectionView.TopRowIndex
                Catch ex As Exception
                    TopRowIndex = -1
                End Try

                If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
                    table.ImportRow(row)
                    row.Delete()
                    Try
                        GridSelectionView.FocusedRowHandle = RowHandler
                    Catch ex As Exception
                        'go to the very end
                        GridSelectionView.FocusedRowHandle = GridSelectionView.RowCount - 1
                    End Try

                    Try
                        GridSelectionView.TopRowIndex = TopRowIndex
                    Catch ex As Exception
                        'go to the very end
                    End Try
                End If

            End If
        End If
    End Sub
    Private Sub GridSelectionView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridSelectionView.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        downHitInfo = Nothing
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left AndAlso hitInfo.RowHandle >= 0 Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub GridSelectionView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridSelectionView.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                Dim row As DataRow = view.GetDataRow(downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub GridSelection_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridSelection.DragDrop
        TransferSelectedRowsInSelGrid(GridSelectedView, GridSelectionView, CType(sender, DevExpress.XtraGrid.GridControl))
    End Sub

    Private Sub GridSelection_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridSelection.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub GridSelected_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridSelected.DragDrop
        TransferSelectedRowsInSelGrid(GridSelectionView, GridSelectedView, CType(sender, DevExpress.XtraGrid.GridControl))
    End Sub

    Sub TransferSelectedRowsInSelGrid(SourceView As DevExpress.XtraGrid.Views.Grid.GridView, DestView As DevExpress.XtraGrid.Views.Grid.GridView, DestGrid As DevExpress.XtraGrid.GridControl)
        Dim tableDest As DataTable = CType(DestGrid.DataSource, DataTable)
        Dim RowHandler As Integer = SourceView.FocusedRowHandle
        Dim row As DataRow
        Dim rowsToDelete As New ArrayList

        Dim TopRowIndex As Integer
        Try
            TopRowIndex = SourceView.TopRowIndex
        Catch ex As Exception
            TopRowIndex = -1
        End Try

        'Transfers all selected row from GridA to GridB
        For i As Integer = 0 To SourceView.SelectedRowsCount - 1
            If SourceView.GetSelectedRows()(i) >= 0 Then
                row = SourceView.GetDataRow(SourceView.GetSelectedRows()(i))
                tableDest.ImportRow(row)
                rowsToDelete.Add(row)

                If i = SourceView.SelectedRowsCount - 1 Then        'if last index of selected rows
                    If DestView.LocateByValue(oReportInfo.SelectionKeyField, row(oReportInfo.SelectionKeyField)) >= 0 Then
                        DestView.FocusedRowHandle = DestView.LocateByValue(oReportInfo.SelectionKeyField, row(oReportInfo.SelectionKeyField))
                    End If
                End If
            End If
        Next
        'Deletes all selected rows from GridA
        For i As Integer = 0 To rowsToDelete.Count - 1
            row = CType(rowsToDelete(i), DataRow)
            row.Delete()
        Next

        'Move focus to last selected row's position
        Try
            SourceView.FocusedRowHandle = RowHandler
        Catch ex As Exception
            'go to the very end
            SourceView.FocusedRowHandle = SourceView.RowCount - 1
        End Try

        'Set Top RowIndex
        Try
            SourceView.TopRowIndex = TopRowIndex
        Catch ex As Exception
            'go to the very end
            SourceView.TopRowIndex = -1
        End Try
    End Sub

    Private Sub GridSelected_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridSelected.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub GridSelectedView_DoubleClick(sender As Object, e As System.EventArgs) Handles GridSelectedView.DoubleClick
        Dim osender As DevExpress.XtraGrid.Views.Grid.GridView
        osender = DirectCast(sender, GridView)
        If osender.FocusedRowHandle >= 0 Then
            Dim p As Point = osender.GridControl.PointToClient(Control.MousePosition)
            Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
            If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then

                Dim table As DataTable = TryCast(GridSelection.DataSource, DataTable)
                Dim row As DataRow = TryCast(GridSelectedView.GetDataRow(GridSelectedView.FocusedRowHandle), DataRow)
                Dim RowHandler As Integer = GridSelectedView.FocusedRowHandle

                Dim TopRowIndex As Integer
                Try
                    TopRowIndex = GridSelectedView.TopRowIndex
                Catch ex As Exception
                    TopRowIndex = -1
                End Try
                If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
                    table.ImportRow(row)
                    row.Delete()
                    Try
                        GridSelectedView.FocusedRowHandle = RowHandler
                    Catch ex As Exception
                        'go to the very end
                        GridSelectedView.FocusedRowHandle = GridSelectedView.RowCount - 1
                    End Try

                    Try
                        GridSelectedView.TopRowIndex = TopRowIndex
                    Catch ex As Exception
                        'go to the very end
                    End Try
                End If

            End If
        End If


    End Sub

    Private Sub GridSelectedView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridSelectedView.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not Control.ModifierKeys = Keys.None Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub GridSelectedView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridSelectedView.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = Windows.Forms.MouseButtons.Left And Not downHitInfo Is Nothing Then
            Dim dragSize = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                Dim row As DataRow = view.GetDataRow(downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

#End Region

#Region "Templates Grid Procedures"

    Public Overrides Sub SaveData()
        '## Description: SAVE TEMPLATE
        CloseCustomLoadScreen()
        If SaveReportTemplate(Me) Then LoadTemplateList(Me)
    End Sub

    Public Overrides Sub DeleteData()
        '## Description: DELETE TEMPLATE
        Dim oTemplate As ReportTemplateDetail = GetSelectedReportDetails()
        If IsNothing(oTemplate) Then
            MsgBox("Please select a template to delete.", MsgBoxStyle.Information)
        Else

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Report Template", 10, System.Environment.MachineName, "Report : " & oReportInfo.Caption & " / Template : " & oTemplate.Name, "Reports") 'neil
            clsAudit.saveAuditPreDelDetails("MSystblRepOptTemplate", oTemplate.PKey, LastUpdatedBy) 'neil

            If DeleteReportTemplate(oTemplate) Then LoadTemplateList(Me)
        End If
    End Sub

    Private Sub GridRepTemplates_DoubleClick(sender As Object, e As System.EventArgs) Handles GridRepTemplates.DoubleClick
        '####################################################################################################################################################################################################################################
        'LOAD TEMPLATE FROM TEMPLATES WHEN DOUBLE CLICKED
        Dim oSender As New GridView
        Try
            oSender = DirectCast(sender, GridView)
            If oSender.FocusedRowHandle >= 0 Then
                Dim p As Point = oSender.GridControl.PointToClient(Control.MousePosition)
                Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
                If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
                    'Load Template
                    LoadSelectedReportTemplate()
                End If
            End If
        Catch ex As Exception
            LogErrors("Failed to load selected template '" & oSender.GetRowCellValue(oSender.FocusedRowHandle, "Name") & "'." & Chr(13) & "Error: " & ex.Message)
            MsgBox("Failed to load selected template '" & oSender.GetRowCellValue(oSender.FocusedRowHandle, "Name") & "'." & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub GridRepTemplates_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridRepTemplates.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = View.CalcHitInfo(New Point(e.X, e.Y))
        If e.Button = Windows.Forms.MouseButtons.Right And hitInfo.RowHandle >= 0 Then
            rightClickMenu.ShowPopup(MousePosition)
        Else
            rightClickMenu.HidePopup()
        End If
    End Sub

    Private Sub GridRepTemplates_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridRepTemplates.RowCellStyle
        If e.RowHandle = GridRepTemplates.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Function GetSelectedReportDetails() As ReportTemplateDetail
        Dim ReturnValue As Object = Nothing
        If GridRepTemplates.FocusedRowHandle >= 0 Then
            If Not IsNothing(GridRepTemplates.GetFocusedRow()) Then
                ReturnValue = New ReportTemplateDetail(IfNull(GridRepTemplates.GetFocusedRowCellValue("PKey"), ""), _
                                                        IfNull(GridRepTemplates.GetFocusedRowCellValue("Name"), ""), _
                                                        IfNull(GridRepTemplates.GetFocusedRowCellValue("Description"), ""),
                                                        IfNull(GridRepTemplates.GetFocusedRowCellValue("Content"), ""))
            End If
        End If
        Return ReturnValue
    End Function

#Region "Load Template"
    Sub LoadSelectedReportTemplate()
        Dim oTemplate As ReportTemplateDetail = GetSelectedReportDetails()
        If IsNothing(oTemplate) Then
            MsgBox("Please select a template to load.", MsgBoxStyle.Information)
        Else
            LoadReportTemplate(Me, oTemplate, oReportInfo.UsePreviewButton)
        End If
    End Sub
#End Region

#End Region

#Region "Apply Filter"
    Private Sub ApplyFilterFromFilterOption(ByVal sender As String, ByVal cFieldName As String, ByVal cCriteria As String) Handles oFilterOption._ApplyFilterToPrintSelectionByFieldName
        '####################################################################################################################################################################################################################################
        'APPLIES FILTER TO SELECTION AND SELECTED GRIDCONTROLS BASED ON PASSED FIELD NAME AND CRITERIA (CONDITION) PARAMETERS
        'THIS EVENT IS HANDLED BY A FILTER OPTION CLASS/CONTROL EVENT
        ApplyFilterToSelection(cFieldName, cCriteria)
    End Sub

    Public Sub ApplyFilterToSelection(ByVal cFieldName As String, ByVal cCriteria As String)
        '####################################################################################################################################################################################################################################
        'APPLIES FILTER TO SELECTION AND SELECTED GRIDCONTROLS BASED ON PASSED FIELD NAME AND CRITERIA (CONDITION) PARAMETERS
        Try
            Dim obj As Object = GridSelectionView.Columns(cFieldName)
            If Not CType(GridSelectionView.Columns(cFieldName), Object) Is Nothing And Not CType(GridSelectedView.Columns(cFieldName), Object) Is Nothing Then
                If cCriteria.ToString.Length > 0 Then
                    GridSelectionView.ActiveFilter.Add(GridSelectionView.Columns(cFieldName), New ColumnFilterInfo(cCriteria))
                    GridSelectedView.ActiveFilter.Add(GridSelectedView.Columns(cFieldName), New ColumnFilterInfo(cCriteria))
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub isFieldInSelectionGridView(ByVal sender As String, ByVal cPrintSelectionFieldName As String, ByRef bReturnValue As Boolean) Handles oFilterOption._isFieldInSelectionGridView
        bReturnValue = True
    End Sub
#End Region

#Region "Clear Procedures"
    Public Sub ClearDataSelection()
        '####################################################################################################################################################################################################################################
        'CLEARS THE DATA SELECTED IN THE GRID SELECTIONS
        Try
            ShowSelectionList()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ClearSelectionListFilter()
        '####################################################################################################################################################################################################################################
        'CLEARS THE FILTER IN THE SELECTION AND SELECTED GRID CONTROLS
        Try
            GridSelectionView.ActiveFilter.Clear()
            GridSelectedView.ActiveFilter.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearSelectionListFilter(ByVal sender As String) Handles oFilterOption._CallClearSelectionListFilter
        '####################################################################################################################################################################################################################################
        'CLEARS THE FILTER IN THE SELECTION AND SELECTED GRID CONTROLS
        'USED AS EVENT FROM FILTER OPTIONS CLASS CONTROL
        ClearSelectionListFilter()
    End Sub

    Public Sub ClearReportList(Optional ByVal ShowErrorMsg As Boolean = False)
        '####################################################################################################################################################################################################################################
        'CLEARS THE REPORT LIST
        Try
            Me.ReportListGrid.DataSource = ""
        Catch ex As Exception
            If ShowErrorMsg Then MsgBox(ex.Message)
        End Try
    End Sub


    'Public Sub ClearTemplateList(Optional ByVal ShowErrorMsg As Boolean = False)
    '    '####################################################################################################################################################################################################################################
    '    'CLEARS THE TEMPLATE LIST
    '    Try
    '        Me.GridTemplates.DataSource = ""
    '    Catch ex As Exception
    '        If ShowErrorMsg Then MsgBox(ex.Message)
    '    End Try
    'End Sub


    Public Sub ClearSortOptions(Optional ByVal ShowErrorMsg As Boolean = False)
        '####################################################################################################################################################################################################################################
        'CLEARS THE SORT OPTIONS CLASS/CONTROL
        Try
            oSortOption.Dispose()
        Catch ex As Exception
            If ShowErrorMsg Then MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ClearSelectionList(Optional ByVal ShowErrorMsg As Boolean = False)
        '####################################################################################################################################################################################################################################
        'CLEARS THE SELECTION AND SELECTED GRID CONTROLS
        Try
            SelectedReport = ""
            GridSelection.DataSource = ""
            GridSelected.DataSource = ""

        Catch ex As Exception
            If ShowErrorMsg Then MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ClearSortOptionsValues(Optional ByVal bResetValuesOnly As Boolean = False, Optional ByVal ShowErrorMsg As Boolean = False)
        '####################################################################################################################################################################################################################################
        'CLEARS THE SORT OPTIONS VALUES, VALUES ARE SET TO 'NONE'
        Try
            If bResetValuesOnly Then
                oSortOption.ResetSortValueAll()
            Else
                oSortOption.ClearSortValueAll()
            End If
            'oSortOption.RefreshData()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ResetOptionsLabels()
        LayoutControlGroup_Filter.Text = FilterRecordsText
        LayoutControlGroup_Sort.Text = SortRecordsText
        LayoutControlGroup_Selection.Text = SelectRecordsText
        LayoutControlGroup_Templates.Text = FilterAndSortTemplatesText
    End Sub
#End Region

    Private Sub BarManager1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarManager1.ItemClick
        Select Case e.Item.Name
            Case "barGenerateReportFromTemplate"
                Dim oTemplate As ReportTemplateDetail = CreateObject_ReportTemplateDetail(GridRepTemplates.GetFocusedDataRow)
                If Not IsNothing(oTemplate) Then
                    If oTemplate.PKey.Length > 0 Then
                        If oTemplate.SaveOptions.SelectedData.Selected Then
                            GenerateReportFromTemplate(oTemplate.PKey, ReportOutputMode.Preview)
                        Else
                            MsgBox("Cannot generate a report from this template because it has no selected data.", MsgBoxStyle.Information)
                        End If
                    Else
                        MsgBox("No template selected.", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("No template selected.", MsgBoxStyle.Information)
                End If
        End Select
    End Sub
End Class


'MsgBox(System.Diagnostics.Debugger.IsAttached) = true 
'if in debug mode