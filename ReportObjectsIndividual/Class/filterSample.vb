Public Class filterSample

    Dim repVsl As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        InitControls()
    End Sub

    Sub InitControls()
        Dim _userfilterstring = MPS4.MPS4DataSources.GetUserFilterString(, , "FKeyFlt", "FKeyPrincipal")
        cboVessel.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tbladmvsl " & _
                                           IIf(_userfilterstring.Length > 0, "WHERE " & _userfilterstring, "") & _
                                           "ORDER BY Name")

    End Sub

    Private Sub cboVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVessel.EditValueChanged
        ApplyFilterToPrintSelectionByFieldName("FKeyVsl", "FKeyVsl = '" & cboVessel.EditValue & "'")
    End Sub
End Class
