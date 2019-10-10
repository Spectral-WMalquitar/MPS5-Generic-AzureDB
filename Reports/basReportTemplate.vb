Imports DevExpress.XtraCharts

Public Module basReportTemplate
    Dim oReportSelection As ReportSelection

#Region "Declarations"
    Public Structure ReportTemplateContentType
        Const Filter As String = "FILTER"
        Const Sort As String = "SORT"
        Const DataSelection As String = "DATA SELECTION"

        Const KPISelectionListing As String = "KPI SELECTION LISTING"
        Const KPIDateCoverage As String = "KPI DATE COVERAGE"
        Const KPIDateCoverageType As String = "KPI DATE COVERAGE TYPE"
        Const KPIChartView As String = "KPI CHART VIEW"
        Const KPIColorPalette As String = "KPI COLOR PALETTE"
    End Structure
#End Region

#Region "Template Class"
    Public Class ReportTemplateDetail
        Public PKey As String = ""
        Public Name As String = ""
        Public Description As String = ""
        Public Content As String = ""
        Public SaveOptions As New TemplateSaveOptions
        Public ReportObject As New ReportObjectClass
        Public LastUpdatedBy As String = ""

        Public Class ReportObjectClass
            Public Group As String = ""
            Public ObjectID As String = ""
        End Class

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Sub New(_PKey As String)
            Dim dt As DataTable = CreateReportTemplateDT(_PKey)

            If dt.Rows.Count > 0 Then
                PKey = _PKey
                Name = Trim(IfNull(dt.Rows(0)("Name"), ""))
                Description = Trim(IfNull(dt.Rows(0)("Description"), ""))
                ReportObject.Group = Trim(IfNull(dt.Rows(0)("ReportGroup"), ""))
                ReportObject.ObjectID = Trim(IfNull(dt.Rows(0)("ReportObjectID"), ""))
                UpdateSaveOptions(Trim(IfNull(dt.Rows(0)("Content"), "")))
            End If

        End Sub

        Sub New(_PKey As String, _Name As String, Optional _Description As String = "", Optional _Content As String = "", Optional _ReportGroup As String = "", Optional _ReportObjectID As String = "")
            PKey = _PKey
            Name = _Name
            Description = _Description
            ReportObject.Group = _ReportGroup
            ReportObject.ObjectID = _ReportObjectID
            UpdateSaveOptions(_Content)
        End Sub

        Sub UpdateSaveOptions(_Content As String)
            If _Content.Length > 0 Then
                Dim arrContent As String() = _Content.Split(",")
                Dim tmpContent As String = ""
                For i As Integer = 0 To arrContent.GetUpperBound(0)
                    tmpContent = Trim(IfNull(arrContent(i), ""))
                    SaveOptions.Filtering.Selected = (tmpContent = "Filter")
                    SaveOptions.Sorting.Selected = (tmpContent = "Sort")
                    SaveOptions.SelectedData.Selected = (tmpContent = "Selected Data")
                Next
            End If
        End Sub
    End Class

    Public Class TemplateSaveOptions
        Public Filtering As New TemplateSaveOptionsObject
        Public Sorting As New TemplateSaveOptionsObject
        Public SelectedData As New TemplateSaveOptionsObject
    End Class

    Public Class TemplateSaveOptionsObject
        Public Selected As New Boolean

        Sub New()
            Selected = False
        End Sub
    End Class

#End Region

