﻿Imports Utilities

Public Class frmPaySASummaryVslPS


    Public DB As New SQLDB(MPSDB.GetConnectionString)

    Public NoIssue As Boolean = True
    Dim tblVsl As New DataTable

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If IsNothing(Me.cboPeriodFrom.EditValue) Or IsNothing(Me.cboPeriodTo.EditValue) Or Me.cboPeriodFrom.EditValue.ToString = "" Or Me.cboPeriodTo.EditValue.ToString = "" Then
            MsgBox("Please select Periods", vbExclamation)
            NoIssue = False
        Else
            ' If Me.cboPeriodFrom.EditValue > 0 And Me.cboPeriodTo.EditValue > 0 Then
            'If Convert.ToInt32(Me.cboPeriodFrom.EditValue) > Convert.ToInt32(Me.cboPeriodTo.EditValue) Then
            If Me.cboPeriodFrom.EditValue > Me.cboPeriodTo.EditValue Then
                MsgBox("Selected periods are invalid")
                NoIssue = False
            Else
                NoIssue = True
            End If
        End If

        If NoIssue Then
            Me.Close()
        End If

        'neil c/out
        'If Me.cboPeriodFrom.EditValue > 0 And Me.cboPeriodTo.EditValue > 0 Then
        '    'If Convert.ToInt32(Me.cboPeriodFrom.EditValue) > Convert.ToInt32(Me.cboPeriodTo.EditValue) Then
        '    If Me.cboPeriodFrom.EditValue > Me.cboPeriodTo.EditValue Then
        '        MsgBox("Selected periods are invalid")
        '        NoIssue = False
        '    Else
        '        NoIssue = True
        '    End If

        'End If

        ''If NoIssue Then
        'Me.Close()
        ''End If
    End Sub

    Private Sub frmPaySASummaryVslPS_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cboPeriodFrom.Properties.DataSource = GetPayPeriods()
        cboPeriodTo.Properties.DataSource = GetPayPeriods()

        tblVsl = DB.CreateTable("SELECT * FROM dbo.VslList ORDER BY Name")
        cboVsl.Properties.DataSource = tblVsl
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        NoIssue = False
        Me.Close()
    End Sub

    Private Sub cboPeriodFrom_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriodFrom.ButtonClick

    End Sub

    Private Sub cboPeriodTo_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriodTo.ButtonClick

    End Sub

    Private Sub cboPeriodFrom_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriodFrom.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
        End If
    End Sub

    Private Sub cboPeriodTo_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriodTo.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
        End If
    End Sub

    Private Sub cboVsl_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboVsl.ButtonPressed
        Dim ctr As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ctr.EditValue = Nothing
        End If
    End Sub
End Class