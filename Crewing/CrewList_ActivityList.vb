Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo


Public Class CrewList_ActivityList

    Dim downHitInfo As GridHitInfo
    Dim dt, subDT, expDocsDT, planningDT As New DataTable
    Dim allow As Boolean = True
    Dim ctr As Integer = 0
    Dim ds As New DataSet
    Dim showAct As Boolean = False
    Dim showExpDocs As Boolean = False
    Dim showPlanning As Boolean = False
    Dim expDocDays As Integer = 60
    Dim expDueDateDays As Integer = 30
    Dim _controlMousePointer As Point
    Dim strContent As String = ""

    'removed by tony20170725 - "I forgot what this is for!"
    'Dim isFormInitialized As Boolean = False    'Added by Tony20161014
    
    Public Overrides Sub HideSelection()
        bAddMode = True
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainView.Click
        'bAddMode = False
        'SelectionChange(Name)
        'MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If Not bSkipGetSelectedID Then GetSelectedID() 'Edited by Tony20161014
        'selectedID = MainView.GetFocusedRowCellValue("IDNbr")  'commemnted out by Tony20161014

        If MainView.FocusedRowHandle >= 0 Then
            SelectionChange(Name)
        End If

        'added by tony20190716 : Enables/disables the Delete Crew button
        RaiseCustomEvent(Name, New Object() {"EnableDeleteCrew", MainView.FocusedRowHandle >= 0})
    End Sub

    Public Overrides Sub RefreshData()
        MainView.OptionsView.ColumnAutoWidth = True 'added by tony20180509
        isRefreshingData = True
        ShowCustomLoadScreen(GetType(MPS4.Waitform), "Loading...")
        If Not bLoaded Then
            RaiseCustomEvent(Name, New Object() {"EnableDeleteCrew", False})
            initControl()
            SelectionChange(Name)
            bLoaded = True
        End If
        SetGridLayout(Me.MainView)
        'Me.MainGrid.ForceInitialize()
        expDueDateDays = CInt(GetUserSetting("DueDateExpDays", "30"))
        Dim nRow As Integer = -1
        If MainView.RowCount > 0 Then
            nRow = MainView.FocusedRowHandle
        End If
        'put data
        bDisableSelectionEvent = True
        setupDetail()
        If MainView.RowCount > 0 And IfNull(selectedID, String.Empty).Equals(String.Empty) Then
            MainView.FocusedRowHandle = nRow
            MainView.SelectRow(nRow)
        End If
        bDisableSelectionEvent = False
        SetSelection(selectedID)
        ApplyCrewListViewSort(MainView)
        ApplyCrewListFindText(MainView)
        CheckPrintCustomPOEAContractPermission()
        CloseCustomLoadScreen()
        isRefreshingData = False
    End Sub

    Private Sub CheckPrintCustomPOEAContractPermission()
        Dim sec As New clsSecurity
        sec.propSQLConnStr = MPSDB.GetConnectionString
        If sec.hasNoViewPermission("PrintCustomPOEAContract", USER_ID) Then
            PrintPOEAContract.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Else
            PrintPOEAContract.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
    End Sub

    Public Overrides Sub SetListLayout(ByVal _ObjectID As String)
        initList(USER_ID, _ObjectID)
    End Sub

    Public Overrides Sub initList(_USERID As Integer, _ObjectID As String)
        GetLayout(DB, Me.MainView, _USERID, _ObjectID, Name)
    End Sub

    'Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
    '    'If e.RowHandle = MainView.FocusedRowHandle And Not bAddMode Then
    '    '    e.Appearance.BackColor = SEL_COLOR
    '    'End If

    '    ViewRowCellStyle(sender, e) 'According to the UserTheme

    '    If e.Column.FieldName = "LName" Then
    '        'Dim hasExp As New DataTable
    '        'hasExp = DB.CreateTable("SELECT TOP 1 hasExpDoc FROM Expiring_Documents WHERE hasExpDoc > 0 AND IDNbr = '" & MainView.GetRowCellValue(e.RowHandle, "IDNbr") & "' ORDER BY hasExpDoc ASC")
    '        'If hasExp.Rows.Count > 0 Then
    '        '    Select Case hasExp.Rows(0).Item(0)
    '        '        Case 1
    '        '            e.Appearance.ForeColor = Color.Red
    '        '        Case 2
    '        '            e.Appearance.ForeColor = Color.Orange
    '        '    End Select
    '        'End If
    '        If Not IsDBNull(MainView.GetRowCellValue(e.RowHandle, "hasExpDoc")) Then
    '            Select Case MainView.GetRowCellValue(e.RowHandle, "hasExpDoc")
    '                Case 1
    '                    e.Appearance.ForeColor = Color.Red
    '                Case 2
    '                    e.Appearance.ForeColor = Color.Orange
    '                Case 3
    '                    e.Appearance.ForeColor = Color.Red
    '            End Select
    '        End If
    '    End If
    'End Sub

    Public Overrides Function GetID() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "IDNbr")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetDesc() As String
        If MainView.RowCount > 0 Then
            'Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "LName") & " " & MainView.GetRowCellValue(MainView.FocusedRowHandle, "FName")
            Return MainView.GetFocusedRowCellValue("LName") & " " & MainView.GetFocusedRowCellValue("FName")
            'Dim strDesc As String = String.Empty
            'Dim selectedIDRowHandle As Integer = IfNull(MainView.LocateByValue(0, MainView.Columns("IDNbr"), selectedID), 0)
            'Return MainView.GetRowCellDisplayText(selectedIDRowHandle, "LName") & " " & MainView.GetRowCellDisplayText(selectedIDRowHandle, "FName")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, _columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try
    End Function

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("IDNbr")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
            MainView.TopRowIndex = RowHandle
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Added by tony20170628
    Public Overrides Sub SetSelection(ByVal id As String, ByVal SetSelectedIDAsTopIndex As Boolean)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("IDNbr")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
            If SetSelectedIDAsTopIndex Then MainView.TopRowIndex = RowHandle
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub SaveLayout()
        MPS4.SaveLayout(DB, Me.MainView, USER_ID, BaseControl, Name)
        If BaseControl = "BIODATA" Then
            DB.RunSql("Update dbo.tblUserLayout SET PicViewStyle='" & PicView & "' WHERE FKeyUserID='" & USER_ID & "' AND ObjectID='" & BaseControl & "' AND ObjectList='" & Name & "'")
        End If
    End Sub

    Private Sub MainView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyData = Windows.Forms.Keys.Down Then
            MainView.MoveNext()
            e.Handled = True
        ElseIf e.KeyData = Windows.Forms.Keys.Up Then
            MainView.MovePrev()
            e.Handled = True
        End If

        If (e.KeyCode And Not Keys.Modifiers) = Keys.E AndAlso e.Modifiers = Keys.Alt Then
            If ctr = 0 Then
                MainView.ExpandMasterRow(MainView.FocusedRowHandle)
                ctr = 1
            Else
                MainView.CollapseMasterRow(MainView.FocusedRowHandle)
                ctr = 0
            End If
        End If

    End Sub

    Public Overrides Sub SetFilter(ByVal _criteria As String)
        MainView.ActiveFilterString = _criteria
        strFilter = _criteria
    End Sub

    Public Overrides Sub ClearFilter()
        bDisableSelectionEvent = True
        MainView.ClearColumnsFilter()
        MainView.RefreshData()
        bDisableSelectionEvent = False
        strFilter = ""
    End Sub

    Private Sub setActivityCrewList()
        For i As Integer = 0 To MainView.Columns.Count - 1
            If MainView.Columns(i).Name = "colLName" Or MainView.Columns(i).Name = "colFName" Or MainView.Columns(i).Name = "colMName" Then
                MainView.Columns(i).Visible = True
            Else
                MainView.Columns(i).Visible = False
            End If
        Next
    End Sub

    Private Sub MainView_RowCountChanged(sender As Object, e As System.EventArgs) Handles MainView.RowCountChanged
        'GridBand1.Caption = "Crew Count: " & MainView.RowCount
        GridBand1.Caption = "Crew Count: " & MainView.DataRowCount
    End Sub

    Private Sub setupDetail()
        If GetUserSetting("DocExpDays") <> "" Then expDocDays = GetUserSetting("DocExpDays") Else expDocDays = 0
        PurifyStringFilter(False, strCrewListFilter)
        Dim userdatafilterstring_SP As String = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
        Dim sql As String = "EXEC [SP_Crewlist_Main_SpeedTest] @ExpDocDays = " & expDocDays & ", @ExpContractDays = " & expDueDateDays & ", @userdatafilterstring = '" & Replace(userdatafilterstring_SP, "'", "''") & "', @crewFilter = '" & strCrewListFilter & "'"

        dt = DB.CreateTable(sql)
        MainGrid.DataSource = dt
        MainGrid.ForceInitialize()
        MainGrid.RefreshDataSource()
    End Sub

    Private Sub Mainview_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles MainView.SelectionChanged
        If Mainview.GetMasterRowExpanded(Mainview.FocusedRowHandle) = True Then
            ctr = 1
        Else
            ctr = 0
        End If
    End Sub

    Private Sub detailsRowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
        Dim view As GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.RowHandle = view.FocusedRowHandle And Not bAddMode Then
            e.Appearance.BackColor = SEL_COLOR
        End If
        If view.GetViewCaption = "Expiring Documents" Then
            If e.Column.FieldName = "Number" Then
                Select Case view.GetRowCellValue(e.RowHandle, "hasExpDoc")
                    Case 1
                        e.Appearance.BackColor = Color.Orange
                        e.Appearance.BackColor2 = Color.Red
                        e.Appearance.GradientMode = Drawing2D.LinearGradientMode.Horizontal
                    Case 2
                        e.Appearance.BackColor = Color.White
                        e.Appearance.BackColor2 = Color.Orange
                        e.Appearance.GradientMode = Drawing2D.LinearGradientMode.Horizontal
                End Select
            End If
        End If
    End Sub

    'December 04, 2015 Update New Codes from Earlsan David Villegas

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "SortCrew_ASC"
                SortCrew_ASC(MainView)
            Case "SortCrew_DESC"
                SortCrew_DESC(MainView)
            Case "SortRank_ASC"
                SortRank_ASC(MainView)
            Case "SortRank_DESC"
                SortRank_DESC(MainView)
            Case "CrewList_Filter"
                'CrewList_Filter(MainView)
                isRefreshingData = True
                ShowCustomLoadScreen(GetType(MPS4.Waitform), "Loading...")
                setupDetail()
                CloseCustomLoadScreen()
                isRefreshingData = False
            Case "EXPORT_TO_EXCEL"
                ExportToExcel(MainView)
            Case "RefreshList"
                RefreshList()
            Case "GetCrewList"
                dtCrewList = TryCast(MainView.DataSource, DataView).ToTable(True, New String() {"IDNbr"})
        End Select
        If Not IsNothing(bContent) Then
            If MainView.DataRowCount > 0 Then
                SetSelection(selectedID, False)
            Else
                bContent.ExecCustomFunction(New Object() {"ClearContent"})
            End If
        End If
    End Sub

    Private Sub initControl()
        repStatCode.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmStat")

        If HasPrintPOEAContractPermission() Then
            PrintPOEAContract.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Else
            PrintPOEAContract.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Sub

    Private Function HasPrintPOEAContractPermission() As Boolean
        Return True
    End Function

    Private Sub ExportToExcel(gridView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        If MsgBox("This will export the current state of the Crew List." & vbNewLine & "Do you want to continue?", vbYesNo + vbQuestion, GetAppName) = vbYes Then

            Dim fullName As String = ""
            Dim svDlg As New SaveFileDialog()
            svDlg.Filter = "Excel Workbook (*.xls)|*.xls"
            svDlg.Title = "Select file location"
            svDlg.FileName = "Crew List Export_" & Format(Date.Now, "yyyy-MM-dd").ToString
            If svDlg.ShowDialog() = DialogResult.OK Then
                fullName = svDlg.FileName
            End If
            If fullName <> "" Then
                gridView.ExportToXls(fullName)
                adjustExcel(fullName)
                If MsgBox("Exported file location:" & vbNewLine & _
                       fullName & vbNewLine & vbNewLine & _
                       "Do you want to open the file?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                    Try
                        Process.Start(fullName)
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                        MsgBox("A problem occurred while opening the file " & fullName & ".", MsgBoxStyle.Critical, GetAppName)
                    End Try
                End If
            End If

        End If
    End Sub

    Private Sub adjustExcel(XLSFilePath As String)
        Try
            Dim objExcel As Object
            objExcel = CreateObject("Excel.Application")
            objExcel.Visible = False
            objExcel.Workbooks.Open(XLSFilePath)
            objExcel.DisplayAlerts = False

            objExcel.ActiveSheet.PageSetup.Orientation = 2 'Set Orientation to landscape
            objExcel.ActiveSheet.PageSetup.PaperSize = 9  'Set Papersize to A4
            objExcel.ActiveSheet.PageSetup.LeftMargin = objExcel.Application.InchesToPoints(0.25)
            objExcel.ActiveSheet.PageSetup.RightMargin = objExcel.Application.InchesToPoints(0.25)
            objExcel.ActiveSheet.PageSetup.TopMargin = objExcel.Application.InchesToPoints(0.25)
            objExcel.ActiveSheet.PageSetup.BottomMargin = objExcel.Application.InchesToPoints(0.25)
            objExcel.Columns("A:Z").EntireColumn.AutoFit()  'Adjust the column's width.

            objExcel.ActiveWorkbook.Save()
            objExcel.Workbooks.Close()
            objExcel.DisplayAlerts = True
            objExcel.Quit()
        Catch ex As Exception
            MsgBox("A problem occurred while setting page setup of the excel file.", MsgBoxStyle.Critical, GetAppName)
        End Try
    End Sub

    Private Sub MainView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            rightClickMenu.ShowPopup(MousePosition)
        Else
            rightClickMenu.HidePopup()
        End If
    End Sub

    Private Sub rightClick_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarManager1.ItemClick
        If e.Item.Tag = "Maincontent" Then
            RaiseCustomEvent(Name, New Object() {"GoTo", e.Item.Name, "Crewing"})
        Else
            Dim CrewID As String = GetID()
            Select Case e.Item.Name
                Case "PrintBio"
                    Try
                        Dim frmRptSel As New ReportSelectionInd(CrewID)
                        frmRptSel.ShowDialog(Me)
                    Catch ex As Exception
                        MsgBox("There is no selected record(s) to preview. Please try again.", vbInformation)
                    End Try
                Case "AddComment"
                    Dim commentDT As New DataTable
                    Dim cName As String = MainView.GetFocusedRowCellValue("LName") & ", " & MainView.GetFocusedRowCellValue("FName") & " " & IfNull(MainView.GetFocusedRowCellValue("MName"), "")
                    commentDT = DB.CreateTable("SELECT *, '' as Remarks FROM dbo.frmCrew_Comment WHERE FKeyIDNbr = '" & CrewID & "'")
                    Dim frm As New frmCrewComments(commentDT, CrewID, cName)
                    frm.ShowDialog()
                Case "Acts"
                    'Dim frm As New frmActivityList(CrewID)
                    Dim cName As String = MainView.GetFocusedRowCellValue("LName") & ", " & MainView.GetFocusedRowCellValue("FName") & " " & IfNull(MainView.GetFocusedRowCellValue("MName"), "")
                    'frm.GridBand1.Caption = cName
                    'frm.GridBand2.Caption = cName
                    'frm.ShowDialog()
                    RaiseCustomEvent(Name, New Object() {"ViewAct", GetID(), cName})
                Case "ExpDocs"
                    'Dim frm As New frmPopExpDocs(CrewID)
                    Dim cName As String = MainView.GetFocusedRowCellValue("LName") & ", " & MainView.GetFocusedRowCellValue("FName") & " " & IfNull(MainView.GetFocusedRowCellValue("MName"), "")
                    'frm.GridBand1.Caption = cName
                    'frm.ShowDialog()
                    'If frm.isPressedGoTo = True Then RaiseCustomEvent(Name, New Object() {"GoTo", "Document", "Crewing"})
                    'frm.Dispose()
                    RaiseCustomEvent(Name, New Object() {"ViewExpDocs", GetID(), cName})
                Case "TravInfo"
                    Try
                        Dim dt As DataTable = DB.CreateTable("SELECT TOP 1 * FROM view_CrewPopupDetails WHERE PKey = '" & selectedID & "'")
                        If IsNothing(dt) Then Exit Sub
                        If dt.Rows.Count = 0 Then Exit Sub
                        'CLIPBOARD CONTENT
                        strContent = ""
                        strContent = strContent & "Crew Information" & vbNewLine
                        strContent = strContent & "Company ID       : " & dt(0)("COIDNo") & vbNewLine
                        strContent = strContent & "Name             : " & dt(0)("Crew") & vbNewLine
                        strContent = strContent & "Rank             : " & dt(0)("Rank") & vbNewLine
                        strContent = strContent & "Nationality      : " & dt(0)("Nat") & vbNewLine
                        strContent = strContent & "Date of Birth    : " & dt(0)("DOB") & vbNewLine
                        strContent = strContent & "Place of Birth   : " & dt(0)("POB") & vbNewLine
                        strContent = strContent & vbNewLine
                        strContent = strContent & "Passport" & vbNewLine &
                                                  "Number           : " & dt(0)("PPNum") & vbNewLine &
                                                  "Date Issue       : " & dt(0)("PPDI") & vbNewLine &
                                                  "Date Expiry      : " & dt(0)("PPDE") & vbNewLine &
                                                  "Place Issued     : " & dt(0)("PPIP") & vbNewLine
                        strContent = strContent & vbNewLine
                        strContent = strContent & "Seaman's Book" & vbNewLine &
                                                  "Number           : " & dt(0)("SBNum") & vbNewLine &
                                                  "Date Issue       : " & dt(0)("SBDI") & vbNewLine &
                                                  "Date Expiry      : " & dt(0)("SBDE")
                        'LOAD CONTENT
                        txtCOIDNo.EditValue = dt(0)("COIDNo")
                        txtCrew.EditValue = dt(0)("Crew")
                        txtRank.EditValue = dt(0)("Rank")
                        txtNat.EditValue = dt(0)("Nat")
                        txtDOB.EditValue = dt(0)("DOB")
                        txtPOB.EditValue = dt(0)("POB")
                        txtPPNum.EditValue = dt(0)("PPNum")
                        txtPPIssue.EditValue = dt(0)("PPDI")
                        txtPPExpiry.EditValue = dt(0)("PPDE")
                        txtPPPlace.EditValue = dt(0)("PPIP")
                        txtSBNum.EditValue = dt(0)("SBNum")
                        txtSBIssue.EditValue = dt(0)("SBDI")
                        txtSBExpiry.EditValue = dt(0)("SBDE")

                        fpMain.ShowBeakForm(_controlMousePointer, True, Me)
                    Catch ex As Exception
                        MsgBox("Encounted an error while loading data." & vbNewLine & "Please contact your Administrator.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName())
                    End Try

                Case "PrintPOEAContract"
                    Try
                        Dim f As New frmPopupPrintPOEAContract(selectedID)

                        f.ShowDialog()
                    Catch ex As Exception
                        MsgBox("There is no selected record(s) crew. Please try again.", vbInformation)
                    End Try
            End Select
        End If
    End Sub

    Private Sub MainView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles MainView.PopupMenuShowing
        selectedID = MainView.GetRowCellValue(e.HitInfo.RowHandle, "IDNbr")
        _controlMousePointer = Control.MousePosition
    End Sub

    Private Sub RefreshList()
        'Throw New NotImplementedException
        If GetUserSetting("ShowAct") <> "" Then showAct = GetUserSetting("ShowAct")
        If GetUserSetting("ShowExpDocs") <> "" Then showExpDocs = GetUserSetting("ShowExpDocs")
        If GetUserSetting("DocExpDays") <> "" Then expDocDays = GetUserSetting("DocExpDays")
        If GetUserSetting("ShowPlanning") <> "" Then showPlanning = GetUserSetting("ShowPlanning")
        Dim userdatafilterstring_SP As String = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
        Dim sql As String = "EXEC SP_Crewlist_Main @ExpDocDays = " & expDocDays & ", @userdatafilterstring = '" & Replace(userdatafilterstring_SP, "'", "''") & "'"
        getCrewListActivitiesDTs(sql, "Crewlist_Main_DT", "Automatic")
        setupDetail()

    End Sub

    Private Sub MainView_EndSorting(sender As System.Object, e As System.EventArgs) Handles MainView.EndSorting
        SaveCrewListViewSort(MainView)
    End Sub

    Private Sub MainView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles MainView.FocusedRowObjectChanged
        If Not bSkipGetSelectedID Then GetSelectedID() 'Edited by Tony20161014
    End Sub

   Private Sub GetSelectedID() 'Added by Tony20161014
        Try
            If isRefreshingData Then
                selectedID = IIf(IfNull(selectedID, "").Equals(""), IfNull(MainView.GetFocusedRowCellValue("IDNbr"), String.Empty), selectedID)

                bSkipGetSelectedID = True
                SetSelection(selectedID)
                bSkipGetSelectedID = False
            Else
                selectedID = IfNull(MainView.GetFocusedRowCellValue("IDNbr"), String.Empty)
            End If
            GetDesc()
        Catch ex As Exception
            MsgBox("Error when getting the selected crew's id. " & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MainView_ColumnFilterChanged(sender As System.Object, e As System.EventArgs) Handles MainView.ColumnFilterChanged
        SaveCrewListFindText(MainView)
    End Sub

    Private Sub MainView_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles MainView.CustomDrawRowIndicator
        If IfNull(MainView.GetRowCellValue(e.RowHandle, "hasExpDoc"), 0) > 0 Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)
            'edited by tony20170222
            'e.Graphics.DrawImage(My.Resources.ExpDocWarning, New RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))
            Select Case IfNull(MainView.GetRowCellValue(e.RowHandle, "hasExpDoc"), 0)
                Case DocumentExpiryTag.Expired, DocumentExpiryTag.ExpiredAndExpiring
                    e.Graphics.DrawImage(My.Resources.WarningExpired, New RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))
                Case DocumentExpiryTag.Expiring
                    e.Graphics.DrawImage(My.Resources.WarningExpiring, New RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))
            End Select
            'end tony
            e.Handled = True
        End If
    End Sub

    Private Sub MainView_RowCellStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.Column.FieldName = "LName" Or e.Column.FieldName = "DueDate" Then
            If Not IsNothing(MainGrid.DataSource) Then

                If Not IsDBNull(MainView.GetRowCellValue(e.RowHandle, "DueDate")) Then
                    Dim due As Date = CDate(MainView.GetRowCellValue(e.RowHandle, "DueDate"))
                    If (due > Date.Now And due < DateAdd(DateInterval.Day, expDueDateDays, Date.Now)) Then
                        e.Appearance.ForeColor = Color.Orange
                    ElseIf due < Date.Now Then
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If

            End If
        End If

    End Sub

    Private Sub cmdCopyToClip_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopyToClip.Click
        Try
            Clipboard.SetText(strContent, TextDataFormat.Text)
            MsgBox("Crew Information has been copied to clipboard.", MsgBoxStyle.Information)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        fpMain.HideBeakForm(True)
    End Sub

    Private Sub ToolTipController_CrewList_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController_CrewList.GetActiveObjectInfo
        'Select Case IfNull(MainView.GetRowCellValue(e.RowHandle, "hasExpDoc"), 0)
        '    Case DocumentExpiryTag.Expired, DocumentExpiryTag.ExpiredAndExpiring
        '        e.Graphics.DrawImage(My.Resources.WarningExpired, New RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))
        '    Case DocumentExpiryTag.Expiring
        '        e.Graphics.DrawImage(My.Resources.WarningExpiring, New RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))
        'End Select


        If Not e.SelectedControl Is MainGrid Then Return

        Dim info As DevExpress.Utils.ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = MainGrid.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells


        If hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
            'FOR ROW INDICATORS. EXPIRING / EXPIRED DOCUMENTS
            'An object that uniquely identifies a row indicator cell
            Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
            Dim text As String = "" '"Row " + hi.RowHandle.ToString()

            Select Case IfNull(view.GetRowCellValue(hi.RowHandle, "hasExpDoc"), 0)
                Case DocumentExpiryTag.Expired, DocumentExpiryTag.ExpiredAndExpiring
                    text = "Crew has an expired document(s)."

                Case DocumentExpiryTag.Expiring
                    text = "Crew has an expiring document(s)."

            End Select

            If text.Length > 0 Then info = New DevExpress.Utils.ToolTipControlInfo(o, text)

        ElseIf hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
            If hi.Column.FieldName = "LName" Or hi.Column.FieldName = "DueDate" Then
                If Not IsDBNull(MainView.GetRowCellValue(hi.RowHandle, "DueDate")) Then
                    Dim due As Date = CDate(MainView.GetRowCellValue(hi.RowHandle, "DueDate"))
                    Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
                    Dim text As String = ""

                    If (due > Date.Now And due < DateAdd(DateInterval.Day, expDueDateDays, Date.Now)) Then
                        text = "Crew's Contract is About to Due in " & DateDiff(DateInterval.Day, DateTime.Now, due) & " days (" & Format(due, "dd-MMM-yyyy") & ")."
                    ElseIf due < Date.Now Then
                        text = "Crew's Contract is Overdue."
                    End If

                    If text.Length > 0 Then info = New DevExpress.Utils.ToolTipControlInfo(o, text)
                End If
            End If

        End If
        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub

    Private Sub rightClickMenu_Popup(sender As Object, e As System.EventArgs) Handles rightClickMenu.Popup
        Try
            fpMain.HideBeakForm(True)
        Catch
            'do nothing
        End Try
    End Sub
End Class
