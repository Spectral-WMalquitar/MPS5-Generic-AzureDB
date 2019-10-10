Public Class Course
#Region "Easy Edit"
    Private FormName As String = "Admin Course"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Dim dtRepeatCourseSub As DataTable

#Region "Data Source"
    Private Function getCourseType() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {1, "STCW"}
        ctable.Rows.Add(crow)
        crow(0) = 2
        crow(1) = "Company Required"
        ctable.Rows.Add(crow)
        crow(0) = 3
        crow(1) = "Others"
        ctable.Rows.Add(crow)

        crow(0) = 4
        crow(1) = "Safety"
        ctable.Rows.Add(crow)

        crow(0) = 5
        crow(1) = "Technical"
        ctable.Rows.Add(crow)
        Return ctable
    End Function
#End Region

    Dim tabChanged As Boolean = False 'if tab is changed
    Dim PrevTab As String = ""

    Private Sub initControls()
        Dim dtCntry As DataTable = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC, SortCode ASC")

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        Me.TabbedControl.SelectedTabPageIndex = 0
        Me.cboCourseTypeCode.Properties.DataSource = getCourseType()
        Me.repCurrency.DataSource = DB.CreateTable("SELECT PKey, Name, Symbol FROM dbo.tbladmCurr ORDER BY Name ASC, SortCode ASC")
        'Me.repFKeyCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC, SortCode ASC")
        Me.repFKeyCntry.DataSource = dtCntry
        Me.repInst.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourseInst ORDER BY Name ASC, SortCode ASC")

        'Certificate Tab
        Me.repLicCert.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.frmAdmDocumentList WHERE FKeyDocGroup='SYSLICCERT' ORDER BY Name ASC")
        CertGrid.ForceInitialize()
        Dim newCol As DevExpress.XtraGrid.Columns.GridColumn = Me.CertView.Columns.AddField("ValDesc")
        newCol.VisibleIndex() = CertView.Columns.Count + 1
        newCol.UnboundType = DevExpress.Data.UnboundColumnType.String
        Me.CertView.OptionsView.ColumnAutoWidth = True
        newCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
        newCol.Caption = "Validation Description"
        newCol.OptionsColumn.ReadOnly = True
        CertView.VisibleColumns(1).Width = 150

        'Repeat Course Tab
        repRetakeFKeyCntry.DataSource = dtCntry
    End Sub

    Private Sub LoadSub()
        CertGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmCourseDoc_map WHERE FKeyCourse = '" & strID & "'")
        InstCostGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmCourseInstDet WHERE FKeyCourse='" & strID & "'")

        'Repeat Course Sub
        'Dim dv As DataView = New DataView(dtRepeatCourseSub)
        'dv.RowFilter = "FKeyCourse = '" & strID & "'"
        RetakeCourseGrid.DataSource = DB.CreateTable("SELECT cast(0 as bit) as Edited, * FROM dbo.tbladmcourseretake WHERE FKeyCourse = '" & strID & "'")    ' dv.ToTable
    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tbladmCourse"
        MyBase.RefreshData()
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Course Details - " & strDesc)
        SetDeleteCaption(Name, "Delete Course")
        strRequiredFields = "txtName;cboCourseTypeCode"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            Me.txtSTCWRef.Text = Trim(IfNull(blList.GetFocusedRowData("STCWRef"), ""))
            Me.cboCourseTypeCode.EditValue = IfNull(blList.GetFocusedRowData("CourseTypeCode"), "")
            Me.txtRemarks.Text = Trim(IfNull(blList.GetFocusedRowData("Remarks"), ""))
            'for SUB DATA
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            EditSubAllowGrid(Me.InstCostView, False)
            EditSubAllowGrid(Me.CertView, False)
            EditSubAllowGrid(Me.RetakeCourseView, False)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
        End If
        EditSubAllowGrid(Me.InstCostView, isEditdable)
        EditSubAllowGrid(Me.CertView, isEditdable)
        EditSubAllowGrid(Me.RetakeCourseView, isEditdable)
        AllowDeletion(Name, False)
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        Me.TabbedControl.SelectedTabPageIndex = 0
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowDeletion(Name, False)
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            'get the max SortCode
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            BRECORDUPDATEDs = False
        End If
        LoadSub()
        EditSubAllowGrid(Me.CertView, True)
        EditSubAllowGrid(Me.InstCostView, True)
    End Sub

    Public Overrides Sub SaveData()
        Dim type As String = "", info As Boolean = False
        Dim query As New ArrayList, id As String = ""
        Me.header.Focus()
        If Not Me.InstCostView.HasColumnErrors And Not Me.RetakeCourseView.HasColumnErrors Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboCourseTypeCode}) Then
                'LASTUPDATED BY FORMAT
                'getusername() & <Description><FormName>
                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Course", 10, System.Environment.MachineName, txtName.EditValue, FormName)
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                        Exit Sub
                    Else
                        info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                        BRECORDUPDATEDs = False
                        id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                        type = "Inserted"
                    End If
                Else
                    id = strID
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                        Exit Sub
                    Else
                        info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & id & "'"))
                        BRECORDUPDATEDs = False
                        type = "Updated"
                    End If
                End If
                Select Case IIf(tabChanged, PrevTab, Me.TabbedControl.SelectedTabPage.Tag)
                    Case "LicCert" 'Certificates
                        info = DB.RunSqls(SaveCertificates(id))

                    Case "Inst" 'Institution
                        info = DB.RunSqls(SaveInstCost(id))

                    Case "RepCourse" 'Repeat Course
                        info = DB.RunSqls(SaveCourseRetake(id))
                End Select
                tabChanged = False

                blList.RefreshData()
                bAddMode = False
                If info Then
                    MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
                    blList.SetSelection(id)
                    RefreshData()
                End If
            End If
        Else
            info = False
            MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboCourseTypeCode}, showMsg) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                End If
            Else
                flag = False
                ALLOWNEXTS = flag
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Overrides Sub DeleteData()
        If IsNothing(focusedView) Then
            DeleteMain()
        Else
            DeleteSubTable()
        End If
    End Sub

    Private Sub DeleteMain()
        MyBase.DeleteData()
        With focusedView

        End With
        Dim info As Boolean = False
        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Course", 10, System.Environment.MachineName, txtName.EditValue, FormName)
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()

                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Admin", _
                    Me.TableName, _
                    "PKey IN ('" & strID & "')", _
                    "<< Delete Admin Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->

                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    ClearFields(Me.LayoutControl1.Root, False)
                    LoadSub()
                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    RefreshData()
                    blList.RefreshData()
                    BRECORDUPDATEDs = False
                End If
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If
        End If
    End Sub

    Private Sub DeleteSubTable()

        Select Case Me.TabbedControl.SelectedTabPage.Tag
            Case "LicCert"
                With Me.CertView
                    If MsgBox("Are you sure want to delete the Certificate '" & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Course - Certificates", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument"), FormName) 'tony20160719

                            clsAudit.saveAuditPreDelDetails("tblAdmCourseDoc_map", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                FormName, _
                                "Crewing", _
                                "tblAdmCourseDoc_map", _
                                "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                                "<< Delete Crew Data - " & FormName & " >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <" & FormName & ">", _
                                GetUserName())
                            '-->
                            DB.RunSql("DELETE FROM dbo.tblAdmCourseDoc_map WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If
                        .DeleteRow(.FocusedRowHandle)
                        If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                    End If
                End With
            Case "Inst"
                With Me.InstCostView
                    If MsgBox("Are you sure want to delete the Institution Cost '" & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCourseInst") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Course - Institution Cost", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCourseInst") & " : " & .GetRowCellValue(.FocusedRowHandle, "Amt"), FormName) 'tony20160719
                            clsAudit.saveAuditPreDelDetails("tblAdmCourseInstDet", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                FormName, _
                                "Crewing", _
                                "tblAdmCourseInstDet", _
                                "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                                "<< Delete Crew Data - " & FormName & " >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <" & FormName & ">", _
                                GetUserName())
                            '-->
                            DB.RunSql("DELETE FROM dbo.tblAdmCourseInstDet WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If
                        .DeleteRow(.FocusedRowHandle)
                        If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                    End If
                End With
        End Select
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

#Region "Certificates"

    Private Function SaveCertificates(ByVal id As String) As ArrayList
        Dim query As New ArrayList
        With Me.CertView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Course - Certificates", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyDocument"), FormName) 'tony20160719
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblAdmCourseDoc_map(FKeyCourse,FKeyDocument,Validity,LastUpdatedBy)" & _
                                  "VALUES('" & id & "'" & _
                                  ",'" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                  ",'" & .GetRowCellValue(i, "Validity") & "'" & _
                                  ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblAdmCourseDoc_map " & _
                                  "SET FKeyDocument='" & .GetRowCellValue(i, "FKeyDocument") & "'" & _
                                   ", Validity='" & .GetRowCellValue(i, "Validity") & "'" & _
                                  ", LastUpdatedBy='" & LastUpdatedBy & "'" & _
                                  ", DateUpdated=(getdate()) " & _
                                  "WHERE FKeyCourse='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If

                    'If Not IfNull(.GetRowCellValue(i, "FKeyDocument"), "").Equals("") Then
                    '    query.Add("UPDATE tblAdmDocument SET AllowDuplicate=1 WHERE PKey='" & .GetRowCellValue(i, "FKeyDocument") & "'")
                    'End If
                End If
            Next
        End With

        Return query
    End Function

    Private Sub CertView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CertView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.CertView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub CertView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CertView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CertView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles CertView.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "ValDesc" AndAlso e.IsGetData Then
            e.Value = getValDesc(view, e.ListSourceRowIndex)
        End If
    End Sub

    Private Sub CertView_GotFocus(sender As Object, e As System.EventArgs) Handles CertView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Certificate")
            AllowDeletion(Name, True)
        End If
    End Sub

    Private Sub CertView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CertView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyCourse"), strID)
        SubAddMode = True
    End Sub

    Private Sub CertView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CertView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CertView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CertView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            CertView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub CertView_LostFocus(sender As Object, e As System.EventArgs) Handles CertView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Course")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub CertView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CertView.RowCellStyle
        If CertView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf CertView.GetRowCellValue(e.RowHandle, "Edited") And CertView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf CertView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = CertView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub CertView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CertView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CertView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles CertView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Course Certificate"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
        For Each cntrl As Windows.Forms.Control In e.EditForm.Controls
            If Not TypeOf cntrl Is DevExpress.XtraGrid.EditForm.Helpers.Controls.EditFormContainer Then
                Continue For
            End If
            For Each nctrl As Windows.Forms.Control In cntrl.Controls
                If Not (TypeOf nctrl Is DevExpress.XtraEditors.PanelControl) Then
                    Continue For
                Else
                    nctrl.Height = 70
                End If
                For Each btn As Windows.Forms.Control In nctrl.Controls
                    If TypeOf btn Is DevExpress.XtraEditors.SimpleButton Then
                        Dim sbtn = TryCast(btn, DevExpress.XtraEditors.SimpleButton)
                        'Update Button
                        If sbtn.Text = "Update" Or sbtn.Text = "Add" Or sbtn.Text = "Edit" Then
                            If SubAddMode Then
                                sbtn.Text = "Add"
                                sbtn.Image = ImageCollection.Images.Item(0)
                                sbtn.ImageIndex = 2
                            Else
                                sbtn.Text = "Edit"
                                sbtn.Image = ImageCollection.Images.Item(2)
                                sbtn.ImageIndex = 0
                            End If
                            SubAddMode = False
                            sbtn.Size = New System.Drawing.Point(90, 38)
                            sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) - sbtn.Size.Width - 3, 18)
                        End If
                        'Cancel Button
                        If sbtn.Text = "Cancel" Then
                            sbtn.Image = ImageCollection.Images.Item(1)
                            sbtn.ImageIndex = 0
                            sbtn.Size = New System.Drawing.Point(90, 38)
                            sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) + 3, 18)
                        End If
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub CertView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CertView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FKeyDocument As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyDocument")

        If view.GetRowCellValue(e.RowHandle, FKeyDocument) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, FKeyDocument) Is Nothing Then
            e.Valid = False
            view.SetColumnError(FKeyDocument, "Please select Certificate")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
        Else
            e.Valid = True
            view.GetDataRow(e.RowHandle).ClearErrors()
            AllowSaving(Name, True)
        End If
    End Sub

    Private Sub CertView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles CertView.ValidatingEditor
        ViewValidatingEditor("tblAdmCourseDoc_map", "FKeyDocument", "FKeyCourse", sender, e)
    End Sub

