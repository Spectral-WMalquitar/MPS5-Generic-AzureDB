Imports DevExpress.XtraSplashScreen
Public Class frmAdmMain

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
    Dim clsFeature As New clsFeatureMod
    Dim prevBtn As String = ""

    Dim btncloseclicked As Boolean = False

#Region "Buttons Configurations"
    'Captions
    Private Sub SetSaveCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomSaveCaption
        cmdSave.Caption = value
    End Sub
    Private Sub SetDeleteCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomDeleteCaption
        cmdDelete.Caption = value
    End Sub
    Private Sub SetDataToolCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomDataToolCaption
        cmdDataTool.Caption = value
    End Sub
    Private Sub SetAddCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomAddCaption
        cmdAdd.Caption = value
    End Sub
    Private Sub SetDeleteSubCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomDeleteSubCaption
        cmdDeleteSub.Caption = value
    End Sub

    'Enabled
    Private Sub EnableAdd(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowAdd
        cmdAdd.Enabled = value
    End Sub
    Private Sub EnableSave(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowSave
        cmdSave.Enabled = value
    End Sub
    Private Sub EnableDelete(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowDelete
        cmdDelete.Enabled = value
    End Sub
    Private Sub EnableDeleteSub(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowDeleteSub
        cmdDeleteSub.Enabled = value
    End Sub
    Private Sub EnableDataTool(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowDataToolUtil
        cmdDataTool.Enabled = value
    End Sub
    Private Sub EnableEdit(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowEdit
        cmdEdit.Enabled = value
    End Sub

    Private Sub SetEditChecked(ByVal sender As String, ByVal value As Boolean) Handles maincontent.EditDown
        cmdEdit.Down = value
    End Sub

    

    'Pannel Visibility
    Private Sub MainPannelVisibility(ByVal sender As String, ByVal value As DevExpress.XtraEditors.SplitPanelVisibility) Handles maincontent.PanelVisibility
        Me.MainPanel.PanelVisibility = value
    End Sub

    'Visiblility
    Private Sub AddVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.AddVisibility
        cmdAdd.Visibility = value
    End Sub
    Private Sub SaveVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.SaveVisibility
        cmdSave.Visibility = value
    End Sub
    Private Sub DeleteVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.DeleteVisibility
        cmdDelete.Visibility = value
    End Sub
    Private Sub DeleteSubVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.DeleteSubVisibility
        cmdDeleteSub.Visibility = value
    End Sub

    Private Sub EditVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.EditVisibility
        cmdEdit.Visibility = value
    End Sub
    Private Sub DataToolUtil(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.DataToolVisibility
        cmdDataTool.Visibility = value
    End Sub

    Private Sub UpdateProgramVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.UpdateProgramVisibility
        cmdUpdateProgram.Visibility = value
    End Sub

    Private Sub HideRibbonPageGroup() Handles maincontent.HideRibbonPageGroup
        rpgAdminReportOptions.Visible = False
        rpgTool.Visible = False
    End Sub

    Private Sub ShowRibbonPageGroup(ByVal sender As String, ByVal RibbonPageGroupName As String, ByVal value As Boolean) Handles maincontent.ShowRibbonPageGroup
        Dim btn As Object = Nothing
        For Each ribbonpage As DevExpress.XtraBars.Ribbon.RibbonPage In RibbonControl.Pages
            Try
                btn = ribbonpage.Groups(RibbonPageGroupName).Name
            Catch
            End Try
            If Not btn Is Nothing Then
                ribbonpage.Groups(RibbonPageGroupName).Visible = value
                Exit For
            End If
        Next

    End Sub

    Private Sub PageGroupVisibility(ByVal sender As String, ByVal pageCaption As String, ByVal pageGroupName As String, ByVal value As Boolean) Handles maincontent.PageGroupVisibility
        Try
            Dim rbngrp As DevExpress.XtraBars.Ribbon.RibbonPageGroup
            rbngrp = RibbonControl.Pages(pageCaption).Groups(pageGroupName)
            rbngrp.Visible = value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#Region "Report Selection"

    Private Sub LoadDataVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.LoadDataVisibility
        cmdLoadData.Visibility = value
    End Sub

    Private Sub ShowSelectionList_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdShowSelectionList.ItemClick
        maincontent.ExecCustomFunction(New Object() {"SHOWLIST"})
    End Sub

    Private Sub ShowListVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ShowListVisibility
        cmdShowSelectionList.Visibility = value
    End Sub

    Private Sub ShowListEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.ShowListEnabled
        cmdShowSelectionList.Enabled = value
    End Sub

    Private Sub cmdLoadData_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdLoadData.ItemClick
        maincontent.ExecCustomFunction(New Object() {"LOADTEMPLATE"})
    End Sub

    Private Sub PreviewReportVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.PreviewReportVisibility
        cmdPreviewReport.Visibility = value
    End Sub

    Private Sub PreviewReportEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.PreviewReportEnabled
        cmdPreviewReport.Enabled = value
    End Sub

    Private Sub cmdReportPreview_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdPreviewReport.ItemClick
        maincontent.ExecCustomFunction(New Object() {"PREVIEWREPORT", Me.chkAuditWithDetails.Checked})
    End Sub

    Private Sub ClearFilterVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ClearFilterVisibility
        cmdClearFilter.Visibility = value
    End Sub

    Private Sub ClearFilterEnabled(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ClearFilterEnabled
        cmdClearFilter.Enabled = value
    End Sub

    Private Sub cmdClearFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClearFilter.ItemClick
        maincontent.ExecCustomFunction(New Object() {"CLEARFILTER"})
    End Sub

    Private Sub SetApplyEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.ApplyEnabled
        cmdApply.Enabled = value
    End Sub

    Private Sub ApplyVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ApplyVisibility
        cmdApply.Visibility = value
    End Sub

    Private Sub SetForceLogoutEnabled(ByVal sender As String, ByVal value As Boolean) Handles maincontent.ApplyEnabled
        cmdForceLogout.Enabled = value
    End Sub

    'Private Sub ShowReportOptionRibbonPageGroup(ByVal sender As String, ByVal RibbonPageGroupName As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.ShowReportOptionRibbonPageGroup
    '    For Each ribbonpage As DevExpress.XtraBars.Ribbon.RibbonPage In RibbonControl.Pages
    '        Dim btn As Object = ribbonpage.Groups(RibbonPageGroupName).Name
    '        If Not btn Is Nothing Then
    '            ribbonpage.Groups(RibbonPageGroupName).Visible = value
    '            Exit For
    '        End If
    '    Next
    '    'Select Case RibbonPageGroupName
    '    '    Case "rpgAdminReportOptions"
    '    '        rpgAdminReportOptions.Visible = value
    '    'End Select
    'End Sub
#End Region

    'Eding Option Ribbon Page
    Private Sub AdminEditOptionsVisibility(ByVal sender As String, ByVal value As Boolean) Handles maincontent.EditOptionsVisibility
        rpgAdminEditOptions.Visible = value
    End Sub

    'Editing Option Ribbon Page
    Private Sub SecEditOptionsVisibility(ByVal sender As String, ByVal value As Boolean) Handles maincontent.EditOptionsVisibility
        rpgSecEditOptions.Visible = value
    End Sub

    'Set all Editing option buttons visible false
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


#End Region

#Region "MainForm Requirments"
    Dim extAssembly As System.Reflection.Assembly
    Private WithEvents maincontent As New BaseControl.BaseControl
    Private WithEvents mainlist As New BaseControl.BaseList
    Dim ContentsObject As DataView
    Dim loading As Boolean = False

    Private Sub frmAdmMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F1 Then
            OpenHelpFile() 'Show Help File
        End If
    End Sub

    'Load
    Private Sub frmAdmMain_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        'clsSec.propSQLConnStr = MPSDB.GetConnectionString
        'LoadForm()

        '///tony20170810 check if lost connection to db
        If Not CheckDatabaseConnection() Then Return
        '////

        'Me.RibbonControl.ApplicationCaption = GetAppName() & " - CREW " & MPSVersion
        clsSec.propSQLConnStr = MPSDB.GetConnectionString


        InitModule()
        CloseCustomLoadScreen()
        Me.RibbonControl.ApplicationCaption = GetAppName() & " - ADMIN " & MPSVersion
        'SplashScreen1.Visible = False
        'InitUserSettings()
        ResetEditButtons()
        'clsSec.get_permissions_all(USER_ID)
        ' SelectTopItem()

        Call checkBtnPermissionAll() 'neil

        SelectTopItem()

        AuditRefreshVisibility(Name, True)

        Me.WindowState = FormWindowState.Maximized
        Me.Visible = True
        Me.MainPanel.SplitterPosition = 382
    End Sub

    'Load Form
    Private Sub LoadForm()
        InitModule()
        'InitUserSettings()
        'Temp'
        ResetEditButtons()
        'SelectTopItem()

        Call checkBtnPermissionAll() '20160507

        SelectTopItem()

        Me.WindowState = FormWindowState.Maximized
        Me.Visible = True
        Me.MainPanel.SplitterPosition = 382
    End Sub

    'InitUser Settings
    Private Sub InitUserSettings()
        'Try
        '    ContentsObject = New DataView(MPSDB.CreateTable("SELECT * FROM dbo.tblObjects WHERE Category='ADMIN'"))
        '    ContentsObject.Sort = "ObjectID"
        '    ResetRibbon()
        'Catch ex As Exception
        '    MsgBox(ex.Message, , GetAppName)
        'End Try

        Try
            USER_INFO = New UserDetail
            Me.txtServerName.Caption = "Connected to: " & SQLServer
            Me.txtUserName.Caption = "Username: " & USER_NAME
            GetThemes()

            'tony20160822 - Changed ADMIN/CREWING to APPLICATION INFO
            'ContentsObject = New DataView(MPSDB.CreateTable("SELECT * FROM dbo.tblObjects WHERE Category='ADMIN' OR Category='ADMIN/CREWING'"))
            ContentsObject = New DataView(MPSDB.CreateTable("SELECT * FROM dbo.tblObjects WHERE Category='ADMIN' OR Category='APPLICATION INFO'"))
            'end tony
            ContentsObject.Sort = "ObjectID"
            ResetRibbon()
        Catch ex As Exception
            MsgBox(ex.Message, , GetAppName)
        End Try
    End Sub

    'Show All Buttons
    Private Sub ResetRibbon()

        Dim nPage As DevExpress.XtraBars.Ribbon.RibbonPage, nPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup

        For Each nPage In RibbonControl.Pages
            nPage.Visible = True

            For Each nPageGroup In nPage.Groups
                nPageGroup.Visible = True
                If nPageGroup.Tag = 1 Then
                    InitRibbonItems(nPageGroup)
                End If
            Next
        Next

        'neil 20160507 Call checkBtnPermissionAll()

    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As System.Object, e As System.EventArgs) Handles RibbonControl.SelectedPageChanged
        Dim rib As DevExpress.XtraBars.Ribbon.RibbonControl = TryCast(sender, DevExpress.XtraBars.Ribbon.RibbonControl)
        For Each container As DevExpress.XtraBars.Ribbon.RibbonPageGroup In rib.SelectedPage.Groups
            If container.Tag = 1 Then
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
                            '                LoadContent(button.Name)
                            '                Exit Sub
                            '            End If
                            '        End If
                            '    Next
                            'ElseIf x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
                            '    If x.GroupIndex > 0 And x.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            '        x.Down = True
                            '        LoadContent(x.Name)
                            '        Exit Sub
                            '    End If
                            'ElseIf x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                            '    If x.GroupIndex > 0 And x.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            '        x.Down = True
                            '        LoadContent(x.Name)
                            '        Exit Sub
                            '    End If

                            'End If
                        End If
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                Next
            End If
        Next
    End Sub

    Dim foundContentToLoad As Boolean = False

    Sub loopchekdropdown(ByVal x As DevExpress.XtraBars.BarButtonItem) ' As String
        'Debug.Print("hhhhhh " & (x.Name))
        If foundContentToLoad Then
            Exit Sub
        End If
        If x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
            Dim popItems As DevExpress.XtraBars.PopupMenu = x.DropDownControl
            For o As Integer = 0 To popItems.ItemLinks.Count - 1
                If TypeOf (popItems.ItemLinks(o).Item) Is DevExpress.XtraBars.BarButtonItem Then
                    Dim button As DevExpress.XtraBars.BarButtonItem = popItems.ItemLinks(o).Item
                    'If button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                    loopchekdropdown(button)
                    'Else
                    '    If Button.GroupIndex > 0 And Button.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                    '        x.Down = True
                    '        Button.Down = True
                    '        ' Return button.Name
                    '        LoadContent(Button.Name)
                    '        Exit Sub
                    '    End If
                    'End If
                End If
            Next
        ElseIf x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
            If x.GroupIndex > 0 And x.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                x.Down = True
                ' Return x.Name
                LoadContent(x.Name)
                foundContentToLoad = True
                Exit Sub
            End If
        ElseIf x.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
            If x.GroupIndex > 0 And x.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                x.Down = True
                ' Return x.Name
                LoadContent(x.Name)
                foundContentToLoad = True
                Exit Sub
            End If

        End If
    End Sub

    Private Sub LoadReportContent(ByVal cContent As String)
        'Elmer 20160404
        CheckUserSession(MPSDB, USER_SESSION)

        If Mid(cContent, cContent.Length - 6) <> "_Report" Then
            LoadContent(cContent)
            Exit Sub
        End If

        Dim btn As New DevExpress.XtraBars.BarButtonItem
        btn = Nothing
        Try
            btn = RibbonControl.Items(cContent)
        Catch ex As Exception
            'do nothing
        End Try

        If maincontent.Name <> cContent Then
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
            'MainPanel.Panel1.Controls.Clear()
            MainPanel.Panel2.Controls.Add(maincontent)
            maincontent.Dock = Windows.Forms.DockStyle.Fill
            MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
            maincontent.DB = MPSDB

            maincontent.ObjectIDContent = cContent
            maincontent.RefreshData()
            '----------------------------------------------------------
            maincontent.Name = MainContentName
        End If
        'btn.Down = True

    End Sub

    Private Sub LoadContent(ByVal cContent As String, Optional sRefresh As Boolean = False)
        'Elmer 20160404
        'CheckUserSession(MPSDB, USER_SESSION)

        '///tony20170810 check if lost connection to db
        If Not CheckDatabaseConnection() Then Return
        '////

        '///neil force log out
        CheckForceLogout("ADMIN")
        '////

        CheckAppVersion("ADMIN", SQLServer, SQLID, SQLPW, , True)

        'fords 20160229
        If Mid(cContent, IIf(cContent.Length < 7, 1, cContent.Length - 6)) = "_Report" Then
            LoadReportContent(cContent)
            Exit Sub
        End If

        loading = True
        Dim nButton As DevExpress.XtraBars.BarButtonItem
        'prevBtn = cContent 'tony20160817 - moved to section after the pressed button is verified ok and opened

        'Dim gGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        'Dim nButton As DevExpress.XtraBars.BarButtonItem = RibbonControl.Items(cContent)
        'Dim nGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroupItemLinkCollection = TryCast(nButton.Links(0).Links, DevExpress.XtraBars.Ribbon.RibbonPageGroupItemLinkCollection)
        ''Ensure that the select item was selected.
        ''RibbonControl.SelectedPage = nGroup.PageGroup.Page
        'nButton.Down = True
        'nButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Dim xrow As DataRowView() = ContentsObject.FindRows(cContent)
        If xrow.Length = 0 Then
            MsgBox("'" & cContent & "' cannot be found in the collection", vbExclamation)
            nButton = RibbonControl.Items(prevBtn)
            nButton.Down = True
            Exit Sub
        End If
        Dim blList As String = Trim(IfNull(xrow(0)("ObjectList"), ""))
        Dim strDLL As String = Trim(IfNull(xrow(0)("DLL"), ""))
        Dim strFilter As String = Trim(IfNull(xrow(0)("Filter"), ""))

        RibbonControl.Minimized = False
        MainPanel.Visible = True

        Dim loadPanel As Boolean = False
        Dim ReloadPanel As Boolean = True
        Try
            If cContent <> maincontent.Name Or sRefresh Then
                If BRECORDUPDATEDs Then
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

                If ReloadPanel And Not BRECORDUPDATEDs Then
                    MainPanel.Panel2.Controls.Clear()
                    maincontent.Dispose()
                    extAssembly = System.Reflection.Assembly.Load(strDLL)
                    Try
                        'maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                        maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                        maincontent.ObjectIDContent = cContent
                        maincontent.Name = cContent
                        'prevBtn = maincontent.Name
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    prevBtn = maincontent.Name
                    maincontent.ObjectIDContent = cContent
                    If blList <> mainlist.Name Then
                        mainlist.Dispose()
                        MainPanel.Panel1.Controls.Clear()
                        If blList <> "" Then
                            mainlist = extAssembly.CreateInstance(strDLL & "." & blList, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                            maincontent.blList = mainlist
                            mainlist.bContent = maincontent
                            maincontent.ObjectIDContent = cContent
                        Else
                            mainlist.Name = ""
                        End If
                    End If
                    If maincontent.Name <> "BaseControl" Then
                        nButton = RibbonControl.Items(maincontent.Name)
                        nButton.Down = True
                    End If
                    loadPanel = True
                Else
                    If maincontent.Name <> "BaseControl" Then
                        'tony20160817 - must press previous button when not loading panel of selected button/menu
                        'nButton = RibbonControl.Items(maincontent.Name)
                        nButton = RibbonControl.Items(prevBtn)
                        nButton.Down = True
                    End If
                    loadPanel = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try
        '========================================================================================
        If loadPanel Then
            HideEditOptionBtn() 'hide buttons in Editing Options Group
            Me.Cursor = Cursors.WaitCursor
            Try
                If blList = "" Then
                    MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
                Else
                    MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                    If strFilter = "" Then
                        mainlist.ClearFilter()
                        'Insert Filters Here
                    Else
                        mainlist.SetFilter(strFilter)
                    End If

                    MainPanel.Panel1.Controls.Add(mainlist)
                    mainlist.DB = MPSDB
                    mainlist.RefreshData()
                    mainlist.Dock = DockStyle.Fill
                    maincontent.blList = mainlist

                End If
                MAIN_CONTENT = maincontent.Name 'Added by Tony20170208

                maincontent.Dock = DockStyle.Fill
                MainPanel.Panel2.Controls.Add(maincontent)
                maincontent.DB = MPSDB
                maincontent.Name = cContent
                maincontent.RefreshData()
                prevBtn = cContent          'tony20160817 - a button must only become a previous button after it had been loaded/opened
            Catch ex As Exception
                MsgBox(ex.Message, , GetAppName)
            End Try
            Me.Cursor = Cursors.Default
        End If

        If Not blList.Equals("") Then
            mainlist.SetListLayout(cContent) 'SetLayout
            Dim PanelWidth As Integer = GetLayoutWidth(USER_ID, cContent, blList)
            If PanelWidth < 0 Then
                MainPanel.SplitterPosition = IfNull(xrow(0)("ObjectListDefaultWidth"), 418)
            Else
                MainPanel.SplitterPosition = CType(PanelWidth, Integer)
            End If
        End If

        loading = False
    End Sub

    'button Click
    Private Sub Contain_ItemClick(ByVal Sender As System.Object, ByVal a As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            'load item in the panel
            If prevBtn <> a.Item.Name Then
                If a.Item.Name = "Refresh" Then
                    'LoadContent(prevBtn, True)
                    'Dim frm As Audit.Audit = DirectCast(maincontent, Audit.Audit)
                    'Dim para(0) As String
                    'para(0) = "btnApply_Click"
                    'maincontent.(maincontent.Name, New Object() {"showmsg"})
                    'frm.teste()
                    maincontent.DataRefresh()
                Else
                    LoadContent(a.Item.Name)
                    prevBtn = a.Item.Name
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

    Private Sub InitRibbonItems(ByVal container As DevExpress.XtraBars.Ribbon.RibbonPageGroup)
        Try
            For i As Integer = 0 To container.ItemLinks.Count - 1
                Dim BarBtnItem As DevExpress.XtraBars.BarButtonItem = TryCast(container.ItemLinks(i).Item, DevExpress.XtraBars.BarButtonItem)

                Try
                    If Not SelRibbonItems(BarBtnItem) Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Beep()
                End Try
                

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
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

    'Grid Selection Change
    Private Sub mainlist_SelectionChange(ByVal sender As String) Handles mainlist.OnSelectionChange
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

    'add button
    Private Sub Add_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdAdd.ItemClick
        If Not loading Then
            If BRECORDUPDATEDs Then
                maincontent.CheckValidateFields()
            Else
                maincontent.AddData()
            End If
        End If
    End Sub

    Private Sub cmdEdit_DownChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdEdit.DownChanged
        maincontent.isEditdable = cmdEdit.Down
    End Sub

    'Edit Button
    Private Sub cmdEdit_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdEdit.ItemClick
        If Not loading Then
            If BRECORDUPDATEDs Then
                maincontent.CheckValidateFields()
            End If
            maincontent.isEditdable = cmdEdit.Down
            maincontent.EditData()
        End If
    End Sub

    'Save Button
    Private Sub cmdSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
        maincontent.SaveData()
    End Sub

    'Delete Button
    Private Sub cmdDelete_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDelete.ItemClick
        maincontent.DeleteData()
    End Sub

    'Delete Sub Button
    Private Sub cmdDeleteSub_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDeleteSub.ItemClick
        maincontent.ExecCustomFunction(New Object() {"DeleteOther"})
    End Sub

    'Closing
    Private Sub frmAdmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
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
            Else
                e.Cancel = False
            End If
        End If

        If Not btncloseclicked Then
            If Not e.Cancel Then 'neil 
                If MsgBox("Are you sure you want to exit the MPS5 Admin?", vbQuestion + vbYesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            End If
        End If

        'user session
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
            'clsAudit.saveAuditLog("User log out", USER_NAME, auditlogid, System.Environment.MachineName, 10,
            '                       , , , , , "MPS Admin") 'neil
            'bSuccess = USER_SESSION.Dispose(MPSDB)
        End If
    End Sub

    'Save Layout Width
    Private Sub SaveLayoutWidth(ByVal _UserID As Integer, ByVal _ObjectID As String, ByVal _ObjectList As String, ByVal value As Integer)
        Dim flag As Boolean = False
        MPSDB.BeginReader("SELECT * FROM dbo.tblUserLayout WHERE FKeyUserID='" & _UserID & "' AND ObjectID='" & _ObjectID & "'  AND ObjectList='" & _ObjectList & "' ")
        If MPSDB.HasRows() Then
            flag = True
        Else
            flag = False
        End If
        MPSDB.CloseReader()

        If flag Then
            MPSDB.RunSql("UPDATE dbo.tblUserLayout SET ObjectListWidth='" & value & "'WHERE FKeyUserID='" & _UserID & "' AND ObjectID='" & _ObjectID & "'  AND ObjectList='" & _ObjectList & "'")
        Else
            MPSDB.RunSql("INSERT INTO dbo.tblUserLayout(FKeyUserID,ObjectID,ObjectList,ObjectListWidth) VALUES('" & USER_ID & "','" & _ObjectID & "','" & _ObjectList & "','" & value & "')")
        End If

    End Sub

    'Restore Layout
    Private Sub RestoreLayout(ByVal _UserID As Integer, ByVal _ObjectID As String, ByVal _ObjectList As String)
        Dim flag As Boolean = False
        MPSDB.BeginReader("SELECT * FROM dbo.tblUserLayout WHERE FKeyUserID='" & _UserID & "' AND ObjectID='" & _ObjectID & "'  AND ObjectList='" & _ObjectList & "' ")
        If MPSDB.HasRows() Then
            flag = True
        Else
            flag = False
        End If
        MPSDB.CloseReader()

        If flag Then
            MPSDB.RunSql("DELETE FROM dbo.tblUserLayout WHERE FKeyUserID='" & _UserID & "' AND ObjectID='" & _ObjectID & "'  AND ObjectList='" & _ObjectList & "'")
        End If
        mainlist.SetListLayout(maincontent.Name)
        maincontent.Name = ""
    End Sub

    'Used for Selecting Top Item of the Ribbon
    Private Function SelItemInPopUp(ByVal BarBtnItems As DevExpress.XtraBars.BarButtonItem) As Boolean
        Dim bool As Boolean = True

        If BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
            Dim popItems As DevExpress.XtraBars.PopupMenu = BarBtnItems.DropDownControl
            For o As Integer = 0 To popItems.ItemLinks.Count - 1
                If TypeOf (popItems.ItemLinks(o).Item) Is DevExpress.XtraBars.BarBaseButtonItem Then
                    Dim button As DevExpress.XtraBars.BarButtonItem = popItems.ItemLinks(o).Item
                    If button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
                        If Not SelItemInPopUp(button) Then
                            bool = False
                            Return bool
                            Exit Function
                        End If
                    ElseIf button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
                        If button.GroupIndex > 0 And button.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            button.Down = True
                            LoadContent(button.Name)
                            bool = False
                            Return bool
                            Exit Function
                        End If
                    ElseIf button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
                        If button.GroupIndex > 0 And button.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                            'button.Down = True
                            LoadContent(button.Name)
                            bool = False
                            Return bool
                            Exit Function
                        End If
                    End If

                End If
            Next
        ElseIf BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
            If BarBtnItems.GroupIndex > 0 And BarBtnItems.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                BarBtnItems.Down = True
                LoadContent(BarBtnItems.Name)
                Return False
                Exit Function
            End If
        ElseIf BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
            If BarBtnItems.GroupIndex > 0 And BarBtnItems.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                'BarBtnItems.Down = True
                LoadContent(BarBtnItems.Name)
                bool = False
                Return bool
                Exit Function
            End If
        End If
        Return bool
    End Function

    'Used for Selecting Top Item of the Ribbon
    Private Function fn_SelItem(BarBtnItems As DevExpress.XtraBars.BarButtonItem) As Boolean
        'Throw New NotImplementedException
        Dim bool As Boolean = True
        If BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown Then
            If BarBtnItems.GroupIndex > 0 And BarBtnItems.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                BarBtnItems.Down = True
                SelItemInPopUp(BarBtnItems)
                bool = False
                Return bool
                Exit Function
            End If
        ElseIf BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default Then
            If BarBtnItems.GroupIndex > 0 And BarBtnItems.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                BarBtnItems.Down = True
                LoadContent(BarBtnItems.Name)
                bool = False
                Return bool
                Exit Function
            End If
        ElseIf BarBtnItems.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check Then
            If BarBtnItems.GroupIndex > 0 And BarBtnItems.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                BarBtnItems.Down = True
                LoadContent(BarBtnItems.Name)
                bool = False
                Return bool
                Exit Function
            End If
        End If
        Return bool
    End Function

    'Selecting top item of the Ribbon
    Private Sub SelectTopItem()
        Dim container As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        For Each container In RibbonControl.SelectedPage.Groups
            If container.Tag = 1 Then
                For cnt As Integer = 0 To container.ItemLinks.Count - 1
                    Dim BarBtnItems As DevExpress.XtraBars.BarButtonItem = container.ItemLinks(cnt).Item
                    If Not fn_SelItem(BarBtnItems) Then
                        Exit Sub
                    End If
                Next
            End If
        Next



    End Sub

    'Data tool button click
    Private Sub cmdDataTool_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDataTool.ItemClick
        If Not loading Then
            If BRECORDUPDATEDs Then
                maincontent.CheckValidateFields()
            Else
                Dim frmObj As New Admin.DataUtility(maincontent.Name)
                Dim tblName As String = ""
                frmObj.DB = MPSDB 'Pass the Database connection
                frmObj.ListSelect = mainlist.bListSelect 'Pass the Select Statement
                'frmObj.AllowDuplicate = maincontent.DataToolDuplicate 'Visibility of The Duplicate option
                'frmObj.AllowMerge = maincontent.DataToolMerge 'Visibility of the Merge Option
                If IsNothing(Trim(maincontent.TableName)) Or maincontent.TableName = "" Then
                    tblName = mainlist.TableName
                    frmObj.TBName = tblName
                Else
                    tblName = maincontent.TableName
                    frmObj.TBName = tblName
                End If
                frmObj.ShowDialog(Me)
                mainlist.RefreshData()
                maincontent.RefreshData()
            End If
        End If
    End Sub

    'change Password button
    Private Sub cmdChangePass_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdChangePass.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                AllowN = maincontent.CheckValidateFields()
                If AllowN Then
                    ChangePassword()
                Else
                    If ALLOWNEXTS Then
                        ChangePassword()
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

    'initialize the Module
    Private Sub InitModule()

        Me.Visible = False
        initDefaultIniFile()

        'server Connection
        If SQLServer = "" And SQLID = "" And SQLPW = "" Then
            Dim frm As New frmConnect
            frm.ShowDialog()
            If SQLServer = "" Or SQLID = "" Or SQLPW = "" Then
                Me.Close()
                Exit Sub
            End If
        End If
        CheckMPSLicense()
        CheckAppVersion("ADMIN", SQLServer, SQLID, SQLPW)
        Logon()
        'neil test 20160507 Me.Visible = True
    End Sub

    Private Sub Logon(Optional ByVal bloggedon As Boolean = False)
        '    Me.Visible = False
        '    'AdmSplash.Visible = False
        '    Dim logfrm As New frmLogin
        '    logfrm.ShowDialog()
        '    If Not logfrm.is_loggedon Then
        '        If bloggedon Then
        '            logfrm.Text = "Currently Logged in As: " & USER_NAME
        '            Me.Visible = True
        '            'loading = False
        '            Exit Sub
        '        Else
        '            End
        '        End If
        '    Else
        '        'AdmSplash.Visible = False
        '        Me.Show()
        '    End If
        '    If USER_PASSWORD = DEFAULT_PASSWORD Then
        '        Dim frmchangepassword As New frmChangePassword
        '        frmchangepassword.ShowDialog()
        '        If Not frmchangepassword.is_saved Then
        '            End
        '        End If
        '    End If
        '    'GetThemes()
        '    InitUserSettings()
        '    Me.Visible = True

        Me.Visible = False
        Dim logfrm As New frmLogin("ADMIN")

        CloseCustomLoadScreen()

        logfrm.modulename = "MPS Admin "
        logfrm.ShowDialog(Me)

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
            clsAudit.saveAuditLog("User log in", USER_NAME, auditlogid, System.Environment.MachineName, 10,
                                   , , , , , "MPS Admin", Date.Now) 'neil

            'neil test 20160507 Me.Show()

            clsSec.get_permissions_all(USER_ID, , userPermDt) 'neil 20160915

            COMPANYID = MPSDB.GetConfig("COMPANYID")
            FEATUREKEY = MPSDB.GetConfig("FEATKEY")
            clsFeature.filterTableByFeature(userPermDt, COMPANYID, FEATUREKEY)

        End If
        If USER_PASSWORD = DEFAULT_PASSWORD Then
            Dim frmchangepassword As New frmChangePassword(Me)
            frmchangepassword.ShowDialog()
            If Not frmchangepassword.is_saved Then
                End
            End If
        End If
        InitUserSettings()
        'neil test 20160507 Me.Visible = True
    End Sub

#End Region

#Region "Quick Options Buttons"
#Region "Quick Btn Functions"
    'ask user if they want to change user
    Private Sub ChangeUser()
        If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

            clsAudit.propSQLConnStr = MPSDB.GetConnectionString 'neil
            clsAudit.saveAuditLog("User log out", USER_NAME, auditlogid, System.Environment.MachineName, 0,
                                   , , , , , "MPS Admin", Date.Now) 'neil

            LoadForm()
        End If
    End Sub

    'Change Connections
    Private Sub ChangeConnections()
        If MsgBox("Are you sure you want to change the connection of your database?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            Me.Visible = False
            SQLServer = ""
            SQLID = ""
            SQLPW = ""
            If SQLServer = "" And SQLID = "" And SQLPW = "" Then
                Dim frm As New frmConnect
                frm.ShowDialog()
                If SQLServer = "" Or SQLID = "" Or SQLPW = "" Then
                    Me.Close()
                    Exit Sub
                End If
            End If
            Dim frmMain As New frmAdmMain
            frmMain.Show()
        End If
    End Sub

    'Save layout function
    Private Sub qSaveLayout()
        If MsgBox("Are you sure you want to save Layout? ", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            mainlist.BaseControl = maincontent.Name
            mainlist.SaveLayout()
            SaveLayoutWidth(USER_ID, maincontent.Name, mainlist.Name, MainPanel.Panel1.Width)
            MsgBox("Layout Saved.", MsgBoxStyle.Information, GetAppName)
        End If
    End Sub

    'Reset Layout Function
    Private Sub qResetLayout()
        If MsgBox("Are you sure you want to Retore Layout? ", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            Dim item As String = maincontent.Name
            RestoreLayout(USER_ID, maincontent.Name, mainlist.Name)
            LoadContent(item)
            MsgBox("Layout Restored.", MsgBoxStyle.Information, GetAppName)
        End If
    End Sub

#End Region
    'change User button
    Private Sub cmdChangeUser_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdChangeUser.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
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
                            Application.Restart()
                            LogoutUser()
                            'Logon()
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
        'If Not loading Then
        '    Dim AllowN As Boolean
        '    If BRECORDUPDATEDs Then
        '        AllowN = maincontent.CheckValidateFields()
        '        If AllowN Then
        '            If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Information + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
        '                Me.Visible = False
        '                Logon()
        '            End If
        '        Else
        '            If ALLOWNEXTS Then
        '                If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Information + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
        '                    Me.Visible = False
        '                    Logon()
        '                End If
        '            End If
        '        End If
        '    Else
        '        If MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Information + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
        '            Me.Visible = False
        '            Logon()
        '        End If
        '    End If
        'End If

        'Call checkBtnPermissionAll()
    End Sub

    Private Sub LogoutUser()
        Dim bSuccess As Boolean = False
        bSuccess = USER_SESSION.Dispose(MPSDB)
    End Sub


    Private Sub cmdCheckConnection_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCheckConnection.ItemClick
        MsgBox("Server Name: " & SQLServer, , GetAppName)
    End Sub

    'Database Connection
    Private Sub cmdConnection_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdConnection.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                AllowN = maincontent.CheckValidateFields()
                If AllowN Then
                    ChangeConnections()
                Else
                    If ALLOWNEXTS Then
                        ChangeConnections()
                    End If
                End If
            Else
                ChangeConnections()
            End If
        End If
    End Sub

    'Save Layout button
    Private Sub cmdSaveLayout_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSaveLayout.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                AllowN = maincontent.CheckValidateFields()
                If AllowN Then
                    qSaveLayout()
                Else
                    If ALLOWNEXTS Then
                        qSaveLayout()
                    End If
                End If
            Else
                qSaveLayout()
            End If
        End If
    End Sub

    'Restore Layout BUtton
    Private Sub cmdResetLayout_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdResetLayout.ItemClick
        If MsgBox("Are you sure you want to restore the original layout? ", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            Dim item As String = maincontent.Name
            ResetLayoutButton(mainlist, maincontent)
            'GetLayoutWidth(USER_ID, maincontent.Name, mainlist.Name)
            maincontent.Name = ""
            mainlist.Name = ""
            LoadContent(item)
        End If
        'If MsgBox("Are you sure you want to Retore Layout? ", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
        '    Dim item As String = maincontent.Name
        '    RestoreLayout(USER_ID, maincontent.Name, mainlist.Name)
        '    maincontent.Name = ""
        '    mainlist.Name = ""
        '    LoadContent(item)
        '    MsgBox("Layout Restored.", MsgBoxStyle.Information, GetAppName)
        'End If
    End Sub

#End Region

    Private Sub HideEditOptionBtn()
        For Each nPage In RibbonControl.Pages
            'neil com-out nPage.Visible = True
            For Each nPageGroup In nPage.Groups
                nPageGroup.Visible = True
                If nPageGroup.Tag = 2 Then
                    Dim rpg As DevExpress.XtraBars.Ribbon.RibbonPageGroup = TryCast(nPageGroup, DevExpress.XtraBars.Ribbon.RibbonPageGroup)
                    For i As Integer = 0 To rpg.ItemLinks.Count - 1
                        Dim btn As DevExpress.XtraBars.BarButtonItem = TryCast(rpg.ItemLinks(i).Item, DevExpress.XtraBars.BarButtonItem)
                        btn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    Next
                End If
            Next
        Next
    End Sub

    Private Function GetLayoutWidth(ByVal _UserID As Integer, ByVal _ObjectID As String, ByVal _ObjectList As String)
        Dim x As Integer = 418
        Dim xrow As DataRowView() = ContentsObject.FindRows(_ObjectID)
        MPSDB.BeginReader("SELECT ObjectListWidth FROM dbo.tblUserLayout WHERE FKeyUserID='" & USER_ID & "' AND ObjectID='" & _ObjectID & "' AND ObjectList='" & _ObjectList & "'")
        While MPSDB.Read()
            x = CType(MPSDB.ReaderItem("ObjectListWidth"), Integer)
        End While
        MPSDB.CloseReader()
        If x > 0 Then
            Return x
        Else
            Return xrow(0)("ObjectListDefaultWidth")
        End If
    End Function

    Private Sub BarButtonItem3_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim frmUSett As New frmUserSetting
        frmUSett.ShowDialog(Me)
    End Sub

#Region "BUTTON_PERMISSION" '////////////////////////////////////////////////////////////////////

    Function checkBtnPermissionAll() As Boolean
        Dim nPage As DevExpress.XtraBars.Ribbon.RibbonPage, nPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Dim nPageFocus As String = ""
        Dim tempret As Boolean = False, ret As Boolean


        checkingPerm = True

        clsSec.isUserAdmin(USER_ID, isadmin)
        'If isadmin = NOT_ADMIN Then
        Try

            firstBtn = ""
            'userPermDt.Reset()
            'neil 20160915 clsSec.get_permissions_all(USER_ID, , userPermDt)

            For Each nPage In RibbonControl.Pages
                tempret = False
                For Each nPageGroup In nPage.Groups

                    If nPageGroup.Tag = 1 Then
                        nPageGroup.Visible = True

                        'If nPageGroup.Tag = 1 Then
                        tempret = False
                        tempret = PermInitRibbonItems(nPageGroup)
                        'End If
                        Debug.Print(tempret & " " & nPageGroup.Name)
                        nPageGroup.Visible = tempret
                    End If
                Next
                Debug.Print(tempret & " " & nPage.Name)
                nPage.Visible = tempret

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
        Catch ex As Exception
            MsgBox(ex.Message)
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
                                finalRet = tempRet
                            Else
                                button.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                                'finalRet = tempRet
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
                Permit = clsSec.hasNoViewPermission(btn.Name, USER_ID, True, userPermDt)
                btn.Visibility = Permit

                If Permit = 0 Then
                    'cntr.page.Visible = True
                    'contr.Visibility = Permit
                    'contrVisible = True
                    tempRet = True
                Else
                    tempRet = False
                    'AddHandler btn.ItemClick, AddressOf Contain_ItemClick
                End If

                Debug.Print(">>>>>" & tempRet & " / " & (btn.Name))
            Else
                'AddHandler btn.ItemClick, AddressOf Contain_ItemClick
                If USER_NAME = "Spectral" Then
                    btn.Visibility = 0
                    tempRet = True
                Else 'Admin
                    If userPermDt.Select("Objectid='" & btn.Name & "'").Count > 0 Then 'feature filter
                        btn.Visibility = 0
                        tempRet = True
                    Else
                        btn.Visibility = 1
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

        Catch
            tempRet = False
            errmsg = Err.Description
        End Try

        Return tempRet

    End Function

    Private Sub RibbonControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs) Handles RibbonControl.SelectedPageChanging
        If checkingPerm Then
            e.Cancel = True
        End If
    End Sub

    Function focusBtnPermission(ObjectID As String) As Boolean
        If isadmin = NOT_ADMIN Then

            If clsSec.hasViewOnlyPermission(ObjectID, USER_ID, True) = 0 Then
                Me.cmdEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdDeleteSub.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                Me.cmdDataTool.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                'SetEditOptionsVisibility(ObjectID, False)

            Else
                Me.cmdEdit.Visibility = clsSec.hasNoUpdatePermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                Me.cmdAdd.Visibility = clsSec.hasNoAddPermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                Me.cmdDeleteSub.Visibility = clsSec.hasNoDeletePermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                Me.cmdDelete.Visibility = clsSec.hasNoDeletePermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                Me.cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest

                'Dim tempCnt As Integer, tempperm As Integer

                'tempperm = clsSec.hasNoUpdatePermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                'Me.cmdEdit.Visibility = tempperm
                'tempCnt = tempperm

                'tempperm = clsSec.hasNoAddPermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                'Me.cmdAdd.Visibility = tempperm
                'tempCnt = tempCnt + tempperm

                'Me.cmdDelete.Visibility = clsSec.hasNoDeletePermission(ObjectID, USER_ID, True, userPermDt) 'neiltest
                'Me.cmdDeleteSub.Visibility = (clsSec.hasNoDeletePermission(ObjectID, USER_ID, True, userPermDt)) 'neiltest

                'tempCnt = tempCnt + tempperm

                'If tempCnt > 0 Then
                '    Me.cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
                'Else
                '    Me.cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'neiltest
                'End If

                Me.cmdDataTool.Visibility = clsSec.hasNoDataToolPermission(ObjectID, USER_ID, True, userPermDt)
                ' SetEditOptionsVisibility(ObjectID, True)
            End If
        Else
            Me.cmdEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdDeleteSub.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always 'neiltest
            Me.cmdDataTool.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            'SetEditOptionsVisibility(ObjectID, False)
            '
        End If

        Return True
    End Function

#End Region '/////////////////////////////////////////////////////////////////////////////////////

    Private Sub LICENSEINFO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LICENSEINFO.ItemClick
        Dim ofrm As New frmActivate
        ofrm.cmdOk.Text = "Ok"
        ofrm.ShowDialog()
    End Sub

    Private Sub cmdUpdateProgram_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdUpdateProgram.ItemClick
        If MsgBox("This will update the current program, would you like to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim nCrewingInstance As Integer = 0
            Dim nAdminInstance As Integer = 0
            nCrewingInstance = System.Diagnostics.Process.GetProcessesByName("Crewing").Count
            nAdminInstance = System.Diagnostics.Process.GetProcessesByName("Admin").Count

            If nCrewingInstance > 0 Then
                MsgBox("Cannot proceed update!" & vbCrLf & vbCrLf & "An instance of MPS Crewing detected. Please close it before continuing.", MsgBoxStyle.Exclamation, GetAppName)
                Exit Sub
            End If

            If nAdminInstance > 1 Then
                MsgBox("Cannot proceed update!" & vbCrLf & vbCrLf & "Another instance of MPS Admin detected. Please close it before continuing.", MsgBoxStyle.Exclamation, GetAppName)
                Exit Sub
            End If

            Dim odMain As New System.Windows.Forms.OpenFileDialog
            odMain.Filter = "Object File (*.obx)|*.obx"
            If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If odMain.FileName <> "" Then

                    Dim strArgs As String = "LOAD " & GetIni("VERSION") & " """ & odMain.FileName & """ """ & USER_NAME & """ """ & SQLServer & """ """ & SQLID & """ """ & SQLPW & """"


                    If System.Environment.OSVersion.Version.Major < 6 Then ' Windows XP
                        Try
                            Shell("UpdateManager.exe " & strArgs, AppWinStyle.NormalFocus)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                        End Try
                        'stop application
                        Process.GetCurrentProcess.Kill()

                    Else ' Higher OS Versions

                        Dim pUpdater As New ProcessStartInfo
                        pUpdater.FileName = "UpdateManager.exe"
                        'defining arguments should be : [ACTIONTYPE] [CURRENT_INTERFACE_VERSION] [SQLSERVERINSTANCE] [USERNAME] [PASWRD]
                        'param ACTIONTYPE: [UPDATE or LOAD]
                        pUpdater.Arguments = strArgs
                        pUpdater.UseShellExecute = True
                        pUpdater.WindowStyle = ProcessWindowStyle.Normal
                        Try
                            Dim proc As Process = Process.Start(pUpdater)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                        End Try
                        'stop application
                        Process.GetCurrentProcess.Kill()
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub frmAdmMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
    '    Me.Hide()
    'End Sub

    Private Sub cmdView_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdView.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ViewData"})
    End Sub

    Private Sub cmdHelp_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdHelp.ItemClick

        Try

            'System.Diagnostics.Process.Start(GetAppPath() & "\Resources\MPS5Help.chm")
            OpenHelpFile()

            'System.Diagnostics.Process.Start(GetRecourceFilePath() & "\MPS5Help.chm")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        End Try
    End Sub

    Private Sub frmAdmMain_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub cmdForceLogout_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdForceLogout.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ForceLogout"})
    End Sub

    Private Sub ForceLogoutBtnVisibility(Sender As Object, value As Boolean) Handles maincontent.ForceLogoutVisibility
        'rpgForceLogout.Visible = value

        If value Then

            Dim ret As Integer
            clsSec.isUserAdmin(USER_ID, ret)

            If ret = 1 And userPermDt.Select("Objectid='cmdForceLogout'").Count > 0 Then
                Me.rpgForceLogout.Visible = True
                Exit Sub
            End If

            If clsSec.hasNoViewPermission("cmdForceLogout", USER_ID, True, userPermDt) = 0 Then
                Me.rpgForceLogout.Visible = True
            End If
        Else
            Me.rpgForceLogout.Visible = False
        End If
    End Sub

    Private Sub EnableFLogout(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowEdit
        'Me.cmdForceLogout.Enabled = value
    End Sub

    Private Sub cmdUserSettings_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdUserSettings.ItemClick
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                AllowN = maincontent.CheckValidateFields()
                If AllowN Then
                    LoadUserSettings()
                Else
                    If ALLOWNEXTS Then
                        LoadUserSettings()
                    End If
                End If
            Else
                LoadUserSettings()
            End If
        End If
    End Sub

    Private Sub LoadUserSettings()
        Dim frmUSett As New frmUserSetting
        'frmUSett.Ribbon.Pages.Remove(frmUSett.rpPreference)
        'frmUSett.Ribbon.Pages.Remove(frmUSett.rpFavorites)
        'frmUSett.Ribbon.Pages.Remove(frmUSett.rpLegends)
        frmUSett.rpFavorites.Visible = False
        frmUSett.rpLegends.Visible = False
        frmUSett.rpPreference.Visible = False 'hiding the first page will trigger a selectedpagechange event
        'frmUSett.rpTheme.Visible = False
        'frmUSett.Hide()
        'frmUSett.Ribbon.SelectedPage = frmUSett.rpConnection
        'frmUSett.maincontent.Name = ""
        frmUSett.ShowDialog(Me)

    End Sub

    Private Sub AuditRefreshVisibility(ByVal sender As String, value As Boolean) Handles maincontent.AuditRefreshVisibility
       
        If value Then
            If clsSec.hasNoViewPermission("Audit", USER_ID, True, userPermDt) = 0 Then
                ' If value Then
                Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                'rpgAudit.Visible = True
                'rpgAuditReportOptions.Visible = True
                cmdPreviewReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                chkAuditWithDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                rpAudit.Visible = True
            Else
                Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                'rpgAudit.Visible = False
                'rpgAuditReportOptions.Visible = False
                cmdPreviewReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                chkAuditWithDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                rpAudit.Visible = False
            End If
            'End If
        Else
            Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            'rpgAudit.Visible = False
            'rpgAuditReportOptions.Visible = False
            cmdPreviewReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            chkAuditWithDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            rpAudit.Visible = False
        End If
    End Sub

    Private Sub btnClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
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
End Class
