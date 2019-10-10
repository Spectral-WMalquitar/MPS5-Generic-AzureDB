Public Class frmCrewComments
    Dim cID As String
    Dim FormName As String = "Crew Comments" 'neil
    'Dim LastUpdatedBy As String = GetUserName() & "<><FrmCRewComment>"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Private isUPDATING As Boolean = False

    Public Sub New(ByVal dt As DataTable, ByVal CrewID As String, Optional ByVal crewName As String = "Crew Comments")
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        GridBand1.Caption = crewName
        CommentGrid.DataSource = dt
        cID = CrewID
        btnSave.Enabled = False
    End Sub

    Private Sub btnSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        SaveData()
    End Sub

    Private Sub SaveData()
        Me.Focus()
        Dim info As Boolean = False
        'Dim sqls As New ArrayList
        'For i As Integer = 0 To CommentView.RowCount - 1
        '    If CommentView.GetRowCellValue(i, "Remarks") = "New" Then
        '        sqls.Add("INSERT INTO [dbo].[tblComment]([FKeyIDNbr],[Comment],[ComBy]) " & _
        '                                    "VALUES('" & cID & "','" & CommentView.GetRowCellValue(i, "Comment") & "', '" & USER_NAME & "')")
        '        CommentView.SetRowCellValue(i, "Remarks", "")
        '    End If
        'Next
        'If sqls.Count > 0 Then
        info = MPSDB.RunSqls(SaveComments(cID))
        If info Then
            MsgBox(GetMessage("Inserted", info), MsgBoxStyle.Information, GetAppName)
            btnSave.Enabled = False
            isUPDATING = False
            Exit Sub
        End If
        'MessageBox.Show("Comment Saved.", "MPS5 - Crew Comments", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Function SaveComments(ByVal _CompanyID As String) As ArrayList
        Dim query As New ArrayList
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        With Me.CommentView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO " & sPrefix & "dbo.tblComment(FKeyIDNbr,Comment,ComDate,ComBy,FilePath,LastUpdatedBy)" & _
                                   "VALUES('" & cID & "'" & _
                                   ",'" & .GetRowCellValue(i, "Comment").ToString.Replace("'", "''") & "'" & _
                                   "," & ChangeToSQLDate(.GetRowCellValue(i, "ComDate")) & _
                                   ",'" & .GetRowCellValue(i, "ComBy") & "'" & _
                                   ",'" & .GetRowCellValue(i, "FilePath") & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE " & sPrefix & "dbo.tblComment SET " & _
                                  "Comment = '" & .GetRowCellValue(i, "Comment").ToString.Replace("'", "''") & "'" & _
                                  ",ComDate = " & ChangeToSQLDate(.GetRowCellValue(i, "ComDate")) & _
                                  ",ComBy = '" & .GetRowCellValue(i, "ComBy") & "'" & _
                                  ",FilePath = '" & .GetRowCellValue(i, "FilePath") & "'" & _
                                  ",DateUpdated =(getdate())" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyIDNbr = '" & cID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub CommentView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CommentView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            If e.Column.FieldName.ToString <> "ComBy" Then
                If e.Column.FieldName.ToString <> "ComDate" Then
                    Me.CommentView.SetRowCellValue(e.RowHandle, "Edited", True)
                    Me.CommentView.SetRowCellValue(e.RowHandle, "ComDate", Date.Now)
                    'Me.CommentView.SetRowCellValue(e.RowHandle, "ComBy", GetUserName)   'edited by tony20170522
                    Me.CommentView.SetRowCellValue(e.RowHandle, "ComBy", USER_NAME)
                End If
            End If
        End If
        btnSave.Enabled = True
    End Sub

    Private Sub CommentView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CommentView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyIDNbr"), cID)
        'View.SetRowCellValue(e.RowHandle, View.Columns("ComBy"), GetUserName)  'edited by tony20170522
        View.SetRowCellValue(e.RowHandle, View.Columns("ComBy"), USER_NAME)
        btnSave.Enabled = False
        isUPDATING = True
    End Sub

    Private Sub CommentView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CommentView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CommentView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.CommentView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub CommentView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CommentView.RowCellStyle
        If Me.CommentView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.CommentView.GetRowCellValue(e.RowHandle, "Edited") And Me.CommentView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.CommentView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.CommentView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
        ViewRowCellStyle(sender, e, "")
    End Sub

    Private Sub CommentView_RowCountChanged(sender As Object, e As System.EventArgs) Handles CommentView.RowCountChanged
        btnSave.Enabled = True
    End Sub

    Private Sub RepositoryItemDateEdit1_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemDateEdit1.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub frmCrewComments_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isUPDATING Then
            Dim nAnswer = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel, GetAppName)

            Select Case nAnswer
                Case MsgBoxResult.Cancel
                    e.Cancel = True

                Case MsgBoxResult.Yes
                    SaveData()

            End Select
        End If
    End Sub
End Class