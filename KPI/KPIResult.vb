Public Class KPIResult

    Public CHART_CONTROL As DevExpress.XtraCharts.ChartControl
    Public KPI_DETAIL As New KPIDetail
    Public SelectedDataDt As New DataTable
    Public SelectionListing As String = ""
    Public FKeyPeriod As String = ""
    Public RangeFrom As Object = Nothing
    Public RangeTo As Object = Nothing

    Dim bKPIHasInvalidColumns As Boolean = False

    Sub New(ByRef _chartcontrol As DevExpress.XtraCharts.ChartControl, _kpidetail As KPIDetail, _selectedDataDt As DataTable, _selectionListing As String, _fkeyPeriod As String, _rangefrom As Object, _rangeto As Object)
        CHART_CONTROL = _chartcontrol
        KPI_DETAIL = _kpidetail
        SelectedDataDt = _selectedDataDt
        SelectionListing = _selectionListing
        FKeyPeriod = _fkeyPeriod
        RangeFrom = _rangefrom
        RangeTo = _rangeto
    End Sub

    Public Sub Generate(Optional ShowErrorMessage As Boolean = True)
        If IsNothing(CHART_CONTROL) Then Exit Sub

        ClearChart(CHART_CONTROL)

        '################################################################################################################################################################################################
        'IF KPI DETAIL CLASS IS NOT SET, EXIT
        If KPI_DETAIL Is Nothing Then Exit Sub
        If KPI_DETAIL.KPICode.Length = 0 Then Exit Sub

        Try
            '################################################
            '############# SET CHART APPEARANCE #############
            '################################################
            SetChartColorPalette(CHART_CONTROL, KPI_DETAIL.ColorPalette)

            '################################################
            '######## ADD CHART MAIN AND SUB TITLES #########
            '################################################
            '################################################################################################################################################################################################
            'MAIN TITLE
            'validates if kpi title is entered
            If KPI_DETAIL.Title.MainTitle.Length > 0 Then
                AddChartTitle(CHART_CONTROL, KPI_DETAIL.Title.MainTitle, , 20.0, System.Drawing.FontStyle.Bold, , 0, , , True)
            End If

            '################################################################################################################################################################################################
            ''CHECK IF KPI Detail HAS A STORED PROCEDURE
            If KPI_DETAIL.StoredProcedureName.ToString.Length = 0 Then
                AddChartTitle(CHART_CONTROL, "This KPI is not yet available.", , 30.0, System.Drawing.FontStyle.Bold, System.Drawing.Color.Red, 0, , , True)
                Exit Sub
                'EXITS IF NONE
            End If

