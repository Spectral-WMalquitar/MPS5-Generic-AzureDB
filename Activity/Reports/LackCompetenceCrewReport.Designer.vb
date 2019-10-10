<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class LackCompetenceCrewReport
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
        Me.XrPageBreak1 = New DevExpress.XtraReports.UI.XRPageBreak()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrTable7 = New DevExpress.XtraReports.UI.XRTable()
        Me.FormatDocStatusTravel = New DevExpress.XtraReports.UI.FormattingRule()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.CrewName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.Rank = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DocStatusTravel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.Sub_VesselType = New DevExpress.XtraReports.UI.XRSubreport()
        Me.Sub_CompanyDefined = New DevExpress.XtraReports.UI.XRSubreport()
        Me.Sub_NationalInformation = New DevExpress.XtraReports.UI.XRSubreport()
        Me.Sub_Medical = New DevExpress.XtraReports.UI.XRSubreport()
        Me.Sub_Courses = New DevExpress.XtraReports.UI.XRSubreport()
        Me.Sub_Certificates = New DevExpress.XtraReports.UI.XRSubreport()
        Me.Sub_Travel = New DevExpress.XtraReports.UI.XRSubreport()
        Me.Medical_Sub2 = New Activity.Medical_Sub()
        CType(Me.XrTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Medical_Sub2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Sub_VesselType, Me.Sub_CompanyDefined, Me.Sub_NationalInformation, Me.Sub_Medical, Me.Sub_Courses, Me.Sub_Certificates, Me.XrLine3, Me.Sub_Travel, Me.XrLine1, Me.XrTable7, Me.XrLabel15, Me.XrLabel14, Me.XrLabel28, Me.XrLabel27, Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel6})
        Me.Detail.HeightF = 290.5417!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageBreak1
        '
        Me.XrPageBreak1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPageBreak1.Name = "XrPageBreak1"
        '
        'XrLine3
        '
        Me.XrLine3.ForeColor = System.Drawing.Color.DarkGray
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 277.9583!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(795.0!, 12.58335!)
        Me.XrLine3.StylePriority.UseForeColor = False
        '
        'XrLine1
        '
        Me.XrLine1.ForeColor = System.Drawing.Color.DarkGray
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 47.99999!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(795.0!, 12.58335!)
        Me.XrLine1.StylePriority.UseForeColor = False
        '
        'XrTable7
        '
        Me.XrTable7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTable7.FormattingRules.Add(Me.FormatDocStatusTravel)
        Me.XrTable7.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.0!)
        Me.XrTable7.Name = "XrTable7"
        Me.XrTable7.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable7.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow7})
        Me.XrTable7.SizeF = New System.Drawing.SizeF(795.438!, 15.0!)
        Me.XrTable7.StylePriority.UseBorders = False
        Me.XrTable7.StylePriority.UsePadding = False
        '
        'FormatDocStatusTravel
        '
        Me.FormatDocStatusTravel.Condition = "[DocStatusTravel] = 'Lacking'"
        '
        '
        '
        Me.FormatDocStatusTravel.Formatting.BackColor = System.Drawing.Color.Firebrick
        Me.FormatDocStatusTravel.Formatting.ForeColor = System.Drawing.Color.White
        Me.FormatDocStatusTravel.Name = "FormatDocStatusTravel"
        '
        'XrTableRow7
        '
        Me.XrTableRow7.BorderWidth = 0.5!
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.CrewName, Me.Rank, Me.DocStatusTravel})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.StylePriority.UseBorderWidth = False
        Me.XrTableRow7.Weight = 1.0R
        '
        'CrewName
        '
        Me.CrewName.BackColor = System.Drawing.Color.Transparent
        Me.CrewName.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrewName.ForeColor = System.Drawing.Color.Black
        Me.CrewName.FormattingRules.Add(Me.FormatDocStatusTravel)
        Me.CrewName.Name = "CrewName"
        Me.CrewName.StylePriority.UseBackColor = False
        Me.CrewName.StylePriority.UseFont = False
        Me.CrewName.StylePriority.UseForeColor = False
        Me.CrewName.Text = "Crew"
        Me.CrewName.Weight = 0.70479015274742851R
        '
        'Rank
        '
        Me.Rank.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rank.FormattingRules.Add(Me.FormatDocStatusTravel)
        Me.Rank.Name = "Rank"
        Me.Rank.StylePriority.UseFont = False
        Me.Rank.Text = "Rank"
        Me.Rank.Weight = 0.37127066307689272R
        '
        'DocStatusTravel
        '
        Me.DocStatusTravel.FormattingRules.Add(Me.FormatDocStatusTravel)
        Me.DocStatusTravel.Name = "DocStatusTravel"
        Me.DocStatusTravel.Visible = False
        Me.DocStatusTravel.Weight = 0.0056782819770045539R
        '
        'XrLabel15
        '
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.BorderWidth = 0.5!
        Me.XrLabel15.CanGrow = False
        Me.XrLabel15.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(691.2999!, 66.83331!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(103.7!, 19.0!)
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseBorderWidth = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "COMMENT"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel14
        '
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel14.BorderWidth = 0.5!
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(613.2599!, 66.83331!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(78.03998!, 19.0!)
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseBorderWidth = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "COMPLIED"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel28
        '
        Me.XrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel28.BorderWidth = 0.5!
        Me.XrLabel28.CanGrow = False
        Me.XrLabel28.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(545.34!, 66.83331!)
        Me.XrLabel28.Name = "XrLabel28"
        Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel28.SizeF = New System.Drawing.SizeF(67.92!, 19.0!)
        Me.XrLabel28.StylePriority.UseBorders = False
        Me.XrLabel28.StylePriority.UseBorderWidth = False
        Me.XrLabel28.StylePriority.UseFont = False
        Me.XrLabel28.StylePriority.UseTextAlignment = False
        Me.XrLabel28.Text = "CAPACITY"
        Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel27
        '
        Me.XrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel27.BorderWidth = 0.5!
        Me.XrLabel27.CanGrow = False
        Me.XrLabel27.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(477.42!, 66.83331!)
        Me.XrLabel27.Name = "XrLabel27"
        Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel27.SizeF = New System.Drawing.SizeF(67.92!, 19.0!)
        Me.XrLabel27.StylePriority.UseBorders = False
        Me.XrLabel27.StylePriority.UseBorderWidth = False
        Me.XrLabel27.StylePriority.UseFont = False
        Me.XrLabel27.StylePriority.UseTextAlignment = False
        Me.XrLabel27.Text = "COUNTRY"
        Me.XrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.BorderWidth = 0.5!
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(390.92!, 66.83331!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(86.5!, 19.0!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseBorderWidth = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "EXPIRE DATE"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.BorderWidth = 0.5!
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(305.3799!, 66.83331!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(85.54!, 19.0!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseBorderWidth = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "ISSUE DATE"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.BorderWidth = 0.5!
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(221.46!, 66.83331!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(83.92!, 19.0!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseBorderWidth = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "NUMBER"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.BorderWidth = 0.5!
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 66.83331!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(221.46!, 19.0!)
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseBorderWidth = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "DOCUMENT TYPE"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1})
        Me.TopMargin.HeightF = 98.29175!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 50.52831!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(795.438!, 22.76345!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Crew with Lacking Qualification/Competence"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageBreak1})
        Me.PageFooter.HeightF = 2.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'Sub_VesselType
        '
        Me.Sub_VesselType.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 250.5!)
        Me.Sub_VesselType.Name = "Sub_VesselType"
        Me.Sub_VesselType.ReportSource = New Activity.VesselType_Sub()
        Me.Sub_VesselType.SizeF = New System.Drawing.SizeF(795.438!, 23.0!)
        '
        'Sub_CompanyDefined
        '
        Me.Sub_CompanyDefined.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 223.5!)
        Me.Sub_CompanyDefined.Name = "Sub_CompanyDefined"
        Me.Sub_CompanyDefined.ReportSource = New Activity.CompanyDefined_Sub()
        Me.Sub_CompanyDefined.SizeF = New System.Drawing.SizeF(795.438!, 23.0!)
        '
        'Sub_NationalInformation
        '
        Me.Sub_NationalInformation.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 196.5!)
        Me.Sub_NationalInformation.Name = "Sub_NationalInformation"
        Me.Sub_NationalInformation.ReportSource = New Activity.NationalInformation_Sub()
        Me.Sub_NationalInformation.SizeF = New System.Drawing.SizeF(795.438!, 23.0!)
        '
        'Sub_Medical
        '
        Me.Sub_Medical.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 169.5!)
        Me.Sub_Medical.Name = "Sub_Medical"
        Me.Sub_Medical.ReportSource = New Activity.Medical_Sub()
        Me.Sub_Medical.SizeF = New System.Drawing.SizeF(795.438!, 23.0!)
        '
        'Sub_Courses
        '
        Me.Sub_Courses.LocationFloat = New DevExpress.Utils.PointFloat(0.00002384186!, 142.0834!)
        Me.Sub_Courses.Name = "Sub_Courses"
        Me.Sub_Courses.ReportSource = New Activity.Courses_Sub()
        Me.Sub_Courses.SizeF = New System.Drawing.SizeF(795.438!, 23.0!)
        '
        'Sub_Certificates
        '
        Me.Sub_Certificates.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 115.0834!)
        Me.Sub_Certificates.Name = "Sub_Certificates"
        Me.Sub_Certificates.ReportSource = New Activity.Certificates_Sub()
        Me.Sub_Certificates.SizeF = New System.Drawing.SizeF(795.438!, 23.0!)
        '
        'Sub_Travel
        '
        Me.Sub_Travel.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 88.50001!)
        Me.Sub_Travel.Name = "Sub_Travel"
        Me.Sub_Travel.ReportSource = New Activity.TravelDoc_Sub()
        Me.Sub_Travel.SizeF = New System.Drawing.SizeF(795.438!, 23.0!)
        '
        'Medical_Sub2
        '
        Me.Medical_Sub2.Margins = New System.Drawing.Printing.Margins(23, 25, 48, 0)
        Me.Medical_Sub2.Name = "Medical_Sub2"
        Me.Medical_Sub2.PageHeight = 1100
        Me.Medical_Sub2.PageWidth = 850
        Me.Medical_Sub2.Version = "14.2"
        '
        'LackCompetenceCrewReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormatDocStatusTravel})
        Me.Margins = New System.Drawing.Printing.Margins(18, 14, 98, 0)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "14.2"
        CType(Me.XrTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Medical_Sub2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents FormatDocStatusTravel As DevExpress.XtraReports.UI.FormattingRule
    Friend WithEvents XrTable7 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents CrewName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents Rank As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DocStatusTravel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents Sub_Travel As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents Sub_Certificates As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents Sub_Courses As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents Sub_Medical As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents XrPageBreak1 As DevExpress.XtraReports.UI.XRPageBreak
    Friend WithEvents Sub_NationalInformation As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents Medical_Sub2 As Activity.Medical_Sub
    Friend WithEvents Sub_CompanyDefined As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents Sub_VesselType As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
End Class
