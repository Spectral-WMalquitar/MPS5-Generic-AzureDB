Imports System.Reflection
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars
Imports System.IO
Imports MPS4.QuickAccessButtons
Imports DevExpress.XtraSplashScreen

Public Class frmCrewMain

    Dim clsAudit As New clsAudit 'neil
    Dim auditlogid As Long 'neil
    Dim clsSec As New clsSecurity
    Const NOT_ADMIN = 0
    Dim isadmin As Integer 'neiltest
    Dim contrVisible As Boolean
    Dim contr As Object
    Dim checkingPerm As Boolean
    Dim firstBtn As String = ""
    Dim FocusBtn As DevExpress.XtraBars.BarButtonItem
    Public Shared includeFormat As Boolean
    Dim prevContent As String = ""
    Dim favoriteButtons As New List(Of RibbonButton)
    Dim isTriggeredFromShortcut As Boolean = False
    Dim isTriggerFromCustomPressButton As Boolean = False
    Dim clsFeature As New clsFeatureMod

    Dim btncloseclicked As Boolean = False

    Private WithEvents frmCrewListFilter As New CrewListFilter

    Private SelectedLTPFilterValue As New Dictionary(Of String, String)

#Region "MainForm Requirements"
    Dim extAssembly As System.Reflection.Assembly
    Private WithEvents maincontent As New BaseControl.BaseControl
    Private WithEvents mainlist As New BaseControl.BaseList
    Dim ContentsObject As DataView
    Dim loading As Boolean = False
    Dim prevBtn As String = ""

    Private Sub frmCrewMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                    e.Cancel = False
                Else
                    'original statements for maincontent.CheckValidateFields()
                    AllowN = maincontent.CheckValidateFields()
                    If AllowN Then
                        e.Cancel = False
                    Else
                        If ALLOWNEXTS Then
                            e.Cancel = False
                        Else
                            e.Cancel = True
                        End If
                    End If
                End If
            Else
                e.Cancel = False
            End If
        End If
        'user session

        If Not btncloseclicked Then
            If Not e.Cancel Then 'neil 
                If MsgBox("Are you sure you want to exit the MPS5 Crew?", vbQuestion + vbYesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            End If
        End If


        If Not e.Cancel Then
            Dim bSuccess As Boolean = False

            '<!-- tony20171019
            Try
                clsAudit.propSQLConnStr = MPSDB.GetConnectionString 'neil
                clsAudit.saveAuditLog("User log out", USER_NAME, auditlogid, System.Environment.MachineName, 10,
                                       , , , , , "MPS Admin") 'neil
            Catch ex As Exception
                LogErrors("Failed save logout audit log when closing the Admin main form. Error: " & ex.Message)
            End Try

            Try
                bSuccess = USER_SESSION.Dispose(MPSDB)
            Catch ex As Exception
                LogErrors("Failed dispose user session when closing the Admin main form. Error: " & ex.Message)
            End Try
            '-->

            'clsAudit.propSQLConnStr = MPSDB.GetConnectionString 'neil
            'clsAudit.saveAuditLog("User log out", USER_NAME, auditlogid, System.Environment.MachineName, 0, , , , , , "MPS Crewing", Date.Now) 'neil
            'bSuccess = USER_SESSION.Dispose(MPSDB)
        End If
    End Sub

    'Form Load
    Private Sub frmCrewMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '///tony20170810 check if lost connection to db
        If Not CheckDatabaseConnection() Then Return
        '////

        clsSec.propSQLConnStr = MPSDB.GetConnectionString

        InitModule()
        CloseCustomLoadScreen()
        Me.RibbonControl.ApplicationCaption = GetAppName() & " - CREW " & MPSVersion
        SplashScreen1.Visible = False
        'InitUserSettings()
        ResetEditButtons()
        'clsSec.get_permissions_all(USER_ID)
        SelectTopItem()

        Call checkBtnPermissionAll() 'neil

        Dim retVal As Integer = 1
        Dim isAdmin As String = clsSec.isUserAdmin(USER_ID, retVal)
        If retVal = 1 Then
            bbiStartArchive.Visibility = BarItemVisibility.Never
        End If

        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        Me.Visible = True 'neil test 20160507
        'Me.MainPanel.SplitterPosition = 382

        ' show expiring document form when checked in user settings
        If CBool(GetUserSetting("ExpDocsAlert", "0")) And NotifExpDocs.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
            Call NotifExpDocs_ItemClick(Nothing, Nothing)
        End If

        Util.MainCrewFormRibbonControl = Me.RibbonControl
        If IsShowShortcutToRibbon() Then
            PopulateFavoriteButtonList()
        End If

        EnableReportConfig()    'added by tony20170228 - this enables the report configuration button/form which can be used for setting up report contents(pre-development)
        '                                                this is only available in DEBUG mode
        EnableKPIConfig()       'added by tony20170412 - this enables the report configuration button/form which can be used for setting up report contents(pre-development)
        '                                                this is only available in DEBUG mode

        Dim bOpenCrewReassignmentConfirmationForm As Boolean
        Call CheckCrewReassignmentNotification(bOpenCrewReassignmentConfirmationForm)
        If bOpenCrewReassignmentConfirmationForm Then
            CustomPressButton("ReassignCrewConfirm")
        End If
    End Sub

    ' form Closing
    Private Sub frmCrewMain_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    'Ribbon Controll Selected Page
    Private Sub RibbonControl_SelectedPageChanged(sender As System.Object, e As System.EventArgs) Handles RibbonControl.SelectedPageChanged
        Dim rib As DevExpress.XtraBars.Ribbon.RibbonControl = TryCast(sender, DevExpress.XtraBars.Ribbon.RibbonControl)
        'If rib.Pages("Activity").  Then CURR_ACT = "SON"

        If isTriggeredFromShortcut Then
            isTriggeredFromShortcut = False
            Return
        End If

        If isTriggerFromCustomPressButton Then
            Return
        End If

        If rib.SelectedPage.Name = "Activity" Then CURR_ACT = "SON"
        For Each container As DevExpress.XtraBars.Ribbon.RibbonPageGroup In rib.SelectedPage.Groups
            If IfNull(container.Tag, "").Equals("1") Then
                Dim i As Integer
                For i = 0 To container.ItemLinks.Count - 1
                    Try
                        If TypeOf (container.ItemLinks(i).Item) Is DevExpress.XtraBars.BarButtonItem Then
                            Dim x As DevExpress.XtraBars.BarButtonItem = container.ItemLinks(i).Item
                            loopchekdropdown(x)
                            If foundContentToLoad Then
                                foundContentToLoad = False
                                Exit Sub
                            End If
                            'If x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                            '    Dim popItems As DevExpress.XtraBars.PopupMenu = x.DropDownControl
                            '    For o As Integer = 0 To popItems.ItemLinks.Count - 1
                            '        If TypeOf (popItems.ItemLinks(o).Item) Is DevExpress.XtraBars.BarButtonItem Then
                            '            Dim button As DevExpress.XtraBars.BarButtonItem = popItems.ItemLinks(o).Item
                            '            If button.GroupIndex > 0 And button.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            '                x.Down = True
                            '                button.Down = True
                            '                prevBtn = button.Name
                            '                LoadContent(button.Name)
                            '                Exit Sub
                            '            End If
                            '        End If
                            '    Next
                            'ElseIf x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
                            '    If x.GroupIndex > 0 And x.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            '        x.Down = True
                            '        prevBtn = x.Name
                            '        LoadContent(x.Name)
                            '        Exit Sub
                            '    End If
                            'ElseIf x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                            '    If x.GroupIndex > 0 And x.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            '        x.Down = True
                            '        prevBtn = x.Name
                            '        LoadContent(x.Name)
                            '        Exit Sub
                            '    End If
                            'End If
                        End If
                    Catch ex As Exception
                        LogErrors("--Error Generated in RibbonControl_SelectedPageChanged() method in frmCrewMain.vb - Start --")
                        LogErrors(ex.Message)
                        LogErrors("--Error Generated in RibbonControl_SelectedPageChanged() method in frmCrewMain.vb - End--")

                    End Try
                Next
            End If
        Next
        'End If

    End Sub

    Dim foundContentToLoad As Boolean = False

    Sub loopchekdropdown(ByRef x As DevExpress.XtraBars.BarButtonItem)
        If foundContentToLoad Then
            Exit Sub
        End If
        If x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
            Dim popItems As DevExpress.XtraBars.PopupMenu = x.DropDownControl
            For o As Integer = 0 To popItems.ItemLinks.Count - 1
                If TypeOf (popItems.ItemLinks(o).Item) Is DevExpress.XtraBars.BarButtonItem Then
                    Dim button As DevExpress.XtraBars.BarButtonItem = popItems.ItemLinks(o).Item
                    ' If button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                    loopchekdropdown(button)
                    'Else
                    '    If Button.GroupIndex > 0 And Button.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                    '        x.Down = True
                    '        Button.Down = True
                    '        prevBtn = Button.Name
                    '        LoadContent(Button.Name)
                    '        Exit Sub
                    '    End If
                    'End If
                End If
            Next
        ElseIf x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
            If x.GroupIndex > 0 And x.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                x.Down = True
                prevBtn = x.Name
                LoadContent(x.Name)
                foundContentToLoad = True
                Exit Sub
            End If
        ElseIf x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
            If x.GroupIndex > 0 And x.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                x.Down = True
                prevBtn = x.Name
                LoadContent(x.Name)
                foundContentToLoad = True
                Exit Sub
            End If
        End If
    End Sub
    'Private Sub LoadContent2(ByVal cContent As String)
    '    loading = True
    '    prevBtn = cContent
    '    'tony20151007
    '    If Mid(cContent, IIf(cContent.Length < 7, 1, cContent.Length - 6)) = "_Report" Then
    '        LoadReportContent(cContent)
    '        Exit Sub
    '    End If

    '    'Dim gGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    '    'Dim nButton As DevExpress.XtraBars.BarButtonItem = RibbonControl.Items(cContent)
    '    'Dim nGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroupItemLinkCollection = TryCast(nButton.Links(0).Links, DevExpress.XtraBars.Ribbon.RibbonPageGroupItemLinkCollection)
    '    ''Ensure that the select item was selected.
    '    ''RibbonControl.SelectedPage = nGroup.PageGroup.Page
    '    'nButton.Down = True
    '    'nButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    '    RibbonControl.Minimized = False
    '    MainPanel.Visible = True

    '    If cContent <> maincontent.Name Then
    '        If cContent = "SOFF" Or cContent = "SICKONB" Or cContent = "PROM" Or cContent = "TRANS" Or cContent = "ASHACT" Or cContent = "GOBACK" Then cContent = "CrewActivity"

    '        Dim xrow As DataRowView() = ContentsObject.FindRows(cContent)
    '        Dim blList As String = Trim(xrow(0)("ObjectList"))
    '        Dim strDLL As String = Trim(xrow(0)("DLL")) 'original
    '        'Dim strDLL As String = UCase(RibbonControl.SelectedPage.Name)
    '        Dim strFilter As String = Trim(IfNull(xrow(0)("Filter"), ""))
    '        maincontent.CheckIFDataUpdated()
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        Try
    '            'mainlist.BaseControl = blList
    '            MainPanel.Panel2.Controls.Clear()
    '            maincontent.Dispose()
    '            extAssembly = System.Reflection.Assembly.Load(strDLL)
    '            'extAssembly = System.Reflection.Assembly.LoadFrom(GetAppPath() & "\" & strDLL & ".dll")
    '            maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
    '            prevBtn = maincontent.Name
    '            If blList = "" Then
    '                MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
    '                mainlist.Name = blList
    '            Else
    '                '============ OBJECLIST WIDTH ===================
    '                Dim PanelWidth As Integer = GetLayoutWidth(USER_ID, cContent, blList)
    '                If PanelWidth < 0 Then
    '                    MainPanel.SplitterPosition = CType(xrow(0)("ObjectListDefaultWidth"), Integer)
    '                Else
    '                    MainPanel.SplitterPosition = CType(PanelWidth, Integer)
    '                End If
    '                '============ OBJECLIST WIDTH ===================

    '                If mainlist.Name <> blList Then 'testing not fully tested Yet
    '                    mainlist.Dispose()
    '                    MainPanel.Panel1.Controls.Clear()
    '                    mainlist = extAssembly.CreateInstance(strDLL & "." & blList, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
    '                    mainlist.Name = blList
    '                    mainlist.BaseControl = maincontent.Name
    '                    If Not IsNothing(maincontent) Then
    '                        mainlist.bContent = maincontent
    '                    End If
    '                    If strFilter = "" Then
    '                        mainlist.ClearFilter()
    '                        'Place Filters here
    '                    Else
    '                        mainlist.SetFilter(strFilter)
    '                    End If
    '                    'For Layout
    '                    '======================= Layout =================
    '                    mainlist.SetListLayout(maincontent.Name)
    '                    Select Case cContent
    '                        Case "Crew", "CREW"
    '                            MainPanel.Panel2.Visible = False
    '                            MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
    '                        Case Else
    '                            MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
    '                    End Select
    '                    '======================= Layout =================

    '                    MainPanel.Panel1.Controls.Add(mainlist)
    '                    mainlist.DB = MPSDB
    '                    mainlist.RefreshData()
    '                    If Not strCrewListFilter.Equals("") Then
    '                        mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"}) 'Filter
    '                    End If
    '                End If

    '                mainlist.Dock = DockStyle.Fill
    '                maincontent.blList = mainlist
    '                maincontent.Name = cContent
    '            End If
    '            maincontent.Dock = DockStyle.Fill
    '            MainPanel.Panel2.Controls.Add(maincontent)
    '            maincontent.DB = MPSDB
    '            MAIN_CONTENT = maincontent.Name 'Added by Calvhin 20160202
    '            maincontent.RefreshData()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '        Me.Cursor = Cursors.Default

    '    ElseIf cContent = maincontent.Name And cContent = "CrewActivity" Then
    '        maincontent.ActivityCommand("SON")
    '    End If

    '    loading = False
    'End Sub
    'This Is used for forms using Single Object With Multiple Buttons

    Private Sub GetContentType()
        Select Case RibbonControl.SelectedPage.Name
            Case "rpAshWageAcct" 'Ashore Wage Accounts
                CONTENTTYPE = "ASH"
            Case "rpOnbWageAcct"
                CONTENTTYPE = "ONB"
        End Select

    End Sub

    Private Sub LoadContent(ByRef cContent As String)
        loading = True
        RibbonControl.Minimized = False
        Dim nButton As DevExpress.XtraBars.BarButtonItem
        Dim cObjID As String = cContent
        SelectedTab = RibbonControl.SelectedPage().Text
        'prevBtn = cContent 'tony20160817 - moved to section after the pressed button is verified ok and opened
        'Elmer  20160404

        '///tony20170810 check if lost connection to db
        If Not CheckDatabaseConnection() Then Return
        '////

        '///neil force log out
        CheckForceLogout("CREWING")
        '////

        'CheckUserSession(MPSDB, USER_SESSION)
        CheckAppVersion("CREWING", SQLServer, SQLID, SQLPW, , True)
        'tony20151007
        If Mid(cContent, IIf(cContent.Length < 7, 1, cContent.Length - 6)) = "_Report" Then
            prevBtn = cContent
            LoadReportContent(cContent)
            Exit Sub
        End If

        AppraisalChecklistMisc(cContent)

        Dim xrow As DataRowView()
        Dim blList As String = ""
        Dim strDLL As String = ""
        Dim strFilter As String = ""
        Dim strListDLL As String = ""
        Dim cContentWidth As Integer = 0
        Dim buttonName As String = cContent

        'Dim xrow As DataRowView() = ContentsObject.FindRows(cContent)
        'Dim blList As String = Trim(IfNull(xrow(0)("ObjectList"), ""))
        'Dim strDLL As String = Trim(IfNull(xrow(0)("DLL"), ""))
        'Dim strFilter As String = Trim(IfNull(xrow(0)("Filter"), ""))

        MainPanel.Visible = True
        Dim loadPanel As Boolean = False
        Dim ReloadPanel As Boolean = True
        Dim retVal As Integer = 1

        If SplashScreenManager.Default Is Nothing Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Loading Data ...") 'added by calvhin 20170118, moved by fords 20170306
        Try
            GetContentType() 'Get the Content Type for modules using same object
            If cContent = "SOFF" Or cContent = "SICKONB" Or cContent = "PROM" Or cContent = "TRANS" Or cContent = "ASHACT" Or cContent = "GOBACK" Then cContent = "CrewActivity"
            'If prevBtn = "CrewActivity_Amend" Or prevBtn = "ContractExtension" Then GoTo Refesh
            If cContent <> maincontent.Name Then
                If cContent = "AshCrewWages" Or cContent = "OnbCrewWages" Then cContent = "CrewWages"
                If cContent = "CrewListArchive" Then
                    cContent = "RecordSum"
                    bbiStartArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    SelectedTab = "Archive"
                Else
                    bbiStartArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    SelectedTab = ""
                End If

                If cContent = "ArchivedCrews" Or RibbonControl.SelectedPage().Text.Equals("Archive") Then
                    SelectedTab = "ArchiveCrews"
                    cContent = "RecordSum"
                End If

                xrow = ContentsObject.FindRows(cContent)
                If xrow.Length = 0 Then
                    MsgBox("'" & cContent & "' cannot be found in the application forms collection. Please consult your system administrator for assistance.", vbExclamation)
                    nButton = RibbonControl.Items(prevBtn)
                    'nButton.Down = True
                    CloseCustomLoadScreen()
                    Exit Sub
                End If
                blList = Trim(IfNull(xrow(0)("ObjectList"), ""))
                strDLL = Trim(IfNull(xrow(0)("DLL"), ""))
                strFilter = Trim(IfNull(xrow(0)("Filter"), ""))
                strListDLL = Trim(IfNull(xrow(0)("ListDLL"), ""))
                cContentWidth = CType(IfNull(xrow(0)("ObjectListDefaultWidth"), 418), Integer)

                If BRECORDUPDATEDs Then
                    If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                        ALLOWNEXTS = True
                        BRECORDUPDATEDs = False
                        'add additional exit statements
                        ReloadPanel = True
                    Else
                        'original statements for maincontent.CheckValidateFields()
                        If maincontent.CheckValidateFields Then
                            ReloadPanel = True
                        Else
                            If ALLOWNEXTS Then
                                ReloadPanel = True
                            Else
                                ReloadPanel = False
                            End If
                        End If
                    End If
                End If

                If ReloadPanel And Not BRECORDUPDATEDs Then
                    If prevBtn <> "TravelEvent_Returning" Then MainPanel.Panel2.Controls.Clear() 'Added by calvhin 20161125
                    maincontent.Dispose()
                    GC.Collect() 'calvhin 20170119
                    GC.WaitForPendingFinalizers() 'calvhin 20170119
                    extAssembly = System.Reflection.Assembly.Load(strDLL)
                    Try
                        'maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                        maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                        maincontent.ObjectIDContent = cObjID
                        maincontent.Name = cContent
                        'prevBtn = maincontent.Name
                    Catch ex As Exception
                        MsgBox("Failed to load a DLL [" & cContent & "] in frmCrewMain. Details : " & ex.Message)
                    End Try

                    prevBtn = maincontent.Name
                    If blList <> mainlist.Name Then
                        mainlist.Dispose()
                        GC.Collect() 'calvhin 20170119
                        GC.WaitForPendingFinalizers() 'calvhin 20170119
                        MainPanel.Panel1.Controls.Clear()
                        If blList <> "" Then
                            extAssembly = System.Reflection.Assembly.Load(strListDLL)
                            'mainlist = extAssembly.CreateInstance(strDLL & "." & blList, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                            mainlist = extAssembly.CreateInstance(strListDLL & "." & blList, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                            mainlist.SetListLayout(maincontent.Name)
                            mainlist.DB = MPSDB
                            mainlist.RefreshData()
                            'maincontent.blList = mainlist
                        Else
                            mainlist.Name = ""
                        End If
                    End If



                    If blList <> "" Then
                        mainlist.bContent = maincontent
                    End If

                    If maincontent.Name <> "BaseControl" Then
                        'nButton = RibbonControl.Items(maincontent.Name)
                        nButton = RibbonControl.Items(buttonName)
                        If Not IsNothing(nButton) Then
                            nButton.Down = True
                        End If
                    End If

                    'TODO: Show or hide the  Filter Info
                    If mainlist.Name.Equals("CrewActivityList") Or mainlist.Name.Equals("CrewList") Or mainlist.Name.Equals("CrewList_ActivityList") Then
                        Dim cFilterInfo As String = frmCrewListFilter.FilterInfoString
                        If cFilterInfo.Equals("") Then
                            SetFilterInfoVisibility(mainlist.Name, BarItemVisibility.Never)
                        Else
                            SetFilterInformation(mainlist.Name, frmCrewListFilter.FilterInfoString)
                            SetFilterInfoVisibility(mainlist.Name, BarItemVisibility.Always)
                        End If

                    Else
                        SetFilterInfoVisibility(mainlist.Name, BarItemVisibility.Never)
                    End If

                    loadPanel = True
                Else
                    If maincontent.Name <> "BaseControl" Then
                        'nButton = RibbonControl.Items(maincontent.Name)
                        If maincontent.Name = "CrewActivity" Then
                            nButton = RibbonControl.Items(prevContent)
                            prevBtn = prevContent
                            'tony20160817
                            'Replaced - Else : nButton = RibbonControl.Items(buttonName)   
                            'Else : nButton = RibbonControl.Items(IIf(prevBtn.Length > 0, prevBtn, buttonName))
                        Else
                            buttonName = prevBtn
                            nButton = RibbonControl.Items(buttonName)
                            'end tony
                        End If
                        nButton.Down = True
                    End If
                    loadPanel = False
                End If

            ElseIf cContent = maincontent.Name And cContent = "CrewActivity" Then

                If BRECORDUPDATEDs Then
                    If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                        ALLOWNEXTS = True
                        BRECORDUPDATEDs = False
                        'add additional exit statements
                        ReloadPanel = True
                    Else
                        'original statements for maincontent.CheckValidateFields()
                        If maincontent.CheckValidateFields Then
                            ReloadPanel = True
                        Else
                            If ALLOWNEXTS Then
                                ReloadPanel = True
                            Else
                                ReloadPanel = False
                            End If
                        End If
                    End If
                End If

                If ReloadPanel And Not BRECORDUPDATEDs Then
                    maincontent.ActivityCommand(CURR_ACT)
                    prevBtn = CURR_ACT
                Else
                    nButton = RibbonControl.Items(prevContent)
                    prevBtn = prevContent
                    nButton.Down = True
                End If
            ElseIf cContent = maincontent.Name And cContent = "CrewWages" Then 'Crew Wages Payroll
                maincontent.ActivityCommand("")
            ElseIf SelectedTab.Equals("Archive") Then
                mainlist.ActivateArchive()
                'mainlist.SetFilter("(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB')")
            ElseIf RibbonControl.SelectedPage().Text.Equals("Archive") Then
                mainlist.RefreshData()
                mainlist.ActivateArchive()
                'mainlist.SetFilter("(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB')")
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in LoadContent() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in LoadContent() method in frmCrewMain.vb - End--")

            MsgBox("frmCrewMain Generated an error with the following details : " & ex.Message, MsgBoxStyle.Critical, GetAppName)
            CloseCustomLoadScreen()
        End Try
        '========================================================================================
        If loadPanel Then
            'HideEditOptionBtn() 'hide buttons in Editing Options Group
            Me.Cursor = Cursors.WaitCursor
            Try
                '============ OBJECLIST WIDTH ===================
                Dim PanelWidth As Integer = GetLayoutWidth(USER_ID, cContent, blList)
                If PanelWidth < 0 Then
                    MainPanel.SplitterPosition = cContentWidth
                Else
                    MainPanel.SplitterPosition = CType(PanelWidth, Integer)
                End If
                '======================= Layout =================
                'mainlist.SetListLayout(maincontent.Name)
                Select Case cContent
                    Case "Crew", "CREW"
                        MainPanel.Panel2.Visible = False
                        MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
                    Case Else
                        MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                End Select
                '======================= Layout =================


                If blList = "" Then
                    MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
                Else
                    If strFilter = "" Then
                        mainlist.ClearFilter()
                    Else
                        mainlist.SetFilter(strFilter)
                    End If

                    'If Not strCrewListFilter.Equals("") Then
                    '    mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"}) 'Filter
                    'End If

                    MainPanel.Panel1.Controls.Add(mainlist)
                    'mainlist.DB = MPSDB
                    'mainlist.RefreshData()
                    mainlist.Dock = DockStyle.Fill
                    maincontent.blList = mainlist

                End If
                getDocFolder(MPSDB)
                maincontent.Dock = DockStyle.Fill
                MainPanel.Panel2.Controls.Add(maincontent)
                maincontent.DB = MPSDB
                maincontent.Name = cContent
                MAIN_CONTENT = maincontent.Name 'Added by Calvhin 20160202

                maincontent.LoadMainContentLayout() 'Added by Calvhin 20160405
                maincontent.RefreshData()
                prevBtn = cObjID 'tony20160817 - a button must only become a previous button after it had been loaded/opened

                'TODO: We'll find a suitable place to set and activate Archive and its filtering. WLM - 20160907
                If SelectedTab.Equals("Archive") Then
                    mainlist.ActivateArchive()
                    'mainlist.SetFilter("(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB')")
                ElseIf RibbonControl.SelectedPage().Text.Equals("Archive") Then
                    mainlist.RefreshData()
                    mainlist.ActivateArchive()
                    'mainlist.SetFilter("(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB')")
                End If

                'Onboard Wages (Use to hide)
                If maincontent.Name.Equals("PayAdvances") Then
                    rpgONBImports.Visible = True
                Else
                    rpgONBImports.Visible = False
                End If

            Catch ex As Exception
                LogErrors("--Error Generated in LoadContent() method in frmCrewMain.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in LoadContent() method in frmCrewMain.vb - End--")

                MsgBox(ex.Message, , GetAppName)
                CloseCustomLoadScreen()
            End Try
            Me.Cursor = Cursors.Default
        Else
            If RibbonControl.SelectedPage().Text.Equals("Archive") Then
                SelectedTab = "ArchiveCrews"
                mainlist.RefreshData()
                mainlist.ActivateArchive()
                'mainlist.SetFilter("(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB')")
            End If
        End If
        If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen() 'added by fords 20170306
        'GetAllButtons()
        loading = False

        '----------------------------------------------------------------
        'THIS PART HERE IS TO AUTO-REFRESH AND CHECK IF THERE ARE RESPONSE TO TRAVEL REQUESTS SENT TO GTravel
        'Removed by tony20181123 : Not Applicable to retrieve details from within intervals due to that everytime you pull a data, there is always something that will be pulled without telling whether it is new update or not
        'DoCheckForTravelRequestResponse()
    End Sub

    Private Sub AppraisalChecklistMisc(cContent As String)
        If (cContent.Equals("CrewChecklist")) Then
            rpgManualRefresh.Visible = False
            rpgFilter.Visible = True
            rpgIncludeFlaggedColors.Visible = False
            cmdPreviewReport.Visibility = BarItemVisibility.Always
        ElseIf (cContent.Equals("PlanChecklist")) Then
            rpgManualRefresh.Visible = True
            rpgFilter.Visible = False
            rpgIncludeFlaggedColors.Visible = True
            beiShowFlaggedColors.EditValue = GetAutoShowFlagColorInJoiningChecklist()
            cmdPreviewReport.Visibility = BarItemVisibility.Always
        ElseIf (cContent.Equals("Appraisal")) Then
            cmdPreviewReport.Visibility = BarItemVisibility.Always
        Else
            If RibbonControl.SelectedPage().Text.Equals("Crew") Then
                cmdPreviewReport.Visibility = BarItemVisibility.Never
            End If
        End If

    End Sub

    Private Function GetAutoShowFlagColorInJoiningChecklist() As Boolean
        Try
            Dim status As String = MPSDB.DLookUp("Value", "tblUserConfig", "False", "FKeyUserID = " & USER_ID & " AND Code = 'FlaggedColor'")

            If status.Equals("False") Then
                HasShowFlaggedColorsInJoiningChecklist = False
            Else
                HasShowFlaggedColorsInJoiningChecklist = True
            End If

        Catch ex As Exception
            LogErrors("--Error Generated in GetAutoShowFlagColorInJoiningChecklist() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetAutoShowFlagColorInJoiningChecklist() method in frmCrewMain.vb - End--")

            HasShowFlaggedColorsInJoiningChecklist = False
        End Try

        Return HasShowFlaggedColorsInJoiningChecklist
    End Function


    Private Function GetLayoutWidth(ByVal _UserID As Integer, ByVal _ObjectID As String, ByVal _ObjectList As String)
        Dim x As Integer = 0
        Dim _code As String = _ObjectID & "_" & _ObjectList & "_WIDTH"
        Dim xrow As DataRowView() = ContentsObject.FindRows(_ObjectID)
        x = IIf(GetUserSetting(_code) = "", 0, GetUserSetting(_code))
        'MPSDB.BeginReader("SELECT ObjectListWidth FROM dbo.tblUserLayout WHERE FKeyUserID='" & USER_ID & "' AND ObjectID='" & _ObjectID & "' AND ObjectList='" & _ObjectList & "'")
        'While MPSDB.Read()
        '    x = CType(MPSDB.ReaderItem("ObjectListWidth"), Integer)
        'End While
        'MPSDB.CloseReader()
        If x > 0 Then
            Return x
        Else
            Return CInt(xrow(0)("ObjectListDefaultWidth"))
        End If
    End Function

    'button Click
    Private Sub Contain_ItemClick(ByVal Sender As System.Object, ByVal a As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            Dim currBtn As String = ""
            'load item in the panel
            Dim rb As DevExpress.XtraBars.Ribbon.RibbonPage = TryCast(TryCast(Sender, DevExpress.XtraBars.Ribbon.RibbonBarManager).Form, DevExpress.XtraBars.Ribbon.RibbonControl).SelectedPage
            For Each gr As DevExpress.XtraBars.Ribbon.RibbonPageGroup In rb.Groups
                If gr.Tag = 1 Then
                    For Each btn As DevExpress.XtraBars.BarButtonItemLink In gr.ItemLinks
                        Dim xbtn As DevExpress.XtraBars.BarButtonItem = TryCast(btn.Item, DevExpress.XtraBars.BarButtonItem)
                        If xbtn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                            If hasItemClickedInDropDownMenu(xbtn) Then
                                ContainDropDown_ItemClick(xbtn)
                                'commented out by tony20171011
                                'Call resetReportsGovButtons(xbtn.Name, prevBtn)
                                xbtn.Down = True
                                Exit Sub
                            Else
                                xbtn.Down = False
                            End If
                        Else
                            If xbtn.Down = True Then
                                currBtn = xbtn.Name
                                If currBtn <> "TravelEvent_Returning" Then 'Added By calvhin Feb 02, 2016, description on TravelEvent_Returning_ItemClick
                                    If prevBtn <> currBtn Then
                                        prevContent = prevBtn
                                        If mainlist.Name <> "" And currBtn = "SOFF" Or currBtn = "SICKONB" Or currBtn = "PROM" Or currBtn = "TRANS" Or currBtn = "ASHACT" Or currBtn = "GOBACK" Or currBtn = "CrewActivity" Or currBtn = "CrewActivity_Amend" Or currBtn = "ContractExtension" Then mainlist.clearFind() 'Added by calvhin 20161006 need to clear
                                        LoadContent(currBtn)
                                        'commented out by tony20171011
                                        'Call resetReportsGovButtons(xbtn.Name, prevBtn)
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If

                    Next
                End If
            Next
        Catch ex As Exception
            LogErrors("--Error Generated in Contain_ItemClick() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in Contain_ItemClick() method in frmCrewMain.vb - End--")

            MsgBox(ex.Message)
        End Try
        'End If
    End Sub

    'neil 20170310
    Sub resetReportsGovButtons(currentBtnDownName As String, Optional prevBtnDownName As String = "")
        If currentBtnDownName <> "ReportGovIndi_Report" And currentBtnDownName <> "ReportGovMonthly_Report" And currentBtnDownName <> "Government_Report" Then
            Me.ReportGovIndi_Report.Down = False
            Me.ReportGovMonthly_Report.Down = False
        Else
            If currentBtnDownName = "Government_Report" And prevBtnDownName = "ReportGovIndi_Report" Then
                Me.ReportGovIndi_Report.Down = True
            Else
                Me.ReportGovIndi_Report.Down = False
            End If

            If currentBtnDownName = "Government_Report" And prevBtnDownName = "ReportGovMonthly_Report" Then
                Me.ReportGovMonthly_Report.Down = True
            Else
                Me.ReportGovMonthly_Report.Down = False
            End If

        End If
    End Sub


    Private Sub ContainDropDown_ItemClick(ByVal BarBtnItem As DevExpress.XtraBars.BarButtonItem)
        If BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
            Dim popItems As DevExpress.XtraBars.PopupMenu = TryCast(BarBtnItem.DropDownControl, DevExpress.XtraBars.PopupMenu)
            For i As Integer = 0 To popItems.ItemLinks.Count - 1
                If TypeOf (popItems.ItemLinks(i).Item) Is DevExpress.XtraBars.BarButtonItem Then
                    Dim button As DevExpress.XtraBars.BarButtonItem = TryCast(popItems.ItemLinks(i).Item, DevExpress.XtraBars.BarButtonItem)
                    If button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                        ContainDropDown_ItemClick(button)
                    ElseIf button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                        If button.Down Then
                            ContainSub_ItemClick(button)
                            Exit For
                        End If
                    End If
                End If
            Next
        Else
            ContainSub_ItemClick(BarBtnItem)
        End If
    End Sub

    Private Function hasItemClickedInDropDownMenu(ByVal BarBtnItem As DevExpress.XtraBars.BarButtonItem) As Boolean
        Dim ReturnValue As Boolean = False
        If BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
            Dim popItems As DevExpress.XtraBars.PopupMenu = TryCast(BarBtnItem.DropDownControl, DevExpress.XtraBars.PopupMenu)
            For i As Integer = 0 To popItems.ItemLinks.Count - 1
                If TypeOf (popItems.ItemLinks(i).Item) Is DevExpress.XtraBars.BarButtonItem Then
                    Dim button As DevExpress.XtraBars.BarButtonItem = TryCast(popItems.ItemLinks(i).Item, DevExpress.XtraBars.BarButtonItem)
                    If button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                        ReturnValue = hasItemClickedInDropDownMenu(button)
                    ElseIf button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                        If button.Down Then
                            ReturnValue = True
                            Exit For
                        End If
                    End If
                End If
            Next
        End If

        Return ReturnValue
    End Function

    Private Sub ContainSub_ItemClick(ByVal BarBtnItem As DevExpress.XtraBars.BarButtonItem)
        If prevBtn <> BarBtnItem.Name Then
            prevContent = prevBtn
            LoadContent(BarBtnItem.Name)
        End If
    End Sub
    'Show All Buttons
    Private Sub ResetRibbon()
        Me.Visible = False 'neil test 20160507
        Try
            Dim nPage As DevExpress.XtraBars.Ribbon.RibbonPage, nPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
            For Each nPage In RibbonControl.Pages
                For Each nPageGroup In nPage.Groups
                    nPageGroup.Visible = True
                    nPageGroup.ShowCaptionButton = False
                    If nPageGroup.Tag = 1 Then
                        InitRibbonItems(nPageGroup)
                    End If
                Next
            Next
            'neil Call checkBtnPermissionAll()
        Catch ex As Exception
            LogErrors("--Error Generated in ResetRibbon() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in ResetRibbon() method in frmCrewMain.vb - End--")

            MsgBox(ex.Message, , GetAppName)
        End Try
    End Sub

    Private Sub InitRibbonItems(ByVal container As DevExpress.XtraBars.Ribbon.RibbonPageGroup)
        Dim i As Integer, hasDown As Boolean = False
        container.Visible = True

        For i = 0 To container.ItemLinks.Count - 1
            Try
                If TypeOf (container.ItemLinks(i).Item) Is DevExpress.XtraBars.BarSubItem Then
                    Dim ctr As DevExpress.XtraBars.BarSubItem = container.ItemLinks(i).Item
                    For Each links As DevExpress.XtraBars.BarItemLink In ctr.ItemLinks
                        If TypeOf (links.Item) Is DevExpress.XtraBars.BarSubItem Then
                            Dim x As DevExpress.XtraBars.BarSubItem = links.Item
                            For Each itms As DevExpress.XtraBars.BarItemLink In x.ItemLinks
                                If TypeOf (itms.Item) Is DevExpress.XtraBars.BarButtonItem Then
                                    Dim btn As DevExpress.XtraBars.BarButtonItem = itms.Item
                                    If btn.GroupIndex > 0 Then
                                        AddHandler btn.ItemClick, AddressOf Contain_ItemClick
                                    End If
                                End If
                            Next
                        ElseIf TypeOf (links.Item) Is DevExpress.XtraBars.BarButtonItem Then
                            Dim btn As DevExpress.XtraBars.BarButtonItem = links.Item
                            If btn.GroupIndex > 0 Then
                                If btn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                                    SelPopUpRibbonItems(btn)
                                Else
                                    AddHandler btn.ItemClick, AddressOf Contain_ItemClick
                                End If
                            End If
                        End If
                    Next
                ElseIf TypeOf (container.ItemLinks(i).Item) Is DevExpress.XtraBars.BarButtonItem Then
                    Dim button As DevExpress.XtraBars.BarButtonItem = container.ItemLinks(i).Item
                    If button.GroupIndex > 0 Then
                        'MsgBox(button.Name & " - " & button.GetType.ToString)
                        If button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                            SelPopUpRibbonItems(button)
                        Else
                            AddHandler button.ItemClick, AddressOf Contain_ItemClick
                        End If
                    End If
                End If
            Catch ex As Exception
                LogErrors("--Error Generated in InitRibbonItems() method in frmCrewMain.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in InitRibbonItems() method in frmCrewMain.vb - End--")

                MsgBox(ex.Message)
            End Try
        Next
    End Sub

    Private Sub CustomPressButton(ButtonName As String)
        Dim i As Integer, hasDown As Boolean = False
        Dim container As DevExpress.XtraBars.Ribbon.RibbonPageGroup

        Dim ButtonToSelect As String = ""
        Dim TabToSelect As String = ""
        Dim TabIndexToSelect As Integer = -1

        For Each nPage In RibbonControl.Pages
            For Each nPageGroup In nPage.Groups
                nPageGroup.Visible = True
                nPageGroup.ShowCaptionButton = False
                If nPageGroup.Tag = 1 Then
                    container = nPageGroup

                    For i = 0 To container.ItemLinks.Count - 1
                        Try
                            If TypeOf (container.ItemLinks(i).Item) Is DevExpress.XtraBars.BarSubItem Then
                                Dim ctr As DevExpress.XtraBars.BarSubItem = container.ItemLinks(i).Item
                                For Each links As DevExpress.XtraBars.BarItemLink In ctr.ItemLinks
                                    If TypeOf (links.Item) Is DevExpress.XtraBars.BarSubItem Then
                                        Dim x As DevExpress.XtraBars.BarSubItem = links.Item
                                        For Each itms As DevExpress.XtraBars.BarItemLink In x.ItemLinks
                                            If TypeOf (itms.Item) Is DevExpress.XtraBars.BarButtonItem Then
                                                Dim btn As DevExpress.XtraBars.BarButtonItem = itms.Item
                                                If btn.GroupIndex > 0 Then
                                                    If btn.Name = ButtonName Then
                                                        btn.Down = True
                                                        'AddHandler btn.ItemClick, AddressOf Contain_ItemClick
                                                        ButtonToSelect = btn.Name
                                                        Exit For
                                                    End If
                                                End If
                                            End If
                                        Next
                                    ElseIf TypeOf (links.Item) Is DevExpress.XtraBars.BarButtonItem Then
                                        Dim btn As DevExpress.XtraBars.BarButtonItem = links.Item
                                        If btn.GroupIndex > 0 Then
                                            If btn.Name = ButtonName Then
                                                btn.Down = True
                                                ButtonToSelect = btn.Name
                                                Exit For
                                            End If

                                        End If
                                    End If
                                Next
                            ElseIf TypeOf (container.ItemLinks(i).Item) Is DevExpress.XtraBars.BarButtonItem Then
                                Dim btn As DevExpress.XtraBars.BarButtonItem = container.ItemLinks(i).Item
                                If btn.GroupIndex > 0 Then
                                    'MsgBox(button.Name & " - " & button.GetType.ToString)
                                    If btn.Name = ButtonName Then
                                        btn.Down = True
                                        ButtonToSelect = btn.Name
                                        Exit For
                                    End If

                                End If
                            End If
                        Catch ex As Exception
                            LogErrors("--Error Generated in CustomPressButton() method in frmCrewMain.vb - Start --")
                            LogErrors(ex.Message)
                            LogErrors("--Error Generated in CustomPressButton() method in frmCrewMain.vb - End--")

                            MsgBox(ex.Message)
                        End Try
                    Next

                    If ButtonToSelect <> "" Then Exit For

                End If
            Next

            If ButtonToSelect <> "" Then
                TabIndexToSelect = TryCast(nPage, RibbonPage).PageIndex
                Exit For
            End If
        Next

        If ButtonToSelect <> "" And TabIndexToSelect >= 0 Then
            isTriggerFromCustomPressButton = True
            RibbonControl.SelectedPage = RibbonControl.Pages(TabIndexToSelect)
            LoadContent(ButtonToSelect)
            isTriggerFromCustomPressButton = False
        End If
    End Sub

    Private Function SelRibbonItems(ByVal BarBtnItem As DevExpress.XtraBars.BarButtonItem) As Boolean
        Dim bool As Boolean = True
        If BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
            SelPopUpRibbonItems(BarBtnItem)
        ElseIf BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
            AddHandler BarBtnItem.ItemClick, AddressOf Contain_ItemClick
        ElseIf BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
            AddHandler BarBtnItem.ItemClick, AddressOf Contain_ItemClick
        End If
        Return bool
    End Function

    Private Function SelPopUpRibbonItems(ByVal BarBtnItem As DevExpress.XtraBars.BarButtonItem) As Boolean
        Dim bool As Boolean = True
        If BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
            Dim popItems As DevExpress.XtraBars.PopupMenu = TryCast(BarBtnItem.DropDownControl, DevExpress.XtraBars.PopupMenu)
            For i As Integer = 0 To popItems.ItemLinks.Count - 1
                If TypeOf (popItems.ItemLinks(i).Item) Is DevExpress.XtraBars.BarButtonItem Then
                    Dim button As DevExpress.XtraBars.BarButtonItem = TryCast(popItems.ItemLinks(i).Item, DevExpress.XtraBars.BarButtonItem)
                    If button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                        SelPopUpRibbonItems(button)
                    ElseIf button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                        SelRibbonItems(button)
                    End If
                End If
            Next
        ElseIf BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
            AddHandler BarBtnItem.ItemClick, AddressOf Contain_ItemClick
        ElseIf BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
            AddHandler BarBtnItem.ItemClick, AddressOf Contain_ItemClick
        End If
        Return bool
    End Function

    'User Login
    Private Sub Logon(Optional ByVal bloggedon As Boolean = False)
        Me.Visible = False
        Dim logfrm As New frmLogin("CREWING")

        CloseCustomLoadScreen()

        logfrm.modulename = "MPS Crewing "
        logfrm.ShowDialog(Me)

        'moved by tony20170315
        'was placed before initusersettings
        If USER_PASSWORD = DEFAULT_PASSWORD Then
            Dim frmchangepassword As New frmChangePassword(Me)
            frmchangepassword.ShowDialog()
            If Not frmchangepassword.is_saved Then
                End
            End If
        End If
        '---------------------------

        ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Prepairing the program ...")

        If Not logfrm.is_loggedon Then
            If bloggedon Then
                logfrm.Text = "Currently Logged in As: " & USER_NAME
                'neil test 20160507 Me.Visible = True
                'loading = False
                Exit Sub
            Else
                End
            End If
        Else
            clsAudit.propSQLConnStr = MPSDB.GetConnectionString 'neil
            clsAudit.saveAuditLog("User log in", USER_NAME, auditlogid, System.Environment.MachineName, 0,
                                   , , , , , "MPS Crewing") 'neil
            'neil test 20160507 Me.Show()

            'neil clsSec.get_permissions_all(USER_ID, , userPermDt) 'neil 20160915

            COMPANYID = MPSDB.GetConfig("COMPANYID")
            FEATUREKEY = MPSDB.GetConfig("FEATKEY")
            'FEATUREKEY = "Tu/UD3wEWNGi9i681yDpmg=="
            'FEATUREKEY = "X7YCTze+CVZuAWrMitsJHxT8uiET5fQ9UZY2nW4dMHw="
            clsFeature.filterTableByFeature(userPermDt, COMPANYID, FEATUREKEY)

        End If

        InitUserSettings()
        'neil test 20160507 Me.Visible = True
        UserHasDataFilter(, True)

        CloseCustomLoadScreen()
    End Sub

    Private Sub InitUserSettings()
        Try
            USER_INFO = New UserDetail
            Me.txtServerName.Caption = "Connected to: " & SQLServer
            Me.txtUserName.Caption = "Username: " & USER_NAME
            GetThemes()
            'tony20160822 - Changed ADMIN/CREWING to APPLICATION INFO
            'ContentsObject = New DataView(MPSDB.CreateTable("SELECT * FROM dbo.tblObjects WHERE Category='CREWING' OR Category='ADMIN/CREWING' OR Category = 'PAYROLL'"))
            ContentsObject = New DataView(MPSDB.CreateTable("SELECT * FROM dbo.tblObjects WHERE Category='CREWING' OR Category='APPLICATION INFO' OR Category = 'PAYROLL'"))
            'end tony
            ContentsObject.Sort = "ObjectID"
            ResetRibbon()
        Catch ex As Exception
            LogErrors("--Error Generated in InitUserSettings() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in InitUserSettings() method in frmCrewMain.vb - End--")

            MsgBox(ex.Message, , GetAppName)
        End Try

    End Sub

    Private Sub SetRibbonPageGroupVisibility(container As DevExpress.XtraBars.Ribbon.RibbonPageGroup, p2 As Boolean, Optional ByVal HidePage As Boolean = False)
        Dim i As Integer
        container.Visible = True
        For i = 0 To container.ItemLinks.Count - 1
            If CType(container.ItemLinks.Item(i).Item, DevExpress.XtraBars.BarButtonItem).Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then Exit Sub
        Next
        container.Visible = False
        If HidePage Then container.Page.Visible = False
    End Sub

    Private Sub mainlist_SelectionChange(ByVal send As String) Handles mainlist.OnSelectionChange
        If Not loading Then
            If BRECORDUPDATEDs Then
                If mainlist.bRecordDeleted Then
                    maincontent.RefreshData()
                End If
            Else
                maincontent.RefreshData()
            End If
        End If
    End Sub

    'Select Top item
    Private Sub SelectTopItem()
        'Select the first Button down
        ''No button is selected or the selected button is not visible
        Dim container As DevExpress.XtraBars.Ribbon.RibbonPageGroup, i As Integer
        'neilcomm Dim isadmin As Integer 'neil
        For Each container In RibbonControl.SelectedPage.Groups
            Dim x As DevExpress.XtraBars.BarButtonItem = container.ItemLinks(i).Item
            Dim xFlag As Boolean = False
            If container.Tag = 1 Then
                For cnt As Integer = 0 To container.ItemLinks.Count - 1
                    Dim BarBtnItems As DevExpress.XtraBars.BarButtonItem = container.ItemLinks(cnt).Item
                    If BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                        Dim popItems As DevExpress.XtraBars.PopupMenu = BarBtnItems.DropDownControl
                        For o As Integer = 0 To popItems.ItemLinks.Count - 1
                            If TypeOf (popItems.ItemLinks(o).Item) Is DevExpress.XtraBars.BarButtonItem Then
                                Dim button As DevExpress.XtraBars.BarButtonItem = popItems.ItemLinks(o).Item
                                ''neiltest
                                ''clsSec.isUserAdmin(USER_ID, isadmin)
                                'If isadmin = NOT_ADMIN Then
                                '    Permit = clsSec.hasNoViewPermission(button.Name, USER_ID, True)
                                '    button.Visibility = Permit
                                '    Debug.Print(button.Name)
                                '    If Permit = 0 Then
                                '        container.Page.Visible = True
                                '    End If
                                'End If
                                ''neiltest end
                                If button.GroupIndex > 0 And button.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                                    button.Down = True
                                    prevBtn = button.Name
                                    LoadContent(button.Name)
                                    Exit For
                                End If
                            End If
                        Next
                    ElseIf BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
                        ''neiltest
                        ''clsSec.isUserAdmin(USER_ID, isadmin)
                        'If isadmin = NOT_ADMIN Then
                        '    Permit = clsSec.hasNoViewPermission(BarBtnItems.Name, USER_ID, True)
                        '    BarBtnItems.Visibility = Permit
                        '    Debug.Print(BarBtnItems.Name)
                        '    If Permit = 0 Then
                        '        container.Page.Visible = True
                        '    End If
                        'Else
                        '    container.Page.Visible = True
                        'End If
                        ''neiltest end
                        If BarBtnItems.GroupIndex > 0 And BarBtnItems.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            BarBtnItems.Down = True
                            prevBtn = BarBtnItems.Name
                            LoadContent(BarBtnItems.Name)
                            Exit For
                        End If
                    ElseIf BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                        ''neiltest
                        ''clsSec.isUserAdmin(USER_ID, isadmin)
                        'If isadmin = NOT_ADMIN Then
                        '    Permit = clsSec.hasNoViewPermission(BarBtnItems.Name, USER_ID, True)
                        '    BarBtnItems.Visibility = Permit
                        '    Debug.Print(BarBtnItems.Name)

                        '    If Permit = 0 Then
                        '        container.Page.Visible = True
                        '    End If
                        'End If
                        ''neiltest end
                        If BarBtnItems.GroupIndex > 0 And BarBtnItems.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            BarBtnItems.Down = True
                            prevBtn = BarBtnItems.Name
                            LoadContent(BarBtnItems.Name)
                            Exit For
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    'Main form status Bar (currently on testing)
    Private Sub SetStatusBarCaption(ByVal sender As String, ByVal value As String, ByVal style As String) Handles maincontent.CustomStatusBarCaption
        Select Case UCase(style)
            Case "INFORMATION"
                Me.sbiInformation.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime
                Me.sbiInformation.Caption = value
            Case "WARNING"
                Me.sbiWarning.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime
                Me.sbiWarning.Caption = value
            Case "ERROR"
                Me.sbiWarning.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime
                Me.sbiWarning.Caption = value
            Case "CHECK"
                Me.sbiCheck.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime
                Me.sbiCheck.Caption = value
        End Select
    End Sub

    'Initialize the Module
    Private Sub InitModule()
        Me.Visible = False
        initDefaultIniFile()
        'Dim strDir As String = GetAppPath() & "\setting.ini"
        'Try
        '    Dim dirinfo As New System.IO.FileInfo(strDir)
        '    Dim dirsec As System.Security.AccessControl.FileSecurity = dirinfo.GetAccessControl
        '    dirsec.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule(Environment.UserDomainName & "\Administrator", System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.AccessControlType.Allow))
        '    System.IO.File.SetAccessControl(strDir, dirsec)
        'Catch ex As Exception
        '    LogErrors("--Error Generated in InitModule() method in frmCrewMain.vb - Start --")
        '    LogErrors(ex.Message)
        '    LogErrors("--Error Generated in InitModule() method in frmCrewMain.vb - End--")

        '    MsgBox(ex.Message)
        '    Application.Exit()
        'End Try
        'server Connection
        If SQLServer = "" And SQLID = "" And SQLPW = "" Then
            Dim frm As New frmConnect
            frm.ShowDialog()
            If SQLServer = "" Or SQLID = "" Or SQLPW = "" Then
                Me.Close()
                Exit Sub
            End If
        End If
        SplashScreen1.Visible = False
        CheckMPSLicense()
        CheckAppVersion("CREWING", SQLServer, SQLID, SQLPW)
        Logon()
        'neil test 20160507 Me.Visible = True
    End Sub

    'Page Group: Edit Options
    Private Sub ResetEditButtons()
        Dim nPage As DevExpress.XtraBars.Ribbon.RibbonPage, nPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        For Each nPage In RibbonControl.Pages
            For Each nPageGroup In nPage.Groups
                'nPageGroup.Visible = True
                If nPageGroup.Tag = 2 Then
                    nPageGroup.Visible = False
                    'For Each item As DevExpress.XtraBars.BarButtonItem In nPageGroup.ItemLinks
                    '    item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    'Next
                End If
            Next
        Next
    End Sub

    'Load new Baselist
    Private Sub LoadNewBaseList(ByVal strDLL As String, ByVal newBaseList As String, ByVal newMainContent As String, Optional refreshMaincontent As Boolean = False)
        Dim xrow As DataRowView() = ContentsObject.FindRows(maincontent.Name)
        extAssembly = System.Reflection.Assembly.Load(strDLL)
        If newBaseList <> "" Then
            If mainlist.Name <> newBaseList Then 'testing not fully tested Yet
                '============ OBJECLIST WIDTH ===================
                Dim PanelWidth As Integer = GetLayoutWidth(USER_ID, maincontent.Name, newBaseList)
                If PanelWidth < 0 Then
                    MainPanel.SplitterPosition = CType(xrow(0)("ObjectListDefaultWidth"), Integer)
                Else
                    MainPanel.SplitterPosition = CType(PanelWidth, Integer)
                End If
                '============ OBJECTLIST WIDTH ===================
                mainlist.Dispose()
                GC.Collect() 'calvhin 20170119
                GC.WaitForPendingFinalizers() 'calvhin 20170119
                MainPanel.Panel1.Controls.Clear()
                mainlist = extAssembly.CreateInstance(strDLL & "." & newBaseList, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                mainlist.Name = newBaseList
                mainlist.bContent = maincontent
                'mainlist.BaseControl = cContent
                'If Not IsNothing(maincontent) Then
                '    mainlist.bContent = maincontent
                'End If
                'If strFilter = "" Then
                '    mainlist.ClearFilter()
                '    'Place Filters here
                'Else
                '    mainlist.SetFilter(strFilter)
                'End If
                'For Layout
                '======================= Layout =================
                mainlist.SetListLayout(maincontent.Name)
                'Dim PanelWidth As Integer = GetLayoutWidth(USER_ID, cContent, blList)
                'If PanelWidth < 0 Then
                '    MainPanel.SplitterPosition = xrow(0)("ObjectListDefaultWidth")
                'Else
                '    MainPanel.SplitterPosition = CType(PanelWidth, Integer)
                'End If
                'Select Case cContent
                '    Case "Crew", "CREW"
                '        MainPanel.Panel2.Visible = False
                '        MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
                '    Case Else
                '        MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                'End Select
                '======================= Layout =================

                MainPanel.Panel1.Controls.Add(mainlist)
                mainlist.DB = MPSDB
                mainlist.RefreshData()
                'If Not strCrewListFilter.Equals("") Then
                '    mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"}) 'Filter
                'End If
            End If

            mainlist.Dock = DockStyle.Fill
            maincontent.blList = mainlist
            MAIN_CONTENT = newMainContent
            If refreshMaincontent = True Then maincontent.RefreshData()
            maincontent.Name = newMainContent 'Need to change maincontent.name to so you can load the "Main" maincontent.
        End If
    End Sub
#End Region

#Region "Buttons"
    'Save Layout Button
    Private Sub cmdSaveLayout_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSaveLayout.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                    qSaveLayout()
                Else
                    'original statements for maincontent.CheckValidateFields()
                    AllowN = maincontent.CheckValidateFields()
                    If AllowN Then
                        qSaveLayout()
                    Else
                        If ALLOWNEXTS Then
                            qSaveLayout()
                        End If
                    End If
                End If
            Else
                qSaveLayout()
            End If
        End If
    End Sub

    'Save layout function
    Private Sub qSaveLayout()
        If MsgBox("Are you sure you want to save Layout? ", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            mainlist.BaseControl = maincontent.Name
            mainlist.SaveLayout()
            SaveLayoutWidth(USER_ID, maincontent.Name, mainlist.Name, MainPanel.Panel1.Width)
            maincontent.SaveMainContentLayout() 'Added by calvhin 20160405
            MsgBox("Layout Saved.", MsgBoxStyle.Information, GetAppName)
        End If
    End Sub
    'Save Layout Width
    Private Sub SaveLayoutWidth(ByVal _UserID As Integer, ByVal _ObjectID As String, ByVal _ObjectList As String, ByVal value As Integer)
        Dim flag As Boolean = False
        Dim _code As String = _ObjectID & "_" & _ObjectList & "_WIDTH"
        SaveUserSetting(_code, value)
    End Sub

    'Restore Layout Button
    Private Sub cmdResetLayout_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdResetLayout.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                    ResetLayout()
                Else
                    'original statements for maincontent.CheckValidateFields()
                    AllowN = maincontent.CheckValidateFields()
                    If AllowN Then
                        ResetLayout()
                    Else
                        If ALLOWNEXTS Then
                            ResetLayout()
                        End If
                    End If
                End If
            Else
                ResetLayout()
            End If
        End If
    End Sub

    Private Sub ResetLayout()
        If MsgBox("Are you sure you want to restore the original layout? ", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            Dim item As String = maincontent.Name
            ResetLayoutButton(mainlist, maincontent)
            maincontent.ResetMainContentLayout()
            'GetLayoutWidth(USER_ID, maincontent.Name, mainlist.Name)
            maincontent.Name = ""
            mainlist.Name = ""
            LoadContent(item)
        End If
    End Sub
    'View Button
    Private Sub cmdView_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdView.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ViewData"})
    End Sub

    'Change password button
    Private Sub cmdChangePass_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdChangePass.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                    ChangePassword()
                Else
                    'original statements for maincontent.CheckValidateFields()
                    AllowN = maincontent.CheckValidateFields()
                    If AllowN Then
                        ChangePassword()
                    Else
                        If ALLOWNEXTS Then
                            ChangePassword()
                        End If
                    End If
                End If
            Else
                ChangePassword()
            End If
        End If
    End Sub

    Private Sub ChangePassword()
        Dim ChngPass As New frmChangePassword(Me)
        ChngPass.ShowDialog()
    End Sub

    'Change User Button
    Private Sub cmdChangeUser_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdChangeUser.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                    If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        Me.Visible = False
                        LogoutUser()
                        Application.Restart()
                        'Logon()
                    End If
                Else
                    'original statements for maincontent.CheckValidateFields()
                    AllowN = maincontent.CheckValidateFields()
                    If AllowN Then
                        If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                            Me.Visible = False
                            LogoutUser()
                            Application.Restart()
                            'Logon()
                        End If
                    Else
                        If ALLOWNEXTS Then
                            If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                                Me.Visible = False
                                LogoutUser()
                                Application.Restart()
                                'Logon()
                            End If
                        End If
                    End If
                End If
            Else
                If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                    Me.Visible = False
                    LogoutUser()
                    Application.Restart()
                    'Logon()
                End If
            End If
        End If


        '20160526 neil Call checkBtnPermissionAll()

    End Sub

    Private Sub LogoutUser()
        Dim bSuccess As Boolean = False
        bSuccess = USER_SESSION.Dispose(MPSDB)
    End Sub

    'add button
    Private Sub cmdAdd_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdAdd.ItemClick
        If Not loading Then
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                Else
                    'original statements for maincontent.CheckValidateFields()
                    maincontent.CheckValidateFields()
                End If
            Else
                maincontent.AddData()
            End If
        End If
    End Sub

    Private Sub cmdEdit_DownChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdEdit.DownChanged
        'If cmdEdit.Down Then
        If Not loading Then
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                Else
                    'original statements for maincontent.CheckValidateFields()
                    maincontent.CheckValidateFields()
                End If
            End If
            maincontent.isEditdable = cmdEdit.Down
            maincontent.EditData()
        End If
        'Else

        'End If
    End Sub

    'edit button
    Private Sub cmdEdit_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdEdit.ItemClick
        '<!-- tony20171108 : below codes were removed and transferred to DownChanged event -->

        'If Not loading Then
        '    If BRECORDUPDATEDs Then
        '        maincontent.CheckValidateFields()
        '    End If
        '    maincontent.isEditdable = cmdEdit.Down
        '    maincontent.EditData()
        'End If

    End Sub

    'Save Button
    Private Sub cmdSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
        'comment out load screen, add manually on each save event
        Try
            'Try Catch and Loading Screen, Added By Calvhin 20170117
            'If SplashScreenManager.Default Is Nothing Then ShowCustomLoadScreen(GetType(MPS4.Waitform), "Saving ...")
            maincontent.SaveData()
            'If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen()
        Catch ex As Exception

            LogErrors("--Error Generated in cmdSave_ItemClick() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in cmdSave_ItemClick() method in frmCrewMain.vb - End--")

            'If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen()
        End Try
    End Sub

    'Delete Button
    Private Sub cmdDelete_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDelete.ItemClick
        maincontent.DeleteData()
    End Sub

    'Delete Sub Button
    Private Sub cmdDeleteSub_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDeleteSub.ItemClick
        maincontent.ExecCustomFunction(New Object() {"DeleteOther"})
    End Sub

    Private Sub EditOptionsVisibility(ByVal sender As String, ByVal value As Boolean) Handles maincontent.EditOptionsVisibility
        rpgEditOptions.Visible = value
        rpgONBWEditOptions.Visible = value 'Onboard Wage Ashore
        rpgAshWages.Visible = value
        rpgReportEditOptions.Visible = value 'added by tony20160902
        rpgCrewReassignEditOptions.Visible = value 'added by tony20161214

        'neil 20160831 /////////////////
        For Each group As DevExpress.XtraBars.Ribbon.RibbonPageGroup In Me.RibbonControl.SelectedPage.Groups
            If group.Text = "Editing Options" Then
                group.Visible = value
            End If
        Next
        'neil end
    End Sub

    Private Sub RibbonGroupTool(ByVal sender As Object, ByVal e As Boolean) Handles maincontent.RibbonGroupToolVisibility
        rpgONBWTool.Visible = e 'OnBoard Wages Tab Ribbon Control Group
    End Sub

#Region "Caption"
    'Captions
    Private Sub SetCalculatePayCaption(sender As String, value As String) Handles maincontent.CalculatePayCaption
        cmdRunPayroll.Caption = value
    End Sub

    Private Sub SetSaveCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomSaveCaption
        cmdSave.Caption = value
    End Sub
    Private Sub SetDeleteCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomDeleteCaption
        cmdDelete.Caption = value
    End Sub
    Private Sub SetAddCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomAddCaption
        cmdAdd.Caption = value
    End Sub
    Private Sub SetDeleteSubCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomDeleteSubCaption
        cmdDeleteSub.Caption = value
    End Sub
    Private Sub SetEditCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomEditCaption
        cmdEdit.Caption = value
    End Sub
    Private Sub SetPrintCaption(sender As String, value As String) Handles maincontent.CustomPrintListCaption
        cmdPrint.Caption = value
    End Sub
    Private Sub ExportToExcelCaption(sender As String, value As String) Handles maincontent.CustomExportToExcelCaption
        cmdExpCrewList.Caption = value
    End Sub
    Private Sub SetViewAttachmentCaption(sender As String, value As String) Handles maincontent.CustomViewAttachmentCaption
        cmdView.Caption = value
    End Sub
    Private Sub SetClearFilterCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomClearFilterCaption
        cmdClearFilter.Caption = value
    End Sub

    'neil
    Public Sub GetDeleteCaption(ByVal sender As String, ByRef value As String) Handles maincontent.CustomGetDeleteCaption
        value = cmdDelete.Caption
    End Sub

#End Region

#Region "Enable"
    'Enabled
    Private Sub EnableCalculatePay(sender As String, value As Boolean) Handles maincontent.CalclatePayAllow
        cmdRunPayroll.Enabled = value
    End Sub
    Private Sub EnableAdd(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowAdd
        cmdAdd.Enabled = value
    End Sub
    Private Sub EnableSave(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowSave
        cmdSave.Enabled = value
    End Sub
    Private Sub EnableDelete(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowDelete
        cmdDelete.Enabled = value
    End Sub
    Private Sub EnableEdit(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowEdit
        cmdEdit.Enabled = value
    End Sub
    Private Sub SetEditChecked(ByVal sender As String, ByVal value As Boolean) Handles maincontent.EditDown
        cmdEdit.Down = value
    End Sub
    Private Sub EnableDeleteSub(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowDeleteSub
        cmdDeleteSub.Enabled = value
    End Sub

    'Private Sub EnableUndo(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowUndo
    '    btnUndo.Enabled = value
    'End Sub

#End Region

#Region "Visibility"
    'Visiblility
    Private Sub SetCalculatePayVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.CalulatePayVisibility
        cmdRunPayroll.Visibility = value
    End Sub

    Private Sub SetViewAttachmentVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.CustomViewAttachmentVisibility
        cmdView.Visibility = value
    End Sub

    Private Sub AddVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.AddVisibility
        cmdAdd.Visibility = value
    End Sub

    Private Sub SaveVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.SaveVisibility
        cmdSave.Visibility = value
    End Sub

    Private Sub DeleteVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.DeleteVisibility
        cmdDelete.Visibility = value
    End Sub

    Private Sub DeleteCrewVisibilityButton(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.DeleteCrewVisibility
        DeleteCrew.Visibility = value
    End Sub

    Private Sub DeleteSubVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.DeleteSubVisibility
        cmdDeleteSub.Visibility = value
    End Sub

    Private Sub EditVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.EditVisibility
        cmdEdit.Visibility = value
    End Sub

    Private Sub ExportToExcelVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.CustomExportToExcelVisibility
        cmdExpCrewList.Visibility = value
    End Sub

    Private Sub GotoForm(sender As String, FormNameByButton As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.CustomGotoForm
        'cmdPrint.Visibility = value
    End Sub

    Private Sub PrintBiodataVisiblity(sender As String, value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.CustomPrintBiodataVisibility
        cmdPrint.Visibility = value
    End Sub

    Private Sub HideCrewReassignmentRequestVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.HideCrewReassignmentRequestVisibility
        cmdHideRequest.Visibility = value
    End Sub

    Private Sub HideRefreshListVisibility(ByVal sender As String, ByVal e As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.RefreshListVisibility
        cmdRefresh.Visibility = e
    End Sub

    Private Sub SortButtonVisibility(ByVal sender As String, ByVal e As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.SortButtonVisibility
        cmdSort.Visibility = e
    End Sub

    Private Sub FilterVisiblity(ByVal sender As String, ByVal e As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.FilterVisibility
        cmdFilter.Visibility = e
    End Sub

    Private Sub ClcmdClearCLFilterVisibility(ByVal sender As String, ByVal e As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ClearFilterButtonVisibility
        cmdClearCLFilter.Visibility = e
    End Sub

    Private Sub ActivityDocsRpgVisibility(Sender As Object, value As Boolean) Handles maincontent.ActivityDocsRpgVisibility
        If value Then

            Dim ret As Integer
            clsSec.isUserAdmin(USER_ID, ret)

            If ret = 1 And userPermDt.Select("Objectid='Activity_Docs'").Count > 0 Then
                Me.rpgActivityDocs.Visible = True
                Exit Sub
            End If

            If clsSec.hasNoViewPermission("Activity_Docs", USER_ID, True, userPermDt) = 0 Then
                Me.rpgActivityDocs.Visible = True
            End If
        Else
            Me.rpgActivityDocs.Visible = False
        End If
    End Sub

    Private Sub ActivityActivityDocsRpgVisibility(Sender As Object, value As Boolean) Handles maincontent.ActivityActivityDocsRpgVisibility
        ActivityActivityDocsRpgVisibility_main(value)
    End Sub

    Sub ActivityActivityDocsRpgVisibility_main(value As Boolean)
        If value Then

            Dim ret As Integer
            clsSec.isUserAdmin(USER_ID, ret)

            If ret = 1 And userPermDt.Select("Objectid='Activity_Docs'").Count > 0 Then
                Me.rpgActivityActivityDocs.Visible = True
                Exit Sub
            End If

            If clsSec.hasNoViewPermission("Activity_Docs", USER_ID, True, userPermDt) = 0 Then
                Me.rpgActivityActivityDocs.Visible = True
            End If
        Else
            Me.rpgActivityActivityDocs.Visible = False
        End If
    End Sub

    Private Sub ActivityDocsVisibility(ByVal sender As String, value As Boolean) Handles maincontent.ActivityDocsVisibility
        'Activity_Docs.Visibility = value
    End Sub
#End Region

#Region "Focus"
    Private Sub FocusOnMainForm(ByVal sender As Object) Handles maincontent.FocusOnMainForm
        SetForegroundWindow(Me.Handle)
    End Sub
#End Region

#End Region

#Region "Crewing"


#End Region

#Region "Activity"
    'Added By Calvhin
    Private Sub mainlist_AcceptedDragObject(ByVal sender As String) Handles mainlist.AcceptedDragObject
        maincontent.DeleteData()
    End Sub

    Private Sub CrewActivity_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SignOn.ItemClick
        CURR_ACT = "SON"
    End Sub

    Private Sub CrewActivity_Amend_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CrewActivity_Amend.ItemClick
        CURR_ACT = ""
    End Sub

    Private Sub SOFF_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SignOff.ItemClick, Promotion.ItemClick, Transfer.ItemClick, SickOnboard.ItemClick, AshoreActivity.ItemClick, GoBack.ItemClick
        CURR_ACT = e.Item.Name
    End Sub


#End Region

#Region "Planning"

#End Region

#Region "Travel"
    Private Sub TravelEvent_Returning_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TravelEvent_Returning.ItemClick
        If prevBtn <> "TravelEvent_Returning" Then
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                    LoadNewBaseList("Travel", "TravelEvent_VslList", "TravelEvent_Returning", True)
                    prevBtn = "TravelEvent_Returning"
                Else
                    'original statements for maincontent.CheckValidateFields()
                    If maincontent.CheckValidateFields = True Then
                        LoadNewBaseList("Travel", "TravelEvent_VslList", "TravelEvent_Returning", True)
                        prevBtn = "TravelEvent_Returning"
                    Else
                        TravelEvent_Returning.Down = False
                        TravelEventV2.Down = True
                    End If
                End If
            Else
                LoadNewBaseList("Travel", "TravelEvent_VslList", "TravelEvent_Returning", True)
                prevBtn = "TravelEvent_Returning"
            End If
        End If
    End Sub
#End Region

#Region "Reports"

    Sub EnableReportConfig()
        Try
            rpgReportConfig.Visible = (System.Diagnostics.Debugger.IsAttached And (UCase(USER_NAME) = "SPECTRAL"))
        Catch
            rpgReportConfig.Visible = False
        End Try
    End Sub

#Region "Advance Search"
    'Report Load Template Button
    Private Sub cmdLoadData_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdLoadData.ItemClick
        maincontent.ExecCustomFunction(New Object() {"LOADTEMPLATE"})
    End Sub
    'Report Export Button
    Private Sub cmdExport_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdExport.ItemClick
        maincontent.ExecCustomFunction(New Object() {"EXPORT"})
    End Sub
#End Region

#Region "Report Selection"

    'tony20151007
    Private Sub ShowListVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ShowListVisibility
        cmdShowSelectionList.Visibility = value
    End Sub

    Private Sub ApplyEnabled(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ApplyEnabled
        cmdApply.Enabled = value
    End Sub

    Private Sub PreviewReportVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.PreviewReportVisibility
        cmdPreviewReport.Visibility = value
    End Sub

    Private Sub ShowListEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.ShowListEnabled
        cmdShowSelectionList.Enabled = value
    End Sub

    Private Sub PreviewReportEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.PreviewReportEnabled
        cmdPreviewReport.Enabled = value
    End Sub

    Private Sub ViewRecordSumEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.ViewRecordSumEnabled
        cmdViewRecordSum.Enabled = value
    End Sub

    Private Sub ClearFilterEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.ClearFilterEnabled
        cmdClearFilter.Enabled = value
    End Sub

    Private Sub HideCrewReassignmentRequestEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.HideCrewReassignmentRequestEnabled
        cmdHideRequest.Enabled = value
    End Sub

    'tony20170104
    Private Sub LoadDataVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.LoadDataVisibility
        cmdLoadData.Visibility = value
    End Sub
    'end tony

    ''' <summary>
    ''' Use this to hide RibbonPageGroups by default
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HideRibbonPageGroup() Handles maincontent.HideRibbonPageGroup
        rpgReportOptions.Visible = False
        rpgPayrollReportOptions.Visible = False
        rpgKPIReportOptions.Visible = False
        rpgPrintOptions.Visible = False
        rpgKPIDisplayOptions.Visible = False
        rpgTravelRefresh.Visible = False
    End Sub

    Private Sub ShowRibbonPageGroup(ByVal sender As String, ByVal RibbonPageGroupName As String, ByVal value As Boolean) Handles maincontent.ShowRibbonPageGroup
        Dim btn As Object = Nothing
        For Each ribbonpage As DevExpress.XtraBars.Ribbon.RibbonPage In RibbonControl.Pages
            Try
                btn = ribbonpage.Groups(RibbonPageGroupName).Name
            Catch ex As Exception
                LogErrors("--Error Generated in ShowRibbonPageGroup() method in frmCrewMain.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in ShowRibbonPageGroup() method in frmCrewMain.vb - End--")

            End Try
            If Not btn Is Nothing Then
                ribbonpage.Groups(RibbonPageGroupName).Visible = value
                Exit For
            End If
        Next

    End Sub

    Private Sub ShowRibbonPageGroup_UsingArray(ByVal sender As String, ByVal RibbonPageGroupNameList As List(Of String), ByVal value As Boolean) Handles maincontent.ShowRibbonPageGroup_UsingArray
        Dim btn As Object = Nothing
        Dim RibbonPageGroupName As String = ""
        Dim RibbonPageGroupIndex As Integer

        'For i As Integer = 0 To RibbonPageGroupNameList.Count
        '    RibbonPageGroupName = RibbonPageGroupNameList(i)

        '    Try
        '        btn = RibbonControl.Pages.Item(RibbonPageGroupName)

        '        TryCast(RibbonControl.Pages.Item(RibbonPageGroupName), DevExpress.XtraBars.Ribbon.RibbonPage).Visible = False
        '    Catch ex As Exception

        '    End Try
        'Next

        For Each ribbonpage As DevExpress.XtraBars.Ribbon.RibbonPage In RibbonControl.Pages
            Try
                'For Each tmpRibbonPageGroupName As String In RibbonPageGroupNameList
                '    RibbonPageGroupName = tmpRibbonPageGroupName
                '    btn = ribbonpage.Groups(RibbonPageGroupName).Name
                'Next
                If RibbonPageGroupNameList.Count = 0 Then Exit For

                For i As Integer = RibbonPageGroupNameList.Count - 1 To 0 Step -1
                    RibbonPageGroupName = RibbonPageGroupNameList(i)
                    RibbonPageGroupIndex = i

                    btn = Nothing
                    Try
                        btn = ribbonpage.Groups(RibbonPageGroupName).Name
                    Catch ex As Exception
                        LogErrors("--Error Generated in ShowRibbonPageGroup_UsingArray() method in frmCrewMain.vb - Start --")
                        LogErrors(ex.Message)
                        LogErrors("--Error Generated in ShowRibbonPageGroup_UsingArray() method in frmCrewMain.vb - End--")

                        'do nothing. proceed to next item on list
                    End Try

                    If Not btn Is Nothing Then
                        ribbonpage.Groups(RibbonPageGroupName).Visible = value

                        RibbonPageGroupNameList.RemoveAt(RibbonPageGroupIndex)
                    End If
                Next

            Catch ex As Exception
                LogErrors("--Error Generated in ShowRibbonPageGroup_UsingArray() method in frmCrewMain.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in ShowRibbonPageGroup_UsingArray() method in frmCrewMain.vb - End--")

            End Try
            'If Not btn Is Nothing Then
            '    ribbonpage.Groups(RibbonPageGroupName).Visible = value
            '    RibbonPageGroupNameList.RemoveAt(RibbonPageGroupIndex)

            '    If RibbonPageGroupNameList.Count = 0 Then Exit For
            'End If
        Next

        'For Each ribbonpage As DevExpress.XtraBars.Ribbon.RibbonPage In RibbonControl.Pages
        '    Try
        '        'For Each tmpRibbonPageGroupName As String In RibbonPageGroupNameList
        '        '    RibbonPageGroupName = tmpRibbonPageGroupName
        '        '    btn = ribbonpage.Groups(RibbonPageGroupName).Name
        '        'Next
        '        If RibbonPageGroupNameList.Count = 0 Then Exit For
        '        For i As Integer = 0 To RibbonPageGroupNameList.Count - 1
        '            RibbonPageGroupName = RibbonPageGroupNameList(i)
        '            RibbonPageGroupIndex = i

        '            btn = Nothing
        '            Try
        '                btn = ribbonpage.Groups(RibbonPageGroupName).Name
        '            Catch
        '                'do nothing. proceed to next item on list
        '            End Try

        '            If Not btn Is Nothing Then
        '                ribbonpage.Groups(RibbonPageGroupName).Visible = value

        '                RibbonPageGroupNameList.RemoveAt(RibbonPageGroupIndex)
        '            End If
        '        Next

        '    Catch
        '    End Try
        '    'If Not btn Is Nothing Then
        '    '    ribbonpage.Groups(RibbonPageGroupName).Visible = value
        '    '    RibbonPageGroupNameList.RemoveAt(RibbonPageGroupIndex)

        '    '    If RibbonPageGroupNameList.Count = 0 Then Exit For
        '    'End If
        'Next

    End Sub
    'end tony

    Private Sub LoadReportContent(ByVal cContent As String)
        loading = True
        If Mid(cContent, cContent.Length - 6) <> "_Report" Then
            LoadContent(cContent)
            Exit Sub
        End If

        Dim btn As New DevExpress.XtraBars.BarButtonItem
        btn = Nothing
        btn = RibbonControl.Items(cContent)

        If btn Is Nothing Then Exit Sub

        If maincontent.Name <> cContent Then
            btn.Down = True
            mainlist.Name = ""
            maincontent.Name = ""

            '------------- SHOW REPORT SELECTION ----------------------
            Dim MainContentName = cContent
            'cContent = cContent.Replace("_Report", "")
            Dim rptSec As New Reports.ReportSelection
            'rptSec.SelectedReportGroup = cContent.Replace("_Report", "")   'cContent
            rptSec.SelectedReportGroup = Trim(IfNull(btn.Tag, ""))
            rptSec.HeaderCaption = Trim(IfNull(btn.Caption, ""))
            rptSec.SelectedMenuPage = Trim(IfNull(Ribbon.SelectedPage.Name, ""))
            maincontent = rptSec
            MainPanel.Panel2.Controls.Clear()
            MainPanel.Panel1.Controls.Clear()
            MainPanel.Panel2.Controls.Add(maincontent)
            maincontent.Dock = Windows.Forms.DockStyle.Fill
            MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
            maincontent.DB = MPSDB

            MAIN_CONTENT = cContent 'Added by Tony20170208

            maincontent.ObjectIDContent = cContent
            maincontent.RefreshData()
            '----------------------------------------------------------
            maincontent.Name = MainContentName
        End If
        btn.Down = True
        loading = False

    End Sub


    'tony20151007
    Private Sub cmdReportPreview_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdPreviewReport.ItemClick
        maincontent.ExecCustomFunction(New Object() {"PREVIEWREPORT"})
    End Sub

    'tony20151008
    'Show List
    Private Sub ShowSelectionList_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdShowSelectionList.ItemClick
        maincontent.ExecCustomFunction(New Object() {"SHOWLIST"})
    End Sub
    'end tony

    Private Sub CustomEvent(ByVal sender As String, ByVal param() As Object) Handles maincontent.OnCustomEvent, mainlist.OnCustomEvent
        'Unique commands
        Select Case param(0)
            Case "UpdateNotification"
                Try
                    'btnNotif.Glyph = System.Drawing.Image.FromFile(GetDefaultImagesPath() & param(1))
                Catch ex As Exception

                End Try
            Case "Preview"
                Try
                    Dim extAssembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(GetAppPath() & "\" & Trim(param(2)) & ".dll")
                    extAssembly.CreateInstance(Trim(param(2)) & "." & Trim(param(1)), True, Reflection.BindingFlags.Default, Nothing, New Object() {MPSDB, Trim(param(3))}, Nothing, Nothing)
                Catch ex As TargetInvocationException
                    LogErrors("--Error Generated in CustomEvent() method in frmCrewMain.vb - Start --")
                    LogErrors(ex.Message)
                    LogErrors("--Error Generated in CustomEvent() method in frmCrewMain.vb - End--")

                    MessageBox.Show(ex.Message)
                End Try

            Case "GoTo"
                'param(1) Kung saan mo gusto pumunta.
                'param(2) Caption ng page yung pupuntahan mo.
                rpgCrewing.Tag = "0"
                RibbonControl.SelectedPage = RibbonControl.Pages(param(2))
                rpgCrewing.Tag = "1"
                LoadContent(param(1))
                maincontent.ExecCustomFunction(New Object() {"LOADFROMPLANNINGEVENT", param(3)})
            Case "barChkShowAllPlanning"
                barChkShowAllPlanning.EditValue = CBool(GetUserSetting("ShowAllPlannings", "False"))
            Case "SetupLTPControls"
                Dim dtFilterMode As New DataTable
                Dim clm As New DataColumn
                clm.ColumnName = "FilterMode"
                clm.DataType = System.Type.GetType("System.String")
                dtFilterMode.Columns.Add(clm)
                dtFilterMode.Rows.Add(New Object() {"Vessel"})
                dtFilterMode.Rows.Add(New Object() {"Rank"})

                repLTPFilterMode.DataSource = dtFilterMode
                barLUEFilterMode.EditValue = Nothing
                barLTPLUE.EditValue = Nothing
                barLTPLUE.Caption = ":"

                lueLTPFilter.DataSource = Nothing
                If lueLTPFilter.Columns.Count = 0 Then
                    lueLTPFilter.ValueMember = "PKey"
                    lueLTPFilter.DisplayMember = "Name"
                    lueLTPFilter.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"))
                    lueLTPFilter.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey"))
                    lueLTPFilter.Columns("PKey").Visible = False
                End If

                'start load sort option
                Dim dtSortMode As New DataTable

                dtSortMode.Columns.Add(New DataColumn("PKey", System.Type.GetType("System.String")))
                dtSortMode.Columns.Add(New DataColumn("Name", System.Type.GetType("System.String")))

                dtSortMode.Rows.Add(New Object() {"AdmSort", "Rank"})
                dtSortMode.Rows.Add(New Object() {"DateSOn", "Date Sign On"})
                dtSortMode.Rows.Add(New Object() {"DateDue", "Date Due"})
                repLTPSortMode.DataSource = dtSortMode

                If repLTPSortMode.Columns.Count = 0 Then
                    repLTPSortMode.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"))
                    repLTPSortMode.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey"))
                    repLTPSortMode.Columns("PKey").Visible = False
                    barLUESortMode.EditValue = "AdmSort"
                End If

                Dim dtSortValue As New DataTable

                dtSortValue.Columns.Add(New DataColumn("PKey", System.Type.GetType("System.String")))
                dtSortValue.Columns.Add(New DataColumn("Name", System.Type.GetType("System.String")))

                dtSortValue.Rows.Add(New Object() {"ASC", "Ascending"})
                dtSortValue.Rows.Add(New Object() {"DESC", "Descending"})
                lueLTPSort.DataSource = dtSortValue

                If lueLTPSort.Columns.Count = 0 Then
                    lueLTPSort.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"))
                    lueLTPSort.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey"))
                    lueLTPSort.Columns("PKey").Visible = False
                    barLTPLUESort.EditValue = "ASC"
                End If
                'end load sort option

                If repColorSchemes.Columns.Count = 0 Then
                    repColorSchemes.ValueMember = "Index"
                    repColorSchemes.DisplayMember = "Caption"
                    repColorSchemes.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caption"))
                    repColorSchemes.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index"))
                    repColorSchemes.Columns("Index").Visible = False
                End If
                repColorSchemes.DataSource = maincontent.getColorSchemes()

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'below section for this CASE, added by tony20170727
                Dim defaultValue As Integer

                Dim dtUserSetting As DataTable = MPSDB.CreateTable("SELECT * FROM dbo.tblUserConfig WHERE FKeyUserID = " & IfNull(USER_ID, -1))
                Dim dvUserSetting As DataView = New DataView(dtUserSetting)
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'SET SHOW EMPTY VESSEL/RANK
                Try
                    Dim showEmptyVesselRank As Boolean
                    dvUserSetting.RowFilter = "Code = '" & UserSettingCode.LTP.ShowEmptyVesselRank & "'"
                    If dvUserSetting.Count > 0 Then
                        showEmptyVesselRank = dvUserSetting(0).Item("Value")
                        If VarType(showEmptyVesselRank) = vbBoolean Then
                            barLTPChk.EditValue = showEmptyVesselRank
                        Else
                            barLTPChk.EditValue = False
                        End If
                    End If

                Catch
                    barLTPChk.EditValue = False
                End Try

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'SET SCALE
                defaultValue = 51
                Try
                    Dim Width As Integer = defaultValue
                    dvUserSetting.RowFilter = "Code = '" & UserSettingCode.LTP.ColorScheme & "'"
                    If dvUserSetting.Count > 0 Then
                        Width = dvUserSetting(0).Item("Value")

                        If IfNull(Width, "").Equals("") Then Width = defaultValue

                        'Width = GetUserSetting(UserSettingCode.LTPScale, defaultValue)
                        'LTPTrackbar.edit
                        'Dim tbLTP As DevExpress.XtraEditors.TrackBarControl = TryCast(LTPTrackbar, DevExpress.XtraEditors.TrackBarControl)
                        LTPScaler.EditValue = Width
                    End If
                Catch
                    barColorScheme.EditValue = defaultValue
                End Try

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'SET COLOR SCHEME 
                defaultValue = 12
                Dim nColorScheme As Integer = -1
                Try
                    dvUserSetting.RowFilter = "Code = '" & UserSettingCode.LTP.ColorScheme & "'"
                    If dvUserSetting.Count > 0 Then
                        nColorScheme = dvUserSetting(0).Item("Value")

                        If IfNull(nColorScheme, "").Equals("") Then nColorScheme = defaultValue

                        If nColorScheme >= 0 And nColorScheme <= 12 Then
                            Dim dt As DataTable = TryCast(repColorSchemes.DataSource, DataTable)
                            Dim dv As DataView = New DataView(dt)
                            dv.RowFilter = "Index = " & IfNull(nColorScheme, defaultValue)
                            If dv.Count = 0 Then
                                nColorScheme = defaultValue
                            End If

                        Else
                            nColorScheme = defaultValue

                        End If

                    End If
                Catch
                    nColorScheme = defaultValue
                End Try

                Try
                    barColorScheme.EditValue = nColorScheme
                    Application.DoEvents()
                    maincontent.setLTPColorScheme(barColorScheme.EditValue)
                Catch
                End Try

            Case "SetupKPIControls"
                SetupKPIControls()
            Case "SetKPIChartView"
                maincontent.ExecCustomFunction(New Object() {"SETCHARTVIEW", barKPIChartView.EditValue})
            Case "RefreshKPIChartViewList"
                RefreshKPIChartViewList()
            Case "SetKPIColorPalette"
                maincontent.ExecCustomFunction(New Object() {"SETCOLORPALETTE", barKPIColorPalette.EditValue})
            Case "ViewAct"
                Dim frm As New frmActivityList(param(1))
                frm.ActBand.Caption = param(2)
                frm.PlanBand.Caption = param(2)
                frm.LDBand.Caption = param(2)
                frm.ShowDialog()
                frm.Dispose()
            Case "ViewExpDocs"
                mainlist.ExecCustomFunction(New Object() {"GetCrewList"}) 'generate ExpDocs Crewlist
                Dim frm As New frmPopExpDocs(param(1), mainlist.dtCrewList)
                frm.GridBand1.Caption = param(2)
                frm.ShowDialog()
                If frm.isPressedGoTo = True Then CustomEvent(Name, New Object() {"GoTo", "Document", "Crewing"})
                frm.Dispose()

            Case "SetUpTravelEventControls"
                rpgTravelFilter.Visible = True
                rpgTravelEventSearch.Visible = True
                cmdPreviewReport.Visibility = BarItemVisibility.Always
                cmdCancel.Visibility = BarItemVisibility.Never

            Case "SetUpTravelGTRSControls"
                rpgTravelFilter.Visible = False
                rpgTravelEventSearch.Visible = False
                cmdPreviewReport.Visibility = BarItemVisibility.Always
                cmdCancel.Visibility = BarItemVisibility.Never
                cmdRefresh.Visibility = BarItemVisibility.Always

                rpgTravel_EditingOptions.Visible = True
                cmdEdit.Visibility = BarItemVisibility.Always
                cmdAdd.Visibility = BarItemVisibility.Always
                cmdCancel.Visibility = BarItemVisibility.Always
                cmdDelete.Visibility = BarItemVisibility.Always
                cmdPreviewReport.Visibility = BarItemVisibility.Always

            Case "SetUpTravelGTRSConfigControls"
                rpgTravelFilter.Visible = False
                rpgTravelEventSearch.Visible = False
                cmdPreviewReport.Visibility = BarItemVisibility.Never
                cmdCancel.Visibility = BarItemVisibility.Never
                cmdRefresh.Visibility = BarItemVisibility.Never

                rpgTravel_EditingOptions.Visible = True
                cmdEdit.Visibility = BarItemVisibility.Always
                cmdAdd.Visibility = BarItemVisibility.Never
                cmdSave.Visibility = BarItemVisibility.Never
                cmdCancel.Visibility = BarItemVisibility.Never
                cmdDelete.Visibility = BarItemVisibility.Never
                cmdPreviewReport.Visibility = BarItemVisibility.Never

            Case "ShowCancelButton"

                If param(1) Then
                    cmdCancel.Visibility = BarItemVisibility.Always
                Else
                    cmdCancel.Visibility = BarItemVisibility.Never
                End If

            Case "HideTravelGTRSControls"

                rpgTravelFilter.Visible = True
                rpgTravelEventSearch.Visible = True
                cmdPreviewReport.Visibility = BarItemVisibility.Never
                cmdCancel.Visibility = BarItemVisibility.Always
                cmdRefresh.Visibility = BarItemVisibility.Never

                rpgTravel_EditingOptions.Visible = True

            Case "UnpressEditButtonDown"
                cmdEdit.Down = False


            Case "EnableDeleteCrew"
                'added by tony20190716 : Enables/disables the Delete Crew button
                Try
                    DeleteCrew.Enabled = param(1)
                Catch ex As Exception
                    LogErrors(ex.Message)
                End Try
                'end tony
        End Select
    End Sub

    Private Sub ExportVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ExportVisibility
        cmdExport.Visibility = value
    End Sub
    Private Sub ClearFilterVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ClearFilterVisibility
        cmdClearFilter.Visibility = value
    End Sub
    Private Sub SetClearFilterEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.ClearFilterEnabled
        cmdClearFilter.Enabled = value
    End Sub
    Private Sub cmdClearFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClearFilter.ItemClick
        maincontent.ExecCustomFunction(New Object() {"CLEARFILTER"})
    End Sub
    Private Sub SetApplyEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.ApplyEnabled
        cmdApply.Enabled = value
    End Sub

    Private Sub AllowLoadT(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowLoadT
        cmdLoadData.Enabled = value
    End Sub

    Private Sub AllowShowHideT(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowShowHideT
        barKPIShowHideTemplates.Enabled = value
    End Sub

    Private Sub ApplyVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ApplyVisibility
        cmdApply.Visibility = value
    End Sub
#End Region

#Region "Payroll Reports"
    'tony20170118
    Private Sub QuickReportsVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.QuickReportsVisibility
        cmdQuickReports.Visibility = value
    End Sub

    Private Sub SetQuickReportsCaption(sender As String, value As String) Handles maincontent.QuickReportsCaption
        cmdQuickReports.Caption = value
    End Sub

    'end tony
#End Region
#End Region

#Region "Competence"

#End Region

#Region "DMS"
    Private Sub cmdDownload_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDownload.ItemClick
        maincontent.DownloadDMSFiles()
    End Sub

    Private Sub cmdPrintFile_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdPrintFile.ItemClick
        maincontent.PrintDMSFiles()
    End Sub
    Private Sub cmdBulk_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdBulk.ItemClick
        If Not loading Then
            maincontent.CheckIFDataUpdated()
            maincontent.BulkUpload()
        End If
    End Sub

    Private Sub cmdSetFolder_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSetFolder.ItemClick
        Dim docfldr As String = getDocFolder(MPSDB)
        If docfldr <> "" Then
            If MessageBox.Show("Document Folder is set to """ & docfldr & """ do you want to change the directory?", GetAppName() & " - Document Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                FolderBrowserDialog1.ShowDialog()
                If IsNothing(FolderBrowserDialog1.SelectedPath) = False Then
                    MPSDB.RunSql("Update tblConfig SET [TextValue] ='" & FolderBrowserDialog1.SelectedPath & "' WHERE Code = 'DOCFOLDER'")
                End If
            End If
        Else
            FolderBrowserDialog1.ShowDialog()
            If IsNothing(FolderBrowserDialog1.SelectedPath) = False Then
                MPSDB.RunSql("Update tblConfig SET [TextValue] ='" & FolderBrowserDialog1.SelectedPath & "' WHERE Code = 'DOCFOLDER'")
            End If
        End If
    End Sub

    Private Sub btnNotif_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNotif.ItemClick
        'MsgBox("Server Name: " & SQLServer, , GetAppName)
        maincontent.openNotification()
    End Sub
#End Region

#Region "Archive"

#End Region

#Region "Log"

#End Region

#Region "Approval"

#End Region

#Region "Sorting and Filtering"
    Private Sub BarButtonItem1_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If MsgBox("Are you sure you want to change the connection of your database?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            Visible = False
            SQLServer = ""
            SQLID = ""
            SQLPW = ""
            If SQLServer = "" And SQLID = "" And SQLPW = "" Then
                Dim frm As New frmConnect
                frm.ShowDialog()
                If SQLServer = "" Or SQLID = "" Or SQLPW = "" Then
                    Close()
                    Exit Sub
                End If
            End If
            Dim frmMain As New frmCrewMain
            frmMain.Show()
        End If
    End Sub

    Private Sub LoadUserSettings()
        Dim frmUSett As New frmUserSetting
        frmUSett.ShowDialog(Me)
        tmr.Enabled = True
        Try
            If SAVE_EVENT_FIRED Then
                SAVE_EVENT_FIRED = False
                If Not IS_RESTARTING Then
                    mainlist.RefreshData()
                    If maincontent.Name = "LTP" Then
                        If SplashScreenManager.Default Is Nothing Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Loading data...")
                        maincontent.FilterLTPResource(barLTPLUE.EditValue, barLUEFilterMode.EditValue)
                        maincontent.LTPShowAllRecords(barLTPChk.EditValue, barLUEFilterMode.EditValue, barLTPLUE.EditValue)
                        maincontent.SortLTPResource(barLUESortMode.EditValue, barLTPLUESort.EditValue)
                        If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen()
                    End If
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in LoadUserSettings() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in LoadUserSettings() method in frmCrewMain.vb - End--")

        End Try
    End Sub
    Private Sub cmdUserSettings_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdUserSettings.ItemClick

        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                    ALLOWNEXTS = True
                    BRECORDUPDATEDs = False
                    'add additional exit statements
                    LoadUserSettings()
                Else
                    'original statements for maincontent.CheckValidateFields()
                    AllowN = maincontent.CheckValidateFields()
                    If AllowN Then
                        LoadUserSettings()
                    Else
                        If ALLOWNEXTS Then
                            LoadUserSettings()
                        End If
                    End If
                End If
            Else
                LoadUserSettings()
            End If
        End If
    End Sub

    Private Sub cmdSortNameASC_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSortNameASC.ItemClick
        'Updated by Calvhin Dec 09, 2015 (Updated If mainlist.Name <> "" Then *para di nag fifilter yung previous mainlist na naload)
        'Added  maincontent.applyCrewFilter(New Object() {"SortCrew_ASC"}) *para kung walang mainlist yung form pwede padin iaapply yung filter, syempre add mo muna applyCrewFilter to sa BaseControl
        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"SortCrew_ASC"})
        maincontent.applyCrewFilter(New Object() {"SortCrew_ASC"})
    End Sub

    Private Sub cmdSortNameDESC_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSortNameDESC.ItemClick
        'Updated by Calvhin Dec 09, 2015 (Updated If mainlist.Name <> "" Then *para di nag fifilter yung previous mainlist na naload)
        'Added  maincontent.applyCrewFilter(New Object() {"SortCrew_ASC"}) *para kung walang mainlist yung form pwede padin iaapply yung filter, syempre add mo muna applyCrewFilter to sa BaseControl
        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"SortCrew_DESC"})
        maincontent.applyCrewFilter(New Object() {"SortCrew_DESC"})
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        MsgBox("Server Name: " & SQLServer, , GetAppName)
    End Sub

    Private Sub cmdSortRank_ASC_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSortRank_ASC.ItemClick
        'Updated by Calvhin Dec 09, 2015 (Updated If mainlist.Name <> "" Then *para di nag fifilter yung previous mainlist na naload)
        'Added  maincontent.applyCrewFilter(New Object() {"SortCrew_ASC"}) *para kung walang mainlist yung form pwede padin iaapply yung filter, syempre add mo muna applyCrewFilter to sa BaseControl
        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"SortRank_ASC"})
        maincontent.applyCrewFilter(New Object() {"SortRank_ASC"})
    End Sub

    Private Sub cmdSortRank_DESC_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSortRank_DESC.ItemClick
        'Updated by Calvhin Dec 09, 2015 (Updated If mainlist.Name <> "" Then *para di nag fifilter yung previous mainlist na naload)
        'Added  maincontent.applyCrewFilter(New Object() {"SortCrew_ASC"}) *para kung walang mainlist yung form pwede padin iaapply yung filter, syempre add mo muna applyCrewFilter to sa BaseControl
        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"SortRank_DESC"})
        maincontent.applyCrewFilter(New Object() {"SortRank_DESC"})
    End Sub

    Private Sub cmdFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdFilter.ItemClick
        'Updated by Calvhin Dec 09, 2015 (Updated If mainlist.Name <> "" Then *para di nag fifilter yung previous mainlist na naload)
        'Added  maincontent.applyCrewFilter(New Object() {"SortCrew_ASC"}) *para kung walang mainlist yung form pwede padin iaapply yung filter, syempre add mo muna applyCrewFilter to sa BaseControl
        'Dim frmFilter As New CrewListFilter
        'neil test 20160507 Me.Visible = True
        frmCrewListFilter.ShowDialog(Me)
        If frmCrewListFilter.clickedApply = True Then 'this line only, added by calvhin 20170111
            If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"})
            maincontent.applyCrewFilter(New Object() {"CrewList_Filter"})
        End If
    End Sub

    Private Sub cmdClearCLFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClearCLFilter.ItemClick
        strCrewListFilter = ""
        oQuickFilter.Clear()
        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"})
        frmCrewListFilter.ClearFilter()
        maincontent.applyCrewFilter(New Object() {"CrewList_Filter"})
        'MsgBox("Filter Cleared", MsgBoxStyle.Information, GetAppName())
    End Sub

#End Region

    Private Sub RibbonControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs) Handles RibbonControl.SelectedPageChanging
        Me.Focus()
        'neil
        If checkingPerm Then
            e.Cancel = True
        End If
        'neil end
        Me.Focus()
        If Not IsNothing(mainlist) Then
            If Not IsNothing(maincontent) Then
                Dim AllowN As Boolean
                If BRECORDUPDATEDs Then
                    If Not mainlist.bRecordDeleted Then
                        If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                            ALLOWNEXTS = True
                            BRECORDUPDATEDs = False
                            'add additional exit statements
                            e.Cancel = Not True
                        Else
                            'original statements for maincontent.CheckValidateFields()
                            AllowN = maincontent.CheckValidateFields()
                            If AllowN Then
                                e.Cancel = Not True
                            Else
                                If ALLOWNEXTS Then
                                    e.Cancel = Not True
                                Else
                                    e.Cancel = Not False
                                End If
                            End If
                        End If
                    Else
                        e.Cancel = Not True
                    End If
                Else
                    e.Cancel = Not True
                End If
            End If
        End If

        If MAIN_CONTENT = "LTP" Then maincontent.closeFrmCrewList() 'Added By Calvhin 20160812
    End Sub

    Private Sub cmdPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdPrint.ItemClick
        'If mainlist.Name = "CrewList_ActivityList" Then
        '    mainlist.ExecCustomFunction(New Object() {"EXPORT_TO_EXCEL"})
        'Else
        're-paste past codes
        '=====
        Try
            Dim frmRptSel As New ReportSelectionInd(mainlist.GetFocusedRowData("IDNbr").ToString)
            frmRptSel.ShowDialog(Me)
        Catch ex As Exception
            LogErrors("--Error Generated in cmdPrint_ItemClick() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in cmdPrint_ItemClick() method in frmCrewMain.vb - End--")

            MsgBox("There is no selected record(s) to preview. Please try again.", vbInformation)
        End Try
        '=====
        'End If
        'maincontent.ExecCustomFunction(New Object() {"PREVIEWREPORT"}) 'Test Earlsan
    End Sub

    Private Sub NotifExpDocs_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotifExpDocs.ItemClick
        mainlist.ExecCustomFunction(New Object() {"GetCrewList"}) 'generate ExpDocs Crewlist
        Dim frm As New frmExpDocs(mainlist.dtCrewList)
        frm.ShowDialog()
        If frm.pressedGoto = True Then
            If MAIN_CONTENT <> frm.gotoContent Then
                LoadContent(frm.gotoContent)
            End If
            mainlist.SetSelection(selectedID)
            maincontent.RefreshData()
            maincontent.ExecCustomFunction(New Object() {"SelectRecord", frm.selectedGroup, frm.selectedKey})
        End If
    End Sub

    Private Sub cmdRefresh_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRefresh.ItemClick
        'ShowCustomLoadScreen(GetType(MPS4.Waitform), "Loading... Please Wait.")
        If SplashScreenManager.Default Is Nothing Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Loading data...") 'added by calvhin 20170118
        ''If mainlist.Name <> "CrewList_ActivityList" Then 'Temporary code
        'mainlist.RefreshData()
        ''End If
        If maincontent.Name = "LTP" Then
            maincontent.FilterLTPResource(barLTPLUE.EditValue, barLUEFilterMode.EditValue)
            maincontent.LTPShowAllRecords(barLTPChk.EditValue, barLUEFilterMode.EditValue, barLTPLUE.EditValue)
            maincontent.SortLTPResource(barLUESortMode.EditValue, barLTPLUESort.EditValue)
            If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen()
            Exit Sub

        ElseIf maincontent.Name = "Travel_GTRS" Then
            maincontent.ExecCustomFunction(New Object() {"REFRESH"})
        End If

        If Not mainlist.Name.Equals("CrewList_ActivityList") Then
            getCrewListDataTable(mainlist.bListSelect, "Automatic") 'Refresh CrewList
            mainlist.ExecCustomFunction(New Object() {"RefreshList"})
            mainlist.RefreshData()
            maincontent.RefreshData()
        Else
            mainlist.ExecCustomFunction(New Object() {"RefreshList"})
        End If

        'CloseCustomLoadScreen()
        If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen()
    End Sub

#Region "BUTTON_PERMISSION" '////////////////////////////////////////////////////////////////////

    Function checkBtnPermissionAll() As Boolean
        Dim nPage As DevExpress.XtraBars.Ribbon.RibbonPage, nPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Dim nPageFocus As String = ""
        Dim tempret As Boolean = False, ret As Boolean, flag As Boolean = False
        checkingPerm = True

        clsSec.isUserAdmin(USER_ID, isadmin)
        'If isadmin = NOT_ADMIN Then
        Try
            firstBtn = ""
            'userPermDt.Reset()
            'clsSec.get_permissions_all(USER_ID, , userPermDt)
            'neil 20160915 clsSec.get_permissions_all(USER_ID, , userPermDt)

            For Each nPage In RibbonControl.Pages
                tempret = False
                flag = False
                For Each nPageGroup In nPage.Groups
                    'nPageGroup.Visible = True
                    If nPageGroup.Tag = 1 Then
                        nPageGroup.Visible = True
                        'If nPageGroup.Tag = 1 Then
                        tempret = False
                        tempret = PermInitRibbonItems(nPageGroup)
                        'End If
                        Debug.Print(tempret & " " & nPageGroup.Name)
                        nPageGroup.Visible = tempret
                    End If
                    flag = flag Or tempret
                Next
                Debug.Print(flag & " " & nPage.Name)
                nPage.Visible = flag
                If tempret And nPageFocus = "" Then
                    nPageFocus = nPage.Name
                End If
            Next
            If firstBtn <> "" Then
                'LoadContent(firstBtn)
                focusBtnPermission(FocusBtn.Name)
            End If
            Me.RibbonControl.SelectedPage = Me.RibbonControl.Pages(nPageFocus)
            checkingPerm = False
            ret = True
        Catch ' ex As Exception
            'LogErrors("--Error Generated in checkBtnPermissionAll()  method in frmCrewMain.vb - Start --")
            'LogErrors(ex.Message)
            'LogErrors("--Error Generated in checkBtnPermissionAll() method in frmCrewMain.vb - End--")
            'MsgBox(ex.Message)
            ret = False
        End Try
        'Else
        'tempret = True
        'End If
        'checkingPerm = False
        Return ret
    End Function

    Function PermInitRibbonItems(ByVal container As DevExpress.XtraBars.Ribbon.RibbonPageGroup) As Boolean

        Dim tempRet As Boolean = False, finalRet As Boolean
        Try
            For i As Integer = 0 To container.ItemLinks.Count - 1
                Dim BarBtnItem As DevExpress.XtraBars.BarButtonItem = TryCast(container.ItemLinks(i).Item, DevExpress.XtraBars.BarButtonItem)
                'neil
                'container.Visible = False
                'contrVisible = False
                'contr = container

                'neil com-out
                'If Not PermSelRibbonItems(BarBtnItem) Then
                '    Exit Function
                'End If
                tempRet = PermSelRibbonItems(BarBtnItem)
                ''neil start
                'container.Visible = contrVisible
                'If contrVisible Then
                '    BarBtnItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                'Else
                '    BarBtnItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                'End If
                If tempRet Then
                    finalRet = True
                End If
            Next
        Catch ex As Exception
            LogErrors("--Error Generated in PermInitRibbonItems()  method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PermInitRibbonItems() method in frmCrewMain.vb - End--")
            MsgBox(ex.Message)
        End Try
        Return finalRet

    End Function

    Private Function PermSelRibbonItems(ByVal BarBtnItem As DevExpress.XtraBars.BarButtonItem) As Boolean
        Dim tempRet As Boolean = False

        Try
            If BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                tempRet = PermSelPopUpRibbonItems(BarBtnItem)

                If tempRet Then
                    BarBtnItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Else
                    BarBtnItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                End If

            ElseIf BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                tempRet = BtnVisible(BarBtnItem)
            ElseIf BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
                tempRet = BtnVisible(BarBtnItem)
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in PermSelRibbonItems()  method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PermSelRibbonItems() method in frmCrewMain.vb - End--")
            MsgBox(ex.Message)
        End Try
        Return tempRet
    End Function

    Private Function PermSelPopUpRibbonItems(ByVal BarBtnItem As DevExpress.XtraBars.BarButtonItem) As Boolean
        Dim tempRet As Boolean = False, finalRet As Boolean = False
        Try

            If BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                Dim popItems As DevExpress.XtraBars.PopupMenu = TryCast(BarBtnItem.DropDownControl, DevExpress.XtraBars.PopupMenu)
                'contrVisible = False
                'contr = BarBtnItem 
                For i As Integer = 0 To popItems.ItemLinks.Count - 1
                    If TypeOf (popItems.ItemLinks(i).Item) Is DevExpress.XtraBars.BarButtonItem Then
                        Dim button As DevExpress.XtraBars.BarButtonItem = TryCast(popItems.ItemLinks(i).Item, DevExpress.XtraBars.BarButtonItem)
                        If button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                            tempRet = PermSelPopUpRibbonItems(button)
                            If tempRet Then
                                button.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                            Else
                                button.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                            End If
                        ElseIf button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                            tempRet = PermSelRibbonItems(button)
                            If tempRet Then
                                finalRet = True
                            End If
                        End If
                    End If
                Next
                'BarBtnItem.Visibility = contrVisible 
            ElseIf BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                finalRet = BtnVisible(BarBtnItem)
            ElseIf BarBtnItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
                finalRet = BtnVisible(BarBtnItem)
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in PermSelPopUpRibbonItems()  method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PermSelPopUpRibbonItems() method in frmCrewMain.vb - End--")
            MsgBox(ex.Message)
        End Try
        Return finalRet
    End Function

    Function BtnVisible(btn As DevExpress.XtraBars.BarButtonItem, Optional ByRef errmsg As String = "") As Boolean
        Dim tempRet As Boolean
        Dim Permit As Integer

        Try
            'clsSec.isUserAdmin(USER_ID, isadmin)
            If isadmin = NOT_ADMIN Then
                '<!-- modified by tony20170926
                '       in the case of button Delete Crew, Delete permission instead View permission identifies if the 
                '       button is to be displayed or not
                If clsSec.CheckBtnVisibleSpecialPermission(btn.Name, USER_ID, Permit, True, userPermDt) Then
                    'this is if button has special permission. for example, Delete Crew
                Else
                    Permit = clsSec.hasNoViewPermission(btn.Name, USER_ID, True, userPermDt)
                End If
                'Permit = clsSec.hasNoViewPermission(btn.Name, USER_ID, True, userPermDt)
                '-->

                btn.Visibility = Permit
                'Debug.Print(btn.Name)
                If Permit = 0 Then
                    'cntr.page.Visible = True
                    'contr.Visibility = Permit
                    'contrVisible = True
                    tempRet = True
                Else
                    tempRet = False
                    'AddHandler btn.ItemClick, AddressOf Contain_ItemClick
                End If
            Else
                'AddHandler btn.ItemClick, AddressOf Contain_ItemClick
                If USER_NAME = "Spectral" Then
                    btn.Visibility = BarItemVisibility.Always
                    tempRet = True
                Else
                    If userPermDt.Select("Objectid='" & btn.Name & "'").Count > 0 Then 'feature filter
                        btn.Visibility = BarItemVisibility.Always
                        tempRet = True
                    Else
                        btn.Visibility = BarItemVisibility.Never
                        tempRet = False
                    End If
                End If

            End If

            If tempRet Then
                If firstBtn = "" Then
                    firstBtn = btn.Name
                    FocusBtn = btn
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in BtnVisible()  method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in BtnVisible() method in frmCrewMain.vb - End--")

            tempRet = False
            errmsg = Err.Description
        End Try

        Return tempRet

    End Function

    Function focusBtnPermission(ObjectID As String) As Boolean
        If isadmin = NOT_ADMIN Then

            If clsSec.hasViewOnlyPermission(ObjectID, USER_ID, True) = 0 Then
                Me.cmdEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdDeleteSub.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                'Me.cmdDataTool.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                'SetEditOptionsVisibility(ObjectID, False)

            Else
                Me.cmdEdit.Visibility = clsSec.hasNoUpdatePermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                Me.cmdAdd.Visibility = clsSec.hasNoAddPermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                Me.cmdDeleteSub.Visibility = clsSec.hasNoDeletePermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                Me.cmdDelete.Visibility = clsSec.hasNoDeletePermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                Me.cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
                'Me.cmdDataTool.Visibility = clsSec.hasNoDataToolPermission(ObjectID, USER_ID, True, userPermDt)
                ' SetEditOptionsVisibility(ObjectID, True)
            End If
        Else
            Me.cmdEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdDeleteSub.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            'Me.cmdDataTool.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            'SetEditOptionsVisibility(ObjectID, False)

        End If

        Return True
    End Function

    'Private Sub RibbonControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs) Handles RibbonControl.SelectedPageChanging
    '    If checkingPerm Then
    '        e.Cancel = True
    '    End If
    'End Sub

#End Region '/////////////////////////////////////////////////////////////////////////////////////

    Private Sub cmdExpCrewList_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdExpCrewList.ItemClick
        If mainlist.Name = "CrewList_ActivityList" Then
            mainlist.ExecCustomFunction(New Object() {"EXPORT_TO_EXCEL"})
        End If
        'comment out by fords: main function is for export of crewlist only
        'If mainlist.Name = "CrewList_ActivityList" Then
        '    mainlist.ExecCustomFunction(New Object() {"EXPORT_TO_EXCEL"})
        'Else
        '    Try
        '        Dim frmRptSel As New ReportSelectionInd(mainlist.GetFocusedRowData("IDNbr").ToString)
        '        frmRptSel.ShowDialog(Me)
        '    Catch ex As Exception
        '        MsgBox("There is no selected record(s) to preview. Please try again.", vbInformation)
        '    End Try
        'End If
    End Sub

    Private Sub CrewWages_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AshCrewWages.ItemClick
        CONTENTTYPE = "CrewWages"
    End Sub

    Private Sub cmdViewRecordSum_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdViewRecordSum.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ViewRecordSum"})
    End Sub

    Private Sub cmdHideRequest_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdHideRequest.ItemClick
        maincontent.ExecCustomFunction(New Object() {"HideRequest"})
    End Sub

#Region "LTP"
    Private Sub LTPTrackbar_EditValueChanged(sender As Object, e As System.EventArgs) Handles LTPTrackbar.EditValueChanged
        Dim tbLTP As DevExpress.XtraEditors.TrackBarControl = TryCast(sender, DevExpress.XtraEditors.TrackBarControl)
        maincontent.AdjustScaleWidth(tbLTP.Value)
    End Sub

    Private Sub chkLTPShowAll_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkLTPShowAll.CheckedChanged
        Dim chk As DevExpress.XtraEditors.CheckEdit = sender
        Try
            If SplashScreenManager.Default Is Nothing Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Loading Data ...") 'added by calvhin 20170118
            If Not IsNothing(barLUEFilterMode.EditValue) Then
                maincontent.FilterLTPResource(barLTPLUE.EditValue, barLUEFilterMode.EditValue)
                maincontent.LTPShowAllRecords(chk.Checked, barLUEFilterMode.EditValue, barLTPLUE.EditValue)
                maincontent.SortLTPResource(barLUESortMode.EditValue, barLTPLUESort.EditValue)
            End If
            If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen() 'added by calvhin 2017011 
        Catch ex As Exception
            LogErrors("--Error Generated in chkLTPShowAll_CheckedChanged() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in chkLTPShowAll_CheckedChanged() method in frmCrewMain.vb - End--")

            If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen() 'added by calvhin 2017011 
        End Try
    End Sub

    'Private Sub rbgLTPFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rbgLTPFilter.SelectedIndexChanged
    '    Dim rbgLTP As Object = TryCast(sender, DevExpress.XtraEditors.RadioGroup)
    '    If Not rbgLTP.EditValue Is Nothing Then
    '        Dim dt As DataTable = maincontent.GetLTPFilterDS(rbgLTP.EditValue)
    '        lueLTPFilter.DataSource = dt
    '        barLTPLUE.EditValue = dt.Rows(0).Item("PKey").ToString
    '    End If
    'End Sub

    Private Sub barLUEFilterMode_EditValueChanged(sender As Object, e As System.EventArgs) Handles barLUEFilterMode.EditValueChanged
        If Not IsNothing(barLUEFilterMode.EditValue) Then
            Dim dt As DataTable = maincontent.GetLTPFilterDS(barLUEFilterMode.EditValue)
            lueLTPFilter.DataSource = dt
            'barLTPLUE.EditValue = dt.Rows(0).Item("PKey").ToString
            barLTPLUE.Caption = barLUEFilterMode.EditValue & ":"

            Dim filterCaption As String = IIf(barLUEFilterMode.EditValue.Equals("Vessel"), "Rank", "Vessel")
            chkLTPShowAll.Caption = "Show All " & filterCaption & ":"

            barLTPSelectVesselRank.Caption = "Filter " & IIf(barLUEFilterMode.EditValue.Equals("Vessel"), "Rank(s)", "Vessel(s)")

            '<!-- added by tony20171218
            Try
                If Not SelectedLTPFilterValue.ContainsKey(barLUEFilterMode.EditValue) Then
                    SelectedLTPFilterValue.Add(barLUEFilterMode.EditValue, "")
                End If

                If IfNull(SelectedLTPFilterValue(barLUEFilterMode.EditValue), "").Length > 0 Then
                    barLTPLUE.EditValue = SelectedLTPFilterValue(barLUEFilterMode.EditValue)
                Else
                    barLTPLUE.EditValue = ""
                End If
            Catch ex As Exception
                LogErrors("Failed to load last selected vessel/rank in LTP. Error: " & ex.Message)
            End Try
            '-->

        End If
    End Sub

    Private Sub barLTPLUE_EditValueChanged(sender As Object, e As System.EventArgs) Handles barLTPLUE.EditValueChanged
        Try
            If SplashScreenManager.Default Is Nothing Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Loading Data ...") 'added by calvhin 20170118
            If Not IsNothing(barLUEFilterMode.EditValue) Then
                maincontent.setLTPColorScheme(barColorScheme.EditValue)
                maincontent.FilterLTPResource(barLTPLUE.EditValue, barLUEFilterMode.EditValue)
                maincontent.LTPShowAllRecords(barLTPChk.EditValue, barLUEFilterMode.EditValue, barLTPLUE.EditValue)
                maincontent.SortLTPResource(barLUESortMode.EditValue, barLTPLUESort.EditValue)
            End If
            If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen() 'added by calvhin 2017011 
        Catch ex As Exception
            LogErrors("--Error Generated in barLTPLUE_EditValueChanged() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in barLTPLUE_EditValueChanged() method in frmCrewMain.vb - End--")

            If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen() 'added by calvhin 2017011 
        End Try

        '<!-- added by tony20171218
        Try
            SelectedLTPFilterValue(barLUEFilterMode.EditValue) = barLTPLUE.EditValue
        Catch ex As Exception
            LogErrors("Failed to save selected vessel/rank in LTP. Error: " & ex.Message)
        End Try
        '-->
    End Sub

    Private Sub barColorScheme_EditValueChanged(sender As Object, e As System.EventArgs) Handles barColorScheme.EditValueChanged
        maincontent.setLTPColorScheme(barColorScheme.EditValue)
    End Sub

    '<!-- added by tony20171213
    Private Sub RemoveLTPRelatedControls(ByVal sender As String) Handles maincontent.RemoveLTPRelatedControls
        'If Application.OpenForms().OfType(Of frmVesselRankSelection).Any Then
        '    MessageBox.Show("Opened")
        '    'Else
        '    '    Dim f2 As New Form2
        '    '    f2.Text = "form2"
        '    '    f2.Show()
        'End If

        For Each form In My.Application.OpenForms
            If (form.name = frmVesselRankSelection.Name) Then
                'form is loaded so can do work 
                'if you need to check whether it is actually visible
                If form.Visible Then
                    CType(form, frmVesselRankSelection).Close()
                    Exit Sub
                End If
            End If
        Next
    End Sub
    '-->
#End Region

    Private Sub cmdRunPayroll_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRunPayroll.ItemClick
        maincontent.ExecCustomFunction(New Object() {"RunPayroll"})

    End Sub

#Region "KPI"

    Sub EnableKPIConfig()
        Try
            rpgKPIConfig.Visible = (System.Diagnostics.Debugger.IsAttached And (UCase(USER_NAME) = "SPECTRAL"))
        Catch
            rpgKPIConfig.Visible = False
        End Try
    End Sub

    Private Sub SetupKPIControls()
        If repKPIChartView.DataSource Is Nothing Then
            repKPIChartView.DataSource = TryCast(maincontent.KPIGetMainFormCtlObject("repKPIChartView"), DataTable)
            barKPIChartView.EditValue = CInt(IfNull(maincontent.KPIGetMainFormCtlObject("DEFAULT_LOOKUP_CHARTVIEW"), 0))
            repKPIChartView.NullText = ""
            repKPIChartView.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey"))
            repKPIChartView.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"))
            repKPIChartView.Columns("PKey").Visible = False
            maincontent.ExecCustomFunction(New Object() {"SETCHARTVIEW", barKPIChartView.EditValue})
        End If

        If repKPIColorPalette.DataSource Is Nothing Then
            repKPIColorPalette.DataSource = TryCast(maincontent.KPIGetMainFormCtlObject("repKPIColorPalette"), DataTable)
            repKPIColorPalette.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey"))
            repKPIColorPalette.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"))
            repKPIColorPalette.Columns("PKey").Visible = False
            repKPIColorPalette.NullText = ""
            barKPIColorPalette.EditValue = GetUserSetting("KPIColorPalette", "Default")
            maincontent.ExecCustomFunction(New Object() {"SETCOLORPALETTE", barKPIColorPalette.EditValue})
        End If

        barKPIChkShowResultOnly.Checked = False
    End Sub

    Private Sub RefreshKPIChartViewList()
        Dim dt As DataTable = TryCast(maincontent.KPIGetMainFormCtlObject("repKPIChartView"), DataTable)
        repKPIChartView.DataSource = dt
        'barKPIChartView.EditValue = CInt(IfNull(maincontent.KPIGetMainFormCtlObject("DEFAULT_LOOKUP_CHARTVIEW", New Object() {barKPIChartView.EditValue}), 0))
        barKPIChartView.EditValue = CInt(IfNull(maincontent.KPIGetMainFormCtlObject("SELECTED_CHART_VIEW"), 0))
    End Sub

    Private Sub barKPIChartView_EditValueChanged(sender As Object, e As System.EventArgs) Handles barKPIChartView.EditValueChanged
        If IsNumeric(barKPIChartView.EditValue) Then
            maincontent.ExecCustomFunction(New Object() {"CHANGECHARTVIEW", barKPIChartView.EditValue})
        End If
    End Sub

    Private Sub btnKPIClearFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnKPIClearFilter.ItemClick
        maincontent.ExecCustomFunction(New Object() {"CLEARFILTER"})
    End Sub


    Private Sub barKPIColorPalette_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles barKPIColorPalette.EditValueChanged
        maincontent.ExecCustomFunction(New Object() {"CHANGECHARTCOLORPALETTE", barKPIColorPalette.EditValue})
    End Sub

    Private Sub barKPIPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barKPIPrint.ItemClick
        maincontent.ExecCustomFunction(New Object() {"PRINTCHART"})
    End Sub

    Private Sub barKPIGenerateResultItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barKPIGenerateResult.ItemClick
        maincontent.ExecCustomFunction(New Object() {"GENERATERESULT"})
    End Sub

    Private Sub barKPIClearChart_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barKPIClearChart.ItemClick
        maincontent.ExecCustomFunction(New Object() {"CLEARCHART"})
    End Sub

    Private Sub barKPIChkShowResultOnly_CheckedChanged(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barKPIChkShowResultOnly.CheckedChanged
        maincontent.ExecCustomFunction(New Object() {"SHOWRESULTONLY", barKPIChkShowResultOnly.Checked})
    End Sub

    Private Sub KPIShowTemplateVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.KPIShowTemplateVisibility
        barKPIShowHideTemplates.Visibility = value
    End Sub

    Private Sub SetKPIShowTemplateCaption(sender As String, value As String) Handles maincontent.KPIShowTemplateCaption
        barKPIShowHideTemplates.Caption = value
    End Sub


#End Region

    'Private Sub btnUndo_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs)
    '    maincontent.undoChanges()
    'End Sub

    Private Sub btnCrewComments_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCrewComments.ItemClick
        maincontent.viewCrewComments()
    End Sub

    Private Sub chkIncludeLabeling_EditValueChanged(sender As Object, e As System.EventArgs) Handles chkIncludeLabeling.EditValueChanged
        Try
            Dim isSelected As Boolean = chkIncludeLabeling.EditValue
            includeFormat = isSelected
        Catch ex As Exception
            LogErrors("--Error Generated in chkIncludeLabeling_EditValueChanged() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in chkIncludeLabeling_EditValueChanged() method in frmCrewMain.vb - End--")

            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub chkIncludeLabeling_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkIncludeLabeling.ItemClick
    End Sub

    Private Sub lueLTPFilter_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles lueLTPFilter.EditValueChanging
        If BRECORDUPDATEDs Then
            If rpgEditOptions.Visible = False Or Me.cmdSave.Visibility = BarItemVisibility.Never Then
                ALLOWNEXTS = True
                BRECORDUPDATEDs = False
                'add additional exit statements
                e.Cancel = False
                barLTPLUE.EditValue = e.NewValue
            Else
                'original statements for maincontent.CheckValidateFields()
                e.Cancel = Not maincontent.CheckValidateFields()
                barLTPLUE.EditValue = e.NewValue
            End If

        End If
    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(sender As System.Object, e As System.EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub

    Private Sub frmCrewMain_LocationChanged(sender As Object, e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub bbiSelectAll_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSelectAll.ItemClick
        mainlist.SetAllSelected(True)
    End Sub

    Private Sub bbiDeselectAll_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiDeselectAll.ItemClick
        mainlist.SetAllSelected(False)
    End Sub

    Private Sub RecordSum_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RecordSum.ItemClick
        SelectedTab = ""
        mainlist.ActivateArchive()
    End Sub

    Private Sub bbiArchiveCrew_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CrewListArchive.ItemClick
        SelectedTab = "Archive"
        mainlist.ActivateArchive()
    End Sub

    Private Sub bbiStartArchive_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiStartArchive.ItemClick
        mainlist.RunSetToArchiveProcess()
    End Sub

    Private Sub bbiStartTransferToActive_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiStartTransferToActive.ItemClick
        mainlist.RunSetToActiveProcess()
    End Sub

    Private Sub ArchivedCrews_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ArchivedCrews.ItemClick
        SelectedTab = "ArchiveCrews"
        mainlist.RefreshData()
        rpgViewArchivedReport.Visible = False
        rpgArchiveProcess.Visible = True
        DeleteCrew.Visibility = BarItemVisibility.Always
    End Sub

    Private Sub Crew_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub Crew_ItemPress(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Crew.ItemPress

    End Sub


    Private Sub Biodata_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Biodata.ItemClick


    End Sub

    Private Sub Archived_Report_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Archived_Report.ItemClick
        rpgViewArchivedReport.Visible = True
        rpgArchiveProcess.Visible = False
    End Sub

#Region "Payroll"
    Private Sub PayrollList_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PayrollList.ItemClick
        maincontent.ExecCustomFunction(New String() {"PayrollList"})
    End Sub

    Private Sub PayrollListBtnVisibility(Sender As Object, value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.PayrollListVisibility
        PayrollList.Visibility = value
    End Sub

    Private Sub ProcessedPayrollListVisibility(Sender As Object, value As Boolean) Handles maincontent.ProcessedPayrollListVisibility
        rpgPayrollFilters.Visible = value
    End Sub
#End Region

    Private Sub PlanChecklist_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PlanChecklist.ItemClick
        rpgFilter.Visible = False
        rpgManualRefresh.Visible = True
        cmdPreviewReport.Visibility = BarItemVisibility.Always
    End Sub

    Private Sub CrewChecklist_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CrewChecklist.ItemClick
        rpgFilter.Visible = True
        rpgManualRefresh.Visible = False
        cmdPreviewReport.Visibility = BarItemVisibility.Always
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub bbiManualRefresh_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiManualRefresh.ItemClick
        maincontent.RefreshPlanningList()
    End Sub

    Private Sub beiShowFlaggedColors_ItemPress(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles beiShowFlaggedColors.ItemPress
        Me.Focus()
        If beiShowFlaggedColors.EditValue = False Then
            beiShowFlaggedColors.EditValue = True
        Else
            beiShowFlaggedColors.EditValue = False
        End If

        HasShowFlaggedColorsInJoiningChecklist = beiShowFlaggedColors.EditValue
        maincontent.ShowChecklistWithFlaggedColors()
    End Sub

    Private Sub btnTravelSearch_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTravelSearch.ItemClick
        maincontent.ExecCustomFunction(New Object() {"TravelSearch"})
    End Sub

    Private Sub barKPIShowHideTemplates_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barKPIShowHideTemplates.ItemClick
        Dim bResultOnly As Boolean = maincontent.GetObjectFromMainContent(New Object() {"RESULTONLY"})

        If Not IsNothing(bResultOnly) Then
            If bResultOnly Then
                MsgBox("Unable to use Show/Hide Templates button while KPI is showing the result only.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        Select Case barKPIShowHideTemplates.Caption
            Case "Show Templates"
                maincontent.ExecCustomFunction(New Object() {"SHOWTEMPLATES"})
                barKPIShowHideTemplates.Caption = "Hide Templates"
            Case "Hide Templates"
                maincontent.ExecCustomFunction(New Object() {"HIDETEMPLATES"})
                barKPIShowHideTemplates.Caption = "Show Templates"
        End Select
    End Sub

    Private Sub GetRibbonControlItemCaption(sender As System.Object, ByVal ControlName As String, ByRef ReturnValue As String) Handles maincontent.GetRibbonControlItemCaption
        Dim oBar As DevExpress.XtraBars.BarButtonItem = Nothing

        Try
            oBar = RibbonControl.Items(ControlName)
        Catch ex As Exception
            LogErrors("--Error Generated in GetRibbonControlItemCaption() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetRibbonControlItemCaption() method in frmCrewMain.vb - End--")

        End Try

        If Not IsNothing(oBar) Then
            ReturnValue = oBar.Caption
        Else
            ReturnValue = ""
        End If

    End Sub

    'Delete Crew Button
    Private Sub DeleteCrew_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DeleteCrew.ItemClick

        If SelectedTab.Equals("ArchiveCrews") Then
            mainlist.DeleteArchivedCrew()
        Else
            maincontent.DeleteData()
        End If
    End Sub

#Region "Favorite Buttons"

    Dim favButtons As String()
    Dim hasSavedFavButtons As Boolean = False
    Dim favGroup As New RibbonPageGroup("Shortcuts")

    Private Function IsShowShortcutToRibbon() As Boolean
        Try
            Dim result As String = MPSDB.DLookUp("Value", "tblUserConfig", "False", "FKeyUserID = '" & USER_ID & "' AND Code = 'ShowFavoriteButtons'")
            Return IIf(result.Equals("True"), True, False)
        Catch ex As Exception
            LogErrors("--Error Generated in IsShowShortcutToRibbon() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in IsShowShortcutToRibbon() method in frmCrewMain.vb - End--")
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Sub PopulateFavoriteButtonList()

        Try
            Dim result As String = MPSDB.DLookUp("Value", "tblUserConfig", "NoData", "FKeyUserID = '" & USER_ID & "' AND Code = 'FavoriteButtons' ORDER BY Value ASC ")
            favButtons = IIf(result.Equals("NoData") Or result.Equals(""), New String() {}, result.Split(","))
            If favButtons.Length > 0 Then
                hasSavedFavButtons = True
                GetAllButtons()
                LoadFavoriteButtons()
            Else
                RemoveQuickAccessGroup()
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in PopulateFavoriteButtonList() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateFavoriteButtonList() method in frmCrewMain.vb - End--")
            MessageBox.Show("Error generated in PopulateFavoriteButtonList : " & ex.Message)
        End Try
    End Sub

    Private Sub LoadForm_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        Dim buttonName As BarItem = TryCast(e.Item, BarButtonItem)
        Select Case True
            Case buttonName.Name.Equals("NotifExpDocs")
                NotifExpDocs_ItemClick(sender, e)
                Return
            Case buttonName.Name.Equals("TravelEvent_Returning")
                TravelEvent_Returning_ItemClick(sender, e)
                Return
            Case Else
                LoadShortcutForm(buttonName)
        End Select


    End Sub


    Private Sub LoadShortcutForm(item As BarItem)
        Me.RibbonControl.SelectedPage = GetPage(item.Name)
        Dim barItem As BarButtonItem = GetItem(item.Name)
        If IsNothing(barItem) Then Return
        barItem.Down = True
        If item.Name.Contains("_Report") Then
            LoadReportContent(item.Name)
        Else
            LoadContent(item.Name)
            If (item.Name.Equals("RecordSum")) Then
                mainlist.RefreshData()
                mainlist.ActivateArchive()
            End If
        End If
        isTriggeredFromShortcut = False
    End Sub


    Private Sub LoadFavoriteButtons()
        Try
            favGroup.ShowCaptionButton = False

            Dim f = From fav In favoriteButtons
                    Select fav
                    Order By fav.ButtonCaption Ascending

            For Each button As RibbonButton In f
                favGroup.ItemLinks.Add(GetBarItem(button))
            Next
        Catch ex As Exception
            LogErrors("--Error Generated in LoadFavoriteButtons() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in LoadFavoriteButtons() method in frmCrewMain.vb - End--")
            MessageBox.Show("Error in LoadFavoriteButtons : " & ex.Message)
        End Try
    End Sub

    Private Function GetPage(ByVal button As String) As RibbonPage

        For Each b As RibbonButton In favoriteButtons
            If (b.ButtonName.Equals(button)) Then
                isTriggeredFromShortcut = True
                Return b.ButtonPage
            End If
        Next

        Return Nothing
    End Function

    Private Function GetGroup(ByVal button As String) As RibbonPageGroup
        For Each b As RibbonButton In favoriteButtons
            If (b.ButtonName.Equals(button)) Then
                Return b.Group
            End If
        Next
        Return Nothing
    End Function

    Private Function GetItem(ByVal button As String) As BarButtonItem
        For Each b As RibbonButton In favoriteButtons
            If (b.ButtonName.Equals(button)) Then
                Return b.ButtonItem
            End If
        Next
        Return Nothing
    End Function

    Private Sub RemoveQuickAccessGroup()
        Try
            For Each page As RibbonPage In Me.RibbonControl.Pages
                For Each group As RibbonPageGroup In page.Groups
                    If group.Equals(favGroup) Then
                        group.ItemLinks.Clear()     '--> Remove first the buttons inside the group.
                    End If
                Next
                page.Groups.Remove(favGroup)        '--> Remove the group entirely.
            Next
        Catch ex As Exception
            LogErrors("--Error Generated in RemoveQuickAccessGroup() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in RemoveQuickAccessGroup() method in frmCrewMain.vb - End--")
        End Try
    End Sub
    Private Sub LoadButtons(item As BarButtonItem, group As RibbonPageGroup, page As RibbonPage)
        If item.Visibility = BarItemVisibility.Never Then Return '--> Do not include the buttons that this user does not have access to.
        'This process will create a separate instance of the button item with the same properties. 
        Dim rButton As RibbonButton
        rButton.ButtonGroup = group.Name
        rButton.ButtonName = item.Name
        rButton.ButtonCaption = item.Caption.Trim()
        rButton.ButtonIcon = item.Glyph
        rButton.ButtonPage = page
        rButton.Group = group
        rButton.ButtonItem = item
        rButton.ButtonItem.Tag = item.Tag
        favoriteButtons.Add(rButton)
    End Sub

    Private Sub GetAllButtons()
        Try
            RemoveQuickAccessGroup()        '--> In case of removing the shortcuts while the Main Crew window is already loaded, remove first the Shortcut buttons container. 
            If hasSavedFavButtons Then
                favoriteButtons.Clear()     '--> The list containing the original shortcut buttons (if any). 
                For Each currentPage As RibbonPage In Me.RibbonControl.Pages
                    If favButtons.Count > 0 Then currentPage.Groups.Add(favGroup) '--> If there is atleast one favorite button saved by this user, add a Shortcuts button group.
                    For Each currentGroup As RibbonPageGroup In currentPage.Groups
                        If currentGroup.Equals(favGroup) Then currentGroup.Visible = True
                        For Each currenLink As BarItemLink In currentGroup.ItemLinks
                            If currenLink.Item.Description.Trim().Length < 0 Then Continue For '--> Ignore if no description assigned to ribbon button.
                            If Not currenLink.Item.Description.Trim().Equals("") Then          '--> If has description, do the following:
                                Try
                                    Dim bItem As BarButtonItem = currenLink.Item               '--> Necessary convertion to access the ButtonStyle property.
                                    If (bItem.ButtonStyle = BarButtonStyle.CheckDropDown) Then '--> A ribbon button that has a PopupMenuItem assigned.
                                        Dim dropDownMenu As PopupMenu = bItem.DropDownControl  '--> Gimme that menu, so that I can get the buttons...
                                        For Each b As BarItemLink In dropDownMenu.ItemLinks
                                            If favButtons.Contains(b.Item.Name.Trim()) Then    '--> If this button is included in my Favorite buttons list, 
                                                LoadButtons(b.Item, currentGroup, currentPage) '--> Add it to Shortcuts button group.
                                            End If
                                        Next
                                    Else
                                        If favButtons.Contains(currenLink.Item.Name.Trim()) Then
                                            LoadButtons(currenLink.Item, currentGroup, currentPage) '--> This is a normal BarButtonItem object, 
                                        End If
                                    End If
                                Catch ex As Exception
                                    LogErrors("--Error Generated in GetAllButtons() method in frmCrewMain.vb - Start --")
                                    LogErrors(ex.Message)
                                    LogErrors("--Error Generated in GetAllButtons() method in frmCrewMain.vb - End--")
                                End Try
                            End If
                        Next currenLink
                    Next currentGroup
                Next currentPage
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in GetAllButtons() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetAllButtons() method in frmCrewMain.vb - End--")
            MessageBox.Show("Error in GetAllButtons : " & ex.Message)
        End Try

    End Sub

    Private Function GetBarItem(ByVal bItem As RibbonButton) As BarButtonItem
        Dim barButtonItem As New BarButtonItem()
        barButtonItem.Name = bItem.ButtonName
        barButtonItem.Caption = bItem.ButtonCaption
        barButtonItem.Glyph = bItem.ButtonIcon
        barButtonItem.Tag = bItem.ButtonItem.Tag
        AddHandler barButtonItem.ItemClick, AddressOf LoadForm_ItemClick
        barButtonItem.RibbonStyle = RibbonItemStyles.SmallWithText
        Return barButtonItem
    End Function

    Public Structure RibbonButton
        Public ButtonGroup As String
        Public ButtonName As String
        Public ButtonCaption As String
        Public ButtonIcon As System.Drawing.Image
        Public ButtonPage As RibbonPage
        Public Group As RibbonPageGroup
        Public ButtonItem As BarButtonItem
    End Structure

#End Region

    Private Sub HideQuickAccessButtons()
        Try
            For Each page As RibbonPage In Me.RibbonControl.Pages
                For Each group As RibbonPageGroup In page.Groups
                    If group.Equals(favGroup) Then
                        group.Visible = False
                    End If
                Next
            Next
        Catch ex As Exception
            LogErrors("--Error Generated in HideQuickAccessButtons() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in HideQuickAccessButtons() method in frmCrewMain.vb - End--")
            MessageBox.Show("Error in HideQuickAccessButtons : " & ex.Message)
        End Try
    End Sub

    Private Sub tmr_Tick(sender As System.Object, e As System.EventArgs) Handles tmr.Tick
        If HasShortcutIsUpdated Then
            tmr.Enabled = False
            If IsShowShortcutToRibbon() Then
                HasShortcutIsUpdated = False
                PopulateFavoriteButtonList()
            Else
                HideQuickAccessButtons()
            End If
        End If
    End Sub

    Private Sub cmdQuickReports_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdQuickReports.ItemClick
        maincontent.ExecCustomFunction(New Object() {"VIEWQUICKREPORTS"})
    End Sub


#Region "Debug-Only Config forms events"
    Private Sub ReportConfig_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportConfig.ItemClick
        Dim cContent As String = "ReportConfig"
        Dim row As DataRowView()
        row = ContentsObject.FindRows(cContent)
        If row.Length = 0 Then
            Dim newRow As DataRowView = ContentsObject.AddNew
            newRow("ObjectID") = cContent
            newRow("ObjectList") = System.DBNull.Value
            newRow("DLL") = "Reports"
            newRow("Filter") = System.DBNull.Value
            newRow("ListDLL") = System.DBNull.Value
            newRow("ObjectListDefaultWidth") = 418
            newRow.EndEdit()
        End If

        LoadContent(cContent)
    End Sub


    Private Sub frmCrewMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F1 Then
            OpenHelpFile()
        End If
        '//////////// Generate Feature Key Form
        If e.Control And e.Alt And e.Shift And e.KeyCode = Keys.F Then
            Dim FeatureID As New frmFeatureID
            If USER_NAME = "Spectral" Then

                'Dim dtObjects As New DataTable
                ''MPSDB.FillTable("SELECt objectid , 'O' as Type " & _
                ''            " FROM dbo.tblObjects " & _
                ''            " union " & _
                ''            " SELECT objectid ,'R' as Type " & _
                ''            " FROM  dbo.msystblreports ", dtObjects)

                'dtObjects = MPSDB.CreateTable("SELECt objectid , 'O' as Type " & _
                '          " FROM dbo.tblObjects " & _
                '          " union " & _
                '          " SELECT objectid ,'R' as Type " & _
                '          " FROM  dbo.msystblreports ")

                'FeatureID.lkuObjects.Properties.DataSource = dtObjects
                Dim clsfeat As New clsFeatureMod

                FeatureID.chkListFeature.CheckMember = "Checked"
                FeatureID.chkListFeature.DisplayMember = "Feature"
                FeatureID.chkListFeature.ValueMember = "Value"
                FeatureID.lkuFeature.Properties.ValueMember = "Value"
                FeatureID.lkuFeature.Properties.DisplayMember = "Feature"

                FeatureID.dtFeat = clsfeat.getFeaturelist

                FeatureID.ShowDialog(Me)
            End If
        End If
        '//////////////////////////////////////
    End Sub

    Private Sub KPIConfig_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles KPIConfig.ItemClick
        Dim cContent As String = "KPIConfig"
        Dim row As DataRowView()
        row = ContentsObject.FindRows(cContent)
        If row.Length = 0 Then
            Dim newRow As DataRowView = ContentsObject.AddNew
            newRow("ObjectID") = cContent
            newRow("ObjectList") = System.DBNull.Value
            newRow("DLL") = "KPI"
            newRow("Filter") = System.DBNull.Value
            newRow("ListDLL") = System.DBNull.Value
            newRow("ObjectListDefaultWidth") = 418
            newRow.EndEdit()
        End If

        LoadContent(cContent)
    End Sub
#End Region



    Private Sub cmdHelp_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdHelp.ItemClick
        OpenHelpFile()
    End Sub

    Private Sub cmdImportFromExcel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdImportFromExcel.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ImportFromExcel"})
    End Sub

    Private Sub cmdGenCAImpTemplate_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdGenCAImpTemplate.ItemClick
        maincontent.ExecCustomFunction(New Object() {"GenerateCAExcelTemplate"})
    End Sub


#Region "Filter Information"

    Private Sub SetFilterInformation(Sender As Object, value As String) Handles frmCrewListFilter.FilterInfoStringEvent
        sbiInformation.Caption = value
    End Sub

    Private Sub SetFilterInfoVisibility(sender As Object, value As DevExpress.XtraBars.BarItemVisibility) Handles frmCrewListFilter.FilterInfoVisibility
        sbiInformation.Visibility = value
    End Sub

#End Region


    Public Sub PageGroupVisibility(ByVal sender As String, ByVal param() As Object) Handles maincontent.OnCustomEvent

    End Sub


    Private Sub ArchivedCrews_ItemPress(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ArchivedCrews.ItemPress
        DeleteCrew.Visibility = BarItemVisibility.Always
    End Sub

    Private Sub RecordSum_ItemPress(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RecordSum.ItemPress
        SelectedTab = ""
        mainlist.ActivateArchive()
    End Sub

    Private Sub Sort_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles barLUESortMode.EditValueChanged, barLTPLUESort.EditValueChanged
        Try
            If SplashScreenManager.Default Is Nothing Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Loading Data ...") 'added by calvhin 20170118
            If Not IsNothing(barLUESortMode.EditValue) And Not IsNothing(barLTPLUESort.EditValue) Then
                maincontent.SortLTPResource(barLUESortMode.EditValue, barLTPLUESort.EditValue)
            End If
            If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen() 'added by calvhin 2017011 
        Catch ex As Exception
            LogErrors("--Error Generated in barLUESortMode_EditValueChanged() method in frmCrewMain.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in barLUESortMode_EditValueChanged() method in frmCrewMain.vb - End--")

            If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen() 'added by calvhin 2017011 
        End Try
    End Sub

    Private Sub Activity_Docs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Activity_Docs.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ACTIVITYDOCS"})
    End Sub

    Private Sub ChkShowAllPlanning_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkShowAllPlanning.CheckedChanged
        Dim chk As DevExpress.XtraEditors.CheckEdit = sender
        SaveUserSetting("ShowAllPlannings", chk.Checked)
        mainlist.RefreshData()
        maincontent.RefreshData()
    End Sub

#Region "Quick Filters"


    Enum StatType
        ONB
        ASH
        PLN
    End Enum

    Private Function getQuickFilterStat(Type As StatType) As String
        Select Case Type
            Case StatType.ONB
                Return "[StatType]='1'"
            Case StatType.ASH
                Return "[StatType]='3'"
            Case StatType.PLN
                Return "[FKeyPlannedVsl] IS NOT NULL"
            Case Else
                Return String.Empty
        End Select
    End Function

    Private Sub cmdFilterONB_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdFilterONB.ItemClick
        oQuickFilter.FilterString = getQuickFilterStat(StatType.ONB)
        oQuickFilter.FilterInfo = "Onboard Crews Only"

        strCrewListFilter = frmCrewListFilter.GeneratedFltStr

        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"})
        maincontent.applyCrewFilter(New Object() {"CrewList_Filter"})

        'sbiInformation.Caption = "Filter By: " & frmCrewListFilter.GenerateFilterInfoString
        sbiInformation.Caption = frmCrewListFilter.GenerateFilterInfoString
        sbiInformation.Visibility = BarItemVisibility.Always
    End Sub

    Private Sub cmdFilterAshore_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdFilterAshore.ItemClick
        oQuickFilter.FilterString = getQuickFilterStat(StatType.ASH)
        oQuickFilter.FilterInfo = "Ashore Crews Only"
        strCrewListFilter = frmCrewListFilter.GeneratedFltStr

        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"})
        maincontent.applyCrewFilter(New Object() {"CrewList_Filter"})

        'sbiInformation.Caption = "Filter By: " & frmCrewListFilter.GenerateFilterInfoString
        sbiInformation.Caption = frmCrewListFilter.GenerateFilterInfoString
        sbiInformation.Visibility = BarItemVisibility.Always
    End Sub

    Private Sub cmdFilterPlanning_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdFilterPlanning.ItemClick
        oQuickFilter.FilterString = getQuickFilterStat(StatType.PLN)
        oQuickFilter.FilterInfo = "Planned Crews Only"

        strCrewListFilter = frmCrewListFilter.GeneratedFltStr

        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"})
        maincontent.applyCrewFilter(New Object() {"CrewList_Filter"})

        'sbiInformation.Caption = "Filter By: " & frmCrewListFilter.GenerateFilterInfoString
        sbiInformation.Caption = frmCrewListFilter.GenerateFilterInfoString
        sbiInformation.Visibility = BarItemVisibility.Always
    End Sub

    Private Sub cmdClearQuickFilter_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClearQuickFilter.ItemClick
        oQuickFilter.Clear()
        strCrewListFilter = frmCrewListFilter.GeneratedFltStr

        If mainlist.Name <> "" Then mainlist.ExecCustomFunction(New Object() {"CrewList_Filter"})
        maincontent.applyCrewFilter(New Object() {"CrewList_Filter"})

        Dim cFilterInfo As String = frmCrewListFilter.GenerateFilterInfoString
        If Not IfNull(cFilterInfo, "").Equals("") Then
            'sbiInformation.Caption = "Filter By: " & cFilterInfo
            sbiInformation.Caption = cFilterInfo
            sbiInformation.Visibility = BarItemVisibility.Always

        Else
            sbiInformation.Caption = ""
            sbiInformation.Visibility = BarItemVisibility.Never
        End If
    End Sub
#End Region


    Private Sub barChkShowAllPlanning_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barChkShowAllPlanning.ItemClick

    End Sub


    'Private Sub RibbonControl_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RibbonControl.ItemClick
    '    Dim itm As BarItem = e.Item

    '    Select Case itm.Name
    '        Case "SignOn", "Promotion", "Transfer", "ContractExtension"
    '            ActivityActivityDocsRpgVisibility_main(True)
    '            'Me.rpgActivityActivityDocs.Visible = True
    '        Case Else
    '            Me.rpgActivityActivityDocs.Visible = False
    '    End Select

    '    'MsgBox(itm.Name)
    'End Sub


    Private Sub barLTPSelectVesselRank_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barLTPSelectVesselRank.ItemClick
        If IsNothing(barLUEFilterMode.EditValue) Then
            MsgBox("Please select if to be filtered by Vessel or by Rank.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If IsNothing(barLTPLUE.EditValue) Then
            If IfNull(barLUEFilterMode.EditValue, "").Equals("Vessel") Then
                MsgBox("Please select a Vessel.", MsgBoxStyle.Exclamation)
            ElseIf IfNull(barLUEFilterMode.EditValue, "").Equals("Rank") Then
                MsgBox("Please select a Rank.", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Please select a Vessel/Rank.", MsgBoxStyle.Exclamation)
            End If
            Exit Sub

        Else
            If IfNull(barLTPLUE.EditValue, "").Length = 0 Then

                If IfNull(barLUEFilterMode.EditValue, "").Equals("Vessel") Then
                    MsgBox("Please select a Vessel.", MsgBoxStyle.Exclamation)
                ElseIf IfNull(barLUEFilterMode.EditValue, "").Equals("Rank") Then
                    MsgBox("Please select a Rank.", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Please select a Vessel/Rank.", MsgBoxStyle.Exclamation)
                End If
                Exit Sub
            End If
        End If


        Try
            If maincontent.LTPShowVesselRankSelection(barLUEFilterMode.EditValue) Then
                ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Filtering Data ...")
                maincontent.LTPShowAllRecords(True, barLUEFilterMode.EditValue, barLTPLUE.EditValue)
                CloseCustomLoadScreen()
            End If
        Catch ex As Exception
            MsgBox("Graphical Planning Filter failed." & Chr(13) & Chr(13) & "Error: " & ex.Message)
        End Try
    End Sub

    Private Sub RibbonControl_ApplicationButtonClick(sender As System.Object, e As System.EventArgs) Handles RibbonControl.ApplicationButtonClick

    End Sub

    Private Sub btnClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
        btncloseclicked = True
        Me.Close()
    End Sub

    Private Sub RibbonControl_ShowCustomizationMenu(sender As Object, e As DevExpress.XtraBars.Ribbon.RibbonCustomizationMenuEventArgs) Handles RibbonControl.ShowCustomizationMenu
        For i As Integer = 0 To e.CustomizationMenu.ItemLinks.Count - 1
            Dim obj As DevExpress.XtraBars.BarButtonItemLink = TryCast(e.CustomizationMenu.ItemLinks.Item(i), DevExpress.XtraBars.BarButtonItemLink)

            Try
                Select Case obj.Caption
                    Case "&Add to Quick Access Toolbar", "&Remove from Quick Access Toolbar", "&Show Quick Access Toolbar Below the Ribbon"
                        obj.Visible = False

                    Case Else
                        obj.Visible = True
                End Select
            Catch

            End Try


        Next
    End Sub

    Private Sub cmdCancel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancel.ItemClick
        maincontent.ExecCustomFunction(New Object() {"CancelData"})
    End Sub

End Class
