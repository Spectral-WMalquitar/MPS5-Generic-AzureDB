<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportVersion1
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
        Me.lblOfficer = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblEmployingCompanyAgency = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblQualification = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNationality = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNationalCOC = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSTCWRegulationHeld = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblIssuingCountry = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFlagCertOfCompetency = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFlagEndorsement = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsWithCompany = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsInRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsOnThisTypeOfTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsOnAllTypeOfTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblEnglishProficiency = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMonthsOnTheVesselThisVoyage = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.ReportVersion1_SubContents1 = New QualificationMatrixReport.ReportVersion1_SubContents()
        CType(Me.ReportVersion1_SubContents1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblOfficer, Me.lblEmployingCompanyAgency, Me.lblQualification, Me.lblNationality, Me.lblNationalCOC, Me.lblSTCWRegulationHeld, Me.lblIssuingCountry, Me.lblFlagCertOfCompetency, Me.lblFlagEndorsement, Me.lblYearsWithCompany, Me.lblYearsInRank, Me.lblYearsOnThisTypeOfTanker, Me.lblYearsOnAllTypeOfTanker, Me.lblEnglishProficiency, Me.lblMonthsOnTheVesselThisVoyage})
        Me.Detail.HeightF = 519.125!
        Me.Detail.MultiColumn.ColumnCount = 7
        Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblOfficer
        '
        Me.lblOfficer.BorderColor = System.Drawing.Color.DarkGray
        Me.lblOfficer.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblOfficer.BorderWidth = 1.0!
        Me.lblOfficer.CanGrow = False
        Me.lblOfficer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOfficer.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 10.5!)
        Me.lblOfficer.Name = "lblOfficer"
        Me.lblOfficer.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOfficer.SizeF = New System.Drawing.SizeF(147.0417!, 35.95832!)
        Me.lblOfficer.StylePriority.UseBorderColor = False
        Me.lblOfficer.StylePriority.UseBorders = False
        Me.lblOfficer.StylePriority.UseBorderWidth = False
        Me.lblOfficer.StylePriority.UseFont = False
        Me.lblOfficer.StylePriority.UseTextAlignment = False
        Me.lblOfficer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblEmployingCompanyAgency
        '
        Me.lblEmployingCompanyAgency.BorderColor = System.Drawing.Color.DarkGray
        Me.lblEmployingCompanyAgency.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblEmployingCompanyAgency.BorderWidth = 1.0!
        Me.lblEmployingCompanyAgency.CanGrow = False
        Me.lblEmployingCompanyAgency.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployingCompanyAgency.LocationFloat = New DevExpress.Utils.PointFloat(0.999999!, 398.58!)
        Me.lblEmployingCompanyAgency.Name = "lblEmployingCompanyAgency"
        Me.lblEmployingCompanyAgency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblEmployingCompanyAgency.SizeF = New System.Drawing.SizeF(147.0418!, 35.95837!)
        Me.lblEmployingCompanyAgency.StylePriority.UseBorderColor = False
        Me.lblEmployingCompanyAgency.StylePriority.UseBorders = False
        Me.lblEmployingCompanyAgency.StylePriority.UseBorderWidth = False
        Me.lblEmployingCompanyAgency.StylePriority.UseFont = False
        Me.lblEmployingCompanyAgency.StylePriority.UseTextAlignment = False
        Me.lblEmployingCompanyAgency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblQualification
        '
        Me.lblQualification.BorderColor = System.Drawing.Color.DarkGray
        Me.lblQualification.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblQualification.BorderWidth = 1.0!
        Me.lblQualification.CanGrow = False
        Me.lblQualification.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQualification.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 45.46!)
        Me.lblQualification.Name = "lblQualification"
        Me.lblQualification.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblQualification.SizeF = New System.Drawing.SizeF(147.0417!, 25.5417!)
        Me.lblQualification.StylePriority.UseBorderColor = False
        Me.lblQualification.StylePriority.UseBorders = False
        Me.lblQualification.StylePriority.UseBorderWidth = False
        Me.lblQualification.StylePriority.UseFont = False
        Me.lblQualification.StylePriority.UseTextAlignment = False
        Me.lblQualification.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblNationality
        '
        Me.lblNationality.BorderColor = System.Drawing.Color.DarkGray
        Me.lblNationality.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNationality.BorderWidth = 1.0!
        Me.lblNationality.CanGrow = False
        Me.lblNationality.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNationality.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 70.0!)
        Me.lblNationality.Name = "lblNationality"
        Me.lblNationality.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNationality.SizeF = New System.Drawing.SizeF(147.0417!, 25.54!)
        Me.lblNationality.StylePriority.UseBorderColor = False
        Me.lblNationality.StylePriority.UseBorders = False
        Me.lblNationality.StylePriority.UseBorderWidth = False
        Me.lblNationality.StylePriority.UseFont = False
        Me.lblNationality.StylePriority.UseTextAlignment = False
        Me.lblNationality.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblNationalCOC
        '
        Me.lblNationalCOC.BorderColor = System.Drawing.Color.DarkGray
        Me.lblNationalCOC.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNationalCOC.BorderWidth = 1.0!
        Me.lblNationalCOC.CanGrow = False
        Me.lblNationalCOC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNationalCOC.LocationFloat = New DevExpress.Utils.PointFloat(0.999999!, 94.53999!)
        Me.lblNationalCOC.Name = "lblNationalCOC"
        Me.lblNationalCOC.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNationalCOC.SizeF = New System.Drawing.SizeF(147.0418!, 47.96008!)
        Me.lblNationalCOC.StylePriority.UseBorderColor = False
        Me.lblNationalCOC.StylePriority.UseBorders = False
        Me.lblNationalCOC.StylePriority.UseBorderWidth = False
        Me.lblNationalCOC.StylePriority.UseFont = False
        Me.lblNationalCOC.StylePriority.UseTextAlignment = False
        Me.lblNationalCOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblSTCWRegulationHeld
        '
        Me.lblSTCWRegulationHeld.BorderColor = System.Drawing.Color.DarkGray
        Me.lblSTCWRegulationHeld.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblSTCWRegulationHeld.BorderWidth = 1.0!
        Me.lblSTCWRegulationHeld.CanGrow = False
        Me.lblSTCWRegulationHeld.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTCWRegulationHeld.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 141.5!)
        Me.lblSTCWRegulationHeld.Name = "lblSTCWRegulationHeld"
        Me.lblSTCWRegulationHeld.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSTCWRegulationHeld.SizeF = New System.Drawing.SizeF(147.0417!, 35.95828!)
        Me.lblSTCWRegulationHeld.StylePriority.UseBorderColor = False
        Me.lblSTCWRegulationHeld.StylePriority.UseBorders = False
        Me.lblSTCWRegulationHeld.StylePriority.UseBorderWidth = False
        Me.lblSTCWRegulationHeld.StylePriority.UseFont = False
        Me.lblSTCWRegulationHeld.StylePriority.UseTextAlignment = False
        Me.lblSTCWRegulationHeld.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblIssuingCountry
        '
        Me.lblIssuingCountry.BorderColor = System.Drawing.Color.DarkGray
        Me.lblIssuingCountry.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblIssuingCountry.BorderWidth = 1.0!
        Me.lblIssuingCountry.CanGrow = False
        Me.lblIssuingCountry.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssuingCountry.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 176.46!)
        Me.lblIssuingCountry.Name = "lblIssuingCountry"
        Me.lblIssuingCountry.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblIssuingCountry.SizeF = New System.Drawing.SizeF(147.0417!, 25.54172!)
        Me.lblIssuingCountry.StylePriority.UseBorderColor = False
        Me.lblIssuingCountry.StylePriority.UseBorders = False
        Me.lblIssuingCountry.StylePriority.UseBorderWidth = False
        Me.lblIssuingCountry.StylePriority.UseFont = False
        Me.lblIssuingCountry.StylePriority.UseTextAlignment = False
        Me.lblIssuingCountry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFlagCertOfCompetency
        '
        Me.lblFlagCertOfCompetency.BorderColor = System.Drawing.Color.DarkGray
        Me.lblFlagCertOfCompetency.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFlagCertOfCompetency.BorderWidth = 1.0!
        Me.lblFlagCertOfCompetency.CanGrow = False
        Me.lblFlagCertOfCompetency.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlagCertOfCompetency.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 201.0!)
        Me.lblFlagCertOfCompetency.Name = "lblFlagCertOfCompetency"
        Me.lblFlagCertOfCompetency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFlagCertOfCompetency.SizeF = New System.Drawing.SizeF(147.0417!, 33.70833!)
        Me.lblFlagCertOfCompetency.StylePriority.UseBorderColor = False
        Me.lblFlagCertOfCompetency.StylePriority.UseBorders = False
        Me.lblFlagCertOfCompetency.StylePriority.UseBorderWidth = False
        Me.lblFlagCertOfCompetency.StylePriority.UseFont = False
        Me.lblFlagCertOfCompetency.StylePriority.UseTextAlignment = False
        Me.lblFlagCertOfCompetency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFlagEndorsement
        '
        Me.lblFlagEndorsement.BorderColor = System.Drawing.Color.DarkGray
        Me.lblFlagEndorsement.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFlagEndorsement.BorderWidth = 1.0!
        Me.lblFlagEndorsement.CanGrow = False
        Me.lblFlagEndorsement.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlagEndorsement.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 233.71!)
        Me.lblFlagEndorsement.Name = "lblFlagEndorsement"
        Me.lblFlagEndorsement.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFlagEndorsement.SizeF = New System.Drawing.SizeF(147.0417!, 37.04164!)
        Me.lblFlagEndorsement.StylePriority.UseBorderColor = False
        Me.lblFlagEndorsement.StylePriority.UseBorders = False
        Me.lblFlagEndorsement.StylePriority.UseBorderWidth = False
        Me.lblFlagEndorsement.StylePriority.UseFont = False
        Me.lblFlagEndorsement.StylePriority.UseTextAlignment = False
        Me.lblFlagEndorsement.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYearsWithCompany
        '
        Me.lblYearsWithCompany.BorderColor = System.Drawing.Color.DarkGray
        Me.lblYearsWithCompany.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsWithCompany.BorderWidth = 1.0!
        Me.lblYearsWithCompany.CanGrow = False
        Me.lblYearsWithCompany.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsWithCompany.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 269.75!)
        Me.lblYearsWithCompany.Name = "lblYearsWithCompany"
        Me.lblYearsWithCompany.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsWithCompany.SizeF = New System.Drawing.SizeF(147.0417!, 34.95834!)
        Me.lblYearsWithCompany.StylePriority.UseBorderColor = False
        Me.lblYearsWithCompany.StylePriority.UseBorders = False
        Me.lblYearsWithCompany.StylePriority.UseBorderWidth = False
        Me.lblYearsWithCompany.StylePriority.UseFont = False
        Me.lblYearsWithCompany.StylePriority.UseTextAlignment = False
        Me.lblYearsWithCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYearsInRank
        '
        Me.lblYearsInRank.BorderColor = System.Drawing.Color.DarkGray
        Me.lblYearsInRank.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsInRank.BorderWidth = 1.0!
        Me.lblYearsInRank.CanGrow = False
        Me.lblYearsInRank.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsInRank.LocationFloat = New DevExpress.Utils.PointFloat(0.9982904!, 303.71!)
        Me.lblYearsInRank.Name = "lblYearsInRank"
        Me.lblYearsInRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsInRank.SizeF = New System.Drawing.SizeF(147.0417!, 25.54178!)
        Me.lblYearsInRank.StylePriority.UseBorderColor = False
        Me.lblYearsInRank.StylePriority.UseBorders = False
        Me.lblYearsInRank.StylePriority.UseBorderWidth = False
        Me.lblYearsInRank.StylePriority.UseFont = False
        Me.lblYearsInRank.StylePriority.UseTextAlignment = False
        Me.lblYearsInRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYearsOnThisTypeOfTanker
        '
        Me.lblYearsOnThisTypeOfTanker.BorderColor = System.Drawing.Color.DarkGray
        Me.lblYearsOnThisTypeOfTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsOnThisTypeOfTanker.BorderWidth = 1.0!
        Me.lblYearsOnThisTypeOfTanker.CanGrow = False
        Me.lblYearsOnThisTypeOfTanker.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsOnThisTypeOfTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.999999!, 328.25!)
        Me.lblYearsOnThisTypeOfTanker.Name = "lblYearsOnThisTypeOfTanker"
        Me.lblYearsOnThisTypeOfTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsOnThisTypeOfTanker.SizeF = New System.Drawing.SizeF(147.0418!, 36.66644!)
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseBorderColor = False
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseBorders = False
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseBorderWidth = False
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseFont = False
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseTextAlignment = False
        Me.lblYearsOnThisTypeOfTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYearsOnAllTypeOfTanker
        '
        Me.lblYearsOnAllTypeOfTanker.BorderColor = System.Drawing.Color.DarkGray
        Me.lblYearsOnAllTypeOfTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsOnAllTypeOfTanker.BorderWidth = 1.0!
        Me.lblYearsOnAllTypeOfTanker.CanGrow = False
        Me.lblYearsOnAllTypeOfTanker.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsOnAllTypeOfTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.999999!, 363.92!)
        Me.lblYearsOnAllTypeOfTanker.Name = "lblYearsOnAllTypeOfTanker"
        Me.lblYearsOnAllTypeOfTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsOnAllTypeOfTanker.SizeF = New System.Drawing.SizeF(147.0418!, 35.95844!)
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseBorderColor = False
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseBorders = False
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseBorderWidth = False
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseFont = False
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseTextAlignment = False
        Me.lblYearsOnAllTypeOfTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblEnglishProficiency
        '
        Me.lblEnglishProficiency.BorderColor = System.Drawing.Color.DarkGray
        Me.lblEnglishProficiency.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblEnglishProficiency.BorderWidth = 1.0!
        Me.lblEnglishProficiency.CanGrow = False
        Me.lblEnglishProficiency.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnglishProficiency.LocationFloat = New DevExpress.Utils.PointFloat(0.999999!, 433.54!)
        Me.lblEnglishProficiency.Name = "lblEnglishProficiency"
        Me.lblEnglishProficiency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblEnglishProficiency.SizeF = New System.Drawing.SizeF(147.0418!, 48.45831!)
        Me.lblEnglishProficiency.StylePriority.UseBorderColor = False
        Me.lblEnglishProficiency.StylePriority.UseBorders = False
        Me.lblEnglishProficiency.StylePriority.UseBorderWidth = False
        Me.lblEnglishProficiency.StylePriority.UseFont = False
        Me.lblEnglishProficiency.StylePriority.UseTextAlignment = False
        Me.lblEnglishProficiency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblMonthsOnTheVesselThisVoyage
        '
        Me.lblMonthsOnTheVesselThisVoyage.BorderColor = System.Drawing.Color.DarkGray
        Me.lblMonthsOnTheVesselThisVoyage.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMonthsOnTheVesselThisVoyage.BorderWidth = 1.0!
        Me.lblMonthsOnTheVesselThisVoyage.CanGrow = False
        Me.lblMonthsOnTheVesselThisVoyage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthsOnTheVesselThisVoyage.LocationFloat = New DevExpress.Utils.PointFloat(0.999999!, 481.0!)
        Me.lblMonthsOnTheVesselThisVoyage.Name = "lblMonthsOnTheVesselThisVoyage"
        Me.lblMonthsOnTheVesselThisVoyage.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMonthsOnTheVesselThisVoyage.SizeF = New System.Drawing.SizeF(147.0418!, 36.95831!)
        Me.lblMonthsOnTheVesselThisVoyage.StylePriority.UseBorderColor = False
        Me.lblMonthsOnTheVesselThisVoyage.StylePriority.UseBorders = False
        Me.lblMonthsOnTheVesselThisVoyage.StylePriority.UseBorderWidth = False
        Me.lblMonthsOnTheVesselThisVoyage.StylePriority.UseFont = False
        Me.lblMonthsOnTheVesselThisVoyage.StylePriority.UseTextAlignment = False
        Me.lblMonthsOnTheVesselThisVoyage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 51.95824!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(1035.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "OFFICER QUALIFICATION AND EXPERIENCES MATRIX"
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
        'ReportVersion1_SubContents1
        '
        Me.ReportVersion1_SubContents1.Margins = New System.Drawing.Printing.Margins(0, 729, 0, 0)
        Me.ReportVersion1_SubContents1.Name = "ReportVersion1_SubContents1"
        Me.ReportVersion1_SubContents1.PageHeight = 1100
        Me.ReportVersion1_SubContents1.PageWidth = 850
        Me.ReportVersion1_SubContents1.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.ReportVersion1_SubContents1.Version = "14.2"
        '
        'ReportVersion1
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter, Me.PageFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(29, 36, 127, 13)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
        Me.Version = "14.2"
        CType(Me.ReportVersion1_SubContents1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ReportVersion1_SubContents1 As QualificationMatrixReport.ReportVersion1_SubContents
    Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents lblOfficer As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblEmployingCompanyAgency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblQualification As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNationality As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNationalCOC As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblSTCWRegulationHeld As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblIssuingCountry As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFlagCertOfCompetency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFlagEndorsement As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsWithCompany As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsInRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsOnThisTypeOfTanker As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsOnAllTypeOfTanker As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblEnglishProficiency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMonthsOnTheVesselThisVoyage As DevExpress.XtraReports.UI.XRLabel
End Class
