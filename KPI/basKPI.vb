Imports Utilities
Imports System.IO
Imports MPS4

Public Module basKPI

#Region "Declarations"
    Public Const ResultPopupFormTag As String = "KPI RESULT POPUP FORM"
    Private Const MINIMUM_YEAR As Integer = 1980

    Public Enum ResultPopupFormShowMode
        'Open = 1
        CloseAll = 2
        HideAll = 3
        ShowAll = 4
    End Enum

    Public Structure KPIPeriod
        Public Const Annually As String = "Annually"
        Public Const SemiAnnual As String = "Semi-Annual"
        Public Const Quarterly As String = "Quarterly"
        Public Const Monthly As String = "Monthly"
        Public Const Weekly As String = "Weekly"
        Public Const Daily As String = "Daily"
        Public Const Hourly As String = "Hourly"
        Public Const Overall As String = "Overall"
    End Structure

    Public Structure KPIPeriodCode
        Public Const Annually As String = "SYSKPIANNUAL"
        Public Const SemiAnnual As String = "SYSKPISANNUAL"
        Public Const Quarterly As String = "SYSKPIQUARTERLY"
        Public Const Monthly As String = "SYSKPIMONTHLY"
        Public Const Weekly As String = "SYSKPIWEEKLY"
        Public Const Daily As String = "SYSKPIDAILY"
        Public Const Hourly As String = "SYSKPIHOURLY"
        Public Const Overall As String = "SYSKPIOVERALL"
    End Structure

    Public Structure KPIDateCoverageParam
        Public Const PeriodFrom As String = "PeriodFrom"
        Public Const PeriodTo As String = "PeriodTo"
        Public Const DateAsOf As String = "DateAsOf"
    End Structure

    Public Structure KPIDateCoverageType
        Public Const FromAndTo As String = "FROMTO"
        Public Const DateAsOf As String = "DATEASOF"
    End Structure
        
#End Region

    Function changeToFromAndToText(ByVal Period As String, ByVal nFrom As Long, ByVal nTo As Long)
        Dim ReturnValue As String = ""

        Select Case Period
            Case KPIPeriodCode.Monthly
                ReturnValue = "from " & Format(NumCodeToDate(nFrom, 1), "MMM-yyyy") & " to " & Format(NumCodeToDate(nTo, 1), "MMM-yyyy")
            Case KPIPeriodCode.Quarterly
                ReturnValue = "from " & QCodeToQDesc(nFrom) & " to " & QCodeToQDesc(nTo)
            Case KPIPeriodCode.Annually
                ReturnValue = "from " & nFrom & " to " & nTo
        End Select

        Return ReturnValue
    End Function

    Public Sub CreatePopupResult(ByVal oChartControl As DevExpress.XtraCharts.ChartControl, Optional ByVal cResultName As String = "")
        If Not oChartControl Is Nothing Then
            Dim f As New frmResultPopup
            f.Tag = ResultPopupFormTag

            Dim ChartPopup As DevExpress.XtraCharts.ChartControl = CType(oChartControl.Clone, DevExpress.XtraCharts.ChartControl)
            Dim init As System.ComponentModel.ISupportInitialize = CType(ChartPopup, System.ComponentModel.ISupportInitialize)

            init.BeginInit()
            init.EndInit()
            f.PanelControl_Chart.Controls.Add(ChartPopup)
            ChartPopup.Dock = DockStyle.Fill
            ChartPopup.Name = "MainChart"

            If cResultName.Length > 0 Then
                f.Text = "Result: " & cResultName
            End If

            f.TopMost = True
            f.Show()
        End If
    End Sub

    Public Sub ShowKPIResultPopupForms(ByVal Mode As ResultPopupFormShowMode)
        Dim frm As Form

        For Each frm In Application.OpenForms
            If frm.Tag = ResultPopupFormTag Then
                Select Case Mode
                    Case ResultPopupFormShowMode.HideAll
                        frm.Visible = False
                    Case ResultPopupFormShowMode.ShowAll
                        frm.Visible = True
                    Case ResultPopupFormShowMode.CloseAll
                        frm.Close()
                End Select
            End If
        Next
    End Sub

