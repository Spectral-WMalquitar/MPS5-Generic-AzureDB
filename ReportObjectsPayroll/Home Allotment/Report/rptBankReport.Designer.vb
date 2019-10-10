<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptBankReport
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
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celBankBranch = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celAccountNumber = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celAccountName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celAmount = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.lblPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCompanyName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeader_Principal = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celPrincipal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celDateRemitted = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupHeader_Currency = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCurrency = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celExRate = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupHeader_BankBranch = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrTable5 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celSubTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrTable6 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow9 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow10 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow11 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celPreparedBy = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celVerifiedBy = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celApprovedBy = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable7 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow12 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.lblGrandTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celGrandTotal = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow13 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.lblDatePrinted = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable4})
        Me.Detail.HeightF = 18.75!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable4
        '
        Me.XrTable4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTable4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable4.Name = "XrTable4"
        Me.XrTable4.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow5})
        Me.XrTable4.SizeF = New System.Drawing.SizeF(727.0!, 18.75!)
        Me.XrTable4.StylePriority.UseFont = False
        Me.XrTable4.StylePriority.UsePadding = False
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celBankBranch, Me.celAccountNumber, Me.celAccountName, Me.celAmount})
        Me.XrTableRow5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.StylePriority.UseBorders = False
        Me.XrTableRow5.StylePriority.UseFont = False
        Me.XrTableRow5.Weight = 1.0R
        '
        'celBankBranch
        '
        Me.celBankBranch.Name = "celBankBranch"
        Me.celBankBranch.Text = "[BankBranch]"
        Me.celBankBranch.Weight = 0.6088377625938951R
        '
        'celAccountNumber
        '
        Me.celAccountNumber.Name = "celAccountNumber"
        Me.celAccountNumber.Text = "[AccountNumber]"
        Me.celAccountNumber.Weight = 0.63462893605396209R
        '
        'celAccountName
        '
        Me.celAccountName.Name = "celAccountName"
        Me.celAccountName.Text = "[BeneficiaryName]"
        Me.celAccountName.Weight = 1.2995182546329627R
        '
        'celAmount
        '
        Me.celAmount.Name = "celAmount"
        Me.celAmount.StylePriority.UseTextAlignment = False
        Me.celAmount.Text = "[Amount]"
        Me.celAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.celAmount.Weight = 0.45701504671917992R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 49.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblPeriod, Me.lblCompanyName, Me.XrLabel1})
        Me.PageHeader.HeightF = 99.91197!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblPeriod
        '
        Me.lblPeriod.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblPeriod.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 58.37504!)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPeriod.SizeF = New System.Drawing.SizeF(727.0!, 20.79168!)
        Me.lblPeriod.StylePriority.UseFont = False
        Me.lblPeriod.StylePriority.UseTextAlignment = False
        Me.lblPeriod.Text = "for the period of: January-2000"
        Me.lblPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyName.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCompanyName.SizeF = New System.Drawing.SizeF(727.0!, 37.58334!)
        Me.lblCompanyName.StylePriority.UseFont = False
        Me.lblCompanyName.StylePriority.UseTextAlignment = False
        Me.lblCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 37.58335!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(727.0!, 20.79168!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "MONTHLY BANK REPORT"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'GroupHeader_Principal
        '
        Me.GroupHeader_Principal.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.GroupHeader_Principal.HeightF = 31.25!
        Me.GroupHeader_Principal.Level = 2
        Me.GroupHeader_Principal.Name = "GroupHeader_Principal"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(727.0!, 18.75!)
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UsePadding = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.celPrincipal, Me.XrTableCell14, Me.XrTableCell4, Me.celDateRemitted})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 0.75R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "Principal:"
        Me.XrTableCell1.Weight = 0.34663000723354759R
        '
        'celPrincipal
        '
        Me.celPrincipal.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.celPrincipal.Name = "celPrincipal"
        Me.celPrincipal.StylePriority.UseBorders = False
        Me.celPrincipal.Text = "[Principal]"
        Me.celPrincipal.Weight = 1.361072902338377R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Weight = 0.30949078104682926R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "Date Remitted:"
        Me.XrTableCell4.Weight = 0.4312244661900495R
        '
        'celDateRemitted
        '
        Me.celDateRemitted.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.celDateRemitted.Name = "celDateRemitted"
        Me.celDateRemitted.StylePriority.UseBorders = False
        Me.celDateRemitted.Weight = 0.55158184319119674R
        '
        'GroupHeader_Currency
        '
        Me.GroupHeader_Currency.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.GroupHeader_Currency.HeightF = 46.875!
        Me.GroupHeader_Currency.Level = 1
        Me.GroupHeader_Currency.Name = "GroupHeader_Currency"
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XrTableRow3})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(727.0!, 37.5!)
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UsePadding = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell2, Me.celCurrency, Me.XrTableCell5})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "Currency:"
        Me.XrTableCell2.Weight = 0.34663000723354759R
        '
        'celCurrency
        '
        Me.celCurrency.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celCurrency.Name = "celCurrency"
        Me.celCurrency.StylePriority.UseBorders = False
        Me.celCurrency.Weight = 0.574449667740393R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Weight = 2.0789203250260595R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3, Me.celExRate, Me.XrTableCell7})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = "Ex. Rate:"
        Me.XrTableCell3.Weight = 0.34663000723354759R
        '
        'celExRate
        '
        Me.celExRate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celExRate.Name = "celExRate"
        Me.celExRate.StylePriority.UseBorders = False
        Me.celExRate.Weight = 0.574449667740393R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Weight = 2.0789203250260595R
        '
        'GroupHeader_BankBranch
        '
        Me.GroupHeader_BankBranch.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.GroupHeader_BankBranch.HeightF = 30.41667!
        Me.GroupHeader_BankBranch.Name = "GroupHeader_BankBranch"
        '
        'XrTable3
        '
        Me.XrTable3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4, Me.XrTableRow6})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(727.0!, 30.41667!)
        Me.XrTable3.StylePriority.UseFont = False
        Me.XrTable3.StylePriority.UsePadding = False
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell6, Me.XrTableCell8, Me.XrTableCell9, Me.XrTableCell10})
        Me.XrTableRow4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.StylePriority.UseBorders = False
        Me.XrTableRow4.StylePriority.UseFont = False
        Me.XrTableRow4.Weight = 0.80833343505859379R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Text = "Bank:"
        Me.XrTableCell6.Weight = 0.6088377625938951R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Text = "Account Number:"
        Me.XrTableCell8.Weight = 0.63462893605396209R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "Beneficiary Name/Account Name:"
        Me.XrTableCell9.Weight = 1.2995182546329627R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StylePriority.UseTextAlignment = False
        Me.XrTableCell10.Text = "Amount:"
        Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell10.Weight = 0.45701504671917992R
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell15})
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.Weight = 0.40833351135253909R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.Weight = 2.9999999999999996R
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable5})
        Me.GroupFooter1.HeightF = 35.83333!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'XrTable5
        '
        Me.XrTable5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTable5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable5.Name = "XrTable5"
        Me.XrTable5.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable5.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow7, Me.XrTableRow8})
        Me.XrTable5.SizeF = New System.Drawing.SizeF(727.0!, 35.83333!)
        Me.XrTable5.StylePriority.UseFont = False
        Me.XrTable5.StylePriority.UsePadding = False
        '
        'XrTableRow7
        '
        Me.XrTableRow7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell13, Me.celSubTotal})
        Me.XrTableRow7.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.StylePriority.UseBorders = False
        Me.XrTableRow7.StylePriority.UseFont = False
        Me.XrTableRow7.Weight = 1.0R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.StylePriority.UseFont = False
        Me.XrTableCell13.StylePriority.UseTextAlignment = False
        Me.XrTableCell13.Text = "Sub Total:"
        Me.XrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell13.Weight = 2.54298495328082R
        '
        'celSubTotal
        '
        Me.celSubTotal.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.celSubTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.celSubTotal.Name = "celSubTotal"
        Me.celSubTotal.StylePriority.UseBorders = False
        Me.celSubTotal.StylePriority.UseFont = False
        Me.celSubTotal.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:#,##0.00}"
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celSubTotal.Summary = XrSummary1
        Me.celSubTotal.Text = "[SubTotal]"
        Me.celSubTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.celSubTotal.Weight = 0.45701504671917992R
        '
        'XrTableRow8
        '
        Me.XrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell12})
        Me.XrTableRow8.Name = "XrTableRow8"
        Me.XrTableRow8.Weight = 0.91111110063033018R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.StylePriority.UseBorders = False
        Me.XrTableCell12.StylePriority.UseFont = False
        Me.XrTableCell12.StylePriority.UseTextAlignment = False
        Me.XrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell12.Weight = 3.0R
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDatePrinted, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 23.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(627.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 18.83334!)
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTable6
        '
        Me.XrTable6.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTable6.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable6.Name = "XrTable6"
        Me.XrTable6.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable6.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow9, Me.XrTableRow10, Me.XrTableRow11})
        Me.XrTable6.SizeF = New System.Drawing.SizeF(727.0!, 56.25!)
        Me.XrTable6.StylePriority.UseFont = False
        Me.XrTable6.StylePriority.UsePadding = False
        '
        'XrTableRow9
        '
        Me.XrTableRow9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell19, Me.XrTableCell11, Me.XrTableCell16, Me.XrTableCell17, Me.XrTableCell18})
        Me.XrTableRow9.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTableRow9.Name = "XrTableRow9"
        Me.XrTableRow9.StylePriority.UseBorders = False
        Me.XrTableRow9.StylePriority.UseFont = False
        Me.XrTableRow9.Weight = 1.0R
        '
        'XrTableCell19
        '
        Me.XrTableCell19.Name = "XrTableCell19"
        Me.XrTableCell19.Text = "Prepared By:"
        Me.XrTableCell19.Weight = 0.84525438122441043R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Weight = 0.12895472866304966R
        '
        'XrTableCell16
        '
        Me.XrTableCell16.Name = "XrTableCell16"
        Me.XrTableCell16.Text = "Verified & Corrected By:"
        Me.XrTableCell16.Weight = 1.0429847486409392R
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.Weight = 0.10746200015817074R
        '
        'XrTableCell18
        '
        Me.XrTableCell18.Name = "XrTableCell18"
        Me.XrTableCell18.StylePriority.UseTextAlignment = False
        Me.XrTableCell18.Text = "Approved By:"
        Me.XrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell18.Weight = 0.87534414131342952R
        '
        'XrTableRow10
        '
        Me.XrTableRow10.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell24})
        Me.XrTableRow10.Name = "XrTableRow10"
        Me.XrTableRow10.Weight = 1.0R
        '
        'XrTableCell24
        '
        Me.XrTableCell24.Name = "XrTableCell24"
        Me.XrTableCell24.StylePriority.UseTextAlignment = False
        Me.XrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell24.Weight = 2.9999999999999996R
        '
        'XrTableRow11
        '
        Me.XrTableRow11.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celPreparedBy, Me.XrTableCell26, Me.celVerifiedBy, Me.XrTableCell28, Me.celApprovedBy})
        Me.XrTableRow11.Name = "XrTableRow11"
        Me.XrTableRow11.Weight = 1.0R
        '
        'celPreparedBy
        '
        Me.celPreparedBy.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.celPreparedBy.Name = "celPreparedBy"
        Me.celPreparedBy.StylePriority.UseBorders = False
        Me.celPreparedBy.Weight = 0.84525438122441043R
        '
        'XrTableCell26
        '
        Me.XrTableCell26.Name = "XrTableCell26"
        Me.XrTableCell26.Weight = 0.12895472866304966R
        '
        'celVerifiedBy
        '
        Me.celVerifiedBy.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.celVerifiedBy.Name = "celVerifiedBy"
        Me.celVerifiedBy.StylePriority.UseBorders = False
        Me.celVerifiedBy.Weight = 1.0429847486409392R
        '
        'XrTableCell28
        '
        Me.XrTableCell28.Name = "XrTableCell28"
        Me.XrTableCell28.Weight = 0.10746200015817074R
        '
        'celApprovedBy
        '
        Me.celApprovedBy.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.celApprovedBy.Name = "celApprovedBy"
        Me.celApprovedBy.StylePriority.UseBorders = False
        Me.celApprovedBy.StylePriority.UseTextAlignment = False
        Me.celApprovedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.celApprovedBy.Weight = 0.87534414131342952R
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable6})
        Me.ReportFooter.HeightF = 72.08334!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable7
        '
        Me.XrTable7.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTable7.LocationFloat = New DevExpress.Utils.PointFloat(0.00002384186!, 0.0!)
        Me.XrTable7.Name = "XrTable7"
        Me.XrTable7.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable7.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow12, Me.XrTableRow13})
        Me.XrTable7.SizeF = New System.Drawing.SizeF(727.0!, 45.83333!)
        Me.XrTable7.StylePriority.UseFont = False
        Me.XrTable7.StylePriority.UsePadding = False
        '
        'XrTableRow12
        '
        Me.XrTableRow12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow12.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.lblGrandTotal, Me.celGrandTotal})
        Me.XrTableRow12.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTableRow12.Name = "XrTableRow12"
        Me.XrTableRow12.StylePriority.UseBorders = False
        Me.XrTableRow12.StylePriority.UseFont = False
        Me.XrTableRow12.Weight = 1.0R
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.StylePriority.UseFont = False
        Me.lblGrandTotal.StylePriority.UseTextAlignment = False
        Me.lblGrandTotal.Text = "Grand Total:"
        Me.lblGrandTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.lblGrandTotal.Weight = 2.54298495328082R
        '
        'celGrandTotal
        '
        Me.celGrandTotal.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.celGrandTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.celGrandTotal.Name = "celGrandTotal"
        Me.celGrandTotal.StylePriority.UseBorders = False
        Me.celGrandTotal.StylePriority.UseFont = False
        Me.celGrandTotal.StylePriority.UseTextAlignment = False
        XrSummary2.FormatString = "{0:#,###.00}"
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celGrandTotal.Summary = XrSummary2
        Me.celGrandTotal.Text = "[GrandTotal]"
        Me.celGrandTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.celGrandTotal.Weight = 0.45701504671917992R
        '
        'XrTableRow13
        '
        Me.XrTableRow13.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell21})
        Me.XrTableRow13.Name = "XrTableRow13"
        Me.XrTableRow13.Weight = 1.4444443766276041R
        '
        'XrTableCell21
        '
        Me.XrTableCell21.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCell21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell21.Name = "XrTableCell21"
        Me.XrTableCell21.StylePriority.UseBorders = False
        Me.XrTableCell21.StylePriority.UseFont = False
        Me.XrTableCell21.StylePriority.UseTextAlignment = False
        Me.XrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell21.Weight = 3.0R
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable7})
        Me.GroupFooter2.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail
        Me.GroupFooter2.HeightF = 45.83333!
        Me.GroupFooter2.Level = 1
        Me.GroupFooter2.Name = "GroupFooter2"
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
        'rptBankReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeader_Principal, Me.GroupHeader_Currency, Me.GroupHeader_BankBranch, Me.GroupFooter1, Me.PageFooter, Me.ReportFooter, Me.GroupFooter2})
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 49)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrTable4 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celBankBranch As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celAccountNumber As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celAccountName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celAmount As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents lblPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCompanyName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupHeader_Principal As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celPrincipal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celDateRemitted As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupHeader_Currency As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCurrency As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celExRate As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupHeader_BankBranch As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrTable5 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celSubTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrTable6 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow10 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow11 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celPreparedBy As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celVerifiedBy As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celApprovedBy As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrTable7 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow12 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents lblGrandTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celGrandTotal As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow13 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lblDatePrinted As DevExpress.XtraReports.UI.XRLabel
End Class
