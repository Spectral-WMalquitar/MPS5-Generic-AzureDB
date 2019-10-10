<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptAudit
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
        Me.tblSubTitle = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.subrep = New DevExpress.XtraReports.UI.XRSubreport()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.celDateUpdated = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celSeamanID = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celSeamanName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celScreenCaption = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celAction = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celDescription = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celRecordKeyword = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celUsername = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celComputerName = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celAuditLogID = New DevExpress.XtraReports.UI.XRTableCell()
        Me.celAuditDetailID = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.txtCoyAdd = New DevExpress.XtraReports.UI.XRLabel()
        Me.txtCompany = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFilter = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDates = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo3 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me.tblSubTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.tblSubTitle, Me.subrep, Me.XrTable1, Me.XrLine1})
        Me.Detail.HeightF = 50.45834!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'tblSubTitle
        '
        Me.tblSubTitle.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.tblSubTitle.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.tblSubTitle.LocationFloat = New DevExpress.Utils.PointFloat(232.636!, 22.79167!)
        Me.tblSubTitle.Name = "tblSubTitle"
        Me.tblSubTitle.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.tblSubTitle.SizeF = New System.Drawing.SizeF(544.7917!, 16.66667!)
        Me.tblSubTitle.StylePriority.UseBorders = False
        Me.tblSubTitle.StylePriority.UseFont = False
        Me.tblSubTitle.StylePriority.UseTextAlignment = False
        Me.tblSubTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.CanShrink = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "Field"
        Me.XrTableCell1.Weight = 1.6770834350585937R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.CanShrink = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "Old Value" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.XrTableCell2.Weight = 2.0104165649414059R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.CanShrink = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = "New Value"
        Me.XrTableCell3.Weight = 1.7604168701171874R
        '
        'subrep
        '
        Me.subrep.LocationFloat = New DevExpress.Utils.PointFloat(232.636!, 39.45833!)
        Me.subrep.Name = "subrep"
        Me.subrep.SizeF = New System.Drawing.SizeF(667.3638!, 10.99999!)
        '
        'XrTable1
        '
        Me.XrTable1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTable1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 3.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(895.1836!, 13.83334!)
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.celDateUpdated, Me.celSeamanID, Me.celSeamanName, Me.celScreenCaption, Me.celAction, Me.celDescription, Me.celRecordKeyword, Me.celUsername, Me.celComputerName, Me.celAuditLogID, Me.celAuditDetailID})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'celDateUpdated
        '
        Me.celDateUpdated.Multiline = True
        Me.celDateUpdated.Name = "celDateUpdated"
        Me.celDateUpdated.Text = "Date Updated"
        Me.celDateUpdated.Weight = 1.4475191597686405R
        '
        'celSeamanID
        '
        Me.celSeamanID.Name = "celSeamanID"
        Me.celSeamanID.Text = "Seaman"
        Me.celSeamanID.Weight = 1.4475191597686405R
        '
        'celSeamanName
        '
        Me.celSeamanName.Name = "celSeamanName"
        Me.celSeamanName.Text = "Seaman Name"
        Me.celSeamanName.Weight = 1.3542858478400435R
        '
        'celScreenCaption
        '
        Me.celScreenCaption.Name = "celScreenCaption"
        Me.celScreenCaption.Text = "Screen Caption"
        Me.celScreenCaption.Weight = 1.3625570695900189R
        '
        'celAction
        '
        Me.celAction.Name = "celAction"
        Me.celAction.Text = "Action"
        Me.celAction.Weight = 1.3584504818577194R
        '
        'celDescription
        '
        Me.celDescription.Name = "celDescription"
        Me.celDescription.Text = "Description"
        Me.celDescription.Weight = 3.1112312286078536R
        '
        'celRecordKeyword
        '
        Me.celRecordKeyword.Name = "celRecordKeyword"
        Me.celRecordKeyword.Text = "Record Keyword"
        Me.celRecordKeyword.Weight = 1.8246194997961198R
        '
        'celUsername
        '
        Me.celUsername.Name = "celUsername"
        Me.celUsername.Text = "Username"
        Me.celUsername.Weight = 2.3653685571941687R
        '
        'celComputerName
        '
        Me.celComputerName.Name = "celComputerName"
        Me.celComputerName.Text = "Computer Name"
        Me.celComputerName.Weight = 1.3949078169123668R
        '
        'celAuditLogID
        '
        Me.celAuditLogID.Name = "celAuditLogID"
        Me.celAuditLogID.Text = "celAuditLogID"
        Me.celAuditLogID.Visible = False
        Me.celAuditLogID.Weight = 0.17900427567528654R
        '
        'celAuditDetailID
        '
        Me.celAuditDetailID.Name = "celAuditDetailID"
        Me.celAuditDetailID.Text = "celAuditDetailID"
        Me.celAuditDetailID.Visible = False
        Me.celAuditDetailID.Weight = 0.17900427567528654R
        '
        'XrLine1
        '
        Me.XrLine1.BorderWidth = 2.0!
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0001033147!, 0.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(899.9999!, 2.0!)
        Me.XrLine1.StylePriority.UseBorderWidth = False
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.txtCoyAdd, Me.txtCompany, Me.lblFilter, Me.lblDates, Me.XrLabel1, Me.XrTable2})
        Me.TopMargin.HeightF = 180.7083!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'txtCoyAdd
        '
        Me.txtCoyAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtCoyAdd.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 58.45834!)
        Me.txtCoyAdd.Name = "txtCoyAdd"
        Me.txtCoyAdd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCoyAdd.SizeF = New System.Drawing.SizeF(899.9996!, 22.04166!)
        Me.txtCoyAdd.StylePriority.UseFont = False
        Me.txtCoyAdd.StylePriority.UseTextAlignment = False
        Me.txtCoyAdd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'txtCompany
        '
        Me.txtCompany.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCompany.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 28.08335!)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.txtCompany.SizeF = New System.Drawing.SizeF(899.9996!, 30.37499!)
        Me.txtCompany.StylePriority.UseFont = False
        Me.txtCompany.StylePriority.UseTextAlignment = False
        Me.txtCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFilter
        '
        Me.lblFilter.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblFilter.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 130.2917!)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFilter.SizeF = New System.Drawing.SizeF(899.9999!, 16.0!)
        Me.lblFilter.StylePriority.UseFont = False
        Me.lblFilter.StylePriority.UseTextAlignment = False
        Me.lblFilter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblDates
        '
        Me.lblDates.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblDates.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 109.2917!)
        Me.lblDates.Name = "lblDates"
        Me.lblDates.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDates.SizeF = New System.Drawing.SizeF(899.9999!, 16.0!)
        Me.lblDates.StylePriority.UseFont = False
        Me.lblDates.StylePriority.UseTextAlignment = False
        Me.lblDates.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 92.29169!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(899.9999!, 16.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "AUDIT REPORT"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTable2
        '
        Me.XrTable2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 151.125!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(885.184!, 26.45834!)
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCell10, Me.XrTableCell11, Me.XrTableCell12, Me.XrTableCell13, Me.XrTableCell14, Me.XrTableCell15, Me.XrTableCell17, Me.XrTableCell18})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "Date Updated"
        Me.XrTableCell4.Weight = 1.4475191597686405R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Multiline = True
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "Seaman " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "System ID" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.XrTableCell10.Weight = 1.4475191597686405R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Text = "Seaman Name"
        Me.XrTableCell11.Weight = 1.3542858478400435R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.Text = "Screen Caption"
        Me.XrTableCell12.Weight = 1.3625572061619866R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.Text = "Action"
        Me.XrTableCell13.Weight = 1.3584503452857519R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Text = "Description"
        Me.XrTableCell14.Weight = 3.1112317748957237R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.Text = "Record Keyword"
        Me.XrTableCell15.Weight = 1.8246189535082498R
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.Text = "Username"
        Me.XrTableCell17.Weight = 2.3653685571941687R
        '
        'XrTableCell18
        '
        Me.XrTableCell18.Name = "XrTableCell18"
        Me.XrTableCell18.Text = "Computer Name"
        Me.XrTableCell18.Weight = 1.5739159778680634R
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo3, Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo3
        '
        Me.XrPageInfo3.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrPageInfo3.Format = "Page {0} of {1}"
        Me.XrPageInfo3.LocationFloat = New DevExpress.Utils.PointFloat(753.8978!, 67.00001!)
        Me.XrPageInfo3.Name = "XrPageInfo3"
        Me.XrPageInfo3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo3.SizeF = New System.Drawing.SizeF(146.102!, 23.0!)
        Me.XrPageInfo3.StylePriority.UseFont = False
        Me.XrPageInfo3.StylePriority.UseTextAlignment = False
        Me.XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrPageInfo1.Format = "Date Printed: {0:dd-MMM-yyyy}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 67.00001!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(194.0187!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseFont = False
        '
        'rptAudit
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 181, 100)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.tblSubTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents celDateUpdated As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celSeamanName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celScreenCaption As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celAction As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celDescription As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celRecordKeyword As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celUsername As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celComputerName As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lblDates As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents subrep As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents celAuditLogID As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tblSubTitle As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lblFilter As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents txtCoyAdd As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents txtCompany As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo3 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents celSeamanID As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents celAuditDetailID As DevExpress.XtraReports.UI.XRTableCell
End Class
