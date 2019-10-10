<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TravelEvent_VslList
    Inherits BaseControl.BaseList

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
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.colVslID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVslName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbPlanningList = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Maingrid
        '
        Me.Maingrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Maingrid.Location = New System.Drawing.Point(0, 0)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.Size = New System.Drawing.Size(303, 323)
        Me.Maingrid.TabIndex = 5
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gbPlanningList})
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colVslID, Me.colVslName})
        Me.Mainview.GridControl = Me.Maingrid
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsBehavior.Editable = False
        Me.Mainview.OptionsBehavior.ReadOnly = True
        Me.Mainview.OptionsFind.AlwaysVisible = True
        Me.Mainview.OptionsMenu.EnableColumnMenu = False
        Me.Mainview.OptionsView.ShowGroupPanel = False
        '
        'colVslID
        '
        Me.colVslID.FieldName = "PKey"
        Me.colVslID.Name = "colVslID"
        '
        'colVslName
        '
        Me.colVslName.Caption = "Name"
        Me.colVslName.FieldName = "Name"
        Me.colVslName.Name = "colVslName"
        Me.colVslName.Visible = True
        '
        'gbPlanningList
        '
        Me.gbPlanningList.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPlanningList.AppearanceHeader.Options.UseFont = True
        Me.gbPlanningList.Caption = "Active Vessels"
        Me.gbPlanningList.Columns.Add(Me.colVslID)
        Me.gbPlanningList.Columns.Add(Me.colVslName)
        Me.gbPlanningList.Name = "gbPlanningList"
        Me.gbPlanningList.VisibleIndex = 0
        Me.gbPlanningList.Width = 75
        '
        'TravelEvent_VslList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Maingrid)
        Me.Name = "TravelEvent_VslList"
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents colVslID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVslName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gbPlanningList As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
