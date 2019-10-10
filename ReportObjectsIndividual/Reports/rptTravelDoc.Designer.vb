<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptTravelDoc
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
        Dim TableQuery1 As DevExpress.DataAccess.Sql.TableQuery = New DevExpress.DataAccess.Sql.TableQuery()
        Dim TableInfo1 As DevExpress.DataAccess.Sql.TableInfo = New DevExpress.DataAccess.Sql.TableInfo()
        Dim ColumnInfo1 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo2 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo3 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo4 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo5 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo6 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo7 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo8 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo9 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo10 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo11 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo12 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo13 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo14 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo15 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo16 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo17 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo18 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo19 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo20 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim ColumnInfo21 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTravelDoc))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.txtDateIssue = New DevExpress.XtraReports.UI.XRTableCell()
        Me.txtDateExpiry = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.subHeader = New DevExpress.XtraReports.UI.XRSubreport()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource()
        Me.GroupHeader_Crew = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.lblDatePrinted = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.Detail.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Detail.HeightF = 16.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StylePriority.UseFont = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable3
        '
        Me.XrTable3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(37.0!, 0.0!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100.0!)
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(1011.5!, 16.0!)
        Me.XrTable3.StylePriority.UseFont = False
        Me.XrTable3.StylePriority.UsePadding = False
        Me.XrTable3.Tag = "BIND"
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell8, Me.XrTableCell14, Me.txtDateIssue, Me.txtDateExpiry, Me.XrTableCell17, Me.XrTableCell18})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.Tag = "BIND_DocName"
        Me.XrTableCell8.Text = "colDocType"
        Me.XrTableCell8.Weight = 2.2154437447867017R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.StylePriority.UseFont = False
        Me.XrTableCell14.Tag = "BIND_Nbr"
        Me.XrTableCell14.Weight = 1.1093100665067921R
        '
        'txtDateIssue
        '
        Me.txtDateIssue.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtDateIssue.Name = "txtDateIssue"
        Me.txtDateIssue.StylePriority.UseFont = False
        Me.txtDateIssue.Weight = 1.150937323120234R
        '
        'txtDateExpiry
        '
        Me.txtDateExpiry.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtDateExpiry.Name = "txtDateExpiry"
        Me.txtDateExpiry.StylePriority.UseFont = False
        Me.txtDateExpiry.Weight = 1.1588817847354624R
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.StylePriority.UseFont = False
        Me.XrTableCell17.Tag = "BIND_Country"
        Me.XrTableCell17.Weight = 0.95233509220090584R
        '
        'XrTableCell18
        '
        Me.XrTableCell18.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTableCell18.Name = "XrTableCell18"
        Me.XrTableCell18.StylePriority.UseFont = False
        Me.XrTableCell18.Tag = "BIND_IssuedBy"
        Me.XrTableCell18.Weight = 1.1271053346937558R
        '
        'TopMargin
        '
        Me.TopMargin.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.TopMargin.HeightF = 41.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.StylePriority.UseFont = False
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003814697!, 130.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(1049.0!, 27.04169!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "DOCUMENTS"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 100.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine1
        '
        Me.XrLine1.LineWidth = 3
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 167.7083!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1049.0!, 13.0!)
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.subHeader, Me.XrLabel1, Me.XrLine1})
        Me.PageHeader.HeightF = 180.7083!
        Me.PageHeader.Name = "PageHeader"
        '
        'subHeader
        '
        Me.subHeader.LocationFloat = New DevExpress.Utils.PointFloat(0.00003814697!, 0.0!)
        Me.subHeader.Name = "subHeader"
        Me.subHeader.SizeF = New System.Drawing.SizeF(1049.0!, 130.0!)
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "developerone-pc\stisqlserver.MPS.dbo"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        TableQuery1.Name = "Report_BioInfo"
        TableInfo1.Name = "Report_BioInfo"
        ColumnInfo1.Name = "IDNbr"
        ColumnInfo2.Name = "COIDNo"
        ColumnInfo3.Name = "Crew"
        ColumnInfo4.Name = "LName"
        ColumnInfo5.Name = "FName"
        ColumnInfo6.Name = "MName"
        ColumnInfo7.Name = "Gender"
        ColumnInfo8.Name = "DOB"
        ColumnInfo9.Name = "Age"
        ColumnInfo10.Name = "POB"
        ColumnInfo11.Name = "Height"
        ColumnInfo12.Name = "Weight"
        ColumnInfo13.Name = "Blood"
        ColumnInfo14.Name = "MaritalStatus"
        ColumnInfo15.Name = "Religion"
        ColumnInfo16.Name = "Rank"
        ColumnInfo17.Name = "Nationality"
        ColumnInfo18.Name = "StatName"
        ColumnInfo19.Name = "VslName"
        ColumnInfo20.Name = "DateSOn"
        ColumnInfo21.Name = "DateAccepted"
        TableInfo1.SelectedColumns.AddRange(New DevExpress.DataAccess.Sql.ColumnInfo() {ColumnInfo1, ColumnInfo2, ColumnInfo3, ColumnInfo4, ColumnInfo5, ColumnInfo6, ColumnInfo7, ColumnInfo8, ColumnInfo9, ColumnInfo10, ColumnInfo11, ColumnInfo12, ColumnInfo13, ColumnInfo14, ColumnInfo15, ColumnInfo16, ColumnInfo17, ColumnInfo18, ColumnInfo19, ColumnInfo20, ColumnInfo21})
        TableQuery1.Tables.AddRange(New DevExpress.DataAccess.Sql.TableInfo() {TableInfo1})
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {TableQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'GroupHeader_Crew
        '
        Me.GroupHeader_Crew.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.XrTable2, Me.XrTable1})
        Me.GroupHeader_Crew.HeightF = 81.0!
        Me.GroupHeader_Crew.Name = "GroupHeader_Crew"
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(37.5!, 79.0!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(1011.5!, 2.0!)
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(37.5!, 62.5!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(1011.5!, 16.0!)
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UsePadding = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell7, Me.XrTableCell9, Me.XrTableCell10, Me.XrTableCell11, Me.XrTableCell12, Me.XrTableCell13})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.Text = "Document Type"
        Me.XrTableCell7.Weight = 2.2154437447867017R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.StylePriority.UseFont = False
        Me.XrTableCell9.Text = "Number"
        Me.XrTableCell9.Weight = 1.1093100665067921R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StylePriority.UseFont = False
        Me.XrTableCell10.Text = "Date Issue"
        Me.XrTableCell10.Weight = 1.150937323120234R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.StylePriority.UseFont = False
        Me.XrTableCell11.Text = "Date Expiry"
        Me.XrTableCell11.Weight = 1.1588817847354624R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.StylePriority.UseFont = False
        Me.XrTableCell12.Text = "Country"
        Me.XrTableCell12.Weight = 0.95233509220090584R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.StylePriority.UseFont = False
        Me.XrTableCell13.Text = "Issued By"
        Me.XrTableCell13.Weight = 1.1271053346937558R
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003973643!, 13.00001!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1049.0!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UsePadding = False
        Me.XrTable1.Tag = "BIND"
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6})
        Me.XrTableRow1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.StylePriority.UseFont = False
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "Crew Name"
        Me.XrTableCell1.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = ":"
        Me.XrTableCell2.Weight = 0.073191334567147326R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Tag = "BIND_Crew"
        Me.XrTableCell3.Weight = 1.9268086654328527R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "Rank"
        Me.XrTableCell4.Weight = 0.36447417020115891R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Text = ":"
        Me.XrTableCell5.Weight = 0.073191596395749015R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Tag = "BIND_Rank"
        Me.XrTableCell6.Weight = 2.5623342334030923R
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5})
        Me.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail
        Me.GroupFooter1.HeightF = 36.45834!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
        '
        'XrLabel5
        '
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 36.45834!)
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.lblDatePrinted})
        Me.PageFooter.HeightF = 25.0!
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
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(962.3975!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(86.60248!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'rptTravelDoc
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeader_Crew, Me.GroupFooter1, Me.PageFooter})
        Me.ComponentStorage.Add(Me.SqlDataSource1)
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(50, 70, 41, 100)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents GroupHeader_Crew As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents txtDateIssue As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents txtDateExpiry As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblDatePrinted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents subHeader As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
