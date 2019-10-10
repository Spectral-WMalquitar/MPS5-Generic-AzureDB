Public Class AddUtility

    Public MPSDB As SQLDB
    Public MPSSESSION As MPSSession
    Private WithEvents maincontent As New BaseControl.BaseControl
    Private WithEvents mainlist As New BaseControl.BaseList
    Dim extAssembly As System.Reflection.Assembly
    Dim ContentsObject As DataView
    Dim loading As Boolean = False

    Public Content As String 'the Content to be Loaded
    Public DLL As String 'The DLL of the content

    Private Sub AddUtility_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Me.LookUpEdit1.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmRate Order By SortCode ASC")
        LoadContent(Content, DLL)
    End Sub

    Private Sub LookUpEdit1_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        If e.Button.Index = 1 Then 'Add Button
            MsgBox("Add Button")
        End If
    End Sub

    Private Sub LoadContent(ByVal cContent As String, ByVal strDLL As String)
        loading = True
        'Dim gGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        'Dim nButton As DevExpress.XtraBars.BarButtonItem = RibbonControl.Items(cContent)
        'Dim nGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroupItemLinkCollection = TryCast(nButton.Links(0).Links, DevExpress.XtraBars.Ribbon.RibbonPageGroupItemLinkCollection)
        ''Ensure that the select item was selected.
        ''RibbonControl.SelectedPage = nGroup.PageGroup.Page
        'nButton.Down = True
        'nButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        RibbonControl.Minimized = False
        'MainPanel.Visible = True


        If cContent <> maincontent.Name Then
            'Dim xrow As DataRowView() = ContentsObject.FindRows(cContent)
            'Dim blList As String = Trim(xrow(0)("ObjectList")) - original
            Dim blList As String = ""
            'Dim strDLL As String = Trim(xrow(0)("DLL"))
            'Dim strDLL As String = UCase(RibbonControl.SelectedPage.Text)
            'Dim strFilter As String = Trim(IfNull(xrow(0)("Filter"), ""))
            maincontent.CheckIFDataUpdated()
            Me.Cursor = Cursors.WaitCursor
            Try
                MainPanel.Panel2.Controls.Clear()
                maincontent.Dispose()
                extAssembly = System.Reflection.Assembly.Load(strDLL)
                maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                If blList = "" Then
                    MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
                Else
                    'If cContent = "LOGO" Then
                    '    'MainPanel.Panel1.Visible = False
                    '    'MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
                    'Else
                    '    'MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                    'End If

                    mainlist.Dispose()
                    'MainPanel.Panel1.Controls.Clear()
                    mainlist = extAssembly.CreateInstance(strDLL & "." & blList, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                    'If strFilter = "" Then
                    '    mainlist.ClearFilter()
                    '    'Select Case cContent
                    '    '    Case "BIODATA", "TRAVELDOC", "LICCERT", "MEDCERT", "COURSE", "MEDCERT", "CREWDEC"
                    '    '        If bbOnboard.Down Then
                    '    '            mainlist.SetFilter("StatCode='SYSONB'")
                    '    '        ElseIf bbAshore.Down Then
                    '    '            mainlist.SetFilter("StatCode<>'SYSONB'")
                    '    '        End If
                    '    'End Select
                    'Else
                    '    mainlist.SetFilter(strFilter)
                    'End If
                    MainPanel.Panel1.Controls.Add(mainlist)
                    mainlist.DB = MPSDB
                    mainlist.RefreshData()
                    mainlist.Dock = DockStyle.Fill
                    maincontent.blList = mainlist
                End If
                maincontent.Dock = DockStyle.Fill
                MainPanel.Panel2.Controls.Add(maincontent)
                maincontent.DB = MPSDB
                maincontent.Name = cContent
                maincontent.RefreshData()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Me.Cursor = Cursors.Default
        End If
        loading = False
    End Sub
End Class