#Region "ChangeChartView"
    Public Function GetKPIChartTable() As DataTable
        Dim ReturnValue As New DataTable

        With ReturnValue
            .Columns.Add("PKey", Type.GetType("System.Int32"))
            .Columns.Add("Name", Type.GetType("System.String"))

            With .Rows
                .Add({KPI.ChartView.SimpleBar, KPI.ChartViewName.Bar})
                .Add({KPI.ChartView.SimpleLine, KPI.ChartViewName.Line})
                .Add({KPI.ChartView.SimpleArea, KPI.ChartViewName.Area})
                .Add({KPI.ChartView.SimplePie, KPI.ChartViewName.Pie})
            End With
            
        End With

        Return ReturnValue
    End Function

    Public Function ChangeChartViewNumToType(nChartView As KPI.ChartView, Optional DefaultReturnValue As Object = Nothing) As Object
        Dim ReturnValue As Object = Nothing
        ReturnValue = getChartViewType(nChartView)

        If IsNothing(ReturnValue) Then
            Return DefaultReturnValue
        Else
            Return ReturnValue
        End If
    End Function

    Public Function ChangeChartViewNumToName(nChartView As KPI.ChartView, Optional DefaultReturnValue As Object = Nothing) As Object
        Dim ReturnValue As String = Nothing
        Select Case IfNull(nChartView, 0)
            Case KPI.ChartView.SimpleBar
                ReturnValue = KPI.ChartViewName.Bar

            Case KPI.ChartView.SimpleLine
                ReturnValue = KPI.ChartViewName.Line

            Case KPI.ChartView.SimpleArea
                ReturnValue = KPI.ChartViewName.Area

            Case KPI.ChartView.SimplePie
                ReturnValue = KPI.ChartViewName.Pie
        End Select

        If IsNothing(ReturnValue) Then
            Return DefaultReturnValue
        Else
            Return ReturnValue
        End If
    End Function

    Public Function ChangeChartViewNameToNum(cChartView As String, Optional DefaultReturnValue As Object = Nothing) As Object
        Dim ReturnValue As KPI.ChartView = 0
        Select Case IfNull(cChartView, "")
            Case KPI.ChartViewName.Bar
                ReturnValue = KPI.ChartView.SimpleBar

            Case KPI.ChartViewName.Line
                ReturnValue = KPI.ChartView.SimpleLine

            Case KPI.ChartViewName.Area
                ReturnValue = KPI.ChartView.SimpleArea

            Case KPI.ChartViewName.Pie
                ReturnValue = KPI.ChartView.SimplePie

        End Select

        If IsNothing(ReturnValue) Then
            Return DefaultReturnValue
        Else
            Return ReturnValue
        End If
    End Function

    Public Function ChangeChartViewNameToType(cChartView As String, Optional DefaultReturnValue As Object = Nothing) As Object
        Dim ReturnValue As Object = Nothing
        Dim nChartView As KPI.ChartView = 0
        nChartView = ChangeChartViewNameToNum(cChartView)
        ReturnValue = getChartViewType(nChartView)

        If IsNothing(ReturnValue) Then
            Return DefaultReturnValue
        Else
            Return ReturnValue
        End If
    End Function

    Public Function getChartViewType(ByVal oChartView As KPI.ChartView) As Object
        Dim seriesView As Object = Nothing
        Try
            If oChartView.ToString.Length = 0 Or oChartView = 0 Then
                oChartView = KPI.ChartView.SimpleBar
            End If
            Select Case IfNull(oChartView, 0)
                Case KPI.ChartView.SimpleBar
                    seriesView = New DevExpress.XtraCharts.SideBySideBarSeriesView()

                Case KPI.ChartView.SimpleLine
                    seriesView = New DevExpress.XtraCharts.LineSeriesView()

                Case KPI.ChartView.SimpleArea
                    seriesView = New DevExpress.XtraCharts.AreaSeriesView()

                Case KPI.ChartView.SimplePie
                    seriesView = New DevExpress.XtraCharts.PieSeriesView()
            End Select
        Catch ex As Exception
            'SET TO BAR TYPE
            seriesView = New DevExpress.XtraCharts.SideBySideBarSeriesView()
        End Try

        Return seriesView
    End Function


