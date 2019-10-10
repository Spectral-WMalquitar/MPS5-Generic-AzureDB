Imports DevExpress.XtraReports.UI

Public Class rptAppraisalReport_Indi


    'Select Case True
    '       Case occassion.Equals("6 Months")
    '           chk6Months.Checked = True
    '       Case occassion.Equals("Special Request")
    '           chkSpecialRequest.Checked = True
    '       Case occassion.Equals("Signing Off")
    '           chkSigningOff.Checked = True
    '       Case occassion.Equals("Dismissal")
    '           chkDismissal.Checked = True
    '   End Select

    Private Sub chk6Months_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chk6Months.BeforePrint
        If txtOccasionReport.Text = "6 Months" Then
            Me.chk6Months.Checked = True
        Else
            Me.chk6Months.Checked = False
        End If
    End Sub

    Private Sub chkSpecialRequest_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkSpecialRequest.BeforePrint
        If txtOccasionReport.Text = "Special Request" Then
            Me.chkSpecialRequest.Checked = True
        Else
            Me.chkSpecialRequest.Checked = False
        End If
    End Sub

    Private Sub chkSigningOff_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkSigningOff.BeforePrint
        If txtOccasionReport.Text = "Signing Off" Then
            Me.chkSigningOff.Checked = True
        Else
            Me.chkSigningOff.Checked = False
        End If
    End Sub

    Private Sub chkDismissal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkDismissal.BeforePrint
        If txtOccasionReport.Text = "6 Months" Then
            Me.chkDismissal.Checked = True
        Else
            Me.chkDismissal.Checked = False
        End If
    End Sub

    Private Sub chkReemployedYes_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkReemployedYes.BeforePrint
        If Me.txtReemployed.Text = "True" Then
            chkReemployedYes.Checked = True
        Else
            chkReemployedYes.Checked = False
        End If
    End Sub

    Private Sub chkReemployedNo_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkReemployedNo.BeforePrint
        If Me.txtReemployed.Text = "False" Then
            chkReemployedNo.Checked = True
        Else
            chkReemployedNo.Checked = False
        End If
    End Sub

    Private Sub chkPromotionYes_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkPromotionYes.BeforePrint
        If Me.txtPromotion.Text = "True" Then
            chkPromotionYes.Checked = True
        Else
            chkPromotionYes.Checked = False
        End If
    End Sub

    Private Sub chkPromotionNo_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkPromotionNo.BeforePrint
        If Me.txtPromotion.Text = "False" Then
            chkPromotionNo.Checked = True
        Else
            chkPromotionNo.Checked = False
        End If
    End Sub

    Private Sub chkSailAgainYes_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkSailAgainYes.BeforePrint
        If Me.txtSailAgain.Text = "True" Then
            chkSailAgainYes.Checked = True
        Else
            chkSailAgainYes.Checked = False
        End If
    End Sub

    Private Sub chkSailAgainNo_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkSailAgainNo.BeforePrint
        If Me.txtSailAgain.Text = "False" Then
            chkSailAgainNo.Checked = True
        Else
            chkSailAgainNo.Checked = False
        End If
    End Sub

    Private Sub chkReemploymentYes_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkReemploymentYes.BeforePrint
        If Me.txtReemployment.Text = "True" Then
            chkReemploymentYes.Checked = True
        Else
            chkReemploymentYes.Checked = False
        End If
    End Sub

    Private Sub chkReemploymentNo_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkReemploymentNo.BeforePrint
        If Me.txtReemployment.Text = "False" Then
            chkReemploymentNo.Checked = True
        Else
            chkReemploymentNo.Checked = False
        End If
    End Sub

    Private Sub chkPromoteYes_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkPromoteYes.BeforePrint
        If Me.txtPromote.Text = "True" Then
            chkPromoteYes.Checked = True
        Else
            chkPromoteYes.Checked = False
        End If
    End Sub

    Private Sub chkPromoteNo_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkPromoteNo.BeforePrint
        If Me.txtPromote.Text = "False" Then
            chkPromoteNo.Checked = True
        Else
            chkPromoteNo.Checked = False
        End If
    End Sub
End Class