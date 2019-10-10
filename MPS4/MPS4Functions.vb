Imports System.IO
Imports System.Reflection

Public Module MPS4Functions

#Region "Appearance"
#End Region

#Region "MPS 4 Main Functions"
    Public CrewReassignmentOpenConfirmation As Boolean = False


    Public Sub ResetLayoutButton(ByVal mainlist As BaseList, ByVal maincontent As BaseControl.BaseControl)
        Dim flag As Boolean = False
        Dim _code As String = mainlist.Name & "_LAYOUT"
        Dim _codeWidth As String = maincontent.Name & "_" & mainlist.Name & "_WIDTH"
        GetUserSetting(_code)
        Dim layout As String = GetUserSetting(_code)
        If Not layout.Equals("") Then
            flag = True
        Else
            flag = False
        End If
        If flag Then
            'SaveUserSetting(_code, text)
            MPSDB.RunSql("DELETE dbo.tblUserConfig WHERE FKeyUserID = '" & USER_ID & "' AND Code = '" & _code & "'")
            MPSDB.RunSql("DELETE dbo.tblUserConfig WHERE FKeyUserID = '" & USER_ID & "' AND Code = '" & _codeWidth & "'")

        End If
        mainlist.SetListLayout(mainlist.Name)

        'MPSDB.BeginReader("SELECT * FROM dbo.tblUserLayout WHERE FKeyUserID='" & USER_ID & "' AND ObjectID='" & maincontent.Name & "'  AND ObjectList='" & mainlist.Name & "' ")

        'If MPSDB.HasRows() Then
        '    flag = True
        'Else
        '    flag = False
        'End If
        'MPSDB.CloseReader()

        'If flag Then
        '    MPSDB.RunSql("DELETE FROM dbo.tblUserLayout WHERE FKeyUserID='" & USER_ID & "' AND ObjectID='" & maincontent.Name & "'  AND ObjectList='" & mainlist.Name & "'")
        'End If
        'mainlist.SetListLayout(maincontent.Name)
    End Sub
    'Save Layout Width
    Public Sub SaveLayoutButton(ByVal mainlist As BaseList, ByVal maincontent As BaseControl.BaseControl, ByVal MainListWidth As Integer)
        Dim flag As Boolean = False
        MPSDB.BeginReader("SELECT * FROM dbo.tblUserLayout WHERE FKeyUserID='" & USER_ID & "' AND ObjectID='" & maincontent.Name & "'  AND ObjectList='" & mainlist.Name & "' ")
        If MPSDB.HasRows() Then
            flag = True
        Else
            flag = False
        End If
        MPSDB.CloseReader()

        If flag Then
            MPSDB.RunSql("UPDATE dbo.tblUserLayout SET ObjectListWidth='" & MainListWidth & "'WHERE FKeyUserID='" & USER_ID & "' AND ObjectID='" & maincontent.Name & "'  AND ObjectList='" & mainlist.Name & "'")
        Else
            MPSDB.RunSql("INSERT INTO dbo.tblUserLayout(FKeyUserID,ObjectID,ObjectList,ObjectListWidth) VALUES('" & USER_ID & "','" & maincontent.Name & "','" & mainlist.Name & "','" & MainListWidth & "')")
        End If

    End Sub

#Region "Crew Photo"
    Public Function GetCrewBiodataPhoto(IDNbr As String) As String

        'CrewPhoto.Image = New System.Drawing.Bitmap(Trim(IfNull(Items("PhotoPath"), "")))
        'Dim _path = GetCrewPhotoPath(_CrewIDNbr, strPhotoPath)
        Dim cPhotoPath As String

        MPSDB.BeginReader("SELECT * FROM dbo.tblcrewinfo WHERE Pkey = '" & IDNbr & "'")
        Try
            If MPSDB.ReaderItemCount = 0 Then Return ""

            MPSDB.Read()
            cPhotoPath = IfNull(MPSDB.ReaderItem("PhotoPath"), "")

            'MPSDB.CloseReader()
            If cPhotoPath.Length > 0 Then
                Return GetCrewPhotoPath(IDNbr, cPhotoPath)
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""

        Finally
            MPSDB.CloseReader()
        End Try
    End Function

    Private Function GetCrewPhotoPath(_CrewIDNbr As String, FileName As String)
        Dim retval As String = Nothing
        Try
            Dim ImagePath As String = FOLDERDIRECTORY & "\" & _CrewIDNbr & "\" & FileName
            'Dim FileName As String = _CrewIDNbr & "_IMAGE"
            'If System.IO.File.Exists(ImagePath & ".jpg") Then
            '    ImagePath = ImagePath & ".jpg"
            'ElseIf System.IO.File.Exists(ImagePath & ".png") Then
            '    ImagePath = ImagePath & ".png"
            'Else
            '    ImagePath = Nothing
            'End If
            retval = ImagePath
        Catch ex As Exception
            retval = Nothing
        End Try
        Return retval
    End Function
#End Region

