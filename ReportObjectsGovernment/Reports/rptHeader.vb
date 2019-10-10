
Public Class rptHeader
    Dim picpath As String, compadress As String, telfax As String

    Private Sub XrPictureBox1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBox1.BeforePrint
        ' Me.XrPictureBox1.Image = New System.Drawing.Bitmap(Trim(MPSDB.GetConfig("LOGOPATH")))
        'Me.XrPictureBox1.Image = New System.Drawing.Bitmap("\\server\drv_z\Test Image\SOUTHERN MARITIME LOGO.jpg")
        If IO.File.Exists(picpath) Then
            Me.XrPictureBox1.Image = New System.Drawing.Bitmap(picpath)
        End If
    End Sub

    Private Sub txtCompAddress_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtCompAddress.BeforePrint
        Me.txtCompAddress.Text = compadress
    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        picpath = Trim(MPSDB.GetConfig("LOGOPATH"))
        compadress = Trim(MPSDB.GetConfig("ADDR"))
        telfax = "Tel. " & Trim(MPSDB.GetConfig("PHONE")) & " Fax " & Trim(MPSDB.GetConfig("TELEFAX")) & _
                 " E-mail:" & Trim(MPSDB.GetConfig("EMAIL"))

    End Sub

    Private Sub txtTelFax_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtTelFax.BeforePrint
        Me.txtTelFax.Text = telfax
    End Sub
End Class