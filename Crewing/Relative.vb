Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class Relative
    Dim is_clicked As Boolean = False, photo_changed As Boolean = False, photo_path As String
    Dim FormName As String = "Crew Relative"
    'Dim LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Dim clsgridflout As New clsGridFlyOut
    Dim stopnaba As Boolean = False

    'initialize
    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        Me.repCntry.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.CntryList ORDER BY Name ASC")
        Me.repRel.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRel ORDER BY Name ASC")
        Me.repSexCode.DataSource = GetSex()
        BRECORDUPDATEDs = False

        clsAudit.propSQLConnStr = DB.GetConnectionString
    End Sub

    Private Sub LoadSub()
        'BRECORDUPDATEDs = False
        Me.MainGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited, CAST(0 AS Bit) SeaAddr FROM dbo.frmCrew_Allottee WHERE FKeyIDNbr='" & strID & "' ORDER BY LName ASC,FName ASC")
        Me.MainView.OptionsEditForm.CustomEditFormLayout = New RelativeSub(strID)
    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblAllottee"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Crew Relative - " & strDesc)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteCaption(Name, "Delete Relatives")
        SetPrintListCaption(Name, "Print Biodata")
        AllowDeletion(Name, False)
        SetEditCaption(Name, "Add/Edit")
        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            'commented out by tony20190716 : adding must be disabled if blList (crew list) does not have any record
            'AddData()
            AllowEditing(Name, False)
            AllowDeletion(Name, False)
        Else
            EditSubAllowGrid(Me.MainView, False)
            LoadSub()
            BRECORDUPDATEDs = False
        End If
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            AllowDeletion(Name, True)
            'MainView Sub
            EditSubAllowGrid(Me.MainView, isEditdable)
        Else
            'MyBase.EditData()
            AllowDeletion(Name, False)
            'MainView Sub
            EditSubAllowGrid(Me.MainView, isEditdable)
        End If
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {}) Then

            With Me.MainView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Relative", 0, System.Environment.MachineName, CleanInput(Trim(IfNull(.GetRowCellValue(i, "LName"), ""))).ToString.Replace("'", "''") & ", " & _
                                       CleanInput(Trim(IfNull(.GetRowCellValue(i, "FName"), ""))).ToString.Replace("'", "''") & _
                                      " " & CleanInput(Trim(IfNull(.GetRowCellValue(i, "MName"), ""))).ToString.Replace("'", "''"), FormName, strID) 'neil

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            type = "Inserted"
                            query.Add("INSERT INTO dbo." & TableName & " ( " & _
                                      "FKeyIDNbr" & _
                                      ",LName" & _
                                      ",FName" & _
                                      ",MName" & _
                                      ",Notify" & _
                                      ",Benef" & _
                                      ",FKeyRel" & _
                                      ",Addr" & _
                                      ",FKeyCntry" & _
                                      ",Phone" & _
                                      ",Telefax" & _
                                      ",Email" & _
                                      ",DOB" & _
                                      ",SexCode" & _
                                      ",LastUpdatedBy)" & _
                                      " VALUES(" & _
                                      "'" & strID & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "LName"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "FName"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "MName"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Notify"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Benef"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "FKeyRel"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Addr"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "FKeyCntry"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Phone"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Telefax"), ""))) & "'" & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Email"), ""))) & "'" & _
                                      "," & ChangeToSQLDate(.GetRowCellValue(i, "DOB")) & _
                                      ",'" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "SexCode"), ""))) & "'" & _
                                      ",'" & LastUpdatedBy & "')")
                        Else
                            type = "Updated"
                            query.Add("UPDATE dbo." & TableName & " SET " & _
                                      "LName='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "LName"), ""))) & "'" & _
                                      ", FName='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "FName"), ""))) & "'" & _
                                      ", MName='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "MName"), ""))) & "'" & _
                                      ", Notify='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Notify"), ""))) & "'" & _
                                      ", Benef='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Benef"), ""))) & "'" & _
                                      ", FKeyRel='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "FKeyRel"), ""))) & "'" & _
                                      ", Addr='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Addr"), ""))) & "'" & _
                                      ", FKeyCntry='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "FKeyCntry"), ""))) & "'" & _
                                      ", Phone='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Phone"), ""))) & "'" & _
                                      ", Telefax='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Telefax"), ""))) & "'" & _
                                      ", Email='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "Email"), ""))) & "'" & _
                                      ", DOB=" & ChangeToSQLDate(.GetRowCellValue(i, "DOB")) & _
                                      ", SexCode='" & CleanInput(Trim(IfNull(.GetRowCellValue(i, "SexCode"), ""))) & "'" & _
                                      ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                      ", DateUpdated=(getdate())" & _
                                      "WHERE FKeyIDNbr='" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next
            End With
            info = DB.RunSqls(query)
            If info Then
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                RefreshData()
            End If
        End If

    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If MainView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
                'Else
                '    If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, showMsg) Then
                '        If bAddMode Then
                '            'If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                '            '    flag = False
                '            '    ALLOWNEXTS = flag
                '            'Else
                '            flag = True
                '            ALLOWNEXTS = flag
                '            SaveData() '
                '            'End If
                '        Else
                '            If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & strID & "'") Then
                '                flag = False
                '                ALLOWNEXTS = flag
            Else
                flag = True
                ALLOWNEXTS = flag
                SaveData() '
            End If
            '        End If
            '    Else
            '        flag = False
            '        ALLOWNEXTS = flag
            '    End If
            'End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    'Delete
    Public Overrides Sub DeleteData()
        If Not IsNothing(focusedView) Then
            DeleteSubTable()
        End If

        'If IsNothing(focusedView) Then
        '    DeleteMain()
        'Else
        '    DeleteSubTable()
        'End If
    End Sub

    Private Sub DeleteMain()
        'MyBase.DeleteData()
        'Dim info As Boolean = False
        'If MsgBox("Are you sure, you want to delete Crew '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
        '    If DB.isDeleteAllowed("tblCrewInfo", strID) Then 'Check if the record is in use or a system data
        '        info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
        '        If info Then
        '            ClearFields(Me.LayoutControl1.Root, False)
        '            MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
        '            RefreshData()
        '            blList.RefreshData()
        '            BRECORDUPDATEDs = False
        '        End If
        '    Else
        '        MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
        '        BRECORDUPDATEDs = False
        '    End If
        'End If
    End Sub

    Private Sub DeleteSubTable()

        Dim subDesc As String = MainView.GetFocusedRowCellDisplayText("LName") & ", " & MainView.GetFocusedRowCellDisplayText("FName") & " " & MainView.GetFocusedRowCellDisplayText("MName")
        If MsgBox("Are you sure want to delete '" & subDesc & "' ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey"), "") <> "" Then

                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil	'tony20160719
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Relative", 0, System.Environment.MachineName, CleanInput(Trim(IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "LName"), ""))).ToString.Replace("'", "''") & ", " & _
                                       CleanInput(Trim(IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "FName"), ""))).ToString.Replace("'", "''") & _
                                      " " & CleanInput(Trim(IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "MName"), ""))).ToString.Replace("'", "''"), FormName, strID) 'neil
                clsAudit.saveAuditPreDelDetails("tblAllottee", MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    TableName, _
                    "PKey IN ('" & MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey") & "')", _
                    "<< Delete Crew Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                DB.RunSql("DELETE FROM dbo.tblAllottee WHERE PKey='" & MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey") & "'AND FKeyIDNbr='" & strID & "'")
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
            MainView.DeleteRow(MainView.FocusedRowHandle)
            If MainView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
        End If
    End Sub

#Region "Relative"
    Dim checkedRowIndex As Integer = -1

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        'Only One Relative is allowed to be notified in Case of Emergency
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                If e.Column.FieldName.Equals("SeaAddr") Then
                    GetCrewAddr(strID)
                End If
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With

    End Sub

    Private Sub MainView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyIDNbr"), strID)
        SubAddMode = True

    End Sub

    Private Sub MainView_GotFocus(sender As Object, e As System.EventArgs) Handles MainView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        focusedView = view
        If isEditdable Or bAddMode Then
            'neil focusedView = view
            SetDeleteCaption(Name, "Delete Relative")
            'Else
            '    focusedView = Nothing
            '    SetDeleteCaption(Name, "Delete Crew")
        End If
    End Sub

    Private Sub MainView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MainView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MainView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            MainView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim strRequiredFieldName As String = "" 'Required FieldsNames
        strRequiredFieldName = "LName;FName;FKeyRel;Addr;FKeyCntry;SexCode;"
        With view
            If InStr(1, strRequiredFieldName, e.Column.FieldName) > 0 Then
                e.Appearance.BackColor = REQUIRED_COLOR
                If .GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
                    e.Appearance.BackColor = SEL_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") And .FocusedRowHandle = e.RowHandle Then
                    e.Appearance.BackColor = EDITED_FOCUSED_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") Then
                    e.Appearance.BackColor = EDITED_COLOR
                ElseIf e.RowHandle = .FocusedRowHandle Then
                    e.Appearance.BackColor = SEL_COLOR
                End If
            ElseIf .IsRowSelected(e.RowHandle) Then
                e.Appearance.BackColor = SEL_COLOR
                e.Appearance.ForeColor = System.Drawing.Color.Black
            End If
        End With
    End Sub

    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow, MainView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim LName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("LName")
        Dim FName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FName")
        Dim FKeyRel As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyRel")
        Dim Addr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Addr")
        Dim SexCode As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("SexCode")
        Dim FKeyCntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")


        With view
            AllowSaving(Name, False)
            'LastName
            If .GetRowCellValue(e.RowHandle, LName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, LName) Is Nothing Or IfNull(.GetRowCellValue(e.RowHandle, LName), "").Equals("") Then
                .SetColumnError(LName, "Please enter Last Name.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(LName, "")
            End If

            'First Name
            If .GetRowCellValue(e.RowHandle, FName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FName) Is Nothing Or IfNull(.GetRowCellValue(e.RowHandle, FName), "").Equals("") Then
                .SetColumnError(FName, "Please enter Validity.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(FName, "")
            End If

            'FKeyRel
            If .GetRowCellValue(e.RowHandle, FKeyRel) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyRel) Is Nothing Or IfNull(.GetRowCellValue(e.RowHandle, FKeyRel), "").Equals("") Then
                .SetColumnError(FKeyRel, "Please select relationship.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(FKeyRel, "")
            End If

            'FKeyRel
            If .GetRowCellValue(e.RowHandle, Addr) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Addr) Is Nothing Or IfNull(.GetRowCellValue(e.RowHandle, Addr), "").Equals("") Then
                .SetColumnError(Addr, "Please enter Address.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(Addr, "")
            End If
            'SexCode
            If .GetRowCellValue(e.RowHandle, SexCode) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, SexCode) Is Nothing Or IfNull(.GetRowCellValue(e.RowHandle, SexCode), "").Equals("") Then
                .SetColumnError(SexCode, "Please select Gender.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(SexCode, "")
            End If
            'FKeyCntry
            If .GetRowCellValue(e.RowHandle, FKeyCntry) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyCntry) Is Nothing Or IfNull(.GetRowCellValue(e.RowHandle, FKeyCntry), "").Equals("") Then
                .SetColumnError(FKeyCntry, "Please select Country.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(FKeyCntry, "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            Else
                BRECORDUPDATEDs = True
            End If
        End With

    End Sub

    'for the Customized Popup Edit Form
    Private Sub MainView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles MainView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Relative"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
        e.EditForm.Icon = frmCrewMain.Icon
        e.EditForm.ShowIcon = True
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

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MainView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub GetCrewAddr(CrewId As String)
        Dim strCrewAddr As String = "", strCrewCntry As String = ""
        With MainView
            If CBool(.GetRowCellValue(.FocusedRowHandle, "SeaAddr")) Then
                strCrewAddr = MPSDB.DLookUp("Addr", "CrewAddrList", "", "FKeyIDNbr='" & strID & "' AND AddrStat=1")
                strCrewCntry = MPSDB.DLookUp("FKeyCntry", "CrewAddrList", "", "FKeyIDNbr='" & strID & "' AND AddrStat=1")

                If strCrewAddr.Equals("") Then
                    MsgBox("No Active Crew Address.", MsgBoxStyle.Information, GetAppName())
                    .SetRowCellValue(.FocusedRowHandle, "Addr", System.DBNull.Value)
                    .SetRowCellValue(.FocusedRowHandle, "FKeyCntry", System.DBNull.Value)

                Else
                    .SetRowCellValue(.FocusedRowHandle, "Addr", strCrewAddr)
                    .SetRowCellValue(.FocusedRowHandle, "FKeyCntry", strCrewCntry)
                End If
            Else
                .SetRowCellValue(.FocusedRowHandle, "Addr", System.DBNull.Value)
                .SetRowCellValue(.FocusedRowHandle, "FKeyCntry", System.DBNull.Value)
            End If
        End With


    End Sub

#End Region

    Private Sub MainGrid_Click(sender As Object, e As System.EventArgs) Handles MainGrid.Click
        stopnaba = True
    End Sub


    Private Sub MainGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseMove
        Application.DoEvents()
        Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub MainView_ShownEditor(sender As Object, e As System.EventArgs) Handles MainView.ShownEditor
        stopnaba = True
    End Sub
End Class
