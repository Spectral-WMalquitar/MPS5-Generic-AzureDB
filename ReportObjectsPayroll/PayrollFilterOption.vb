Imports System.Windows.Forms

Public Class PayrollFilterOption

    'Private reportGroup As String = "" 'commented out by tony20170302

    Private Sub PayrollFilterOption_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'reportGroup = MyBase.FilterOptionsParam.ToString.Split(";").GetValue(1).ToString.ToUpper   'commented out by tony20170302
        Select Case reportGroup
            Case "ONBOARD PAYROLL"
                reportGroup = "ONB"
            Case "HOME ALLOTMENT PAYROLL"
                reportGroup = "HA"
            Case "SPECIAL ALLOTMENT PAYROLL"
                reportGroup = "SA"
        End Select

        Period.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM (SELECT CAST(MCode AS varchar) AS MCode, FORMAT(dbo.ChangeMCodeToDate(MCode,1), 'MMMM-yyyy') AS Period FROM tblPay WHERE PayType='" & reportGroup & "') dt GROUP BY MCode, Period ORDER BY MCode DESC")
        Principal.Enabled = False
        Vessel.Enabled = False
        RefNo.Enabled = False

    End Sub

    Private Sub Period_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles Period.EditValueChanged
        Principal.EditValue = Nothing
        Vessel.EditValue = Nothing
        RefNo.EditValue = Nothing
        If Not IsNothing(Period.EditValue) Then
            Principal.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM (SELECT p.FKeyPrincipal AS PKey, a.Name FROM tblPay p INNER JOIN tblAdmCompany a ON p.FKeyPrincipal = a.PKey WHERE p.MCode='" & Period.EditValue & "' AND p.PayType='" & reportGroup & "') dt GROUP BY PKey, Name ORDER BY Name")
            Vessel.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM (SELECT p.FKeyVsl AS PKey, a.Name FROM tblPay p INNER JOIN tblAdmVsl a ON p.FKeyVsl = a.PKey WHERE p.MCode='" & Period.EditValue & "' AND p.PayType='" & reportGroup & "') dt GROUP BY PKey, Name ORDER BY Name")
            RefNo.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM (SELECT p.PKey AS PKey, p.RefNo + ' - ' + a.Name AS Name FROM tblPay p INNER JOIN tblAdmVsl a ON p.FKeyVsl = a.PKey WHERE p.MCode='" & Period.EditValue & "' AND p.PayType='" & reportGroup & "') dt GROUP BY PKey, Name ORDER BY Name")
            Principal.Enabled = True
            Vessel.Enabled = True
            RefNo.Enabled = True
        Else
            Principal.Properties.DataSource = Nothing
            Vessel.Properties.DataSource = Nothing
            RefNo.Properties.DataSource = Nothing
            Principal.Enabled = False
            Vessel.Enabled = False
            RefNo.Enabled = False
        End If
    End Sub

    Private Sub Principal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles Principal.EditValueChanged
        Vessel.EditValue = Nothing
        RefNo.EditValue = Nothing
        If Not IsNothing(Principal.EditValue) Then
            Vessel.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM (SELECT p.FKeyVsl AS PKey, a.Name FROM tblPay p INNER JOIN tblAdmVsl a ON p.FKeyVsl = a.PKey WHERE p.MCode='" & Period.EditValue & "' AND p.FKeyPrincipal='" & Principal.EditValue & "' AND p.PayType='" & reportGroup & "') dt GROUP BY PKey, Name ORDER BY Name")
            Vessel_EditValueChanged(sender, e)
        End If
    End Sub

    Private Sub Vessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles Vessel.EditValueChanged
        RefNo.EditValue = Nothing
        If Not IsNothing(Vessel.EditValue) And Not IsNothing(Principal.EditValue) Then
            RefNo.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM (SELECT p.PKey AS PKey, p.RefNo + ' - ' + a.Name AS Name FROM tblPay p INNER JOIN tblAdmVsl a ON p.FKeyVsl = a.PKey WHERE p.MCode='" & Period.EditValue & "' AND p.FKeyPrincipal='" & Principal.EditValue & "' AND p.FKeyVsl='" & Vessel.EditValue & "' AND p.PayType='" & reportGroup & "') dt GROUP BY PKey, Name ORDER BY Name")
        ElseIf Not IsNothing(Vessel.EditValue) Then
            RefNo.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM (SELECT p.PKey AS PKey, p.RefNo + ' - ' + a.Name AS Name FROM tblPay p INNER JOIN tblAdmVsl a ON p.FKeyVsl = a.PKey WHERE p.MCode='" & Period.EditValue & "' AND p.FKeyVsl='" & Vessel.EditValue & "' AND p.PayType='" & reportGroup & "') dt GROUP BY PKey, Name ORDER BY Name")
        ElseIf Not IsNothing(Principal.EditValue) Then
            RefNo.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM (SELECT p.PKey AS PKey, p.RefNo + ' - ' + a.Name AS Name FROM tblPay p INNER JOIN tblAdmVsl a ON p.FKeyVsl = a.PKey WHERE p.MCode='" & Period.EditValue & "' AND p.FKeyPrincipal='" & Principal.EditValue & "' AND p.PayType='" & reportGroup & "') dt GROUP BY PKey, Name ORDER BY Name")
        End If
    End Sub

    Private Sub Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Period.Properties.ButtonClick, Principal.Properties.ButtonClick, Vessel.Properties.ButtonClick, RefNo.Properties.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class

