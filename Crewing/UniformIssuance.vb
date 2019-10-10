Imports DevExpress.XtraEditors.Controls

Public Class UniformIssuance

#Region "Declarations"
    Dim LastUpdatedBy = ""
    Dim ActID As String = ""
    Dim tblAcivity As New DataTable
    Dim clsAudit As New clsAudit 'neil
    Dim TKey As Integer = 0

    Dim FormName As String = "Uniform Issuance"

    Dim AddFromTemplateSessionNo As Integer 'used to group garments added to be able to undo them if undo is clicked

    Private DEFAULT_ISSUE_TYPE As String = ""

    Private Const QUANTITY_MIN As Integer = 1
    Private Const QUANTITY_MAX As Integer = 100

    Private SubGridIDNbr As String = ""

    Private Structure InUseLabel
        Const InUse = "Currently In Use"
        Const NotInUse = "Not In Use"
    End Structure

    Private Enum RowCellStyle
        Normal = 0
        NeedReIssue = 1
        DoNotNeedReIssue = 2
        AddedFromTemplate = 3
    End Enum

    Private Enum AddGarmentsFromTemplateButton
        Add = 1
        Undo = 2
    End Enum

#End Region

#Region "Properties"
    Private ReadOnly Property GetLayoutControlGroups As DevExpress.XtraLayout.LayoutControlGroup()
        Get
            Return New DevExpress.XtraLayout.LayoutControlGroup() {Me.LayoutControl1.Root}
        End Get
    End Property

