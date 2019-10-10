<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopupPrintPOEAContract
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPopupPrintPOEAContract))
        Me.MainLayoutControl = New DevExpress.XtraLayout.LayoutControl()
        Me.txtPlace = New DevExpress.XtraEditors.TextEdit()
        Me.cboSignatory = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cboPort = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtStatus = New DevExpress.XtraEditors.TextEdit()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPrintContractAddendum = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintPOEAContract = New DevExpress.XtraEditors.CheckEdit()
        Me.txtDate = New DevExpress.XtraEditors.DateEdit()
        Me.cboPrincipal = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboVessel = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboAgent = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboWageScale = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtLOCDays = New DevExpress.XtraEditors.SpinEdit()
        Me.txtLOC = New DevExpress.XtraEditors.SpinEdit()
        Me.cboRank = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtCrewName = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup_Main = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcgVesselDetails = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciAgent = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPrincipal = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciVessel = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPort = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgPlaceDate = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciDate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPlace = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgSignatory = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciSignatory = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgCrewDetails = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciCrewName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciRank = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciLOC = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciWageScale = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciLOCDays = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lciStatus = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_SelectReport = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciPrintPOEAContract = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPrintContractAddendum = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPrintButton = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciCancelButton = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.MainLayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainLayoutControl.SuspendLayout()
        CType(Me.txtPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSignatory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintContractAddendum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintPOEAContract.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrincipal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboWageScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLOCDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLOC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCrewName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgVesselDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgPlaceDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPlace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgSignatory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciSignatory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgCrewDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciCrewName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciRank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciLOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciWageScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciLOCDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_SelectReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPrintPOEAContract, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPrintContractAddendum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPrintButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciCancelButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainLayoutControl
        '
        Me.MainLayoutControl.Controls.Add(Me.txtPlace)
        Me.MainLayoutControl.Controls.Add(Me.cboSignatory)
        Me.MainLayoutControl.Controls.Add(Me.cboPort)
        Me.MainLayoutControl.Controls.Add(Me.txtStatus)
        Me.MainLayoutControl.Controls.Add(Me.btnCancel)
        Me.MainLayoutControl.Controls.Add(Me.btnPrint)
        Me.MainLayoutControl.Controls.Add(Me.chkPrintContractAddendum)
        Me.MainLayoutControl.Controls.Add(Me.chkPrintPOEAContract)
        Me.MainLayoutControl.Controls.Add(Me.txtDate)
        Me.MainLayoutControl.Controls.Add(Me.cboPrincipal)
        Me.MainLayoutControl.Controls.Add(Me.cboVessel)
        Me.MainLayoutControl.Controls.Add(Me.cboAgent)
        Me.MainLayoutControl.Controls.Add(Me.cboWageScale)
        Me.MainLayoutControl.Controls.Add(Me.txtLOCDays)
        Me.MainLayoutControl.Controls.Add(Me.txtLOC)
        Me.MainLayoutControl.Controls.Add(Me.cboRank)
        Me.MainLayoutControl.Controls.Add(Me.txtCrewName)
        Me.MainLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainLayoutControl.Location = New System.Drawing.Point(0, 0)
        Me.MainLayoutControl.Name = "MainLayoutControl"
        Me.MainLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(605, 250, 250, 350)
        Me.MainLayoutControl.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.MainLayoutControl.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.MainLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.MainLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.MainLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.MainLayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MainLayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MainLayoutControl.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.MainLayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainLayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MainLayoutControl.Root = Me.LayoutControlGroup_Main
        Me.MainLayoutControl.Size = New System.Drawing.Size(573, 552)
        Me.MainLayoutControl.TabIndex = 0
        Me.MainLayoutControl.Text = "LayoutControl1"
        '
        'txtPlace
        '
        Me.txtPlace.Location = New System.Drawing.Point(145, 378)
        Me.txtPlace.Name = "txtPlace"
        Me.txtPlace.Size = New System.Drawing.Size(404, 22)
        Me.txtPlace.StyleController = Me.MainLayoutControl
        Me.txtPlace.TabIndex = 22
        '
        'cboSignatory
        '
        Me.cboSignatory.EditValue = ""
        Me.cboSignatory.Location = New System.Drawing.Point(145, 454)
        Me.cboSignatory.Name = "cboSignatory"
        Me.cboSignatory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSignatory.Properties.DisplayMember = "NameAndPosition"
        Me.cboSignatory.Properties.NullText = ""
        Me.cboSignatory.Properties.ValueMember = "PKey"
        Me.cboSignatory.Properties.View = Me.SearchLookUpEdit1View
        Me.cboSignatory.Size = New System.Drawing.Size(404, 22)
        Me.cboSignatory.StyleController = Me.MainLayoutControl
        Me.cboSignatory.TabIndex = 21
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'cboPort
        '
        Me.cboPort.Location = New System.Drawing.Point(145, 250)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPort.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboPort.Properties.DisplayMember = "Name"
        Me.cboPort.Properties.NullText = ""
        Me.cboPort.Properties.ShowHeader = False
        Me.cboPort.Properties.ValueMember = "PKey"
        Me.cboPort.Size = New System.Drawing.Size(404, 22)
        Me.cboPort.StyleController = Me.MainLayoutControl
        Me.cboPort.TabIndex = 20
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(145, 122)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(404, 22)
        Me.txtStatus.StyleController = Me.MainLayoutControl
        Me.txtStatus.TabIndex = 19
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(288, 502)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(273, 38)
        Me.btnCancel.StyleController = Me.MainLayoutControl
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        '
        'btnPrint
        '
        Me.btnPrint.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.Appearance.Options.UseFont = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(12, 502)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(272, 38)
        Me.btnPrint.StyleController = Me.MainLayoutControl
        Me.btnPrint.TabIndex = 16
        Me.btnPrint.Text = "Print"
        '
        'chkPrintContractAddendum
        '
        Me.chkPrintContractAddendum.Location = New System.Drawing.Point(288, 48)
        Me.chkPrintContractAddendum.Name = "chkPrintContractAddendum"
        Me.chkPrintContractAddendum.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.chkPrintContractAddendum.Properties.Appearance.Options.UseFont = True
        Me.chkPrintContractAddendum.Properties.Caption = "Contract Addendum"
        Me.chkPrintContractAddendum.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chkPrintContractAddendum.Properties.RadioGroupIndex = 1
        Me.chkPrintContractAddendum.Size = New System.Drawing.Size(261, 20)
        Me.chkPrintContractAddendum.StyleController = Me.MainLayoutControl
        Me.chkPrintContractAddendum.TabIndex = 15
        Me.chkPrintContractAddendum.TabStop = False
        '
        'chkPrintPOEAContract
        '
        Me.chkPrintPOEAContract.Location = New System.Drawing.Point(24, 48)
        Me.chkPrintPOEAContract.Name = "chkPrintPOEAContract"
        Me.chkPrintPOEAContract.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.chkPrintPOEAContract.Properties.Appearance.Options.UseFont = True
        Me.chkPrintPOEAContract.Properties.Caption = "POEA Contract"
        Me.chkPrintPOEAContract.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chkPrintPOEAContract.Properties.RadioGroupIndex = 1
        Me.chkPrintPOEAContract.Size = New System.Drawing.Size(260, 20)
        Me.chkPrintPOEAContract.StyleController = Me.MainLayoutControl
        Me.chkPrintPOEAContract.TabIndex = 14
        Me.chkPrintPOEAContract.TabStop = False
        '
        'txtDate
        '
        Me.txtDate.EditValue = Nothing
        Me.txtDate.Location = New System.Drawing.Point(145, 404)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDate.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.txtDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDate.Size = New System.Drawing.Size(404, 22)
        Me.txtDate.StyleController = Me.MainLayoutControl
        Me.txtDate.TabIndex = 12
        '
        'cboPrincipal
        '
        Me.cboPrincipal.Location = New System.Drawing.Point(145, 328)
        Me.cboPrincipal.Name = "cboPrincipal"
        Me.cboPrincipal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPrincipal.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboPrincipal.Properties.DisplayMember = "Name"
        Me.cboPrincipal.Properties.NullText = ""
        Me.cboPrincipal.Properties.ShowHeader = False
        Me.cboPrincipal.Properties.ValueMember = "PKey"
        Me.cboPrincipal.Size = New System.Drawing.Size(404, 22)
        Me.cboPrincipal.StyleController = Me.MainLayoutControl
        Me.cboPrincipal.TabIndex = 11
        '
        'cboVessel
        '
        Me.cboVessel.Location = New System.Drawing.Point(145, 302)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVessel.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboVessel.Properties.DisplayMember = "Name"
        Me.cboVessel.Properties.NullText = ""
        Me.cboVessel.Properties.ShowHeader = False
        Me.cboVessel.Properties.ValueMember = "PKey"
        Me.cboVessel.Size = New System.Drawing.Size(404, 22)
        Me.cboVessel.StyleController = Me.MainLayoutControl
        Me.cboVessel.TabIndex = 10
        '
        'cboAgent
        '
        Me.cboAgent.Location = New System.Drawing.Point(145, 276)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAgent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboAgent.Properties.DisplayMember = "Name"
        Me.cboAgent.Properties.NullText = ""
        Me.cboAgent.Properties.ShowHeader = False
        Me.cboAgent.Properties.ValueMember = "PKey"
        Me.cboAgent.Size = New System.Drawing.Size(404, 22)
        Me.cboAgent.StyleController = Me.MainLayoutControl
        Me.cboAgent.TabIndex = 9
        '
        'cboWageScale
        '
        Me.cboWageScale.Location = New System.Drawing.Point(145, 200)
        Me.cboWageScale.Name = "cboWageScale"
        Me.cboWageScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboWageScale.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboWageScale.Properties.DisplayMember = "Name"
        Me.cboWageScale.Properties.NullText = ""
        Me.cboWageScale.Properties.ShowHeader = False
        Me.cboWageScale.Properties.ValueMember = "PKey"
        Me.cboWageScale.Size = New System.Drawing.Size(404, 22)
        Me.cboWageScale.StyleController = Me.MainLayoutControl
        Me.cboWageScale.TabIndex = 8
        '
        'txtLOCDays
        '
        Me.txtLOCDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtLOCDays.Location = New System.Drawing.Point(409, 174)
        Me.txtLOCDays.Name = "txtLOCDays"
        Me.txtLOCDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtLOCDays.Properties.Mask.EditMask = "d"
        Me.txtLOCDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtLOCDays.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtLOCDays.Size = New System.Drawing.Size(140, 22)
        Me.txtLOCDays.StyleController = Me.MainLayoutControl
        Me.txtLOCDays.TabIndex = 7
        '
        'txtLOC
        '
        Me.txtLOC.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtLOC.Location = New System.Drawing.Point(145, 174)
        Me.txtLOC.Name = "txtLOC"
        Me.txtLOC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtLOC.Properties.Mask.EditMask = "d"
        Me.txtLOC.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtLOC.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtLOC.Size = New System.Drawing.Size(139, 22)
        Me.txtLOC.StyleController = Me.MainLayoutControl
        Me.txtLOC.TabIndex = 6
        '
        'cboRank
        '
        Me.cboRank.Location = New System.Drawing.Point(145, 148)
        Me.cboRank.Name = "cboRank"
        Me.cboRank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboRank.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboRank.Properties.DisplayMember = "Name"
        Me.cboRank.Properties.NullText = ""
        Me.cboRank.Properties.ShowHeader = False
        Me.cboRank.Properties.ValueMember = "PKey"
        Me.cboRank.Size = New System.Drawing.Size(223, 22)
        Me.cboRank.StyleController = Me.MainLayoutControl
        Me.cboRank.TabIndex = 5
        '
        'txtCrewName
        '
        Me.txtCrewName.Location = New System.Drawing.Point(145, 96)
        Me.txtCrewName.Name = "txtCrewName"
        Me.txtCrewName.Size = New System.Drawing.Size(404, 22)
        Me.txtCrewName.StyleController = Me.MainLayoutControl
        Me.txtCrewName.TabIndex = 4
        '
        'LayoutControlGroup_Main
        '
        Me.LayoutControlGroup_Main.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup_Main.GroupBordersVisible = False
        Me.LayoutControlGroup_Main.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgVesselDetails, Me.lcgPlaceDate, Me.lcgSignatory, Me.lcgCrewDetails, Me.LayoutControlGroup_SelectReport, Me.lciPrintButton, Me.lciCancelButton, Me.EmptySpaceItem2})
        Me.LayoutControlGroup_Main.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Main.Name = "LayoutControlGroup_Main"
        Me.LayoutControlGroup_Main.Size = New System.Drawing.Size(573, 552)
        Me.LayoutControlGroup_Main.TextVisible = False
        '
        'lcgVesselDetails
        '
        Me.lcgVesselDetails.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciAgent, Me.lciPrincipal, Me.lciVessel, Me.lciPort})
        Me.lcgVesselDetails.Location = New System.Drawing.Point(0, 226)
        Me.lcgVesselDetails.Name = "lcgVesselDetails"
        Me.lcgVesselDetails.Size = New System.Drawing.Size(553, 128)
        Me.lcgVesselDetails.TextVisible = False
        '
        'lciAgent
        '
        Me.lciAgent.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciAgent.AppearanceItemCaption.Options.UseFont = True
        Me.lciAgent.Control = Me.cboAgent
        Me.lciAgent.Location = New System.Drawing.Point(0, 26)
        Me.lciAgent.Name = "lciAgent"
        Me.lciAgent.Size = New System.Drawing.Size(529, 26)
        Me.lciAgent.Text = "Agent:"
        Me.lciAgent.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciPrincipal
        '
        Me.lciPrincipal.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciPrincipal.AppearanceItemCaption.Options.UseFont = True
        Me.lciPrincipal.Control = Me.cboPrincipal
        Me.lciPrincipal.Location = New System.Drawing.Point(0, 78)
        Me.lciPrincipal.Name = "lciPrincipal"
        Me.lciPrincipal.Size = New System.Drawing.Size(529, 26)
        Me.lciPrincipal.Text = "Principal:"
        Me.lciPrincipal.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciVessel
        '
        Me.lciVessel.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciVessel.AppearanceItemCaption.Options.UseFont = True
        Me.lciVessel.Control = Me.cboVessel
        Me.lciVessel.Location = New System.Drawing.Point(0, 52)
        Me.lciVessel.Name = "lciVessel"
        Me.lciVessel.Size = New System.Drawing.Size(529, 26)
        Me.lciVessel.Text = "Vessel:"
        Me.lciVessel.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciPort
        '
        Me.lciPort.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciPort.AppearanceItemCaption.Options.UseFont = True
        Me.lciPort.Control = Me.cboPort
        Me.lciPort.Location = New System.Drawing.Point(0, 0)
        Me.lciPort.Name = "lciPort"
        Me.lciPort.Size = New System.Drawing.Size(529, 26)
        Me.lciPort.Text = "Port:"
        Me.lciPort.TextSize = New System.Drawing.Size(118, 16)
        '
        'lcgPlaceDate
        '
        Me.lcgPlaceDate.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciDate, Me.lciPlace})
        Me.lcgPlaceDate.Location = New System.Drawing.Point(0, 354)
        Me.lcgPlaceDate.Name = "lcgPlaceDate"
        Me.lcgPlaceDate.Size = New System.Drawing.Size(553, 76)
        Me.lcgPlaceDate.TextVisible = False
        '
        'lciDate
        '
        Me.lciDate.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciDate.AppearanceItemCaption.Options.UseFont = True
        Me.lciDate.Control = Me.txtDate
        Me.lciDate.Location = New System.Drawing.Point(0, 26)
        Me.lciDate.Name = "lciDate"
        Me.lciDate.Size = New System.Drawing.Size(529, 26)
        Me.lciDate.Text = "Date:"
        Me.lciDate.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciPlace
        '
        Me.lciPlace.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciPlace.AppearanceItemCaption.Options.UseFont = True
        Me.lciPlace.Control = Me.txtPlace
        Me.lciPlace.Location = New System.Drawing.Point(0, 0)
        Me.lciPlace.Name = "lciPlace"
        Me.lciPlace.Size = New System.Drawing.Size(529, 26)
        Me.lciPlace.Text = "Place (City):"
        Me.lciPlace.TextSize = New System.Drawing.Size(118, 16)
        '
        'lcgSignatory
        '
        Me.lcgSignatory.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciSignatory})
        Me.lcgSignatory.Location = New System.Drawing.Point(0, 430)
        Me.lcgSignatory.Name = "lcgSignatory"
        Me.lcgSignatory.Size = New System.Drawing.Size(553, 50)
        Me.lcgSignatory.TextVisible = False
        '
        'lciSignatory
        '
        Me.lciSignatory.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciSignatory.AppearanceItemCaption.Options.UseFont = True
        Me.lciSignatory.Control = Me.cboSignatory
        Me.lciSignatory.Location = New System.Drawing.Point(0, 0)
        Me.lciSignatory.Name = "lciSignatory"
        Me.lciSignatory.Size = New System.Drawing.Size(529, 26)
        Me.lciSignatory.Text = "Signatory:"
        Me.lciSignatory.TextSize = New System.Drawing.Size(118, 16)
        '
        'lcgCrewDetails
        '
        Me.lcgCrewDetails.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciCrewName, Me.lciRank, Me.lciLOC, Me.lciWageScale, Me.lciLOCDays, Me.EmptySpaceItem1, Me.lciStatus})
        Me.lcgCrewDetails.Location = New System.Drawing.Point(0, 72)
        Me.lcgCrewDetails.Name = "lcgCrewDetails"
        Me.lcgCrewDetails.Size = New System.Drawing.Size(553, 154)
        Me.lcgCrewDetails.TextVisible = False
        '
        'lciCrewName
        '
        Me.lciCrewName.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciCrewName.AppearanceItemCaption.Options.UseFont = True
        Me.lciCrewName.Control = Me.txtCrewName
        Me.lciCrewName.Location = New System.Drawing.Point(0, 0)
        Me.lciCrewName.Name = "lciCrewName"
        Me.lciCrewName.Size = New System.Drawing.Size(529, 26)
        Me.lciCrewName.Text = "Name of Seafarer:"
        Me.lciCrewName.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciRank
        '
        Me.lciRank.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciRank.AppearanceItemCaption.Options.UseFont = True
        Me.lciRank.Control = Me.cboRank
        Me.lciRank.Location = New System.Drawing.Point(0, 52)
        Me.lciRank.Name = "lciRank"
        Me.lciRank.Size = New System.Drawing.Size(348, 26)
        Me.lciRank.Text = "Rank:"
        Me.lciRank.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciLOC
        '
        Me.lciLOC.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciLOC.AppearanceItemCaption.Options.UseFont = True
        Me.lciLOC.Control = Me.txtLOC
        Me.lciLOC.Location = New System.Drawing.Point(0, 78)
        Me.lciLOC.Name = "lciLOC"
        Me.lciLOC.Size = New System.Drawing.Size(264, 26)
        Me.lciLOC.Text = "LOC:"
        Me.lciLOC.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciWageScale
        '
        Me.lciWageScale.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciWageScale.AppearanceItemCaption.Options.UseFont = True
        Me.lciWageScale.Control = Me.cboWageScale
        Me.lciWageScale.Location = New System.Drawing.Point(0, 104)
        Me.lciWageScale.Name = "lciWageScale"
        Me.lciWageScale.Size = New System.Drawing.Size(529, 26)
        Me.lciWageScale.Text = "Wage Scale:"
        Me.lciWageScale.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciLOCDays
        '
        Me.lciLOCDays.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciLOCDays.AppearanceItemCaption.Options.UseFont = True
        Me.lciLOCDays.Control = Me.txtLOCDays
        Me.lciLOCDays.Location = New System.Drawing.Point(264, 78)
        Me.lciLOCDays.Name = "lciLOCDays"
        Me.lciLOCDays.Size = New System.Drawing.Size(265, 26)
        Me.lciLOCDays.Text = "LOC Days:"
        Me.lciLOCDays.TextSize = New System.Drawing.Size(118, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(348, 52)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(181, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'lciStatus
        '
        Me.lciStatus.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciStatus.AppearanceItemCaption.Options.UseFont = True
        Me.lciStatus.Control = Me.txtStatus
        Me.lciStatus.Location = New System.Drawing.Point(0, 26)
        Me.lciStatus.Name = "lciStatus"
        Me.lciStatus.Size = New System.Drawing.Size(529, 26)
        Me.lciStatus.Text = "Status:"
        Me.lciStatus.TextSize = New System.Drawing.Size(118, 16)
        '
        'LayoutControlGroup_SelectReport
        '
        Me.LayoutControlGroup_SelectReport.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_SelectReport.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_SelectReport.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciPrintPOEAContract, Me.lciPrintContractAddendum})
        Me.LayoutControlGroup_SelectReport.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_SelectReport.Name = "LayoutControlGroup_SelectReport"
        Me.LayoutControlGroup_SelectReport.Size = New System.Drawing.Size(553, 72)
        Me.LayoutControlGroup_SelectReport.Text = "Select A Report To Print"
        '
        'lciPrintPOEAContract
        '
        Me.lciPrintPOEAContract.Control = Me.chkPrintPOEAContract
        Me.lciPrintPOEAContract.Location = New System.Drawing.Point(0, 0)
        Me.lciPrintPOEAContract.Name = "lciPrintPOEAContract"
        Me.lciPrintPOEAContract.Size = New System.Drawing.Size(264, 24)
        Me.lciPrintPOEAContract.TextSize = New System.Drawing.Size(0, 0)
        Me.lciPrintPOEAContract.TextVisible = False
        '
        'lciPrintContractAddendum
        '
        Me.lciPrintContractAddendum.Control = Me.chkPrintContractAddendum
        Me.lciPrintContractAddendum.Location = New System.Drawing.Point(264, 0)
        Me.lciPrintContractAddendum.Name = "lciPrintContractAddendum"
        Me.lciPrintContractAddendum.Size = New System.Drawing.Size(265, 24)
        Me.lciPrintContractAddendum.TextSize = New System.Drawing.Size(0, 0)
        Me.lciPrintContractAddendum.TextVisible = False
        '
        'lciPrintButton
        '
        Me.lciPrintButton.Control = Me.btnPrint
        Me.lciPrintButton.Location = New System.Drawing.Point(0, 490)
        Me.lciPrintButton.MaxSize = New System.Drawing.Size(0, 42)
        Me.lciPrintButton.MinSize = New System.Drawing.Size(81, 42)
        Me.lciPrintButton.Name = "lciPrintButton"
        Me.lciPrintButton.Size = New System.Drawing.Size(276, 42)
        Me.lciPrintButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lciPrintButton.TextSize = New System.Drawing.Size(0, 0)
        Me.lciPrintButton.TextVisible = False
        '
        'lciCancelButton
        '
        Me.lciCancelButton.Control = Me.btnCancel
        Me.lciCancelButton.Location = New System.Drawing.Point(276, 490)
        Me.lciCancelButton.MaxSize = New System.Drawing.Size(0, 42)
        Me.lciCancelButton.MinSize = New System.Drawing.Size(92, 42)
        Me.lciCancelButton.Name = "lciCancelButton"
        Me.lciCancelButton.Size = New System.Drawing.Size(277, 42)
        Me.lciCancelButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lciCancelButton.TextSize = New System.Drawing.Size(0, 0)
        Me.lciCancelButton.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 480)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(553, 10)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmPopupPrintPOEAContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 552)
        Me.ControlBox = False
        Me.Controls.Add(Me.MainLayoutControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmPopupPrintPOEAContract"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print POEA Contract"
        CType(Me.MainLayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainLayoutControl.ResumeLayout(False)
        CType(Me.txtPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSignatory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintContractAddendum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintPOEAContract.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrincipal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboWageScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLOCDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLOC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCrewName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgVesselDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgPlaceDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPlace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgSignatory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciSignatory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgCrewDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciCrewName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciRank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciLOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciWageScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciLOCDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_SelectReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPrintPOEAContract, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPrintContractAddendum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPrintButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciCancelButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainLayoutControl As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup_Main As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboRank As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtCrewName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciCrewName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciRank As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboPrincipal As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboVessel As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboAgent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboWageScale As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtLOCDays As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtLOC As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lciLOC As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciLOCDays As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciWageScale As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgVesselDetails As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lciAgent As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciPrincipal As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciVessel As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciDate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgPlaceDate As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcgSignatory As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcgCrewDetails As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPrintContractAddendum As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintPOEAContract As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlGroup_SelectReport As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lciPrintPOEAContract As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciPrintContractAddendum As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciPrintButton As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciCancelButton As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciStatus As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboPort As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lciPort As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboSignatory As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lciSignatory As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPlace As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciPlace As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
End Class
