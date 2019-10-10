<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddFromPlanningEvent
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtPlannedDateSOn = New DevExpress.XtraEditors.DateEdit()
        Me.cboPlanningEvent = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAddPlanningEvent = New DevExpress.XtraEditors.SimpleButton()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLOCDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCrewID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.txtPlannedPlaceSOn = New DevExpress.XtraEditors.TextEdit()
        Me.txtVessel = New DevExpress.XtraEditors.TextEdit()
        Me.txtPlanningEvent = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciPlanningEvent = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciVessel = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPlannedPlaceSOn = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtPlannedDateSOn.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlannedDateSOn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPlanningEvent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlannedPlaceSOn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlanningEvent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPlanningEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPlannedPlaceSOn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtPlannedDateSOn)
        Me.LayoutControl1.Controls.Add(Me.cboPlanningEvent)
        Me.LayoutControl1.Controls.Add(Me.btnAddPlanningEvent)
        Me.LayoutControl1.Controls.Add(Me.MainGrid)
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
        Me.LayoutControl1.Controls.Add(Me.txtPlannedPlaceSOn)
        Me.LayoutControl1.Controls.Add(Me.txtVessel)
        Me.LayoutControl1.Controls.Add(Me.txtPlanningEvent)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(954, 192, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(966, 416)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtPlannedDateSOn
        '
        Me.txtPlannedDateSOn.EditValue = Nothing
        Me.txtPlannedDateSOn.Location = New System.Drawing.Point(172, 182)
        Me.txtPlannedDateSOn.Name = "txtPlannedDateSOn"
        Me.txtPlannedDateSOn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPlannedDateSOn.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPlannedDateSOn.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.txtPlannedDateSOn.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPlannedDateSOn.Size = New System.Drawing.Size(309, 22)
        Me.txtPlannedDateSOn.StyleController = Me.LayoutControl1
        Me.txtPlannedDateSOn.TabIndex = 16
        '
        'cboPlanningEvent
        '
        Me.cboPlanningEvent.Location = New System.Drawing.Point(172, 24)
        Me.cboPlanningEvent.Name = "cboPlanningEvent"
        Me.cboPlanningEvent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPlanningEvent.Properties.DisplayMember = "PlanningEventLabel"
        Me.cboPlanningEvent.Properties.NullText = ""
        Me.cboPlanningEvent.Properties.ValueMember = "PKey"
        Me.cboPlanningEvent.Properties.View = Me.SearchLookUpEdit1View
        Me.cboPlanningEvent.Size = New System.Drawing.Size(456, 22)
        Me.cboPlanningEvent.StyleController = Me.LayoutControl1
        Me.cboPlanningEvent.TabIndex = 15
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'btnAddPlanningEvent
        '
        Me.btnAddPlanningEvent.Location = New System.Drawing.Point(632, 24)
        Me.btnAddPlanningEvent.Name = "btnAddPlanningEvent"
        Me.btnAddPlanningEvent.Size = New System.Drawing.Size(310, 23)
        Me.btnAddPlanningEvent.StyleController = Me.LayoutControl1
        Me.btnAddPlanningEvent.TabIndex = 12
        Me.btnAddPlanningEvent.Text = "Select This Planning Event"
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(24, 253)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(918, 139)
        Me.MainGrid.TabIndex = 11
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCrewName, Me.colRank, Me.colLOC, Me.colLOCDays, Me.colCrewID})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'colCrewName
        '
        Me.colCrewName.Caption = "Crew"
        Me.colCrewName.FieldName = "CrewName"
        Me.colCrewName.Name = "colCrewName"
        Me.colCrewName.Visible = True
        Me.colCrewName.VisibleIndex = 0
        '
        'colRank
        '
        Me.colRank.Caption = "Rank"
        Me.colRank.FieldName = "Rank"
        Me.colRank.Name = "colRank"
        Me.colRank.Visible = True
        Me.colRank.VisibleIndex = 1
        '
        'colLOC
        '
        Me.colLOC.Caption = "LOC"
        Me.colLOC.FieldName = "LOC"
        Me.colLOC.Name = "colLOC"
        Me.colLOC.Visible = True
        Me.colLOC.VisibleIndex = 2
        '
        'colLOCDays
        '
        Me.colLOCDays.Caption = "LOC Days"
        Me.colLOCDays.FieldName = "LOCDays"
        Me.colLOCDays.Name = "colLOCDays"
        Me.colLOCDays.Visible = True
        Me.colLOCDays.VisibleIndex = 3
        '
        'colCrewID
        '
        Me.colCrewID.Caption = "CrewID"
        Me.colCrewID.FieldName = "CrewID"
        Me.colCrewID.Name = "colCrewID"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(485, 149)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(457, 81)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 10
        '
        'txtPlannedPlaceSOn
        '
        Me.txtPlannedPlaceSOn.Location = New System.Drawing.Point(172, 208)
        Me.txtPlannedPlaceSOn.Name = "txtPlannedPlaceSOn"
        Me.txtPlannedPlaceSOn.Size = New System.Drawing.Size(309, 22)
        Me.txtPlannedPlaceSOn.StyleController = Me.LayoutControl1
        Me.txtPlannedPlaceSOn.TabIndex = 9
        '
        'txtVessel
        '
        Me.txtVessel.Location = New System.Drawing.Point(172, 156)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(309, 22)
        Me.txtVessel.StyleController = Me.LayoutControl1
        Me.txtVessel.TabIndex = 6
        '
        'txtPlanningEvent
        '
        Me.txtPlanningEvent.Location = New System.Drawing.Point(172, 130)
        Me.txtPlanningEvent.Name = "txtPlanningEvent"
        Me.txtPlanningEvent.Size = New System.Drawing.Size(309, 22)
        Me.txtPlanningEvent.StyleController = Me.LayoutControl1
        Me.txtPlanningEvent.TabIndex = 5
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.EmptySpaceItem1, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(966, 416)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciPlanningEvent, Me.LayoutControlItem6, Me.lciVessel, Me.lciPlannedPlaceSOn, Me.LayoutControlItem7, Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(946, 312)
        Me.LayoutControlGroup2.Text = "Planning Event Details:"
        '
        'lciPlanningEvent
        '
        Me.lciPlanningEvent.Control = Me.txtPlanningEvent
        Me.lciPlanningEvent.Location = New System.Drawing.Point(0, 0)
        Me.lciPlanningEvent.Name = "lciPlanningEvent"
        Me.lciPlanningEvent.Size = New System.Drawing.Size(461, 26)
        Me.lciPlanningEvent.Text = "Planning Event:"
        Me.lciPlanningEvent.TextSize = New System.Drawing.Size(145, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtRemarks
        Me.LayoutControlItem6.Location = New System.Drawing.Point(461, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(461, 104)
        Me.LayoutControlItem6.Text = "Remarks:"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(145, 16)
        '
        'lciVessel
        '
        Me.lciVessel.Control = Me.txtVessel
        Me.lciVessel.Location = New System.Drawing.Point(0, 26)
        Me.lciVessel.Name = "lciVessel"
        Me.lciVessel.Size = New System.Drawing.Size(461, 26)
        Me.lciVessel.Text = "Vessel:"
        Me.lciVessel.TextSize = New System.Drawing.Size(145, 16)
        '
        'lciPlannedPlaceSOn
        '
        Me.lciPlannedPlaceSOn.Control = Me.txtPlannedPlaceSOn
        Me.lciPlannedPlaceSOn.Location = New System.Drawing.Point(0, 78)
        Me.lciPlannedPlaceSOn.Name = "lciPlannedPlaceSOn"
        Me.lciPlannedPlaceSOn.Size = New System.Drawing.Size(461, 26)
        Me.lciPlannedPlaceSOn.Text = "Planned Place Sign On:"
        Me.lciPlannedPlaceSOn.TextSize = New System.Drawing.Size(145, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem7.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem7.Control = Me.MainGrid
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(922, 162)
        Me.LayoutControlItem7.Text = "Planned Crew/s:"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(145, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtPlannedDateSOn
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(461, 26)
        Me.LayoutControlItem3.Text = "Planned Date Sign On:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(145, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnAddPlanningEvent
        Me.LayoutControlItem2.Location = New System.Drawing.Point(608, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(314, 27)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 51)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(946, 33)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboPlanningEvent
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(608, 27)
        Me.LayoutControlItem4.Text = "Choose a Planning Event:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(145, 16)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(946, 51)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'frmAddFromPlanningEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 416)
        Me.Controls.Add(Me.LayoutControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddFromPlanningEvent"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose a Planning Event"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtPlannedDateSOn.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlannedDateSOn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPlanningEvent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlannedPlaceSOn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlanningEvent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPlanningEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPlannedPlaceSOn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnAddPlanningEvent As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtPlannedPlaceSOn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtVessel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPlanningEvent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lciPlanningEvent As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciVessel As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciPlannedPlaceSOn As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colCrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboPlanningEvent As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colLOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLOCDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPlannedDateSOn As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colCrewID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
End Class
