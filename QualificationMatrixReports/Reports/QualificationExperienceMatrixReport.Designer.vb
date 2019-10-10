<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class QualificationExperienceMatrixReport
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
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVesselName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.pbLogoPhoto = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.lblQualificationOfficers = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNationality = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNationalCOC = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblIssuingCountry = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAdministrationAcceptance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDangerousCargoEndorsement = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRadioQualification = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSTCWEndorsement = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsWithPrincipal = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsInRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsOnThisTypeOfTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsOnAllTypeOfTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblEnglishProficiency = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMonthsOnTheVesselThisTourOfDuty = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblQualificationOfficers, Me.lblNationality, Me.lblNationalCOC, Me.lblIssuingCountry, Me.lblAdministrationAcceptance, Me.lblDangerousCargoEndorsement, Me.lblRadioQualification, Me.lblSTCWEndorsement, Me.lblYearsWithPrincipal, Me.lblYearsInRank, Me.lblYearsOnThisTypeOfTanker, Me.lblYearsOnAllTypeOfTanker, Me.lblEnglishProficiency, Me.lblMonthsOnTheVesselThisTourOfDuty})
        Me.Detail.HeightF = 468.902!
        Me.Detail.MultiColumn.ColumnCount = 7
        Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pbLogoPhoto, Me.XrLabel1, Me.lblVesselName, Me.XrLabel4, Me.XrLabel3, Me.lblDate})
        Me.TopMargin.HeightF = 192.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.HeightF = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(250.3805!, 26.66667!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(651.6611!, 30.29167!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "OFFICERS' QUALIFICATION & EXPERIENCE MATRIX"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblVesselName
        '
        Me.lblVesselName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblVesselName.BorderWidth = 2.0!
        Me.lblVesselName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVesselName.LocationFloat = New DevExpress.Utils.PointFloat(101.0833!, 139.6667!)
        Me.lblVesselName.Name = "lblVesselName"
        Me.lblVesselName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVesselName.SizeF = New System.Drawing.SizeF(899.9167!, 25.08334!)
        Me.lblVesselName.StylePriority.UseBorders = False
        Me.lblVesselName.StylePriority.UseBorderWidth = False
        Me.lblVesselName.StylePriority.UseFont = False
        Me.lblVesselName.StylePriority.UseTextAlignment = False
        Me.lblVesselName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.BorderWidth = 2.0!
        Me.XrLabel4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 166.7502!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(101.0833!, 25.08334!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseBorderWidth = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "DATE            :"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.BorderWidth = 2.0!
        Me.XrLabel3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 139.6667!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(101.0833!, 25.08334!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseBorderWidth = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "SHIP NAME  :"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblDate
        '
        Me.lblDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblDate.BorderWidth = 2.0!
        Me.lblDate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.LocationFloat = New DevExpress.Utils.PointFloat(101.0833!, 166.7502!)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDate.SizeF = New System.Drawing.SizeF(899.9167!, 25.08334!)
        Me.lblDate.StylePriority.UseBorders = False
        Me.lblDate.StylePriority.UseBorderWidth = False
        Me.lblDate.StylePriority.UseFont = False
        Me.lblDate.StylePriority.UseTextAlignment = False
        Me.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'pbLogoPhoto
        '
        Me.pbLogoPhoto.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 26.66667!)
        Me.pbLogoPhoto.Name = "pbLogoPhoto"
        Me.pbLogoPhoto.SizeF = New System.Drawing.SizeF(225.3805!, 98.41674!)
        Me.pbLogoPhoto.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'lblQualificationOfficers
        '
        Me.lblQualificationOfficers.BorderColor = System.Drawing.Color.DarkGray
        Me.lblQualificationOfficers.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblQualificationOfficers.BorderWidth = 0.5!
        Me.lblQualificationOfficers.CanGrow = False
        Me.lblQualificationOfficers.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQualificationOfficers.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.04164505!)
        Me.lblQualificationOfficers.Name = "lblQualificationOfficers"
        Me.lblQualificationOfficers.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblQualificationOfficers.SizeF = New System.Drawing.SizeF(142.2084!, 36.95834!)
        Me.lblQualificationOfficers.StylePriority.UseBorderColor = False
        Me.lblQualificationOfficers.StylePriority.UseBorders = False
        Me.lblQualificationOfficers.StylePriority.UseBorderWidth = False
        Me.lblQualificationOfficers.StylePriority.UseFont = False
        Me.lblQualificationOfficers.StylePriority.UseTextAlignment = False
        Me.lblQualificationOfficers.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblNationality
        '
        Me.lblNationality.BorderColor = System.Drawing.Color.DarkGray
        Me.lblNationality.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNationality.BorderWidth = 0.5!
        Me.lblNationality.CanGrow = False
        Me.lblNationality.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNationality.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 36.99998!)
        Me.lblNationality.Name = "lblNationality"
        Me.lblNationality.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNationality.SizeF = New System.Drawing.SizeF(142.2084!, 26.54168!)
        Me.lblNationality.StylePriority.UseBorderColor = False
        Me.lblNationality.StylePriority.UseBorders = False
        Me.lblNationality.StylePriority.UseBorderWidth = False
        Me.lblNationality.StylePriority.UseFont = False
        Me.lblNationality.StylePriority.UseTextAlignment = False
        Me.lblNationality.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblNationalCOC
        '
        Me.lblNationalCOC.BorderColor = System.Drawing.Color.DarkGray
        Me.lblNationalCOC.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNationalCOC.BorderWidth = 0.5!
        Me.lblNationalCOC.CanGrow = False
        Me.lblNationalCOC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNationalCOC.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 63.5417!)
        Me.lblNationalCOC.Name = "lblNationalCOC"
        Me.lblNationalCOC.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNationalCOC.SizeF = New System.Drawing.SizeF(142.2084!, 36.95834!)
        Me.lblNationalCOC.StylePriority.UseBorderColor = False
        Me.lblNationalCOC.StylePriority.UseBorders = False
        Me.lblNationalCOC.StylePriority.UseBorderWidth = False
        Me.lblNationalCOC.StylePriority.UseFont = False
        Me.lblNationalCOC.StylePriority.UseTextAlignment = False
        Me.lblNationalCOC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblIssuingCountry
        '
        Me.lblIssuingCountry.BorderColor = System.Drawing.Color.DarkGray
        Me.lblIssuingCountry.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblIssuingCountry.BorderWidth = 0.5!
        Me.lblIssuingCountry.CanGrow = False
        Me.lblIssuingCountry.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssuingCountry.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 100.5001!)
        Me.lblIssuingCountry.Name = "lblIssuingCountry"
        Me.lblIssuingCountry.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblIssuingCountry.SizeF = New System.Drawing.SizeF(142.2084!, 26.54168!)
        Me.lblIssuingCountry.StylePriority.UseBorderColor = False
        Me.lblIssuingCountry.StylePriority.UseBorders = False
        Me.lblIssuingCountry.StylePriority.UseBorderWidth = False
        Me.lblIssuingCountry.StylePriority.UseFont = False
        Me.lblIssuingCountry.StylePriority.UseTextAlignment = False
        Me.lblIssuingCountry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblAdministrationAcceptance
        '
        Me.lblAdministrationAcceptance.BorderColor = System.Drawing.Color.DarkGray
        Me.lblAdministrationAcceptance.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAdministrationAcceptance.BorderWidth = 0.5!
        Me.lblAdministrationAcceptance.CanGrow = False
        Me.lblAdministrationAcceptance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdministrationAcceptance.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 127.0418!)
        Me.lblAdministrationAcceptance.Name = "lblAdministrationAcceptance"
        Me.lblAdministrationAcceptance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAdministrationAcceptance.SizeF = New System.Drawing.SizeF(142.2084!, 36.95834!)
        Me.lblAdministrationAcceptance.StylePriority.UseBorderColor = False
        Me.lblAdministrationAcceptance.StylePriority.UseBorders = False
        Me.lblAdministrationAcceptance.StylePriority.UseBorderWidth = False
        Me.lblAdministrationAcceptance.StylePriority.UseFont = False
        Me.lblAdministrationAcceptance.StylePriority.UseTextAlignment = False
        Me.lblAdministrationAcceptance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblDangerousCargoEndorsement
        '
        Me.lblDangerousCargoEndorsement.BorderColor = System.Drawing.Color.DarkGray
        Me.lblDangerousCargoEndorsement.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDangerousCargoEndorsement.BorderWidth = 0.5!
        Me.lblDangerousCargoEndorsement.CanGrow = False
        Me.lblDangerousCargoEndorsement.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDangerousCargoEndorsement.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 164.0!)
        Me.lblDangerousCargoEndorsement.Name = "lblDangerousCargoEndorsement"
        Me.lblDangerousCargoEndorsement.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDangerousCargoEndorsement.SizeF = New System.Drawing.SizeF(142.2084!, 36.67046!)
        Me.lblDangerousCargoEndorsement.StylePriority.UseBorderColor = False
        Me.lblDangerousCargoEndorsement.StylePriority.UseBorders = False
        Me.lblDangerousCargoEndorsement.StylePriority.UseBorderWidth = False
        Me.lblDangerousCargoEndorsement.StylePriority.UseFont = False
        Me.lblDangerousCargoEndorsement.StylePriority.UseTextAlignment = False
        Me.lblDangerousCargoEndorsement.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblRadioQualification
        '
        Me.lblRadioQualification.BorderColor = System.Drawing.Color.DarkGray
        Me.lblRadioQualification.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRadioQualification.BorderWidth = 0.5!
        Me.lblRadioQualification.CanGrow = False
        Me.lblRadioQualification.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRadioQualification.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 238.85!)
        Me.lblRadioQualification.Name = "lblRadioQualification"
        Me.lblRadioQualification.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRadioQualification.SizeF = New System.Drawing.SizeF(142.2084!, 26.54167!)
        Me.lblRadioQualification.StylePriority.UseBorderColor = False
        Me.lblRadioQualification.StylePriority.UseBorders = False
        Me.lblRadioQualification.StylePriority.UseBorderWidth = False
        Me.lblRadioQualification.StylePriority.UseFont = False
        Me.lblRadioQualification.StylePriority.UseTextAlignment = False
        Me.lblRadioQualification.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblSTCWEndorsement
        '
        Me.lblSTCWEndorsement.BorderColor = System.Drawing.Color.DarkGray
        Me.lblSTCWEndorsement.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblSTCWEndorsement.BorderWidth = 0.5!
        Me.lblSTCWEndorsement.CanGrow = False
        Me.lblSTCWEndorsement.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTCWEndorsement.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 200.7!)
        Me.lblSTCWEndorsement.Name = "lblSTCWEndorsement"
        Me.lblSTCWEndorsement.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSTCWEndorsement.SizeF = New System.Drawing.SizeF(142.2084!, 38.0417!)
        Me.lblSTCWEndorsement.StylePriority.UseBorderColor = False
        Me.lblSTCWEndorsement.StylePriority.UseBorders = False
        Me.lblSTCWEndorsement.StylePriority.UseBorderWidth = False
        Me.lblSTCWEndorsement.StylePriority.UseFont = False
        Me.lblSTCWEndorsement.StylePriority.UseTextAlignment = False
        Me.lblSTCWEndorsement.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblYearsWithPrincipal
        '
        Me.lblYearsWithPrincipal.BorderColor = System.Drawing.Color.DarkGray
        Me.lblYearsWithPrincipal.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsWithPrincipal.BorderWidth = 0.5!
        Me.lblYearsWithPrincipal.CanGrow = False
        Me.lblYearsWithPrincipal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsWithPrincipal.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 265.4!)
        Me.lblYearsWithPrincipal.Name = "lblYearsWithPrincipal"
        Me.lblYearsWithPrincipal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsWithPrincipal.SizeF = New System.Drawing.SizeF(142.2084!, 25.54163!)
        Me.lblYearsWithPrincipal.StylePriority.UseBorderColor = False
        Me.lblYearsWithPrincipal.StylePriority.UseBorders = False
        Me.lblYearsWithPrincipal.StylePriority.UseBorderWidth = False
        Me.lblYearsWithPrincipal.StylePriority.UseFont = False
        Me.lblYearsWithPrincipal.StylePriority.UseTextAlignment = False
        Me.lblYearsWithPrincipal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblYearsInRank
        '
        Me.lblYearsInRank.BorderColor = System.Drawing.Color.DarkGray
        Me.lblYearsInRank.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsInRank.BorderWidth = 0.5!
        Me.lblYearsInRank.CanGrow = False
        Me.lblYearsInRank.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsInRank.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 291.0!)
        Me.lblYearsInRank.Name = "lblYearsInRank"
        Me.lblYearsInRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsInRank.SizeF = New System.Drawing.SizeF(142.2084!, 26.54169!)
        Me.lblYearsInRank.StylePriority.UseBorderColor = False
        Me.lblYearsInRank.StylePriority.UseBorders = False
        Me.lblYearsInRank.StylePriority.UseBorderWidth = False
        Me.lblYearsInRank.StylePriority.UseFont = False
        Me.lblYearsInRank.StylePriority.UseTextAlignment = False
        Me.lblYearsInRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblYearsOnThisTypeOfTanker
        '
        Me.lblYearsOnThisTypeOfTanker.BorderColor = System.Drawing.Color.DarkGray
        Me.lblYearsOnThisTypeOfTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsOnThisTypeOfTanker.BorderWidth = 0.5!
        Me.lblYearsOnThisTypeOfTanker.CanGrow = False
        Me.lblYearsOnThisTypeOfTanker.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsOnThisTypeOfTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 317.6!)
        Me.lblYearsOnThisTypeOfTanker.Name = "lblYearsOnThisTypeOfTanker"
        Me.lblYearsOnThisTypeOfTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsOnThisTypeOfTanker.SizeF = New System.Drawing.SizeF(142.2084!, 36.95834!)
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseBorderColor = False
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseBorders = False
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseBorderWidth = False
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseFont = False
        Me.lblYearsOnThisTypeOfTanker.StylePriority.UseTextAlignment = False
        Me.lblYearsOnThisTypeOfTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblYearsOnAllTypeOfTanker
        '
        Me.lblYearsOnAllTypeOfTanker.BorderColor = System.Drawing.Color.DarkGray
        Me.lblYearsOnAllTypeOfTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsOnAllTypeOfTanker.BorderWidth = 0.5!
        Me.lblYearsOnAllTypeOfTanker.CanGrow = False
        Me.lblYearsOnAllTypeOfTanker.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsOnAllTypeOfTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 354.6!)
        Me.lblYearsOnAllTypeOfTanker.Name = "lblYearsOnAllTypeOfTanker"
        Me.lblYearsOnAllTypeOfTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsOnAllTypeOfTanker.SizeF = New System.Drawing.SizeF(142.2084!, 36.95834!)
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseBorderColor = False
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseBorders = False
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseBorderWidth = False
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseFont = False
        Me.lblYearsOnAllTypeOfTanker.StylePriority.UseTextAlignment = False
        Me.lblYearsOnAllTypeOfTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblEnglishProficiency
        '
        Me.lblEnglishProficiency.BorderColor = System.Drawing.Color.DarkGray
        Me.lblEnglishProficiency.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblEnglishProficiency.BorderWidth = 0.5!
        Me.lblEnglishProficiency.CanGrow = False
        Me.lblEnglishProficiency.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnglishProficiency.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 428.6!)
        Me.lblEnglishProficiency.Name = "lblEnglishProficiency"
        Me.lblEnglishProficiency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblEnglishProficiency.SizeF = New System.Drawing.SizeF(142.2084!, 36.95834!)
        Me.lblEnglishProficiency.StylePriority.UseBorderColor = False
        Me.lblEnglishProficiency.StylePriority.UseBorders = False
        Me.lblEnglishProficiency.StylePriority.UseBorderWidth = False
        Me.lblEnglishProficiency.StylePriority.UseFont = False
        Me.lblEnglishProficiency.StylePriority.UseTextAlignment = False
        Me.lblEnglishProficiency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblMonthsOnTheVesselThisTourOfDuty
        '
        Me.lblMonthsOnTheVesselThisTourOfDuty.BorderColor = System.Drawing.Color.DarkGray
        Me.lblMonthsOnTheVesselThisTourOfDuty.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMonthsOnTheVesselThisTourOfDuty.BorderWidth = 0.5!
        Me.lblMonthsOnTheVesselThisTourOfDuty.CanGrow = False
        Me.lblMonthsOnTheVesselThisTourOfDuty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthsOnTheVesselThisTourOfDuty.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 391.6!)
        Me.lblMonthsOnTheVesselThisTourOfDuty.Name = "lblMonthsOnTheVesselThisTourOfDuty"
        Me.lblMonthsOnTheVesselThisTourOfDuty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMonthsOnTheVesselThisTourOfDuty.SizeF = New System.Drawing.SizeF(142.2084!, 36.95834!)
        Me.lblMonthsOnTheVesselThisTourOfDuty.StylePriority.UseBorderColor = False
        Me.lblMonthsOnTheVesselThisTourOfDuty.StylePriority.UseBorders = False
        Me.lblMonthsOnTheVesselThisTourOfDuty.StylePriority.UseBorderWidth = False
        Me.lblMonthsOnTheVesselThisTourOfDuty.StylePriority.UseFont = False
        Me.lblMonthsOnTheVesselThisTourOfDuty.StylePriority.UseTextAlignment = False
        Me.lblMonthsOnTheVesselThisTourOfDuty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'QualificationExperienceMatrixReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(51, 48, 192, 100)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVesselName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents pbLogoPhoto As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents lblQualificationOfficers As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNationality As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNationalCOC As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblIssuingCountry As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAdministrationAcceptance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDangerousCargoEndorsement As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRadioQualification As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblSTCWEndorsement As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsWithPrincipal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsInRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsOnThisTypeOfTanker As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsOnAllTypeOfTanker As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblEnglishProficiency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMonthsOnTheVesselThisTourOfDuty As DevExpress.XtraReports.UI.XRLabel
End Class
