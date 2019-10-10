Imports MPS4
Imports Utilities
Imports System.Windows.Forms
Imports DevExpress.XtraReports
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraReports.UI
Imports Reports
Imports System.Drawing

Public Class KPI

#Region "Properties"
    Protected ReadOnly Property ResultOnly As Boolean
        Get
            Return (SplitContainerControl_Selection_Result.PanelVisibility <> DevExpress.XtraEditors.SplitPanelVisibility.Both)
        End Get
    End Property
#End Region

#Region "Layout Contants"
    Private Const Layout_S1 = 395
    Private Const Layout_S2 = 287
#End Region

#Region "Version History"
    Private Const KPIVersion As String = "1.2.2"
    '<Ver. 1.1.0> - Initial
    '<Ver. 1.1.1> - Added Filter Options
    '             - Removed Principal, Fleet filter from main menu bar
    '<Ver. 1.2.0> - Modified KPI Chart Result
    '             - Added Color Palette and Chart View Changing
    '<Ver. 1.2.1> - Added KPI Popup Result form
    '<Ver. 1.2.2> - Modified KPI Details to show formulas as images
    '             - Modified KPI Popup Result form. Allow Minimize and Maximize
    '<Ver. 2.0>   - Uses dynamic SelectionListing and Period
    '<Ver. 2.0.1> - Modified displaying of Period and Grouped By Column
#End Region

#Region "Declarations"
    Public WithEvents oFilterOption As New Reports.BaseFilterOption
    Public oKPIDetail As New KPIDetail
    Public TemplateGroup As String = "KPI"
    Public CascadeDateCoverageOnUpdate As Boolean = True

    Private dtKPIType As New DataTable
    Private dtSelectionListing As New DataTable
    Dim bHasSelectedKPI As Boolean = False
    Private SELECTED_CHART_VIEW As ChartView = ChartView.SimpleBar
    Private SELECTED_COLOR_PALETTE As String = ""

    Dim extAssembly As System.Reflection.Assembly

    Private Const SetDateCoverageText As String = "2. Set Date Coverage"
    Private Const SelectDataText As String = "3. Select"
    Private FilterOptionParam As String = ""

    Private FLOATING_DATA As New FloatingKPIValue
    Private isUpdateFloatingData As Boolean = True

    Private WithEvents timer As New Windows.Forms.Timer
    Dim timerCounter As Integer

    Dim clsAudit As New clsAudit 'neil
    Dim LastUpdatedBy As String

    Structure KPIType
        Public Const BIMCO As String = "SYSKPIBIMCO"
        Public Const MPS As String = "SYSKPIMPS"
    End Structure

    Enum ChartView
        SimpleBar = 1
        SimpleLine = 2
        SimplePie = 3
        SimpleArea = 4
    End Enum

    Structure ChartViewName
        Public Const Area As String = "Area"
        Public Const Bar As String = "Bar"
        Public Const Line As String = "Line"
        Public Const Pie As String = "Pie"
    End Structure

    Structure SelectionListing
        Public Const Vessel As String = "Vessel"
        Public Const Principal As String = "Principal"
    End Structure



#End Region

#Region "Classes"
    'Public Class Period
    '    Public Annual As New PeriodRange
    '    Public Monthly As New PeriodRange
    '    Public Quarterly As New PeriodRange

    '    Public Class PeriodRange
    '        Public RangeFrom As Object = Nothing
    '        Public RangeTo As Object = Nothing
    '    End Class
    'End Class
#End Region
#Region "Main"

    Public Overrides Sub RefreshData()
        OpenReportWaitForm()
        If Not bLoaded Then
            MyBase.RefreshData()
            InitControls()

            '####################################################################################################################################################################################################################################
            GridKPIView.OptionsSelection.EnableAppearanceFocusedRow = False

            '####################################################################################################################################################################################################################################
            'CLEARS THE CONTENT OF THE CHART
            clearChart(MainChart)

            '####################################################################################################################################################################################################################################
            'INITIALIZES THE CONTENT OF THE SELECTION GRID (SET TO BLANK)
            InitSelectionList("", True, True, True)

            bLoaded = True

        Else
            If Not GridKPIView.OptionsSelection.EnableAppearanceFocusedRow Then GoTo EXIT_SUB 'Make sure than an actual KPI row is selected
            If GridKPIView.FocusedRowHandle < 0 Then GoTo EXIT_SUB

            '####################################################################################################################################################################################################################################
            oKPIDetail = New KPIDetail

            '####################################################################################################################################################################################################################################
            'REFRESH PERIOD (DATE COVERAGE)
            InitPeriodControls()

            '####################################################################################################################################################################################################################################
            'REFRESH SELECTION LISTING
            InitSelectionList(GetFocusedKPIData("SelectionListing"), GetFocusedKPIData("isMultiSelection", 0), GetFocusedKPIData("CanChangeSelectionListing", 0), GetFocusedKPIData("ShowCrewInSelectionListing", 0))

            '####################################################################################################################################################################################################################################
            'REFRESH KPI DETAIL CLASS - KPI IDENTITY
            RefreshKPIDetail()

            If Not oKPIDetail Is Nothing Then
                If Not oKPIDetail.KPICode Is Nothing Then
                    RefreshTemplateButtons(RefreshTemplateButtonsMode.KPISelected)
                End If
            End If

            LoadTemplateList(Me)
        End If

EXIT_SUB:
        CloseReportWaitForm()
    End Sub

    Private Sub InitControls()
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl2.AllowCustomization = False
        Me.LayoutControl3.AllowCustomization = False
        Me.LayoutControl4.AllowCustomization = False
        Me.LayoutControl5.AllowCustomization = False
        Me.LayoutControl6.AllowCustomization = False
        Me.LayoutControl7.AllowCustomization = False

        '####################################################################################################################################################################################################################################
        'INITIALIZE RIBBON PAGE
        Dim oList As New List(Of String)
        oList.Add(ReportOptionsPageGroup.KPIViewingOptions)
        oList.Add(ReportOptionsPageGroup.KPIDisplayOptions)
        oList.Add(RibbonControlReportPage.KPI)
        SetRibbonPageGroupVisibility(Name, oList, True)

        RefreshTemplateButtons(RefreshTemplateButtonsMode.Init)

        '####################################################################################################################################################################################################################################
        ''CREATES THE SOURCE OF KPI TYPE DROPDOWN LIST
        LoadDataSource_KPIType(cboKPIType)

        '####################################################################################################################################################################################################################################
        ''GENERATE KPI LIST DATA SOURCE
        repKPIPeriod.DataSource = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmkpiperiod ORDER BY Name")
        repPeriod.DataSource = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmkpiperiod ORDER BY sortcode")

        'Dim cSQL As String = "SELECT    dbo.FN_ToTitleCase(KPI.Name) as [KPIName], " & _
        '                     "          KPI.*, " & _
        '                     "          CASE WHEN LEN(isnull(Category,'')) > 0 THEN Category ELSE 'Uncategorized' END as CategoryLabel, " & _
        '                     "          CASE WHEN LEN(isnull(SelectionListing,'')) > 0 THEN concat('By ', SelectionListing) ELSE '' END as SelectionListingLabel " & _
        '                     "FROM	    dbo.tblKPI KPI LEFT JOIN " & _
        '                     "		    dbo.tblAdmKPIPeriod period ON KPI.FKeyPeriod = period.PKey " & _
        '                     "WHERE     ShowInGenerateList = 1 " & _
        '                     "		    ORDER BY KPI.SortCode, KPI.Name"
        Dim cSQL As String = "SELECT    dbo.FN_ToTitleCase(KPI.Name) as [KPIName], " & _
                             "          CASE WHEN LEN(isnull(Category,'')) > 0 THEN Category ELSE 'Uncategorized' END as CategoryLabel, " & _
                             "          CASE WHEN LEN(isnull(SelectionListing,'')) > 0 AND CanChangeSelectionListing = 0 THEN concat('By ', SelectionListing) ELSE '' END as SelectionListingLabel, " & _
                             "          CASE WHEN LEN(isnull(FKeyPeriod,'')) > 0 AND CanChangeFKeyPeriod = 0 THEN period.Name ELSE '' END as PeriodLabel, " & _
                             "          KPI.* " & _
                             "FROM		dbo.tblKPI KPI LEFT JOIN " & _
                             "			dbo.tblAdmKPIPeriod period ON KPI.FKeyPeriod = period.PKey " & _
                             "WHERE     ShowInGenerateList = 1 " & _
                             "ORDER BY	KPI.SortCode, KPI.Name"

        Dim dt As DataTable = MPSDB.CreateTable(cSQL)
        GridKPI.DataSource = dt

        'GROUP KPI LIST BY SELECTION LISTING
        GridKPIView.Columns("CategoryLabel").Group()
        GridKPIView.ExpandAllGroups()

        ''FILTER KPI UNDER SELECTED KPI TYPE
        'Dim filterinfo As String
        'filterinfo = "KPIType = '" & cboKPIType.EditValue & "'"
        'GridKPIView.ActiveFilter.Add(GridSelectionListView.Columns("KPIType"), New ColumnFilterInfo(filterinfo))

        '####################################################################################################################################################################################################################################
        'FILTER KPI TYPE TO DEFAULT SELECTION - MPS 
        cboKPIType.EditValue = KPIType.MPS

        '####################################################################################################################################################################################################################################
        ''GENERATE DATE COVERAGE TYPE DATA SOURCE
        cboDateCoverageType.Properties.DataSource = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmkpiperiod WHERE PKey IN ('SYSKPIANNUAL', 'SYSKPIMONTHLY', 'SYSKPIQUARTERLY') ORDER BY Name")
        cboDateCoverageType.Properties.DropDownRows = TryCast(cboDateCoverageType.Properties.DataSource, DataTable).Rows.Count
        
        '####################################################################################################################################################################################################################################
        ''GENERATE SELECTION TYPE DATA SOURCE
        dtSelectionListing = MPSDB.CreateTable("EXEC dbo.KPI_GenerateSelectionList 'LOOKUPEDIT_DATASOURCE', 0")
        
        '####################################################################################################################################################################################################################################
        ''GENERATE SELECTION LIST DATA SOURCE
        KPIRefreshSelectionList()

        '####################################################################################################################################################################################################################################
        'INITIALIZE FILTER CONTROL
        InitFilterOption()

        '####################################################################################################################################################################################################################################
        'INITIALIZES KPI-RELATED CONTROLS FROM THE MAIN FORM
        RaiseCustomEvent(Name, New Object() {"SetupKPIControls"})
    End Sub

