
Public Class frmAppraisalPopup
    Dim extAssembly As System.Reflection.Assembly
    Private WithEvents maincontent As New BaseControl.BaseControl
    Dim loading As Boolean = False
    Private Const strDLL As String = "Crewing"
    Dim _Content As String = ""
    Dim crewID As String
    Dim Description As String

    Sub New(_strID As String, strDesc As String, editable As Boolean, appraisal As CrewAppraisal)
        InitializeComponent()
        Me.crewID = _strID
        Me.Description = strDesc
        frmAppraisalEdit.crewName = strDesc
        frmAppraisalEdit.crewID = _strID
        frmAppraisalEdit.IsNewAppraisal = IIf(IsNothing(appraisal), True, False)
        frmAppraisalEdit.selectedCrewAppraisal = Nothing
        frmAppraisalEdit.selectedCrewAppraisal = appraisal
        frmAppraisalEdit.editable = editable
    End Sub

    Private Sub LoadContent(cContent As String)
        loading = True
        Me.Cursor = Cursors.WaitCursor
        If cContent <> "" And maincontent.Name <> cContent Then
            Me.MainPanel.Controls.Clear()
            maincontent.Dispose()
            extAssembly = System.Reflection.Assembly.Load(strDLL)
            maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
            maincontent.Dock = DockStyle.Fill
            MainPanel.Controls.Add(maincontent)
            maincontent.DB = MPSDB
            maincontent.Name = cContent
            maincontent.RefreshData()
        Else
            Me.MainPanel.Controls.Clear()
            maincontent.Dispose()
            maincontent.Name = ""
        End If
        Me.Cursor = Cursors.Arrow
        loading = False
    End Sub


    Private Sub frmUserSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadContent("frmAppraisalEdit")
    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As System.EventArgs) Handles RibbonControl.SelectedPageChanged
        LoadContent("frmAppraisalEdit")
    End Sub


    Private Sub frmAppraisalPopup_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If maincontent.CheckValidateFields() Then
            Dim result As DialogResult = MessageBox.Show("You have changes in the selected Appraisal, do you want to save it?", "Appraisal", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If DialogResult.Yes = result Then
                frmAppraisalEdit.IsTriggeredInClose = True
                maincontent.SaveData()
            ElseIf DialogResult.Cancel = result Then
                e.Cancel = True
            Else
                e.Cancel = False
                BRECORDUPDATEDs = False
            End If
        End If

    End Sub
End Class