PROCEED_GENERATE_CHART:

            '################################################################################################################################################################################################
            '################################################
            '############# CREATE SUB TITLES ################
            '################################################

            '################################################################################################################################################################################################
            'Period title
            If Not IsNothing(KPI_DETAIL.DateCoverage.Period._From) And Not IsNothing(KPI_DETAIL.DateCoverage.Period._To) And KPI_DETAIL.NeedDateCoverage Then
                'IF NEEDS DATE COVERAE AND DATE FROM AND TO ARE PROVIDED
                If KPI_DETAIL.DateCoverage.Period._From.ToString.Length > 0 And KPI_DETAIL.DateCoverage.Period._To.ToString.Length > 0 Then
                    AddChartTitle(CHART_CONTROL, GetToFromAndToText(), , 10.0, System.Drawing.FontStyle.Italic, , 0)
                End If
            Else
                'IF NO DATE COVERAGE IS PROVIDED
                AddChartTitle(CHART_CONTROL, "as of " & Format(DateTime.Now, "dd-MMM-yyyy"), , 10.0, System.Drawing.FontStyle.Italic, , 0)
            End If

            '################################################################################################################################################################################################
            'Subtitle (MinReq and Target / Subtitle defined in the database
            If KPI_DETAIL.SubTitleToDisplay.Length > 0 Then
                AddChartTitle(CHART_CONTROL, KPI_DETAIL.SubTitleToDisplay, , 14.0, System.Drawing.FontStyle.Italic, System.Drawing.Color.Red, 0, , , True)
            End If

            '################################################################################################################################################################################################
            'Filter/Condition Description
            Dim cCondition As String = KPI_DETAIL.FilterOption.GetConditionDescForKPI()
            If cCondition.Length > 0 Then
                AddChartTitle(CHART_CONTROL, cCondition, "Calibri", 10.0, , , 0)
            End If

            '################################################################################################################################################################################################
            'Footer Note
            If KPI_DETAIL.Title.FooterNote.Length > 0 Then
                AddChartTitle(CHART_CONTROL, KPI_DETAIL.Title.FooterNote, , 10.0, System.Drawing.FontStyle.Italic, System.Drawing.Color.Maroon, 0, , DevExpress.XtraCharts.ChartTitleDockStyle.Bottom)
            End If

            '################################################################################################################################################################################################
            '################################################
            '################# ADD SERIES ###################
            '################################################
            If SelectedDataDt.Rows.Count = 0 Then
                AddChartTitle(CHART_CONTROL, "No data to generate.", , 30.0, System.Drawing.FontStyle.Bold, System.Drawing.Color.Red, , , , True)
                Exit Sub

            Else
                AddSeriesToChartControl()
                If bKPIHasInvalidColumns Then
                    CHART_CONTROL.Series.Clear()
                    AddChartTitle(CHART_CONTROL, "Query has invalid columns.", , 30.0, System.Drawing.FontStyle.Bold, System.Drawing.Color.Red, , , , True)
                    If ShowErrorMessage Then MsgBox("Unable to generate chart because the KPI query returned invalid columns." & vbNewLine & "(Columns 'LegendText' or 'Value' may not exist.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

            End If

            '################################################################################################################################################################################################
            '################################################
            '############# ADD DIAGRAM LABELS ###############
            '################################################
            If KPI_DETAIL.ChartView <> KPI.ChartView.SimplePie Then
                Dim oDiagram As DevExpress.XtraCharts.XYDiagram = CType(CHART_CONTROL.Diagram, DevExpress.XtraCharts.XYDiagram)
                If Not oDiagram Is Nothing Then
                    '-- Axix X
                    If KPI_DETAIL.AxisLabel.AxisXLabel.Length > 0 Then
                        oDiagram.AxisX.Title.Text = KPI_DETAIL.AxisLabel.AxisXLabel
                        oDiagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.[True]
                        oDiagram.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.[True]
                        oDiagram.AxisX.VisibleInPanesSerializable = "-1"
                        oDiagram.AxisX.Title.Antialiasing = True
                        oDiagram.AxisX.Title.TextColor = System.Drawing.Color.Blue
                    End If
                    '-- Axix Y
                    If KPI_DETAIL.AxisLabel.AxisYLabel.Length > 0 Then
                        oDiagram.AxisY.Title.Text = KPI_DETAIL.AxisLabel.AxisYLabel
                        oDiagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.[True]
                        oDiagram.AxisY.VisibleInPanesSerializable = "-1"
                        oDiagram.AxisY.Title.Antialiasing = True
                        oDiagram.AxisY.Title.TextColor = System.Drawing.Color.Blue
                    End If
                    '################################################################################################################################################################################################
                End If
            End If

            '################################################
            '############### FINALIZE CHART #################
            '################################################
            If CHART_CONTROL.Series.Count = 0 Then
                AddChartTitle(CHART_CONTROL, "Result has no data.", , 30.0, System.Drawing.FontStyle.Bold, System.Drawing.Color.Red)
            Else
                If KPI_DETAIL.ChartView = KPI.ChartView.SimplePie Then
                    CHART_CONTROL.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
                Else
                    CHART_CONTROL.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True
                End If
            End If


        Catch ex As Exception
            ClearChart(CHART_CONTROL)
            If ShowErrorMessage Then MsgBox("Unable to generate chart." & Chr(13) & Chr(13) & "Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Sub AddSeriesToChartControl()
        Dim cDateCoverage As String = ""
        Dim dtResult As New DataTable

        Dim SQL_DEBUG As String = ""    'USE THIS STRING IN SQL SERVER TO RUN/DEBUG THE STORED PROC EXECUTION

        If KPI_DETAIL.NeedDateCoverage Then
            If Not IsNothing(KPI_DETAIL.DateCoverage.Period._From) And Not IsNothing(KPI_DETAIL.DateCoverage.Period._To) Then
                cDateCoverage = ", " & RangeFrom.ToString & ", " & RangeTo.ToString
                'cDateCoverage = ", " & KPI_DETAIL.DateCoverage.Period._From.ToString & ", " & KPI_DETAIL.DateCoverage.Period._To.ToString
            Else
                cDateCoverage = ", DEFAULT, DEFAULT"
            End If
        End If

        CreateDebugSQL(SQL_DEBUG) 'UNCOMMENT THIS LINE OF CODE HERE IF YOU WANT TO TEST YOUR SP IN SQL SERVER
        Debug.Print("OUTPUT FROM: KPIResult.AddSeriesToChartControl")
        Debug.Print(SQL_DEBUG)

        GenerateKPIResult(dtResult)

        '################################################################################################################################################################################################
        If dtResult Is Nothing Then
            'NO SERIES TO CREATE

        Else
            If dtResult.Rows.Count > 0 Then
                If Not dtResult.Columns.Contains("LegendText") Or Not dtResult.Columns.Contains("Value") Then
                    bKPIHasInvalidColumns = True
                    Exit Sub
                Else
                    bKPIHasInvalidColumns = False
                End If

                Dim dv As New DataView(dtResult)
                Dim dtSeriesLegend As DataTable = TryCast(dv, DataView).ToTable(True, New String() {"LegendText"})

                For i As Integer = 0 To dtSeriesLegend.Rows.Count - 1

                    Try
                        Dim SeriesDataSource As DataTable = dtResult.Clone
                        Dim cLegendText As String = dtSeriesLegend.Rows(i).Item("LegendText").ToString
                        cLegendText = cLegendText.Replace("'", "''")
                        Dim cCondition As String = "LegendText = '" & cLegendText & "'"

                        Dim dr As DataRow() = dtResult.Select(cCondition)
                        For Each row As DataRow In dr
                            SeriesDataSource.ImportRow(row)
                        Next

                        Dim ValueSum As Object
                        ValueSum = SeriesDataSource.Compute("Sum(Value)", "")

                        If KPI_DETAIL.ChartView = KPI.ChartView.SimplePie And ValueSum = 0 Then GoTo NEXT_SERIES

                        Dim tmpSeries As New DevExpress.XtraCharts.Series
                        tmpSeries = CreateKPISeries(KPI_DETAIL, cLegendText, SeriesDataSource)

                        If Not IsNothing(tmpSeries) Then
                            CHART_CONTROL.Series.Add(tmpSeries)
                        End If

                    Catch ex As Exception
                        LogErrors("Failed to generate series for [" & dtSeriesLegend.Rows(i).Item("LegendText").ToString & "]")
                    End Try
NEXT_SERIES:
                Next


            End If
        End If
    End Sub

    Private Sub GenerateKPIResult(ByRef dtResult As DataTable)
        Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(MPSDB.GetConnectionString())
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Dim da As New System.Data.SqlClient.SqlDataAdapter

        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandText = "KPIGenerateResult"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@KPICode", KPI_DETAIL.KPICode)
                    .AddWithValue("@PrintSelection", SelectedDataDt)
                    .AddWithValue("@SelectionListing", SelectionListing)
                    .AddWithValue("@FKeyPeriod", FKeyPeriod)
                    .AddWithValue("@minDate", ChangeRangeToDate(FKeyPeriod, RangeFrom, DayOfTheMonth.First, MonthOfQuarter.First, MonthOfTheYear.First))
                    .AddWithValue("@maxDate", ChangeRangeToDate(FKeyPeriod, RangeTo, DayOfTheMonth.Last, MonthOfQuarter.Last, MonthOfTheYear.Last))
                    '.AddWithValue("@AddlCondition", KPI_DETAIL.DataSourceCondition.Replace("'", "''"))
                    .AddWithValue("@AddlCondition", KPI_DETAIL.DataSourceCondition)
                End With
                Dim d As New DataTable
                da.SelectCommand = cmd
                da.Fill(dtResult)
            End Using

        Catch ex As Exception
            sqlConn.Close()

        Finally
            sqlConn.Close()
        End Try

    End Sub

    Sub CreateDebugSQL(ByRef cSQL As String)
        Dim sql As New System.Text.StringBuilder

        sql.Append("DECLARE @PrintSelection [dbo].[PrintSelection] ")
        For i As Integer = 0 To SelectedDataDt.Rows.Count - 1
            If i = 0 Then
                sql.AppendLine("INSERT INTO @PrintSelection VALUES")
            End If

            sql.AppendLine(IIf(i > 0, ", ", "") & _
                           "('" & IfNull(SelectedDataDt.Rows(i)("PKey"), "").ToString & "')")

        Next

        sql.AppendLine("DECLARE @KPICode varchar(15) = '" & KPI_DETAIL.KPICode & "'")
        sql.AppendLine("DECLARE @SelectionListing varchar(30) = '" & SelectionListing & "'")
        sql.AppendLine("DECLARE @FKeyPeriod varchar(30) = '" & FKeyPeriod & "'")
        sql.AppendLine("DECLARE @minDate date = " & ChangeToSQLDate(ChangeRangeToDate(FKeyPeriod, RangeFrom, DayOfTheMonth.First, MonthOfQuarter.First, MonthOfTheYear.First)))
        sql.AppendLine("DECLARE @maxDate date = " & ChangeToSQLDate(ChangeRangeToDate(FKeyPeriod, RangeTo, DayOfTheMonth.Last, MonthOfQuarter.Last, MonthOfTheYear.Last)))
        sql.AppendLine("DECLARE @AddlCondition varchar(max) = '" & KPI_DETAIL.DataSourceCondition.Replace("'", "''") & "'")

        sql.AppendLine("EXEC dbo.KPIGenerateResult ")
        sql.AppendLine("@KPICode ")
        sql.AppendLine(",@PrintSelection ")
        sql.AppendLine(",@SelectionListing ")
        sql.AppendLine(",@FKeyPeriod ")
        sql.AppendLine(",@minDate ")
        sql.AppendLine(",@maxDate ")
        sql.AppendLine(",@AddlCondition ")

        cSQL = sql.ToString
    End Sub

    Function CreateKPISeries(ByVal oKPIDetail As KPIDetail, ByVal cLegendText As String, ByVal SeriesDataSource As DataTable) As DevExpress.XtraCharts.Series
        Dim tmpSeries As DevExpress.XtraCharts.Series = Nothing

        tmpSeries = New DevExpress.XtraCharts.Series(cLegendText, DevExpress.XtraCharts.ViewType.Bar)

        tmpSeries.DataSource = SeriesDataSource
        SetSeriesView(tmpSeries, oKPIDetail.ChartView, cLegendText, oKPIDetail.UsePercentInPieChartView)

        Return tmpSeries
    End Function

    Sub SetSeriesView(ByRef oSeries As DevExpress.XtraCharts.Series, ByVal ChartView As KPI.ChartView, ByVal LegendText As String, Optional bUsePercentInPieChartView As Boolean = False)
        ' Specify data members to bind the series.
        oSeries.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Auto
        oSeries.ArgumentDataMember = "Argument"
        oSeries.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        oSeries.ValueDataMembers.AddRange(New String() {"Value"})
        oSeries.LegendText = LegendText
        oSeries.Name = LegendText
        oSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True

        ''CUSTOMIZE VIEW - ESPECIALLY IF PIE CHART VIEW
        If ChartView = KPI.ChartView.SimplePie Then
            'IF PIE CHART

            ''Series Title (Caption that appears below the chart)
            Dim oPieSeriesView As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView()
            Dim oSeriesTitle As DevExpress.XtraCharts.SeriesTitle = New DevExpress.XtraCharts.SeriesTitle()
            oSeriesTitle.Text = oSeries.Name
            oSeriesTitle.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom
            oPieSeriesView.Titles.AddRange(New DevExpress.XtraCharts.SeriesTitle() {oSeriesTitle})
            oSeries.View = oPieSeriesView

            '    oSeries.Label.TextPattern = "{A} : {V}"
            'End If
            oSeries.Label.TextPattern = "{A} : {V}"
        Else
            'IF NOT PIE CHART
            oSeries.View = getChartViewType(ChartView)

            'text pattern
            oSeries.LegendTextPattern = "{V}"
            oSeries.Label.TextPattern = "{V}"
        End If


    End Sub

    Function GetToFromAndToText() As String
        Dim ReturnValue As String = ""

        Try
            Select Case FKeyPeriod
                Case KPIPeriodCode.Monthly
                    ReturnValue = "from " & Format(NumCodeToDate(RangeFrom, 1), "MMM-yyyy") & " to " & Format(NumCodeToDate(RangeTo, 1), "MMM-yyyy")
                Case KPIPeriodCode.Quarterly
                    ReturnValue = "from " & QCodeToQDesc(RangeFrom) & " to " & QCodeToQDesc(RangeTo)
                Case KPIPeriodCode.Annually
                    ReturnValue = "from " & RangeFrom & " to " & RangeTo
            End Select

        Catch ex As Exception

        End Try

        Return ReturnValue
    End Function

    Function ChangeRangeToDate(FKeyPeriod As String, RangeValue As Object, Optional DayOfTheMonth As DayOfTheMonth = KPIResult.DayOfTheMonth.First, Optional MonthOfQuarter_IfQuarterly As MonthOfQuarter = MonthOfQuarter.First, Optional MonthOfTheYear_IfAnnually As MonthOfTheYear = MonthOfTheYear.First) As Date
        Dim ReturnValue As Date = Nothing

        If Not RangeValue Is Nothing Then
            Try
                Select Case FKeyPeriod
                    Case KPIPeriodCode.Monthly
                        Dim nDay As Integer
                        If DayOfTheMonth = KPIResult.DayOfTheMonth.First Then
                            nDay = 1
                        Else
                            nDay = GetDaysOfMonth(NumCodeToDate(RangeValue, 1))
                        End If

                        Return NumCodeToDate(RangeValue, nDay)

                    Case KPIPeriodCode.Quarterly
                        Dim nDay As Integer
                        If DayOfTheMonth = KPIResult.DayOfTheMonth.First Then
                            nDay = 1
                        Else
                            nDay = GetDaysOfMonth(QCodeToDate(RangeValue, MonthOfQuarter_IfQuarterly, 1))
                        End If

                        Return QCodeToDate(RangeValue, MonthOfQuarter_IfQuarterly, nDay)

                    Case KPIPeriodCode.Annually
                        Dim nDay As Integer
                        If DayOfTheMonth = KPIResult.DayOfTheMonth.First Then
                            nDay = 1
                        Else
                            nDay = GetDaysOfMonth(DateSerial(RangeValue, IIf(MonthOfTheYear_IfAnnually = MonthOfTheYear.First, 1, IIf(MonthOfTheYear_IfAnnually = MonthOfTheYear.Last, 12, MonthOfTheYear_IfAnnually)), 1))
                        End If

                        Return DateSerial(RangeValue, IIf(MonthOfTheYear_IfAnnually = MonthOfTheYear.First, 1, IIf(MonthOfTheYear_IfAnnually = MonthOfTheYear.Last, 12, MonthOfTheYear_IfAnnually)), nDay)

                End Select

            Catch ex As Exception

            End Try
        End If

        Return ReturnValue
    End Function

    Public Enum MonthOfTheYear
        First = 1
        Last = 2
    End Enum

    Public Enum DayOfTheMonth
        First = 1
        Last = 2
    End Enum

End Class
