Imports System.Windows.Forms
Public Class CrewAmortization
    Dim dtWageAsh As New DataTable
    Dim dtCurrency As New DataTable
    Dim dtRemitAllottee As New DataTable
    Private tblAmortDistrib As DataTable
    Dim payFunch As New PayrollFunctions
    Dim dtAmortization As New DataTable
    Dim CrewID As String
    Dim LastUpdatedBy As String
    Dim clsAudit As New clsAudit
#Region "Overridables"

    Private Sub GenerateDT()
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandText = "SP_CrewAmortization"
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@FKeyIDNbr", strID)
                End With
                Using Adp As New SqlClient.SqlDataAdapter(cmd)
                    Dim DT As New DataSet
                    Adp.Fill(DT)
                    With DT

                        .Tables(0).TableName = "Amortization"
                        dtAmortization = .Tables(0)
                        .Tables(1).TableName = "AmortDistrib"
                        tblAmortDistrib = .Tables(1)
                        .Tables(2).TableName = "RemitAllot"
                        dtRemitAllottee = .Tables(2)

                    End With
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
        End Try
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        Me.LayoutControl1.AllowCustomization = False

        If bLoaded = False Then
            SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)

            SetAddCaption(Name, "Add")
            SetSaveCaption(Name, "Save")
            SetEditCaption(Name, "Edit")
            SetDeleteCaption(Name, "Delete")

            initDatatables()
            'initAmortizationDT()
            clsAudit.propSQLConnStr = DB.GetConnectionString
            bLoaded = True
        End If

        CrewID = blList.GetID()
        If CrewID <> "" Then
            GenerateDT()
            'dtRemitAllottee = DB.CreateTable("SELECT LName + ', ' + FName + ' ' + ISNULL(MName, '') as Name, PKey FROM tblRemittance WHERE FKeyIDNbr = '" & CrewID & "' ORDER BY Name")
            lueRemitAllot.Properties.DataSource = dtRemitAllottee
            gcAmortDistrib.DataSource = tblAmortDistrib
            gcCrewAmort.DataSource = dtAmortization
            LoadAmortDetails()
            LoadAmortPayment()
            'dtAmortization.Rows.Clear()
            'For Each rNew As DataRow In DB.CreateTable("SELECT [PKey],[FKeyWageAsh],[RefNo],[LoanAmt],[LoanDate],[DateGranted],dbo.periodToDate([StartPeriod]) as StartPeriod,[MonthlyDed],[LoanInterest],[OtherCharge],[FKeyCurrency],[FKeyRemitAllot],[Remarks] FROM [dbo].[tblAmortization] WHERE FKeyIDNbr = '" & CrewID & "'").Rows
            '    dtAmortization.ImportRow(rNew)
            'Next
            AllowAddition(Name, True)
        Else
            AllowAddition(Name, False)
        End If

        AllowEditing(Name, Not IfNull(gvCrewAmort.GetFocusedRowCellValue("PKey"), "").Equals(""))
        AllowDeletion(Name, Not IfNull(gvCrewAmort.GetFocusedRowCellValue("PKey"), "").Equals(""))
        EditAddModeControls(True)
        AllowSaving(Name, False)

        RequiredControls = {lueItem}
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        Dim strAmortID As String
        Dim sql As String
        Dim newAmortDT As New DataTable

        If CheckRequiredFields() = True Then
            MsgBox("Please insert data on the required fields.", MsgBoxStyle.Information, GetAppName() & " - Crew Amortization")
            Exit Sub
        End If

        If bAddMode Then strAmortID = "" Else strAmortID = gvCrewAmort.GetFocusedRowCellValue("PKey")
        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "ACT_DESC", 0, System.Environment.MachineName, "DATA_DESC", "Crew Amortization", "")
        sql = "EXECUTE [dbo].[AMORTIZATION_INSERT/UPDATE] " & _
              " @PKey = '" & strAmortID & "'" & _
              ",@FKeyIDNbr = '" & CrewID & "'" & _
              ",@FKeyWageAsh = '" & lueItem.EditValue & "'" & _
              ",@RefNo = '" & txtRefNo.EditValue & "'" & _
              ",@LoanAmt = '" & txtLoanAmt.EditValue & "'" & _
              ",@LoanDate = " & ChangeToSQLDate(deLoanDate.EditValue) & "" & _
              ",@DateGranted = " & ChangeToSQLDate(deDateGranted.EditValue) & "" & _
              ",@StartPeriod = " & payFunch.dateToPeriod(deStartPeriod.EditValue) & "" & _
              ",@MonthlyDed = '" & txtMonDed.EditValue & "'" & _
              ",@LoanInterest = '" & txtInterest.EditValue & "'" & _
              ",@OtherCharge = '" & txtOtherCharge.EditValue & "'" & _
              ",@FKeyCurrency = '" & lueCurrency.EditValue & "'" & _
              ",@FKeyRemitAllot = '" & lueRemitAllot.EditValue & "'" & _
              ",@Remarks = '" & txtRemarks.EditValue & "'" & _
              ",@LastUpdatedBy = '" & LastUpdatedBy & "'"
        newAmortDT = DB.CreateTable(sql)

        If bAddMode = False Then
            For i As Integer = 0 To dtAmortization.Rows.Count - 1
                If strAmortID = dtAmortization.Rows(i).Item("PKey") Then
                    dtAmortization.Rows.Remove(dtAmortization(i))
                    Exit For
                End If
            Next
        End If

        dtAmortization.ImportRow(newAmortDT(0))
        SetSelection(newAmortDT(0)("PKey"))
        MsgBox(GetMessage("Saved", True), MsgBoxStyle.Information, GetAppName)
        AllowAddition(Name, True)
        AllowEditing(Name, True)
        AllowSaving(Name, False)
        AllowDeletion(Name, True)
        bAddMode = False
        isEditdable = False
        EditAddModeControls(True)
        EditCheck(Name, False)
        BRECORDUPDATEDs = False
    End Sub

    Public Overrides Sub AddData()
        MyBase.AddData()
        lueItem.EditValue = Nothing
        txtRefNo.EditValue = Nothing
        deLoanDate.EditValue = Nothing
        deDateGranted.EditValue = Nothing
        lueCurrency.EditValue = Nothing
        txtLoanAmt.EditValue = Nothing
        txtInterest.EditValue = Nothing
        txtOtherCharge.EditValue = Nothing
        txtRemarks.EditValue = Nothing
        deStartPeriod.EditValue = Nothing
        txtMonDed.EditValue = Nothing
        lueRemitAllot.EditValue = Nothing
        txtLoanTotal.EditValue = Nothing
        EditAddModeControls(False)
        bAddMode = True
    End Sub

    Public Overrides Sub EditData()
        'isEditdable = True
        MyBase.EditData()
        'EditAddModeControls(False)
        If isEditdable = False Then
            AllowAddition(Name, True)
            AllowDeletion(Name, True)
            AllowSaving(Name, False)
            EditAddModeControls(True)
        Else
            AllowAddition(Name, False)
            AllowDeletion(Name, False)
            AllowSaving(Name, True)
            EditAddModeControls(False)
        End If
    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        If gvCrewAmort.RowCount = 0 Then
            MessageBox.Show("There's no record to delete.", "MPS5 - Remittances", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MsgBox("Are you sure you want to delete " & gvCrewAmort.GetFocusedRowCellDisplayText("FKeyWageAsh") & "?", MsgBoxStyle.YesNo, "MPS5 - Remittances") = MsgBoxResult.Yes Then
            Dim strDeletedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "Delete Crew Amortization.", 0, System.Environment.MachineName, "Deleted Crew Amortization.", "Crew Amortization", "")
            clsAudit.saveAuditPreDelDetails("tblAmortization", gvCrewAmort.GetFocusedRowCellValue("PKey"), strDeletedBy)
            '<!--added by tony20180922 : Log Deletion
            oLogDeletion.Init()
            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                "Crew Amortization", _
                "Crewing", _
                "tblAmortization", _
                "PKey IN ('" & gvCrewAmort.GetFocusedRowCellValue("PKey") & "')", _
                "<< Delete Crew Data - Crew Amortization >>", _
                LogDeletion.DeletionType.Manual, _
                "Manually Deleted in <Crew Amortization>", _
                GetUserName())
            '-->
            If DB.RunSql("DELETE FROM tblAmortization WHERE PKey = '" & gvCrewAmort.GetFocusedRowCellValue("PKey") & "'") Then
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
            gvCrewAmort.DeleteRow(gvCrewAmort.FocusedRowHandle)
        End If
    End Sub
