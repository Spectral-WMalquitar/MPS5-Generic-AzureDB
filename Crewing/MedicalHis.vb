Imports DevExpress.XtraGrid.Views.Base

Public Class MedicalHis

#Region "Easy Edit"
    Private FormName As String = "Medical History"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Dim cSql As String = ""
    Dim bIsMedHisUpd As Boolean = False
    Dim bIsMedStatUpd As Boolean = False
    Dim bIsMedCostUpd As Boolean = False
    Dim SelectedView As DevExpress.XtraGrid.Views.Grid.GridView = MedHisView

#Region "Overrides"

    Public Overrides Sub RefreshData()
        TableName = "tblMedHistory"
        MyBase.RefreshData()
        'MedHisView.Focus()
        Me.header.Text = "Medical History - " & strDesc
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditCaption(Name, "Add/Edit")
        SetDeleteCaption(Name, "Delete Medical History")
        SetPrintListCaption(Name, "Print Biodata")
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SelectedView = MedHisView
        bIsMedHisUpd = False
        bIsMedStatUpd = False
        bIsMedCostUpd = False
        isEditdable = False
        BRECORDUPDATEDs = False

        If Not bLoaded Then
            initControls()
            'LoadMedHis()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            'commented out by tony20190716 : adding must be disabled if blList (crew list) does not have any record
            'AddData()
            AllowEditing(Name, False)
            AllowDeletion(Name, False)
        Else
            LoadMedHis()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'for SUB DATA
            EditSubAllowGrid(MedHisView, False)
            EditSubAllowGrid(MedStatView, False)
            EditSubAllowGrid(MedCostView, False)
            EditSubAllowGrid(MedHisImgView, False)
            AllowDeletion(Name, False)
            MPS4Functions.AllowRepositoryBtnEdit(repBtnEditBrowse, False)

        End If
    End Sub

    Public Overrides Sub EditData()
        'MyBase.EditData()
        header.Focus()
        If bIsMedHisUpd Or bIsMedStatUpd Or bIsMedCostUpd Then Exit Sub
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, True)
        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, False)
        End If
        EditSubAllowGrid(MedHisView, isEditdable)
        EditSubAllowGrid(MedHisImgView, isEditdable)
        MPS4Functions.AllowRepositoryBtnEdit(repBtnEditBrowse, isEditdable)

        isEditdable = IIf(MedHisView.DataRowCount <> 0 And isEditdable, True, False)
        EditSubAllowGrid(MedStatView, isEditdable)
        EditSubAllowGrid(MedCostView, isEditdable)
    End Sub

    Public Overrides Sub SaveData()
        Me.header.Focus()
        If bIsMedHisUpd Then
            SaveMedHis()
        End If
        If bIsMedStatUpd Then
            SaveMedStat()
        End If
        If bIsMedCostUpd Then
            SaveMedCost()
        End If
        MsgBox(GetMessage("Saved"), MsgBoxStyle.Information, GetAppName)
        RefreshData()
    End Sub

    Public Overrides Sub DeleteData()
        header.Focus()
        If SelectedView.DataRowCount = 0 Then
            MsgBox("Nothing to delete", MsgBoxStyle.Information + vbOKOnly, GetAppName)
            Exit Sub
        End If

        If MsgBox("Are you sure want to delete the record?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            MsgBox(GetMessage("Deleted"), MsgBoxStyle.Information, GetAppName)
            If Not SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey") Is DBNull.Value Then

                If SelectedView.Name = "MedHisView" Then

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, SelectedView.GetRowCellDisplayText(SelectedView.FocusedRowHandle, "FKeyMedStatus"), FormName, strID) 'neil	'tony20160719
                    Dim cDataDescription = SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "Diagnosis").ToString.Replace("'", "''") & " / " & SelectedView.GetRowCellDisplayText(SelectedView.FocusedRowHandle, "FKeyMedStatus").ToString.Replace("'", "''")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical History", 0, System.Environment.MachineName, cDataDescription, FormName, strID)
                    'clsAudit.saveAuditPreDelDetails(SelectedView.Name, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    clsAudit.saveAuditPreDelDetails("tblMedHistory", SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblMedHistory", _
                        "PKey IN ('" & SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Crew Data - " & FormName & " >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & ">", _
                        GetUserName())
                    '-->
                    DeleteMedical("tblMedHistory", SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"))
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    MPS4Functions.AttachDocument.DeleteAttachDoc(MedHisView, MedHisImgView.LevelName, strID)
                ElseIf SelectedView.Name = "MedStatView" Then

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "Status"), FormName, strID) 'neil	'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical History - Status Monitoring", 0, System.Environment.MachineName, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "Status").ToString.Replace("'", "''"), FormName, strID)

                    'clsAudit.saveAuditPreDelDetails(SelectedView.Name, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    clsAudit.saveAuditPreDelDetails("tblMedStatusMonitor", SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblMedStatusMonitor", _
                        "PKey IN ('" & SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Crew Data - " & FormName & " - Status Monitoring >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Status Monitoring>", _
                        GetUserName())
                    '-->
                    DeleteMedical("tblMedStatusMonitor", SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"))
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                ElseIf SelectedView.Name = "MedCostView" Then

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "Amount"), FormName, strID) 'neil	'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical History - Cost Monitoring", 0, System.Environment.MachineName, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "Amount") & " / " & SelectedView.GetRowCellDisplayText(SelectedView.FocusedRowHandle, "FKeyMedCostItem").ToString.Replace("'", "''"), FormName, strID)

                    'clsAudit.saveAuditPreDelDetails(SelectedView.Name, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    clsAudit.saveAuditPreDelDetails("tblMedCostMonitor", SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblMedCostMonitor", _
                        "PKey IN ('" & SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Crew Data - " & FormName & " - Cost Monitoring >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Cost Monitoring>", _
                        GetUserName())
                    '-->
                    DeleteMedical("tblMedCostMonitor", SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"))
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                ElseIf SelectedView.Name = "MedHisImgView" Then

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "Amount"), FormName, strID) 'neil	'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical History Documents", 0, System.Environment.MachineName, SelectedView.GetRowCellDisplayText(SelectedView.FocusedRowHandle, "Description").ToString.Replace("'", "''"), FormName, strID)

                    'clsAudit.saveAuditPreDelDetails(SelectedView.Name, SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    clsAudit.saveAuditPreDelDetails("tblDocImage", SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblAttachDoc", _
                        "PKey IN ('" & MedHisView.GetRowCellValue(SelectedView.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Crew Data - " & FormName & " - Scanned Image >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Scanned Image>", _
                        GetUserName())
                    '-->
                    MPS4Functions.AttachDocument.DeleteAttachDoc(MedHisView, MedHisImgView.LevelName, strID)
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                End If
            Else
                SelectedView.DeleteSelectedRows()
                Exit Sub
            End If
        End If
        RefreshData()

    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim res As MsgBoxResult
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        res = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If MedHisView.HasColumnErrors() Or MedStatView.HasColumnErrors() Or MedCostView.HasColumnErrors() Then
                MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                flag = False
                ALLOWNEXTS = flag
            Else
                flag = True
                ALLOWNEXTS = flag
                SaveData()
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "ViewData"
                ViewFile(MPS4Functions.AttachDocument.GetAttachDocFilePath(MedHisGrid, strID))
        End Select
    End Sub