#End Region

    Public Function CreateKPISelectionList(cSelectionListing As String) As DataTable
        Dim dt As DataTable = Nothing
        dt = MPSDB.CreateTable("EXEC dbo.KPI_GenerateSelectionList '" & cSelectionListing & "', " & USER_ID)
        Return dt
    End Function

    Public Function CreateKPIFilterOption(oKPIDetail As KPIDetail) As BaseFilterOption
        Dim ReturnValue As BaseFilterOption = Nothing
        ReturnValue = New Reports.BaseFilterOption
        ReturnValue = Reports.FilterOption.Create("KPI", "KPI", BaseFilterOption.ReportFilterOptionUser.KPI)

        If Not ReturnValue Is Nothing Then
            ReturnValue.AdditionalFilterOptions.ObjectID = oKPIDetail.KPICode
            ReturnValue.AdditionalFilterOptions.Group = "KPI"
            ReturnValue.RefreshData()
        End If

        Return ReturnValue
    End Function


#Region "Basic Chart Methods and Functions"
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub ClearChart(ByRef oChartControl As DevExpress.XtraCharts.ChartControl)
        If Not oChartControl Is Nothing Then
            oChartControl.Titles.Clear()
            oChartControl.Series.Clear()
        End If
    End Sub

    Sub SetChartColorPalette(ByRef oChartControl As DevExpress.XtraCharts.ChartControl, ByVal ColorPalette As String)
        If ColorPalette Is Nothing Then ColorPalette = "Default"
        If ColorPalette.Length = 0 Then ColorPalette = "Default"

        Try
            oChartControl.PaletteName = ColorPalette
        Catch ex As Exception
            oChartControl.PaletteName = "Default"
        End Try

    End Sub

#Region "Title"
    Public Sub AddChartTitle(ByRef oChartControl As DevExpress.XtraCharts.ChartControl, ByVal cTitle As String, Optional ByVal cFontFace As String = "Tahoma", Optional ByVal nFontSize As Single = 16.0, Optional ByVal fFontStyle As System.Drawing.FontStyle = System.Drawing.FontStyle.Regular, Optional ByVal Color As Object = Nothing, Optional Indent As Integer = 5, Optional ByVal bFormatTitleToWordsPerLine As Boolean = False, Optional ByVal oDocking As DevExpress.XtraCharts.ChartTitleDockStyle = DevExpress.XtraCharts.ChartTitleDockStyle.Top, Optional ByVal WordWrap As Boolean = False, Optional ByVal MaxLineCount As Integer = 0)
        Dim oTitle As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        oTitle.Font = New System.Drawing.Font(cFontFace, nFontSize, fFontStyle)

        If bFormatTitleToWordsPerLine Then
            oTitle.Text = FormatTitleToWordsPerLine(cTitle)
        Else
            oTitle.Text = cTitle
        End If

        If Color Is Nothing Then
            oTitle.TextColor = System.Drawing.Color.Black
        Else
            oTitle.TextColor = Color
        End If

        oTitle.WordWrap = WordWrap
        oTitle.MaxLineCount = MaxLineCount
        oTitle.Dock = oDocking
        oTitle.Indent = 0
        oTitle.Visibility = DevExpress.Utils.DefaultBoolean.True

        oChartControl.Titles.Add(oTitle)
    End Sub

    Function FormatTitleToWordsPerLine(ByRef cTitle As String, Optional ByVal WordsPerLine As Integer = 6) As String
        Dim ReturnValue As String = ""
        For i As Integer = 1 To CountItemDelimited(cTitle, " ")
            If i Mod 7 = 0 Then
                ReturnValue = ReturnValue & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & GetItemDelimited(cTitle, i, " ")
            Else
                ReturnValue = ReturnValue & " " & GetItemDelimited(cTitle, i, " ")
            End If
        Next

        Return ReturnValue
    End Function
