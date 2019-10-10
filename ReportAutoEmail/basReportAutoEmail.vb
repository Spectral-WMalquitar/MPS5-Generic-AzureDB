Imports Reports
Imports KPI
Imports Utilities
Imports System.Net.Mail
Imports System.Security.AccessControl

Module basReportAutoEmail

#Region "Template-Related"
    'NOTE: THE ITEMS ON THIS REGION ARE USED FOR AUTO_EMAIL REPORT FEATURE ONLY AND IS NOT USED BY ANY OTHER FEATURE\

    '####################################################################################################################################################################################################################################
    'This structure is used as field names from the datatable parameter used by the 
    '   AutoEmailReport class that is passed to GenerateReportFromTemplate function
    '   which generates the reports from the templates
    Private Structure UserEmailReportFields
        Const PKey As String = "PKey"
        Const TemplatePKey As String = "FKeyOptTemplate"
        Const LastDateFrom As String = "LastDateFrom"
        Const LastDateTo As String = "LastDateTo"
    End Structure

    Public Function GenerateReportFromTemplate(TemplatePKey As String, Optional ShowMessage As Boolean = True) As DevExpress.XtraReports.UI.XtraReport
        '####################################################################################################################################################################################################################################
        '## DESCRIPTION:    This generates a report from a selected Template
        '                   The selected template is passed to this function thru the TemplatePKey string parameter
        '                       which is the template's pkey from the MSysTblRepOptTemplate table

        Dim ReturnValue As New DevExpress.XtraReports.UI.XtraReport
        ReturnValue = Nothing

        Try
            '####################################################################################################################################################################################################################################
            'Creates a Report Tempate Detail object
            '   The Report Template Detail contains information about the template such as name, caption, content and connected report's info
            Dim TemplateDetails As New ReportTemplateDetail(TemplatePKey)

            '####################################################################################################################################################################################################################################
            If IsNothing(TemplateDetails) Then
                If ShowMessage Then MsgBox("Unable to load template.", MsgBoxStyle.Exclamation)
                GoTo RETURN_AND_EXIT
            End If

            '####################################################################################################################################################################################################################################
            'Creates the report object based on the Report Template Detail
            Return CreateReportFromTemplateDetail(TemplateDetails)

        Catch ex As Exception
            MsgBox("Unable to generate report from the selected template", MsgBoxStyle.Exclamation)
        End Try

