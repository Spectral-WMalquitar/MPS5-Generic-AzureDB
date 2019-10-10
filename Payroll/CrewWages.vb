Public Class CrewWages

#Region "Base Items"

    Dim LastUpdatedBy = ""
    Dim tabChanged As Boolean = False, PrevTab As String = ""
    Dim ActID As String = "", FKeyWScaleRankCode As String = "", FKeyWScaleCode As String = "", DateStart As Date
    Dim tblAcivity As New DataTable
    Dim clsAudit As New clsAudit 'neil

    Private Sub initControls()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        LayoutControl1.AllowCustomization = False
        LayoutControl2.AllowCustomization = False
        tcgWages.SelectedTabPageIndex = 0 'Select First Tab on first Load
        tcgFixWages.SelectedTabPageIndex = 0
        tcgVarWages.SelectedTabPageIndex = 0 'Select First Tab on first Load

        Dim dtWageOnb As DataTable = DB.CreateTable("SELECT * FROM dbo.tblAdmWageOnb ORDER BY Name")
        Dim dtFKeyCurr As DataTable = DB.CreateTable("SELECT * FROM dbo.tblAdmCurr ORDER BY Ref desc, Name")

        'Variable Wages
        '============================================
        ''Earnings
        repEarnFKeyWageOnb.DataSource = dtWageOnb.Select("WageType=1").CopyToDataTable
        repEarnFKeyCurr.DataSource = dtFKeyCurr

        'Deductions
        repDedFKeyCurr.DataSource = dtFKeyCurr
        repDedFKeyWageOnb.DataSource = dtWageOnb.Select("WageType=2").CopyToDataTable
        ''============================================

        'Fixed Wages
        '============================================
        Dim dtDateType_ As DataTable = dtDateType()

        'ONB-Earnings
        repFWEarnFKeyWageOnb.DataSource = dtWageOnb
        repFWEarnFKeyCurr.DataSource = dtFKeyCurr
        repFWEarnDateType.DataSource = dtDateType_
        'ONB-Deduction
        repFWDedFKeyWageDed.DataSource = dtWageOnb
        repFWDedFKeyCurr.DataSource = dtFKeyCurr
        repFWDedDateType.DataSource = dtDateType_

        'WageInfo
        repInfoFKeyWageInfo.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageInfo ORDER BY Name")
        repInfoDen.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageDen ORDER BY Name")
        repInfoPrd.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWagePrd ORDER BY Name")
        repInfoDateType.DataSource = dtDateType_

        'Employee Contribution
        repEmpeCurr.DataSource = dtFKeyCurr
        repEmpeWageAsh.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageAsh ORDER BY Name")
        repEmpeDateType.DataSource = dtDateType_

        'Employer Contribution
        repEmprCurr.DataSource = dtFKeyCurr
        repEmprWageAshEmp.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWageAshEmp ORDER BY Name")
        repEmprDateType.DataSource = dtDateType_

        EditSubAllowGrid(ActView, False)
        EditSubAllowGrid(EarnView, False)
        EditSubAllowGrid(DedView, False)
        EditSubAllowGrid(InfoView, False)
        EditSubAllowGrid(EmpeView, False)
        EditSubAllowGrid(EmprView, False)
        '============================================

        clsAudit.propSQLConnStr = MPSDB.GetConnectionString
    End Sub

    Private Sub LoadSub()
        Dim nRow As Integer = -1
        With ActView
            If .RowCount > 0 Then
                'nRow = .FocusedRowHandle
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
        LoadWages()
    End Sub

    Private Sub LoadWages()
        GetActivityCode()
        'for SUB DATA
        EditSubAllowGrid(Me.VWEarnView, False)
        EditSubAllowGrid(Me.VWDedView, False)

        'Load Wages
        Select Case tcgWages.SelectedTabPage.Tag
            Case "FW" 'Fixed wages
                LoadFixedWages()
            Case "VW" 'Variable Wage
                LoadVarriableWages()
        End Select

    End Sub

    'refresh
    Public Overrides Sub RefreshData()
        TableName = "tblAdmDocument"
        MyBase.RefreshData()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'Hide Add button
        GetSelectedView()
        SetContentKind()
        'SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        'Me.header.Text = IIf(strDesc = "New Record", strDesc, "Crew Varriable Wages - " & strDesc)
        SetEditCaption(Name, "Add/Edit")
        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
        Else
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            ''for SUB DATA
            'EditSubAllowGrid(Me.VWEarnView, False)
            'EditSubAllowGrid(Me.VWDedView, False)
            isVWEditable()
            AllowDeletion(Name, False)
            BRECORDUPDATEDs = False
        End If
    End Sub

    Private Sub SetContentKind()

        Select Case CONTENTTYPE
            Case "ASH"
                lcgVarWages.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lcgFWDed.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lcgFWWI.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lcgFWEME.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lcgFWEMR.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case "ONB"
                lcgFWEME.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lcgFWEMR.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lcgVarWages.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lcgFWDed.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lcgFWWI.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End Select

    End Sub

    Public Overrides Sub ActivityCommand(_activity As String)
        'MyBase.ActivityCommand(_activity)
        SetContentKind()
    End Sub

    'Edit/Add
    Public Overrides Sub EditData()
        MyBase.EditData()
        GetSelectedView()
        header.Focus()
        If isEditdable Then
            If focusedView.RowCount > 0 Then
                AllowDeletion(Name, True)
            Else
                AllowDeletion(Name, False)
            End If
        Else
            AllowDeletion(Name, False)
        End If

        EditSubAllowGrid(Me.VWEarnView, isEditdable)
        EditSubAllowGrid(Me.VWDedView, isEditdable)
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim info As Boolean = False
        If Not focusedView.HasColumnErrors And (Not IfNull(ActID, "").Equals("")) Then
            'If ValidateFields(New DevExpress.XtraEditors.TextEdit() {}) Then
            If BRECORDUPDATEDs Then
                Select Case IIf(tabChanged, PrevTab, Me.tcgVarWages.SelectedTabPage.Tag)
                    Case "Earn" 'Earning
                        info = DB.RunSqls(SaveEarnings(strID, ActID))
                    Case "Ded" 'Deductions
                        info = DB.RunSqls(SaveDed(strID, ActID))
                End Select
            End If
            tabChanged = False
            BRECORDUPDATEDs = False
            'blList.RefreshData()
            If info Then
                blList.SetSelection(strID)
                'RefreshData()
                'LoadWages()
                LoadVarriableWages()
                MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
            End If
            'End If
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
            If VWEarnView.HasColumnErrors() Or VWDedView.HasColumnErrors Then
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
            Dim SubDesc As String = ""
            SubDesc = .GetRowCellDisplayText(.FocusedRowHandle, "FKeyWageOnbID")
            If MsgBox("Are you sure want to delete the '" & SubDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                'Delete Per Record
                If Not .GetRowCellValue(.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                    If Not Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")).Equals("") Then

                        clsAudit.propSQLConnStr = MPSDB.GetConnectionString
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Onboard Wages", 0, System.Environment.MachineName, "Vessel : " & IfNull(ActView.GetRowCellDisplayText(.FocusedRowHandle, "Vessel"), "") & " - " & SubDesc, "Crew Wages", strID) 'neil
                        clsAudit.saveAuditPreDelDetails("tblWageOnb", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                        '<!--added by tony20180922 : Log Deletion
                        Dim oLogDeletion As New LogDeletion
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            "Crew Wages", _
                            "Crewing", _
                            TableName, _
                            "PKey IN ('" & strID & "')", _
                            "<< Delete Crew Data - Crew Wages >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <Crew Wages>", _
                            GetUserName())
                        '-->

                        info = DB.RunSql("DELETE dbo.tblWageOnb WHERE PKey ='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
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

    Private Sub tcgWages_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles tcgWages.SelectedPageChanged
        isVWEditable()
        GetSelectedView()
        LoadSub()
    End Sub

    Private Sub tcgWages_SelectedPageChanging(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangingEventArgs) Handles tcgWages.SelectedPageChanging
        If BRECORDUPDATEDs Then
            'If MsgBox("Would you like to save the changes you made on " & GetDesc() & "?", MsgBoxStyle.YesNoCancel, strCaption) = MsgBoxResult.Yes Then
            '    tabChanged = True
            '    SaveData()
            'ElseIf MsgBoxResult.No Then
            '    RefreshData()
            'Else
            '    e.Cancel = True
            'End If
            Dim msgans As Integer
            msgans = MsgBox("Would you like to save the changes you made on " & GetDesc() & "?", MsgBoxStyle.YesNoCancel, strCaption)
            'If MsgBox("Would you like to save the changes you made on " & e.PrevPage.Text & "?", MsgBoxStyle.YesNoCancel, strCaption) = MsgBoxResult.Yes Then
            If msgans = MsgBoxResult.Yes Then
                tabChanged = True
                SaveData()
            ElseIf msgans = MsgBoxResult.No Then
                RefreshData()
                'ElseIf MsgBoxResult.Cancel Then
            Else
                e.Cancel = True
            End If
        End If
    End Sub


#End Region

#Region "Base Functions"

    Private Sub GetSelectedView()
        Select Case Me.tcgWages.SelectedTabPage.Tag
            Case "FW" 'Fixed Wages
                SetEditOptionsVisibility(Name, False) 'Hide Editing Option
            Case "VW" 'Variable Wages
                SetEditOptionsVisibility(Name, True) 'Hide Editing Option
                Select Case tcgVarWages.SelectedTabPage.Tag
                    Case "Earn"
                        'Me.VWEarnView.Focus()
                        focusedView = VWEarnView
                        SetDeleteCaption(Name, "Delete Earning")
                    Case "Ded"
                        'Me.VWDedView.Focus()
                        focusedView = VWDedView
                        SetDeleteCaption(Name, "Delete Deduction")
                End Select
        End Select
    End Sub

    'Get Referential Currency
    Private Function GetRefCurr() As String
        Return DB.DLookUp("PKey", "tblAdmCurr", "", "Ref=1")
    End Function

    'Check if the Selectedt Activity is Editable of NOT
    Private Function isVWEditable() As Boolean
        Dim RetVal As Boolean = False
        If tcgWages.SelectedTabPage.Tag = "VW" Then
            Dim CurrrentActGrpID As String = ""
            Dim SelectedActGrpID As String = ""
            Dim ActType As String = ""
   
            If tblAcivity.Rows.Count > 0 Then
                With ActView
                    ActType = IfNull(.GetRowCellValue(.FocusedRowHandle, "ActivityType"), "").ToUpper
                    SelectedActGrpID = IfNull(.GetRowCellValue(.FocusedRowHandle, "ActGrpID"), "")
                End With

                If ActType.Equals("SEA") Then
                    If SelectedActGrpID.Equals(getLatestSEAActGrpID()) Then
                        RetVal = True
                    Else
                        RetVal = False
                    End If
                Else
                    RetVal = False
                End If
            Else
                RetVal = True
            End If
        End If
        AllowEditing(Name, RetVal)
        Return RetVal
    End Function

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

    Private Sub ActView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ActView.FocusedRowChanged
        LoadWages()
        isVWEditable()
        'If isVWEditable() Then
        '    AllowEditing(Name, True)
        'Else
        '    AllowEditing(Name, False)
        'End If
    End Sub

    'get Code
    Private Sub GetActivityCode()
        With ActView
            ActID = IfNull(.GetRowCellValue(.FocusedRowHandle, "ActID"), "")
            FKeyWScaleRankCode = IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyWScaleRankCode"), "")
            FKeyWScaleCode = IfNull(.GetRowCellValue(.FocusedRowHandle, "FkeyWScaleCode"), "")
            DateStart = .GetRowCellValue(.FocusedRowHandle, "DateStarted")
        End With
    End Sub

    Private Sub ActView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ActView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#Region "Earnings"

    Private Sub tcgVarWages_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles tcgVarWages.SelectedPageChanged
        PrevTab = Me.tcgVarWages.SelectedTabPage.Tag
        GetSelectedView()
        LoadVarriableWages()
        tabChanged = True
    End Sub

    Private Sub LoadVarriableWages()
        Select Case tcgVarWages.SelectedTabPage.Tag
            Case "Earn"
                VWEarnGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) AS Edited FROM dbo.tblWageOnb WHERE FKeyIDNbr='" & strID & "' AND FKeyActivityID='" & ActID & "' AND WageType=1")
                isAllowDelete(VWEarnView)
            Case "Ded"
                VWDedGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) AS Edited FROM dbo.tblWageOnb WHERE FKeyIDNbr='" & strID & "' AND FKeyActivityID='" & ActID & "' AND WageType=2")
                isAllowDelete(VWDedView)
        End Select
    End Sub

    Private Sub isAllowDelete(_view As DevExpress.XtraGrid.Views.Grid.GridView)
        If _view.RowCount > 0 Then
            AllowDeletion(Name, True)
        Else
            AllowDeletion(Name, False)
        End If
    End Sub


    Private Function SaveEarnings(FKeyIDNbr As String, CurrActID As String) As ArrayList
        Dim query As New ArrayList
        Dim WageType As Integer = 1
        With focusedView
            .CloseEditForm()
            .UpdateCurrentRow()
            For nRowCount As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(nRowCount, "Edited") Then
                    Dim DateStart As String = ChangeToSQLDate(.GetRowCellValue(nRowCount, "DateStart"))
                    Dim DateEnd As String = ChangeToSQLDate(.GetRowCellValue(nRowCount, "DateEnd"))

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Onboard Wages", 0, System.Environment.MachineName, "Vessel : " & IfNull(ActView.GetRowCellDisplayText(.FocusedRowHandle, "Vessel"), "") & " - " & .GetRowCellDisplayText(nRowCount, "FKeyWageOnbID"), "Crew Wages - Variable Wages - Earnings", FKeyIDNbr) 'neil

                    If IfNull(.GetRowCellValue(nRowCount, "PKey"), "").Equals("") Then
                        query.Add("INSERT INTO dbo.tblWageOnb(" & _
                                  "FKeyIDNbr," & _
                                  "FKeyActivityID," & _
                                  "FKeyWageOnbID," & _
                                  "WageType," & _
                                  "Amt," & _
                                  "Formula," & _
                                  "FKeyCurr," & _
                                  "DateStart," & _
                                  "DateEnd," & _
                                  "Remarks," & _
                                  "LastUpdatedBy)" & _
                                  " VALUES(" & _
                                  "'" & FKeyIDNbr & "'," & _
                                  "'" & CurrActID & "'," & _
                                  "'" & .GetRowCellValue(nRowCount, "FKeyWageOnbID") & "'," & _
                                  "" & WageType & "," & _
                                  "" & .GetRowCellValue(nRowCount, "Amt") & "," & _
                                  "'" & .GetRowCellValue(nRowCount, "Formula") & "'," & _
                                  "'" & .GetRowCellValue(nRowCount, "FKeyCurr") & "'," & _
                                  "" & DateStart & "," & _
                                  "" & DateEnd & "," & _
                                  "'" & .GetRowCellValue(nRowCount, "Remarks") & "'," & _
                                  "'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblWageOnb SET " & _
                                  "FKeyWageOnbID='" & .GetRowCellValue(nRowCount, "FKeyWageOnbID") & "'" & _
                                  ",Amt=" & .GetRowCellValue(nRowCount, "Amt") & _
                                  ",Formula='" & .GetRowCellValue(nRowCount, "Formula") & "'" & _
                                  ",DateStart=" & DateStart & _
                                  ",DateEnd=" & DateEnd & _
                                  ",Remarks='" & .GetRowCellValue(nRowCount, "Remarks") & "'" & _
                                  ",FKeyCurr='" & .GetRowCellValue(nRowCount, "FKeyCurr") & "'" & _
                                  ",LastUpdatedBy='" & LastUpdatedBy & "'" & _
                                  ",DateUpdated= getdate()" & _
                                  " WHERE FKeyIDNbr='" & FKeyIDNbr & "' AND FKeyActivityID='" & CurrActID & "' AND PKey='" & .GetRowCellValue(nRowCount, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub VWEarnView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles VWEarnView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub VWEarnView_GotFocus(sender As Object, e As System.EventArgs) Handles VWEarnView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.RowCount > 0 Then
            AllowDeletion(Name, True)
        Else
            AllowDeletion(Name, False)
        End If

        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Earning")
        Else
            focusedView = Nothing
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub VWEarnView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles VWEarnView.InitNewRow
        Dim CView As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        CView.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        CView.SetRowCellValue(e.RowHandle, "FKeyIDNbr", strID) 'Crew ID
        CView.SetRowCellValue(e.RowHandle, "FKeyActivityID", IfNull(blList.GetFocusedRowData("CurrActID"), "NULL"))
        CView.SetRowCellValue(e.RowHandle, "WageType", 1)
        CView.SetRowCellValue(e.RowHandle, "FKeyCurr", GetRefCurr())
        CView.SetRowCellValue(e.RowHandle, "DateStart", DateStart)
        SubAddMode = True
    End Sub

    Private Sub VWEarnView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles VWEarnView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub VWEarnView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles VWEarnView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub VWEarnView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles VWEarnView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr,Amt,FKeyWageOnbID,DateStart")
    End Sub

    Private Sub VWEarnView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles VWEarnView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub VWEarnView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles VWEarnView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FKeyWageOnbID As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyWageOnbID")
        Dim Amt As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Amt")
        Dim DateStart As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateStart")
        Dim FKeyCurr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCurr")

        With view

            'FKeyWageOnbID
            If .GetRowCellValue(e.RowHandle, FKeyWageOnbID) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyWageOnbID) Is Nothing Then
                .SetColumnError(FKeyWageOnbID, "Please select an earning.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, FKeyWageOnbID).Equals("") Then
                    .SetColumnError(FKeyWageOnbID, "Please select an earning.")
                    e.Valid = False
                Else
                    .SetColumnError(FKeyWageOnbID, "")
                End If
            End If

            'FKeyCurr
            If .GetRowCellValue(e.RowHandle, FKeyCurr) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyCurr) Is Nothing Then
                .SetColumnError(FKeyCurr, "Please select a currency.")
                e.Valid = False
            Else
                .SetColumnError(FKeyCurr, "")
            End If

            'Amount
            If .GetRowCellValue(e.RowHandle, Amt) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Amt) Is Nothing Then
                .SetColumnError(Amt, "Please Enter Amount.")
                e.Valid = False
            Else
                .SetColumnError(Amt, "")
            End If

            'DateStart
            If .GetRowCellValue(e.RowHandle, DateStart) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, DateStart) Is Nothing Then
                .SetColumnError(DateStart, "Please Enter Date Start.")
                e.Valid = False
            Else
                .SetColumnError(DateStart, "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                BRECORDUPDATEDs = True
            End If
        End With
    End Sub

    Private Sub VWEarnView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles VWEarnView.ValidatingEditor

    End Sub

#End Region

#Region "Deductions"

    Private Function SaveDed(FKeyIDNbr As String, CurrActID As String) As ArrayList
        Dim query As New ArrayList
        Dim WageType As Integer = 2
        With focusedView
            .CloseEditForm()
            .UpdateCurrentRow()
            For nRowCount As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(nRowCount, "Edited") Then
                    Dim DateStart As String = ChangeToSQLDate(.GetRowCellValue(nRowCount, "DateStart"))
                    Dim DateEnd As String = ChangeToSQLDate(.GetRowCellValue(nRowCount, "DateEnd"))

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Onboard Wages", 0, System.Environment.MachineName, "Vessel : " & IfNull(ActView.GetRowCellDisplayText(.FocusedRowHandle, "Vessel"), "") & " - " & .GetRowCellDisplayText(nRowCount, "FKeyWageOnbID"), "Crew Wages - Varialbe Wages - Deductions", FKeyIDNbr) 'neil

                    If IfNull(.GetRowCellValue(nRowCount, "PKey"), "").Equals("") Then
                        query.Add("INSERT INTO dbo.tblWageOnb(" & _
                                  "FKeyIDNbr," & _
                                  "FKeyActivityID," & _
                                  "FKeyWageOnbID," & _
                                  "WageType," & _
                                  "Amt," & _
                                  "Formula," & _
                                  "FKeyCurr," & _
                                  "DateStart," & _
                                  "DateEnd," & _
                                  "Remarks," & _
                                  "LastUpdatedBy)" & _
                                  " VALUES(" & _
                                  "'" & FKeyIDNbr & "'," & _
                                  "'" & CurrActID & "'," & _
                                  "'" & .GetRowCellValue(nRowCount, "FKeyWageOnbID") & "'," & _
                                  "" & WageType & "," & _
                                  "" & .GetRowCellValue(nRowCount, "Amt") & "," & _
                                  "'" & .GetRowCellValue(nRowCount, "Formula") & "'," & _
                                  "'" & .GetRowCellValue(nRowCount, "FKeyCurr") & "'," & _
                                  "" & DateStart & "," & _
                                  "" & DateEnd & "," & _
                                  "'" & .GetRowCellValue(nRowCount, "Remarks") & "'," & _
                                  "'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblWageOnb SET " & _
                                  "FKeyWageOnbID='" & .GetRowCellValue(nRowCount, "FKeyWageOnbID") & "'" & _
                                  ",Amt=" & .GetRowCellValue(nRowCount, "Amt") & _
                                  ",Formula='" & .GetRowCellValue(nRowCount, "Formula") & "'" & _
                                  ",DateStart=" & DateStart & _
                                  ",DateEnd=" & DateEnd & _
                                  ",Remarks='" & .GetRowCellValue(nRowCount, "Remarks") & "'" & _
                                  ",FKeyCurr='" & .GetRowCellValue(nRowCount, "FKeyCurr") & "'" & _
                                  ",LastUpdatedBy='" & LastUpdatedBy & "'" & _
                                  ",DateUpdated= getdate()" & _
                                  " WHERE FKeyIDNbr='" & FKeyIDNbr & "' AND FKeyActivityID='" & CurrActID & "' AND PKey='" & .GetRowCellValue(nRowCount, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub VWDedView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles VWDedView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End If
        End With
    End Sub

    Private Sub VWDedView_GotFocus(sender As Object, e As System.EventArgs) Handles VWDedView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If view.RowCount > 0 Then
            AllowDeletion(Name, True)
        Else
            AllowDeletion(Name, False)
        End If

        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Deduction")
        Else
            focusedView = Nothing
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub VWDedView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles VWDedView.InitNewRow
        Dim CView As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        CView.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        CView.SetRowCellValue(e.RowHandle, "FKeyIDNbr", strID) 'Crew ID
        CView.SetRowCellValue(e.RowHandle, "FKeyActivityID", IfNull(blList.GetFocusedRowData("CurrActID"), "NULL"))
        CView.SetRowCellValue(e.RowHandle, "FKeyCurr", GetRefCurr())
        CView.SetRowCellValue(e.RowHandle, "WageType", 2)
        CView.SetRowCellValue(e.RowHandle, "DateStart", DateStart)
        SubAddMode = True
    End Sub

    Private Sub VWDedView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles VWDedView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub VWDedView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles VWDedView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub VWDedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles VWDedView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCurr,Amt,FKeyWageOnbID,DateStart")
    End Sub

    Private Sub VWDedView_RowCountChanged(sender As Object, e As System.EventArgs) Handles VWDedView.RowCountChanged
        Dim v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If v.RowCount > 0 Then
            AllowDeletion(Name, True)
        Else
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub VWDedView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles VWDedView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub VWDedView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles VWDedView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FKeyWageOnbID As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyWageOnbID")
        Dim Amt As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Amt")
        Dim DateStart As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateStart")
        Dim FKeyCurr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCurr")

        With view

            'FKeyWageOnbID
            If .GetRowCellValue(e.RowHandle, FKeyWageOnbID) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyWageOnbID) Is Nothing Then
                .SetColumnError(FKeyWageOnbID, "Please select a deduction.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, FKeyWageOnbID).Equals("") Then
                    .SetColumnError(FKeyWageOnbID, "Please select an earning.")
                    e.Valid = False
                Else
                    .SetColumnError(FKeyWageOnbID, "")
                End If
            End If

            'FKeyCurr
            If .GetRowCellValue(e.RowHandle, FKeyCurr) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyCurr) Is Nothing Then
                .SetColumnError(FKeyCurr, "Please select a currency.")
                e.Valid = False
            Else
                .SetColumnError(FKeyCurr, "")
            End If

            'Amount
            If .GetRowCellValue(e.RowHandle, Amt) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Amt) Is Nothing Then
                .SetColumnError(Amt, "Please Enter Amount.")
                e.Valid = False
            Else
                .SetColumnError(Amt, "")
            End If

            'DateStart
            If .GetRowCellValue(e.RowHandle, DateStart) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, DateStart) Is Nothing Then
                .SetColumnError(DateStart, "Please Enter Date Start.")
                e.Valid = False
            Else
                .SetColumnError(DateStart, "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                BRECORDUPDATEDs = True
            End If
        End With
    End Sub

    Private Sub VWDedView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles VWDedView.ValidatingEditor

    End Sub

#End Region

#Region "Fixed Wages"

    Private Sub LoadFixedWages()

        Select Case tcgFixWages.SelectedTabPage.Tag
            Case "Earnings"
                EarnGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWscaleOnb where FKeyWScaleRank='" & FKeyWScaleRankCode & "' AND WageType =1")
            Case "Deduction"
                DedGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWscaleOnb where FKeyWScaleRank='" & FKeyWScaleRankCode & "' AND WageType =2")
            Case "WageInfo"
                InfoGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWScaleInfo where FKeyWScaleRank='" & FKeyWScaleRankCode & "'")
            Case "Employee"
                GrdEmpe.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWscaleAsh where FKeyWScaleRank='" & FKeyWScaleRankCode & "' AND WageType =2")
            Case "Employer"
                GrdEmpr.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWscaleAshEmp where FKeyWScaleRank='" & FKeyWScaleRankCode & "'")
        End Select

    End Sub

    Private Sub tcgFixWages_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles tcgFixWages.SelectedPageChanged
        GetSelectedView()
        LoadFixedWages()

        'LoadSub()
    End Sub


#Region "ONB Earning"

    Private Sub EarnView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EarnView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#Region "ONB Ded"

    Private Sub DedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DedView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#Region "Onb INFo View"

    Private Sub InfoView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles InfoView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#Region "ONB Employee Contribution"

    Private Sub EmpeView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EmpeView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#Region "Employers Contribution"

    Private Sub EmprView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EmprView.RowCellStyle
        ViewRowCellStyle(sender, e)
    End Sub

#End Region

#End Region


    Private Sub repInfoDateType_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles repInfoDateType.ParseEditValue
        Try
            e.Value = Convert.ToInt32(e.Value)
            e.Handled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try
    End Sub

    Private Sub DedView_RowCountChanged(sender As Object, e As System.EventArgs) Handles DedView.RowCountChanged
        Dim v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If v.RowCount > 0 Then
                AllowDeletion(Name, True)
            Else
                AllowDeletion(Name, False)
            End If
    End Sub

    Private Sub EarnView_RowCountChanged(sender As Object, e As System.EventArgs) Handles EarnView.RowCountChanged
        Dim v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If v.RowCount > 0 Then
            AllowDeletion(Name, True)
        Else
            AllowDeletion(Name, False)
        End If
    End Sub
End Class
