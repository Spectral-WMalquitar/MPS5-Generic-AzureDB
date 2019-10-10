Public Class KPIConfig

    'Public ReportsTable As DataTable
    Public KPITable As DataTable
    Public KPICategoryTable As DataTable
    Public LayoutControlGroups() As DevExpress.XtraLayout.LayoutControlGroup
    Public FocusedKPI As New FocusedKPIClass

    Private SelectionSourceType As New SelectionSourceTypeClass
    Private SortFields As String = ""

    Private Const ReportGroup_ShowAll As String = "<Show All>"

    Private Const FilterOptionSortField As String = "rn"
    Private Const REPORT_GROUP As String = "KPI"

    Private FormulaImage As Byte() = Nothing


#Region "Easy Edit"
    Private FormName As String = "Report Configuration"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
#End Region

#Region "Classes"
    Public Class FocusedKPIClass
        Public PKey As String = ""
        Public KPIType As String = ""
        Public Category As String = ""
        Public Name As String = ""

        Public Sub Refresh(_view As DevExpress.XtraGrid.Views.Grid.GridView)
            PKey = IfNull(_view.GetFocusedRowCellValue("PKey"), "")
            KPIType = IfNull(_view.GetFocusedRowCellValue("KPIType"), "")
            Category = IfNull(_view.GetFocusedRowCellValue("Category"), "")
            Name = IfNull(_view.GetFocusedRowCellValue("Name"), "")
        End Sub

        Public Sub SetFocusedReport(cPKey As String, cKPIType As String, cCategory As String, cName As String)
            PKey = cPKey
            KPIType = cKPIType
            Category = cCategory
            Name = cName
        End Sub

        Public Function GetFocusedReportAsCondition()
            Return "PKey = '" & PKey & "' AND KPIType = '" & KPIType & "' AND Category = '" & Category & "' AND Name = '" & Name & "'"
        End Function

        Public Function HasValue() As Boolean
            Return (Not IfNull(PKey, "").Equals("") And Not IfNull(KPIType, "").Equals("") And Not IfNull(Category, "").Equals("") And Not IfNull(Name, "").Equals(""))
        End Function
    End Class

    Private Class SelectionSourceTypeClass
        Public ItemList As New SelectionSourceType("ITEMLIST", "Item List")
        Public Predef_Ds As New SelectionSourceType("PREDEF_DS", "Predefined DataSource")
        Public Query As New SelectionSourceType("QUERY", "Query")
        Public SQL As New SelectionSourceType("SQL", "SQL")

        Public Class SelectionSourceType
            Public PKey As String = ""
            Public Name As String = ""

            Sub New(cPKey As String, cName As String)
                PKey = cPKey
                Name = cName
            End Sub
        End Class
    End Class
#End Region

#Region "Selection"
    Public Sub SetSelection(_KPIToFocus As FocusedKPIClass)
        Try
            bAddMode = False
            Dim dt As DataTable = GridKPI.DataSource
            Dim dv As DataView = New DataView(TryCast(GridKPI.DataSource, DataTable))
            dv.RowFilter = "Name = '" & _KPIToFocus.Name & "' AND KPIType = '" & _KPIToFocus.KPIType & "' AND Category = '" & _KPIToFocus.Category & "'"
            If dv.Count > 0 Then
                Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridKPIView.Columns("rn")
                Dim rowhandle As Integer = GridKPIView.LocateByValue("rn", dv(0)("rn"))
                GridKPIView.FocusedRowHandle = rowhandle
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "LOADTEMPLATE"
                MsgBox("This function does not apply to this form", MsgBoxStyle.Information)
        End Select
    End Sub

