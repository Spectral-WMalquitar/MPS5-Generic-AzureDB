Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid


Public Class frmActivityDocs

    Dim CallFromService As Boolean

    Dim var_actkey As String, var_crewid As String, dt As New DataTable
    Dim var_dateissue_s As String, var_dateexpire_s As String
    Dim var_dateissue As Date, var_dateexpire As Date
    Dim var_vslname As String = ""
    Dim crew_name As String
    Dim clsAudit As New clsAudit
    Dim sqlConn As New SqlClient.SqlConnection
    Dim clsSec As New clsSecurity

    'THESE CONST ARE FROM DATABASE
    Const CONST_FILETAG = "ACTD"
    Const CONST_DOCGROUP = "SYSACTIVITYDOC"
    Const CONST_ACTDOCUMENT = "SYSACTIVITYDOCD"

    Dim clsActAct As clsActivityDocs_temptbl
    Dim clsDoc As New clsDocumentViewer_Functions

    Public Sub New(ByRef clsAct As clsActivityDocs_temptbl, idnbr As String, dateissue As Date, vslname As String,
                   Optional dateexpire As Date = Nothing, Optional crewname As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        clsActAct = clsAct

        CallFromService = False
        '' Add any initialization after the InitializeComponent() call.
        '' var_actkey = activityKey
        var_crewid = idnbr
        'var_dateissue_s = IfNull(Format(dateissue, "yyyyMMdd") & "_", "")
        var_dateissue = dateissue
        var_dateexpire = dateexpire
        var_dateexpire_s = dateexpire
        var_vslname = vslname 'for audit

        clsSec.propSQLConnStr = MPSDB.GetConnectionString

        repBtnBrowse.Buttons(0).Enabled = False

        crew_name = crewname

        Call checkbtnpermissions()

        Call ReloadDSource()

        EditSubAllowGrid(Me.viewImages, False, True)
        'Dim imgBtn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repBtnBrowse
        'With imgBtn
        '    .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
        '                                                              "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
        '                                                              Nothing, Nothing, Nothing, Nothing))
        '    .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        '    AddHandler .ButtonPressed, AddressOf repButtonClick
        'End With
        clsAudit.propSQLConnStr = MPSDB.GetConnectionString
    End Sub

    Public Sub New(activityKey As String, idnbr As String, dateissue As Date, vslname As String,
                   Optional dateexpire As Date = Nothing, Optional crewname As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        CallFromService = True

        ' Add any initialization after the InitializeComponent() call.
        var_actkey = activityKey
        var_crewid = idnbr
        var_dateissue_s = IfNull(Format(dateissue, "yyyyMMdd") & "_", "")
        var_dateissue = dateissue
        var_dateexpire = dateexpire
        var_dateexpire_s = dateexpire
        var_vslname = vslname

        clsSec.propSQLConnStr = MPSDB.GetConnectionString

        repBtnBrowse.Buttons(0).Enabled = False

        crew_name = crewname

        Call checkbtnpermissions()

        Call ReloadDSource()

        EditSubAllowGrid(Me.viewImages, False, True)
        'Dim imgBtn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repBtnBrowse
        'With imgBtn
        '    .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
        '                                                              "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
        '                                                              Nothing, Nothing, Nothing, Nothing))
        '    .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        '    AddHandler .ButtonPressed, AddressOf repButtonClick
        'End With
        clsAudit.propSQLConnStr = MPSDB.GetConnectionString
    End Sub

    Sub checkbtnpermissions()
        If clsSec.hasNoUpdatePermission("Activity_Docs", USER_ID, True, userPermDt) = 0 Then
            Me.cmdEdit.Enabled = True
            Me.cmdSave.Enabled = True
        Else
            Me.cmdSave.Enabled = False
            Me.cmdEdit.Enabled = False
        End If

        If clsSec.hasNoDeletePermission("Activity_Docs", USER_ID, True, userPermDt) = 0 Then
            Me.cmdDelete.Enabled = True
        Else
            Me.cmdDelete.Enabled = False
        End If

        If Not cmdDelete.Enabled And Not cmdEdit.Enabled Then
            Me.rpgEditOption.Visible = False
        End If

        Me.layMainGrid.Text = crew_name

    End Sub

    Sub ReloadDSource()

        If CallFromService Then
            dt = MPSDB.CreateTable("select * from viewfrmActivitydocs where ActivityPKey = '" & var_actkey & "' ORDER BY DateIssue ASC")
            'dt = MPSDB.CreateTable("select * from viewfrmActivitydocs")
        Else
            dt = clsActAct.getDocs(var_crewid)
        End If
        Me.gridImages.DataSource = dt

    End Sub
    'Private Sub repButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
    '    Dim _Parentview As DevExpress.XtraGrid.Views.Grid.GridView = viewImages.ParentView
    '    Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
    '    Dim bIndex As Integer = btn.Properties.Buttons.IndexOf(e.Button)
    '    'If _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey") = Nothing Then Return

    '    'If Not IsNothing(_Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey")) Then
    '    '    If Not _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
    '    '        If Not _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey").Equals(CStr(_Parentview.FocusedRowHandle)) Then
    '    Select Case bIndex
    '        Case 0 'Browse Button
    '            Dim odMain As New System.Windows.Forms.OpenFileDialog
    '            odMain.Filter = MPS4Functions.AttachDocument.GetAttachDocFilter()
    '            If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '                btn.Text = odMain.SafeFileName
    '                viewImages.SetFocusedRowCellValue("FilePath", odMain.FileName.ToString)
    '                BRECORDUPDATEDs = True
    '            End If
    '    End Select
    '    '        Else
    '    'MsgBox("Save First the Record(s).", MsgBoxStyle.Information, GetAppName)
    '    '        End If
    '    '    End If
    '    'End If



    'End Sub

    'Public Sub EditSubAllowGrid(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal value As Boolean, Optional showNewRow As Boolean = True)
    '    With view
    '        .CancelUpdateCurrentRow()
    '        If value Then
    '            .OptionsBehavior.ReadOnly = False
    '            If showNewRow Then
    '                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
    '                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
    '                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
    '                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    '            Else
    '                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
    '                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
    '                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
    '                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    '            End If
    '        Else
    '            .OptionsBehavior.ReadOnly = True
    '            .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
    '            .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
    '            .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
    '            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

    '        End If
    '    End With

    'End Sub

    Private Sub cmdEdit_DownChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdEdit.DownChanged
        If cmdEdit.Down = False Then
            If isThereAChange() Then
                Dim ans As Integer
                ans = MsgBox("Would you like to Cancel the changes?", vbYesNo + vbExclamation)
                If ans = vbYes Then
                    EditSubAllowGrid(Me.viewImages, cmdEdit.Down, True)
                    repBtnBrowse.Buttons(0).Enabled = cmdEdit.Down
                    'Me.cmdSave.Enabled = cmdEdit.Down
                    viewImages.CancelUpdateCurrentRow()
                    viewImages.HideEditor()
                    'viewImages.RefreshData()
                    ReloadDSource()
                    'BRECORDUPDATEDs = False
                Else
                    cmdEdit.Down = True
                End If
            Else
                EditSubAllowGrid(Me.viewImages, cmdEdit.Down, True)
                repBtnBrowse.Buttons(0).Enabled = cmdEdit.Down
                'Me.cmdSave.Enabled = cmdEdit.Down
            End If
        Else
            EditSubAllowGrid(Me.viewImages, cmdEdit.Down, True)
            repBtnBrowse.Buttons(0).Enabled = cmdEdit.Down
        End If


    End Sub

    Private Sub cmdEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdEdit.ItemClick

    End Sub

    Private Sub repBtnBrowse_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repBtnBrowse.ButtonClick
        Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        ' Dim bIndex As Integer = btn.Properties.Buttons.IndexOf(e.Button)
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = MPS4Functions.AttachDocument.GetAttachDocFilter()
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If odMain.SafeFileName <> "" Then
                If Not alreadyInList(odMain.SafeFileName) Then
                    btn.Text = odMain.SafeFileName
                    viewImages.SetFocusedRowCellValue("FilePath", odMain.FileName.ToString)
                    viewImages.SetRowCellValue(viewImages.FocusedRowHandle, "FPathEdited", True)
                    BRECORDUPDATEDs = True
                Else
                    MsgBox("Description already in the list.", vbExclamation)
                End If
            End If
        End If
    End Sub

    Private Sub repBtnBrowse_Click(sender As Object, e As System.EventArgs) Handles repBtnBrowse.Click

    End Sub

    Private Sub viewImages_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles viewImages.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                ' TryCast(view.ParentView, DevExpress.XtraGrid.Views.Grid.GridView).SetRowCellValue(view.SourceRowHandle, "Edited", True)
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub viewImages_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles viewImages.CellValueChanging

    End Sub

    'Private Sub viewImages_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles viewImages.CustomDrawCell
    '    'Dim cellInfo As ViewInfo.GridCellInfo
    '    'Dim buttonEditViewInfo As DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo
    '    'Dim sValue As String = "-"

    '    'Try
    '    '    If e.Column.Name.ToString = "Description" Then
    '    '        ' sValue = e.CellValue.ToString

    '    '        cellInfo = CType(e.Cell, ViewInfo.GridCellInfo)
    '    '        buttonEditViewInfo = CType(cellInfo.ViewInfo, DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo)
    '    '        buttonEditViewInfo.RightButtons(0).Button.Caption = "Browse"
    '    '    End If
    '    'Catch ex As Exception
    '    '    ' ... error handling
    '    'End Try
    'End Sub

  

    Private Sub viewImages_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles viewImages.CustomUnboundColumnData
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = view.ParentView 'Master View
        'With view
        '    If e.Column.FieldName = "FileName" AndAlso e.IsGetData Then
        '        e.Value = MView.GetRowCellValue(view.SourceRowHandle, "File_Name") & "_" & e.ListSourceRowIndex.ToString
        '    End If
        'End With
    End Sub

    Private Sub viewImages_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles viewImages.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
    End Sub

    Private Sub cmdSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
        'Dim dt As New DataTable, docPKey As String = "", errmsg As String
        'Dim info As Boolean = False
        'Dim LastUpdatedBy As String = ""
        ''dt = MPSDB.CreateTable("insert into tbldocument (FileTag) output inserted.PKey values('testtest')")
        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Activity Documents", 0, System.Environment.MachineName, "Activity Document", "Activity Document", ) 'tony20160719
        'errmsg = insertActivityDoc(var_actkey, var_crewid, var_dateissue, var_dateexpire, docPKey, , LastUpdatedBy)
        'If errmsg <> "" Then
        '    MsgBox(errmsg)
        'Else
        '    MsgBox(docPKey)
        '    saveImage(var_actkey, docPKey)
        'End If

        If viewImages.HasColumnErrors Then
            MsgBox("Please correct invalid value(s)", vbExclamation)
            Exit Sub
        End If

        'Dim dtchanges As New DataTable
        '' If dt.DataSet.HasChanges > 0 Then
        'viewImages.PostEditor()
        'viewImages.CloseEditForm()
        'viewImages.UpdateCurrentRow()
        'dtchanges = dt.GetChanges
        'If Not dtchanges Is Nothing Then
        '    If saveImage() Then
        '        'MsgBox("Record(s) saved.", vbInformation)
        '        ReloadDSource()
        '        Me.gridImages.RefreshDataSource()
        '        Me.cmdEdit.Down = False
        '        EditSubAllowGrid(Me.viewImages, False, False)
        '    Else
        '        MsgBox("Error saving document images.", vbExclamation)
        '    End If
        '    BRECORDUPDATEDs = False
        'Else
        '    MsgBox("No changes to save.", vbInformation)
        '    BRECORDUPDATEDs = False
        'End If

        If isThereAChange() Then

            If CallFromService Then 'not from activity
                If saveImage() Then
                    'MsgBox("Record(s) saved.", vbInformation)
                    ReloadDSource()
                    Me.gridImages.RefreshDataSource()
                    Me.cmdEdit.Down = False
                    EditSubAllowGrid(Me.viewImages, False, False)
                Else
                    MsgBox("Error saving document images.", vbExclamation)
                End If
                'BRECORDUPDATEDs = False
            Else ' call from activity
                clsActAct.deleteDocs(var_crewid) ' delete first all docs of selected crew
                With Me.viewImages
                    For intmo = 0 To .RowCount - 1
                        clsActAct.saveDocsToDt(var_crewid, .GetRowCellValue(intmo, "Description"), .GetRowCellValue(intmo, "FilePath"), var_dateissue, var_vslname, "", var_dateexpire)
                    Next
                End With

                MsgBox("Attachement(s) saved for current activity.", vbInformation)

                ReloadDSource()
                Me.gridImages.RefreshDataSource()
                Me.cmdEdit.Down = False
                EditSubAllowGrid(Me.viewImages, False, False)
            End If


        Else
            MsgBox("No changes to save.", vbInformation)
            'BRECORDUPDATEDs = False
        End If

    End Sub

    Function saveImage() As Boolean
        Dim ret As Boolean = True
        Dim query As New ArrayList
        Dim LastUpdatedBy As String = ""
        'Dim DocStr As String = ""
        Dim count As Integer = 0, editedcount As Integer = 0
        Dim strID As String = ""
        Dim sql As String, prefiletag As String = ""
        Dim docPKey As String = "", errmsg As String
        'Dim DocumentList As New List(Of Dictionary(Of Integer, String))()
        'Dim child As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(.GetDetailView(i, x), DevExpress.XtraGrid.Views.Grid.GridView)
        Try

            With Me.viewImages
                '.PostEditor()
                '.CloseEditForm()
                '.UpdateCurrentRow()

                'For count = 0 To .RowCount - 1
                '    If .GetRowCellValue(count, "Edited") Then
                '        editedcount = editedcount + 1
                '        Exit For
                '    End If
                'Next

                'If editedcount = 0 Then
                '    MsgBox("No Record(s) to save.", vbInformation)
                '    Return ret
                'End If

                If Not isThereAChange() Then
                    MsgBox("No Record(s) to save.", vbInformation)
                    Return ret
                End If

                Dim intmo As Integer, existingActKey As String
                ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Saving Document...")

                For intmo = 0 To .RowCount - 1
                    prefiletag = var_crewid & "_" & CONST_FILETAG & "_" & var_dateissue_s & intmo
                    'MsgBox(.ActiveEditor.OldEditValue() & " " & .ActiveEditor.EditValue)
                    ' MsgBox(.GetRowCellValue(intmo, "FilePath") & " _ " & .GetRowCellDisplayText(intmo, "FilePath"))


                    If .GetRowCellValue(intmo, "Edited") And Not viewImages.GetRowCellValue(intmo, "Description").Equals(System.DBNull.Value) Then

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Activity Documents", 0, System.Environment.MachineName, var_vslname & " \ " & var_dateissue & " \ " & _
                                                             CleanInput(.GetRowCellValue(intmo, "Description")).ToString.Replace("'", "''"), "Activity Document", var_crewid)

                        'Insert
                        If .GetRowCellValue(intmo, "FPathEdited") Then
                            Dim ermsg As String = ""


                            If LinkDocument(.GetRowCellValue(intmo, "FilePath"), var_crewid, CONST_FILETAG, var_dateissue_s & intmo, ermsg) Then
                                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Activity Documents", 0, System.Environment.MachineName, .GetRowCellValue(intmo, "VslName") & " \ " & var_dateissue & " \ " &
                                '                                         CleanInput(.GetRowCellValue(intmo, "Description")).ToString.Replace("'", "''"), "Activity Document", var_crewid)
                                If IfNull(.GetRowCellValue(intmo, "DocImgPKey"), "") = "" Then
                                    existingActKey = MPSDB.DLookUp("PKey", "tbldocument", "", "FKeyActivity ='" & var_actkey & "'")
                                    If existingActKey = "" Then
                                        errmsg = insertActivityDoc(var_actkey, var_crewid, var_dateissue, var_dateexpire,
                                                                   CONST_FILETAG, docPKey, , )
                                        If errmsg <> "" Then
                                            'MsgBox(errmsg)
                                        Else
                                            'MsgBox(docPKey)

                                            sql = "INSERT INTO dbo.tblDocImage(FKeyIDNbr,FKeyCrewDocumentID,Description,FilePath,LastUpdatedBy)" & _
                                                      "VALUES(" & _
                                                      "'" & var_crewid & "'" & _
                                                      ",'" & docPKey & "'" & _
                                                      ",'" & CleanInput(.GetRowCellValue(intmo, "Description")) & "'" & _
                                                      ",'" & prefiletag & "'" & _
                                                      ",'" & CleanInput(LastUpdatedBy) & "')"
                                            'MPSDB.RunSql(sql)
                                            query.Add(sql)
                                        End If
                                    Else
                                        sql = "INSERT INTO dbo.tblDocImage(FKeyIDNbr,FKeyCrewDocumentID,Description,FilePath,LastUpdatedBy)" & _
                                                      "VALUES(" & _
                                                      "'" & var_crewid & "'" & _
                                                      ",'" & existingActKey & "'" & _
                                                      ",'" & CleanInput(.GetRowCellValue(intmo, "Description")) & "'" & _
                                                      ",'" & prefiletag & "'" & _
                                                      ",'" & CleanInput(LastUpdatedBy) & "')"
                                        ' MPSDB.RunSql(sql)
                                        query.Add(sql)
                                    End If
                                Else
                                    'update
                                    sql = "UPDATE dbo.tblDocImage SET " & _
                                              "Description = '" & CleanInput(.GetRowCellValue(intmo, "Description")) & "'" & _
                                              ",FilePath ='" & prefiletag & "'" & _
                                              ",DateUpdated = getdate()" & _
                                              ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                              " WHERE PKey = '" & CleanInput(IfNull(.GetRowCellValue(intmo, "DocImgPKey"), "")) & "'"
                                    '",FKeyCrewDocumentID='" & CONST_ACTDOCUMENT & "'" & _
                                    'MPSDB.RunSql(sql)
                                    query.Add(sql)
                                End If
                            Else
                                MsgBox("Something went wrong. Cannot save the Document." & vbCrLf & ermsg, vbExclamation)
                            End If
                        Else
                            sql = "UPDATE dbo.tblDocImage SET " & _
                                        "Description = '" & CleanInput(.GetRowCellValue(intmo, "Description")) & "'" & _
                                        ",FilePath ='" & prefiletag & "'" & _
                                        ",DateUpdated = getdate()" & _
                                        ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                        " WHERE PKey = '" & CleanInput(IfNull(.GetRowCellValue(intmo, "DocImgPKey"), "")) & "'"
                            '",FKeyCrewDocumentID='" & CONST_ACTDOCUMENT & "'" & _
                            'MPSDB.RunSql(sql)
                            query.Add(sql)
                        End If

                        'If (Not IfNull(.GetRowCellValue(intmo, "FilePath"), "").ToString.Equals(IfNull(.GetRowCellValue(intmo, "FileName"), ""))) And Not IfNull(.GetRowCellValue(intmo, "FilePath"), "").ToString.Equals("") Then
                        '    DocStr = IfNull(.GetRowCellValue(intmo, "FilePath"), "") & "|" & _
                        '             IfNull(.GetRowCellValue(intmo, "FileName"), "")
                        '    count = count + 1
                        '    DocumentList.Add(New Dictionary(Of Integer, String)() From {{count, DocStr}})
                        'End If

                        'If .GetRowCellValue(intmo, "FPathEdited") Then
                        '    Call LinkDocument(.GetRowCellValue(intmo, "FilePath"), var_crewid, CONST_FILETAG, var_dateissue_s & intmo)
                        'End If
                    End If
                Next
                Try
                    MPSDB.RunSqls(query)
                Catch ex As Exception
                    ret = False
                End Try
                CloseCustomLoadScreen()
            End With
            MsgBox("Record(s) saved.", vbInformation)
            repBtnBrowse.Buttons(0).Enabled = False
            closeConn()
        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    Function delete_image(Optional recordOnly As Boolean = False, Optional ByRef errmsg As String = "") As Boolean
        Dim ret As Boolean = True, LastUpdatedBy As String = ""

        ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Deleting Document...")

        With Me.viewImages

            If CallFromService Then
                Try
                    If Not recordOnly Then
                        Kill(GenerateCrewFilePath(.GetRowCellValue(.FocusedRowHandle, "FilePath")))
                    End If

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Activity Documents", 0, System.Environment.MachineName, .GetRowCellValue(.FocusedRowHandle, "VslName") & " \ " & var_dateissue & " \ " &
                                                                         CleanInput(.GetRowCellValue(.FocusedRowHandle, "Description")).ToString.Replace("'", "''"), "Activity Document", var_crewid)
                    clsAudit.saveAuditPreDelDetails("tblDocImage", .GetRowCellValue(.FocusedRowHandle, "DocImgPKey"), LastUpdatedBy) 'neil

                    MPSDB.RunSql("Delete from tblDocImage where PKey ='" & .GetRowCellValue(.FocusedRowHandle, "DocImgPKey") & "'")
                Catch ex As Exception
                    ret = False
                    errmsg = ex.Message
                End Try
            Else
                clsActAct.deleteDocs(.GetRowCellValue(.FocusedRowHandle, "FKeyIDNbr"), .GetRowCellValue(.FocusedRowHandle, "Description"))
                .DeleteRow(.FocusedRowHandle)
                'dt.AcceptChanges()
            End If

            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Activity Documents", 0, System.Environment.MachineName, .GetRowCellValue(.FocusedRowHandle, "VslName") & " \ " & var_dateissue & " \ " & _
            '                                            CleanInput(.GetRowCellValue(.FocusedRowHandle, "Description")).ToString.Replace("'", "''"), "Activity Document", var_crewid)
            'clsAudit.saveAuditPreDelDetails("tblDocImage", .GetRowCellValue(.FocusedRowHandle, "DocImgPKey"), LastUpdatedBy) 'neil
            'MPSDB.RunSql("Delete from tblDocImage where PKey ='" & .GetRowCellValue(.FocusedRowHandle, "DocImgPKey") & "'")
        End With

        CloseCustomLoadScreen()

        Return ret
    End Function

    'Private Function GetFilePathFileName(xRowHandle As Integer, view As DevExpress.XtraGrid.Views.Grid.GridView) As String
    '    Dim retval As String = "NULL"
    '    Dim filePath As Object = "", FileName As String = "NULL"

    '    With view
    '        If Not .GetRowCellValue(xRowHandle, "FilePath").Equals(System.DBNull.Value) Then
    '            If Not Trim(.GetRowCellValue(xRowHandle, "FilePath")).Equals("") Then
    '                filePath = Trim(.GetRowCellValue(xRowHandle, "FilePath"))
    '                retval = "'" & Trim(.GetRowCellValue(xRowHandle, "FileName")) & "'"
    '            End If
    '        Else
    '            retval = "NULL"
    '        End If
    '    End With
    '    Return retval
    'End Function

    Public Function insertActivityDoc(FKeyActivity As String,
                                        FKeyIDNbr As String,
                                        DateIssue As Date,
                                        DateExpiry As Date,
                                        FileTag As String,
                                        ByRef sRetLogPKey As String,
                                        Optional dDateUpdated As Date = Nothing,
                                        Optional LastUpdatedBy As String = "",
                                        Optional closeconn As Boolean = False
                                                                ) As String

        Dim sRetString As String = ""
        'Dim sqlConn As New SqlClient.SqlConnection

        Dim sqlComm As New SqlCommand()

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                sRetString = "sql connection is nothing"
            Else

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "SP_addActivityDoc"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("FKeyActivity", FKeyActivity)
                sqlComm.Parameters.AddWithValue("FKeyIDNbr", FKeyIDNbr)
                If DateIssue = Nothing Then
                    'sqlComm.Parameters.AddWithValue("DateIssue", DBNull.Value)
                Else
                    sqlComm.Parameters.AddWithValue("DateIssue", DateIssue)
                End If
                If DateExpiry = Nothing Then
                    'sqlComm.Parameters.AddWithValue("DateExpiry", DBNull.Value)
                Else
                    sqlComm.Parameters.AddWithValue("DateExpiry", DateExpiry)
                End If
                sqlComm.Parameters.AddWithValue("FileTag", FileTag)
                If dDateUpdated = Nothing Then
                    ' sqlComm.Parameters.AddWithValue("DateUpdated", DBNull.Value)
                Else
                    sqlComm.Parameters.AddWithValue("DateUpdated", dDateUpdated)
                End If

                If LastUpdatedBy = Nothing Then
                    sqlComm.Parameters.AddWithValue("LastUpdatedBy", DBNull.Value)
                Else
                    sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                End If

                sqlComm.Parameters.Add("insertedID", SqlDbType.NVarChar, 20)
                sqlComm.Parameters("insertedID").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    sRetLogPKey = sqlComm.Parameters("insertedID").Value
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        sRetString = sRetString & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If

            If closeconn Then
                sqlConn.Close()
            Else
            End If

        End Using

        Return sRetString
    End Function

    Function closeConn() As Boolean
        Dim ret As Boolean = True
        If sqlConn.State = ConnectionState.Open Then
            Try
                sqlConn.Close()
                ret = True
            Catch ex As Exception
                ret = False
            End Try
        End If
        Return ret
    End Function

    Private Sub cmdDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdDelete.ItemClick
        Dim desc As String, qans As Integer

        If viewImages.IsNewItemRow(viewImages.FocusedRowHandle) Then
            Exit Sub
        End If

        With Me.viewImages
            desc = .GetRowCellValue(.FocusedRowHandle, "Description")
        End With

        If viewImages.GetRowCellValue(viewImages.FocusedRowHandle, "DocImgPKey") Is DBNull.Value Then
            qans = MsgBox("Do you want to delete unsaved record " & desc & "?", vbQuestion + vbYesNo)
            If qans = vbYes Then
                viewImages.DeleteRow(viewImages.FocusedRowHandle)
            End If
            Exit Sub
        End If

        If Not desc Is Nothing Then
            qans = MsgBox("Do you want to delete " & desc & "?", vbQuestion + vbYesNo)

            If qans = MsgBoxResult.Yes Then
                Dim ermsg As String = ""
                Call delete_image(, ermsg)
                If ermsg <> "" Then
                    If MsgBox("Something went wrong. Cannot delete the document." & vbCrLf & _
                            ermsg & vbCrLf & vbCrLf & "Do you still want to delete the record pertaining to the document?", vbExclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ermsg = ""
                        Call delete_image(True, ermsg)
                        If ermsg <> "" Then
                            MsgBox("Something went wrong. Cannot delete the document." & vbCrLf & _
                           ermsg, vbExclamation)
                        End If
                    End If
                End If
            Else
            End If

            ReloadDSource()
            Me.gridImages.RefreshDataSource()
            Me.viewImages.RefreshData()
        End If
    End Sub

    Private Sub viewImages_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles viewImages.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub viewImages_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles viewImages.KeyDown
        If e.KeyCode = Keys.Escape Then
            If viewImages.IsDefaultState Then
                viewImages.CancelUpdateCurrentRow()
                'viewImages.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            ElseIf viewImages.IsEditing Then
                viewImages.HideEditor()
            End If
        End If
    End Sub

    Private Sub viewImages_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles viewImages.KeyPress

    End Sub

    Private Sub viewImages_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles viewImages.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ViewRowCellStyle(sender, e, "")
    End Sub

    Private Sub viewImages_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles viewImages.RowUpdated

    End Sub

    Private Sub viewImages_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles viewImages.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim Desc As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("Description")
        Dim colfilpath As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("FilePath")

        If (View.GetRowCellValue(e.RowHandle, Desc) = "" Or View.GetRowCellValue(e.RowHandle, Desc) Is Nothing) Then
            View.SetColumnError(Desc, "Invalid Description")
            e.Valid = False
        End If
        If (View.GetRowCellValue(e.RowHandle, colfilpath) Is DBNull.Value) Then
            View.SetColumnError(Desc, "No browsed file")
            e.Valid = False
        End If
    End Sub

    'Codes below from Document.vb
    Private Function LinkDocument(_SourceFile As String, _IDNbr As String, _FileTag As String,
                                  _DateIssue As String, Optional ByRef errmsg As String = "") As Boolean

        Dim ret As Boolean = True
        Dim strDir As String = ""
        Dim fileName As String = ""
        Dim fileExt As String = ""
        Dim fName As String = ""

        Try
            strDir = FOLDERDIRECTORY & "\" & _IDNbr & "\"
            fileExt = System.IO.Path.GetExtension(_SourceFile)
            fileName = _IDNbr & "_" & _FileTag & "_" & _DateIssue & fileExt
            fName = _IDNbr & "_" & _FileTag & "_" & _DateIssue

            If (Not System.IO.Directory.Exists(strDir)) Then
                System.IO.Directory.CreateDirectory(strDir)
            End If

            If (System.IO.File.Exists(strDir & "\" & fileName)) Then
                replaceCrewDoc(_SourceFile, fName)
            Else
                Dim fP As String = ""
                fP = GenerateCrewFilePath(fName)
                If System.IO.File.Exists(fP) Then
                    Kill(fP)
                End If
                clsDoc.ExportCrewDocToPdf(_SourceFile, _IDNbr, _FileTag, _DateIssue)
            End If
        Catch ex As Exception
            ret = False
            errmsg = ex.Message ' MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try

        Return ret
    End Function

    Private Sub frmActivityDocs_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If Me.viewImages.IsEditing Then
        '    e.Cancel = True
        'End If
        '  If Me.viewImages.State Then
        'MsgBox(Me.viewImages.State)
        'e.Cancel = True
        '  End If

        'Dim dtchanges As New DataTable
        '' If dt.DataSet.HasChanges > 0 Then
        'viewImages.PostEditor()
        'viewImages.CloseEditForm()
        'viewImages.UpdateCurrentRow()
        'dtchanges = dt.GetChanges
        'If Not dtchanges Is Nothing Then
        '    'MsgBox(dtchanges.Rows.Count)
        '    'If dt.HasErrors Then
        '    'Else
        '    If MsgBox("Would you like to Cancel changes and close the form?", vbExclamation + vbYesNo) = vbNo Then
        '        e.Cancel = True
        '    End If
        '    'End If
        'End If

        If isThereAChange() Then
            If MsgBox("Would you like to Cancel changes and close the form?", vbExclamation + vbYesNo) = vbNo Then
                e.Cancel = True
            End If
        Else

        End If

        If viewImages.HasColumnErrors Then
            If MsgBox("Would you like to Cancel changes and close the form?", vbExclamation + vbYesNo) = vbNo Then
                e.Cancel = True
            End If
        End If
        'End If

        BRECORDUPDATEDs = False
    End Sub

    Function alreadyInList(Desc As String) As Boolean
        Dim ret As Boolean = False
        With viewImages
            For a As Integer = 0 To .RowCount - 1
                If .GetRowCellDisplayText(a, "Description") = Desc Then
                    ret = True
                    Exit For
                End If
            Next
        End With
        Return ret
    End Function

    Function isThereAChange() As Boolean
        Dim ret As Boolean = False

        Dim dtchanges As New DataTable
        ' If dt.DataSet.HasChanges > 0 Then
        viewImages.PostEditor()
        viewImages.CloseEditForm()
        viewImages.UpdateCurrentRow()
        If Not CallFromService Then
            'dt.AcceptChanges()
        End If
        dtchanges = dt.GetChanges
        If Not dtchanges Is Nothing Then
            ret = True
        Else

        End If

        Return ret
    End Function

    Private Sub ViewData()
        '\\\code from biodata with some modification
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

        view = Me.viewImages

        If view.RowCount > 0 Then
            ShowCustomLoadScreen(GetType(MPS4.Waitform), , "loading...")

            Dim filePath As String = ""


            If Not IsNothing(view) Then
                'Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = view.GetDetailView(view.FocusedRowHandle, 0)
                Dim fName As String = ""

                'If Not IsNothing(vw) Then
                'fName = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "FilePath"), "")
                fName = IfNull(view.GetRowCellValue(view.FocusedRowHandle, "FilePath"), "")
                'End If

                If Not fName.Equals("") Then

                    If CallFromService Then
                        filePath = GenerateCrewFilePath(fName)
                        If filePath <> "" Then
                            Try
                                System.Diagnostics.Process.Start(filePath)
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
                            End Try
                        End If
                    Else
                        Try
                            System.Diagnostics.Process.Start(fName)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
                        End Try
                    End If

                Else
                    MsgBox("No files selected.", vbExclamation)
                End If
            End If
        End If
        'Try
        '    System.Diagnostics.Process.Start(filePath)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        'End Try
        CloseCustomLoadScreen()
    End Sub

    Private Sub cmdView_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdView.ItemClick

        Call ViewData()

    End Sub

    Private Sub frmActivityDocs_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub
End Class