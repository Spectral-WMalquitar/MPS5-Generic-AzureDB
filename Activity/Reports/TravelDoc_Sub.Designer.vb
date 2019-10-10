<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class TravelDoc_Sub
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
        Me.DocNameTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.NumberTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DateIssueTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DateExpiryTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CountryTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CapacityTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CompliedTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.CommentTravel = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.DocNameTravel, Me.NumberTravel, Me.DateIssueTravel, Me.DateExpiryTravel, Me.CountryTravel, Me.CapacityTravel, Me.CompliedTravel, Me.CommentTravel, Me.DocStatusTravel})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.StylePriority.UseBorderWidth = False
        Me.XrTableRow7.Weight = 1.0R
        '
        'DocNameTravel
        '
        Me.DocNameTravel.BackColor = System.Drawing.Color.Transparent
        Me.DocNameTravel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DocNameTravel.ForeColor = System.Drawing.Color.Black
        Me.DocNameTravel.Name = "DocNameTravel"
        Me.DocNameTravel.StylePriority.UseBackColor = False
        Me.DocNameTravel.StylePriority.UseFont = False
        Me.DocNameTravel.StylePriority.UseForeColor = False
        Me.DocNameTravel.Tag = "BIND_DocName"
        Me.DocNameTravel.Weight = 0.713104187723757R
        '
        'NumberTravel
        '
        Me.NumberTravel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberTravel.Name = "NumberTravel"
        Me.NumberTravel.StylePriority.UseFont = False
        Me.NumberTravel.Tag = "BIND_Number"
        Me.NumberTravel.Weight = 0.33331223286166528R
        '
        'DateIssueTravel
        '
        Me.DateIssueTravel.CanGrow = False
        Me.DateIssueTravel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateIssueTravel.Name = "DateIssueTravel"
        Me.DateIssueTravel.StylePriority.UseFont = False
        Me.DateIssueTravel.Tag = "BIND_DateIssue"
        Me.DateIssueTravel.Weight = 0.33974595132979019R
        '
        'DateExpiryTravel
        '
        Me.DateExpiryTravel.CanGrow = False
        Me.DateExpiryTravel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateExpiryTravel.Name = "DateExpiryTravel"
        Me.DateExpiryTravel.StylePriority.UseFont = False
        Me.DateExpiryTravel.Tag = "BIND_DateExpiry"
        Me.DateExpiryTravel.Weight = 0.34355874999752478R
        '
        'CountryTravel
        '
        Me.CountryTravel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountryTravel.Name = "CountryTravel"
        Me.CountryTravel.StylePriority.UseFont = False
        Me.CountryTravel.StylePriority.UseTextAlignment = False
        Me.CountryTravel.Tag = "BIND_Country"
        Me.CountryTravel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CountryTravel.Weight = 0.26656408557621741R
        '
        'CapacityTravel
        '
        Me.CapacityTravel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapacityTravel.Name = "CapacityTravel"
        Me.CapacityTravel.StylePriority.UseFont = False
        Me.CapacityTravel.StylePriority.UseTextAlignment = False
        Me.CapacityTravel.Tag = "BIND_Capacity"
        Me.CapacityTravel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CapacityTravel.Weight = 0.27296243462662306R
        '
        'CompliedTravel
        '
        Me.CompliedTravel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompliedTravel.Name = "CompliedTravel"
        Me.CompliedTravel.StylePriority.UseFont = False
        Me.CompliedTravel.StylePriority.UseTextAlignment = False
        Me.CompliedTravel.Tag = "BIND_Complied"
        Me.CompliedTravel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.CompliedTravel.Weight = 0.30748258768068482R
        '
        'CommentTravel
        '
        Me.CommentTravel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommentTravel.Name = "CommentTravel"
        Me.CommentTravel.StylePriority.UseFont = False
        Me.CommentTravel.Tag = "BIND_Comment"
        Me.CommentTravel.Weight = 0.40215015536946186R
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
        Me.XrLabel16.Text = "               Travel"
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
        'TravelDoc_Sub
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
    Public WithEvents DocNameTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents NumberTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DateIssueTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DateExpiryTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CountryTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CapacityTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CompliedTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CommentTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DocStatusTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
End Class