#End Region

#Region "Functions"
    Private Function GetMedHisID() As String
        Try
            If MedHisView.RowCount > 0 Then
                Return MedHisView.GetRowCellValue(MedHisView.FocusedRowHandle, "PKey")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub ValidateRequiredFields(ByRef sender As Object, ByRef e As ValidateRowEventArgs, colName As String, errMessage As String)
        'wlm - 20160808
        'fords - 20160831
        Dim view As GridView = TryCast(sender, GridView)
        Dim column As DevExpress.XtraGrid.Columns.GridColumn = view.Columns(colName)
        'If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
        If view.GetRowCellValue(e.RowHandle, column) Is DBNull.Value Or
            view.GetRowCellValue(e.RowHandle, column) Is Nothing Then
            'view.GetRowCellValue(e.RowHandle, column).ToString().Trim().Equals("") Then
            'e.Valid = False
            view.SetColumnError(column, errMessage)
            'view.FocusedColumn = view.VisibleColumns(0)
        Else
            view.SetColumnError(column, "")
            'e.Valid = True
        End If
        'End If
    End Sub

#End Region

#Region "Sub Events"
    Private Sub initControls()
        LayoutControl1.AllowCustomization = False
        repVessel.DataSource = MPSDB.CreateTable("SELECT *, CASE WHEN VslStat = 1 THEN '' ELSE 'Inactive' END as VesselStatus FROM dbo.tblAdmVsl ORDER BY Name") 'SortCode, Name")
        repMedStatus.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmMedStat WHERE StatType = 1 ORDER BY SortCode, Name")
        repCurr.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmCurr ORDER BY ref desc, SortCode asc, Name asc")
        repItems.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmPICst ORDER BY SortCode, Name")
        repChargeType.DataSource = getChargeType()
        EditSubAllowGrid(MedHisView, False)
        EditSubAllowGrid(MedStatView, False)
        EditSubAllowGrid(MedCostView, False)
        EditSubAllowGrid(MedHisImgView, False)
        MPS4Functions.AttachDocument.InitBrowseButton(repBtnEditBrowse)

        clsAudit.propSQLConnStr = DB.GetConnectionString
    End Sub

    Private Sub LoadMedHis()
        MPS4Functions.AttachDocument.LoadViewWithDocImage(MedHisGrid, MedHisView, MedHisImgView, _
                          "SELECT *, 0 as Edited FROM dbo.tblMedHistory WHERE FKeyIDNbr = '" & strID & "' ORDER BY DateStatus DESC", _
                          "SELECT sub.*, 0 as Edited, '' AS tempFilePath FROM dbo.tblAttachDoc sub INNER JOIN tblMedHistory main ON main.PKey = sub.FKeyParent WHERE main.FKeyIDNbr = '" & strID & "' AND sub.TableName = 'tblMedHistory'", _
                  "PKey", "FKeyParent")
        LoadMedHisSubs()
    End Sub

    Private Sub LoadMedHisSubs()
        MedStatGrid.DataSource = DB.CreateTable("SELECT *, 0 as Edited FROM dbo.tblMedStatusMonitor WHERE FKeyMedHistory = '" & GetMedHisID() & "' ORDER BY DateEntry DESC")
        MedCostGrid.DataSource = DB.CreateTable("SELECT *, 0 as Edited FROM dbo.tblMedCostMonitor WHERE FKeyMedHistory = '" & GetMedHisID() & "' ORDER BY DateEntry DESC")
    End Sub

    Private Sub SaveMedHis()
        With Me.MedHisView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellValue(i, "Diagnosis") & " / " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyMedStatus"), FormName, strID) 'neil   'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical History", 0, System.Environment.MachineName, .GetRowCellValue(i, "Diagnosis").ToString.Replace("'", "''") & " / " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyMedStatus").ToString.Replace("'", "''"), FormName, strID)

                    If CStr(IfNull(.GetRowCellValue(i, "PKey"), "")).Equals(CStr(i)) Then
                        'Use insert query
                        cSql = "INSERT INTO dbo.tblMedHistory " & _
                                  "(" & _
                                  "FKeyIDNbr, " & _
                                  "WorkRel, " & _
                                  "Diagnosis, " & _
                                  "DateAcq, " & _
                                  "FKeyVessel, " & _
                                  "IsPICase, " & _
                                  "PICaseRefNo, " & _
                                  "FKeyMedStatus, " & _
                                  "DateStatus, " & _
                                  "Remarks, " & _
                                  "PlaceAcq, " & _
                                  "LastUpdatedBy) " & _
                                  "VALUES ( " & _
                                  "'" & strID & "'," & _
                                  "" & Convert.ToInt32(.GetRowCellValue(i, "WorkRel")) & ", " & _
                                  "'" & .GetRowCellValue(i, "Diagnosis") & "', " & _
                                  "" & ChangeToSQLDate(.GetRowCellValue(i, "DateAcq")) & ", " & _
                                  "'" & .GetRowCellValue(i, "FKeyVessel") & "', " & _
                                  "" & Convert.ToInt32(.GetRowCellValue(i, "IsPICase")) & ", " & _
                                  "'" & .GetRowCellValue(i, "PICaseRefNo") & "', " & _
                                  "'" & .GetRowCellValue(i, "FKeyMedStatus") & "', " & _
                                  "" & ChangeToSQLDate(.GetRowCellValue(i, "DateStatus")) & ", " & _
                                  "'" & .GetRowCellValue(i, "Remarks") & "', " & _
                                  "'" & .GetRowCellValue(i, "PlaceAcq") & "', " & _
                                  "'" & LastUpdatedBy & "')"
                        DB.RunSql(cSql)
                    Else
                        'Use Update query
                        cSql = "UPDATE dbo.tblMedHistory SET " & _
                                  "WorkRel = " & Convert.ToInt32(.GetRowCellValue(i, "WorkRel")) & ", " & _
                                  "Diagnosis = '" & .GetRowCellValue(i, "Diagnosis") & "', " & _
                                  "DateAcq = " & ChangeToSQLDate(.GetRowCellValue(i, "DateAcq")) & ", " & _
                                  "FKeyVessel = '" & .GetRowCellValue(i, "FKeyVessel") & "', " & _
                                  "IsPICase = " & Convert.ToInt32(.GetRowCellValue(i, "IsPICase")) & ", " & _
                                  "PICaseRefNo = '" & .GetRowCellValue(i, "PICaseRefNo") & "', " & _
                                  "FKeyMedStatus = '" & .GetRowCellValue(i, "FKeyMedStatus") & "', " & _
                                  "DateStatus = " & ChangeToSQLDate(.GetRowCellValue(i, "DateStatus")) & ", " & _
                                  "Remarks = '" & .GetRowCellValue(i, "Remarks") & "', " & _
                                  "PlaceAcq = '" & .GetRowCellValue(i, "PlaceAcq") & "', " & _
                                  "LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                  "WHERE PKey = '" & .GetRowCellValue(i, "PKey") & "'"
                        DB.RunSql(cSql)
                    End If

                End If
            Next
            MPS4Functions.AttachDocument.SaveAttachDoc(MedHisView, MedHisImgView.LevelName, LastUpdatedBy, strID, strID, "MEDHIS", "DateAcq", "tblMedHistory")
        End With
    End Sub

    Private Sub SaveMedStat()
        With Me.MedStatView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyMedHistory") & " / " & .GetRowCellValue(i, "Status"), FormName, strID) 'neil 'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical History - Status Monitoring", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyMedHistory").ToString.Replace("'", "''") & " / " & .GetRowCellValue(i, "Status").ToString.Replace("'", "''"), FormName, strID)

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        'Use insert query
                        cSql = "INSERT INTO dbo.tblMedStatusMonitor " & _
                                  "(" & _
                                  "FKeyMedHistory, " & _
                                  "DateEntry, " & _
                                  "Status, " & _
                                  "Remarks, " & _
                                  "LastUpdatedBy, " & _
                                  "UserName, " & _
                                  "UserID) " & _
                                  "VALUES ( " & _
                                  "'" & .GetRowCellValue(i, "FKeyMedHistory") & "', " & _
                                  "" & ChangeToSQLDate(.GetRowCellValue(i, "DateEntry")) & ", " & _
                                  "'" & .GetRowCellValue(i, "Status") & "', " & _
                                  "'" & .GetRowCellValue(i, "Remarks") & "', " & _
                                  "'" & LastUpdatedBy & "', " & _
                                  "'" & USER_NAME & "', " & _
                                  "'" & USER_ID & "')"
                        DB.RunSql(cSql)
                    Else
                        'Use Update query
                        cSql = "UPDATE dbo.tblMedStatusMonitor SET " & _
                                  "DateEntry = " & ChangeToSQLDate(.GetRowCellValue(i, "DateEntry")) & ", " & _
                                  "Status = '" & .GetRowCellValue(i, "Status") & "', " & _
                                  "Remarks = '" & .GetRowCellValue(i, "Remarks") & "', " & _
                                  "UserName = '" & USER_NAME & "', " & _
                                  "UserID = '" & USER_ID & "', " & _
                                  "LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                  "WHERE PKey = '" & .GetRowCellValue(i, "PKey") & "'"
                        DB.RunSql(cSql)
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub SaveMedCost()
        With Me.MedCostView
            .CloseEditForm()
            .UpdateCurrentRow() 'test
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellValue(i, "Amount") & " / " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyMedCostItem"), FormName, strID) 'neil    'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Medical History - Cost Monitoring", 0, System.Environment.MachineName, .GetRowCellValue(i, "Amount") & " / " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyMedCostItem").ToString.Replace("'", "''"), FormName, strID)

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        'Use insert query
                        cSql = "INSERT INTO dbo.tblMedCostMonitor " & _
                                  "(" & _
                                  "FKeyMedHistory, " & _
                                  "FKeyCurr, " & _
                                  "Amount, " & _
                                  "FKeyMedCostItem, " & _
                                  "Place, " & _
                                  "Remarks, " & _
                                  "ChargeType, " & _
                                  "DateEntry, " & _
                                  "LastUpdatedBy) " & _
                                  "VALUES ( " & _
                                  "'" & .GetRowCellValue(i, "FKeyMedHistory") & "', " & _
                                  "'" & .GetRowCellValue(i, "FKeyCurr") & "', " & _
                                  "" & .GetRowCellValue(i, "Amount") & ", " & _
                                  "'" & .GetRowCellValue(i, "FKeyMedCostItem") & "', " & _
                                  "'" & .GetRowCellValue(i, "Place") & "', " & _
                                  "'" & .GetRowCellValue(i, "Remarks") & "', " & _
                                  "'" & .GetRowCellValue(i, "ChargeType") & "', " & _
                                  "" & ChangeToSQLDate(.GetRowCellValue(i, "DateEntry")) & ", " & _
                                  "'" & LastUpdatedBy & "')"
                        DB.RunSql(cSql)
                    Else
                        'Use Update query
                        cSql = "UPDATE dbo.tblMedCostMonitor SET " & _
                                  "FKeyCurr = '" & .GetRowCellValue(i, "FKeyCurr") & "', " & _
                                  "Amount = " & .GetRowCellValue(i, "Amount") & ", " & _
                                  "FKeyMedCostItem = '" & .GetRowCellValue(i, "FKeyMedCostItem") & "', " & _
                                  "Place = '" & .GetRowCellValue(i, "Place") & "', " & _
                                  "ChargeType = '" & .GetRowCellValue(i, "ChargeType") & "', " & _
                                  "DateEntry = " & ChangeToSQLDate(.GetRowCellValue(i, "DateEntry")) & ", " & _
                                  "Remarks = '" & .GetRowCellValue(i, "Remarks") & "', " & _
                                  "LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                  "WHERE PKey = '" & .GetRowCellValue(i, "PKey") & "'"
                        DB.RunSql(cSql)
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub DeleteMedical(TableName As String, PKey As String)
        DB.RunSql("DELETE FROM " & TableName & " WHERE PKey = '" & PKey & "'")
    End Sub

    Private Sub SubEnable(enable As Boolean)
        'MedStatGrid.Enabled = enable
        'MedCostGrid.Enabled = enable

        EditSubAllowGrid(MedStatView, enable)
        EditSubAllowGrid(MedCostView, enable)
    End Sub