RETURN_AND_EXIT:

        Return ReturnValue

    End Function

    Public Function GenerateReportFromTemplate(TemplatesDT As DataTable, Optional ShowMessage As Boolean = False) As List(Of DevExpress.XtraReports.UI.XtraReport)
        '####################################################################################################################################################################################################################################
        '## DESCRIPTION:    This generates a list of report objects from a selected Template
        '                   The selected template is passed to this function thru the TemplatesDT datatable parameter
        '                       which should contain fields found from the structure UserEmailReportFields
        '                   The TemplatesDT datatable is the list of templates selected by a user thru the Email Profile

        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Dim dt As DataTable = MPSDB.CreateTable("SELECT * FROM dbo.tblUserEmailProfileReports WHERE FKeyEmailProfile = 'SPECT0000000009'")
        'Dim repList As List(Of DevExpress.XtraReports.UI.XtraReport)

        'repList = GenerateReportFromTemplate(dt)

        'For Each rep As DevExpress.XtraReports.UI.XtraReport In repList
        '    If Not IsNothing(rep) Then rep.ShowPreviewDialog()
        'Next
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Dim errMsg As String
        Dim ReturnValue As New List(Of DevExpress.XtraReports.UI.XtraReport)

        Dim TemplateDetails As ReportTemplateDetail = Nothing

        If TemplatesDT.Columns.Contains(UserEmailReportFields.TemplatePKey) Then
            Try
                '####################################################################################################################################################################################################################################
                'Loop through each template
                For Each dr As DataRow In TemplatesDT.Rows
                    Try
                        '####################################################################################################################################################################################################################################
                        'Create a Report Template Detail object
                        TemplateDetails = New ReportTemplateDetail(dr(UserEmailReportFields.TemplatePKey).ToString)

                        If IsNothing(TemplateDetails) Then
                            errMsg = "Unable to load template."
                            LogErrors(errMsg)
                            If ShowMessage Then MsgBox(errMsg, MsgBoxStyle.Exclamation)
                            GoTo RETURN_AND_EXIT
                        End If

                        '####################################################################################################################################################################################################################################
                        'Create the Email Auto Report Profile object
                        '   this contains details of the Auto Email Profile such as key and date range
                        Dim oEmailAutoReportProfile As New EmailAutoReportProfile

                        '####################################################################################################################################################################################################################################
                        oEmailAutoReportProfile.PKey = dr(UserEmailReportFields.PKey).ToString
                        If Not IsNothing(dr(UserEmailReportFields.LastDateFrom)) Then
                            If IsDate(dr(UserEmailReportFields.LastDateFrom)) Then oEmailAutoReportProfile.DatesCovered.Values._From = dr(UserEmailReportFields.LastDateFrom)
                        End If
                        If Not IsNothing(dr(UserEmailReportFields.LastDateTo)) Then
                            If IsDate(dr(UserEmailReportFields.LastDateTo)) Then oEmailAutoReportProfile.DatesCovered.Values._To = dr(UserEmailReportFields.LastDateTo)
                        End If
                        oEmailAutoReportProfile.TemplatePKey = dr(UserEmailReportFields.TemplatePKey).ToString
                        '####################################################################################################################################################################################################################################

                        '####################################################################################################################################################################################################################################
                        'Create Report From Template Detail
                        ReturnValue.Add(CreateReportFromTemplateDetail(TemplateDetails, oEmailAutoReportProfile))
                    Catch ex As Exception
                        If Not IsNothing(TemplateDetails) Then
                            LogErrors("basReportAutoEmail : Failed to create report from template [" & TemplateDetails.PKey & " - " & TemplateDetails.Name & "]")
                        Else
                            LogErrors("basReportAutoEmail : Failed to create report template object with key [" & dr(UserEmailReportFields.TemplatePKey).ToString & "]")
                        End If
                    End Try
                Next

            Catch ex As Exception
                LogErrors("basReportAutoEmail : Unable to generate report from the selected template")
            End Try

        End If