#Region "Templates Buttons"
    Enum RefreshTemplateButtonsMode
        Init = 0
        KPISelected = 1
        Refresh = 2
        Load = 3
        Save = 4
        Delete = 5
    End Enum
    Sub RefreshTemplateButtons(Mode As RefreshTemplateButtonsMode)
        Select Case Mode
            Case RefreshTemplateButtonsMode.Init
                'button: show/hide templates
                SetKPIShowTemplateVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetKPIShowTemplateCaption(Name, "Show Templates")
                AllowShowHideTemplate(Name, False)

                'button: save
                SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetSaveCaption(Name, "Save Template")
                AllowSaving(Name, False)

                'button: delete
                SetDeleteTemplateVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetDeleteCaption(Name, "Delete Template")
                AllowDeletion(Name, False)

                'button: load
                SetLoadDataVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                AllowLoadingTemplate(Name, False)

                'templates
                ShowHideTemplate(False)

            Case RefreshTemplateButtonsMode.KPISelected
                AllowShowHideTemplate(Name, True)
                AllowSaving(Name, True)
                'AllowDeletion(Name, True)
                'AllowLoadingTemplate(Name, True)
                AllowDeletion(Name, (LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always))
                AllowLoadingTemplate(Name, (LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always))

            Case RefreshTemplateButtonsMode.Refresh, RefreshTemplateButtonsMode.Load, RefreshTemplateButtonsMode.Save
                'SetKPIShowTemplateCaption(Name, "Show Templates")
                AllowShowHideTemplate(Name, True)
                AllowSaving(Name, True)
                'AllowDeletion(Name, False)
                'AllowLoadingTemplate(Name, False)
                AllowDeletion(Name, (LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always))
                AllowLoadingTemplate(Name, (LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always))

                'ShowHideTemplate(False)

        End Select
    End Sub
#End Region

    Sub LoadDataSource_KPIType(ByRef obj As DevExpress.XtraEditors.LookUpEdit)
        Dim ccolumn As DataColumn

        dtKPIType = New DataTable
        Try
            dtKPIType = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmkpitype ORDER BY SortCode")
        Catch ex As Exception

        End Try

        If dtKPIType.Rows.Count = 0 Then
            ccolumn = New DataColumn
            ccolumn.ColumnName = "PKey"
            ccolumn.DataType = System.Type.GetType("System.String")
            dtKPIType.Columns.Add(ccolumn)
            ccolumn = New DataColumn
            ccolumn.ColumnName = "Name"
            ccolumn.DataType = System.Type.GetType("System.String")
            dtKPIType.Columns.Add(ccolumn)
            dtKPIType.Rows.Add(New Object() {KPIType.MPS, "MPS"})
            dtKPIType.Rows.Add(New Object() {KPIType.BIMCO, "BIMCO"})
        End If

        cboKPIType.Properties.DataSource = dtKPIType
        'cboKPIType.EditValue = KPIType.MPS
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "PRINTCHART"
                PrintChart()

            Case "GENERATERESULT"
                GenerateResult()

            Case "SETCHARTVIEW"
                setChartViewValue(param(1))

            Case "CHANGECHARTVIEW"
                ChangeChartView(param(1))

            Case "CLEARCHART"
                Try
                    ClearChart(MainChart)
                Catch ex As Exception
                    MsgBox("Unable to clear chart. Please try again." & Chr(13) & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Information)
                End Try

            Case "CLEARFILTER"
                oFilterOption.ClearFilterValueAll()
                ClearSelectionListFilter()

            Case "SHOWRESULTONLY"
                ShowResultOnly(param(1))

            Case "SETCOLORPALETTE"
                SELECTED_COLOR_PALETTE = Trim(IfNull(param(1), ""))

            Case "CHANGECHARTCOLORPALETTE"
                SELECTED_COLOR_PALETTE = Trim(IfNull(param(1), ""))
                ChangeChartColorPalette(SELECTED_COLOR_PALETTE)
                SaveUserSetting("KPIColorPalette", SELECTED_COLOR_PALETTE)

            Case "SHOWTEMPLATES"
                ShowHideTemplate(True)

            Case "HIDETEMPLATES"
                ShowHideTemplate(False)

            Case "LOADTEMPLATE"
                LoadSelectedReportTemplate()

        End Select
    End Sub

    Public Overrides Function GetObjectFromMainContent(param() As Object) As Object
        Dim ReturnValue As Object = Nothing
        Select Case param(0)
            Case "RESULTONLY"
                ReturnValue = ResultOnly
        End Select

        Return ReturnValue
    End Function

    Private Sub ShowResultOnly(Optional ByVal isResultOnly As Boolean = True)
        Dim cBtnCaption As String = ""
        If isResultOnly Then
            SplitContainerControl_Selection_Result.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
            SplitContainerControl_KPIList_Selection_Result.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2

            LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            SplitContainerControl_Selection_Result.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
            SplitContainerControl_KPIList_Selection_Result.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both

            GetRibbonControlItemCaptionFromCrewMain(Name, "barKPIShowHideTemplates", cBtnCaption)
            If cBtnCaption.Equals("Show Templates") Then
                LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            ElseIf cBtnCaption.Equals("Hide Templates") Then
                LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If
        End If
    End Sub

    Private Sub ShowHideTemplate(ByVal isShow As Boolean)
        'PROCEED TO SHOW
        If isShow Then
            LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            SplitterItem_Template.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            AllowLoadingTemplate(Name, True)
            AllowDeletion(Name, True)

        Else
            LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            SplitterItem_Template.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            AllowLoadingTemplate(Name, False)
            AllowDeletion(Name, False)

        End If
    End Sub

    Private Sub cboPeriodTo_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPeriodTo.EditValueChanged
        If IsNothing(cboPeriodFrom.EditValue) Then
            If CascadeDateCoverageOnUpdate Then cboPeriodFrom.EditValue = cboPeriodTo.EditValue
        End If

        If isUpdateFloatingData Then FLOATING_DATA.DateCoverage.SetPeriodRange(cboDateCoverageType.EditValue, Period.FromTo._To, cboPeriodTo.EditValue)
    End Sub

    Private Sub cboPeriodFrom_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPeriodFrom.EditValueChanged
        If IsNothing(cboPeriodTo.EditValue) Then
            If CascadeDateCoverageOnUpdate Then cboPeriodTo.EditValue = cboPeriodFrom.EditValue
        End If

        If isUpdateFloatingData Then FLOATING_DATA.DateCoverage.SetPeriodRange(cboDateCoverageType.EditValue, Period.FromTo._From, cboPeriodFrom.EditValue)

    End Sub
