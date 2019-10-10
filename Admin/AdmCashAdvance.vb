Public Class AdmCashAdvance


#Region "Declaration"
    Dim FormName As String = "Admin Cash Advances"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
#End Region

    Private Sub initControls()
        LayoutControl1.AllowCustomization = False
        clsAudit.propSQLConnStr = DB.GetConnectionString
    End Sub

    Private Sub LoadSub()
        txtName.Text = IfNull(blList.GetFocusedRowData("Name"), "")
        txtSortCode.Text = IfNull(blList.GetFocusedRowData("SortCode"), 0)
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        'TableName = "tblAdmCAType"
        TableName = "tblAdmWageOnb"
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteCaption(Name, "Delete Cash Advance Type")
        GroupControl1.Text = IIf(strDesc = "New Record", strDesc, "Cash Advances Type Details - " & strDesc)
        If Not bLoaded Then
            initControls()
            RequiredControls = {txtName}
            bLoaded = True
        End If

        If IfNull(blList.GetID, "").Equals("") Then
            AddData()
        Else
            LoadSub()
            MakeReadOnlyListener(LayoutControl1.Root)
            BRECORDUPDATEDs = False
        End If

        AddEditListener(LayoutControl1.Root)

    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            RemoveReadOnlyListener(LayoutControl1.Root)
        Else
            MakeReadOnlyListener(LayoutControl1.Root)
        End If
        AllowDeletion(Name, False)
        AllowEditing(Name, False)
    End Sub

    Public Overrides Sub AddData()
        MyBase.AddData()
        txtName.Focus()
        txtName.BackColor = SEL_COLOR
        ClearFields(LayoutControl1.Root, False)
        RemoveReadOnlyListener(LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowEditing(Name, False) 'Dont Allow Edit Button
            AllowDeletion(Name, False)
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            GroupControl1.Text = strDesc
            BRECORDUPDATEDs = False
        End If


    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        GroupControl1.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False

        If ValidateFields(RequiredControls) Then
            'If bAddMode Then
            '    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
            '    BRECORDUPDATEDs = False
            '    id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
            '    type = "Inserted"
            'Else
            '    id = strID
            '    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=(getdate()) ", "PKey='" & id & "'"))
            '    BRECORDUPDATEDs = False
            '    type = "Updated"
            'End If

            If bAddMode Then
                info = DB.RunSql("INSERT INTO dbo.tblAdmWageOnb(Name,SortCode,WageType,isCAType,LastUpdatedBy) VALUES('" & CleanInput(txtName.EditValue) & "'," & CInt(txtSortCode.EditValue) & ",2,'True','" & CleanInput(LastUpdatedBy) & "')")
                BRECORDUPDATEDs = False
                id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                type = "Inserted"
            Else
                id = strID
                info = DB.RunSql("UPDATE dbo.tblAdmWageOnb SET Name='" & CleanInput(txtName.EditValue) & "' , SortCode= " & CleanInput(txtSortCode.EditValue) & " , DateUpdated=getdate(), LastUpdatedBy='" & CleanInput(LastUpdatedBy) & "' " & _
                                 " WHERE PKey= '" & id & "'")
                BRECORDUPDATEDs = False
                type = "Updated"
            End If

            If info Then
                blList.RefreshData()
                blList.SetSelection(id)
                'RefreshData()
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)

                RefreshData()
                BRECORDUPDATEDs = False
            Else
                blList.SetSelection(id)
                'RefreshData()
                MsgBox(GetMessage(type, info), MsgBoxStyle.Exclamation, GetAppName)
            End If
        End If

    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = False



        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Cash Advances", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil

                '<--added by tony20180922 : Log Deletion
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
                    'RefreshData()
                    blList.RefreshData()
                    RefreshData()
                    BRECORDUPDATEDs = False
                End If
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If
        End If
    End Sub

End Class
