Public Class frmValidateByAdministrator

    Public Success As Boolean = False
    Public Canceled As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Canceled = False
        Success = False

    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Success = txtPassword.EditValue.Equals(sysMpsUserPassword("DECRYPT", MPSDB.DLookUp("Password", "MSysSec_Users", "", "Name = '" & txtUsername.EditValue & "'")))
        If Success Then
            Me.Close()
        Else
            MsgBox("Invalid Administrator password", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Canceled = True
        Me.Close()
    End Sub
End Class