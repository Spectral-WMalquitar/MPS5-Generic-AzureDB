<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QualificationMatrix
    Inherits BaseControl.BaseControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QualificationMatrix))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CrewAshoreCrew = New DevExpress.XtraGrid.GridControl()
        Me.CrewAshoreView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.glcmFullName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.glcmRankName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.glcmPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.glcmFKeyIDNbr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnVessels = New DevExpress.XtraEditors.SimpleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CertCourseGrid = New DevExpress.XtraGrid.GridControl()
        Me.CertCourseView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.glcmCoursesCertificates = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.glcmQualificationMatrixPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.glcmCertificates = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepCertificates = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.glcmCourses = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepCourses = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.glcmEdited = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepNew = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ReportGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.ReportView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit20 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.SelectedCrewGrid = New DevExpress.XtraGrid.GridControl()
        Me.SelectedCrewView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit18 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.OnBoardCrewGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.OnBoardCrewView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReportGrid = New DevExpress.XtraGrid.GridControl()
        Me.ReportView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.glcmReportPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmReportName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OnBoardCrewGrid = New DevExpress.XtraGrid.GridControl()
        Me.OnBoardCrewView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.glcmCrewPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmIDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCrewFullName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCrewRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepFullName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VesselGrid = New DevExpress.XtraGrid.GridControl()
        Me.VesselView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.glcmVesselName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.glcmVslSortCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cmbVesselName = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup8 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.tbgcPrintingModes = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem39 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem42 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem45 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem37 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem3 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem4 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem5 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView2 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridControl5 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.RadioGroup3 = New DevExpress.XtraEditors.RadioGroup()
        Me.DropDownButton3 = New DevExpress.XtraEditors.DropDownButton()
        Me.DropDownButton4 = New DevExpress.XtraEditors.DropDownButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GridControl6 = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GridControl7 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView3 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridControl8 = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit9 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit10 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CheckEdit2 = New DevExpress.XtraEditors.CheckEdit()
        Me.RadioGroup4 = New DevExpress.XtraEditors.RadioGroup()
        Me.DropDownButton5 = New DevExpress.XtraEditors.DropDownButton()
        Me.DropDownButton6 = New DevExpress.XtraEditors.DropDownButton()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.GridControl9 = New DevExpress.XtraGrid.GridControl()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit11 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit12 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.DropDownButton7 = New DevExpress.XtraEditors.DropDownButton()
        Me.DropDownButton8 = New DevExpress.XtraEditors.DropDownButton()
        Me.CheckEdit3 = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label25 = New System.Windows.Forms.Label()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CrewAshoreCrew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewAshoreView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CertCourseGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CertCourseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepCertificates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepCourses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectedCrewGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectedCrewView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnBoardCrewGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnBoardCrewView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnBoardCrewGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnBoardCrewView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepFullName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VesselGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VesselView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbVesselName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbgcPrintingModes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageCollection
        '
        Me.ImageCollection.ImageStream = CType(resources.GetObject("ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection.InsertGalleryImage("add_32x32.png", "images/actions/add_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png"), 0)
        Me.ImageCollection.Images.SetKeyName(0, "add_32x32.png")
        Me.ImageCollection.InsertGalleryImage("cancel_32x32.png", "images/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png"), 1)
        Me.ImageCollection.Images.SetKeyName(1, "cancel_32x32.png")
        Me.ImageCollection.InsertGalleryImage("edit_32x32.png", "images/edit/edit_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_32x32.png"), 2)
        Me.ImageCollection.Images.SetKeyName(2, "edit_32x32.png")
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1146, 520)
        Me.header.TabIndex = 7
        Me.header.Text = "Qualification Matrix"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CrewAshoreCrew)
        Me.LayoutControl1.Controls.Add(Me.Label20)
        Me.LayoutControl1.Controls.Add(Me.Label19)
        Me.LayoutControl1.Controls.Add(Me.Label8)
        Me.LayoutControl1.Controls.Add(Me.Label7)
        Me.LayoutControl1.Controls.Add(Me.btnVessels)
        Me.LayoutControl1.Controls.Add(Me.Label6)
        Me.LayoutControl1.Controls.Add(Me.Label5)
        Me.LayoutControl1.Controls.Add(Me.Label4)
        Me.LayoutControl1.Controls.Add(Me.CertCourseGrid)
        Me.LayoutControl1.Controls.Add(Me.ReportGrid2)
        Me.LayoutControl1.Controls.Add(Me.SelectedCrewGrid)
        Me.LayoutControl1.Controls.Add(Me.OnBoardCrewGrid2)
        Me.LayoutControl1.Controls.Add(Me.ReportGrid)
        Me.LayoutControl1.Controls.Add(Me.Label3)
        Me.LayoutControl1.Controls.Add(Me.Label2)
        Me.LayoutControl1.Controls.Add(Me.OnBoardCrewGrid)
        Me.LayoutControl1.Controls.Add(Me.Label1)
        Me.LayoutControl1.Controls.Add(Me.VesselGrid)
        Me.LayoutControl1.Controls.Add(Me.cmbVesselName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 22)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(298, 171, 351, 502)
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1142, 496)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CrewAshoreCrew
        '
        Me.CrewAshoreCrew.AllowDrop = True
        Me.CrewAshoreCrew.Location = New System.Drawing.Point(589, 85)
        Me.CrewAshoreCrew.MainView = Me.CrewAshoreView
        Me.CrewAshoreCrew.Name = "CrewAshoreCrew"
        Me.CrewAshoreCrew.Size = New System.Drawing.Size(268, 374)
        Me.CrewAshoreCrew.TabIndex = 67
        Me.CrewAshoreCrew.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CrewAshoreView})
        '
        'CrewAshoreView
        '
        Me.CrewAshoreView.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
        Me.CrewAshoreView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.CrewAshoreView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewAshoreView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.CrewAshoreView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewAshoreView.Appearance.Row.Options.UseTextOptions = True
        Me.CrewAshoreView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewAshoreView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CrewAshoreView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.CrewAshoreView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.CrewAshoreView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewAshoreView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CrewAshoreView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand5})
        Me.CrewAshoreView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.glcmPKey, Me.glcmFKeyIDNbr, Me.glcmFullName, Me.glcmRankName})
        Me.CrewAshoreView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.CrewAshoreView.GridControl = Me.CrewAshoreCrew
        Me.CrewAshoreView.Name = "CrewAshoreView"
        Me.CrewAshoreView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CrewAshoreView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CrewAshoreView.OptionsBehavior.AutoPopulateColumns = False
        Me.CrewAshoreView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CrewAshoreView.OptionsBehavior.Editable = False
        Me.CrewAshoreView.OptionsCustomization.AllowFilter = False
        Me.CrewAshoreView.OptionsCustomization.AllowGroup = False
        Me.CrewAshoreView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CrewAshoreView.OptionsDetail.EnableMasterViewMode = False
        Me.CrewAshoreView.OptionsFilter.AllowFilterEditor = False
        Me.CrewAshoreView.OptionsFind.AlwaysVisible = True
        Me.CrewAshoreView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CrewAshoreView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CrewAshoreView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.CrewAshoreView.OptionsSelection.UseIndicatorForSelection = False
        Me.CrewAshoreView.OptionsView.ColumnAutoWidth = True
        Me.CrewAshoreView.OptionsView.ShowBands = False
        Me.CrewAshoreView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.CrewAshoreView.OptionsView.ShowGroupPanel = False
        '
        'GridBand5
        '
        Me.GridBand5.Caption = "GridBand1"
        Me.GridBand5.Columns.Add(Me.glcmFullName)
        Me.GridBand5.Columns.Add(Me.glcmRankName)
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.VisibleIndex = 0
        Me.GridBand5.Width = 994
        '
        'glcmFullName
        '
        Me.glcmFullName.Caption = "Crew Name"
        Me.glcmFullName.FieldName = "FullName"
        Me.glcmFullName.Name = "glcmFullName"
        Me.glcmFullName.Visible = True
        Me.glcmFullName.Width = 706
        '
        'glcmRankName
        '
        Me.glcmRankName.Caption = "Rank"
        Me.glcmRankName.FieldName = "RankName"
        Me.glcmRankName.Name = "glcmRankName"
        Me.glcmRankName.Visible = True
        Me.glcmRankName.Width = 288
        '
        'glcmPKey
        '
        Me.glcmPKey.FieldName = "PKey"
        Me.glcmPKey.Name = "glcmPKey"
        '
        'glcmFKeyIDNbr
        '
        Me.glcmFKeyIDNbr.FieldName = "FKeyIDNbr"
        Me.glcmFKeyIDNbr.Name = "glcmFKeyIDNbr"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(866, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(239, 22)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "Select a Report"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(589, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(268, 22)
        Me.Label19.TabIndex = 65
        Me.Label19.Text = "Crew Ashore"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(323, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(257, 22)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Selected Crews"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(277, 22)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Select Crew On Board"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnVessels
        '
        Me.btnVessels.Location = New System.Drawing.Point(260, 85)
        Me.btnVessels.Name = "btnVessels"
        Me.btnVessels.Padding = New System.Windows.Forms.Padding(2)
        Me.btnVessels.Size = New System.Drawing.Size(54, 22)
        Me.btnVessels.StyleController = Me.LayoutControl1
        Me.btnVessels.TabIndex = 61
        Me.btnVessels.Text = "Clear"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(748, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(357, 22)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Map to Course"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(325, 22)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Course and Certificates in the Report"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(366, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(378, 22)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Map to Certificate"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CertCourseGrid
        '
        Me.CertCourseGrid.Location = New System.Drawing.Point(37, 85)
        Me.CertCourseGrid.MainView = Me.CertCourseView
        Me.CertCourseGrid.Name = "CertCourseGrid"
        Me.CertCourseGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepCourses, Me.RepCertificates, Me.RepNew})
        Me.CertCourseGrid.Size = New System.Drawing.Size(1068, 374)
        Me.CertCourseGrid.TabIndex = 54
        Me.CertCourseGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CertCourseView})
        '
        'CertCourseView
        '
        Me.CertCourseView.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
        Me.CertCourseView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.CertCourseView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CertCourseView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.CertCourseView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CertCourseView.Appearance.Row.Options.UseTextOptions = True
        Me.CertCourseView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CertCourseView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CertCourseView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.CertCourseView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.CertCourseView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CertCourseView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CertCourseView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.CertCourseView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.glcmQualificationMatrixPKey, Me.glcmCoursesCertificates, Me.glcmCertificates, Me.glcmCourses, Me.glcmEdited})
        Me.CertCourseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.CertCourseView.GridControl = Me.CertCourseGrid
        Me.CertCourseView.Name = "CertCourseView"
        Me.CertCourseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CertCourseView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CertCourseView.OptionsBehavior.AutoPopulateColumns = False
        Me.CertCourseView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CertCourseView.OptionsCustomization.AllowFilter = False
        Me.CertCourseView.OptionsCustomization.AllowGroup = False
        Me.CertCourseView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CertCourseView.OptionsDetail.EnableMasterViewMode = False
        Me.CertCourseView.OptionsFilter.AllowFilterEditor = False
        Me.CertCourseView.OptionsFind.AlwaysVisible = True
        Me.CertCourseView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CertCourseView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CertCourseView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.CertCourseView.OptionsSelection.UseIndicatorForSelection = False
        Me.CertCourseView.OptionsView.ColumnAutoWidth = True
        Me.CertCourseView.OptionsView.ShowBands = False
        Me.CertCourseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.CertCourseView.OptionsView.ShowGroupPanel = False
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "GridBand1"
        Me.GridBand2.Columns.Add(Me.glcmCoursesCertificates)
        Me.GridBand2.Columns.Add(Me.glcmQualificationMatrixPKey)
        Me.GridBand2.Columns.Add(Me.glcmCertificates)
        Me.GridBand2.Columns.Add(Me.glcmCourses)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 1050
        '
        'glcmCoursesCertificates
        '
        Me.glcmCoursesCertificates.Caption = "Courses and Certificates"
        Me.glcmCoursesCertificates.FieldName = "Name"
        Me.glcmCoursesCertificates.Name = "glcmCoursesCertificates"
        Me.glcmCoursesCertificates.OptionsColumn.AllowEdit = False
        Me.glcmCoursesCertificates.OptionsColumn.AllowMove = False
        Me.glcmCoursesCertificates.OptionsColumn.AllowShowHide = False
        Me.glcmCoursesCertificates.Visible = True
        Me.glcmCoursesCertificates.Width = 309
        '
        'glcmQualificationMatrixPKey
        '
        Me.glcmQualificationMatrixPKey.FieldName = "PKey"
        Me.glcmQualificationMatrixPKey.Name = "glcmQualificationMatrixPKey"
        '
        'glcmCertificates
        '
        Me.glcmCertificates.Caption = "Certificates"
        Me.glcmCertificates.ColumnEdit = Me.RepCertificates
        Me.glcmCertificates.FieldName = "FKeyDocument"
        Me.glcmCertificates.Name = "glcmCertificates"
        Me.glcmCertificates.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        Me.glcmCertificates.Visible = True
        Me.glcmCertificates.Width = 385
        '
        'RepCertificates
        '
        Me.RepCertificates.AutoHeight = False
        Me.RepCertificates.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepCertificates.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RepCertificates.DisplayMember = "Name"
        Me.RepCertificates.Name = "RepCertificates"
        Me.RepCertificates.NullText = ""
        Me.RepCertificates.ShowFooter = False
        Me.RepCertificates.ShowHeader = False
        Me.RepCertificates.ValueMember = "PKey"
        '
        'glcmCourses
        '
        Me.glcmCourses.Caption = "Courses"
        Me.glcmCourses.ColumnEdit = Me.RepCourses
        Me.glcmCourses.FieldName = "FKeyCourse"
        Me.glcmCourses.Name = "glcmCourses"
        Me.glcmCourses.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        Me.glcmCourses.Visible = True
        Me.glcmCourses.Width = 356
        '
        'RepCourses
        '
        Me.RepCourses.AutoHeight = False
        Me.RepCourses.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepCourses.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RepCourses.DisplayMember = "Name"
        Me.RepCourses.DropDownRows = 10
        Me.RepCourses.Name = "RepCourses"
        Me.RepCourses.NullText = ""
        Me.RepCourses.ShowFooter = False
        Me.RepCourses.ShowHeader = False
        Me.RepCourses.ValueMember = "PKey"
        '
        'glcmEdited
        '
        Me.glcmEdited.Caption = "Edited"
        Me.glcmEdited.FieldName = "Edited"
        Me.glcmEdited.Name = "glcmEdited"
        '
        'RepNew
        '
        Me.RepNew.AutoHeight = False
        Me.RepNew.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepNew.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RepNew.DisplayMember = "Name"
        Me.RepNew.Name = "RepNew"
        Me.RepNew.NullText = ""
        Me.RepNew.ValueMember = "PKey"
        '
        'ReportGrid2
        '
        Me.ReportGrid2.Location = New System.Drawing.Point(866, 85)
        Me.ReportGrid2.MainView = Me.ReportView2
        Me.ReportGrid2.Name = "ReportGrid2"
        Me.ReportGrid2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit20})
        Me.ReportGrid2.Size = New System.Drawing.Size(239, 374)
        Me.ReportGrid2.TabIndex = 52
        Me.ReportGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportView2})
        '
        'ReportView2
        '
        Me.ReportView2.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.ReportView2.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReportView2.Appearance.GroupRow.Options.UseTextOptions = True
        Me.ReportView2.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReportView2.Appearance.Row.Options.UseTextOptions = True
        Me.ReportView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReportView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ReportView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.ReportView2.AppearancePrint.Row.Options.UseTextOptions = True
        Me.ReportView2.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReportView2.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ReportView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn54, Me.GridColumn55})
        Me.ReportView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.ReportView2.GridControl = Me.ReportGrid2
        Me.ReportView2.Name = "ReportView2"
        Me.ReportView2.NewItemRowText = "Add New Rank Here"
        Me.ReportView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportView2.OptionsBehavior.AutoPopulateColumns = False
        Me.ReportView2.OptionsBehavior.AutoSelectAllInEditor = False
        Me.ReportView2.OptionsCustomization.AllowFilter = False
        Me.ReportView2.OptionsCustomization.AllowGroup = False
        Me.ReportView2.OptionsCustomization.AllowQuickHideColumns = False
        Me.ReportView2.OptionsDetail.EnableMasterViewMode = False
        Me.ReportView2.OptionsFilter.AllowFilterEditor = False
        Me.ReportView2.OptionsFind.AllowFindPanel = False
        Me.ReportView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ReportView2.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.ReportView2.OptionsSelection.EnableAppearanceHideSelection = False
        Me.ReportView2.OptionsSelection.UseIndicatorForSelection = False
        Me.ReportView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn54
        '
        Me.GridColumn54.FieldName = "PKey"
        Me.GridColumn54.Name = "GridColumn54"
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "Report Type"
        Me.GridColumn55.FieldName = "Name"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.OptionsColumn.AllowEdit = False
        Me.GridColumn55.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn55.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn55.OptionsColumn.AllowShowHide = False
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 0
        Me.GridColumn55.Width = 107
        '
        'RepositoryItemLookUpEdit20
        '
        Me.RepositoryItemLookUpEdit20.AutoHeight = False
        Me.RepositoryItemLookUpEdit20.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit20.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit20.DisplayMember = "FullName"
        Me.RepositoryItemLookUpEdit20.DropDownRows = 10
        Me.RepositoryItemLookUpEdit20.Name = "RepositoryItemLookUpEdit20"
        Me.RepositoryItemLookUpEdit20.ShowFooter = False
        Me.RepositoryItemLookUpEdit20.ShowHeader = False
        Me.RepositoryItemLookUpEdit20.ValueMember = "FKeyIDNbr"
        '
        'SelectedCrewGrid
        '
        Me.SelectedCrewGrid.AllowDrop = True
        Me.SelectedCrewGrid.Location = New System.Drawing.Point(323, 85)
        Me.SelectedCrewGrid.MainView = Me.SelectedCrewView
        Me.SelectedCrewGrid.Name = "SelectedCrewGrid"
        Me.SelectedCrewGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit18})
        Me.SelectedCrewGrid.Size = New System.Drawing.Size(257, 374)
        Me.SelectedCrewGrid.TabIndex = 49
        Me.SelectedCrewGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SelectedCrewView})
        '
        'SelectedCrewView
        '
        Me.SelectedCrewView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.SelectedCrewView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SelectedCrewView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.SelectedCrewView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SelectedCrewView.Appearance.Row.Options.UseTextOptions = True
        Me.SelectedCrewView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SelectedCrewView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SelectedCrewView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.SelectedCrewView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.SelectedCrewView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.SelectedCrewView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SelectedCrewView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49})
        Me.SelectedCrewView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.SelectedCrewView.GridControl = Me.SelectedCrewGrid
        Me.SelectedCrewView.Name = "SelectedCrewView"
        Me.SelectedCrewView.NewItemRowText = "Add New Rank Here"
        Me.SelectedCrewView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SelectedCrewView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SelectedCrewView.OptionsBehavior.AutoPopulateColumns = False
        Me.SelectedCrewView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.SelectedCrewView.OptionsCustomization.AllowFilter = False
        Me.SelectedCrewView.OptionsCustomization.AllowGroup = False
        Me.SelectedCrewView.OptionsCustomization.AllowQuickHideColumns = False
        Me.SelectedCrewView.OptionsDetail.EnableMasterViewMode = False
        Me.SelectedCrewView.OptionsFilter.AllowFilterEditor = False
        Me.SelectedCrewView.OptionsFind.AllowFindPanel = False
        Me.SelectedCrewView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SelectedCrewView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.SelectedCrewView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.SelectedCrewView.OptionsSelection.UseIndicatorForSelection = False
        Me.SelectedCrewView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn46
        '
        Me.GridColumn46.FieldName = "PKey"
        Me.GridColumn46.Name = "GridColumn46"
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "IDNbr"
        Me.GridColumn47.FieldName = "FKeyIDNbr"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Width = 114
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Crew Name"
        Me.GridColumn48.FieldName = "FullName"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsColumn.AllowEdit = False
        Me.GridColumn48.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn48.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn48.OptionsColumn.AllowShowHide = False
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 0
        Me.GridColumn48.Width = 164
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Rank"
        Me.GridColumn49.FieldName = "RankName"
        Me.GridColumn49.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsColumn.AllowEdit = False
        Me.GridColumn49.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn49.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn49.OptionsColumn.AllowShowHide = False
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 1
        Me.GridColumn49.Width = 78
        '
        'RepositoryItemLookUpEdit18
        '
        Me.RepositoryItemLookUpEdit18.AutoHeight = False
        Me.RepositoryItemLookUpEdit18.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit18.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit18.DisplayMember = "FullName"
        Me.RepositoryItemLookUpEdit18.DropDownRows = 10
        Me.RepositoryItemLookUpEdit18.Name = "RepositoryItemLookUpEdit18"
        Me.RepositoryItemLookUpEdit18.ShowFooter = False
        Me.RepositoryItemLookUpEdit18.ShowHeader = False
        Me.RepositoryItemLookUpEdit18.ValueMember = "FKeyIDNbr"
        '
        'OnBoardCrewGrid2
        '
        Me.OnBoardCrewGrid2.AllowDrop = True
        Me.OnBoardCrewGrid2.Location = New System.Drawing.Point(37, 111)
        Me.OnBoardCrewGrid2.MainView = Me.OnBoardCrewView2
        Me.OnBoardCrewGrid2.Name = "OnBoardCrewGrid2"
        Me.OnBoardCrewGrid2.Size = New System.Drawing.Size(277, 348)
        Me.OnBoardCrewGrid2.TabIndex = 46
        Me.OnBoardCrewGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.OnBoardCrewView2})
        '
        'OnBoardCrewView2
        '
        Me.OnBoardCrewView2.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.OnBoardCrewView2.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView2.Appearance.GroupRow.Options.UseTextOptions = True
        Me.OnBoardCrewView2.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView2.Appearance.Row.Options.UseTextOptions = True
        Me.OnBoardCrewView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.OnBoardCrewView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.OnBoardCrewView2.AppearancePrint.Row.Options.UseTextOptions = True
        Me.OnBoardCrewView2.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView2.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.OnBoardCrewView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45})
        Me.OnBoardCrewView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.OnBoardCrewView2.GridControl = Me.OnBoardCrewGrid2
        Me.OnBoardCrewView2.Name = "OnBoardCrewView2"
        Me.OnBoardCrewView2.NewItemRowText = "Add New Rank Here"
        Me.OnBoardCrewView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.OnBoardCrewView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.OnBoardCrewView2.OptionsBehavior.AutoPopulateColumns = False
        Me.OnBoardCrewView2.OptionsBehavior.AutoSelectAllInEditor = False
        Me.OnBoardCrewView2.OptionsCustomization.AllowFilter = False
        Me.OnBoardCrewView2.OptionsCustomization.AllowGroup = False
        Me.OnBoardCrewView2.OptionsCustomization.AllowQuickHideColumns = False
        Me.OnBoardCrewView2.OptionsDetail.EnableMasterViewMode = False
        Me.OnBoardCrewView2.OptionsFilter.AllowFilterEditor = False
        Me.OnBoardCrewView2.OptionsFind.AllowFindPanel = False
        Me.OnBoardCrewView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.OnBoardCrewView2.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.OnBoardCrewView2.OptionsSelection.EnableAppearanceHideSelection = False
        Me.OnBoardCrewView2.OptionsSelection.UseIndicatorForSelection = False
        Me.OnBoardCrewView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn42
        '
        Me.GridColumn42.FieldName = "PKey"
        Me.GridColumn42.Name = "GridColumn42"
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "IDNbr"
        Me.GridColumn43.FieldName = "FKeyIDNbr"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Width = 114
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Crew Name"
        Me.GridColumn44.FieldName = "FullName"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        Me.GridColumn44.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn44.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn44.OptionsColumn.AllowShowHide = False
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 0
        Me.GridColumn44.Width = 176
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Rank"
        Me.GridColumn45.FieldName = "RankName"
        Me.GridColumn45.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        Me.GridColumn45.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn45.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn45.OptionsColumn.AllowShowHide = False
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 1
        Me.GridColumn45.Width = 83
        '
        'ReportGrid
        '
        Me.ReportGrid.Location = New System.Drawing.Point(767, 85)
        Me.ReportGrid.MainView = Me.ReportView
        Me.ReportGrid.Name = "ReportGrid"
        Me.ReportGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit2})
        Me.ReportGrid.Size = New System.Drawing.Size(338, 374)
        Me.ReportGrid.TabIndex = 43
        Me.ReportGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportView})
        '
        'ReportView
        '
        Me.ReportView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.ReportView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReportView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.ReportView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReportView.Appearance.Row.Options.UseTextOptions = True
        Me.ReportView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReportView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ReportView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.ReportView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.ReportView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReportView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ReportView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmReportPKey, Me.glcmReportName})
        Me.ReportView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.ReportView.GridControl = Me.ReportGrid
        Me.ReportView.Name = "ReportView"
        Me.ReportView.NewItemRowText = "Add New Rank Here"
        Me.ReportView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportView.OptionsBehavior.AutoPopulateColumns = False
        Me.ReportView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.ReportView.OptionsCustomization.AllowFilter = False
        Me.ReportView.OptionsCustomization.AllowGroup = False
        Me.ReportView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ReportView.OptionsDetail.EnableMasterViewMode = False
        Me.ReportView.OptionsFilter.AllowFilterEditor = False
        Me.ReportView.OptionsFind.AllowFindPanel = False
        Me.ReportView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ReportView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.ReportView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.ReportView.OptionsSelection.UseIndicatorForSelection = False
        Me.ReportView.OptionsView.ShowGroupPanel = False
        '
        'glcmReportPKey
        '
        Me.glcmReportPKey.FieldName = "PKey"
        Me.glcmReportPKey.Name = "glcmReportPKey"
        Me.glcmReportPKey.OptionsColumn.AllowEdit = False
        '
        'glcmReportName
        '
        Me.glcmReportName.Caption = "Report Type"
        Me.glcmReportName.FieldName = "Name"
        Me.glcmReportName.Name = "glcmReportName"
        Me.glcmReportName.OptionsColumn.AllowEdit = False
        Me.glcmReportName.Visible = True
        Me.glcmReportName.VisibleIndex = 0
        Me.glcmReportName.Width = 107
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit2.DisplayMember = "FullName"
        Me.RepositoryItemLookUpEdit2.DropDownRows = 10
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.ShowFooter = False
        Me.RepositoryItemLookUpEdit2.ShowHeader = False
        Me.RepositoryItemLookUpEdit2.ValueMember = "FKeyIDNbr"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(767, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(338, 22)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "3 - Select a Report"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(348, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(410, 22)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "2 - On-Board Officers on Selected Vessel"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OnBoardCrewGrid
        '
        Me.OnBoardCrewGrid.Location = New System.Drawing.Point(348, 85)
        Me.OnBoardCrewGrid.MainView = Me.OnBoardCrewView
        Me.OnBoardCrewGrid.Name = "OnBoardCrewGrid"
        Me.OnBoardCrewGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepFullName})
        Me.OnBoardCrewGrid.Size = New System.Drawing.Size(410, 374)
        Me.OnBoardCrewGrid.TabIndex = 6
        Me.OnBoardCrewGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.OnBoardCrewView})
        '
        'OnBoardCrewView
        '
        Me.OnBoardCrewView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.OnBoardCrewView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.OnBoardCrewView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView.Appearance.Row.Options.UseTextOptions = True
        Me.OnBoardCrewView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.OnBoardCrewView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.OnBoardCrewView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.OnBoardCrewView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.OnBoardCrewView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmCrewPKey, Me.glcmIDNbr, Me.glcmCrewFullName, Me.glcmCrewRank})
        Me.OnBoardCrewView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.OnBoardCrewView.GridControl = Me.OnBoardCrewGrid
        Me.OnBoardCrewView.Name = "OnBoardCrewView"
        Me.OnBoardCrewView.NewItemRowText = "Add New Rank Here"
        Me.OnBoardCrewView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.OnBoardCrewView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.OnBoardCrewView.OptionsBehavior.AutoPopulateColumns = False
        Me.OnBoardCrewView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.OnBoardCrewView.OptionsCustomization.AllowFilter = False
        Me.OnBoardCrewView.OptionsCustomization.AllowGroup = False
        Me.OnBoardCrewView.OptionsCustomization.AllowQuickHideColumns = False
        Me.OnBoardCrewView.OptionsDetail.EnableMasterViewMode = False
        Me.OnBoardCrewView.OptionsFilter.AllowFilterEditor = False
        Me.OnBoardCrewView.OptionsFind.AllowFindPanel = False
        Me.OnBoardCrewView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.OnBoardCrewView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.OnBoardCrewView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.OnBoardCrewView.OptionsSelection.UseIndicatorForSelection = False
        Me.OnBoardCrewView.OptionsView.ShowGroupPanel = False
        '
        'glcmCrewPKey
        '
        Me.glcmCrewPKey.FieldName = "PKey"
        Me.glcmCrewPKey.Name = "glcmCrewPKey"
        '
        'glcmIDNbr
        '
        Me.glcmIDNbr.Caption = "IDNbr"
        Me.glcmIDNbr.FieldName = "IDNbr"
        Me.glcmIDNbr.Name = "glcmIDNbr"
        Me.glcmIDNbr.Width = 114
        '
        'glcmCrewFullName
        '
        Me.glcmCrewFullName.Caption = "Crew Name"
        Me.glcmCrewFullName.FieldName = "FullName"
        Me.glcmCrewFullName.Name = "glcmCrewFullName"
        Me.glcmCrewFullName.OptionsColumn.AllowEdit = False
        Me.glcmCrewFullName.Visible = True
        Me.glcmCrewFullName.VisibleIndex = 0
        Me.glcmCrewFullName.Width = 107
        '
        'glcmCrewRank
        '
        Me.glcmCrewRank.Caption = "Rank"
        Me.glcmCrewRank.FieldName = "RankName"
        Me.glcmCrewRank.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.glcmCrewRank.Name = "glcmCrewRank"
        Me.glcmCrewRank.OptionsColumn.AllowEdit = False
        Me.glcmCrewRank.Visible = True
        Me.glcmCrewRank.VisibleIndex = 1
        '
        'RepFullName
        '
        Me.RepFullName.AutoHeight = False
        Me.RepFullName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepFullName.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepFullName.DisplayMember = "FullName"
        Me.RepFullName.DropDownRows = 10
        Me.RepFullName.Name = "RepFullName"
        Me.RepFullName.ShowFooter = False
        Me.RepFullName.ShowHeader = False
        Me.RepFullName.ValueMember = "FKeyIDNbr"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(302, 22)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "1 - Select a Vessel"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VesselGrid
        '
        Me.VesselGrid.Location = New System.Drawing.Point(37, 85)
        Me.VesselGrid.MainView = Me.VesselView
        Me.VesselGrid.Name = "VesselGrid"
        Me.VesselGrid.Size = New System.Drawing.Size(302, 374)
        Me.VesselGrid.TabIndex = 4
        Me.VesselGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.VesselView})
        '
        'VesselView
        '
        Me.VesselView.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
        Me.VesselView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.VesselView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VesselView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.VesselView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VesselView.Appearance.Row.Options.UseTextOptions = True
        Me.VesselView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VesselView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.VesselView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.VesselView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.VesselView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VesselView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.VesselView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.VesselView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.glcmVesselName, Me.glcmVslSortCode})
        Me.VesselView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.VesselView.GridControl = Me.VesselGrid
        Me.VesselView.Name = "VesselView"
        Me.VesselView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.VesselView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.VesselView.OptionsBehavior.AutoPopulateColumns = False
        Me.VesselView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.VesselView.OptionsBehavior.Editable = False
        Me.VesselView.OptionsCustomization.AllowFilter = False
        Me.VesselView.OptionsCustomization.AllowGroup = False
        Me.VesselView.OptionsCustomization.AllowQuickHideColumns = False
        Me.VesselView.OptionsDetail.EnableMasterViewMode = False
        Me.VesselView.OptionsFilter.AllowFilterEditor = False
        Me.VesselView.OptionsFind.AlwaysVisible = True
        Me.VesselView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.VesselView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.VesselView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.VesselView.OptionsSelection.UseIndicatorForSelection = False
        Me.VesselView.OptionsView.ColumnAutoWidth = True
        Me.VesselView.OptionsView.ShowBands = False
        Me.VesselView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.VesselView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Columns.Add(Me.glcmVesselName)
        Me.GridBand1.Columns.Add(Me.colPKey)
        Me.GridBand1.Columns.Add(Me.glcmVslSortCode)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 284
        '
        'glcmVesselName
        '
        Me.glcmVesselName.Caption = "Vessel Name"
        Me.glcmVesselName.FieldName = "Name"
        Me.glcmVesselName.Name = "glcmVesselName"
        Me.glcmVesselName.Visible = True
        Me.glcmVesselName.Width = 124
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'glcmVslSortCode
        '
        Me.glcmVslSortCode.Caption = "Vessel Type"
        Me.glcmVslSortCode.FieldName = "VslType"
        Me.glcmVslSortCode.Name = "glcmVslSortCode"
        Me.glcmVslSortCode.Visible = True
        Me.glcmVslSortCode.Width = 160
        '
        'cmbVesselName
        '
        Me.cmbVesselName.Location = New System.Drawing.Point(100, 85)
        Me.cmbVesselName.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.cmbVesselName.Name = "cmbVesselName"
        Me.cmbVesselName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.cmbVesselName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbVesselName.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cmbVesselName.Properties.DisplayMember = "Name"
        Me.cmbVesselName.Properties.DropDownRows = 10
        Me.cmbVesselName.Properties.NullText = ""
        Me.cmbVesselName.Properties.ShowFooter = False
        Me.cmbVesselName.Properties.ShowHeader = False
        Me.cmbVesselName.Properties.ValueMember = "PKey"
        Me.cmbVesselName.Size = New System.Drawing.Size(156, 20)
        Me.cmbVesselName.StyleController = Me.LayoutControl1
        Me.cmbVesselName.TabIndex = 41
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup8})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1142, 496)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup8
        '
        Me.LayoutControlGroup8.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup8.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup8.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.tbgcPrintingModes})
        Me.LayoutControlGroup8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup8.Name = "LayoutControlGroup8"
        Me.LayoutControlGroup8.Size = New System.Drawing.Size(1102, 456)
        Me.LayoutControlGroup8.Text = "Documents"
        Me.LayoutControlGroup8.TextVisible = False
        '
        'tbgcPrintingModes
        '
        Me.tbgcPrintingModes.Location = New System.Drawing.Point(0, 0)
        Me.tbgcPrintingModes.Name = "tbgcPrintingModes"
        Me.tbgcPrintingModes.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.tbgcPrintingModes.SelectedTabPage = Me.LayoutControlGroup6
        Me.tbgcPrintingModes.SelectedTabPageIndex = 2
        Me.tbgcPrintingModes.Size = New System.Drawing.Size(1078, 432)
        Me.tbgcPrintingModes.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3, Me.LayoutControlGroup2, Me.LayoutControlGroup6})
        Me.tbgcPrintingModes.Text = "Vessel Type"
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.SplitterItem1, Me.SplitterItem2})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1072, 404)
        Me.LayoutControlGroup3.Text = "Crew On Board"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.VesselGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(306, 378)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Label1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(306, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.OnBoardCrewGrid
        Me.LayoutControlItem3.Location = New System.Drawing.Point(311, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(414, 378)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Label2
        Me.LayoutControlItem4.Location = New System.Drawing.Point(311, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(414, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.Label3
        Me.LayoutControlItem5.Location = New System.Drawing.Point(730, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(342, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.ReportGrid
        Me.LayoutControlItem6.Location = New System.Drawing.Point(730, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(342, 378)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(306, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 404)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(725, 0)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(5, 404)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem39, Me.LayoutControlItem42, Me.LayoutControlItem45, Me.LayoutControlItem37, Me.LayoutControlItem11, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem17, Me.SplitterItem3, Me.SplitterItem4, Me.SplitterItem5, Me.LayoutControlItem12})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1072, 404)
        Me.LayoutControlGroup2.Text = "All Crew"
        '
        'LayoutControlItem39
        '
        Me.LayoutControlItem39.Control = Me.OnBoardCrewGrid2
        Me.LayoutControlItem39.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem39.Name = "LayoutControlItem39"
        Me.LayoutControlItem39.Size = New System.Drawing.Size(281, 352)
        Me.LayoutControlItem39.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem39.TextVisible = False
        '
        'LayoutControlItem42
        '
        Me.LayoutControlItem42.Control = Me.SelectedCrewGrid
        Me.LayoutControlItem42.Location = New System.Drawing.Point(286, 26)
        Me.LayoutControlItem42.Name = "LayoutControlItem42"
        Me.LayoutControlItem42.Size = New System.Drawing.Size(261, 378)
        Me.LayoutControlItem42.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem42.TextVisible = False
        '
        'LayoutControlItem45
        '
        Me.LayoutControlItem45.Control = Me.ReportGrid2
        Me.LayoutControlItem45.Location = New System.Drawing.Point(829, 26)
        Me.LayoutControlItem45.Name = "LayoutControlItem45"
        Me.LayoutControlItem45.Size = New System.Drawing.Size(243, 378)
        Me.LayoutControlItem45.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem45.TextVisible = False
        '
        'LayoutControlItem37
        '
        Me.LayoutControlItem37.Control = Me.cmbVesselName
        Me.LayoutControlItem37.CustomizationFormText = "Vessel Name"
        Me.LayoutControlItem37.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem37.Name = "LayoutControlItem37"
        Me.LayoutControlItem37.Size = New System.Drawing.Size(223, 26)
        Me.LayoutControlItem37.Text = "Vessel Name"
        Me.LayoutControlItem37.TextSize = New System.Drawing.Size(60, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.btnVessels
        Me.LayoutControlItem11.Location = New System.Drawing.Point(223, 26)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(58, 26)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.Label7
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(281, 26)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.Label8
        Me.LayoutControlItem15.Location = New System.Drawing.Point(286, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.Label19
        Me.LayoutControlItem16.Location = New System.Drawing.Point(552, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(272, 26)
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextVisible = False
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.Label20
        Me.LayoutControlItem17.Location = New System.Drawing.Point(829, 0)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(243, 26)
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextVisible = False
        '
        'SplitterItem3
        '
        Me.SplitterItem3.AllowHotTrack = True
        Me.SplitterItem3.Location = New System.Drawing.Point(281, 0)
        Me.SplitterItem3.Name = "SplitterItem3"
        Me.SplitterItem3.Size = New System.Drawing.Size(5, 404)
        '
        'SplitterItem4
        '
        Me.SplitterItem4.AllowHotTrack = True
        Me.SplitterItem4.Location = New System.Drawing.Point(547, 0)
        Me.SplitterItem4.Name = "SplitterItem4"
        Me.SplitterItem4.Size = New System.Drawing.Size(5, 404)
        '
        'SplitterItem5
        '
        Me.SplitterItem5.AllowHotTrack = True
        Me.SplitterItem5.Location = New System.Drawing.Point(824, 0)
        Me.SplitterItem5.Name = "SplitterItem5"
        Me.SplitterItem5.Size = New System.Drawing.Size(5, 404)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.CrewAshoreCrew
        Me.LayoutControlItem12.Location = New System.Drawing.Point(552, 26)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(272, 378)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(1072, 404)
        Me.LayoutControlGroup6.Text = "Document Mapping"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.CertCourseGrid
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(1072, 378)
        Me.LayoutControlItem8.Text = "1 - Select a Vessel"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.Label4
        Me.LayoutControlItem7.Location = New System.Drawing.Point(329, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(382, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.Label5
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(329, 26)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.Label6
        Me.LayoutControlItem10.Location = New System.Drawing.Point(711, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(361, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'GridControl4
        '
        Me.GridControl4.Location = New System.Drawing.Point(37, 83)
        Me.GridControl4.MainView = Me.AdvBandedGridView2
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.Size = New System.Drawing.Size(374, 134)
        Me.GridControl4.TabIndex = 10
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView2})
        '
        'AdvBandedGridView2
        '
        Me.AdvBandedGridView2.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
        Me.AdvBandedGridView2.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.AdvBandedGridView2.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView2.Appearance.GroupRow.Options.UseTextOptions = True
        Me.AdvBandedGridView2.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView2.Appearance.Row.Options.UseTextOptions = True
        Me.AdvBandedGridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AdvBandedGridView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.AdvBandedGridView2.AppearancePrint.Row.Options.UseTextOptions = True
        Me.AdvBandedGridView2.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView2.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.AdvBandedGridView2.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand3})
        Me.AdvBandedGridView2.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn7, Me.BandedGridColumn6, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn10})
        Me.AdvBandedGridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.AdvBandedGridView2.GridControl = Me.GridControl4
        Me.AdvBandedGridView2.Name = "AdvBandedGridView2"
        Me.AdvBandedGridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView2.OptionsBehavior.AutoPopulateColumns = False
        Me.AdvBandedGridView2.OptionsBehavior.AutoSelectAllInEditor = False
        Me.AdvBandedGridView2.OptionsBehavior.Editable = False
        Me.AdvBandedGridView2.OptionsCustomization.AllowFilter = False
        Me.AdvBandedGridView2.OptionsCustomization.AllowGroup = False
        Me.AdvBandedGridView2.OptionsCustomization.AllowQuickHideColumns = False
        Me.AdvBandedGridView2.OptionsDetail.EnableMasterViewMode = False
        Me.AdvBandedGridView2.OptionsFilter.AllowFilterEditor = False
        Me.AdvBandedGridView2.OptionsFind.AlwaysVisible = True
        Me.AdvBandedGridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.AdvBandedGridView2.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.AdvBandedGridView2.OptionsSelection.EnableAppearanceHideSelection = False
        Me.AdvBandedGridView2.OptionsSelection.UseIndicatorForSelection = False
        Me.AdvBandedGridView2.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView2.OptionsView.ShowBands = False
        Me.AdvBandedGridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.AdvBandedGridView2.OptionsView.ShowGroupPanel = False
        '
        'GridBand3
        '
        Me.GridBand3.Caption = "GridBand1"
        Me.GridBand3.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn9)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn10)
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.VisibleIndex = 0
        Me.GridBand3.Width = 240
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Vessel Name"
        Me.BandedGridColumn6.FieldName = "Name"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 162
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.FieldName = "PKey"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.FieldName = "SortCode"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 78
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.FieldName = "DateUpdated"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.FieldName = "LastUpdatedBy"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        '
        'GridControl5
        '
        Me.GridControl5.Location = New System.Drawing.Point(415, 245)
        Me.GridControl5.MainView = Me.GridView3
        Me.GridControl5.Name = "GridControl5"
        Me.GridControl5.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit5, Me.RepositoryItemLookUpEdit6})
        Me.GridControl5.Size = New System.Drawing.Size(389, 214)
        Me.GridControl5.TabIndex = 17
        Me.GridControl5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView3.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView3.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView3.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView3.Appearance.Row.Options.UseTextOptions = True
        Me.GridView3.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView3.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView3.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView3.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView3.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView3.GridControl = Me.GridControl5
        Me.GridView3.Name = "GridView3"
        Me.GridView3.NewItemRowText = "Add New Rank Here"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView3.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView3.OptionsCustomization.AllowFilter = False
        Me.GridView3.OptionsCustomization.AllowGroup = False
        Me.GridView3.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView3.OptionsDetail.EnableMasterViewMode = False
        Me.GridView3.OptionsFilter.AllowFilterEditor = False
        Me.GridView3.OptionsFind.AllowFindPanel = False
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView3.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView3.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.FieldName = "PKey"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "FKeyComp"
        Me.GridColumn13.FieldName = "FKeyComp"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Width = 114
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Full Name"
        Me.GridColumn14.ColumnEdit = Me.RepositoryItemLookUpEdit5
        Me.GridColumn14.FieldName = "FKeyRank"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 107
        '
        'RepositoryItemLookUpEdit5
        '
        Me.RepositoryItemLookUpEdit5.AutoHeight = False
        Me.RepositoryItemLookUpEdit5.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit5.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit5.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit5.DropDownRows = 10
        Me.RepositoryItemLookUpEdit5.Name = "RepositoryItemLookUpEdit5"
        Me.RepositoryItemLookUpEdit5.ShowFooter = False
        Me.RepositoryItemLookUpEdit5.ShowHeader = False
        Me.RepositoryItemLookUpEdit5.ValueMember = "PKey"
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Edited"
        Me.GridColumn15.FieldName = "Edited"
        Me.GridColumn15.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Rank"
        Me.GridColumn16.FieldName = "IsDelete"
        Me.GridColumn16.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.ToolTip = "Tick rank that you want to remove."
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 1
        Me.GridColumn16.Width = 58
        '
        'RepositoryItemLookUpEdit6
        '
        Me.RepositoryItemLookUpEdit6.AutoHeight = False
        Me.RepositoryItemLookUpEdit6.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit6.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit6.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit6.DropDownRows = 10
        Me.RepositoryItemLookUpEdit6.Name = "RepositoryItemLookUpEdit6"
        Me.RepositoryItemLookUpEdit6.ShowFooter = False
        Me.RepositoryItemLookUpEdit6.ShowHeader = False
        Me.RepositoryItemLookUpEdit6.ValueMember = "PKey"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(415, 221)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(389, 20)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "4 - Selected for Inclusion in Report"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(37, 221)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(374, 20)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "3 - List of Officers"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(374, 20)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "1 - Select a Vessel"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(415, 83)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Size = New System.Drawing.Size(19, 19)
        Me.CheckEdit1.TabIndex = 23
        '
        'RadioGroup3
        '
        Me.RadioGroup3.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.RadioGroup3.Location = New System.Drawing.Point(808, 83)
        Me.RadioGroup3.Name = "RadioGroup3"
        Me.RadioGroup3.Properties.Columns = 2
        Me.RadioGroup3.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 1"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 2"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 3"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Shell"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Chevron && Total"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Conoco Philips"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Koch")})
        Me.RadioGroup3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioGroup3.Size = New System.Drawing.Size(297, 376)
        Me.RadioGroup3.TabIndex = 18
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Location = New System.Drawing.Point(439, 109)
        Me.DropDownButton3.Name = "DropDownButton3"
        Me.DropDownButton3.Size = New System.Drawing.Size(365, 22)
        Me.DropDownButton3.TabIndex = 15
        Me.DropDownButton3.Text = "Rank Name"
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Location = New System.Drawing.Point(438, 83)
        Me.DropDownButton4.Name = "DropDownButton4"
        Me.DropDownButton4.Size = New System.Drawing.Size(366, 22)
        Me.DropDownButton4.TabIndex = 14
        Me.DropDownButton4.Text = "Vessel Name"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(415, 109)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(20, 20)
        Me.CheckBox1.TabIndex = 24
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GridControl6
        '
        Me.GridControl6.Location = New System.Drawing.Point(37, 245)
        Me.GridControl6.MainView = Me.GridView4
        Me.GridControl6.Name = "GridControl6"
        Me.GridControl6.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit7, Me.RepositoryItemLookUpEdit8})
        Me.GridControl6.Size = New System.Drawing.Size(374, 214)
        Me.GridControl6.TabIndex = 16
        Me.GridControl6.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView4.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView4.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView4.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView4.Appearance.Row.Options.UseTextOptions = True
        Me.GridView4.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView4.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView4.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView4.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView4.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView4.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView4.GridControl = Me.GridControl6
        Me.GridView4.Name = "GridView4"
        Me.GridView4.NewItemRowText = "Add New Rank Here"
        Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView4.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView4.OptionsCustomization.AllowFilter = False
        Me.GridView4.OptionsCustomization.AllowGroup = False
        Me.GridView4.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView4.OptionsDetail.EnableMasterViewMode = False
        Me.GridView4.OptionsFilter.AllowFilterEditor = False
        Me.GridView4.OptionsFind.AllowFindPanel = False
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView4.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView4.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn17
        '
        Me.GridColumn17.FieldName = "PKey"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "FKeyComp"
        Me.GridColumn18.FieldName = "FKeyComp"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Width = 114
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Full Name"
        Me.GridColumn19.ColumnEdit = Me.RepositoryItemLookUpEdit7
        Me.GridColumn19.FieldName = "FKeyRank"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        Me.GridColumn19.Width = 107
        '
        'RepositoryItemLookUpEdit7
        '
        Me.RepositoryItemLookUpEdit7.AutoHeight = False
        Me.RepositoryItemLookUpEdit7.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit7.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit7.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit7.DropDownRows = 10
        Me.RepositoryItemLookUpEdit7.Name = "RepositoryItemLookUpEdit7"
        Me.RepositoryItemLookUpEdit7.ShowFooter = False
        Me.RepositoryItemLookUpEdit7.ShowHeader = False
        Me.RepositoryItemLookUpEdit7.ValueMember = "PKey"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Edited"
        Me.GridColumn20.FieldName = "Edited"
        Me.GridColumn20.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Rank"
        Me.GridColumn21.FieldName = "IsDelete"
        Me.GridColumn21.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.ToolTip = "Tick rank that you want to remove."
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 1
        Me.GridColumn21.Width = 58
        '
        'RepositoryItemLookUpEdit8
        '
        Me.RepositoryItemLookUpEdit8.AutoHeight = False
        Me.RepositoryItemLookUpEdit8.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit8.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit8.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit8.DropDownRows = 10
        Me.RepositoryItemLookUpEdit8.Name = "RepositoryItemLookUpEdit8"
        Me.RepositoryItemLookUpEdit8.ShowFooter = False
        Me.RepositoryItemLookUpEdit8.ShowHeader = False
        Me.RepositoryItemLookUpEdit8.ValueMember = "PKey"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(808, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(297, 20)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "5- Select a Report"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(415, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(389, 20)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "2 - Filter"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridControl7
        '
        Me.GridControl7.Location = New System.Drawing.Point(37, 83)
        Me.GridControl7.MainView = Me.AdvBandedGridView3
        Me.GridControl7.Name = "GridControl7"
        Me.GridControl7.Size = New System.Drawing.Size(374, 134)
        Me.GridControl7.TabIndex = 10
        Me.GridControl7.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView3})
        '
        'AdvBandedGridView3
        '
        Me.AdvBandedGridView3.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
        Me.AdvBandedGridView3.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.AdvBandedGridView3.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView3.Appearance.GroupRow.Options.UseTextOptions = True
        Me.AdvBandedGridView3.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView3.Appearance.Row.Options.UseTextOptions = True
        Me.AdvBandedGridView3.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AdvBandedGridView3.Appearance.RowSeparator.Options.UseBackColor = True
        Me.AdvBandedGridView3.AppearancePrint.Row.Options.UseTextOptions = True
        Me.AdvBandedGridView3.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView3.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.AdvBandedGridView3.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand4})
        Me.AdvBandedGridView3.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn12, Me.BandedGridColumn11, Me.BandedGridColumn13, Me.BandedGridColumn14, Me.BandedGridColumn15})
        Me.AdvBandedGridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.AdvBandedGridView3.GridControl = Me.GridControl7
        Me.AdvBandedGridView3.Name = "AdvBandedGridView3"
        Me.AdvBandedGridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView3.OptionsBehavior.AutoPopulateColumns = False
        Me.AdvBandedGridView3.OptionsBehavior.AutoSelectAllInEditor = False
        Me.AdvBandedGridView3.OptionsBehavior.Editable = False
        Me.AdvBandedGridView3.OptionsCustomization.AllowFilter = False
        Me.AdvBandedGridView3.OptionsCustomization.AllowGroup = False
        Me.AdvBandedGridView3.OptionsCustomization.AllowQuickHideColumns = False
        Me.AdvBandedGridView3.OptionsDetail.EnableMasterViewMode = False
        Me.AdvBandedGridView3.OptionsFilter.AllowFilterEditor = False
        Me.AdvBandedGridView3.OptionsFind.AlwaysVisible = True
        Me.AdvBandedGridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.AdvBandedGridView3.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.AdvBandedGridView3.OptionsSelection.EnableAppearanceHideSelection = False
        Me.AdvBandedGridView3.OptionsSelection.UseIndicatorForSelection = False
        Me.AdvBandedGridView3.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView3.OptionsView.ShowBands = False
        Me.AdvBandedGridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.AdvBandedGridView3.OptionsView.ShowGroupPanel = False
        '
        'GridBand4
        '
        Me.GridBand4.Caption = "GridBand1"
        Me.GridBand4.Columns.Add(Me.BandedGridColumn11)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn12)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn13)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn14)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn15)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 0
        Me.GridBand4.Width = 240
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Vessel Name"
        Me.BandedGridColumn11.FieldName = "Name"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.Visible = True
        Me.BandedGridColumn11.Width = 162
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.FieldName = "PKey"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.FieldName = "SortCode"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.Visible = True
        Me.BandedGridColumn13.Width = 78
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.FieldName = "DateUpdated"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.FieldName = "LastUpdatedBy"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        '
        'GridControl8
        '
        Me.GridControl8.Location = New System.Drawing.Point(415, 245)
        Me.GridControl8.MainView = Me.GridView5
        Me.GridControl8.Name = "GridControl8"
        Me.GridControl8.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit9, Me.RepositoryItemLookUpEdit10})
        Me.GridControl8.Size = New System.Drawing.Size(389, 214)
        Me.GridControl8.TabIndex = 17
        Me.GridControl8.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView5.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView5.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView5.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView5.Appearance.Row.Options.UseTextOptions = True
        Me.GridView5.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView5.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView5.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView5.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView5.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView5.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26})
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView5.GridControl = Me.GridControl8
        Me.GridView5.Name = "GridView5"
        Me.GridView5.NewItemRowText = "Add New Rank Here"
        Me.GridView5.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView5.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView5.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView5.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView5.OptionsCustomization.AllowFilter = False
        Me.GridView5.OptionsCustomization.AllowGroup = False
        Me.GridView5.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView5.OptionsDetail.EnableMasterViewMode = False
        Me.GridView5.OptionsFilter.AllowFilterEditor = False
        Me.GridView5.OptionsFind.AllowFindPanel = False
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView5.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView5.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GridColumn22
        '
        Me.GridColumn22.FieldName = "PKey"
        Me.GridColumn22.Name = "GridColumn22"
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "FKeyComp"
        Me.GridColumn23.FieldName = "FKeyComp"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Width = 114
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Full Name"
        Me.GridColumn24.ColumnEdit = Me.RepositoryItemLookUpEdit9
        Me.GridColumn24.FieldName = "FKeyRank"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 0
        Me.GridColumn24.Width = 107
        '
        'RepositoryItemLookUpEdit9
        '
        Me.RepositoryItemLookUpEdit9.AutoHeight = False
        Me.RepositoryItemLookUpEdit9.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit9.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit9.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit9.DropDownRows = 10
        Me.RepositoryItemLookUpEdit9.Name = "RepositoryItemLookUpEdit9"
        Me.RepositoryItemLookUpEdit9.ShowFooter = False
        Me.RepositoryItemLookUpEdit9.ShowHeader = False
        Me.RepositoryItemLookUpEdit9.ValueMember = "PKey"
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Edited"
        Me.GridColumn25.FieldName = "Edited"
        Me.GridColumn25.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn25.Name = "GridColumn25"
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Rank"
        Me.GridColumn26.FieldName = "IsDelete"
        Me.GridColumn26.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.ToolTip = "Tick rank that you want to remove."
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 1
        Me.GridColumn26.Width = 58
        '
        'RepositoryItemLookUpEdit10
        '
        Me.RepositoryItemLookUpEdit10.AutoHeight = False
        Me.RepositoryItemLookUpEdit10.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit10.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit10.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit10.DropDownRows = 10
        Me.RepositoryItemLookUpEdit10.Name = "RepositoryItemLookUpEdit10"
        Me.RepositoryItemLookUpEdit10.ShowFooter = False
        Me.RepositoryItemLookUpEdit10.ShowHeader = False
        Me.RepositoryItemLookUpEdit10.ValueMember = "PKey"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(415, 221)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(389, 20)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "4 - Selected for Inclusion in Report"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(37, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(374, 20)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "3 - List of Officers"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(37, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(374, 20)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "1 - Select a Vessel"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckEdit2
        '
        Me.CheckEdit2.Location = New System.Drawing.Point(415, 83)
        Me.CheckEdit2.Name = "CheckEdit2"
        Me.CheckEdit2.Size = New System.Drawing.Size(19, 19)
        Me.CheckEdit2.TabIndex = 23
        '
        'RadioGroup4
        '
        Me.RadioGroup4.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.RadioGroup4.Location = New System.Drawing.Point(808, 83)
        Me.RadioGroup4.Name = "RadioGroup4"
        Me.RadioGroup4.Properties.Columns = 2
        Me.RadioGroup4.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 1"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 2"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 3"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Shell"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Chevron && Total"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Conoco Philips"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Koch")})
        Me.RadioGroup4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioGroup4.Size = New System.Drawing.Size(297, 376)
        Me.RadioGroup4.TabIndex = 18
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Location = New System.Drawing.Point(439, 109)
        Me.DropDownButton5.Name = "DropDownButton5"
        Me.DropDownButton5.Size = New System.Drawing.Size(365, 22)
        Me.DropDownButton5.TabIndex = 15
        Me.DropDownButton5.Text = "Rank Name"
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Location = New System.Drawing.Point(438, 83)
        Me.DropDownButton6.Name = "DropDownButton6"
        Me.DropDownButton6.Size = New System.Drawing.Size(366, 22)
        Me.DropDownButton6.TabIndex = 14
        Me.DropDownButton6.Text = "Vessel Name"
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(415, 109)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(20, 20)
        Me.CheckBox2.TabIndex = 24
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'GridControl9
        '
        Me.GridControl9.Location = New System.Drawing.Point(37, 245)
        Me.GridControl9.MainView = Me.GridView6
        Me.GridControl9.Name = "GridControl9"
        Me.GridControl9.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit11, Me.RepositoryItemLookUpEdit12})
        Me.GridControl9.Size = New System.Drawing.Size(374, 214)
        Me.GridControl9.TabIndex = 16
        Me.GridControl9.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6})
        '
        'GridView6
        '
        Me.GridView6.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView6.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView6.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView6.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView6.Appearance.Row.Options.UseTextOptions = True
        Me.GridView6.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView6.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView6.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView6.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView6.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView6.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31})
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView6.GridControl = Me.GridControl9
        Me.GridView6.Name = "GridView6"
        Me.GridView6.NewItemRowText = "Add New Rank Here"
        Me.GridView6.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView6.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView6.OptionsCustomization.AllowFilter = False
        Me.GridView6.OptionsCustomization.AllowGroup = False
        Me.GridView6.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView6.OptionsDetail.EnableMasterViewMode = False
        Me.GridView6.OptionsFilter.AllowFilterEditor = False
        Me.GridView6.OptionsFind.AllowFindPanel = False
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView6.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView6.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn27
        '
        Me.GridColumn27.FieldName = "PKey"
        Me.GridColumn27.Name = "GridColumn27"
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "FKeyComp"
        Me.GridColumn28.FieldName = "FKeyComp"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Width = 114
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Full Name"
        Me.GridColumn29.ColumnEdit = Me.RepositoryItemLookUpEdit11
        Me.GridColumn29.FieldName = "FKeyRank"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        Me.GridColumn29.Width = 107
        '
        'RepositoryItemLookUpEdit11
        '
        Me.RepositoryItemLookUpEdit11.AutoHeight = False
        Me.RepositoryItemLookUpEdit11.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit11.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit11.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit11.DropDownRows = 10
        Me.RepositoryItemLookUpEdit11.Name = "RepositoryItemLookUpEdit11"
        Me.RepositoryItemLookUpEdit11.ShowFooter = False
        Me.RepositoryItemLookUpEdit11.ShowHeader = False
        Me.RepositoryItemLookUpEdit11.ValueMember = "PKey"
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Edited"
        Me.GridColumn30.FieldName = "Edited"
        Me.GridColumn30.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn30.Name = "GridColumn30"
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Rank"
        Me.GridColumn31.FieldName = "IsDelete"
        Me.GridColumn31.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.ToolTip = "Tick rank that you want to remove."
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 1
        Me.GridColumn31.Width = 58
        '
        'RepositoryItemLookUpEdit12
        '
        Me.RepositoryItemLookUpEdit12.AutoHeight = False
        Me.RepositoryItemLookUpEdit12.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit12.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit12.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit12.DropDownRows = 10
        Me.RepositoryItemLookUpEdit12.Name = "RepositoryItemLookUpEdit12"
        Me.RepositoryItemLookUpEdit12.ShowFooter = False
        Me.RepositoryItemLookUpEdit12.ShowHeader = False
        Me.RepositoryItemLookUpEdit12.ValueMember = "PKey"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(808, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(297, 20)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "5- Select a Report"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(415, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(389, 20)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "2 - Filter"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox3
        '
        Me.CheckBox3.Location = New System.Drawing.Point(415, 113)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(20, 20)
        Me.CheckBox3.TabIndex = 24
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Location = New System.Drawing.Point(438, 87)
        Me.DropDownButton7.Name = "DropDownButton7"
        Me.DropDownButton7.Size = New System.Drawing.Size(366, 22)
        Me.DropDownButton7.TabIndex = 14
        Me.DropDownButton7.Text = "Vessel Name"
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Location = New System.Drawing.Point(439, 113)
        Me.DropDownButton8.Name = "DropDownButton8"
        Me.DropDownButton8.Size = New System.Drawing.Size(365, 22)
        Me.DropDownButton8.TabIndex = 15
        Me.DropDownButton8.Text = "Rank Name"
        '
        'CheckEdit3
        '
        Me.CheckEdit3.Location = New System.Drawing.Point(415, 87)
        Me.CheckEdit3.Name = "CheckEdit3"
        Me.CheckEdit3.Size = New System.Drawing.Size(19, 19)
        Me.CheckEdit3.TabIndex = 23
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(269, 85)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Padding = New System.Windows.Forms.Padding(2)
        Me.SimpleButton1.Size = New System.Drawing.Size(36, 22)
        Me.SimpleButton1.TabIndex = 61
        Me.SimpleButton1.Text = "Clear"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(309, 59)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(283, 46)
        Me.Label25.TabIndex = 48
        Me.Label25.Text = "Selected Crews"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QualificationMatrix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "QualificationMatrix"
        Me.Size = New System.Drawing.Size(1146, 520)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CrewAshoreCrew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewAshoreView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CertCourseGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CertCourseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepCertificates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepCourses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectedCrewGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectedCrewView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnBoardCrewGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnBoardCrewView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnBoardCrewGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnBoardCrewView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepFullName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VesselGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VesselView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbVesselName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbgcPrintingModes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup8 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents tbgcPrintingModes As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents VesselGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents VesselView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents glcmVesselName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents glcmVslSortCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OnBoardCrewGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents OnBoardCrewView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents glcmCrewPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmIDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCrewFullName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepFullName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents glcmCrewRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView2 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridControl5 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents RadioGroup3 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents DropDownButton3 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents DropDownButton4 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GridControl6 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GridControl7 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView3 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridControl8 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit9 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit10 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CheckEdit2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents RadioGroup4 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents DropDownButton5 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents DropDownButton6 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents GridControl9 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit11 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit12 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents DropDownButton7 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents DropDownButton8 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents CheckEdit3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ReportGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents glcmReportPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmReportName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmbVesselName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem37 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents OnBoardCrewGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents OnBoardCrewView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem39 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SelectedCrewGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents SelectedCrewView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit18 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem42 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ReportGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit20 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem45 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CertCourseGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CertCourseView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents glcmCoursesCertificates As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents glcmQualificationMatrixPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents glcmCertificates As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents glcmCourses As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepCourses As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepCertificates As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepNew As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents glcmEdited As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents btnVessels As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem3 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem4 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem5 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents CrewAshoreCrew As DevExpress.XtraGrid.GridControl
    Friend WithEvents CrewAshoreView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents glcmFullName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents glcmRankName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents glcmPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents glcmFKeyIDNbr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem

End Class
