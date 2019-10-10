<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPayHAReportCrewPerVsl
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.txtSignPos = New DevExpress.XtraReports.UI.XRLabel()
        Me.SubRNetSum = New DevExpress.XtraReports.UI.XRSubreport()
        Me.SubRTotDed = New DevExpress.XtraReports.UI.XRSubreport()
        Me.SubRTotEarn = New DevExpress.XtraReports.UI.XRSubreport()
        Me.txtSignName = New DevExpress.XtraReports.UI.XRLabel()
        Me.subRDed = New DevExpress.XtraReports.UI.XRSubreport()
        Me.subREarn = New DevExpress.XtraReports.UI.XRSubreport()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.txtAllotUSD = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAllotUSD_lbl = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtExRate_lbl = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtExRate = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAllotPHP_lbl = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAllotPHP = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.txtCoyAdd = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtCompany = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtCrewName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtVesselName = New DevExpress.XtraReports.UI.XRLabel()
        Me.CrewGroup = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.txtAllotteeAdd = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAllottee = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtBankCurrency = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAcctNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtBank = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtFleet = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        Me.CrewFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.allotteegroup = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.mcodegroup = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.GroupFooter3 = New DevExpress.XtraReports.UI.GroupFooterBand()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtSignPos, Me.SubRNetSum, Me.SubRTotDed, Me.SubRTotEarn, Me.txtSignName, Me.subRDed, Me.subREarn, Me.XrLabel2, Me.XrLine1, Me.txtAllotUSD, Me.txtAllotUSD_lbl, Me.txtExRate_lbl, Me.txtExRate, Me.txtAllotPHP_lbl, Me.txtAllotPHP})
        Me.Detail.HeightF = 370.8125!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtSignPos
        '
        Me.txtSignPos.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtSignPos.LocationFloat = New DevExpress.Utils.PointFloat(486.4618!, 348.8125!)
        Me.txtSignPos.Name = "txtSignPos"
        Me.txtSignPos.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtSignPos.SizeF = New System.Drawing.SizeF(216.6668!, 20.0!)
        Me.txtSignPos.StylePriority.UseFont = False
        Me.txtSignPos.StylePriority.UseTextAlignment = False
        Me.txtSignPos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'SubRNetSum
        '
        Me.SubRNetSum.LocationFloat = New DevExpress.Utils.PointFloat(10.00015!, 169.83!)
        Me.SubRNetSum.Name = "SubRNetSum"
        Me.SubRNetSum.SizeF = New System.Drawing.SizeF(331.9878!, 15.0!)
        '
        'SubRTotDed
        '
        Me.SubRTotDed.LocationFloat = New DevExpress.Utils.PointFloat(10.00015!, 144.83!)
        Me.SubRTotDed.Name = "SubRTotDed"
        Me.SubRTotDed.SizeF = New System.Drawing.SizeF(331.9878!, 15.0!)
        '
        'SubRTotEarn
        '
        Me.SubRTotEarn.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 129.83!)
        Me.SubRTotEarn.Name = "SubRTotEarn"
        Me.SubRTotEarn.SizeF = New System.Drawing.SizeF(331.9878!, 15.0!)
        '
        'txtSignName
        '
        Me.txtSignName.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtSignName.LocationFloat = New DevExpress.Utils.PointFloat(486.4618!, 322.7291!)
        Me.txtSignName.Name = "txtSignName"
        Me.txtSignName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtSignName.SizeF = New System.Drawing.SizeF(216.6668!, 23.0!)
        Me.txtSignName.StylePriority.UseFont = False
        Me.txtSignName.StylePriority.UseTextAlignment = False
        Me.txtSignName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'subRDed
        '
        Me.subRDed.LocationFloat = New DevExpress.Utils.PointFloat(373.5!, 9.999974!)
        Me.subRDed.Name = "subRDed"
        Me.subRDed.SizeF = New System.Drawing.SizeF(320.5317!, 298.7884!)
        '
        'subREarn
        '
        Me.subREarn.LocationFloat = New DevExpress.Utils.PointFloat(10.00015!, 104.83!)
        Me.subREarn.Name = "subREarn"
        Me.subREarn.SizeF = New System.Drawing.SizeF(331.9878!, 15.0!)
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(373.5!, 324.8125!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(102.269!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "PREPARED BY:"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(486.4618!, 345.7292!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(216.6668!, 2.083336!)
        '
        'txtAllotUSD
        '
        Me.txtAllotUSD.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtAllotUSD.LocationFloat = New DevExpress.Utils.PointFloat(218.7207!, 9.999974!)
        Me.txtAllotUSD.Name = "txtAllotUSD"
        Me.txtAllotUSD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAllotUSD.SizeF = New System.Drawing.SizeF(123.2672!, 23.0!)
        Me.txtAllotUSD.StylePriority.UseFont = False
        Me.txtAllotUSD.StylePriority.UseTextAlignment = False
        Me.txtAllotUSD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'txtAllotUSD_lbl
        '
        Me.txtAllotUSD_lbl.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtAllotUSD_lbl.LocationFloat = New DevExpress.Utils.PointFloat(10.00015!, 10.00001!)
        Me.txtAllotUSD_lbl.Name = "txtAllotUSD_lbl"
        Me.txtAllotUSD_lbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAllotUSD_lbl.SizeF = New System.Drawing.SizeF(121.875!, 23.0!)
        Me.txtAllotUSD_lbl.StylePriority.UseFont = False
        Me.txtAllotUSD_lbl.StylePriority.UseTextAlignment = False
        Me.txtAllotUSD_lbl.Text = "ALLOTMENT (US$)"
        Me.txtAllotUSD_lbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtExRate_lbl
        '
        Me.txtExRate_lbl.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtExRate_lbl.LocationFloat = New DevExpress.Utils.PointFloat(10.00015!, 32.99999!)
        Me.txtExRate_lbl.Name = "txtExRate_lbl"
        Me.txtExRate_lbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtExRate_lbl.SizeF = New System.Drawing.SizeF(121.875!, 23.0!)
        Me.txtExRate_lbl.StylePriority.UseFont = False
        Me.txtExRate_lbl.StylePriority.UseTextAlignment = False
        Me.txtExRate_lbl.Text = "USD Exchange Rate"
        Me.txtExRate_lbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtExRate
        '
        Me.txtExRate.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtExRate.LocationFloat = New DevExpress.Utils.PointFloat(218.7207!, 32.99999!)
        Me.txtExRate.Name = "txtExRate"
        Me.txtExRate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtExRate.SizeF = New System.Drawing.SizeF(123.2672!, 23.0!)
        Me.txtExRate.StylePriority.UseFont = False
        Me.txtExRate.StylePriority.UseTextAlignment = False
        Me.txtExRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'txtAllotPHP_lbl
        '
        Me.txtAllotPHP_lbl.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtAllotPHP_lbl.LocationFloat = New DevExpress.Utils.PointFloat(10.00015!, 56.00001!)
        Me.txtAllotPHP_lbl.Name = "txtAllotPHP_lbl"
        Me.txtAllotPHP_lbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAllotPHP_lbl.SizeF = New System.Drawing.SizeF(121.875!, 23.0!)
        Me.txtAllotPHP_lbl.StylePriority.UseFont = False
        Me.txtAllotPHP_lbl.StylePriority.UseTextAlignment = False
        Me.txtAllotPHP_lbl.Text = "ALLOTMENT (PHP)"
        Me.txtAllotPHP_lbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtAllotPHP
        '
        Me.txtAllotPHP.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtAllotPHP.LocationFloat = New DevExpress.Utils.PointFloat(218.7207!, 56.00001!)
        Me.txtAllotPHP.Name = "txtAllotPHP"
        Me.txtAllotPHP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAllotPHP.SizeF = New System.Drawing.SizeF(123.2672!, 23.0!)
        Me.txtAllotPHP.StylePriority.UseFont = False
        Me.txtAllotPHP.StylePriority.UseTextAlignment = False
        Me.txtAllotPHP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
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
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.HeightF = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'txtCoyAdd
        '
        Me.txtCoyAdd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtCoyAdd.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 22.04165!)
        Me.txtCoyAdd.Name = "txtCoyAdd"
        Me.txtCoyAdd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCoyAdd.SizeF = New System.Drawing.SizeF(727.0!, 22.04166!)
        Me.txtCoyAdd.StylePriority.UseFont = False
        Me.txtCoyAdd.StylePriority.UseTextAlignment = False
        Me.txtCoyAdd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txtCompany
        '
        Me.txtCompany.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtCompany.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCompany.SizeF = New System.Drawing.SizeF(727.0!, 22.04166!)
        Me.txtCompany.StylePriority.UseFont = False
        Me.txtCompany.StylePriority.UseTextAlignment = False
        Me.txtCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txtCrewName
        '
        Me.txtCrewName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtCrewName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtCrewName.LocationFloat = New DevExpress.Utils.PointFloat(112.4289!, 8.406147!)
        Me.txtCrewName.Name = "txtCrewName"
        Me.txtCrewName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCrewName.SizeF = New System.Drawing.SizeF(229.5589!, 23.0!)
        Me.txtCrewName.StylePriority.UseBorders = False
        Me.txtCrewName.StylePriority.UseFont = False
        Me.txtCrewName.StylePriority.UseTextAlignment = False
        Me.txtCrewName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 62.37516!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(727.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Allottee Payslip"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txtVesselName
        '
        Me.txtVesselName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtVesselName.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtVesselName.LocationFloat = New DevExpress.Utils.PointFloat(60.17712!, 31.80205!)
        Me.txtVesselName.Name = "txtVesselName"
        Me.txtVesselName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtVesselName.SizeF = New System.Drawing.SizeF(293.3228!, 23.0!)
        Me.txtVesselName.StylePriority.UseBorders = False
        Me.txtVesselName.StylePriority.UseFont = False
        Me.txtVesselName.StylePriority.UseTextAlignment = False
        Me.txtVesselName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'CrewGroup
        '
        Me.CrewGroup.HeightF = 0.0!
        Me.CrewGroup.Level = 1
        Me.CrewGroup.Name = "CrewGroup"
        '
        'XrTable4
        '
        Me.XrTable4.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 108.3752!)
        Me.XrTable4.Name = "XrTable4"
        Me.XrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XrTableRow5})
        Me.XrTable4.SizeF = New System.Drawing.SizeF(727.0!, 130.2084!)
        Me.XrTable4.StylePriority.UseBorders = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell6, Me.XrTableCell7})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtAllotteeAdd, Me.txtAllottee})
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Text = "XrTableCell6"
        Me.XrTableCell6.Weight = 1.0R
        '
        'txtAllotteeAdd
        '
        Me.txtAllotteeAdd.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtAllotteeAdd.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtAllotteeAdd.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 31.70843!)
        Me.txtAllotteeAdd.Name = "txtAllotteeAdd"
        Me.txtAllotteeAdd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAllotteeAdd.SizeF = New System.Drawing.SizeF(331.9878!, 23.0!)
        Me.txtAllotteeAdd.StylePriority.UseBorders = False
        Me.txtAllotteeAdd.StylePriority.UseFont = False
        Me.txtAllotteeAdd.StylePriority.UseTextAlignment = False
        Me.txtAllotteeAdd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtAllottee
        '
        Me.txtAllottee.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtAllottee.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtAllottee.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 7.208443!)
        Me.txtAllottee.Name = "txtAllottee"
        Me.txtAllottee.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAllottee.SizeF = New System.Drawing.SizeF(331.9878!, 23.0!)
        Me.txtAllottee.StylePriority.UseBorders = False
        Me.txtAllottee.StylePriority.UseFont = False
        Me.txtAllottee.StylePriority.UseTextAlignment = False
        Me.txtAllottee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel4, Me.txtBankCurrency, Me.XrLabel12, Me.XrLabel13, Me.txtAcctNo, Me.txtBank})
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Text = "XrTableCell7"
        Me.XrTableCell7.Weight = 1.0R
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(239.229!, 32.10421!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(72.56445!, 23.0!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "CURRENCY:"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtBankCurrency
        '
        Me.txtBankCurrency.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtBankCurrency.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtBankCurrency.LocationFloat = New DevExpress.Utils.PointFloat(311.7935!, 32.1042!)
        Me.txtBankCurrency.Name = "txtBankCurrency"
        Me.txtBankCurrency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtBankCurrency.SizeF = New System.Drawing.SizeF(41.70654!, 23.0!)
        Me.txtBankCurrency.StylePriority.UseBorders = False
        Me.txtBankCurrency.StylePriority.UseFont = False
        Me.txtBankCurrency.StylePriority.UseTextAlignment = False
        Me.txtBankCurrency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 7.208443!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(95.0629!, 23.0!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "BANK/BRANCH  :"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 31.80211!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(103.3021!, 23.0!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Account Number  :"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtAcctNo
        '
        Me.txtAcctNo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtAcctNo.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtAcctNo.LocationFloat = New DevExpress.Utils.PointFloat(113.3021!, 31.80211!)
        Me.txtAcctNo.Name = "txtAcctNo"
        Me.txtAcctNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAcctNo.SizeF = New System.Drawing.SizeF(125.9269!, 23.0!)
        Me.txtAcctNo.StylePriority.UseBorders = False
        Me.txtAcctNo.StylePriority.UseFont = False
        Me.txtAcctNo.StylePriority.UseTextAlignment = False
        Me.txtAcctNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtBank
        '
        Me.txtBank.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtBank.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtBank.LocationFloat = New DevExpress.Utils.PointFloat(105.0629!, 7.208443!)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtBank.SizeF = New System.Drawing.SizeF(248.4371!, 23.00001!)
        Me.txtBank.StylePriority.UseBorders = False
        Me.txtBank.StylePriority.UseFont = False
        Me.txtBank.StylePriority.UseTextAlignment = False
        Me.txtBank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell9, Me.XrTableCell10})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.0R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel14, Me.XrLabel15, Me.txtRank, Me.txtCrewName})
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "XrTableCell9"
        Me.XrTableCell9.Weight = 1.0R
        '
        'XrLabel14
        '
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel14.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 31.40616!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(102.4289!, 23.0!)
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "POSITION  :"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel15
        '
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 8.406185!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(102.4289!, 23.00001!)
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "NAME OF CREW  :"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtRank
        '
        Me.txtRank.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtRank.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtRank.LocationFloat = New DevExpress.Utils.PointFloat(112.4289!, 31.40616!)
        Me.txtRank.Name = "txtRank"
        Me.txtRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtRank.SizeF = New System.Drawing.SizeF(229.559!, 23.0!)
        Me.txtRank.StylePriority.UseBorders = False
        Me.txtRank.StylePriority.UseFont = False
        Me.txtRank.StylePriority.UseTextAlignment = False
        Me.txtRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel10, Me.txtFleet, Me.txtVesselName})
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "XrTableCell10"
        Me.XrTableCell10.Weight = 1.0R
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 7.208401!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(50.17712!, 23.00001!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Fleet  :"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 31.80207!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(50.17712!, 23.0!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Vessel  :"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtFleet
        '
        Me.txtFleet.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.txtFleet.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtFleet.LocationFloat = New DevExpress.Utils.PointFloat(60.17712!, 7.208405!)
        Me.txtFleet.Name = "txtFleet"
        Me.txtFleet.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtFleet.SizeF = New System.Drawing.SizeF(293.3228!, 23.00002!)
        Me.txtFleet.StylePriority.UseBorders = False
        Me.txtFleet.StylePriority.UseFont = False
        Me.txtFleet.StylePriority.UseTextAlignment = False
        Me.txtFleet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'txtPeriod
        '
        Me.txtPeriod.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtPeriod.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 85.37515!)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtPeriod.SizeF = New System.Drawing.SizeF(727.0!, 23.0!)
        Me.txtPeriod.StylePriority.UseFont = False
        Me.txtPeriod.StylePriority.UseTextAlignment = False
        Me.txtPeriod.Text = "For the month of:"
        Me.txtPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'FormattingRule1
        '
        Me.FormattingRule1.Name = "FormattingRule1"
        '
        'CrewFooter
        '
        Me.CrewFooter.HeightF = 0.0!
        Me.CrewFooter.Level = 1
        Me.CrewFooter.Name = "CrewFooter"
        Me.CrewFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
        Me.CrewFooter.PrintAtBottom = True
        '
        'allotteegroup
        '
        Me.allotteegroup.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtPeriod, Me.XrLabel1, Me.XrTable4, Me.txtCoyAdd, Me.txtCompany})
        Me.allotteegroup.HeightF = 238.5836!
        Me.allotteegroup.Name = "allotteegroup"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.HeightF = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
        '
        'mcodegroup
        '
        Me.mcodegroup.HeightF = 0.0!
        Me.mcodegroup.Level = 2
        Me.mcodegroup.Name = "mcodegroup"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.HeightF = 0.0!
        Me.GroupFooter2.Level = 2
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.HeightF = 0.0!
        Me.GroupFooter3.Level = 3
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'rptPayHAReportCrew
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.CrewGroup, Me.CrewFooter, Me.allotteegroup, Me.GroupFooter1, Me.mcodegroup, Me.GroupFooter2, Me.GroupFooter3})
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "14.2"
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtVesselName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtCompany As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtCrewName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents CrewGroup As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents CrewFooter As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents txtCoyAdd As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable4 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents txtPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents subRDed As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents subREarn As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents txtAllotteeAdd As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAllottee As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAcctNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtBank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtFleet As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAllotPHP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAllotPHP_lbl As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtExRate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtExRate_lbl As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAllotUSD_lbl As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAllotUSD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtSignName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents allotteegroup As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents SubRTotEarn As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents SubRTotDed As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents SubRNetSum As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents mcodegroup As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents GroupFooter3 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtBankCurrency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtSignPos As DevExpress.XtraReports.UI.XRLabel
End Class