#End Region

#Region "Connected to Main Form"

    '## Description: Can be used as function to communicate with frmCrewMain to get values from the KPI form
    Public Overrides Function KPIGetMainFormCtlObject(ByVal cControlName As String, Optional ByVal param() As Object = Nothing)
        Dim cCriteria As String = ""
        Dim retval = Nothing

        Select Case cControlName
            Case "repKPIChartView"
                ''RETURNS CHART VIEW CONTROL DATA SOURCE
                retval = New DataTable
                retval = GetKPIChartTable()

            Case "DEFAULT_LOOKUP_CHARTVIEW"
                ''RETURNS VALUE AS DEFAULT VALUE FOR CHART VIEW LOOKUP EDIT CONTROL
                Dim selectedFromMenu As Integer
                If param Is Nothing Then
                    selectedFromMenu = ChartView.SimpleBar
                Else
                    If param.Count > 0 Then
                        selectedFromMenu = param(0)
                    Else
                        selectedFromMenu = ChartView.SimpleBar
                    End If
                End If

                If Not oKPIDetail Is Nothing Then
                    If Not oKPIDetail.KPICode Is Nothing Then
                        If oKPIDetail.KPICode.Length > 0 Then
                            If oKPIDetail.AllowedChartViewList.Count > 0 Then
                                If oKPIDetail.AllowedChartViewList.Contains(selectedFromMenu) Then
                                    retval = selectedFromMenu
                                Else
                                    retval = oKPIDetail.DefaultChartView
                                End If
                            Else
                                retval = oKPIDetail.DefaultChartView
                            End If
                        End If
                    End If
                End If

                If retval Is Nothing Then
                    retval = CInt(IfNull(KPI.ChartView.SimpleBar, 0))
                Else
                    If retval.ToString.Length = 0 Then
                        retval = CInt(IfNull(KPI.ChartView.SimpleBar, 0))
                    End If
                End If

            Case "repKPIColorPalette"
                retval = New DataTable
                retval.Columns.Add("Name", Type.GetType("System.String"))

                Dim oChart As New DevExpress.XtraCharts.ChartControl
                Dim arrColorPaletteList() As String = oChart.PaletteRepository.PaletteNames()

                For i As Integer = 0 To arrColorPaletteList.GetUpperBound(0)
                    retval.Rows.Add({arrColorPaletteList(i)})
                Next

            Case "SELECTED_CHART_VIEW"

                retval = SELECTED_CHART_VIEW

        End Select
        Return retval
    End Function

#End Region

#Region "Date Coverage"
    '### Description: Initializes the From and To dropdown lists based on the period of the selected KPI
    Private Sub InitPeriodControls()
        Dim dtPeriod As DataTable = Nothing

        Try
            If GetFocusedKPIData("NeedDateCoverage") = True Then 'And Not IfNull(GetFocusedKPIData("FKeyPeriod"), "").Equals("") Then
                LayoutControlGroup_DateCoverage.Text = SetDateCoverageText
                LayoutControlGroup_DateCoverage.Enabled = True
            Else
                LayoutControlGroup_DateCoverage.Text = SetDateCoverageText & " - NOT APPLICABLE TO THIS KPI"
                LayoutControlGroup_DateCoverage.Enabled = False
                Exit Sub
            End If

            LayoutControlItem_From.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem_To.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            If Not IfNull(GetFocusedKPIData("FKeyPeriod"), "").Equals("") And LayoutControlGroup_DateCoverage.Enabled Then
                If cboDateCoverageType.EditValue <> GetFocusedKPIData("FKeyPeriod") Then
                    cboDateCoverageType.EditValue = GetFocusedKPIData("FKeyPeriod")
                End If
            End If

            cboDateCoverageType.Properties.ReadOnly = Not IfNull(CBool(GridKPIView.GetFocusedRowCellValue("CanChangeFKeyPeriod")), False)

        Catch ex As Exception

        End Try
    End Sub

    Sub RecheckDateCoverageEditValue()
        'VALIDATES EDITVALUES OF cboFrom and cboTo
        With cboPeriodFrom
            Try
                Dim dtPeriod As DataTable = TryCast(.Properties.DataSource, DataTable)
                If dtPeriod.Rows.Count > 0 Then
                    If dtPeriod.Select("Period = " & .EditValue).Count = 0 Then
                        .EditValue = Nothing
                    End If
                End If
            Catch ex As Exception
                .EditValue = Nothing
            End Try
        End With


        With cboPeriodTo
            Try
                Dim dtPeriod As DataTable = TryCast(.Properties.DataSource, DataTable)
                If dtPeriod.Rows.Count > 0 Then
                    If dtPeriod.Select("Period = " & .EditValue).Count = 0 Then
                        .EditValue = Nothing
                    End If
                End If
            Catch ex As Exception
                .EditValue = Nothing
            End Try
        End With
    End Sub

    Public Sub SetDateCoverageValue(ByVal ControlName As String, ByVal Value As Object, Optional ByVal bCascadeDateCoverageOnUpdate As Boolean = True)
        CascadeDateCoverageOnUpdate = bCascadeDateCoverageOnUpdate
        Select Case ControlName
            Case KPIDateCoverageParam.PeriodFrom
                cboPeriodFrom.EditValue = Value

            Case KPIDateCoverageParam.PeriodTo
                cboPeriodTo.EditValue = Value

            Case KPIDateCoverageParam.DateAsOf
                dateAsOf.EditValue = Value
        End Select

        'Reset CascadeDateCoverageOnUpdate variable
        CascadeDateCoverageOnUpdate = True
    End Sub

    '## Description: Checks if Date Coverage is valid, may return message if entries are invalid
    Private Function isValidDateCoverage(Optional bShowMsg As Boolean = False) As Boolean
        Dim bRetval As Boolean = False
        Dim cMsgbox As String = ""

        Try
            If Not cboPeriodFrom.EditValue Is Nothing And Not cboPeriodTo.EditValue Is Nothing Then
                If cboPeriodFrom.EditValue.ToString.Length > 0 And cboPeriodTo.EditValue.ToString.Length > 0 Then
                    If cboPeriodFrom.EditValue > cboPeriodTo.EditValue Then
                        cMsgbox = "Start Coverage Date must not be earlier than the End Coverage Date."
                    Else
                        bRetval = True
                    End If
                Else
                    cMsgbox = "Please specify the Date Coverage."
                End If

            Else
                cMsgbox = "Please specify the Date Coverage."
            End If


        Catch ex As Exception
            cMsgbox = "Unable to validate date coverage. Please check your entries and try again."
        End Try

        If cMsgbox.Length > 0 And bShowMsg Then
            MsgBox(cMsgbox, MsgBoxStyle.Exclamation)
        End If

        Return bRetval
    End Function
#End Region

