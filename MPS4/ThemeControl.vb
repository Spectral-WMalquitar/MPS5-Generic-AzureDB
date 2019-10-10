Public Class ThemeControl


    'Dim MainFontSize As Double
    Dim GridFontSize As Double
    Dim GridFocusedSelectColor As System.Drawing.Color = SEL_COLOR 'grid Selected Color
    Dim GridFocusedFontColor As System.Drawing.Color = GRID_SELFONTCOLOR 'grid FOcused ROw FOnt Color
    Dim GridRowFontColor As System.Drawing.Color = GRID_ROWFONTCOLOR ' Grid  RowFont Color
    Dim GridEvenRowColor As System.Drawing.Color = GRID_EVENCOLOR 'Even Row Background Color
    Dim GridEvenFontColor As System.Drawing.Color = GRID_EVENFONT 'Even Font Color
    Dim GridOddFontColor As System.Drawing.Color = GRID_ODDFONT 'Odd Row Font Color
    Dim GridOddColor As System.Drawing.Color = GRID_ODDCOLOR 'Odd Row Background Color
    Dim EvenODD As Boolean = GRID_EVENODD_VIEW 'allow Grid ODD/Even View
    Dim FontFace As String = MAINFONTFAMILY
    Dim FontStyle As Integer = MAINFONTSTYLE
    Dim MainFSize As Integer = MAINFONTSIZE

    Private Sub MainGridApplyColor()
        Me.GridView1.Appearance.EvenRow.ForeColor = GridEvenFontColor
        Me.GridView1.Appearance.OddRow.ForeColor = GridOddFontColor
        Me.GridView1.Appearance.EvenRow.BackColor = GridEvenRowColor
        Me.GridView1.Appearance.OddRow.BackColor = GridOddColor
        Me.GridControl1.ForceInitialize()
    End Sub

#Region "Main Controls"

    Private Sub txtMainFont_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtMainFont.EditValueChanged
        Dim tFont As Font = SetThemeFont()
        Me.txtSample.Font = tFont
        Me.LayoutControlItem3.AppearanceItemCaption.Font = tFont

    End Sub

    Private Sub txtMainFontFace_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtMainFontFace.EditValueChanged
        Dim TFont As Font = SetThemeFont()
        Me.txtSample.Font = SetThemeFont()
        Me.LayoutControlItem3.AppearanceItemCaption.Font = SetThemeFont()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Dim TFont As Font = SetThemeFont()
        Me.txtSample.Font = TFont
        Me.LayoutControlItem3.AppearanceItemCaption.Font = TFont
    End Sub

#End Region

#Region "Grid Control"
    Private Function DummyData() As DataTable
        Dim ctable As New DataTable
        ctable.Columns.Add("PKey", System.Type.GetType("System.String"))
        ctable.Columns.Add("Name", System.Type.GetType("System.String"))
        ctable.Rows.Add("1", "The Quick")
        ctable.Rows.Add("2", "brown fox")
        ctable.Rows.Add("3", "jumps over the")
        ctable.Rows.Add("4", "Lazy Dog")
        ctable.Rows.Add("5", "Down the River")
        Return ctable
    End Function

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.RowHandle = GridView1.FocusedRowHandle Then
            e.Appearance.BackColor = GridFocusedSelectColor
        End If
    End Sub

    'Grid Select Font Color
    Private Sub clrGridFont_EditValueChanged(sender As Object, e As System.EventArgs) Handles clrGridFont.EditValueChanged
        GridFocusedFontColor = TryCast(sender, DevExpress.XtraEditors.ColorPickEdit).EditValue
        Me.GridView1.Appearance.FocusedCell.ForeColor = GridFocusedFontColor
        GridControl1.ForceInitialize()
        GridView1.RefreshRow(GridView1.FocusedRowHandle)
    End Sub

    'Grid Select Color
    Private Sub clrGridSelect_EditValueChanged(sender As Object, e As System.EventArgs) Handles clrGridSelect.EditValueChanged
        GridFocusedSelectColor = TryCast(sender, DevExpress.XtraEditors.ColorPickEdit).EditValue
        Me.GridView1.Appearance.FocusedRow.BackColor = GridFocusedSelectColor
        GridControl1.ForceInitialize()
    End Sub

    'Grid  Font Color
    Private Sub ColorPickEdit1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles clrRowFont.EditValueChanged
        GridRowFontColor = TryCast(sender, DevExpress.XtraEditors.ColorPickEdit).EditValue
        Me.GridView1.Appearance.Row.ForeColor = GridRowFontColor
        GridControl1.ForceInitialize()
        GridView1.RefreshRow(GridView1.FocusedRowHandle)
    End Sub

    Private Sub txtGridFont_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtGridFont.EditValueChanged
        GridFontSize = TryCast(sender, DevExpress.XtraEditors.SpinEdit).EditValue
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", GridFontSize)
        GridControl1.ForceInitialize()
    End Sub

    'Enable Theme_EvenOdd Checkbox
    Private Sub chkEvenOdd_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkEvenOdd.CheckStateChanged
        If chkEvenOdd.Checked Then
            GridView1.OptionsView.EnableAppearanceEvenRow = True
            GridView1.OptionsView.EnableAppearanceOddRow = True
            Me.clrEvenColor.Enabled = True
            Me.clrEvenFontColor.Enabled = True
            Me.clrOddColor.Enabled = True
            Me.clrOddFontColor.Enabled = True
            Me.clrRowFont.Enabled = False
            MainGridApplyColor()
        Else
            GridView1.OptionsView.EnableAppearanceEvenRow = False
            GridView1.OptionsView.EnableAppearanceOddRow = False
            Me.clrEvenColor.Enabled = False
            Me.clrEvenFontColor.Enabled = False
            Me.clrOddColor.Enabled = False
            Me.clrOddFontColor.Enabled = False
            Me.clrRowFont.Enabled = True
        End If
    End Sub

