Public Class rptHeader
    Public Sub New(rptParent As DevExpress.XtraReports.UI.XtraReport)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Landscape = rptParent.Landscape
        Me.PaperKind = rptParent.PaperKind
        Me.PageWidth = rptParent.PageWidth - (rptParent.Margins.Left + rptParent.Margins.Right)

        Me.celCompanyName.Text = MPS4.MPSDB.GetConfig("Name")
        Me.celAddress.Text = MPS4.MPSDB.GetConfig("Addr")
        Me.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        Me.pbLogo.Image = MPS4.MPS4BasicFunctions.GetLogo
        Me.XrTableDate.Visible = False
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
        InitializeComponent()
    End Sub

End Class