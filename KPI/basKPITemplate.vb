Imports Reports
Imports MPS4

Public Module basKPITemplate
    Dim oKPI As KPI

#Region "Generate"
    Public Sub GenerateKPIFromTemplate(TemplatePKey As String, Optional Mode As ReportOutputMode = ReportOutputMode.Preview, Optional ShowMessage As Boolean = True)
        Dim oChartControl As New DevExpress.XtraCharts.ChartControl
        Dim oKPIDetail As KPIDetail = GenerateKPIDetailFromTemplate(TemplatePKey)

        'GenerateChart(oChartControl, oKPIDetail, GetSelectionAsArrayListFromTemplate(TemplatePKey, oKPIDetail))
        Dim result As New KPIResult(oChartControl, oKPIDetail, GetSelectionAsDTFromTemplate(TemplatePKey, oKPIDetail), oKPIDetail.SelectionListing, oKPIDetail.Period, oKPIDetail.DateCoverage.Period._From, oKPIDetail.DateCoverage.Period._To)

        Select Case Mode
            Case ReportOutputMode.Preview
                CreatePopupResult(oChartControl, oKPIDetail.Name)

            Case ReportOutputMode.Export
                'do export method here

        End Select
    End Sub

    Public Function GenerateKPIDetailFromTemplate(TemplateKey As String, Optional initDateCoverageFromTemplate As Boolean = True) As KPIDetail
        Dim oKPIDetail As New KPIDetail
        Dim foundrows() As DataRow

        Dim dtKPI As DataTable = MPSDB.CreateTable("SELECT TOP 1 * FROM dbo.tblKPI WHERE PKey = (SELECT ReportObjectID FROM dbo.MSystblRepOptTemplate WHERE ReportGroup = 'KPI' AND PKey = '" & TemplateKey & "')")
        Dim dtTemplateValues As DataTable = CreateReportTemplateValuesDT(TemplateKey)

        If dtKPI.Rows.Count = 0 Then
            Return Nothing
            Exit Function
        End If

        Dim dr As DataRow = dtKPI.Rows(0)

        oKPIDetail = New KPIDetail
        With oKPIDetail
            .KPICode = dr("PKey")
            .Name = IfNull(dr("Name"), "")
            .KPITypeName = IfNull(dr("KPIType"), "")
            .Title.MainTitle = IfNull(dr("Name"), "")
            .Title.SubTitle = IfNull(dr("SubTitle"), "")
            .Title.FooterNote = IfNull(dr("FooterNote"), "")
            .AxisLabel.AxisXLabel = IfNull(dr("AxisXLabel"), "")
            .AxisLabel.AxisYLabel = IfNull(dr("AxisYLabel"), "")

            'CHART VIEW
            Dim nChartView As KPI.ChartView
            foundrows = dtTemplateValues.Select("OptionsObjectID = 'CHARTVIEW'")
            If foundrows.GetUpperBound(0) >= 0 Then
                nChartView = foundrows(0)("Value")
            Else
                nChartView = GetUserSetting("KPIColorPalette", "Default")
            End If
            nChartView = ChangeChartViewNameToNum(IfNull(dr("DefaultChartView"), "Bar"), KPI.ChartView.SimpleBar)
            .ChartView = nChartView
            .DateCoverage.Type = IfNull(dr("DateCoverageType"), "")

            If .NeedDateCoverage Then
                foundrows = dtTemplateValues.Select("OptionsType = '" & ReportTemplateContentType.KPIDateCoverageType & "'")
                If foundrows.Count > 0 Then
                    .Result.DateCoverageType = foundrows(0)("Value")
                End If
            End If

            foundrows = dtTemplateValues.Select("OptionsType = '" & ReportTemplateContentType.KPISelectionListing & "'")
            If foundrows.Count > 0 Then
                .Result.SelectionListing = foundrows(0)("Value")
            End If

            If initDateCoverageFromTemplate Then
                If .DateCoverage.Type = KPIDateCoverageType.FromAndTo Then
                    foundrows = dtTemplateValues.Select("OptionsObjectID = '" & KPIDateCoverageParam.PeriodFrom & "' OR OptionsObjectID = '" & KPIDateCoverageParam.PeriodTo & "'")
                    For i As Integer = 0 To foundrows.GetUpperBound(0)
                        If foundrows(i)("OptionsObjectID") = KPIDateCoverageParam.PeriodFrom Then
                            .DateCoverage.Period._From = foundrows(i)("Value")
                        ElseIf foundrows(i)("OptionsObjectID") = KPIDateCoverageParam.PeriodTo Then
                            .DateCoverage.Period._To = foundrows(i)("Value")
                        End If
                    Next i
                ElseIf .DateCoverage.Type = KPIDateCoverageType.DateAsOf Then
                    foundrows = dtTemplateValues.Select("OptionsObjectID = '" & KPIDateCoverageParam.PeriodTo)
                    .DateCoverage.Period._From = Nothing
                    .DateCoverage.Period._To = foundrows(0)("Value")
                End If
            End If

            .StoredProcedureName = IfNull(dr("StoredProcedureName"), "")
            .SelectionListing = IfNull(dr("SelectionListing"), "")
            .MultiSelection = IfNull(dr("isMultiSelection"), True)
            .MinReq = IfNull(dr("MinReq"), 0)
            .Target = IfNull(dr("Target"), 0)
            .NeedDateCoverage = IfNull(dr("NeedDateCoverage"), False)
            .UsePercentInPieChartView = IfNull(dr("PieView_UsePercentage"), False)
            .Formula.FormulaString = IfNull(dr("Formula"), "")
            If IfNull(dr("FormulaImage"), "").Length > 0 Then
                .Formula.FormulaImage = dr("FormulaImage")
            Else
                .Formula.FormulaImage = Nothing
            End If
            .Period = IfNull(dr("FKeyPeriod"), "")

            foundrows = dtTemplateValues.Select("OptionsObjectID = 'COLORPALETTE'")
            If foundrows.GetUpperBound(0) >= 0 Then
                .ColorPalette = foundrows(0)("Value")
            Else
                .ColorPalette = GetUserSetting("KPIColorPalette", "Default")
            End If


            Dim oFilterOption As BaseFilterOption = CreateKPIFilterOption(oKPIDetail)
            If Not IsNothing(oFilterOption) Then
                'GET EXTRA CONDITION FROM FILTER OPTION
                oFilterOption.RefreshData()
                .DataSourceCondition = oFilterOption.GetWhereString()                                  'Where condition based on the items from the Filter Option
                '---------------------------
                .FilterOption = oFilterOption                                                   'Filter Option Class Object
            End If

        End With

        'GET EXTRA CONDITION IF KPI USES USER-DATA FILTER
        If IfNull(dr("UserDataFilter_AgentField"), "").ToString.Length > 0 Or _
            IfNull(dr("UserDataFilter_PrinField"), "").ToString.Length > 0 Or _
            IfNull(dr("UserDataFilter_FleetField"), "").ToString.Length > 0 Then

            Dim cUserDataFilterString = GetUserFilterString(, IfNull(dr("UserDataFilter_AgentField"), ""), IfNull(dr("UserDataFilter_PrinField"), ""), IfNull(dr("UserDataFilter_FleetField"), ""))

            oKPIDetail.DataSourceCondition = oKPIDetail.DataSourceCondition & IIf(oKPIDetail.DataSourceCondition.Length > 0 And cUserDataFilterString.Length > 0, " AND ", "") & cUserDataFilterString
        End If

        Try
            '-- CHECKS WHAT CHART VIEWS ARE ALLOWED TO BE USED FOR VIEWING
            Dim arrList As New ArrayList
            If IfNull(dr("AllowChartView_Bar"), 0) <> 0 Then arrList.Add(KPI.ChartView.SimpleBar)
            If IfNull(dr("AllowChartView_Line"), 0) <> 0 Then arrList.Add(KPI.ChartView.SimpleLine)
            If IfNull(dr("AllowChartView_Area"), 0) <> 0 Then arrList.Add(KPI.ChartView.SimpleArea)
            If IfNull(dr("AllowChartView_Pie"), 0) <> 0 Then arrList.Add(KPI.ChartView.SimplePie)

            If arrList.Count = 0 Then
                'use Bar only as default
                arrList.Add(KPI.ChartView.SimpleBar)
            End If

            oKPIDetail.AllowedChartViewList = arrList
            '-------------------------------------------------------------------------------------------------------------------------------------

            If dr("DefaultChartView").ToString.Length > 0 Then
                'oKPIDetail.DefaultChartView = ResultGenerator.GetChartViewValue(dr("DefaultChartView"), ResultGenerator.KPIChartViewValue.Number)
                oKPIDetail.DefaultChartView = ChangeChartViewNameToNum(IfNull(dr("DefaultChartView"), ""), KPI.ChartView.SimpleBar)
            Else
                'use Bar as default if not specified
                oKPIDetail.DefaultChartView = KPI.ChartView.SimpleBar
            End If

            '-------------------------------------------------------------------------------------------------------------------------------------

        Catch ex As Exception
            'do nothing
            oKPIDetail.DefaultChartView = KPI.ChartView.SimpleBar
        End Try

        Return oKPIDetail
    End Function

    'Function CreateFilterOptionObject(oKPIDetail As KPIDetail) As BaseFilterOption
    '    '### Description: Creates a Filter Option Object

    '    Dim ReturnValue As BaseFilterOption = Nothing
    '    Dim oFilterOption As New BaseFilterOption
    '    Dim extAssembly As System.Reflection.Assembly
    '    Dim cAddlFilterOption As String = ""

    '    If Not IsNothing(oKPIDetail.DataSourceCondition) Then
    '        cAddlFilterOption = oKPIDetail.DataSourceCondition
    '    End If

    '    extAssembly = System.Reflection.Assembly.Load(DefaultFilterOptionControlDLL)
    '    oFilterOption = extAssembly.CreateInstance(DefaultFilterOptionControlDLL & "." & DefaultFilterOptionControl, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)

    '    If Not oFilterOption Is Nothing Then
    '        oFilterOption.UsedBy = BaseFilterOption.ReportFilterOptionUser.KPI
    '        Dim cFilterOptionParam As String = MPSDB.DLookUp("CriteriaFieldValue", "MSysRptDataMapping", "", "PKey = 'KPI_FILTER_OPTIONS_DEFAULT'")


    '        oFilterOption.ReportObjectID = "KPI"
    '        oFilterOption.ReportGroup = "KPI"
    '        oFilterOption.RefreshData()
    '        ReturnValue = oFilterOption
    '    End If

    '    Return ReturnValue
    'End Function

    Public Function GetSelectionAsArrayListFromTemplate(TemplateKey As String, oKPIDetail As KPIDetail) As ArrayList
        Dim Rows As New ArrayList
        ' Add the selected rows to the list.
        Dim dt As DataTable = CreateReportTemplateValuesDT(TemplateKey, ReportTemplateContentType.DataSelection)
        Dim dtSelectionList As DataTable = CreateKPISelectionList(oKPIDetail.Result.SelectionListing)

        Dim foundrows() As DataRow

        If dtSelectionList.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                foundrows = dtSelectionList.Select("ColumnKey = '" & dr("Value") & "'")
                If foundrows.GetUpperBound(0) >= 0 Then
                    Rows.Add(New Object() {foundrows(0)("ColumnKey"), foundrows(0)("ColumnDisplay")})
                End If
            Next
        End If

        Return Rows
    End Function

    Function GetSelectionAsDTFromTemplate(TemplateKey As String, oKPIDetail As KPIDetail) As DataTable
        Dim ReturnValue As New DataTable
        Dim col As New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        ReturnValue.Columns.Add(col)

        Dim dt As DataTable = CreateReportTemplateValuesDT(TemplateKey, ReportTemplateContentType.DataSelection)
        Dim dtSelectionList As DataTable = CreateKPISelectionList(oKPIDetail.Result.SelectionListing)

        Dim foundrows() As DataRow

        If dtSelectionList.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                foundrows = dtSelectionList.Select("ColumnKey = '" & dr("Value") & "'")
                If foundrows.GetUpperBound(0) >= 0 Then
                    ReturnValue.Rows.Add(New Object() {foundrows(0)("ColumnKey")})
                End If
            Next
        End If

        Return ReturnValue

    End Function
