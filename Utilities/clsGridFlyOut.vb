Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns

Public Class clsGridFlyOut

    '///for flypanel
    Dim hirowhandle As Integer
    Dim flyfrm As GridFlyOut
    Dim mousePoint As System.Drawing.Point

    Public Sub addFlyout(ByRef gridctlmo As DevExpress.XtraGrid.GridControl, e As System.Windows.Forms.MouseEventArgs, Optional ByRef stopnaba As Boolean = False)

        Dim gridctl As DevExpress.XtraGrid.GridControl = TryCast(gridctlmo, DevExpress.XtraGrid.GridControl)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(gridctl.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim mousePoint As System.Drawing.Point = Control.MousePosition

        'AddHandler gridctl.MouseClick, AddressOf testclick

        Dim tmr As New Stopwatch, tmr2 As New Stopwatch
        Dim kkk As Boolean = False

        If gridctl Is Nothing Then
            If Not flyfrm Is Nothing Then
                flyfrm.FlyoutPanel1.HideBeakForm()
                flyfrm = Nothing
            End If

            Return
        End If

        Dim hi As GridHitInfo = Nothing
        Try
            hi = view.CalcHitInfo(e.Location)
        Catch ex As Exception
            hi = Nothing
        End Try

        If Not hi Is Nothing Then

            Dim dt As New DataTable, ds As New DataSet
            'For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
            '    dt.Columns.Add(col.FieldName)
            'Next
            For Each column As GridColumn In view.VisibleColumns
                dt.Columns.Add(column.Caption, System.Type.GetType("System.String")) ' column.ColumnType)
            Next column

            If hirowhandle <> hi.RowHandle Then

                If Not flyfrm Is Nothing Then
                    flyfrm.FlyoutPanel1.HideBeakForm()
                    flyfrm = Nothing
                End If

                If hi.HitTest.ToString() = "RowCell" Or hi.HitTest = GridHitTest.RowIndicator Then

                    mousePoint = Control.MousePosition

                    tmr2.Start()
                    Do While Not kkk And Not stopnaba
                        ' Application.DoEvents()
                        If tmr2.ElapsedMilliseconds >= 700 Then
                            'tmr2.Stop()
                            'tmr2.Reset()
                            kkk = True
                            Exit Do
                        End If
                    Loop

                    tmr2.Stop()
                    tmr2.Reset()
                    tmr2 = Nothing


                    If Not mousePoint = Control.MousePosition Then
                        Exit Sub
                    End If

                    'dt.ImportRow(view.GetDataRow(hi.RowHandle))
                    Dim row As DataRow = dt.NewRow()

                  

                    For Each column As GridColumn In view.VisibleColumns
                        'row(column.FieldName) = view.GetRowCellValue(hi.RowHandle, column)
                        ' column.ColumnEdit = repmemomo
                        row(column.Caption) = view.GetRowCellDisplayText(hi.RowHandle, column)

                    Next (column)

                    dt.Rows.Add(row)
                    'hirowhandle = hi.RowHandle
                    Debug.Print(hirowhandle & ";" & hi.RowHandle)

                    If stopnaba Then
                        hirowhandle = hi.RowHandle
                        If Not flyfrm Is Nothing Then
                            flyfrm.FlyoutPanel1.HideBeakForm()
                            flyfrm = Nothing
                        End If
                        tmr = Nothing
                        tmr2 = Nothing
                        'hirowhandle = hi.RowHandle

                        stopnaba = False

                        Exit Sub
                    End If

                    hirowhandle = hi.RowHandle
                    stopnaba = False
                    flyfrm = New GridFlyOut

                    '//make multi line column
                    Dim repmemomo = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
                    flyfrm.CardView1.OptionsBehavior.FieldAutoHeight = True
                    flyfrm.Grid.RepositoryItems.Add(repmemomo)
                    '////

                    flyfrm.Grid.DataSource = dt

                    '/// for multiline column
                    For i As Integer = 0 To flyfrm.CardView1.VisibleColumns.Count - 1
                        flyfrm.CardView1.VisibleColumns(i).ColumnEdit = repmemomo
                    Next
                    '///////

                    flyfrm.Show()
                    flyfrm.FlyoutPanel1.OwnerControl = view.GridControl
                    flyfrm.FlyoutPanel1.ShowBeakForm(Control.MousePosition)
                    'stopnaba = False
                    'tmr.Start()
                    'Dim sdfds As Boolean = False

                    'Do While Not sdfds
                    '    Application.DoEvents()
                    '    If tmr.ElapsedMilliseconds >= 2000 Then
                    '        tmr.Stop()
                    '        tmr.Reset()
                    '        tmr = Nothing
                    '        tmr2 = Nothing
                    '        If Not flyfrm Is Nothing Then
                    '            flyfrm.FlyoutPanel1.HideBeakForm()
                    '            flyfrm = Nothing
                    '        End If
                    '        'Exit Do

                    '        sdfds = True
                    '    End If
                    'Loop
                Else
                    If Not flyfrm Is Nothing Then
                        flyfrm.FlyoutPanel1.HideBeakForm()
                        flyfrm = Nothing
                    End If
                    tmr = Nothing
                    tmr2 = Nothing
                    If hi.HitTest.ToString() <> "RowEdge" Then
                        hirowhandle = -1
                        'Else
                        'hirowhandle = hi.RowHandle
                    End If
                    'Text = hi.HitTest.ToString()
                    'MsgBox(Text)
                    stopnaba = False
                End If
        Else
                    tmr = Nothing
                    tmr2 = Nothing
                    'lbltest2.Text = hirowhandle & "-" & hi.RowHandle
        End If
            'lbltest.Text = hirowhandle & "-" & hi.RowHandle
        Else
            If Not flyfrm Is Nothing Then
                flyfrm.FlyoutPanel1.HideBeakForm()
                flyfrm = Nothing
            End If
            tmr = Nothing
            tmr2 = Nothing
        End If
    End Sub

    Public Sub removeFlyOut(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If Not flyfrm Is Nothing Then
            flyfrm.FlyoutPanel1.HideBeakForm()
            flyfrm = Nothing
        End If
    End Sub

    Public Sub AddFlyOutEvent(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Call addFlyout(sender, e)
    End Sub

    Public Sub RemoveFlyOutEvent(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Call removeFlyOut(sender, e)
    End Sub

    Sub testclick()
        '  MsgBox("click")
    End Sub
End Class