#Region "Generate Report From Template"
    Public Sub GenerateReportFromTemplate(TemplatePKey As String, Optional OutputMode As ReportOutputMode = ReportOutputMode.Preview, Optional ShowMessage As Boolean = True)
        Try
            'CREATE A CLASS FOR THE DETAILS OF THE TEMPLATE
            Dim TemplateDetails As New ReportTemplateDetail(TemplatePKey)
            If IsNothing(TemplateDetails) Then
                If ShowMessage Then MsgBox("Unable to load template.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'CREATE A CLASS FOR THE INFORMATION ABOUT THE REPORT
            Dim ReportInfo As New ReportInfo(TemplateDetails.ReportObject.ObjectID, TemplateDetails.ReportObject.Group)                    'information about what the report is
            If IsNothing(ReportInfo) Then
                If ShowMessage Then MsgBox("Unable to locate associated report to this template.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'CREATE A CLASS FOR THE DETAILS OF THE REPORT TO BE GENERATED
            Dim ReportDetail As ReportDetail = CreateReportDetailFromTemplate(ReportInfo, TemplateDetails)
            ReportDetail.Output.Mode = OutputMode

            BuildReport(ReportDetail)
        Catch ex As Exception
            MsgBox("Unable to generate report from the selected template", MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Function CreateReportDetailFromTemplate(ReportInfo As ReportInfo, TemplateDetails As ReportTemplateDetail) As ReportDetail
        '####################################################################################################################################################################################################################################
        'ASSIGNS VARIABLES TO REPORT DETAIL CLASS
        Dim ReturnValue = New ReportDetail
        With ReturnValue
            .DB = MPSDB                                                                                                     'Reference to database
            .ReportInfo = ReportInfo                                                                                        'ReportInfo class
            .PresentRecord.ReportDataSourceKey = ReportInfo.KeyFilterField                                                  'KeyField of Report DataSource
            .PresentRecord.SelectionList = GetSelectedRecordsFromTemplate(TemplateDetails)                                  'Where condition based on the print selection that can be used to filter the report datasource
            .PresentRecord.ConditionString = GetSelectedRecordsFromTemplate(TemplateDetails, ReportInfo.KeyFilterField)     'List of Values based on the print selection that can be used to filter the report datasource
            
            'Dim oFilterOption As BaseFilterOption = CreateFilterOptionObject(ReportInfo)
            Dim oFilterOption As BaseFilterOption = Reports.FilterOption.Create(ReportInfo)
            If Not IsNothing(oFilterOption) Then
                .FilterOption = oFilterOption                                                   'Filter Option Class Object
            End If

            Dim oSortOption As BaseSortOption = SortOption.Create(ReportInfo)
            If Not IsNothing(oSortOption) Then
                .SortOption = oSortOption                                                       'Sort Option Class Object
                .FieldSorting = oSortOption.GetSortString()                                     'ORDER BY statement based on the items from the Sort Option
            End If

        End With

        Return ReturnValue
    End Function
#End Region

#Region "Procedures/Functions Create Report Template Details"
    Function CreateObject_ReportTemplateDetail(TemplatePKey As String) As ReportTemplateDetail
        Dim ReturnValue As ReportTemplateDetail = Nothing
        Dim dt As DataTable = CreateReportTemplateDT(TemplatePKey)

        If dt.Rows.Count > 0 Then
            ReturnValue = New ReportTemplateDetail(Trim(IfNull(dt.Rows(0)("PKey"), "")), _
                                                    Trim(IfNull(dt.Rows(0)("Name"), "")), _
                                                    Trim(IfNull(dt.Rows(0)("Description"), "")), _
                                                    Trim(IfNull(dt.Rows(0)("Content"), "")))
        End If

        Return ReturnValue

    End Function

    Function CreateObject_ReportTemplateDetail(dr As DataRow) As ReportTemplateDetail
        Dim ReturnValue As ReportTemplateDetail = Nothing

        If Not IsNothing(dr) Then
            ReturnValue = New ReportTemplateDetail(Trim(IfNull(dr("PKey"), "")), _
                                                    Trim(IfNull(dr.Item("Name"), "")), _
                                                    Trim(IfNull(dr.Item("Description"), "")), _
                                                    Trim(IfNull(dr.Item("Content"), "")))
        End If
        Return ReturnValue

    End Function
#End Region

#Region "Create Report Template and Template Values DataTable"
    Function CreateReportTemplateDT(TemplatePKey As String) As DataTable
        Dim ReturnValue As DataTable = Nothing
        'Dim cSQL As String = "SELECT        TOP 1 tmp.*, " & _
        '                     "              Replace(RTrim(LTrim(CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = '" & ReportTemplateContentType.Filter & "' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Filter' ELSE '' END + " & _
        '                     "              '  ' + " & _
        '                     "              CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = '" & ReportTemplateContentType.Sort & "' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Sort' ELSE '' END +  " & _
        '                     "              '  ' + " & _
        '                     "              CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = '" & ReportTemplateContentType.DataSelection & "' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Selected Data' ELSE '' END)),'  ', ', ') as Content " & _
        '                     "FROM		    dbo.MSystblRepOptTemplate tmp " & _
        '                     "WHERE         tmp.pkey = '" & TemplatePKey & "'"

        Dim cSQL As String = "SELECT        TOP 1 tmp.*,                                              " & _
                             "              dbo.ChangeDelimitedStringToSingleSeries(            " & _
                             "                      CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = 'FILTER' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Filter' ELSE '' END +          " & _
                             "                      ';' +                                       " & _
                             "                      CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = 'SORT' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Sort' ELSE '' END +              " & _
                             "                      ';' +                                       " & _
                             "                      CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = 'DATA SELECTION' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Selected Data' ELSE '' END         " & _
                             "              , ';', ',', 1, '') as Content                       " & _
                             "FROM			dbo.MSystblRepOptTemplate tmp                       " & _
                             "WHERE         tmp.pkey = '" & TemplatePKey & "'"

        ReturnValue = MPSDB.CreateTable(cSQL)

        Return ReturnValue

    End Function

    Function CreateReportTemplateDT(ReportGroup As String, ReportObjectID As String, Optional nUserID As Object = "CURRENTUSER") As DataTable
        Dim ReturnValue As DataTable = Nothing

        If nUserID = "CURRENTUSER" Then
            nUserID = IfNull(USER_ID, 0)
        End If

        Dim cSQL As String = "SELECT        tmp.*,                                              " & _
                             "              dbo.ChangeDelimitedStringToSingleSeries(            " & _
                             "                      CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = 'FILTER' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Filter' ELSE '' END +          " & _
                             "                      ';' +                                       " & _
                             "                      CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = 'SORT' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Sort' ELSE '' END +              " & _
                             "                      ';' +                                       " & _
                             "                      CASE WHEN (SELECT count(FKeyTemplate) FROM dbo.MSystblRepOptTemplateValues WHERE OptionsType = 'DATA SELECTION' AND FKeyTemplate = tmp.PKey GROUP BY FKeyTemplate) > 0 THEN 'Selected Data' ELSE '' END         " & _
                             "              , ';', ',', 1, '') as Content                       " & _
                             "FROM			dbo.MSystblRepOptTemplate tmp                       " & _
                             "WHERE			tmp.ReportGroup = '" & ReportGroup & "'             " & _
                             "              AND                                                 " & _
                             "              tmp.ReportObjectID = '" & ReportObjectID & "'       " & _
                             "              AND                                                 " & _
                             "              UserID = " & nUserID & "                            " & _
                             "ORDER BY		tmp.Name, tmp.Description"

        ReturnValue = MPSDB.CreateTable(cSQL)

        Return ReturnValue

    End Function

    Public Function CreateReportTemplateValuesDT(TemplatePKey As String, Optional ContentType As String = Nothing, Optional OptionsObjectID As String = Nothing) As DataTable
        Dim cCondition As String

        cCondition = "FKeyTemplate = '" & TemplatePKey & "'"

        If Not ContentType Is Nothing Then
            If ContentType.Length > 0 Then
                cCondition = cCondition & IIf(cCondition.Length > 0, " AND ", "") & "OptionsType = '" & ContentType & "'"
            End If
        End If

        If Not OptionsObjectID Is Nothing Then
            If OptionsObjectID.Length > 0 Then
                cCondition = cCondition & IIf(cCondition.Length > 0, " AND ", "") & "OptionsObjectID = '" & OptionsObjectID & "'"
            End If
        End If

        Dim ReturnValue As DataTable = MPSDB.CreateTable("SELECT * FROM dbo.MSystblRepOptTemplateValues WHERE " & cCondition)
        Return ReturnValue
    End Function