RETURN_AND_EXIT:

        Return ReturnValue

    End Function

    Private Function CreateReportFromTemplateDetail(oTemplateDetail As ReportTemplateDetail, Optional ShowMessage As Boolean = True) As DevExpress.XtraReports.UI.XtraReport
        '####################################################################################################################################################################################################################################
        '## DESCRIPTION :   This creates the report/kpi object based on a Report Template Detail parameter

        '####################################################################################################################################################################################################################################
        Dim ReturnValue As DevExpress.XtraReports.UI.XtraReport = Nothing

        '####################################################################################################################################################################################################################################
        If oTemplateDetail.ReportObject.Group = "KPI" Then
            '####################################################################################################################################################################################################################################
            'KPI Report
            Dim oChartControl As New DevExpress.XtraCharts.ChartControl

            '####################################################################################################################################################################################################################################
            'Creates a KPI Detail objects which contains detail about the KPI, such as, key, name, chartview, date from, date to, color palette, etc.
            Dim oKPIDetail As KPIDetail = GenerateKPIDetailFromTemplate(oTemplateDetail.PKey)

            '####################################################################################################################################################################################################################################
            'Generates the chart
            'GenerateChart(oChartControl, oKPIDetail, GetSelectionAsArrayListFromTemplate(oTemplateDetail.PKey, oKPIDetail))
            Dim result As New KPIResult(oChartControl, oKPIDetail, GetSelectionAsDTFromTemplate(oTemplateDetail.PKey, oKPIDetail), oKPIDetail.SelectionListing, oKPIDetail.Period, oKPIDetail.DateCoverage.Period._From, oKPIDetail.DateCoverage.Period._To)

            '####################################################################################################################################################################################################################################
            If IsNothing(oChartControl) Then
                If ShowMessage Then MsgBox("Unable to locate associated report to this template.", MsgBoxStyle.Exclamation)
                Return Nothing
            Else
                '####################################################################################################################################################################################################################################
                'Creates a report object where the generated chart will be placed.
                Dim KPIReport As clsRptKPI = New clsRptKPI(oChartControl)
                If Not IsNothing(KPIReport) Then
                    ReturnValue = KPIReport.ReportObject

                    If oKPIDetail.Name.Length > 0 Then ReturnValue.Name = oKPIDetail.Name
                End If

            End If

        Else
            '####################################################################################################################################################################################################################################
            'Regular Report

            '####################################################################################################################################################################################################################################
            'Creates a Report Info object. This contains information about the report such as its fields from the MSystblReports table
            Dim ReportInfo As New ReportInfo(oTemplateDetail.ReportObject.ObjectID, oTemplateDetail.ReportObject.Group)                    'information about what the report is

            '####################################################################################################################################################################################################################################
            If IsNothing(ReportInfo) Then
                If ShowMessage Then MsgBox("Unable to locate associated report to this template.", MsgBoxStyle.Exclamation)
                Return Nothing
            Else
                '####################################################################################################################################################################################################################################
                'Creates a ReportDetail object based on the ReportInfo
                '   The ReportDetails contains details about the report to be generated such as filtering, sorting, condition, output format, etc.
                Dim ReportDetail As ReportDetail = CreateReportDetailFromTemplate(ReportInfo, oTemplateDetail)
                ReportDetail.Output.Mode = ReportOutputMode.None    'Set to none because this will be create a list object with a list of all reports associated to the selected template

                '####################################################################################################################################################################################################################################
                'Build the report
                BuildReport(ReportDetail)

                '####################################################################################################################################################################################################################################
                If Not IsNothing(ReportDetail.MainReport) Then
                    ReturnValue = ReportDetail.MainReport

                    If ReportDetail.ReportObjectID.Length > 0 Then ReturnValue.Name = ReportDetail.ReportObjectID
                End If
            End If

            '####################################################################################################################################################################################################################################
        End If

        Return ReturnValue
    End Function

    Private Function CreateReportFromTemplateDetail(oTemplateDetail As ReportTemplateDetail, oEmailAutoReportProfile As EmailAutoReportProfile, Optional ShowMessage As Boolean = False) As DevExpress.XtraReports.UI.XtraReport
        '####################################################################################################################################################################################################################################
        '## DESCRIPTION :   This creates the report/kpi object based on a Report Template Detail parameter
        '                   which may contain date coverage criteria based on the Email Profile

        '####################################################################################################################################################################################################################################
        Dim ReturnValue As DevExpress.XtraReports.UI.XtraReport = Nothing

        If oTemplateDetail.ReportObject.Group = "KPI" Then
            '####################################################################################################################################################################################################################################
            'KPI
            ReturnValue = CreateKPIObjectFromTemplateDetail(oTemplateDetail, oEmailAutoReportProfile, ShowMessage)

        Else
            '####################################################################################################################################################################################################################################
            'Regular Report
            ReturnValue = CreateReportObjectFromTemplateDetail(oTemplateDetail, oEmailAutoReportProfile, ShowMessage)

        End If

        Return ReturnValue
    End Function

    Private Function CreateKPIObjectFromTemplateDetail(ByRef oTemplateDetail As ReportTemplateDetail, ByRef oEmailAutoReportProfile As EmailAutoReportProfile, Optional ShowMessage As Boolean = False) As DevExpress.XtraReports.UI.XtraReport
        '####################################################################################################################################################################################################################################
        '## DESCRIPTION :   Creates the KPI Object from the Template Detail

        '####################################################################################################################################################################################################################################
        Dim ReturnValue As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim oDateCoverage As New KPI.KPIDetail.DateCoverageClass

        '####################################################################################################################################################################################################################################

        Dim oChartControl As New DevExpress.XtraCharts.ChartControl
        Dim oKPIDetail As KPIDetail = GenerateKPIDetailFromTemplate(oTemplateDetail.PKey)

        If IsNothing(oKPIDetail) Then
            Return ReturnValue
            Exit Function
        End If

        Try
            If oKPIDetail.NeedDateCoverage Then
                Select Case oKPIDetail.Period
                    Case KPIPeriodCode.Monthly
                        If oKPIDetail.DateCoverage.Type = KPIDateCoverageType.FromAndTo Then
                            oKPIDetail.DateCoverage.Period._From = DateToNumCode(oEmailAutoReportProfile.DatesCovered.Values._From)
                            oKPIDetail.DateCoverage.Period._To = DateToNumCode(oEmailAutoReportProfile.DatesCovered.Values._To)
                        ElseIf oKPIDetail.DateCoverage.Type = KPIDateCoverageType.DateAsOf Then
                            oKPIDetail.DateCoverage.DateAsOf = oEmailAutoReportProfile.DatesCovered.Values._To
                        End If


                    Case KPIPeriodCode.Quarterly
                        If oKPIDetail.DateCoverage.Type = KPIDateCoverageType.FromAndTo Then
                            oKPIDetail.DateCoverage.Period._From = DateToQCode(oEmailAutoReportProfile.DatesCovered.Values._From)
                            oKPIDetail.DateCoverage.Period._To = DateToQCode(oEmailAutoReportProfile.DatesCovered.Values._To)
                        ElseIf oKPIDetail.DateCoverage.Type = KPIDateCoverageType.DateAsOf Then
                            oKPIDetail.DateCoverage.DateAsOf = oEmailAutoReportProfile.DatesCovered.Values._To
                        End If

                    Case KPIPeriodCode.Overall
                        If oKPIDetail.DateCoverage.Type = KPIDateCoverageType.DateAsOf Then
                            oKPIDetail.DateCoverage.DateAsOf = oEmailAutoReportProfile.DatesCovered.Values._To
                        End If

                End Select
            End If

            Dim kpiresult As New KPIResult(oChartControl, oKPIDetail, GetSelectionAsDTFromTemplate(oTemplateDetail.PKey, oKPIDetail), oKPIDetail.Result.SelectionListing, oKPIDetail.Result.DateCoverageType, oEmailAutoReportProfile.DatesCovered.Values._From, oEmailAutoReportProfile.DatesCovered.Values._To)
            'Dim kpiresult As New KPIResult(oChartControl, oKPIDetail, New DataTable("Test"), "SelectionListing", "FKeyPeriod", "RangeFrom", "RangeTo")
            'GenerateChart(oChartControl, oKPIDetail, GetSelectionAsArrayListFromTemplate(oTemplateDetail.PKey, oKPIDetail), False)

            If IsNothing(oChartControl) Then
                If ShowMessage Then MsgBox("Unable to locate associated report to this template.", MsgBoxStyle.Exclamation)
            Else
                Dim KPIReport As clsRptKPI = New clsRptKPI(oChartControl)
                If Not IsNothing(KPIReport) Then
                    ReturnValue = KPIReport.ReportObject

                    If oKPIDetail.Name.Length > 0 Then ReturnValue.Name = oKPIDetail.Name
                End If

            End If
        Catch ex As Exception
            LogErrors("[Auto Email Report Generator] Failed to create kpi object from Template Detail with Key '" & oTemplateDetail.PKey & "'")
        End Try

        Return ReturnValue
    End Function

    Private Function CreateReportObjectFromTemplateDetail(ByRef oTemplateDetail As ReportTemplateDetail, ByRef oEmailAutoReportProfile As EmailAutoReportProfile, Optional ShowMessage As Boolean = False) As DevExpress.XtraReports.UI.XtraReport
        '####################################################################################################################################################################################################################################
        '## DESCRIPTION :   Creates the Report Object from the Template Detail

        Dim ReturnValue As DevExpress.XtraReports.UI.XtraReport = Nothing

        Dim ReportDetail As ReportDetail

        Try
            Dim tmpReportInfo As New ReportInfo(oTemplateDetail.ReportObject.ObjectID, oTemplateDetail.ReportObject.Group)                    'information about what the report is
            If IsNothing(tmpReportInfo) Then
                If ShowMessage Then MsgBox("Unable to locate associated report to this template.", MsgBoxStyle.Exclamation)
                Return Nothing
            Else
                ReportDetail = CreateReportDetailFromTemplate(tmpReportInfo, oTemplateDetail)

                With ReportDetail
                    .Output.Mode = ReportOutputMode.None    'Set to none because this will be create a list object with a list of all reports associated to the selected template
                    .ShowMsgBox = False
                    With .AutoEmail
                        .Enabled = True
                        '.DateRange.Fields._From = tmpReportInfo.DateRangeFields._From
                        '.DateRange.Fields._To = tmpReportInfo.DateRangeFields._To
                        .DateRange.Values._From = oEmailAutoReportProfile.DatesCovered.Values._From
                        .DateRange.Values._To = oEmailAutoReportProfile.DatesCovered.Values._To
                    End With
                    '.InitExcemptFields("DATERANGE_AUTOEMAIL")

                    'With .AutoEmail
                    '    If .hasDateRangeFields() Then
                    '        .Condition = oEmailAutoReportProfile.GenerateDateRangeCondition(.DateRange.Fields._From, .DateRange.Fields._To)
                    '        .ConditionTitle = changeDateRangeToSubTitle(.DateRange.Values._From, .DateRange.Values._To)
                    '    End If
                    'End With

                    BuildReport(ReportDetail)
                    If Not IsNothing(.MainReport) Then
                        ReturnValue = .MainReport

                        If .ReportObjectID.Length > 0 Then ReturnValue.Name = .ReportObjectID
                    End If
                End With

            End If

        Catch ex As Exception
            LogErrors("[Auto Email Report Generator] Failed to create report object from Template Detail with Key '" & oTemplateDetail.PKey & "'")
        End Try

        Return ReturnValue
    End Function

    Private Class EmailAutoReportProfile
        Public PKey As String
        Public TemplatePKey As String
        Public DatesCovered As New DateRangeClass
        Public ExecutionType As KPI.KPIPeriodCode
        Public Interval As IntervalClass

        Public Class IntervalClass
            Public Sunday As Boolean = False
            Public Monday As Boolean = False
            Public Tuesday As Boolean = False
            Public Wednesday As Boolean = False
            Public Thursday As Boolean = False
            Public Friday As Boolean = False
            Public Saturday As Boolean = False
        End Class

        Public Sub UpdateInterval(cInterval As String)
            Dim arrInterval() As String

            arrInterval = cInterval.Split(";")
            Interval.Sunday = arrInterval.Contains("1")
            Interval.Monday = arrInterval.Contains("2")
            Interval.Tuesday = arrInterval.Contains("3")
            Interval.Wednesday = arrInterval.Contains("4")
            Interval.Thursday = arrInterval.Contains("5")
            Interval.Friday = arrInterval.Contains("6")
            Interval.Saturday = arrInterval.Contains("7")

        End Sub

        Public Function GenerateDateRangeCondition(Optional FromFieldName As String = "", Optional ToFieldName As String = "") As String
            Dim ReturnValue As String = ""

            'Starting Range
            If Not IsNothing(DatesCovered.Values._From) Then
                If IsDate(DatesCovered.Values._From) Then
                    If FromFieldName.Length > 0 Then
                        ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " AND ", "") & FromFieldName & " >= " & ChangeToSQLDate(CDate(DatesCovered.Values._From))
                    End If
                End If
            End If

            'Ending Range
            If Not IsNothing(DatesCovered.Values._To) Then
                If IsDate(DatesCovered.Values._To) Then
                    If ToFieldName.Length > 0 Then
                        ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " AND ", "") & ToFieldName & " >= " & ChangeToSQLDate(CDate(DatesCovered.Values._To))
                    End If
                End If
            End If

            'Return Value
            Return ReturnValue
        End Function
    End Class
#End Region

End Module
