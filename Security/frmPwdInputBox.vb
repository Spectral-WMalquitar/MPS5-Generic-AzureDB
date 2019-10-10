Public Class frmPwdInputBox 

    Private sPassword As String = String.Empty

    Private _txtPwd As String = String.Empty
    Public Property Password() As String
        Get
            Return _txtPwd
        End Get
        Set(ByVal value As String)
            _txtPwd = value
        End Set
    End Property

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        If Not IfNull(txtPassword.EditValue, "").Equals(sPassword) Then
            txtPassword.Focus()
            txtPassword.SelectAll()
            MsgBox("Invalid Password", MsgBoxStyle.Critical, GetAppName)
        Else
            Password = txtPassword.EditValue
            Me.Close()
        End If

    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Public Sub New(strPassword As String)
        ' This call is required by the designer.
        InitializeComponent()
        sPassword = strPassword
        ' Add any initialization after the InitializeComponent() call.
        LayoutControlItem1.Text = "Current User's(" & USER_NAME & ") Password:"
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyValue = System.Windows.Forms.Keys.Enter Then
            cmdOk_Click(sender, e)
        End If
    End Sub
End Class