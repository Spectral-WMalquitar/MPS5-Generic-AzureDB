<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportVersion3
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
        Me.lblRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNationality = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCertificateOfCompetency = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblIssuingCountry = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAdministrationAcceptance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDECSatisfactoryProof = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblISPSFamiliarizationCourse = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSSBTCourse = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBRMTraining = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBTMTrainingCourse = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYrsWithOperator = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYearsInRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYrsOnTankerType = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblYrsOnAllTypeOfTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblEnglishProficiency = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFlag = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVesselType = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVesselNameDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblISPSTrainingCourse = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblISPSTrainingCourse, Me.lblRank, Me.lblNationality, Me.lblCertificateOfCompetency, Me.lblIssuingCountry, Me.lblAdministrationAcceptance, Me.lblDECSatisfactoryProof, Me.lblISPSFamiliarizationCourse, Me.lblSSBTCourse, Me.lblBRMTraining, Me.lblBTMTrainingCourse, Me.lblYrsWithOperator, Me.lblYearsInRank, Me.lblYrsOnTankerType, Me.lblYrsOnAllTypeOfTanker, Me.lblEnglishProficiency, Me.XrLabel2})
        Me.Detail.HeightF = 930.1536!
        Me.Detail.MultiColumn.ColumnCount = 6
        Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblRank
        '
        Me.lblRank.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRank.BorderWidth = 1.0!
        Me.lblRank.CanGrow = False
        Me.lblRank.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRank.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 4.629633!)
        Me.lblRank.Name = "lblRank"
        Me.lblRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRank.SizeF = New System.Drawing.SizeF(125.0!, 48.00002!)
        Me.lblRank.StylePriority.UseBorders = False
        Me.lblRank.StylePriority.UseBorderWidth = False
        Me.lblRank.StylePriority.UseFont = False
        Me.lblRank.StylePriority.UseTextAlignment = False
        Me.lblRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblNationality
        '
        Me.lblNationality.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNationality.BorderWidth = 1.0!
        Me.lblNationality.CanGrow = False
        Me.lblNationality.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNationality.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 51.62968!)
        Me.lblNationality.Name = "lblNationality"
        Me.lblNationality.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNationality.SizeF = New System.Drawing.SizeF(125.0!, 48.00002!)
        Me.lblNationality.StylePriority.UseBorders = False
        Me.lblNationality.StylePriority.UseBorderWidth = False
        Me.lblNationality.StylePriority.UseFont = False
        Me.lblNationality.StylePriority.UseTextAlignment = False
        Me.lblNationality.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCertificateOfCompetency
        '
        Me.lblCertificateOfCompetency.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCertificateOfCompetency.BorderWidth = 1.0!
        Me.lblCertificateOfCompetency.CanGrow = False
        Me.lblCertificateOfCompetency.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCertificateOfCompetency.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 98.62972!)
        Me.lblCertificateOfCompetency.Name = "lblCertificateOfCompetency"
        Me.lblCertificateOfCompetency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCertificateOfCompetency.SizeF = New System.Drawing.SizeF(125.0!, 48.00001!)
        Me.lblCertificateOfCompetency.StylePriority.UseBorders = False
        Me.lblCertificateOfCompetency.StylePriority.UseBorderWidth = False
        Me.lblCertificateOfCompetency.StylePriority.UseFont = False
        Me.lblCertificateOfCompetency.StylePriority.UseTextAlignment = False
        Me.lblCertificateOfCompetency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblIssuingCountry
        '
        Me.lblIssuingCountry.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblIssuingCountry.BorderWidth = 1.0!
        Me.lblIssuingCountry.CanGrow = False
        Me.lblIssuingCountry.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssuingCountry.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 145.6298!)
        Me.lblIssuingCountry.Name = "lblIssuingCountry"
        Me.lblIssuingCountry.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblIssuingCountry.SizeF = New System.Drawing.SizeF(125.0!, 48.00002!)
        Me.lblIssuingCountry.StylePriority.UseBorders = False
        Me.lblIssuingCountry.StylePriority.UseBorderWidth = False
        Me.lblIssuingCountry.StylePriority.UseFont = False
        Me.lblIssuingCountry.StylePriority.UseTextAlignment = False
        Me.lblIssuingCountry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAdministrationAcceptance
        '
        Me.lblAdministrationAcceptance.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAdministrationAcceptance.BorderWidth = 1.0!
        Me.lblAdministrationAcceptance.CanGrow = False
        Me.lblAdministrationAcceptance.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdministrationAcceptance.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 192.6297!)
        Me.lblAdministrationAcceptance.Name = "lblAdministrationAcceptance"
        Me.lblAdministrationAcceptance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAdministrationAcceptance.SizeF = New System.Drawing.SizeF(125.0!, 48.00002!)
        Me.lblAdministrationAcceptance.StylePriority.UseBorders = False
        Me.lblAdministrationAcceptance.StylePriority.UseBorderWidth = False
        Me.lblAdministrationAcceptance.StylePriority.UseFont = False
        Me.lblAdministrationAcceptance.StylePriority.UseTextAlignment = False
        Me.lblAdministrationAcceptance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDECSatisfactoryProof
        '
        Me.lblDECSatisfactoryProof.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDECSatisfactoryProof.BorderWidth = 1.0!
        Me.lblDECSatisfactoryProof.CanGrow = False
        Me.lblDECSatisfactoryProof.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDECSatisfactoryProof.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 239.6297!)
        Me.lblDECSatisfactoryProof.Name = "lblDECSatisfactoryProof"
        Me.lblDECSatisfactoryProof.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDECSatisfactoryProof.SizeF = New System.Drawing.SizeF(125.0!, 48.00005!)
        Me.lblDECSatisfactoryProof.StylePriority.UseBorders = False
        Me.lblDECSatisfactoryProof.StylePriority.UseBorderWidth = False
        Me.lblDECSatisfactoryProof.StylePriority.UseFont = False
        Me.lblDECSatisfactoryProof.StylePriority.UseTextAlignment = False
        Me.lblDECSatisfactoryProof.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblISPSFamiliarizationCourse
        '
        Me.lblISPSFamiliarizationCourse.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblISPSFamiliarizationCourse.BorderWidth = 1.0!
        Me.lblISPSFamiliarizationCourse.CanGrow = False
        Me.lblISPSFamiliarizationCourse.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblISPSFamiliarizationCourse.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 333.455!)
        Me.lblISPSFamiliarizationCourse.Name = "lblISPSFamiliarizationCourse"
        Me.lblISPSFamiliarizationCourse.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblISPSFamiliarizationCourse.SizeF = New System.Drawing.SizeF(125.0!, 48.0!)
        Me.lblISPSFamiliarizationCourse.StylePriority.UseBorders = False
        Me.lblISPSFamiliarizationCourse.StylePriority.UseBorderWidth = False
        Me.lblISPSFamiliarizationCourse.StylePriority.UseFont = False
        Me.lblISPSFamiliarizationCourse.StylePriority.UseTextAlignment = False
        Me.lblISPSFamiliarizationCourse.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblSSBTCourse
        '
        Me.lblSSBTCourse.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblSSBTCourse.BorderWidth = 1.0!
        Me.lblSSBTCourse.CanGrow = False
        Me.lblSSBTCourse.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSSBTCourse.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 380.455!)
        Me.lblSSBTCourse.Name = "lblSSBTCourse"
        Me.lblSSBTCourse.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSSBTCourse.SizeF = New System.Drawing.SizeF(125.0!, 48.00003!)
        Me.lblSSBTCourse.StylePriority.UseBorders = False
        Me.lblSSBTCourse.StylePriority.UseBorderWidth = False
        Me.lblSSBTCourse.StylePriority.UseFont = False
        Me.lblSSBTCourse.StylePriority.UseTextAlignment = False
        Me.lblSSBTCourse.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBRMTraining
        '
        Me.lblBRMTraining.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBRMTraining.BorderWidth = 1.0!
        Me.lblBRMTraining.CanGrow = False
        Me.lblBRMTraining.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBRMTraining.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 427.4549!)
        Me.lblBRMTraining.Name = "lblBRMTraining"
        Me.lblBRMTraining.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBRMTraining.SizeF = New System.Drawing.SizeF(125.0!, 47.00003!)
        Me.lblBRMTraining.StylePriority.UseBorders = False
        Me.lblBRMTraining.StylePriority.UseBorderWidth = False
        Me.lblBRMTraining.StylePriority.UseFont = False
        Me.lblBRMTraining.StylePriority.UseTextAlignment = False
        Me.lblBRMTraining.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBTMTrainingCourse
        '
        Me.lblBTMTrainingCourse.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBTMTrainingCourse.BorderWidth = 1.0!
        Me.lblBTMTrainingCourse.CanGrow = False
        Me.lblBTMTrainingCourse.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBTMTrainingCourse.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 473.455!)
        Me.lblBTMTrainingCourse.Name = "lblBTMTrainingCourse"
        Me.lblBTMTrainingCourse.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBTMTrainingCourse.SizeF = New System.Drawing.SizeF(125.0!, 48.00003!)
        Me.lblBTMTrainingCourse.StylePriority.UseBorders = False
        Me.lblBTMTrainingCourse.StylePriority.UseBorderWidth = False
        Me.lblBTMTrainingCourse.StylePriority.UseFont = False
        Me.lblBTMTrainingCourse.StylePriority.UseTextAlignment = False
        Me.lblBTMTrainingCourse.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYrsWithOperator
        '
        Me.lblYrsWithOperator.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYrsWithOperator.BorderWidth = 1.0!
        Me.lblYrsWithOperator.CanGrow = False
        Me.lblYrsWithOperator.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYrsWithOperator.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 520.455!)
        Me.lblYrsWithOperator.Name = "lblYrsWithOperator"
        Me.lblYrsWithOperator.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYrsWithOperator.SizeF = New System.Drawing.SizeF(125.0!, 48.00003!)
        Me.lblYrsWithOperator.StylePriority.UseBorders = False
        Me.lblYrsWithOperator.StylePriority.UseBorderWidth = False
        Me.lblYrsWithOperator.StylePriority.UseFont = False
        Me.lblYrsWithOperator.StylePriority.UseTextAlignment = False
        Me.lblYrsWithOperator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYearsInRank
        '
        Me.lblYearsInRank.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYearsInRank.BorderWidth = 1.0!
        Me.lblYearsInRank.CanGrow = False
        Me.lblYearsInRank.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearsInRank.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 567.455!)
        Me.lblYearsInRank.Name = "lblYearsInRank"
        Me.lblYearsInRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYearsInRank.SizeF = New System.Drawing.SizeF(125.0!, 47.99994!)
        Me.lblYearsInRank.StylePriority.UseBorders = False
        Me.lblYearsInRank.StylePriority.UseBorderWidth = False
        Me.lblYearsInRank.StylePriority.UseFont = False
        Me.lblYearsInRank.StylePriority.UseTextAlignment = False
        Me.lblYearsInRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYrsOnTankerType
        '
        Me.lblYrsOnTankerType.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYrsOnTankerType.BorderWidth = 1.0!
        Me.lblYrsOnTankerType.CanGrow = False
        Me.lblYrsOnTankerType.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYrsOnTankerType.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 614.4551!)
        Me.lblYrsOnTankerType.Name = "lblYrsOnTankerType"
        Me.lblYrsOnTankerType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYrsOnTankerType.SizeF = New System.Drawing.SizeF(125.0!, 47.99988!)
        Me.lblYrsOnTankerType.StylePriority.UseBorders = False
        Me.lblYrsOnTankerType.StylePriority.UseBorderWidth = False
        Me.lblYrsOnTankerType.StylePriority.UseFont = False
        Me.lblYrsOnTankerType.StylePriority.UseTextAlignment = False
        Me.lblYrsOnTankerType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblYrsOnAllTypeOfTanker
        '
        Me.lblYrsOnAllTypeOfTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblYrsOnAllTypeOfTanker.BorderWidth = 1.0!
        Me.lblYrsOnAllTypeOfTanker.CanGrow = False
        Me.lblYrsOnAllTypeOfTanker.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYrsOnAllTypeOfTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 661.4551!)
        Me.lblYrsOnAllTypeOfTanker.Name = "lblYrsOnAllTypeOfTanker"
        Me.lblYrsOnAllTypeOfTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblYrsOnAllTypeOfTanker.SizeF = New System.Drawing.SizeF(125.0!, 48.0!)
        Me.lblYrsOnAllTypeOfTanker.StylePriority.UseBorders = False
        Me.lblYrsOnAllTypeOfTanker.StylePriority.UseBorderWidth = False
        Me.lblYrsOnAllTypeOfTanker.StylePriority.UseFont = False
        Me.lblYrsOnAllTypeOfTanker.StylePriority.UseTextAlignment = False
        Me.lblYrsOnAllTypeOfTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblEnglishProficiency
        '
        Me.lblEnglishProficiency.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblEnglishProficiency.BorderWidth = 1.0!
        Me.lblEnglishProficiency.CanGrow = False
        Me.lblEnglishProficiency.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnglishProficiency.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 708.455!)
        Me.lblEnglishProficiency.Name = "lblEnglishProficiency"
        Me.lblEnglishProficiency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblEnglishProficiency.SizeF = New System.Drawing.SizeF(125.0!, 48.0!)
        Me.lblEnglishProficiency.StylePriority.UseBorders = False
        Me.lblEnglishProficiency.StylePriority.UseBorderWidth = False
        Me.lblEnglishProficiency.StylePriority.UseFont = False
        Me.lblEnglishProficiency.StylePriority.UseTextAlignment = False
        Me.lblEnglishProficiency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel4, Me.lblFlag, Me.lblVesselType, Me.XrLabel1, Me.lblVesselNameDate})
        Me.TopMargin.HeightF = 173.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.BorderWidth = 2.0!
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 123.5833!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(51.08331!, 25.08334!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseBorderWidth = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "TYPE:"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.BorderWidth = 2.0!
        Me.XrLabel4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 147.6667!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(51.08331!, 25.08334!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseBorderWidth = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "FLAG:"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblFlag
        '
        Me.lblFlag.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblFlag.BorderWidth = 2.0!
        Me.lblFlag.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlag.LocationFloat = New DevExpress.Utils.PointFloat(55.08331!, 147.6667!)
        Me.lblFlag.Name = "lblFlag"
        Me.lblFlag.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFlag.SizeF = New System.Drawing.SizeF(693.9166!, 25.08333!)
        Me.lblFlag.StylePriority.UseBorders = False
        Me.lblFlag.StylePriority.UseBorderWidth = False
        Me.lblFlag.StylePriority.UseFont = False
        Me.lblFlag.StylePriority.UseTextAlignment = False
        Me.lblFlag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblVesselType
        '
        Me.lblVesselType.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblVesselType.BorderWidth = 2.0!
        Me.lblVesselType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVesselType.LocationFloat = New DevExpress.Utils.PointFloat(55.08331!, 123.5833!)
        Me.lblVesselType.Name = "lblVesselType"
        Me.lblVesselType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVesselType.SizeF = New System.Drawing.SizeF(693.9166!, 25.08334!)
        Me.lblVesselType.StylePriority.UseBorders = False
        Me.lblVesselType.StylePriority.UseBorderWidth = False
        Me.lblVesselType.StylePriority.UseFont = False
        Me.lblVesselType.StylePriority.UseTextAlignment = False
        Me.lblVesselType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.BorderWidth = 2.0!
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 50.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(749.0!, 25.08334!)
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseBorderWidth = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "QUALIFICATION OF OFFICERS"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblVesselNameDate
        '
        Me.lblVesselNameDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblVesselNameDate.BorderWidth = 2.0!
        Me.lblVesselNameDate.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVesselNameDate.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 79.91665!)
        Me.lblVesselNameDate.Name = "lblVesselNameDate"
        Me.lblVesselNameDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVesselNameDate.SizeF = New System.Drawing.SizeF(749.0!, 25.08335!)
        Me.lblVesselNameDate.StylePriority.UseBorders = False
        Me.lblVesselNameDate.StylePriority.UseBorderWidth = False
        Me.lblVesselNameDate.StylePriority.UseFont = False
        Me.lblVesselNameDate.StylePriority.UseTextAlignment = False
        Me.lblVesselNameDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        'PageFooter
        '
        Me.PageFooter.HeightF = 13.39287!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.BorderWidth = 1.0!
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 879.2867!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(116.0998!, 48.0!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseBorderWidth = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblISPSTrainingCourse
        '
        Me.lblISPSTrainingCourse.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblISPSTrainingCourse.BorderWidth = 1.0!
        Me.lblISPSTrainingCourse.CanGrow = False
        Me.lblISPSTrainingCourse.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblISPSTrainingCourse.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 286.455!)
        Me.lblISPSTrainingCourse.Name = "lblISPSTrainingCourse"
        Me.lblISPSTrainingCourse.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblISPSTrainingCourse.SizeF = New System.Drawing.SizeF(125.0!, 48.00005!)
        Me.lblISPSTrainingCourse.StylePriority.UseBorders = False
        Me.lblISPSTrainingCourse.StylePriority.UseBorderWidth = False
        Me.lblISPSTrainingCourse.StylePriority.UseFont = False
        Me.lblISPSTrainingCourse.StylePriority.UseTextAlignment = False
        Me.lblISPSTrainingCourse.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportVersion3
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 173, 0)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFlag As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVesselType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVesselNameDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNationality As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCertificateOfCompetency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblIssuingCountry As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAdministrationAcceptance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDECSatisfactoryProof As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblISPSFamiliarizationCourse As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblSSBTCourse As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBRMTraining As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBTMTrainingCourse As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYrsWithOperator As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYearsInRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYrsOnTankerType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblYrsOnAllTypeOfTanker As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblEnglishProficiency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblISPSTrainingCourse As DevExpress.XtraReports.UI.XRLabel
End Class
