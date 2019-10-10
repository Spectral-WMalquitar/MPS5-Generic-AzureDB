Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UI.XtraReportExtensions

Public Module basReports

#Region "Constants"
    Public Const REPORT_DATE_FORMAT As String = "dd-MMM-yyyy"

    Public Const tblNameReports As String = "MSystblReports"
    Public Const tblNameReportsOptions As String = "MSystblReportFilterOptions"
    Public Const tblNameTemplate As String = "MSystblRepOptTemplate"
    Public Const tblNameTemplateValues As String = "MSystblRepOptTemplateValues"

    Public Const DefaultFilterOptionControlDLL As String = "Reports"
    Public Const DefaultFilterOptionControl As String = "FilterControlDefault"
#End Region

#Region "Declarations"
    Public FilterOption As New clsFilterOption
    Public SortOption As New clsSortOption
    Public SavedFilterOptionValues As New clsFilterOptionValues


    Structure RowSoureType
        Const Query = "QUERY"
        Const SQL = "SQL"
        Const PredefinedDataSource = "PREDEF_DS"
        Const ItemList = "ITEMLIST"
        Const Object$ = "OBJ"
    End Structure

    Public Class ControlObjectClass
        Public ObjectDLL As String = ""
        Public ObjectClass As String = ""
    End Class

    Public Class ReportObjectInfo
        Public ObjectID As String = ""
        Public Group As String = ""
    End Class

#Region "Enum and Structure For Report Selection Form"
    Structure PreviewExport
        Const Preview = "PREVIEW"
        Const Export = "EXPORT"
    End Structure

    Public Enum ReportOutputMode As Integer
        None = 0
        Preview = 1
        Print = 2
        Export = 3
        PreviewMultiple = 4
    End Enum

    Public Enum ReportExportType As Integer
        None = 0
        Csv = 1
        Html = 2
        Image = 3
        Mht = 4
        Pdf = 5
        Rtf = 6
        Text = 7
        Custom = 8
    End Enum

    Public Enum SelectDeselectAll As Integer
        SelectAll = 1
        DeselectAll = 2
    End Enum

    Structure RibbonControlReportPage
        Const Crew As String = "rpReports"
        Const Payroll As String = "rpPayroll"
        Const Admin As String = "rpAdmin"
        Const KPI As String = "rpKPI"
    End Structure

    Structure ReportOptionsPageGroup
        Const Crew As String = "rpgReportOptions"
        Const Payroll As String = "rpgPayrollReportOptions"
        Const Admin As String = "rpgAdminReportOptions"
        Const KPI As String = "rpgKPIReportOptions"
        Const KPITemplate As String = "rpgKPITemplateOptions"
        Const KPIDisplayOptions As String = "rpgKPIDisplayOptions"
        Const KPIViewingOptions As String = "rpgPrintOptions"
    End Structure

    '####################################################################################################################################################################################################################################
    Public Structure ReportListFields
        Const ObjectID As String = "ObjectID"
        Const Caption As String = "Caption"
        Const ReportGroup As String = "ReportGroup"
        Const DLL As String = "DLL"
        Const ReportClass As String = "ReportClass"
        Const SelectionSource As String = "SelectionSource"
        Const SelectionSourceType As String = "SelectionSourceType"
        Const SelectionKeyField As String = "SelectionKeyField"
        Const SelectionDisplayField As String = "SelectionDisplayField"
        Const SelectionSortField As String = "SelectionSortField"
        Const SortCode As String = "SortCode"
        Const GroupedBy As String = "GroupedBy"
        Const SortedBy As String = "SortedBy"
        Const Remarks As String = "Remarks"
        Const UseSelectionList As String = "UseSelectionList"
        Const OpensPopupForm As String = "OpensPopupForm"
        Const DataSource As String = "DataSource"
        Const KeyFilterField As String = "KeyFilterField"
        Const SortFields As String = "SortFields"
        Const ReportFilterOptions As String = "ReportFilterOptions"
        Const UseTemplateList As String = "UseTemplateList"
        Const ReportFilterOptionDLL As String = "ReportFilterOptionDLL"
        Const ReportFilterOptionClass As String = "ReportFilterOptionClass"
        Const UsePreviewButton As String = "UsePreviewButton"
        Const UseExportButton As String = "UseExportButton"
        Const DateRangeFromField As String = "DateRangeFromField"
        Const DateRangeToField As String = "DateRangeToField"
    End Structure



#End Region

#Region "Enum and Structure For Sorting"
    Structure SortOptionFields
        Const FieldName = "FieldName"
        Const Caption = "Caption"
        Const SortOrder = "SortOrder"
        Const DefaultSortOrder = "DefaultSortOrder"
        Const isMovable = "isMovable"
    End Structure

    Structure SortOptionSortCode
        Const Ascending = "ASC"
        Const Descending = "DESC"
        Const None = "NONE"
    End Structure

    Public Enum FieldSortOrder
        Ascending = 1
        Descending = 2
        None = 0
    End Enum
#End Region


#End Region

