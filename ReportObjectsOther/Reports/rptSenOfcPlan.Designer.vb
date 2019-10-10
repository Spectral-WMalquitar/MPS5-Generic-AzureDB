<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSenOfcPlan
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
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celVslName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celMSTR = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCO = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCE = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cel2E = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celETOEL = New DevExpress.XtraReports.UI.XRTableCell()
        Me.rowDet = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celMSTR_det = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCO_det = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCE_det = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cel2E_det = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celETOEL_det = New DevExpress.XtraReports.UI.XRTableCell()
        Me.rowPlan = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celMSTR_plan = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCO_plan = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCE_plan = New DevExpress.XtraReports.UI.XRTableCell()
        Me.cel2E_plan = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celETOEL_plan = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.maintable = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celGrp = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrTable5 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celDatePrinted = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.maintable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.Detail.HeightF = 80.0!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable2
        '
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4, Me.rowDet, Me.rowPlan})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(1069.0!, 80.0!)
        Me.XrTable2.StylePriority.UsePadding = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celVslName, Me.celMSTR, Me.celCO, Me.celCE, Me.cel2E, Me.celETOEL})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0312499745686847R
        '
        'celVslName
        '
        Me.celVslName.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celVslName.Name = "celVslName"
        Me.celVslName.ProcessDuplicatesMode = DevExpress.XtraReports.UI.ProcessDuplicatesMode.Merge
        Me.celVslName.StylePriority.UseBorders = False
        Me.celVslName.Text = "celVslName"
        Me.celVslName.Weight = 0.5R
        '
        'celMSTR
        '
        Me.celMSTR.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celMSTR.Name = "celMSTR"
        Me.celMSTR.StylePriority.UseBorders = False
        Me.celMSTR.Text = "celMSTR"
        Me.celMSTR.Weight = 0.5R
        '
        'celCO
        '
        Me.celCO.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celCO.Name = "celCO"
        Me.celCO.StylePriority.UseBorders = False
        Me.celCO.Text = "celCO"
        Me.celCO.Weight = 0.5R
        '
        'celCE
        '
        Me.celCE.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celCE.Name = "celCE"
        Me.celCE.StylePriority.UseBorders = False
        Me.celCE.Text = "celCE"
        Me.celCE.Weight = 0.5R
        '
        'cel2E
        '
        Me.cel2E.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.cel2E.Name = "cel2E"
        Me.cel2E.StylePriority.UseBorders = False
        Me.cel2E.Text = "cel2E"
        Me.cel2E.Weight = 0.5R
        '
        'celETOEL
        '
        Me.celETOEL.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celETOEL.Name = "celETOEL"
        Me.celETOEL.StylePriority.UseBorders = False
        Me.celETOEL.Text = "celETOEL"
        Me.celETOEL.Weight = 0.5R
        '
        'rowDet
        '
        Me.rowDet.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell17, Me.celMSTR_det, Me.celCO_det, Me.celCE_det, Me.cel2E_det, Me.celETOEL_det})
        Me.rowDet.Name = "rowDet"
        Me.rowDet.Weight = 0.68749998966852821R
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.StylePriority.UseBorders = False
        Me.XrTableCell17.Weight = 0.5R
        '
        'celMSTR_det
        '
        Me.celMSTR_det.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celMSTR_det.Name = "celMSTR_det"
        Me.celMSTR_det.StylePriority.UseBorders = False
        Me.celMSTR_det.Weight = 0.5R
        '
        'celCO_det
        '
        Me.celCO_det.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celCO_det.Name = "celCO_det"
        Me.celCO_det.StylePriority.UseBorders = False
        Me.celCO_det.Weight = 0.5R
        '
        'celCE_det
        '
        Me.celCE_det.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celCE_det.Name = "celCE_det"
        Me.celCE_det.StylePriority.UseBorders = False
        Me.celCE_det.Weight = 0.5R
        '
        'cel2E_det
        '
        Me.cel2E_det.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.cel2E_det.Name = "cel2E_det"
        Me.cel2E_det.StylePriority.UseBorders = False
        Me.cel2E_det.Weight = 0.5R
        '
        'celETOEL_det
        '
        Me.celETOEL_det.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.celETOEL_det.Name = "celETOEL_det"
        Me.celETOEL_det.StylePriority.UseBorders = False
        Me.celETOEL_det.Weight = 0.5R
        '
        'rowPlan
        '
        Me.rowPlan.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.rowPlan.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell23, Me.celMSTR_plan, Me.celCO_plan, Me.celCE_plan, Me.cel2E_plan, Me.celETOEL_plan})
        Me.rowPlan.Name = "rowPlan"
        Me.rowPlan.StylePriority.UseBorders = False
        Me.rowPlan.Weight = 1.031250035762787R
        '
        'XrTableCell23
        '
        Me.XrTableCell23.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell23.Name = "XrTableCell23"
        Me.XrTableCell23.StylePriority.UseBorders = False
        Me.XrTableCell23.Weight = 0.5R
        '
        'celMSTR_plan
        '
        Me.celMSTR_plan.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.celMSTR_plan.Name = "celMSTR_plan"
        Me.celMSTR_plan.StylePriority.UseBorders = False
        Me.celMSTR_plan.Text = "celMSTR_plan"
        Me.celMSTR_plan.Weight = 0.5R
        '
        'celCO_plan
        '
        Me.celCO_plan.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.celCO_plan.Name = "celCO_plan"
        Me.celCO_plan.StylePriority.UseBorders = False
        Me.celCO_plan.Text = "celCO_plan"
        Me.celCO_plan.Weight = 0.5R
        '
        'celCE_plan
        '
        Me.celCE_plan.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.celCE_plan.Name = "celCE_plan"
        Me.celCE_plan.StylePriority.UseBorders = False
        Me.celCE_plan.Text = "celCE_plan"
        Me.celCE_plan.Weight = 0.5R
        '
        'cel2E_plan
        '
        Me.cel2E_plan.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cel2E_plan.Name = "cel2E_plan"
        Me.cel2E_plan.StylePriority.UseBorders = False
        Me.cel2E_plan.Text = "cel2E_plan"
        Me.cel2E_plan.Weight = 0.5R
        '
        'celETOEL_plan
        '
        Me.celETOEL_plan.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.celETOEL_plan.Name = "celETOEL_plan"
        Me.celETOEL_plan.StylePriority.UseBorders = False
        Me.celETOEL_plan.Text = "celETOEL_plan"
        Me.celETOEL_plan.Weight = 0.5R
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
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.maintable})
        Me.GroupHeader1.HeightF = 75.0!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatEveryPage = True
        '
        'maintable
        '
        Me.maintable.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.maintable.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.maintable.Name = "maintable"
        Me.maintable.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.maintable.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow3, Me.XrTableRow2})
        Me.maintable.SizeF = New System.Drawing.SizeF(1069.0!, 75.0!)
        Me.maintable.StylePriority.UseFont = False
        Me.maintable.StylePriority.UsePadding = False
        Me.maintable.StylePriority.UseTextAlignment = False
        Me.maintable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.celGrp})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "SENIOR OFFICERS PLANNING -"
        Me.XrTableCell4.Weight = 0.55940132390906316R
        '
        'celGrp
        '
        Me.celGrp.Name = "celGrp"
        Me.celGrp.Text = "celGrp"
        Me.celGrp.Weight = 2.4405986760909366R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell2})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Weight = 3.0R
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell7, Me.XrTableCell8, Me.XrTableCell9, Me.XrTableCell10, Me.XrTableCell11, Me.XrTableCell12})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.StylePriority.UseBorders = False
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Text = "Vessels"
        Me.XrTableCell7.Weight = 0.5R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Text = "Masters"
        Me.XrTableCell8.Weight = 0.5R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "Chief Officers"
        Me.XrTableCell9.Weight = 0.5R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "Chief Engineer"
        Me.XrTableCell10.Weight = 0.5R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Text = "Second Engineer"
        Me.XrTableCell11.Weight = 0.5R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.Text = "ETO / EL-OFF"
        Me.XrTableCell12.Weight = 0.5R
        '
        'GroupFooter1
        '
        Me.GroupFooter1.HeightF = 20.0!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable5, Me.XrLine1, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 28.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1069.0!, 5.0!)
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(969.0!, 5.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTable5
        '
        Me.XrTable5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 5.0!)
        Me.XrTable5.Name = "XrTable5"
        Me.XrTable5.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.XrTable5.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow6})
        Me.XrTable5.SizeF = New System.Drawing.SizeF(363.5417!, 23.0!)
        Me.XrTable5.StylePriority.UsePadding = False
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell13, Me.celDatePrinted})
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.Weight = 1.0R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.StylePriority.UseTextAlignment = False
        Me.XrTableCell13.Text = "Date Printed : "
        Me.XrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell13.Weight = 0.750716325342702R
        '
        'celDatePrinted
        '
        Me.celDatePrinted.Name = "celDatePrinted"
        Me.celDatePrinted.StylePriority.UseTextAlignment = False
        Me.celDatePrinted.Text = "celDatePrinted"
        Me.celDatePrinted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celDatePrinted.Weight = 2.2492836746572982R
        '
        'rptSenOfcPlan
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader1, Me.GroupFooter1, Me.PageFooter})
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "14.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.maintable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents maintable As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celGrp As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celVslName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celMSTR As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCO As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCE As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cel2E As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celETOEL As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents rowDet As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celMSTR_det As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCO_det As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCE_det As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cel2E_det As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celETOEL_det As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents rowPlan As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celMSTR_plan As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCO_plan As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCE_plan As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents cel2E_plan As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celETOEL_plan As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrTable5 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celDatePrinted As DevExpress.XtraReports.UI.XRTableCell
End Class