#End Region

#Region "Creating Filter/Sort Option from Template"
    Function CreateFilterOptionFromTemplate(TemplateDetails As ReportTemplateDetail) As BaseFilterOption
        Dim ReturnValue As New BaseFilterOption
        Dim dt As DataTable = CreateReportTemplateValuesDT(TemplateDetails.PKey, ReportTemplateContentType.DataSelection)

        Dim cKeys As String = ""
        Dim cValues As String = ""
        For Each dr As DataRow In dt.Rows
            cKeys = cKeys & IIf(dr.Table.Rows.IndexOf(dr) > 0, ";", "") & dr("")
            cValues = cValues & IIf(dr.Table.Rows.IndexOf(dr) > 0, ";", "") & dr("Value")
        Next
        Return ReturnValue
    End Function
#End Region

#Region "Clear Procedures and Functions"
    Public Sub ClearTemplateList(ByRef TemplateGrid As DevExpress.XtraGrid.GridControl, Optional ByVal ShowErrorMsg As Boolean = False)
        '####################################################################################################################################################################################################################################
        'CLEARS THE TEMPLATE LIST
        Try
            TemplateGrid.DataSource = ""
        Catch ex As Exception
            If ShowErrorMsg Then MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "Get Procedures and Functions"
    Function GetSelectedRecordsFromTemplate(TemplateDetails As ReportTemplateDetail, Optional KeyFieldName As String = "") As String
        Dim ReturnValue As String = ""
        If TemplateDetails.SaveOptions.SelectedData.Selected Then
            Dim dt As DataTable = MPSDB.CreateTable("SELECT * FROM " & tblNameTemplateValues & " WHERE FKeyTemplate = '" & TemplateDetails.PKey & "' AND OptionsType = '" & ReportTemplateContentType.DataSelection & "'")
            For Each dr As DataRow In dt.Rows
                ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, ", ", "") & IIf(Not IsNumeric(dr("Value")), "'", "") & dr("Value") & IIf(Not IsNumeric(dr("Value")), "'", "")
            Next

            'If KeyFieldName.Length > 0 Then
            '    ReturnValue = KeyFieldName & " IN (" & ReturnValue & ")"
            'End If

            ReturnValue = IIf(KeyFieldName.Length > 0, KeyFieldName & " IN ", "") & "(" & ReturnValue & ")"

        End If

        Return ReturnValue
    End Function
