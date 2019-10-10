<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptCrewCount
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
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celRankName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celOnboard = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celOnVacation = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celApplicant = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celNotToBeRehired = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celLeftEmployment = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCrewCount = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.subHeader = New DevExpress.XtraReports.UI.XRSubreport()
        Me.lblSubTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeader_Agent = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celGroupName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celTotalOnboard = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celTotalOnVacation = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celTotalApplicant = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celTotalNotToBeRehired = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celTotalLeftEmployment = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celTotalCrewCount = New DevExpress.XtraReports.UI.XRTableCell()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.lblDatePrinted = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.Detail.HeightF = 16.53646!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow5})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(675.9999!, 16.53646!)
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.Tag = "BIND"
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celRankName, Me.celOnboard, Me.celOnVacation, Me.celApplicant, Me.celNotToBeRehired, Me.celLeftEmployment, Me.celCrewCount})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100.0!)
        Me.XrTableRow5.StylePriority.UsePadding = False
        Me.XrTableRow5.Weight = 0.99999988465799006R
        '
        'celRankName
        '
        Me.celRankName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celRankName.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celRankName.Name = "celRankName"
        Me.celRankName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celRankName.StylePriority.UseBorders = False
        Me.celRankName.StylePriority.UseFont = False
        Me.celRankName.StylePriority.UsePadding = False
        Me.celRankName.StylePriority.UseTextAlignment = False
        Me.celRankName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celRankName.Weight = 0.70255065512125514R
        '
        'celOnboard
        '
        Me.celOnboard.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celOnboard.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celOnboard.Name = "celOnboard"
        Me.celOnboard.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celOnboard.StylePriority.UseBorders = False
        Me.celOnboard.StylePriority.UseFont = False
        Me.celOnboard.StylePriority.UsePadding = False
        Me.celOnboard.StylePriority.UseTextAlignment = False
        Me.celOnboard.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celOnboard.Weight = 0.42344489624807097R
        '
        'celOnVacation
        '
        Me.celOnVacation.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celOnVacation.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celOnVacation.Name = "celOnVacation"
        Me.celOnVacation.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celOnVacation.StylePriority.UseBorders = False
        Me.celOnVacation.StylePriority.UseFont = False
        Me.celOnVacation.StylePriority.UsePadding = False
        Me.celOnVacation.StylePriority.UseTextAlignment = False
        Me.celOnVacation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celOnVacation.Weight = 0.42344489624807097R
        '
        'celApplicant
        '
        Me.celApplicant.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celApplicant.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celApplicant.Name = "celApplicant"
        Me.celApplicant.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celApplicant.StylePriority.UseBorders = False
        Me.celApplicant.StylePriority.UseFont = False
        Me.celApplicant.StylePriority.UsePadding = False
        Me.celApplicant.StylePriority.UseTextAlignment = False
        Me.celApplicant.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celApplicant.Weight = 0.423444896248071R
        '
        'celNotToBeRehired
        '
        Me.celNotToBeRehired.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celNotToBeRehired.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celNotToBeRehired.Name = "celNotToBeRehired"
        Me.celNotToBeRehired.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celNotToBeRehired.StylePriority.UseBorders = False
        Me.celNotToBeRehired.StylePriority.UseFont = False
        Me.celNotToBeRehired.StylePriority.UsePadding = False
        Me.celNotToBeRehired.StylePriority.UseTextAlignment = False
        Me.celNotToBeRehired.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celNotToBeRehired.Weight = 0.423444896248071R
        '
        'celLeftEmployment
        '
        Me.celLeftEmployment.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celLeftEmployment.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celLeftEmployment.Name = "celLeftEmployment"
        Me.celLeftEmployment.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celLeftEmployment.StylePriority.UseBorders = False
        Me.celLeftEmployment.StylePriority.UseFont = False
        Me.celLeftEmployment.StylePriority.UsePadding = False
        Me.celLeftEmployment.StylePriority.UseTextAlignment = False
        Me.celLeftEmployment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celLeftEmployment.Weight = 0.41905905394242526R
        '
        'celCrewCount
        '
        Me.celCrewCount.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.celCrewCount.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celCrewCount.Name = "celCrewCount"
        Me.celCrewCount.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celCrewCount.StylePriority.UseBorders = False
        Me.celCrewCount.StylePriority.UseFont = False
        Me.celCrewCount.StylePriority.UsePadding = False
        Me.celCrewCount.StylePriority.UseTextAlignment = False
        Me.celCrewCount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celCrewCount.Weight = 0.41905905394242526R
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 47.91667!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTitle, Me.subHeader, Me.lblSubTitle})
        Me.ReportHeader.HeightF = 182.4584!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'xrTitle
        '
        Me.xrTitle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrTitle.LocationFloat = New DevExpress.Utils.PointFloat(1.00015!, 130.0!)
        Me.xrTitle.Name = "xrTitle"
        Me.xrTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrTitle.SizeF = New System.Drawing.SizeF(675.9999!, 27.04169!)
        Me.xrTitle.StylePriority.UseFont = False
        Me.xrTitle.StylePriority.UseTextAlignment = False
        Me.xrTitle.Text = "CREW COUNT BY AGENT"
        Me.xrTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'subHeader
        '
        Me.subHeader.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.subHeader.Name = "subHeader"
        Me.subHeader.SizeF = New System.Drawing.SizeF(677.0!, 130.0!)
        '
        'lblSubTitle
        '
        Me.lblSubTitle.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblSubTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 157.0417!)
        Me.lblSubTitle.Name = "lblSubTitle"
        Me.lblSubTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSubTitle.SizeF = New System.Drawing.SizeF(677.0!, 15.00002!)
        Me.lblSubTitle.StylePriority.UseFont = False
        Me.lblSubTitle.StylePriority.UseTextAlignment = False
        Me.lblSubTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'GroupHeader_Agent
        '
        Me.GroupHeader_Agent.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.GroupHeader_Agent.HeightF = 59.1198!
        Me.GroupHeader_Agent.Name = "GroupHeader_Agent"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4, Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(675.9999!, 59.1198!)
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.Tag = "BIND"
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celGroupName})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.7562205099316388R
        '
        'celGroupName
        '
        Me.celGroupName.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celGroupName.Name = "celGroupName"
        Me.celGroupName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celGroupName.StylePriority.UseFont = False
        Me.celGroupName.StylePriority.UsePadding = False
        Me.celGroupName.StylePriority.UseTextAlignment = False
        Me.celGroupName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.celGroupName.Weight = 3.2344483479983892R
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell5, Me.XrTableCell6, Me.XrTableCell2, Me.XrTableCell8, Me.XrTableCell3, Me.XrTableCell9, Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100.0!)
        Me.XrTableRow1.StylePriority.UsePadding = False
        Me.XrTableRow1.Weight = 1.8188973580681964R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell5.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell5.StylePriority.UseBorders = False
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.StylePriority.UsePadding = False
        Me.XrTableCell5.StylePriority.UseTextAlignment = False
        Me.XrTableCell5.Text = "RANK"
        Me.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell5.Weight = 0.70255065512125514R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell6.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell6.StylePriority.UseBorders = False
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.StylePriority.UsePadding = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.Text = "ONBOARD"
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell6.Weight = 0.42344489624807097R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell2.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell2.StylePriority.UseBorders = False
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UsePadding = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "ON VACATION"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell2.Weight = 0.42344489624807097R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell8.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell8.StylePriority.UseBorders = False
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.StylePriority.UsePadding = False
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = "APPLICANT"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell8.Weight = 0.423444896248071R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell3.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell3.StylePriority.UseBorders = False
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UsePadding = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.Text = "NOT TO BE REHIRED"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell3.Weight = 0.423444896248071R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell9.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell9.StylePriority.UseBorders = False
        Me.XrTableCell9.StylePriority.UseFont = False
        Me.XrTableCell9.StylePriority.UsePadding = False
        Me.XrTableCell9.StylePriority.UseTextAlignment = False
        Me.XrTableCell9.Text = "LEFT EMPLOYMENT"
        Me.XrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell9.Weight = 0.41905905394242526R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell1.StylePriority.UseBorders = False
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UsePadding = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "TOTAL"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell1.Weight = 0.41905905394242526R
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail
        Me.GroupFooter1.HeightF = 16.53646!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
        '
        'XrTable3
        '
        Me.XrTable3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(675.9999!, 16.53646!)
        Me.XrTable3.StylePriority.UseFont = False
        Me.XrTable3.StylePriority.UseTextAlignment = False
        Me.XrTable3.Tag = "BIND"
        Me.XrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.celTotalOnboard, Me.celTotalOnVacation, Me.celTotalApplicant, Me.celTotalNotToBeRehired, Me.celTotalLeftEmployment, Me.celTotalCrewCount})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100.0!)
        Me.XrTableRow2.StylePriority.UsePadding = False
        Me.XrTableRow2.Weight = 0.99999988465799006R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrTableCell4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTableCell4.StylePriority.UseBorders = False
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.StylePriority.UsePadding = False
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "TOTAL"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell4.Weight = 0.70255065512125514R
        '
        'celTotalOnboard
        '
        Me.celTotalOnboard.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.celTotalOnboard.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celTotalOnboard.Name = "celTotalOnboard"
        Me.celTotalOnboard.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celTotalOnboard.StylePriority.UseBorders = False
        Me.celTotalOnboard.StylePriority.UseFont = False
        Me.celTotalOnboard.StylePriority.UsePadding = False
        Me.celTotalOnboard.StylePriority.UseTextAlignment = False
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celTotalOnboard.Summary = XrSummary1
        Me.celTotalOnboard.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celTotalOnboard.Weight = 0.42344489624807097R
        '
        'celTotalOnVacation
        '
        Me.celTotalOnVacation.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.celTotalOnVacation.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celTotalOnVacation.Name = "celTotalOnVacation"
        Me.celTotalOnVacation.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celTotalOnVacation.StylePriority.UseBorders = False
        Me.celTotalOnVacation.StylePriority.UseFont = False
        Me.celTotalOnVacation.StylePriority.UsePadding = False
        Me.celTotalOnVacation.StylePriority.UseTextAlignment = False
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celTotalOnVacation.Summary = XrSummary2
        Me.celTotalOnVacation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celTotalOnVacation.Weight = 0.42344489624807097R
        '
        'celTotalApplicant
        '
        Me.celTotalApplicant.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.celTotalApplicant.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celTotalApplicant.Name = "celTotalApplicant"
        Me.celTotalApplicant.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celTotalApplicant.StylePriority.UseBorders = False
        Me.celTotalApplicant.StylePriority.UseFont = False
        Me.celTotalApplicant.StylePriority.UsePadding = False
        Me.celTotalApplicant.StylePriority.UseTextAlignment = False
        XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celTotalApplicant.Summary = XrSummary3
        Me.celTotalApplicant.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celTotalApplicant.Weight = 0.423444896248071R
        '
        'celTotalNotToBeRehired
        '
        Me.celTotalNotToBeRehired.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.celTotalNotToBeRehired.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celTotalNotToBeRehired.Name = "celTotalNotToBeRehired"
        Me.celTotalNotToBeRehired.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celTotalNotToBeRehired.StylePriority.UseBorders = False
        Me.celTotalNotToBeRehired.StylePriority.UseFont = False
        Me.celTotalNotToBeRehired.StylePriority.UsePadding = False
        Me.celTotalNotToBeRehired.StylePriority.UseTextAlignment = False
        XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celTotalNotToBeRehired.Summary = XrSummary4
        Me.celTotalNotToBeRehired.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celTotalNotToBeRehired.Weight = 0.423444896248071R
        '
        'celTotalLeftEmployment
        '
        Me.celTotalLeftEmployment.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.celTotalLeftEmployment.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celTotalLeftEmployment.Name = "celTotalLeftEmployment"
        Me.celTotalLeftEmployment.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celTotalLeftEmployment.StylePriority.UseBorders = False
        Me.celTotalLeftEmployment.StylePriority.UseFont = False
        Me.celTotalLeftEmployment.StylePriority.UsePadding = False
        Me.celTotalLeftEmployment.StylePriority.UseTextAlignment = False
        XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celTotalLeftEmployment.Summary = XrSummary5
        Me.celTotalLeftEmployment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celTotalLeftEmployment.Weight = 0.41905905394242526R
        '
        'celTotalCrewCount
        '
        Me.celTotalCrewCount.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.celTotalCrewCount.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.celTotalCrewCount.Name = "celTotalCrewCount"
        Me.celTotalCrewCount.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celTotalCrewCount.StylePriority.UseBorders = False
        Me.celTotalCrewCount.StylePriority.UseFont = False
        Me.celTotalCrewCount.StylePriority.UsePadding = False
        Me.celTotalCrewCount.StylePriority.UseTextAlignment = False
        XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.celTotalCrewCount.Summary = XrSummary6
        Me.celTotalCrewCount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.celTotalCrewCount.Weight = 0.41905905394242526R
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDatePrinted, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 23.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblDatePrinted
        '
        Me.lblDatePrinted.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblDatePrinted.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblDatePrinted.Name = "lblDatePrinted"
        Me.lblDatePrinted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDatePrinted.SizeF = New System.Drawing.SizeF(276.0417!, 23.0!)
        Me.lblDatePrinted.StylePriority.UseFont = False
        Me.lblDatePrinted.Text = "Date Printed:"
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(577.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'rptCrewCount
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.GroupHeader_Agent, Me.GroupFooter1, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(75, 75, 50, 48)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents xrTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents subHeader As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents lblSubTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupHeader_Agent As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celRankName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celOnboard As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celOnVacation As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celApplicant As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celNotToBeRehired As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celLeftEmployment As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCrewCount As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celGroupName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celTotalOnboard As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celTotalOnVacation As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celTotalApplicant As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celTotalNotToBeRehired As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celTotalLeftEmployment As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celTotalCrewCount As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblDatePrinted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