#Region "Print Selection"
    Public Class PresentRecord

        '------------------------------------------------------------------------------------
        'Variables
        Public Table As DataTable
        Public _ConditionString As String = ""
        Public _SelectionList As String = ""
        Public _List As List(Of Object) = Nothing
        Public ReportDataSourceKey As String = ""

        '------------------------------------------------------------------------------------
        'Public Data As New DataClass

        Public Sub New()
            InitTableObject()
        End Sub

        Public Sub New(_reportinfo As ReportInfo, _view As DevExpress.XtraGrid.Views.Grid.GridView)
            InitTableObject()
            Populate(_reportinfo, _view)
        End Sub

        Public Sub New(_reportinfo As ReportInfo, _value As Object())
            InitTableObject()
            Populate(_reportinfo, _value)
        End Sub

        Public Sub Populate(_reportinfo As ReportInfo, _view As DevExpress.XtraGrid.Views.Grid.GridView)
            '####################################################################################################################################################################################################################################
            '### Description: Gets selected items from report selection's gridselectedview. Places into Data.Table
            ReportDataSourceKey = _reportinfo.KeyFilterField

            Table.Rows.Clear()
            If _reportinfo.UseSelectionList <> 0 Then
                Try
                    For i As Integer = 0 To _view.RowCount - 1
                        Table.Rows.Add(New Object() {_view.GetRowCellValue(i, _reportinfo.SelectionKeyField)})
                    Next

                Catch ex As Exception
                    Table.Rows.Clear()
                    'MsgBox(ex.Message)
                End Try

            End If
        End Sub

        Public Sub Populate(_reportinfo As ReportInfo, _values As Object()) ', Optional UseDisplayField As Boolean = False)
            '####################################################################################################################################################################################################################################
            '### Description: Gets selected items from array object parameter. Places into Data.Table
            ReportDataSourceKey = _reportinfo.KeyFilterField

            Table.Rows.Clear()
            If _reportinfo.UseSelectionList <> 0 Then
                Try
                    For i As Integer = 0 To _values.GetUpperBound(0)
                        Table.Rows.Add(New Object() {_values(i)})
                    Next

                Catch ex As Exception
                    Table.Rows.Clear()
                    'MsgBox(ex.Message)
                End Try

            End If
        End Sub


        'Values Procedures
        Public Property ConditionString(Optional WithReportDataSourceKey As Boolean = False) As String
            Set(value As String)
                _ConditionString = value
            End Set
            Get
                'checks if a condition string value is manually assigned
                'return immediately if yes
                If Not IfNull(_ConditionString, "").Equals("") Then
                    Return _ConditionString

                Else
                    Return GetConditionString(True)
                End If

            End Get
        End Property

        'Values Procedures
        Public Property SelectionList(Optional WithReportDataSourceKey As Boolean = False) As String
            Set(value As String)
                _SelectionList = value
            End Set
            Get
                'checks if a condition string value is manually assigned
                'return immediately if yes
                If Not IfNull(_SelectionList, "").Equals("") Then
                    Return _SelectionList

                Else
                    Return GetConditionString()
                End If

            End Get
        End Property

        Private Function GetConditionString(Optional WithReportDataSourceKey As Boolean = False)
            '####################################################################################################################################################################################################################################
            '### Description: Gets selected items from presentrecord table. Places into format: <field> IN ('item1', 'item2', ..... 'itemX')
            Dim cStringCondition As New System.Text.StringBuilder

            Dim cTemp As String

            cStringCondition.Clear()

            Try
                For i As Integer = 0 To Table.Rows.Count - 1
                    cTemp = IIf(cStringCondition.Length > 0, ", ", "") & _
                            "'" & CleanInput(Table.Rows(i)("PKey")) & "'"
                    cStringCondition.Append(cTemp)
                Next

            Catch ex As Exception
                cStringCondition.Clear()
                'MsgBox(ex.Message)
            End Try

            Dim ReturnValue As String
            If cStringCondition.Length > 0 Then
                ReturnValue = "(" & cStringCondition.ToString & ")"
                'Data._ConditionString = cStringCondition.ToString
                If WithReportDataSourceKey Then
                    If ReportDataSourceKey.Length > 0 Then
                        Return IIf(WithReportDataSourceKey, ReportDataSourceKey & " IN ", "") & _
                                ReturnValue
                    Else
                        'Return "true"
                        ReturnValue = "1 = 1"
                    End If
                End If
            Else
                ReturnValue = ""
            End If

            Return ReturnValue
        End Function

        Public Property List() As List(Of Object)
            Set(value As List(Of Object))
                _List = value
            End Set
            Get
                'checks if a "list" variable value is manually assigned
                'return immediately if yes
                If Not IsNothing(_List) Then
                    Return _List
                    Exit Property
                End If

                '####################################################################################################################################################################################################################################
                '### Description: Gets selected items from selection. Places into format: <field> IN ('item1', 'item2', ..... 'itemX')
                Dim tmpList As New List(Of Object)
                tmpList.Clear()

                Try
                    For i As Integer = 0 To Table.Rows.Count - 1

                        tmpList.Add(Table.Rows(i)("PKey"))

                    Next

                Catch ex As Exception
                    tmpList.Clear()
                    'MsgBox(ex.Message)
                End Try

                Return tmpList

            End Get
        End Property

       Private Sub InitTableObject()
            Table = New DataTable
            Table.Columns.Add(New DataColumn("PKey", System.Type.GetType("System.String")))
        End Sub



    End Class
#End Region