#Region "Selection"
    '## Description: THIS INITIALIZES THE SELECTION GRID LISTING - WHETHER PER VESSEL OR PER PRINCIPAL
    Public Sub InitSelectionList(ByVal cSelectionListing As String, ByVal bMultiSelection As Boolean, ByVal canChangeSelection As Boolean, bShowCrewSelection As Boolean)
        'Dim cCaption As String = ""

        UpdateSelectionTypeSource(cSelectionListing, canChangeSelection, bShowCrewSelection)
        If IfNull(cSelectionListing, "").Equals("") Then
            'EXIT IF THERE IS NO SELECTION LISTING DEFINED
            '   THE PREVIOUSLY SELECTED SELECTION LISTING TYPE REMAINS
            Exit Sub
        Else
            'IF THERE IS A SELECTION LISTING DEFINED
            If oKPIDetail Is Nothing Then
                Exit Sub
            Else
                If cSelectionListing = oKPIDetail.SelectionListing And bMultiSelection = oKPIDetail.MultiSelection Then
                    Exit Sub
                End If
            End If
        End If


        cboSelectionType.EditValue = IIf(cSelectionListing.Length = 0, Nothing, cSelectionListing)
    End Sub

    Sub UpdateSelectionTypeSource(SpecificSelectionListing As String, canChangeSelection As Boolean, isShowCrewSelectionListing As Boolean)
        '********************************************************************************************************************
        'UPDATES THE DATASOURCE OF THE 'SelectionListing' LOOKUPEDIT
        'Rule: if a KPI has a specific SelectionListing defined, the selection will only be generated based on that specific listing
        '      otherwise, all available selection listing (with the exception if crew selection listing is set to be shown or not)

        'Identifiy if the selection will be filtered
        Dim cCondition As String = ""
        If Not IfNull(SpecificSelectionListing, "").Equals("") And Not canChangeSelection Then
            cCondition = "Name = '" & SpecificSelectionListing & "'"

        ElseIf Not isShowCrewSelectionListing Then
            cCondition = "Name <> 'Crew'"
        End If

        'set the selection listing type datasource
        If cCondition.Length > 0 Then
            Dim dv As DataView = New DataView(dtSelectionListing)
            dv.RowFilter = cCondition
            cboSelectionType.Properties.DataSource = dv.ToTable
        Else
            cboSelectionType.Properties.DataSource = dtSelectionListing
        End If

        'change dropdownrows count
        cboSelectionType.Properties.DropDownRows = TryCast(cboSelectionType.Properties.DataSource, DataTable).Rows.Count

        If cboSelectionType.EditValue = "Crew" And _
            Not isShowCrewSelectionListing And _
            SpecificSelectionListing <> "Crew" Then cboSelectionType.EditValue = Nothing
    End Sub

    Sub UpdateSelectionList(ByVal cSelectionListing As String, ByVal bMultiSelection As Boolean)
        Dim cCaption As String = SelectDataText
        If Not cSelectionListing Is Nothing Then
            If cSelectionListing.Length > 0 Then
                cCaption = "3. Select [Selection](s)"

                If cSelectionListing.ToString.Length > 0 Then
                    cCaption = cCaption.Replace("[Selection]", cSelectionListing)
                End If

                'CLEAR THE DATA SOURCE AND COLUMNS OF SELECTION GRID
                GridSelectionList.DataSource = ""
                Try
                    GridSelectionListView.Columns.Clear()
                Catch ex As Exception

                End Try

                'GENRATE THE SELECTION GRID DATA SOURCE
                'Note: Make sure that the datasource contains a 'ColumnKey' and a 'ColumnDisplay' field for the ValueMember and DisplayMember fields, respectively
                Dim dt As DataTable = FLOATING_DATA.SelectedData.GetDataSource(cSelectionListing, bMultiSelection)

                If dt.Rows.Count > 0 Then
                    If dt.Columns.Contains("ColumnKey") And dt.Columns.Contains("ColumnDisplay") Then
                        GridSelectionList.DataSource = dt
                        GenerateSelectionGridColumnsFromDt(GridSelectionListView, dt)
                        GridSelectionListView.Columns("ColumnDisplay").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                        colSelectionName.Caption = cSelectionListing
                    End If

                    GridSelectionListView.ApplyFindFilter("")
                    FLOATING_DATA.SelectedData.ApplySelectedDataToGridView(cSelectionListing, bMultiSelection, GridSelectionListView)

                End If

                GridSelectionListView.OptionsSelection.MultiSelect = bMultiSelection
                If GridSelectionListView.OptionsSelection.MultiSelect Then
                    GridSelectionListView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
                Else
                    GridSelectionListView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect
                End If

                If bMultiSelection Then
                    LayoutControlItem_SelectAll.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    LayoutControlItem_DeselectAll.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Else
                    LayoutControlItem_SelectAll.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    LayoutControlItem_DeselectAll.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                End If

                If Not GridSelectionListView.Columns("ColumnDisplay") Is Nothing Then GridSelectionListView.Columns("ColumnDisplay").OptionsColumn.AllowFocus = False

            Else
                GridSelectionList.DataSource = ""
            End If
        Else
            GridSelectionList.DataSource = ""
        End If

        LayoutControlGroup_Select.Text = cCaption

    End Sub

    '## Description: Refreshes the Selection List
    Public Overrides Sub KPIRefreshSelectionList(Optional cFKeyPrincipal As String = "", Optional cFKeyFleet As String = "", Optional bActiveVesselOnly As Boolean = False)
        Dim filterinfo As String

        GridSelectionListView.ActiveFilter.Clear()

        If Not cFKeyPrincipal Is Nothing Then
            If cFKeyPrincipal.Length > 0 Then
                Select Case oKPIDetail.SelectionListing
                    Case SelectionListing.Vessel
                        filterinfo = "FKeyPrincipal = '" & cFKeyPrincipal & "'"
                        GridSelectionListView.ActiveFilter.Add(GridSelectionListView.Columns("FKeyPrincipal"), New ColumnFilterInfo(filterinfo))

                    Case SelectionListing.Principal
                        filterinfo = "PKey = '" & cFKeyPrincipal & "'"
                        GridSelectionListView.ActiveFilter.Add(GridSelectionListView.Columns("PKey"), New ColumnFilterInfo(filterinfo))
                End Select
            End If
        End If

        If Not cFKeyFleet Is Nothing Then
            If cFKeyFleet.Length > 0 Then
                Select Case oKPIDetail.SelectionListing
                    Case SelectionListing.Vessel
                        filterinfo = "FKeyFlt = '" & cFKeyFleet & "'"
                        GridSelectionListView.ActiveFilter.Add(GridSelectionListView.Columns("FKeyFlt"), New ColumnFilterInfo(filterinfo))

                End Select
            End If
        End If

        If bActiveVesselOnly Then
            Select Case oKPIDetail.SelectionListing
                Case SelectionListing.Vessel
                    filterinfo = "VslStat = 1"
                    GridSelectionListView.ActiveFilter.Add(GridSelectionListView.Columns("VslStat"), New ColumnFilterInfo(filterinfo))

            End Select
        End If
    End Sub

    Private Sub GridSelectionListView_DoubleClick(sender As Object, e As System.EventArgs) Handles GridSelectionListView.DoubleClick
        If Not CBool(GetFocusedKPIData("isMultiSelection", 0)) Then GenerateResult()
    End Sub

    Private Sub GridSelectionListView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridSelectionListView.FocusedRowChanged
        Dim oKPISeriesDetail As New KPISeriesDetail
        oKPISeriesDetail.RecordKey = GridSelectionListView.GetRowCellValue(GridSelectionListView.FocusedRowHandle, "ColumnKey")
        oKPISeriesDetail.RecordName = GridSelectionListView.GetRowCellValue(GridSelectionListView.FocusedRowHandle, "ColumnDisplay")

        If Not GridSelectionListView.OptionsSelection.MultiSelect Then FLOATING_DATA.SelectedData.Add(cboSelectionType.EditValue, GetFocusedKPIData("isMultiSelection", 0), oKPISeriesDetail.RecordKey, oKPISeriesDetail.RecordName)
    End Sub

    Private Sub GridSelectionListView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles GridSelectionListView.FocusedRowObjectChanged
        Dim oKPISeriesDetail As New KPISeriesDetail
        oKPISeriesDetail.RecordKey = GridSelectionListView.GetRowCellValue(GridSelectionListView.FocusedRowHandle, "ColumnKey")
        oKPISeriesDetail.RecordName = GridSelectionListView.GetRowCellValue(GridSelectionListView.FocusedRowHandle, "ColumnDisplay")

        If Not GridSelectionListView.OptionsSelection.MultiSelect Then FLOATING_DATA.SelectedData.Add(cboSelectionType.EditValue, GetFocusedKPIData("isMultiSelection", 0), oKPISeriesDetail.RecordKey, oKPISeriesDetail.RecordName)
    End Sub

    Private Sub GridSelectionListView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridSelectionListView.SelectionChanged
        Dim oKPISeriesDetail As New KPISeriesDetail
        oKPISeriesDetail.RecordKey = GridSelectionListView.GetRowCellValue(GridSelectionListView.FocusedRowHandle, "ColumnKey")
        oKPISeriesDetail.RecordName = GridSelectionListView.GetRowCellValue(GridSelectionListView.FocusedRowHandle, "ColumnDisplay")

        If e.Action = System.ComponentModel.CollectionChangeAction.Add And FLOATING_DATA.SelectedData.Enabled Then
            FLOATING_DATA.SelectedData.Add(cboSelectionType.EditValue, GridSelectionListView.OptionsSelection.MultiSelect, oKPISeriesDetail.RecordKey, oKPISeriesDetail.RecordName)
        ElseIf e.Action = System.ComponentModel.CollectionChangeAction.Remove And FLOATING_DATA.SelectedData.Enabled Then
            FLOATING_DATA.SelectedData.Remove(cboSelectionType.EditValue, GridSelectionListView.OptionsSelection.MultiSelect, oKPISeriesDetail.RecordKey, oKPISeriesDetail.RecordName)
        End If
        'DO NOT AUTO-UPDATE FOR NOW
        'If e.Action = System.ComponentModel.CollectionChangeAction.Add Then
        '    oKPIResultGenerator.addChartSeries(MainChart, oKPIDetail, oKPISeriesDetail)
        'ElseIf e.Action = System.ComponentModel.CollectionChangeAction.Remove Then
        '    oKPIResultGenerator.removeChartSeries(MainChart, oKPISeriesDetail.RecordName)
        'End If
    End Sub

    Private Function GetSelectionKeysAsDT() As DataTable
        Dim dt As DataTable = Nothing, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        Dim selectedRows As Integer() = GridSelectionListView.GetSelectedRows()
        For i As Integer = 0 To selectedRows.GetUpperBound(0)
            dt.Rows.Add(New Object() {GridSelectionListView.GetRowCellValue(selectedRows(i), "ColumnKey")})
        Next

        Return dt
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Function GetSelectionAsArrayList() As ArrayList
        Dim Rows As New ArrayList
        Dim r As DataRow
        ' Add the selected rows to the list.
        Dim I As Integer
        For I = 0 To GridSelectionListView.SelectedRowsCount() - 1
            If (GridSelectionListView.GetSelectedRows()(I) >= 0) Then
                r = GridSelectionListView.GetDataRow(GridSelectionListView.GetSelectedRows()(I))
                'Rows.Add(New Object() {r.Item("PKey"), r.Item("Name")})
                Rows.Add(New Object() {r.Item("ColumnKey"), r.Item("ColumnDisplay")})
            End If
        Next

        Return Rows
    End Function

    Sub GenerateSelectionGridColumnsFromDt(ByRef gv As DevExpress.XtraGrid.Views.Grid.GridView, ByRef dt As DataTable)
        '####################################################################################################################################################################################################################################
        'CREATES COLUMNS FOR THE SELECTION/SELECTED LIST
        Dim Column As DevExpress.XtraGrid.Columns.GridColumn
        gv.Columns.Clear()
        For I As Integer = 0 To dt.Columns.Count - 1
            Column = gv.Columns.AddField(dt.Columns(I).ColumnName)
            Column.Name = dt.Columns(I).ColumnName
            Column.Visible = (dt.Columns(I).ColumnName = "ColumnDisplay")
            gv.Columns(Column.Name).OptionsColumn.ReadOnly = True
            gv.Columns(Column.Name).OptionsColumn.AllowMove = False
            gv.Columns(Column.Name).OptionsColumn.AllowSize = False
            gv.Columns(Column.Name).OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False
        Next
    End Sub

