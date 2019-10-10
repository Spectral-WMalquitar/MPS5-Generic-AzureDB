<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptCompleteBiodata
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCompleteBiodata))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.subrpt_traveldoc = New DevExpress.XtraReports.UI.XRSubreport()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.subrpt_addr = New DevExpress.XtraReports.UI.XRSubreport()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.txtDOB = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.txtDateAccepted = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell30 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell31 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell32 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell33 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell34 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell35 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell36 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell37 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell38 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell39 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell40 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell41 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.txtDateSON = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell43 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell44 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell45 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell46 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow9 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell50 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell51 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell52 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell53 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.lblCompanyAddr = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCompanyName = New DevExpress.XtraReports.UI.XRLabel()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource()
        Me.GroupHeader_Crew = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell42 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter_IDNbr = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.lblDatePrinted = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel4, Me.XrLine3, Me.subrpt_traveldoc, Me.XrLabel3, Me.subrpt_addr, Me.XrLabel2, Me.XrPictureBox1, Me.XrTable2, Me.XrLine2})
        Me.Detail.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Detail.HeightF = 370.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StylePriority.UseFont = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 316.9168!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(145.8333!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "DOCUMENTS"
        '
        'XrLine3
        '
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 339.9166!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(1049.0!, 7.083333!)
        '
        'subrpt_traveldoc
        '
        Me.subrpt_traveldoc.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 347.0!)
        Me.subrpt_traveldoc.Name = "subrpt_traveldoc"
        Me.subrpt_traveldoc.SizeF = New System.Drawing.SizeF(1049.0!, 23.0!)
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 247.125!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "ADDRESS"
        '
        'subrpt_addr
        '
        Me.subrpt_addr.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 277.2083!)
        Me.subrpt_addr.Name = "subrpt_addr"
        Me.subrpt_addr.SizeF = New System.Drawing.SizeF(1049.0!, 23.0!)
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 51.99998!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(162.392!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "PHOTO"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(162.392!, 150.0!)
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(162.392!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XrTableRow3, Me.XrTableRow4, Me.XrTableRow5, Me.XrTableRow6, Me.XrTableRow7, Me.XrTableRow8, Me.XrTableRow9})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(886.608!, 200.0!)
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.Tag = "BIND"
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6, Me.XrTableCell7, Me.XrTableCell8})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.Text = "Full Name"
        Me.XrTableCell2.Weight = 1.1084420219321633R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.Text = ":"
        Me.XrTableCell3.Weight = 0.094626170699427747R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.Tag = "BIND_Crew"
        Me.XrTableCell4.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.XrTableCell4.Weight = 1.7009345244033376R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.Weight = 0.79556069093788429R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.Text = "Rank"
        Me.XrTableCell6.Weight = 1.1334670158148654R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.Text = ":"
        Me.XrTableCell7.Weight = 0.12412362775980051R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.Tag = "BIND_Rank"
        Me.XrTableCell8.Weight = 1.7424093564253345R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell9, Me.txtDOB, Me.XrTableCell11, Me.XrTableCell12, Me.XrTableCell13, Me.txtDateAccepted})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Date of Birth"
        Me.XrTableCell1.Weight = 1.1084420219321633R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.StylePriority.UseFont = False
        Me.XrTableCell9.Text = ":"
        Me.XrTableCell9.Weight = 0.094626170699427747R
        '
        'txtDOB
        '
        Me.txtDOB.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.StylePriority.UseFont = False
        Me.txtDOB.Tag = "BIND_DOB"
        Me.txtDOB.Weight = 1.7009345244033376R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.StylePriority.UseFont = False
        Me.XrTableCell11.Weight = 0.79556069093788429R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.StylePriority.UseFont = False
        Me.XrTableCell12.Text = "Date Accepted"
        Me.XrTableCell12.Weight = 1.1334670158148654R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.StylePriority.UseFont = False
        Me.XrTableCell13.Text = ":"
        Me.XrTableCell13.Weight = 0.12412362775980051R
        '
        'txtDateAccepted
        '
        Me.txtDateAccepted.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtDateAccepted.Name = "txtDateAccepted"
        Me.txtDateAccepted.StylePriority.UseFont = False
        Me.txtDateAccepted.Tag = "BIND_DateAccepted"
        Me.txtDateAccepted.Weight = 1.7424093564253345R
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell15, Me.XrTableCell16, Me.XrTableCell17, Me.XrTableCell18, Me.XrTableCell19, Me.XrTableCell20, Me.XrTableCell21})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.StylePriority.UseFont = False
        Me.XrTableCell15.Text = "Age"
        Me.XrTableCell15.Weight = 1.1084420219321633R
        '
        'XrTableCell16
        '
        Me.XrTableCell16.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell16.Name = "XrTableCell16"
        Me.XrTableCell16.StylePriority.UseFont = False
        Me.XrTableCell16.Text = ":"
        Me.XrTableCell16.Weight = 0.094626170699427747R
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.StylePriority.UseFont = False
        Me.XrTableCell17.Tag = "BIND_Age"
        Me.XrTableCell17.Weight = 1.7009345244033376R
        '
        'XrTableCell18
        '
        Me.XrTableCell18.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell18.Name = "XrTableCell18"
        Me.XrTableCell18.StylePriority.UseFont = False
        Me.XrTableCell18.Weight = 0.79556069093788429R
        '
        'XrTableCell19
        '
        Me.XrTableCell19.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell19.Name = "XrTableCell19"
        Me.XrTableCell19.StylePriority.UseFont = False
        Me.XrTableCell19.Text = "Nationality"
        Me.XrTableCell19.Weight = 1.1334670158148654R
        '
        'XrTableCell20
        '
        Me.XrTableCell20.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell20.Name = "XrTableCell20"
        Me.XrTableCell20.StylePriority.UseFont = False
        Me.XrTableCell20.Text = ":"
        Me.XrTableCell20.Weight = 0.12412362775980051R
        '
        'XrTableCell21
        '
        Me.XrTableCell21.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell21.Name = "XrTableCell21"
        Me.XrTableCell21.StylePriority.UseFont = False
        Me.XrTableCell21.Tag = "BIND_Nationality"
        Me.XrTableCell21.Weight = 1.7424093564253345R
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell22, Me.XrTableCell23, Me.XrTableCell24, Me.XrTableCell25, Me.XrTableCell26, Me.XrTableCell27, Me.XrTableCell28})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.0R
        '
        'XrTableCell22
        '
        Me.XrTableCell22.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell22.Name = "XrTableCell22"
        Me.XrTableCell22.StylePriority.UseFont = False
        Me.XrTableCell22.Text = "Place of Birth"
        Me.XrTableCell22.Weight = 1.1084420219321633R
        '
        'XrTableCell23
        '
        Me.XrTableCell23.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell23.Name = "XrTableCell23"
        Me.XrTableCell23.StylePriority.UseFont = False
        Me.XrTableCell23.Text = ":"
        Me.XrTableCell23.Weight = 0.094626170699427747R
        '
        'XrTableCell24
        '
        Me.XrTableCell24.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell24.Name = "XrTableCell24"
        Me.XrTableCell24.StylePriority.UseFont = False
        Me.XrTableCell24.Tag = "BIND_POB"
        Me.XrTableCell24.Weight = 1.7009345244033376R
        '
        'XrTableCell25
        '
        Me.XrTableCell25.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell25.Name = "XrTableCell25"
        Me.XrTableCell25.StylePriority.UseFont = False
        Me.XrTableCell25.Weight = 0.79556069093788429R
        '
        'XrTableCell26
        '
        Me.XrTableCell26.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell26.Name = "XrTableCell26"
        Me.XrTableCell26.StylePriority.UseFont = False
        Me.XrTableCell26.Text = "Service Status"
        Me.XrTableCell26.Weight = 1.1334670158148654R
        '
        'XrTableCell27
        '
        Me.XrTableCell27.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell27.Name = "XrTableCell27"
        Me.XrTableCell27.StylePriority.UseFont = False
        Me.XrTableCell27.Text = ":"
        Me.XrTableCell27.Weight = 0.12412362775980051R
        '
        'XrTableCell28
        '
        Me.XrTableCell28.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell28.Name = "XrTableCell28"
        Me.XrTableCell28.StylePriority.UseFont = False
        Me.XrTableCell28.Tag = "BIND_CurrentStat"
        Me.XrTableCell28.Weight = 1.7424093564253345R
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell29, Me.XrTableCell30, Me.XrTableCell31, Me.XrTableCell32, Me.XrTableCell33, Me.XrTableCell34, Me.XrTableCell35})
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.Weight = 1.0R
        '
        'XrTableCell29
        '
        Me.XrTableCell29.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell29.Name = "XrTableCell29"
        Me.XrTableCell29.StylePriority.UseFont = False
        Me.XrTableCell29.Text = "Height"
        Me.XrTableCell29.Weight = 1.1084420219321633R
        '
        'XrTableCell30
        '
        Me.XrTableCell30.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell30.Name = "XrTableCell30"
        Me.XrTableCell30.StylePriority.UseFont = False
        Me.XrTableCell30.Text = ":"
        Me.XrTableCell30.Weight = 0.094626170699427747R
        '
        'XrTableCell31
        '
        Me.XrTableCell31.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell31.Name = "XrTableCell31"
        Me.XrTableCell31.StylePriority.UseFont = False
        Me.XrTableCell31.Tag = "BIND_Height"
        Me.XrTableCell31.Weight = 1.7009345244033376R
        '
        'XrTableCell32
        '
        Me.XrTableCell32.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell32.Name = "XrTableCell32"
        Me.XrTableCell32.StylePriority.UseFont = False
        Me.XrTableCell32.Weight = 0.79556069093788429R
        '
        'XrTableCell33
        '
        Me.XrTableCell33.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell33.Name = "XrTableCell33"
        Me.XrTableCell33.StylePriority.UseFont = False
        Me.XrTableCell33.Text = "Current Vessel"
        Me.XrTableCell33.Weight = 1.1334670158148654R
        '
        'XrTableCell34
        '
        Me.XrTableCell34.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell34.Name = "XrTableCell34"
        Me.XrTableCell34.StylePriority.UseFont = False
        Me.XrTableCell34.Text = ":"
        Me.XrTableCell34.Weight = 0.12412362775980051R
        '
        'XrTableCell35
        '
        Me.XrTableCell35.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell35.Name = "XrTableCell35"
        Me.XrTableCell35.StylePriority.UseFont = False
        Me.XrTableCell35.Tag = "BIND_CurrentVsl"
        Me.XrTableCell35.Weight = 1.7424093564253345R
        '
        'XrTableRow7
        '
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell36, Me.XrTableCell37, Me.XrTableCell38, Me.XrTableCell39, Me.XrTableCell40, Me.XrTableCell41, Me.txtDateSON})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.Weight = 1.0R
        '
        'XrTableCell36
        '
        Me.XrTableCell36.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell36.Name = "XrTableCell36"
        Me.XrTableCell36.StylePriority.UseFont = False
        Me.XrTableCell36.Text = "Weight"
        Me.XrTableCell36.Weight = 1.1084420219321633R
        '
        'XrTableCell37
        '
        Me.XrTableCell37.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell37.Name = "XrTableCell37"
        Me.XrTableCell37.StylePriority.UseFont = False
        Me.XrTableCell37.Text = ":"
        Me.XrTableCell37.Weight = 0.094626170699427747R
        '
        'XrTableCell38
        '
        Me.XrTableCell38.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell38.Name = "XrTableCell38"
        Me.XrTableCell38.StylePriority.UseFont = False
        Me.XrTableCell38.Tag = "BIND_Weight"
        Me.XrTableCell38.Weight = 1.7009345244033376R
        '
        'XrTableCell39
        '
        Me.XrTableCell39.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell39.Name = "XrTableCell39"
        Me.XrTableCell39.StylePriority.UseFont = False
        Me.XrTableCell39.Weight = 0.79556069093788429R
        '
        'XrTableCell40
        '
        Me.XrTableCell40.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell40.Name = "XrTableCell40"
        Me.XrTableCell40.StylePriority.UseFont = False
        Me.XrTableCell40.Text = "Sign On"
        Me.XrTableCell40.Weight = 1.1334670158148654R
        '
        'XrTableCell41
        '
        Me.XrTableCell41.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell41.Name = "XrTableCell41"
        Me.XrTableCell41.StylePriority.UseFont = False
        Me.XrTableCell41.Text = ":"
        Me.XrTableCell41.Weight = 0.12412362775980051R
        '
        'txtDateSON
        '
        Me.txtDateSON.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtDateSON.Name = "txtDateSON"
        Me.txtDateSON.StylePriority.UseFont = False
        Me.txtDateSON.Tag = "BIND_DateSOn"
        Me.txtDateSON.Weight = 1.7424093564253345R
        '
        'XrTableRow8
        '
        Me.XrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell43, Me.XrTableCell44, Me.XrTableCell45, Me.XrTableCell46})
        Me.XrTableRow8.Name = "XrTableRow8"
        Me.XrTableRow8.Weight = 1.0R
        '
        'XrTableCell43
        '
        Me.XrTableCell43.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell43.Name = "XrTableCell43"
        Me.XrTableCell43.StylePriority.UseFont = False
        Me.XrTableCell43.Text = "Marital Status"
        Me.XrTableCell43.Weight = 1.1084420219321633R
        '
        'XrTableCell44
        '
        Me.XrTableCell44.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell44.Name = "XrTableCell44"
        Me.XrTableCell44.StylePriority.UseFont = False
        Me.XrTableCell44.Text = ":"
        Me.XrTableCell44.Weight = 0.094626170699427747R
        '
        'XrTableCell45
        '
        Me.XrTableCell45.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell45.Name = "XrTableCell45"
        Me.XrTableCell45.StylePriority.UseFont = False
        Me.XrTableCell45.Tag = "BIND_MaritalStatus"
        Me.XrTableCell45.Weight = 1.7009345244033376R
        '
        'XrTableCell46
        '
        Me.XrTableCell46.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell46.Name = "XrTableCell46"
        Me.XrTableCell46.StylePriority.UseFont = False
        Me.XrTableCell46.Weight = 3.7955606909378847R
        '
        'XrTableRow9
        '
        Me.XrTableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell50, Me.XrTableCell51, Me.XrTableCell52, Me.XrTableCell53})
        Me.XrTableRow9.Name = "XrTableRow9"
        Me.XrTableRow9.Weight = 1.0R
        '
        'XrTableCell50
        '
        Me.XrTableCell50.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell50.Name = "XrTableCell50"
        Me.XrTableCell50.StylePriority.UseFont = False
        Me.XrTableCell50.Text = "Religion"
        Me.XrTableCell50.Weight = 1.1084420219321633R
        '
        'XrTableCell51
        '
        Me.XrTableCell51.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell51.Name = "XrTableCell51"
        Me.XrTableCell51.StylePriority.UseFont = False
        Me.XrTableCell51.Text = ":"
        Me.XrTableCell51.Weight = 0.094626170699427747R
        '
        'XrTableCell52
        '
        Me.XrTableCell52.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell52.Name = "XrTableCell52"
        Me.XrTableCell52.StylePriority.UseFont = False
        Me.XrTableCell52.Tag = "BIND_Religion"
        Me.XrTableCell52.Weight = 1.7009345244033376R
        '
        'XrTableCell53
        '
        Me.XrTableCell53.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.XrTableCell53.Name = "XrTableCell53"
        Me.XrTableCell53.StylePriority.UseFont = False
        Me.XrTableCell53.Weight = 3.7955606909378847R
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 270.1249!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(1049.0!, 7.083333!)
        '
        'TopMargin
        '
        Me.TopMargin.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.TopMargin.HeightF = 40.625!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.StylePriority.UseFont = False
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(357.9167!, 27.04169!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "Complete Biodata"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine1
        '
        Me.XrLine1.LineWidth = 3
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 27.04167!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1049.0!, 13.0!)
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblCompanyAddr, Me.lblCompanyName})
        Me.PageHeader.HeightF = 100.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblCompanyAddr
        '
        Me.lblCompanyAddr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyAddr.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 37.58334!)
        Me.lblCompanyAddr.Name = "lblCompanyAddr"
        Me.lblCompanyAddr.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCompanyAddr.SizeF = New System.Drawing.SizeF(1049.0!, 37.58334!)
        Me.lblCompanyAddr.StylePriority.UseFont = False
        Me.lblCompanyAddr.StylePriority.UseTextAlignment = False
        Me.lblCompanyAddr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyName.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCompanyName.SizeF = New System.Drawing.SizeF(1049.0!, 37.58334!)
        Me.lblCompanyName.StylePriority.UseFont = False
        Me.lblCompanyName.StylePriority.UseTextAlignment = False
        Me.lblCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
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
        Me.GroupHeader_Crew.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XrLabel1, Me.XrLine1})
        Me.GroupHeader_Crew.HeightF = 40.04167!
        Me.GroupHeader_Crew.Name = "GroupHeader_Crew"
        '
        'XrTable1
        '
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(818.4127!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(230.5872!, 25.0!)
        Me.XrTable1.Tag = "BIND"
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell14, Me.XrTableCell42})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.StylePriority.UseFont = False
        Me.XrTableCell14.Text = "Co ID Number:"
        Me.XrTableCell14.Weight = 1.3058721923828125R
        '
        'XrTableCell42
        '
        Me.XrTableCell42.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.XrTableCell42.Name = "XrTableCell42"
        Me.XrTableCell42.StylePriority.UseFont = False
        Me.XrTableCell42.Tag = "BIND_CoIDNbr"
        Me.XrTableCell42.Weight = 1.0R
        '
        'GroupFooter_IDNbr
        '
        Me.GroupFooter_IDNbr.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5})
        Me.GroupFooter_IDNbr.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail
        Me.GroupFooter_IDNbr.HeightF = 36.45834!
        Me.GroupFooter_IDNbr.Name = "GroupFooter_IDNbr"
        Me.GroupFooter_IDNbr.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry
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
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDatePrinted})
        Me.PageFooter.HeightF = 100.0!
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
        'rptCompleteBiodata
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeader_Crew, Me.GroupFooter_IDNbr, Me.PageFooter})
        Me.ComponentStorage.Add(Me.SqlDataSource1)
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(50, 70, 41, 0)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "14.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents txtDOB As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents txtDateAccepted As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell30 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell31 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell32 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell33 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell34 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell35 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell36 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell37 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell38 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell39 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell40 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell41 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents txtDateSON As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell43 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell44 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell45 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell46 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell50 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell51 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell52 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell53 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents subrpt_addr As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents subrpt_traveldoc As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents GroupHeader_Crew As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell42 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lblCompanyAddr As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCompanyName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents GroupFooter_IDNbr As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblDatePrinted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
End Class
