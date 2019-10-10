<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptCrewTravelEvent
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrTable5 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celCompanyName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celDatePrinted = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celTravAgent = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celAddr = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celContact = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DetailReport_Crew = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.Detail1 = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable6 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celCrewCnt = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celCrew = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celRank = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celRptBody = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable7 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow9 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celFlightCnt = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celRefNo = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celFlightFrom = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celETD = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celFlightTo = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celETA = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow10 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupHeader3 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.DetailReport_Flight = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.Detail3 = New DevExpress.XtraReports.UI.DetailBand()
        Me.ReportHeader2 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 0.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 100.0!
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
        'XrTable5
        '
        Me.XrTable5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable5.Name = "XrTable5"
        Me.XrTable5.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow7, Me.XrTableRow6})
        Me.XrTable5.SizeF = New System.Drawing.SizeF(627.0!, 50.0!)
        '
        'XrTableRow7
        '
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celCompanyName})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.Weight = 1.0R
        '
        'celCompanyName
        '
        Me.celCompanyName.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.celCompanyName.Name = "celCompanyName"
        Me.celCompanyName.StylePriority.UseFont = False
        Me.celCompanyName.StylePriority.UseTextAlignment = False
        Me.celCompanyName.Text = "celCompanyName"
        Me.celCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celCompanyName.Weight = 3.0R
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell12, Me.celDatePrinted})
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.Weight = 1.0R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.StylePriority.UseFont = False
        Me.XrTableCell12.StylePriority.UseTextAlignment = False
        Me.XrTableCell12.Text = "Date : "
        Me.XrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell12.Weight = 0.02884485948329657R
        '
        'celDatePrinted
        '
        Me.celDatePrinted.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.celDatePrinted.Name = "celDatePrinted"
        Me.celDatePrinted.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.celDatePrinted.StylePriority.UseFont = False
        Me.celDatePrinted.StylePriority.UsePadding = False
        Me.celDatePrinted.StylePriority.UseTextAlignment = False
        Me.celDatePrinted.Text = "celDatePrinted"
        Me.celDatePrinted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.celDatePrinted.Weight = 0.33242907491296325R
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 80.00002!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow2})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(627.0!, 50.0!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celTravAgent})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'celTravAgent
        '
        Me.celTravAgent.Name = "celTravAgent"
        Me.celTravAgent.Text = "celTravAgent"
        Me.celTravAgent.Weight = 1.0R
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celAddr})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'celAddr
        '
        Me.celAddr.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.celAddr.Name = "celAddr"
        Me.celAddr.StylePriority.UseFont = False
        Me.celAddr.Text = "celAddr"
        Me.celAddr.Weight = 0.096358352490779509R
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 160.0001!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(627.0!, 25.0!)
        Me.XrTable2.StylePriority.UseFont = False
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.celContact})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "To"
        Me.XrTableCell1.Weight = 0.067371560664747587R
        '
        'celContact
        '
        Me.celContact.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.celContact.Name = "celContact"
        Me.celContact.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.celContact.StylePriority.UseFont = False
        Me.celContact.StylePriority.UsePadding = False
        Me.celContact.Text = "celContact"
        Me.celContact.Weight = 1.9326284393352524R
        '
        'DetailReport_Crew
        '
        Me.DetailReport_Crew.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail1, Me.ReportHeader})
        Me.DetailReport_Crew.Level = 0
        Me.DetailReport_Crew.Name = "DetailReport_Crew"
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable6})
        Me.Detail1.HeightF = 25.0!
        Me.Detail1.Name = "Detail1"
        '
        'XrTable6
        '
        Me.XrTable6.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable6.Name = "XrTable6"
        Me.XrTable6.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow5})
        Me.XrTable6.SizeF = New System.Drawing.SizeF(627.0!, 25.0!)
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celCrewCnt, Me.celCrew, Me.celRank})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.0R
        '
        'celCrewCnt
        '
        Me.celCrewCnt.Name = "celCrewCnt"
        Me.celCrewCnt.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:#,#}"
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.celCrewCnt.Summary = XrSummary1
        Me.celCrewCnt.Text = "celCrewCnt"
        Me.celCrewCnt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.celCrewCnt.Weight = 0.60416671680711087R
        '
        'celCrew
        '
        Me.celCrew.Name = "celCrew"
        Me.celCrew.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.celCrew.StylePriority.UsePadding = False
        Me.celCrew.Text = "celCrew"
        Me.celCrew.Weight = 3.6137564250922365R
        '
        'celRank
        '
        Me.celRank.Name = "celRank"
        Me.celRank.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.celRank.StylePriority.UsePadding = False
        Me.celRank.Text = "celRank"
        Me.celRank.Weight = 3.349099841049485R
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.ReportHeader.HeightF = 25.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrTable3
        '
        Me.XrTable3.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow8})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(627.0!, 25.0!)
        Me.XrTable3.StylePriority.UseFont = False
        '
        'XrTableRow8
        '
        Me.XrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celRptBody})
        Me.XrTableRow8.Name = "XrTableRow8"
        Me.XrTableRow8.Weight = 1.0R
        '
        'celRptBody
        '
        Me.celRptBody.Name = "celRptBody"
        Me.celRptBody.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.celRptBody.StylePriority.UsePadding = False
        Me.celRptBody.Text = "          Please find below crew that will travel on <StartPoint>."
        Me.celRptBody.Weight = 2.0R
        '
        'XrTable7
        '
        Me.XrTable7.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable7.Name = "XrTable7"
        Me.XrTable7.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow9})
        Me.XrTable7.SizeF = New System.Drawing.SizeF(627.0!, 25.0!)
        '
        'XrTableRow9
        '
        Me.XrTableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celFlightCnt, Me.celRefNo, Me.celFlightFrom, Me.celETD, Me.celFlightTo, Me.celETA})
        Me.XrTableRow9.Name = "XrTableRow9"
        Me.XrTableRow9.Weight = 1.0R
        '
        'celFlightCnt
        '
        Me.celFlightCnt.Name = "celFlightCnt"
        Me.celFlightCnt.StylePriority.UseTextAlignment = False
        XrSummary2.FormatString = "{0:#,#}"
        XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.celFlightCnt.Summary = XrSummary2
        Me.celFlightCnt.Text = "celFlightCnt"
        Me.celFlightCnt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.celFlightCnt.Weight = 0.60073845095242107R
        '
        'celRefNo
        '
        Me.celRefNo.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.celRefNo.Name = "celRefNo"
        Me.celRefNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.celRefNo.StylePriority.UseBorders = False
        Me.celRefNo.StylePriority.UsePadding = False
        Me.celRefNo.Text = "celRefNo"
        Me.celRefNo.Weight = 1.2861845572600727R
        '
        'celFlightFrom
        '
        Me.celFlightFrom.Name = "celFlightFrom"
        Me.celFlightFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celFlightFrom.StylePriority.UsePadding = False
        Me.celFlightFrom.Text = "celFlightFrom"
        Me.celFlightFrom.Weight = 1.8845404681620139R
        '
        'celETD
        '
        Me.celETD.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.celETD.Name = "celETD"
        Me.celETD.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.celETD.StylePriority.UseBorders = False
        Me.celETD.StylePriority.UsePadding = False
        Me.celETD.StylePriority.UseTextAlignment = False
        Me.celETD.Text = "celETD"
        Me.celETD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.celETD.Weight = 1.104012569738279R
        '
        'celFlightTo
        '
        Me.celFlightTo.Name = "celFlightTo"
        Me.celFlightTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.celFlightTo.StylePriority.UsePadding = False
        Me.celFlightTo.Text = "celFlightTo"
        Me.celFlightTo.Weight = 1.6405958869615782R
        '
        'celETA
        '
        Me.celETA.Name = "celETA"
        Me.celETA.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.celETA.StylePriority.UsePadding = False
        Me.celETA.StylePriority.UseTextAlignment = False
        Me.celETA.Text = "celETA"
        Me.celETA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.celETA.Weight = 1.0080111435346661R
        '
        'XrTable4
        '
        Me.XrTable4.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.XrTable4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.0!)
        Me.XrTable4.Name = "XrTable4"
        Me.XrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4, Me.XrTableRow10})
        Me.XrTable4.SizeF = New System.Drawing.SizeF(627.0!, 50.0!)
        Me.XrTable4.StylePriority.UseFont = False
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell2})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(30, 0, 0, 0, 100.0!)
        Me.XrTableCell2.StylePriority.UsePadding = False
        Me.XrTableCell2.Text = "Flight Details :"
        Me.XrTableCell2.Weight = 2.0R
        '
        'XrTableRow10
        '
        Me.XrTableRow10.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell9, Me.XrTableCell8, Me.XrTableCell7, Me.XrTableCell4, Me.XrTableCell6, Me.XrTableCell3})
        Me.XrTableRow10.Name = "XrTableRow10"
        Me.XrTableRow10.Weight = 1.0R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrTableCell9.StylePriority.UseBorders = False
        Me.XrTableCell9.StylePriority.UsePadding = False
        Me.XrTableCell9.Weight = 0.1596841766503439R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 0, 0, 0, 100.0!)
        Me.XrTableCell8.StylePriority.UseBorders = False
        Me.XrTableCell8.StylePriority.UsePadding = False
        Me.XrTableCell8.Text = "Booking Ref."
        Me.XrTableCell8.Weight = 0.3418846312892494R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrTableCell7.StylePriority.UseBorders = False
        Me.XrTableCell7.StylePriority.UsePadding = False
        Me.XrTableCell7.StylePriority.UseTextAlignment = False
        Me.XrTableCell7.Text = "From"
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell7.Weight = 0.50093567770634129R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrTableCell4.StylePriority.UseBorders = False
        Me.XrTableCell4.StylePriority.UsePadding = False
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "ETD"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell4.Weight = 0.29346092503987253R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrTableCell6.StylePriority.UseBorders = False
        Me.XrTableCell6.StylePriority.UsePadding = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.Text = "TO"
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell6.Weight = 0.43609200558213879R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrTableCell3.StylePriority.UseBorders = False
        Me.XrTableCell3.StylePriority.UsePadding = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.Text = "ETA"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell3.Weight = 0.26794258373205782R
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable5, Me.XrTable1, Me.XrTable2})
        Me.GroupHeader3.HeightF = 185.0001!
        Me.GroupHeader3.Name = "GroupHeader3"
        Me.GroupHeader3.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry
        Me.GroupHeader3.RepeatEveryPage = True
        '
        'DetailReport_Flight
        '
        Me.DetailReport_Flight.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail3, Me.ReportHeader2})
        Me.DetailReport_Flight.Level = 1
        Me.DetailReport_Flight.Name = "DetailReport_Flight"
        '
        'Detail3
        '
        Me.Detail3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable7})
        Me.Detail3.HeightF = 25.0!
        Me.Detail3.Name = "Detail3"
        '
        'ReportHeader2
        '
        Me.ReportHeader2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable4})
        Me.ReportHeader2.HeightF = 70.0!
        Me.ReportHeader2.Name = "ReportHeader2"
        '
        'rptCrewTravelEvent
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.DetailReport_Crew, Me.GroupHeader3, Me.DetailReport_Flight})
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrTable5 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celCompanyName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celDatePrinted As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celTravAgent As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celAddr As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celContact As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DetailReport_Crew As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents Detail1 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrTable6 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celCrewCnt As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celCrew As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable7 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celFlightCnt As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celFlightFrom As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable4 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celRptBody As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupHeader3 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents celRank As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celETD As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celFlightTo As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celETA As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celRefNo As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents DetailReport_Flight As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents Detail3 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader2 As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrTableRow10 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
End Class