#End Region

#Region "Filter"
    Sub InitFilterOption()
        SetFilterOptionEnabled(False)

        ShowFilterOption()
    End Sub

    Sub ShowFilterOption()
        'edited by tony20170323

        oFilterOption = New Reports.BaseFilterOption
        oFilterOption = CreateKPIFilterOption(oKPIDetail)

        If Not oFilterOption Is Nothing Then

            PanelControl_FilterOption.Controls.Add(oFilterOption)
            oFilterOption.Dock = DockStyle.Fill
            oFilterOption.RefreshData()

            SetFilterOptionEnabled(True)
        End If

    End Sub

    Sub SetFilterOptionVisibility(ByVal value As DevExpress.XtraLayout.Utils.LayoutVisibility)
        LayoutControlItem_FilterOption.Visibility = value
    End Sub

    Sub SetFilterOptionEnabled(ByVal value As Boolean)
        LayoutControlGroup_FilterOption.Enabled = value
    End Sub

#Region "Filter Option Control"
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
            With GridSelectionListView
                Dim obj As Object = .Columns(cFieldName)
                If Not CType(.Columns(cFieldName), Object) Is Nothing And Not CType(.Columns(cFieldName), Object) Is Nothing Then
                    If cCriteria.ToString.Length > 0 Then
                        .ActiveFilter.Add(.Columns(cFieldName), New ColumnFilterInfo(cCriteria))
                        .ActiveFilter.Add(.Columns(cFieldName), New ColumnFilterInfo(cCriteria))
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub isFieldInSelectionGridView(ByVal sender As String, ByVal cPrintSelectionFieldName As String, ByRef bReturnValue As Boolean) Handles oFilterOption._isFieldInSelectionGridView
        Dim tmpReturnValue As Boolean = False
        Dim obj As Object = Nothing
        Try
            obj = GridSelectionListView.Columns(cPrintSelectionFieldName)
        Catch ex As Exception
            tmpReturnValue = False
        End Try

        If Not obj Is Nothing Then tmpReturnValue = True

        bReturnValue = tmpReturnValue
    End Sub

    Private Sub ClearSelectionListFilter(ByVal sender As String) Handles oFilterOption._CallClearSelectionListFilter
        '####################################################################################################################################################################################################################################
        'CLEARS THE FILTER IN THE SELECTION AND SELECTED GRID CONTROLS
        'USED AS EVENT FROM FILTER OPTIONS CLASS CONTROL
        ClearSelectionListFilter()
    End Sub

    Public Sub ClearSelectionListFilter()
        '####################################################################################################################################################################################################################################
        'CLEARS THE FILTER IN THE SELECTION GRID CONTROL
        Try
            GridSelectionListView.ActiveFilter.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ClearSelection()

    End Sub

#End Region
#End Region

