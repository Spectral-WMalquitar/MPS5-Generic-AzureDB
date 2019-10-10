Public Class fdlgPayrollLock_Multiple
    Private DB As SQLDB

    Private Paytype As String = String.Empty
    Private isLocked As Boolean
    Private PayrollType As String = String.Empty
    Private Remarks As String = String.Empty

    Private PayList As New List(Of PayrollRecord)

    Public Structure PayrollRecord
        Public PKey As String
        Public MCode As Integer
        Public VesselName As String
        Public RefNo As String
        Public PrincipalName As String
    End Structure


    Public Sub New(_DB As SQLDB, _PayList As List(Of PayrollRecord), _PayrollType As String, mode As frmPayrollList.MultipleSelectionType)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        LayoutControl1.AllowCustomization = False
        DB = _DB
        PayrollType = _PayrollType
        PayList = _PayList
        If mode = frmPayrollList.MultipleSelectionType.Unlock Then
            Me.Text = "Unlock Payroll"
            lblDesc.Text = "Enter password to unlock payroll(s) :"
            PictureEdit1.Image = Payroll.My.Resources.Unlock300x300
            Me.Icon = System.Drawing.Icon.FromHandle(Payroll.My.Resources.Unlock300x300.GetHicon())
            lciPasswordField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            isLocked = True
        ElseIf mode = frmPayrollList.MultipleSelectionType.Lock Then
            Me.Text = "Lock Payroll"
            lblDesc.Text = "Do you want to Lock the selected payroll(s)?"
            lblDesc2.Text = "Click OK to continue."
            PictureEdit1.Image = Payroll.My.Resources.Lock300x300
            Me.Icon = System.Drawing.Icon.FromHandle(Payroll.My.Resources.Lock300x300.GetHicon())
            txtPwd.Text = AES_Decrypt(DB.GetConfig(PAYROLL_UNLOCK_KEY), PAYROLL_UNLOCK_KEY)
            lciPasswordField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            isLocked = False
        Else
            Me.Text = "Invalid mode"
            lblDesc.Text = "Invalid form initialization mode"
            PictureEdit1.Image = Nothing
            Me.Icon = System.Drawing.Icon.FromHandle(Payroll.My.Resources.Lock300x300.GetHicon())
            cmdOK.Visible = False

        End If

    End Sub
    'cancel Button
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    'Okay Button
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        LockUnlockPayroll()
    End Sub

    Private Sub LockUnlockPayroll()

        Dim strKey As String = IIf(DB.GetConfig(PAYROLL_UNLOCK_KEY).Trim.Length > 0, DB.GetConfig(PAYROLL_UNLOCK_KEY), DEFAULT_PASSWORD)
        If strKey.Equals(DEFAULT_PASSWORD) Then
            MsgBox("Please set a Password For Payroll Lock in the Admin", MsgBoxStyle.Information, GetAppName)
            Exit Sub
        Else
            strKey = AES_Decrypt(IfNull(DB.GetConfig(PAYROLL_UNLOCK_KEY), DEFAULT_PASSWORD), PAYROLL_UNLOCK_KEY)
        End If

        Dim info As Boolean = False
        Dim sqls As New ArrayList
        If strKey.Equals(txtPwd.Text) Then
            Select Case PayrollType
                Case "ONB", "HA"
                    For Each rec As PayrollRecord In PayList
                        sqls.Add(" UPDATE dbo.tblPay SET [isLocked] = '" & (Not isLocked).ToString & "' WHERE PKey='" & rec.PKey & "' AND Paytype= '" & PayrollType & "'")
                        DB.SavePayrollLog(rec.PKey, rec.MCode, rec.RefNo, PayrollType, rec.PrincipalName, rec.VesselName, USER_ID, DateTime.Now, IIf(Not isLocked, LockType.Locked, LockType.Unlocked), My.Computer.Name, "")
                    Next

                    info = DB.RunSqls(sqls)
                Case "MPO"
                    For Each rec As PayrollRecord In PayList
                        sqls.Add(" UPDATE dbo.tblmpo SET [isLocked] =  '" & (Not isLocked).ToString & "' WHERE PKey ='" & rec.PKey & "'")
                        DB.SavePayrollLog(rec.PKey, rec.MCode, rec.RefNo, PayrollType, rec.PrincipalName, rec.VesselName, USER_ID, DateTime.Now, IIf(Not isLocked, LockType.Locked, LockType.Unlocked), My.Computer.Name, "")
                    Next
                    info = DB.RunSqls(sqls)

            End Select
            If info Then
                If (isLocked) Then
                    MsgBox("Payroll(s) are unlocked.", MsgBoxStyle.Information, GetAppName)
                Else
                    MsgBox("Payroll(s) are locked.", MsgBoxStyle.Information, GetAppName)
                End If
                Me.Close()
            Else
                If (isLocked) Then
                    MsgBox("Unable to unlock payroll(s).", MsgBoxStyle.Information, GetAppName)
                Else
                    MsgBox("Unable to lock payroll(s).", MsgBoxStyle.Information, GetAppName)
                End If
            End If
        Else
            MsgBox("Invalid Password.", MsgBoxStyle.Exclamation, GetAppName)
            txtPwd.Focus()
            txtPwd.SelectAll()
        End If


    End Sub

    Private Sub txtPwd_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPwd.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Windows.Forms.Keys.Enter) Then
            LockUnlockPayroll()
        End If
    End Sub
End Class