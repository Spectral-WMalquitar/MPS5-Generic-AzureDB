Public Class WageScaleCalendar

#Region "Base Items"

    Private FormName As String = "Admin Wage Scale Calendar"
    'Private LastUpdatedBy As String = GetUserName() & "<" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil


    Dim ctrValidate As DevExpress.XtraEditors.BaseEdit()

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        LayoutControl1.AllowCustomization = False
        cboType.Properties.DataSource = getCalType()
    End Sub

    Private Sub LoadSub()

    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblAdmWScaleCalendar"
        MyBase.RefreshData()
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteCaption(Name, "Delete Calendar")
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Wage Scale Calendar Details - " & strDesc)
        'strRequiredFields = "txtName;txtJan;txtFeb;txtMar;txtApr;txtMay;txtJun;txtJul;txtAug;txtSep;txtOct;txtNov;txtDec;"
        'strRequiredFields = "txtName;txtJan;txtFeb;txtMar;txtApr;txtMay;txtJun;txtJul;txtAug;txtSep;txtOct;txtNov;txtDec;"

        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            AddData()
        Else
            txtName.Text = IfNull(blList.GetFocusedRowData("Name"), "")
            cboType.EditValue = IfNull(blList.GetFocusedRowData("Type"), "0")
            txtJan.Text = IfNull(blList.GetFocusedRowData("Jan"), "")
            txtFeb.Text = IfNull(blList.GetFocusedRowData("Feb"), "")
            txtMar.Text = IfNull(blList.GetFocusedRowData("Mar"), "")
            txtApr.Text = IfNull(blList.GetFocusedRowData("Apr"), "")
            txtMay.Text = IfNull(blList.GetFocusedRowData("May"), "")
            txtJun.Text = IfNull(blList.GetFocusedRowData("Jun"), "")
            txtJul.Text = IfNull(blList.GetFocusedRowData("Jul"), "")
            txtAug.Text = IfNull(blList.GetFocusedRowData("Aug"), "")
            txtSep.Text = IfNull(blList.GetFocusedRowData("Sep"), "")
            txtOct.Text = IfNull(blList.GetFocusedRowData("Oct"), "")
            txtNov.Text = IfNull(blList.GetFocusedRowData("Nov"), "")
            txtDec.Text = IfNull(blList.GetFocusedRowData("Dec"), "")
            'LoadSub()
            MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2})
            BRECORDUPDATEDs = False
        End If
        InitType()
        AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2})
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False

        If cboType.EditValue.Equals("2") Then
            ctrValidate = New DevExpress.XtraEditors.TextEdit() {txtName, cboType, txtJan, txtFeb, txtMar, txtApr, txtMay, txtJun, txtJul, txtAug, txtSep, txtOct, txtNov, txtDec}
        Else
            ctrValidate = New DevExpress.XtraEditors.TextEdit() {txtName, cboType}
        End If


        If ValidateEntry(ctrValidate) Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                    Exit Sub
                Else
                    'info = DB.RunSql(GenerateInsertScript(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2}, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    Dim qstr As String = "INSERT INTO dbo." & TableName & _
                        "(Name,Type,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec,LastUpdatedBy)" & _
                        "VALUES(" & CleanNull(txtName.Text) & _
                        "," & CleanNull(cboType.EditValue) & _
                        "," & CleanNull(txtJan.Text) & _
                        "," & CleanNull(txtFeb.Text) & _
                        "," & CleanNull(txtMar.Text) & _
                        "," & CleanNull(txtApr.Text) & _
                        "," & CleanNull(txtMay.Text) & _
                        "," & CleanNull(txtJun.Text) & _
                        "," & CleanNull(txtJul.Text) & _
                        "," & CleanNull(txtAug.Text) & _
                        "," & CleanNull(txtSep.Text) & _
                        "," & CleanNull(txtOct.Text) & _
                        "," & CleanNull(txtNov.Text) & _
                        "," & CleanNull(txtDec.Text) & _
                        ",'" & LastUpdatedBy & "')"
                    info = DB.RunSql(qstr)
                    BRECORDUPDATEDs = False
                    id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                    type = "Inserted"
                End If
            Else
                id = strID
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & id & "'") Then
                    Exit Sub
                Else
                    'query.Add(GenerateUpdateScript(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2}, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=(getdate()) ", "PKey='" & id & "'"))
                    Dim qstr As String = "UPDATE dbo." & TableName & " SET " & _
                        "Name=" & CleanNull(txtName.Text) & _
                        ",Type=" & CleanNull(cboType.EditValue) & _
                        ",Jan=" & CleanNull(txtJan.Text) & _
                        ",Feb=" & CleanNull(txtFeb.Text) & _
                        ",Mar=" & CleanNull(txtMar.Text) & _
                        ",Apr=" & CleanNull(txtApr.Text) & _
                        ",May=" & CleanNull(txtMay.Text) & _
                        ",Jun=" & CleanNull(txtJun.Text) & _
                        ",Jul=" & CleanNull(txtJul.Text) & _
                        ",Aug=" & CleanNull(txtAug.Text) & _
                        ",Sep=" & CleanNull(txtSep.Text) & _
                        ",Oct=" & CleanNull(txtOct.Text) & _
                        ",Nov=" & CleanNull(txtNov.Text) & _
                        ",Dec=" & CleanNull(txtDec.Text) & _
                        ",DateUpdated=(getdate())" & _
                        ",LastUpdatedBy='" & LastUpdatedBy & "'" & _
                        " WHERE PKey='" & id & "'"
                    query.Add(qstr)
                    BRECORDUPDATEDs = False
                    type = "Updated"
                End If
            End If

            info = DB.RunSqls(query)
            BRECORDUPDATEDs = False
            blList.RefreshData()
            If info Then
                blList.SetSelection(id)
                RefreshData()
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)

            End If
        End If

    End Sub

    Private Function CleanNull(str As String) As String
        If Not IsNothing(str) Then
            Return "'" & CleanInput(str) & "'"
        Else
            Return "NULL"
        End If
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateEntry(ctrValidate) Then
                If bAddMode Then
                    'If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                    '    flag = False
                    '    ALLOWNEXTS = flag
                    'Else
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData() '
                    'End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData() '
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

    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2})
        Else
            MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2})
        End If
        AllowDeletion(Name, False)
    End Sub

    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2})
        Me.txtName.Focus()
        Me.txtName.BackColor = SEL_COLOR
        If Not bAddMode Then
            ClearFields(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2}, False)
            LayoutControlGroup2.Enabled = False
            'SetDefaultData(LayoutControlGroup2)
            AllowEditing(Name, False) 'Dont Allow Edit Button
            AllowDeletion(Name, False)
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            BRECORDUPDATEDs = False
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If IsNothing(focusedView) Then
            DeleteMain()
            'Else
            '    DeleteSubTable()
        End If
    End Sub

    'set default Details
    Private Sub SetDefaultData(cContainer As DevExpress.XtraLayout.LayoutControlGroup, CalendarType As String)
        Select Case CalendarType
            Case "2"
                For o As Integer = 0 To cContainer.Items.Count - 1
                    If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                        Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        Select Case Mid(ctr.Name, 4)
                            Case "Jan"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 1)
                            Case "Feb"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 2)
                            Case "Mar"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 3)
                            Case "Apr"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 4)
                            Case "May"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 5)
                            Case "Jun"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 6)
                            Case "Jul"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 7)
                            Case "Aug"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 8)
                            Case "Sep"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 9)
                            Case "Oct"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 10)
                            Case "Nov"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 11)
                            Case "Dec"
                                ctr.Text = Date.DaysInMonth(Year(Date.Now), 12)
                        End Select
                    End If
                Next
            Case "3"
                For o As Integer = 0 To cContainer.Items.Count - 1
                    If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                        Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        ctr.Text = 30
                    End If
                Next
        End Select
    End Sub

    Private Function ValidateEntry(ByVal ctrs() As DevExpress.XtraEditors.BaseEdit, Optional ByVal showMsg As Boolean = True) As Boolean
        Dim ctr As DevExpress.XtraEditors.BaseEdit
        For Each ctr In ctrs
            If ctr.EditValue Is System.DBNull.Value Then
                ctr.BackColor = INVALID_COLOR
                If showMsg Then
                    MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                End If
                Return False
            Else
                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If Not CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        ctr.BackColor = INVALID_COLOR
                        If showMsg Then
                            MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                        End If
                        Return False
                    Else
                        ctr.BackColor = REQUIRED_COLOR
                    End If
                ElseIf Not TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                    If TypeOf (ctr.EditValue) Is String Then
                        If Trim(ctr.EditValue) = "" Or ctr.EditValue = "00" Or ctr.EditValue = "0" Then
                            ctr.BackColor = INVALID_COLOR
                            If showMsg Then
                                MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                            End If
                            Return False
                        Else
                            ctr.BackColor = REQUIRED_COLOR
                        End If
                    ElseIf ctr.EditValue = 0 Then
                        ctr.BackColor = INVALID_COLOR
                        If showMsg Then
                            MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                        End If
                        Return False
                    Else
                        ctr.BackColor = REQUIRED_COLOR
                    End If
                End If
            End If
        Next


        Return True
    End Function

    Private Function getCalType() As DataTable
        Dim ctable As New DataTable
        ctable.Columns.Add("PKey", System.Type.GetType("System.String"))
        ctable.Columns.Add("Name", System.Type.GetType("System.String"))
        ctable.Rows.Add("1", "Calendar Dates")
        ctable.Rows.Add("2", "Customized Dates")
        ctable.Rows.Add("3", "30 day months")
        Return ctable
    End Function

