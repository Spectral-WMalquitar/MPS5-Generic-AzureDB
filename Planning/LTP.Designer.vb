<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LTP
    Inherits BaseControl.BaseControl

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LTP))
        Dim TimeScaleYear1 As DevExpress.XtraScheduler.TimeScaleYear = New DevExpress.XtraScheduler.TimeScaleYear()
        Dim TimeScaleQuarter1 As DevExpress.XtraScheduler.TimeScaleQuarter = New DevExpress.XtraScheduler.TimeScaleQuarter()
        Dim TimeScaleMonth1 As DevExpress.XtraScheduler.TimeScaleMonth = New DevExpress.XtraScheduler.TimeScaleMonth()
        Dim TimeScaleWeek1 As DevExpress.XtraScheduler.TimeScaleWeek = New DevExpress.XtraScheduler.TimeScaleWeek()
        Dim TimeScaleDay1 As DevExpress.XtraScheduler.TimeScaleDay = New DevExpress.XtraScheduler.TimeScaleDay()
        Dim TimeScaleHour1 As DevExpress.XtraScheduler.TimeScaleHour = New DevExpress.XtraScheduler.TimeScaleHour()
        Dim TimeScale15Minutes1 As DevExpress.XtraScheduler.TimeScale15Minutes = New DevExpress.XtraScheduler.TimeScale15Minutes()
        Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeScaleYear2 As DevExpress.XtraScheduler.TimeScaleYear = New DevExpress.XtraScheduler.TimeScaleYear()
        Dim TimeScaleQuarter2 As DevExpress.XtraScheduler.TimeScaleQuarter = New DevExpress.XtraScheduler.TimeScaleQuarter()
        Dim TimeScaleMonth2 As DevExpress.XtraScheduler.TimeScaleMonth = New DevExpress.XtraScheduler.TimeScaleMonth()
        Dim TimeScaleWeek2 As DevExpress.XtraScheduler.TimeScaleWeek = New DevExpress.XtraScheduler.TimeScaleWeek()
        Dim TimeScaleDay2 As DevExpress.XtraScheduler.TimeScaleDay = New DevExpress.XtraScheduler.TimeScaleDay()
        Dim TimeScaleHour2 As DevExpress.XtraScheduler.TimeScaleHour = New DevExpress.XtraScheduler.TimeScaleHour()
        Dim TimeScale15Minutes2 As DevExpress.XtraScheduler.TimeScale15Minutes = New DevExpress.XtraScheduler.TimeScale15Minutes()
        Dim TimeRuler3 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Me.SchedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
        Me.SchedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ResourcesTree1 = New DevExpress.XtraScheduler.UI.ResourcesTree()
        Me.colCaption = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
        Me.colRankCount = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.SimpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.colAbbrv = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.ResourcesTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageCollection
        '
        Me.ImageCollection.ImageSize = New System.Drawing.Size(12, 12)
        Me.ImageCollection.ImageStream = CType(resources.GetObject("ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection.Images.SetKeyName(0, "lacking.png")
        Me.ImageCollection.Images.SetKeyName(1, "warning-icon.png")
        Me.ImageCollection.Images.SetKeyName(2, "exclamation-sign-16.png")
        '
        'SchedulerControl1
        '
        Me.SchedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Gantt
        Me.SchedulerControl1.BackColor = System.Drawing.Color.White
        Me.SchedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SchedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
        Me.SchedulerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SchedulerControl1.Name = "SchedulerControl1"
        Me.SchedulerControl1.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl1.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl1.OptionsCustomization.AllowAppointmentMultiSelect = False
        Me.SchedulerControl1.OptionsCustomization.AllowDisplayAppointmentDependencyForm = DevExpress.XtraScheduler.AllowDisplayAppointmentDependencyForm.Never
        Me.SchedulerControl1.OptionsCustomization.AllowDisplayAppointmentForm = DevExpress.XtraScheduler.AllowDisplayAppointmentForm.Never
        Me.SchedulerControl1.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl1.OptionsRangeControl.AllowChangeActiveView = False
        Me.SchedulerControl1.OptionsRangeControl.MaxIntervalWidth = 50
        Me.SchedulerControl1.OptionsRangeControl.MinIntervalWidth = 10
        TimeScaleQuarter1.Enabled = False
        TimeScaleWeek1.Enabled = False
        TimeScaleDay1.Enabled = False
        TimeScaleDay1.Width = 5
        TimeScaleHour1.Enabled = False
        TimeScale15Minutes1.Enabled = False
        Me.SchedulerControl1.OptionsRangeControl.Scales.Add(TimeScaleYear1)
        Me.SchedulerControl1.OptionsRangeControl.Scales.Add(TimeScaleQuarter1)
        Me.SchedulerControl1.OptionsRangeControl.Scales.Add(TimeScaleMonth1)
        Me.SchedulerControl1.OptionsRangeControl.Scales.Add(TimeScaleWeek1)
        Me.SchedulerControl1.OptionsRangeControl.Scales.Add(TimeScaleDay1)
        Me.SchedulerControl1.OptionsRangeControl.Scales.Add(TimeScaleHour1)
        Me.SchedulerControl1.OptionsRangeControl.Scales.Add(TimeScale15Minutes1)
        Me.SchedulerControl1.OptionsView.ShowOnlyResourceAppointments = True
        Me.SchedulerControl1.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Never
        Me.SchedulerControl1.Size = New System.Drawing.Size(1215, 677)
        Me.SchedulerControl1.Start = New Date(2016, 1, 1, 0, 0, 0, 0)
        Me.SchedulerControl1.Storage = Me.SchedulerStorage1
        Me.SchedulerControl1.TabIndex = 0
        Me.SchedulerControl1.Text = "SchedulerControl1"
        Me.SchedulerControl1.ToolTipController = Me.ToolTipController1
        Me.SchedulerControl1.Views.DayView.Enabled = False
        Me.SchedulerControl1.Views.DayView.TimeRulers.Add(TimeRuler1)
        Me.SchedulerControl1.Views.FullWeekView.TimeRulers.Add(TimeRuler2)
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.BackColor = System.Drawing.Color.Red
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.BackColor2 = System.Drawing.Color.Red
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.BorderColor = System.Drawing.Color.Red
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.ForeColor = System.Drawing.Color.Red
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.Options.UseBackColor = True
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.Options.UseBorderColor = True
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.Options.UseFont = True
        Me.SchedulerControl1.Views.GanttView.Appearance.Dependency.Options.UseForeColor = True
        Me.SchedulerControl1.Views.GanttView.Appearance.SelectedDependency.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SchedulerControl1.Views.GanttView.Appearance.SelectedDependency.Options.UseFont = True
        Me.SchedulerControl1.Views.GanttView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never
        Me.SchedulerControl1.Views.GanttView.AppointmentDisplayOptions.ShowRecurrence = False
        Me.SchedulerControl1.Views.GanttView.AppointmentDisplayOptions.ShowReminder = False
        Me.SchedulerControl1.Views.GanttView.AppointmentDisplayOptions.SnapToCellsMode = DevExpress.XtraScheduler.AppointmentSnapToCellsMode.Never
        Me.SchedulerControl1.Views.GanttView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never
        Me.SchedulerControl1.Views.GanttView.AppointmentDisplayOptions.TimeDisplayType = DevExpress.XtraScheduler.AppointmentTimeDisplayType.Text
        Me.SchedulerControl1.Views.GanttView.CellsAutoHeightOptions.Enabled = True
        Me.SchedulerControl1.Views.GanttView.ResourcesPerPage = 5
        TimeScaleQuarter2.Enabled = False
        TimeScaleQuarter2.Visible = False
        TimeScaleWeek2.Enabled = False
        TimeScaleWeek2.Visible = False
        TimeScaleDay2.DisplayFormat = "dd"
        TimeScaleDay2.Enabled = False
        TimeScaleDay2.Visible = False
        TimeScaleDay2.Width = 4
        TimeScaleHour2.Enabled = False
        TimeScaleHour2.Visible = False
        TimeScale15Minutes2.Enabled = False
        TimeScale15Minutes2.Visible = False
        Me.SchedulerControl1.Views.GanttView.Scales.Add(TimeScaleYear2)
        Me.SchedulerControl1.Views.GanttView.Scales.Add(TimeScaleQuarter2)
        Me.SchedulerControl1.Views.GanttView.Scales.Add(TimeScaleMonth2)
        Me.SchedulerControl1.Views.GanttView.Scales.Add(TimeScaleWeek2)
        Me.SchedulerControl1.Views.GanttView.Scales.Add(TimeScaleDay2)
        Me.SchedulerControl1.Views.GanttView.Scales.Add(TimeScaleHour2)
        Me.SchedulerControl1.Views.GanttView.Scales.Add(TimeScale15Minutes2)
        Me.SchedulerControl1.Views.GanttView.SelectionBar.Visible = False
        Me.SchedulerControl1.Views.MonthView.Enabled = False
        Me.SchedulerControl1.Views.TimelineView.Enabled = False
        Me.SchedulerControl1.Views.WeekView.Enabled = False
        Me.SchedulerControl1.Views.WorkWeekView.Enabled = False
        Me.SchedulerControl1.Views.WorkWeekView.TimeRulers.Add(TimeRuler3)
        '
        'SchedulerStorage1
        '
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SplitContainerControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(522, 140, 463, 402)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1398, 681)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ResourcesTree1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SchedulerControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1394, 677)
        Me.SplitContainerControl1.SplitterPosition = 174
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ResourcesTree1
        '
        Me.ResourcesTree1.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.ResourcesTree1.Appearance.Row.Options.UseBackColor = True
        Me.ResourcesTree1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colCaption, Me.colAbbrv, Me.colRankCount})
        Me.ResourcesTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResourcesTree1.Location = New System.Drawing.Point(0, 0)
        Me.ResourcesTree1.Name = "ResourcesTree1"
        Me.ResourcesTree1.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.ResourcesTree1.OptionsBehavior.Editable = False
        Me.ResourcesTree1.SchedulerControl = Me.SchedulerControl1
        Me.ResourcesTree1.Size = New System.Drawing.Size(174, 677)
        Me.ResourcesTree1.TabIndex = 0
        Me.ResourcesTree1.VertScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Never
        '
        'colCaption
        '
        Me.colCaption.Caption = "Rank"
        Me.colCaption.FieldName = "Name"
        Me.colCaption.Name = "colCaption"
        Me.colCaption.OptionsColumn.AllowSort = False
        Me.colCaption.Visible = True
        Me.colCaption.VisibleIndex = 0
        Me.colCaption.Width = 117
        '
        'colRankCount
        '
        Me.colRankCount.AppearanceHeader.Options.UseTextOptions = True
        Me.colRankCount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colRankCount.Caption = "Crew Needed"
        Me.colRankCount.FieldName = "RankCount"
        Me.colRankCount.MinWidth = 55
        Me.colRankCount.Name = "colRankCount"
        Me.colRankCount.OptionsColumn.AllowSort = False
        Me.colRankCount.OptionsColumn.FixedWidth = True
        Me.colRankCount.Width = 55
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1398, 681)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.SplitContainerControl1
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(54, 27)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(1398, 681)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(0, 0)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleLabelItem1
        '
        Me.SimpleLabelItem1.AllowHotTrack = False
        Me.SimpleLabelItem1.Location = New System.Drawing.Point(223, 0)
        Me.SimpleLabelItem1.Name = "SimpleLabelItem1"
        Me.SimpleLabelItem1.Size = New System.Drawing.Size(519, 20)
        Me.SimpleLabelItem1.TextSize = New System.Drawing.Size(80, 16)
        '
        'colAbbrv
        '
        Me.colAbbrv.Caption = "Abbrv"
        Me.colAbbrv.FieldName = "Abbrv"
        Me.colAbbrv.Name = "colAbbrv"
        '
        'LTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "LTP"
        Me.Size = New System.Drawing.Size(1398, 681)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.ResourcesTree1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SchedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
    Friend WithEvents SchedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
    Friend WithEvents ResourcesTree1 As DevExpress.XtraScheduler.UI.ResourcesTree
    Friend WithEvents colCaption As DevExpress.XtraScheduler.Native.ResourceTreeColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents colRankCount As DevExpress.XtraScheduler.Native.ResourceTreeColumn
    Friend WithEvents SimpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Private WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colAbbrv As DevExpress.XtraScheduler.Native.ResourceTreeColumn

End Class