#End Region

    'refresh
    Public Overrides Sub RefreshData()
        TableName = "tblUniformIssuance"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Uniform Issuance - " & strDesc)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'Hide Add button
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'Hide Delete Sub Button
        RemoveEditListener(GetLayoutControlGroups)
        AllowDeletion(Name, False)
        ShowAddGarmentsFromTemplateButton(AddGarmentsFromTemplateButton.Add, False)
        ShowAddGarmentsFromTemplateButton(AddGarmentsFromTemplateButton.Undo, False)

        SetEditCaption(Name, "Add/Edit")
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            'commented out by tony20190716 : adding must be disabled if blList (crew list) does not have any record
            'AddData()
            AllowEditing(Name, False)
        Else
            LoadSub()
            MakeReadOnlyListener(GetLayoutControlGroups)
            BRECORDUPDATEDs = False

        End If

        SizeInformationLabel.ForeColor = System.Drawing.Color.Firebrick
        SetReadOnlySizeInfoFields()
    End Sub

    Private Sub SetReadOnlySizeInfoFields()
        '<!-- added by tony20171125
        RemoveEditListener(txtShoeSize, False)
        RemoveEditListener(txtCoverallSize, False)
        RemoveEditListener(txtPoloSize, False)
        RemoveEditListener(txtPantsSize, False)

        'MakeReadOnlyListener(txtShoeSize)
        'MakeReadOnlyListener(txtCoverallSize)
        'MakeReadOnlyListener(txtPoloSize)
        'MakeReadOnlyListener(txtPantsSize)
        txtShoeSize.ReadOnly = True
        txtCoverallSize.ReadOnly = True
        txtPoloSize.ReadOnly = True
        txtPantsSize.ReadOnly = True
        '-->
    End Sub

    Private Sub initControls()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        LayoutControl1.AllowCustomization = False

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
        '============================================

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil

    End Sub

    Private Sub LoadSub()
        RemoveReadOnlyListener(GetLayoutControlGroups())

        'FOR SUB GRID
        EditSubAllowGrid(Me.MainView, False)

        'CLEAR FIELDS
        ClearFields(GetLayoutControlGroups(), False)

        'LOAD SEA SERVICE SELECTION
        'If SubGridIDNbr <> strID Then
        'edited by tony20180627 - repSS.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.view_SeaServiceSelection WHERE FKeyIDNbr = " & ChangeToSQLString(strID) & " ORDER BY seq desc")
        repSS.DataSource = MPSDB.CreateTable("EXEC dbo.GenerateSeaServSelection " & ChangeToSQLString(strID))
        SubGridIDNbr = strID
        'End If

        'LOAD UNIFORM ISSUANCE DETAILS
        MainGrid.DataSource = MPSDB.CreateTable("SELECT cast(0 as bit) Edited, CASE WHEN u.InUse <> 0 THEN '" & InUseLabel.InUse & "' ELSE '" & InUseLabel.NotInUse & "' ENd InUseLabel, dbo.isUniformReissue(u.FKeyGarment, u.InUse, u.DateIssue, u.FKeyIDNbr, u.FKeyActID) NeedReIssue, u.*, 0 as AddTemplateSessionNo FROM dbo.tbluniformissuance u LEFT JOIN dbo.tblAdmGarment g ON u.FKeyGarment = g.PKey WHERE FKeyIDNbr = '" & strID & "' ORDER BY g.Name")

        '<!-- added by tony20171125
        'LOAD SIZE INFORMATION DETAILS
        Dim dtSizes As DataTable = MPSDB.CreateTable("SELECT ShoeSize, CoverallSize, PoloSize, PantsSize FROM dbo.tblcrewinfo WHERE PKey = '" & strID & "'")
        If dtSizes.Rows.Count > 0 Then
            With dtSizes.Rows(0)
                Me.txtShoeSize.Text = Trim(IfNull(.Item("ShoeSize"), ""))
                Me.txtCoverallSize.Text = Trim(IfNull(.Item("CoverallSize"), ""))
                Me.txtPoloSize.Text = Trim(IfNull(.Item("PoloSize"), ""))
                Me.txtPantsSize.Text = Trim(IfNull(.Item("PantsSize"), ""))
            End With
        Else
            Me.txtShoeSize.Text = ""
            Me.txtCoverallSize.Text = ""
            Me.txtPoloSize.Text = ""
            Me.txtPantsSize.Text = ""
        End If
        '-->

        MainView.Columns("InUseLabel").Group()
        MainView.ExpandAllGroups()

        MakeReadOnlyListener(GetLayoutControlGroups())

    End Sub

    'Edit/Add
    Public Overrides Sub EditData()
        MyBase.EditData()
        header.Focus()
        If isEditdable Then
            AllowDeletion(Name, True)
            AddEditListener(GetLayoutControlGroups())
            RemoveReadOnlyListener(GetLayoutControlGroups())
            RemoveEditListener(cboGarmentTemplate, False)
            ShowAddGarmentsFromTemplateButton(AddGarmentsFromTemplateButton.Add, True)
        Else
            AllowDeletion(Name, False)
            RemoveEditListener(GetLayoutControlGroups())
            MakeReadOnlyListener(GetLayoutControlGroups())
            ShowAddGarmentsFromTemplateButton(AddGarmentsFromTemplateButton.Add, False)
        End If

        EditSubAllowGrid(Me.MainView, isEditdable)
        SetReadOnlySizeInfoFields()
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean

        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If MainView.HasColumnErrors Then
                flag = False
                ALLOWNEXTS = flag
            Else
                flag = True
                ALLOWNEXTS = flag
                SaveData() '
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If


        Return flag
    End Function

    Private Sub repGarmentType_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repGarment.ButtonClick
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
            MainView.SetFocusedRowCellValue("FKeyGarment", Nothing)
        End If
    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view

            Dim cFieldName As String = e.Column.FieldName.ToString

            If cFieldName <> "Edited" Then
                'Marks Actitive the Document if newly Added
                .SetRowCellValue(e.RowHandle, "Edited", True)

                If cFieldName = "InUse" Then
                    If .GetRowCellValue(e.RowHandle, "InUse") <> 0 Then
                        .SetRowCellValue(e.RowHandle, "InUseLabel", InUseLabel.InUse)
                    Else
                        .SetRowCellValue(e.RowHandle, "InUseLabel", InUseLabel.NotInUse)
                    End If
                End If

            End If
        End With
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Dim query As New ArrayList
        'MyBase.SaveData()
        Me.header.Focus()

        Dim info As Boolean = False

        If ((Not HasError) And (Not Me.MainView.HasColumnErrors)) Then
            info = SaveUniform()
        End If

        If info Then
            BRECORDUPDATEDs = False
            blList.SetSelection(strID)
            RefreshData()
            MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
        End If

    End Sub

    Private Function SaveUniform() As Boolean
        Dim query As New ArrayList
        Dim cSQL As String = ""
        With Me.MainView
            .CloseEditForm()
            .UpdateCurrentRow()

            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Uniform Issuance", 0, System.Environment.MachineName, .GetRowCellDisplayText(i, "FKeyGarment").ToString.Replace("'", "''") & " / " & .GetRowCellValue(i, "Quantity").ToString, FormName, strID)

                    If IfNull(.GetRowCellValue(i, "PKey"), "").Equals("") Then
                        'Use insert query
                        cSQL = "INSERT INTO dbo.tblUniformIssuance " & _
                                  "(" & _
                                  "FKeyIDNbr, " & _
                                  "FKeyGarment, " & _
                                  "FKeyIssueType, " & _
                                  "InUse, " & _
                                  "Quantity, " & _
                                  "PreferredSize, " & _
                                  "DateIssue, " & _
                                  "IssuedBy, " & _
                                  "FKeyActID, " & _
                                  "Remarks, " & _
                                  "LastUpdatedBy) " & _
                                  "VALUES ( " & _
                                  "'" & strID & "'," & _
                                  ChangeToSQLString(.GetRowCellValue(i, "FKeyGarment")) & ", " & _
                                  ChangeToSQLString(.GetRowCellValue(i, "FKeyIssueType")) & ", " & _
                                  Convert.ToInt32(.GetRowCellValue(i, "InUse")) & ", " & _
                                  Convert.ToInt32(.GetRowCellValue(i, "Quantity")) & ", " & _
                                  ChangeToSQLString(.GetRowCellValue(i, "PreferredSize")) & ", " & _
                                  ChangeToSQLDate(.GetRowCellValue(i, "DateIssue")) & ", " & _
                                  ChangeToSQLString(.GetRowCellValue(i, "IssuedBy")) & ", " & _
                                  ChangeToSQLString(.GetRowCellValue(i, "FKeyActID")) & ", " & _
                                  ChangeToSQLString(.GetRowCellValue(i, "Remarks")) & ", " & _
                                  "'" & LastUpdatedBy & "')"
                        query.Add(cSQL)
                    Else
                        'Use Update query
                        cSQL = "UPDATE dbo.tblUniformIssuance SET " & _
                                  "FKeyGarment = " & ChangeToSQLString(.GetRowCellValue(i, "FKeyGarment")) & ", " & _
                                  "FKeyIssueType = " & ChangeToSQLString(.GetRowCellValue(i, "FKeyIssueType")) & ", " & _
                                  "InUse = " & Convert.ToInt32(.GetRowCellValue(i, "InUse")) & ", " & _
                                  "Quantity = " & Convert.ToInt32(.GetRowCellValue(i, "Quantity")) & ", " & _
                                  "PreferredSize = " & ChangeToSQLString(.GetRowCellValue(i, "PreferredSize")) & ", " & _
                                  "DateIssue = " & ChangeToSQLDate(.GetRowCellValue(i, "DateIssue")) & ", " & _
                                  "IssuedBy = " & ChangeToSQLString(.GetRowCellValue(i, "IssuedBy")) & ", " & _
                                  "FKeyActID = " & ChangeToSQLString(.GetRowCellValue(i, "FKeyActID")) & ", " & _
                                  "Remarks = " & ChangeToSQLString(.GetRowCellValue(i, "Remarks")) & ", " & _
                                  "DateUpdated = getdate(), " & _
                                  "LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                  "WHERE PKey = '" & .GetRowCellValue(i, "PKey") & "'"
                        query.Add(cSQL)

                    End If

                End If

            Next
        End With

        Dim info As Boolean = False
        info = MPSDB.RunSqls(query)
        Return info
    End Function

    Private Sub MainView_GotFocus(sender As Object, e As System.EventArgs) Handles MainView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        focusedView = view
    End Sub

    Private Sub MainView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        view.SetRowCellValue(e.RowHandle, "Edited", True)
        view.SetRowCellValue(e.RowHandle, "InUse", True)
        view.SetRowCellValue(e.RowHandle, "Quantity", 1)
        view.SetRowCellValue(e.RowHandle, "DateIssue", System.DateTime.Now)
        view.SetRowCellValue(e.RowHandle, "IssuedBy", USER_NAME)
        view.SetRowCellValue(e.RowHandle, "FKeyIssueType", "SYSSTANDARD")
    End Sub

    'Delete
    Public Overrides Sub DeleteData()
        If IsNothing(focusedView) Then
            'DeleteMain()
        Else
            DeleteSubTable()
        End If
    End Sub

    'Delete Sub Table
    Private Sub DeleteSubTable()
        Dim view As New DevExpress.XtraGrid.Views.Grid.GridView
        Dim info As Boolean = False, FNames As New ArrayList
        Dim subDesc As String = "", subtblcount As Integer = 0
        Dim DelSQL As String = "", PKey As String = ""


        With focusedView
            If .FocusedRowHandle < 0 Then Exit Sub
            view = focusedView
            PKey = IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")
            subDesc = .GetRowCellDisplayText(.FocusedRowHandle, "FKeyGarment")

            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil	'tony20160719
            Dim cActionDesc As String = "Uniform Issuance"

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, cActionDesc, 0, System.Environment.MachineName, subDesc & " : " & .GetRowCellValue(.FocusedRowHandle, "Quantity"), FormName, strID)
            clsAudit.saveAuditPreDelDetails("tblUniformIssuance", PKey, LastUpdatedBy) 'neil
            '<!--added by tony20180922 : Log Deletion
            oLogDeletion.Init()
            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                FormName, _
                "Crewing", _
                "tblUniformIssuance", _
                "PKey IN ('" & PKey & "')", _
                "<< Delete Crew Data - " & FormName & " >>", _
                LogDeletion.DeletionType.Manual, _
                "Manually Deleted in <" & FormName & ">", _
                LastUpdatedBy)
            '-->

            DelSQL = "DELETE FROM dbo.tblUniformIssuance WHERE PKey='" & PKey & "'"

            If Not view.Name.Equals("") Then
                With view
                    If MsgBox("Are you sure want to delete the '" & subDesc & " (Qty. =" & .GetRowCellValue(.FocusedRowHandle, "Quantity") & ")'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        info = DB.RunSql(DelSQL)
                        If info Then
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If
                        .DeleteRow(.FocusedRowHandle)
                    End If
                End With

            End If

        End With
    End Sub

    Private Sub MainView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MainView.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub MainView_LostFocus(sender As Object, e As System.EventArgs) Handles MainView.LostFocus
        focusedView = Nothing
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.Column.FieldName = "NeedReIssue" Then
            Try

                If IfNull(MainView.GetRowCellValue(e.RowHandle, "AddTemplateSessionNo"), 0) <> 0 Then
                    SetRowCellStyle(e, RowCellStyle.AddedFromTemplate)

                Else
                    Select Case IfNull(MainView.GetRowCellValue(e.RowHandle, "NeedReIssue"), "")
                        Case "YES"
                            SetRowCellStyle(e, RowCellStyle.NeedReIssue)
                        Case Else
                            SetRowCellStyle(e, RowCellStyle.Normal)
                    End Select

                End If

            Catch ex As Exception
                SetRowCellStyle(e, RowCellStyle.Normal)
            End Try

        Else
            Try
                If IfNull(MainView.GetRowCellValue(e.RowHandle, "AddTemplateSessionNo"), 0) <> 0 Then
                    SetRowCellStyle(e, RowCellStyle.AddedFromTemplate)

                Else

                    SetRowCellStyle(e, RowCellStyle.Normal)
                End If

            Catch ex As Exception
                SetRowCellStyle(e, RowCellStyle.Normal)
            End Try
        End If
    End Sub

    Private Sub SetRowCellStyle(e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs, RowCellStyle As RowCellStyle)
        Select Case RowCellStyle
            Case UniformIssuance.RowCellStyle.Normal, UniformIssuance.RowCellStyle.DoNotNeedReIssue
                e.Appearance.BackColor = System.Drawing.Color.White
                e.Appearance.ForeColor = System.Drawing.Color.Black

            Case UniformIssuance.RowCellStyle.NeedReIssue
                e.Appearance.BackColor = System.Drawing.Color.Firebrick
                e.Appearance.ForeColor = System.Drawing.Color.Wheat

            Case UniformIssuance.RowCellStyle.AddedFromTemplate
                e.Appearance.BackColor = System.Drawing.Color.LightGreen
                e.Appearance.ForeColor = System.Drawing.Color.Black

        End Select

    End Sub

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MainView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Garment As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyGarment")
        Dim Quantity As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Quantity")
        'tonytest Dim bValid As Boolean = True
        With view

            'Validate Garment
            If .GetRowCellValue(e.RowHandle, Garment) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Garment) Is Nothing Then
                .SetColumnError(Garment, "Please select Garment.")
                'tonytest bValid = False
            Else
                .SetColumnError(Garment, "")
                'tonytest bValid = bValid And True
            End If

            'Validate Quantity
            If .GetRowCellValue(e.RowHandle, Quantity) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Quantity) Is Nothing Then
                .SetColumnError(Quantity, "Please enter Quantity.")
                'tonytest bValid = False
            ElseIf .GetRowCellValue(e.RowHandle, Quantity) = 0 Then
                .SetColumnError(Quantity, "Please enter Quantity.")
                'tonytest bValid = False
            Else
                .SetColumnError(Quantity, "")
                'tonytest bValid = bValid And True
            End If


            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                e.Valid = False
                BRECORDUPDATEDs = True
            End If

        End With
    End Sub

