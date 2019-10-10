<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptCrewList
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim XrGroupSortingSummary1 As DevExpress.XtraReports.UI.XRGroupSortingSummary = New DevExpress.XtraReports.UI.XRGroupSortingSummary()
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celCrewName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celRank = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celAge = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celDateSON = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celDateSOFF = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celLOC = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celDL = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celFormerVsl = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celHireStat = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celAvailAp = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celServPrin = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celDesc = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupHeader_RankGroup = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.grpVSL = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celVSL = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter_RankGroup = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrTable5 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celRankGroup = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celTAgeAvg = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celServRank = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celServTotal = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable4})
        Me.Detail.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Detail.HeightF = 25.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StylePriority.UseFont = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable4
        '
        Me.XrTable4.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable4.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrTable4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable4.Name = "XrTable4"
        Me.XrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4})
        Me.XrTable4.SizeF = New System.Drawing.SizeF(1069.0!, 25.0!)
        Me.XrTable4.StylePriority.UseBorders = False
        Me.XrTable4.StylePriority.UseFont = False
        Me.XrTable4.StylePriority.UseTextAlignment = False
        Me.XrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celCrewName, Me.celRank, Me.celAge, Me.celDateSON, Me.celDateSOFF, Me.celLOC, Me.celDL, Me.celFormerVsl, Me.celHireStat, Me.celAvailAp, Me.celServPrin, Me.celServRank, Me.celServTotal})
        Me.XrTableRow4.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.StylePriority.UseFont = False
        Me.XrTableRow4.Weight = 0.90225574261150421R
        '
        'celCrewName
        '
        Me.celCrewName.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celCrewName.Name = "celCrewName"
        Me.celCrewName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celCrewName.StylePriority.UseFont = False
        Me.celCrewName.StylePriority.UsePadding = False
        Me.celCrewName.StylePriority.UseTextAlignment = False
        Me.celCrewName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celCrewName.Weight = 0.050946259128919383R
        '
        'celRank
        '
        Me.celRank.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celRank.Name = "celRank"
        Me.celRank.StylePriority.UseFont = False
        Me.celRank.StylePriority.UseTextAlignment = False
        Me.celRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celRank.Weight = 0.016982079297759228R
        '
        'celAge
        '
        Me.celAge.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celAge.Name = "celAge"
        Me.celAge.StylePriority.UseFont = False
        Me.celAge.StylePriority.UseTextAlignment = False
        Me.celAge.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celAge.Weight = 0.010189236573067483R
        '
        'celDateSON
        '
        Me.celDateSON.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celDateSON.Name = "celDateSON"
        Me.celDateSON.StylePriority.UseFont = False
        Me.celDateSON.StylePriority.UseTextAlignment = False
        Me.celDateSON.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celDateSON.Weight = 0.030567767477406669R
        '
        'celDateSOFF
        '
        Me.celDateSOFF.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celDateSOFF.Name = "celDateSOFF"
        Me.celDateSOFF.StylePriority.UseFont = False
        Me.celDateSOFF.StylePriority.UseTextAlignment = False
        Me.celDateSOFF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celDateSOFF.Weight = 0.03056774767235642R
        '
        'celLOC
        '
        Me.celLOC.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celLOC.Multiline = True
        Me.celLOC.Name = "celLOC"
        Me.celLOC.StylePriority.UseFont = False
        Me.celLOC.StylePriority.UseTextAlignment = False
        Me.celLOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celLOC.Weight = 0.010189259538150093R
        '
        'celDL
        '
        Me.celDL.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celDL.Multiline = True
        Me.celDL.Name = "celDL"
        Me.celDL.StylePriority.UseFont = False
        Me.celDL.StylePriority.UseTextAlignment = False
        Me.celDL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celDL.Weight = 0.013585678377493061R
        '
        'celFormerVsl
        '
        Me.celFormerVsl.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celFormerVsl.Name = "celFormerVsl"
        Me.celFormerVsl.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celFormerVsl.StylePriority.UseFont = False
        Me.celFormerVsl.StylePriority.UsePadding = False
        Me.celFormerVsl.StylePriority.UseTextAlignment = False
        Me.celFormerVsl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celFormerVsl.Weight = 0.033964147057906818R
        '
        'celHireStat
        '
        Me.celHireStat.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celHireStat.Name = "celHireStat"
        Me.celHireStat.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celHireStat.StylePriority.UseFont = False
        Me.celHireStat.StylePriority.UsePadding = False
        Me.celHireStat.StylePriority.UseTextAlignment = False
        Me.celHireStat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celHireStat.Weight = 0.027171332292151636R
        '
        'celAvailAp
        '
        Me.celAvailAp.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celAvailAp.Name = "celAvailAp"
        Me.celAvailAp.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celAvailAp.StylePriority.UseFont = False
        Me.celAvailAp.StylePriority.UsePadding = False
        Me.celAvailAp.StylePriority.UseTextAlignment = False
        Me.celAvailAp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celAvailAp.Weight = 0.037360561182872988R
        '
        'celServPrin
        '
        Me.celServPrin.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celServPrin.Name = "celServPrin"
        Me.celServPrin.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celServPrin.StylePriority.UseFont = False
        Me.celServPrin.StylePriority.UsePadding = False
        Me.celServPrin.StylePriority.UseTextAlignment = False
        Me.celServPrin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celServPrin.Weight = 0.033964194019170516R
        '
        'TopMargin
        '
        Me.TopMargin.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.TopMargin.HeightF = 100.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.StylePriority.UseFont = False
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.StylePriority.UseFont = False
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.ReportHeader.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.ReportHeader.HeightF = 50.0!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseFont = False
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow2})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1069.0!, 50.0!)
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.StylePriority.UseFont = False
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UsePadding = False
        Me.XrTableCell1.Text = "F. CREW LIST"
        Me.XrTableCell1.Weight = 1.0R
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celDesc})
        Me.XrTableRow2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.StylePriority.UseFont = False
        Me.XrTableRow2.Weight = 1.0R
        '
        'celDesc
        '
        Me.celDesc.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.celDesc.Name = "celDesc"
        Me.celDesc.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.celDesc.StylePriority.UseFont = False
        Me.celDesc.StylePriority.UsePadding = False
        Me.celDesc.Text = "THE TABLE SHOWS THE NUMBER OF CREWS ON-BOARD  FROM (RANGE) TO (RANGE)"
        Me.celDesc.Weight = 1.0R
        '
        'GroupHeader_RankGroup
        '
        Me.GroupHeader_RankGroup.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.GroupHeader_RankGroup.HeightF = 0.0!
        Me.GroupHeader_RankGroup.Name = "GroupHeader_RankGroup"
        XrGroupSortingSummary1.Enabled = True
        Me.GroupHeader_RankGroup.SortingSummary = XrGroupSortingSummary1
        Me.GroupHeader_RankGroup.StylePriority.UseFont = False
        '
        'grpVSL
        '
        Me.grpVSL.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.grpVSL.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2, Me.XrTable3})
        Me.grpVSL.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.grpVSL.HeightF = 70.0!
        Me.grpVSL.Level = 1
        Me.grpVSL.Name = "grpVSL"
        Me.grpVSL.StylePriority.UseBackColor = False
        Me.grpVSL.StylePriority.UseFont = False
        '
        'XrTable2
        '
        Me.XrTable2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XrTable2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 32.29167!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow6})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(1069.0!, 37.70833!)
        Me.XrTable2.StylePriority.UseBackColor = False
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell16, Me.XrTableCell17, Me.XrTableCell18, Me.XrTableCell19, Me.XrTableCell20, Me.XrTableCell21, Me.XrTableCell22, Me.XrTableCell23, Me.XrTableCell24, Me.XrTableCell25, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4})
        Me.XrTableRow6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.StylePriority.UseFont = False
        Me.XrTableRow6.Weight = 1.3609022282079506R
        '
        'XrTableCell16
        '
        Me.XrTableCell16.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell16.Name = "XrTableCell16"
        Me.XrTableCell16.StylePriority.UseFont = False
        Me.XrTableCell16.StylePriority.UseTextAlignment = False
        Me.XrTableCell16.Text = "CREW"
        Me.XrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell16.Weight = 0.050946253946398616R
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.StylePriority.UseFont = False
        Me.XrTableCell17.StylePriority.UseTextAlignment = False
        Me.XrTableCell17.Text = "RANK"
        Me.XrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell17.Weight = 0.01698208448028R
        '
        'XrTableCell18
        '
        Me.XrTableCell18.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell18.Name = "XrTableCell18"
        Me.XrTableCell18.StylePriority.UseFont = False
        Me.XrTableCell18.StylePriority.UseTextAlignment = False
        Me.XrTableCell18.Text = "AGE"
        Me.XrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell18.Weight = 0.010189250165633086R
        '
        'XrTableCell19
        '
        Me.XrTableCell19.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell19.Name = "XrTableCell19"
        Me.XrTableCell19.StylePriority.UseFont = False
        Me.XrTableCell19.StylePriority.UseTextAlignment = False
        Me.XrTableCell19.Text = "SIGN ON"
        Me.XrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell19.Weight = 0.030567751270477811R
        '
        'XrTableCell20
        '
        Me.XrTableCell20.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell20.Name = "XrTableCell20"
        Me.XrTableCell20.StylePriority.UseFont = False
        Me.XrTableCell20.StylePriority.UseTextAlignment = False
        Me.XrTableCell20.Text = "SIGN OFF"
        Me.XrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell20.Weight = 0.030567750252065394R
        '
        'XrTableCell21
        '
        Me.XrTableCell21.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell21.Multiline = True
        Me.XrTableCell21.Name = "XrTableCell21"
        Me.XrTableCell21.StylePriority.UseFont = False
        Me.XrTableCell21.StylePriority.UseTextAlignment = False
        Me.XrTableCell21.Text = "LOC"
        Me.XrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell21.Weight = 0.010189250253871443R
        '
        'XrTableCell22
        '
        Me.XrTableCell22.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell22.Multiline = True
        Me.XrTableCell22.Name = "XrTableCell22"
        Me.XrTableCell22.StylePriority.UseFont = False
        Me.XrTableCell22.StylePriority.UseTextAlignment = False
        Me.XrTableCell22.Text = "DAYS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LEFT"
        Me.XrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell22.Weight = 0.013585666908585758R
        '
        'XrTableCell23
        '
        Me.XrTableCell23.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell23.Name = "XrTableCell23"
        Me.XrTableCell23.StylePriority.UseFont = False
        Me.XrTableCell23.StylePriority.UseTextAlignment = False
        Me.XrTableCell23.Text = "FORMER VESSEL"
        Me.XrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell23.Weight = 0.0339641677879899R
        '
        'XrTableCell24
        '
        Me.XrTableCell24.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell24.Name = "XrTableCell24"
        Me.XrTableCell24.StylePriority.UseFont = False
        Me.XrTableCell24.StylePriority.UseTextAlignment = False
        Me.XrTableCell24.Text = "HIRE STATUS"
        Me.XrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell24.Weight = 0.027171334883412019R
        '
        'XrTableCell25
        '
        Me.XrTableCell25.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell25.Name = "XrTableCell25"
        Me.XrTableCell25.StylePriority.UseFont = False
        Me.XrTableCell25.StylePriority.UseTextAlignment = False
        Me.XrTableCell25.Text = "AVAILABLE APPRAISAL / REPORTING"
        Me.XrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell25.Weight = 0.037360584504216456R
        '
        'XrTable3
        '
        Me.XrTable3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.20834!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(1069.0!, 22.08333!)
        Me.XrTable3.StylePriority.UseBorders = False
        Me.XrTable3.StylePriority.UseFont = False
        Me.XrTable3.StylePriority.UseTextAlignment = False
        Me.XrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celVSL})
        Me.XrTableRow3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.StylePriority.UseFont = False
        Me.XrTableRow3.Weight = 1.0R
        '
        'celVSL
        '
        Me.celVSL.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.celVSL.Name = "celVSL"
        Me.celVSL.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celVSL.StylePriority.UseFont = False
        Me.celVSL.StylePriority.UsePadding = False
        Me.celVSL.Text = "VESSEL NAME"
        Me.celVSL.Weight = 0.3630769571699366R
        '
        'GroupFooter_RankGroup
        '
        Me.GroupFooter_RankGroup.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable5})
        Me.GroupFooter_RankGroup.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.GroupFooter_RankGroup.HeightF = 20.0!
        Me.GroupFooter_RankGroup.Name = "GroupFooter_RankGroup"
        Me.GroupFooter_RankGroup.StylePriority.UseFont = False
        '
        'XrTable5
        '
        Me.XrTable5.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.XrTable5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable5.Name = "XrTable5"
        Me.XrTable5.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow5})
        Me.XrTable5.SizeF = New System.Drawing.SizeF(1069.0!, 20.0!)
        Me.XrTable5.StylePriority.UseBackColor = False
        Me.XrTable5.StylePriority.UseBorders = False
        Me.XrTable5.StylePriority.UseFont = False
        Me.XrTable5.StylePriority.UseTextAlignment = False
        Me.XrTable5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celRankGroup, Me.celTAgeAvg, Me.XrTableCell28})
        Me.XrTableRow5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.StylePriority.UseFont = False
        Me.XrTableRow5.Weight = 1.1294119674524585R
        '
        'celRankGroup
        '
        Me.celRankGroup.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celRankGroup.Name = "celRankGroup"
        Me.celRankGroup.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.celRankGroup.StylePriority.UseFont = False
        Me.celRankGroup.StylePriority.UsePadding = False
        Me.celRankGroup.StylePriority.UseTextAlignment = False
        Me.celRankGroup.Text = "RANK TYPE AVG AGE :"
        Me.celRankGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celRankGroup.Weight = 0.064919469317934353R
        '
        'celTAgeAvg
        '
        Me.celTAgeAvg.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celTAgeAvg.Name = "celTAgeAvg"
        Me.celTAgeAvg.StylePriority.UseBorders = False
        Me.celTAgeAvg.StylePriority.UseFont = False
        Me.celTAgeAvg.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:#,#}"
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celTAgeAvg.Summary = XrSummary1
        Me.celTAgeAvg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celTAgeAvg.Weight = 0.0097379057222266238R
        '
        'XrTableCell28
        '
        Me.XrTableCell28.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell28.Name = "XrTableCell28"
        Me.XrTableCell28.StylePriority.UseFont = False
        Me.XrTableCell28.StylePriority.UseTextAlignment = False
        Me.XrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell28.Weight = 0.2723371940318331R
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.GroupFooter2.HeightF = 0.0!
        Me.GroupFooter2.Level = 1
        Me.GroupFooter2.Name = "GroupFooter2"
        Me.GroupFooter2.StylePriority.UseFont = False
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "TIME WITH PRINCIPAL"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell2.Weight = 0.033964170272232863R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.Text = "TIME IN RANK"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell3.Weight = 0.033964167680972462R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "TOTAL YEARS " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OF SEA SERVICE"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell4.Weight = 0.033624525998648062R
        '
        'celServRank
        '
        Me.celServRank.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celServRank.Name = "celServRank"
        Me.celServRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celServRank.StylePriority.UseFont = False
        Me.celServRank.StylePriority.UsePadding = False
        Me.celServRank.StylePriority.UseTextAlignment = False
        Me.celServRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celServRank.Weight = 0.033964194019170516R
        '
        'celServTotal
        '
        Me.celServTotal.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.celServTotal.Name = "celServTotal"
        Me.celServTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celServTotal.StylePriority.UseFont = False
        Me.celServTotal.StylePriority.UsePadding = False
        Me.celServTotal.StylePriority.UseTextAlignment = False
        Me.celServTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celServTotal.Weight = 0.033624469407998993R
        '
        'rptCrewList
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.GroupHeader_RankGroup, Me.grpVSL, Me.GroupFooter_RankGroup, Me.GroupFooter2})
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 100, 100)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "14.2"
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celDesc As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupHeader_RankGroup As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents grpVSL As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter_RankGroup As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrTable4 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celCrewName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celRank As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celAge As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celDateSON As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celDateSOFF As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celLOC As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celFormerVsl As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celHireStat As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celServPrin As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable5 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celRankGroup As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celTAgeAvg As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celVSL As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celAvailAp As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celDL As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celServRank As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celServTotal As DevExpress.XtraReports.UI.XRTableCell
End Class
