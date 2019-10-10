Public Class ReportConfig

    Public ReportsTable As DataTable
    Public LayoutControlGroups() As DevExpress.XtraLayout.LayoutControlGroup
    Public FocusedReport As New FocusedReportClass

    Private SelectionSourceType As New SelectionSourceTypeClass
    Private SortFields As String = ""

    Private Const ReportGroup_ShowAll As String = "<Show All>"

    Private Const FilterOptionSortField As String = "rn"

    Dim dtFeature As DataTable

#Region "Easy Edit"
    Private FormName As String = "Report Configuration"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
#End Region

#Region "Classes"
    Public Class FocusedReportClass
        Public ObjectID As String = ""
        Public ReportGroup As String = ""
        Public Caption As String = ""

        Public Sub Refresh(_view As DevExpress.XtraGrid.Views.Grid.GridView)
            ObjectID = _view.GetFocusedRowCellValue("ObjectID")
            ReportGroup = _view.GetFocusedRowCellValue("ReportGroup")
            Caption = _view.GetFocusedRowCellValue("Caption")
        End Sub

        Public Sub SetFocusedReport(cObjectID As String, cReportGroup As String, cCaption As String)
            ObjectID = cObjectID
            ReportGroup = cReportGroup
            Caption = cCaption
        End Sub

        Public Function GetFocusedReportAsCondition()
            Return "ObjectID = '" & ObjectID & "' AND ReportGroup = '" & ReportGroup & "'"
        End Function

        Public Function HasValue() As Boolean
            Return (Not IfNull(ObjectID, "").Equals("") And Not IfNull(ReportGroup, "").Equals(""))
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
    Public Sub SetSelection(ByVal ObjectID As String, ByVal ReportGroup As String)
        Try
            bAddMode = False
            Dim dt As DataTable = GridReports.DataSource
            Dim dv As DataView = New DataView(TryCast(GridReports.DataSource, DataTable))
            dv.RowFilter = "ObjectID = '" & ObjectID & "' AND ReportGroup = '" & ReportGroup & "'"
            If dv.Count > 0 Then
                Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridReportsView.Columns("rn")
                Dim rowhandle As Integer = GridReportsView.LocateByValue("rn", dv(0)("rn"))
                GridReportsView.FocusedRowHandle = rowhandle
            End If
            'Dim RowHandle As Integer = 0
            'Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridReportsView.Columns("PKey")
            'GridReportsView.LocateByValue(
            'RowHandle = GridReportsView.LocateByValue(0, Col, id)
            'GridReportsView.FocusedRowHandle = RowHandle
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

            SetRibbonPageGroupVisibility(Me.Name, "rpgReportEditOptions", False)
            SetAddVisibility(Me.Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetEditVisibility(Me.Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetLoadDataVisibility(Me.Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetDeleteCaption(Me.Name, "Delete Report")
            AllowSaving(Me.Name, False)
            AllowDeletion(Me.Name, False)
        End If

        FocusedReport.Refresh(GridReportsView)
        If FocusedReport.ObjectID = "" Then
            AddData()

        Else
            bAddMode = False
            LoadSub()
            MakeReadOnlyListener(LayoutControlGroups)
            EditSubAllowGrid(Me.GridFilterOptionsView, False)
            EditSubAllowGrid(Me.GridSortOptionsView, False)

            BRECORDUPDATEDs = False
        End If

        AddEditListener(LayoutControlGroups)
        CloseReportWaitForm()
    End Sub

    Sub RefreshGridReport()
        Dim cCondition As String = ""
        Try
            If IfNull(cboReportGroupList.EditValue, "").ToString.Length > 0 Then
                If cboReportGroupList.EditValue <> ReportGroup_ShowAll Then
                    cCondition = "ReportGroup = '" & cboReportGroupList.EditValue & "'"
                End If
            End If

            Dim dt As DataTable = ReportsTable
            Dim dv As DataView = New DataView(dt)
            If cCondition.Length > 0 Then dv.RowFilter = cCondition
            GridReports.DataSource = dv.ToTable
        Catch ex As Exception
            LogErrors(ex.Message)
        End Try
    End Sub

    Sub RefreshSelectionSource()
        If IfNull(cboSelectionSourceType.EditValue, "").ToString.Length > 0 Then
            cboSelectionSource.Enabled = (cboSelectionSourceType.EditValue = SelectionSourceType.Predef_Ds.PKey)
            txtSelectionSource.Enabled = Not (cboSelectionSourceType.EditValue = SelectionSourceType.Predef_Ds.PKey)
            If cboSelectionSourceType.EditValue = SelectionSourceType.ItemList.PKey And bAddMode Then
                txtSelectionKeyField.EditValue = "PKey"
                txtSelectionDisplayField.EditValue = "Name"
            End If
        Else
            cboSelectionSource.Enabled = False
            txtSelectionSource.Enabled = False
        End If
    End Sub

    Sub EnableSubButtons(ByVal _value As Boolean)
        cmdDeleteFilterOption.Enabled = _value
        cmdDeleteSortOption.Enabled = _value
        cmdMoveDownFilterOption.Enabled = _value
        cmdMoveDownSortOption.Enabled = _value
        cmdMoveUpFilterOption.Enabled = _value
        cmdMoveUpSortOption.Enabled = _value
        cmdAddReportGroup.Enabled = _value
        cmdGenerateFID.Enabled = _value
    End Sub

    Private Sub EnableSelectedFilterOption(FilterOptionType As FilterOptionType)
        LayoutControlGroup_FilterOptionSpecific.Enabled = (FilterOptionType = ReportConfig.FilterOptionType.Specific)
        LayoutControlGroup_FilterOptionGeneric.Enabled = (FilterOptionType = ReportConfig.FilterOptionType.Generic)
    End Sub

    Private Enum FilterOptionType
        Specific = 1
        Generic = 2
    End Enum

#Region "Button Refresh"
    Private Sub RefreshButtons(ButtonMode As ButtonMode)
        Select Case ButtonMode
            Case ReportConfig.ButtonMode.Add
                cmdAddSave.Text = "Save"
                cmdEditCancel.Text = "Cancel"
                LayoutControlItem_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                EnableSubButtons(True)
                AllowSaving(Me.Name, False)

            Case ReportConfig.ButtonMode.Edit
                cmdAddSave.Text = "Save"
                cmdEditCancel.Text = "Cancel"
                LayoutControlItem_Delete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                isEditdable = True
                EnableSubButtons(True)
                AllowSaving(Me.Name, False)

            Case ReportConfig.ButtonMode.Delete

            Case ReportConfig.ButtonMode.Init
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
    End Enum
#End Region
#End Region

#Region "Initialization"
    Private Sub InitControls()
        LayoutControlGroups = New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup_Main, LayoutControlGroup_SelectionSource, LayoutControlGroup_Optionals, LayoutControlGroup_DateRangeFields, LayoutControlGroup_FilterOptions, LayoutControlGroup_SortOptions, LayoutControlGroup_Feature, LayoutControlGroup_FeatureSetup}
        tabDetails.SelectedTabPageIndex = 0
        InitControl_ReportGroup()
        InitControl_GenScript()
        InitControl_GridReport()
        InitControl_SelectionSourceType()
        InitControl_SortOrder()
        InitControl_FilterOption()
        InitControl_SelectionSource_PredefDS()
        InitControl_FeatureList()

        GridReportsView.OptionsSelection.EnableAppearanceFocusedRow = True
    End Sub

    Sub InitControl_ReportGroup()
        Dim cSQL As String = "SELECT ReportGroup FROM " & _
                             "  (SELECT '" & ReportGroup_ShowAll & "' as ReportGroup, 0 as GroupSort " & _
                             "  UNION " & _
                             "  SELECT ReportGroup, 1 as GroupSort FROM dbo.MSystblReports GROUP BY ReportGroup " & _
                             "  ) t " & _
                             "ORDER BY t.GroupSort, t.ReportGroup"
        Dim dt As DataTable = MPSDB.CreateTable(cSQL)
        Dim objList As New List(Of DevExpress.XtraEditors.LookUpEdit)
        objList.Add(cboReportGroup)
        objList.Add(cboReportGroupList)

        For Each obj As DevExpress.XtraEditors.LookUpEdit In objList
            With obj.Properties
                .Columns.Clear()
                .Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportGroup", "Name"))
                .DataSource = dt
                .ShowHeader = False
                .ShowFooter = False
                .ValueMember = "ReportGroup"
                .DisplayMember = "ReportGroup"
                .DropDownRows = dt.Rows.Count
            End With
        Next
    End Sub

    Sub InitControl_GridReport()
        'ReportsTable = MPSDB.CreateTable("SELECT * FROM dbo.MSystblReports ORDER BY ReportGroup, SortCode, Caption")
        ReportsTable = MPSDB.CreateTable("SELECT * FROM (SELECT rn = ROW_NUMBER() OVER (ORDER BY ObjectID), * FROM dbo.MSystblReports ) reports ORDER BY reports.ReportGroup, reports.SortCode, reports.Caption")
        RefreshGridReport()
    End Sub

    Sub InitControl_SelectionSource_PredefDS()
        Dim dt As DataTable = MPSDB.CreateTable("SELECT * FROM dbo.MSystblDataSource ORDER BY Code")
        cboSelectionSource.Properties.DataSource = dt
    End Sub

    Sub InitControl_SelectionSourceType()
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

        With SelectionSourceType
            dt.Rows.Add(New Object() {.ItemList.PKey, .ItemList.Name})
            dt.Rows.Add(New Object() {.Predef_Ds.PKey, .Predef_Ds.Name})
            dt.Rows.Add(New Object() {.Query.PKey, .Query.Name})
            dt.Rows.Add(New Object() {.SQL.PKey, .SQL.Name})
        End With

        With cboSelectionSourceType.Properties
            .ValueMember = "PKey"
            .DisplayMember = "Name"
            .DataSource = dt
        End With

    End Sub

    Sub InitControl_SortOrder()
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

        dt.Rows.Add(New Object() {"NONE", "None"})
        dt.Rows.Add(New Object() {"ASC", "Ascending"})
        dt.Rows.Add(New Object() {"DESC", "Descending"})

        repSortOrder.DataSource = dt
    End Sub

    Sub InitControl_FilterOption()
        Dim dt As DataTable = MPSDB.CreateTable("SELECT cast(0 as bit) as isEdited, * FROM dbo.MSysAdmFilterOption ORDER BY ObjectID")
        repFilterOption.DataSource = dt
    End Sub

    Sub InitControl_FeatureList()
        Dim clsfeat As New clsFeatureMod

        dtFeature = clsfeat.getFeaturelist
        cboFeature.Properties.DataSource = dtFeature
    End Sub

#End Region

#Region "Load"
    Public Sub LoadSub()
        Dim dt As DataTable = ReportsTable

        'Dim dv As DataView = New DataView(dt)
        'dv.RowFilter = "ObjectID = '" & GetFocusedReport(ReportGridColumn.ObjectID) & "' AND ReportGroup = '" & GetFocusedReport(ReportGridColumn.ReportGroup) & "'"
        Dim row As DataRow() = dt.Select("ObjectID = '" & FocusedReport.ObjectID & "' AND ReportGroup = '" & FocusedReport.ReportGroup & "'")

        If row.Length > 0 Then
            txtCaption.EditValue = IfNull(row(0).Item("Caption"), "")
            cboReportGroup.EditValue = IfNull(row(0).Item("ReportGroup"), "")
            txtObjectID.EditValue = IfNull(row(0).Item("ObjectID"), "")
            txtSortCode.EditValue = IfNull(row(0).Item("SortCode"), 0)
            txtDLL.EditValue = IfNull(row(0).Item("DLL"), "")
            txtReportClass.EditValue = IfNull(row(0).Item("ReportClass"), "")
            txtGroupedBy.EditValue = IfNull(row(0).Item("GroupedBy"), "")
            txtSortedBy.EditValue = IfNull(row(0).Item("SortedBy"), "")
            txtRemarks.EditValue = IfNull(row(0).Item("Remarks"), "")
            cboSelectionSourceType.EditValue = IfNull(row(0).Item("SelectionSourceType"), "")
            txtSelectionSource.EditValue = IfNull(row(0).Item("SelectionSource"), "")
            cboSelectionSource.EditValue = IfNull(row(0).Item("SelectionSource"), "")
            txtSelectionKeyField.EditValue = IfNull(row(0).Item("SelectionKeyField"), "")
            txtSelectionDisplayField.EditValue = IfNull(row(0).Item("SelectionDisplayField"), "")
            txtSelectionSortField.EditValue = IfNull(row(0).Item("SelectionSortField"), "")
            txtKeyFilterField.EditValue = IfNull(row(0).Item("KeyFilterField"), "")
            chkUseSelectionList.Checked = IfNull(row(0).Item("UseSelectionList"), False)
            chkUseTemplateList.Checked = IfNull(row(0).Item("UseTemplateList"), False)
            chkUsePreviewButton.Checked = IfNull(row(0).Item("UsePreviewButton"), False)
            chkUseExportButton.Checked = IfNull(row(0).Item("UseExportButton"), False)
            chkShowInPopup.Checked = IfNull(row(0).Item("ShowInPopup"), False)
            txtDateRangeFromField.EditValue = IfNull(row(0).Item("DateRangeFromField"), "")
            txtDateRangeToField.EditValue = IfNull(row(0).Item("DateRangeToField"), "")
            SortFields = IfNull(row(0).Item("SortFields"), "")
            Me.txtReportFilterOptionDLL.EditValue = IfNull(row(0).Item("ReportFilterOptionDLL"), "")
            Me.txtReportFilterOptionClass.EditValue = IfNull(row(0).Item("ReportFilterOptionClass"), "")

            If Not IfNull(row(0).Item("ReportFilterOptionDLL"), "").Equals("") And Not IfNull(row(0).Item("ReportFilterOptionClass"), "").Equals("") Then
                Me.optFilterOption_UseSpecific.Checked = True
            Else
                Me.optFilterOption_UseGeneric.Checked = True
            End If

            Me.txtFID.EditValue = IfNull(row(0).Item("FID"), "")
            'get the feature value
            txtFeature.EditValue = GetFeatureName(txtFID.EditValue)

            cboFeature.EditValue = ""
        Else
            ClearFields_Recursive(LayoutControlGroups, False)
        End If

        LoadFilterOptions()
        LoadSortOptions()

    End Sub

    Function GetFeatureName(cFID As String) As String
        Dim ReturnValue As String = ""
        If Not IfNull(cFID, "").Equals("") Then
            If Not IsNothing(dtFeature) Then
                If dtFeature.Rows.Count > 0 Then
                    Dim featurestr As String = AES_Decrypt(cFID, "spectral")
                    Dim arrFeatureCode() As String = featurestr.Split("_")
                    'Dim featureCode As String = Mid(featurestr, featurestr.Length, 1)
                    Dim featureCode As String = arrFeatureCode(arrFeatureCode.GetUpperBound(0))
                    Dim dv As DataView = New DataView(dtFeature)
                    dv.RowFilter = "Value = '" & featureCode & "'"
                    If dv.Count > 0 Then
                        ReturnValue = dv(0)("Feature")
                    End If
                End If
            End If
        End If

        Return ReturnValue
    End Function

    Public Shared Function GetFeatureNameFromFID(cFID As String, Optional dtFeatureList As DataTable = Nothing) As String
        Dim ReturnValue As String = ""

        If IsNothing(dtFeatureList) Then
            Dim clsfeat As New clsFeatureMod
            dtFeatureList = clsfeat.getFeaturelist
        End If

        If Not IfNull(cFID, "").Equals("") Then
            If Not IsNothing(dtFeatureList) Then
                If dtFeatureList.Rows.Count > 0 Then
                    Dim featurestr As String = AES_Decrypt(cFID, "spectral")
                    Dim arrFeatureCode() As String = featurestr.Split("_")
                    'Dim featureCode As String = Mid(featurestr, featurestr.Length, 1)
                    Dim featureCode As String = arrFeatureCode(arrFeatureCode.GetUpperBound(0))
                    Dim dv As DataView = New DataView(dtFeatureList)
                    dv.RowFilter = "Value = '" & featureCode & "'"
                    If dv.Count > 0 Then
                        ReturnValue = dv(0)("Feature")
                    End If
                End If
            End If
        End If

        Return ReturnValue
    End Function

    Sub LoadFilterOptions()
        Dim dt As DataTable

        Dim cSQL As String = "SELECT Cast(0 as bit) as Edited, rn = ROW_NUMBER() OVER (ORDER BY SortCode, Caption), * FROM dbo." & tblNameReportsOptions & " WHERE FKeyReportObjectID = '" & FocusedReport.ObjectID & "' AND ReportGroup = '" & FocusedReport.ReportGroup & "'"

        dt = New DataTable
        dt = MPSDB.CreateTable(cSQL)
        If dt.Rows.Count > 0 Then
            GridFilterOptions.DataSource = dt
        Else
            GridFilterOptions.DataSource = InitializeGridFilterOptionDT()
        End If

        GridFilterOptionsView.Columns("rn").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        GridFilterOptionsView.OptionsCustomization.AllowSort = False


    End Sub

    Function InitializeGridFilterOptionDT() As DataTable
        Dim dt As New DataTable

        Dim ccolumn As DataColumn

        ''isEdited
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "isEdited"
        'ccolumn.DataType = System.Type.GetType("System.Boolean")
        'dt.Columns.Add(ccolumn)

        ''rn
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "rn"
        'ccolumn.DataType = System.Type.GetType("System.Int32")
        'dt.Columns.Add(ccolumn)

        For i As Integer = 0 To GridFilterOptionsView.Columns.Count - 1
            ccolumn = New DataColumn
            ccolumn.ColumnName = GridFilterOptionsView.Columns(i).FieldName
            Select Case GridFilterOptionsView.Columns(i).FieldName
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

    Sub LoadSortOptions()
        Dim arrSortFields() As String
        Dim SortField() As String
        Dim isMovable As Boolean
        Dim cSortOrder As String

        Dim dt As New DataTable
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "isEdited"
        ccolumn.DataType = System.Type.GetType("System.Boolean")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FieldName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Caption"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "SortOrder"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "isMovable"
        ccolumn.DataType = System.Type.GetType("System.Boolean")
        dt.Columns.Add(ccolumn)

        If SortFields.Length > 0 Then
            arrSortFields = SortFields.Split(";")
            For i As Integer = 0 To arrSortFields.GetUpperBound(0)
                SortField = arrSortFields(i).Split("~")

                If IfNull(SortField(2), "").Length = 0 Then
                    cSortOrder = "NONE"
                Else
                    cSortOrder = SortField(2)
                End If
                If SortField.Length >= 4 Then
                    isMovable = Not (SortField(3) = 1)
                Else
                    isMovable = True
                End If
                dt.Rows.Add(New Object() {0, SortField(0), SortField(1), cSortOrder, isMovable})
            Next

        End If

        GridSortOptionsView.OptionsCustomization.AllowSort = False
        GridSortOptions.DataSource = dt
    End Sub
#End Region

#Region "Edit"
    'Edit Data
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtCaption.Focus()
        RefreshButtons(ButtonMode.Edit)
        If isEditdable Then
            RemoveReadOnlyListener(LayoutControlGroups)

            'Sub GridViews
            'GridFilterOptionsView.OptionsBehavior.ReadOnly = False
            'GridSortOptionsView.OptionsBehavior.ReadOnly = False
            'AllowRepositoryBtnEdit(repFilterOption, True)
            'AllowRepositoryBtnEdit(repSortOrder, True)
            SetFilterAndSortOptionsAsReadOnly(False)

            txtFID.ReadOnly = True
            txtFeature.ReadOnly = True

        Else
            MakeReadOnlyListener(LayoutControlGroups)

            'GridFilterOptionsView.OptionsBehavior.ReadOnly = True
            'GridSortOptionsView.OptionsBehavior.ReadOnly = True
            'AllowRepositoryBtnEdit(repFilterOption, False)
            'AllowRepositoryBtnEdit(repSortOrder, False)

            SetFilterAndSortOptionsAsReadOnly(True)
        End If

        EditSubAllowGrid(GridFilterOptionsView, isEditdable)
        EditSubAllowGrid(GridSortOptionsView, isEditdable)
    End Sub

    Private Sub SetFilterAndSortOptionsAsReadOnly(Optional isReadonly As Boolean = True)
        'Sub GridViews
        GridFilterOptionsView.OptionsBehavior.ReadOnly = isReadonly
        GridSortOptionsView.OptionsBehavior.ReadOnly = isReadonly
        AllowRepositoryBtnEdit(repFilterOption, Not isReadonly)
        AllowRepositoryBtnEdit(repSortOrder, Not isReadonly)

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
            Me.txtCaption.Focus()
            Me.txtCaption.BackColor = SEL_COLOR
            Me.optFilterOption_UseGeneric.Checked = True
            If Not IfNull(cboReportGroupList.EditValue, "").Equals("") Then
                cboReportGroup.EditValue = cboReportGroupList.EditValue
            End If
            BRECORDUPDATEDs = False
            FocusedReport = New FocusedReportClass
            LoadFilterOptions()
            LoadSortOptions()
            txtFeature.ReadOnly = True
            txtFID.ReadOnly = True

        Else
            SetFilterAndSortOptionsAsReadOnly(False)
        End If

        EditSubAllowGrid(GridFilterOptionsView, bAddMode)
        EditSubAllowGrid(GridSortOptionsView, bAddMode)
    End Sub

    Sub AddReportGroup()
        Dim cGroupName As String
        If MsgBox("Do you want to add a new Report Group?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        cGroupName = InputBox("Add new group name", "MPS5 Report Group")
        If IfNull(cGroupName, "").Equals("") Then
            MsgBox("Invalid group name.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim dt As DataTable = cboReportGroupList.Properties.DataSource
        Dim dv As DataView = New DataView(dt)

        dv.RowFilter = "ReportGroup = '" & cGroupName & "'"
        If dv.Count > 0 Then
            MsgBox("Cannot add group name [" & cGroupName & "] because it already exists.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            dt.Rows.Add(New Object() {cGroupName})
            dv = New DataView(dt)

            dv.Sort = "ReportGroup ASC"
            cboReportGroupList.Properties.DataSource = dv.ToTable
            cboReportGroup.Properties.DataSource = dv.ToTable
            cboReportGroup.EditValue = cGroupName
            MsgBox("Added", MsgBoxStyle.Information)
        End If



    End Sub
#End Region


#Region "Save"
    'Public Overrides Sub SaveData()
    '    MyBase.SaveData()
    '    RefreshButtons(ButtonMode.Add)

    '    Me.header.Focus()
    '    Dim query As New ArrayList, info As Boolean = False, LastObjectID As String = "", LastReportGroup As String = ""
    '    Dim type As String = ""
    '    Dim cSQL As String

    '    If Not GridHasColumnErrors() Then
    '        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtObjectID, txtCaption, cboReportGroup, txtDLL, txtReportClass, txtSortCode}) Then
    '            'LASTUPDATED BY FORMAT
    '            'getusername() & <Description><FormName>
    '            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
    '            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Bank", 10, System.Environment.MachineName, cboReportGroup.Text & " | " & txtCaption.EditValue & " | " & txtObjectID.EditValue, FormName)
    '            If bAddMode Then
    '                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtObjectID, txtCaption, cboReportGroup}) Then
    '                    Exit Sub
    '                Else
    '                    'cSQL = "INSERT INTO     [dbo].[MSystblReports] " & _
    '                    '       "                ([ObjectID] " & _
    '                    '       "                ,[Caption] " & _
    '                    '       "                ,[ReportGroup] " & _
    '                    '       "                ,[DLL] " & _
    '                    '       "                ,[ReportClass] " & _
    '                    '       "                ,[SelectionSource] " & _
    '                    '       "                ,[SelectionSourceType] " & _
    '                    '       "                ,[SelectionKeyField] " & _
    '                    '       "                ,[SelectionDisplayField] " & _
    '                    '       "                ,[SelectionSortField] " & _
    '                    '       "                ,[KeyFilterField] " & _
    '                    '       "                ,[SortCode] " & _
    '                    '       "                ,[GroupedBy] " & _
    '                    '       "                ,[SortedBy] " & _
    '                    '       "                ,[Remarks] " & _
    '                    '       "                ,[UseSelectionList] " & _
    '                    '       "                ,[UseTemplateList] " & _
    '                    '       "                ,[UsePreviewButton] " & _
    '                    '       "                ,[UseExportButton] " & _
    '                    '       "                ,[ShowInPopUp] " & _
    '                    '       "                ,[OpensPopupForm] " & _
    '                    '       "                ,[SortFields] " & _
    '                    '       "                ,[ReportFilterOptionDLL] " & _
    '                    '       "                ,[ReportFilterOptionClass] " & _
    '                    '       "                ,[DateRangeFromField] " & _
    '                    '       "                ,[DateRangeToField]) " & _
    '                    '       "VALUES(                                 " & _
    '                    '       "                '" & txtObjectID.EditValue & "' " & _
    '                    '       "                ," & IIf(IsDBNull(txtCaption.EditValue), "NULL", "'" & txtCaption.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(cboReportGroup.EditValue), "NULL", "'" & cboReportGroup.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtDLL.EditValue), "NULL", "'" & txtDLL.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtReportClass.EditValue), "NULL", "'" & txtReportClass.EditValue & "'") & " " & _
    '                    '       "                ,'" & GetSelectionSource(cboSelectionSourceType.EditValue, txtSelectionSource.EditValue, cboSelectionSource.EditValue) & "' " & _
    '                    '       "                ," & IIf(IsDBNull(cboSelectionSourceType.EditValue), "NULL", "'" & cboSelectionSourceType.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtSelectionKeyField.EditValue), "NULL", "'" & txtSelectionKeyField.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtSelectionDisplayField.EditValue), "NULL", "'" & txtSelectionDisplayField.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtSelectionSortField.EditValue), "NULL", "'" & txtSelectionSortField.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtKeyFilterField.EditValue), "NULL", "'" & txtKeyFilterField.EditValue & "'") & " " & _
    '                    '       "                ," & IfNull(txtSortCode.EditValue, 0) & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtGroupedBy.EditValue), "NULL", "'" & txtGroupedBy.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtSortedBy.EditValue), "NULL", "'" & txtSortedBy.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtRemarks.EditValue), "NULL", "'" & txtRemarks.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(chkUseSelectionList.Checked, 1, 0) & " " & _
    '                    '       "                ," & IIf(chkUseTemplateList.Checked, 1, 0) & " " & _
    '                    '       "                ," & IIf(chkUsePreviewButton.Checked, 1, 0) & " " & _
    '                    '       "                ," & IIf(chkUseExportButton.Checked, 1, 0) & " " & _
    '                    '       "                ," & IIf(chkShowInPopup.Checked, 1, 0) & " " & _
    '                    '       "                ,NULL " & _
    '                    '       "                ,'" & GetSortFieldsAsDelimitedString(GridSortOptionsView) & "' " & _
    '                    '       "                ,NULL " & _
    '                    '       "                ,NULL " & _
    '                    '       "                ," & IIf(IsDBNull(txtDateRangeFromField.EditValue), "NULL", "'" & txtDateRangeFromField.EditValue & "'") & " " & _
    '                    '       "                ," & IIf(IsDBNull(txtDateRangeToField.EditValue), "NULL", "'" & txtDateRangeToField.EditValue & "'") & ")"

    '                    'info = DB.RunSql(cSQL)

    '                    Dim sp As New StoredProcedureCommand("AddEditReportObject", DB)

    '                    With sp.Parameters
    '                        .Add(New StoredProcedureCommand.SPParameter("Mode", "ADD"))
    '                        .Add(New StoredProcedureCommand.SPParameter("ObjectID", IIf(IsDBNull(txtObjectID.EditValue), System.DBNull.Value, txtObjectID.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("Caption", IIf(IsDBNull(txtCaption.EditValue), System.DBNull.Value, txtCaption.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("ReportGroup", IIf(IsDBNull(cboReportGroup.EditValue), System.DBNull.Value, cboReportGroup.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("DLL", IIf(IsDBNull(txtDLL.EditValue), System.DBNull.Value, txtDLL.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("ReportClass", IIf(IsDBNull(txtReportClass.EditValue), System.DBNull.Value, txtReportClass.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionSource", GetSelectionSource(cboSelectionSourceType.EditValue, txtSelectionSource.EditValue, cboSelectionSource.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionSourceType", IIf(IsDBNull(cboSelectionSourceType.EditValue), System.DBNull.Value, cboSelectionSourceType.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionKeyField", IIf(IsDBNull(txtSelectionKeyField.EditValue), System.DBNull.Value, txtSelectionKeyField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionDisplayField", IIf(IsDBNull(txtSelectionDisplayField.EditValue), System.DBNull.Value, txtSelectionDisplayField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionSortField", IIf(IsDBNull(txtSelectionSortField.EditValue), System.DBNull.Value, txtSelectionSortField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("KeyFilterField", IIf(IsDBNull(txtKeyFilterField.EditValue), System.DBNull.Value, txtKeyFilterField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SortCode", IfNull(txtSortCode.EditValue, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("GroupedBy", IIf(IsDBNull(txtGroupedBy.EditValue), System.DBNull.Value, txtGroupedBy.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SortedBy", IIf(IsDBNull(txtSortedBy.EditValue), System.DBNull.Value, txtSortedBy.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("Remarks", IIf(IsDBNull(txtRemarks.EditValue), System.DBNull.Value, txtRemarks.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("UseSelectionList", IIf(chkUseSelectionList.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("UseTemplateList", IIf(chkUseTemplateList.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("UsePreviewButton", IIf(chkUsePreviewButton.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("UseExportButton", IIf(chkUseExportButton.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("ShowInPopup", IIf(chkShowInPopup.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("OpensPopupForm", System.DBNull.Value))
    '                        .Add(New StoredProcedureCommand.SPParameter("SortFields", GetSortFieldsAsDelimitedString(GridSortOptionsView)))
    '                        If optFilterOption_UseSpecific.Checked Then
    '                            .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionDLL", IIf(IsDBNull(txtReportFilterOptionDLL.EditValue), System.DBNull.Value, txtReportFilterOptionDLL.EditValue)))
    '                            .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionClass", IIf(IsDBNull(txtReportFilterOptionClass.EditValue), System.DBNull.Value, txtReportFilterOptionClass.EditValue)))
    '                        Else
    '                            .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionDLL", System.DBNull.Value))
    '                            .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionClass", System.DBNull.Value))
    '                        End If
    '                        .Add(New StoredProcedureCommand.SPParameter("DateRangeFromField", IIf(IsDBNull(txtDateRangeFromField.EditValue), System.DBNull.Value, txtDateRangeFromField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("DateRangeToField", IIf(IsDBNull(txtDateRangeToField.EditValue), System.DBNull.Value, txtDateRangeToField.EditValue)))
    '                    End With

    '                    info = (sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected) > 0)

    '                    BRECORDUPDATEDs = False
    '                    'id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
    '                    'LastObjectID = Trim(IfNull(DB.GetLastInsertedItem("ObjectID", Me.TableName), "ObjectID = '" & FocusedReport.ObjectID & "' AND ReportGroup = '" & FocusedReport.ReportGroup & "'"))
    '                    'LastReportGroup = Trim(IfNull(DB.GetLastInsertedItem("ReportGroup", Me.TableName), "ObjectID = '" & FocusedReport.ObjectID & "' AND ReportGroup = '" & FocusedReport.ReportGroup & "'"))
    '                    'LastObjectID = Trim(IfNull(DB.GetLastInsertedItem("ObjectID", Me.TableName), ""))
    '                    'LastReportGroup = Trim(IfNull(DB.GetLastInsertedItem("ReportGroup", Me.TableName), ""))
    '                    If info Then
    '                        LastObjectID = IIf(IsDBNull(txtObjectID.EditValue), System.DBNull.Value, txtObjectID.EditValue)
    '                        LastReportGroup = IIf(IsDBNull(cboReportGroup.EditValue), System.DBNull.Value, cboReportGroup.EditValue)
    '                    End If
    '                    type = "Inserted"
    '                End If
    '            Else
    '                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtObjectID, txtCaption, cboReportGroup}, "ObjectID<>'" & FocusedReport.ObjectID & "' AND ReportGroup <> '" & FocusedReport.ReportGroup & "'") Then
    '                    Exit Sub
    '                Else
    '                    'id = strID
    '                    'info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & id & "'"))
    '                    'cSQL = "UPDATE      [dbo].[MSystblReports] " & _
    '                    '       "SET         [Caption] = " & IIf(IsDBNull(txtCaption.EditValue), "NULL", "'" & txtCaption.EditValue & "'") & " " & _
    '                    '       "            ,[DLL] = " & IIf(IsDBNull(txtDLL.EditValue), "NULL", "'" & txtDLL.EditValue & "'") & " " & _
    '                    '       "            ,[ReportClass] = " & IIf(IsDBNull(txtReportClass.EditValue), "NULL", "'" & txtReportClass.EditValue & "'") & " " & _
    '                    '       "            ,[SelectionSource] = '" & GetSelectionSource(cboSelectionSourceType.EditValue, txtSelectionSource.EditValue, cboSelectionSource.EditValue) & "' " & _
    '                    '       "            ,[SelectionSourceType] = " & IIf(IsDBNull(cboSelectionSourceType.EditValue), "NULL", "'" & cboSelectionSourceType.EditValue & "'") & " " & _
    '                    '       "            ,[SelectionKeyField] = " & IIf(IsDBNull(txtSelectionKeyField.EditValue), "NULL", "'" & txtSelectionKeyField.EditValue & "'") & " " & _
    '                    '       "            ,[SelectionDisplayField] = " & IIf(IsDBNull(txtSelectionDisplayField.EditValue), "NULL", "'" & txtSelectionDisplayField.EditValue & "'") & " " & _
    '                    '       "            ,[SelectionSortField] = " & IIf(IsDBNull(txtSelectionSortField.EditValue), "NULL", "'" & txtSelectionSortField.EditValue & "'") & " " & _
    '                    '       "            ,[KeyFilterField] = " & IIf(IsDBNull(txtKeyFilterField.EditValue), "NULL", "'" & txtKeyFilterField.EditValue & "'") & " " & _
    '                    '       "            ,[SortCode] = " & IfNull(txtSortCode.EditValue, 0) & " " & _
    '                    '       "            ,[GroupedBy] = " & IIf(IsDBNull(txtGroupedBy.EditValue), "NULL", "'" & txtGroupedBy.EditValue & "'") & " " & _
    '                    '       "            ,[SortedBy] = " & IIf(IsDBNull(txtSortedBy.EditValue), "NULL", "'" & txtSortedBy.EditValue & "'") & " " & _
    '                    '       "            ,[Remarks] = " & IIf(IsDBNull(txtRemarks.EditValue), "NULL", "'" & txtRemarks.EditValue & "'") & " " & _
    '                    '       "            ,[UseSelectionList] = " & IIf(chkUseSelectionList.Checked, 1, 0) & " " & _
    '                    '       "            ,[UseTemplateList] = " & IIf(chkUseTemplateList.Checked, 1, 0) & " " & _
    '                    '       "            ,[UsePreviewButton] = " & IIf(chkUsePreviewButton.Checked, 1, 0) & " " & _
    '                    '       "            ,[UseExportButton] = " & IIf(chkUseExportButton.Checked, 1, 0) & " " & _
    '                    '       "            ,[ShowInPopUp] = " & IIf(chkShowInPopup.Checked, 1, 0) & " " & _
    '                    '       "            ,[SortFields] = '" & GetSortFieldsAsDelimitedString(GridSortOptionsView) & "' " & _
    '                    '       "            ,[ReportFilterOptionDLL] = [ReportFilterOptionDLL] " & _
    '                    '       "            ,[ReportFilterOptionClass] = [ReportFilterOptionClass] " & _
    '                    '       "            ,[DateRangeFromField] = " & IIf(IsDBNull(txtDateRangeFromField.EditValue), "NULL", "'" & txtDateRangeFromField.EditValue & "'") & " " & _
    '                    '       "            ,[DateRangeToField] = " & IIf(IsDBNull(txtDateRangeToField.EditValue), "NULL", "'" & txtDateRangeToField.EditValue & "'") & " " & _
    '                    '       "WHERE       ObjectID = '" & FocusedReport.ObjectID & "' AND ReportGroup = '" & FocusedReport.ReportGroup & "'"

    '                    'info = DB.RunSql(cSQL)

    '                    Dim sp As New StoredProcedureCommand("AddEditReportObject", DB)

    '                    With sp.Parameters
    '                        .Add(New StoredProcedureCommand.SPParameter("Mode", "EDIT"))
    '                        .Add(New StoredProcedureCommand.SPParameter("ObjectID", IIf(IsDBNull(txtObjectID.EditValue), System.DBNull.Value, txtObjectID.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("Caption", IIf(IsDBNull(txtCaption.EditValue), System.DBNull.Value, txtCaption.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("ReportGroup", IIf(IsDBNull(cboReportGroup.EditValue), System.DBNull.Value, cboReportGroup.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("DLL", IIf(IsDBNull(txtDLL.EditValue), System.DBNull.Value, txtDLL.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("ReportClass", IIf(IsDBNull(txtReportClass.EditValue), System.DBNull.Value, txtReportClass.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionSource", GetSelectionSource(cboSelectionSourceType.EditValue, txtSelectionSource.EditValue, cboSelectionSource.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionSourceType", IIf(IsDBNull(cboSelectionSourceType.EditValue), System.DBNull.Value, cboSelectionSourceType.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionKeyField", IIf(IsDBNull(txtSelectionKeyField.EditValue), System.DBNull.Value, txtSelectionKeyField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionDisplayField", IIf(IsDBNull(txtSelectionDisplayField.EditValue), System.DBNull.Value, txtSelectionDisplayField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SelectionSortField", IIf(IsDBNull(txtSelectionSortField.EditValue), System.DBNull.Value, txtSelectionSortField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("KeyFilterField", IIf(IsDBNull(txtKeyFilterField.EditValue), System.DBNull.Value, txtKeyFilterField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SortCode", IfNull(txtSortCode.EditValue, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("GroupedBy", IIf(IsDBNull(txtGroupedBy.EditValue), System.DBNull.Value, txtGroupedBy.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("SortedBy", IIf(IsDBNull(txtSortedBy.EditValue), System.DBNull.Value, txtSortedBy.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("Remarks", IIf(IsDBNull(txtRemarks.EditValue), System.DBNull.Value, txtRemarks.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("UseSelectionList", IIf(chkUseSelectionList.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("UseTemplateList", IIf(chkUseTemplateList.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("UsePreviewButton", IIf(chkUsePreviewButton.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("UseExportButton", IIf(chkUseExportButton.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("ShowInPopup", IIf(chkShowInPopup.Checked, 1, 0)))
    '                        .Add(New StoredProcedureCommand.SPParameter("OpensPopupForm", System.DBNull.Value))
    '                        .Add(New StoredProcedureCommand.SPParameter("SortFields", GetSortFieldsAsDelimitedString(GridSortOptionsView)))
    '                        If optFilterOption_UseSpecific.Checked Then
    '                            .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionDLL", IIf(IsDBNull(txtReportFilterOptionDLL.EditValue), System.DBNull.Value, txtReportFilterOptionDLL.EditValue)))
    '                            .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionClass", IIf(IsDBNull(txtReportFilterOptionClass.EditValue), System.DBNull.Value, txtReportFilterOptionClass.EditValue)))
    '                        Else
    '                            .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionDLL", System.DBNull.Value))
    '                            .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionClass", System.DBNull.Value))
    '                        End If
    '                        .Add(New StoredProcedureCommand.SPParameter("DateRangeFromField", IIf(IsDBNull(txtDateRangeFromField.EditValue), System.DBNull.Value, txtDateRangeFromField.EditValue)))
    '                        .Add(New StoredProcedureCommand.SPParameter("DateRangeToField", IIf(IsDBNull(txtDateRangeToField.EditValue), System.DBNull.Value, txtDateRangeToField.EditValue)))
    '                    End With

    '                    info = (sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected) > 0)

    '                    BRECORDUPDATEDs = False
    '                    LastObjectID = FocusedReport.ObjectID
    '                    LastReportGroup = FocusedReport.ReportGroup
    '                    type = "Updated"
    '                End If
    '            End If

    '            SaveFilerOption()
    '            InitControl_GridReport()
    '            If info Then
    '                SetSelection(LastObjectID, LastReportGroup)
    '                RefreshData()
    '                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
    '                tabDetails.SelectedTabPageIndex = 0
    '            End If

    '            bAddMode = False
    '        End If
    '    Else
    '        info = False
    '        MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
    '    End If
    'End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        RefreshButtons(ButtonMode.Add)

        Me.header.Focus()
        Dim query As New ArrayList, info As Boolean = False, LastObjectID As String = "", LastReportGroup As String = ""
        Dim type As String = ""

        If Not GridHasColumnErrors() Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtObjectID, txtCaption, cboReportGroup, txtDLL, txtReportClass, txtSortCode}) Then

                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtObjectID, cboReportGroup}) Then
                        Exit Sub
                    Else

                        Dim sp As StoredProcedureCommand = ConstructAddEditReportSP("ADD")

                        info = (sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected) > 0)

                        BRECORDUPDATEDs = False

                        'If info Then
                        '    LastObjectID = IIf(IsDBNull(txtObjectID.EditValue), System.DBNull.Value, txtObjectID.EditValue)
                        '    LastReportGroup = IIf(IsDBNull(cboReportGroup.EditValue), System.DBNull.Value, cboReportGroup.EditValue)
                        'End If
                        LastObjectID = IIf(IsDBNull(txtObjectID.EditValue), System.DBNull.Value, txtObjectID.EditValue)
                        LastReportGroup = IIf(IsDBNull(cboReportGroup.EditValue), System.DBNull.Value, cboReportGroup.EditValue)
                        type = "Inserted"
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtObjectID, cboReportGroup}, "ObjectID<>'" & FocusedReport.ObjectID & "' AND ReportGroup <> '" & FocusedReport.ReportGroup & "'") Then
                        Exit Sub
                    Else
                        Dim sp As StoredProcedureCommand = ConstructAddEditReportSP("EDIT")
                        info = (sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected) > 0)

                        BRECORDUPDATEDs = False
                        LastObjectID = IIf(IsDBNull(txtObjectID.EditValue), System.DBNull.Value, txtObjectID.EditValue)
                        LastReportGroup = IIf(IsDBNull(cboReportGroup.EditValue), System.DBNull.Value, cboReportGroup.EditValue)
                        type = "Updated"
                    End If
                End If

                SaveFilerOption()
                InitControl_GridReport()
                SetSelection(LastObjectID, LastReportGroup)
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

    Function ConstructAddEditReportSP(cMode As String) As StoredProcedureCommand
        Dim sp As New StoredProcedureCommand("AddEditReportObject", DB)

        With sp.Parameters
            .Add(New StoredProcedureCommand.SPParameter("Mode", cMode))
            .Add(New StoredProcedureCommand.SPParameter("ObjectID", IIf(IsDBNull(txtObjectID.EditValue), System.DBNull.Value, txtObjectID.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("Caption", IIf(IsDBNull(txtCaption.EditValue), System.DBNull.Value, txtCaption.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("ReportGroup", IIf(IsDBNull(cboReportGroup.EditValue), System.DBNull.Value, cboReportGroup.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("DLL", IIf(IsDBNull(txtDLL.EditValue), System.DBNull.Value, txtDLL.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("ReportClass", IIf(IsDBNull(txtReportClass.EditValue), System.DBNull.Value, txtReportClass.EditValue)))
            If Not IsDBNull(cboSelectionSourceType.EditValue) Then
                .Add(New StoredProcedureCommand.SPParameter("SelectionSource", GetSelectionSource(cboSelectionSourceType.EditValue, txtSelectionSource.EditValue, cboSelectionSource.EditValue)))
                .Add(New StoredProcedureCommand.SPParameter("SelectionSourceType", IIf(IsDBNull(cboSelectionSourceType.EditValue), System.DBNull.Value, cboSelectionSourceType.EditValue)))
                .Add(New StoredProcedureCommand.SPParameter("SelectionKeyField", IIf(IsDBNull(txtSelectionKeyField.EditValue), System.DBNull.Value, txtSelectionKeyField.EditValue)))
                .Add(New StoredProcedureCommand.SPParameter("SelectionDisplayField", IIf(IsDBNull(txtSelectionDisplayField.EditValue), System.DBNull.Value, txtSelectionDisplayField.EditValue)))
                .Add(New StoredProcedureCommand.SPParameter("SelectionSortField", IIf(IsDBNull(txtSelectionSortField.EditValue), System.DBNull.Value, txtSelectionSortField.EditValue)))
                .Add(New StoredProcedureCommand.SPParameter("KeyFilterField", IIf(IsDBNull(txtKeyFilterField.EditValue), System.DBNull.Value, txtKeyFilterField.EditValue)))
            Else
                .Add(New StoredProcedureCommand.SPParameter("SelectionSource", System.DBNull.Value))
                .Add(New StoredProcedureCommand.SPParameter("SelectionSourceType", System.DBNull.Value))
                .Add(New StoredProcedureCommand.SPParameter("SelectionKeyField", System.DBNull.Value))
                .Add(New StoredProcedureCommand.SPParameter("SelectionDisplayField", System.DBNull.Value))
                .Add(New StoredProcedureCommand.SPParameter("SelectionSortField", System.DBNull.Value))
                .Add(New StoredProcedureCommand.SPParameter("KeyFilterField", System.DBNull.Value))
            End If

            .Add(New StoredProcedureCommand.SPParameter("SortCode", IfNull(txtSortCode.EditValue, 0)))
            .Add(New StoredProcedureCommand.SPParameter("GroupedBy", IIf(IsDBNull(txtGroupedBy.EditValue), System.DBNull.Value, txtGroupedBy.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("SortedBy", IIf(IsDBNull(txtSortedBy.EditValue), System.DBNull.Value, txtSortedBy.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("Remarks", IIf(IsDBNull(txtRemarks.EditValue), System.DBNull.Value, txtRemarks.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("UseSelectionList", IIf(chkUseSelectionList.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("UseTemplateList", IIf(chkUseTemplateList.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("UsePreviewButton", IIf(chkUsePreviewButton.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("UseExportButton", IIf(chkUseExportButton.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("ShowInPopup", IIf(chkShowInPopup.Checked, 1, 0)))
            .Add(New StoredProcedureCommand.SPParameter("OpensPopupForm", System.DBNull.Value))
            .Add(New StoredProcedureCommand.SPParameter("SortFields", GetSortFieldsAsDelimitedString(GridSortOptionsView)))
            If optFilterOption_UseSpecific.Checked Then
                .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionDLL", IIf(IsDBNull(txtReportFilterOptionDLL.EditValue), System.DBNull.Value, txtReportFilterOptionDLL.EditValue)))
                .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionClass", IIf(IsDBNull(txtReportFilterOptionClass.EditValue), System.DBNull.Value, txtReportFilterOptionClass.EditValue)))
            Else
                .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionDLL", System.DBNull.Value))
                .Add(New StoredProcedureCommand.SPParameter("ReportFilterOptionClass", System.DBNull.Value))
            End If
            .Add(New StoredProcedureCommand.SPParameter("DateRangeFromField", IIf(IsDBNull(txtDateRangeFromField.EditValue), System.DBNull.Value, txtDateRangeFromField.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("DateRangeToField", IIf(IsDBNull(txtDateRangeToField.EditValue), System.DBNull.Value, txtDateRangeToField.EditValue)))
            .Add(New StoredProcedureCommand.SPParameter("FID", IIf(IsDBNull(txtDateRangeToField.EditValue), System.DBNull.Value, txtFID.EditValue)))
        End With

        Return sp
    End Function

    Sub SaveFilerOption()
        Dim bSuccess As Boolean
        Dim sp As StoredProcedureCommand

        With Me.GridFilterOptionsView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1

                If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                    sp = New StoredProcedureCommand("AddEditReportFilterOption")
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Mode", "ADD"))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("PKey", System.DBNull.Value))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("FKeyReportObjectID", IIf(IfNull(txtObjectID.EditValue, "").Equals(""), System.DBNull.Value, txtObjectID.EditValue)))
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ReportGroup", IIf(IfNull(cboReportGroup.EditValue, "").Equals(""), System.DBNull.Value, cboReportGroup.EditValue)))
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
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("DefaultValue", IIf(IfNull(.GetRowCellValue(i, "DefaultValue"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "DefaultValue"))))

                    bSuccess = sp.Execute(StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected, True)

                Else
                    If Not IfNull(.GetRowCellValue(i, "PKey"), "").Equals("") Then
                        sp = New StoredProcedureCommand("AddEditReportFilterOption")
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Mode", "EDIT"))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("PKey", .GetRowCellValue(i, "PKey")))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("FKeyReportObjectID", IIf(IfNull(txtObjectID.EditValue, "").Equals(""), System.DBNull.Value, txtObjectID.EditValue)))
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("ReportGroup", IIf(IfNull(cboReportGroup.EditValue, "").Equals(""), System.DBNull.Value, cboReportGroup.EditValue)))
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
                        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("DefaultValue", IIf(IfNull(.GetRowCellValue(i, "DefaultValue"), "").Equals(""), System.DBNull.Value, .GetRowCellValue(i, "DefaultValue"))))

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
        If FocusedReport.HasValue Then
            If MsgBox("Do you want to continue delete [" & FocusedReport.ReportGroup & " - " & FocusedReport.Caption & "]?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Dim cSQL As String = "DELETE FROM dbo.MSystblReports WHERE ObjectID = '" & FocusedReport.ObjectID & "' AND ReportGroup = '" & FocusedReport.ReportGroup & "'"
                info = DB.RunSql(cSQL)
                If info Then
                    InitControl_ReportGroup()
                    InitControl_GridReport()
                    RefreshData()
                    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Get Functions"
    Function GetSelectionSource_Focused() As String
        Select Case cboSelectionSourceType.EditValue
            Case SelectionSourceType.ItemList.PKey, SelectionSourceType.Query.PKey, SelectionSourceType.SQL.PKey
                Return IfNull(txtSelectionSource.EditValue, "")

            Case SelectionSourceType.Predef_Ds.PKey
                Return IfNull(cboSelectionSource.EditValue, "")

            Case Else
                Return ""
        End Select
    End Function

    Function GetSelectionSource(cSelectionSourceType As String, textSelectionSource As Object, comboSelectionSource As Object) As String
        Select Case cSelectionSourceType
            Case SelectionSourceType.ItemList.PKey, SelectionSourceType.Query.PKey, SelectionSourceType.SQL.PKey
                Return IfNull(textSelectionSource, "")

            Case SelectionSourceType.Predef_Ds.PKey
                Return IfNull(comboSelectionSource, "")

            Case Else
                Return ""
        End Select
    End Function

    Function GetSortFieldsAsDelimitedString(_view As DevExpress.XtraGrid.Views.Grid.GridView) As String
        Dim Returnvalue As String = ""
        Dim SortFields As New System.Text.StringBuilder
        Dim tmpSortField As String

        For i As Integer = 0 To _view.RowCount - 1
            tmpSortField = ""

            tmpSortField = _view.GetRowCellValue(i, "FieldName") & _
                           "~" & _
                           _view.GetRowCellValue(i, "Caption") & _
                           "~" & _
                           _view.GetRowCellValue(i, "SortOrder") & _
                           "~" & _
                           IIf(_view.GetRowCellValue(i, "isMovable"), 0, 1)

            If SortFields.Length > 0 Then SortFields.Append(";")
            SortFields.Append(tmpSortField)

        Next

        If SortFields.Length > 0 Then Returnvalue = SortFields.ToString

        Return Returnvalue
    End Function
#End Region


    Function GridHasColumnErrors() As Boolean
        If GridFilterOptionsView.HasColumnErrors() Then
            tabDetails.SelectedTabPageIndex = 1
            Return True
            Exit Function
        End If

        If GridSortOptionsView.HasColumnErrors() Then
            tabDetails.SelectedTabPageIndex = 2
            Return True
            Exit Function
        End If

        Return False
    End Function

    Private Sub GridReportsView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles GridReportsView.FocusedRowObjectChanged
        If GridReportsView.FocusedRowHandle >= 0 Then RefreshData()
    End Sub

    Private Sub cboSelectionSourceType_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboSelectionSourceType.EditValueChanged
        RefreshSelectionSource()
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddSave.Click
        If cmdAddSave.Text = "Add" Then
            AddData()
        ElseIf cmdAddSave.Text = "Save" Then
            SaveData()
        End If
    End Sub



    Private Sub cboReportGroup_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboReportGroup.EditValueChanged
        If bAddMode Then
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName, "ReporGroup = '" & cboReportGroup.EditValue & "'")
        End If
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As System.EventArgs) Handles cmdEditCancel.Click
        If cmdEditCancel.Text = "Edit" Then
            EditData()
        ElseIf cmdEditCancel.Text = "Cancel" Then
            RefreshData()
        End If
    End Sub

    Private Sub txtSelectionDisplayField_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtSelectionDisplayField.EditValueChanged
        If bAddMode And Not IfNull(txtSelectionDisplayField.EditValue, "").Equals("") Then
            txtSelectionSortField.EditValue = txtSelectionDisplayField.EditValue
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As System.EventArgs) Handles cmdDelete.Click
        DeleteData()
    End Sub

    Private Sub cmdDeleteSortOption_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeleteSortOption.Click
        Dim rowhandle = GridSortOptionsView.FocusedRowHandle
        If rowhandle >= 0 Then
            GridSortOptionsView.DeleteRow(rowhandle)
        End If
    End Sub

    Private Sub cmdMoveUpSortOption_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoveUpSortOption.Click
        Dim rowhandle = GridSortOptionsView.FocusedRowHandle
        If rowhandle > 0 Then
            Dim dt As DataTable = GridSortOptions.DataSource




            Dim rowBefore As DataRow = GridSortOptionsView.GetDataRow(rowhandle - 1)
            Dim newRow As DataRow = dt.NewRow
            dt.Rows.InsertAt(newRow, rowhandle + 1)
            Dim newlyAddedRow As DataRow = dt.Rows(rowhandle + 1)
            newlyAddedRow.ItemArray = rowBefore.ItemArray
            rowBefore.Delete()

            GridSortOptions.DataSource = dt

            GridSortOptionsView.FocusedRowHandle = rowhandle - 1

        End If
    End Sub

    Private Sub cmdMoveDownSortOption_Click(sender As Object, e As System.EventArgs) Handles cmdMoveDownSortOption.Click
        Dim rowhandle = GridSortOptionsView.FocusedRowHandle
        If rowhandle < GridSortOptionsView.RowCount - 1 And rowhandle >= 0 Then
            Dim dt As DataTable = GridSortOptions.DataSource

            Dim rowAfter As DataRow = GridSortOptionsView.GetDataRow(rowhandle + 1)
            Dim newRow As DataRow = dt.NewRow
            dt.Rows.InsertAt(newRow, rowhandle)
            Dim newlyAddedRow As DataRow = dt.Rows(rowhandle)
            newlyAddedRow.ItemArray = rowAfter.ItemArray
            rowAfter.Delete()

            GridSortOptions.DataSource = dt

            GridSortOptionsView.FocusedRowHandle = rowhandle + 1

        End If
    End Sub

    Private Sub GridFilterOptionsView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridFilterOptionsView.CellValueChanged
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

    Private Sub cmdDeleteFilterOption_Click(sender As Object, e As System.EventArgs) Handles cmdDeleteFilterOption.Click
        If GridFilterOptionsView.FocusedRowHandle >= 0 Then
            Dim cSQL As String = "DELETE FROM dbo." & tblNameReportsOptions & " WHERE PKey = '" & GridFilterOptionsView.GetFocusedRowCellValue("PKey") & "'"
            DB.RunSql(cSQL)
            GridFilterOptionsView.DeleteRow(GridFilterOptionsView.FocusedRowHandle)
            GridFilterOptions.RefreshDataSource()
        End If
    End Sub

    Private Sub cmdMoveDownFilterOption_Click(sender As Object, e As System.EventArgs) Handles cmdMoveDownFilterOption.Click
        MoveFilterOptionUpDown(MoveDirection.Down)
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridFilterOptionsView
        'view.GridControl.Focus()
        'Dim index As Integer = view.FocusedRowHandle
        'If index > view.RowCount - 1 Then
        '    Return
        'End If

        'Dim row1 As DataRow = view.GetDataRow(index)
        'Dim row2 As DataRow = view.GetDataRow(index - 1)
        'Dim val1 As Object = row1(FilterOptionSortField)
        'Dim val2 As Object = row2(FilterOptionSortField)
        'row1(FilterOptionSortField) = val2
        'row2(FilterOptionSortField) = val1

        'view.FocusedRowHandle = index + 1

        'Dim rowhandle = GridFilterOptionsView.FocusedRowHandle
        'If rowhandle < GridFilterOptionsView.RowCount - 1 And rowhandle >= 0 Then
        '    Dim dt As DataTable = GridFilterOptions.DataSource

        '    Dim rowAfterItemArray As Object()
        '    'Dim selRowItemArray As Object()

        '    Dim selRow As DataRow = GridFilterOptionsView.GetDataRow(rowhandle)
        '    Dim rowAfter As DataRow = GridFilterOptionsView.GetDataRow(rowhandle + 1)
        '    rowAfterItemArray = rowAfter.ItemArray
        '    rowAfter.ItemArray = selRow.ItemArray
        '    selRow.ItemArray = rowAfterItemArray

        '    'Dim rowAfter As DataRow = GridFilterOptionsView.GetDataRow(rowhandle + 1)
        '    'Dim newRow As DataRow = dt.NewRow
        '    'dt.Rows.InsertAt(newRow, rowhandle)
        '    'Dim newlyAddedRow As DataRow = dt.Rows(rowhandle)
        '    'newlyAddedRow.ItemArray = rowAfter.ItemArray
        '    'rowAfter.Delete()

        '    'GridFilterOptions.DataSource = dt

        '    GridFilterOptionsView.FocusedRowHandle = rowhandle + 1
        '    GridFilterOptions.RefreshDataSource()
        'End If
        'Dim rowhandle = GridFilterOptionsView.FocusedRowHandle
        'If rowhandle < GridFilterOptionsView.RowCount - 1 And rowhandle >= 0 Then
        '    Dim dt As DataTable = GridFilterOptions.DataSource

        '    Dim rowAfter As DataRow = GridFilterOptionsView.GetDataRow(rowhandle + 1)
        '    Dim newRow As DataRow = dt.NewRow
        '    dt.Rows.InsertAt(newRow, rowhandle)
        '    Dim newlyAddedRow As DataRow = dt.Rows(rowhandle)
        '    newlyAddedRow.ItemArray = rowAfter.ItemArray
        '    rowAfter.Delete()

        '    GridFilterOptions.DataSource = dt

        '    GridFilterOptionsView.FocusedRowHandle = rowhandle + 1
        '    GridFilterOptions.RefreshDataSource()

        'End If

        'Dim rowhandle = GridFilterOptionsView.FocusedRowHandle
        'If rowhandle < GridFilterOptionsView.RowCount - 1 And rowhandle >= 0 Then
        '    Dim dt As New DataTable
        '    dt = GridFilterOptions.DataSource

        '    'get item array of selected row
        '    Dim selRowItemArray As Object() = dt.Rows(rowhandle).ItemArray


        '    dt.Rows.RemoveAt(rowhandle)
        '    Dim newRow As DataRow = dt.NewRow
        '    newRow.ItemArray = selRowItemArray
        '    dt.Rows.InsertAt(newRow, rowhandle + 1)

        '    GridFilterOptions.DataSource = ""
        '    GridFilterOptions.DataSource = dt

        '    GridFilterOptionsView.FocusedRowHandle = rowhandle + 1
        '    GridFilterOptions.RefreshDataSource()

        'End If

        'Dim rowhandle = GridFilterOptionsView.FocusedRowHandle
        'Dim rowhandleafter = rowhandle + 1

        'If rowhandle < GridFilterOptionsView.RowCount - 1 And rowhandle >= 0 Then
        '    Dim dt As New DataTable
        '    dt = GridFilterOptions.DataSource

        '    'Dim row As DataRow = GridFilterOptionsView.GetFocusedDataRow()
        '    'Dim newrow As DataRow = dt.NewRow
        '    'newrow = row
        '    'dt.Rows.InsertAt(newrow, rowhandleafter + 1)
        '    'dt.Rows(rowhandle).Delete()
        '    'GridFilterOptions.DataSource = dt
        '    'GridFilterOptionsView.FocusedRowHandle = rowhandle + 1

        '    Dim selectedRow As DataRow = dt.Rows(rowhandle)
        '    Dim newRow As DataRow = dt.NewRow
        '    newRow.ItemArray = selectedRow.ItemArray
        '    dt.Rows.Remove(selectedRow)
        '    dt.Rows.InsertAt(newRow, rowhandle + 1)
        '    GridFilterOptions.DataSource = dt

        '    '    'get item array of selected row
        '    '    Dim selRowItemArray As Object() = dt.Rows(rowhandle).ItemArray


        '    '    dt.Rows.RemoveAt(rowhandle)
        '    '    Dim newRow As DataRow = dt.NewRow
        '    '    newRow.ItemArray = selRowItemArray
        '    '    dt.Rows.InsertAt(newRow, rowhandle + 1)

        '    '    GridFilterOptions.DataSource = ""
        '    '    GridFilterOptions.DataSource = dt

        '    '    GridFilterOptionsView.FocusedRowHandle = rowhandle + 1
        '    '    GridFilterOptions.RefreshDataSource()

        'End If

        'Dim SourceView As DevExpress.XtraGrid.Views.Grid.GridView, DestView As DevExpress.XtraGrid.Views.Grid.GridView, DestGrid As DevExpress.XtraGrid.GridControl


        'Dim tableDest As DataTable = CType(DestGrid.DataSource, DataTable)
        'Dim RowHandler As Integer = SourceView.FocusedRowHandle
        ''Dim row As DataRow
        'Dim rowsToDelete As New ArrayList

        ''Transfers all selected row from GridA to GridB
        'For i As Integer = 0 To SourceView.SelectedRowsCount - 1
        '    If SourceView.GetSelectedRows()(i) >= 0 Then
        '        row = SourceView.GetDataRow(SourceView.GetSelectedRows()(i))
        '        tableDest.ImportRow(row)
        '        rowsToDelete.Add(row)

        '        If i = SourceView.SelectedRowsCount - 1 Then        'if last index of selected rows
        '            If DestView.LocateByValue(oReportInfo.SelectionKeyField, row(oReportInfo.SelectionKeyField)) >= 0 Then
        '                DestView.FocusedRowHandle = DestView.LocateByValue(oReportInfo.SelectionKeyField, row(oReportInfo.SelectionKeyField))
        '            End If
        '        End If
        '    End If
        'Next
        ''Deletes all selected rows from GridA
        'For i As Integer = 0 To rowsToDelete.Count - 1
        '    row = CType(rowsToDelete(i), DataRow)
        '    row.Delete()
        'Next

        ''Move focus to last selected row's position
        'Try
        '    SourceView.FocusedRowHandle = RowHandler
        'Catch ex As Exception
        '    'go to the very end
        '    SourceView.FocusedRowHandle = SourceView.RowCount - 1
        'End Try

    End Sub

    Private Enum MoveDirection
        Up = 1
        Down = 2
    End Enum

    Private Sub MoveFilterOptionUpDown(MoveDirection As MoveDirection)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridFilterOptionsView
        view.GridControl.Focus()
        Dim index As Integer = view.FocusedRowHandle

        If MoveDirection = ReportConfig.MoveDirection.Down And index >= view.RowCount - 1 Then
            Exit Sub

        ElseIf MoveDirection = ReportConfig.MoveDirection.Up And index <= 0 Then
            Exit Sub

        ElseIf MoveDirection <> ReportConfig.MoveDirection.Down And MoveDirection <> ReportConfig.MoveDirection.Up Then
            Exit Sub
        End If

        Dim newindex As Integer
        newindex = -1
        If MoveDirection = ReportConfig.MoveDirection.Up Then newindex = index - 1
        If MoveDirection = ReportConfig.MoveDirection.Down Then newindex = index + 1

        Dim row1 As DataRow = view.GetDataRow(index)
        Dim row2 As DataRow = view.GetDataRow(newindex)
        Dim val1 As Object = row1(FilterOptionSortField)
        Dim val2 As Object = row2(FilterOptionSortField)
        row1(FilterOptionSortField) = val2
        row2(FilterOptionSortField) = val1

        view.FocusedRowHandle = newindex
    End Sub

    Private Sub cmdMoveUpFilterOption_Click(sender As Object, e As System.EventArgs) Handles cmdMoveUpFilterOption.Click
        MoveFilterOptionUpDown(MoveDirection.Up)
        'Dim rowhandle = GridFilterOptionsView.FocusedRowHandle
        'If rowhandle > 0 Then
        '    Dim dt As DataTable = GridFilterOptions.DataSource

        '    Dim rowBefore As DataRow = GridFilterOptionsView.GetDataRow(rowhandle - 1)
        '    Dim newRow As DataRow = dt.NewRow
        '    dt.Rows.InsertAt(newRow, rowhandle + 1)
        '    Dim newlyAddedRow As DataRow = dt.Rows(rowhandle + 1)
        '    newlyAddedRow.ItemArray = rowBefore.ItemArray
        '    rowBefore.Delete()

        '    GridFilterOptions.DataSource = dt

        '    GridFilterOptionsView.FocusedRowHandle = rowhandle - 1

        'End If
    End Sub

    Private Sub cboReportGroupList_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboReportGroupList.EditValueChanged
        RefreshGridReport()
    End Sub

    Private Sub GridFilterOptionsView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridFilterOptionsView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("ApplyToReportSource"), False)
        View.SetRowCellValue(e.RowHandle, View.Columns("isRowSourceHasUserDataFilter"), False)
        View.SetRowCellValue(e.RowHandle, View.Columns("rn"), View.RowCount + 1)
    End Sub

    Private Sub GridFilterOptionsView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridFilterOptionsView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim columnCaption As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Caption")
        Dim columnFilterOption As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyFilterOption")
        Dim columnApplyToReportSource As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("ApplyToReportSource")
        Dim columnReportKeyFilterField As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("ReportKeyFilterField")
        Dim columnReportHasUserDataFilter As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("isRowSourceHasUserDataFilter")

        Dim bValid As Boolean = True

        'Caption
        If view.GetRowCellValue(e.RowHandle, columnCaption) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, columnCaption) Is Nothing Then
            e.Valid = False
            view.SetColumnError(columnCaption, "Please enter a caption.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        ElseIf view.GetRowCellValue(e.RowHandle, columnCaption) = "" Then
            e.Valid = False
            view.SetColumnError(columnCaption, "Please enter a caption.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        Else
            If bValid Then
                e.Valid = True
                view.ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End If

        'Filter Option Type
        If view.GetRowCellValue(e.RowHandle, columnFilterOption) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, columnFilterOption) Is Nothing Then
            e.Valid = False
            view.SetColumnError(columnFilterOption, "Please select a filter option type.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        ElseIf view.GetRowCellValue(e.RowHandle, columnFilterOption) = "" Then
            e.Valid = False
            view.SetColumnError(columnFilterOption, "Please select a filter option type.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        Else
            If bValid Then
                e.Valid = True
                view.ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End If

        'ApplyToReportSource
        If view.GetRowCellValue(e.RowHandle, columnApplyToReportSource) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, columnApplyToReportSource) Is Nothing Then
            e.Valid = False
            view.SetColumnError(columnApplyToReportSource, "Not set if filter applies to report datasource.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
            'ElseIf view.GetRowCellValue(e.RowHandle, columnApplyToReportSource) = "" Then
            '    e.Valid = False
            '    view.SetColumnError(columnApplyToReportSource, "Please select a filter option type.")
            '    view.FocusedColumn = view.VisibleColumns(0)
            '    AllowSaving(Name, False)
        Else
            If view.GetRowCellValue(e.RowHandle, columnApplyToReportSource) Then
                If view.GetRowCellValue(e.RowHandle, columnReportKeyFilterField) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, columnReportKeyFilterField) Is Nothing Then
                    e.Valid = False
                    view.SetColumnError(columnApplyToReportSource, "Set to apply to report datasource but key filter field is not set.")
                    view.FocusedColumn = view.VisibleColumns(0)
                    AllowSaving(Name, False)
                    bValid = False
                ElseIf view.GetRowCellValue(e.RowHandle, columnReportKeyFilterField) = "" Then
                    e.Valid = False
                    view.SetColumnError(columnApplyToReportSource, "Set to apply to report datasource but key filter field is not set.")
                    view.FocusedColumn = view.VisibleColumns(0)
                    AllowSaving(Name, False)
                    bValid = False
                Else
                    If bValid Then
                        e.Valid = True
                        view.ClearColumnErrors()
                        AllowSaving(Name, True)
                    End If
                End If
            End If
        End If

        'ReportHasUserDataFilter
        If view.GetRowCellValue(e.RowHandle, columnReportHasUserDataFilter) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, columnReportHasUserDataFilter) Is Nothing Then
            e.Valid = False
            view.SetColumnError(columnReportHasUserDataFilter, "Not set if filter applies to report datasource.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
            'ElseIf view.GetRowCellValue(e.RowHandle, columnApplyToReportSource) = "" Then
            '    e.Valid = False
            '    view.SetColumnError(columnApplyToReportSource, "Please select a filter option type.")
            '    view.FocusedColumn = view.VisibleColumns(0)
            '    AllowSaving(Name, False)
        Else
            If bValid Then
                e.Valid = True
                view.ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End If
    End Sub

    Private Sub GridSortOptionsView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridSortOptionsView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.GridSortOptionsView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub GridSortOptionsView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridSortOptionsView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("isMovable"), False)
        View.SetRowCellValue(e.RowHandle, View.Columns("SortOrder"), "NONE")
    End Sub

    Private Sub GridSortOptionsView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridSortOptionsView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim columnCaption As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Caption")
        Dim columnFieldName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FieldName")
        Dim columnSortOrder As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("SortOrder")

        Dim bValid As Boolean = True

        'FieldName
        If view.GetRowCellValue(e.RowHandle, columnFieldName) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, columnFieldName) Is Nothing Then
            e.Valid = False
            view.SetColumnError(columnFieldName, "Please enter the field name.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        ElseIf view.GetRowCellValue(e.RowHandle, columnFieldName) = "" Then
            e.Valid = False
            view.SetColumnError(columnFieldName, "Please enter the field name.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        Else
            If bValid Then
                e.Valid = True
                view.ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End If

        'Caption
        If view.GetRowCellValue(e.RowHandle, columnCaption) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, columnCaption) Is Nothing Then
            e.Valid = False
            view.SetColumnError(columnCaption, "Please enter a caption.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        ElseIf view.GetRowCellValue(e.RowHandle, columnCaption) = "" Then
            e.Valid = False
            view.SetColumnError(columnCaption, "Please enter a caption.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        Else
            If bValid Then
                e.Valid = True
                view.ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End If

        'Default Sort Order
        If view.GetRowCellValue(e.RowHandle, columnSortOrder) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, columnSortOrder) Is Nothing Then
            e.Valid = False
            view.SetColumnError(columnSortOrder, "Must select a default sort order.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        ElseIf view.GetRowCellValue(e.RowHandle, columnSortOrder) = "" Then
            e.Valid = False
            view.SetColumnError(columnSortOrder, "Must select a default sort order.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            bValid = False
        Else
            If bValid Then
                e.Valid = True
                view.ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End If
    End Sub

    Private Sub cmdAddReportGroup_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddReportGroup.Click
        AddReportGroup()
    End Sub

    Private Sub optFilterOption_UseSpecific_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optFilterOption_UseSpecific.CheckedChanged
        EnableSelectedFilterOption(FilterOptionType.Specific)
    End Sub

    Private Sub optFilterOption_UseGeneric_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optFilterOption_UseGeneric.CheckedChanged
        EnableSelectedFilterOption(FilterOptionType.Generic)
    End Sub

    Private Sub chkUseSelectionList_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUseSelectionList.CheckedChanged
        Me.LayoutControlGroup_SelectionSource.Enabled = chkUseSelectionList.Checked
    End Sub

    Private Sub cmdGenerateFID_Click(sender As System.Object, e As System.EventArgs) Handles cmdGenerateFID.Click
        If Not IfNull(txtFID.EditValue, "").Equals("") Then
            If MsgBox("Object is already with an FID. Do you still want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = vbNo Then Exit Sub
        End If

        Dim featureLetter As String = ""
        Dim generatedid As String
        If Not IsNothing(cboFeature.EditValue) Then
            If Not IfNull(cboFeature.EditValue, "").Equals("") Then
                featureLetter = cboFeature.GetColumnValue("Value").ToString()

                If featureLetter <> "" Then
                    generatedid = AES_Encrypt(Trim(txtObjectID.EditValue) & "_" & featureLetter, "spectral")
                    txtFID.Text = generatedid
                    txtFeature.EditValue = GetFeatureName(txtFID.EditValue)
                End If
                MsgBox("Feature ID generated.", MsgBoxStyle.Information)
            End If
        End If

        cboFeature.EditValue = ""
    End Sub


#Region "Generate Script"
    Sub InitControl_GenScript()
        Dim dt As New DataTable
        Dim col As DataColumn

        If cboGenScript.Properties.DataSource = "" Or IsNothing(cboGenScript.Properties.DataSource) Then
            col = New DataColumn
            col.DataType = GetType(System.String)
            col.ColumnName = "PKey"
            dt.Columns.Add(col)

            col = New DataColumn
            col.DataType = GetType(System.String)
            col.ColumnName = "Name"
            dt.Columns.Add(col)

            dt.Rows.Add(New Object() {"INSERT", "Insert"})
            dt.Rows.Add(New Object() {"UPDATE", "Update"})
            dt.Rows.Add(New Object() {"DELETE", "Delete"})

            'Update Gridcontro Properties
            cboGenScript.Properties.DataSource = dt
        End If


        Dim colInfo As DevExpress.XtraEditors.Controls.LookUpColumnInfo
        If cboGenScript.Properties.Columns.Count = 0 Then
            colInfo = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
            colInfo.FieldName = "PKey"
            colInfo.Caption = "PKey"
            colInfo.Visible = False
            cboGenScript.Properties.Columns.Add(colInfo)

            colInfo = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
            colInfo.FieldName = "Name"
            colInfo.Caption = "Name"
            colInfo.Visible = True
            cboGenScript.Properties.Columns.Add(colInfo)
        End If

        cboGenScript.EditValue = DBNull.Value

        cboGenScript.Properties.ShowFooter = False
        cboGenScript.Properties.ShowHeader = False

        cboGenScript.Properties.DisplayMember = "Name"
        cboGenScript.Properties.ValueMember = "PKey"

        cboGenScript.Properties.NullText = "Select..."
    End Sub

    Private Sub cboGenScript_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboGenScript.EditValueChanged
        If Not cboGenScript.EditValue.Equals(DBNull.Value) Then
            GenerateScript(cboGenScript.EditValue)
        End If
    End Sub

    Sub GenerateScript(GenerateAs As String)
        Dim strScript As New System.Text.StringBuilder
        Dim fd As FolderBrowserDialog
        Dim cFile As String

        Try
            Select Case GenerateAs
                Case "INSERT"
                    GenerateScript_Insert(strScript)
                    cboGenScript.EditValue = DBNull.Value

                Case "UPDATE"
                    GenerateScript_Update(strScript)
                    cboGenScript.EditValue = DBNull.Value

                Case "DELETE"
                    GenerateScript_Delete(strScript)
                    cboGenScript.EditValue = DBNull.Value

                Case Else

                    cboGenScript.EditValue = DBNull.Value
                    Exit Sub
            End Select
        Catch ex As Exception
            MsgBox("Problem encountered when generating the script. (Error: " & ex.Message & ")")
        End Try


        MsgBox("Select where you want to save the script.", MsgBoxStyle.Information)
        fd = New FolderBrowserDialog


        If fd.ShowDialog() = DialogResult.OK Then
            cFile = fd.SelectedPath
            cFile = cFile & IIf(Mid(cFile, cFile.Length) = "\", "", "\") & _
                    GenerateAs.ToUpper & "_" & txtObjectID.Text & ".sql"

            If System.IO.File.Exists(cFile) Then
                If MsgBox("File [" & cFile & "] already exists. The file will be replaced." & vbNewLine & _
                          "Do you want to continue?", vbQuestion + vbYesNo) = vbYes Then
                    Kill(cFile)
                Else
                    MsgBox("User canceled.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
        Else
            MsgBox("User canceled.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        System.IO.File.AppendAllText(cFile, strScript.ToString)

        'CHECKS IF FILE IS CREATED
        If System.IO.File.Exists(cFile) Then
            If MsgBox("Script file [" & cFile & "] has been created." & vbNewLine & "Do you want to go to the file now?", vbQuestion + vbYesNo) = MsgBoxResult.Yes Then
                'Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(cFile))
                'Application.DoEvents()
                Process.Start("explorer.exe", "/select," & cFile)
            End If
        Else
            MsgBox("There was a problem creating the generating the file but there were no errors.", vbCritical)
        End If
    End Sub


    Sub GenerateScript_Insert(ByRef strScript As System.Text.StringBuilder)
        strScript.AppendLine("USE [MPS]")
        strScript.AppendLine("INSERT INTO [dbo].[MSystblReports]")
        strScript.AppendLine("([ObjectID]")
        strScript.AppendLine(",[Caption]")
        strScript.AppendLine(",[ReportGroup]")
        strScript.AppendLine(",[DLL]")
        strScript.AppendLine(",[ReportClass]")
        strScript.AppendLine(",[SelectionSourceType]")
        strScript.AppendLine(",[SelectionSource]")
        strScript.AppendLine(",[SelectionKeyField]")
        strScript.AppendLine(",[SelectionDisplayField]")
        strScript.AppendLine(",[SelectionSortField]")
        strScript.AppendLine(",[KeyFilterField]")
        strScript.AppendLine(",[SortCode]")
        strScript.AppendLine(",[GroupedBy]")
        strScript.AppendLine(",[SortedBy]")
        strScript.AppendLine(",[Remarks]")
        strScript.AppendLine(",[UseSelectionList]")
        strScript.AppendLine(",[UseTemplateList]")
        strScript.AppendLine(",[UsePreviewButton]")
        strScript.AppendLine(",[UseExportButton]")
        strScript.AppendLine(",[ShowInPopUp]")
        strScript.AppendLine(",[OpensPopupForm]")
        strScript.AppendLine(",[SortFields]")
        strScript.AppendLine(",[ReportFilterOptions]")
        strScript.AppendLine(",[ReportFilterOptionDLL]")
        strScript.AppendLine(",[ReportFilterOptionClass]")
        strScript.AppendLine(",[DateRangeFromField]")
        strScript.AppendLine(",[DateRangeToField]")
        strScript.AppendLine(",[FID])")

        strScript.AppendLine("VALUES")
        strScript.AppendLine("(" & ChangeToSQLString(txtObjectID.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtCaption.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(cboReportGroup.EditValue) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtDLL.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtReportClass.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(cboSelectionSourceType.EditValue) & " ")
        If cboSelectionSourceType.EditValue = SelectionSourceType.Predef_Ds.PKey Then
            strScript.AppendLine("," & ChangeToSQLString(cboSelectionSource.EditValue) & " ")
        Else
            strScript.AppendLine("," & ChangeToSQLString(txtSelectionSource.Text) & " ")
        End If
        strScript.AppendLine("," & ChangeToSQLString(txtSelectionKeyField.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtSelectionDisplayField.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtSelectionSortField.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtKeyFilterField.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtSortCode.Text, 0) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtGroupedBy.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtSortedBy.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtRemarks.Text) & " ")
        strScript.AppendLine("," & IIf(chkUseSelectionList.Checked, 1, 0) & " ")
        strScript.AppendLine("," & IIf(chkUseTemplateList.Checked, 1, 0) & " ")
        strScript.AppendLine("," & IIf(chkUsePreviewButton.Checked, 1, 0) & " ")
        strScript.AppendLine("," & IIf(chkUseExportButton.Checked, 1, 0) & " ")
        strScript.AppendLine("," & IIf(chkShowInPopup.Checked, 1, 0) & " ")
        strScript.AppendLine(",NULL")
        strScript.AppendLine("," & ChangeToSQLString(GetSortFieldsAsDelimitedString(GridSortOptionsView)) & " ")
        strScript.AppendLine(",NULL")
        If optFilterOption_UseGeneric.Checked Then
            strScript.AppendLine(",NULL")
            strScript.AppendLine(",NULL")
        ElseIf optFilterOption_UseSpecific.Checked Then
            strScript.AppendLine("," & ChangeToSQLString(txtReportFilterOptionDLL.Text) & " ")
            strScript.AppendLine("," & ChangeToSQLString(txtReportFilterOptionClass.Text) & " ")
        Else
            strScript.AppendLine(",NULL")
            strScript.AppendLine(",NULL")
        End If
        strScript.AppendLine("," & ChangeToSQLString(txtDateRangeFromField.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtDateRangeToField.Text) & " ")
        strScript.AppendLine("," & ChangeToSQLString(txtFID.Text) & ") ")

        If GridFilterOptionsView.RowCount > 0 Then
            strScript.AppendLine("")
            strScript.AppendLine("INSERT INTO [dbo].[MSystblReportFilterOptions]")
            strScript.AppendLine("([FKeyReportObjectID]")
            strScript.AppendLine(",[ReportGroup]")
            strScript.AppendLine(",[SortCode]")
            strScript.AppendLine(",[FKeyFilterOption]")
            strScript.AppendLine(",[Caption]")
            strScript.AppendLine(",[ReportKeyFilterField]")
            strScript.AppendLine(",[Operator]")
            strScript.AppendLine(",[ComboBoxCustomRowSource]")
            strScript.AppendLine(",[CustomRowSourceKeyField]")
            strScript.AppendLine(",[CustomRowSourceDisplayField]")
            strScript.AppendLine(",[ApplyToReportSource]")
            strScript.AppendLine(",[isRowSourceHasUserDataFilter]")
            strScript.AppendLine(",[GroupName])")
            strScript.AppendLine("VALUES")

            For i As Integer = 0 To GridFilterOptionsView.RowCount - 1
                With GridFilterOptionsView
                    strScript.AppendLine(IIf(i > 0, ",", "") & "(" & ChangeToSQLString(.GetRowCellValue(i, "FKeyReportObjectID")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "ReportGroup")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "SortCode")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "FKeyFilterOption")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "Caption")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "ReportKeyFilterField")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "Operator")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "ComboBoxCustomRowSource")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "CustomRowSourceKeyField")) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "CustomRowSourceDisplayField")) & " ")
                    strScript.AppendLine("," & IfNull(.GetRowCellValue(i, "ApplyToReportSource"), 0) & " ")
                    strScript.AppendLine("," & IfNull(.GetRowCellValue(i, "isRowSourceHasUserDataFilter"), 0) & " ")
                    strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "GroupName")) & ") ")
                End With

            Next
        End If

    End Sub


    Sub GenerateScript_Update(ByRef strScript As System.Text.StringBuilder)
        strScript.AppendLine("USE [MPS]")
        strScript.AppendLine("")
        strScript.AppendLine("")
        strScript.AppendLine("UPDATE [dbo].[MSystblReports]")
        strScript.AppendLine("SET [Caption] = " & ChangeToSQLString(txtCaption.Text) & " ")
        strScript.AppendLine("    ,[ReportGroup] = " & ChangeToSQLString(cboReportGroup.EditValue) & " ")
        strScript.AppendLine("    ,[DLL] = " & ChangeToSQLString(txtDLL.Text) & " ")
        strScript.AppendLine("    ,[ReportClass] = " & ChangeToSQLString(txtReportClass.Text) & " ")
        strScript.AppendLine("    ,[SelectionSourceType] = " & ChangeToSQLString(cboSelectionSourceType.EditValue) & " ")
        If cboSelectionSourceType.EditValue = SelectionSourceType.Predef_Ds.PKey Then
            strScript.AppendLine("    ,[SelectionSource] = " & ChangeToSQLString(cboSelectionSource.EditValue) & " ")
        Else
            strScript.AppendLine("    ,[SelectionSource] = " & ChangeToSQLString(txtSelectionSource.Text) & " ")
        End If
        strScript.AppendLine("    ,[SelectionKeyField] = " & ChangeToSQLString(txtSelectionKeyField.Text) & " ")
        strScript.AppendLine("    ,[SelectionDisplayField] = " & ChangeToSQLString(txtSelectionDisplayField.Text) & " ")
        strScript.AppendLine("    ,[SelectionSortField] = " & ChangeToSQLString(txtSelectionSortField.Text) & " ")
        strScript.AppendLine("    ,[KeyFilterField] = " & ChangeToSQLString(txtKeyFilterField.Text) & " ")
        strScript.AppendLine("    ,[SortCode] = " & IfNull(txtSortCode.Text, 0) & " ")
        strScript.AppendLine("    ,[GroupedBy] = " & ChangeToSQLString(txtGroupedBy.Text) & " ")
        strScript.AppendLine("    ,[SortedBy] = " & ChangeToSQLString(txtSortedBy.Text) & " ")
        strScript.AppendLine("    ,[Remarks] = " & ChangeToSQLString(txtRemarks.Text) & " ")
        strScript.AppendLine("    ,[UseSelectionList] = " & IIf(chkUseSelectionList.Checked, 1, 0) & " ")
        strScript.AppendLine("    ,[UseTemplateList] = " & IIf(chkUseTemplateList.Checked, 1, 0) & " ")
        strScript.AppendLine("    ,[UsePreviewButton] = " & IIf(chkUsePreviewButton.Checked, 1, 0) & " ")
        strScript.AppendLine("    ,[UseExportButton] = " & IIf(chkUseExportButton.Checked, 1, 0) & " ")
        strScript.AppendLine("    ,[ShowInPopUp] = " & IIf(chkShowInPopup.Checked, 1, 0) & " ")
        strScript.AppendLine("    ,[SortFields] = " & ChangeToSQLString(GetSortFieldsAsDelimitedString(GridSortOptionsView)) & " ")
        If optFilterOption_UseGeneric.Checked Then
            strScript.AppendLine("    ,[ReportFilterOptionDLL] = NULL ")
            strScript.AppendLine("    ,[ReportFilterOptionClass] = NULL ")
        ElseIf optFilterOption_UseSpecific.Checked Then
            strScript.AppendLine("    ,[ReportFilterOptionDLL] = " & ChangeToSQLString(txtReportFilterOptionDLL.Text) & " ")
            strScript.AppendLine("    ,[ReportFilterOptionClass] = " & ChangeToSQLString(txtReportFilterOptionClass.Text) & " ")
        Else
            strScript.AppendLine("    ,[ReportFilterOptionDLL] = NULL ")
            strScript.AppendLine("    ,[ReportFilterOptionClass] = NULL ")
        End If

        strScript.AppendLine("    ,[DateRangeToField] = " & ChangeToSQLString(txtDateRangeToField.Text) & " ")
        strScript.AppendLine("    ,[FID] = " & ChangeToSQLString(txtFID.Text) & " ")
        strScript.AppendLine("WHERE ObjectID = '" & txtObjectID.Text & "'")
        strScript.AppendLine("")

        'For i As Integer = 0 To GridFilterOptionsView.RowCount - 1
        '    With GridFilterOptionsView
        '        strScript.AppendLine("UPDATE [dbo].[MSystblReportFilterOptions]")
        '        strScript.AppendLine("SET [ReportGroup] = " & ChangeToSQLString(.GetRowCellValue(i, "ReportGroup")) & " ")
        '        strScript.AppendLine("   ,[SortCode] = " & IfNull(.GetRowCellValue(i, "SortCode"), 0) & " ")
        '        strScript.AppendLine("   ,[FKeyFilterOption] = " & ChangeToSQLString(.GetRowCellValue(i, "FKeyFilterOption")) & " ")
        '        strScript.AppendLine("   ,[Caption] = " & ChangeToSQLString(.GetRowCellValue(i, "Caption")) & " ")
        '        strScript.AppendLine("   ,[ReportKeyFilterField] = " & ChangeToSQLString(.GetRowCellValue(i, "ReportKeyFilterField")) & " ")
        '        strScript.AppendLine("   ,[Operator] = " & ChangeToSQLString(.GetRowCellValue(i, "Operator")) & " ")
        '        strScript.AppendLine("   ,[ComboBoxCustomRowSource] = " & ChangeToSQLString(.GetRowCellValue(i, "ComboBoxCustomRowSource")) & " ")
        '        strScript.AppendLine("   ,[CustomRowSourceKeyField] = " & ChangeToSQLString(.GetRowCellValue(i, "CustomRowSourceKeyField")) & " ")
        '        strScript.AppendLine("   ,[CustomRowSourceDisplayField] = " & ChangeToSQLString(.GetRowCellValue(i, "CustomRowSourceDisplayField")) & " ")
        '        strScript.AppendLine("   ,[ApplyToReportSource] = " & IfNull(.GetRowCellValue(i, "ApplyToReportSource"), 0) & " ")
        '        strScript.AppendLine("   ,[isRowSourceHasUserDataFilter] = " & IfNull(.GetRowCellValue(i, "isRowSourceHasUserDataFilter"), 0) & " ")
        '        strScript.AppendLine("   ,[GroupName] = " & ChangeToSQLString(.GetRowCellValue(i, "GroupName")) & " ")
        '        strScript.AppendLine("WHERE PKey = '" & .GetRowCellValue(i, "PKey") & " AND FKeyReportObjectID = '" & .GetRowCellValue(i, "FKeyReportObjectID")_& "'")
        '    End With
        'Next
        strScript.AppendLine("DELETE FROM dbo.[MSystblReportFilterOptions] WHERE FKeyReportObjectID = '" & txtObjectID.Text & "'")
        strScript.AppendLine("")

        If GridFilterOptionsView.RowCount > 0 Then
            strScript.AppendLine("")
            strScript.AppendLine("INSERT INTO [dbo].[MSystblReportFilterOptions]")
            strScript.AppendLine("([PKey]")
            strScript.AppendLine(",[FKeyReportObjectID]")
            strScript.AppendLine(",[ReportGroup]")
            strScript.AppendLine(",[SortCode]")
            strScript.AppendLine(",[FKeyFilterOption]")
            strScript.AppendLine(",[Caption]")
            strScript.AppendLine(",[ReportKeyFilterField]")
            strScript.AppendLine(",[Operator]")
            strScript.AppendLine(",[ComboBoxCustomRowSource]")
            strScript.AppendLine(",[CustomRowSourceKeyField]")
            strScript.AppendLine(",[CustomRowSourceDisplayField]")
            strScript.AppendLine(",[ApplyToReportSource]")
            strScript.AppendLine(",[isRowSourceHasUserDataFilter]")
            strScript.AppendLine(",[GroupName])")
            strScript.AppendLine("VALUES")
        End If


        For i As Integer = 0 To GridFilterOptionsView.RowCount - 1
            With GridFilterOptionsView
                strScript.AppendLine(IIf(i > 0, ",", "") & "(" & ChangeToSQLString(.GetRowCellValue(i, "PKey")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "FKeyReportObjectID")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "ReportGroup")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "SortCode")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "FKeyFilterOption")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "Caption")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "ReportKeyFilterField")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "Operator")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "ComboBoxCustomRowSource")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "CustomRowSourceKeyField")) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "CustomRowSourceDisplayField")) & " ")
                strScript.AppendLine("," & IfNull(.GetRowCellValue(i, "ApplyToReportSource"), 0) & " ")
                strScript.AppendLine("," & IfNull(.GetRowCellValue(i, "isRowSourceHasUserDataFilter"), 0) & " ")
                strScript.AppendLine("," & ChangeToSQLString(.GetRowCellValue(i, "GroupName")) & ") ")
            End With

        Next

    End Sub

    Sub GenerateScript_Delete(ByRef strScript As System.Text.StringBuilder)
        strScript.AppendLine("DELETE FROM dbo.[MSystblReportFilterOptions] WHERE FKeyReportObjectID = '" & txtObjectID.Text & "'")
        strScript.AppendLine("DELETE FROM dbo.[MSystblReports] WHERE ObjectID = '" & txtObjectID.Text & "'")
    End Sub



#End Region

    Private Sub cboSelectionSource_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboSelectionSource.ButtonClick
        'If cmdEditCancel.Text = "Cancel" Then
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            If IfNull(cboSelectionSource.EditValue, "").Length > 0 Then
                Dim foundrows As DataRow() = TryCast(cboSelectionSource.Properties.DataSource, DataTable).Select("Code = '" & cboSelectionSource.EditValue & "'")
                If foundrows.Count > 0 Then
                    Dim o As New frmSelectionSourceDataSample.SelectionSourceStructure
                    With o
                        .Code = foundrows(0)("Code")
                        .SQLScript = foundrows(0)("SQLScript")
                        .Type = foundrows(0)("Type")
                        .OrderBy = foundrows(0)("OrderBy")
                        .AgentFieldName = foundrows(0)("AgentFieldName")
                        .PrincipalFieldName = foundrows(0)("PrincipalFieldName")
                        .FleetFieldName = foundrows(0)("FleetFieldName")
                        .VesselFieldName = foundrows(0)("VesselFieldName")
                        .Description = foundrows(0)("Description")

                        .DisplayValueField = txtSelectionDisplayField.EditValue
                    End With

                    Dim f As New frmSelectionSourceDataSample(o)
                    f.ShowDialog()
                End If
            End If
        End If
        'End If

    End Sub

    Private Sub repFilterOption_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFilterOption.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            Dim foundrow() As DataRow = TryCast(repFilterOption.DataSource, DataTable).Select("ObjectID = '" & GridFilterOptionsView.GetFocusedRowCellValue("FKeyFilterOption") & "'")

            If foundrow.Count > 0 Then
                If Not foundrow(0)("ControlType").Equals("COMBOBOX") Then
                    MsgBox("Applicable only for Filter Option of COMBOBOX type", MsgBoxStyle.Information)
                    Exit Sub
                End If
                Dim o As New frmFilterOptionDataSample.FilterOptionDataStructure
                With o
                    .ObjecID = foundrow(0)("ObjectID")
                    .Description = foundrow(0)("Description")
                    .OptionType = foundrow(0)("OptionType")
                    .ValueFieldType = foundrow(0)("ValueFieldType")
                    .ControlType = foundrow(0)("ControlType")
                    .RowSourceType = foundrow(0)("RowSourceType")
                    .RowSource = foundrow(0)("RowSource")
                    .RowSourceValueField = foundrow(0)("RowSourceValueField")
                    .RowSourceDisplayField = foundrow(0)("RowSourceDisplayField")
                    .RowSourceSortField = foundrow(0)("RowSourceSortField")

                    .FilterCaption = GridFilterOptionsView.GetFocusedRowCellValue("Caption")
                End With

                Dim f As New frmFilterOptionDataSample(o)
                f.ShowDialog()
            End If
            
        End If
    End Sub
End Class
