Imports DevExpress.XtraGrid

Public Class AdmBDORemittance

    Dim _config As New Config("Code IN (" & _
                              "'" & BDO.BDOInfoFields.TieUpCode & "', " & _
                              "'" & BDO.BDOInfoFields.BatchNo & "', " & _
                              "'" & BDO.BDOInfoFields.LocatorCode & "', " & _
                              "'" & BDO.BDOInfoFields.UseFixedPassword & "', " & _
                              "'" & BDO.BDOInfoFields.FixedPassword & "')")

    Dim NextBatchNo As Integer

    Dim _ExportPath As String = ""

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()

        _config.Refresh()

        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)

        AllowSaving(Name, True)

        'Tie-up Short Code
        txtShortCode.EditValue = _config.GetValue(BDO.BDOInfoFields.TieUpCode)

        'Locator Code
        txtLocatorCode.EditValue = _config.GetValue(BDO.BDOInfoFields.LocatorCode)

        'Next Batch No
        Dim tmpNextBatchNo As String = _config.GetValue(BDO.BDOInfoFields.BatchNo)
        If IfNull(tmpNextBatchNo, "").Equals("") Then
            NextBatchNo = 1
        ElseIf Not IsNumeric(tmpNextBatchNo) Then
            NextBatchNo = 1
        Else
            NextBatchNo = CInt(tmpNextBatchNo)
        End If
        txtNextBatchNo.EditValue = BDO.ChangeNumToBatchNo(NextBatchNo)

        'Password
        If _config.HasValue(BDO.BDOInfoFields.UseFixedPassword) Then
            If _config.GetValue(BDO.BDOInfoFields.UseFixedPassword) = "1" Then
                If _config.HasValue(BDO.BDOInfoFields.FixedPassword) Then
                    If Not IfNull(_config.GetValue(BDO.BDOInfoFields.FixedPassword), "").Equals("") Then
                        chkUseFixedPassword.Checked = 1
                        txtFixedPassword.EditValue = _config.GetValue(BDO.BDOInfoFields.FixedPassword)
                        GoTo AFTER_SET_PASSWORD
                    End If
                End If
            End If
        End If

        chkUseCustomPassword.Checked = 2
        txtFixedPassword.EditValue = System.DBNull.Value

AFTER_SET_PASSWORD:

        'Bank Code Grid
        Dim dt As DataTable
        dt = New DataTable
        dt = MPSDB.CreateTable("SELECT cast(0 as bit) as Edited, * FROM dbo.tbladmBDOBankTable ORDER BY BankCode")
        MainGrid.DataSource = dt

        'Grid Repositories
        dt = New DataTable
        dt = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmBank ORDER BY Name")
        repBank.DataSource = dt

        If Not bLoaded Then
            Dim editorButton As New DevExpress.XtraEditors.Controls.EditorButton
            editorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear
            editorButton.Caption = "CLEAR"
            repBank.Buttons.Add(editorButton)
            AddHandler repBank.ButtonClick, AddressOf BankCell_ButtonClick

            bLoaded = True
        End If
        

    End Sub

    Public Overrides Sub SaveData()
        Me.header.Focus()
        MyBase.SaveData()
        Dim info As Boolean = False, sqls As New ArrayList

        If chkUseFixedPassword.Checked Then
            If IfNull(txtFixedPassword.EditValue, "").Equals("") Then
                MsgBox("Unable to save. Use Fixed Password option is selected but no Fixed Password is provided.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        If MainView.HasColumnErrors Then
            MsgBox("Unable to save. There are errors in the Bank Code assignment.", MsgBoxStyle.Information)
            Exit Sub
        End If

        _config.Refresh()

        _config.SaveValue(BDO.BDOInfoFields.TieUpCode, txtShortCode.EditValue)
        _config.SaveValue(BDO.BDOInfoFields.LocatorCode, txtLocatorCode.EditValue)
        _config.SaveValue(BDO.BDOInfoFields.BatchNo, NextBatchNo)
        If chkUseFixedPassword.Checked Then
            _config.SaveValue(BDO.BDOInfoFields.UseFixedPassword, 1)
            _config.SaveValue(BDO.BDOInfoFields.FixedPassword, txtFixedPassword.EditValue)
        Else
            _config.SaveValue(BDO.BDOInfoFields.UseFixedPassword, 0)
            _config.SaveValue(BDO.BDOInfoFields.FixedPassword, "")
        End If

        With MainView
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    sqls.Add("UPDATE dbo.tbladmbdobanktable SET FKeyBank = " & IIf(IfNull(.GetRowCellValue(i, "FKeyBank"), "").Equals(""), "NULL", "'" & .GetRowCellValue(i, "FKeyBank") & "'") & " WHERE BankCode = '" & .GetRowCellValue(i, "BankCode") & "'")
                End If
            Next
        End With

        info = MPSDB.RunSqls(sqls)
        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
        RefreshData()
    End Sub

    Sub UpdPasswordField()
        txtFixedPassword.Enabled = chkUseFixedPassword.Checked
    End Sub

    Private Sub chkUseFixedPassword_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUseFixedPassword.CheckedChanged
        UpdPasswordField()
    End Sub

    Private Sub chkUseCustomPassword_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkUseCustomPassword.CheckedChanged
        UpdPasswordField()
    End Sub

    Private Sub cmdResetBatchNo_Click(sender As System.Object, e As System.EventArgs) Handles cmdResetBatchNo.Click
        NextBatchNo = 1
        txtNextBatchNo.EditValue = BDO.ChangeNumToBatchNo(NextBatchNo)
    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Marks Actitive the Document if newly Added
        If e.Column.FieldName.ToString <> "Edited" Then
            view.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub MainView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        AllowSaving(Name, False)
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.Column.FieldName.ToString = "FKeyBank" Then
            e.Appearance.BackColor = REQUIRED_COLOR
        End If
    End Sub

    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
        Dim view As Views.Grid.GridView = CType(sender, Views.Grid.GridView)
        Dim cellValue As String = IfNull(view.GetRowCellValue(e.RowHandle, "FKeyBank"), "")

        If cellValue.Length > 0 Then
            Dim dt As DataTable = TryCast(MainGrid.DataSource, DataTable)
            Dim foundrows As DataRow() = dt.Select("BankCode <> '" & view.GetRowCellValue(e.RowHandle, "BankCode") & "' AND FKeyBank = '" & view.GetRowCellValue(e.RowHandle, "FKeyBank") & "'")
            If foundrows.Length > 0 Then
                view.GetDataRow(e.RowHandle).SetColumnError("FKeyBank", "You cannot select Bank [" & view.GetRowCellDisplayText(e.RowHandle, "FKeyBank") & "] because it is already assigned to another Bank Code.")
                AllowSaving(Name, False)
                Exit Sub
            End If
        End If

        view.GetDataRow(e.RowHandle).ClearErrors()
        AllowSaving(Name, True)
    End Sub

    Private Sub repBank_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repBank.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            MainView.SetFocusedRowCellValue("FKeyBank", "")
        End If
    End Sub

    Private Sub BankCell_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            MainView.SetFocusedRowCellValue("FKeyBank", "")
            AllowSaving(Name, True)
        End If
    End Sub
End Class
