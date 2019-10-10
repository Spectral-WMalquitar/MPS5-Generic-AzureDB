<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GridFlyOut
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.FlyoutPanel1 = New DevExpress.Utils.FlyoutPanel()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.CardView1 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.repMemo = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        CType(Me.FlyoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanel1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlyoutPanel1
        '
        Me.FlyoutPanel1.Controls.Add(Me.Grid)
        Me.FlyoutPanel1.Location = New System.Drawing.Point(29, 16)
        Me.FlyoutPanel1.Name = "FlyoutPanel1"
        Me.FlyoutPanel1.Size = New System.Drawing.Size(391, 311)
        Me.FlyoutPanel1.TabIndex = 0
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(17, 18)
        Me.Grid.MainView = Me.CardView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repMemo})
        Me.Grid.Size = New System.Drawing.Size(356, 275)
        Me.Grid.TabIndex = 0
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CardView1})
        '
        'CardView1
        '
        Me.CardView1.Appearance.FieldCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CardView1.Appearance.FieldCaption.Options.UseFont = True
        Me.CardView1.FocusedCardTopFieldIndex = 0
        Me.CardView1.GridControl = Me.Grid
        Me.CardView1.Name = "CardView1"
        Me.CardView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CardView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CardView1.OptionsBehavior.AllowExpandCollapse = False
        Me.CardView1.OptionsBehavior.AutoHorzWidth = True
        Me.CardView1.OptionsBehavior.Editable = False
        Me.CardView1.OptionsBehavior.FieldAutoHeight = True
        Me.CardView1.OptionsView.ShowCardCaption = False
        Me.CardView1.OptionsView.ShowCardExpandButton = False
        Me.CardView1.OptionsView.ShowLines = False
        Me.CardView1.OptionsView.ShowQuickCustomizeButton = False
        Me.CardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        '
        'repMemo
        '
        Me.repMemo.Name = "repMemo"
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.AutoSize = True
        Me.FlyoutPanelControl1.Controls.Add(Me.FlyoutPanel1)
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanel1
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(25, 15)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(460, 359)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'GridFlyOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FlyoutPanelControl1)
        Me.Name = "GridFlyOut"
        Me.Size = New System.Drawing.Size(520, 377)
        CType(Me.FlyoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanel1.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMemo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents FlyoutPanel1 As DevExpress.Utils.FlyoutPanel
    Public WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Public WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CardView1 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents repMemo As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit

End Class