#End Region

#Region "Institution Cost"

    Private Function SaveInstCost(ByVal id As String) As ArrayList
        Dim query As New ArrayList
        With Me.InstCostView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Course - Institution Cost", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyCourseInst") & " : " & .GetRowCellValue(i, "Amt"), FormName) 'tony20160719
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblAdmCourseInstDet(FKeyCourse,FKeyCourseInst,Amt,FKeyCurrency,FKeyCntry,LastUpdatedBy)" & _
                                  " VALUES('" & id & "'" & _
                                  ",'" & .GetRowCellValue(i, "FKeyCourseInst") & "'" & _
                                  ",'" & .GetRowCellValue(i, "Amt") & "'" & _
                                  ",'" & .GetRowCellValue(i, "FKeyCurrency") & "'" & _
                                  ",'" & .GetRowCellValue(i, "FKeyCntry") & "'" & _
                                  ",'" & LastUpdatedBy & "')")
                    Else
                        id = strID
                        query.Add("UPDATE dbo.tblAdmCourseInstDet " & _
                                  "SET FKeyCourseInst='" & .GetRowCellValue(i, "FKeyCourseInst") & "'" & _
                                  ", Amt='" & .GetRowCellValue(i, "Amt") & "'" & _
                                  ", FKeyCurrency='" & .GetRowCellValue(i, "FKeyCurrency") & "'" & _
                                  ", FKeyCntry='" & .GetRowCellValue(i, "FKeyCntry") & "'" & _
                                  ", LastUpdatedBy='" & LastUpdatedBy & "'" & _
                                  ", DateUpdated=(getdate()) " & _
                                  "WHERE FKeyCourse='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub InstCostView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles InstCostView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName.ToString <> "Edited" And e.Column.FieldName <> "FKeyCntry" Then
            If e.Column.FieldName.ToString = "FKeyCourseInst" Then
                With Me.InstCostView
                    Dim str As String = DB.DLookUp("FKeyCntry", "tblAdmCourseInst", "", "PKey='" & e.Value.ToString & "'")
                    .SetRowCellValue(e.RowHandle, "FKeyCntry", str)
                End With
            End If
            With Me.InstCostView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If


    End Sub

    Private Sub InstCostView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles InstCostView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub InstCostView_GotFocus(sender As Object, e As System.EventArgs) Handles InstCostView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Institution")
            AllowDeletion(Name, True)
        End If
    End Sub

    Private Sub InstCostView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles InstCostView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyCourse"), strID)
        SubAddMode = True
    End Sub

    Private Sub InstCostView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles InstCostView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub InstCostView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles InstCostView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            InstCostView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub InstCostView_LostFocus(sender As Object, e As System.EventArgs) Handles InstCostView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Course")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub InstCostView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles InstCostView.RowCellStyle
        If InstCostView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf InstCostView.GetRowCellValue(e.RowHandle, "Edited") And InstCostView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf InstCostView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = InstCostView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub InstCostView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles InstCostView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub InstCostView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles InstCostView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Course Institution"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
        For Each cntrl As Windows.Forms.Control In e.EditForm.Controls
            If Not TypeOf cntrl Is DevExpress.XtraGrid.EditForm.Helpers.Controls.EditFormContainer Then
                Continue For
            End If
            For Each nctrl As Windows.Forms.Control In cntrl.Controls
                If Not (TypeOf nctrl Is DevExpress.XtraEditors.PanelControl) Then
                    Continue For
                Else
                    nctrl.Height = 70
                End If
                For Each btn As Windows.Forms.Control In nctrl.Controls
                    If TypeOf btn Is DevExpress.XtraEditors.SimpleButton Then
                        Dim sbtn = TryCast(btn, DevExpress.XtraEditors.SimpleButton)
                        'Update Button
                        If sbtn.Text = "Update" Or sbtn.Text = "Add" Or sbtn.Text = "Edit" Then
                            If SubAddMode Then
                                sbtn.Text = "Add"
                                sbtn.Image = ImageCollection.Images.Item(0)
                                sbtn.ImageIndex = 2
                            Else
                                sbtn.Text = "Edit"
                                sbtn.Image = ImageCollection.Images.Item(2)
                                sbtn.ImageIndex = 0
                            End If
                            SubAddMode = False
                            sbtn.Size = New System.Drawing.Point(90, 38)
                            sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) - sbtn.Size.Width - 3, 18)
                        End If
                        'Cancel Button
                        If sbtn.Text = "Cancel" Then
                            sbtn.Image = ImageCollection.Images.Item(1)
                            sbtn.ImageIndex = 0
                            sbtn.Size = New System.Drawing.Point(90, 38)
                            sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) + 3, 18)
                        End If
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub InstCostView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles InstCostView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")
        Dim FKeyCurr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCurrency")
        Dim FKeyCourseInst As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCourseInst")
        'Dim FKeyCourse As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCourse")

        If view.GetRowCellValue(e.RowHandle, FKeyCourseInst) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, FKeyCourseInst) Is Nothing Then
            e.Valid = False
            view.SetColumnError(FKeyCourseInst, "Please select Institution")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            'ElseIf view.GetRowCellValue(e.RowHandle, FKeyCourse) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, FKeyCourse) Is Nothing Then
            '    e.Valid = False
            '    view.SetColumnError(FKeyCourse, "Please select Course")
            '    view.FocusedColumn = view.VisibleColumns(0)
            '    AllowSaving(Name, False)
        ElseIf view.GetRowCellValue(e.RowHandle, FKeyCurr) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, FKeyCurr) Is Nothing Then
            e.Valid = False
            view.SetColumnError(FKeyCurr, "Invalid Currency")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
        Else
            e.Valid = True
            view.GetDataRow(e.RowHandle).ClearErrors()
            AllowSaving(Name, True)
        End If


    End Sub

    Private Sub InstCostView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles InstCostView.ValidatingEditor
        ViewValidatingEditor("tblAdmCourseInstDet", "FKeyCourseInst", "FKeyCourse", sender, e)
    End Sub