#End Region

#Region "Inits"
    Private Sub initDatatables()
        dtCurrency = DB.CreateTable("SELECT PKey, Name, Symbol From tblAdmCurr ORDER BY SortCode, Name")
        dtAdmWageAsh = DB.CreateTable("SELECT PKey, Name, WageType From tblAdmWageAsh WHERE WageType = 2 ORDER BY Name")

        lueCurrency.Properties.DataSource = dtCurrency
        lueItem.Properties.DataSource = dtAdmWageAsh
        WageAshEdit.DataSource = dtAdmWageAsh
    End Sub

    Private Sub initAmortizationDT()
        Dim clm As DataColumn

        clm = New DataColumn
        clm.ColumnName = "PKey"
        clm.DataType = System.Type.GetType("System.String")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "FKeyWageAsh"
        clm.DataType = System.Type.GetType("System.String")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "RefNo"
        clm.DataType = System.Type.GetType("System.String")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "LoanAmt"
        clm.DataType = System.Type.GetType("System.Double")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "LoanDate"
        clm.DataType = System.Type.GetType("System.DateTime")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "DateGranted"
        clm.DataType = System.Type.GetType("System.DateTime")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "StartPeriod"
        clm.DataType = System.Type.GetType("System.DateTime")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "MonthlyDed"
        clm.DataType = System.Type.GetType("System.Double")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "LoanInterest"
        clm.DataType = System.Type.GetType("System.Double")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "OtherCharge"
        clm.DataType = System.Type.GetType("System.Double")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "FKeyCurrency"
        clm.DataType = System.Type.GetType("System.String")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "FKeyRemitAllot"
        clm.DataType = System.Type.GetType("System.String")
        dtAmortization.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "Remarks"
        clm.DataType = System.Type.GetType("System.String")
        dtAmortization.Columns.Add(clm)

        gcCrewAmort.DataSource = dtAmortization
    End Sub