#End Region

#Region "Chart Color Palette"
    Public Sub changeChartColorPalette(ByRef oChartControl As DevExpress.XtraCharts.ChartControl, ByRef oKPIDetail As KPIDetail)
        If oChartControl Is Nothing Then Exit Sub

        SetChartColorPalette(oChartControl, oKPIDetail.ColorPalette)
    End Sub

    Public Sub changeChartColorPalette(ByRef oChartControl As DevExpress.XtraCharts.ChartControl, ByRef ColorPalette As String)
        If oChartControl Is Nothing Then Exit Sub

        SetChartColorPalette(oChartControl, ColorPalette)
    End Sub
#End Region

#Region "Series"
    Public Sub RemoveChartSeries(ByRef oChartControl As DevExpress.XtraCharts.ChartControl, ByVal cSeriesName As String)
        If Not oChartControl Is Nothing Then

            If Not oChartControl Is Nothing Then
                For i As Integer = 0 To oChartControl.Series.Count - 1
                    If oChartControl.Series(i).Name = cSeriesName Then
                        oChartControl.Series.RemoveAt(i)
                        Exit For
                    End If
                Next
            End If

        End If

    End Sub
#End Region

#Region "Series View"

    'ALL SERIES IN CHART
    Public Sub ChangeSeriesView(ByRef oChartControl As DevExpress.XtraCharts.ChartControl, ByVal oChartView As KPI.ChartView, ByRef oKPIDetail As KPIDetail)
        If oChartControl Is Nothing Then Exit Sub

        If oChartView.ToString.Length = 0 Or oChartView > 0 Then
            If oChartControl.Series.Count > 0 Then
                For i As Integer = 0 To oChartControl.Series.Count - 1
                    SetSeriesView(oChartControl.Series(i), oChartView, oChartControl.Series(i).Name, oChartControl.Series(i).LegendText, oKPIDetail.UsePercentInPieChartView)
                Next
            End If

            If oChartView = KPI.ChartView.SimplePie Then
                oChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
            Else
                oChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.Default
            End If
        End If
    End Sub

    'BY SERIES INDEX
    Public Sub changeSeriesView(ByRef oChartControl As DevExpress.XtraCharts.ChartControl, ByVal SeriesIndex As Integer, ByVal oChartView As KPI.ChartView, ByRef oKPIDetail As KPIDetail)
        If oChartControl Is Nothing Then Exit Sub

        If oChartView.ToString.Length = 0 Or oChartView = 0 Then
            SetSeriesView(oChartControl.Series(SeriesIndex), oChartView, oChartControl.Series(SeriesIndex).Name, oChartControl.Series(SeriesIndex).LegendText, oKPIDetail.UsePercentInPieChartView)
        End If
    End Sub

    'BY SERIES NAME
    Public Sub changeSeriesView(ByRef oChartControl As DevExpress.XtraCharts.ChartControl, ByVal SeriesName As String, ByVal oChartView As KPI.ChartView, ByRef oKPIDetail As KPIDetail)
        If oChartControl Is Nothing Then Exit Sub

        If oChartView.ToString.Length = 0 Or oChartView = 0 Then
            SetSeriesView(oChartControl.Series(SeriesName), oChartView, oChartControl.Series(SeriesName).Name, oChartControl.Series(SeriesName).LegendText, oKPIDetail.UsePercentInPieChartView)
        End If
    End Sub

    Sub SetSeriesView(ByRef oSeries As DevExpress.XtraCharts.Series, ByVal ChartView As KPI.ChartView, ByVal SeriesName As String, ByVal SeriesLegendText As String, Optional bUsePercentInPieChartView As Boolean = False)
        ' Specify data members to bind the series.
        oSeries.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Auto
        oSeries.ArgumentDataMember = "Argument"
        oSeries.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        oSeries.ValueDataMembers.AddRange(New String() {"Value"})
        oSeries.LegendText = SeriesLegendText
        oSeries.Name = SeriesLegendText
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

            'text pattern
            'Commented Out by Tony20161027
            'If bUsePercentInPieChartView Then
            '    oSeries.Label.TextPattern = "{A} : {VP:P0}"
            'Else
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
#End Region
#End Region

