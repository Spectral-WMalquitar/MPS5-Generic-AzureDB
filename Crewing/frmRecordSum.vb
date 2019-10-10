Public Class frmRecordSum

    Dim extAssembly As System.Reflection.Assembly
    Private WithEvents maincontent As New BaseControl.BaseControl
    Dim loading As Boolean = False
    Private Const strDLL As String = "Crewing"
    Dim _Content As String = ""
    Public IDNbr As String = ""

    Private Sub LoadContent(cContent As String)
        cContent = "RecordSum"
        loading = True
        If cContent <> "" And maincontent.Name <> cContent Then
            Me.MainPanel.Controls.Clear()
            maincontent.Dispose()
            extAssembly = System.Reflection.Assembly.Load(strDLL)
            maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
            maincontent.Dock = DockStyle.Fill
            MainPanel.Controls.Add(maincontent)
            maincontent.DB = MPSDB
            maincontent.Name = cContent
            maincontent.ExecCustomFunction(New Object() {"LoadData", IDNbr})
            maincontent.RefreshData()   'uncommented out by tony20161219 'moved after execcustom by calvhin 20170113
            'maincontent.ExecCustomFunction(New Object() {"InitTabs", "CREWREASSIGNMENT"}) 'commented by calvhin 20170113
        Else
            Me.MainPanel.Controls.Clear()
            maincontent.Dispose()
            maincontent.Name = ""
        End If
        loading = False
    End Sub

    Private Sub frmRecordSum_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Height = 600
        LoadContent("RecordSum")
    End Sub
End Class