#End Region

    Private Sub cboType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboType.EditValueChanged
        Dim lookup As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If Not IsNothing(lookup.EditValue) Then
            If Not lookup.EditValue.Equals(System.DBNull.Value) Then
                Select Case lookup.EditValue
                    Case "2", "1" 'Calendar Dates and Customized Dates
                        LayoutControlGroup2.Enabled = True
                        ctrValidate = New DevExpress.XtraEditors.TextEdit() {txtName, cboType, txtJan, txtFeb, txtMar, txtApr, txtMay, txtJun, txtJul, txtAug, txtSep, txtOct, txtNov, txtDec}
                        strRequiredFields = "txtName;cboType;txtJan;txtFeb;txtMar;txtApr;txtMay;txtJun;txtJul;txtAug;txtSep;txtOct;txtNov;txtDec;"
                        AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup2})
                        SetDefaultData(LayoutControlGroup2, lookup.EditValue)
                        'ClearFields(LayoutControlGroup2, True)
                    Case "3" '30 day month
                        LayoutControlGroup2.Enabled = True
                        ctrValidate = New DevExpress.XtraEditors.TextEdit() {txtName, cboType, txtJan, txtFeb, txtMar, txtApr, txtMay, txtJun, txtJul, txtAug, txtSep, txtOct, txtNov, txtDec}
                        strRequiredFields = "txtName;cboType;txtJan;txtFeb;txtMar;txtApr;txtMay;txtJun;txtJul;txtAug;txtSep;txtOct;txtNov;txtDec;"
                        AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup2})
                        SetDefaultData(LayoutControlGroup2, lookup.EditValue)
                    Case Else
                        LayoutControlGroup2.Enabled = False
                        ctrValidate = New DevExpress.XtraEditors.TextEdit() {txtName, cboType}
                        ClearDates(LayoutControlGroup2)
                End Select
            End If
        End If
    End Sub

    Private Sub InitType()

        If Not IsNothing(cboType.EditValue) Then
            If cboType.EditValue.Equals("2") Then
                strRequiredFields = "txtName;cboType;txtJan;txtFeb;txtMar;txtApr;txtMay;txtJun;txtJul;txtAug;txtSep;txtOct;txtNov;txtDec;"
            Else
                strRequiredFields = "txtName;cboType;"
            End If

        End If
       
        'AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup2})
    End Sub

    Private Sub ClearDates(cContainer As DevExpress.XtraLayout.LayoutControlGroup)
        For o As Integer = 0 To cContainer.Items.Count - 1
            If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                ctr.Text = Nothing
            End If
        Next
    End Sub

    Private Sub DeleteMain()
        MyBase.DeleteData()
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    TableName, _
                    "PKey IN ('" & strID & "')", _
                    "<< Delete Admin Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    ClearFields(Me.LayoutControl1.Root, False)
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

    Private Sub cboType_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