#Region "KPI Listing"
    Private Sub repKPIType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboKPIType.EditValueChanged
        RefreshKPIList()
        GridKPIView.OptionsSelection.EnableAppearanceFocusedRow = False
    End Sub

    Function GetFocusedKPIData(ByVal FieldName As String, Optional ByVal ValueIfNull As Object = "", Optional ByVal bGetDisplayValue As Boolean = False)
        '### Description : Gets Field Value from the KPI Listing/GridKPI
        Dim ReturnValue As Object = ValueIfNull

        Dim _colvalue As Object = DBNull.Value

        Try
            If bGetDisplayValue Then
                If GridKPIView.GetRowCellValue(GridKPIView.FocusedRowHandle, FieldName).GetType.Name = "Byte[]" Or _
                    GridKPIView.GetRowCellValue(GridKPIView.FocusedRowHandle, FieldName).GetType.Name = "Byte" Then
                    ReturnValue = GridKPIView.GetRowCellDisplayText(GridKPIView.FocusedRowHandle, FieldName)
                Else
                    'ReturnValue = Trim(IfNull(GridKPIView.GetRowCellDisplayText(GridKPIView.FocusedRowHandle, FieldName), ValueIfNull))
                    _colvalue = GridKPIView.GetRowCellDisplayText(GridKPIView.FocusedRowHandle, FieldName)
                    If Not IsNothing(_colvalue) Then
                        If Not _colvalue.Equals(DBNull.Value) Then
                            ReturnValue = Trim(_colvalue)
                        Else
                            ReturnValue = ValueIfNull
                        End If
                    Else
                        ReturnValue = ValueIfNull
                    End If

                End If
            Else
                If GridKPIView.GetRowCellValue(GridKPIView.FocusedRowHandle, FieldName).GetType.Name = "Byte[]" Or _
                    GridKPIView.GetRowCellValue(GridKPIView.FocusedRowHandle, FieldName).GetType.Name = "Byte" Then
                    ReturnValue = GridKPIView.GetRowCellValue(GridKPIView.FocusedRowHandle, FieldName)
                Else
                    'ReturnValue = Trim(IfNull(GridKPIView.GetRowCellValue(GridKPIView.FocusedRowHandle, FieldName), ValueIfNull))
                    _colvalue = GridKPIView.GetRowCellValue(GridKPIView.FocusedRowHandle, FieldName)
                    If Not IsNothing(_colvalue) Then
                        If Not _colvalue.Equals(DBNull.Value) Then
                            ReturnValue = Trim(_colvalue)
                        Else
                            ReturnValue = ValueIfNull
                        End If
                    Else
                        ReturnValue = ValueIfNull
                    End If

                End If
            End If
        Catch ex As Exception
            ReturnValue = ValueIfNull
        End Try

        Return ReturnValue
    End Function

    Private Sub rightClick_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarManager_KPI.ItemClick
        Select Case e.Item.Name
            Case "ViewKPIDetails"
                RefreshKPIDetail()
                Dim frm As New frmKPIDetails(oKPIDetail)
                frm.ShowDialog(Me)

            Case "barGenerateChartFromTemplate"
                GenerateKPIFromTemplate(GridRepTemplates.GetFocusedRowCellValue("PKey"), ReportOutputMode.Preview)
        End Select
    End Sub

    '## Description: Refreshes the KPI Listing based on the selected from the KPI Type dropdown 
    Private Sub RefreshKPIList()
        GridKPIView.ActiveFilter.Clear()

        Dim filterinfo As String
        filterinfo = "KPIType = '" & cboKPIType.EditValue & "'"
        GridKPIView.ActiveFilter.Add(GridSelectionListView.Columns("KPIType"), New ColumnFilterInfo(filterinfo))
        GridKPIView.ExpandAllGroups()

        Dim showPeriod As Boolean = False
        Dim showGroupedBy As Boolean = False

        For i As Integer = 0 To GridKPIView.RowCount - 1

            If Not showGroupedBy Then
                'if atleast one record has a selectionlistinglabel value, set to true
                If Not IfNull(GridKPIView.GetRowCellValue(i, "SelectionListingLabel"), "").Equals("") Then showGroupedBy = True
            End If

            If Not showPeriod Then
                'if atleast one record has a showperiod value, set to true
                If Not IfNull(GridKPIView.GetRowCellValue(i, "PeriodLabel"), "").Equals("") Then showPeriod = True
            End If

            If showGroupedBy And showPeriod Then Exit For
        Next

        colSelectionListing.Visible = showGroupedBy
        colPeriod.Visible = showPeriod

    End Sub

    '## Description: Refreshes the KPI Detail Class
    Private Sub RefreshKPIDetail()
        With GridKPIView
            oKPIDetail = New KPIDetail
            oKPIDetail.KPICode = GetFocusedKPIData("PKey")
            oKPIDetail.Name = GetFocusedKPIData("KPIName")
            oKPIDetail.KPITypeCode = GetFocusedKPIData("KPIType")
            oKPIDetail.KPITypeName = GetKPITypeName(GetFocusedKPIData("KPIType"))
            oKPIDetail.Title.MainTitle = GetFocusedKPIData("KPIName")
            oKPIDetail.Title.SubTitle = GetFocusedKPIData("SubTitle")
            oKPIDetail.Title.FooterNote = GetFocusedKPIData("FooterNote")
            oKPIDetail.AxisLabel.AxisXLabel = GetFocusedKPIData("AxisXLabel")
            oKPIDetail.AxisLabel.AxisYLabel = GetFocusedKPIData("AxisYLabel")
            oKPIDetail.ChartView = ChangeChartViewNameToNum(GetFocusedKPIData("DefaultChartView"))
            SELECTED_CHART_VIEW = ChangeChartViewNameToNum(GetFocusedKPIData("DefaultChartView"))

            oKPIDetail.DateCoverage.Type = GetFocusedKPIData("DateCoverageType")
            If oKPIDetail.DateCoverage.Type = KPIDateCoverageType.FromAndTo Then
                oKPIDetail.DateCoverage.Period._From = cboPeriodFrom.EditValue
                oKPIDetail.DateCoverage.Period._To = cboPeriodTo.EditValue
            ElseIf oKPIDetail.DateCoverage.Type = KPIDateCoverageType.DateAsOf Then
                oKPIDetail.DateCoverage.DateAsOf = dateAsOf.EditValue
            End If
            oKPIDetail.StoredProcedureName = GetFocusedKPIData("StoredProcedureName")
            oKPIDetail.SelectionListing = GetFocusedKPIData("SelectionListing")
            oKPIDetail.MultiSelection = GetFocusedKPIData("isMultiSelection", 0)
            oKPIDetail.MinReq = GetFocusedKPIData("MinReq")
            oKPIDetail.Target = GetFocusedKPIData("Target")
            oKPIDetail.NeedDateCoverage = GetFocusedKPIData("NeedDateCoverage", False)
            oKPIDetail.UsePercentInPieChartView = GetFocusedKPIData("PieView_UsePercentage", False)
            oKPIDetail.Formula.FormulaString = GetFocusedKPIData("Formula", "")
            Try
                oKPIDetail.Formula.FormulaImage = GetFocusedKPIData("FormulaImage", Nothing)
            Catch ex As Exception

            End Try
            oKPIDetail.Period = GetFocusedKPIData("FKeyPeriod", "")
            oKPIDetail.ColorPalette = SELECTED_COLOR_PALETTE
            oKPIDetail.FilterOption = oFilterOption

            'GET EXTRA CONDITION FROM FILTER OPTION
            oKPIDetail.DataSourceCondition = oFilterOption.GetWhereString()

            'GET EXTRA CONDITION IF KPI USES USER-DATA FILTER
            If GetFocusedKPIData("UserDataFilter_AgentField", "").ToString.Length > 0 Or _
                GetFocusedKPIData("UserDataFilter_PrinField", "").ToString.Length > 0 Or _
                GetFocusedKPIData("UserDataFilter_FleetField", "").ToString.Length > 0 Then

                Dim cUserDataFilterString = GetUserFilterString(, GetFocusedKPIData("UserDataFilter_AgentField", ""), GetFocusedKPIData("UserDataFilter_PrinField", ""), GetFocusedKPIData("UserDataFilter_FleetField", ""))

                oKPIDetail.DataSourceCondition = oKPIDetail.DataSourceCondition & IIf(oKPIDetail.DataSourceCondition.Length > 0 And cUserDataFilterString.Length > 0, " AND ", "") & cUserDataFilterString
            End If

            Try
                '-- CHECKS WHAT CHART VIEWS ARE ALLOWED TO BE USED FOR VIEWING
                Dim arrList As New ArrayList
                If GetFocusedKPIData("AllowChartView_Bar", 0) <> 0 Then arrList.Add(ChartView.SimpleBar)
                If GetFocusedKPIData("AllowChartView_Line", 0) <> 0 Then arrList.Add(ChartView.SimpleLine)
                If GetFocusedKPIData("AllowChartView_Area", 0) <> 0 Then arrList.Add(ChartView.SimpleArea)
                If GetFocusedKPIData("AllowChartView_Pie", 0) <> 0 Then arrList.Add(ChartView.SimplePie)

                If arrList.Count = 0 Then
                    'use Bar only as default
                    arrList.Add(ChartView.SimpleBar)
                End If

                oKPIDetail.AllowedChartViewList = arrList
                '-------------------------------------------------------------------------------------------------------------------------------------

                If GetFocusedKPIData("DefaultChartView").ToString.Length > 0 Then
                    oKPIDetail.DefaultChartView = oKPIDetail.DefaultChartView = ChangeChartViewNameToNum(IfNull(GetFocusedKPIData("DefaultChartView"), ""), KPI.ChartView.SimpleBar)
                Else
                    'use Bar as default if not specified
                    oKPIDetail.DefaultChartView = ChartView.SimpleBar
                End If
                '-------------------------------------------------------------------------------------------------------------------------------------

            Catch ex As Exception
                'do nothing
                oKPIDetail.DefaultChartView = ChartView.SimpleBar
            End Try

        End With
    End Sub

    Private Function GetKPITypeName(KPITypeCode As String) As String
        Dim dv As DataView = New DataView(dtKPIType)
        dv.RowFilter = "PKey = '" & KPITypeCode & "'"
        If dv.Count > 0 Then
            Return dv(0)("Name")
        Else
            Return ""
        End If
    End Function

    Private Sub GridKPIView_DoubleClick(sender As Object, e As System.EventArgs) Handles GridKPIView.DoubleClick
        MakeKPISelection()
        GenerateResult(False)
    End Sub

    Private Sub MakeKPISelection()
        If Not bLoaded Then Exit Sub

        GridKPIView.OptionsSelection.EnableAppearanceFocusedRow = True
        bHasSelectedKPI = True
        RefreshData()
    End Sub

    Private Sub GridKPIView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridKPIView.FocusedRowChanged
        If Not bLoaded Then Exit Sub

        RefreshData()
    End Sub

    Private Sub GridKPIView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GridKPIView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            MakeKPISelection()
            RightClickMenu_KPI.ShowPopup(MousePosition)
        Else
            MakeKPISelection()
            RightClickMenu_KPI.HidePopup()
        End If
    End Sub

    Private Sub GridKPIView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridKPIView.PopupMenuShowing
        selectedID = GridKPIView.GetRowCellValue(e.HitInfo.RowHandle, "PKey")
    End Sub

    Private Sub GridKPIView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridKPIView.RowCellStyle
        If GridKPIView.OptionsSelection.EnableAppearanceFocusedRow And e.RowHandle = GridKPIView.FocusedRowHandle And bHasSelectedKPI Then
            e.Appearance.BackColor = System.Drawing.Color.Yellow
        End If
    End Sub

