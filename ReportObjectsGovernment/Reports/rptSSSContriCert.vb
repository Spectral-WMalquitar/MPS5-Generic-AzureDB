Public Class rptSSSContriCert

    Public Reason As String = ""

    Private Sub txtParagraph_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtParagraph.BeforePrint
        Me.txtParagraph.Text = "	This is to certify that " & MPSDB.GetConfig("NAME") & " with SSS No. " & MPSDB.GetConfig("SSSNBR") & " " & _
                  "has remitted the following SSS Contribution for MR. " & UCase(Me.txtCrew.Text) & ", one of our " & _
                  "crew members, with SSS No. " & Me.txtCrewSSSNo.Text & "." ' who was onboard the Vessel ELIXIR from 2/13/2016 " & _
        '"to 8/31/2016."
    End Sub


    Private Sub txtPeriodCoveMMYYYY_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtPeriodCoveMMYYYY.BeforePrint
        Me.txtPeriodCoveMMYYYY.Text = MonthName(Me.txtPeriodCover.Text - ((Me.txtPeriodCover.Text \ 100) * 100), True) & _
                         "-" & Me.txtPeriodCover.Text \ 100
    End Sub

    Private Sub lblFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles lblFooter.BeforePrint
        Me.lblFooter.Text = " This certification is being issued upon the request of Mr. " & Me.txtCrewLName.Text & " " & _
                            IIf(IfNull(Reason, "").Length = 0, "for whatever purpose it may serve. ", Reason & ".")
    End Sub
End Class