#Region "Refresh"
    Public Overrides Sub RefreshData()
        OpenReportWaitForm()
        MyBase.RefreshData()
        RefreshButtons(ButtonMode.Init)

        If Not bLoaded Then
            InitControls()

            bLoaded = True

            SetAddVisibility(Me.Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetEditVisibility(Me.Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetLoadDataVisibility(Me.Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetDeleteVisibility(Me.Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetKPIShowTemplateVisibility(Me.Name, DevExpress.XtraBars.BarItemVisibility.Never)

            AllowSaving(Me.Name, False)
            AllowDeletion(Me.Name, False)
        End If

        FocusedKPI.Refresh(GridKPIView)

        bAddMode = False
        LoadSub()
        MakeReadOnlyListener(LayoutControlGroups)
        EditSubAllowGrid(Me.GridFilterOptionsView_Addl, False)

        BRECORDUPDATEDs = False

        AddEditListener(LayoutControlGroups)
        CloseReportWaitForm()
    End Sub

    Sub RefreshGridKPI()
        Dim cCondition As New System.Text.StringBuilder
        Dim dv As DataView

        cCondition.Clear()

        If chkShowShownInGenerateListOnly.Checked Then
            cCondition.Append("ShowInGenerateList = 1")
            'Else
            '    cCondition.Append("ShowInGenerateList = 0")
        End If

        Try
            If Not cboKPIType.EditValue Is Nothing Then
                If IfNull(cboKPIType.EditValue, "").ToString.Length > 0 Then
                    If cboKPIType.EditValue <> ReportGroup_ShowAll Then
                        cCondition.Append(IIf(cCondition.Length > 0, " AND ", "") & "KPIType = '" & cboKPIType.EditValue & "'")
                    End If
                End If
            Else
                cCondition.Append(IIf(cCondition.Length > 0, " AND ", "") & "KPIType = 'NONE'")
            End If

            If chkShowShownInGenerateListOnly.Checked Then
                dv = New DataView(KPITable)
                dv.RowFilter = "ShowInGenerateList = 1"
                GridKPI.DataSource = dv.ToTable
            Else
                GridKPI.DataSource = KPITable
            End If

            Dim dt As DataTable = KPITable
            dv = New DataView(dt)
            If cCondition.Length > 0 Then dv.RowFilter = cCondition.ToString
            GridKPI.DataSource = dv.ToTable

            GroupUngroupKPIList()
        Catch ex As Exception
            LogErrors(ex.Message)
        End Try
    End Sub

    Sub EnableMainsButtons(ByVal _value As Boolean)
        cmdAddSave.Enabled = _value
        cmdEditCancel.Enabled = _value
        cmdDelete.Enabled = _value
    End Sub

    Private Sub EnableSelectedFilterOption(FilterOptionType As FilterOptionType)
        LayoutControlGroup_FilterOptionGeneric.Enabled = (FilterOptionType = KPIConfig.FilterOptionType.Generic)
    End Sub

    Private Enum FilterOptionType
        Specific = 1
        Generic = 2
    End Enum

#Region "Button Refresh"
    Private Sub RefreshButtons(ButtonMode As ButtonMode)
        Select Case ButtonMode
            Case KPIConfig.ButtonMode.Add
                cmdAddSave.Text = "Save"
                cmdEditCancel.Text = "Cancel"
                LayoutControlItem_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                EnableSubButtons(True)
                AllowSaving(Me.Name, False)

            Case KPIConfig.ButtonMode.Edit
                cmdAddSave.Text = "Save"
                cmdEditCancel.Text = "Cancel"
                LayoutControlItem_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                isEditdable = True
                EnableSubButtons(True)
                AllowSaving(Me.Name, False)

            Case KPIConfig.ButtonMode.Delete

            Case KPIConfig.ButtonMode.Disable
                RefreshButtons(KPIConfig.ButtonMode.Init)
                EnableMainsButtons(False)

            Case KPIConfig.ButtonMode.Init
                EnableMainsButtons(True)
                cmdAddSave.Text = "Add"
                cmdEditCancel.Text = "Edit"
                LayoutControlItem_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                EnableSubButtons(False)
                AllowSaving(Me.Name, False)

        End Select
    End Sub

    Private Enum ButtonMode
        Add = 1
        Edit = 2
        Delete = 3
        Init = 4
        Disable = 5
    End Enum
#End Region
#End Region

#Region "Initialization"
    Private Sub InitControls()
        LayoutControlGroups = New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup_Main, LayoutControlGroup_KPIDetails, LayoutControlGroup_AdditionalFilterOptions, LayoutControlGroup_MainDetail, LayoutControlGroup_Computation, LayoutControlGroup_StoredProcedureName, LayoutControlGroup_DateCoverage, LayoutControlGroup_DataFilter}
        tabDetails.SelectedTabPageIndex = 0
        chkShowShownInGenerateListOnly.Checked = True
        InitControl_KPIType()
        InitControl_GridKPI()
        InitControl_SelectionListing()
        InitControl_TimePeriod()
        InitControl_ChartView()
        InitControl_DateCoverageType()
        InitControl_FilterOption()
        InitControl_GenerateScript()

        GridFilterOptionsView.OptionsBehavior.ReadOnly = True
    End Sub

    Sub EnableSubButtons(ByVal _value As Boolean)
        cmdDeleteFilterOption.Enabled = _value
        cmdMoveDownFilterOption.Enabled = _value
        cmdMoveUpFilterOption.Enabled = _value
        cmdAddReportGroup.Enabled = _value
        cmdFormulaChange.Enabled = _value
        cmdFormulaRemove.Enabled = _value
    End Sub

    Sub InitControl_KPIType()
        Dim dtKPIType As New DataTable, ccolumn As DataColumn

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
            dtKPIType.Rows.Add(New Object() {KPI.KPIType.MPS, "MPS"})
            dtKPIType.Rows.Add(New Object() {KPI.KPIType.BIMCO, "BIMCO"})
        End If

        Dim objList As New List(Of DevExpress.XtraEditors.LookUpEdit)
        objList.Add(cboKPIType)
        objList.Add(cboKPITypeSelected)

        For Each obj As DevExpress.XtraEditors.LookUpEdit In objList
            With obj.Properties
                .Columns.Clear()
                .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"))
                .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"))
                .Columns("PKey").Visible = False
                .Columns("Name").Visible = True
                .DataSource = dtKPIType
                .ShowHeader = False
                .ShowFooter = False
                .ValueMember = "PKey"
                .DisplayMember = "Name"
                .DropDownRows = dtKPIType.Rows.Count
            End With
        Next

        cboKPIType.EditValue = dtKPIType.Rows(0)("PKey")
    End Sub

    Sub InitControl_GridKPI()
        KPITable = MPSDB.CreateTable("SELECT t.* FROM (SELECT rn = ROW_NUMBER() OVER (ORDER BY kpi.PKey), kpitype.name as KPITypeName, kpi.* FROM dbo.tblkpi kpi INNER JOIN dbo.tbladmkpitype kpitype ON kpi.kpitype = kpitype.pkey) t ORDER BY t.KPITypeName, t.SortCode, t.Name")
        RefreshGridKPI()
    End Sub

    Sub RefreshCategory()
        Dim ccolumn As DataColumn

        KPICategoryTable = New DataTable
        KPICategoryTable = MPSDB.CreateTable("SELECT Category FROM dbo.tblkpi WHERE Category is not null AND KPIType = '" & cboKPITypeSelected.EditValue & "' GROUP BY Category ")

        If KPICategoryTable.Rows.Count = 0 Then
            If KPICategoryTable.Columns.Count = 0 Then
                ccolumn = New DataColumn
                ccolumn.ColumnName = "Category"
                ccolumn.DataType = System.Type.GetType("System.String")
                KPICategoryTable.Columns.Add(ccolumn)
            End If
            KPICategoryTable.Rows.Add(New Object() {"Others"})
        End If

        With cboCategory.Properties
            .Columns.Clear()
            .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "Category"))
            .Columns("Category").Visible = True
            .Columns(0).Visible = True
            .DataSource = KPICategoryTable
            .ShowHeader = False
            .ShowFooter = False
            .DisplayMember = "Category"
            .ValueMember = "Category"
            .DropDownRows = KPICategoryTable.Rows.Count
        End With
    End Sub

    Sub InitControl_GenerateScript()
        Dim dt As New DataTable
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        dt.Rows.Add(New Object() {1, "INSERT Script"})
        dt.Rows.Add(New Object() {2, "UPDATE Script"})
        cboGenerateScript.Properties.DataSource = dt
        cboGenerateScript.Properties.DropDownRows = dt.Rows.Count
    End Sub

    Sub InitControl_SelectionListing()
        Dim dt As New DataTable

        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        dt = MPSDB.CreateTable("EXEC dbo.KPI_GenerateSelectionList 'LOOKUPEDIT_DATASOURCE', 0")
        With cboSelectionListing.Properties
            .Columns.Clear()
            .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"))
            .Columns(0).Visible = True
            .DataSource = dt
            .ShowFooter = False
            .ShowHeader = False
            .DisplayMember = "Name"
            .ValueMember = "Name"
            .DropDownRows = dt.Rows.Count
        End With

        LayoutControlItem_ShowCrewInSelectionListing.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Sub InitControl_TimePeriod()
        Dim dt As New DataTable

        Dim ccolumn As DataColumn

        dt = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmKPIPeriod ORDER BY Name")

        If dt.Rows.Count = 0 Then
            ccolumn = New DataColumn
            ccolumn.ColumnName = "PKey"
            ccolumn.DataType = System.Type.GetType("System.String")
            dt.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = "Name"
            ccolumn.DataType = System.Type.GetType("System.String")
            dt.Columns.Add(ccolumn)
        End If

        With cboTimePeriod.Properties
            .Columns.Clear()
            .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"))
            .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"))
            .Columns("PKey").Visible = False
            .DataSource = dt
            .ShowFooter = False
            .ShowHeader = False
            .ValueMember = "PKey"
            .DisplayMember = "Name"
            .DropDownRows = dt.Rows.Count
        End With
    End Sub

    Sub InitControl_ChartView()
        Dim dt As DataTable = GetKPIChartTable()
        With cboDefaultChartView.Properties
            .Columns.Clear()
            .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"))
            .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"))
            .Columns(0).Visible = False
            .Columns(1).Visible = True
            .DataSource = dt
            .ShowFooter = False
            .ShowHeader = False
            .ValueMember = "PKey"
            .DisplayMember = "Name"
            .DropDownRows = dt.Rows.Count
        End With
    End Sub

    Sub InitControl_DateCoverageType()
        'Dim dt As New DataTable

        'With dt
        '    .Columns.Add("PKey", Type.GetType("System.String"))
        '    .Columns.Add("Name", Type.GetType("System.String"))

        '    With .Rows
        '        .Add({KPIDateCoverageType.FromAndTo, "From and To"})
        '        .Add({KPIDateCoverageType.DateAsOf, "Date As Of"})
        '    End With

        'End With

        'With cboDateCoverageType.Properties
        '    .Columns.Clear()
        '    .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"))
        '    .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"))
        '    .DataSource = dt
        '    .ShowHeader = False
        '    .ShowFooter = False
        '    .ValueMember = "PKey"
        '    .DisplayMember = "Name"
        '    .DropDownRows = dt.Rows.Count
        'End With
        'no longer need DateCoverageType
    End Sub

#End Region

#Region "Load"
    Public Sub LoadSub()
        Dim dt As DataTable = KPITable

        Dim row As DataRow() = dt.Select("PKey = '" & FocusedKPI.PKey & "'")

        If row.Length > 0 Then
            chkShowInGenerateList.Checked = IfNull(row(0).Item("ShowInGenerateList"), 0)
            txtPKey.EditValue = IfNull(row(0).Item("PKey"), "")
            txtName.EditValue = IfNull(row(0).Item("Name"), "")
            cboKPITypeSelected.EditValue = IfNull(row(0).Item("KPIType"), "")
            cboCategory.EditValue = IfNull(row(0).Item("Category"), "")
            txtNbr.EditValue = IfNull(row(0).Item("Nbr"), "")
            txtSortCode.EditValue = IfNull(row(0).Item("SortCode"), 0)
            txtDescription.EditValue = IfNull(row(0).Item("Description"), "")
            txtSubTitle.EditValue = IfNull(row(0).Item("SubTitle"), "")
            txtFooterNote.EditValue = IfNull(row(0).Item("FooterNote"), "")
            cboSelectionListing.EditValue = IfNull(row(0).Item("SelectionListing"), "")
            cboTimePeriod.EditValue = IfNull(row(0).Item("FKeyPeriod"), "")
            cboDefaultChartView.EditValue = CInt(IfNull(ChangeChartViewNameToNum(IfNull(row(0).Item("DefaultChartView"), "")), 0))
            txtMinReq.EditValue = IfNull(row(0).Item("MinReq"), "")
            txtTarget.EditValue = IfNull(row(0).Item("Target"), "")

            txtFormula.EditValue = System.DBNull.Value
            imgFormula.Image = Nothing
            If Not IsDBNull(row(0).Item("FormulaImage")) Then  'Formula Image
                Dim imageData As Byte() = DirectCast(row(0).Item("FormulaImage"), Byte())

                If Not imageData Is Nothing Then
                    Using ms As New System.IO.MemoryStream(imageData, 0, imageData.Length)
                        ms.Write(imageData, 0, imageData.Length)
                        Try
                            imgFormula.Image = System.Drawing.Image.FromStream(ms, True)
                        Catch
                        End Try
                    End Using

                    FormulaImage = imageData
                Else
                    FormulaImage = Nothing
                End If

            End If
            txtFormula.EditValue = IfNull(row(0).Item("Formula"), "")
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            txtAxisXLabel.EditValue = IfNull(row(0).Item("AxisXLabel"), "")
            txtAxisYLabel.EditValue = IfNull(row(0).Item("AxisYLabel"), "")
            txtStoredProcedureName.EditValue = IfNull(row(0).Item("StoredProcedureName"), "")
            isNeedDateCoverage.Checked = IfNull(row(0).Item("NeedDateCoverage"), 0)
            'cboDateCoverageType.EditValue = IfNull(row(0).Item("DateCoverageType"), "")
            'no longer need DateCoverageType
            chkUserPercentage.Checked = IfNull(row(0).Item("PieView_UsePercentage"), 0)
            isMultiSelection.Checked = IfNull(row(0).Item("isMultiSelection"), 0)

            txtAgentFieldName.EditValue = IfNull(row(0).Item("UserDataFilter_AgentField"), "")
            txtPrinFieldName.EditValue = IfNull(row(0).Item("UserDataFilter_PrinField"), "")
            txtFleetFieldName.EditValue = IfNull(row(0).Item("UserDataFilter_FleetField"), "")

            chkShowCrewInSelectionListing.Checked = IfNull(row(0).Item("ShowCrewInSelectionListing"), 0)
            chkCanChangeSelectionListing.Checked = IfNull(row(0).Item("CanChangeSelectionListing"), 0)
            chkCanChangeFKeyPeriod.Checked = IfNull(row(0).Item("CanChangeFKeyPeriod"), 0)

            UpdSelectionListing()

        Else
            ClearFields_Recursive(LayoutControlGroups, False)
        End If

        LoadFilterOptions()

    End Sub

    Sub InitControl_FilterOption()
        Dim dt As DataTable = MPSDB.CreateTable("SELECT cast(0 as bit) as isEdited, * FROM dbo.MSysAdmFilterOption ORDER BY ObjectID")
        repFilterOption.DataSource = dt
        repFilterOption_Addl.DataSource = dt
    End Sub

    Sub LoadFilterOptions()
        Dim dt As DataTable

        Dim cSQL As String

        'DEFAULT FILTER OPTIONS
        cSQL = "SELECT Cast(0 as bit) as Edited, rn = ROW_NUMBER() OVER (ORDER BY SortCode, Caption), * FROM dbo." & tblNameReportsOptions & " WHERE FKeyReportObjectID = '" & REPORT_GROUP & "' AND ReportGroup = '" & REPORT_GROUP & "'"

        dt = New DataTable
        dt = MPSDB.CreateTable(cSQL)
        If dt.Rows.Count > 0 Then
            GridFilterOptions.DataSource = dt
        Else
            GridFilterOptions.DataSource = InitializeGridFilterOptionDT()
        End If

        GridFilterOptionsView.Columns("rn").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        GridFilterOptionsView.OptionsCustomization.AllowSort = False
        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        'ADDITIONAL FILTER OPTIONS TO SELECTED KPI
        cSQL = "SELECT Cast(0 as bit) as Edited, rn = ROW_NUMBER() OVER (ORDER BY SortCode, Caption), * FROM dbo." & tblNameReportsOptions & " WHERE FKeyReportObjectID = '" & FocusedKPI.PKey & "' AND ReportGroup = '" & REPORT_GROUP & "'"

        dt = New DataTable
        dt = MPSDB.CreateTable(cSQL)
        If dt.Rows.Count > 0 Then
            GridFilterOptions_Addl.DataSource = dt
        Else
            GridFilterOptions_Addl.DataSource = InitializeGridFilterOptionDT()
        End If

        GridFilterOptionsView_Addl.Columns("rn").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        GridFilterOptionsView_Addl.OptionsCustomization.AllowSort = False
        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    End Sub

    Function InitializeGridFilterOptionDT() As DataTable
        Dim dt As New DataTable

        Dim ccolumn As DataColumn

        For i As Integer = 0 To GridFilterOptionsView_Addl.Columns.Count - 1
            ccolumn = New DataColumn
            ccolumn.ColumnName = GridFilterOptionsView_Addl.Columns(i).FieldName
            Select Case GridFilterOptionsView_Addl.Columns(i).FieldName
                Case "SortCode", "rn"
                    ccolumn.DataType = System.Type.GetType("System.Int32")
                Case "ApplyToReportSource", "isRowSourceHasUserDataFilter", "Edited"
                    ccolumn.DataType = System.Type.GetType("System.Boolean")
                Case Else
                    ccolumn.DataType = System.Type.GetType("System.String")
            End Select
            dt.Columns.Add(ccolumn)
        Next

        Return dt
    End Function

#End Region

#Region "Edit"
    'Edit Data
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        RefreshButtons(ButtonMode.Edit)
        If isEditdable Then
            RemoveReadOnlyListener(LayoutControlGroups)

            'Sub GridViews
            GridFilterOptionsView_Addl.OptionsBehavior.ReadOnly = False
            AllowRepositoryBtnEdit(repFilterOption_Addl, True)

        Else
            MakeReadOnlyListener(LayoutControlGroups)

            GridFilterOptionsView_Addl.OptionsBehavior.ReadOnly = True
            AllowRepositoryBtnEdit(repFilterOption_Addl, False)
        End If

        EditSubAllowGrid(GridFilterOptionsView_Addl, isEditdable)
    End Sub
#End Region

#Region "Add"
    Public Overrides Sub AddData()
        MyBase.AddData()
        RefreshButtons(ButtonMode.Add)
        RemoveReadOnlyListener(LayoutControlGroups)
        If Not bAddMode Then

            ClearFields_Recursive(LayoutControlGroups, False)
            SortFields = ""
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            Me.header.Text = "New Report"
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            If Not IfNull(cboKPIType.EditValue, "").Equals("") Then
                cboKPITypeSelected.EditValue = cboKPIType.EditValue
            End If
            Me.chkShowInGenerateList.Checked = True
            BRECORDUPDATEDs = False
            FocusedKPI = New FocusedKPIClass
            LoadFilterOptions()
            'End If

        End If
    End Sub

    Sub AddCategory()
        Dim cCategory As String
        If MsgBox("Do you want to add a new Category?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        cCategory = InputBox("Enter new category name", "MPS5 Report Group")
        If IfNull(cCategory, "").Equals("") Then
            MsgBox("Invalid category name.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim dt As DataTable = cboCategory.Properties.DataSource
        Dim dv As DataView = New DataView(dt)

        dv.RowFilter = "Category = '" & cCategory & "'"
        If dv.Count > 0 Then
            MsgBox("Cannot add category name [" & cCategory & "] because it already exists.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            dt.Rows.Add(New Object() {cCategory})
            dv = New DataView(dt)

            dv.Sort = "Category ASC"
            cboCategory.Properties.DataSource = dv.ToTable
            cboCategory.EditValue = cCategory
            MsgBox("Added", MsgBoxStyle.Information)
        End If
    End Sub
#End Region


#Region "Save"
    Public Overrides Sub SaveData()
        MyBase.SaveData()
        RefreshButtons(ButtonMode.Add)

        Me.header.Focus()
        Dim query As New ArrayList, info As Boolean = False
        Dim LastFocusedKPI As New FocusedKPIClass
        Dim type As String = ""

        If Not GridHasColumnErrors() Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtPKey, txtName, cboCategory, cboKPIType}) Then

                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, cboCategory, cboKPIType}) Then
                        Exit Sub
                    ElseIf CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtPKey}) Then
                        Exit Sub
                    Else

                        Dim sp As StoredProcedureCommand = ConstructAddEditReportSP("ADD")

                        info = (sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected) > 0)

                        BRECORDUPDATEDs = False

                        LastFocusedKPI.Name = IIf(IsDBNull(txtName.EditValue), System.DBNull.Value, txtName.EditValue)
                        LastFocusedKPI.KPIType = IIf(IsDBNull(cboKPITypeSelected.EditValue), System.DBNull.Value, cboKPITypeSelected.EditValue)
                        LastFocusedKPI.Category = IIf(IsDBNull(cboCategory.EditValue), System.DBNull.Value, cboCategory.EditValue)
                        type = "Inserted"
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, cboKPITypeSelected, cboCategory}, "Name <> '" & txtName.EditValue & "' AND KPIType <> '" & cboKPITypeSelected.EditValue & "' AND Category <> '" & cboCategory.EditValue & "'") Then
                        Exit Sub
                    Else
                        If NewKeyExists(GridKPIView.GetFocusedRowCellValue("PKey"), txtPKey.EditValue) Then
                            MsgBox("A KPI with a code [" & txtPKey.EditValue & "] already exists. Please use a different code.", MsgBoxStyle.Information)
                            Exit Sub
                        Else
                            Dim sp As StoredProcedureCommand = ConstructAddEditReportSP("EDIT")
                            info = (sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected) > 0)

                            BRECORDUPDATEDs = False
                            LastFocusedKPI.PKey = FocusedKPI.PKey
                            LastFocusedKPI.Name = IIf(IsDBNull(txtName.EditValue), System.DBNull.Value, txtName.EditValue)
                            LastFocusedKPI.KPIType = IIf(IsDBNull(cboKPITypeSelected.EditValue), System.DBNull.Value, cboKPITypeSelected.EditValue)
                            LastFocusedKPI.Category = IIf(IsDBNull(cboCategory.EditValue), System.DBNull.Value, cboCategory.EditValue)
                            type = "Updated"
                        End If
                    End If

                End If

                SaveFilerOption()
                InitControl_GridKPI()
                SetSelection(LastFocusedKPI)
                RefreshData()
                MsgBox("Saved.", MsgBoxStyle.Information, GetAppName)
                tabDetails.SelectedTabPageIndex = 0

                bAddMode = False
            End If
        Else
            info = False
            MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
        End If
    End Sub

    Function NewKeyExists(OldPKey As String, NewPKey As String) As Boolean
        Dim ReturnValue As Boolean = False
        MPSDB.BeginReader("SELECT * FROM dbo.tblkpi WHERE PKey = '" & NewPKey & "' AND PKey <> = '" & OldPKey & "'")
        MPSDB.CloseReader()
        ReturnValue = (MPSDB.ReaderItemCount() > 0)
        Return ReturnValue
    End Function

    Function ConstructAddEditReportSP(cMode As String) As StoredProcedureCommand
        Dim sp As New StoredProcedureCommand("AddEditKPIObject", DB)

        With sp.Parameters
            .Add(New StoredProcedureCommand.SPParameter("Mode", cMode))
            .Add(New StoredProcedureCommand.SPParameter("PKey", IIf(IsDBNull(txtPKey.EditValue), System.DBNull.Value, txtPKey.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("Name", IIf(IsDBNull(txtName.EditValue), System.DBNull.Value, txtName.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("SortCode", IIf(IsDBNull(txtSortCode.EditValue), 0, txtSortCode.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("Nbr", IIf(IsDBNull(txtNbr.EditValue), System.DBNull.Value, txtNbr.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("KPIType", IIf(IsDBNull(cboKPITypeSelected.EditValue), System.DBNull.Value, cboKPITypeSelected.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("Category", IIf(IsDBNull(cboCategory.EditValue), System.DBNull.Value, cboCategory.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("Description", IIf(IsDBNull(txtDescription.EditValue), System.DBNull.Value, txtDescription.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("MinReq", IIf(IsDBNull(txtMinReq.EditValue), System.DBNull.Value, txtMinReq.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("Target", IIf(IsDBNull(txtTarget.EditValue), System.DBNull.Value, txtTarget.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("Formula", IIf(IsDBNull(txtFormula.EditValue), System.DBNull.Value, txtFormula.EditValue)))

            If Not IsNothing(imgFormula.Image) Then
                Dim ms As New System.IO.MemoryStream
                Dim newBitmap As New System.Drawing.Bitmap(imgFormula.Image)
                newBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

                .Add(New StoredProcedureCommand.SPParameter("FormulaImage", SqlDbType.Image, ms.GetBuffer()))
            End If

            .Add(New StoredProcedureCommand.SPParameter("SubTitle", IIf(IsDBNull(txtSubTitle.EditValue), System.DBNull.Value, txtSubTitle.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("FooterNote", IIf(IsDBNull(txtFooterNote.EditValue), System.DBNull.Value, txtFooterNote.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("AxisXLabel", IIf(IsDBNull(txtAxisXLabel.EditValue), System.DBNull.Value, txtAxisXLabel.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("AxisYLabel", IIf(IsDBNull(txtAxisYLabel.EditValue), System.DBNull.Value, txtAxisYLabel.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("FKeyPeriod", IIf(IsDBNull(cboTimePeriod.EditValue), "DEFAULT", cboTimePeriod.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("FKeyUnit", System.DBNull.Value))
            .Add(New StoredProcedureCommand.SPParameter("SelectionListing", IIf(IsDBNull(cboSelectionListing.EditValue), "DEFAULT", cboSelectionListing.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("ShowInGenerateList", IIf(chkShowInGenerateList.Checked, 1, 0)))
            '.Add(New StoredProcedureCommand.SPParameter("DateUpdated", ChangeToSQLDate(System.DateTime.Now())))
            '.Add(New StoredProcedureCommand.SPParameter("LastUpdatedBy", USER_INFO))
            .Add(New StoredProcedureCommand.SPParameter("LastUpdatedBy", clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName)))
            .Add(New StoredProcedureCommand.SPParameter("StoredProcedureName", IIf(IsDBNull(txtStoredProcedureName.EditValue), System.DBNull.Value, txtStoredProcedureName.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("NeedDateCoverage", IIf(isNeedDateCoverage.Checked, 1, 0)))
            '.Add(New StoredProcedureCommand.SPParameter("DateCoverageType", IIf(IsDBNull(cboDateCoverageType.EditValue), System.DBNull.Value, cboDateCoverageType.EditValue)))
            'no longer need DateCoverageType
            .Add(New StoredProcedureCommand.SPParameter("AllowChartView_Bar", 1))
            .Add(New StoredProcedureCommand.SPParameter("AllowChartView_Line", 1))
            .Add(New StoredProcedureCommand.SPParameter("AllowChartView_Area", 1))
            .Add(New StoredProcedureCommand.SPParameter("AllowChartView_Pie", 1))
            .Add(New StoredProcedureCommand.SPParameter("DefaultChartView", IIf(IsDBNull(cboDefaultChartView.EditValue), System.DBNull.Value, basKPI.ChangeChartViewNumToName(cboDefaultChartView.EditValue))))
            .Add(New StoredProcedureCommand.SPParameter("PieView_UsePercentage", IIf(chkUserPercentage.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("AddlFilterOption", System.DBNull.Value))
            .Add(New StoredProcedureCommand.SPParameter("isMultiSelection", IIf(isMultiSelection.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("UserDataFilter_AgentField", IIf(IsDBNull(txtAgentFieldName.EditValue), System.DBNull.Value, txtAgentFieldName.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("UserDataFilter_PrinField", IIf(IsDBNull(txtPrinFieldName.EditValue), System.DBNull.Value, txtPrinFieldName.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("UserDataFilter_FleetField", IIf(IsDBNull(txtFleetFieldName.EditValue), System.DBNull.Value, txtFleetFieldName.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("ShowCrewInSelectionListing", IIf(chkShowCrewInSelectionListing.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("CanChangeSelectionListing", IIf(chkCanChangeSelectionListing.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("CanChangeFKeyPeriod", IIf(chkCanChangeFKeyPeriod.Checked, 1, 0)))

        End With

        Return sp
    End Function

    Sub SaveFilerOption()
        Dim bSuccess As Boolean
        Dim sp As StoredProcedureCommand

        With Me.GridFilterOptionsView_Addl
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1

                If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                    sp = New StoredProcedureCommand("AddEditReportFilterOption")
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Mode", "ADD"))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("PKey", System.DBNull.Value))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("FKeyReportObjectID", IIf(IfNull(txtPKey.EditValue, "").Equals(""), System.DBNull.Value, txtPKey.EditValue)))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ReportGroup", REPORT_GROUP))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("SortCode", i + 1))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("FKeyFilterOption", IIf(IfNull(.GetRowCellValue(i, "FKeyFilterOption"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "FKeyFilterOption"))))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Caption", IIf(IfNull(.GetRowCellValue(i, "Caption"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "Caption"))))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ReportKeyFilterField", IIf(IfNull(.GetRowCellValue(i, "ReportKeyFilterField"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "ReportKeyFilterField"))))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Operator", IIf(IfNull(.GetRowCellValue(i, "Operator"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "Operator"))))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ComboBoxCustomRowSource", IIf(IfNull(.GetRowCellValue(i, "ComboBoxCustomRowSource"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "ComboBoxCustomRowSource"))))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ApplyToReportSource", IIf(IfNull(.GetRowCellValue(i, "ApplyToReportSource"), "").Equals(""), 0, .GetRowCellValue(i, "ApplyToReportSource"))))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("isRowSourceHasUserDataFilter", IIf(IfNull(.GetRowCellValue(i, "isRowSourceHasUserDataFilter"), "").Equals(""), 0, .GetRowCellValue(i, "isRowSourceHasUserDataFilter"))))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("CustomRowSourceKeyField", IIf(IfNull(.GetRowCellValue(i, "CustomRowSourceKeyField"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "CustomRowSourceKeyField"))))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("CustomRowSourceDisplayField", IIf(IfNull(.GetRowCellValue(i, "CustomRowSourceDisplayField"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "CustomRowSourceDisplayField"))))

                    bSuccess = sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected, True)

                Else
                    If Not IfNull(.GetRowCellValue(i, "PKey"), "").Equals("") Then
                        sp = New StoredProcedureCommand("AddEditReportFilterOption")
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Mode", "EDIT"))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("PKey", .GetRowCellValue(i, "PKey")))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("FKeyReportObjectID", IIf(IfNull(txtPKey.EditValue, "").Equals(""), System.DBNull.Value, txtPKey.EditValue)))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ReportGroup", REPORT_GROUP))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("SortCode", i + 1))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("FKeyFilterOption", IIf(IfNull(.GetRowCellValue(i, "FKeyFilterOption"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "FKeyFilterOption"))))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Caption", IIf(IfNull(.GetRowCellValue(i, "Caption"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "Caption"))))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ReportKeyFilterField", IIf(IfNull(.GetRowCellValue(i, "ReportKeyFilterField"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "ReportKeyFilterField"))))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Operator", IIf(IfNull(.GetRowCellValue(i, "Operator"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "Operator"))))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ComboBoxCustomRowSource", IIf(IfNull(.GetRowCellValue(i, "ComboBoxCustomRowSource"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "ComboBoxCustomRowSource"))))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ApplyToReportSource", IIf(IfNull(.GetRowCellValue(i, "ApplyToReportSource"), "").Equals(""), 0, .GetRowCellValue(i, "ApplyToReportSource"))))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("isRowSourceHasUserDataFilter", IIf(IfNull(.GetRowCellValue(i, "isRowSourceHasUserDataFilter"), "").Equals(""), 0, .GetRowCellValue(i, "isRowSourceHasUserDataFilter"))))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("CustomRowSourceKeyField", IIf(IfNull(.GetRowCellValue(i, "CustomRowSourceKeyField"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "CustomRowSourceKeyField"))))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("CustomRowSourceDisplayField", IIf(IfNull(.GetRowCellValue(i, "CustomRowSourceDisplayField"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "CustomRowSourceDisplayField"))))

                        bSuccess = sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected, True)

                    End If
                End If
            Next
        End With

    End Sub
#End Region

#Region "Delete"
    Public Overrides Sub DeleteData()
        Dim info As Boolean
        If FocusedKPI.HasValue Then
            If MsgBox("Do you want to continue delete [" & FocusedKPI.Name & "]?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Dim cSQL As String = "DELETE FROM dbo.tblkpi WHERE PKey = '" & FocusedKPI.PKey & "'"
                info = DB.RunSql(cSQL)
                If info Then
                    InitControl_KPIType()
                    InitControl_GridKPI()
                    RefreshData()
                    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                End If
            End If
        End If
    End Sub
#End Region

    Function GridHasColumnErrors() As Boolean
        If GridFilterOptionsView_Addl.HasColumnErrors() Then
            tabDetails.SelectedTabPageIndex = 1
            Return True
            Exit Function
        End If

        Return False
    End Function

    Private Sub GridKPIView_Click(sender As Object, e As System.EventArgs) Handles GridKPIView.Click
        RefreshData()
    End Sub

    Private Sub GridKPIView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles GridKPIView.FocusedRowObjectChanged
        If FocusedKPI.PKey <> GridKPIView.GetFocusedRowCellValue("PKey") Then RefreshData()
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddSave.Click
        If cmdAddSave.Text = "Add" Then
            AddData()
        ElseIf cmdAddSave.Text = "Save" Then
            SaveData()
        End If
    End Sub

    Private Function Bytes_To_String2(ByVal bytes_Input As Byte()) As String
        Dim strTemp As New System.Text.StringBuilder(bytes_Input.Length * 2)
        For Each b As Byte In bytes_Input
            strTemp.Append(Conversion.Hex(b))
        Next
        Return strTemp.ToString()
    End Function

    Private Sub cboKPITypeSelected_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboKPITypeSelected.EditValueChanged
        RefreshCategory()
        If bAddMode Then
            cboCategory.EditValue = ""
        End If

    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As System.EventArgs) Handles cmdEditCancel.Click
        If cmdEditCancel.Text = "Edit" Then
            EditData()
        ElseIf cmdEditCancel.Text = "Cancel" Then
            RefreshData()
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As System.EventArgs) Handles cmdDelete.Click
        DeleteData()
    End Sub

    Private Sub cboKPIType_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboKPIType.EditValueChanged
        RefreshGridKPI()
    End Sub

    Private Sub cmdAddReportGroup_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddReportGroup.Click
        AddCategory()
    End Sub

    Private Sub cmdFormulaChange_Click(sender As System.Object, e As System.EventArgs) Handles cmdFormulaChange.Click
        browseFormulaImage()
    End Sub

    Private Sub browseFormulaImage()
        Dim nAnswer = MsgBox("Do you want to continue change the formula image?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)

        If nAnswer = MsgBoxResult.Yes Then
            Dim myStream As System.IO.Stream = Nothing
            Dim openFileDialog1 As New OpenFileDialog()

            openFileDialog1.InitialDirectory = "c:\"
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|jpeg files (*.jpeg)|*.jpeg|bmp files (*.bmp)|*.bmp|png files (*.png)|*.png|All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    imgFormula.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName)
                    FormulaImage = imgFormula.EditValue
                Catch Ex As Exception
                    MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
                Finally
                    ' Check this again, since we need to make sure we didn't throw an exception on open.
                    If (myStream IsNot Nothing) Then
                        myStream.Close()
                    End If
                End Try
            End If
        End If
    End Sub



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub GridFilterOptionsView_Addl_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridFilterOptionsView_Addl.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.GridFilterOptionsView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If

        If e.Column.FieldName.ToString = "ApplyToReportSource" Then
            Dim isApplyToReportSource As Boolean = Me.GridFilterOptionsView.GetRowCellValue(e.RowHandle, "ApplyToReportSource")
            If isApplyToReportSource Then
                Me.GridFilterOptionsView.SetRowCellValue(e.RowHandle, "Operator", "=")
            Else
                Me.GridFilterOptionsView.SetRowCellValue(e.RowHandle, "Operator", System.DBNull.Value)
            End If
        End If
    End Sub

    Private Sub GridFilterOptionsView_Addl_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridFilterOptionsView_Addl.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("ApplyToReportSource"), False)
        View.SetRowCellValue(e.RowHandle, View.Columns("isRowSourceHasUserDataFilter"), False)
        View.SetRowCellValue(e.RowHandle, View.Columns("rn"), View.RowCount + 1)
    End Sub

    Private Sub cmdFormulaRemove_Click(sender As System.Object, e As System.EventArgs) Handles cmdFormulaRemove.Click
        imgFormula.Image = Nothing
        FormulaImage = Nothing
    End Sub

    Enum ScriptType
        INSERT = 1
        UPDATE = 2
    End Enum

    Private Sub cboGenerateScript_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboGenerateScript.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.OK Then
            If cmdAddSave.Text = "Save" Then
                MsgBox("Click save first before you generate a script.", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim nSelected As ScriptType = cboGenerateScript.EditValue
            Dim script As New System.Text.StringBuilder

            If IsNumeric(nSelected) Then
                Select Case nSelected
                    Case ScriptType.INSERT
                        GenerateInsertScript()
                        MsgBox("Insert script file created.", MsgBoxStyle.Information)

                    Case ScriptType.UPDATE
                        GenerateUpdateScript()
                        MsgBox("Update script file created.", MsgBoxStyle.Information)

                End Select
            End If
        End If
    End Sub

    Sub GenerateInsertScript()
        Dim oSaveFileDialog As New SaveFileDialog()
        oSaveFileDialog.Filter = "Text File|*.txt|SQL File|*.sql"
        oSaveFileDialog.Title = "Save Insert Script"

        MsgBox("Select where you want to save the script file", MsgBoxStyle.Information)
        oSaveFileDialog.ShowDialog()

        ' If the file name is not an empty string open it for saving.  
        If oSaveFileDialog.FileName <> "" Then

            If My.Computer.FileSystem.FileExists(oSaveFileDialog.FileName) Then
                Kill(oSaveFileDialog.FileName)

            End If

        Else
            MsgBox("Destination not set. Process is canceled.", MsgBoxStyle.Information)
            Exit Sub
        End If


        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(oSaveFileDialog.FileName, True)

        file.WriteLine("USE [MPS]")
        file.WriteLine("GO")
        file.WriteLine("")
        file.WriteLine("INSERT INTO [dbo].[tblKPI]")
        file.WriteLine("           ([Name]")
        file.WriteLine("           ,[SortCode]")
        file.WriteLine("           ,[Nbr]")
        file.WriteLine("           ,[KPIType]")
        file.WriteLine("           ,[Category]")
        file.WriteLine("           ,[Description]")
        file.WriteLine("           ,[MinReq]")
        file.WriteLine("           ,[Target]")
        file.WriteLine("           ,[Formula]")
        file.WriteLine("           ,[FormulaImage]")
        file.WriteLine("           ,[SubTitle]")
        file.WriteLine("           ,[FooterNote]")
        file.WriteLine("           ,[AxisXLabel]")
        file.WriteLine("           ,[AxisYLabel]")
        file.WriteLine("           ,[FKeyPeriod]")
        file.WriteLine("           ,[FKeyUnit]")
        file.WriteLine("           ,[SelectionListing]")
        file.WriteLine("           ,[ShowInGenerateList]")
        file.WriteLine("           ,[DateUpdated]")
        file.WriteLine("           ,[LastUpdatedBy]")
        file.WriteLine("           ,[StoredProcedureName]")
        file.WriteLine("           ,[NeedDateCoverage]")
        'file.WriteLine("           ,[DateCoverageType]")
        'no longer need DateCoverageType
        file.WriteLine("           ,[AllowChartView_Bar]")
        file.WriteLine("           ,[AllowChartView_Line]")
        file.WriteLine("           ,[AllowChartView_Area]")
        file.WriteLine("           ,[AllowChartView_Pie]")
        file.WriteLine("           ,[DefaultChartView]")
        file.WriteLine("           ,[PieView_UsePercentage]")
        file.WriteLine("           ,[AddlFilterOption]")
        file.WriteLine("           ,[isMultiSelection]")
        file.WriteLine("           ,[UserDataFilter_AgentField]")
        file.WriteLine("           ,[UserDataFilter_PrinField]")
        file.WriteLine("           ,[UserDataFilter_FleetField])")
        file.WriteLine("VALUES")
        file.WriteLine("           ('" & txtName.EditValue & "'")
        file.WriteLine("           ," & IfNull(txtSortCode.EditValue, 0))
        file.WriteLine("           ," & IIf(IfNull(txtNbr.EditValue, "").Equals(""), "NULL", "'" & txtNbr.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(cboKPIType.EditValue, "").Equals(""), "NULL", "'" & cboKPIType.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(cboCategory.EditValue, "").Equals(""), "NULL", "'" & cboCategory.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtDescription.EditValue, "").Equals(""), "NULL", "'" & txtDescription.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtMinReq.EditValue, "").Equals(""), "NULL", "'" & txtMinReq.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtTarget.EditValue, "").Equals(""), "NULL", "'" & txtTarget.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtFormula.EditValue, "").Equals(""), "NULL", "'" & txtFormula.EditValue & "'"))
        If IsNothing(FormulaImage) Then
            file.WriteLine("           ,NULL")
        Else
            file.WriteLine("           ,0x" & Bytes_To_String2(FormulaImage))
        End If
        file.WriteLine("           ," & IIf(IfNull(txtSubTitle.EditValue, "").Equals(""), "NULL", "'" & txtSubTitle.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtFooterNote.EditValue, "").Equals(""), "NULL", "'" & txtFooterNote.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtAxisXLabel.EditValue, "").Equals(""), "NULL", "'" & txtAxisXLabel.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtAxisYLabel.EditValue, "").Equals(""), "NULL", "'" & txtAxisYLabel.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(cboTimePeriod.EditValue, "").Equals(""), "NULL", "'" & cboTimePeriod.EditValue & "'"))
        file.WriteLine("           ,NULL")
        file.WriteLine("           ," & IIf(IfNull(cboSelectionListing.EditValue, "").Equals(""), "NULL", "'" & cboSelectionListing.EditValue & "'"))
        file.WriteLine("           ," & IIf(chkShowInGenerateList.Checked, 1, 0))
        file.WriteLine("           ,getdate()")
        file.WriteLine("           ,'" & USER_NAME & "'")
        file.WriteLine("           ," & IIf(IfNull(txtStoredProcedureName.EditValue, "").Equals(""), "NULL", "'" & txtStoredProcedureName.EditValue & "'"))
        file.WriteLine("           ," & IIf(isNeedDateCoverage.Checked, 1, 0))
        'file.WriteLine("           ," & IIf(IfNull(cboDateCoverageType.EditValue, "").Equals(""), "NULL", "'" & cboDateCoverageType.EditValue & "'"))
        'no longer need DateCoverageType
        file.WriteLine("           ,1")
        file.WriteLine("           ,1")
        file.WriteLine("           ,1")
        file.WriteLine("           ,1")
        file.WriteLine("           ," & IIf(IfNull(cboDefaultChartView.EditValue, "").Equals(""), "NULL", "'" & basKPI.ChangeChartViewNumToName(cboDefaultChartView.EditValue) & "'"))
        file.WriteLine("           ," & IfNull(chkUserPercentage.EditValue, 0))
        file.WriteLine("           ,NULL")
        file.WriteLine("           ," & IIf(isMultiSelection.Checked, 1, 0))
        file.WriteLine("           ," & IIf(IfNull(txtAgentFieldName.EditValue, "").Equals(""), "NULL", "'" & txtAgentFieldName.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtPrinFieldName.EditValue, "").Equals(""), "NULL", "'" & txtPrinFieldName.EditValue & "'"))
        file.WriteLine("           ," & IIf(IfNull(txtFleetFieldName.EditValue, "").Equals(""), "NULL", "'" & txtFleetFieldName.EditValue & "'") & ")")
        file.WriteLine("GO")

        file.Close()

    End Sub

    Sub GenerateUpdateScript()
        Dim oSaveFileDialog As New SaveFileDialog()
        oSaveFileDialog.Filter = "Text File|*.txt|SQL File|*.sql"
        oSaveFileDialog.Title = "Save Update Script"

        MsgBox("Select where you want to save the script file", MsgBoxStyle.Information)
        oSaveFileDialog.ShowDialog()

        ' If the file name is not an empty string open it for saving.  
        If oSaveFileDialog.FileName <> "" Then

            If My.Computer.FileSystem.FileExists(oSaveFileDialog.FileName) Then
                Kill(oSaveFileDialog.FileName)

            End If

        Else
            MsgBox("Destination not set. Process is canceled.", MsgBoxStyle.Information)
            Exit Sub
        End If


        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(oSaveFileDialog.FileName, True)

        file.WriteLine("USE [MPS]")
        file.WriteLine("GO")
        file.WriteLine("Update [dbo].[tblKPI]")
        file.WriteLine("SET [Name] = '" & txtName.EditValue & "'")
        file.WriteLine("      ,[SortCode] = " & IfNull(txtSortCode.EditValue, 0))
        file.WriteLine("      ,[Nbr] = " & IIf(IfNull(txtNbr.EditValue, "").Equals(""), "NULL", "'" & txtNbr.EditValue & "'"))
        file.WriteLine("      ,[KPIType] = " & IIf(IfNull(cboKPIType.EditValue, "").Equals(""), "NULL", "'" & cboKPIType.EditValue & "'"))
        file.WriteLine("      ,[Category] = " & IIf(IfNull(cboCategory.EditValue, "").Equals(""), "NULL", "'" & cboCategory.EditValue & "'"))
        file.WriteLine("      ,[Description] = " & IIf(IfNull(txtDescription.EditValue, "").Equals(""), "NULL", "'" & txtNbr.EditValue & "'"))
        file.WriteLine("      ,[MinReq] = " & IIf(IfNull(txtMinReq.EditValue, "").Equals(""), "NULL", "'" & txtMinReq.EditValue & "'"))
        file.WriteLine("      ,[Target] = " & IIf(IfNull(txtTarget.EditValue, "").Equals(""), "NULL", "'" & txtTarget.EditValue & "'"))
        file.WriteLine("      ,[Formula] = " & IIf(IfNull(txtFormula.EditValue, "").Equals(""), "NULL", "'" & txtFormula.EditValue & "'"))
        If FormulaImage Is Nothing Then
            file.WriteLine("      ,[FormulaImage] = NULL")
        Else
            file.WriteLine("      ,[FormulaImage] = 0x" & Bytes_To_String2(FormulaImage))
        End If
        file.WriteLine("      ,[SubTitle] = " & IIf(IfNull(txtNbr.EditValue, "").Equals(""), "NULL", "'" & txtSubTitle.EditValue & "'"))
        file.WriteLine("      ,[FooterNote] = " & IIf(IfNull(txtFooterNote.EditValue, "").Equals(""), "NULL", "'" & txtFooterNote.EditValue & "'"))
        file.WriteLine("      ,[AxisXLabel] = " & IIf(IfNull(txtAxisXLabel.EditValue, "").Equals(""), "NULL", "'" & txtAxisXLabel.EditValue & "'"))
        file.WriteLine("      ,[AxisYLabel] = " & IIf(IfNull(txtAxisYLabel.EditValue, "").Equals(""), "NULL", "'" & txtAxisYLabel.EditValue & "'"))
        file.WriteLine("      ,[FKeyPeriod] = " & IIf(IfNull(cboTimePeriod.EditValue, "").Equals(""), "NULL", "'" & cboTimePeriod.EditValue & "'"))
        file.WriteLine("      ,[FKeyUnit] = NULL")
        file.WriteLine("      ,[SelectionListing] = " & IIf(IfNull(cboSelectionListing.EditValue, "").Equals(""), "NULL", "'" & cboSelectionListing.EditValue & "'"))
        file.WriteLine("      ,[ShowInGenerateList] = " & IIf(chkShowInGenerateList.Checked, 1, 0))
        file.WriteLine("      ,[DateUpdated] = getdate()")
        file.WriteLine("      ,[LastUpdatedBy] = '" & USER_NAME & "'")
        file.WriteLine("      ,[StoredProcedureName] = " & IIf(IfNull(txtStoredProcedureName.EditValue, "").Equals(""), "NULL", "'" & txtStoredProcedureName.EditValue & "'"))
        file.WriteLine("      ,[NeedDateCoverage] = " & IIf(isNeedDateCoverage.Checked, 1, 0))
        'file.WriteLine("      ,[DateCoverageType] = " & IIf(IfNull(cboDateCoverageType.EditValue, "").Equals(""), "NULL", "'" & cboDateCoverageType.EditValue & "'"))
        'no longer need DateCoverageType
        file.WriteLine("      ,[AllowChartView_Bar] = 1")
        file.WriteLine("      ,[AllowChartView_Line] = 1")
        file.WriteLine("      ,[AllowChartView_Area] = 1")
        file.WriteLine("      ,[AllowChartView_Pie] = 1")
        file.WriteLine("      ,[DefaultChartView] = " & IIf(IfNull(cboDefaultChartView.EditValue, "").Equals(""), "NULL", "'" & basKPI.ChangeChartViewNumToName(cboDefaultChartView.EditValue) & "'"))
        file.WriteLine("      ,[PieView_UsePercentage] = " & IIf(chkUserPercentage.Checked, 1, 0))
        file.WriteLine("      ,[AddlFilterOption] = NULL")
        file.WriteLine("      ,[isMultiSelection] = " & IIf(isMultiSelection.Checked, 1, 0))
        file.WriteLine("      ,[UserDataFilter_AgentField] = " & IIf(IfNull(txtAgentFieldName.EditValue, "").Equals(""), "NULL", "'" & txtAgentFieldName.EditValue & "'"))
        file.WriteLine("      ,[UserDataFilter_PrinField] = " & IIf(IfNull(txtPrinFieldName.EditValue, "").Equals(""), "NULL", "'" & txtPrinFieldName.EditValue & "'"))
        file.WriteLine("      ,[UserDataFilter_FleetField] = " & IIf(IfNull(txtFleetFieldName.EditValue, "").Equals(""), "NULL", "'" & txtFleetFieldName.EditValue & "'"))
        file.WriteLine(" WHERE PKey = '" & GridKPIView.GetFocusedRowCellValue("PKey") & "'")
        file.WriteLine("GO")

        file.Close()

    End Sub

    Private Sub chkGroupGrid_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkGroupGrid.CheckedChanged
        GroupUngroupKPIList()
    End Sub

    Sub GroupUngroupKPIList()
        If chkGroupGrid.Checked Then
            GridKPIView.Columns("Category").Group()
            GridKPIView.ExpandAllGroups()
        Else
            GridKPIView.Columns("Category").UnGroup()
        End If
    End Sub

    Private Sub chkShowShownInGenerateListOnly_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowShownInGenerateListOnly.CheckedChanged
        RefreshGridKPI()
    End Sub

    Private Sub cboSelectionListing_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboSelectionListing.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            cboSelectionListing.EditValue = Nothing
        End If
    End Sub

    Private Sub cboSelectionListing_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboSelectionListing.EditValueChanged
        UpdSelectionListing()
    End Sub

    Sub UpdSelectionListing()
        If IfNull(cboSelectionListing.EditValue, "").Equals("") Then
            LayoutControlItem_ShowCrewInSelectionListing.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItem_ShowCrewInSelectionListing.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub cboTimePeriod_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboTimePeriod.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            cboTimePeriod.EditValue = Nothing
        End If
    End Sub
End Class
