Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports DevExpress.XtraExport.Xls
Imports DevExpress.XtraPrinting.Export.XLS
'Imports Microsoft.Office.Interop

Public Class CrewCashAdvance


    Private Sub InitControls()
        LayoutControl1.AllowCustomization = False

        cboVsl.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.VslList ORDER BY Name")
        cboPeriod.Properties.DataSource = GetPeriods()
        cboCAType.Properties.DataSource = DB.CreateTable("SELECT * From dbo.tblAdmWageOnb WHERE isCAType <> 0 ORDER BY Name")
        lciTotalAmount.Text = "Total Amount in " & GetRefCurrency(1)

        SetRibbonGroupToolVisibility(Name, False)

    End Sub

    Private Sub LoadSub()
        LoadCrewDetails()
        CAGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frm_Pay_Crew_Advances WHERE FKeyIDNbr= '" & strID & "'")
        CaclulateTotal(String.Empty)
    End Sub

    Private Sub LoadCrewDetails()
        txtCrewName.Text = IfNull(blList.GetFocusedRowData("LName"), "") & _
                ", " & IfNull(blList.GetFocusedRowData("FName"), "") & _
                " " & IfNull(blList.GetFocusedRowData("MName"), "")
        txtRankName.Text = IfNull(blList.GetFocusedRowData("RankName"), "")
        txtStatus.Text = IfNull(blList.GetFocusedRowData("StatName"), "")
        txtVessel.Text = IfNull(blList.GetFocusedRowData("VslName"), "")
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        SetEditOptionsVisibility(Name, False)
        SetRibbonGroupToolVisibility(Name, False)
        If Not bLoaded Then
            InitControls()
            bLoaded = True
        End If
        LoadSub()
        MakeReadOnlyListener(lcgCrewDetail)
        EditSubGrid(CAView, False)
    End Sub

    Private Sub CAView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CAView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub


#Region "Filter"

    Private Sub FilterCrewAdvances()
        Dim vslFtr As String = String.Empty, periodFtr As String = String.Empty, CATypeFtr As String = String.Empty
        Dim strFinalFtr As String = String.Empty

        If Not IsNothing(cboPeriod.EditValue) Then
            periodFtr = " Period = " & CInt(cboPeriod.EditValue)
        Else
            periodFtr = String.Empty
        End If

        If Not IsNothing(cboCAType.EditValue) Then
            CATypeFtr = " FKeyCAType = '" & cboCAType.EditValue & "'"
        Else
            CATypeFtr = String.Empty
        End If

        If Not IsNothing(cboVsl.EditValue) Then
            vslFtr = " FKeyVsl = '" & cboVsl.EditValue & "'"
        Else
            vslFtr = String.Empty
        End If

        If periodFtr.Trim.Length > 0 Then
            If vslFtr.Trim.Length > 0 Then
                If CATypeFtr.Trim.Length > 0 Then
                    strFinalFtr = periodFtr & " AND " & vslFtr & " AND " & CATypeFtr
                Else
                    strFinalFtr = periodFtr & " AND " & vslFtr
                End If
            Else
                If CATypeFtr.Trim.Length > 0 Then
                    strFinalFtr = periodFtr & " AND " & CATypeFtr
                Else
                    strFinalFtr = periodFtr
                End If
            End If
        Else
            If vslFtr.Trim.Length > 0 Then
                If CATypeFtr.Trim.Length > 0 Then
                    strFinalFtr = vslFtr & " AND " & CATypeFtr
                Else
                    strFinalFtr = vslFtr
                End If
            Else
                If CATypeFtr.Trim.Length > 0 Then
                    strFinalFtr = CATypeFtr
                Else
                    strFinalFtr = String.Empty
                End If
            End If
        End If
        CaclulateTotal(strFinalFtr)
        CAView.ActiveFilter.NonColumnFilter = strFinalFtr
    End Sub

    Private Sub CaclulateTotal(strFilter As String)
        'tEarn = tEarn + ConvertToRefAmt(Math.Round(IfNull(dt.Compute("SUM(CAmt)", "FKeyPayAllotID= '" & dr("PKey") & "' AND WageType = 1 AND WageRecID IS NULL AND FKeyWageAsh='SYSPAYALLOT' "), CDbl(0)), 2, MidpointRounding.AwayFromZero), dr("FKeyCurr"))

        txtTotal.Text = IfNull(Math.Round(IfNull(TryCast(CAGrid.DataSource, DataTable).Compute("SUM(CAmt)", strFilter), CDbl(0)), 2, MidpointRounding.AwayFromZero), CDbl(0))
    End Sub


    Private Sub cboPeriod_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriod.ButtonPressed
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        FilterCrewAdvances()
    End Sub

    Private Sub cboVsl_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboVsl.ButtonPressed
        ClearLookUpEdit(sender, e)

    End Sub

    Private Sub cboVsl_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVsl.EditValueChanged
        FilterCrewAdvances()
    End Sub

    Private Sub cboCAType_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboCAType.ButtonPressed
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboCAType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboCAType.EditValueChanged
        FilterCrewAdvances()
    End Sub


#End Region


End Class
