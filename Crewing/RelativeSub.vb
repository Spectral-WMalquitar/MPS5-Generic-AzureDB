'Imports DevExpress.XtraGrid.Views.Grid
Public Class RelativeSub
    Inherits EditFormUserControl
    Private strID As String = ""

    Public Sub New(_strID As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call
        Me.LayoutControl1.AllowCustomization = False
        Me.cboCntry.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM CntryList ORDER BY Name ASC")
        Me.cboSex.Properties.DataSource = GetSex()
        Me.cboRel.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmRel ORDER BY Name ASC")
        strID = _strID
    End Sub

    'Use Seamans Address
    Private Sub CheckEdit3_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles CheckEdit3.CheckStateChanged
        Dim strCrewAddr As String = ""
        Dim strCrewCntry As String = ""
        If CheckEdit3.Checked Then
            strCrewAddr = MPSDB.DLookUp("Addr", "CrewAddrList", "", "FKeyIDNbr='" & strID & "' AND AddrStat=1")
            strCrewCntry = MPSDB.DLookUp("FKeyCntry", "CrewAddrList", "", "FKeyIDNbr='" & strID & "' AND AddrStat=1")

            If strCrewAddr.Equals("") Then
                MsgBox("No Active Crew Address.", MsgBoxStyle.Information, GetAppName())
                Me.txtAddr.EditValue = System.DBNull.Value
                Me.cboCntry.EditValue = System.DBNull.Value
                CheckEdit3.EditValue = False
            Else
                Me.txtAddr.EditValue = strCrewAddr
                Me.cboCntry.EditValue = strCrewCntry
                CheckEdit3.EditValue = True
            End If

        Else
            Me.txtAddr.EditValue = System.DBNull.Value
            Me.cboCntry.EditValue = System.DBNull.Value
            CheckEdit3.EditValue = False
        End If

    End Sub

    Private Sub Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRel.Properties.ButtonClick, cboSex.Properties.ButtonClick, cboCntry.Properties.ButtonClick, txtDOB.Properties.ButtonClick
        If sender.ReadOnly = False And e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            sender.Focus()
            sender.ClosePopup()
            sender.EditValue = Nothing
        End If
    End Sub

End Class
