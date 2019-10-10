Imports System.Drawing

Public Class frmPopUpCrew

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CompGridGroup.Text = "Qualification Check" 'added by tony20171228
    End Sub

    Private Sub CompetenceDocsView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles CompetenceDocsView.CustomDrawRowIndicator
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CompetenceDocsView
        Dim imageName As String = ""
        Select Case IfNull(view.GetRowCellValue(e.RowHandle, "StatusLevel"), "")
            Case "High"
                imageName = "Lacking.png"
            Case "Medium"
                imageName = "toexpire.png"
            Case "Low"
                imageName = "optional.png"
        End Select

        If Not IfNull(imageName, "").Equals("") Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)
            Dim fileName As String = Application.StartupPath & "\Resources\Icons\" & imageName & ""
            Dim iconForFile As Icon = SystemIcons.WinLogo
            iconForFile = Icon.ExtractAssociatedIcon(fileName)
            e.Graphics.DrawImage(Image.FromFile(fileName), New RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))
            e.Handled = True
        End If
    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If Not e.SelectedControl Is CompetenceDocsGrid Then Return

        Dim info As ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CompetenceDocsGrid.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells
        If hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
            'An object that uniquely identifies a row indicator cell
            Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
            Dim text As String = "" '"Row " + hi.RowHandle.ToString()

            Select Case IfNull(view.GetRowCellValue(hi.RowHandle, "StatusLevel"), "")
                Case "High"
                    text = "Lacking Document / Expired Document"
                Case "Medium"
                    text = "Document about to expire before due contract"
                Case "Low"
                    text = "Document about to expire before due contract [Optional]"
            End Select

            If text.Length > 0 Then info = New ToolTipControlInfo(o, text)
        End If
        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub
End Class