#End Region

    Private Sub TabbedControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControl.SelectedPageChanged
        If BRECORDUPDATEDs Then
            'If BRECORDUPDATEDs And (bPermission And 4) > 0 Then
            'If MsgBox("Would you like to save the changes you made on " & GetDesc() & "?", MsgBoxStyle.YesNo, strCaption) = MsgBoxResult.Yes Then
            If MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.YesNo, strCaption) = MsgBoxResult.Yes Then
                tabChanged = True
                SaveData()
            Else
                RefreshData()
            End If
        End If
    End Sub

    Private Sub TabbedControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangingEventArgs) Handles TabbedControl.SelectedPageChanging
        PrevTab = Me.TabbedControl.SelectedTabPage.Tag
    End Sub

    Private Sub ViewValidatingEditor(TableName As String, FieldName As String, FKeyField As String, sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            With _view
                Dim AllowDup As Boolean = False
                If .FocusedColumn.FieldName.Equals(FieldName) Then
                    If DB.HasDuplicate(TableName, FieldName & "= '" & e.Value & "' AND " & FKeyField & "='" & strID & "' ") Then
                        e.Valid = False
                        .SetColumnError(.FocusedColumn, "Already in use.")
                    Else
                        For i As Integer = 0 To .DataRowCount - 1
                            If i <> (.FocusedRowHandle) Then
                                If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
                                    e.Valid = False
                                    .SetColumnError(.FocusedColumn, "Already in use.")
                                Else
                                    .SetColumnError(.FocusedColumn, "")
                                    e.Valid = True
                                End If
                            End If
                        Next
                    End If


                Else
                    .SetFocusedRowCellValue(.FocusedColumn, e.Value)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCourseTypeCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboCourseTypeCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repLicCert_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repLicCert.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repInst_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repInst.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repCurrency_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCurrency.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

#Region "Repeat Course"
    Private Function SaveCourseRetake(ByVal id As String) As ArrayList
        Dim query As New ArrayList
        With Me.RetakeCourseView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Course - Course Retake", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyCntry"), FormName) 'tony20160719
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tbladmcourseretake(FKeyCourse,FKeyCntry,RetakeCourseYear,RetakeCourseMonth,Remarks,DateUpdated,LastUpdatedBy)" & _
                                  "VALUES('" & id & "'" & _
                                  ",'" & .GetRowCellValue(i, "FKeyCntry") & "'" & _
                                  ",'" & .GetRowCellValue(i, "RetakeCourseYear") & "'" & _
                                  ",'" & .GetRowCellValue(i, "RetakeCourseMonth") & "'" & _
                                  ",'" & .GetRowCellValue(i, "Remarks") & "'" & _
                                  ",getdate()" & _
                                  ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tbladmcourseretake " & _
                                  "SET FKeyCntry='" & .GetRowCellValue(i, "FKeyCntry") & "'" & _
                                   ", RetakeCourseYear='" & .GetRowCellValue(i, "RetakeCourseYear") & "'" & _
                                   ", RetakeCourseMonth='" & .GetRowCellValue(i, "RetakeCourseMonth") & "'" & _
                                   ", Remarks='" & .GetRowCellValue(i, "Remarks") & "'" & _
                                  ", LastUpdatedBy='" & LastUpdatedBy & "'" & _
                                  ", DateUpdated=(getdate()) " & _
                                  "WHERE FKeyCourse='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If

                    'If Not IfNull(.GetRowCellValue(i, "FKeyDocument"), "").Equals("") Then
                    '    query.Add("UPDATE tblAdmDocument SET AllowDuplicate=1 WHERE PKey='" & .GetRowCellValue(i, "FKeyDocument") & "'")
                    'End If
                End If
            Next
        End With

        Return query
    End Function

    Private Sub RepeatCourseView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RetakeCourseView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.Column.FieldName.ToString <> "Edited" Then
            view.SetRowCellValue(e.RowHandle, "Edited", 1)
        End If

    End Sub

    Private Sub RepeatCourseView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RetakeCourseView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub RepeatCourseView_GotFocus(sender As Object, e As System.EventArgs) Handles RetakeCourseView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Repeat Course")
            AllowDeletion(Name, True)
        End If
    End Sub

    Private Sub RepeatCourseView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RetakeCourseView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyCourse"), strID)
        View.SetRowCellValue(e.RowHandle, View.Columns("RetakeCourseYear"), 0)
        View.SetRowCellValue(e.RowHandle, View.Columns("RetakeCourseMonth"), 0)
        SubAddMode = True
    End Sub

    Private Sub RepeatCourseView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles RetakeCourseView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub RepeatCourseView_LostFocus(sender As Object, e As System.EventArgs) Handles RetakeCourseView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Course")
            AllowDeletion(Name, False)
        End If
    End Sub