#End Region

#Region "Load"
    Public Sub LoadKPITemplate(ByRef sender As KPI, SelectedTemplateDetails As ReportTemplateDetail, Optional ByVal ConfirmFirst As Boolean = True)
        '####################################################################################################################################################################################################################################
        '## Load a Selected Template

        '####################################################################################################################################################################################################################################
        'DECLARE VARIABLES
        Dim bViewAfterLoadTemplate As Boolean = False

        '####################################################################################################################################################################################################################################

        oKPI = sender

        If SelectedTemplateDetails.PKey.Length > 0 Then
            Dim bProceed As Boolean = False
            If ConfirmFirst Then
                'bProceed = (MsgBox("Load Template: '" & SelectedTemplateDetails.Name & "'?", 36, GetAppName) = vbYes)
                bProceed = isLoadTemplate(frmLoadTemplate.UsedBy.KPI, bViewAfterLoadTemplate, SelectedTemplateDetails.Name, True)
            Else
                bProceed = True
            End If

            If bProceed Then
                OpenReportWaitForm()
                Try
                    oKPI.oFilterOption.ClearFilterValueAll(False)
                    oKPI.ClearSelectionListFilter()
                    oKPI.SelectDeselectAll(KPI.SelectDeselectMode.DeselectAll)

                    '####################################################################################################################################################################################################################################
                    LoadKPITemplateSelectionListing(SelectedTemplateDetails)

                    '####################################################################################################################################################################################################################################
                    'LOAD SELECTED DATA VALUES FROM TEMPLATE
                    LoadKPITemplateSelectedDataValues(SelectedTemplateDetails)

                    '####################################################################################################################################################################################################################################
                    LoadKPITemplateDateCoverageType(SelectedTemplateDetails)

                    '####################################################################################################################################################################################################################################
                    'LOAD DATE COVERAGE FROM TEMPLATE
                    LoadKPITemplateDateCoverageValues(SelectedTemplateDetails)

                    '####################################################################################################################################################################################################################################
                    'LOAD FILTER OPTION VALUES FROM TEMPLATE
                    oKPI.oFilterOption.LoadFilterOptionTemplateValues(SelectedTemplateDetails.PKey)

                    '####################################################################################################################################################################################################################################
                    'APPLIES THE LOADED TEMPLATE OPTION VALUES TO THE PRINT SELECTION
                    oKPI.oFilterOption.ApplyFilterToPrintSelection()
                    CloseReportWaitForm()

                    If bViewAfterLoadTemplate Then sender.ExecCustomFunction(New Object() {"GENERATERESULT"})
                Catch ex As Exception
                    Dim cErr As String = ex.Message
                    CloseReportWaitForm()
                    LogErrors("Failed to load report template [" & SelectedTemplateDetails.Name & "] of report [" & oKPI.oKPIDetail.Name & "]." & Chr(13) & "Error: " & cErr)
                    MsgBox("Failed to load report template [" & SelectedTemplateDetails.Name & "]." & Chr(13) & "Error: " & cErr, MsgBoxStyle.Exclamation)
                End Try
            End If
        Else
            MsgBox("Please select template to load.", MsgBoxStyle.Information, GetAppName)
        End If
    End Sub

    Public Sub LoadKPITemplateSelectionListing(TemplateDetails As ReportTemplateDetail)
        '####################################################################################################################################################################################################################################
        'Description: Loads the Selected Data values from the selected template
        Dim row As DataRow = Nothing
        Dim oControl As New Control
        Dim templateItems As DataTable = basReportTemplate.CreateReportTemplateValuesDT(TemplateDetails.PKey, ReportTemplateContentType.KPISelectionListing)
        If templateItems.Rows.Count = 0 Then Exit Sub

        If templateItems.Rows.Count > 0 Then
            Try
                oKPI.cboSelectionType.EditValue = templateItems.Rows(0)("Value")
            Catch ex As Exception
                LogErrors("Failed to load selection listing type [" & row("OptionsObjectID") & " = " & row("Value") & "] from template '" & TemplateDetails.Name & "'.")
            End Try
        End If
    End Sub

    Public Sub LoadKPITemplateSelectedDataValues(TemplateDetails As ReportTemplateDetail)
        '####################################################################################################################################################################################################################################
        'Description: Loads the Selected Data values from the selected template
        Dim row As DataRow = Nothing
        Dim oControl As New Control
        Dim templateItems As DataTable = basReportTemplate.CreateReportTemplateValuesDT(TemplateDetails.PKey, ReportTemplateContentType.DataSelection)
        If templateItems.Rows.Count = 0 Then Exit Sub

        For Each templateRow As DataRow In templateItems.Rows
            Try
                'oKPI.GridSelectionListView.SelectRows

                Dim rowhandle As Integer = oKPI.GridSelectionListView.LocateByValue("ColumnKey", templateRow("Value"))
                If rowhandle <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                    oKPI.GridSelectionListView.SelectRow(rowhandle)
                End If

            Catch ex As Exception
                LogErrors("Failed to load selected data [" & row("OptionsObjectID") & " = " & row("Value") & "] from template '" & TemplateDetails.Name & "'.")
            End Try
        Next
    End Sub

    Public Sub LoadKPITemplateDateCoverageType(TemplateDetails As ReportTemplateDetail)
        '####################################################################################################################################################################################################################################
        'Description: Loads the Selected Data values from the selected template
        Dim row As DataRow = Nothing
        Dim oControl As New Control
        Dim templateItems As DataTable = basReportTemplate.CreateReportTemplateValuesDT(TemplateDetails.PKey, ReportTemplateContentType.KPIDateCoverageType)
        If templateItems.Rows.Count = 0 Then Exit Sub

        If templateItems.Rows.Count > 0 Then
            Try
                oKPI.cboDateCoverageType.EditValue = templateItems.Rows(0)("Value")
            Catch ex As Exception
                LogErrors("Failed to load date coverage type [" & row("OptionsObjectID") & " = " & row("Value") & "] from template '" & TemplateDetails.Name & "'.")
            End Try
        End If
    End Sub

    Public Sub LoadKPITemplateDateCoverageValues(TemplateDetails As ReportTemplateDetail)
        '####################################################################################################################################################################################################################################
        'Description: Loads the Selected Data values from the selected template
        'Dim row As DataRow = Nothing
        Dim oControl As New Control
        Dim templateObjectID As String = ""
        Dim templateValue As String = ""
        Dim templateItems As DataTable = basReportTemplate.CreateReportTemplateValuesDT(TemplateDetails.PKey, ReportTemplateContentType.KPIDateCoverage)
        If templateItems.Rows.Count = 0 Then Exit Sub

        For Each templateRow As DataRow In templateItems.Rows
            templateObjectID = templateRow("OptionsObjectID")
            templateValue = templateRow("Value")

            Try
                '####################################################################################################################################################################################################################################
                If Not IsNothing(templateValue) Then
                    If templateValue.Length > 0 Then
                        Try
                            Select Case templateObjectID
                                Case KPIDateCoverageParam.PeriodFrom
                                    'oKPI.cboPeriodFrom.EditValue = CLng(templateValue)
                                    'oKPI.cboPeriodFrom.EditValue = templateValue
                                    oKPI.SetDateCoverageValue(KPIDateCoverageParam.PeriodFrom, CInt(templateValue), False)

                                Case KPIDateCoverageParam.PeriodTo
                                    'oKPI.cboPeriodTo.EditValue = CLng(templateValue)
                                    'oKPI.cboPeriodTo.EditValue = templateValue
                                    oKPI.SetDateCoverageValue(KPIDateCoverageParam.PeriodTo, CInt(templateValue), False)

                                Case KPIDateCoverageParam.DateAsOf
                                    'oKPI.cboPeriodTo.EditValue = CDate(templateValue)
                                    oKPI.SetDateCoverageValue(KPIDateCoverageParam.DateAsOf, CDate(templateValue), False)

                            End Select
                        Catch ex As Exception
                            LogErrors("Failed to cast from value [" & templateValue & "] with type of [" & templateObjectID & "] from template to KPI date coverage type.")
                            LogErrors(ex.Message)
                        End Try
                    End If
                End If

                'FROM
                If templateObjectID.Equals(KPIDateCoverageParam.PeriodFrom) Then
                    If Not IsNothing(templateValue) Then
                        If templateValue.Length > 0 Then
                            Try
                                oKPI.cboPeriodFrom.EditValue = CLng(templateValue)
                            Catch ex As Exception
                                LogErrors("Failed to cast from value '" & templateRow("Value") & "' from template to integer")
                                LogErrors(ex.Message)
                            End Try
                        End If
                    End If
                End If

                If Not IsNothing(templateValue) Then
                    'If templateValue.Equals(KPI
                End If
            Catch ex As Exception
                LogErrors("Failed to load Date Coverage values from template.")
                LogErrors(ex.Message)
            End Try


            'Try

            '    If templateRow("OptionsObjectID").Equals(KPIDateCoverageParam.PeriodFrom) Then
            '        If Not IsNothing(templateRow("Value")) Then
            '            If templateRow("Value").ToString.Length > 0 Then
            '                Try
            '                    oKPI.cboPeriodFrom.EditValue = DirectCast(templateRow("Value"), Integer)
            '                Catch ex As Exception
            '                    LogErrors("Failed to cast from value '" & templateRow("Value") & "' from template to integer")
            '                    LogErrors(ex.Message)
            '                End Try
            '            End If
            '        End If
            '    End If

            '    If templateRow("OptionsObjectID").Equals(KPIDateCoverageParam.PeriodTo) Then
            '        If Not IsNothing(templateRow("Value")) Then
            '            If templateRow("Value").ToString.Length > 0 Then
            '                Try
            '                    oKPI.cboPeriodTo.EditValue = DirectCast(templateRow("Value"), Integer)
            '                Catch
            '                End Try
            '            End If
            '        End If
            '    End If

            '    If templateRow("OptionsObjectID").Equals(KPIDateCoverageParam.DateAsOf) Then
            '        If Not IsNothing(templateRow("Value")) Then
            '            If templateRow("Value").ToString.Length > 0 Then
            '                Try
            '                    oKPI.dateAsOf.EditValue = DirectCast(templateRow("Value"), Date)
            '                Catch
            '                End Try
            '            End If
            '        End If
            '    End If

            'Catch ex As Exception
            '    LogErrors("Failed to load date coverage [" & templateRow("OptionsObjectID") & " = " & templateRow("Value") & "] from template '" & TemplateDetails.Name & "'.")
            'End Try
        Next
    End Sub

    Public Sub LoadTemplateList(sender As KPI, Optional nUserID As Object = "CURRENTUSER")
        '####################################################################################################################################################################################################################################
        'Description: Load Template List

        oKPI = sender

        If nUserID = "CURRENTUSER" Then
            nUserID = IfNull(USER_ID, 0)
        End If

        If IsNothing(oKPI) Then Exit Sub
        Try
            Dim TemplatesTable As DataTable
            ClearTemplateList(oKPI.GridTemplates)

            '####################################################################################################################################################################################################################################
            'LOAD THE TEMPLATE LIST
            TemplatesTable = CreateReportTemplateDT(oKPI.TemplateGroup, oKPI.oKPIDetail.KPICode)

            If TemplatesTable.Rows.Count > 0 Then
                oKPI.GridTemplates.DataSource = TemplatesTable
                oKPI.GridTemplates.Refresh()
            End If
        Catch ex As Exception
            LogErrors("Error loading template list for KPI '" & oKPI.oKPIDetail.Name & "'." & Chr(13) & "Error: " & ex.Message)
            MsgBox("Error loading template list for KPI '" & oKPI.oKPIDetail.Name & "'." & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

#End Region

#Region "Save"
    Public Function SaveKPITemplate(ByRef sender As KPI, Optional nUserID As Object = "CURRENTUSER") As Boolean
        '####################################################################################################################################################################################################################################
        '## Description: Saves the Filter and Sort options as a template
        Dim bSuccess As Boolean = False

        oKPI = sender

        If nUserID = "CURRENTUSER" Then
            nUserID = IfNull(USER_ID, 0)
        End If

        '####################################################################################################################################################################################################################################
        'VALIDATE ENTRIES AND FILTER AND SORTING OPTIONS
        Dim bHasFilterToSave As Boolean = False, bHasDatePeriodToSave As Boolean = False, bHasSelectedDataToSave As Boolean = False

        If Not IsNothing(oKPI.oFilterOption) Then
            bHasFilterToSave = oKPI.oFilterOption.HasFilterValuesToSave
        End If

        If Not IsNothing(oKPI.GridSelectionListView) Then
            bHasSelectedDataToSave = oKPI.GridSelectionListView.SelectedRowsCount > 0
        End If

        If oKPI.LayoutControlItem_From.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And oKPI.LayoutControlItem_To.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
            bHasDatePeriodToSave = (Not IsNothing(oKPI.LayoutControlItem_From) And Not IsNothing(oKPI.LayoutControlItem_To))
        ElseIf oKPI.LayoutControlItem_DateAsOf.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
            bHasDatePeriodToSave = Not IsNothing(oKPI.LayoutControlItem_DateAsOf)
        Else
            bHasDatePeriodToSave = True
        End If

        '####################################################################################################################################################################################################################################
        'exits if there are no selection(s) made in the Filter Options or in the Selection
        If Not bHasFilterToSave And Not bHasSelectedDataToSave Then
            MsgBox("There is no filter or selected data to save as template." & Chr(13) & "Please try again.", MsgBoxStyle.Information)
            GoTo RETURN_FALSE_AND_EXIT
        End If

        If Not bHasDatePeriodToSave Then
            MsgBox("There is no Date Coverage to save. Please try again.", MsgBoxStyle.Information)
            GoTo RETURN_FALSE_AND_EXIT
        End If

        '####################################################################################################################################################################################################################################
        'CONSTRUCT DESCRIPTION BASED ON DATE COVERAGE
        Dim cDateCoverageDesc As String = ContructDescriptionFromDateCoverage()

        '####################################################################################################################################################################################################################################
        'ENTER TEMPLATE NAME AND DESCRIPTION
        Dim frmSaveTemplate As New frmSaveTemplate(True, oKPI.TemplateGroup, oKPI.oKPIDetail.KPICode, oKPI.oKPIDetail.Name)

        AddHandler frmSaveTemplate.chkFilter.EditValueChanging, AddressOf validateIfHasFilterToSave
        AddHandler frmSaveTemplate.chkSelectedData.EditValueChanging, AddressOf validateIfHasSelectedDataToSave

        frmSaveTemplate.LayoutControlItem_Sorting.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        If cDateCoverageDesc.Length > 0 Then frmSaveTemplate.txtDescription.Text = cDateCoverageDesc & Chr(13)
OPEN_SAVE_FORM:
        frmSaveTemplate.ShowDialog()

        If frmSaveTemplate.CancelButtonIsClicked Then
            MsgBox("Save cancelled.", 64, GetAppName)
            GoTo RETURN_FALSE_AND_EXIT
        End If

        '####################################################################################################################################################################################################################################
        'VALIDATES ENTERED NAME (AND DESCRIPTION)

        Dim TemplateDetails As New ReportTemplateDetail
        TemplateDetails = frmSaveTemplate.oReportTemplate

        '####################################################################################################################################################################################################################################
        'CHECKS IF ENTERED NAME IS ALREADY IN THE SAVED TEMPLATE LIST
        Dim tmpTbl As New DataTable

        tmpTbl = MPSDB.CreateTable("SELECT * FROM dbo." & tblNameTemplate & " " & _
                                                 "WHERE ReportGroup = '" & oKPI.TemplateGroup & "' " & _
                                                 "AND ReportObjectID = '" & oKPI.oKPIDetail.KPICode & "' " & _
                                                 "AND Name = '" & TemplateDetails.Name & "' " & _
                                                 "AND UserID = " & nUserID)

        If tmpTbl.Rows.Count > 0 Then
            Dim nAnswer As Integer = MsgBox("A template with name `" & TemplateDetails.Name & "` already exists. Do you want to overwrite the existing template?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
            If nAnswer = vbCancel Then
                MsgBox("Save template is canceled.", MsgBoxStyle.Information)
                GoTo RETURN_FALSE_AND_EXIT
            ElseIf nAnswer = vbNo Then
                GoTo OPEN_SAVE_FORM
            Else
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    "KPI", _
                    "Crewing", _
                    tblNameTemplate, _
                    "ReportGroup = '" & oKPI.TemplateGroup & "' " & _
                                     "AND ReportObjectID = '" & oKPI.oKPIDetail.KPICode & "' " & _
                                     "AND Name = '" & TemplateDetails.Name & "' " & _
                                     "AND UserID = " & nUserID, _
                    "<< Delete Data - KPI-Template >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <KPI-Template>", _
                    GetUserName())
                '-->
                bSuccess = MPSDB.RunSql("DELETE FROM dbo." & tblNameTemplate & " " & _
                                     "WHERE ReportGroup = '" & oKPI.TemplateGroup & "' " & _
                                     "AND ReportObjectID = '" & oKPI.oKPIDetail.KPICode & "' " & _
                                     "AND Name = '" & TemplateDetails.Name & "' " & _
                                     "AND UserID = " & nUserID)

                If Not bSuccess Then GoTo TRY_AGAIN_AND_EXIT
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
        End If

        '####################################################################################################################################################################################################################################
        'SAVE TEMPLATE
        'bSuccess = MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplate & " ([ReportGroup], [ReportObjectID], [Name], [Description], [UserID]) " & _
        '                     "VALUES ('" & oKPI.TemplateGroup & "', '" & oKPI.oKPIDetail.KPICode & "', '" & TemplateDetails.Name & "', " & IIf(TemplateDetails.Description.Length = 0, "NULL", "'" & TemplateDetails.Description & "'") & ", " & nUserID & ")")

        'neil
        bSuccess = MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplate & " ([ReportGroup], [ReportObjectID], [Name], [Description], [UserID], [LastUpdatedBy]) " & _
                     "VALUES ('" & oKPI.TemplateGroup & "', '" & oKPI.oKPIDetail.KPICode & "', '" & TemplateDetails.Name & "', " & IIf(TemplateDetails.Description.Length = 0, "NULL", "'" & TemplateDetails.Description & "'") & ", " & nUserID & ",'" & TemplateDetails.LastUpdatedBy & "')")

        '####################################################################################################################################################################################################################################
        'TRY SAVING AGAIN IF FAILS
        If Not bSuccess Then GoTo TRY_AGAIN_AND_EXIT

        '####################################################################################################################################################################################################################################
        'GET PKEY OF LAST INSERTED ITEM IN TEMPLATES
        TemplateDetails.PKey = MPSDB.GetLastInsertedItem("PKey", tblNameTemplate)

        If TemplateDetails.PKey.Length = 0 Then GoTo TRY_AGAIN_AND_EXIT

        '####################################################################################################################################################################################################################################
        'SAVE FILTER OPTION VALUES INTO TEMPLATE
        If TemplateDetails.SaveOptions.Filtering.Selected Then oKPI.oFilterOption.SaveFilterOptionValuesToTemplate(TemplateDetails.PKey)

        '####################################################################################################################################################################################################################################
        'SAVE SELECTED DATA OPTION VALUES INTO TEMPLATE
        If TemplateDetails.SaveOptions.SelectedData.Selected Then SaveSelectedDataOptionValuesToTemplate(TemplateDetails)

        '####################################################################################################################################################################################################################################
        'SAVE SELECTION LISTING
        SaveKPISelectionListing(TemplateDetails)

        '####################################################################################################################################################################################################################################
        'SAVE DATE COVERAGE INTO TEMPLATE
        SaveKPIDateCoverageValuesToTemplate(TemplateDetails)

        '####################################################################################################################################################################################################################################
        'SAVE CHART VIEW INTO TEMPLATE
        SaveSelectedKPIChartView(TemplateDetails, oKPI.oKPIDetail.ChartView)

        '####################################################################################################################################################################################################################################
        'SAVE COLOR PALETTE INTO TEMPLATE
        SaveSelectedKPIColorPalette(TemplateDetails, oKPI.oKPIDetail.ColorPalette)

        '####################################################################################################################################################################################################################################
        MsgBox("Template saved.", MsgBoxStyle.Information)

        Return True
        Exit Function
