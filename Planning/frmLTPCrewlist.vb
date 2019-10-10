Imports Crewing
Public Class frmLTPCrewlist
    Dim frmFilter As New CrewListFilter
    Dim ucCrewlist As New CrewList
    Public strFilter As String = ""

    Private Sub frmLTPCrewlist_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmLTPCrewlist_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
        Me.TopMost = True
        Me.IsMdiContainer = True
        Me.RibbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always
        frmFilter.Text = "Filter"
        frmFilter.MdiParent = Me
        frmFilter.WindowState = Windows.Forms.FormWindowState.Maximized
        frmFilter.MaximizeBox = False
        frmFilter.MinimizeBox = False
        frmFilter.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmFilter.DoDragDrop = DragDropEffects.None
        frmFilter.CloseBox = False
        frmFilter.Dock = Windows.Forms.DockStyle.Fill
        frmFilter.Show()
        AddHandler frmFilter.Move, AddressOf Form_Move
        Me.SplitContainerControl1.Panel1.Controls.Add(frmFilter)
        Me.SplitContainerControl1.Panel2.Controls.Add(ucCrewlist)
        Me.SplitContainerControl1.Panel1.Controls(0).Dock = Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Panel2.Controls(0).Dock = Windows.Forms.DockStyle.Fill
        ucCrewlist.ExecCustomFunction(New Object() {"SortRank_ASC"})
        ucCrewlist.Draggable(True)
        ucCrewlist.LTPSetDB(MPSDB)
        ucCrewlist.RefreshData()
        'ucCrewlist.ExecCustomFunction(New Object() {"SetFocusedRank", strFilter, "RankCode"})
    End Sub

    Private Sub btnFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFilter.DownChanged
        If btnFilter.Down = True Then
            Me.SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
            Me.Width = 800
            Me.SplitContainerControl1.SplitterPosition = Me.Width * 0.6
            btnFilter.Caption = "Hide Filter"
            Me.TopMost = False
        Else
            Me.SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
            Me.Width = 400
            btnFilter.Caption = "Show Filter"
            Me.TopMost = True
        End If
    End Sub

    Private Sub btnApplyFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnApplyFilter.ItemClick
        frmFilter.applyFilter()
        btnFilter.Down = False
        ucCrewlist.SetFilter(strCrewListFilter)
    End Sub

    Private Sub btnClearFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClearFilter.ItemClick
        ucCrewlist.ClearFilter()
    End Sub

    Private Sub btnClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
        Me.Hide()
    End Sub

    Public Sub setFocusRank(ByVal strRankName As String, ByVal clm As String)
        ucCrewlist.ExecCustomFunction(New Object() {"SetFocusedRank", strRankName, clm})
    End Sub

    Private Sub Form_Move(ByVal sender As Object, ByVal e As System.EventArgs)
        'sender.top = 0
        'sender.left = 0
    End Sub
End Class