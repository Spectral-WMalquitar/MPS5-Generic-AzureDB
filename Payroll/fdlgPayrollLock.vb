Public Class fdlgPayrollLock
    Private DB As SQLDB

    Private PKey As String = String.Empty
    Private MCode As Integer
    Private FKeyVsl As String = String.Empty
    Private Paytype As String = String.Empty
    Private isLocked As Boolean
    Private PayrollType As String = String.Empty
    Private PrincipalName As String = String.Empty
    Private Vesselname As String = String.Empty
    Private Remarks As String = String.Empty


    Public Sub New(_DB As SQLDB, PayRow As DataRowView, _PayrollType As String)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        LayoutControl1.AllowCustomization = False
        DB = _DB
        PayrollType = _PayrollType
        PKey = IfNull(PayRow("PKey"), "")
        MCode = IfNull(PayRow("MCode"), 0)
        lblPeriod.Text = IfNull(PayRow("Period"), String.Empty)
        lblVsl.Text = IfNull(PayRow("AdmVslName"), String.Empty)
        lvlRefNo.Text = IfNull(PayRow("RefNo"), String.Empty)
        isLocked = PayRow("isLocked")
        PrincipalName = IfNull(PayRow("PrinName"), String.Empty)
        Vesselname = IfNull(PayRow("VslName"), String.Empty)
        'Remarks = IfNull(PayRow(""), String.Empty)
        If isLocked Then
            Me.Text = "Unlock Payroll"
            lblDesc.Text = "Enter password to unlock payroll :"
            PictureEdit1.Image = Payroll.My.Resources.Unlock300x300
            Me.Icon = System.Drawing.Icon.FromHandle(Payroll.My.Resources.Unlock300x300.GetHicon())
            lciPasswordField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        Else
            Me.Text = "Lock Payroll"
            lblDesc.Text = "Do you want to Lock the selected payroll? Click OK to continue."
            PictureEdit1.Image = Payroll.My.Resources.Lock300x300
            Me.Icon = System.Drawing.Icon.FromHandle(Payroll.My.Resources.Lock300x300.GetHicon())
            txtPwd.Text = AES_Decrypt(DB.GetConfig(PAYROLL_UNLOCK_KEY), PAYROLL_UNLOCK_KEY)
            lciPasswordField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

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
        If strKey.Equals(txtPwd.Text) Then
            Select Case PayrollType
                Case "ONB", "HA"
                    info = DB.RunSql(" UPDATE dbo.tblPay SET [isLocked] = '" & (Not isLocked).ToString & "' WHERE PKey='" & PKey & "' AND Paytype= '" & PayrollType & "'")
                    'DB.SavePayrollLog(PKey, MCode, lvlRefNo.Text, PayrollType, PrincipalName, Vesselname, USER_ID, DateTime.Now, IIf(Not isLocked, GetLoctType(LockType.Locked), GetLoctType(LockType.Unlocked)), My.Computer.Name, "")
                    DB.SavePayrollLog(PKey, MCode, lvlRefNo.Text, PayrollType, PrincipalName, Vesselname, USER_ID, DateTime.Now, IIf(Not isLocked, LockType.Locked, LockType.Unlocked), My.Computer.Name, "")
                Case "MPO"
                    info = DB.RunSql(" UPDATE dbo.tblmpo SET [isLocked] =  '" & (Not isLocked).ToString & "' WHERE PKey ='" & PKey & "'")
                    'DB.SavePayrollLog(PKey, MCode, lvlRefNo.Text, PayrollType, PrincipalName, Vesselname, USER_ID, DateTime.Now, IIf(Not isLocked, GetLoctType(LockType.Locked), GetLoctType(LockType.Unlocked)), My.Computer.Name, "")
                    DB.SavePayrollLog(PKey, MCode, lvlRefNo.Text, PayrollType, PrincipalName, Vesselname, USER_ID, DateTime.Now, IIf(Not isLocked, LockType.Locked, LockType.Unlocked), My.Computer.Name, "")
            End Select
            If info Then
                If (isLocked) Then
                    MsgBox("Payroll is unlocked.", MsgBoxStyle.Information, GetAppName)
                Else
                    MsgBox("Payroll is locked.", MsgBoxStyle.Information, GetAppName)
                End If
                Me.Close()
            Else
                If (isLocked) Then
                    MsgBox("Unable to unlock payroll.", MsgBoxStyle.Information, GetAppName)
                Else
                    MsgBox("Unable to lock payroll.", MsgBoxStyle.Information, GetAppName)
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

    'moved to Utils.vb by tony
    'Private Enum LockType
    '    Locked
    '    Unlocked
    '    BankExport
    'End Enum

    'Private Function GetLoctType(Type As LockType) As String
    '    Select Case Type
    '        Case LockType.Locked
    '            Return 1
    '        Case LockType.Unlocked
    '            Return 2
    '        Case LockType.BankExport
    '            Return 3
    '        Case Else
    '            Return Nothing
    '    End Select
    'End Function
End Class