TRY_AGAIN_AND_EXIT:
        LogErrors("Unable to save template [" & TemplateDetails.Name & "].")
        MsgBox("Unable to save template. Please try again.", vbExclamation)

RETURN_FALSE_AND_EXIT:
        Return False
        Exit Function
    End Function

    Function ContructDescriptionFromDateCoverage() As String
        Dim cReturnValue As String = ""
        If oKPI.LayoutControlItem_From.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
            If Not IsNothing(oKPI.cboPeriodFrom.EditValue) Then
                If oKPI.cboPeriodFrom.EditValue.ToString.Length > 0 Then
                    cReturnValue = cReturnValue & IIf(cReturnValue.Length > 0, vbCrLf, "") & "From: " & Format(NumCodeToDate(oKPI.cboPeriodFrom.EditValue, 1), "MMM-yyyy")
                End If
            End If
        End If

        If oKPI.LayoutControlItem_To.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
            If Not IsNothing(oKPI.cboPeriodTo.EditValue) Then
                If oKPI.cboPeriodTo.EditValue.ToString.Length > 0 Then
                    cReturnValue = cReturnValue & IIf(cReturnValue.Length > 0, vbCrLf, "") & "To: " & Format(NumCodeToDate(oKPI.cboPeriodTo.EditValue, 1), "MMM-yyyy")
                End If
            End If
        End If

        If oKPI.LayoutControlItem_DateAsOf.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
            If Not IsNothing(oKPI.dateAsOf.EditValue) Then
                If oKPI.dateAsOf.EditValue.ToString.Length > 0 Then
                    cReturnValue = cReturnValue & IIf(cReturnValue.Length > 0, vbCrLf, "") & "As of: " & Format(oKPI.dateAsOf.EditValue, REPORT_DATE_FORMAT)
                End If
            End If
        End If

        Return cReturnValue
    End Function

    Private Function SaveSelectedDataOptionValuesToTemplate(TemplateDetails As ReportTemplateDetail) As Boolean
        'Description: Saves the Filter values to the templates
        Dim bSuccess As Boolean = True
        Dim cValue As String = ""
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A PASSED TEMPLATE PKEY PARAMETER
            If TemplateDetails.PKey.Length > 0 Then

                Dim view As DevExpress.XtraGrid.Views.Grid.GridView = oKPI.GridSelectionListView
                Dim row As DataRow
                Dim I As Integer
                For I = 0 To view.SelectedRowsCount() - 1
                    If (view.GetSelectedRows()(I) >= 0) Then
                        row = view.GetDataRow(view.GetSelectedRows()(I))


                        cValue = row("ColumnKey")
                        Try
                            bSuccess = bSuccess And MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                    "VALUES ('" & TemplateDetails.PKey & "', 'PKey', '" & ReportTemplateContentType.DataSelection & "', '" & cValue & "',0)")
                        Catch ex As Exception
                            LogErrors("Inserting selected data [" & row("ColumnDisplay") & "] into report template with key [" & TemplateDetails.PKey & "] failed.")
                            LogErrors("Error: " & ex.Message)
                        End Try


                    End If
                Next

                If Not bSuccess Then
                    MsgBox("There is an error when saving the selected data to the template.", vbInformation)
                    GoTo RETURN_AND_EXIT
                End If

            Else
                '####################################################################################################################################################################################################################################
                'IF THERE IS NO PASSED TemplatePKey PARAMETER
                bSuccess = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function

    Private Function SaveKPIDateCoverageValuesToTemplate(TemplateDetails As ReportTemplateDetail) As Boolean
        'Description: Saves the Filter values to the templates
        Dim bSuccess As Boolean = True
        Dim cValue As Object = Nothing
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A PASSED TEMPLATE PKEY PARAMETER
            If TemplateDetails.PKey.Length > 0 Then

                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'DATE COVERAGE TYPE
                If Not IsNothing(oKPI.cboDateCoverageType.EditValue) Then
                    If Not IfNull(oKPI.cboDateCoverageType.EditValue, "").Equals("") Then
                        cValue = IfNull(oKPI.cboDateCoverageType.EditValue, "")
                        Try
                            If Not IsNothing(cValue) Then
                                bSuccess = bSuccess And MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                        "VALUES ('" & TemplateDetails.PKey & "', '" & ReportTemplateContentType.KPIDateCoverageType & "', '" & ReportTemplateContentType.KPIDateCoverageType & "', '" & cValue & "',0)")
                            End If
                        Catch ex As Exception
                            LogErrors("Inserting date coverage type [" & cValue & "] into report template with key [" & TemplateDetails.PKey & "] failed.")
                            LogErrors("Error: " & ex.Message)
                        End Try
                    End If
                End If

                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'PERIOD FROM
                If oKPI.LayoutControlItem_From.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
                    cValue = oKPI.cboPeriodFrom.EditValue
                    Try
                        If Not IsNothing(cValue) Then
                            bSuccess = bSuccess And MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                    "VALUES ('" & TemplateDetails.PKey & "', '" & KPIDateCoverageParam.PeriodFrom & "', '" & ReportTemplateContentType.KPIDateCoverage & "', '" & cValue & "',0)")
                        End If
                    Catch ex As Exception
                        LogErrors("Inserting date coverage [" & cValue & "] into report template with key [" & TemplateDetails.PKey & "] failed.")
                        LogErrors("Error: " & ex.Message)
                    End Try
                End If

                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'PERIOD TO
                If oKPI.LayoutControlItem_To.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
                    cValue = oKPI.cboPeriodTo.EditValue
                    Try
                        If Not IsNothing(cValue) Then
                            bSuccess = bSuccess And MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                    "VALUES ('" & TemplateDetails.PKey & "', '" & KPIDateCoverageParam.PeriodTo & "', '" & ReportTemplateContentType.KPIDateCoverage & "', '" & cValue & "',0)")
                        End If
                    Catch ex As Exception
                        LogErrors("Inserting date coverage [" & cValue & "] into report template with key [" & TemplateDetails.PKey & "] failed.")
                        LogErrors("Error: " & ex.Message)
                    End Try
                End If

                ''--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                ''PERIOD DATE AS OF
                'If oKPI.LayoutControlItem_DateAsOf.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
                '    cValue = oKPI.dateAsOf.EditValue
                '    Try
                '        If Not IsNothing(cValue) Then
                '            bSuccess = bSuccess And MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                '                                    "VALUES ('" & TemplateDetails.PKey & "', '" & KPIDateCoverageParam.DateAsOf & "', '" & ReportTemplateContentType.KPIDateCoverage & "', '" & cValue & "',0)")
                '        End If
                '    Catch ex As Exception
                '        LogErrors("Inserting date coverage [" & cValue & "] into report template with key [" & TemplateDetails.PKey & "] failed.")
                '        LogErrors("Error: " & ex.Message)
                '    End Try
                'End If

                If Not bSuccess Then
                    MsgBox("There is an error when saving the template. Please see error log or contact your system administrator for assistance.", vbInformation)
                    GoTo RETURN_AND_EXIT
                End If

            Else
                '####################################################################################################################################################################################################################################
                'IF THERE IS NO PASSED TemplatePKey PARAMETER
                bSuccess = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function

    Private Function SaveKPISelectionListing(TemplateDetails As ReportTemplateDetail) As Boolean
        'Description: Saves the Filter values to the templates
        Dim bSuccess As Boolean = True
        Dim cValue As Object = Nothing
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A PASSED TEMPLATE PKEY PARAMETER
            If TemplateDetails.PKey.Length > 0 Then

                If Not IsNothing(oKPI.cboSelectionType.EditValue) Then
                    If Not IfNull(oKPI.cboSelectionType.EditValue, "").Equals("") Then
                        Try
                            cValue = IfNull(oKPI.cboSelectionType.EditValue, "")
                            If Not IsNothing(cValue) Then
                                bSuccess = bSuccess And MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                        "VALUES ('" & TemplateDetails.PKey & "', '" & ReportTemplateContentType.KPISelectionListing & "', '" & ReportTemplateContentType.KPISelectionListing & "', '" & cValue & "',0)")
                            End If
                        Catch ex As Exception
                            LogErrors("Inserting selection listing type [" & cValue & "] into report template with key [" & TemplateDetails.PKey & "] failed.")
                            LogErrors("Error: " & ex.Message)
                        End Try
                    End If
                End If
            Else
                '####################################################################################################################################################################################################################################
                'IF THERE IS NO PASSED TemplatePKey PARAMETER
                bSuccess = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function

    Private Function SaveSelectedKPIChartView(TemplateDetails As ReportTemplateDetail, ChartView As KPI.ChartView) As Boolean
        Dim bSuccess As Boolean = True

        Try
            If ChartView <> 0 Then

                bSuccess = bSuccess And MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                        "VALUES ('" & TemplateDetails.PKey & "', 'CHARTVIEW', '" & ReportTemplateContentType.KPIChartView & "', '" & ChartView & "',0)")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function

    Private Function SaveSelectedKPIColorPalette(TemplateDetails As ReportTemplateDetail, cColorPalette As String) As Boolean
        Dim bSuccess As Boolean = True

        Try
            If Not cColorPalette Is Nothing Then
                If cColorPalette.Length > 0 Then
                    bSuccess = bSuccess And MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                            "VALUES ('" & TemplateDetails.PKey & "', 'COLORPALETTE', '" & ReportTemplateContentType.KPIColorPalette & "', '" & cColorPalette & "',0)")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function

#Region "Save Template Form Selection Validator"
    Private Sub validateIfHasFilterToSave(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        'If Not isReportSelectionInitialized() Then
        '    e.Cancel = True
        '    Exit Sub
        'End If

        If IsNothing(oKPI.oFilterOption) Then
            MsgBox("There is no filtering to save.", MsgBoxStyle.Information)
            e.Cancel = True
            Exit Sub
        End If

        If Not oKPI.oFilterOption.HasFilterValuesToSave Then
            MsgBox("There is no filtering to save.", MsgBoxStyle.Information)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub validateIfHasSelectedDataToSave(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        'If Not isReportSelectionInitialized() Then
        '    e.Cancel = True
        '    Exit Sub
        'End If

        If Not oKPI.GridSelectionListView.SelectedRowsCount > 0 Then
            MsgBox("There is no selected data to save.", MsgBoxStyle.Information)
            e.Cancel = True
            Exit Sub
        End If
    End Sub
#End Region
#End Region
End Module
