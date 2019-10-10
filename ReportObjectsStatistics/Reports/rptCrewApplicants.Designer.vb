<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptCrewApplicants
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
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celGroupName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celSubName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.subHeader = New DevExpress.XtraReports.UI.XRSubreport()
        Me.lblSubTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.GroupHeader_GroupName = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celGroupNameHeader = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celSubNameHeader = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrTableFooter = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celTotalCrews = New DevExpress.XtraReports.UI.XRTableCell()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.lblDatePrinted = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTableFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.Detail.HeightF = 16.53646!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable2
        '
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(628.0001!, 16.53646!)
        Me.XrTable2.Tag = "BIND"
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celGroupName, Me.celSubName, Me.XrTableCell7})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'celGroupName
        '
        Me.celGroupName.Font = New System.Drawing.Font("Calibri", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.celGroupName.Name = "celGroupName"
        Me.celGroupName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celGroupName.StylePriority.UseFont = False
        Me.celGroupName.StylePriority.UsePadding = False
        Me.celGroupName.Tag = "BIND_GroupName"
        Me.celGroupName.Weight = 1.0R
        '
        'celSubName
        '
        Me.celSubName.Font = New System.Drawing.Font("Calibri", 8.0!)
        Me.celSubName.Name = "celSubName"
        Me.celSubName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celSubName.StylePriority.UseFont = False
        Me.celSubName.StylePriority.UsePadding = False
        Me.celSubName.Tag = "BIND_SubName"
        Me.celSubName.Weight = 1.0R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Font = New System.Drawing.Font("Calibri", 8.0!)
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.StylePriority.UsePadding = False
        Me.XrTableCell7.Tag = "BIND_CrewCount"
        Me.XrTableCell7.Weight = 1.0047844471573981R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 100.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 49.50002!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTitle, Me.subHeader, Me.lblSubTitle})
        Me.ReportHeader.HeightF = 172.0417!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'xrTitle
        '
        Me.xrTitle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrTitle.LocationFloat = New DevExpress.Utils.PointFloat(1.00015!, 130.0!)
        Me.xrTitle.Name = "xrTitle"
        Me.xrTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTitle.SizeF = New System.Drawing.SizeF(627.0!, 27.04169!)
        Me.xrTitle.StylePriority.UseFont = False
        Me.xrTitle.StylePriority.UseTextAlignment = False
        Me.xrTitle.Text = "CREW APPLICANTS BY AGENT"
        Me.xrTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'subHeader
        '
        Me.subHeader.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.subHeader.Name = "subHeader"
        Me.subHeader.SizeF = New System.Drawing.SizeF(627.0!, 130.0!)
        '
        'lblSubTitle
        '
        Me.lblSubTitle.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblSubTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 157.0417!)
        Me.lblSubTitle.Name = "lblSubTitle"
        Me.lblSubTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSubTitle.SizeF = New System.Drawing.SizeF(627.0!, 15.00002!)
        Me.lblSubTitle.StylePriority.UseFont = False
        Me.lblSubTitle.StylePriority.UseTextAlignment = False
        Me.lblSubTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLine2
        '
        Me.XrLine2.LineWidth = 3
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.9999772!, 0.0!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(627.0!, 13.00001!)
        '
        'GroupHeader_GroupName
        '
        Me.GroupHeader_GroupName.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XrLine2})
        Me.GroupHeader_GroupName.HeightF = 38.0!
        Me.GroupHeader_GroupName.Name = "GroupHeader_GroupName"
        '
        'XrTable1
        '
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.9999772!, 12.99999!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(627.0001!, 25.0!)
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celGroupNameHeader, Me.celSubNameHeader, Me.XrTableCell3})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'celGroupNameHeader
        '
        Me.celGroupNameHeader.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.celGroupNameHeader.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.celGroupNameHeader.Name = "celGroupNameHeader"
        Me.celGroupNameHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celGroupNameHeader.StylePriority.UseBorders = False
        Me.celGroupNameHeader.StylePriority.UseFont = False
        Me.celGroupNameHeader.StylePriority.UsePadding = False
        Me.celGroupNameHeader.Weight = 1.0R
        '
        'celSubNameHeader
        '
        Me.celSubNameHeader.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.celSubNameHeader.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.celSubNameHeader.Name = "celSubNameHeader"
        Me.celSubNameHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celSubNameHeader.StylePriority.UseBorders = False
        Me.celSubNameHeader.StylePriority.UseFont = False
        Me.celSubNameHeader.StylePriority.UsePadding = False
        Me.celSubNameHeader.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell3.StylePriority.UseBorders = False
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UsePadding = False
        Me.XrTableCell3.Text = "No. of Crews"
        Me.XrTableCell3.Weight = 1.0R
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTableFooter})
        Me.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail
        Me.GroupFooter1.HeightF = 25.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrTableFooter
        '
        Me.xrTableFooter.LocationFloat = New DevExpress.Utils.PointFloat(208.0!, 0.0!)
        Me.xrTableFooter.Name = "xrTableFooter"
        Me.xrTableFooter.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.xrTableFooter.SizeF = New System.Drawing.SizeF(420.0001!, 16.53646!)
        Me.xrTableFooter.Tag = "BIND"
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.celTotalCrews})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.StylePriority.UsePadding = False
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "Total No. of Crews:"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell4.Weight = 0.81773293062464458R
        '
        'celTotalCrews
        '
        Me.celTotalCrews.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.celTotalCrews.Name = "celTotalCrews"
        Me.celTotalCrews.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celTotalCrews.StylePriority.UseFont = False
        Me.celTotalCrews.StylePriority.UsePadding = False
        Me.celTotalCrews.StylePriority.UseTextAlignment = False
        Me.celTotalCrews.Tag = "BIND_CrewCount"
        Me.celTotalCrews.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.celTotalCrews.Weight = 0.81773293062464458R
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.lblDatePrinted})
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
        Me.lblDatePrinted.StylePriority.UseTextAlignment = False
        Me.lblDatePrinted.Text = "Date Printed:"
        Me.lblDatePrinted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(528.0001!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'rptCrewApplicants
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.GroupHeader_GroupName, Me.GroupFooter1, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 99, 100, 50)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTableFooter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents xrTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents subHeader As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents lblSubTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents GroupHeader_GroupName As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celSubNameHeader As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celGroupName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celSubName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celGroupNameHeader As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents xrTableFooter As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celTotalCrews As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblDatePrinted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