#Region "Classes"
    Public Class Period
        Public Annual As New PeriodRange
        Public Monthly As New PeriodRange
        Public Quarterly As New PeriodRange

        Public Enum FromTo
            _From = 1
            _To = 2
        End Enum

        Sub New()
            Annual.DropDownRowsCount = 10
            Annual.FKeyPeriod = KPIPeriodCode.Annually

            Monthly.DropDownRowsCount = 12
            Monthly.FKeyPeriod = KPIPeriodCode.Monthly

            Quarterly.DropDownRowsCount = 12
            Quarterly.FKeyPeriod = KPIPeriodCode.Quarterly
        End Sub

        Public Function GetPeriodRangeObject(FKeyPeriod As String) As Period.PeriodRange
            Select Case FKeyPeriod
                Case KPIPeriodCode.Annually
                    Return Annual

                Case KPIPeriodCode.Monthly
                    Return Monthly

                Case KPIPeriodCode.Quarterly
                    Return Quarterly

                Case Else
                    Return Nothing

            End Select
        End Function

        Public Sub SetPeriodRange(FKeyPeriod As String, FromTo As Period.FromTo, value As Object)
            Dim oPeriodRange As Period.PeriodRange = GetPeriodRangeObject(FKeyPeriod)
            If Not IsNothing(oPeriodRange) Then
                With oPeriodRange
                    'If IsNothing(.Table) Then .Table = oPeriodRangegetDefaultTableDataSource(FKeyPeriod)
                    If FromTo = Period.FromTo._From Then .RangeFrom = value
                    If FromTo = Period.FromTo._To Then .RangeTo = value
                End With

            End If
        End Sub

        Public Class PeriodRange
            'Public Table As DataTable = Nothing
            Public FKeyPeriod As String = ""
            Public _Table As DataTable = Nothing
            Public DropDownRowsCount As Integer
            Public RangeFrom As Object = Nothing
            Public RangeTo As Object = Nothing

            Public Property Table As DataTable

                Get
                    If IsNothing(_Table) Then
                        _Table = getDefaultTableDataSource()
                    End If
                    Return _Table
                End Get
                Set(value As DataTable)
                    _Table = value
                End Set
            End Property


            Function getDefaultTableDataSource() As DataTable
                Select Case FKeyPeriod
                    Case KPIPeriodCode.Annually
                        Return MPSDB.CreateTable("EXEC dbo.getperiodsyear " & MINIMUM_YEAR & ", 0")

                    Case KPIPeriodCode.Monthly
                        Dim cMinDate As String = MINIMUM_YEAR & "-01-01"
                        Dim cMaxDate As String = Year(getServerDateTime()) & "-12-31"
                        Return MPSDB.CreateTable("EXEC dbo.getperiods '" & cMinDate & "', '" & cMaxDate & "'")

                    Case KPIPeriodCode.Quarterly
                        Return MPSDB.CreateTable("EXEC dbo.getperiodsquarter " & MINIMUM_YEAR & ", 0")

                    Case Else
                        Return Nothing

                End Select
            End Function

        End Class
    End Class

    Public Class SelectedKPIData
        Property Enabled As Boolean = True

        Private KPISelectionList As New List(Of SelectedKPIDataCollection)
        Private SelectedSelectionListing As SelectedSelectionListingStruct


        Structure SelectedSelectionListingStruct
            Public SelectionListing As String
            Public MultiSelection As Boolean
        End Structure

        Function GetDataSource(cSelectionListing As String, isMultiSelection As Boolean) As DataTable
            Dim ReturnValue As DataTable = Nothing
            SetSelectedSelectionListing(cSelectionListing, isMultiSelection)
            Dim obj As SelectedKPIDataCollection = GetSelectedKPIDataCollection(SelectedSelectionListing)
            If Not IsNothing(obj) Then
                ReturnValue = obj.Data.DataSource
            Else
                obj = New SelectedKPIDataCollection
                obj = CreateSelectionListing(cSelectionListing, isMultiSelection)
                ReturnValue = obj.Data.DataSource
            End If

            Return ReturnValue
        End Function

        Function CreateSelectionListing(cSelectionListing As String, isMultiSelection As Boolean) As SelectedKPIDataCollection
            Dim newObj As New SelectedKPIDataCollection
            With newObj
                .SelectionListing = cSelectionListing
                .isMultiSelection = isMultiSelection
                .Data.DataSource = CreateKPISelectionList(cSelectionListing)
            End With

            KPISelectionList.Add(newObj)
            Return newObj
        End Function

        Sub SetSelectedSelectionListing(cSelectionListing As String, isMultiSelection As Boolean)
            SelectedSelectionListing.SelectionListing = cSelectionListing
            SelectedSelectionListing.MultiSelection = isMultiSelection
        End Sub

        Sub SetSelectedData(cSelectionListing As String, isMultiSelection As Boolean, view As DevExpress.XtraGrid.Views.Grid.GridView) 'grid As DevExpress.XtraGrid.GridControl)
            'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = grid.Views(0)
            SetSelectedSelectionListing(cSelectionListing, isMultiSelection)

            Dim obj As SelectedKPIDataCollection = GetSelectedKPIDataCollection(SelectedSelectionListing)
            If Not IsNothing(obj) Then
                obj.Data.ClearSelection()

                For i As Integer = 0 To view.SelectedRowsCount - 1
                    obj.Data.Add(view.GetRowCellValue(i, "ColumnKey"), view.GetRowCellValue(i, "ColumnDisplay"))
                Next

            End If
        End Sub

        Sub Add(cSelectionListing As String, isMultiSelection As Boolean, PKey As String, Name As String)
            SetSelectedSelectionListing(cSelectionListing, isMultiSelection)

            Dim obj As SelectedKPIDataCollection = GetSelectedKPIDataCollection(SelectedSelectionListing)
            If IsNothing(obj) Then
                obj = New SelectedKPIDataCollection
                obj = CreateSelectionListing(cSelectionListing, isMultiSelection)
            End If
            If Not obj.isMultiSelection Then obj.Data.ClearSelection()
            If Not IsNothing(obj) Then obj.Data.Add(PKey, Name)
        End Sub

        Sub Remove(cSelectionListing As String, isMultiSelection As Boolean, PKey As String, Name As String)
            SetSelectedSelectionListing(cSelectionListing, isMultiSelection)

            Dim obj As SelectedKPIDataCollection = GetSelectedKPIDataCollection(SelectedSelectionListing)
            If Not IsNothing(obj) Then obj.Data.Remove(PKey, Name)
        End Sub

        Sub ApplySelectedDataToGridView(cSelectionListing As String, isMultiSelection As Boolean, view As DevExpress.XtraGrid.Views.Grid.GridView)
            Enabled = False
            SetSelectedSelectionListing(cSelectionListing, isMultiSelection)

            For i As Integer = 0 To view.SelectedRowsCount - 1
                view.UnselectRow(i)
            Next

            Dim obj As SelectedKPIDataCollection = GetSelectedKPIDataCollection(SelectedSelectionListing)

            If Not IsNothing(obj) Then
                For Each row As DataRow In obj.Data.SelectionSource.Rows
                    view.SelectRow(view.LocateByValue("ColumnKey", row("PKey")))
                Next
            End If
            Enabled = True
        End Sub

        Function GetSelectedKPIDataCollection(oSelectionListing As SelectedSelectionListingStruct) As SelectedKPIDataCollection
            Dim ReturnValue As SelectedKPIDataCollection = Nothing
            For Each i As SelectedKPIDataCollection In KPISelectionList
                If i.SelectionListing = oSelectionListing.SelectionListing And _
                    i.isMultiSelection = oSelectionListing.MultiSelection Then

                    ReturnValue = i
                    Exit For

                End If
            Next
            Return ReturnValue
        End Function
    End Class

