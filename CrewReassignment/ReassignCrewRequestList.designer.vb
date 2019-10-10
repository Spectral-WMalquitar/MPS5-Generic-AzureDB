<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReassignCrewRequestList
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
        Me.gbPlanningList = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRequestDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRequestedByName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
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
        Me.Maingrid.TabIndex = 6
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gbPlanningList})
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colDescription, Me.colRequestDate, Me.colRequestedByName})
        Me.Mainview.GridControl = Me.Maingrid
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsBehavior.Editable = False
        Me.Mainview.OptionsBehavior.ReadOnly = True
        Me.Mainview.OptionsFind.AlwaysVisible = True
        Me.Mainview.OptionsMenu.EnableColumnMenu = False
        Me.Mainview.OptionsView.ShowGroupPanel = False
        '
        'gbPlanningList
        '
        Me.gbPlanningList.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPlanningList.AppearanceHeader.Options.UseFont = True
        Me.gbPlanningList.Caption = "List of Transfer Requests"
        Me.gbPlanningList.Columns.Add(Me.colPKey)
        Me.gbPlanningList.Columns.Add(Me.colDescription)
        Me.gbPlanningList.Columns.Add(Me.colRequestDate)
        Me.gbPlanningList.Name = "gbPlanningList"
        Me.gbPlanningList.VisibleIndex = 0
        Me.gbPlanningList.Width = 1056
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colDescription
        '
        Me.colDescription.Caption = "Description"
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Visible = True
        Me.colDescription.Width = 760
        '
        'colRequestDate
        '
        Me.colRequestDate.Caption = "Request Date"
        Me.colRequestDate.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.colRequestDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colRequestDate.FieldName = "DateRequested"
        Me.colRequestDate.Name = "colRequestDate"
        Me.colRequestDate.Visible = True
        Me.colRequestDate.Width = 296
        '
        'colRequestedByName
        '
        Me.colRequestedByName.Caption = "Requested By"
        Me.colRequestedByName.FieldName = "RequestedByName"
        Me.colRequestedByName.Name = "colRequestedByName"
        '
        'ReassignCrewRequestList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Maingrid)
        Me.Name = "ReassignCrewRequestList"
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents gbPlanningList As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRequestDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRequestedByName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
