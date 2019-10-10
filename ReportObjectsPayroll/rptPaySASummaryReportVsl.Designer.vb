<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPaySASummaryReportVsl
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
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.colCrewName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.colBank = New DevExpress.XtraReports.UI.XRTableCell()
        Me.colAcctName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.colAcctNo = New DevExpress.XtraReports.UI.XRTableCell()
        Me.colTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.CurrGroup = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.txtGrpCurrency = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.txtPayPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtCompany = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CurrFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.colTotalMPO = New DevExpress.XtraReports.UI.XRTableCell()
        Me.VslGroup = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.txtVesselName = New DevExpress.XtraReports.UI.XRLabel()
        Me.VslFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.MCodeGroup = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.txtPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.lblDatePrinted = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.Detail.HeightF = 27.60417!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(702.0!, 27.60417!)
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.colCrewName, Me.colBank, Me.colAcctName, Me.colAcctNo, Me.colTotal})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'colCrewName
        '
        Me.colCrewName.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.colCrewName.Name = "colCrewName"
        Me.colCrewName.StylePriority.UseBorders = False
        Me.colCrewName.StylePriority.UseTextAlignment = False
        Me.colCrewName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.colCrewName.Weight = 2.9534079757301823R
        '
        'colBank
        '
        Me.colBank.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.colBank.Name = "colBank"
        Me.colBank.StylePriority.UseBorders = False
        Me.colBank.StylePriority.UseTextAlignment = False
        Me.colBank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify
        Me.colBank.Weight = 1.7968835456866157R
        '
        'colAcctName
        '
        Me.colAcctName.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.colAcctName.Name = "colAcctName"
        Me.colAcctName.StylePriority.UseBorders = False
        Me.colAcctName.StylePriority.UseTextAlignment = False
        Me.colAcctName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.colAcctName.Weight = 1.663782221981549R
        '
        'colAcctNo
        '
        Me.colAcctNo.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.colAcctNo.Name = "colAcctNo"
        Me.colAcctNo.StylePriority.UseBorders = False
        Me.colAcctNo.StylePriority.UseTextAlignment = False
        Me.colAcctNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.colAcctNo.Weight = 1.947889599254403R
        '
        'colTotal
        '
        Me.colTotal.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.colTotal.Name = "colTotal"
        Me.colTotal.StylePriority.UseBorders = False
        Me.colTotal.StylePriority.UseTextAlignment = False
        Me.colTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.colTotal.Weight = 1.1594745326999683R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 60.41667!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 40.83333!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'CurrGroup
        '
        Me.CurrGroup.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtGrpCurrency, Me.XrLabel8})
        Me.CurrGroup.HeightF = 23.0!
        Me.CurrGroup.Name = "CurrGroup"
        '
        'txtGrpCurrency
        '
        Me.txtGrpCurrency.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtGrpCurrency.LocationFloat = New DevExpress.Utils.PointFloat(123.9583!, 0.0!)
        Me.txtGrpCurrency.Name = "txtGrpCurrency"
        Me.txtGrpCurrency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtGrpCurrency.SizeF = New System.Drawing.SizeF(557.2084!, 23.0!)
        Me.txtGrpCurrency.StylePriority.UseFont = False
        Me.txtGrpCurrency.StylePriority.UseTextAlignment = False
        Me.txtGrpCurrency.Text = "CURR"
        Me.txtGrpCurrency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(42.70833!, 0.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(81.24997!, 23.0!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "CURRENCY:"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtPayPeriod, Me.txtCompany, Me.XrLabel3, Me.XrLabel1, Me.XrTable1})
        Me.ReportHeader.HeightF = 127.8333!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'txtPayPeriod
        '
        Me.txtPayPeriod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtPayPeriod.LocationFloat = New DevExpress.Utils.PointFloat(123.9583!, 54.83332!)
        Me.txtPayPeriod.Name = "txtPayPeriod"
        Me.txtPayPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtPayPeriod.SizeF = New System.Drawing.SizeF(575.0417!, 23.0!)
        Me.txtPayPeriod.StylePriority.UseFont = False
        Me.txtPayPeriod.StylePriority.UseTextAlignment = False
        Me.txtPayPeriod.Text = "PAY PERIOD"
        Me.txtPayPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtCompany
        '
        Me.txtCompany.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtCompany.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCompany.SizeF = New System.Drawing.SizeF(699.0!, 29.33333!)
        Me.txtCompany.StylePriority.UseFont = False
        Me.txtCompany.StylePriority.UseTextAlignment = False
        Me.txtCompany.Text = "COMPANY"
        Me.txtCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 54.83331!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(123.9583!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "PAYROLL PERIOD:"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 29.33333!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(699.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "SPECIAL ALLOTMENT REPORT"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(1.041889!, 102.8333!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(700.9581!, 25.0!)
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4, Me.XrTableCell5})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "CREW NAME"
        Me.XrTableCell1.Weight = 1.552722769655523R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "BANK NAME"
        Me.XrTableCell2.Weight = 0.9388975510254518R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = "ACCOUNT NAME"
        Me.XrTableCell3.Weight = 0.874715832168474R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "ACCT. NUMBER"
        Me.XrTableCell4.Weight = 1.0240823389595106R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Text = "AMOUNT"
        Me.XrTableCell5.Weight = 0.60958150819104029R
        '
        'CurrFooter
        '
        Me.CurrFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.CurrFooter.HeightF = 29.6875!
        Me.CurrFooter.Name = "CurrFooter"
        '
        'XrTable3
        '
        Me.XrTable3.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(492.2759!, 4.58334!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(209.7241!, 15.10416!)
        Me.XrTable3.StylePriority.UseFont = False
        Me.XrTable3.StylePriority.UseTextAlignment = False
        Me.XrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell14, Me.colTotalMPO})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.StylePriority.UseBorders = False
        Me.XrTableCell14.StylePriority.UseFont = False
        Me.XrTableCell14.StylePriority.UseTextAlignment = False
        Me.XrTableCell14.Text = "TOTAL"
        Me.XrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell14.Weight = 1.3143594800374023R
        '
        'colTotalMPO
        '
        Me.colTotalMPO.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.colTotalMPO.Name = "colTotalMPO"
        Me.colTotalMPO.StylePriority.UseBorders = False
        Me.colTotalMPO.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:n2}"
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.colTotalMPO.Summary = XrSummary1
        Me.colTotalMPO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.colTotalMPO.Weight = 0.904390367374707R
        '
        'VslGroup
        '
        Me.VslGroup.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtVesselName})
        Me.VslGroup.HeightF = 23.0!
        Me.VslGroup.Level = 1
        Me.VslGroup.Name = "VslGroup"
        '
        'txtVesselName
        '
        Me.txtVesselName.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.txtVesselName.LocationFloat = New DevExpress.Utils.PointFloat(25.00022!, 0.0!)
        Me.txtVesselName.Name = "txtVesselName"
        Me.txtVesselName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtVesselName.SizeF = New System.Drawing.SizeF(676.9998!, 23.0!)
        Me.txtVesselName.StylePriority.UseFont = False
        Me.txtVesselName.StylePriority.UseTextAlignment = False
        Me.txtVesselName.Text = "Vessel Name"
        Me.txtVesselName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'VslFooter
        '
        Me.VslFooter.HeightF = 0.0!
        Me.VslFooter.Level = 1
        Me.VslFooter.Name = "VslFooter"
        '
        'MCodeGroup
        '
        Me.MCodeGroup.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtPeriod})
        Me.MCodeGroup.HeightF = 30.0!
        Me.MCodeGroup.Level = 2
        Me.MCodeGroup.Name = "MCodeGroup"
        '
        'txtPeriod
        '
        Me.txtPeriod.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.txtPeriod.LocationFloat = New DevExpress.Utils.PointFloat(1.04181!, 7.000001!)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtPeriod.SizeF = New System.Drawing.SizeF(194.7082!, 23.0!)
        Me.txtPeriod.StylePriority.UseFont = False
        Me.txtPeriod.StylePriority.UseTextAlignment = False
        Me.txtPeriod.Text = "Period"
        Me.txtPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'FormattingRule1
        '
        Me.FormattingRule1.Name = "FormattingRule1"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.XrLine1, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel2})
        Me.ReportFooter.HeightF = 235.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(453.0001!, 185.4167!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(225.0414!, 2.083336!)
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 185.4167!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(216.6668!, 2.083336!)
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(453.0001!, 188.0417!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(225.0414!, 23.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "FLEET OFFICER"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(1.041889!, 188.0417!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(215.6249!, 23.0!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "RECRUITMENT MANAGER"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(453.0003!, 131.0417!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(245.9999!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "NOTED BY:"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 131.0417!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(215.6249!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "PREPARED BY:"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDatePrinted, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 23.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblDatePrinted
        '
        Me.lblDatePrinted.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblDatePrinted.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblDatePrinted.Name = "lblDatePrinted"
        Me.lblDatePrinted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDatePrinted.SizeF = New System.Drawing.SizeF(276.0417!, 23.0!)
        Me.lblDatePrinted.StylePriority.UseFont = False
        Me.lblDatePrinted.Text = "Date Printed:"
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(602.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'rptPaySASummaryReportVsl
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.CurrGroup, Me.ReportHeader, Me.CurrFooter, Me.VslGroup, Me.VslFooter, Me.MCodeGroup, Me.ReportFooter, Me.PageFooter})
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
        Me.Margins = New System.Drawing.Printing.Margins(51, 97, 60, 41)
        Me.Version = "14.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents CurrGroup As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents CurrFooter As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents VslGroup As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents txtVesselName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents VslFooter As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents colCrewName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents colBank As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents colAcctName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents colAcctNo As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents colTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents txtCompany As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtGrpCurrency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtPayPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents colTotalMPO As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents MCodeGroup As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents txtPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblDatePrinted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
