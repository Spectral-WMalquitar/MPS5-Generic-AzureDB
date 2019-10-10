<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class TCC1
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
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.lblVesselName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVesselType = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVesselFlag = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celQualification = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celOfficer = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celNationality = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celCOC = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celIssuingCountry = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celAdminAcceptance = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celTankerCertification = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celSpecialTT = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow9 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celRadioQualification = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow10 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celYearsWithCompany = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow11 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celYearsInRank = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow12 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celYearsOnThisTypeOfTanker = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow13 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celYearsOnAllTypeOfTanker = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow14 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celYearsInRankOfficer = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow15 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celMonthInVessel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow16 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celEnglishProficiency = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow17 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celYearsInRankOfficerJunior = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.HeightF = 578.849!
        Me.Detail.MultiColumn.ColumnCount = 7
        Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblVesselName, Me.XrLabel2, Me.XrLabel3, Me.XrLabel4, Me.lblVesselType, Me.lblVesselFlag, Me.XrLabel5})
        Me.TopMargin.HeightF = 126.9167!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblVesselName
        '
        Me.lblVesselName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblVesselName.BorderWidth = 2.0!
        Me.lblVesselName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVesselName.LocationFloat = New DevExpress.Utils.PointFloat(71.87498!, 91.83328!)
        Me.lblVesselName.Name = "lblVesselName"
        Me.lblVesselName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVesselName.SizeF = New System.Drawing.SizeF(263.5833!, 25.08334!)
        Me.lblVesselName.StylePriority.UseBorders = False
        Me.lblVesselName.StylePriority.UseBorderWidth = False
        Me.lblVesselName.StylePriority.UseFont = False
        Me.lblVesselName.StylePriority.UseTextAlignment = False
        Me.lblVesselName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.BorderWidth = 2.0!
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.999999!, 91.83328!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(70.87498!, 25.08334!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseBorderWidth = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "VESSEL :"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 51.95824!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(1035.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "CREW QUALIFICATIONS"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.BorderWidth = 2.0!
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(354.7083!, 91.83328!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(62.54164!, 25.08334!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseBorderWidth = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "TYPE   :"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrLabel4.Visible = False
        '
        'lblVesselType
        '
        Me.lblVesselType.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblVesselType.BorderWidth = 2.0!
        Me.lblVesselType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVesselType.LocationFloat = New DevExpress.Utils.PointFloat(417.25!, 91.83328!)
        Me.lblVesselType.Name = "lblVesselType"
        Me.lblVesselType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVesselType.SizeF = New System.Drawing.SizeF(263.5833!, 25.08334!)
        Me.lblVesselType.StylePriority.UseBorders = False
        Me.lblVesselType.StylePriority.UseBorderWidth = False
        Me.lblVesselType.StylePriority.UseFont = False
        Me.lblVesselType.StylePriority.UseTextAlignment = False
        Me.lblVesselType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblVesselType.Visible = False
        '
        'lblVesselFlag
        '
        Me.lblVesselFlag.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblVesselFlag.BorderWidth = 2.0!
        Me.lblVesselFlag.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVesselFlag.LocationFloat = New DevExpress.Utils.PointFloat(771.4167!, 91.83328!)
        Me.lblVesselFlag.Name = "lblVesselFlag"
        Me.lblVesselFlag.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVesselFlag.SizeF = New System.Drawing.SizeF(263.5833!, 25.08334!)
        Me.lblVesselFlag.StylePriority.UseBorders = False
        Me.lblVesselFlag.StylePriority.UseBorderWidth = False
        Me.lblVesselFlag.StylePriority.UseFont = False
        Me.lblVesselFlag.StylePriority.UseTextAlignment = False
        Me.lblVesselFlag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblVesselFlag.Visible = False
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.BorderWidth = 2.0!
        Me.XrLabel5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(708.8751!, 91.83339!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(62.54164!, 25.08334!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseBorderWidth = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "FLAG   :"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrLabel5.Visible = False
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 13.20833!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.HeightF = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.HeightF = 0.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageFooter
        '
        Me.PageFooter.HeightF = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrControlStyle1
        '
        Me.XrControlStyle1.Name = "XrControlStyle1"
        Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow2, Me.XrTableRow3, Me.XrTableRow4, Me.XrTableRow5, Me.XrTableRow6, Me.XrTableRow7, Me.XrTableRow8, Me.XrTableRow9, Me.XrTableRow10, Me.XrTableRow11, Me.XrTableRow12, Me.XrTableRow13, Me.XrTableRow14, Me.XrTableRow15, Me.XrTableRow16, Me.XrTableRow17})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(147.9167!, 578.849!)
        Me.XrTable1.StylePriority.UseBorders = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celQualification})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.1666666412353517R
        '
        'celQualification
        '
        Me.celQualification.CanGrow = False
        Me.celQualification.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celQualification.Multiline = True
        Me.celQualification.Name = "celQualification"
        Me.celQualification.StylePriority.UseFont = False
        Me.celQualification.StylePriority.UseTextAlignment = False
        Me.celQualification.Text = "celQualification"
        Me.celQualification.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celQualification.Weight = 1.0R
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celOfficer})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.1666666412353517R
        '
        'celOfficer
        '
        Me.celOfficer.CanGrow = False
        Me.celOfficer.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celOfficer.Multiline = True
        Me.celOfficer.Name = "celOfficer"
        Me.celOfficer.StylePriority.UseFont = False
        Me.celOfficer.StylePriority.UseTextAlignment = False
        Me.celOfficer.Text = "celOfficer"
        Me.celOfficer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celOfficer.Weight = 1.0R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celNationality})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.1666666412353517R
        '
        'celNationality
        '
        Me.celNationality.CanGrow = False
        Me.celNationality.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celNationality.Multiline = True
        Me.celNationality.Name = "celNationality"
        Me.celNationality.StylePriority.UseFont = False
        Me.celNationality.StylePriority.UseTextAlignment = False
        Me.celNationality.Text = "celNationality"
        Me.celNationality.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celNationality.Weight = 1.0R
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celCOC})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.1666666412353517R
        '
        'celCOC
        '
        Me.celCOC.CanGrow = False
        Me.celCOC.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celCOC.Multiline = True
        Me.celCOC.Name = "celCOC"
        Me.celCOC.StylePriority.UseFont = False
        Me.celCOC.StylePriority.UseTextAlignment = False
        Me.celCOC.Text = "celCOC"
        Me.celCOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celCOC.Weight = 1.0R
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celIssuingCountry})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.1666666412353517R
        '
        'celIssuingCountry
        '
        Me.celIssuingCountry.CanGrow = False
        Me.celIssuingCountry.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celIssuingCountry.Multiline = True
        Me.celIssuingCountry.Name = "celIssuingCountry"
        Me.celIssuingCountry.StylePriority.UseFont = False
        Me.celIssuingCountry.StylePriority.UseTextAlignment = False
        Me.celIssuingCountry.Text = "celIssuingCountry"
        Me.celIssuingCountry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celIssuingCountry.Weight = 1.0R
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celAdminAcceptance})
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.Weight = 1.1666666412353517R
        '
        'celAdminAcceptance
        '
        Me.celAdminAcceptance.CanGrow = False
        Me.celAdminAcceptance.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celAdminAcceptance.Multiline = True
        Me.celAdminAcceptance.Name = "celAdminAcceptance"
        Me.celAdminAcceptance.StylePriority.UseFont = False
        Me.celAdminAcceptance.StylePriority.UseTextAlignment = False
        Me.celAdminAcceptance.Text = "celAdminAcceptance"
        Me.celAdminAcceptance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celAdminAcceptance.Weight = 1.0R
        '
        'XrTableRow7
        '
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celTankerCertification})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.Weight = 1.5848546726128028R
        '
        'celTankerCertification
        '
        Me.celTankerCertification.CanGrow = False
        Me.celTankerCertification.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celTankerCertification.Multiline = True
        Me.celTankerCertification.Name = "celTankerCertification"
        Me.celTankerCertification.StylePriority.UseFont = False
        Me.celTankerCertification.StylePriority.UseTextAlignment = False
        Me.celTankerCertification.Text = "celTankerCertification"
        Me.celTankerCertification.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celTankerCertification.Weight = 1.0R
        '
        'XrTableRow8
        '
        Me.XrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celSpecialTT})
        Me.XrTableRow8.Name = "XrTableRow8"
        Me.XrTableRow8.Weight = 1.1261876620396691R
        '
        'celSpecialTT
        '
        Me.celSpecialTT.CanGrow = False
        Me.celSpecialTT.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celSpecialTT.Multiline = True
        Me.celSpecialTT.Name = "celSpecialTT"
        Me.celSpecialTT.StylePriority.UseFont = False
        Me.celSpecialTT.StylePriority.UseTextAlignment = False
        Me.celSpecialTT.Text = "celSpecialTT"
        Me.celSpecialTT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celSpecialTT.Weight = 1.0R
        '
        'XrTableRow9
        '
        Me.XrTableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celRadioQualification})
        Me.XrTableRow9.Name = "XrTableRow9"
        Me.XrTableRow9.Weight = 1.1775458186361913R
        '
        'celRadioQualification
        '
        Me.celRadioQualification.CanGrow = False
        Me.celRadioQualification.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celRadioQualification.Multiline = True
        Me.celRadioQualification.Name = "celRadioQualification"
        Me.celRadioQualification.StylePriority.UseFont = False
        Me.celRadioQualification.StylePriority.UseTextAlignment = False
        Me.celRadioQualification.Text = "celRadioQualification"
        Me.celRadioQualification.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celRadioQualification.Weight = 1.0R
        '
        'XrTableRow10
        '
        Me.XrTableRow10.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celYearsWithCompany})
        Me.XrTableRow10.Name = "XrTableRow10"
        Me.XrTableRow10.Weight = 1.2044354785501554R
        '
        'celYearsWithCompany
        '
        Me.celYearsWithCompany.CanGrow = False
        Me.celYearsWithCompany.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celYearsWithCompany.Multiline = True
        Me.celYearsWithCompany.Name = "celYearsWithCompany"
        Me.celYearsWithCompany.StylePriority.UseFont = False
        Me.celYearsWithCompany.StylePriority.UseTextAlignment = False
        Me.celYearsWithCompany.Text = "celYearsWithCompany"
        Me.celYearsWithCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celYearsWithCompany.Weight = 1.0R
        '
        'XrTableRow11
        '
        Me.XrTableRow11.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celYearsInRank})
        Me.XrTableRow11.Name = "XrTableRow11"
        Me.XrTableRow11.Weight = 1.1557895386539503R
        '
        'celYearsInRank
        '
        Me.celYearsInRank.CanGrow = False
        Me.celYearsInRank.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celYearsInRank.Multiline = True
        Me.celYearsInRank.Name = "celYearsInRank"
        Me.celYearsInRank.StylePriority.UseFont = False
        Me.celYearsInRank.StylePriority.UseTextAlignment = False
        Me.celYearsInRank.Text = "celYearsInRank"
        Me.celYearsInRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celYearsInRank.Weight = 1.0R
        '
        'XrTableRow12
        '
        Me.XrTableRow12.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celYearsOnThisTypeOfTanker})
        Me.XrTableRow12.Name = "XrTableRow12"
        Me.XrTableRow12.Weight = 1.1288965590288851R
        '
        'celYearsOnThisTypeOfTanker
        '
        Me.celYearsOnThisTypeOfTanker.CanGrow = False
        Me.celYearsOnThisTypeOfTanker.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celYearsOnThisTypeOfTanker.Multiline = True
        Me.celYearsOnThisTypeOfTanker.Name = "celYearsOnThisTypeOfTanker"
        Me.celYearsOnThisTypeOfTanker.StylePriority.UseFont = False
        Me.celYearsOnThisTypeOfTanker.StylePriority.UseTextAlignment = False
        Me.celYearsOnThisTypeOfTanker.Text = "celYearsOnThisTypeOfTanker"
        Me.celYearsOnThisTypeOfTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celYearsOnThisTypeOfTanker.Weight = 1.0R
        '
        'XrTableRow13
        '
        Me.XrTableRow13.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celYearsOnAllTypeOfTanker})
        Me.XrTableRow13.Name = "XrTableRow13"
        Me.XrTableRow13.Weight = 1.1666660187895204R
        '
        'celYearsOnAllTypeOfTanker
        '
        Me.celYearsOnAllTypeOfTanker.CanGrow = False
        Me.celYearsOnAllTypeOfTanker.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celYearsOnAllTypeOfTanker.Multiline = True
        Me.celYearsOnAllTypeOfTanker.Name = "celYearsOnAllTypeOfTanker"
        Me.celYearsOnAllTypeOfTanker.StylePriority.UseFont = False
        Me.celYearsOnAllTypeOfTanker.StylePriority.UseTextAlignment = False
        Me.celYearsOnAllTypeOfTanker.Text = "celYearsOnAllTypeOfTanker"
        Me.celYearsOnAllTypeOfTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celYearsOnAllTypeOfTanker.Weight = 1.0R
        '
        'XrTableRow14
        '
        Me.XrTableRow14.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celYearsInRankOfficer})
        Me.XrTableRow14.Name = "XrTableRow14"
        Me.XrTableRow14.Weight = 1.2153141718264595R
        '
        'celYearsInRankOfficer
        '
        Me.celYearsInRankOfficer.CanGrow = False
        Me.celYearsInRankOfficer.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celYearsInRankOfficer.Multiline = True
        Me.celYearsInRankOfficer.Name = "celYearsInRankOfficer"
        Me.celYearsInRankOfficer.StylePriority.UseFont = False
        Me.celYearsInRankOfficer.StylePriority.UseTextAlignment = False
        Me.celYearsInRankOfficer.Text = "celYearsInRankOfficer"
        Me.celYearsInRankOfficer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celYearsInRankOfficer.Weight = 1.0R
        '
        'XrTableRow15
        '
        Me.XrTableRow15.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celMonthInVessel})
        Me.XrTableRow15.Name = "XrTableRow15"
        Me.XrTableRow15.Weight = 1.1557906452243167R
        '
        'celMonthInVessel
        '
        Me.celMonthInVessel.CanGrow = False
        Me.celMonthInVessel.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celMonthInVessel.Multiline = True
        Me.celMonthInVessel.Name = "celMonthInVessel"
        Me.celMonthInVessel.StylePriority.UseFont = False
        Me.celMonthInVessel.StylePriority.UseTextAlignment = False
        Me.celMonthInVessel.Text = "celMonthInVessel"
        Me.celMonthInVessel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celMonthInVessel.Weight = 1.0R
        '
        'XrTableRow16
        '
        Me.XrTableRow16.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celEnglishProficiency})
        Me.XrTableRow16.Name = "XrTableRow16"
        Me.XrTableRow16.Weight = 1.1666660187895204R
        '
        'celEnglishProficiency
        '
        Me.celEnglishProficiency.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celEnglishProficiency.Multiline = True
        Me.celEnglishProficiency.Name = "celEnglishProficiency"
        Me.celEnglishProficiency.StylePriority.UseFont = False
        Me.celEnglishProficiency.StylePriority.UseTextAlignment = False
        Me.celEnglishProficiency.Text = "celEnglishProficiency"
        Me.celEnglishProficiency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celEnglishProficiency.Weight = 1.0R
        '
        'XrTableRow17
        '
        Me.XrTableRow17.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celYearsInRankOfficerJunior})
        Me.XrTableRow17.Name = "XrTableRow17"
        Me.XrTableRow17.Weight = 1.1137830209587234R
        '
        'celYearsInRankOfficerJunior
        '
        Me.celYearsInRankOfficerJunior.CanGrow = False
        Me.celYearsInRankOfficerJunior.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.celYearsInRankOfficerJunior.Multiline = True
        Me.celYearsInRankOfficerJunior.Name = "celYearsInRankOfficerJunior"
        Me.celYearsInRankOfficerJunior.StylePriority.UseFont = False
        Me.celYearsInRankOfficerJunior.StylePriority.UseTextAlignment = False
        Me.celYearsInRankOfficerJunior.Text = "celYearsInRankOfficerJunior"
        Me.celYearsInRankOfficerJunior.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.celYearsInRankOfficerJunior.Weight = 1.0R
        '
        'TCC1
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter, Me.PageFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(29, 36, 127, 13)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
        Me.Version = "14.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblVesselName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVesselType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVesselFlag As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celQualification As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celOfficer As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celNationality As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celCOC As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celIssuingCountry As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celAdminAcceptance As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celTankerCertification As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celSpecialTT As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celRadioQualification As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow10 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celYearsWithCompany As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow11 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celYearsInRank As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow12 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celYearsOnThisTypeOfTanker As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow13 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celYearsOnAllTypeOfTanker As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow14 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celYearsInRankOfficer As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow15 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celMonthInVessel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow16 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celEnglishProficiency As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow17 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celYearsInRankOfficerJunior As DevExpress.XtraReports.UI.XRTableCell
End Class
