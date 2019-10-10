Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Ribbon.RibbonControl
Imports DevExpress.XtraBars
Imports System.IO
Imports DevExpress.XtraLayout
Imports System.Reflection
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Scrolling
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

'The Ribbon button structure.
Public Structure RibbonButton
    Public ButtonGroup As String
    Public ButtonName As String
    Public ButtonIcon As Image
    Public ButtonCaption As String
End Structure

Public Class QuickAccessButtons

    Private ButtonGroups As String()                                                        'This array will handle all the groups for each tab. 
    Dim buttonOptions As String = ""
    Dim userFavoriteButtons As String = ""
    Dim favorites As New List(Of RibbonButton)                                              'List of Favorite Buttons, as can be seen in tblUserConfig for this user.
    Dim usersButton As New List(Of RibbonButton)
    Dim availableButton As New List(Of RibbonButton)
    Dim _downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
    Protected Mode As Integer = 0 'Mode Merge or Duplicate
    Dim _buttonName As String

    Dim availableButtons As String()
    Dim favoriteButtons As String()
    Dim hasSaveButtons As Boolean = False

    Private Const GridMinWidth As Integer = 400
    Private Const GridMinHeight As Integer = 900

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        LoadButtonGroups()
        Try
            buttonOptions = MPSDB.DLookUp("TextValue", "tblConfig", "", "Code='ButtonTypes'")
        Catch ex As Exception
            LogErrors("--Error Generated in RefreshData() method in QuickAccessButtons.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in RefreshData() method in QuickAccessButtons.vb - End--")

            Debug.WriteLine(ex.Message)
        End Try
        ConfigureView()
        GetAllButtons()
        LoadData()
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            flag = True
            ALLOWNEXTS = flag
            SaveData()
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function
    'This method will load all the available buttons according to the description assigned to each button and if it is included in the tblConfig.
    Private Sub LoadButtonGroups()
        Try
            ButtonGroups = MPSDB.DLookUp("TextValue", "tblConfig", "", "Code='ButtonGroups'").Split(",")
            Dim result As String = MPSDB.DLookUp("Value", "tblUserConfig", "NoData", "FKeyUserID = '" & USER_ID & "' AND Code = 'FavoriteButtons'")         'Load the saved buttons of this user.
            Dim showResult As String = MPSDB.DLookUp("Value", "tblUserConfig", "NoData", "FKeyUserID = '" & USER_ID & "' AND Code = 'ShowFavoriteButtons'") 'Get the value if the user wants the shortcuts to be shown on each tab in ribbon. 
            favoriteButtons = IIf(result.Equals("NoData"), New String() {}, result.Split(","))
            If favoriteButtons.Length > 0 Or Not showResult.Equals("NoData") Then
                hasSaveButtons = True
            Else
                hasSaveButtons = False
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in LoadButtonGroups() method in QuickAccessButtons.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in LoadButtonGroups() method in QuickAccessButtons.vb - End--")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadData()
        ButtonsGrid.DataSource = ConvertToDataTable(favorites)              'Load the available buttons.
        FavoriteButtonsGrid.DataSource = ConvertToDataTable(usersButton)    'Load the users favorite buttons.
    End Sub

    Public Overrides Sub SaveData()
        SaveUsersFavoriteButtons()
    End Sub

    Public Overrides Sub ClearData()
        MyBase.ClearData()
        If DialogResult.Yes = MessageBox.Show("This will remove your selected shortcut buttons, continue?", "Clear Selected Shortcuts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            For Each obj As RibbonButton In usersButton
                favorites.Add(obj)
            Next
            usersButton.Clear()
            LoadData()
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub SaveUsersFavoriteButtons()
        Dim _buttons As New System.Text.StringBuilder()
        Dim updateQueries As New ArrayList
        Dim saveResult As Boolean = False
        Dim errMessage As String = ""

        With FavoriteButtonsView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .DataRowCount - 1
                _buttons.Append(.GetRowCellValue(i, "ButtonName").ToString() & ",")
            Next
        End With
        If (_buttons.Length > 0) Then
            _buttons = New System.Text.StringBuilder(_buttons.ToString().Substring(0, _buttons.Length - 1))
        End If

        If Not hasSaveButtons Then  'If the user does not have any favorite buttons yet, save it as a new record. 
            updateQueries.Add("INSERT INTO tblUserConfig(FKeyUserID, Code, Value) VALUES ('" & USER_ID & "','FavoriteButtons','" & _buttons.ToString() & "')")
            updateQueries.Add("INSERT INTO tblUserConfig(FKeyUserID, Code, Value) VALUES ('" & USER_ID & "','ShowFavoriteButtons','" & ShowShortcutOnRibbon & "')")
        Else                        'otherwise, update his current favorite buttons. 
            updateQueries.Add("UPDATE tblUserConfig SET Value = '" & _buttons.ToString() & "' WHERE FKeyUserID = '" & USER_ID & "' AND Code = 'FavoriteButtons'")
            updateQueries.Add("UPDATE tblUserConfig SET Value = '" & ShowShortcutOnRibbon & "' WHERE FKeyUserID = '" & USER_ID & "' AND Code = 'ShowFavoriteButtons'")
        End If

        Try
            saveResult = MPSDB.RunSqls(updateQueries)
            updateQueries.Clear()
        Catch ex As Exception
            LogErrors("--Error Generated in SaveUserFavoriteButtons() method in QuickAccessButtons.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SaveUserFavoriteButtons() method in QuickAccessButtons.vb - End--")

            saveResult = False
            errMessage = ex.Message
        Finally
            updateQueries = Nothing
        End Try

        If BRECORDUPDATEDs Then
            ProcessResult(saveResult, errMessage)
        Else
            If DialogResult.Yes = MessageBox.Show("Save changes on Shortcuts buttons?", "Shortcut Buttons", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                ProcessResult(saveResult, errMessage)
            End If
        End If

    End Sub

    Private Sub ProcessResult(result As Boolean, errMessage As String)
        If (result) Then
            MessageBox.Show("Changes has been saved successfully.", "Shortcut Buttons", MessageBoxButtons.OK, MessageBoxIcon.Information)
            hasSaveButtons = True
            HasShortcutIsUpdated = True
            BRECORDUPDATEDs = False
        Else
            MessageBox.Show("Error has been encountered while saving the changes : " + errMessage, "Favorite Buttons", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ConfigureView()
        With ButtonsView
            .BeginSort()
            Try
                .ClearGrouping()
                .Columns("ButtonGroup").GroupIndex = 0
                .Columns("ButtonCaption").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            Finally
                .EndSort()
            End Try
        End With

        With FavoriteButtonsView
            .BeginSort()
            Try
                .ClearGrouping()
                .Columns("ButtonGroup").GroupIndex = 0
                .Columns("ButtonCaption").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            Finally
                .EndSort()
            End Try
        End With
    End Sub

    Public Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As New DataTable()
        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next

        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

    Private Sub LoadButtons(item As BarButtonItem)
        If item.Visibility = BarItemVisibility.Never Then Return

        If favoriteButtons.Contains(item.Name) Then 'If this button is already saved as user's favorite, it will add to list usersButtons   
            AddShortcutButtons(item, False)
        Else                                                'If not, load to favorites list for possible selection. 
            AddShortcutButtons(item, True)
        End If
    End Sub

    Private Sub AddShortcutButtons(item As BarButtonItem, isFavorite As Boolean)
        Dim button As RibbonButton
        button.ButtonGroup = GetGroup(item.Description)
        button.ButtonName = item.Name
        button.ButtonCaption = item.Caption.Trim()
        button.ButtonIcon = TryCast(item.Glyph.GetThumbnailImage(25, 25, Nothing, Nothing), Image)
        If isFavorite Then
            favorites.Add(button)
        Else
            usersButton.Add(button)
        End If
    End Sub

    'Load all the buttons available in the ribbon. This method will be called after the security feature has filtered the buttons according to the permission assigned for each user.
    Public Sub GetAllButtons()
        Dim ribbonControl As RibbonControl = Util.MainCrewFormRibbonControl
        Dim retVal As String = ""
        Dim mCurrentItem As BarItem
        For Each currentPage As RibbonPage In ribbonControl.Pages
            For Each currentGroup As RibbonPageGroup In currentPage.Groups
                For Each currenLink As BarItemLink In currentGroup.ItemLinks
                    mCurrentItem = currenLink.Item
                    If Not mCurrentItem.Description.Equals("") And buttonOptions.Contains(mCurrentItem.Description) Then
                        If (TryCast(mCurrentItem, BarButtonItem).ButtonStyle = BarButtonStyle.CheckDropDown) Then
                            Dim dropDownMenu As PopupMenu = TryCast(mCurrentItem, BarButtonItem).DropDownControl
                            For Each b As BarItemLink In dropDownMenu.ItemLinks
                                LoadButtons(b.Item)
                            Next
                        Else
                            LoadButtons(mCurrentItem)
                        End If
                    End If
                Next currenLink
            Next currentGroup
        Next currentPage
    End Sub

    Public Function GetGroup(description As String) As String
        For Each group As String In ButtonGroups
            If description.Equals(group) Then
                Return group
            End If
        Next
        Return ""
    End Function

    Private Sub ButtonsView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ButtonsView.RowCellStyle
        SetRowCellStyle(ButtonsView, sender, e)
    End Sub

    Private Sub FavoriteButtonsView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles FavoriteButtonsView.RowCellStyle
        SetRowCellStyle(FavoriteButtonsView, sender, e)
    End Sub

    Public Sub SetRowCellStyle(controlGrid As GridView, ByRef sender As Object, ByRef e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Try
            If controlGrid.GetRowCellValue(e.RowHandle, "Edited") Is DBNull.Value Then
                e.Appearance.BackColor = SEL_COLOR
            ElseIf controlGrid.GetRowCellValue(e.RowHandle, "Edited") And controlGrid.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = EDITED_FOCUSED_COLOR
            ElseIf controlGrid.GetRowCellValue(e.RowHandle, "Edited") = True Then
                e.Appearance.BackColor = EDITED_COLOR
            ElseIf e.RowHandle = controlGrid.FocusedRowHandle Then
                e.Appearance.BackColor = SEL_COLOR
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in SetRowCellStyle() method in QuickAccessButtons.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetRowCellStyle() method in QuickAccessButtons.vb - End--")

            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    '--------------------------------------------- Drag and Drop ---------------------------------------------'
#Region "Drag and Drop Functionalities"
    Private Sub ButtonsView_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles ButtonsView.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        _downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not ModifierKeys = Keys.None Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            _downHitInfo = hitInfo
        End If
    End Sub

    Private Sub ButtonsView_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles ButtonsView.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = Windows.Forms.MouseButtons.Left And Not _downHitInfo Is Nothing Then
            Dim dragSize = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(_downHitInfo.HitPoint.X - dragSize.Width / 2, _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                _buttonName = view.Name
                Dim row As DataRow = view.GetDataRow(_downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                _downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub ButtonsGrid_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles ButtonsGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            Select Case Mode
                Case 2 'Duplicate Mode
                    row.Delete()
                Case Else
                    If Not _buttonName.Equals("ButtonsView") Then
                        table.ImportRow(row)
                        row.Delete()
                        BRECORDUPDATEDs = True
                    End If
            End Select
        End If
    End Sub

    Private Sub ButtonsGrid_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles ButtonsGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ButtonsView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles ButtonsView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub
    '------------------------------------ Destination Grid - Favorite Buttons -----------------------------------------'
    Private Sub FavoriteButtonsView_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles FavoriteButtonsView.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        _downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not ModifierKeys = Keys.None Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            _downHitInfo = hitInfo
        End If
    End Sub

    Private Sub FavoriteButtonsView_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles FavoriteButtonsView.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = Windows.Forms.MouseButtons.Left And Not _downHitInfo Is Nothing Then
            Dim dragSize = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(_downHitInfo.HitPoint.X - dragSize.Width / 2, _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                _buttonName = view.Name
                Dim row As DataRow = view.GetDataRow(_downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                _downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub FavoriteButtonsGrid_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles FavoriteButtonsGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub FavoriteButtonsView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles FavoriteButtonsView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub FavoriteButtonsGrid_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles FavoriteButtonsGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            'table.ImportRow(row)
            'row.Delete()
            Select Case Mode
                Case 2 'Duplicate Mode
                    row.Delete()
                Case Else
                    If Not _buttonName.Equals("FavoriteButtonsView") Then
                        table.ImportRow(row)
                        row.Delete()
                        BRECORDUPDATEDs = True
                    End If
            End Select
        End If
    End Sub
#End Region

End Class

