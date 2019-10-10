<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataPreviewDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataPreviewDialog))
        Me._grid = New System.Windows.Forms.DataGridView
        CType(Me._grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_grid
        '
        Me._grid.AllowUserToAddRows = False
        Me._grid.AllowUserToDeleteRows = False
        Me._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me._grid.Location = New System.Drawing.Point(0, 0)
        Me._grid.Margin = New System.Windows.Forms.Padding(2)
        Me._grid.Name = "_grid"
        Me._grid.ReadOnly = True
        Me._grid.RowTemplate.Height = 24
        Me._grid.Size = New System.Drawing.Size(462, 279)
        Me._grid.TabIndex = 1
        '
        'DataPreviewDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(462, 279)
        Me.Controls.Add(Me._grid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DataPreviewDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "{0} ({1:n0} records)"
        CType(Me._grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents _grid As System.Windows.Forms.DataGridView
End Class
