<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class NationalInformation_Sub
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
        Me.XrTable7 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.DocNameNatReq = New DevExpress.XtraReports.UI.XRTableCell()
        Me.NumberNatReq = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DateIssueNatReq = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DateExpiryNatReq = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CountryNatReq = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CapacityNatReq = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CompliedNatReq = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CommentNatReq = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DocStatusTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.GroupHeader_IDNbr = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        CType(Me.XrTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable7})
        Me.Detail.HeightF = 15.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable7
        '
        Me.XrTable7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTable7.LocationFloat = New DevExpress.Utils.PointFloat(53.54201!, 0.0!)
        Me.XrTable7.Name = "XrTable7"
        Me.XrTable7.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable7.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow7})
        Me.XrTable7.SizeF = New System.Drawing.SizeF(748.4581!, 15.0!)
        Me.XrTable7.StylePriority.UseBorders = False
        Me.XrTable7.StylePriority.UsePadding = False
        '
        'XrTableRow7
        '
        Me.XrTableRow7.BorderWidth = 0.5!
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.DocNameNatReq, Me.NumberNatReq, Me.DateIssueNatReq, Me.DateExpiryNatReq, Me.CountryNatReq, Me.CapacityNatReq, Me.CompliedNatReq, Me.CommentNatReq, Me.DocStatusTravel})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.StylePriority.UseBorderWidth = False
        Me.XrTableRow7.Weight = 1.0R
        '
        'DocNameNatReq
        '
        Me.DocNameNatReq.BackColor = System.Drawing.Color.Transparent
        Me.DocNameNatReq.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DocNameNatReq.ForeColor = System.Drawing.Color.Black
        Me.DocNameNatReq.Name = "DocNameNatReq"
        Me.DocNameNatReq.StylePriority.UseBackColor = False
        Me.DocNameNatReq.StylePriority.UseFont = False
        Me.DocNameNatReq.StylePriority.UseForeColor = False
        Me.DocNameNatReq.Tag = "BIND_DocName"
        Me.DocNameNatReq.Weight = 0.713104187723757R
        '
        'NumberNatReq
        '
        Me.NumberNatReq.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberNatReq.Name = "NumberNatReq"
        Me.NumberNatReq.StylePriority.UseFont = False
        Me.NumberNatReq.Tag = "BIND_Number"
        Me.NumberNatReq.Weight = 0.33331223286166528R
        '
        'DateIssueNatReq
        '
        Me.DateIssueNatReq.CanGrow = False
        Me.DateIssueNatReq.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateIssueNatReq.Name = "DateIssueNatReq"
        Me.DateIssueNatReq.StylePriority.UseFont = False
        Me.DateIssueNatReq.Tag = "BIND_DateIssue"
        Me.DateIssueNatReq.Weight = 0.33974595132979019R
        '
        'DateExpiryNatReq
        '
        Me.DateExpiryNatReq.CanGrow = False
        Me.DateExpiryNatReq.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateExpiryNatReq.Name = "DateExpiryNatReq"
        Me.DateExpiryNatReq.StylePriority.UseFont = False
        Me.DateExpiryNatReq.Tag = "BIND_DateExpiry"
        Me.DateExpiryNatReq.Weight = 0.34355874999752478R
        '
        'CountryNatReq
        '
        Me.CountryNatReq.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountryNatReq.Name = "CountryNatReq"
        Me.CountryNatReq.StylePriority.UseFont = False
        Me.CountryNatReq.StylePriority.UseTextAlignment = False
        Me.CountryNatReq.Tag = "BIND_Country"
        Me.CountryNatReq.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CountryNatReq.Weight = 0.26656408557621741R
        '
        'CapacityNatReq
        '
        Me.CapacityNatReq.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityNatReq.Name = "CapacityNatReq"
        Me.CapacityNatReq.StylePriority.UseFont = False
        Me.CapacityNatReq.StylePriority.UseTextAlignment = False
        Me.CapacityNatReq.Tag = "BIND_Capacity"
        Me.CapacityNatReq.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CapacityNatReq.Weight = 0.27296243462662306R
        '
        'CompliedNatReq
        '
        Me.CompliedNatReq.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompliedNatReq.Name = "CompliedNatReq"
        Me.CompliedNatReq.StylePriority.UseFont = False
        Me.CompliedNatReq.StylePriority.UseTextAlignment = False
        Me.CompliedNatReq.Tag = "BIND_Complied"
        Me.CompliedNatReq.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CompliedNatReq.Weight = 0.30748258768068482R
        '
        'CommentNatReq
        '
        Me.CommentNatReq.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommentNatReq.Name = "CommentNatReq"
        Me.CommentNatReq.StylePriority.UseFont = False
        Me.CommentNatReq.Tag = "BIND_Comment"
        Me.CommentNatReq.Weight = 0.40215015536946186R
        '
        'DocStatusTravel
        '
        Me.DocStatusTravel.Name = "DocStatusTravel"
        Me.DocStatusTravel.Visible = False
        Me.DocStatusTravel.Weight = 0.0059810154130772513R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 47.91667!
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
        'ReportHeader
        '
        Me.ReportHeader.HeightF = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'PageHeader
        '
        Me.PageHeader.HeightF = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'GroupHeader_IDNbr
        '
        Me.GroupHeader_IDNbr.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel16})
        Me.GroupHeader_IDNbr.HeightF = 19.16667!
        Me.GroupHeader_IDNbr.Name = "GroupHeader_IDNbr"
        '
        'XrLabel16
        '
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel16.BorderWidth = 0.0!
        Me.XrLabel16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(53.542!, 0.0!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(748.458!, 19.16667!)
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseBorderWidth = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.StylePriority.UseTextAlignment = False
        Me.XrLabel16.Text = "               National Requirements"
        Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5})
        Me.ReportFooter.HeightF = 19.16668!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel5
        '
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 19.16668!)
        '
        'PageFooter
        '
        Me.PageFooter.HeightF = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'NationalInformation_Sub
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageHeader, Me.GroupHeader_IDNbr, Me.ReportFooter, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(23, 25, 48, 0)
        Me.Version = "14.2"
        CType(Me.XrTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents GroupHeader_IDNbr As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable7 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Public WithEvents DocNameNatReq As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents NumberNatReq As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DateIssueNatReq As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DateExpiryNatReq As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CountryNatReq As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CapacityNatReq As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CompliedNatReq As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CommentNatReq As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DocStatusTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
End Class
