<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPOEADisembark
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
        Me.txtNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtFullName = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtPosition = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtBasic = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtAgentContractPart = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtVessel = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtRegistry = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.txtCertifiedCorrectBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine6 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtCertifiedCorrectPosition = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.txtAgent = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtMonthOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtNameofAgent = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLine5 = New DevExpress.XtraReports.UI.XRLine()
        Me.GrpHeaderPrin = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.txtPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtNo, Me.txtFullName, Me.txtPosition, Me.txtBasic, Me.txtAgentContractPart, Me.txtVessel, Me.txtRegistry})
        Me.Detail.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Detail.HeightF = 17.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StylePriority.UseFont = False
        Me.Detail.StylePriority.UseTextAlignment = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtNo
        '
        Me.txtNo.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtNo.LocationFloat = New DevExpress.Utils.PointFloat(2.083333!, 0.0!)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtNo.SizeF = New System.Drawing.SizeF(30.20833!, 17.0!)
        Me.txtNo.StylePriority.UseFont = False
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
        Me.txtNo.Summary = XrSummary1
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtFullName.LocationFloat = New DevExpress.Utils.PointFloat(45.83333!, 0.0!)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtFullName.SizeF = New System.Drawing.SizeF(150.4583!, 17.0!)
        Me.txtFullName.StylePriority.UseFont = False
        '
        'txtPosition
        '
        Me.txtPosition.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtPosition.LocationFloat = New DevExpress.Utils.PointFloat(200.2916!, 0.0!)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtPosition.SizeF = New System.Drawing.SizeF(77.08336!, 17.0!)
        Me.txtPosition.StylePriority.UseFont = False
        Me.txtPosition.StylePriority.UseTextAlignment = False
        Me.txtPosition.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'txtBasic
        '
        Me.txtBasic.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtBasic.LocationFloat = New DevExpress.Utils.PointFloat(277.375!, 0.0!)
        Me.txtBasic.Name = "txtBasic"
        Me.txtBasic.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtBasic.SizeF = New System.Drawing.SizeF(66.0!, 17.0!)
        Me.txtBasic.StylePriority.UseFont = False
        Me.txtBasic.StylePriority.UseTextAlignment = False
        Me.txtBasic.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'txtAgentContractPart
        '
        Me.txtAgentContractPart.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtAgentContractPart.LocationFloat = New DevExpress.Utils.PointFloat(343.375!, 0.0!)
        Me.txtAgentContractPart.Name = "txtAgentContractPart"
        Me.txtAgentContractPart.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAgentContractPart.SizeF = New System.Drawing.SizeF(161.8333!, 17.0!)
        Me.txtAgentContractPart.StylePriority.UseFont = False
        Me.txtAgentContractPart.StylePriority.UseTextAlignment = False
        Me.txtAgentContractPart.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'txtVessel
        '
        Me.txtVessel.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtVessel.LocationFloat = New DevExpress.Utils.PointFloat(505.2083!, 0.0!)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtVessel.SizeF = New System.Drawing.SizeF(114.5833!, 17.0!)
        Me.txtVessel.StylePriority.UseFont = False
        Me.txtVessel.StylePriority.UseTextAlignment = False
        Me.txtVessel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'txtRegistry
        '
        Me.txtRegistry.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtRegistry.LocationFloat = New DevExpress.Utils.PointFloat(619.7917!, 0.0!)
        Me.txtRegistry.Name = "txtRegistry"
        Me.txtRegistry.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtRegistry.SizeF = New System.Drawing.SizeF(140.2083!, 17.0!)
        Me.txtRegistry.StylePriority.UseFont = False
        Me.txtRegistry.StylePriority.UseTextAlignment = False
        Me.txtRegistry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrPageInfo2.Format = "{0:dddd, MMMM dd, yyyy}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(130.2084!, 10.00001!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(201.7083!, 23.0!)
        Me.XrPageInfo2.StylePriority.UseFont = False
        '
        'txtCertifiedCorrectBy
        '
        Me.txtCertifiedCorrectBy.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtCertifiedCorrectBy.LocationFloat = New DevExpress.Utils.PointFloat(472.9167!, 37.45835!)
        Me.txtCertifiedCorrectBy.Name = "txtCertifiedCorrectBy"
        Me.txtCertifiedCorrectBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCertifiedCorrectBy.SizeF = New System.Drawing.SizeF(265.6251!, 18.0!)
        Me.txtCertifiedCorrectBy.StylePriority.UseFont = False
        '
        'XrLine6
        '
        Me.XrLine6.LocationFloat = New DevExpress.Utils.PointFloat(472.9167!, 55.45835!)
        Me.XrLine6.Name = "XrLine6"
        Me.XrLine6.SizeF = New System.Drawing.SizeF(265.625!, 2.0!)
        '
        'XrLine3
        '
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 3.999964!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(760.0!, 2.0!)
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(130.2084!, 23.0!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = "DATE SUBMITTED:"
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(472.9167!, 10.00001!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(232.2917!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "CERTIFIED CORRECT BY:"
        '
        'txtCertifiedCorrectPosition
        '
        Me.txtCertifiedCorrectPosition.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtCertifiedCorrectPosition.LocationFloat = New DevExpress.Utils.PointFloat(472.9165!, 57.45834!)
        Me.txtCertifiedCorrectPosition.Name = "txtCertifiedCorrectPosition"
        Me.txtCertifiedCorrectPosition.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCertifiedCorrectPosition.SizeF = New System.Drawing.SizeF(265.6251!, 18.0!)
        Me.txtCertifiedCorrectPosition.StylePriority.UseFont = False
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 0.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtAgent
        '
        Me.txtAgent.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtAgent.ForeColor = System.Drawing.Color.Transparent
        Me.txtAgent.LocationFloat = New DevExpress.Utils.PointFloat(45.83332!, 92.41663!)
        Me.txtAgent.Name = "txtAgent"
        Me.txtAgent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtAgent.SizeF = New System.Drawing.SizeF(144.7917!, 17.0!)
        Me.txtAgent.StylePriority.UseFont = False
        Me.txtAgent.StylePriority.UseForeColor = False
        '
        'XrLine4
        '
        Me.XrLine4.BorderWidth = 1.0!
        Me.XrLine4.LineWidth = 4
        Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 148.6251!)
        Me.XrLine4.Name = "XrLine4"
        Me.XrLine4.SizeF = New System.Drawing.SizeF(760.0!, 7.999985!)
        Me.XrLine4.StylePriority.UseBorderWidth = False
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 195.5001!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(760.0!, 2.0!)
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 92.66663!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 16.75!)
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(760.0!, 53.20832!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Philippine Overseas Employment Administration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LICENSING AND REGULATION OFFICE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "D" & _
    "ISEMBARKATION REPORT"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'txtMonthOf
        '
        Me.txtMonthOf.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Bold)
        Me.txtMonthOf.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 53.20832!)
        Me.txtMonthOf.Name = "txtMonthOf"
        Me.txtMonthOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtMonthOf.SizeF = New System.Drawing.SizeF(760.0!, 23.0!)
        Me.txtMonthOf.StylePriority.UseFont = False
        Me.txtMonthOf.StylePriority.UseTextAlignment = False
        Me.txtMonthOf.Text = "For The Month Of"
        Me.txtMonthOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'txtNameofAgent
        '
        Me.txtNameofAgent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtNameofAgent.LocationFloat = New DevExpress.Utils.PointFloat(2.083333!, 129.625!)
        Me.txtNameofAgent.Name = "txtNameofAgent"
        Me.txtNameofAgent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtNameofAgent.SizeF = New System.Drawing.SizeF(757.9167!, 19.0!)
        Me.txtNameofAgent.StylePriority.UseFont = False
        Me.txtNameofAgent.StylePriority.UseTextAlignment = False
        Me.txtNameofAgent.Text = "Name of Agent:"
        Me.txtNameofAgent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(86.45834!, 164.375!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(86.45834!, 17.0!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "FULL NAME"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)

        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(528.625!, 164.7916!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(75.0!, 17.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "VESSEL"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(343.375!, 164.375!)
        Me.XrLabel8.Multiline = True
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(134.375!, 27.41666!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "AGENT'S CONTRACT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PARTY"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(279.375!, 164.375!)
        Me.XrLabel9.Multiline = True
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(64.0!, 27.41669!)
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "BASIC SAL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "IN USD"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(200.2916!, 164.7916!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(77.08336!, 17.0!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "POSITION"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel12
        '
        Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(2.083333!, 164.375!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(30.20833!, 17.0!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "NO."
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(638.5417!, 164.7916!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 17.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "REGISTRY"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 161.0416!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(760.0!, 2.0!)
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 57.08332!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine5
        '
        Me.XrLine5.BorderWidth = 1.0!
        Me.XrLine5.LineWidth = 4
        Me.XrLine5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLine5.Name = "XrLine5"
        Me.XrLine5.SizeF = New System.Drawing.SizeF(760.0!, 7.999985!)
        Me.XrLine5.StylePriority.UseBorderWidth = False
        '
        'GrpHeaderPrin
        '
        Me.GrpHeaderPrin.HeightF = 0.0!
        Me.GrpHeaderPrin.Name = "GrpHeaderPrin"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine5})
        Me.PageFooter.HeightF = 7.999985!
        Me.PageFooter.Name = "PageFooter"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.txtCertifiedCorrectPosition, Me.XrPageInfo2, Me.txtCertifiedCorrectBy, Me.XrLine3, Me.XrLabel4, Me.XrLine6})
        Me.ReportFooter.HeightF = 100.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'txtPeriod
        '
        Me.txtPeriod.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.txtPeriod.ForeColor = System.Drawing.Color.Transparent
        Me.txtPeriod.LocationFloat = New DevExpress.Utils.PointFloat(293.75!, 92.41663!)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtPeriod.SizeF = New System.Drawing.SizeF(144.7917!, 17.0!)
        Me.txtPeriod.StylePriority.UseFont = False
        Me.txtPeriod.StylePriority.UseForeColor = False
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.XrLabel6, Me.XrLabel12, Me.XrLabel10, Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel11, Me.txtNameofAgent, Me.txtMonthOf, Me.XrLine1, Me.XrPageInfo1, Me.XrLine2, Me.XrLine4, Me.txtAgent, Me.txtPeriod})
        Me.PageHeader.HeightF = 197.5001!
        Me.PageHeader.Name = "PageHeader"
        '
        'rptPOEADisembark
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GrpHeaderPrin, Me.PageFooter, Me.ReportFooter, Me.PageHeader})
        Me.Margins = New System.Drawing.Printing.Margins(42, 48, 0, 57)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtMonthOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtNameofAgent As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine5 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine6 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents txtNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtFullName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtPosition As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtBasic As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAgentContractPart As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtVessel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtRegistry As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtCertifiedCorrectBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents txtCertifiedCorrectPosition As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtAgent As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GrpHeaderPrin As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents txtPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
End Class