#End Region
#Region "Chart"
    Function getDefaultChartView(Optional selectedFromMenu As ChartView = ChartView.SimpleBar) As Integer
        Dim retval As Object = Nothing

        If Not oKPIDetail.KPICode Is Nothing Then
            If oKPIDetail.KPICode.Length > 0 Then
                If oKPIDetail.AllowedChartViewList.Count > 0 Then
                    If oKPIDetail.AllowedChartViewList.Contains(selectedFromMenu) Then
                        retval = selectedFromMenu
                    Else
                        retval = oKPIDetail.DefaultChartView
                    End If
                Else
                    retval = oKPIDetail.DefaultChartView
                End If
            End If
        End If

        If retval Is Nothing Then
            retval = CInt(IfNull(KPI.ChartView.SimpleBar, 0))
        Else
            If retval.ToString.Length = 0 Then
                retval = CInt(IfNull(KPI.ChartView.SimpleBar, 0))
            End If
        End If

        Return retval
    End Function

    Private Sub setChartViewValue(ByVal ChartView As ChartView)
        Select Case ChartView
            Case KPI.ChartView.SimpleArea, KPI.ChartView.SimpleBar, KPI.ChartView.SimpleLine, KPI.ChartView.SimplePie
                SELECTED_CHART_VIEW = ChartView
            Case Else
                SELECTED_CHART_VIEW = KPI.ChartView.SimpleBar
        End Select
    End Sub

    Private Sub ChangeChartView(ByVal ChartView As ChartView)
        setChartViewValue(ChartView)

        Try
            basKPI.ChangeSeriesView(MainChart, SELECTED_CHART_VIEW, oKPIDetail)

        Catch ex As Exception
            MsgBox("Unable to change chart view. Please try again." & Chr(13) & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub setColorPaletteValue(ByVal cColorPalette As String)
        SELECTED_COLOR_PALETTE = Trim(IfNull(cColorPalette, "Default"))
    End Sub

    Private Sub ChangeChartColorPalette(ByVal cColorPalette As String)
        setColorPaletteValue(cColorPalette)

        Try
            basKPI.changeChartColorPalette(MainChart, SELECTED_COLOR_PALETTE)

        Catch ex As Exception
            MsgBox("Unable to change chart color palette. Please try again." & Chr(13) & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub
#End Region

#Region "Result"
    Private Sub GenerateResult(Optional bShowErrMsg As Boolean = True)
        If GetFocusedKPIData("PKey") = "" Then Exit Sub 'The Grouping Column is the one selected/double clicked

        '##################################################################################################################################################################################################################
        Reports.OpenReportWaitForm()

        'VALIDATE ENTRY PARAMETERS
        If Not ValidatePreGenerate(bShowErrMsg) Then
            'EXIT IF INVALID
            Reports.CloseReportWaitForm()
            Exit Sub
        End If

        '##################################################################################################################################################################################################################
        ''START GENERATE CHART
        Try
            '####################################################################################################################################################################################################################################
            ''REFRESH KPI DETAILS CLASS
            RefreshKPIDetail()

            '####################################################################################################################################################################################################################################
            ''REFRESHES THE KPI CHART VIEW DROPDOWN TO SET THE CHART VIEW TO THE DEFAULT CHART VIEW OF THE SELECTED KPI ITEM
            '                                          SHOW ONLY APPLICABLE VIEW TYPES
            RaiseCustomEvent(Name, New Object() {"RefreshKPIChartViewList"})

            '####################################################################################################################################################################################################################################
            ''GET CHART VIEW TYPE (BAR / LINE / AREA)
            RaiseCustomEvent(Name, New Object() {"SetKPIChartView"}) 'ALWAYS CALL THIS BEFORE CALLING THE generateChart procedure to initialize the SELECTED_CHART_VIEW
            oKPIDetail.ChartView = SELECTED_CHART_VIEW

            '####################################################################################################################################################################################################################################
            ''GENEATE CHART
            Dim Result As New KPIResult(MainChart, oKPIDetail, GetSelectionAsDT(), cboSelectionType.EditValue, cboDateCoverageType.EditValue, cboPeriodFrom.EditValue, cboPeriodTo.EditValue)
            Result.Generate()
            '------------------------------------------------------------------------------------------------------------------------

        Catch ex As Exception
            MsgBox("Unable to generate chart result. Please try again." & Chr(13) & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Information)
        End Try

        '##################################################################################################################################################################################################################

        Reports.CloseReportWaitForm()
    End Sub

    Function GetSelectionAsDT() As DataTable
        Dim dt As New DataTable
        Dim col As New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        Dim selected As Integer() = GridSelectionListView.GetSelectedRows
        For i As Integer = 0 To selected.GetUpperBound(0)
            dt.Rows.Add(New Object() {GridSelectionListView.GetRowCellValue(selected(i), "ColumnKey")})
        Next

        Return dt

    End Function

    Private Function ValidatePreGenerate(Optional bShowErrMsg As Boolean = True) As Boolean
        If Not GridKPIView.OptionsSelection.EnableAppearanceFocusedRow Then
            If bShowErrMsg Then MsgBox("Please select a KPI to generate.", MsgBoxStyle.Exclamation)
            Return False
            Exit Function
        End If

        If GridSelectionListView.SelectedRowsCount = 0 Then
            If bShowErrMsg Then MsgBox("Please select a record/s to generate a KPI with.", MsgBoxStyle.Exclamation)
            Return False
            Exit Function
        End If

        If GetFocusedKPIData("NeedDateCoverage") = True Then
            RecheckDateCoverageEditValue()
            If Not isValidDateCoverage(bShowErrMsg) Then
                'message box is already inside the procedure
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Private Sub GenerateChartFromTemplate()
        Dim oTemplate As ReportTemplateDetail = GetSelectedReportDetails()
        LoadKPITemplate(Me, oTemplate, False)
        GenerateResult()
    End Sub

    Private Sub PrintChart()
        Reports.OpenReportWaitForm()

        Try
            RefreshKPIDetail()

            If MainChart.Titles.Count = 0 Then
                MsgBox("There is no generated chart to print.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Reports.OpenReportWaitForm()
            Dim MainReport As clsRptKPI = New clsRptKPI(MainChart)
            MainReport.OpenReport()
            Reports.CloseReportWaitForm()

        Catch ex As Exception
            MsgBox("Unable to print chart. " & Chr(13) & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Reports.CloseReportWaitForm()
    End Sub

#End Region

#Region "Select/Deselect All"
    Private Sub cmdSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdSelectAll.Click
        SelectDeselectAll(SelectDeselectMode.SelectAll)
    End Sub

    Private Sub cmdDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeselectAll.Click
        SelectDeselectAll(SelectDeselectMode.DeselectAll)
    End Sub

    Enum SelectDeselectMode
        SelectAll = 1
        DeselectAll = 2
    End Enum

    Public Sub SelectDeselectAll(Mode As SelectDeselectMode)
        For i As Integer = 0 To GridSelectionListView.RowCount - 1
            If Mode = SelectDeselectMode.SelectAll Then
                GridSelectionListView.SelectRow(i)

            ElseIf Mode = SelectDeselectMode.DeselectAll Then
                GridSelectionListView.UnselectRow(i)
            End If
        Next
    End Sub

#End Region

#Region "Popup Result"
    Private Sub LayoutControlGroup_Result_DoubleClick(sender As Object, e As System.EventArgs) Handles LayoutControlGroup_Result.DoubleClick
        If Not MainChart Is Nothing Then
            If Not oKPIDetail Is Nothing Then
                If Not oKPIDetail.KPICode Is Nothing Then
                    CreatePopupResult(MainChart, oKPIDetail.Name)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Layout"
    Public Overrides Sub SaveMainContentLayout()
        SaveUserSetting(Me.Name & SplitContainerControl_KPIList_Selection_Result.Name & "_LAYOUT", SplitContainerControl_KPIList_Selection_Result.SplitterPosition.ToString)
        SaveUserSetting(Me.Name & SplitContainerControl_Selection_Result.Name & "_LAYOUT", SplitContainerControl_Selection_Result.SplitterPosition.ToString)
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        SplitContainerControl_KPIList_Selection_Result.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl_KPIList_Selection_Result.Name & "_LAYOUT", Layout_S1))
        SplitContainerControl_Selection_Result.SplitterPosition = CInt(GetUserSetting(Me.Name & SplitContainerControl_Selection_Result.Name & "_LAYOUT", Layout_S2))

    End Sub

    Public Overrides Sub ResetMainContentLayout()
        SplitContainerControl_KPIList_Selection_Result.SplitterPosition = Layout_S1
        SplitContainerControl_Selection_Result.SplitterPosition = Layout_S2
        SaveMainContentLayout()
    End Sub
#End Region

    Private Sub GridRepTemplates_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles GridRepTemplates.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))

        If e.Button = Windows.Forms.MouseButtons.Right And hitInfo.RowHandle >= 0 Then
            RightClickMenu_Templates.ShowPopup(MousePosition)
        Else
            RightClickMenu_Templates.HidePopup()
        End If
    End Sub

    Private Sub GridRepTemplates_RowCellStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridRepTemplates.RowCellStyle

    End Sub

