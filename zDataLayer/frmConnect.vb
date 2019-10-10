Imports zDataLayer
Imports zUtil

Friend Class frmConnect
    Public oConn As connDetails
    Public nResult As Integer = 2 '0=fail, 1=success, 2=cancelled

    Public Sub New(ByVal oTmpConn As connDetails)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oConn = oTmpConn

    End Sub

    Private Sub frmConnect_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cboAuth.Properties.DataSource = GetAuth()
        txtServer.Text = oConn.Server
        txtUser.Text = oConn.User
        txtPwd.Text = oConn.Pwd
        cboAuth.EditValue = oConn.OtherOptions
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        nResult = 2
        Me.Close()
    End Sub

    Private Sub cmdTest_Click(sender As System.Object, e As System.EventArgs) Handles cmdTest.Click
        nResult = PerformTest()
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        nResult = PerformTest(True)
        If nResult = 0 Then
            MsgBox("Connection Failed. Cannot proceed.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Unable to proceed")
        Else
            Me.Close()
        End If
    End Sub

    Public Function PerformTest(Optional ByVal nSuppressMsg As Boolean = False) As Integer
        Dim nRetVal As Integer = 0
        Dim oDL As New DataLayer
        Dim cErr As String = ""

        oConn.Server = txtServer.Text
        oConn.User = txtUser.Text
        oConn.Pwd = txtPwd.Text
        oConn.OtherOptions = cboAuth.EditValue

        'initialize new instance connection for testing
        oDL.Init(oConn)
        If oDL.TestConn(cErr) Then
            If Not nSuppressMsg Then
                MsgBox("Test Success", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Test Connection Result")
            End If
            'set temp connection back to application connection
            nRetVal = 1
        Else
            If Not nSuppressMsg Then
                MsgBox("Test Failed" & vbCrLf & cErr, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Test Connection Result")
            End If
            nRetVal = 0
        End If
        oConn = oDL.GetConnDetailObject
        Return nRetVal
    End Function

    Private Sub cboAuth_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboAuth.EditValueChanged
        If cboAuth.EditValue = "SQLSERVER_AUTH" Then
            txtUser.Enabled = True
            txtPwd.Enabled = True
        Else
            txtUser.Text = ""
            txtPwd.Text = ""
            txtUser.Enabled = False
            txtPwd.Enabled = False
        End If
    End Sub
End Class