#End Region

#Region "MedHisView Events"
    Private Sub MedHisView_FocusedRowChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MedHisView.FocusedRowChanged
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)


        If bIsMedStatUpd Or bIsMedCostUpd Then
            Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you made?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName)
            If res = MsgBoxResult.Yes Then
                SaveMedHis()
                SaveMedStat()
                SaveMedCost()
            End If
            RefreshData()
            'views.FocusedRowHandle = e.PrevFocusedRowHandle
        End If

        If e.FocusedRowHandle < 0 Then
            SubEnable(False)
        ElseIf (views.IsNewItemRow(e.FocusedRowHandle) Or CStr(views.GetRowCellValue(e.FocusedRowHandle, "PKey")).Equals(CStr(e.FocusedRowHandle))) Or Not isEditdable Then
            SubEnable(False)
        Else
            SubEnable(True)
        End If
        LoadMedHisSubs()

    End Sub

    Private Sub MedHisView_CellValueChanging(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MedHisView.CellValueChanging, MedHisImgView.CellValueChanging
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim parentView As DevExpress.XtraGrid.Views.Grid.GridView = views.ParentView
        BRECORDUPDATEDs = True
        bIsMedHisUpd = True
        If e.Column.FieldName.ToString <> "Edited" Then
            With views
                .SetRowCellValue(e.RowHandle, "Edited", True)
                If views.Name = MedHisImgView.Name Then
                    parentView.SetRowCellValue(.SourceRowHandle, "Edited", True)
                End If
            End With
        End If
    End Sub

    Private Sub MedHisView_RowCellStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MedHisView.RowCellStyle
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If views.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") And views.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = views.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub MedHisView_ValidateRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MedHisView.ValidateRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        header.Focus()
        With views
            AllowSaving(Name, False)
            e.Valid = False

            ValidateRequiredFields(sender, e, "WorkRel", "Is Medical Work Related?")
            ValidateRequiredFields(sender, e, "Diagnosis", "Please enter Diagnosis")
            ValidateRequiredFields(sender, e, "DateAcq", "Please enter Date Acquired.")
            ValidateRequiredFields(sender, e, "PlaceAcq", "Please enter Place Acquired.")
            'ValidateRequiredFields(sender, e, "FKeyVessel", "Please select Vessel.")
            'ValidateRequiredFields(sender, e, "IsPICase", "Is P&I Case?")
            ValidateRequiredFields(sender, e, "FKeyMedStatus", "Please select Medical Status.")
            ValidateRequiredFields(sender, e, "DateStatus", "Please enter Status Date")

            'Clear Errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With

    End Sub

    Private Sub MedHisView_FocusedColumnChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles MedHisView.FocusedColumnChanged
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'Clear Errors
        With views
            .ClearColumnErrors()
        End With
    End Sub

    Private Sub MedHisView_GotFocus(sender As System.Object, e As System.EventArgs) Handles MedHisView.GotFocus, MedHisImgView.GotFocus
        SelectedView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If SelectedView.Name = "MedHisView" Then
            SetDeleteCaption(Name, "Delete Medical History")
        Else
            SetDeleteCaption(Name, "Delete Medical History Document Image")
        End If
    End Sub

    Private Sub MedHisView_InitNewRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MedHisView.InitNewRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        BRECORDUPDATEDs = True
        bIsMedHisUpd = True
        With views
            .SetRowCellValue(e.RowHandle, "WorkRel", False)
            .SetRowCellValue(e.RowHandle, "IsPICase", False)
            .SetRowCellValue(e.RowHandle, "FKeyMedStatus", "SYSMEDONGOING")
            .SetRowCellValue(e.RowHandle, "DateStatus", DateTime.Now)
            .SetRowCellValue(e.RowHandle, "PKey", views.RowCount)
        End With
        SubEnable(False)
    End Sub

    Private Sub MedHisView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MedHisView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub
#End Region

#Region "MedStatView Events"
    Private Sub MedStatView_CellValueChanging(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MedStatView.CellValueChanging
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        BRECORDUPDATEDs = True
        bIsMedStatUpd = True
        If e.Column.FieldName.ToString <> "Edited" Then
            With views
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub MedStatView_RowCellStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MedStatView.RowCellStyle
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If views.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") And views.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = views.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub MedStatView_ValidateRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MedStatView.ValidateRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        header.Focus()
        With views
            AllowSaving(Name, False)
            e.Valid = False

            ValidateRequiredFields(sender, e, "DateEntry", "Please enter Date.")
            ValidateRequiredFields(sender, e, "Status", "Please select Status.")

            'Clear Errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub

    Private Sub MedStatView_FocusedColumnChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles MedStatView.FocusedColumnChanged
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'Clear Errors
        With views
            .ClearColumnErrors()
        End With
    End Sub

    Private Sub MedStatView_GotFocus(sender As System.Object, e As System.EventArgs) Handles MedStatView.GotFocus
        SetDeleteCaption(Name, "Delete Medical Status")
        SelectedView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    End Sub

    Private Sub MedStatView_InitNewRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MedStatView.InitNewRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        BRECORDUPDATEDs = True
        bIsMedStatUpd = True
        With views
            .SetRowCellValue(e.RowHandle, "FKeyMedHistory", GetMedHisID)
            .SetRowCellValue(e.RowHandle, "DateEntry", System.DateTime.Now)
            .SetRowCellValue(e.RowHandle, "UserID", USER_ID)
            .SetRowCellValue(e.RowHandle, "UserName", USER_NAME)
        End With
    End Sub

    Private Sub MedStatView_InvalidRowException(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MedStatView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub
#End Region

#Region "MedCostView Events"
    Private Sub MedCostView_CellValueChanging(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MedCostView.CellValueChanging
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        BRECORDUPDATEDs = True
        bIsMedCostUpd = True
        If e.Column.FieldName.ToString <> "Edited" Then
            With views
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub MedCostView_RowCellStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MedCostView.RowCellStyle
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If views.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") And views.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = views.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub MedCostView_ValidateRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MedCostView.ValidateRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        header.Focus()
        With views
            AllowSaving(Name, False)
            e.Valid = False

            ValidateRequiredFields(sender, e, "FKeyCurr", "Please select Currency.")
            ValidateRequiredFields(sender, e, "Amount", "Please enter Amount.")
            ValidateRequiredFields(sender, e, "FKeyMedCostItem", "Please select Item.")
            ValidateRequiredFields(sender, e, "Place", "Please enter Place.")
            ValidateRequiredFields(sender, e, "DateEntry", "Please enter Date.")

            'Clear Errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub

    Private Sub MedCostView_FocusedColumnChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles MedCostView.FocusedColumnChanged
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'Clear Errors
        With views
            .ClearColumnErrors()
        End With
    End Sub

    Private Sub MedCostView_GotFocus(sender As System.Object, e As System.EventArgs) Handles MedCostView.GotFocus
        SetDeleteCaption(Name, "Delete Medical Cost")
        SelectedView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    End Sub

    Private Sub MedCostView_InitNewRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MedCostView.InitNewRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        BRECORDUPDATEDs = True
        bIsMedCostUpd = True
        With views
            .SetRowCellValue(e.RowHandle, "FKeyMedHistory", GetMedHisID)
            .SetRowCellValue(e.RowHandle, "DateEntry", DateSerial(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day))
        End With
    End Sub

    Private Sub MedCostView_InvalidRowException(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MedCostView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub
#End Region

#Region "ClearLookUpEdit Event"

    Private Sub repItem_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repMedStatus.ButtonClick, repDate.ButtonClick, repVessel.ButtonClick, repDateStat.ButtonClick, repCurr.ButtonClick, repItems.ButtonClick, repChargeType.ButtonClick, repDateCost.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

#End Region

#Region "MedHisImgView Events"

    Private Sub MedHisImgView_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MedHisImgView.MouseDown
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
    End Sub

    Private Sub MedHisImgView_LostFocus(sender As System.Object, e As System.EventArgs) Handles MedHisImgView.LostFocus
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
    End Sub

    Private Sub MedHisImgView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MedHisImgView.ValidateRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        header.Focus()
        With views
            AllowSaving(Name, False)
            e.Valid = False

            Dim view As GridView = TryCast(sender, GridView)
            Dim column As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("tempFilePath")
            If view.GetRowCellValue(e.RowHandle, column) Is DBNull.Value Or
                view.GetRowCellValue(e.RowHandle, column) Is Nothing Then
                view.SetColumnError(view.Columns("Description"), "Please select a file.")
            Else
                view.SetColumnError(view.Columns("Description"), "")
            End If

            'Clear Errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub

    Private Sub MedHisImgView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MedHisImgView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MedHisImgView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MedHisImgView.FocusedRowChanged
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'Clear Errors
        With views
            .ClearColumnErrors()
        End With
    End Sub

#End Region

End Class
