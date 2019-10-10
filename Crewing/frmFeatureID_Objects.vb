Public Class frmFeatureID_Objects

    Public Sub RefreshData()
        InitControls()
        LoadData()
    End Sub

    Private Sub InitControls()
        Dim dt As New DataTable
        Dim clsfeat As New clsFeatureMod

        dt = clsfeat.getFeaturelist()
        repFeature.DataSource = dt
        'repFeature.count

    End Sub

    Public Sub LoadData()
        Dim dt As DataTable = MPSDB.CreateTable("SELECT *, '' Feature, Cast(0 as bit) isEdited FROM dbo.tblobjects ORDER BY ObjectID")
        Dim temps As String, arr() As String, dectryptErrMsg = ""

        For Each row In dt.Rows
            If Not IsDBNull(row("FID")) Then
                temps = AES_Decrypt(row("FID"), "spectral", dectryptErrMsg)
                arr = temps.Split("_")
                Debug.Print(temps)
                If dectryptErrMsg = "" Then
                    'If Left(temps, temps.Length - 2) = Trim(row("ObjectID")) Then
                    If Microsoft.VisualBasic.Strings.Left(temps, temps.Length - ((arr(arr.GetUpperBound(0)).Length) + 1)) = Trim(row("ObjectID")) Then
                        'row("oFeatLetter") = Right(temps, 1)
                        row("Feature") = arr(arr.GetUpperBound(0))
                    End If
                
                End If
                dectryptErrMsg = ""
            Else
                'row("oFeatLetter") = "ERROR"
            End If
        Next

        MainGrid.DataSource = dt
        MainView.Columns("ObjectID").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.FieldName <> "isEdited" Then
            If e.Column.FieldName = "Feature" Then
                Dim generatedid As String
                generatedid = AES_Encrypt(Trim(MainView.GetRowCellValue(e.RowHandle, "ObjectID")) & "_" & MainView.GetRowCellValue(e.RowHandle, "Feature"), "spectral")
                MainView.SetRowCellValue(e.RowHandle, "FID", generatedid)
            End If
            MainView.SetRowCellValue(e.RowHandle, "isEdited", True)
            MainView.PostEditor()
        End If
    End Sub

    Private Sub MainView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged

    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        'If e.Column.FieldName = "Feature" Or e.Column.FieldName = "FID" Then
        '    If Not IsNothing(MainGrid.DataSource) Then
        '        If MainView.GetRowCellValue(e.RowHandle, "isEdited") Then
        '            e.Appearance.BackColor = System.Drawing.Color.ForestGreen
        '        End If

        '    End If
        'End If

        If Not IsNothing(MainGrid.DataSource) Then
            If MainView.GetRowCellValue(e.RowHandle, "isEdited") Then
                e.Appearance.BackColor = System.Drawing.Color.ForestGreen
                e.Appearance.ForeColor = System.Drawing.Color.White
            End If

        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim sqls As New ArrayList
        For i As Integer = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(i, "isEdited") Then
                sqls.Add("UPDATE dbo.tblobjects SET FID = '" & MainView.GetRowCellValue(i, "FID") & "' WHERE ObjectID = '" & MainView.GetRowCellValue(i, "ObjectID") & "'")
            End If
        Next

        If sqls.Count > 0 Then
            If MPSDB.RunSqls(sqls) Then
                MsgBox("tblObjects saved.", MsgBoxStyle.Information)
                Me.Close()
            End If
        End If
    End Sub
End Class