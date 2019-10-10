Imports Utilities
Imports System.Windows.Forms
Imports System.IO

Public Class frmBDOParam
    Public _Password As String
    Public _ExportPath As String
    Public Canceled As Boolean = False

    Dim _config As New Config("Code = '" & BDO.BDOInfoFields.FixedPassword & "' OR " & _
                              "Code = '" & BDO.BDOInfoFields.UseFixedPassword & "'")

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        If IfNull(txtPassword.EditValue, "").Equals("") Then
            MsgBox("Enter a valid password.", MsgBoxStyle.Information)
            txtPassword.Focus()
            Exit Sub
        End If

        If IfNull(txtExportPath.EditValue, "").Equals("") Then
            MsgBox("Please enter a valid destination path.", MsgBoxStyle.Information)
            txtExportPath.Focus()
            Exit Sub
        End If

        If Not Directory.Exists(txtExportPath.EditValue) Then
            MsgBox("The destination path you specifided does not exist. Please select a valid path.", MsgBoxStyle.Exclamation)
            txtExportPath.Focus()
            Exit Sub
        End If

        _Password = txtPassword.EditValue
        _ExportPath = txtExportPath.EditValue

        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _ExportPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        txtExportPath.EditValue = _ExportPath

        SetUpPasswordField()

        'txtPassword.Focus()
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim oFolderBrowserDialog As New FolderBrowserDialog
        If (oFolderBrowserDialog.ShowDialog() = DialogResult.OK) Then
            _ExportPath = oFolderBrowserDialog.SelectedPath
            txtExportPath.EditValue = _ExportPath
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Canceled = True
        MsgBox("Canceled by User.")
        Me.Close()
    End Sub

    Sub SetUpPasswordField()
        If _config.HasValue(BDO.BDOInfoFields.UseFixedPassword) And _config.HasValue(BDO.BDOInfoFields.FixedPassword) Then
            With txtPassword
                .EditValue = _config.GetValue(BDO.BDOInfoFields.FixedPassword)
                .Properties.PasswordChar = "*"
                .ReadOnly = True
            End With
            LayoutControlGroupPwd.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            With txtPassword
                txtPassword.Properties.PasswordChar = ""
                .ReadOnly = False
            End With
            LayoutControlGroupPwd.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub
End Class