#End Region

#Region "Save Procedures and Functions"
    Public Function SaveReportTemplate(ByRef sender As ReportSelection, Optional nUserID As Object = "CURRENTUSER") As Boolean
        '####################################################################################################################################################################################################################################
        '## Description: Saves the Filter and Sort options as a template
        Dim bSuccess As Boolean = False

        oReportSelection = sender

        If nUserID = "CURRENTUSER" Then
            nUserID = IfNull(USER_ID, 0)
        End If

        If Not isReportSelectionInitialized() Then
            MsgBox("Unable to save report template because Report Selection form is not initialized.", MsgBoxStyle.Information)
            GoTo RETURN_FALSE_AND_EXIT
        End If

        '####################################################################################################################################################################################################################################
        'VALIDATE ENTRIES AND FILTER AND SORTING OPTIONS
        Dim bHasFilterToSave As Boolean = False, bHasSortToSave As Boolean = False, bHasSelectedDataToSave As Boolean = False

        If Not IsNothing(oReportSelection.oFilterOption) Then
            bHasFilterToSave = oReportSelection.oFilterOption.HasFilterValuesToSave
        End If

        If Not IsNothing(oReportSelection.oSortOption) Then
            bHasSortToSave = oReportSelection.oSortOption.HasSortValuesToSave()
        End If

        If Not IsNothing(oReportSelection.GridSelectedView) Then
            bHasSelectedDataToSave = oReportSelection.GridSelectedView.RowCount > 0
        End If

        '####################################################################################################################################################################################################################################
        'exits if there are no selection(s) made in the Filter Options or in the Sort Options
        If Not bHasFilterToSave And Not bHasSortToSave And Not bHasSelectedDataToSave Then
            MsgBox("There is no filter, sort or selected data to save as template." & Chr(13) & "Please try again.", MsgBoxStyle.Information)
            GoTo RETURN_FALSE_AND_EXIT
        End If

        '####################################################################################################################################################################################################################################
        'ENTER TEMPLATE NAME AND DESCRIPTION
        Dim frmSaveTemplate As New frmSaveTemplate(True, oReportSelection.oReportInfo.ReportGroup, oReportSelection.oReportInfo.ObjectID, _
                                                   oReportSelection.oReportInfo.Caption)

        AddHandler frmSaveTemplate.chkFilter.EditValueChanging, AddressOf validateIfHasFilterToSave
        AddHandler frmSaveTemplate.chkSort.EditValueChanging, AddressOf validateIfHasSortToSave
        AddHandler frmSaveTemplate.chkSelectedData.EditValueChanging, AddressOf validateIfHasSelectedDataToSave

