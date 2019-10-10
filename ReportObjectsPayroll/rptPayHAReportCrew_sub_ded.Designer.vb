<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPayHAReportCrew_sub_ded
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
        Me.txtItemDedAmt = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtDedItem = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.txtItemDedAmtSum = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtItemDedAmt, Me.txtDedItem})
        Me.Detail.HeightF = 19.08334!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtItemDedAmt
        '
        Me.txtItemDedAmt.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtItemDedAmt.LocationFloat = New DevExpress.Utils.PointFloat(216.625!, 0.0!)
        Me.txtItemDedAmt.Name = "txtItemDedAmt"
        Me.txtItemDedAmt.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtItemDedAmt.SizeF = New System.Drawing.SizeF(108.3333!, 14.91667!)
        Me.txtItemDedAmt.StylePriority.UseFont = False
        Me.txtItemDedAmt.StylePriority.UseTextAlignment = False
        Me.txtItemDedAmt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'txtDedItem
        '
        Me.txtDedItem.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtDedItem.LocationFloat = New DevExpress.Utils.PointFloat(14.5833!, 0.0!)
        Me.txtDedItem.Name = "txtDedItem"
        Me.txtDedItem.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtDedItem.SizeF = New System.Drawing.SizeF(201.0417!, 14.91667!)
        Me.txtDedItem.StylePriority.UseFont = False
        Me.txtDedItem.Text = "txtDedItem"
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
        Me.BottomMargin.HeightF = 0.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtItemDedAmtSum, Me.XrLabel1, Me.XrLine1})
        Me.ReportFooter.HeightF = 19.79167!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'txtItemDedAmtSum
        '
        Me.txtItemDedAmtSum.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtItemDedAmtSum.LocationFloat = New DevExpress.Utils.PointFloat(227.0416!, 2.0!)
        Me.txtItemDedAmtSum.Name = "txtItemDedAmtSum"
        Me.txtItemDedAmtSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtItemDedAmtSum.SizeF = New System.Drawing.SizeF(97.91667!, 14.91667!)
        Me.txtItemDedAmtSum.StylePriority.UseFont = False
        Me.txtItemDedAmtSum.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:#,##0.00}"
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RunningSum
        Me.txtItemDedAmtSum.Summary = XrSummary1
        Me.txtItemDedAmtSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 2.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(215.625!, 14.91667!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "Total Deduction :"
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(332.5625!, 2.0!)
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel19})
        Me.ReportHeader.HeightF = 23.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel19
        '
        Me.XrLabel19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(121.875!, 23.0!)
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.StylePriority.UseTextAlignment = False
        Me.XrLabel19.Text = "DEDUCTIONS :"
        Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'rptPayHAReportCrew_sub_ded
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter, Me.ReportHeader})
        Me.Margins = New System.Drawing.Printing.Margins(100, 414, 0, 0)
        Me.Version = "14.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents txtItemDedAmt As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtDedItem As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents txtItemDedAmtSum As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
End Class
