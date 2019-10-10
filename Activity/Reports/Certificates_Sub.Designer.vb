<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Certificates_Sub
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
        Me.DocNameCert = New DevExpress.XtraReports.UI.XRTableCell()
        Me.NumberCert = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DateIssueCert = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DateExpiryCert = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CountryCert = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CapacityCert = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CompliedCert = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CommentCert = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.DocNameCert, Me.NumberCert, Me.DateIssueCert, Me.DateExpiryCert, Me.CountryCert, Me.CapacityCert, Me.CompliedCert, Me.CommentCert, Me.DocStatusTravel})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.StylePriority.UseBorderWidth = False
        Me.XrTableRow7.Weight = 1.0R
        '
        'DocNameCert
        '
        Me.DocNameCert.BackColor = System.Drawing.Color.Transparent
        Me.DocNameCert.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DocNameCert.ForeColor = System.Drawing.Color.Black
        Me.DocNameCert.Name = "DocNameCert"
        Me.DocNameCert.StylePriority.UseBackColor = False
        Me.DocNameCert.StylePriority.UseFont = False
        Me.DocNameCert.StylePriority.UseForeColor = False
        Me.DocNameCert.Tag = "BIND_DocName"
        Me.DocNameCert.Weight = 0.713104187723757R
        '
        'NumberCert
        '
        Me.NumberCert.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberCert.Name = "NumberCert"
        Me.NumberCert.StylePriority.UseFont = False
        Me.NumberCert.Tag = "BIND_Number"
        Me.NumberCert.Weight = 0.33331223286166528R
        '
        'DateIssueCert
        '
        Me.DateIssueCert.CanGrow = False
        Me.DateIssueCert.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateIssueCert.Name = "DateIssueCert"
        Me.DateIssueCert.StylePriority.UseFont = False
        Me.DateIssueCert.Tag = "BIND_DateIssue"
        Me.DateIssueCert.Weight = 0.33974595132979019R
        '
        'DateExpiryCert
        '
        Me.DateExpiryCert.CanGrow = False
        Me.DateExpiryCert.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateExpiryCert.Name = "DateExpiryCert"
        Me.DateExpiryCert.StylePriority.UseFont = False
        Me.DateExpiryCert.Tag = "BIND_DateExpiry"
        Me.DateExpiryCert.Weight = 0.34355874999752478R
        '
        'CountryCert
        '
        Me.CountryCert.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountryCert.Name = "CountryCert"
        Me.CountryCert.StylePriority.UseFont = False
        Me.CountryCert.StylePriority.UseTextAlignment = False
        Me.CountryCert.Tag = "BIND_Country"
        Me.CountryCert.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CountryCert.Weight = 0.26656408557621741R
        '
        'CapacityCert
        '
        Me.CapacityCert.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityCert.Name = "CapacityCert"
        Me.CapacityCert.StylePriority.UseFont = False
        Me.CapacityCert.StylePriority.UseTextAlignment = False
        Me.CapacityCert.Tag = "BIND_Capacity"
        Me.CapacityCert.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CapacityCert.Weight = 0.27296243462662306R
        '
        'CompliedCert
        '
        Me.CompliedCert.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompliedCert.Name = "CompliedCert"
        Me.CompliedCert.StylePriority.UseFont = False
        Me.CompliedCert.StylePriority.UseTextAlignment = False
        Me.CompliedCert.Tag = "BIND_Complied"
        Me.CompliedCert.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CompliedCert.Weight = 0.30748258768068482R
        '
        'CommentCert
        '
        Me.CommentCert.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommentCert.Name = "CommentCert"
        Me.CommentCert.StylePriority.UseFont = False
        Me.CommentCert.Tag = "BIND_Comment"
        Me.CommentCert.Weight = 0.40215015536946186R
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
        Me.BottomMargin.HeightF = 1.041667!
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
        Me.XrLabel16.Text = "               Certificates"
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
        'Certificates_Sub
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageHeader, Me.GroupHeader_IDNbr, Me.ReportFooter, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(23, 25, 48, 1)
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
    Public WithEvents DocNameCert As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents NumberCert As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DateIssueCert As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DateExpiryCert As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CountryCert As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CapacityCert As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CompliedCert As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CommentCert As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DocStatusTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
End Class
