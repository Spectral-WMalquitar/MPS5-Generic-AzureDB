<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopUpDeleteCrew
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPopUpDeleteCrew))
        Me.lblDelMsg1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdContinue = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCrewName = New DevExpress.XtraEditors.LabelControl()
        Me.lblDelMsg2 = New DevExpress.XtraEditors.LabelControl()
        Me.chkExtractFiles = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.CrewPhoto = New DevExpress.XtraEditors.PictureEdit()
        Me.PictureEdit2 = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.chkExtractFiles.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewPhoto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDelMsg1
        '
        Me.lblDelMsg1.Location = New System.Drawing.Point(190, 40)
        Me.lblDelMsg1.Name = "lblDelMsg1"
        Me.lblDelMsg1.Size = New System.Drawing.Size(243, 16)
        Me.lblDelMsg1.TabIndex = 1
        Me.lblDelMsg1.Text = "You are about to DELETE record of crew : "
        '
        'cmdContinue
        '
        Me.cmdContinue.Location = New System.Drawing.Point(254, 229)
        Me.cmdContinue.Name = "cmdContinue"
        Me.cmdContinue.Size = New System.Drawing.Size(112, 40)
        Me.cmdContinue.TabIndex = 2
        Me.cmdContinue.Text = "CONTINUE"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(390, 229)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 40)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "CANCEL"
        '
        'lblCrewName
        '
        Me.lblCrewName.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCrewName.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.lblCrewName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblCrewName.Location = New System.Drawing.Point(190, 71)
        Me.lblCrewName.Name = "lblCrewName"
        Me.lblCrewName.Size = New System.Drawing.Size(371, 18)
        Me.lblCrewName.TabIndex = 4
        Me.lblCrewName.Text = "_____________________________________"
        '
        'lblDelMsg2
        '
        Me.lblDelMsg2.Location = New System.Drawing.Point(175, 207)
        Me.lblDelMsg2.Name = "lblDelMsg2"
        Me.lblDelMsg2.Size = New System.Drawing.Size(258, 16)
        Me.lblDelMsg2.TabIndex = 5
        Me.lblDelMsg2.Text = "(The crew has related files and sea services)"
        Me.lblDelMsg2.Visible = False
        '
        'chkExtractFiles
        '
        Me.chkExtractFiles.Location = New System.Drawing.Point(175, 181)
        Me.chkExtractFiles.Name = "chkExtractFiles"
        Me.chkExtractFiles.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Italic)
        Me.chkExtractFiles.Properties.Appearance.Options.UseFont = True
        Me.chkExtractFiles.Properties.Caption = "Extract scanned documents/images before deletion"
        Me.chkExtractFiles.Size = New System.Drawing.Size(339, 20)
        Me.chkExtractFiles.TabIndex = 6
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(175, 124)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(377, 16)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "By clicking CONTINUE all the crew's record will be deleted in MPS."
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(175, 146)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(171, 16)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "This procedure is irreversible."
        '
        'CrewPhoto
        '
        Me.CrewPhoto.Location = New System.Drawing.Point(571, 58)
        Me.CrewPhoto.Name = "CrewPhoto"
        Me.CrewPhoto.Properties.NullText = "No biodata photo "
        Me.CrewPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.CrewPhoto.Size = New System.Drawing.Size(168, 143)
        Me.CrewPhoto.TabIndex = 12
        '
        'PictureEdit2
        '
        Me.PictureEdit2.EditValue = CType(resources.GetObject("PictureEdit2.EditValue"), Object)
        Me.PictureEdit2.Location = New System.Drawing.Point(12, 58)
        Me.PictureEdit2.Name = "PictureEdit2"
        Me.PictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PictureEdit2.Size = New System.Drawing.Size(147, 143)
        Me.PictureEdit2.TabIndex = 13
        '
        'frmPopUpDeleteCrew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 296)
        Me.Controls.Add(Me.PictureEdit2)
        Me.Controls.Add(Me.CrewPhoto)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.chkExtractFiles)
        Me.Controls.Add(Me.lblDelMsg2)
        Me.Controls.Add(Me.lblCrewName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdContinue)
        Me.Controls.Add(Me.lblDelMsg1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPopUpDeleteCrew"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "[APPLICATION NAME]"
        CType(Me.chkExtractFiles.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewPhoto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDelMsg1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdContinue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblCrewName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDelMsg2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkExtractFiles As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CrewPhoto As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PictureEdit2 As DevExpress.XtraEditors.PictureEdit
End Class