#Region "Sub Class: Selected KPI"
    Public Class SelectedKPIDataSource
        Public DataSource As DataTable = Nothing
        Public SelectionSource As DataTable = Nothing

        Sub New()
            'initialize the ListOfSelectedData Datatable
            SelectionSource = New DataTable
            Dim ccolumn As DataColumn
            ccolumn = New DataColumn
            ccolumn.ColumnName = "PKey"
            ccolumn.DataType = System.Type.GetType("System.String")
            SelectionSource.Columns.Add(ccolumn)

            ccolumn = New DataColumn
            ccolumn.ColumnName = "Name"
            ccolumn.DataType = System.Type.GetType("System.String")
            SelectionSource.Columns.Add(ccolumn)

        End Sub

        Public Sub Add(PKey As String, Name As String)
            If Not IsNothing(PKey) And Not IsNothing(Name) Then
                Remove(PKey, Name)
                SelectionSource.Rows.Add(New Object() {PKey, Name})
            End If
            
        End Sub

        Public Sub Remove(PKey As String, Name As String)
            Dim row() As DataRow

            If Not IsNothing(PKey) And Not IsNothing(Name) Then
                Name = Name.Replace("'", "''")
                row = SelectionSource.Select("PKey = '" & PKey & "' AND Name = '" & Name & "'")
                If row.Count > 0 Then
                    For i As Integer = 0 To row.Count - 1
                        row(i).Delete()
                    Next
                End If
            End If
        End Sub

        Public Sub ClearSelection()
            SelectionSource.Clear()
        End Sub

        
    End Class

    Public Class SelectedKPIDataCollection
        Public SelectionListing As String = ""
        Public isMultiSelection As Boolean
        Public Data As New SelectedKPIDataSource
    End Class
#End Region

    Public Class FloatingKPIValue
        Public DateCoverage As New Period
        Public SelectedData As New SelectedKPIData


        'Function getDefaultTableDataSource(FKeyPeriod As String) As DataTable
        '    Select Case FKeyPeriod
        '        Case KPIPeriodCode.Annually
        '            Return MPSDB.CreateTable("EXEC dbo.getperiodsyear " & MINIMUM_YEAR & ", 0")

        '        Case KPIPeriodCode.Monthly
        '            Dim cMinDate As String = MINIMUM_YEAR & "-01-01"
        '            Dim cMaxDate As String = Year(getServerDateTime()) & "-12-31"
        '            Return MPSDB.CreateTable("EXEC dbo.getperiods '" & cMinDate & "', '" & cMaxDate & "'")

        '        Case KPIPeriodCode.Quarterly
        '            Return MPSDB.CreateTable("EXEC dbo.getperiodsquarter " & MINIMUM_YEAR & ", 0")

        '        Case Else
        '            Return Nothing

        '    End Select
        'End Function


    End Class
#End Region
End Module