OPEN_SAVE_FORM:
        frmSaveTemplate.ShowDialog()

        If frmSaveTemplate.CancelButtonIsClicked Then
            MsgBox("Save cancelled.", 64, GetAppName)
            frmSaveTemplate.Dispose()
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
                                                 "WHERE ReportGroup = '" & oReportSelection.oReportInfo.ReportGroup & "' " & _
                                                 "AND ReportObjectID = '" & oReportSelection.oReportInfo.ObjectID & "' " & _
                                                 "AND Name = '" & TemplateDetails.Name & "' " & _
                                                 "AND UserID = " & nUserID)

        If tmpTbl.Rows.Count > 0 Then
            Dim nAnswer As Integer = MsgBox("A template with name `" & TemplateDetails.Name & "` already exists. Do you want to overwrite the existing template?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)

            If nAnswer = vbCancel Then
                MsgBox("Save template is canceled.", MsgBoxStyle.Information)
                frmSaveTemplate.Dispose()
                GoTo RETURN_FALSE_AND_EXIT
            ElseIf nAnswer = vbNo Then
                GoTo OPEN_SAVE_FORM
            Else
                frmSaveTemplate.Dispose()

                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    "ReportsI", _
                    "Crewing", _
                    tblNameTemplate, _
                    "ReportGroup = '" & oReportSelection.oReportInfo.ReportGroup & "' " & _
                                     "AND ReportObjectID = '" & oReportSelection.oReportInfo.ObjectID & "' " & _
                                     "AND Name = '" & TemplateDetails.Name & "' " & _
                                     "AND UserID = " & nUserID, _
                    "<< Delete Data - Reports-Template >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <Reports-Template>", _
                    GetUserName())
                '-->
                bSuccess = MPSDB.RunSql("DELETE FROM dbo." & tblNameTemplate & " " & _
                                     "WHERE ReportGroup = '" & oReportSelection.oReportInfo.ReportGroup & "' " & _
                                     "AND ReportObjectID = '" & oReportSelection.oReportInfo.ObjectID & "' " & _
                                     "AND Name = '" & TemplateDetails.Name & "' " & _
                                     "AND UserID = " & nUserID)

                If Not bSuccess Then GoTo TRY_AGAIN_AND_EXIT
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
        End If

        '####################################################################################################################################################################################################################################
        'SAVE TEMPLATE
        'bSuccess = MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplate & " ([ReportGroup], [ReportObjectID], [Name], [Description], [UserID]) " & _
        '                     "VALUES ('" & oReportSelection.oReportInfo.ReportGroup & "', '" & oReportSelection.oReportInfo.ObjectID & "', '" & TemplateDetails.Name & "', " & IIf(TemplateDetails.Description.Length = 0, "NULL", "'" & TemplateDetails.Description & "'") & ", " & nUserID & ")")

        bSuccess = MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplate & " ([ReportGroup], [ReportObjectID], [Name], [Description], [UserID], [LastUpdatedBy]) " & _
                           "VALUES ('" & oReportSelection.oReportInfo.ReportGroup & "', '" & oReportSelection.oReportInfo.ObjectID & "', '" & TemplateDetails.Name & "', " & IIf(TemplateDetails.Description.Length = 0, "NULL", "'" & TemplateDetails.Description & "'") & ", " & nUserID & ", '" & TemplateDetails.LastUpdatedBy & "')")


        '####################################################################################################################################################################################################################################
        'TRY SAVING AGAIN IF FAILS
        If Not bSuccess Then GoTo TRY_AGAIN_AND_EXIT

        '####################################################################################################################################################################################################################################
        'GET PKEY OF LAST INSERTED ITEM IN TEMPLATES
        TemplateDetails.PKey = MPSDB.GetLastInsertedItem("PKey", tblNameTemplate)

        If TemplateDetails.PKey.Length = 0 Then GoTo TRY_AGAIN_AND_EXIT

        '####################################################################################################################################################################################################################################
        'SAVE FILTER OPTION VALUES INTO TEMPLATE
        If TemplateDetails.SaveOptions.Filtering.Selected Then oReportSelection.oFilterOption.SaveFilterOptionValuesToTemplate(TemplateDetails.PKey)

        '####################################################################################################################################################################################################################################
        'SAVE SORT OPTION VALUES INTO TEMPLATE
        If TemplateDetails.SaveOptions.Sorting.Selected Then oReportSelection.oSortOption.SaveSortOptionValuesToTemplate(TemplateDetails.PKey)

        '####################################################################################################################################################################################################################################
        'SAVE SELECTED DATA OPTION VALUES INTO TEMPLATE
        If TemplateDetails.SaveOptions.SelectedData.Selected Then SaveSelectedDataOptionValuesToTemplate(TemplateDetails)

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

    Private Function SaveSelectedDataOptionValuesToTemplate(TemplateDetails As ReportTemplateDetail) As Boolean
        'Description: Saves the Filter values to the templates
        Dim bSuccess As Boolean = False
        Dim cValue As String = ""
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A PASSED TEMPLATE PKEY PARAMETER
            If TemplateDetails.PKey.Length > 0 Then

                Dim dt As DataTable = TryCast(oReportSelection.GridSelected.DataSource, DataTable)
                dt.AcceptChanges()
                For i As Integer = 0 To dt.Rows.Count - 1
                    cValue = dt.Rows(i).Item(oReportSelection.oReportInfo.SelectionKeyField) 'ReportSelection.GridSelectedView.GetRowCellValue(i, ReportSelection.oReportInfo.SelectionKeyField)
                    Try
                        bSuccess = MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                "VALUES ('" & TemplateDetails.PKey & "', '" & oReportSelection.oReportInfo.SelectionKeyField & "', '" & ReportTemplateContentType.DataSelection & "', '" & cValue & "',0)")
                    Catch ex As Exception
                        LogErrors("Inserting selected data [" & dt.Rows(i).Item(oReportSelection.oReportInfo.SelectionDisplayField) & " = " & dt.Rows(i).Item(oReportSelection.oReportInfo.SelectionKeyField) & "] into report template with key [" & TemplateDetails.PKey & "] failed.")
                        LogErrors("Error: " & ex.Message)
                    End Try
                Next

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

