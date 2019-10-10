Public Class frmOnboardCrew

    Public Sub New(ByVal vslCode As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If vslCode <> "" Then
            Dim dt As New DataTable
            dt = MPSDB.CreateTable("SELECT CrewName, RankName, DateDue FROM [dbo].[frmCrewOnboard_Datasource] WHERE FKeyVslCode = '" & vslCode & "' ORDER BY DateDue ASC")
            GridControl1.DataSource = dt
        Else
            Me.Close()
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub ReloadData(ByVal vslCode As String)
        If vslCode <> "" Then
            Dim dt As New DataTable
            dt = MPSDB.CreateTable("SELECT CrewName, RankName, DateDue FROM [dbo].[frmCrewOnboard_Datasource] WHERE FKeyVslCode = '" & vslCode & "' ORDER BY DateDue ASC")
            GridControl1.DataSource = dt
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmOnboardCrew_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub
End Class