#End Region

    'Refresh
    Public Overrides Sub RefreshData()
        Try
            Me.GridControl1.DataSource = DummyData()
            Me.GridView1.Columns(0).Visible = False
            Me.txtGridFont.Text = CSng(Me.GridView1.Appearance.Row.GetFont.Size.ToString)
            Me.txtMainFont.Text = CSng(MainFSize)
            Me.clrGridSelect.EditValue = GridFocusedSelectColor
            Me.clrGridFont.EditValue = GridFocusedFontColor
            Me.clrRowFont.EditValue = GridRowFontColor
            Me.chkEvenOdd.Checked = GRID_EVENODD_VIEW
            Me.clrEvenColor.EditValue = GridEvenRowColor
            Me.clrEvenFontColor.EditValue = GridEvenFontColor
            Me.clrOddColor.EditValue = GridOddColor
            Me.clrOddFontColor.EditValue = GridOddFontColor
            Me.txtMainFontFace.EditValue = FontFace
            Me.RadioGroup1.SelectedIndex = FontStyle
            If chkEvenOdd.Checked Then
                Me.clrEvenColor.Enabled = True
                Me.clrEvenFontColor.Enabled = True
                Me.clrOddColor.Enabled = True
                Me.clrOddFontColor.Enabled = True
                Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
                Me.GridView1.OptionsView.EnableAppearanceOddRow = True
                Me.clrRowFont.Enabled = False
            Else
                Me.clrGridFont.Enabled = True
                Me.clrEvenColor.Enabled = False
                Me.clrEvenFontColor.Enabled = False
                Me.clrOddColor.Enabled = False
                Me.clrOddFontColor.Enabled = False
                Me.GridView1.OptionsView.EnableAppearanceEvenRow = False
                Me.GridView1.OptionsView.EnableAppearanceOddRow = False
                Me.clrRowFont.Enabled = True
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    'Save
    Public Overrides Sub SaveData()
        'MyBase.SaveData()
        SaveUserSetting("Theme_GridSelColor", CStr(GridFocusedSelectColor.ToArgb))
        SaveUserSetting("Theme_GridSelFontColor", CStr(GridFocusedFontColor.ToArgb))
        SaveUserSetting("Theme_GridRowFont", CStr(GridRowFontColor.ToArgb))
        SaveUserSetting("Theme_Name", UserLookAndFeel.Default.ActiveSkinName.ToString)
        SaveUserSetting("Theme_GridFontSize", CStr(Me.txtGridFont.EditValue.ToString))
        SaveUserSetting("Theme_FontSize", CStr(Me.txtMainFont.EditValue.ToString))
        SaveUserSetting("Theme_EvenOdd", CStr(Me.chkEvenOdd.Checked))
        SaveUserSetting("Theme_EvenColor", CStr(GridEvenRowColor.ToArgb))
        SaveUserSetting("Theme_EvenFontColor", CStr(GridEvenFontColor.ToArgb))
        SaveUserSetting("Theme_OddColor", CStr(GridOddColor.ToArgb))
        SaveUserSetting("Theme_OddFontColor", CStr(GridOddFontColor.ToArgb))
        SaveUserSetting("Theme_FontFamily", CStr(Me.txtMainFontFace.EditValue))
        SaveUserSetting("Theme_FontStyle", CStr(Me.RadioGroup1.SelectedIndex))
        MsgBox(GetMessage("Saved", True), MsgBoxStyle.Information, GetAppName)
        If MsgBox("For the changes to take effect. The application must be Restarted. Do you want to restart now?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            Application.Restart()
            IS_RESTARTING = True
        End If
    End Sub

    'ODD Back Color
    Private Sub clrOddColor_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles clrOddColor.EditValueChanged
        If chkEvenOdd.Checked Then
            GridOddColor = TryCast(sender, DevExpress.XtraEditors.ColorPickEdit).EditValue
            Me.GridView1.Appearance.OddRow.BackColor = GridOddColor
            Me.GridControl1.ForceInitialize()
        End If
    End Sub

    'Even Back Color
    Private Sub clrEvenColor_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles clrEvenColor.EditValueChanged
        If chkEvenOdd.Checked Then
            GridEvenRowColor = TryCast(sender, DevExpress.XtraEditors.ColorPickEdit).EditValue
            Me.GridView1.Appearance.EvenRow.BackColor = GridEvenRowColor
            Me.GridControl1.ForceInitialize()
        End If
    End Sub

    'Odd Font Color
    Private Sub clrOddFontColor_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles clrOddFontColor.EditValueChanged
        If chkEvenOdd.Checked Then
            GridOddFontColor = TryCast(sender, DevExpress.XtraEditors.ColorPickEdit).EditValue
            Me.GridView1.Appearance.OddRow.ForeColor = GridOddFontColor
            Me.GridControl1.ForceInitialize()
        End If
    End Sub

    'Even Font Color
    Private Sub clrEvenFontColor_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles clrEvenFontColor.EditValueChanged
        If chkEvenOdd.Checked Then
            GridEvenFontColor = TryCast(sender, DevExpress.XtraEditors.ColorPickEdit).EditValue
            Me.GridView1.Appearance.EvenRow.ForeColor = GridEvenFontColor
            Me.GridControl1.ForceInitialize()
        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0)
            'Case "DeleteOther"
            '    DeleteSubItem()
            Case "ResetDefault"
                Try
                    If MsgBox("Are you sure you want to Restore Default Settings?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Yes Then
                        MPSDB.RunSql("DELETE tblUserConfig WHERE FKeyUserID='" & USER_ID & "' AND Code LIKE 'Theme_%'")
                        If MsgBox("For the changes to take effect. The application must be Restarted. Do you want to restart now?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                            Application.Restart()
                        End If
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub

    'get Font Style
    Private Function GetFontStyle() As FontStyle
        Dim retval As FontStyle
        Select Case RadioGroup1.SelectedIndex
            Case 0
                retval = Drawing.FontStyle.Regular
            Case 1
                retval = Drawing.FontStyle.Bold
            Case 2
                retval = Drawing.FontStyle.Italic
            Case Else
                retval = Drawing.FontStyle.Regular
        End Select
        Return retval
    End Function

    'get Font Family
    Private Function GetFontFamily() As String
        Dim retval As String = "Tahoma"
        If Not IfNull(CStr(Me.txtMainFontFace.EditValue), "").Equals("") Then
            retval = CStr(Me.txtMainFontFace.EditValue)
        End If
        Return retval
    End Function

    'get Font Size
    Private Function GetFontSize() As Single
        Dim retval As Single = MAINFONTSIZE
        If CInt(IfNull(Me.txtMainFont.EditValue, 0)) > 0 Then
            retval = CSng(Me.txtMainFont.EditValue)
        End If
        Return retval
    End Function

    'set Theme Font
    Private Function SetThemeFont() As Font
        Dim retval As Font
        retval = New Font(GetFontFamily(), GetFontSize(), GetFontStyle())
        Return retval
    End Function

End Class