#Region "Sorting And Filtering"
    'for Crew List Settings
    Public strCrewListFilter As String = ""
    Public oQuickFilter As New FilterStructure
    Public MonthsAshore As String = "0"
    Public MonthsAshoreCriteria As String = " MonthsAshore >= "
    Private crewListGridSort As DevExpress.XtraGrid.Columns.GridColumnReadOnlyCollection
    Private crewListFindText As String = ""

    Public Class FilterStructure
        Public FilterString As String = ""
        Public FilterInfo As String = ""

        Public Sub Clear()
            FilterString = ""
            FilterInfo = ""
        End Sub
    End Class

    Public Sub SaveCrewListViewSort(view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        crewListGridSort = view.SortedColumns
    End Sub

    Public Sub ApplyCrewListViewSort(view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        Dim colToSort As New DevExpress.XtraGrid.Columns.GridColumn

        If Not IsNothing(crewListGridSort) Then
            If crewListGridSort.Count <> 0 Then
                For Each sortedCol As DevExpress.XtraGrid.Columns.GridColumn In crewListGridSort
                    Try
                        colToSort = view.Columns(sortedCol.FieldName)
                        If Not IsNothing(colToSort) Then
                            colToSort.SortIndex = sortedCol.SortIndex
                            colToSort.SortOrder = sortedCol.SortOrder
                        End If
                    Catch ex As Exception
                        MsgBox("Sort error : " & ex.Message)
                    End Try
                Next
            End If
        End If

    End Sub

    Public Sub SaveCrewListFindText(view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        crewListFindText = view.FindFilterText
    End Sub

    Public Sub SaveCrewListFindText(findText As String)
        crewListFindText = findText
    End Sub

    Public Sub ApplyCrewListFindText(view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        view.FindFilterText = crewListFindText
    End Sub

    Public Sub SortCrew_ASC(ByVal view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        With view
            .BeginSort()
            Try
                .ClearSorting()
                .Columns("LName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                .Columns("FName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                .Columns("MName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Finally
                .EndSort()
            End Try
        End With

    End Sub

    Public Sub SortCrew_DESC(ByVal view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        With view
            .BeginSort()
            Try
                .ClearSorting()
                .Columns("LName").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("FName").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                .Columns("MName").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            Finally
                .EndSort()
            End Try
        End With
    End Sub

    Public Sub SortRank_ASC(ByVal view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        With view
            .BeginSort()
            Try
                .ClearSorting()
                .Columns("RankSortCode").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Finally
                .EndSort()
            End Try
        End With
    End Sub

    Public Sub SortRank_DESC(ByVal view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        With view
            .BeginSort()
            Try
                .ClearSorting()
                .Columns("RankSortCode").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            Finally
                .EndSort()
            End Try
        End With
    End Sub

    Public Sub CrewList_Filter(view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        With view
            Try
                'Updated by calvhin 20150125
                'This will fix the bug when filtering while in Activity
                view.Columns("VslName").FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                If strBContentFilter <> "" And strCrewListFilter <> "" Then
                    view.ActiveFilterString = strCrewListFilter & " AND " & strBContentFilter
                Else
                    If strBContentFilter = "" Then
                        view.ActiveFilterString = strCrewListFilter
                    ElseIf strCrewListFilter = "" Then
                        view.ActiveFilterString = strBContentFilter
                    End If
                End If
            Finally
            End Try
        End With
    End Sub

#End Region

#End Region

#Region "User Settings"
    'Get Themes
    Public Sub GetThemes()
        Try
            SEL_COLOR = System.Drawing.Color.FromArgb(CInt(IIf(GetUserSetting("Theme_GridSelColor") <> "", GetUserSetting("Theme_GridSelColor"), "0")))
            If SEL_COLOR = System.Drawing.Color.FromArgb(0) Then
                SEL_COLOR = System.Drawing.Color.FromArgb(200, 247, 200)
            End If
            GRID_SELFONTCOLOR = System.Drawing.Color.FromArgb(CInt(IIf(GetUserSetting("Theme_GridSelFontColor") <> "", GetUserSetting("Theme_GridSelFontColor"), "0")))
            GRID_ROWFONTCOLOR = System.Drawing.Color.FromArgb(CInt(IIf(GetUserSetting("Theme_GridRowFont") <> "", GetUserSetting("Theme_GridRowFont"), "0")))
            GRID_EVENCOLOR = System.Drawing.Color.FromArgb(CInt(IIf(GetUserSetting("Theme_EvenColor") <> "", GetUserSetting("Theme_EvenColor"), "0")))
            GRID_EVENFONT = System.Drawing.Color.FromArgb(CInt(IIf(GetUserSetting("Theme_EvenFontColor") <> "", GetUserSetting("Theme_EvenFontColor"), "0")))
            GRID_ODDCOLOR = System.Drawing.Color.FromArgb(CInt(IIf(GetUserSetting("Theme_OddColor") <> "", GetUserSetting("Theme_OddColor"), "0")))
            GRID_ODDFONT = System.Drawing.Color.FromArgb(CInt(IIf(GetUserSetting("Theme_OddFontColor") <> "", GetUserSetting("Theme_OddFontColor"), "0")))
            GRID_EVENODD_VIEW = CBool(IIf(GetUserSetting("Theme_EvenOdd") <> "", GetUserSetting("Theme_EvenOdd"), "0"))
            MAINFONTFAMILY = CStr(IIf(GetUserSetting("Theme_FontFamily") <> "", GetUserSetting("Theme_FontFamily"), "Tahoma"))
            MAINFONTSTYLE = IIf(GetUserSetting("Theme_FontStyle") <> "", GetUserSetting("Theme_FontStyle"), "0")
            MAINFONTSIZE = CInt(IIf(GetUserSetting("Theme_FontSize") <> "", GetUserSetting("Theme_FontSize"), "8"))
            THEME_NAME = IIf(GetUserSetting("Theme_Name") <> "", GetUserSetting("Theme_Name"), "Office 2013 White")
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(THEME_NAME)
            Dim MainFStyle As FontStyle = FontStyle.Regular
            Select Case MAINFONTSTYLE
                Case 0
                    MainFStyle = FontStyle.Regular
                Case 1
                    MainFStyle = FontStyle.Bold
                Case 2
                    MainFStyle = FontStyle.Italic
            End Select
            DevExpress.Utils.AppearanceObject.DefaultFont = New Font(MAINFONTFAMILY, MAINFONTSIZE, MainFStyle)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GetUserSetting(ByVal SettingCode As String, Optional DefaultValue As String = "") As String
        Dim str As String = MPSDB.DLookUp("Value", "tblUserConfig", "", "FKeyUserID='" & USER_ID & "' AND Code='" & SettingCode & "'")
        If Not str.Equals("") Then
            Return str
        Else
            If Not IfNull(DefaultValue, "").Equals("") Then
                SaveUserSetting(SettingCode, DefaultValue)
            End If
            Return DefaultValue
        End If
    End Function

    Public Structure UserSettingCode
        Public Const DueDateExpDays = "DueDateExpDays"
        Public Const ShowActivity = "ShowAct"
        Public Const ShowExpDocs = "ShowExpDocs"
        Public Const ShowPlanning = "ShowPlanning"
        Public Const DocExpDays = "DocExpDays"


        Public Structure LTP
            Public Const ShowEmptyVesselRank = "LTPShowEmptyVesselRank"
            Public Const ColorScheme = "LTPColorScheme"
            Public Const Scale = "LTPScale"
        End Structure

        Public Structure Travel
            Public Const RecordFilter = "TravelRecordFilter"
            Public Const ShowPendingOnly = "TravelShowPendingOnly"
            Public Const ShowBooked = "TravelShowBooked"
            Public Const ShowCompleted = "TravelShowCompleted"
            Public Const ShowRegularBooking = "TravelShowRegularBooking"
            Public Const ShowBookedWithGTravel = "TravelShowBookedWithGTravel"
            Public Const ShowCompletedTravel = "TravelShowCompletedTravel"
            Public Const ShowBookingType = "TravelShowBookingType"
            Public Const ReceiveResponseNotification = "TravelReceiveResponseNotif"
            Public Const ResponseRefreshTime = "TravelResponseRefreshTime"
            Public Const LastResponseCheckTime = "TravelLastResponseCheckTime"
        End Structure
        
    End Structure

    Public Function GetUserSetting(ByVal SettingCode As UserSettingCode, Optional DefaultValue As String = "") As String
        Dim str As String = MPSDB.DLookUp("Value", "tblUserConfig", "", "FKeyUserID='" & USER_ID & "' AND Code='" & SettingCode.ToString & "'")
        If Not str.Equals("") Then
            Return str
        Else
            If Not IfNull(DefaultValue, "").Equals("") Then
                SaveUserSetting(SettingCode.ToString, DefaultValue)
            End If
            Return DefaultValue
        End If
    End Function

    Public Sub SaveUserSetting(ByVal SettingCode As String, ByVal Value As String)
        Try
            Dim sql As String = ""
            With MPSDB
                .BeginReader("SELECT * FROM dbo.tblUserConfig WHERE FKeyUserID='" & USER_ID & "' AND Code='" & SettingCode & "'")
                If .HasRows Then
                    sql = "UPDATE dbo.tblUserConfig SET " & _
                            "Value='" & Value & "'" & _
                            "WHERE FKeyUserID='" & USER_ID & "' AND Code='" & SettingCode & "'"
                Else
                    sql = "INSERT INTO dbo.tblUserConfig(FKeyUserID,Code,Value)" & _
                             "VALUES('" & USER_ID & "'" & _
                             ",'" & SettingCode & "'" & _
                             ",'" & Value & "')"
                End If
                .CloseReader()
                .RunSql(sql)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            MPSDB.CloseReader()
        End Try
    End Sub

#End Region

#Region "Database Connection Check"
    Public Function CheckDatabaseConnection(Optional ExitProgramIfFails As Boolean = True, Optional ShowWaitForm As Boolean = False) As Boolean
        If ShowWaitForm Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Checking database connection...")
        If MPSDB.CheckConnection Then
            If ShowWaitForm Then CloseCustomLoadScreen()
            Return True
        Else

            Application.DoEvents()
            MsgBox("MPS5 has lost connection to the database. Check your connection or consult your system administrator for assistance." & IIf(ExitProgramIfFails, vbNewLine & vbNewLine & "This program will exit.", ""), MsgBoxStyle.Critical)
            If ExitProgramIfFails Then KillCurrentProcess()
            If ShowWaitForm Then CloseCustomLoadScreen()
            Return False
        End If
    End Function
#End Region

#Region "Force Logout"
    Public Sub CheckForceLogout(ModuleName As String)
        '///neil force log out
        'Dim userlogged As String
        'userlogged = MPSDB.DLookUp("FKeyUserID", "MSysSec_Users_Log", "not", "FKeyUserID=" & USER_ID & "")
        'If userlogged = "not" Then
        '    If Not USER_NAME.ToUpper.Equals("SPECTRAL") Then
        '        MsgBox("You have been logged out by the Administrator." & vbCrLf & _
        '           "MPS Crewing will shutdown.", vbExclamation)
        '        KillCurrentProcess()
        '        Exit Sub
        '    End If
        'End If

        If Not USER_NAME.ToUpper.Equals("SPECTRAL") Then
            Dim loggedinFrom As String
            If USER_NAME.ToUpper.Equals("ADMINISTRATOR") Then
                loggedinFrom = MPSDB.DLookUp("CompName", "MSysSec_Users_Log", "NOT_LOGGED_IN", "FKeyUserID=" & USER_ID & " AND ModuleName = '" & ModuleName & "' and [CompName] = '" & My.Computer.Name.Replace("'", "''") & "'")
            Else
                loggedinFrom = MPSDB.DLookUp("CompName", "MSysSec_Users_Log", "NOT_LOGGED_IN", "FKeyUserID=" & USER_ID & " AND ModuleName = '" & ModuleName & "'")
            End If

            Dim CurrentCompName As String = My.Computer.Name.Replace("'", "''")
            If Not loggedinFrom.Equals(CurrentCompName) Then


                'MsgBox("You have been logged out by the Administrator or by another user." & vbCrLf & _
                '   "MPS " & ToTitleCase(ModuleName) & " will shutdown.", vbExclamation)

                'MsgBox("You have been logged out by f. MPS " & ToTitleCase(ModuleName) & " will shutdown." & vbCrLf & vbCrLf & _
                '   "Press Ok to continue", vbExclamation)
                MsgBox("You have been logged out from your computer." & vbCrLf & _
                   "MPS " & ToTitleCase(ModuleName) & " will exit.", vbExclamation)
                KillCurrentProcess()
                Exit Sub
            End If
        End If

        '////
    End Sub
#End Region

    Public strBContentFilter As String = ""

    ''' <summary>
    ''' Checks if given number range is valid based on checkMode
    ''' </summary>
    ''' <param name="startPoint">number value for start of range</param>
    ''' <param name="endPoint">number value for end of range</param>
    ''' <param name="DB">database to search</param>
    ''' <param name="domain">table/query to search</param>
    ''' <param name="startField">start field in the table/query</param>
    ''' <param name="endField">end field in the table/query</param>
    ''' <param name="checkMode">type of checking</param>
    ''' <param name="additionalCriteria">can be use for editing</param>
    ''' <returns>True or False</returns>
    ''' <remarks></remarks>
    '''

    Public Function IsRangeValid(startPoint As Double, endPoint As Double, DB As SQLDB, domain As String, startField As String, endField As String, Optional ByVal checkMode As String = "OVERLAP", Optional ByVal additionalCriteria As String = "") As Boolean
        IsRangeValid = True
        Dim crit As String = ""
        Dim crit_OverLap As String = "((" & startField & ">=" & startPoint & " AND " & startField & "<=" & endPoint & ")" & " OR " & _
                                "(" & endField & ">=" & startPoint & " AND " & endField & "<=" & endPoint & ")" & " OR " & _
                                "(" & startField & "<=" & startPoint & " AND " & endField & ">=" & endPoint & "))"

        crit = crit_OverLap & IIf(Len(additionalCriteria) <> 0, " AND (" & additionalCriteria & ")", "")

        If startPoint >= endPoint Then
            IsRangeValid = False
            MsgBox("The specified range is not valid.", MsgBoxStyle.Exclamation, GetAppName)
            Exit Function
        End If

        Select Case checkMode
            Case "OVERLAP"
                If DB.HasDuplicate(domain, crit) Then
                    IsRangeValid = False
                    MsgBox("The specified range overlaps a record in the list.", MsgBoxStyle.Exclamation, GetAppName)
                    Exit Function
                End If
        End Select
    End Function

    ''' <summary>
    ''' Checks if given datetime range is valid based on checkMode
    ''' </summary>
    ''' <param name="startPoint">date value for start of range</param>
    ''' <param name="endPoint">date value for end of range</param>
    ''' <param name="DB">database to search</param>
    ''' <param name="domain">table/query to search</param>
    ''' <param name="startField">start field in the table/query</param>
    ''' <param name="endField">end field in the table/query</param>
    ''' <param name="checkMode">type of checking</param>
    ''' <param name="additionalCriteria">can be use for editing</param>
    ''' <returns>True or False</returns>
    ''' <remarks></remarks>
    ''' 
    Public Function IsRangeValid(startPoint As DateTime, endPoint As DateTime, DB As SQLDB, domain As String, startField As String, endField As String, Optional ByVal checkMode As String = "OVERLAP", Optional ByVal additionalCriteria As String = "") As Boolean
        IsRangeValid = True
        Dim crit As String = ""
        Dim crit_OverLap As String = "((" & startField & ">='" & startPoint & "' AND " & startField & "<='" & endPoint & "')" & " OR " & _
                                "(" & endField & ">='" & startPoint & "' AND " & endField & "<='" & endPoint & "')" & " OR " & _
                                "(" & startField & "<='" & startPoint & "' AND " & endField & ">='" & endPoint & "'))"

        crit = crit_OverLap & IIf(Len(additionalCriteria) <> 0, " AND (" & additionalCriteria & ")", "")

        If startPoint >= endPoint Then
            IsRangeValid = False
            MsgBox("The specified range is not valid.", MsgBoxStyle.Exclamation, GetAppName)
            Exit Function
        End If

        Select Case checkMode
            Case "OVERLAP"
                If DB.HasDuplicate(domain, crit) Then
                    IsRangeValid = False
                    MsgBox("The specified range overlaps a record in the list.", MsgBoxStyle.Exclamation, GetAppName)
                    Exit Function
                End If
        End Select
    End Function

    'Description for Validity field
    Public Function getValDesc(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, listSourceRowIndex As Integer) As String
        Dim str As String() = Split(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "Validity")), ".")
        Dim temp As String = ""
        For x As Integer = 0 To str.Count - 1
            Select Case x
                Case 0 'Year
                    If Not IsNothing(str(x)) And str(x) <> "" Then
                        If CInt(str(x)) > 0 Then
                            temp = str(x) & " Year(s) "
                        End If
                    End If
                Case 1 'Months
                    If Not IsNothing(str(x)) And str(x) <> "" Then
                        If CInt(str(x)) > 0 Then
                            temp = temp & str(x) & " Month(s) "
                        End If
                    End If
                Case 2
                    If Not IsNothing(str(x)) And str(x) <> "" Then
                        If CInt(str(x)) > 0 Then
                            temp = temp & str(x) & " Day(s) "
                        End If
                    End If
            End Select
        Next
        'MsgBox(temp)
        'MainView.SetRowCellValue(listSourceRowIndex, "ValDesc", temp)
        Return temp
        'End If
    End Function

    Public Function getValDesc(ByVal _str As String) As String
        Dim str As String() = Split(Convert.ToString(_str), ".")
        Dim temp As String = ""
        For x As Integer = 0 To str.Count - 1
            Select Case x
                Case 0 'Year
                    If Not IsNothing(str(x)) And str(x) <> "" Then
                        If CInt(str(x)) > 0 Then
                            temp = str(x) & " Year(s) "
                        End If
                    End If
                Case 1 'Months
                    If Not IsNothing(str(x)) And str(x) <> "" Then
                        If CInt(str(x)) > 0 Then
                            temp = temp & str(x) & " Month(s) "
                        End If
                    End If
                Case 2
                    If Not IsNothing(str(x)) And str(x) <> "" Then
                        If CInt(str(x)) > 0 Then
                            temp = temp & str(x) & " Day(s) "
                        End If
                    End If
            End Select
        Next
        Return temp
    End Function

    'addded by Elmer
    Public Function CleanInput(strIn As String) As String
        Dim r As String
        r = strIn
        r = r.Replace("'", "''")
        Return r
    End Function

    Public Function CleanInput(strIn As Object) As String
        Dim r As String
        r = IfNull(strIn, "")
        r = r.Replace("'", "''")
        Return r
    End Function
    'end elmer

    Public Sub ClearLookUpEdit(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Try
            If sender.ReadOnly = False And e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
                sender.Focus()
                If sender.Parent.GetType().Name = "GridControl" Then
                    SendKeys.SendWait("^{DEL}")
                Else
                    SendKeys.SendWait("{ESC}")
                    sender.EditValue = Nothing
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Public Sub PurifyStringFilter(IsInArchive As Boolean, ByVal sourceFilter As String)

        If (sourceFilter Is Nothing) Then Return

        If (IsInArchive) Then
            If (MonthsAshore.Equals("0")) Then
                strCrewListFilter = sourceFilter.Replace(MonthsAshoreCriteria & MonthsAshore, " ")
            Else
                strCrewListFilter = sourceFilter
            End If
        Else
            strCrewListFilter = sourceFilter.Replace(MonthsAshoreCriteria & MonthsAshore, " ").Replace(" [StatType] = 3 ", "")
        End If
        If strCrewListFilter.Length > 0 Then
            If LTrim(strCrewListFilter).StartsWith("AND") Then
                strCrewListFilter = strCrewListFilter.Trim().Substring(3).Trim()
            End If
            While (Trim(strCrewListFilter).EndsWith("AND"))
                strCrewListFilter = strCrewListFilter.Trim().Remove(strCrewListFilter.LastIndexOf("AND"))
            End While
            'strCrewListFilter = strCrewListFilter.Replace("''", "'").Replace("'", "''")
            strCrewListFilter = strCrewListFilter.Replace("'", "''")
        End If

    End Sub


#Region "Sub Table Functions"

    Public Sub EditSubGrid(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal value As Boolean)
        With view
            .CancelUpdateCurrentRow()
            If value Then
                .OptionsBehavior.ReadOnly = False
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                '.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Else
                .OptionsBehavior.ReadOnly = True
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            End If
        End With

    End Sub

    Public Sub EditSubAllowGrid(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal value As Boolean, Optional showNewRow As Boolean = True)
        With view
            .CancelUpdateCurrentRow()
            If value Then
                .OptionsBehavior.ReadOnly = False
                If showNewRow Then
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                Else
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                End If
            Else
                .OptionsBehavior.ReadOnly = True
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            End If
        End With

    End Sub

    Public Sub AllowRepositoryBtnEdit(ByVal btn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, Optional ByVal value As Boolean = True)
        For i As Integer = 0 To btn.Buttons.Count - 1
            btn.Buttons(i).Enabled = value
        Next
    End Sub

    Public Sub AllowRepositoryBtnEdit(ByVal btn As DevExpress.XtraEditors.ButtonEdit, Optional ByVal value As Boolean = True)
        For i As Integer = 0 To btn.Properties.Buttons.Count - 1
            btn.Properties.Buttons(i).Enabled = value
        Next
    End Sub

#End Region


#Region "DateTime"
    'Added by Tony20160706
    Public Function getServerDateTime() As Date
        Dim retval As Date
        MPSDB.BeginReader("SELECT getdate() as currdate")
        While MPSDB.Read()
            retval = MPSDB.ReaderItem("currdate")
        End While
        MPSDB.CloseReader()
        Return retval
    End Function

#End Region

#Region "ATTACH DOCUMENT"
    Public Class AttachDocument

        Public Shared ReadOnly ATTACH_DOC_FILTER() As String = {"PDF Files (*.pdf)|*.pdf", _
                                                                "Word Documents (*.doc, *.docx)|*.doc;*.docx", _
                                                                "Image Files (*.jpg, *.jpeg, *.bmp, *.png, *.tiff, *.gif)|*.jpg;*.jpeg;*.bmp;*.png;*.tiff;*.gif"}

        Private Shared _fileFilter As String = ""
        Private Shared wordToPdf As New DevExpress.XtraRichEdit.RichEditControl
        Private Shared tempPdf As New pdfTemplate

        Public Shared Function GetAttachDocFilter(Optional AddAllFiles As Boolean = False) As String
            Dim retVal As String = ""

            For Each fFormat As String In ATTACH_DOC_FILTER
                retVal = retVal & fFormat & "|"
            Next
            retVal = retVal.Substring(0, retVal.Length - 1)
            retVal = retVal & IIf(AddAllFiles, "|" & "All Files|*.*", "")

            Return retVal
        End Function

        ''' <summary>
        ''' One time initialization of Browse button of the column
        ''' </summary>
        ''' <param name="repBtn"></param>
        ''' <remarks></remarks>
        Public Shared Sub InitBrowseButton(ByRef repBtn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit)
            With repBtn
                .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                                      "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                                      Nothing, Nothing, Nothing, Nothing))
                .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
                AddHandler .ButtonPressed, AddressOf repButtonClick
            End With
        End Sub

        ''' <summary>
        ''' Event for Browse button
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Shared Sub repButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
            Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
            Dim mainGrid As DevExpress.XtraGrid.GridControl = TryCast(btn.Parent, DevExpress.XtraGrid.GridControl)
            Dim mainView As DevExpress.XtraGrid.Views.Grid.GridView
            Dim subView As DevExpress.XtraGrid.Views.Grid.GridView = mainGrid.FocusedView
            mainView = subView.ParentView
            Dim odMain As New System.Windows.Forms.OpenFileDialog
            If _fileFilter.Length <> 0 Then
                odMain.Filter = _fileFilter
            End If
            If Not CStr(mainView.GetRowCellValue(subView.SourceRowHandle, "PKey")).Equals(CStr(subView.SourceRowHandle)) Then
                If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    'btn.Text = odMain.SafeFileName
                    If btn.Text.Length = 0 Then
                        btn.Text = odMain.SafeFileName
                    End If
                    subView.SetFocusedRowCellValue("tempFilePath", odMain.FileName.ToString)
                    subView.SetFocusedRowCellValue("FKeyParent", mainView.GetRowCellValue(subView.SourceRowHandle, "PKey"))
                    subView.SetFocusedRowCellValue("Edited", True)
                    mainView.SetFocusedRowCellValue("Edited", True)
                End If
            Else
                subView.CancelUpdateCurrentRow()
                MsgBox("Save the new record first before uploading document.", MsgBoxStyle.OkOnly + vbInformation, GetAppName)
            End If
        End Sub

        ''' <summary>
        ''' Specify file filter
        ''' </summary>
        ''' <param name="fileFilter"></param>
        ''' <remarks></remarks>
        Public Shared Sub SetFileFilter(fileFilter As String)
            _fileFilter = fileFilter
        End Sub

        ''' <summary>
        ''' Load data on both Main GridView and Sub GridView with relationship and data validation
        ''' </summary>
        ''' <param name="MainGrid">Parent GridControl container</param>
        ''' <param name="MainView">main data</param>
        ''' <param name="SubView">sub data</param>
        ''' <param name="mainViewSql">query for main view data</param>
        ''' <param name="subViewSql">query for sub view data</param>
        ''' <param name="PKey">key of main view</param>
        ''' <param name="FKey">key relation to main view</param>
        ''' <remarks></remarks>
        Public Shared Sub LoadViewWithDocImage(MainGrid As DevExpress.XtraGrid.GridControl, MainView As DevExpress.XtraGrid.Views.Grid.GridView, SubView As DevExpress.XtraGrid.Views.Grid.GridView, mainViewSql As String, subViewSql As String, PKey As String, FKey As String)
            Try
                Dim dataSet As New DataSet("DataSet")
                Dim mainDT As New DataTable, subImgDT As New DataTable
                MainView.OptionsDetail.AllowExpandEmptyDetails = True
                With dataSet
                    mainDT = MPSDB.CreateTable(mainViewSql)
                    subImgDT = MPSDB.CreateTable(subViewSql)
                    .Tables.Add(mainDT)
                    .Tables(0).TableName = "Main"
                    .Tables.Add(subImgDT)
                    .Tables(1).TableName = "Sub"
                    'Dim CDUnq As UniqueConstraint = New UniqueConstraint(New DataColumn() {mainDT.Columns(PKey)}, True)
                    'Dim clmForeign As ForeignKeyConstraint = New ForeignKeyConstraint(New DataColumn() {mainDT.Columns(PKey)}, New DataColumn() {subImgDT.Columns(FKey)})
                    '.Tables("Main").Constraints.Add(CDUnq)
                    '.Tables("Sub").Constraints.Add(clmForeign)
                    .Relations.Add(SubView.LevelName, .Tables("Main").Columns(PKey), .Tables("Sub").Columns(FKey))
                    Try 'unexpected error sometimes
                        MainGrid.DataSource = dataSet
                    Catch ex As Exception
                        MainGrid.DataSource = dataSet
                    End Try
                    MainGrid.DataMember = "Main"
                    SubView.ViewCaption = "Attached Documents"
                    SubView.OptionsView.ShowGroupPanel = False
                    SubView.OptionsCustomization.AllowFilter = False

                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        ''' <summary>
        ''' Create sub directories of FOLDERDIRECTORY
        ''' </summary>
        ''' <param name="subDirectories"></param>
        ''' <returns>FOLDERDIRECTORY and subDirectories</returns>
        ''' <remarks></remarks>
        Public Shared Function GetSubDirectories(ByVal subDirectories As String) As String
            Dim strDir As String = ""
            Dim folders() As String = subDirectories.Split("\")

            If subDirectories.Length <> 0 Then
                strDir = FOLDERDIRECTORY & "\"
                For Each folder As String In folders
                    strDir = strDir & IIf(folder.Length = 0, "", folder & "\")

                    Try
                        If (Not System.IO.Directory.Exists(strDir)) Then
                            System.IO.Directory.CreateDirectory(strDir)
                        End If
                    Catch ex As Exception
                        LogErrors("GetSubDirectories() : " & ex.Message)
                    End Try

                Next
            End If

            Return strDir
        End Function

        ''' <summary>
        ''' Generate fullname of file
        ''' </summary>
        ''' <param name="subDirectories"></param>
        ''' <param name="fileName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GenerateFilePath(ByVal subDirectories As String, ByVal fileName As String) As String
            Dim res As String = ""
            Dim filePath As String = ""

            filePath = GetSubDirectories(subDirectories) & fileName
            res = filePath

            Return res
        End Function

        ''' <summary>
        ''' Check filename w/o ext exists
        ''' </summary>
        ''' <param name="strDir"></param>
        ''' <param name="fileName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsUniqueFileName(strDir As String, fileName As String) As Boolean

            Dim retVal As Boolean = True
            Dim files() As String = Nothing
            Dim fName As String = ""

            Try
                files = IO.Directory.GetFiles(strDir)
            Catch ex As Exception
                LogErrors("IsUniqueFileName() : " & ex.Message)
            End Try

            If Not IsNothing(files) Then
                For Each file As String In files
                    fName = IO.Path.GetFileNameWithoutExtension(strDir & file)
                    If fName.ToUpper = fileName.ToUpper Then
                        retVal = False
                        Exit For
                    End If
                Next
            End If

            Return retVal
        End Function


        Public Shared Sub SaveAttachDoc(MainView As DevExpress.XtraGrid.Views.Grid.GridView, levelName As String, LastUpdatedBy As String, ByVal subDirectories As String, ByVal topParentKey As String, ByVal fileTag As String, dateFileColName As String, tableName As String)
            Dim subView As DevExpress.XtraGrid.Views.Grid.GridView
            Dim cSql As String = ""
            Dim fileName As String = ""

            With MainView
                .CloseEditForm()
                .UpdateCurrentRow()
                For mainCnt As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(mainCnt, "Edited") Then
                        subView = .GetDetailView(mainCnt, .GetRelationIndex(mainCnt, levelName))

                        If Not subView Is Nothing Then
                            With subView
                                For subCnt As Integer = 0 To .RowCount - 1
                                    If .GetRowCellValue(subCnt, "Edited") Then
                                        If IfNull(.GetRowCellValue(subCnt, "PKey"), "") = "" Then
                                            'Use insert query
                                            fileName = LinkDocument(.GetRowCellValue(subCnt, "tempFilePath"), subDirectories, topParentKey, fileTag, MainView.GetRowCellValue(mainCnt, dateFileColName), False)
                                            .SetRowCellValue(subCnt, "FilePath", fileName)
                                            cSql = "INSERT INTO dbo.tblAttachDoc " & _
                                                      "(" & _
                                                      "FKeyParent, " & _
                                                      "TableName, " & _
                                                      "Description, " & _
                                                      "FilePath, " & _
                                                      "LastUpdatedBy) " & _
                                                      "VALUES ( " & _
                                                      "'" & .GetRowCellValue(subCnt, "FKeyParent") & "', " & _
                                                      "'" & tableName & "', " & _
                                                      "'" & .GetRowCellValue(subCnt, "Description") & "'," & _
                                                      "'" & .GetRowCellValue(subCnt, "FilePath") & "', " & _
                                                      "'" & LastUpdatedBy & "')"
                                            MPSDB.RunSql(cSql)
                                        Else
                                            'Use Update query
                                            fileName = LinkDocument(.GetRowCellValue(subCnt, "tempFilePath"), subDirectories, topParentKey, fileTag, MainView.GetRowCellValue(mainCnt, dateFileColName), True, .GetRowCellValue(subCnt, "FilePath"))
                                            .SetRowCellValue(subCnt, "FilePath", fileName)
                                            cSql = "UPDATE dbo.tblAttachDoc SET " & _
                                                      "Description = '" & .GetRowCellValue(subCnt, "Description") & "', " & _
                                                      "FilePath = '" & .GetRowCellValue(subCnt, "FilePath") & "', " & _
                                                      "LastUpdatedBy= '" & LastUpdatedBy & "' " & _
                                                      "WHERE PKey = '" & .GetRowCellValue(subCnt, "PKey") & "'"
                                            MPSDB.RunSql(cSql)
                                        End If
                                    End If
                                Next
                            End With
                        End If

                    End If
                Next
            End With

        End Sub

        Public Shared Function LinkDocument(sourceFile As String, destDir As String, topParentKey As String, fileTag As String, dateFile As Date, overwrite As Boolean, Optional origFilePath As String = "") As String

            Dim strDir As String = ""
            Dim fileName As String = ""
            Dim fileExt As String = ""
            Dim fName As String = ""
            Dim filePath As String = ""
            Dim cntr As Integer = 0
            Try
                strDir = GetSubDirectories(destDir)

                If sourceFile.Length <> 0 Then
                    Try
                        fileExt = System.IO.Path.GetExtension(sourceFile)
                    Catch ex As System.IO.DirectoryNotFoundException
                        fileExt = ".pdf"
                    End Try

                    If Not overwrite Then

                        fName = topParentKey & "_" & fileTag & "_" & Format(dateFile, "yyyyMMdd")
                        fileName = fName

                        Do
                            If Not IsUniqueFileName(strDir, fileName) Then
                                fileName = fName & "_" & CStr(cntr)
                                cntr = cntr + 1
                            End If
                        Loop While (Not IsUniqueFileName(strDir, fileName))

                        'Do
                        '    If (System.IO.File.Exists(filePath)) Then
                        '        fileName = fName & "_" & CStr(cntr)
                        '        filePath = strDir & fileName & fileExt
                        '        cntr = cntr + 1
                        '    End If
                        'Loop While (System.IO.File.Exists(filePath))

                        fName = fileName & fileExt
                    Else
                        Kill(strDir & origFilePath)
                        fName = IO.Path.GetFileNameWithoutExtension(strDir & origFilePath) & fileExt
                    End If
                Else
                    fName = origFilePath
                End If


                fName = ImportAttachDocToPdf(sourceFile, strDir, fName)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
            End Try

            Return fName
        End Function

        Public Shared Function ImportAttachDocToPdf(ByVal sourceFile As String, ByVal destDir As String, ByVal fileName As String) As String
            Dim retVal As String = ""
            Dim strDir As String = destDir
            Dim fName As String = IO.Path.GetFileNameWithoutExtension(destDir & fileName)
            Dim fileExt As String = ""
            Try
                If sourceFile.Length = 0 Then
                    Return fileName
                    Exit Function
                End If

                fileExt = System.IO.Path.GetExtension(sourceFile)
                fileExt = fileExt.ToLower

                Select Case fileExt
                    Case ".docx", ".doc"
                        wordToPdf = New DevExpress.XtraRichEdit.RichEditControl
                        wordToPdf.LoadDocument(sourceFile)
                        wordToPdf.ExportToPdf(strDir & fName & ".pdf")
                        retVal = fName & ".pdf"
                    Case ".pdf"
                        My.Computer.FileSystem.CopyFile(sourceFile, strDir & fName & ".pdf", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        retVal = fName & ".pdf"
                    Case ".jpg", ".jpeg", ".bmp", ".png", ".tiff", ".gif"
                        'Try
                        Dim img As System.Drawing.Image
                        tempPdf = New pdfTemplate
                        Using Strm As System.IO.Stream = System.IO.File.OpenRead(sourceFile)
                            img = Image.FromStream(Strm)
                        End Using
                        tempPdf.imgFile.Image = img
                        tempPdf.ExportToPdf(strDir & fName & ".pdf")
                        retVal = fName & ".pdf"
                        'Catch ex As Exception
                        '    MessageBox.Show(GetAppName() & " - Invalid file type:" & ex.Message, GetAppName())
                        'End Try

                    Case Else
                        My.Computer.FileSystem.CopyFile(sourceFile, strDir & fName & fileExt, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        retVal = fName & fileExt

                End Select
            Catch ex As Exception
                MessageBox.Show(GetAppName() & " - Can't link file:" & ex.Message, GetAppName())
                Return fileName
            End Try
            Return retVal
        End Function

        Public Shared Sub DeleteAttachDoc(mainView As DevExpress.XtraGrid.Views.Grid.GridView, levelName As String, subDirectories As String)
            Dim mainGrid As DevExpress.XtraGrid.GridControl = mainView.GridControl
            Dim subView As DevExpress.XtraGrid.Views.Grid.GridView = mainGrid.FocusedView
            Dim pkey As String
            Dim FKeyParent As String
            Dim fName As String

            If subView.LevelName = levelName Then 'delete selected attached document
                pkey = subView.GetFocusedRowCellValue("PKey")
                fName = subView.GetFocusedRowCellValue("FilePath")

                If Not (pkey Is Nothing Or pkey = "") Then
                    Try
                        Kill(GenerateFilePath(subDirectories, fName))
                    Catch ex As Exception
                        LogErrors("DeleteAttachDoc() : " & ex.Message)
                    End Try
                    MPSDB.RunSql("DELETE FROM tblAttachDoc WHERE PKey='" & pkey & "'")
                End If

            Else 'delete all documents of parent record
                FKeyParent = mainView.GetFocusedRowCellValue("PKey")
                Dim dt As DataTable = MPSDB.CreateTable("SELECT * FROM tblAttachDoc WHERE FKeyParent='" & FKeyParent & "'")
                For i As Integer = 0 To dt.Rows.Count - 1
                    fName = dt.Rows(i).Item("FilePath")
                    Try
                        Kill(GenerateFilePath(subDirectories, fName))
                    Catch ex As Exception
                        LogErrors("DeleteAttachDoc() : " & ex.Message)
                    End Try
                Next
                MPSDB.RunSql("DELETE FROM tblAttachDoc WHERE FKeyParent='" & FKeyParent & "'")

            End If

        End Sub

        Public Shared Function GetAttachDocFilePath(MainGrid As DevExpress.XtraGrid.GridControl, subDirectories As String) As String
            Dim DocView As DevExpress.XtraGrid.Views.Grid.GridView = MainGrid.FocusedView
            Dim filePath As String = ""
            If Not IsNothing(DocView.GetRowCellValue(DocView.FocusedRowHandle, "FilePath")) Then
                filePath = DocView.GetRowCellValue(DocView.FocusedRowHandle, "FilePath").ToString
            End If
            Dim tempFilePath As String = ""
            If Not IsNothing(DocView.GetRowCellValue(DocView.FocusedRowHandle, "tempFilePath")) Then
                tempFilePath = DocView.GetRowCellValue(DocView.FocusedRowHandle, "tempFilePath").ToString
            End If

            If filePath.Length <> 0 Then
                Return GenerateFilePath(subDirectories, filePath)
            Else
                Return tempFilePath
            End If
        End Function


    End Class

#End Region

#Region "Info Help"
    Public Sub OpenHelpFile()

        Try

            'Help.ShowHelp(Nothing, GetAppPath() & "\..\..\Resources\MPS5Help.chm")
            Help.ShowHelp(Nothing, GetAppPath() & "\Help\MPS5.chm")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        End Try
    End Sub
#End Region

#Region "Config"
    'ADDED BY: tony20170404
    Public Class Config
        Dim Data As DataTable
        Dim Criteria As String

        Sub New()
            InitData()
        End Sub

        Sub New(_Criteria As String)
            InitData(_Criteria)
            Criteria = _Criteria
        End Sub

        Sub New(CodeList() As String)
            Dim _Criteria As String = ""
            If CodeList.Length > 0 Then
                For i As Integer = 0 To CodeList.GetUpperBound(0)
                    _Criteria = _Criteria & IIf(_Criteria.Length > 0, ", ", "") & _
                                    "'" & CodeList(i).ToString.Replace("'", "''") & "'"
                Next
                _Criteria = "Code In (" & _Criteria & ")"

            Else
                _Criteria = "1 = 0" 'means return no rows
            End If

            Criteria = _Criteria
            InitData(Criteria)

        End Sub

        Sub Refresh()
            InitData(Criteria)
        End Sub

        Sub InitData(Optional cCriteria As String = "")
            Data = New DataTable
            Data = MPSDB.CreateTable("SELECT * FROM dbo.tblconfig " & IIf(cCriteria.Length > 0, "WHERE " & cCriteria, ""))
        End Sub

        Function HasValue() As Boolean
            If Data.Rows.Count = 0 Then
                Return False
            Else
                Return Not IfNull(Data.Rows(0).Item("TextValue"), "").Equals("")
            End If
            Return Data.Rows.Count > 0
        End Function

        Function HasValue(Code As String) As Boolean
            Dim dv As DataView = New DataView(Data)

            If Code.Length = 0 Then
                Return False
                Exit Function
            End If
            dv.RowFilter = "Code = '" & Code & "'"
            If dv.Count = 0 Then
                Return False
            Else
                Return Not IfNull(dv(0).Item("TextValue"), "").Equals("")
            End If
        End Function

        Function GetValue() As String
            If Data.Rows.Count > 0 Then
                Return Data.Rows(0).Item("TextValue")
            Else
                Return ""
            End If
        End Function

        Function GetValue(Code As String) As String
            Dim dv As DataView = New DataView(Data)

            If Code.Length = 0 Then
                Return ""
                Exit Function
            End If
            dv.RowFilter = "Code = '" & Code & "'"
            If dv.Count > 0 Then
                Return IfNull(dv(0).Item("TextValue"), "")
            Else
                Return ""
            End If
        End Function

        Sub SaveValue(Code As String, Value As String)
            Dim dv As DataView = New DataView(Data)

            If Code.Length = 0 Then
                Exit Sub
            End If
            dv.RowFilter = "Code = '" & Code & "'"
            If dv.Count > 0 Then
                dv(0).Item("TextValue") = Value
                MPSDB.RunSql("UPDATE dbo.tblconfig SET TextValue = '" & Value & "' WHERE Code = '" & Code & "'")
            Else
                MPSDB.RunSql("INSERT INTO dbo.tblconfig VALUES('" & Code & "', '" & Value & "')")
            End If
        End Sub
    End Class
#End Region

#Region "BDO Remittance System"
    Public Class BDO
        Public Const BatchNoChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        Public Structure BDOInfoFields
            Const TieUpCode = "BDO_SHORTCODE"
            Const BatchNo = "BDO_NEXTBATCHNO"
            Const LocatorCode = "BDO_LOCATORCODE"
            Const FixedPassword = "BDO_FIXEDPWD"
            Const UseFixedPassword = "BDO_USEFIXEDPWD"
        End Structure

        Public Enum BDOInfo
            TieUpCode = 1
            CurrentBatchNo = 2
            NextBatchNo = 3
            LocatorCode = 4
        End Enum

        Public Structure BDOExportFields
            Const VslCode As String = "VslCode"
            Const VslName As String = "VslName"
            Const MCode As String = "MCode"
            Const ReferenceNo As String = "ReferenceNo"
            Const TranDate As String = "TranDate"
            Const SenderName As String = "SenderName"
            Const SenderAddr1 As String = "SenderAddr1"
            Const SenderAddr2 As String = "SenderAddr2"
            Const SenderPhone As String = "SenderPhone"
            Const ReceiverName As String = "ReceiverName"
            Const ReceiverAddr1 As String = "ReceiverAddr1"
            Const ReceiverAddr2 As String = "ReceiverAddr2"
            Const ReceiverPhone As String = "ReceiverPhone"
            Const ReceiverGender As String = "ReceiverGender"
            Const ReceiverDOB As String = "ReceiverDOB"
            Const TransactionType As String = "TransactionType"
            Const PayableCode As String = "PayableCode"
            Const BankCode As String = "BankCode"
            Const BranchName As String = "BranchName"
            Const AcctNo As String = "AcctNo"
            Const LandedCurrency As String = "LandedCurrency"
            Const LandedAmount As String = "LandedAmount"
            Const InstructionToBDO As String = "InstructionToBDO"
            Const InstructionToJbee As String = "InstructionToJbee"


        End Structure

        Public Shared Function ChangeNumToBatchNo(_value As Integer) As String
            Dim _grpctr As Integer
            Dim _minctr As Integer

            'get corresponding value for tens position
            _grpctr = (_value \ BDO.BatchNoChars.Length) + 1
            'get corresponding value for ones position
            _minctr = _value - ((_value \ (BDO.BatchNoChars.Length + 1)) * BDO.BatchNoChars.Length)
            Return Mid(BDO.BatchNoChars, _grpctr, 1) & Mid(BDO.BatchNoChars, _minctr, 1)
        End Function
    End Class

#End Region

#Region "Company ID"
    'Created by     Tony
    'Date Created:  2017-08-024
    'Remarks:       Modify procedures to generate in Stored Procedure 'GenerateCrewCompanyID'
    '               Procedure might vary depending on client procedure/requirement
    Sub GenerateCompanyID(CrewID As String)
        Dim ReplaceIfHasCrewID As Boolean = False

        If Not IfNull(CrewID, "").Equals("") Then
            Dim isSuccess As Boolean = False, ErrMessage As String = ""

            Try
                'Dim sp As New StoredProcedureCommand("GenerateCrewCompanyID")
                'With sp.Parameters
                '    .Add(New StoredProcedureCommand.SPParameter("CrewID", CrewID))
                '    .Add(New StoredProcedureCommand.SPParameter("ReplaceIfHasCrewID", 0))
                '    .Add(New StoredProcedureCommand.SPParameter("isSuccess", isSuccess))
                '    .Add(New StoredProcedureCommand.SPParameter("ErrMessage", ErrMessage))
                'End With
                'sp.Execute(StoredProcedureCommand.ReturnType.ReturnValue)



                'MPSDB.RunSql("EXEC dbo.GenerateCrewCompanyID '" & CrewID & "'", False)

                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim sqlConn As New SqlClient.SqlConnection

                Using sqlConn
                    sqlConn.ConnectionString = MPSDB.GetConnectionString

                    sqlConn.Open()

                    If sqlConn.State <> ConnectionState.Open Then
                        MsgBox("Failed to generate Company ID. Cannot open sql connection.", MsgBoxStyle.Critical)
                    Else

                        sqlComm.Connection = sqlConn

                        sqlComm.CommandText = "GenerateCrewCompanyID"
                        sqlComm.CommandType = CommandType.StoredProcedure

                        sqlComm.Parameters.AddWithValue("CrewID", CrewID)
                        sqlComm.Parameters.AddWithValue("ReplaceIfHasCrewID", ReplaceIfHasCrewID)

                        sqlComm.Parameters.Add("isSuccess", SqlDbType.Bit)
                        sqlComm.Parameters("isSuccess").Direction = ParameterDirection.Output

                        sqlComm.Parameters.Add("ErrMessage", SqlDbType.VarChar, 200)
                        sqlComm.Parameters("ErrMessage").Direction = ParameterDirection.Output

                        Try
                            sqlComm.ExecuteNonQuery()
                            isSuccess = sqlComm.Parameters("isSuccess").Value
                            ErrMessage = sqlComm.Parameters("ErrMessage").Value
                        Catch SqlEx As System.Data.SqlClient.SqlException
                            Dim myError As System.Data.SqlClient.SqlError
                            Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                            isSuccess = 0
                            For Each myError In SqlEx.Errors
                                ErrMessage = ErrMessage & " / " & (myError.Number & " - " & myError.Message)
                            Next
                        End Try


                    End If

                    sqlConn.Close()
                End Using
            Catch ex As Exception
                isSuccess = 0
                ErrMessage = ex.Message
                LogErrors("Failed to generate company id for crew with pkey [" & CrewID & "]")
            End Try

            If Not isSuccess And Not IfNull(ErrMessage, "").Equals("") Then
                MsgBox("Failed to generate company ID." & vbNewLine & "Error: " & ErrMessage, MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

#End Region

#Region "Validate by Administrator"
    Public Function ValidateByAdministrator() As Boolean
        If MPSDB.DLookUp("ID", "MSysSec_Users", 0, "Name = 'Administrator'").ToString.Equals(USER_ID.ToString) Then
            Return True
        Else
            Dim f As New frmValidateByAdministrator
            f.ShowDialog()
            If f.Canceled Then
                Return False
            Else
                Return f.Success
            End If
        End If
    End Function
#End Region

End Module