#End Region

    Private Sub RepeatCourseView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles RetakeCourseView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim RepeatCourseYear As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("RetakeCourseYear")
        Dim RepeatCourseMonth As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("RetakeCourseMonth")
        Dim RepeatCourseCountry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")

        If isCountryAlreadySelected(view, e.RowHandle, view.GetRowCellValue(e.RowHandle, "FKeyCntry")) Then
            e.Valid = False
            view.SetColumnError(RepeatCourseCountry, "Country has been already selected.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
        ElseIf IfNull(view.GetRowCellValue(e.RowHandle, RepeatCourseYear), 0) = 0 And IfNull(view.GetRowCellValue(e.RowHandle, RepeatCourseMonth), 0) = 0 Then
            e.Valid = False
            view.SetColumnError(RepeatCourseYear, "Please enter the year interval when this course should be repeated/retaken")
            view.SetColumnError(RepeatCourseMonth, "Please enter the month interval when this course should be repeated/retaken")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
        Else
            e.Valid = True
            view.GetDataRow(e.RowHandle).ClearErrors()
            view.SetColumnError(RepeatCourseYear, "")
            view.SetColumnError(RepeatCourseMonth, "")
            view.SetColumnError(RepeatCourseCountry, "")
            AllowSaving(Name, True)
        End If
    End Sub

    Private Function isCountryAlreadySelected(view As DevExpress.XtraGrid.Views.Grid.GridView, FocusedRowhandle As Integer, val As String)
        For i As Integer = 0 To view.RowCount - 1
            If view.GetRowCellValue(i, "FKeyCntry") = val And i <> FocusedRowhandle Then
                Return True
            End If
        Next

        Return False
    End Function

End Class
