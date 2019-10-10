Imports System.Drawing

Public Class frmExpDocs
    Dim dtDocGroups As DataTable
    Dim dtAdmDocs As DataTable
    Dim strDocFilter As String = ""
    Dim strHasExp As String = ""
    Dim expDocDays As Integer = GetUserSetting("DocExpDays", "0")
    Public pressedGoto As Boolean = False
    Public gotoContent As String = ""
    Public selectedKey As String = ""
    Public selectedGroup As String = ""
    Dim userdatafilterstring_SP As String
    Dim _CrewList As New DataTable
    Public Sub New(CrewList As DataTable)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _CrewList = CrewList
        dtDocGroups = MPSDB.CreateTable("SELECT PKey, Name, SortCode FROM tblAdmDocGroup WHERE PKey IN ('SYSTRAVELDOC','SYSMEDCERT','SYSLICCERT','SYSNATINFO') UNION SELECT 'isCourse', 'Training', 5 ORDER BY SortCode")
        dtAdmDocs = MPSDB.CreateTable("SELECT PKey, Name, FKeyDocGroup From tblAdmDocument UNION SELECT PKey, Name, 'isCourse' From tblAdmCourse")
        For i As Integer = 0 To dtDocGroups.Rows.Count - 1
            Dim xtraTab As New DevExpress.XtraTab.XtraTabPage
            xtraTab.Name = dtDocGroups.Rows(i).Item("PKey").ToString
            xtraTab.Text = dtDocGroups.Rows(i).Item("Name").ToString
            tabDocGroups.TabPages.Add(xtraTab)
        Next
        genericDateEdit.EditMask = "dd-MMM-yyyy"
        genericDateEdit.Mask.UseMaskAsDisplayFormat = True
        userdatafilterstring_SP = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
        XtraTabPage1.PageVisible = False
        chkExpired.EditValue = chkEdit2.ValueChecked
        chkExpiring.EditValue = chkEdit.ValueChecked

        loadExpDocSetting()
        AddHandler chkExpDocAlert.EditValueChanged, AddressOf chkExpDocAlert_EditValueChanged
    End Sub

    Private Sub tabDocGroups_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tabDocGroups.SelectedPageChanged
        Dim dtDocs As New DataTable
        'dtDocs = MPSDB.CreateTable("SELECT UPPER(ci.LName) + ', ' + ISNULL(ci.FName,'') + ' ' + ISNULL(ci.MName,'') as CrewName,ed.* FROM Expiring_Documents ed LEFT JOIN tblCrewInfo ci ON ed.IDNbr = ci.PKey WHERE ISNULL(FKeyDocGroup,'isCourse') = '" & e.Page.Name & "' ORDER BY CrewName, Name")
        'dtDocs = MPSDB.CreateTable("EXEC SP_EXPIRING_DOCUMENTS @DocExpDays = " & expDocDays & ", @FKeyDocGroup = '" & e.Page.Name & "'").Select("DateExpiry IS NOT NULL").CopyToDataTable
        'dtDocs = MPSDB.CreateTable("EXEC [SP_EXPIRING_DOCUMENTS] @DocExpDays = " & expDocDays & ", @FKeyDocGroup = '" & e.Page.Name & "', @userdatafilterstring = '" & Replace(userdatafilterstring_SP, "'", "''") & "'")
        'dtDocs = SP_ExpiringDocuments(e.Page.Name, Replace(userdatafilterstring_SP, "'", "''"), "")
        dtDocs = SP_ExpiringDocuments(e.Page.Name, userdatafilterstring_SP, "")
        Maingrid.DataSource = dtDocs
        e.Page.Controls.Add(Maingrid)
        Mainview.ClearColumnsFilter()
        If dtAdmDocs.Select("FKeyDocGroup = '" & e.Page.Name & "'", "Name").Count > 0 Then
            documentEdit.DataSource = dtAdmDocs.Select("FKeyDocGroup = '" & e.Page.Name & "'", "Name").CopyToDataTable
        Else
            documentEdit.DataSource = Nothing
        End If

        'tony20160817
        Select Case e.Page.Name
            Case "isCourse"
                colDateIssue.Caption = "Date Started"
                colDateExpiry.Caption = "Date Ended"

            Case Else
                colDateIssue.Caption = "Date Issue"
                colDateExpiry.Caption = "Date Expiry"
        End Select
        'end tony
        docFilter.EditValue = Nothing
        btnApply_ItemClick(Nothing, Nothing)
    End Sub

    Private Function SP_ExpiringDocuments(PageName As String, userDateFilter_SP As String, Optional strCrewFilter As String = "") As DataTable
        Dim cTable As New DataTable
        Dim sqlConn As New SqlClient.SqlConnection(MPSDB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_EXPIRING_DOCUMENTS"
                With cmd.Parameters
                    .AddWithValue("@DocExpDays", expDocDays)
                    .AddWithValue("@FKeyDocGroup", PageName)
                    .AddWithValue("@userdatafilterstring", userDateFilter_SP)
                    .AddWithValue("@crewFilter", strCrewFilter)
                    .AddWithValue("@ExpiringCrewList", _CrewList)
                End With
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(cTable)
                End Using

            End Using

        Catch ex As Exception
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try

        Return cTable
    End Function

    Private Sub btnApply_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnApply.ItemClick
        Dim hasExp As Integer = 0
        strDocFilter = IfNull(docFilter.EditValue, "")

        hasExp += chkExpiring.EditValue
        hasExp += chkExpired.EditValue

        Select Case hasExp
            Case 0
                strHasExp = ""
            Case 1
                strHasExp = " AND hasExpDoc = 1"
            Case 2
                strHasExp = " AND hasExpDoc = 2"
            Case Else
                strHasExp = " AND hasExpDoc IN (1,2)"
        End Select


        If strHasExp = "" And strDocFilter = "" Then
            Mainview.ClearColumnsFilter()
        Else
            If strDocFilter = "" Then
                Mainview.ActiveFilterString = strHasExp.Remove(0, 5)
            Else
                Mainview.ActiveFilterString = "FKeyDoc = '" & strDocFilter & "'" & strHasExp
            End If
        End If
    End Sub

    Private Sub documentEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles documentEdit.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            docFilter.EditValue = Nothing
        End If
    End Sub

    Private Sub btnGotoDocs_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGotoDocs.ItemClick
        selectedID = Mainview.GetFocusedRowCellValue("IDNbr")
        selectedKey = Mainview.GetFocusedRowCellValue("DocCode")
        selectedGroup = tabDocGroups.SelectedTabPage.Name
        pressedGoto = True
        Select Case selectedGroup
            Case "SYSTRAVELDOC", "SYSLICCERT", "SYSMEDCERT"
                gotoContent = "Document"
            Case "SYSNATINFO"
                gotoContent = "Biodata"
            Case "isCourse"
                gotoContent = "Training"
        End Select
        Me.Close()
    End Sub

#Region "REPORTING"

    Private Sub cmdPreviewReport_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdPreviewReport.ItemClick
        Dim dt As New DataTable()
        dt = getCurrentData()
        dt.DefaultView.Sort = getSorting()

        If dt.Rows.Count = 0 Or dt Is Nothing Then
            MsgBox("No record to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, GetAppName)
        Else
            Dim expDoc As New ExpDoc(dt)
        End If
    End Sub

    Private Sub cmdPreviewReportAll_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdPreviewReportAll.ItemClick
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim prevTab As Integer = tabDocGroups.SelectedTabPageIndex

        For cnt As Integer = 0 To tabDocGroups.TabPages.Count - 1
            tabDocGroups.SelectedTabPageIndex = cnt
            If Not ds.Tables.Contains(tabDocGroups.SelectedTabPage.Text) Then
                dt = getCurrentData()
                ds.Tables.Add(dt)
            End If
        Next cnt
        tabDocGroups.SelectedTabPageIndex = prevTab

        dt = consolidateData(ds)
        dt.DefaultView.Sort = getSorting()

        If dt.Rows.Count = 0 Or dt Is Nothing Then
            MsgBox("No record to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, GetAppName)
        Else
            Dim report As New ExpDoc_All(dt)
        End If
    End Sub

    Private Function getCurrentData() As DataTable
        Dim dt As New DataTable()
        'for report header
        dt.TableName = tabDocGroups.SelectedTabPage.Text
        'get visible columns
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Mainview.VisibleColumns
            dt.Columns.Add(col.Tag, col.ColumnType)
        Next
        'add 'hasExpDoc'
        dt.Columns.Add("hasExpDoc")
        'add 'Remarks'
        dt.Columns.Add("Remarks")

        'get visible rows
        For i As Integer = 0 To Mainview.DataRowCount - 1
            Dim row As DataRow = dt.NewRow()
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In Mainview.VisibleColumns
                row(col.Tag) = Mainview.GetRowCellValue(i, col)
            Next col
            row("hasExpDoc") = Mainview.GetRowCellValue(i, "hasExpDoc")
            row("Remarks") = Mainview.GetRowCellValue(i, "Remarks")
            dt.Rows.Add(row)
        Next i

        Return dt
    End Function

    Private Function consolidateData(ds As DataSet) As DataTable
        Dim dt As New DataTable()

        dt.Columns.Add("DocType")
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Mainview.VisibleColumns
            dt.Columns.Add(col.Tag, col.ColumnType)
        Next
        dt.Columns.Add("hasExpDoc")
        dt.Columns.Add("Remarks")

        For Each tempDT As DataTable In ds.Tables
            For i As Integer = 0 To tempDT.Rows.Count - 1
                Dim row As DataRow = dt.NewRow()
                row("DocType") = tempDT.TableName
                For Each col As DataColumn In tempDT.Columns
                    row(col.Caption) = tempDT.Rows(i).Item(col.Caption)
                Next col
                row("hasExpDoc") = tempDT.Rows(i).Item("hasExpDoc")
                row("Remarks") = tempDT.Rows(i).Item("Remarks")
                dt.Rows.Add(row)
            Next i
        Next

        Return dt
    End Function

    Private Function getSorting() As String
        Dim sort As String = ""

        If Mainview.SortedColumns.Count <> 0 Then
            For cnt As Integer = 0 To Mainview.SortedColumns.Count - 1
                sort = sort & Mainview.SortedColumns(cnt).Caption & " " & Mainview.SortedColumns(cnt).SortOrder.ToString & ","
            Next
            sort = sort.Substring(0, sort.Length - 1)
            sort = sort.Replace("Descending", "DESC")
            sort = sort.Replace("Ascending", "ASC")
        End If

        Return sort
    End Function

#End Region

    Private Sub Mainview_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Mainview.RowCellStyle
        Dim view As GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "DateExpiry" Then
            Select Case view.GetRowCellValue(e.RowHandle, "hasExpDoc")
                Case 1
                    e.Appearance.BackColor = Color.Orange
                    e.Appearance.BackColor2 = Color.Red
                    e.Appearance.GradientMode = Drawing2D.LinearGradientMode.Horizontal
                Case 2
                    e.Appearance.BackColor = Color.White
                    e.Appearance.BackColor2 = Color.Orange
                    e.Appearance.GradientMode = Drawing2D.LinearGradientMode.Horizontal
            End Select
        End If
    End Sub

    Private Sub loadExpDocSetting()
        Dim strExpDocsAlert As String = GetUserSetting("ExpDocsAlert")
        chkExpDocAlert.EditValue = CType(IIf(strExpDocsAlert.Equals(""), "False", strExpDocsAlert), Boolean)
    End Sub

    Private Sub frmExpDocs_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        SaveUserSetting("ExpDocsAlert", chkExpDocAlert.EditValue)
    End Sub

    Private Sub chkExpDocAlert_EditValueChanged(sender As System.Object, e As System.EventArgs)
        Dim val As Boolean
        Dim strOverrideExpDoc As String = MPSDB.DLookUp("TextValue", "tblConfig", "", "Code='OVERRIDE_EXPDOC'")
        val = CType(IIf(strOverrideExpDoc.Equals(""), "False", strOverrideExpDoc), Boolean)
        If val Then
            MsgBox("The Administrator has assigned a default configuration. Overriding of this setting is disabled.", vbInformation, GetAppName)

            RemoveHandler chkExpDocAlert.EditValueChanged, AddressOf chkExpDocAlert_EditValueChanged
            loadExpDocSetting()
            AddHandler chkExpDocAlert.EditValueChanged, AddressOf chkExpDocAlert_EditValueChanged
        End If
    End Sub

End Class