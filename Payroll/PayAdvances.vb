Public Class PayAdvances

#Region "Declarations"
    Private FormName As String = "Pay Advances"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil
    Dim tblCrewList As New DataTable
    Dim isImport As Boolean = False
#End Region

#Region "InitControl"

    Dim clrBtn As Boolean = False

    Private Sub InitControl()
        clsAudit.propSQLConnStr = DB.GetConnectionString
        cboFKeyVsl.Properties.DataSource = DB.CreateTable("SELECT * FROM VslList ORDER BY Name ")
        cboFKeyPort.Properties.DataSource = DB.CreateTable(" SELECT PKey,Name FROM dbo.tblAdmPort ORDER BY Name ")
        cboFKeyCurr.Properties.DataSource = DB.CreateTable("SELECT PKey,Symbol,Name FROM dbo.tblAdmCurr ORDER BY Ref desc, Name ")
        cboFKeyCAType.Properties.DataSource = DB.CreateTable("SELECT Name,PKey From dbo.tblAdmWageOnb WHERE isCAType <> 0 ORDER BY Name")
        cboPeriod.Properties.DataSource = GetPeriods()
        LayoutControlItem6.Text = "* Exchange Rate to referential currency [" & GetRefCurrency(1) & "]"
        InitCrewAdvancesList()

        SetRibbonGroupToolVisibility(Me.Name.ToString, False)

    End Sub

    Private Sub InittblCrewList()
        tblCrewList = New DataTable
        Dim VslCode As String = IfNull(cboFKeyVsl.EditValue, "")
        Dim Period As String = IfNull(cboPeriod.EditValue, 0)
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandText = "SP_PAY_CA_CrewList"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Period", Period)
                    .AddWithValue("@VslCode", VslCode)
                End With
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(tblCrewList)
                End Using
            End Using
            clrBtn = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        End Try
    End Sub

    Private Sub LoadCrewList()
        'tblCrewList = New DataTable
        'Dim VslCode As String = IfNull(cboFKeyVsl.EditValue, "")
        'Dim Period As String = IfNull(cboPeriod.EditValue, 0)
        'Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        'Try
        '    sqlConn.Open()
        '    Using cmd As New SqlClient.SqlCommand
        '        cmd.Connection = sqlConn
        '        cmd.CommandText = "SP_PAY_CA_CrewList"
        '        cmd.CommandType = CommandType.StoredProcedure
        '        With cmd.Parameters
        '            .AddWithValue("@Period", Period)
        '            .AddWithValue("@VslCode", VslCode)
        '        End With
        '        Using adp As New SqlClient.SqlDataAdapter(cmd)
        '            adp.Fill(tblCrewList)
        '        End Using
        '    End Using
        '    clrBtn = False
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        'End Try
        InittblCrewList()
        InitCrewAdvancesList()
        repCrewList.DataSource = tblCrewList
    End Sub

    Public Function strFilterCrewList() As String
        Dim RetVal As String = String.Empty
        If CAView.DataRowCount > 0 Then
            For Each dr As DataRowView In CAView.DataSource
                    RetVal = "'" & dr("FKeyIDNbr") & "'," & RetVal
            Next
            RetVal = RetVal.Substring(0, Len(RetVal) - 1)
            RetVal = " FKeyIDNbr NOT IN(" & RetVal & ") "
        Else
            RetVal = String.Empty
        End If
        Return RetVal
    End Function

    Private Sub InitCrewAdvancesList()
        Dim ctbl As New DataTable
        With ctbl
            .Columns.Add("PKey", GetType(String))
            .Columns.Add("FKeyIDNbr", GetType(String))
            .Columns.Add("FKeyVsl", GetType(String))
            .Columns.Add("FKeyRank", GetType(String))
            .Columns.Add("RankName", GetType(String))
            .Columns.Add("VesselName", GetType(String))
            .Columns.Add("ActID", GetType(String))
            .Columns.Add("ActGroupID", GetType(String))
            .Columns.Add("Amt", GetType(Double))
            .Columns.Add("ItemDesc", GetType(String))
            .Columns.Add("COIDNo", GetType(String))
            .Columns.Add("Edited", GetType(Boolean))
        End With
        CAGrid.DataSource = ctbl
    End Sub

    Private Sub cboType_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyCAType.ButtonPressed
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboPort_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyPort.ButtonPressed
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboFKeyCurr_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyCurr.ButtonPressed
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboPeriod_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriod.ButtonPressed
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            If hasCAEdited() Then
                If bAddMode Or isEditdable Then

                    Dim msgans As Integer
                    msgans = MsgBox("Crew advances list is not empty. Would you like to save the changes you've made?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + vbDefaultButton2, GetAppName)

                    If msgans = MsgBoxResult.Yes And Not clrBtn Then
                        SaveData()
                    ElseIf msgans = MsgBoxResult.No Then
                        clrBtn = True
                        ClearLookUpEdit(sender, e)
                    End If
                Else
                    clrBtn = True
                    ClearLookUpEdit(sender, e)
                End If
            Else
                clrBtn = True
                ClearLookUpEdit(sender, e)
            End If
        End If
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        Dim _LookEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        cboFKeyVsl.EditValue = Nothing
        If Not IsNothing(_LookEd) Then
            If hasCAEdited() Then
                If bAddMode Or isEditdable Then
                    If MsgBox("Crew advances list is not empty. Would you like to save the changes you've made?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes And Not clrBtn Then
                        SaveData()
                        'Else
                        '    LoadCrewList()
                    End If
                    'Else
                    '    LoadCrewList()
                End If
                'Else
                '    LoadCrewList()
            End If
            'LoadCrewList()
        End If

    End Sub

    Private Sub cboVessel_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyVsl.ButtonPressed
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then

            If hasCAEdited() Then
                Dim msgans As Integer
                msgans = MsgBox("Crew advances list is not empty. Would you like to save the changes you've made?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + vbDefaultButton2, GetAppName)
                If msgans = MsgBoxResult.Yes And Not clrBtn Then
                    SaveData()
                ElseIf msgans = MsgBoxResult.No Then
                    clrBtn = True
                    ClearLookUpEdit(sender, e)
                End If
            Else
                clrBtn = True
                ClearLookUpEdit(sender, e)
            End If
        End If

    End Sub

    Private Sub cboVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyVsl.EditValueChanged
        Dim _LookEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If Not IsNothing(_LookEd) Then
            If hasCAEdited() Then

                If bAddMode Or isEditdable Then
                    LoadCrewList()
                Else
                    If MsgBox("Crew advances list is not empty. Would you like to save the changes you've made?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes And Not clrBtn Then
                        SaveData()
                    Else
                        LoadCrewList()
                    End If
                End If
            Else
                LoadCrewList()
            End If
        End If
    End Sub

    Private Function hasCAEdited() As Boolean
        Dim retval As Boolean = False
        If BRECORDUPDATEDs Then
            For Each dr As DataRowView In CAView.DataSource
                If dr("Edited").Equals(True) Then
                    retval = True
                    Exit For
                End If
            Next
        Else
            retval = False
        End If
        Return retval
    End Function

    Private Sub cmdAllCrew_Click(sender As System.Object, e As System.EventArgs) Handles cmdAllCrew.Click
        If ValidateFields(RequiredControls) Then
            'If CAView.DataRowCount > 0 Then
            '    If MsgBox("Crew advances list is not empty. Would you like to clear Unsaved changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes And Not clrBtn Then
            '        clrBtn = True
            '        FillAllCrew()
            '    End If
            'Else
            clrBtn = True
            FillAllCrew()
            'End If
        End If
    End Sub

    Private Sub FillAllCrew()

        Dim ctbl As DataTable = TryCast(CAView.DataSource, DataView).ToTable
        Dim strFilter As String = strFilterCrewList()
        Dim dv As DataView
        If tblCrewList.Select(strFilter).Length > 0 Then
            dv = New DataView(tblCrewList.Select(strFilter).CopyToDataTable)
            For Each dr As DataRowView In dv
                Dim nRow As DataRow
                nRow = ctbl.NewRow
                nRow("FKeyIDNbr") = dr("FKeyIDNbr")
                nRow("FKeyRank") = dr("FKeyRank")
                nRow("RankName") = dr("RankName")
                nRow("FKeyVsl") = dr("FKeyVslCode")
                nRow("VesselName") = dr("VslName")
                nRow("ActID") = dr("ActID")
                nRow("ActGroupID") = dr("ActGrpID")
                nRow("Amt") = 0
                nRow("Edited") = True
                'tony20181008 - corrected this code nRow("COIDNbr") = dr("COIDNo")
                '             - replaced with code below
                nRow("COIDNo") = dr("COIDNo")
                ctbl.Rows.Add(nRow)
            Next
        End If

        CAGrid.DataSource = ctbl
    End Sub

    Private Sub FillCrewRowDetails(rowHandle As Integer, IDNbr As String)
        Dim dv As New DataView(tblCrewList)
        dv.Sort = "FKeyIDNbr"
        Dim drv As DataRowView() = dv.FindRows(IDNbr)
        With CAView
            .SetRowCellValue(rowHandle, "FKeyIDNbr", Trim(IfNull(drv(0)("FKeyIDNbr"), "")))
            .SetRowCellValue(rowHandle, "FKeyRank", Trim(IfNull(drv(0)("FKeyRank"), "")))
            .SetRowCellValue(rowHandle, "RankName", Trim(IfNull(drv(0)("RankName"), "")))
            .SetRowCellValue(rowHandle, "FKeyVsl", Trim(IfNull(drv(0)("FKeyVslCode"), "")))
            .SetRowCellValue(rowHandle, "VesselName", Trim(IfNull(drv(0)("VslName"), "")))
            .SetRowCellValue(rowHandle, "ActID", Trim(IfNull(drv(0)("ActID"), "")))
            .SetRowCellValue(rowHandle, "ActGroupID", Trim(IfNull(drv(0)("ActGrpID"), "")))
            .SetRowCellValue(rowHandle, "COIDNo", Trim(IfNull(drv(0)("COIDNo"), "")))
        End With
    End Sub

#End Region

#Region "Main Function"

    Private Sub LoadSub()
        LoadAdvancesDetails()
        CAGrid.DataSource = LoadCrewAdvances()
    End Sub

    Private Sub LoadAdvancesDetails()
        cboPeriod.EditValue = IfNull(blList.GetFocusedRowData("Period"), 0)
        cboFKeyVsl.EditValue = IfNull(blList.GetFocusedRowData("FKeyVsl"), "")
        txtDatePrepared.EditValue = blList.GetFocusedRowData("DatePrepared")
        txtRef.Text = IfNull(blList.GetFocusedRowData("Ref"), "")
        cboFKeyCAType.EditValue = IfNull(blList.GetFocusedRowData("FKeyCAType"), "")
        cboFKeyPort.EditValue = IfNull(blList.GetFocusedRowData("FKeyPort"), "")
        cboFKeyCurr.EditValue = IfNull(blList.GetFocusedRowData("FKeyCurr"), "")
        txtExRate.Text = IfNull(blList.GetFocusedRowData("ExRate"), CDbl(0))
        txtDescription.Text = IfNull(blList.GetFocusedRowData("Description"), "")
    End Sub

    Private Function LoadCrewAdvances() As DataTable
        Dim ctbl As New DataTable
        ctbl = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblCASeaman WHERE FKeyCA ='" & strID & "'")
        Return ctbl
    End Function

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        GroupControl1.Text = IIf(strDesc = "New Record", strDesc, "Crew Advances  " & strDesc)
        If Not bLoaded Then
            InitControl()
            RequiredControls() = {cboFKeyCAType, cboPeriod, cboFKeyVsl, txtDatePrepared, txtExRate, txtRef, cboFKeyPort, cboFKeyCurr}
            bLoaded = True
        End If
        If IfNull(blList.GetID, "").Equals("") Then
            AddData()
        Else
            cmdAllCrew.Enabled = False
            LoadSub()
            EditSubAllowGrid(CAView, False, False)
            MakeReadOnlyListener(lcgCADetails)
            If ValidateCADetail() Then
                InittblCrewList()
                repCrewList.DataSource = tblCrewList
            End If
            BRECORDUPDATEDs = False

        End If
        AddEditListener(lcgCADetails)

    End Sub

    Public Overrides Sub AddData()
        MyBase.AddData()
        cboPeriod.Focus()
        cboPeriod.BackColor = SEL_COLOR
        RemoveReadOnlyListener(lcgCADetails)
        EditSubAllowGrid(CAView, True, True)
        cmdAllCrew.Enabled = True
        If Not bAddMode Then
            bAddMode = True
            ClearFields(lcgCADetails, False)
            AllowEditing(Name, False) 'Dont Allow Edit Button
            AllowDeletion(Name, True)
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            GroupControl1.Text = strDesc
            CAGrid.DataSource = LoadCrewAdvances()
            txtDatePrepared.EditValue = Date.Now
            BRECORDUPDATEDs = False
        End If

    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        'Check if IMPORTED or MANUAL Type
        RemoveReadOnlyListener(lcgCADetails)
        EditSubAllowGrid(CAView, True, True)
        AllowAddition(Name, Not isEditdable)
        AllowDeletion(Name, True)
        cmdAllCrew.Enabled = isEditdable
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        GroupControl1.Focus()
        Dim isSaved As Boolean = False
        If ValidateCADetail() Then
            isSaved = SaveCrewAdvances()
            If isSaved Then
                MsgBox(GetMessage("Saved", isSaved), MsgBoxStyle.Information, GetAppName)
                bLoaded = False
                RefreshData()
                blList.RefreshData()
            Else
                MsgBox(GetMessage("Saved", isSaved), MsgBoxStyle.Exclamation, GetAppName)
            End If
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If IsNothing(focusedView) Then
            DeleteMain()
        Else
            DeleteSubTable()
        End If
    End Sub

    Private Sub DeleteMain()
        MyBase.DeleteData()
        Dim info As Boolean = False
        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed("tblCA", strID) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Advances", 0, System.Environment.MachineName, GroupControl1.Text, FormName)
                clsAudit.saveAuditPreDelDetails("tblCA", strID, LastUpdatedBy) 'neil
                info = DB.RunSql("DELETE FROM dbo." & "tblCA" & " WHERE PKey='" & strID & "'")
                If info Then
                    ClearFields(lcgCADetails, False)
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
        With focusedView
            .CancelUpdateCurrentRow()
            If MsgBox("Are you sure want to delete " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyIDNbr") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Cash Advances", 0, System.Environment.MachineName, GroupControl1.Text & " : " & CAView.GetRowCellDisplayText(CAView.FocusedRowHandle, "FKeyIDNbr"), FormName)
                    clsAudit.saveAuditPreDelDetails("tblCASeaman", CAView.GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    DB.RunSql("DELETE FROM dbo.tblCASeaman WHERE PKey='" & CAView.GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                End If
                .DeleteRow(.FocusedRowHandle)
                If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
            End If
        End With
    End Sub

    Private Function SaveCrewAdvances() As Boolean
        Dim retval As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing

        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction

            'tblCA
            If bAddMode Then
                ''Insert New CA (Main Table)
                Dim tblCASeaman As New DataTable
                With tblCASeaman
                    .Columns.Add("COMPANY_ID", GetType(String))
                    .Columns.Add("Amount", GetType(Double))
                    .Columns.Add("Item", GetType(String))
                End With
                isImport = False 'Not imported. Details from MPS.
                Dim dvCASeaman As DataView = TryCast(CAView.DataSource, DataView)
                dvCASeaman.RowFilter = "Edited=1"
                If dvCASeaman.Count > 0 Then
                    tblCASeaman = dvCASeaman.ToTable(True, New String() {"COIDNo", "Amt", "ItemDesc"})
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Transaction = sqlTran
                        cmd.Connection = sqlConn
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "SP_PAY_Process_CA"
                        With cmd.Parameters
                            .AddWithValue("@DatePrepared", CDate(txtDatePrepared.EditValue).ToString("yyyy-MM-dd"))
                            .AddWithValue("@strDescription", IfNull(txtDescription.Text, String.Empty))
                            .AddWithValue("@FKeyCurrName", cboFKeyCurr.Text)
                            .AddWithValue("@ExRate", CDbl(txtExRate.Text))
                            .AddWithValue("@FKeyVslName", cboFKeyVsl.Text)
                            .AddWithValue("@FKeyPortName", cboFKeyPort.Text)
                            .AddWithValue("@FKeyCATypeName", cboFKeyCAType.Text)
                            .AddWithValue("@Period", cboPeriod.EditValue)
                            .AddWithValue("@Ref", txtRef.Text)
                            .AddWithValue("@isImported", isImport)
                            .AddWithValue("@CASeaman", tblCASeaman)
                            .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                        End With
                        retval = (cmd.ExecuteNonQuery() > 0)
                    End Using
                End If
            Else
                'Update CA
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTran
                    cmd.CommandText = GenerateUpdateScript(lcgCADetails, 3, "tblCA", "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=getdate()", "PKey='" & strID & "'")
                    retval = (cmd.ExecuteNonQuery() = 1)
                End Using
                If CAView.DataRowCount > 0 Then
                    'For Each dr As DataRowView In CAView.DataSource
                    With CAView
                        For i = 0 To CAView.DataRowCount - 1
                            If .GetRowCellValue(i, "Edited").Equals(True) Then
                                If IfNull(.GetRowCellValue(i, "PKey"), "").Equals("") Then
                                    'Insert new Row to tblCASeaman
                                    Using cmd As New SqlClient.SqlCommand
                                        cmd.Connection = sqlConn
                                        cmd.Transaction = sqlTran
                                        cmd.CommandText = "INSERT INTO dbo.tblCASeaman(" & _
                                            "FKeyCA" & _
                                            ",FKeyIDNbr" & _
                                            ",ActGroupID" & _
                                            ",ActID" & _
                                            ",FKeyVsl" & _
                                            ",VesselName" & _
                                            ",FKeyRank" & _
                                            ",RankName" & _
                                            ",Amt" & _
                                            ",ItemDesc" & _
                                            ",LastUpdatedBy)" & _
                                            "VALUES(" & _
                                            "@FKeyCA" & _
                                            ",@FKeyIDNbr" & _
                                            ",@ActGroupID" & _
                                            ",@ActID" & _
                                            ",@FKeyVsl" & _
                                            ",@VesselName" & _
                                            ",@FKeyRank" & _
                                            ",@RankName" & _
                                            ",@Amt" & _
                                            ",@ItemDesc" & _
                                            ",@LastUpdatedBy)"
                                        With cmd.Parameters
                                            .AddWithValue("@FKeyCA", strID)
                                            .AddWithValue("@FKeyIDNbr", CAView.GetRowCellValue(i, "FKeyIDNbr"))
                                            .AddWithValue("@ActGroupID", CAView.GetRowCellValue(i, "ActGroupID"))
                                            .AddWithValue("@ActID", CAView.GetRowCellValue(i, "ActID"))
                                            .AddWithValue("@FKeyVsl", CAView.GetRowCellValue(i, "FKeyVsl"))
                                            .AddWithValue("@VesselName", CAView.GetRowCellValue(i, "VesselName"))
                                            .AddWithValue("@FKeyRank", CAView.GetRowCellValue(i, "FKeyRank"))
                                            .AddWithValue("@RankName", CAView.GetRowCellValue(i, "RankName"))
                                            .AddWithValue("@Amt", CAView.GetRowCellValue(i, "Amt"))
                                            .AddWithValue("@ItemDesc", CAView.GetRowCellValue(i, "ItemDesc"))
                                            .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                                        End With
                                        retval = (cmd.ExecuteNonQuery() > 0)
                                    End Using

                                Else
                                    'Update tblCASeaman
                                    Using cmd As New SqlClient.SqlCommand
                                        cmd.Connection = sqlConn
                                        cmd.Transaction = sqlTran
                                        cmd.CommandText = "UPDATE dbo.tblCASeaman SET " & _
                                            "FKeyIDNbr = @FKeyIDNbr" & _
                                            ",ActGroupID = @ActGroupID" & _
                                            ",ActID = @ActID" & _
                                            ",FKeyVsl =@FKeyVsl" & _
                                            ",VesselName =@VesselName" & _
                                            ",FKeyRank = @FKeyRank" & _
                                            ",RankName = @RankName" & _
                                            ",Amt = @Amt" & _
                                            ",ItemDesc = @ItemDesc" & _
                                            ",LastUpdatedBy = @LastUpdatedBy" & _
                                            ",DateUpdated = getdate()" & _
                                            " WHERE FKeyCA = @FKeyCA AND PKey = @PKey "
                                        With cmd.Parameters
                                            .AddWithValue("@PKey", CAView.GetRowCellValue(i, "PKey"))
                                            .AddWithValue("@FKeyCA", strID)
                                            .AddWithValue("@FKeyIDNbr", CAView.GetRowCellValue(i, "FKeyIDNbr"))
                                            .AddWithValue("@ActGroupID", CAView.GetRowCellValue(i, "ActGroupID"))
                                            .AddWithValue("@ActID", CAView.GetRowCellValue(i, "ActID"))
                                            .AddWithValue("@FKeyVsl", CAView.GetRowCellValue(i, "FKeyVsl"))
                                            .AddWithValue("@VesselName", CAView.GetRowCellValue(i, "VesselName"))
                                            .AddWithValue("@FKeyRank", CAView.GetRowCellValue(i, "FKeyRank"))
                                            .AddWithValue("@RankName", CAView.GetRowCellValue(i, "RankName"))
                                            .AddWithValue("@Amt", CAView.GetRowCellValue(i, "Amt"))
                                            .AddWithValue("@ItemDesc", CAView.GetRowCellValue(i, "ItemDesc"))
                                            .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                                        End With
                                        retval = (cmd.ExecuteNonQuery() > 0)
                                    End Using
                                End If
                            End If
                        Next
                    End With
                End If
            End If

            If retval Then
                sqlTran.Commit()
            End If
        Catch ex As Exception
            sqlTran.Rollback()
            retval = False
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return retval
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If CAView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidateCADetail() Then
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData() '
                Else
                    flag = False
                    ALLOWNEXTS = flag
                End If
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag

    End Function

#End Region

#Region "Validation"
    Private Function ValidateCADetail() As Boolean
        Dim retval As Boolean = False
        If ValidateFields(RequiredControls) Then
            If Not isCAVal() Then
                'retval = True
                If isValidCrewList() Then
                    retval = True
                Else
                    retval = False
                End If
            Else
                MsgBox("Duplicate Cash Advance", MsgBoxStyle.Exclamation, GetAppName)
                retval = False
            End If


        Else
            retval = False
        End If
        Return retval
    End Function


    Private Function isValidCrewList() As Boolean
        Dim retVal As Boolean = False

        If CAView.DataRowCount > 0 Then
            For Each dr As DataRow In TryCast(CAGrid.DataSource, DataTable).Rows
                If IfNull(dr.Item("Amt"), CDbl(0)) <= 0 Then
                    retVal = False
                    MsgBox("Crew has an invalid Amount.", MsgBoxStyle.Exclamation, GetAppName())
                    Exit For
                Else
                    retVal = True
                End If
            Next
        Else
            retVal = False
        End If

        Return retVal
    End Function

    Private Function isCAVal() As Boolean
        Dim retval As Boolean = True
        If bAddMode And (Not isImport) Then
            Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
            Try
                sqlConn.Open()
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.CommandText = "SELECT dbo.FN_isCA_Exist(@FKeyVsl,@FKeyPort,@FKeyCAType,@Period)"
                    With cmd.Parameters
                        .AddWithValue("@FKeyVsl", cboFKeyVsl.EditValue)
                        .AddWithValue("@FKeyPort", cboFKeyPort.EditValue)
                        .AddWithValue("@FKeyCAType", cboFKeyCAType.EditValue)
                        .AddWithValue("@Period", cboPeriod.EditValue)
                    End With
                    retval = cmd.ExecuteScalar
                End Using
            Catch ex As Exception
                retval = True
                MsgBox(ex.Message)
            Finally
                If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
            End Try
        Else
            retval = False
        End If

        Return retval
    End Function

#End Region

#Region "Cash Advances View"

    Private Sub ReLoadCrewList(_View As DevExpress.XtraGrid.Views.Grid.GridView)
        With _View
            If .FocusedColumn.FieldName.Equals("FKeyIDNbr") And (TypeOf (.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                Dim strCrewFltr As String = String.Empty
                If CAView.DataRowCount > 0 Then
                    For Each dr As DataRowView In CAView.DataSource
                        If Not IfNull(CAView.GetFocusedRowCellValue("FKeyIDNbr"), "").Equals(dr("FKeyIDNbr")) Then
                            strCrewFltr = "'" & dr("FKeyIDNbr") & "'," & strCrewFltr
                        End If
                    Next
                    If Trim(strCrewFltr).Length > 0 Then
                        strCrewFltr = strCrewFltr.Substring(0, Len(strCrewFltr) - 1)
                        strCrewFltr = " FKeyIDNbr NOT IN(" & strCrewFltr & ") "
                    Else
                        strCrewFltr = String.Empty
                    End If
                Else
                    strCrewFltr = String.Empty
                End If

                Dim dv = New DataView(tblCrewList)
                dv.RowFilter = strCrewFltr
                edit.Properties.DataSource = dv
                If dv.Count = 1 Then
                    edit.Properties.DropDownRows = 1
                Else
                    edit.Properties.DropDownRows = 10
                End If
            End If
        End With
    End Sub

    Private Sub CAView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CAView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then

            With Me.CAView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub CAView_GotFocus(sender As Object, e As System.EventArgs) Handles CAView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Crew Advance")
        Else

            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Cash Advance")
        End If

    End Sub

    Private Sub CAView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CAView.InitNewRow
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If ValidateFields(RequiredControls) Then
            _V.SetRowCellValue(e.RowHandle, "Edited", True)
        Else
            MsgBox("Incomplete Cash Advance Details", MsgBoxStyle.Exclamation, GetAppName())
        End If
    End Sub

    Private Sub CAView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CAView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CAView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CAView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub CAView_RowCountChanged(sender As Object, e As System.EventArgs) Handles CAView.RowCountChanged
        Dim v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If v.RowCount > 0 Then
            AllowSaving(Name, True)
        Else
            AllowSaving(Name, False)
        End If
    End Sub

    Private Sub CAView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CAView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CAView_ShownEditor(sender As Object, e As System.EventArgs) Handles CAView.ShownEditor
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ReLoadCrewList(_V)
    End Sub

    Private Sub CAView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CAView.ValidateRow
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not ValidateFields(RequiredControls) Then
            e.Valid = False
            'e.ErrorText = "Incomplete Cash Advance Details"
        Else
            With _V
                If .FocusedColumn.FieldName.Equals("Amt") Then
                    If .GetRowCellValue(e.RowHandle, "Amt") Is (System.DBNull.Value) Then
                        e.Valid = False
                        .SetColumnError(.FocusedColumn, "Incomplete Cash Advance Details")
                    ElseIf IfNull(.GetRowCellValue(e.RowHandle, "Amt"), CDbl(0)) <= 0 Then
                        e.Valid = False
                        .SetColumnError(.FocusedColumn, "Incomplete Cash Advance Details")
                    Else
                        e.Valid = True
                        .SetColumnError(.FocusedColumn, String.Empty)
                    End If
                End If

            End With

        End If

    End Sub

    Private Sub CAView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles CAView.ValidatingEditor
        Dim _V As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'If Not ValidateCADetail() Then
        '    e.Valid = False
        '    e.ErrorText = "Incomplete Cash Advance Details"
        'Else
        If _V.FocusedColumn.FieldName.Equals("FKeyIDNbr") Then
            FillCrewRowDetails(_V.FocusedRowHandle, e.Value)
        End If

        If _V.FocusedColumn.FieldName.Equals("Amt") Then
            If IfNull(CDbl(e.Value), CDbl(0)) <= 0 Then
                e.Valid = False
                e.ErrorText = "Invalid Amount"
            Else
                e.Valid = True
                e.ErrorText = ""
            End If
        End If
        'End If
    End Sub


#End Region

    Private Sub cboFKeyCAType_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboFKeyCAType.EditValueChanging
        Dim lookupEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If Not IsNothing(e.NewValue) Then
            If e.NewValue.Equals("SYSPAYSLOPCHEST") Or e.NewValue.Equals("SASV2J41ZR8LR5D") Then 'Slopchess and Bond A/C
                ShowItemColumn(True)
            Else
                ShowItemColumn(False)
            End If
        Else
            ShowItemColumn(False)
        End If
    End Sub

    Private Sub ShowItemColumn(Optional value As Boolean = True)
        grdColItem.Visible = value
    End Sub


#Region "Import/Export"

    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0).ToString
            Case "GenerateCAExcelTemplate"
                GenerateCAExcelTemplate()
            Case "ImportFromExcel"
                ImportCAFromExcel()
        End Select
    End Sub
#End Region
End Class