#Region "Loading Screen"
    Public Sub OpenReportWaitForm()
        Try
            Cursor.Current = Cursors.WaitCursor
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(Waitform))
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CloseReportWaitForm()
        Try
            Cursor.Current = Cursors.Default
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Sub title"
    Function CreateDateRangeSubTitle(Optional ByVal DateFrom As Object = Nothing, Optional ByVal DateTo As Object = Nothing) As String
        Dim cReturnValue As String = ""

        If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
            cReturnValue = "from " & Format(DateFrom, REPORT_DATE_FORMAT) & " to " & Format(DateTo, REPORT_DATE_FORMAT)
        ElseIf IsNothing(DateFrom) And Not IsNothing(DateTo) Then
            cReturnValue = "until " & Format(DateTo, REPORT_DATE_FORMAT)
        ElseIf Not IsNothing(DateFrom) And IsNothing(DateTo) Then
            cReturnValue = "since " & Format(DateFrom, REPORT_DATE_FORMAT)
        Else
            cReturnValue = "as of " & Format(DateTime.Now(), REPORT_DATE_FORMAT)
        End If
        Return cReturnValue
    End Function

#End Region

#Region "Report Object Classes"

#Region "Report Info Class"
    Public Class ReportInfo
        Private oReportObjectInfo As New ReportObjectInfo

        Public Property ObjectID() As String
            Get
                Return oReportObjectInfo.ObjectID
            End Get
            Set(ByVal value As String)
                oReportObjectInfo.ObjectID = value
            End Set
        End Property

        Public Property ReportGroup() As String
            Get
                Return oReportObjectInfo.Group
            End Get
            Set(ByVal value As String)
                oReportObjectInfo.Group = value
            End Set
        End Property

        'Public ObjectID As String = ""
        'Public ReportGroup As String = ""
        Public Caption As String = ""
        Public DLL As String = ""
        Public ReportClass As String = ""
        Public SelectionSource As String = ""
        Public SelectionSourceType As String = ""
        Public SelectionKeyField As String = ""
        Public SelectionDisplayField As String = ""
        Public SelectionSortField As String = ""
        Public SortCode As Integer = 0
        Public GroupedBy As String = ""
        Public SortedBy As String = ""
        Public Remarks As String = ""
        Public UseSelectionList As Boolean = False
        Public OpensPopupForm As String = ""
        Public KeyFilterField As String = ""
        Public SortFields As String = ""
        Public ReportFilterOptions As String = ""
        Public UseTemplateList As Boolean = False
        Public ReportFilterOptionDLL As String = ""
        Public ReportFilterOptionClass As String = ""
        Public UsePreviewButton As Boolean = False
        Public UseExportButton As Boolean = False

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Sub New(cReportObjectID As String, cReportGroup As String)
            Dim dt As DataTable = MPSDB.CreateTable("SELECT TOP 1 * FROM " & tblNameReports & " WHERE ObjectID = '" & cReportObjectID & "' AND ReportGroup = '" & cReportGroup & "'")
            If dt.Rows.Count > 0 Then
                LoadReportPropertiesFromDt(dt)
            End If
        End Sub

        Sub New(dr As DataRow)
            If Not dr Is Nothing Then
                LoadReportPropertiesFromDataRow(dr)
            End If
        End Sub

        Public Sub LoadReportPropertiesFromDt(ByVal dt As DataTable)
            For Each dr As DataRow In dt.Rows
                LoadReportPropertiesFromDataRow(dr)
            Next
        End Sub

        Public Sub LoadReportPropertiesFromDataRow(ByVal dr As DataRow)
            ObjectID = Trim(IfNull(dr.Item(ReportListFields.ObjectID), ""))
            Caption = Trim(IfNull(dr.Item(ReportListFields.Caption), ""))
            ReportGroup = Trim(IfNull(dr.Item(ReportListFields.ReportGroup), ""))
            DLL = Trim(IfNull(dr.Item(ReportListFields.DLL), ""))
            ReportClass = Trim(IfNull(dr.Item(ReportListFields.ReportClass), ""))
            SelectionSource = Trim(IfNull(dr.Item(ReportListFields.SelectionSource), ""))
            SelectionSourceType = Trim(IfNull(dr.Item(ReportListFields.SelectionSourceType), ""))
            SelectionKeyField = Trim(IfNull(dr.Item(ReportListFields.SelectionKeyField), ""))
            SelectionDisplayField = Trim(IfNull(dr.Item(ReportListFields.SelectionDisplayField), ""))
            SelectionSortField = Trim(IfNull(dr.Item(ReportListFields.SelectionSortField), ""))
            SortCode = Trim(IfNull(dr.Item(ReportListFields.SortCode), 0))
            GroupedBy = Trim(IfNull(dr.Item(ReportListFields.GroupedBy), ""))
            SortedBy = Trim(IfNull(dr.Item(ReportListFields.SortedBy), ""))
            Remarks = Trim(IfNull(dr.Item(ReportListFields.Remarks), ""))
            UseSelectionList = Trim(IfNull(dr.Item(ReportListFields.UseSelectionList), 0))
            OpensPopupForm = Trim(IfNull(dr.Item(ReportListFields.OpensPopupForm), ""))
            KeyFilterField = Trim(IfNull(dr.Item(ReportListFields.KeyFilterField), ""))
            SortFields = Trim(IfNull(dr.Item(ReportListFields.SortFields), ""))
            ReportFilterOptions = Trim(IfNull(dr.Item(ReportListFields.ReportFilterOptions), ""))
            UseTemplateList = Trim(IfNull(dr.Item(ReportListFields.UseTemplateList), 0))
            ReportFilterOptionDLL = Trim(IfNull(dr.Item(ReportListFields.ReportFilterOptionDLL), ""))
            ReportFilterOptionClass = Trim(IfNull(dr.Item(ReportListFields.ReportFilterOptionClass), ""))
            UsePreviewButton = Trim(IfNull(dr.Item(ReportListFields.UsePreviewButton), 0))
            UseExportButton = Trim(IfNull(dr.Item(ReportListFields.UseExportButton), 0))

        End Sub
    End Class