#End Region
    Private Sub LoadAmortDetails()
        lueItem.EditValue = gvCrewAmort.GetFocusedRowCellValue("FKeyWageAsh")
        txtRefNo.EditValue = gvCrewAmort.GetFocusedRowCellValue("RefNo")
        deLoanDate.EditValue = gvCrewAmort.GetFocusedRowCellValue("LoanDate")
        deDateGranted.EditValue = gvCrewAmort.GetFocusedRowCellValue("DateGranted")
        lueCurrency.EditValue = gvCrewAmort.GetFocusedRowCellValue("FKeyCurrency")
        txtLoanAmt.EditValue = IfNull(gvCrewAmort.GetFocusedRowCellValue("LoanAmt"), CDbl(0.0))
        txtInterest.EditValue = IfNull(gvCrewAmort.GetFocusedRowCellValue("LoanInterest"), CDbl(0.0))
        txtOtherCharge.EditValue = IfNull(gvCrewAmort.GetFocusedRowCellValue("OtherCharge"), CDbl(0.0))
        txtRemarks.EditValue = gvCrewAmort.GetFocusedRowCellValue("Remarks")
        deStartPeriod.EditValue = gvCrewAmort.GetFocusedRowCellValue("StartPeriod")
        txtMonDed.EditValue = IfNull(gvCrewAmort.GetFocusedRowCellValue("MonthlyDed"), CDbl(0.0))
        lueRemitAllot.EditValue = gvCrewAmort.GetFocusedRowCellValue("FKeyRemitAllot")
        txtLoanTotal.EditValue = IfNull(txtLoanAmt.EditValue, 0) + IfNull(txtInterest.EditValue, 0) + IfNull(txtOtherCharge.EditValue, 0)
    End Sub

    Private Sub LoadAmortPayment()
        'tblAmortDistrib = DB.CreateTable("SELECT * FROM dbo.frm_Pay_CrewAmort_distrib WHERE FKeyIDNbr = '" & strID & "' AND PKey ='" & GetSelectedAmortID() & "'")
        'gcAmortDistrib.DataSource = tblAmortDistrib
        'Filter Amort List
        gvAmortDistrib.ActiveFilter.NonColumnFilter = "PKey = '" & GetSelectedAmortID() & "'"
        txtPaid.Text = getTotalPaid()
        txtRemain.Text = getRemaining()

    End Sub

    Private Function getTotalPaid() As Double
        'Dim retval As Double
        Dim cVal As Double = Math.Round(IfNull(tblAmortDistrib.Compute("SUM(AmtPd)", "PKey = '" & GetSelectedAmortID() & "'"), CDbl(0)), 2, MidpointRounding.AwayFromZero)
        Return cVal
    End Function

    Private Function getRemaining() As Double
        Return Math.Round(CDbl(txtLoanTotal.Text) - getTotalPaid(), 2, MidpointRounding.AwayFromZero)
    End Function

    Private Function GetSelectedAmortID() As String
        Dim retVal As String = String.Empty
        Return IfNull(gvCrewAmort.GetFocusedRowCellValue("PKey"), String.Empty)
    End Function

    Private Sub gvCrewAmort_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles gvCrewAmort.BeforeLeaveRow
        'If (bAddMode Or isEditdable) And BRECORDUPDATEDs Then
        '    e.Allow = Not CheckValidateFields()
        'End If
    End Sub

    Private Sub gvCrewAmort_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvCrewAmort.FocusedRowChanged
        ''If bAddMode Or isEditdable Then Exit Sub
        'lueItem.EditValue = gvCrewAmort.GetFocusedRowCellValue("FKeyWageAsh")
        'txtRefNo.EditValue = gvCrewAmort.GetFocusedRowCellValue("RefNo")
        'deLoanDate.EditValue = gvCrewAmort.GetFocusedRowCellValue("LoanDate")
        'deDateGranted.EditValue = gvCrewAmort.GetFocusedRowCellValue("DateGranted")
        'lueCurrency.EditValue = gvCrewAmort.GetFocusedRowCellValue("FKeyCurrency")
        'txtLoanAmt.EditValue = IfNull(gvCrewAmort.GetFocusedRowCellValue("LoanAmt"), CDbl(0.0))
        'txtInterest.EditValue = IfNull(gvCrewAmort.GetFocusedRowCellValue("LoanInterest"), CDbl(0.0))
        'txtOtherCharge.EditValue = IfNull(gvCrewAmort.GetFocusedRowCellValue("OtherCharge"), CDbl(0.0))
        'txtRemarks.EditValue = gvCrewAmort.GetFocusedRowCellValue("Remarks")
        'deStartPeriod.EditValue = gvCrewAmort.GetFocusedRowCellValue("StartPeriod")
        'txtMonDed.EditValue = IfNull(gvCrewAmort.GetFocusedRowCellValue("MonthlyDed"), CDbl(0.0))
        'lueRemitAllot.EditValue = gvCrewAmort.GetFocusedRowCellValue("FKeyRemitAllot")
        'txtLoanTotal.EditValue = IfNull(txtLoanAmt.EditValue, 0) + IfNull(txtInterest.EditValue, 0) + IfNull(txtOtherCharge.EditValue, 0)
        LoadAmortDetails()
        LoadAmortPayment()
        EditAddModeControls(True)
        bAddMode = False
        isEditdable = False
        BRECORDUPDATEDs = False
    End Sub

    Private Sub EditAddModeControls(ByVal bol As Boolean)
        txtInterest.ReadOnly = bol
        txtLoanAmt.ReadOnly = bol
        txtMonDed.ReadOnly = bol
        txtOtherCharge.ReadOnly = bol
        txtRefNo.ReadOnly = bol
        txtRemarks.ReadOnly = bol
        lueCurrency.ReadOnly = bol
        lueItem.ReadOnly = bol
        lueRemitAllot.ReadOnly = bol
        deLoanDate.ReadOnly = bol
        deStartPeriod.ReadOnly = bol
        deDateGranted.ReadOnly = bol

        If Not bol Then
            txtRefNo.BackColor = REQUIRED_COLOR
            txtLoanAmt.BackColor = REQUIRED_COLOR
            txtMonDed.BackColor = REQUIRED_COLOR
            deDateGranted.BackColor = REQUIRED_COLOR
            deStartPeriod.BackColor = REQUIRED_COLOR
            deLoanDate.BackColor = REQUIRED_COLOR
            lueCurrency.BackColor = REQUIRED_COLOR
            lueItem.BackColor = REQUIRED_COLOR
            lueRemitAllot.BackColor = REQUIRED_COLOR
        Else
            txtRefNo.BackColor = DISABLED_COLOR
            txtLoanAmt.BackColor = DISABLED_COLOR
            txtMonDed.BackColor = DISABLED_COLOR
            deDateGranted.BackColor = DISABLED_COLOR
            deStartPeriod.BackColor = DISABLED_COLOR
            deLoanDate.BackColor = DISABLED_COLOR
            lueCurrency.BackColor = DISABLED_COLOR
            lueItem.BackColor = DISABLED_COLOR
            lueRemitAllot.BackColor = DISABLED_COLOR
        End If
      
        'EditCheck(Name, Not bol)
    End Sub

    Private Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = gvCrewAmort.Columns("PKey")
            RowHandle = gvCrewAmort.LocateByValue(0, Col, id)
            gvCrewAmort.FocusedRowHandle = RowHandle
            gvCrewAmort.TopRowIndex = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Function CheckRequiredFields() As Boolean
        If txtRefNo.Text = "" Then
            txtRefNo.Focus()
            Return True
        End If
        If txtLoanAmt.Text = "" Then
            txtLoanAmt.Focus()
            Return True
        End If
        If txtMonDed.Text = "" Then
            txtMonDed.Focus()
            Return True
        End If
        If deDateGranted.Text = "" Then
            deDateGranted.Focus()
            Return True
        End If
        If deStartPeriod.Text = "" Then
            deStartPeriod.Focus()
            Return True
        End If
        If deLoanDate.Text = "" Then
            deLoanDate.Focus()
            Return True
        End If
        If lueCurrency.Text = "" Then
            lueCurrency.Focus()
            Return True
        End If
        If lueItem.Text = "" Then
            lueItem.Focus()
            Return True
        End If
        If lueRemitAllot.Text = "" Then
            lueRemitAllot.Focus()
            Return True
        End If
        Return False
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel, GetAppName)
        If res = MsgBoxResult.Yes Then
            flag = True
            ALLOWNEXTS = flag
            SaveData()
        ElseIf res = MsgBoxResult.No Then
            'RefreshData()
            flag = False
            ALLOWNEXTS = True
            BRECORDUPDATEDs = False
        End If
        Return flag
    End Function

    Private Sub amortControls_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtInterest.EditValueChanged, txtLoanAmt.EditValueChanged, txtLoanTotal.EditValueChanged, txtMonDed.EditValueChanged, txtOtherCharge.EditValueChanged, txtRefNo.EditValueChanged, txtRemarks.EditValueChanged, deDateGranted.EditValueChanged, deLoanDate.EditValueChanged, deStartPeriod.EditValueChanged, lueCurrency.EditValueChanged, lueItem.EditValueChanged, lueRemitAllot.EditValueChanged
        If bAddMode Or isEditdable Then BRECORDUPDATEDs = True
    End Sub

    Private Sub gvCrewAmort_FocusedRowLoaded(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles gvCrewAmort.FocusedRowLoaded
        LoadAmortPayment()
    End Sub
End Class
