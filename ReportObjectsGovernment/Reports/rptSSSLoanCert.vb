Public Class rptSSSLoanCert

    Private Sub txtParagraph_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtParagraph.BeforePrint
        'Me.txtParagraph.Text = "	This is to certify that Mr. " & MPSDB.GetConfig("NAME") & " with SSS No. " & MPSDB.GetConfig("SSSNBR") & " " & _
        '          "has remitted the following SSS Contribution for MR. " & UCase(Me.txtCrew.Text) & ", one of our " & _
        '          "crewmembers, with SSS No. " & Me.txtCrewSSSNo.Text & "." ' who was onboard the Vessel ELIXIR from 2/13/2016 " & _
        '"to 8/31/2016."

    End Sub

    Private Sub txtFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtFooter.BeforePrint
        Me.txtFooter.Text = " This certification is being issued upon the request of Mr. " & Me.txtCrewLName.Text & " for whatever purpose it " & _
                            "may serve. "
    End Sub

    Private Sub txtPeriodCoveMMYYYY_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtPeriodCoveMMYYYY.BeforePrint
        Me.txtPeriodCoveMMYYYY.Text = MonthName(Me.txtPeriodCover.Text - ((Me.txtPeriodCover.Text \ 100) * 100), True) & _
                         "-" & Me.txtPeriodCover.Text \ 100
    End Sub

    Private Sub txtCrewName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtCrewName.BeforePrint
        Me.txtCrewName.Text = UCase(Me.txtCrew.Text)
    End Sub

    Private Sub txtSSSNo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtSSSNo.BeforePrint
        Me.txtSSSNo.Text = Me.txtCrewSSSNo.Text
    End Sub
End Class