#End Region
#End Region

#Region "Report Generating Procedures"
    Public Sub BuildReport(REPORT_DETAIL As ReportDetail, Optional ShowErrorMessage As Boolean = True)
        '####################################################################################################################################################################################################################################
        '### Description: Assembles the report by (1) calling the class constructor, or (2) constructing the data source based from the tblreports
        '--------------------------------------------------------------------------------------------------------------------------------------
        'OpenReportWaitForm()
        Dim eA As System.Reflection.Assembly

        Try
            If REPORT_DETAIL.hasDllAndClass() Then
                'IF A REPORT HAS A SPECIFIC DATA BUILD CLASS

                If CustomOutputReport(REPORT_DETAIL) Then
                    '####################################################################################################################################################################################################################################
                    'IF REPORT USES CUSTOM OUTPUT
                Else
                    '####################################################################################################################################################################################################################################
                    'IF REPORT USES AUTOMATIC VIEWING
                    'LOADS THE CORRESPONDING DLL AND CLASS
                    eA = System.Reflection.Assembly.Load(REPORT_DETAIL.ReportInfo.DLL)
                    eA.CreateInstance(REPORT_DETAIL.ReportInfo.DLL & "." & REPORT_DETAIL.ReportInfo.ReportClass, True, Reflection.BindingFlags.Default, Nothing, New Object() {REPORT_DETAIL}, Nothing, Nothing)

                    'ADD TITLE PARAMETER TO REPORT
                    BuildReportDisplayName(REPORT_DETAIL.MainReport, REPORT_DETAIL)

                    'GENERATES AN OUTPUT FOR EACH REPORT GENERATED BY THE REPORT CLASS
                    OutputReport(REPORT_DETAIL.MainReport, REPORT_DETAIL.Output.Mode, REPORT_DETAIL.Output.ExportType, REPORT_DETAIL.Output.Path, REPORT_DETAIL)
                End If

            Else
                If ShowErrorMessage Then MsgBox("Unable to build/generate report. Please contact your system administrator for assistance.", vbExclamation)
            End If
        Catch ex As Exception
            If ShowErrorMessage Then MessageBox.Show(ex.Message, "MPS 5 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CloseReportWaitForm()
    End Sub

    Public Sub OutputReport(oReport As DevExpress.XtraReports.UI.XtraReport, OutputMode As ReportOutputMode, Optional ExportType As ReportExportType = ReportExportType.None, Optional OutputPath As String = "", Optional reportDetail As ReportDetail = Nothing)
        If IsNothing(oReport) Then Exit Sub

        WatermarkReport_Payroll(oReport, reportDetail)

        With oReport
            Select Case OutputMode
                Case ReportOutputMode.Preview
                    oReport.ShowPreviewDialog()

                Case ReportOutputMode.PreviewMultiple
                    oReport.ShowPreview()

                Case ReportOutputMode.Export
                    Select Case ExportType
                        Case ReportExportType.Csv
                            .ExportToCsv(IIf(OutputPath.Length > 0, OutputPath, System.AppDomain.CurrentDomain.BaseDirectory() & oReport.Name & ".pdf"))

                        Case ReportExportType.Html
                            .ExportToHtml(IIf(OutputPath.Length > 0, OutputPath, System.AppDomain.CurrentDomain.BaseDirectory() & oReport.Name & ".html"))

                        Case ReportExportType.Image
                            .ExportToImage(IIf(OutputPath.Length > 0, OutputPath, System.AppDomain.CurrentDomain.BaseDirectory() & oReport.Name & ".jpg"))

                        Case ReportExportType.Mht
                            .ExportToImage(IIf(OutputPath.Length > 0, OutputPath, System.AppDomain.CurrentDomain.BaseDirectory() & oReport.Name & ".mht"))

                        Case ReportExportType.Pdf
                            .ExportToPdf(IIf(OutputPath.Length > 0, OutputPath, System.AppDomain.CurrentDomain.BaseDirectory() & oReport.Name & ".pdf"))

                        Case ReportExportType.Rtf
                            .ExportToRtf(IIf(OutputPath.Length > 0, OutputPath, System.AppDomain.CurrentDomain.BaseDirectory() & oReport.Name & ".rtf"))

                        Case ReportExportType.Text
                            .ExportToText(IIf(OutputPath.Length > 0, OutputPath, System.AppDomain.CurrentDomain.BaseDirectory() & oReport.Name & ".txt"))

                    End Select

                Case ReportOutputMode.Print
                    .Print()

            End Select
        End With

    End Sub

    'Public Function CustomOutputReport(ReportObjectID As String, ReportGroup As String) As Boolean
    '    If ReportObjectID = "<SAMPLE REPORT 1>" And ReportGroup = "<SAMPLE REPORT GROUP 1>" Then
    '        'do something here

    '        Return True     'do not forget to return true to identify that report used customoutputreport

    '    ElseIf ReportObjectID = "<SAMPLE REPORT 2>" And ReportGroup = "<SAMPLE REPORT GROUP 2>" Then
    '        'do something here

    '        Return True     'do not forget to return true to identify that report used customoutputreport

    '    Else
    '        'Otherwise
    '        Return False
    '    End If
    'End Function

    Public Function CustomOutputReport(REPORT_DETAIL As ReportDetail) As Boolean
        If REPORT_DETAIL.ReportInfo.ObjectID = "rptBDORemittance" And REPORT_DETAIL.ReportInfo.ReportGroup = "HOME ALLOTMENT PAYROLL" Then
            If REPORT_DETAIL.Output.Mode = ReportOutputMode.Export Then
                Dim eA As System.Reflection.Assembly
                eA = System.Reflection.Assembly.Load(REPORT_DETAIL.ReportInfo.DLL)
                eA.CreateInstance(REPORT_DETAIL.ReportInfo.DLL & "." & REPORT_DETAIL.ReportInfo.ReportClass, True, Reflection.BindingFlags.Default, Nothing, New Object() {REPORT_DETAIL}, Nothing, Nothing)


                Return True
            Else
                Return False
            End If


        Else
            'Otherwise
            Return False
        End If
    End Function

    Public Sub BuildReportDisplayName(ByRef oReport As DevExpress.XtraReports.UI.XtraReport, oReportDetail As ReportDetail)
        If IsNothing(oReport) Then Exit Sub

        Dim cReportName As String = oReportDetail.ReportInfo.Caption

        Try
            If Not IsNothing(oReportDetail.AutoEmail.ConditionTitle) Then
                If oReportDetail.AutoEmail.ConditionTitle.ToString.Length > 0 Then
                    cReportName = cReportName & " (" & oReportDetail.AutoEmail.ConditionTitle & ")"
                End If
            End If
        Catch ex As Exception
            LogErrors("Error when adding title parameter to report [" & oReport.Name & "]")
        End Try

        oReport.DisplayName = cReportName
    End Sub

    Public Function ReportHasData(ByVal SQL As String, Optional ByVal ShowMessage As Boolean = False, Optional ByVal CustomMessage As String = "") As Boolean
        '####################################################################################################################################################################################################################################
        '### Description: Checks if report has data based on passed sql statement parameter.
        '                 Returns boolean

        Dim dt As DataTable
        Dim bHasData As Boolean = False

        Try
            dt = MPSDB.CreateTable(SQL)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    bHasData = True
                End If
            End If
        Catch ex As Exception

        End Try

        If Not bHasData And ShowMessage Then
            If CustomMessage.Length > 0 Then
                MsgBox(CustomMessage, vbExclamation, GetAppName() & " Reports")
            Else
                MsgBox("Report has no data.", vbExclamation, GetAppName() & " Reports")
            End If
        End If

        Return bHasData
    End Function

    Public Function ReportHasData(ByVal dt As DataTable, Optional ByVal ShowMessage As Boolean = False, Optional ByVal CustomMessage As String = "") As Boolean
        '####################################################################################################################################################################################################################################
        '### Description: Checks if report has data based on passed datatable parameter.
        '                 Returns boolean

        Dim bHasData As Boolean = False

        Try
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    bHasData = True
                End If
            End If
        Catch ex As Exception

        End Try

        If Not bHasData And ShowMessage Then
            If CustomMessage.Length > 0 Then
                MsgBox(CustomMessage, vbExclamation, GetAppName() & " Reports")
            Else
                MsgBox("Report has no data.", vbExclamation, GetAppName() & " Reports")
            End If
        End If

        Return bHasData
    End Function

    Public Function validateReportDataSource(ByRef dt As DataTable, Optional ShowErrorMessage As Boolean = True) As Boolean
        '####################################################################################################################################################################################################################################
        '### Description: Validates if report data source if it has contents 
        Dim retval As Boolean = False

        If dt Is Nothing Then
            If ShowErrorMessage Then MsgBox("Unable to generate report source.", vbExclamation)
            GoTo RETURN_AND_EXIT
        End If

        If Not ReportHasData(dt, ShowErrorMessage) Then
            'function already returns an message if has no data.
            GoTo RETURN_AND_EXIT
        End If

        retval = True
RETURN_AND_EXIT:
        Return retval
    End Function

    Public Function changeDateRangeToSubTitle(ByVal tmpDateFrom, ByVal tmpDateTo)
        Dim strSubTitle As String = ""

        '####################################################################################################################################################################################################################################
        'Remove Single Quotes
        If InStr(tmpDateFrom, "'") Then
            tmpDateFrom = Replace(tmpDateFrom, "'", "")
        End If

        If InStr(tmpDateTo, "'") Then
            tmpDateTo = Replace(tmpDateTo, "'", "")
        End If

        '####################################################################################################################################################################################################################################
        'Construct SubTitle
        If IsDate(tmpDateFrom) And IsDate(tmpDateTo) Then
            strSubTitle = "from " & Format(CDate(tmpDateFrom), "dd-MMM-yyyy") & " to " & Format(CDate(tmpDateTo), "dd-MMM-yyyy")
        ElseIf IsDate(tmpDateFrom) And Not IsDate(tmpDateTo) Then
            strSubTitle = "since " & Format(CDate(tmpDateFrom), "dd-MMM-yyyy")
        ElseIf Not IsDate(tmpDateFrom) And IsDate(tmpDateTo) Then
            strSubTitle = "until " & Format(CDate(tmpDateTo), "dd-MMM-yyyy")
        End If

        Return strSubTitle
    End Function

    Public Sub SetDefaultReportLabels(ByRef rep As DevExpress.XtraReports.UI.XtraReport, ByVal db As SQLDB)
        '####################################################################################################################################################################################################################################
        '### Description: This function is used to assign values in the report static labels (for example: Company Name, Company Address, Date Printed, etc.)
        '                 In cases where a certain control is in the function below but not found in the report, the value assignment is skipped via try-catch

        '####################################################################################################################################################################################################################################
        'COMPANY NAME
        Try
            rep.FindControl("lblCompanyName", False).Text = Trim(db.GetConfig("Name"))
        Catch ex As Exception
        End Try

        '####################################################################################################################################################################################################################################
        'COMPANY ADDRESS
        Try
            rep.FindControl("lblCompanyAddr", False).Text = Trim(db.GetConfig("Addr"))
        Catch ex As Exception
        End Try

        '####################################################################################################################################################################################################################################
        'DATE PRINTED
        Try
            rep.FindControl("lblDatePrinted", False).Text = "Date Printed: " & Format(Now(), "dd-MMM-yyyy")
        Catch ex As Exception
        End Try

    End Sub
#End Region

#Region "Bind Procedures"
    Public Sub BindReportControls(ByRef rep As XtraReport)
        '####################################################################################################################################################################################################################################
        '### Description: THE BELOW OPTION BINDS THE DATA BY LOOPING TO ALL CONTROLS IN THE REPORT
        '                 THE CONTROL TO BIND MUST HAVE A TAG VALUE THAT HAS THE FF FORMAT:
        '                 sample format: "BIND_" + <field name>
        '                 sample:        "BIND_LName"
        '                                "BIND_CrewName"
        '                 IF THE CONTROL IS XRTABLE, ASSIGN "BIND" TO TAG PROPERTY
        Dim type As Type


        For Each band As DevExpress.XtraReports.UI.Band In rep.Bands

            For Each control As DevExpress.XtraReports.UI.XRControl In band

                If control.Tag.ToString.Length > 0 Then

                    If control.Tag.ToString = "BIND" Then

                        type = control.GetType()

                        Select Case type.Name
                            Case "XRTable"  'if control is an XRTable
                                Dim table As DevExpress.XtraReports.UI.XRTable = TryCast(control, DevExpress.XtraReports.UI.XRTable)

                                For Each row As DevExpress.XtraReports.UI.XRTableRow In table

                                    For Each cell As DevExpress.XtraReports.UI.XRTableCell In row

                                        If cell.Tag.ToString.Length > 0 Then
                                            If cell.Tag.ToString.Substring(0, 5) = "BIND_" Then
                                                BindData(rep.FindControl(cell.Name, True), "Text", Nothing, cell.Tag.ToString.Substring(5))
                                            End If
                                        End If
                                    Next
                                Next
                        End Select

                    Else 'if .Tag is not "BIND"
                        If control.Tag.ToString.Substring(0, 5) = "BIND_" Then
                            Try
                                BindData(rep.FindControl(control.Name, True), "Text", Nothing, control.Tag.ToString.Substring(5))
                            Catch ex As Exception
                                Try
                                    rep.FindControl(control.Name, True).Text = "BIND FAILED"
                                Catch ex2 As Exception
                                    'do nothing
                                End Try
                            End Try
                        End If
                    End If
                End If



            Next
        Next

    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub BindData(ByVal sender As Object, ByVal nProperty As String, ByVal DbSource As String, ByVal nFieldName As String, Optional ByVal nFormat As String = "")
        '####################################################################################################################################################################################################################################
        '### Description: Binds data to a report control based on the passed parameters
        Try
            Dim nType As Type = sender.GetType
            Select Case nType.Name
                Case "XRLabel"
                    TryCast(sender, DevExpress.XtraReports.UI.XRLabel).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
                Case "XRTableCell"
                    TryCast(sender, DevExpress.XtraReports.UI.XRTableCell).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
                Case "XRPictureBox"
                    TryCast(sender, DevExpress.XtraReports.UI.XRPictureBox).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
            End Select
        Catch ex As Exception
            Throw (New Exception(ex.Message))
        End Try
    End Sub

    Public Sub LoadDataToDetailReport(sender As System.Object, sql As String)
        Dim detailReport As DetailReportBand
        Dim dt As DataTable
        dt = MPSDB.CreateTable(sql)
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        detailReport.DataSource = dt
    End Sub

    Public Sub AssignReportParameter(MainRpt As XtraReport, RptSub As XtraReport, MainRpt_FieldName As String, SubRpt_FieldName As String)
        '####################################################################################################################################################################################################################################
        ''### Description: This procedure is used for sub reports where a field value from the mainreport is assigned to the sub report paramter
        Try
            Dim Value As String = MainRpt.GetCurrentColumnValue(MainRpt_FieldName).ToString()
            RptSub.Parameters(SubRpt_FieldName).Value = Value
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Report Band Procedures/Functions"

    Public Sub AddSortFieldToDetailBand(ByRef ReportBand As DevExpress.XtraReports.UI.DetailBand, ByVal FieldName As String, ByVal nFieldSortOrder As FieldSortOrder)
        '####################################################################################################################################################################################################################################
        '### Description: Adds a sort field to the passed detail band
        Try
            With ReportBand
                .SortFields.Add(New GroupField(FieldName))
                If nFieldSortOrder = 1 Then
                    .SortFields(FieldName).SortOrder = XRColumnSortOrder.Ascending
                ElseIf nFieldSortOrder = 2 Then
                    .SortFields(FieldName).SortOrder = XRColumnSortOrder.Descending
                End If
            End With
        Catch ex As Exception
            'do nothing.
        End Try
    End Sub

    Public Sub AddSortFieldsToDetailBand(ByRef ReportBand As DevExpress.XtraReports.UI.DetailBand, ByVal FieldNameAndSortList As String)
        '####################################################################################################################################################################################################################################
        '### Description: Adds multiple sort fields to the passed detail band based on passed delimited string list of fields
        '    Sample FieldNameAndSortList format: 
        '                 <Field#1>~<SortOrder>;<Field#2>~<SortOrder>;<Field#n>~<SortOrder>

        Dim arrFieldNameList As String()
        Dim tmpField As String()
        Dim tmpFieldName As String
        Dim tmpFieldSort As Integer
        arrFieldNameList = Split(FieldNameAndSortList, ":")

        Try
            For i As Integer = 0 To arrFieldNameList.GetUpperBound(0)
                tmpField = arrFieldNameList(i).Split("~")
                tmpFieldName = tmpField(0)
                tmpFieldSort = CInt(IfNull(tmpField(1), 0))

                With ReportBand
                    .SortFields.Add(New GroupField(tmpFieldName))
                    If tmpFieldSort = 1 Then
                        .SortFields(tmpFieldName).SortOrder = XRColumnSortOrder.Ascending
                    ElseIf tmpFieldSort = 2 Then
                        .SortFields(tmpFieldName).SortOrder = XRColumnSortOrder.Descending
                    End If
                End With
            Next
        Catch ex As Exception

            For Each gf As GroupField In ReportBand.SortFields
                ReportBand.SortFields.Remove(gf)
            Next
        End Try

    End Sub

    Public Sub AddSortFieldsToDetailBandFromDT(ByRef ReportBand As DevExpress.XtraReports.UI.DetailBand, FieldName As String, Sorting As FieldSortOrder)
        With ReportBand
            If Sorting = FieldSortOrder.Ascending Then
                .SortFields.Add(New GroupField(FieldName))
                .SortFields(FieldName).SortOrder = XRColumnSortOrder.Ascending
            ElseIf Sorting = FieldSortOrder.Descending Then
                .SortFields.Add(New GroupField(FieldName))
                .SortFields(FieldName).SortOrder = XRColumnSortOrder.Descending
            End If
        End With
    End Sub

    Public Sub AddSortFieldsToDetailBandFromDT(ByRef ReportBand As DevExpress.XtraReports.UI.DetailBand, ByVal SortingDT As DataTable, Optional ExcemptFields As String = "")
        '####################################################################################################################################################################################################################################
        '### Description: Adds multiple sort fields to the passed detail band based on passed sorting datatable
        Dim SortFieldName As String = ""
        Dim arrExcemptFields As String() = Nothing

        Try
            If ExcemptFields.Length > 0 Then
                arrExcemptFields = ExcemptFields.Split(";")
            End If

            For Each dr As DataRow In SortingDT.Rows

                If Not arrExcemptFields Is Nothing Then
                    If Array.IndexOf(arrExcemptFields, dr.Item(SortOptionFields.FieldName)) >= 0 Then
                        GoTo NextRow
                    End If
                End If

                If dr.Item(SortOptionFields.SortOrder) = SortOptionSortCode.Ascending Or dr.Item(SortOptionFields.SortOrder) = SortOptionSortCode.Descending Then
                    SortFieldName = dr.Item(SortOptionFields.FieldName)
                    With ReportBand
                        .SortFields.Add(New GroupField(SortFieldName))
                        If dr.Item(SortOptionFields.SortOrder) = SortOptionSortCode.Ascending Then
                            .SortFields(SortFieldName).SortOrder = XRColumnSortOrder.Ascending
                        Else
                            .SortFields(SortFieldName).SortOrder = XRColumnSortOrder.Descending
                        End If
                    End With

                End If
NextRow:
            Next
        Catch ex As Exception

            For Each gf As GroupField In ReportBand.SortFields
                ReportBand.SortFields.Remove(gf)
            Next
        End Try
    End Sub

    Public Sub AddFieldsToGroupHeaderBand(ByRef GroupHeaderBand As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal FieldName As String, ByVal nFieldSortOrder As FieldSortOrder)
        '####################################################################################################################################################################################################################################
        '### Description: Adds a group field to the passed groupheader band based on passed fieldname
        Try
            With GroupHeaderBand

                .GroupFields.Add(New GroupField(FieldName))
                If nFieldSortOrder = 1 Then
                    .GroupFields(FieldName).SortOrder = XRColumnSortOrder.Ascending
                ElseIf nFieldSortOrder = 2 Then
                    .GroupFields(FieldName).SortOrder = XRColumnSortOrder.Descending
                End If
            End With
        Catch ex As Exception
            'do nothing
        End Try
    End Sub

    Public Sub AddFieldsToGroupHeaderBand(ByRef GroupHeaderBand As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal SortDT As DataTable)
        '####################################################################################################################################################################################################################################
        If SortDT Is Nothing Then Exit Sub 'if called from crewlist

        Try
            'Dim dt As DataTable = SortDT.Select("isNotMovable <> 0").CopyToDataTable 'tony20161102
            Dim dt As DataTable = SortDT.Select("isMovable = 0").CopyToDataTable
            Dim FieldName As String = ""
            Dim nFieldSortOrder As FieldSortOrder

            For Each fld As DataRow In dt.Rows
                FieldName = fld.Item("FieldName").ToString
                nFieldSortOrder = IIf(fld.Item("SortOrder").ToString = "DESC", FieldSortOrder.Descending, FieldSortOrder.Ascending)

                With GroupHeaderBand
                    .GroupFields.Add(New GroupField(FieldName))
                    If nFieldSortOrder = 1 Then
                        .GroupFields(FieldName).SortOrder = XRColumnSortOrder.Ascending
                    ElseIf nFieldSortOrder = 2 Then
                        .GroupFields(FieldName).SortOrder = XRColumnSortOrder.Descending
                    End If
                End With
            Next

        Catch ex As Exception
            'do nothing
        End Try
    End Sub

    Public Sub AddFieldsToGroupHeaderBand(ByRef GroupHeaderBand As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal FieldNameAndSortList As String)
        '####################################################################################################################################################################################################################################
        '### Description: Adds multiple group fields to the passed groupheader band based on passed delimited string list of fields
        '    Sample FieldNameAndSortList format: 
        '              <Field#1>~<SortOrder>;<Field#2>~<SortOrder>;<Field#n>~<SortOrder>

        Dim arrFieldNameList As String()
        Dim tmpField As String()
        Dim tmpFieldName As String
        Dim tmpFieldSort As Integer
        arrFieldNameList = Split(FieldNameAndSortList, ";")

        Try
            For i As Integer = 0 To arrFieldNameList.GetUpperBound(0)
                tmpField = arrFieldNameList(i).Split("~")
                tmpFieldName = tmpField(0)
                tmpFieldSort = CInt(IfNull(tmpField(1), 0))

                With GroupHeaderBand
                    .GroupFields.Add(New GroupField(tmpFieldName))
                    If tmpFieldSort = 1 Then
                        .GroupFields(tmpFieldName).SortOrder = XRColumnSortOrder.Ascending
                    ElseIf tmpFieldSort = 2 Then
                        .GroupFields(tmpFieldName).SortOrder = XRColumnSortOrder.Descending
                    End If
                End With
            Next
        Catch ex As Exception

            MsgBox(ex.Message)
            For Each gf As GroupField In GroupHeaderBand.GroupFields
                GroupHeaderBand.GroupFields.Remove(gf)
            Next
        End Try

    End Sub

#End Region

    Public Sub WatermarkReport_Payroll(oReport As XtraReport, reportDetail As ReportDetail)
        Dim rptGroup As String = reportDetail.ReportInfo.ReportGroup
        Dim rptGroups() As String = {"DISKETTING PAYROLL", _
                                     "HOME ALLOTMENT PAYROLL", _
                                     "HOME ALLOTMENT PAYROLL (QUICK VIEW)", _
                                     "ONBOARD PAYROLL", _
                                     "ONBOARD PAYROLL (QUICK VIEW)", _
                                     "SPECIAL ALLOTMENT PAYROLL", _
                                     "SPECIAL ALLOTMENT PAYROLL (QUICK VIEW)", _
                                     "PAYROLL REPORTS"}

        If Not IsNothing(reportDetail) And Not IsNothing(oReport) Then
            If rptGroups.Contains(rptGroup) Then

                Dim dt As DataTable
                Dim applyMark As Boolean = True

                Try
                    If (Not IsNothing(reportDetail.dtMainSource)) And (reportDetail.dtMainSource.Rows.Count <> 0) Then
                        dt = reportDetail.dtMainSource.DefaultView.ToTable(True, {"isLocked"})
                    Else
                        dt = oReport.DataSource.DefaultView.ToTable(True, {"isLocked"})
                    End If

                    If dt.Rows.Count = 1 And CInt(dt.Rows(0).Item("isLocked")) <> 0 Then 'all records are locked
                        applyMark = False
                    End If
                Catch ex As Exception
                    LogErrors("WatermarkReport_Payroll() : " & ex.Message)
                End Try

                If applyMark Then
                    AddWatermarkToReport(oReport, reportDetail, "DRAFT ONLY")
                    'oReport.Watermark.Text = "DRAFT ONLY"
                    'oReport.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.ForwardDiagonal
                    'oReport.Watermark.Font = New Font(oReport.Watermark.Font.FontFamily, 70, FontStyle.Bold)
                    'oReport.Watermark.ForeColor = Color.DodgerBlue
                    'oReport.Watermark.TextTransparency = 200
                    'oReport.Watermark.ShowBehind = True
                End If

            End If
        End If
    End Sub

    Public Sub AddWatermarkToReport(oReport As XtraReport, reportDetail As ReportDetail, Optional WatermarkText As String = "DRAFT ONLY")

        If Not IsNothing(reportDetail) And Not IsNothing(oReport) Then

            oReport.Watermark.Text = WatermarkText
            oReport.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.ForwardDiagonal
            oReport.Watermark.Font = New Font(oReport.Watermark.Font.FontFamily, 70, FontStyle.Bold)
            oReport.Watermark.ForeColor = Color.DodgerBlue
            oReport.Watermark.TextTransparency = 200
            oReport.Watermark.ShowBehind = True
        End If
    End Sub

End Module
