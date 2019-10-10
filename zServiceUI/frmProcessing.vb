Public Class frmProcessing
    Public Sub New(Optional ByVal cLabel As String = "Please wait. THis may take a while...", Optional ByVal cTitle As String = "Processing")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblCurr.Text = cLabel
        Me.Text = cTitle
    End Sub
End Class