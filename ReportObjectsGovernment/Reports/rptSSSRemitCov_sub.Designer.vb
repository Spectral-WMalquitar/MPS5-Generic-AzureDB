<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSSSRemitCov_sub
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
        Me.celFamName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celGivName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celMI = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celSSNo = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celSS = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celEC = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celRMRK = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celDTHRD = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.Detail.HeightF = 17.70833!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(650.0001!, 17.70833!)
        Me.XrTable2.StylePriority.UseFont = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celFamName, Me.celGivName, Me.celMI, Me.celSSNo, Me.celSS, Me.celEC, Me.celRMRK, Me.celDTHRD})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'celFamName
        '
        Me.celFamName.Name = "celFamName"
        Me.celFamName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.celFamName.StylePriority.UsePadding = False
        Me.celFamName.Weight = 0.4519229119010037R
        '
        'celGivName
        '
        Me.celGivName.Name = "celGivName"
        Me.celGivName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.celGivName.StylePriority.UsePadding = False
        Me.celGivName.Weight = 0.48076936555583782R
        '
        'celMI
        '
        Me.celMI.Name = "celMI"
        Me.celMI.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.celMI.StylePriority.UsePadding = False
        Me.celMI.Weight = 0.20192315678503842R
        '
        'celSSNo
        '
        Me.celSSNo.Name = "celSSNo"
        Me.celSSNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.celSSNo.StylePriority.UsePadding = False
        Me.celSSNo.Weight = 0.4134611129855314R
        '
        'celSS
        '
        Me.celSS.Name = "celSS"
        Me.celSS.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.celSS.StylePriority.UsePadding = False
        Me.celSS.StylePriority.UseTextAlignment = False
        Me.celSS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.celSS.Weight = 0.3028850185323716R
        '
        'celEC
        '
        Me.celEC.Name = "celEC"
        Me.celEC.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.celEC.StylePriority.UsePadding = False
        Me.celEC.StylePriority.UseTextAlignment = False
        Me.celEC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.celEC.Weight = 0.29326930342682556R
        '
        'celRMRK
        '
        Me.celRMRK.Name = "celRMRK"
        Me.celRMRK.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.celRMRK.StylePriority.UsePadding = False
        Me.celRMRK.StylePriority.UseTextAlignment = False
        Me.celRMRK.Text = "N"
        Me.celRMRK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.celRMRK.Weight = 0.38942320756101467R
        '
        'celDTHRD
        '
        Me.celDTHRD.Name = "celDTHRD"
        Me.celDTHRD.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100.0!)
        Me.celDTHRD.StylePriority.UsePadding = False
        Me.celDTHRD.Text = "0"
        Me.celDTHRD.Weight = 0.46634628148046192R
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
        'FormattingRule1
        '
        Me.FormattingRule1.Name = "FormattingRule1"
        '
        'rptSSSRemitCov_sub
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 0, 0)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celFamName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celGivName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celMI As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celSSNo As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celEC As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celRMRK As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celDTHRD As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celSS As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
End Class
