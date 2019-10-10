<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocViewer_Add
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
        Me.lblCrewName = New DevExpress.XtraEditors.LabelControl()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.picThumbnail = New DevExpress.XtraEditors.PictureEdit()
        Me.lblFilePath = New DevExpress.XtraEditors.LabelControl()
        Me.cmdLink = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDocType = New DevExpress.XtraEditors.LabelControl()
        Me.lblIssueDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblFileName = New DevExpress.XtraEditors.LabelControl()
        CType(Me.picThumbnail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCrewName
        '
        Me.lblCrewName.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrewName.Location = New System.Drawing.Point(12, 12)
        Me.lblCrewName.Name = "lblCrewName"
        Me.lblCrewName.Size = New System.Drawing.Size(138, 19)
        Me.lblCrewName.TabIndex = 0
        Me.lblCrewName.Text = "Crew Name Here"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(227, 100)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 38)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        '
        'picThumbnail
        '
        Me.picThumbnail.Location = New System.Drawing.Point(12, 37)
        Me.picThumbnail.Name = "picThumbnail"
        Me.picThumbnail.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picThumbnail.Properties.Appearance.Options.UseBackColor = True
        Me.picThumbnail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.picThumbnail.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.picThumbnail.Size = New System.Drawing.Size(128, 101)
        Me.picThumbnail.TabIndex = 3
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblFilePath.Location = New System.Drawing.Point(12, 152)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(309, 14)
        Me.lblFilePath.TabIndex = 4
        Me.lblFilePath.Text = "....."
        '
        'cmdLink
        '
        Me.cmdLink.Location = New System.Drawing.Point(146, 100)
        Me.cmdLink.Name = "cmdLink"
        Me.cmdLink.Size = New System.Drawing.Size(75, 38)
        Me.cmdLink.TabIndex = 2
        Me.cmdLink.Text = "Link"
        '
        'lblDocType
        '
        Me.lblDocType.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDocType.Location = New System.Drawing.Point(146, 37)
        Me.lblDocType.Name = "lblDocType"
        Me.lblDocType.Size = New System.Drawing.Size(113, 14)
        Me.lblDocType.TabIndex = 4
        Me.lblDocType.Text = "[Document Type]"
        '
        'lblIssueDate
        '
        Me.lblIssueDate.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssueDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.lblIssueDate.Location = New System.Drawing.Point(146, 57)
        Me.lblIssueDate.Name = "lblIssueDate"
        Me.lblIssueDate.Size = New System.Drawing.Size(70, 16)
        Me.lblIssueDate.TabIndex = 4
        Me.lblIssueDate.Text = "[Issue Date]"
        '
        'lblFileName
        '
        Me.lblFileName.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileName.Location = New System.Drawing.Point(146, 78)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(63, 16)
        Me.lblFileName.TabIndex = 5
        Me.lblFileName.Text = "[FileName]"
        '
        'DocViewer_Add
        '
        Me.AllowDrop = True
        Me.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 178)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.lblIssueDate)
        Me.Controls.Add(Me.lblDocType)
        Me.Controls.Add(Me.lblFilePath)
        Me.Controls.Add(Me.picThumbnail)
        Me.Controls.Add(Me.cmdLink)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblCrewName)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(346, 202)
        Me.MinimizeBox = False
        Me.Name = "DocViewer_Add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Drop file here."
        CType(Me.picThumbnail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picThumbnail As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblFilePath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdLink As DevExpress.XtraEditors.SimpleButton
    Public WithEvents lblCrewName As DevExpress.XtraEditors.LabelControl
    Public WithEvents lblDocType As DevExpress.XtraEditors.LabelControl
    Public WithEvents lblIssueDate As DevExpress.XtraEditors.LabelControl
    Public WithEvents lblFileName As DevExpress.XtraEditors.LabelControl
End Class
