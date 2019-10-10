<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayrollReportControl
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.ReportGrid = New DevExpress.XtraGrid.GridControl()
        Me.ReportView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ReportGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.ReportGrid)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(342, 307)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Reports"
        '
        'ReportGrid
        '
        Me.ReportGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportGrid.Location = New System.Drawing.Point(2, 22)
        Me.ReportGrid.MainView = Me.ReportView
        Me.ReportGrid.Name = "ReportGrid"
        Me.ReportGrid.Size = New System.Drawing.Size(338, 283)
        Me.ReportGrid.TabIndex = 0
        Me.ReportGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportView})
        '
        'ReportView
        '
        Me.ReportView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.ReportView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.ReportView.GridControl = Me.ReportGrid
        Me.ReportView.Name = "ReportView"
        Me.ReportView.OptionsBehavior.Editable = False
        Me.ReportView.OptionsView.ShowColumnHeaders = False
        Me.ReportView.OptionsView.ShowGroupPanel = False
        Me.ReportView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportView.OptionsView.ShowIndicator = False
        Me.ReportView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ObjectID"
        Me.GridColumn1.FieldName = "ObjectID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Caption"
        Me.GridColumn2.FieldName = "Caption"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ReportGroup"
        Me.GridColumn3.FieldName = "ReportGroup"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ReportClass"
        Me.GridColumn4.FieldName = "ReportClass"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'PayrollReportControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "PayrollReportControl"
        Me.Size = New System.Drawing.Size(342, 307)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.ReportGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ReportGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn

End Class