#Region "Garment Template"
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
        Dim _garments As DataTable = TryCast(MainGrid.DataSource, DataTable)
        Dim newrow As DataRow

        AddFromTemplateSessionNo = AddFromTemplateSessionNo + 1 'used for undo

        For Each row As DataRow In dtGarments.Rows
            newrow = _garments.NewRow
            newrow("Edited") = True
            newrow("FKeyGarment") = row("FKeyGarment")
            newrow("FKeyIssueType") = DEFAULT_ISSUE_TYPE
            newrow("Quantity") = row("Qty")
            newrow("InUse") = 1
            newrow("InUseLabel") = InUseLabel.InUse
            newrow("DateIssue") = System.DateTime.Now
            newrow("IssuedBy") = USER_NAME
            newrow("AddTemplateSessionNo") = AddFromTemplateSessionNo

            _garments.Rows.Add(newrow)

        Next

        BRECORDUPDATEDs = True
        MainGrid.DataSource = _garments
        cboGarmentTemplate.EditValue = Nothing
        ShowAddGarmentsFromTemplateButton(AddGarmentsFromTemplateButton.Undo, True)
    End Sub

    Private Sub UndoAddedGarmentsFromTemplate()
        Dim _garments As DataTable = TryCast(MainGrid.DataSource, DataTable)
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

        MainGrid.DataSource = _garments
        ShowAddGarmentsFromTemplateButton(AddGarmentsFromTemplateButton.Undo, False)
    End Sub

    'Private Sub ShowUndoAddedGarmentsFromTemplate(isShow As Boolean)
    '    Try
    '        cboGarmentTemplate.Properties.Buttons(2).Visible = isShow
    '    Catch ex As Exception
    '        LogErrors("Failed to set visible = " & isShow & " for button index 2")
    '    End Try
    'End Sub

    Private Sub ShowAddGarmentsFromTemplateButton(Button As AddGarmentsFromTemplateButton, isShow As Boolean)
        Try
            If Button = AddGarmentsFromTemplateButton.Add Or Button = AddGarmentsFromTemplateButton.Undo Then
                cboGarmentTemplate.Properties.Buttons(Button).Visible = isShow
            End If
        Catch ex As Exception
            LogErrors("Failed to set visible = " & isShow & " for button index 2")
        End Try
    End Sub

#End Region

    Private Sub cboGarmentTemplate_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboGarmentTemplate.EditValueChanged
        ShowAddGarmentsFromTemplateButton(AddGarmentsFromTemplateButton.Undo, False)
    End Sub

    Private Sub RepButtonClick_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repIssueType.ButtonClick, repDateEdit.ButtonClick, repSS.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

End Class
