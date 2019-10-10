<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFeatureID
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
        Me.txtObjFeatID = New DevExpress.XtraEditors.TextEdit()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.lkuObjects = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lkuFeature = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.chkListFeature = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCompanyID = New DevExpress.XtraEditors.TextEdit()
        Me.mmoCompanyFeatID = New DevExpress.XtraEditors.MemoEdit()
        Me.cmdGenCoyFeatures = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.btnShowObjectsList = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtObjFeatID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuObjects.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.lkuFeature.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.chkListFeature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mmoCompanyFeatID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtObjFeatID
        '
        Me.txtObjFeatID.Location = New System.Drawing.Point(104, 65)
        Me.txtObjFeatID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtObjFeatID.Name = "txtObjFeatID"
        Me.txtObjFeatID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.txtObjFeatID.Size = New System.Drawing.Size(503, 24)
        Me.txtObjFeatID.TabIndex = 2
        '
        'cmdSave
        '
        Me.cmdSave.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdSave.Appearance.Options.UseFont = True
        Me.cmdSave.Location = New System.Drawing.Point(615, 23)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(100, 69)
        Me.cmdSave.TabIndex = 3
        Me.cmdSave.Text = "Generate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "&&" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Save"
        Me.cmdSave.ToolTip = "Generate ID and auto update data on database"
        '
        'lkuObjects
        '
        Me.lkuObjects.Location = New System.Drawing.Point(104, 23)
        Me.lkuObjects.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lkuObjects.Name = "lkuObjects"
        Me.lkuObjects.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkuObjects.Properties.DisplayMember = "ObjectID"
        Me.lkuObjects.Properties.NullText = ""
        Me.lkuObjects.Properties.ValueMember = "ObjectID"
        Me.lkuObjects.Size = New System.Drawing.Size(199, 22)
        Me.lkuObjects.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnShowObjectsList)
        Me.GroupBox1.Controls.Add(Me.lkuFeature)
        Me.GroupBox1.Controls.Add(Me.LabelControl3)
        Me.GroupBox1.Controls.Add(Me.LabelControl2)
        Me.GroupBox1.Controls.Add(Me.LabelControl1)
        Me.GroupBox1.Controls.Add(Me.txtObjFeatID)
        Me.GroupBox1.Controls.Add(Me.lkuObjects)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(723, 116)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generate Feature ID for Object"
        '
        'lkuFeature
        '
        Me.lkuFeature.Location = New System.Drawing.Point(415, 23)
        Me.lkuFeature.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lkuFeature.Name = "lkuFeature"
        Me.lkuFeature.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkuFeature.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Feature", "Feature"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuFeature.Properties.DisplayMember = "Feature"
        Me.lkuFeature.Properties.NullText = ""
        Me.lkuFeature.Properties.ShowHeader = False
        Me.lkuFeature.Properties.ValueMember = "Value"
        Me.lkuFeature.Size = New System.Drawing.Size(192, 22)
        Me.lkuFeature.TabIndex = 8
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(8, 70)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(75, 16)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Generated ID"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(335, 27)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 16)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Feature"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 27)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 16)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Objects"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SimpleButton3)
        Me.GroupBox2.Controls.Add(Me.SimpleButton2)
        Me.GroupBox2.Controls.Add(Me.SimpleButton1)
        Me.GroupBox2.Controls.Add(Me.chkListFeature)
        Me.GroupBox2.Controls.Add(Me.LabelControl6)
        Me.GroupBox2.Controls.Add(Me.txtCompanyID)
        Me.GroupBox2.Controls.Add(Me.mmoCompanyFeatID)
        Me.GroupBox2.Controls.Add(Me.cmdGenCoyFeatures)
        Me.GroupBox2.Controls.Add(Me.LabelControl5)
        Me.GroupBox2.Controls.Add(Me.LabelControl4)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 138)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(723, 319)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generate Company Feature ID"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(11, 117)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(51, 20)
        Me.SimpleButton3.TabIndex = 17
        Me.SimpleButton3.Text = "SimpleButton3"
        Me.SimpleButton3.Visible = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Location = New System.Drawing.Point(615, 171)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(100, 59)
        Me.SimpleButton2.TabIndex = 16
        Me.SimpleButton2.Text = "Test/Decrypt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ID"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.Red
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(615, 238)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(100, 59)
        Me.SimpleButton1.TabIndex = 15
        Me.SimpleButton1.Text = "Generate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "All"
        Me.SimpleButton1.Visible = False
        '
        'chkListFeature
        '
        Me.chkListFeature.Location = New System.Drawing.Point(113, 71)
        Me.chkListFeature.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkListFeature.Name = "chkListFeature"
        Me.chkListFeature.Size = New System.Drawing.Size(199, 229)
        Me.chkListFeature.TabIndex = 14
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(335, 71)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(75, 16)
        Me.LabelControl6.TabIndex = 13
        Me.LabelControl6.Text = "Generated ID"
        '
        'txtCompanyID
        '
        Me.txtCompanyID.Location = New System.Drawing.Point(113, 32)
        Me.txtCompanyID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCompanyID.Name = "txtCompanyID"
        Me.txtCompanyID.Size = New System.Drawing.Size(493, 22)
        Me.txtCompanyID.TabIndex = 12
        Me.txtCompanyID.ToolTip = "Enter ID. Get from our Company list"
        '
        'mmoCompanyFeatID
        '
        Me.mmoCompanyFeatID.Location = New System.Drawing.Point(335, 91)
        Me.mmoCompanyFeatID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.mmoCompanyFeatID.Name = "mmoCompanyFeatID"
        Me.mmoCompanyFeatID.Size = New System.Drawing.Size(272, 206)
        Me.mmoCompanyFeatID.TabIndex = 11
        '
        'cmdGenCoyFeatures
        '
        Me.cmdGenCoyFeatures.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdGenCoyFeatures.Appearance.Options.UseFont = True
        Me.cmdGenCoyFeatures.Location = New System.Drawing.Point(615, 92)
        Me.cmdGenCoyFeatures.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdGenCoyFeatures.Name = "cmdGenCoyFeatures"
        Me.cmdGenCoyFeatures.Size = New System.Drawing.Size(100, 71)
        Me.cmdGenCoyFeatures.TabIndex = 10
        Me.cmdGenCoyFeatures.Text = "Generate"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(8, 36)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(69, 16)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Company ID"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 71)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(67, 16)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Feature List"
        '
        'btnShowObjectsList
        '
        Me.btnShowObjectsList.Location = New System.Drawing.Point(615, 92)
        Me.btnShowObjectsList.Name = "btnShowObjectsList"
        Me.btnShowObjectsList.Size = New System.Drawing.Size(100, 23)
        Me.btnShowObjectsList.TabIndex = 9
        Me.btnShowObjectsList.Text = "Show as List"
        '
        'frmFeatureID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 476)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmFeatureID"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate Feature ID"
        CType(Me.txtObjFeatID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuObjects.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.lkuFeature.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.chkListFeature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mmoCompanyFeatID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtObjFeatID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lkuObjects As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCompanyID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents mmoCompanyFeatID As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cmdGenCoyFeatures As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkListFeature As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents lkuFeature As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnShowObjectsList As DevExpress.XtraEditors.SimpleButton
End Class
