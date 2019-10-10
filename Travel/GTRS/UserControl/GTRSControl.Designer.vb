<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GTRSControl
    Inherits Travel.BaseGTRSControl

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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnGetBookingDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSendUpdates = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelBooking = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBookWithGTravel = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciCancelBooking = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lblBookedWithGTravel = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.lciGetBookingDetails = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciBookWithGTravel = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciSendUpdates = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciCancelBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBookedWithGTravel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciGetBookingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciBookWithGTravel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciSendUpdates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnGetBookingDetails)
        Me.LayoutControl1.Controls.Add(Me.btnSendUpdates)
        Me.LayoutControl1.Controls.Add(Me.btnCancelBooking)
        Me.LayoutControl1.Controls.Add(Me.btnBookWithGTravel)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(882, 291, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(263, 132)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnGetBookingDetails
        '
        Me.btnGetBookingDetails.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnGetBookingDetails.Appearance.Options.UseFont = True
        Me.btnGetBookingDetails.Image = Global.Travel.My.Resources.Resources.Green_Download
        Me.btnGetBookingDetails.Location = New System.Drawing.Point(2, 51)
        Me.btnGetBookingDetails.Name = "btnGetBookingDetails"
        Me.btnGetBookingDetails.Size = New System.Drawing.Size(259, 23)
        Me.btnGetBookingDetails.StyleController = Me.LayoutControl1
        Me.btnGetBookingDetails.TabIndex = 11
        Me.btnGetBookingDetails.Text = "Get Booking Details"
        '
        'btnSendUpdates
        '
        Me.btnSendUpdates.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnSendUpdates.Appearance.Options.UseFont = True
        Me.btnSendUpdates.Image = Global.Travel.My.Resources.Resources.Red_Exclamation_Mark
        Me.btnSendUpdates.Location = New System.Drawing.Point(2, 78)
        Me.btnSendUpdates.Name = "btnSendUpdates"
        Me.btnSendUpdates.Size = New System.Drawing.Size(259, 23)
        Me.btnSendUpdates.StyleController = Me.LayoutControl1
        Me.btnSendUpdates.TabIndex = 10
        Me.btnSendUpdates.Text = "Send Updates to GTravel"
        '
        'btnCancelBooking
        '
        Me.btnCancelBooking.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnCancelBooking.Appearance.Options.UseFont = True
        Me.btnCancelBooking.Location = New System.Drawing.Point(2, 105)
        Me.btnCancelBooking.Name = "btnCancelBooking"
        Me.btnCancelBooking.Size = New System.Drawing.Size(259, 23)
        Me.btnCancelBooking.StyleController = Me.LayoutControl1
        Me.btnCancelBooking.TabIndex = 9
        Me.btnCancelBooking.Text = "Cancel Booking From GTravel"
        '
        'btnBookWithGTravel
        '
        Me.btnBookWithGTravel.Appearance.BackColor = System.Drawing.Color.Navy
        Me.btnBookWithGTravel.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBookWithGTravel.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnBookWithGTravel.Appearance.Options.UseBackColor = True
        Me.btnBookWithGTravel.Appearance.Options.UseFont = True
        Me.btnBookWithGTravel.Appearance.Options.UseForeColor = True
        Me.btnBookWithGTravel.Location = New System.Drawing.Point(2, 2)
        Me.btnBookWithGTravel.Name = "btnBookWithGTravel"
        Me.btnBookWithGTravel.Size = New System.Drawing.Size(259, 23)
        Me.btnBookWithGTravel.StyleController = Me.LayoutControl1
        Me.btnBookWithGTravel.TabIndex = 8
        Me.btnBookWithGTravel.Text = "Book With GTravel"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciCancelBooking, Me.lblBookedWithGTravel, Me.lciGetBookingDetails, Me.lciBookWithGTravel, Me.lciSendUpdates})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(263, 132)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lciCancelBooking
        '
        Me.lciCancelBooking.Control = Me.btnCancelBooking
        Me.lciCancelBooking.Location = New System.Drawing.Point(0, 103)
        Me.lciCancelBooking.Name = "lciCancelBooking"
        Me.lciCancelBooking.Size = New System.Drawing.Size(263, 29)
        Me.lciCancelBooking.TextSize = New System.Drawing.Size(0, 0)
        Me.lciCancelBooking.TextVisible = False
        '
        'lblBookedWithGTravel
        '
        Me.lblBookedWithGTravel.AllowHotTrack = False
        Me.lblBookedWithGTravel.AppearanceItemCaption.BackColor = System.Drawing.Color.Navy
        Me.lblBookedWithGTravel.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBookedWithGTravel.AppearanceItemCaption.ForeColor = System.Drawing.Color.White
        Me.lblBookedWithGTravel.AppearanceItemCaption.Options.UseBackColor = True
        Me.lblBookedWithGTravel.AppearanceItemCaption.Options.UseFont = True
        Me.lblBookedWithGTravel.AppearanceItemCaption.Options.UseForeColor = True
        Me.lblBookedWithGTravel.AppearanceItemCaption.Options.UseTextOptions = True
        Me.lblBookedWithGTravel.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblBookedWithGTravel.Location = New System.Drawing.Point(0, 27)
        Me.lblBookedWithGTravel.Name = "lblBookedWithGTravel"
        Me.lblBookedWithGTravel.Size = New System.Drawing.Size(263, 22)
        Me.lblBookedWithGTravel.Text = "Booked With GTravel"
        Me.lblBookedWithGTravel.TextSize = New System.Drawing.Size(157, 18)
        '
        'lciGetBookingDetails
        '
        Me.lciGetBookingDetails.Control = Me.btnGetBookingDetails
        Me.lciGetBookingDetails.Location = New System.Drawing.Point(0, 49)
        Me.lciGetBookingDetails.Name = "lciGetBookingDetails"
        Me.lciGetBookingDetails.Size = New System.Drawing.Size(263, 27)
        Me.lciGetBookingDetails.TextSize = New System.Drawing.Size(0, 0)
        Me.lciGetBookingDetails.TextVisible = False
        '
        'lciBookWithGTravel
        '
        Me.lciBookWithGTravel.Control = Me.btnBookWithGTravel
        Me.lciBookWithGTravel.Location = New System.Drawing.Point(0, 0)
        Me.lciBookWithGTravel.Name = "lciBookWithGTravel"
        Me.lciBookWithGTravel.Size = New System.Drawing.Size(263, 27)
        Me.lciBookWithGTravel.TextSize = New System.Drawing.Size(0, 0)
        Me.lciBookWithGTravel.TextVisible = False
        '
        'lciSendUpdates
        '
        Me.lciSendUpdates.Control = Me.btnSendUpdates
        Me.lciSendUpdates.Location = New System.Drawing.Point(0, 76)
        Me.lciSendUpdates.Name = "lciSendUpdates"
        Me.lciSendUpdates.Size = New System.Drawing.Size(263, 27)
        Me.lciSendUpdates.TextSize = New System.Drawing.Size(0, 0)
        Me.lciSendUpdates.TextVisible = False
        '
        'GTRSControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "GTRSControl"
        Me.Size = New System.Drawing.Size(263, 132)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciCancelBooking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBookedWithGTravel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciGetBookingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciBookWithGTravel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciSendUpdates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnBookWithGTravel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lciBookWithGTravel As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblBookedWithGTravel As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents btnCancelBooking As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lciCancelBooking As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnGetBookingDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSendUpdates As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lciSendUpdates As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciGetBookingDetails As DevExpress.XtraLayout.LayoutControlItem

End Class
