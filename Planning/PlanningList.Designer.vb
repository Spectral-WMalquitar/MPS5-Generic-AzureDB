<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanningList
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
        Me.colPlanningID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colEventName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.VslName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PlannedDateSON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCrewWithTravel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCrewOnbCount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDateCreated = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colTravelEvent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colChecklist = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Maingrid
        '
        Me.Maingrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Maingrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.Maingrid.Location = New System.Drawing.Point(0, 0)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Margin = New System.Windows.Forms.Padding(4)
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.Size = New System.Drawing.Size(404, 398)
        Me.Maingrid.TabIndex = 5
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gbPlanningList})
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPlanningID, Me.colEventName, Me.colDateCreated, Me.colTravelEvent, Me.colChecklist, Me.colCrewOnbCount, Me.colCrewWithTravel, Me.PlannedDateSON, Me.VslName, Me.BandedGridColumn1})
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
        Me.gbPlanningList.Caption = "List of Planning Events"
        Me.gbPlanningList.Columns.Add(Me.colPlanningID)
        Me.gbPlanningList.Columns.Add(Me.colEventName)
        Me.gbPlanningList.Columns.Add(Me.VslName)
        Me.gbPlanningList.Columns.Add(Me.PlannedDateSON)
        Me.gbPlanningList.Columns.Add(Me.colCrewWithTravel)
        Me.gbPlanningList.Columns.Add(Me.colCrewOnbCount)
        Me.gbPlanningList.Columns.Add(Me.colDateCreated)
        Me.gbPlanningList.Columns.Add(Me.colTravelEvent)
        Me.gbPlanningList.Columns.Add(Me.colChecklist)
        Me.gbPlanningList.Name = "gbPlanningList"
        Me.gbPlanningList.VisibleIndex = 0
        Me.gbPlanningList.Width = 1285
        '
        'colPlanningID
        '
        Me.colPlanningID.FieldName = "PKey"
        Me.colPlanningID.Name = "colPlanningID"
        '
        'colEventName
        '
        Me.colEventName.Caption = "Event Name"
        Me.colEventName.FieldName = "PlanningEvent"
        Me.colEventName.Name = "colEventName"
        Me.colEventName.Visible = True
        Me.colEventName.Width = 564
        '
        'VslName
        '
        Me.VslName.Caption = "Vessel"
        Me.VslName.FieldName = "VslName"
        Me.VslName.Name = "VslName"
        Me.VslName.Visible = True
        Me.VslName.Width = 393
        '
        'PlannedDateSON
        '
        Me.PlannedDateSON.Caption = "Plan Date Sign-on"
        Me.PlannedDateSON.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.PlannedDateSON.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PlannedDateSON.FieldName = "PlannedDateSON"
        Me.PlannedDateSON.Name = "PlannedDateSON"
        Me.PlannedDateSON.Visible = True
        Me.PlannedDateSON.Width = 328
        '
        'colCrewWithTravel
        '
        Me.colCrewWithTravel.Caption = "With Travel Event"
        Me.colCrewWithTravel.FieldName = "CrewWithTravel"
        Me.colCrewWithTravel.Name = "colCrewWithTravel"
        Me.colCrewWithTravel.Width = 296
        '
        'colCrewOnbCount
        '
        Me.colCrewOnbCount.Caption = "Crew Onboard"
        Me.colCrewOnbCount.FieldName = "CrewOnbCount"
        Me.colCrewOnbCount.Name = "colCrewOnbCount"
        Me.colCrewOnbCount.Width = 256
        '
        'colDateCreated
        '
        Me.colDateCreated.Caption = "Date Created"
        Me.colDateCreated.Name = "colDateCreated"
        '
        'colTravelEvent
        '
        Me.colTravelEvent.Caption = "Travel Event"
        Me.colTravelEvent.Name = "colTravelEvent"
        '
        'colChecklist
        '
        Me.colChecklist.Caption = "Checklist"
        Me.colChecklist.Name = "colChecklist"
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Plan Event Status"
        Me.BandedGridColumn1.FieldName = "PlanStatus"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'PlanningList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Controls.Add(Me.Maingrid)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "PlanningList"
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents colPlanningID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colEventName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDateCreated As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTravelEvent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colChecklist As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCrewOnbCount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCrewWithTravel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PlannedDateSON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gbPlanningList As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents VslName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
