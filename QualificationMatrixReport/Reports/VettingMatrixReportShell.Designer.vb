<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class VettingMatrixReportShell
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
        Me.lblTotalSum = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl2AE3AE_YrsCurrRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl2O3O_YrsCurrRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl2O3O_YrsTypeTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl2AE3AE_YrsTypeTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl2AE3AE_YrsWOperator = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl2O3O_YrsWOperator = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCE1AE_YrsTypeTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMSTCO_YrsTypeTanker = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCE1AE_YrsWOperator = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMSTCO_YrsWOperator = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCE1AE_YrsCurrRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMSTCO_YrsCurrRank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCrew = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.lblCharterer = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblVessel = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDatePrinted = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTotalSum, Me.lbl2AE3AE_YrsCurrRank, Me.lbl2O3O_YrsCurrRank, Me.lbl2O3O_YrsTypeTanker, Me.lbl2AE3AE_YrsTypeTanker, Me.lbl2AE3AE_YrsWOperator, Me.lbl2O3O_YrsWOperator, Me.lblCE1AE_YrsTypeTanker, Me.lblMSTCO_YrsTypeTanker, Me.lblCE1AE_YrsWOperator, Me.lblMSTCO_YrsWOperator, Me.lblCE1AE_YrsCurrRank, Me.lblMSTCO_YrsCurrRank, Me.lblCrew})
        Me.Detail.HeightF = 695.5834!
        Me.Detail.MultiColumn.ColumnCount = 9
        Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblTotalSum
        '
        Me.lblTotalSum.BorderColor = System.Drawing.Color.DarkGray
        Me.lblTotalSum.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalSum.BorderWidth = 1.0!
        Me.lblTotalSum.CanGrow = False
        Me.lblTotalSum.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSum.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 615.9584!)
        Me.lblTotalSum.Name = "lblTotalSum"
        Me.lblTotalSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalSum.SizeF = New System.Drawing.SizeF(115.7917!, 65.625!)
        Me.lblTotalSum.StylePriority.UseBorderColor = False
        Me.lblTotalSum.StylePriority.UseBorders = False
        Me.lblTotalSum.StylePriority.UseBorderWidth = False
        Me.lblTotalSum.StylePriority.UseFont = False
        Me.lblTotalSum.StylePriority.UseTextAlignment = False
        Me.lblTotalSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lbl2AE3AE_YrsCurrRank
        '
        Me.lbl2AE3AE_YrsCurrRank.BorderColor = System.Drawing.Color.DarkGray
        Me.lbl2AE3AE_YrsCurrRank.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl2AE3AE_YrsCurrRank.BorderWidth = 1.0!
        Me.lbl2AE3AE_YrsCurrRank.CanGrow = False
        Me.lbl2AE3AE_YrsCurrRank.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2AE3AE_YrsCurrRank.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 567.4584!)
        Me.lbl2AE3AE_YrsCurrRank.Name = "lbl2AE3AE_YrsCurrRank"
        Me.lbl2AE3AE_YrsCurrRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl2AE3AE_YrsCurrRank.SizeF = New System.Drawing.SizeF(115.7917!, 49.49994!)
        Me.lbl2AE3AE_YrsCurrRank.StylePriority.UseBorderColor = False
        Me.lbl2AE3AE_YrsCurrRank.StylePriority.UseBorders = False
        Me.lbl2AE3AE_YrsCurrRank.StylePriority.UseBorderWidth = False
        Me.lbl2AE3AE_YrsCurrRank.StylePriority.UseFont = False
        Me.lbl2AE3AE_YrsCurrRank.StylePriority.UseTextAlignment = False
        Me.lbl2AE3AE_YrsCurrRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lbl2O3O_YrsCurrRank
        '
        Me.lbl2O3O_YrsCurrRank.BorderColor = System.Drawing.Color.DarkGray
        Me.lbl2O3O_YrsCurrRank.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl2O3O_YrsCurrRank.BorderWidth = 1.0!
        Me.lbl2O3O_YrsCurrRank.CanGrow = False
        Me.lbl2O3O_YrsCurrRank.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2O3O_YrsCurrRank.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 518.9583!)
        Me.lbl2O3O_YrsCurrRank.Name = "lbl2O3O_YrsCurrRank"
        Me.lbl2O3O_YrsCurrRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl2O3O_YrsCurrRank.SizeF = New System.Drawing.SizeF(115.7917!, 49.50006!)
        Me.lbl2O3O_YrsCurrRank.StylePriority.UseBorderColor = False
        Me.lbl2O3O_YrsCurrRank.StylePriority.UseBorders = False
        Me.lbl2O3O_YrsCurrRank.StylePriority.UseBorderWidth = False
        Me.lbl2O3O_YrsCurrRank.StylePriority.UseFont = False
        Me.lbl2O3O_YrsCurrRank.StylePriority.UseTextAlignment = False
        Me.lbl2O3O_YrsCurrRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lbl2O3O_YrsTypeTanker
        '
        Me.lbl2O3O_YrsTypeTanker.BorderColor = System.Drawing.Color.DarkGray
        Me.lbl2O3O_YrsTypeTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl2O3O_YrsTypeTanker.BorderWidth = 1.0!
        Me.lbl2O3O_YrsTypeTanker.CanGrow = False
        Me.lbl2O3O_YrsTypeTanker.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2O3O_YrsTypeTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 421.9583!)
        Me.lbl2O3O_YrsTypeTanker.Name = "lbl2O3O_YrsTypeTanker"
        Me.lbl2O3O_YrsTypeTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl2O3O_YrsTypeTanker.SizeF = New System.Drawing.SizeF(115.7917!, 49.5!)
        Me.lbl2O3O_YrsTypeTanker.StylePriority.UseBorderColor = False
        Me.lbl2O3O_YrsTypeTanker.StylePriority.UseBorders = False
        Me.lbl2O3O_YrsTypeTanker.StylePriority.UseBorderWidth = False
        Me.lbl2O3O_YrsTypeTanker.StylePriority.UseFont = False
        Me.lbl2O3O_YrsTypeTanker.StylePriority.UseTextAlignment = False
        Me.lbl2O3O_YrsTypeTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lbl2AE3AE_YrsTypeTanker
        '
        Me.lbl2AE3AE_YrsTypeTanker.BorderColor = System.Drawing.Color.DarkGray
        Me.lbl2AE3AE_YrsTypeTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl2AE3AE_YrsTypeTanker.BorderWidth = 1.0!
        Me.lbl2AE3AE_YrsTypeTanker.CanGrow = False
        Me.lbl2AE3AE_YrsTypeTanker.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2AE3AE_YrsTypeTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 470.4583!)
        Me.lbl2AE3AE_YrsTypeTanker.Name = "lbl2AE3AE_YrsTypeTanker"
        Me.lbl2AE3AE_YrsTypeTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl2AE3AE_YrsTypeTanker.SizeF = New System.Drawing.SizeF(115.7917!, 49.49997!)
        Me.lbl2AE3AE_YrsTypeTanker.StylePriority.UseBorderColor = False
        Me.lbl2AE3AE_YrsTypeTanker.StylePriority.UseBorders = False
        Me.lbl2AE3AE_YrsTypeTanker.StylePriority.UseBorderWidth = False
        Me.lbl2AE3AE_YrsTypeTanker.StylePriority.UseFont = False
        Me.lbl2AE3AE_YrsTypeTanker.StylePriority.UseTextAlignment = False
        Me.lbl2AE3AE_YrsTypeTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lbl2AE3AE_YrsWOperator
        '
        Me.lbl2AE3AE_YrsWOperator.BorderColor = System.Drawing.Color.DarkGray
        Me.lbl2AE3AE_YrsWOperator.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl2AE3AE_YrsWOperator.BorderWidth = 1.0!
        Me.lbl2AE3AE_YrsWOperator.CanGrow = False
        Me.lbl2AE3AE_YrsWOperator.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2AE3AE_YrsWOperator.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 374.4583!)
        Me.lbl2AE3AE_YrsWOperator.Name = "lbl2AE3AE_YrsWOperator"
        Me.lbl2AE3AE_YrsWOperator.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl2AE3AE_YrsWOperator.SizeF = New System.Drawing.SizeF(115.7917!, 49.5!)
        Me.lbl2AE3AE_YrsWOperator.StylePriority.UseBorderColor = False
        Me.lbl2AE3AE_YrsWOperator.StylePriority.UseBorders = False
        Me.lbl2AE3AE_YrsWOperator.StylePriority.UseBorderWidth = False
        Me.lbl2AE3AE_YrsWOperator.StylePriority.UseFont = False
        Me.lbl2AE3AE_YrsWOperator.StylePriority.UseTextAlignment = False
        Me.lbl2AE3AE_YrsWOperator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lbl2O3O_YrsWOperator
        '
        Me.lbl2O3O_YrsWOperator.BorderColor = System.Drawing.Color.DarkGray
        Me.lbl2O3O_YrsWOperator.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl2O3O_YrsWOperator.BorderWidth = 1.0!
        Me.lbl2O3O_YrsWOperator.CanGrow = False
        Me.lbl2O3O_YrsWOperator.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2O3O_YrsWOperator.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 325.9583!)
        Me.lbl2O3O_YrsWOperator.Name = "lbl2O3O_YrsWOperator"
        Me.lbl2O3O_YrsWOperator.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl2O3O_YrsWOperator.SizeF = New System.Drawing.SizeF(115.7917!, 49.5!)
        Me.lbl2O3O_YrsWOperator.StylePriority.UseBorderColor = False
        Me.lbl2O3O_YrsWOperator.StylePriority.UseBorders = False
        Me.lbl2O3O_YrsWOperator.StylePriority.UseBorderWidth = False
        Me.lbl2O3O_YrsWOperator.StylePriority.UseFont = False
        Me.lbl2O3O_YrsWOperator.StylePriority.UseTextAlignment = False
        Me.lbl2O3O_YrsWOperator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCE1AE_YrsTypeTanker
        '
        Me.lblCE1AE_YrsTypeTanker.BorderColor = System.Drawing.Color.DarkGray
        Me.lblCE1AE_YrsTypeTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCE1AE_YrsTypeTanker.BorderWidth = 1.0!
        Me.lblCE1AE_YrsTypeTanker.CanGrow = False
        Me.lblCE1AE_YrsTypeTanker.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCE1AE_YrsTypeTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 277.4583!)
        Me.lblCE1AE_YrsTypeTanker.Name = "lblCE1AE_YrsTypeTanker"
        Me.lblCE1AE_YrsTypeTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCE1AE_YrsTypeTanker.SizeF = New System.Drawing.SizeF(115.7917!, 49.5!)
        Me.lblCE1AE_YrsTypeTanker.StylePriority.UseBorderColor = False
        Me.lblCE1AE_YrsTypeTanker.StylePriority.UseBorders = False
        Me.lblCE1AE_YrsTypeTanker.StylePriority.UseBorderWidth = False
        Me.lblCE1AE_YrsTypeTanker.StylePriority.UseFont = False
        Me.lblCE1AE_YrsTypeTanker.StylePriority.UseTextAlignment = False
        Me.lblCE1AE_YrsTypeTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblMSTCO_YrsTypeTanker
        '
        Me.lblMSTCO_YrsTypeTanker.BorderColor = System.Drawing.Color.DarkGray
        Me.lblMSTCO_YrsTypeTanker.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMSTCO_YrsTypeTanker.BorderWidth = 1.0!
        Me.lblMSTCO_YrsTypeTanker.CanGrow = False
        Me.lblMSTCO_YrsTypeTanker.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSTCO_YrsTypeTanker.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 228.9583!)
        Me.lblMSTCO_YrsTypeTanker.Name = "lblMSTCO_YrsTypeTanker"
        Me.lblMSTCO_YrsTypeTanker.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMSTCO_YrsTypeTanker.SizeF = New System.Drawing.SizeF(115.7917!, 49.49995!)
        Me.lblMSTCO_YrsTypeTanker.StylePriority.UseBorderColor = False
        Me.lblMSTCO_YrsTypeTanker.StylePriority.UseBorders = False
        Me.lblMSTCO_YrsTypeTanker.StylePriority.UseBorderWidth = False
        Me.lblMSTCO_YrsTypeTanker.StylePriority.UseFont = False
        Me.lblMSTCO_YrsTypeTanker.StylePriority.UseTextAlignment = False
        Me.lblMSTCO_YrsTypeTanker.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCE1AE_YrsWOperator
        '
        Me.lblCE1AE_YrsWOperator.BorderColor = System.Drawing.Color.DarkGray
        Me.lblCE1AE_YrsWOperator.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCE1AE_YrsWOperator.BorderWidth = 1.0!
        Me.lblCE1AE_YrsWOperator.CanGrow = False
        Me.lblCE1AE_YrsWOperator.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCE1AE_YrsWOperator.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 180.4583!)
        Me.lblCE1AE_YrsWOperator.Name = "lblCE1AE_YrsWOperator"
        Me.lblCE1AE_YrsWOperator.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCE1AE_YrsWOperator.SizeF = New System.Drawing.SizeF(115.7917!, 49.49998!)
        Me.lblCE1AE_YrsWOperator.StylePriority.UseBorderColor = False
        Me.lblCE1AE_YrsWOperator.StylePriority.UseBorders = False
        Me.lblCE1AE_YrsWOperator.StylePriority.UseBorderWidth = False
        Me.lblCE1AE_YrsWOperator.StylePriority.UseFont = False
        Me.lblCE1AE_YrsWOperator.StylePriority.UseTextAlignment = False
        Me.lblCE1AE_YrsWOperator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblMSTCO_YrsWOperator
        '
        Me.lblMSTCO_YrsWOperator.BorderColor = System.Drawing.Color.DarkGray
        Me.lblMSTCO_YrsWOperator.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMSTCO_YrsWOperator.BorderWidth = 1.0!
        Me.lblMSTCO_YrsWOperator.CanGrow = False
        Me.lblMSTCO_YrsWOperator.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSTCO_YrsWOperator.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 131.9583!)
        Me.lblMSTCO_YrsWOperator.Name = "lblMSTCO_YrsWOperator"
        Me.lblMSTCO_YrsWOperator.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMSTCO_YrsWOperator.SizeF = New System.Drawing.SizeF(115.7917!, 49.49998!)
        Me.lblMSTCO_YrsWOperator.StylePriority.UseBorderColor = False
        Me.lblMSTCO_YrsWOperator.StylePriority.UseBorders = False
        Me.lblMSTCO_YrsWOperator.StylePriority.UseBorderWidth = False
        Me.lblMSTCO_YrsWOperator.StylePriority.UseFont = False
        Me.lblMSTCO_YrsWOperator.StylePriority.UseTextAlignment = False
        Me.lblMSTCO_YrsWOperator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCE1AE_YrsCurrRank
        '
        Me.lblCE1AE_YrsCurrRank.BorderColor = System.Drawing.Color.DarkGray
        Me.lblCE1AE_YrsCurrRank.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCE1AE_YrsCurrRank.BorderWidth = 1.0!
        Me.lblCE1AE_YrsCurrRank.CanGrow = False
        Me.lblCE1AE_YrsCurrRank.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCE1AE_YrsCurrRank.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 83.45833!)
        Me.lblCE1AE_YrsCurrRank.Name = "lblCE1AE_YrsCurrRank"
        Me.lblCE1AE_YrsCurrRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCE1AE_YrsCurrRank.SizeF = New System.Drawing.SizeF(115.7917!, 49.49998!)
        Me.lblCE1AE_YrsCurrRank.StylePriority.UseBorderColor = False
        Me.lblCE1AE_YrsCurrRank.StylePriority.UseBorders = False
        Me.lblCE1AE_YrsCurrRank.StylePriority.UseBorderWidth = False
        Me.lblCE1AE_YrsCurrRank.StylePriority.UseFont = False
        Me.lblCE1AE_YrsCurrRank.StylePriority.UseTextAlignment = False
        Me.lblCE1AE_YrsCurrRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblMSTCO_YrsCurrRank
        '
        Me.lblMSTCO_YrsCurrRank.BorderColor = System.Drawing.Color.DarkGray
        Me.lblMSTCO_YrsCurrRank.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMSTCO_YrsCurrRank.BorderWidth = 1.0!
        Me.lblMSTCO_YrsCurrRank.CanGrow = False
        Me.lblMSTCO_YrsCurrRank.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSTCO_YrsCurrRank.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 34.95833!)
        Me.lblMSTCO_YrsCurrRank.Name = "lblMSTCO_YrsCurrRank"
        Me.lblMSTCO_YrsCurrRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMSTCO_YrsCurrRank.SizeF = New System.Drawing.SizeF(115.7917!, 49.49999!)
        Me.lblMSTCO_YrsCurrRank.StylePriority.UseBorderColor = False
        Me.lblMSTCO_YrsCurrRank.StylePriority.UseBorders = False
        Me.lblMSTCO_YrsCurrRank.StylePriority.UseBorderWidth = False
        Me.lblMSTCO_YrsCurrRank.StylePriority.UseFont = False
        Me.lblMSTCO_YrsCurrRank.StylePriority.UseTextAlignment = False
        Me.lblMSTCO_YrsCurrRank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCrew
        '
        Me.lblCrew.BorderColor = System.Drawing.Color.DarkGray
        Me.lblCrew.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCrew.BorderWidth = 1.0!
        Me.lblCrew.CanGrow = False
        Me.lblCrew.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrew.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblCrew.Name = "lblCrew"
        Me.lblCrew.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCrew.SizeF = New System.Drawing.SizeF(115.7917!, 35.95832!)
        Me.lblCrew.StylePriority.UseBorderColor = False
        Me.lblCrew.StylePriority.UseBorders = False
        Me.lblCrew.StylePriority.UseBorderWidth = False
        Me.lblCrew.StylePriority.UseFont = False
        Me.lblCrew.StylePriority.UseTextAlignment = False
        Me.lblCrew.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblCharterer, Me.lblVessel, Me.lblDatePrinted, Me.XrLabel4, Me.XrLabel2, Me.XrLabel1, Me.XrLabel3})
        Me.TopMargin.HeightF = 145.25!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblCharterer
        '
        Me.lblCharterer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharterer.LocationFloat = New DevExpress.Utils.PointFloat(100.625!, 76.25!)
        Me.lblCharterer.Name = "lblCharterer"
        Me.lblCharterer.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCharterer.SizeF = New System.Drawing.SizeF(934.3749!, 22.99998!)
        Me.lblCharterer.StylePriority.UseFont = False
        Me.lblCharterer.StylePriority.UseTextAlignment = False
        Me.lblCharterer.Text = "SHELL"
        Me.lblCharterer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblVessel
        '
        Me.lblVessel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVessel.LocationFloat = New DevExpress.Utils.PointFloat(100.625!, 99.25!)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblVessel.SizeF = New System.Drawing.SizeF(934.3749!, 23.0!)
        Me.lblVessel.StylePriority.UseFont = False
        Me.lblVessel.StylePriority.UseTextAlignment = False
        Me.lblVessel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblDatePrinted
        '
        Me.lblDatePrinted.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatePrinted.LocationFloat = New DevExpress.Utils.PointFloat(100.625!, 122.25!)
        Me.lblDatePrinted.Name = "lblDatePrinted"
        Me.lblDatePrinted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDatePrinted.SizeF = New System.Drawing.SizeF(934.3749!, 23.0!)
        Me.lblDatePrinted.StylePriority.UseFont = False
        Me.lblDatePrinted.StylePriority.UseTextAlignment = False
        Me.lblDatePrinted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 122.25!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(100.625!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Date Printed"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 99.25!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(100.625!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Vessel"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 76.25!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(100.625!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Charterer"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 48.75!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(1035.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Vetting Matrix Report"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 2.0!
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
        Me.PageFooter.HeightF = 50.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'VettingMatrixReportShell
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter, Me.PageFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(30, 30, 145, 2)
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
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblCharterer As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblVessel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDatePrinted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMSTCO_YrsTypeTanker As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCE1AE_YrsWOperator As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMSTCO_YrsWOperator As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCE1AE_YrsCurrRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMSTCO_YrsCurrRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCrew As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalSum As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl2AE3AE_YrsCurrRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl2O3O_YrsCurrRank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl2O3O_YrsTypeTanker As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl2AE3AE_YrsTypeTanker As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl2AE3AE_YrsWOperator As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl2O3O_YrsWOperator As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCE1AE_YrsTypeTanker As DevExpress.XtraReports.UI.XRLabel
End Class