#Region "Save Template Form Selection Validator"
    Private Sub validateIfHasFilterToSave(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        If Not isReportSelectionInitialized() Then
            e.Cancel = True
            Exit Sub
        End If

        If IsNothing(oReportSelection.oFilterOption) Then
            MsgBox("There is no filtering to save.", MsgBoxStyle.Information)
            e.Cancel = True
            Exit Sub
        End If

        If Not oReportSelection.oFilterOption.HasFilterValuesToSave Then
            MsgBox("There is no filtering to save.", MsgBoxStyle.Information)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub validateIfHasSortToSave(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        If Not isReportSelectionInitialized() Then
            e.Cancel = True
            Exit Sub
        End If

        If IsNothing(oReportSelection.oSortOption) Then
            MsgBox("There is no filtering to save.", MsgBoxStyle.Information)
            e.Cancel = True
            Exit Sub
        End If

        If Not oReportSelection.oSortOption.HasSortValuesToSave() Then
            MsgBox("There is no sorting to save.", MsgBoxStyle.Information)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub validateIfHasSelectedDataToSave(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        If Not isReportSelectionInitialized() Then
            e.Cancel = True
            Exit Sub
        End If

        If Not oReportSelection.GridSelectedView.RowCount > 0 Then
            MsgBox("There is no selected data to save.", MsgBoxStyle.Information)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Function isReportSelectionInitialized(Optional ByVal bShowMessage As Boolean = True) As Boolean
        Dim ReturnValue As Boolean = False
        If IsNothing(oReportSelection) Then
            MsgBox("Report selection is not initialized. Please try again.", MsgBoxStyle.Information)
        Else
            ReturnValue = True
        End If

        Return ReturnValue
    End Function
#End Region
#End Region

#Region "Delete  Procedures and Functions"
    Public Function DeleteReportTemplate(TemplateDetails As ReportTemplateDetail) As Boolean
        '####################################################################################################################################################################################################################################
        '## Description: Deletes the selected Filter and Sort options Template
        Dim ReturnValue As Boolean = False
        Dim bSuccess As Boolean

        Try
            If TemplateDetails.PKey.Length > 0 Then
                If MsgBox("Are you sure want to delete the " & IIf(TemplateDetails.Name.Length > 0, "template: '" & TemplateDetails.Name & "'", "selected template") & "?", MsgBoxStyle.Critical + vbYesNo + vbDefaultButton2) = MsgBoxResult.Yes Then

                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        "Report Selection - Templates", _
                        "Crewing", _
                        "tblNameTemplate", _
                        "PKey IN ('" & TemplateDetails.PKey & "')", _
                        "<< Delete Crew Data - KPI Selection - Templates >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <KPI Selection - Templates>", _
                        GetUserName())
                    '-->
                    bSuccess = MPSDB.RunSql("DELETE FROM dbo." & tblNameTemplate & " WHERE PKey='" & TemplateDetails.PKey & "'")
                    If Not bSuccess Then
                        MsgBox("MPS could not delete the selected template. Please try again.", vbExclamation)
                    Else
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        MsgBox("Template Deleted.", MsgBoxStyle.Information, GetAppName)
                        ReturnValue = True
                    End If
                Else
                    MsgBox("Delete Template Canceled", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Please select template to delete.", MsgBoxStyle.Information, GetAppName)
            End If


        Catch ex As Exception
            LogErrors("Error deleting template [" & TemplateDetails.Name & "]." & Chr(13) & "Error: " & ex.Message)
            MsgBox("Error deleting template [" & TemplateDetails.Name & "]." & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

RETURN_AND_EXIT:
        Return ReturnValue
    End Function
#End Region

#Region "Load Procedures and Functions"
    Public Sub LoadTemplateList(sender As ReportSelection)
        '####################################################################################################################################################################################################################################
        'Description: Load Template List

        oReportSelection = sender

        If IsNothing(oReportSelection) Then Exit Sub
        Try
            Dim TemplatesTable As DataTable
            ClearTemplateList(oReportSelection.GridTemplates)

            '####################################################################################################################################################################################################################################
            'EXITS IF TEMPLATES CONTROL IS NOT ENABLED (BECAUSE REPORT IS SET NOT TO USE TEMPLATES)
            If Not oReportSelection.LayoutControlGroup_Templates.Enabled Then Exit Sub

            '####################################################################################################################################################################################################################################
            'EXITS IF FILTER OPTIONS CONTROL IS NOT ENABLED 
            'tonytest If Not oReportSelection.LayoutControlGroup_Filter.Enabled Then Exit Sub

            '####################################################################################################################################################################################################################################
            'LOAD THE TEMPLATE LIST
            TemplatesTable = CreateReportTemplateDT(oReportSelection.oReportInfo.ReportGroup, oReportSelection.oReportInfo.ObjectID)

            If TemplatesTable.Rows.Count > 0 Then
                oReportSelection.GridTemplates.DataSource = TemplatesTable
                oReportSelection.GridTemplates.Refresh()
            End If
        Catch ex As Exception
            LogErrors("Error loading template list for report '" & oReportSelection.oReportInfo.Caption & "'." & Chr(13) & "Error: " & ex.Message)
            MsgBox("Error loading template list for report '" & oReportSelection.oReportInfo.Caption & "'." & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub LoadReportTemplate(ByRef sender As ReportSelection, SelectedTemplateDetails As ReportTemplateDetail, Optional HasViewReportButton As Boolean = False)
        '####################################################################################################################################################################################################################################
        '## Load a Selected Template

        '####################################################################################################################################################################################################################################
        'DECLARE VARIABLES
        Dim bViewAfterLoadTemplate As Boolean = False
        '####################################################################################################################################################################################################################################

        oReportSelection = sender
        If Not isReportSelectionInitialized() Then Exit Sub

        If SelectedTemplateDetails.PKey.Length > 0 Then
            'If MsgBox("Load Template: '" & SelectedTemplateDetails.Name & "'?", 36, GetAppName) = vbYes Then
            If isLoadTemplate(frmLoadTemplate.UsedBy.Report, bViewAfterLoadTemplate, SelectedTemplateDetails.Name, HasViewReportButton) Then
                OpenReportWaitForm()
                Try
                    oReportSelection.setReportIsClicked()
                    oReportSelection.setClearFilterButtonIsClicked()
                    Dim dt As DataTable = TryCast(oReportSelection.GridSelected.DataSource, DataTable)
                    If dt.Rows.Count > 0 Then
                        oReportSelection.ShowSelectionList()
                    End If
                    oReportSelection.ClearSelectionListFilter()
                    If oReportSelection.oFilterOption.HasFilterOptionTemplateValues(SelectedTemplateDetails.PKey) Then oReportSelection.ClearFilterOptionsValues()
                    If oReportSelection.oSortOption.HasSortOptionTemplateValues(SelectedTemplateDetails.PKey) Then oReportSelection.ClearSortOptionsValues(True)
                    oReportSelection.ShowButtons(ReportSelection.ShowButtonOption.SELECTREPORT)

                    '####################################################################################################################################################################################################################################
                    'LOAD FILTER OPTION VALUES FROM TEMPLATE
                    oReportSelection.oFilterOption.LoadFilterOptionTemplateValues(SelectedTemplateDetails.PKey)

                    '####################################################################################################################################################################################################################################
                    'LOAD SORT OPTION VALUES FROM TEMPLATE
                    oReportSelection.oSortOption.LoadSortOptionTemplateValues(SelectedTemplateDetails.PKey)

                    '####################################################################################################################################################################################################################################
                    'LOAD SELECTED DATA VALUES FROM TEMPLATE
                    LoadReportTemplateSelectedDataValues(SelectedTemplateDetails)

                    oReportSelection.setClearFilterButtonIsClicked(False)

                    '####################################################################################################################################################################################################################################
                    'APPLIES THE LOADED TEMPLATE OPTION VALUES TO THE PRINT SELECTION
                    oReportSelection.oFilterOption.ApplyFilterToPrintSelection()
                    CloseReportWaitForm()

                    If bViewAfterLoadTemplate Then sender.ExecCustomFunction(New Object() {"PREVIEWREPORT"})
                Catch ex As Exception
                    Dim cErr As String = ex.Message
                    CloseReportWaitForm()
                    LogErrors("Failed to load report template [" & SelectedTemplateDetails.Name & "] of report [" & oReportSelection.oReportInfo.Caption & "]." & Chr(13) & "Error: " & cErr)
                    MsgBox("Failed to load report template [" & SelectedTemplateDetails.Name & "]." & Chr(13) & "Error: " & cErr, MsgBoxStyle.Exclamation)
                End Try
            End If

        Else
            MsgBox("Please select template to load.", MsgBoxStyle.Information, GetAppName)
        End If
    End Sub

    Public Function isLoadTemplate(Type As frmLoadTemplate.UsedBy, ByRef varIfViewAfterLoad As Boolean, TemplateName As String, Optional HasViewReportButton As Boolean = False, Optional ShowErrorMessage As Boolean = True) As Boolean
        Dim ReturnValue As Boolean = False
        Dim f As New frmLoadTemplate(Type, TemplateName, HasViewReportButton)
        f.ShowDialog()

        ReturnValue = f.OKButtonIsClicked
        varIfViewAfterLoad = f.chkViewAfterLoad.Checked

        f.Close()
        f.Dispose()
        Return ReturnValue

    End Function


    Public Sub LoadReportTemplateSelectedDataValues(TemplateDetails As ReportTemplateDetail)
        '####################################################################################################################################################################################################################################
        'Description: Loads the Selected Data values from the selected template
        Dim row As DataRow = Nothing
        Dim oControl As New Control
        Dim templateItems As DataTable = CreateReportTemplateValuesDT(TemplateDetails.PKey, ReportTemplateContentType.DataSelection)
        If templateItems.Rows.Count = 0 Then Exit Sub

        For Each templateRow As DataRow In templateItems.Rows
            Try

                Dim table As DataTable = TryCast(oReportSelection.GridSelected.DataSource, DataTable)
                Dim nRowHandle As Integer = oReportSelection.GridSelectionView.LocateByValue(oReportSelection.oReportInfo.SelectionKeyField, templateRow("Value"))
                row = TryCast(oReportSelection.GridSelectionView.GetDataRow(nRowHandle), DataRow)
                Dim RowHandler As Integer = oReportSelection.GridSelectionView.FocusedRowHandle
                If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
                    table.ImportRow(row)
                    row.Delete()
                    Try
                        oReportSelection.GridSelectionView.FocusedRowHandle = RowHandler
                    Catch ex As Exception
                        'go to the very end
                        oReportSelection.GridSelectionView.FocusedRowHandle = oReportSelection.GridSelectionView.RowCount - 1
                    End Try
                End If

            Catch ex As Exception
                LogErrors("Failed to load selected data [" & row("OptionsObjectID") & " = " & row("Value") & "] from template '" & TemplateDetails.Name & "'.")
            End Try
        Next
    End Sub

#End Region

End Module
