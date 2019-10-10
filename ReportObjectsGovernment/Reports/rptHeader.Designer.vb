<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptHeader
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
        Me.txtTelFax = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtCompAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtTelFax, Me.txtCompAddress, Me.XrPictureBox1})
        Me.Detail.HeightF = 105.0417!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtTelFax
        '
        Me.txtTelFax.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtTelFax.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 90.04169!)
        Me.txtTelFax.Name = "txtTelFax"
        Me.txtTelFax.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtTelFax.SizeF = New System.Drawing.SizeF(650.0!, 15.0!)
        Me.txtTelFax.StylePriority.UseFont = False
        Me.txtTelFax.StylePriority.UseTextAlignment = False
        Me.txtTelFax.Text = "Tel. Fax E-mail: Telex:"
        Me.txtTelFax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'txtCompAddress
        '
        Me.txtCompAddress.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtCompAddress.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 74.04169!)
        Me.txtCompAddress.Name = "txtCompAddress"
        Me.txtCompAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCompAddress.SizeF = New System.Drawing.SizeF(650.0!, 16.0!)
        Me.txtCompAddress.StylePriority.UseFont = False
        Me.txtCompAddress.StylePriority.UseTextAlignment = False
        Me.txtCompAddress.Text = "txtCompAddress"
        Me.txtCompAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(221.875!, 0.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(201.0417!, 74.04167!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
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
        Me.BottomMargin.HeightF = 26.04167!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'rptHeader
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 100, 26)
        Me.Version = "14.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents txtTelFax As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtCompAddress As DevExpress.XtraReports.UI.XRLabel
End Class
