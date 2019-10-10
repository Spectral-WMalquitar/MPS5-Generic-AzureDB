<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GTRSConfig
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GTRSConfig))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl_Main = New DevExpress.XtraLayout.LayoutControl()
        Me.btnToggelViewPassword = New DevExpress.XtraEditors.CheckButton()
        Me.cboLogStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.cmdClearFilter = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdApplyFilter = New DevExpress.XtraEditors.SimpleButton()
        Me.cboUserName = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboComputerName = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtDateTo = New DevExpress.XtraEditors.DateEdit()
        Me.txtDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.TransactionLogGrid = New DevExpress.XtraGrid.GridControl()
        Me.TransactionLogView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTransactionType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCalledMethod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCallingForm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTransactionDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colComputerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUsername = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFailErrorMessage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFailErrorMessage = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colHasError = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValidLog = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repStatus = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblGTRSAccount_Result = New DevExpress.XtraEditors.LabelControl()
        Me.btnSaveURL = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSignInOut = New DevExpress.XtraEditors.SimpleButton()
        Me.txtGTRSAccount_Pwd = New DevExpress.XtraEditors.TextEdit()
        Me.txtGTRSAccount_User = New DevExpress.XtraEditors.TextEdit()
        Me.txtEndpointURL = New DevExpress.XtraEditors.TextEdit()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.tabGTRSConfig = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.lcgGTRSSettings = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcgEndpointAddr = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lcgGTRSAccount = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciLoadingGTRSAccount = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lcgTransactionLog = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciUsername = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciDateTo = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.timerGTRSAccount = New System.Windows.Forms.Timer(Me.components)
        Me.bgValidateAccount = New System.ComponentModel.BackgroundWorker()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl_Main.SuspendLayout()
        CType(Me.cboLogStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboComputerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionLogGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionLogView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFailErrorMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGTRSAccount_Pwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGTRSAccount_User.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEndpointURL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabGTRSConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgGTRSSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgEndpointAddr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgGTRSAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciLoadingGTRSAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgTransactionLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciUsername, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl_Main)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1522, 614)
        Me.header.TabIndex = 0
        Me.header.Text = "GTRS Configuration"
        '
        'LayoutControl_Main
        '
        Me.LayoutControl_Main.Controls.Add(Me.btnToggelViewPassword)
        Me.LayoutControl_Main.Controls.Add(Me.cboLogStatus)
        Me.LayoutControl_Main.Controls.Add(Me.cmdClearFilter)
        Me.LayoutControl_Main.Controls.Add(Me.cmdApplyFilter)
        Me.LayoutControl_Main.Controls.Add(Me.cboUserName)
        Me.LayoutControl_Main.Controls.Add(Me.cboComputerName)
        Me.LayoutControl_Main.Controls.Add(Me.txtDateTo)
        Me.LayoutControl_Main.Controls.Add(Me.txtDateFrom)
        Me.LayoutControl_Main.Controls.Add(Me.TransactionLogGrid)
        Me.LayoutControl_Main.Controls.Add(Me.PictureBox1)
        Me.LayoutControl_Main.Controls.Add(Me.lblGTRSAccount_Result)
        Me.LayoutControl_Main.Controls.Add(Me.btnSaveURL)
        Me.LayoutControl_Main.Controls.Add(Me.btnSignInOut)
        Me.LayoutControl_Main.Controls.Add(Me.txtGTRSAccount_Pwd)
        Me.LayoutControl_Main.Controls.Add(Me.txtGTRSAccount_User)
        Me.LayoutControl_Main.Controls.Add(Me.txtEndpointURL)
        Me.LayoutControl_Main.Controls.Add(Me.PictureEdit1)
        Me.LayoutControl_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl_Main.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl_Main.Name = "LayoutControl_Main"
        Me.LayoutControl_Main.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(855, 350, 250, 350)
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl_Main.Root = Me.LayoutControlGroup1
        Me.LayoutControl_Main.Size = New System.Drawing.Size(1518, 586)
        Me.LayoutControl_Main.TabIndex = 0
        Me.LayoutControl_Main.Text = "LayoutControl1"
        '
        'btnToggelViewPassword
        '
        Me.btnToggelViewPassword.Image = CType(resources.GetObject("btnToggelViewPassword.Image"), System.Drawing.Image)
        Me.btnToggelViewPassword.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnToggelViewPassword.Location = New System.Drawing.Point(671, 247)
        Me.btnToggelViewPassword.Name = "btnToggelViewPassword"
        Me.btnToggelViewPassword.Size = New System.Drawing.Size(26, 22)
        Me.btnToggelViewPassword.StyleController = Me.LayoutControl_Main
        Me.btnToggelViewPassword.TabIndex = 21
        '
        'cboLogStatus
        '
        Me.cboLogStatus.Location = New System.Drawing.Point(414, 115)
        Me.cboLogStatus.Name = "cboLogStatus"
        Me.cboLogStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboLogStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboLogStatus.Properties.DropDownRows = 3
        Me.cboLogStatus.Properties.NullText = ""
        Me.cboLogStatus.Size = New System.Drawing.Size(212, 22)
        Me.cboLogStatus.StyleController = Me.LayoutControl_Main
        Me.cboLogStatus.TabIndex = 20
        '
        'cmdClearFilter
        '
        Me.cmdClearFilter.Location = New System.Drawing.Point(788, 115)
        Me.cmdClearFilter.Name = "cmdClearFilter"
        Me.cmdClearFilter.Size = New System.Drawing.Size(158, 23)
        Me.cmdClearFilter.StyleController = Me.LayoutControl_Main
        Me.cmdClearFilter.TabIndex = 19
        Me.cmdClearFilter.Text = "Clear Filter"
        '
        'cmdApplyFilter
        '
        Me.cmdApplyFilter.Location = New System.Drawing.Point(630, 115)
        Me.cmdApplyFilter.Name = "cmdApplyFilter"
        Me.cmdApplyFilter.Size = New System.Drawing.Size(154, 23)
        Me.cmdApplyFilter.StyleController = Me.LayoutControl_Main
        Me.cmdApplyFilter.TabIndex = 18
        Me.cmdApplyFilter.Text = "Apply Filter"
        '
        'cboUserName
        '
        Me.cboUserName.Location = New System.Drawing.Point(731, 89)
        Me.cboUserName.Name = "cboUserName"
        Me.cboUserName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboUserName.Properties.NullText = ""
        Me.cboUserName.Size = New System.Drawing.Size(215, 22)
        Me.cboUserName.StyleController = Me.LayoutControl_Main
        Me.cboUserName.TabIndex = 17
        '
        'cboComputerName
        '
        Me.cboComputerName.Location = New System.Drawing.Point(731, 63)
        Me.cboComputerName.Name = "cboComputerName"
        Me.cboComputerName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboComputerName.Properties.NullText = ""
        Me.cboComputerName.Size = New System.Drawing.Size(215, 22)
        Me.cboComputerName.StyleController = Me.LayoutControl_Main
        Me.cboComputerName.TabIndex = 16
        '
        'txtDateTo
        '
        Me.txtDateTo.EditValue = Nothing
        Me.txtDateTo.Location = New System.Drawing.Point(414, 89)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.txtDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateTo.Properties.Mask.EditMask = "dd-MMM-yyyy hh:mm tt"
        Me.txtDateTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDateTo.Size = New System.Drawing.Size(212, 22)
        Me.txtDateTo.StyleController = Me.LayoutControl_Main
        Me.txtDateTo.TabIndex = 15
        '
        'txtDateFrom
        '
        Me.txtDateFrom.EditValue = Nothing
        Me.txtDateFrom.Location = New System.Drawing.Point(414, 63)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.txtDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateFrom.Properties.Mask.EditMask = "dd-MMM-yyyy hh:mm tt"
        Me.txtDateFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDateFrom.Size = New System.Drawing.Size(212, 22)
        Me.txtDateFrom.StyleController = Me.LayoutControl_Main
        Me.txtDateFrom.TabIndex = 14
        '
        'TransactionLogGrid
        '
        Me.TransactionLogGrid.Location = New System.Drawing.Point(325, 176)
        Me.TransactionLogGrid.MainView = Me.TransactionLogView
        Me.TransactionLogGrid.Name = "TransactionLogGrid"
        Me.TransactionLogGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repStatus, Me.repDateEdit, Me.repFailErrorMessage})
        Me.TransactionLogGrid.Size = New System.Drawing.Size(1145, 362)
        Me.TransactionLogGrid.TabIndex = 13
        Me.TransactionLogGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TransactionLogView})
        '
        'TransactionLogView
        '
        Me.TransactionLogView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTransactionType, Me.colCalledMethod, Me.colCallingForm, Me.colAction, Me.colDescription, Me.colTransactionDate, Me.colComputerName, Me.colUsername, Me.colFailErrorMessage, Me.colHasError, Me.colValidLog})
        Me.TransactionLogView.GridControl = Me.TransactionLogGrid
        Me.TransactionLogView.Name = "TransactionLogView"
        Me.TransactionLogView.OptionsBehavior.ReadOnly = True
        Me.TransactionLogView.OptionsCustomization.AllowColumnMoving = False
        Me.TransactionLogView.OptionsCustomization.AllowGroup = False
        Me.TransactionLogView.OptionsCustomization.AllowSort = False
        Me.TransactionLogView.OptionsFind.AlwaysVisible = True
        Me.TransactionLogView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.TransactionLogView.OptionsView.ShowGroupPanel = False
        '
        'colTransactionType
        '
        Me.colTransactionType.Caption = "Transaction"
        Me.colTransactionType.FieldName = "TransactionType"
        Me.colTransactionType.Name = "colTransactionType"
        Me.colTransactionType.Visible = True
        Me.colTransactionType.VisibleIndex = 1
        Me.colTransactionType.Width = 104
        '
        'colCalledMethod
        '
        Me.colCalledMethod.Caption = "Called Method"
        Me.colCalledMethod.FieldName = "CalledMethod"
        Me.colCalledMethod.Name = "colCalledMethod"
        Me.colCalledMethod.Visible = True
        Me.colCalledMethod.VisibleIndex = 2
        Me.colCalledMethod.Width = 139
        '
        'colCallingForm
        '
        Me.colCallingForm.Caption = "Form Name"
        Me.colCallingForm.FieldName = "CallingForm"
        Me.colCallingForm.Name = "colCallingForm"
        Me.colCallingForm.Visible = True
        Me.colCallingForm.VisibleIndex = 3
        Me.colCallingForm.Width = 187
        '
        'colAction
        '
        Me.colAction.Caption = "Action"
        Me.colAction.FieldName = "Action"
        Me.colAction.Name = "colAction"
        Me.colAction.Visible = True
        Me.colAction.VisibleIndex = 4
        Me.colAction.Width = 263
        '
        'colDescription
        '
        Me.colDescription.Caption = "Description"
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 5
        Me.colDescription.Width = 363
        '
        'colTransactionDate
        '
        Me.colTransactionDate.Caption = "Transaction Date"
        Me.colTransactionDate.ColumnEdit = Me.repDateEdit
        Me.colTransactionDate.FieldName = "TransactionDate"
        Me.colTransactionDate.Name = "colTransactionDate"
        Me.colTransactionDate.Visible = True
        Me.colTransactionDate.VisibleIndex = 6
        Me.colTransactionDate.Width = 152
        '
        'repDateEdit
        '
        Me.repDateEdit.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.repDateEdit.AutoHeight = False
        Me.repDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit.Mask.EditMask = "dd-MMM-yyyy hh:mm:ss tt"
        Me.repDateEdit.Mask.UseMaskAsDisplayFormat = True
        Me.repDateEdit.Name = "repDateEdit"
        '
        'colComputerName
        '
        Me.colComputerName.Caption = "Computer Name"
        Me.colComputerName.FieldName = "ComputerName"
        Me.colComputerName.Name = "colComputerName"
        Me.colComputerName.Visible = True
        Me.colComputerName.VisibleIndex = 8
        Me.colComputerName.Width = 154
        '
        'colUsername
        '
        Me.colUsername.Caption = "Username"
        Me.colUsername.FieldName = "Username"
        Me.colUsername.Name = "colUsername"
        Me.colUsername.Visible = True
        Me.colUsername.VisibleIndex = 7
        Me.colUsername.Width = 115
        '
        'colFailErrorMessage
        '
        Me.colFailErrorMessage.Caption = "Error Message"
        Me.colFailErrorMessage.ColumnEdit = Me.repFailErrorMessage
        Me.colFailErrorMessage.FieldName = "FailErrorMessage"
        Me.colFailErrorMessage.Name = "colFailErrorMessage"
        Me.colFailErrorMessage.Visible = True
        Me.colFailErrorMessage.VisibleIndex = 9
        Me.colFailErrorMessage.Width = 119
        '
        'repFailErrorMessage
        '
        Me.repFailErrorMessage.AutoHeight = False
        Me.repFailErrorMessage.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repFailErrorMessage.Name = "repFailErrorMessage"
        '
        'colHasError
        '
        Me.colHasError.Caption = "HasError"
        Me.colHasError.FieldName = "HasError"
        Me.colHasError.Name = "colHasError"
        '
        'colValidLog
        '
        Me.colValidLog.Caption = " "
        Me.colValidLog.ColumnEdit = Me.repStatus
        Me.colValidLog.FieldName = "ValidLog"
        Me.colValidLog.Name = "colValidLog"
        Me.colValidLog.Visible = True
        Me.colValidLog.VisibleIndex = 0
        Me.colValidLog.Width = 36
        '
        'repStatus
        '
        Me.repStatus.AutoHeight = False
        Me.repStatus.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.repStatus.Name = "repStatus"
        Me.repStatus.PictureChecked = Global.Travel.My.Resources.Resources.GTRS_TransactionLog_OK
        Me.repStatus.PictureUnchecked = Global.Travel.My.Resources.Resources.GTRS_TransactionLog_withError
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Travel.My.Resources.Resources.loading
        Me.PictureBox1.Location = New System.Drawing.Point(313, 281)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'lblGTRSAccount_Result
        '
        Me.lblGTRSAccount_Result.Appearance.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Italic)
        Me.lblGTRSAccount_Result.Location = New System.Drawing.Point(337, 281)
        Me.lblGTRSAccount_Result.Name = "lblGTRSAccount_Result"
        Me.lblGTRSAccount_Result.Size = New System.Drawing.Size(735, 14)
        Me.lblGTRSAccount_Result.StyleController = Me.LayoutControl_Main
        Me.lblGTRSAccount_Result.TabIndex = 11
        '
        'btnSaveURL
        '
        Me.btnSaveURL.Enabled = False
        Me.btnSaveURL.Location = New System.Drawing.Point(313, 139)
        Me.btnSaveURL.Name = "btnSaveURL"
        Me.btnSaveURL.Size = New System.Drawing.Size(123, 23)
        Me.btnSaveURL.StyleController = Me.LayoutControl_Main
        Me.btnSaveURL.TabIndex = 10
        Me.btnSaveURL.Text = "Save"
        '
        'btnSignInOut
        '
        Me.btnSignInOut.Enabled = False
        Me.btnSignInOut.Location = New System.Drawing.Point(701, 247)
        Me.btnSignInOut.Name = "btnSignInOut"
        Me.btnSignInOut.Size = New System.Drawing.Size(159, 23)
        Me.btnSignInOut.StyleController = Me.LayoutControl_Main
        Me.btnSignInOut.TabIndex = 9
        Me.btnSignInOut.Text = "Sign In"
        '
        'txtGTRSAccount_Pwd
        '
        Me.txtGTRSAccount_Pwd.Location = New System.Drawing.Point(414, 247)
        Me.txtGTRSAccount_Pwd.Name = "txtGTRSAccount_Pwd"
        Me.txtGTRSAccount_Pwd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtGTRSAccount_Pwd.Size = New System.Drawing.Size(253, 22)
        Me.txtGTRSAccount_Pwd.StyleController = Me.LayoutControl_Main
        Me.txtGTRSAccount_Pwd.TabIndex = 8
        '
        'txtGTRSAccount_User
        '
        Me.txtGTRSAccount_User.Location = New System.Drawing.Point(414, 213)
        Me.txtGTRSAccount_User.Name = "txtGTRSAccount_User"
        Me.txtGTRSAccount_User.Size = New System.Drawing.Size(253, 22)
        Me.txtGTRSAccount_User.StyleController = Me.LayoutControl_Main
        Me.txtGTRSAccount_User.TabIndex = 7
        '
        'txtEndpointURL
        '
        Me.txtEndpointURL.Location = New System.Drawing.Point(313, 105)
        Me.txtEndpointURL.Name = "txtEndpointURL"
        Me.txtEndpointURL.Size = New System.Drawing.Size(759, 22)
        Me.txtEndpointURL.StyleController = Me.LayoutControl_Main
        Me.txtEndpointURL.TabIndex = 6
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(115, 12)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PictureEdit1.Size = New System.Drawing.Size(144, 170)
        Me.PictureEdit1.StyleController = Me.LayoutControl_Main
        Me.PictureEdit1.TabIndex = 5
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem6, Me.EmptySpaceItem9, Me.tabGTRSConfig})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1518, 586)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PictureEdit1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(103, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(148, 174)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(148, 174)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(148, 174)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(103, 174)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(148, 392)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(103, 566)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(251, 0)
        Me.EmptySpaceItem9.MaxSize = New System.Drawing.Size(26, 0)
        Me.EmptySpaceItem9.MinSize = New System.Drawing.Size(26, 10)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(26, 566)
        Me.EmptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'tabGTRSConfig
        '
        Me.tabGTRSConfig.Location = New System.Drawing.Point(277, 0)
        Me.tabGTRSConfig.Name = "tabGTRSConfig"
        Me.tabGTRSConfig.SelectedTabPage = Me.lcgGTRSSettings
        Me.tabGTRSConfig.SelectedTabPageIndex = 0
        Me.tabGTRSConfig.Size = New System.Drawing.Size(1221, 566)
        Me.tabGTRSConfig.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgGTRSSettings, Me.lcgTransactionLog})
        '
        'lcgGTRSSettings
        '
        Me.lcgGTRSSettings.AppearanceTabPage.Header.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lcgGTRSSettings.AppearanceTabPage.Header.Options.UseFont = True
        Me.lcgGTRSSettings.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgEndpointAddr, Me.lcgGTRSAccount, Me.EmptySpaceItem8, Me.EmptySpaceItem1})
        Me.lcgGTRSSettings.Location = New System.Drawing.Point(0, 0)
        Me.lcgGTRSSettings.Name = "lcgGTRSSettings"
        Me.lcgGTRSSettings.Size = New System.Drawing.Size(1197, 515)
        Me.lcgGTRSSettings.Text = "GTRS Settings"
        '
        'lcgEndpointAddr
        '
        Me.lcgEndpointAddr.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lcgEndpointAddr.AppearanceGroup.Options.UseFont = True
        Me.lcgEndpointAddr.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem6, Me.EmptySpaceItem7})
        Me.lcgEndpointAddr.Location = New System.Drawing.Point(0, 0)
        Me.lcgEndpointAddr.Name = "lcgEndpointAddr"
        Me.lcgEndpointAddr.Size = New System.Drawing.Size(787, 127)
        Me.lcgEndpointAddr.Text = "GTRS Endpoint Address"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtEndpointURL
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(763, 53)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(763, 53)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(763, 53)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "URL:"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(98, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnSaveURL
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 53)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(127, 27)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(127, 27)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(127, 27)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(127, 53)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(636, 27)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'lcgGTRSAccount
        '
        Me.lcgGTRSAccount.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lcgGTRSAccount.AppearanceGroup.Options.UseFont = True
        Me.lcgGTRSAccount.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.EmptySpaceItem4, Me.LayoutControlItem5, Me.EmptySpaceItem5, Me.LayoutControlItem7, Me.lciLoadingGTRSAccount, Me.LayoutControlItem14})
        Me.lcgGTRSAccount.Location = New System.Drawing.Point(0, 127)
        Me.lcgGTRSAccount.Name = "lcgGTRSAccount"
        Me.lcgGTRSAccount.Size = New System.Drawing.Size(787, 139)
        Me.lcgGTRSAccount.Text = "GTRS Account"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtGTRSAccount_User
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(358, 34)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(358, 34)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(358, 34)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Username:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(98, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtGTRSAccount_Pwd
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(358, 34)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(358, 34)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(358, 34)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Password:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(98, 16)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(358, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(193, 34)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnSignInOut
        Me.LayoutControlItem5.Location = New System.Drawing.Point(388, 34)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(163, 27)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(163, 27)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(163, 34)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(551, 0)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(212, 68)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.lblGTRSAccount_Result
        Me.LayoutControlItem7.Location = New System.Drawing.Point(24, 68)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(739, 24)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'lciLoadingGTRSAccount
        '
        Me.lciLoadingGTRSAccount.Control = Me.PictureBox1
        Me.lciLoadingGTRSAccount.Location = New System.Drawing.Point(0, 68)
        Me.lciLoadingGTRSAccount.MaxSize = New System.Drawing.Size(24, 0)
        Me.lciLoadingGTRSAccount.MinSize = New System.Drawing.Size(24, 24)
        Me.lciLoadingGTRSAccount.Name = "lciLoadingGTRSAccount"
        Me.lciLoadingGTRSAccount.Size = New System.Drawing.Size(24, 24)
        Me.lciLoadingGTRSAccount.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lciLoadingGTRSAccount.TextSize = New System.Drawing.Size(0, 0)
        Me.lciLoadingGTRSAccount.TextVisible = False
        Me.lciLoadingGTRSAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.btnToggelViewPassword
        Me.LayoutControlItem14.Location = New System.Drawing.Point(358, 34)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(30, 26)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(30, 26)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(30, 34)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(787, 0)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(410, 515)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 266)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(787, 249)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'lcgTransactionLog
        '
        Me.lcgTransactionLog.AppearanceTabPage.Header.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lcgTransactionLog.AppearanceTabPage.Header.Options.UseFont = True
        Me.lcgTransactionLog.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3})
        Me.lcgTransactionLog.Location = New System.Drawing.Point(0, 0)
        Me.lcgTransactionLog.Name = "lcgTransactionLog"
        Me.lcgTransactionLog.Size = New System.Drawing.Size(1197, 515)
        Me.lcgTransactionLog.Text = "Transaction Log"
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.LayoutControlItem12, Me.LayoutControlItem9, Me.lciUsername, Me.LayoutControlGroup2, Me.lciDateTo, Me.EmptySpaceItem3, Me.LayoutControlItem11, Me.LayoutControlItem13})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1197, 515)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.cmdApplyFilter
        Me.LayoutControlItem10.Location = New System.Drawing.Point(317, 52)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(158, 27)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.cmdClearFilter
        Me.LayoutControlItem12.Location = New System.Drawing.Point(475, 52)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(162, 27)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtDateFrom
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(317, 26)
        Me.LayoutControlItem9.Text = "Date From:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(98, 16)
        '
        'lciUsername
        '
        Me.lciUsername.Control = Me.cboUserName
        Me.lciUsername.Location = New System.Drawing.Point(317, 26)
        Me.lciUsername.Name = "lciUsername"
        Me.lciUsername.Size = New System.Drawing.Size(320, 26)
        Me.lciUsername.Text = "Username:"
        Me.lciUsername.TextSize = New System.Drawing.Size(98, 16)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 79)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1173, 412)
        Me.LayoutControlGroup2.Text = "Log Details"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TransactionLogGrid
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(1149, 366)
        Me.LayoutControlItem8.Text = "Log Details:"
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'lciDateTo
        '
        Me.lciDateTo.Control = Me.txtDateTo
        Me.lciDateTo.Location = New System.Drawing.Point(0, 26)
        Me.lciDateTo.Name = "lciDateTo"
        Me.lciDateTo.Size = New System.Drawing.Size(317, 26)
        Me.lciDateTo.Text = "Date To:"
        Me.lciDateTo.TextSize = New System.Drawing.Size(98, 16)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(637, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(536, 79)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cboComputerName
        Me.LayoutControlItem11.Location = New System.Drawing.Point(317, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(320, 26)
        Me.LayoutControlItem11.Text = "Computer Name:"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(98, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.cboLogStatus
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(317, 27)
        Me.LayoutControlItem13.Text = "Status:"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(98, 16)
        '
        'bgValidateAccount
        '
        '
        'GTRSConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "GTRSConfig"
        Me.Size = New System.Drawing.Size(1522, 614)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl_Main.ResumeLayout(False)
        CType(Me.cboLogStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboComputerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionLogGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionLogView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFailErrorMessage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGTRSAccount_Pwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGTRSAccount_User.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEndpointURL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabGTRSConfig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgGTRSSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgEndpointAddr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgGTRSAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciLoadingGTRSAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgTransactionLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciUsername, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl_Main As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtEndpointURL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSignInOut As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtGTRSAccount_Pwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGTRSAccount_User As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSaveURL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblGTRSAccount_Result As DevExpress.XtraEditors.LabelControl
    Friend WithEvents timerGTRSAccount As System.Windows.Forms.Timer
    Friend WithEvents bgValidateAccount As System.ComponentModel.BackgroundWorker
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TransactionLogGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents TransactionLogView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTransactionType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCalledMethod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCallingForm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTransactionDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComputerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUsername As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFailErrorMessage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHasError As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboUserName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboComputerName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtDateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciDateTo As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciUsername As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdClearFilter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdApplyFilter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colValidLog As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repStatus As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents repDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents repFailErrorMessage As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents tabGTRSConfig As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents lcgGTRSSettings As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lcgEndpointAddr As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lcgGTRSAccount As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciLoadingGTRSAccount As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lcgTransactionLog As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboLogStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnToggelViewPassword As DevExpress.XtraEditors.CheckButton
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem

End Class
