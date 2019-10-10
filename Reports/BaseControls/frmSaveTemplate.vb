Imports DevExpress.XtraEditors

Public Class frmSaveTemplate

    Dim EnableContentSelection As Boolean
    Dim ReportGroup As String
    Dim ObjectID As String
    Public CancelButtonIsClicked As Boolean = False
    Public SaveButtonIsClicked As Boolean = False

    Public oReportTemplate As New ReportTemplateDetail

    Const CHECK_SELECTION_BY_DEFAULT As Boolean = False

    Dim clsAudit As New clsAudit
    Dim RepCaption As String

    Sub New(Optional ByVal _EnableContentSelection As Boolean = False, Optional _ReportGroup As String = "", Optional _ObjectID As String = "", Optional _RepCaption As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        EnableContentSelection = _EnableContentSelection
        ReportGroup = _ReportGroup
        ObjectID = _ObjectID
        RepCaption = _RepCaption

        InitControls()

    End Sub


    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        cmdSave.Focus()
        If Not ValidateEntries() Then Exit Sub

        SaveButtonIsClicked = True

        oReportTemplate = New ReportTemplateDetail
        With oReportTemplate
            .Name = cboTemplateName.Text
            If Not IsNothing(txtDescription.EditValue) Then
                If txtDescription.EditValue.ToString.Length > 0 Then
                    .Description = txtDescription.EditValue
                End If
            End If

            .SaveOptions.Filtering.Selected = chkFilter.Checked
            .SaveOptions.Sorting.Selected = chkSort.Checked
            .SaveOptions.SelectedData.Selected = chkSelectedData.Checked

            .LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Template", _
                                                      0, System.Environment.MachineName, _
                                                      "Template Name : " & cboTemplateName.Text & " / " & _
                                                      ReportGroup & " Name : " & RepCaption, ReportGroup & " - Save Template") 'neil

        End With

        Me.Close()
    End Sub



    Private Function ValidateEntries() As Boolean
        Dim ReturnValue As Boolean = False
        If cboTemplateName.Text Is Nothing Then
            MsgBox("Please enter a valid Template Name.", MsgBoxStyle.Information)
            cboTemplateName.Focus()
        ElseIf cboTemplateName.Text.ToString.Length = 0 Then
            MsgBox("Please enter a Template Name.", MsgBoxStyle.Information)
            cboTemplateName.Focus()
        ElseIf cboTemplateName.Text = cboTemplateName.Properties.NullText Then
            MsgBox("Please enter a Template Name.", MsgBoxStyle.Information)
            cboTemplateName.Focus()
        ElseIf EnableContentSelection And Not chkFilter.Checked And Not chkSort.Checked And Not chkSelectedData.Checked Then
            MsgBox("Please select an item(s) to save.", MsgBoxStyle.Information)
            chkFilter.Focus()
        Else
            ReturnValue = True
        End If

        Return ReturnValue
    End Function

    Private Sub InitControls()
        '############################################################################################################################################################################################################################################################
        Dim dt As New DataTable
        Dim col As DataColumn

        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Column - PKey
        col = New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Column - Name
        col = New DataColumn
        col.ColumnName = "Name"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        dt.Rows.Add(New Object() {"SYSTMPOPTFS", "Filter and Sorting Only"})
        dt.Rows.Add(New Object() {"SYSTMPOPTSEL", "Selection Only"})
        dt.Rows.Add(New Object() {"SYSTMPOPTALL", "Save All"})

        '############################################################################################################################################################################################################################################################
        If EnableContentSelection Then
            LayoutControlGroup_ContentSelection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            chkFilter.Checked = CHECK_SELECTION_BY_DEFAULT
            chkSort.Checked = CHECK_SELECTION_BY_DEFAULT
            chkSelectedData.Checked = CHECK_SELECTION_BY_DEFAULT
        Else
            LayoutControlGroup_ContentSelection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If

        '############################################################################################################################################################################################################################################################
        'Template Name
        dt = New DataTable

        col = New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Name"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        If Not IfNull(ReportGroup, "").Equals("") And Not IfNull(ObjectID, "").Equals("") Then
            dt = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.MSystblRepOptTemplate WHERE ReportGroup = '" & IfNull(ReportGroup, "") & "' AND ReportObjectID = '" & IfNull(ObjectID, "") & "' AND UserID = " & USER_ID & " ORDER BY Name")
        End If

        cboTemplateName.Properties.DataSource = dt
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        CancelButtonIsClicked = True
        Me.Close()
    End Sub

    Private Sub cboTemplateName_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboTemplateName.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            sender.EditValue = Nothing
        End If
    End Sub

    Private Sub cboTemplateName_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboTemplateName.ProcessNewValue

        If CStr(e.DisplayValue) <> String.Empty Then
            Dim dt As DataTable = TryCast(TryCast(sender, LookUpEdit).Properties.DataSource, DataTable)

            For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                If IfNull(dt.Rows(i)("PKey"), "").Equals("") Then
                    dt.Rows(i).Delete()
                End If
            Next

            Dim newRow As DataRow = dt.NewRow()
            newRow("PKey") = ""
            newRow("Name") = e.DisplayValue.ToString()

            dt.Rows.Add(newRow)

            e.Handled = True
        End If
    End Sub

    Private Sub frmSaveTemplate_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cmdCancel.Focus()
    End Sub
End Class