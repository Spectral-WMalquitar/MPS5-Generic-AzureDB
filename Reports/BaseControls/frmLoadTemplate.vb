Public Class frmLoadTemplate

    Public CancelButtonIsClicked As Boolean = False
    Public OKButtonIsClicked As Boolean = False

    Public Enum UsedBy
        Report = 1
        KPI = 2
    End Enum

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(ByVal UsedBy As UsedBy, ByVal TemplateCaption As String, Optional ByVal ShowOptionViewAfterLoad As Boolean = False)
        InitializeComponent()

        If TemplateCaption.Length > 0 Then lblLoadTemplate.Text = "Load Template: " & TemplateCaption & "?"
        If UsedBy = frmLoadTemplate.UsedBy.Report Then chkViewAfterLoad.Text = "View report after template is loaded"
        If UsedBy = frmLoadTemplate.UsedBy.KPI Then chkViewAfterLoad.Text = "Generate chart after template is loaded"
        If UsedBy = frmLoadTemplate.UsedBy.Report And UsedBy = frmLoadTemplate.UsedBy.KPI Then chkViewAfterLoad.Text = "View after template is loaded"
        chkViewAfterLoad.Visible = ShowOptionViewAfterLoad

    End Sub

    Private Sub btnOK_Click(sender As Object, e As System.EventArgs) Handles btnOK.Click
        OKButtonIsClicked = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        CancelButtonIsClicked = True
        Me.Close()
    End Sub

    Private Sub frmLoadTemplate_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        btnCancel.Focus()
    End Sub
End Class