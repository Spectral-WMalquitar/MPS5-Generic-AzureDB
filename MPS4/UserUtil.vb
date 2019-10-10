Public Module UserUtil
    Public USER_INFO As New UserDetail
    'Save layout of XML in the DataBase
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Sub SaveLayout(ByVal _DB As SQLDB, ByVal _GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal _UserID As Integer, ByVal _ObjectID As String, ByVal _ObjectList As String)
        Dim str As New System.IO.MemoryStream()
        _GridView.SaveLayoutToStream(str)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Dim sreader As New System.IO.StreamReader(str)
        Dim text As String = sreader.ReadToEnd().Replace("'", "''")
        Dim flag As Boolean = False
        Dim _code As String = _ObjectList & "_LAYOUT"
        Dim layout As String = GetUserSetting(_code)
        SaveUserSetting(_code, text)
    End Sub

    'Get and set the Layout in the Grid view
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Sub GetLayout(ByVal _DB As SQLDB, ByVal _GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal _UserID As Integer, ByVal _ObjectID As String, ByVal _ObjectList As String)
        Dim _code As String = _ObjectList & "_LAYOUT"
        Dim text As String = ""
        text = GetUserSetting(_code)
        If text <> "" And IsNothing(text) = False Then
            Dim byteArray As Byte() = System.Text.Encoding.ASCII.GetBytes(text)
            Dim stream As New System.IO.MemoryStream(byteArray)
            _GridView.RestoreLayoutFromStream(stream)
        Else
            If System.IO.File.Exists(GetAppPath() & "\Users\" & _ObjectID & "_" & _ObjectList & "layout.xml") Then
                _GridView.RestoreLayoutFromXml(GetAppPath() & "\Users\" & _ObjectID & "_" & _ObjectList & "layout.xml")
            End If
        End If
    End Sub

    Public Sub SetGridLayout(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            .Appearance.EvenRow.BackColor = GRID_EVENCOLOR
            .Appearance.EvenRow.ForeColor = GRID_EVENFONT
            .Appearance.OddRow.ForeColor = GRID_ODDFONT
            .Appearance.OddRow.BackColor = GRID_ODDCOLOR
            view.Appearance.Row.ForeColor = GRID_ROWFONTCOLOR
            If GRID_EVENODD_VIEW Then
                .OptionsView.EnableAppearanceEvenRow = True
                .OptionsView.EnableAppearanceOddRow = True
            Else
                .OptionsView.EnableAppearanceEvenRow = False
                .OptionsView.EnableAppearanceOddRow = False
            End If
        End With
    End Sub

    Public Sub ViewRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        With view
            If e.RowHandle = .FocusedRowHandle Then
                e.Appearance.BackColor = SEL_COLOR
                e.Appearance.ForeColor = GRID_SELFONTCOLOR
            End If
        End With
    End Sub

    Public Sub ViewRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs, ByVal strRequiredFieldName As String)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If InStr(1, strRequiredFieldName, e.Column.FieldName) > 0 Then
                If .GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
                    e.Appearance.BackColor = SEL_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") And .FocusedRowHandle.Equals(e.RowHandle) Then
                    e.Appearance.BackColor = EDITED_FOCUSED_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") Then
                    e.Appearance.BackColor = EDITED_COLOR
                ElseIf e.RowHandle.Equals(.FocusedRowHandle) Then
                    e.Appearance.BackColor = SEL_COLOR
                End If
                e.Appearance.BackColor = REQUIRED_COLOR
            Else
                If .IsRowSelected(e.RowHandle) Then
                    e.Appearance.BackColor = SEL_COLOR
                    e.Appearance.ForeColor = System.Drawing.Color.Black
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
                    e.Appearance.BackColor = SEL_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") And .FocusedRowHandle.Equals(e.RowHandle) Then
                    e.Appearance.BackColor = EDITED_FOCUSED_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") Then
                    e.Appearance.BackColor = EDITED_COLOR
                ElseIf e.RowHandle.Equals(.FocusedRowHandle) Then
                    e.Appearance.BackColor = SEL_COLOR
                End If
            End If
        End With


    End Sub
End Module
