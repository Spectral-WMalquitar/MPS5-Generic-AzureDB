<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterControlDefault
    Inherits Reports.BaseFilterOption

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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridFilter = New DevExpress.XtraGrid.GridControl()
        Me.GridFilterView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FReportKeyFilterField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FCaption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.FDisplayValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FControlType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FRowSourceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FRowSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FRowSourceDisplayField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FRowSourceValueField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FComboBoxCustomRowSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FOperator = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FValueFieldType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FApplyToReportSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FisRowSourceHasUserDataFilter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FAgentFieldName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FPrinFieldName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FFleetFieldName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FVslFieldName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFilterView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridFilter)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
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
        Me.LayoutControl1.Size = New System.Drawing.Size(468, 393)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridFilter
        '
        Me.GridFilter.Location = New System.Drawing.Point(2, 2)
        Me.GridFilter.MainView = Me.GridFilterView
        Me.GridFilter.Name = "GridFilter"
        Me.GridFilter.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.repMemoEdit})
        Me.GridFilter.Size = New System.Drawing.Size(464, 389)
        Me.GridFilter.TabIndex = 4
        Me.GridFilter.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridFilterView})
        '
        'GridFilterView
        '
        Me.GridFilterView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FReportKeyFilterField, Me.FCaption, Me.FDisplayValue, Me.FValue, Me.FControlType, Me.FRowSourceType, Me.FRowSource, Me.FRowSourceDisplayField, Me.FRowSourceValueField, Me.FComboBoxCustomRowSource, Me.FOperator, Me.FValueFieldType, Me.FPKey, Me.FApplyToReportSource, Me.FisRowSourceHasUserDataFilter, Me.FAgentFieldName, Me.FPrinFieldName, Me.FFleetFieldName, Me.FVslFieldName})
        Me.GridFilterView.GridControl = Me.GridFilter
        Me.GridFilterView.Name = "GridFilterView"
        Me.GridFilterView.OptionsCustomization.AllowSort = False
        Me.GridFilterView.OptionsView.ShowGroupPanel = False
        Me.GridFilterView.OptionsView.ShowIndicator = False
        '
        'FReportKeyFilterField
        '
        Me.FReportKeyFilterField.Caption = "FieldName"
        Me.FReportKeyFilterField.FieldName = "ReportKeyFilterField"
        Me.FReportKeyFilterField.Name = "FReportKeyFilterField"
        Me.FReportKeyFilterField.OptionsColumn.AllowEdit = False
        Me.FReportKeyFilterField.OptionsColumn.AllowFocus = False
        Me.FReportKeyFilterField.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.FReportKeyFilterField.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.FReportKeyFilterField.OptionsColumn.AllowMove = False
        Me.FReportKeyFilterField.OptionsColumn.AllowShowHide = False
        Me.FReportKeyFilterField.OptionsColumn.AllowSize = False
        Me.FReportKeyFilterField.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.FReportKeyFilterField.OptionsColumn.FixedWidth = True
        Me.FReportKeyFilterField.OptionsColumn.ReadOnly = True
        '
        'FCaption
        '
        Me.FCaption.Caption = "Filter By"
        Me.FCaption.ColumnEdit = Me.repMemoEdit
        Me.FCaption.FieldName = "Caption"
        Me.FCaption.Name = "FCaption"
        Me.FCaption.OptionsColumn.AllowEdit = False
        Me.FCaption.OptionsColumn.AllowFocus = False
        Me.FCaption.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.FCaption.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.FCaption.OptionsColumn.AllowMove = False
        Me.FCaption.OptionsColumn.AllowShowHide = False
        Me.FCaption.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.FCaption.OptionsColumn.ReadOnly = True
        Me.FCaption.Visible = True
        Me.FCaption.VisibleIndex = 0
        '
        'repMemoEdit
        '
        Me.repMemoEdit.LinesCount = 4
        Me.repMemoEdit.Name = "repMemoEdit"
        '
        'FDisplayValue
        '
        Me.FDisplayValue.Caption = "Filter Value"
        Me.FDisplayValue.FieldName = "DisplayValue"
        Me.FDisplayValue.Name = "FDisplayValue"
        Me.FDisplayValue.Visible = True
        Me.FDisplayValue.VisibleIndex = 1
        '
        'FValue
        '
        Me.FValue.Caption = "Value"
        Me.FValue.FieldName = "Value"
        Me.FValue.Name = "FValue"
        Me.FValue.OptionsColumn.AllowMove = False
        Me.FValue.OptionsColumn.AllowShowHide = False
        Me.FValue.OptionsColumn.AllowSize = False
        Me.FValue.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.FValue.OptionsColumn.FixedWidth = True
        Me.FValue.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        '
        'FControlType
        '
        Me.FControlType.Caption = "ControlType"
        Me.FControlType.FieldName = "ControlType"
        Me.FControlType.Name = "FControlType"
        '
        'FRowSourceType
        '
        Me.FRowSourceType.Caption = "RowSourceType"
        Me.FRowSourceType.FieldName = "RowSourceType"
        Me.FRowSourceType.Name = "FRowSourceType"
        '
        'FRowSource
        '
        Me.FRowSource.Caption = "RowSource"
        Me.FRowSource.FieldName = "RowSource"
        Me.FRowSource.Name = "FRowSource"
        '
        'FRowSourceDisplayField
        '
        Me.FRowSourceDisplayField.Caption = "RowSourceDisplayField"
        Me.FRowSourceDisplayField.FieldName = "RowSourceDisplayField"
        Me.FRowSourceDisplayField.Name = "FRowSourceDisplayField"
        '
        'FRowSourceValueField
        '
        Me.FRowSourceValueField.Caption = "RowSourceValueField"
        Me.FRowSourceValueField.FieldName = "RowSourceValueField"
        Me.FRowSourceValueField.Name = "FRowSourceValueField"
        '
        'FComboBoxCustomRowSource
        '
        Me.FComboBoxCustomRowSource.Caption = "ComboBoxCustomRowSource"
        Me.FComboBoxCustomRowSource.FieldName = "ComboBoxCustomRowSource"
        Me.FComboBoxCustomRowSource.Name = "FComboBoxCustomRowSource"
        '
        'FOperator
        '
        Me.FOperator.Caption = "Operator"
        Me.FOperator.FieldName = "Operator"
        Me.FOperator.Name = "FOperator"
        '
        'FValueFieldType
        '
        Me.FValueFieldType.Caption = "ValueFieldType"
        Me.FValueFieldType.FieldName = "ValueFieldType"
        Me.FValueFieldType.Name = "FValueFieldType"
        '
        'FPKey
        '
        Me.FPKey.Caption = "PKey"
        Me.FPKey.FieldName = "PKey"
        Me.FPKey.Name = "FPKey"
        '
        'FApplyToReportSource
        '
        Me.FApplyToReportSource.Caption = "Apply To Report Source"
        Me.FApplyToReportSource.FieldName = "ApplyToReportSource"
        Me.FApplyToReportSource.Name = "FApplyToReportSource"
        '
        'FisRowSourceHasUserDataFilter
        '
        Me.FisRowSourceHasUserDataFilter.Caption = "isRowSourceHasUserDataFilter"
        Me.FisRowSourceHasUserDataFilter.FieldName = "isRowSourceHasUserDataFilter"
        Me.FisRowSourceHasUserDataFilter.Name = "FisRowSourceHasUserDataFilter"
        '
        'FAgentFieldName
        '
        Me.FAgentFieldName.Caption = "AgentFieldName"
        Me.FAgentFieldName.FieldName = "AgentFieldName"
        Me.FAgentFieldName.Name = "FAgentFieldName"
        '
        'FPrinFieldName
        '
        Me.FPrinFieldName.Caption = "PrinFieldName"
        Me.FPrinFieldName.FieldName = "PrinFieldName"
        Me.FPrinFieldName.Name = "FPrinFieldName"
        '
        'FFleetFieldName
        '
        Me.FFleetFieldName.Caption = "FleetFieldName"
        Me.FFleetFieldName.FieldName = "FleetFieldName"
        Me.FFleetFieldName.Name = "FFleetFieldName"
        '
        'FVslFieldName
        '
        Me.FVslFieldName.Caption = "VslFieldName"
        Me.FVslFieldName.FieldName = "VslFieldName"
        Me.FVslFieldName.Name = "FVslFieldName"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(468, 393)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridFilter
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(468, 393)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'FilterControlDefault
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FilterControlDefault"
        Me.Size = New System.Drawing.Size(468, 393)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFilterView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridFilter As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridFilterView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FReportKeyFilterField As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FCaption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FDisplayValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FControlType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FRowSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FRowSourceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FRowSourceDisplayField As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FRowSourceValueField As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FOperator As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FValueFieldType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FApplyToReportSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents FComboBoxCustomRowSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FisRowSourceHasUserDataFilter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FAgentFieldName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FPrinFieldName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FFleetFieldName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FVslFieldName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit

End Class
