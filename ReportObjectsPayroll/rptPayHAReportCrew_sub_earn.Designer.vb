<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPayHAReportCrew_sub_earn
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
        Me.txtEarnItem = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtItemEarnAmt = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtItemEarnAmtSum = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtEarnItem, Me.txtItemEarnAmt})
        Me.Detail.HeightF = 17.00001!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtEarnItem
        '
        Me.txtEarnItem.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtEarnItem.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 0.0!)
        Me.txtEarnItem.Name = "txtEarnItem"
        Me.txtEarnItem.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtEarnItem.SizeF = New System.Drawing.SizeF(215.625!, 14.91667!)
        Me.txtEarnItem.StylePriority.UseFont = False
        Me.txtEarnItem.Text = "txtEarnItem"
        '
        'txtItemEarnAmt
        '
        Me.txtItemEarnAmt.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtItemEarnAmt.LocationFloat = New DevExpress.Utils.PointFloat(231.2083!, 0.0!)
        Me.txtItemEarnAmt.Name = "txtItemEarnAmt"
        Me.txtItemEarnAmt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtItemEarnAmt.SizeF = New System.Drawing.SizeF(97.91667!, 14.91667!)
        Me.txtItemEarnAmt.StylePriority.UseFont = False
        Me.txtItemEarnAmt.StylePriority.UseTextAlignment = False
        Me.txtItemEarnAmt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 0.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 5.208333!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XrLabel1, Me.txtItemEarnAmtSum})
        Me.ReportFooter.HeightF = 28.125!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(332.5625!, 2.0!)
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 2.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(215.625!, 14.91667!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "Total Other Earning :"
        '
        'txtItemEarnAmtSum
        '
        Me.txtItemEarnAmtSum.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtItemEarnAmtSum.LocationFloat = New DevExpress.Utils.PointFloat(231.2083!, 2.0!)
        Me.txtItemEarnAmtSum.Name = "txtItemEarnAmtSum"
        Me.txtItemEarnAmtSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtItemEarnAmtSum.SizeF = New System.Drawing.SizeF(97.91667!, 14.91667!)
        Me.txtItemEarnAmtSum.StylePriority.UseFont = False
        Me.txtItemEarnAmtSum.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:#,##0.00}"
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum
        Me.txtItemEarnAmtSum.Summary = XrSummary1
        Me.txtItemEarnAmtSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel17})
        Me.ReportHeader.HeightF = 23.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel17
        '
        Me.XrLabel17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(121.875!, 23.0!)
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.StylePriority.UseTextAlignment = False
        Me.XrLabel17.Text = "OTHER EARNINGS :"
        Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'rptPayHAReportCrew_sub_earn
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter, Me.ReportHeader})
        Me.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Margins = New System.Drawing.Printing.Margins(100, 399, 0, 5)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents txtItemEarnAmt As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtEarnItem As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents txtItemEarnAmtSum As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
End Class