#Region "Template Procedures"
#Region "Load Template"
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

    Sub LoadSelectedReportTemplate()
        Dim oTemplate As ReportTemplateDetail = GetSelectedReportDetails()
        If IsNothing(oTemplate) Then
            MsgBox("Please select a template to load.", MsgBoxStyle.Information)
        Else
            basKPITemplate.LoadKPITemplate(Me, oTemplate)
            RefreshTemplateButtons(RefreshTemplateButtonsMode.Load)
        End If
    End Sub
#End Region

#Region "Save Template"

    Public Overrides Sub SaveData()
        '## Description: SAVE TEMPLATE
        If SaveKPITemplate(Me) Then
            LoadTemplateList(Me)
            RefreshTemplateButtons(RefreshTemplateButtonsMode.Save)
        End If
    End Sub
#End Region

#Region "Delete Template"
    Public Overrides Sub DeleteData()
        '## Description: DELETE TEMPLATE
        Dim oTemplate As ReportTemplateDetail = GetSelectedReportDetails()
        If IsNothing(oTemplate) Then
            MsgBox("Please select a template to delete.", MsgBoxStyle.Information)
        Else

            clsAudit.propSQLConnStr = MPSDB.GetConnectionString

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "KPI Template", 0, System.Environment.MachineName, "Template : " & GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "Name") & " / KPI Name : " & Me.oKPIDetail.Name, "KPI") 'neil
            clsAudit.saveAuditPreDelDetails("MSystblRepOptTemplate", GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

            If DeleteReportTemplate(oTemplate) Then LoadTemplateList(Me)
        End If
    End Sub
#End Region
#End Region

    Private Sub cmdClearDateCoverage_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearDateCoverage.Click
        CascadeDateCoverageOnUpdate = False
        If LayoutControlItem_From.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then cboPeriodFrom.EditValue = Nothing
        If LayoutControlItem_To.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then cboPeriodTo.EditValue = Nothing
        If LayoutControlItem_DateAsOf.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then dateAsOf.EditValue = Nothing
        CascadeDateCoverageOnUpdate = True
    End Sub

    Private Sub cboDateCoverageType_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboDateCoverageType.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            cboDateCoverageType.EditValue = Nothing
        End If
    End Sub

    Private Sub cboDateCoverageType_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboDateCoverageType.EditValueChanged
        UpdatePeriodControls(cboDateCoverageType.EditValue)
    End Sub

    Private Sub UpdatePeriodControls(FKeyPeriod)
        isUpdateFloatingData = False

        cboPeriodFrom.Properties.DataSource = ""
        cboPeriodTo.Properties.DataSource = ""

        cboPeriodFrom.EditValue = Nothing
        cboPeriodTo.EditValue = Nothing

        Dim oPeriodRange As Period.PeriodRange = FLOATING_DATA.DateCoverage.GetPeriodRangeObject(FKeyPeriod)
        Dim DataSource As DataTable = Nothing
        Dim FromEditValue As Object = Nothing
        Dim ToEditValue As Object = Nothing
        Dim DropDownRowsCount As Integer = 0

        If Not IsNothing(oPeriodRange) Then
            DataSource = oPeriodRange.Table
            DropDownRowsCount = oPeriodRange.DropDownRowsCount
            FromEditValue = oPeriodRange.RangeFrom
            ToEditValue = oPeriodRange.RangeTo
        End If

        cboPeriodFrom.Properties.DataSource = DataSource
        cboPeriodFrom.Properties.DropDownRows = DropDownRowsCount
        cboPeriodTo.Properties.DataSource = DataSource
        cboPeriodTo.Properties.DropDownRows = DropDownRowsCount

        LayoutControlItem_From.Text = "From:"
        LayoutControlItem_To.Text = "To:"

        cboPeriodFrom.EditValue = FromEditValue
        cboPeriodTo.EditValue = ToEditValue
        isUpdateFloatingData = True
    End Sub

    Private Sub cboSelectionType_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboSelectionType.EditValueChanged
        UpdateSelectionList(cboSelectionType.EditValue, GetFocusedKPIData("isMultiSelection", False))
    End Sub
End Class