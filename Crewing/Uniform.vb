Public Class Uniform

#Region "Base Items"

    Dim LastUpdatedBy = ""
    Dim ActID As String = ""
    Dim tblAcivity As New DataTable
    Dim clsAudit As New clsAudit 'neil
    Dim TKey As Integer = 0

    Dim FormName As String = "Uniform Issuance"

    Dim AddFromTemplateSessionNo As Integer 'used to group garments added to be able to undo them if undo is clicked

    Private DEFAULT_ISSUE_TYPE As String = ""

    Private Const QUANTITY_MIN As Integer = 0
    Private Const QUANTITY_MAX As Integer = 100

    'Dim CurrentRow_Issueance As DataRow

    Dim TEMP_Issuance As DataTable
    Dim TEMP_IssuedUniform As DataTable

    Private IssuancePKey As String = ""
    Private isGridRequiredFieldsIncomplete As Boolean = False

    Private Sub initControls()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        LayoutControl1.AllowCustomization = False
        LayoutControl2.AllowCustomization = False

        'GARMENT REPOSITORY
        repGarment.DataSource = MPSDB.CreateTable("SELECT g.*, gt.name as GarmentType FROM dbo.tblAdmGarment g LEFT JOIN dbo.tblAdmGarmentType gt ON g.FKeyGarmentType = gt.PKey ORDER BY g.Name")

        'UNIFORM ISSUE TYPE
        repIssueType.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmuniformissuetype ORDER BY SortCode")
        Dim row() = TryCast(repIssueType.DataSource, DataTable).Select("PKey = 'SYSUNDEFINED'")
        If row.Length > 0 Then
            DEFAULT_ISSUE_TYPE = row(0)("PKey")
        End If

        'GARMENT TEMPLATE
        cboGarmentTemplate.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmgarmenttemplate ORDER BY Name")

        'GARMENT QUANTITY
        repQty.MinValue = QUANTITY_MIN
        repQty.MaxValue = QUANTITY_MAX

        EditSubAllowGrid(ActView, False)
        '============================================

        Try
            IssuanceView.Columns("DateIssue").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        Catch
            'do nothing
        End Try

        Try
            IssuanceView.Columns("IssuedBy").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        Catch
            'do nothing
        End Try

        Init_TEMP_Issuance()
        Init_TEMP_IssuedUniform()

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
    End Sub

    Sub Init_TEMP_Issuance()
        '============================================
        'TEMP_Issuance
        '============================================
        TEMP_Issuance = New DataTable
        Dim col As DataColumn
        col = New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "FKeyActID"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "DateIssue"
        col.DataType = System.Type.GetType("System.DateTime")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "IssuedBy"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Remarks"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "EyeColor"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "HairColor"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Height"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Weight"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "ShoeSize"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "DistinguishMarks1"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "DistinguishMarks2"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "DateUpdated"
        col.DataType = System.Type.GetType("System.DateTime")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "LastUpdatedBy"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "TKey"
        col.DataType = System.Type.GetType("System.String")
        TEMP_Issuance.Columns.Add(col)
    End Sub

    Sub Init_TEMP_IssuedUniform()
        '============================================
        'TEMP_IssuedUniform
        '============================================
        TEMP_IssuedUniform = New DataTable
        Dim col As DataColumn
        col = New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "FKeyUniformIssuance"
        col.DataType = System.Type.GetType("System.String")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "FKeyGarment"
        col.DataType = System.Type.GetType("System.String")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "FKeyIssueType"
        col.DataType = System.Type.GetType("System.String")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Quantity"
        col.DataType = System.Type.GetType("System.Int32")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "PreferredSize"
        col.DataType = System.Type.GetType("System.String")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "Remarks"
        col.DataType = System.Type.GetType("System.String")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "DateUpdated"
        col.DataType = System.Type.GetType("System.DateTime")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "LastUpdatedBy"
        col.DataType = System.Type.GetType("System.String")
        TEMP_IssuedUniform.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "TKey"
        col.DataType = System.Type.GetType("System.String")
        TEMP_IssuedUniform.Columns.Add(col)
    End Sub

    Function GetLayoutControlGroups() As DevExpress.XtraLayout.LayoutControlGroup()
        Return New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl2.Root, LayoutControlGroup_PhysicalChars, LayoutControlGroup_Uniform, LayoutControlGroup_IssueDetails}
    End Function

    Private Sub LoadSub()
        Dim nRow As Integer = -1
        With ActView
            If .RowCount > 0 Then
                nRow = 0
            End If

            Dim filter As String = IIf(CONTENTTYPE = "ONB", " AND ActivityType='SEA' ", "")

            tblAcivity = DB.CreateTable("SELECT *, ar.Name as WSRank FROM dbo.Crewlist_Activities_All caa LEFT OUTER JOIN tblAdmWscaleRank wsr ON caa.FKeyWScaleRankCode = wsr.PKey LEFT OUTER JOIN tblAdmRank ar ON wsr.FKeyRank = ar.PKey WHERE IDNbr='" & strID & "' " & filter & " ORDER BY rn")
            ActGrid.DataSource = tblAcivity
            If .RowCount > 0 Then
                .FocusedRowHandle = nRow
                .SelectRow(nRow)
            End If
        End With

        LoadUniformInfo()
        LoadUniformInfoDetails(IfNull(IssuanceView.GetFocusedRowCellValue("TKey"), ""))
    End Sub

    'refresh
    Public Overrides Sub RefreshData()
        TableName = "tblUniform"
        MyBase.RefreshData()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'Hide Add button
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'Hide Delete Sub Button
        RemoveEditListener(GetLayoutControlGroups())
        TKey = 0

        SetEditCaption(Name, "Add/Edit")
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            'commented out by tony20190716 : adding must be disabled if blList (crew list) does not have any record
            'AddData()
            AllowEditing(Name, False)
            AllowDeletion(Name, False)
        Else
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            MakeReadOnlyListener(Me.LayoutControl2.Root)
            AllowDeletion(Name, False)
            BRECORDUPDATEDs = False
        End If

        ShowUndoAddedGarmentsFromTemplate(False)
        isGridRequiredFieldsIncomplete = False
    End Sub

    'Edit/Add
    Public Overrides Sub EditData()
        MyBase.EditData()
        header.Focus()
        If isEditdable Then
            AddEditListener(GetLayoutControlGroups())
            RemoveReadOnlyListener(LayoutControl2.Root)
        Else
            RemoveEditListener(GetLayoutControlGroups())
            ResetControlOnEdit()
            MakeReadOnlyListener(LayoutControl2.Root)
        End If

        EditSubAllowGrid(Me.GridUniformView, isEditdable)
        EditSubAllowGrid(Me.IssuanceView, isEditdable)

        LayoutControlGroup_IssueDetails.Enabled = IIf(isEditdable, IssuanceView.FocusedRowHandle >= 0, True)
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim query As New ArrayList
        Dim info As Boolean = False

        Dim dt As DataTable = TryCast(GridUniform.DataSource, DataTable)

        SaveLastEditedToFloating(IssuanceView.GetFocusedRowCellValue("TKey"))

        If Not IssuanceView.HasColumnErrors And Not GridUniformView.HasColumnErrors And (Not IfNull(ActID, "").Equals("")) Then

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'SAVE UNIFORM ISSUANCE
            Dim cAuditDesc As String = ConcatWithSpaces(New Object() {"Uniform for service under [" & ActView.GetFocusedRowCellDisplayText("Vessel").ToString.Replace("'", "''") & "] on date [" & ActView.GetFocusedRowCellDisplayText("DateStarted").ToString.Replace("'", "''")})

            'SETUP TEMP TABLES TO BE PASSED AS TABLE PARAMETERS TO STORED PROCEDURE
            TEMP_Issuance.Rows.Clear()
            TEMP_IssuedUniform.Rows.Clear()

            'INSERT ISSUANCE INFORMATION ON TEMP_Issuance VARIABLE WHICH WILL BE USED IN THE STORED PROCEDURE
            For Each row As DataRow In TryCast(IssuanceGrid.DataSource, DataTable).Select("Edited <> 0")
                Dim newRow = TEMP_Issuance.NewRow
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Uniform Issuance", 0, System.Environment.MachineName, cAuditDesc, "Uniform Issuance", strID)
                newRow.ItemArray = New Object() {row("PKey"), _
                                                 row("FKeyActID"), _
                                                 row("DateIssue"), _
                                                 row("IssuedBy"), _
                                                 row("Remarks"), _
                                                 row("EyeColor"), _
                                                 row("HairColor"), _
                                                 row("Height"), _
                                                 row("Weight"), _
                                                 row("ShoeSize"), _
                                                 row("DistinguishMarks1"), _
                                                 row("DistinguishMarks2"), _
                                                 System.DateTime.Now, _
                                                 LastUpdatedBy, _
                                                 row("TKey")}

                TEMP_Issuance.Rows.Add(newRow)
            Next

            'INSERT ISSUED UNIFORM INFORMATION ON TEMP_IssuedUniform VARIABLE WHICH WILL BE USED IN THE STORED PROCEDURE
            For Each row As DataRow In TryCast(GridUniform.DataSource, DataTable).Select("Edited <> 0")
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Issued Uniform", 0, System.Environment.MachineName, cAuditDesc, "Uniform Issuance", strID)
                Dim newRow = TEMP_IssuedUniform.NewRow
                newRow.ItemArray = New Object() {row("PKey"), _
                                                 row("FKeyUniformIssuance"), _
                                                 row("FKeyGarment"), _
                                                 row("FKeyIssueType"), _
                                                 row("Quantity"), _
                                                 row("PreferredSize"), _
                                                 row("Remarks"), _
                                                 System.DateTime.Now, _
                                                 LastUpdatedBy, _
                                                 row("TKey")}

                TEMP_IssuedUniform.Rows.Add(newRow)
            Next

            'START SAVING
            Dim sqlConn As New SqlClient.SqlConnection(MPSDB.GetConnectionString)
            Dim tran As SqlClient.SqlTransaction = Nothing
            info = False
            Try
                sqlConn.Open()
                tran = sqlConn.BeginTransaction()
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.CommandText = "SaveData_UniformIssuance"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Transaction = tran
                    With cmd.Parameters
                        .AddWithValue("@NewUniformIssuance", TEMP_Issuance)
                        .AddWithValue("@NewIssuedUniform", TEMP_IssuedUniform)
                    End With

                    info = cmd.ExecuteNonQuery()

                End Using

                If info Then
                    tran.Commit()
                    BRECORDUPDATEDs = False
                    blList.SetSelection(strID)
                    RefreshData()
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                End If
            Catch ex As Exception
                tran.Rollback()
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
            Finally
                sqlConn.Close()
            End Try

        Else
            MsgBox(GetMessage("SUB"), MsgBoxStyle.Critical, GetAppName())
        End If
    End Sub

    'CheckValidate
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            SaveData()
            flag = True
            ALLOWNEXTS = True
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    'Delete
    Public Overrides Sub DeleteData()
        If IsNothing(focusedView) Then
            'DeleteMain()
        Else
            DeleteSubTable()
        End If
    End Sub

    Private Sub DeleteSubTable()
        With focusedView
            Select Case focusedView.Name
                Case GridUniformView.Name
                    DeleteSubTable_IssuedUniform()

                Case IssuanceView.Name
                    DeleteSubTable_Issuance()

            End Select

        End With

    End Sub

    Private Sub DeleteSubTable_Issuance()
        Dim info As Boolean

        With focusedView

            If MsgBox("Are you sure want to delete record with date issue: '" & .GetRowCellDisplayText(.FocusedRowHandle, "DateIssue") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                Dim TKey As String = .GetRowCellValue(.FocusedRowHandle, "TKey")    'If record exists, TKey is same with PKey
                If Not .GetRowCellValue(.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                    If Not Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")).Equals("") Then

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Uniform Issuance", 0, System.Environment.MachineName,
                                                    "date issue: " & .GetRowCellDisplayText(.FocusedRowHandle, "DateIssue"), FormName, strID) 'neil
                        clsAudit.saveAuditPreDelDetails("tbluniformIssuance", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tbluniformIssuance", _
                            "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                            "<< Delete Crew Data - " & FormName & " >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & ">", _
                            GetUserName())
                        '-->

                        info = DB.RunSql("DELETE dbo.tbluniformIssuance WHERE PKey ='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                        If info Then
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If
                    End If
                End If

                .DeleteRow(.FocusedRowHandle)
                If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
            End If
        End With
    End Sub

    Private Sub DeleteSubTable_IssuedUniform()
        Dim info As Boolean

        With focusedView

            If MsgBox("Are you sure want to delete '" & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyGarment") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                'Delete Per Record
                Dim TKey As String = .GetRowCellValue(.FocusedRowHandle, "TKey")
                If Not .GetRowCellValue(.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                    If Not Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")).Equals("") Then

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Uniform Issuance", 0, System.Environment.MachineName, strDesc & _
                                                          " - " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyGarment"), FormName, strID) 'neil
                        clsAudit.saveAuditPreDelDetails("tbluniform", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tbluniform", _
                            "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                            "<< Delete Crew Data - " & FormName & " - Uniform >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & " - Uniform>", _
                            GetUserName())
                        '-->

                        info = DB.RunSql("DELETE dbo.tbluniform WHERE PKey ='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                        If info Then
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If
                    End If
                End If

                .DeleteRow(.FocusedRowHandle)
                If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
            End If
        End With
    End Sub

#End Region

#Region "Base Functions"

    'Get the Latest SEA Activity
    Private Function getLatestSEAActGrpID() As String
        Dim RetVal As String = ""
        Dim SeaAct As New DataTable
        If tblAcivity.Rows.Count > 0 Then
            SeaAct = tblAcivity.Select("ActivityType = 'SEA' OR ActivityType = 'sea'").CopyToDataTable
            '    Dim dr As DataRow = SeaAct.Rows(0)
            RetVal = SeaAct.Rows(0).Item("ActGrpID").ToString
        End If

        Return RetVal
    End Function

#End Region

#Region "Crew Activity"

    Private Sub ActView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles ActView.BeforeLeaveRow
        If BRECORDUPDATEDs Then
            If Not CheckValidateFields() Then
                e.Allow = ALLOWNEXTS
            Else
                e.Allow = True
            End If
        Else
            e.Allow = True
        End If
    End Sub

    Private Sub ActView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ActView.FocusedRowChanged
        LoadUniformInfo()
    End Sub

    'get Code
    Private Sub GetActivityCode()
        With ActView
            ActID = IfNull(.GetRowCellValue(.FocusedRowHandle, "ActID"), "")
        End With
    End Sub

    Private Sub ActView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ActView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#Region "Uniform"
    Sub LoadUniformInfo()
        GetActivityCode()

        RemoveReadOnlyListener(GetLayoutControlGroups())

        'FOR SUB GRID
        EditSubAllowGrid(Me.GridUniformView, False)

        'CLEAR FIELDS
        ClearFields(GetLayoutControlGroups(), False)

        'LOAD PHYSICAL CHARACTERISTICS DETAILS
        IssuanceGrid.DataSource = MPSDB.CreateTable("SELECT cast(0 as bit) Edited, PKey as TKey, * FROM dbo.tbluniformissuance WHERE FKeyActID = '" & ActID & "'")

        GridUniform.DataSource = MPSDB.CreateTable("SELECT cast(0 as bit) Edited, u.*, 0 as AddTemplateSessionNo, FKeyUniformIssuance as TKey, ui.FKeyActID FROM dbo.tbluniform u INNER JOIN dbo.tblUniformIssuance ui ON u.FKeyUniformIssuance = ui.PKey WHERE ui.FKeyActID = '" & ActID & "'")

        MakeReadOnlyListener(GetLayoutControlGroups())

    End Sub

    Sub LoadUniformInfoDetails(TKey As String)
        With IssuanceView
            Dim drow() As DataRow = TryCast(IssuanceGrid.DataSource, DataTable).Select("TKey = '" & TKey & "'")
            ClearFields(LayoutControlGroup_PhysicalChars, False)
            'CurrentRow_Issueance = Nothing
            'If drow.Count > 0 Then
            '    CurrentRow_Issueance = drow(0)
            '    Dim dt As DataTable = TryCast(IssuanceGrid.DataSource, DataTable)
            '    Me.txtEyeColor.Text = IfNull(CurrentRow_Issueance("EyeColor"), "")
            '    Me.txtHairColor.Text = IfNull(CurrentRow_Issueance("HairColor"), "")
            '    Me.txtHeight.Text = IfNull(CurrentRow_Issueance("Height"), "")
            '    Me.txtWeight.Text = IfNull(CurrentRow_Issueance("Weight"), "")
            '    Me.txtShoeSize.Text = IfNull(CurrentRow_Issueance("ShoeSize"), "")
            '    Me.txtDistinguishMarks1.Text = IfNull(CurrentRow_Issueance("DistinguishMarks1"), "")
            '    Me.txtDistinguishMarks2.Text = IfNull(CurrentRow_Issueance("DistinguishMarks2"), "")
            'Else
            '    CurrentRow_Issueance = TryCast(IssuanceGrid.DataSource, DataTable).NewRow
            '    CurrentRow_Issueance("TKey") = TKey
            '    TryCast(IssuanceGrid.DataSource, DataTable).Rows.Add(CurrentRow_Issueance)
            'End If

            If drow.Count > 0 Then
                Dim dt As DataTable = TryCast(IssuanceGrid.DataSource, DataTable)
                Me.txtEyeColor.Text = IfNull(drow(0)("EyeColor"), "")
                Me.txtHairColor.Text = IfNull(drow(0)("HairColor"), "")
                Me.txtHeight.Text = IfNull(drow(0)("Height"), "")
                Me.txtWeight.Text = IfNull(drow(0)("Weight"), "")
                Me.txtShoeSize.Text = IfNull(drow(0)("ShoeSize"), "")
                Me.txtDistinguishMarks1.Text = IfNull(drow(0)("DistinguishMarks1"), "")
                Me.txtDistinguishMarks2.Text = IfNull(drow(0)("DistinguishMarks2"), "")
            End If

            ClearFields(GetLayoutControlGroups(), True) 'FORMAT ONLY

            'FILTER UNIFORM GRID BASED ON SELECTED ISSUANCE INFO
            GridUniformView.ActiveFilter.Clear()
            UpdateUniformActiveFilterString(ActID, IfNull(.GetFocusedRowCellValue("TKey"), ""))
        End With
    End Sub
#End Region

    Private Sub UpdateUniformActiveFilterString(_ActID As String, _TKey As String)
        Try
            GridUniformView.ActiveFilterString = "FKeyActID = '" & _ActID & "' AND TKey = '" & _TKey & "'"
        Catch
        End Try
    End Sub

    Private Sub ResetControlOnEdit()
        ResetGridViewEdits(New DevExpress.XtraGrid.Views.Grid.GridView() {GridUniformView})
        RefreshData()
    End Sub

    Private Sub GridUniformView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridUniformView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.GridUniformView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub GridUniformView_GotFocus(sender As Object, e As System.EventArgs) Handles GridUniformView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Uniform")
        Else
            focusedView = Nothing
            AllowDeletion(Name, False)
            SetDeleteCaption(Name, "Delete")
        End If
    End Sub

    Private Sub GridUniformView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridUniformView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyUniformIssuance"), IssuanceView.GetFocusedRowCellValue("PKey"))
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyIssueType"), DEFAULT_ISSUE_TYPE)
        View.SetRowCellValue(e.RowHandle, View.Columns("AddTemplateSessionNo"), 0)
        View.SetRowCellValue(e.RowHandle, View.Columns("Quantity"), 0)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyActID"), ActID)
        View.SetRowCellValue(e.RowHandle, View.Columns("TKey"), IssuanceView.GetFocusedRowCellValue("TKey"))
        SubAddMode = True
    End Sub

    Private Sub GridUniformView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles GridUniformView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub GridUniformView_LostFocus(sender As Object, e As System.EventArgs) Handles GridUniformView.LostFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        focusedView = Nothing
        AllowDeletion(Name, False)
        SetDeleteCaption(Name, "Delete")
    End Sub

    Private Sub GridUniformView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridUniformView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'If GridUniformView.GetRowCellValue(e.RowHandle, "Edited") Then
        '    If GridUniformView.IsRowSelected(e.RowHandle) And e.Column.Tag = "Required" Then
        '        If IfNull(e.CellValue, "").Equals("") Then
        '            e.Appearance.BackColor = REQUIRED_SELECTED_COLOR
        '            'If isGridRequiredFieldsIncomplete Then

        '            'End If
        '            GridUniformView.SetColumnError(e.Column, "Required field must not be blank.")
        '        Else
        '            'If isGridRequiredFieldsIncomplete Then

        '            'End If
        '            GridUniformView.SetColumnError(e.Column, "")
        '        End If
        '    ElseIf GridUniformView.IsRowSelected(e.RowHandle) Then
        '        e.Appearance.BackColor = SEL_COLOR
        '        e.Appearance.ForeColor = System.Drawing.Color.Black
        '    Else
        '        If e.Column.Tag = "Required" Then
        '            If IfNull(e.CellValue, "").Equals("") Then
        '                e.Appearance.BackColor = REQUIRED_COLOR
        '                'If isGridRequiredFieldsIncomplete Then

        '                'End If
        '                GridUniformView.SetColumnError(e.Column, "Required field must not be blank.")
        '            Else
        '                'If isGridRequiredFieldsIncomplete Then

        '                'End If
        '                GridUniformView.SetColumnError(e.Column, "")
        '            End If
        '        End If
        '    End If
        'End If

        If view.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") And view.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = view.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If

    End Sub

    Private Sub GridUniformView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridUniformView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub cboGarmentTemplate_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboGarmentTemplate.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus And isEditdable Then
            If IfNull(cboGarmentTemplate.EditValue, "").Equals("") Then Exit Sub

            If MsgBox("Do you want to add garments from Uniform Template [" & cboGarmentTemplate.Text & "]?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            AddGarmentsFromTemplate()

        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Undo And isEditdable Then

            If MsgBox("Do you want to undo last added garments from template?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            UndoAddedGarmentsFromTemplate()

        End If

    End Sub

    Private Sub AddGarmentsFromTemplate()
        Dim dtGarments As DataTable = DB.CreateTable("SELECT gitem.* FROM dbo.tblAdmGarmentTemplateItem gitem INNER JOIN dbo.tbladmgarment g ON gitem.FKeyGarment = g.PKey WHERE gitem.FKeyGarmentTemplate = '" & IfNull(cboGarmentTemplate.EditValue, "") & "' ORDER BY gitem.Sortcode, g.Name")
        Dim _garments As DataTable = TryCast(GridUniform.DataSource, DataTable)
        Dim newrow As DataRow

        AddFromTemplateSessionNo = AddFromTemplateSessionNo + 1 'used for undo

        For Each row As DataRow In dtGarments.Rows
            newrow = _garments.NewRow
            newrow("Edited") = True
            newrow("FKeyUniformIssuance") = IssuancePKey
            newrow("FKeyGarment") = row("FKeyGarment")
            newrow("FKeyIssueType") = DEFAULT_ISSUE_TYPE
            newrow("Quantity") = 0
            newrow("AddTemplateSessionNo") = AddFromTemplateSessionNo

            _garments.Rows.Add(newrow)

        Next

        GridUniform.DataSource = _garments
        cboGarmentTemplate.EditValue = Nothing
        ShowUndoAddedGarmentsFromTemplate(True)
    End Sub

    Private Sub UndoAddedGarmentsFromTemplate()
        Dim _garments As DataTable = TryCast(GridUniform.DataSource, DataTable)
        Dim rowstodelete As New List(Of DataRow)

        For Each row As DataRow In _garments.Rows
            If row("AddTemplateSessionNo") = AddFromTemplateSessionNo Then
                'row.Delete()
                rowstodelete.Add(row)
            End If
        Next

        For Each row As DataRow In rowstodelete
            row.Delete()
        Next

        GridUniform.DataSource = _garments
        ShowUndoAddedGarmentsFromTemplate(False)
    End Sub

    Private Sub ShowUndoAddedGarmentsFromTemplate(isShow As Boolean)
        Try
            cboGarmentTemplate.Properties.Buttons(2).Visible = isShow
        Catch ex As Exception
            LogErrors("Failed to set visible = " & isShow & " for button index 2")
        End Try
    End Sub

    Private Sub repGarment_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repGarment.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
            Dim PhotoPath As String = ""

            If Not IsNothing(row) Then
                If Not IfNull(row("PhotoPath"), "").Equals("") Then PhotoPath = GetGarmentPhotoPath(row("PKey"), row("PhotoPath"))
            End If

            If Not IfNull(PhotoPath, "").Equals("") Then
                Dim f As New frmImagePreview(PhotoPath, row("Name"))
                f.ShowDialog()
            Else
                MsgBox("Preview not available", MsgBoxStyle.Information)
            End If

        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            GridUniformView.SetFocusedRowCellValue("FKeyGarment", Nothing)
        End If
    End Sub

    Private Sub cboGarmentTemplate_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboGarmentTemplate.EditValueChanged
        ShowUndoAddedGarmentsFromTemplate(False)
    End Sub

    Private Sub IssuanceView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles IssuanceView.BeforeLeaveRow
        SaveLastEditedToFloating(IssuanceView.GetRowCellValue(e.RowHandle, "TKey"))
    End Sub

    Private Sub SaveLastEditedToFloating(_TKey As String)
        If isEditdable Then
            Dim ctlList As Object() = New Object() {txtEyeColor, txtHairColor, txtHeight, txtWeight, txtShoeSize, txtDistinguishMarks1, txtDistinguishMarks2}

            Dim drow() As DataRow = TryCast(IssuanceGrid.DataSource, DataTable).Select("TKey = '" & _TKey & "'")

            If drow.Count > 0 Then
                Dim txtEdit As DevExpress.XtraEditors.TextEdit
                For i As Integer = 0 To ctlList.Count - 1
                    Try
                        txtEdit = TryCast(ctlList(i), DevExpress.XtraEditors.TextEdit)
                        If Not IsNothing(drow(0)(Mid(txtEdit.Name, 4))) Then
                            If IfNull(drow(0)(Mid(txtEdit.Name, 4)), "") <> txtEdit.Text Then
                                drow(0)("Edited") = True
                            End If
                            drow(0)(Mid(txtEdit.Name, 4)) = txtEdit.Text
                        End If
                    Catch ex As Exception

                    End Try
                Next

            End If

            Dim dt As DataTable = TryCast(IssuanceGrid.DataSource, DataTable)
        End If
    End Sub

    Private Sub IssuanceView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles IssuanceView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                'Marks Actitive the Document if newly Added
                .SetRowCellValue(e.RowHandle, "Edited", True)
                CheckIfEnableUniformView(e.RowHandle)
            End If
        End With
    End Sub

    Private Sub CheckIfEnableUniformView(rowhandle As Integer)
        Dim RequiredFieldsCompleted As Boolean = True
        With IssuanceView
            For i As Integer = 0 To .Columns.Count - 1
                If .Columns(i).FieldName.ToString <> "Edited" And .Columns(i).Tag = "Required" Then
                    If IfNull(.GetRowCellValue(rowhandle, .Columns(i).FieldName.ToString), "").Equals("") Then
                        RequiredFieldsCompleted = False
                    End If
                End If
            Next
        End With

        LayoutControlGroup_IssueDetails.Enabled = RequiredFieldsCompleted

    End Sub

    Private Sub IssuanceView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles IssuanceView.FocusedRowChanged
        'LoadUniformInfoDetails(IfNull(IssuanceView.GetFocusedRowCellValue("TKey"), ""))
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        LayoutControlGroup_IssueDetails.Enabled = IIf(isEditdable, view.FocusedRowHandle >= 0, True)
        EditSubAllowGrid(Me.GridUniformView, IIf(isEditdable, view.FocusedRowHandle >= 0, True))
    End Sub

    Private Sub IssuanceView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles IssuanceView.FocusedRowObjectChanged
        LoadUniformInfoDetails(IfNull(IssuanceView.GetFocusedRowCellValue("TKey"), ""))
    End Sub

    Private Sub IssuanceView_GotFocus(sender As Object, e As System.EventArgs) Handles IssuanceView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Issuance")
        Else
            focusedView = Nothing
            AllowDeletion(Name, False)
            SetDeleteCaption(Name, "Delete")
        End If
    End Sub

    Private Sub IssuanceView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles IssuanceView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        TKey = TKey + 1

        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("TKey"), TKey)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyActID"), ActID)
        ClearFields(GetLayoutControlGroups(), False)

        LoadUniformInfoDetails(TKey)
    End Sub

    Private Sub IssuanceView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles IssuanceView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub IssuanceView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles IssuanceView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'If view.IsRowSelected(e.RowHandle) And e.Column.Tag = "Required" And Not IfNull(view.GetRowCellValue(e.RowHandle, "TKey"), "").Equals("") Then
        '    If IfNull(e.CellValue, "").Equals("") Then
        '        e.Appearance.BackColor = REQUIRED_SELECTED_COLOR
        '        'If isGridRequiredFieldsIncomplete Then Mainview.SetColumnError(e.Column, "Required field must not be blank.")
        '        view.SetColumnError(e.Column, "Required field must not be blank.")
        '    Else
        '        'If isGridRequiredFieldsIncomplete Then Mainview.SetColumnError(e.Column, "")
        '        view.SetColumnError(e.Column, "")
        '    End If
        'ElseIf view.IsRowSelected(e.RowHandle) Then
        '    e.Appearance.BackColor = SEL_COLOR
        '    e.Appearance.ForeColor = System.Drawing.Color.Black
        'Else
        '    If Not IfNull(view.GetRowCellValue(e.RowHandle, "TKey"), "").Equals("") Then
        '        If e.Column.Tag = "Required" Then
        '            If IfNull(e.CellValue, "").Equals("") Then
        '                e.Appearance.BackColor = REQUIRED_COLOR
        '                'If isGridRequiredFieldsIncomplete Then Mainview.SetColumnError(e.Column, "Required field must not be blank.")
        '                view.SetColumnError(e.Column, "Required field must not be blank.")
        '            Else
        '                'If isGridRequiredFieldsIncomplete Then Mainview.SetColumnError(e.Column, "")
        '                view.SetColumnError(e.Column, "")
        '            End If
        '        End If
        '    End If

        'End If

        If view.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") And view.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = view.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If

    End Sub

    Private Sub IssuanceView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles IssuanceView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub IssuanceView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles IssuanceView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim DateIssue As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateIssue")

        With view
            'Validate DateIssue
            If .GetRowCellValue(e.RowHandle, DateIssue) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, DateIssue) Is Nothing Then
                .SetColumnError(DateIssue, "Please Enter Issued Date.")
                e.Valid = False
            Else
                .SetColumnError(DateIssue, "")
            End If
        End With
    End Sub

    Private Sub GridUniformView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridUniformView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FKeyGarment As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyGarment")
        Dim FKeyIssueType As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyIssueType")
        Dim Quantity As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Quantity")

        With view
            'Validate Garment Type
            If .GetRowCellValue(e.RowHandle, FKeyGarment) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyGarment) Is Nothing Then
                .SetColumnError(FKeyGarment, "Please Select Garment Type.")
                e.Valid = False
            Else
                .SetColumnError(FKeyGarment, "")
            End If

            'Validate Issue Type
            If .GetRowCellValue(e.RowHandle, FKeyIssueType) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyIssueType) Is Nothing Then
                .SetColumnError(FKeyIssueType, "Please Select Issue Type.")
                e.Valid = False
            Else
                .SetColumnError(FKeyIssueType, "")
            End If

            'Validate Quantity
            If .GetRowCellValue(e.RowHandle, Quantity) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Quantity) Is Nothing Then
                .SetColumnError(Quantity, "Please Enter Quantity.")
                e.Valid = False
            Else
                .SetColumnError(Quantity, "")
            End If
        End With
    End Sub
End Class
