Public Class AdmPayrollPassword


#Region "Declaration"

    Private tblPayLog As New DataTable
    Dim isBuilt As Boolean = False
    Dim sPeriod As Integer = 0
    Private tblUsers As New DataTable
    Private tblLogType As New DataTable

#End Region

    Private Sub cmdChangePayPass_Click(sender As System.Object, e As System.EventArgs) Handles cmdChangePayPass.Click
        Dim frm As New fdlgAdmPayrollPass(DB)
        frm.ShowDialog(Me)
        RefreshData()
    End Sub

    Private Sub InitControls()
        tblUsers = DB.CreateTable("SELECT [ID] AS PKey,[Name] FROM dbo.MSysSec_Users ORDER BY Name")
        cboPeriod.Properties.DataSource = GetPeriods()
        cboUserName.Properties.DataSource = tblUsers
        tblLogType = DB.CreateTable("SELECT * FROM dbo.MSys_Pay_LogType ORDER BY Name")
        cboLogType.Properties.DataSource = tblLogType

        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditOptionsVisibility(Name, False)
    End Sub


    Private Sub LoadPayrollDetails()
        cboPayType.Properties.DataSource = PayrollTypeDataSource()
        cboVessel.Properties.DataSource = VesselDataSource()
        cboPrincipal.Properties.DataSource = PrincipalDataSource()
        cboRefNo.Properties.DataSource = RefNoDataSource()
        cboCompName.Properties.DataSource = ComputerNameDataSource()
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If Not bLoaded Then
            InitControls()
            bLoaded = True
        End If

        Dim strPass As String = IIf(DB.GetConfig(PAYROLL_UNLOCK_KEY).Trim.Length > 0, DB.GetConfig(PAYROLL_UNLOCK_KEY), DEFAULT_PASSWORD)
        If strPass.Equals(DEFAULT_PASSWORD) Then
            lcicmdChangePass.Text = "The password is currently set on default password: 12345"
            lcicmdChangePass.TextVisible = True
        Else
            lcicmdChangePass.Text = String.Empty
            lcicmdChangePass.TextVisible = False
        End If
    End Sub


    Private Sub cmdBuildData_Click(sender As System.Object, e As System.EventArgs) Handles cmdBuildData.Click
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = Nothing
        tblPayLog = Nothing
        ClearFields(LayoutControlGroup4, False)
        ClearFields(LayoutControlGroup3, False)
        ClearFields(LayoutControlGroup7, False)
        tblPayLog = DB.Log_CreateTable("SELECT *,FORMAT(DateOFAction,'yyyyMMdd') AS ActionDate FROM dbo.tblPayLog WHERE MCode ='" & IfNull(cboPeriod.EditValue, String.Empty) & "' ORDER BY DateOFAction DESC ")
        GridControl1.DataSource = tblPayLog
        LoadPayrollDetails()
        sPeriod = cboPeriod.EditValue
        isBuilt = True
        PayrollLogReadOnly()
        Cursor = Cursors.Default

    End Sub


#Region "Payroll Details Log"

    'Private Sub cboLogType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboLogType.EditValueChanged
    '    If Not LockType.Equals(cboLogType.EditValue) Then
    '        isBuilt = False
    '    Else
    '        isBuilt = True
    '    End If
    '    PayrollLogReadOnly()
    'End Sub

    Private Sub cboPeriod_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        If Not sPeriod.Equals(cboPeriod.EditValue) Then
            isBuilt = False
        Else
            isBuilt = True
        End If
        PayrollLogReadOnly()
    End Sub

    Private Sub PayrollLogReadOnly()
        If isBuilt Then
            RemoveReadOnlyListener(LayoutControlGroup4)
            RemoveReadOnlyListener(LayoutControlGroup3)
            RemoveReadOnlyListener(LayoutControlGroup7)
        Else
            MakeReadOnlyListener(LayoutControlGroup7)
            MakeReadOnlyListener(LayoutControlGroup4)
            MakeReadOnlyListener(LayoutControlGroup3)
        End If
    End Sub

    Private Function getFilterString() As String
        Dim retVal As String = String.Empty

        'Dim strPeriod As String = String.Empty
        'If Not IfNull(cboPeriod.EditValue, "").Equals("") Then
        '    strPeriod = " AND MCode = " & CInt(IfNull(cboPeriod.EditValue, 0))
        'Else
        '    strPeriod = String.Empty
        'End If
        Dim strLockType As String = String.Empty
        If Not IfNull(cboLogType.EditValue, "").Equals("") Then
            strLockType = " AND LogType = " & CInt(IfNull(cboLogType.EditValue, ""))
        Else
            strLockType = String.Empty
        End If

        Dim strPayType As String = String.Empty
        If Not IfNull(cboPayType.EditValue, "").Equals("") Then
            strPayType = " AND PayType= '" & cboPayType.EditValue & "'"
        Else
            strPayType = String.Empty
        End If

        Dim strRefNo As String = String.Empty
        If Not IfNull(cboRefNo.EditValue, "").Equals("") Then
            strPayType = " AND RefNo = '" & cboRefNo.EditValue & "'"
        Else
            strRefNo = String.Empty
        End If

        Dim strPrincipal As String = String.Empty
        If Not IfNull(cboPrincipal.EditValue, "").Equals("") Then
            strPrincipal = " AND Principal='" & cboPrincipal.EditValue & "'"
        Else
            strPrincipal = ""
        End If

        Dim strVessel As String = String.Empty
        If Not IfNull(cboVessel.EditValue, "").Equals("") Then
            strVessel = " AND Vessel ='" & cboVessel.EditValue & "' "
        Else
            strVessel = String.Empty
        End If

        Dim strCompName As String = String.Empty
        If Not IfNull(cboCompName.EditValue, "").Equals("") Then
            strCompName = " AND ComputerName ='" & cboCompName.EditValue & "' "
        Else
            strCompName = String.Empty
        End If

        Dim strUserName As String = String.Empty
        If Not IfNull(cboUserName.EditValue, "").Equals("") Then
            strUserName = " AND UserID ='" & cboUserName.EditValue & "' "
        Else
            strUserName = String.Empty
        End If


        Dim strFrom As String = String.Empty
        If Not IsNothing(cboFrom.EditValue) And IsNothing(cboTo.EditValue) Then
            strFrom = " AND ActionDate >=" & CDate(cboFrom.EditValue).ToString("yyyyMMdd") & " "
        ElseIf Not IsNothing(cboFrom.EditValue) And Not IsNothing(cboTo.EditValue) Then
            strFrom = " AND ActionDate >=" & CDate(cboFrom.EditValue).ToString("yyyyMMdd") & " AND ActionDate <=" & CDate(cboTo.EditValue).ToString("yyyyMMdd") & ""
            'strFrom = " AND ActionDate BETWEEN " & CDate(cboFrom.EditValue).ToString("yyyyMMdd") & " AND " & CDate(cboTo.EditValue).ToString("yyyyMMdd") & " "
        ElseIf Not IsNothing(cboTo.EditValue) And IsNothing(cboFrom.EditValue) Then
            strFrom = " AND ActionDate <=" & CDate(cboTo.EditValue).ToString("yyyyMMdd") & ""
        End If

        Dim strFilter As String = strLockType & strRefNo & strPayType & strPrincipal & strVessel & strCompName & strFrom & strUserName
        If strFilter.Length > 0 Then
            retVal = Mid(strFilter, 5)
        End If

        Return retVal
    End Function

#Region "Payroll Log Source"

    Private Function PeriodDataSource() As DataTable
        Dim dv As New DataView(tblPayLog)
        dv.RowFilter = "LogType ='" & cboLogType.EditValue & "'"
        Dim retVal As New DataTable
        retVal.Columns.Add("PKey", GetType(String))
        retVal.Columns.Add("Name", GetType(String))
        For Each dr As DataRow In dv.ToTable(True, New String() {"MCode"}).Rows
            Dim nDr As DataRow = retVal.NewRow
            nDr("PKey") = dr(0)
            nDr("Name") = NumCodeToDate(dr(0), 1).ToString("MMMM-yyyy")
            retVal.Rows.Add(nDr)
        Next
        Return retVal
    End Function

    Private Function PayrollTypeDataSource() As DataTable
        Dim retval As New DataView(tblPayLog)
        retval.RowFilter = "LogType ='" & cboLogType.EditValue & "'"
        'Return retval.ToTable(True, New String() {"PayType"})
        Dim tbl As New DataTable
        tbl.Columns.Add("PKey", GetType(String))
        tbl.Columns.Add("Name", GetType(String))
        For Each dr As DataRow In retval.ToTable(True, New String() {"PayType"}).Rows
            Dim nDR As DataRow = tbl.NewRow
            nDR("PKey") = dr(0)
            nDR("Name") = IIf(dr(0).Equals("ONB"), "Onboard Payroll", IIf(dr(0).Equals("HA"), "Home Allotment", IIf(dr(0).Equals("MPO"), "Special Allotment", System.DBNull.Value)))
            tbl.Rows.Add(nDR)
        Next
        Return tbl
    End Function

    Private Function RefNoDataSource() As DataTable
        Dim dv As New DataView(tblPayLog)
        dv.RowFilter = "LogType ='" & cboLogType.EditValue & "'"
        'Dim tbl As New DataTable
        'tbl.Columns.Add("PKey", GetType(String))
        'tbl.Columns.Add("Name", GetType(String))
        'For Each dr As DataRow In dv.ToTable(True, New String() {"RefNo"}).Rows
        '    Dim nDR As DataRow = tbl.NewRow

        'Next

        Return dv.ToTable(True, New String() {"RefNo"})
    End Function

    Private Function PrincipalDataSource() As DataTable
        Dim dv As New DataView(tblPayLog)
        dv.RowFilter = "LogType ='" & cboLogType.EditValue & "'"
        Return dv.ToTable(True, New String() {"Principal"})
    End Function

    Private Function VesselDataSource() As DataTable
        Dim dv As New DataView(tblPayLog)
        Return dv.ToTable(True, New String() {"Vessel"})
    End Function

    Private Function ComputerNameDataSource() As DataTable
        Dim dv As New DataView(tblPayLog)
        Return dv.ToTable(True, New String() {"ComputerName"})
    End Function


#End Region

#End Region

    Private Sub EditValueChanged() Handles cboLogType.EditValueChanged,
        cboPayType.EditValueChanged,
        cboRefNo.EditValueChanged,
        cboPrincipal.EditValueChanged,
        cboVessel.EditValueChanged,
        cboCompName.EditValueChanged,
        cboUserName.EditValueChanged,
        cboFrom.EditValueChanged,
        cboTo.EditValueChanged

        If isBuilt Then
            GridView1.ActiveFilter.NonColumnFilter = getFilterString()
        End If

    End Sub

    Private Sub ButtonClear(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriod.ButtonPressed,
        cboPayType.ButtonPressed,
        cboRefNo.ButtonPressed,
        cboPrincipal.ButtonPressed,
        cboVessel.ButtonPressed,
        cboCompName.ButtonPressed,
        cboUserName.ButtonPressed,
        cboFrom.ButtonPressed,
        cboTo.ButtonPressed

        ClearLookUpEdit(sender, e)

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        If e.Column.FieldName = "UserName" AndAlso e.IsGetData Then
            e.Value = (From a As DataRow In tblUsers.Rows
                       Where (a("PKey") = e.Row("UserID"))
                       Select a("Name")).FirstOrDefault()
        End If
        If e.Column.FieldName.Equals("LockTypeName") AndAlso e.IsGetData Then
            e.Value = (From a As DataRow In tblLogType.Rows
                       Where a("PKey") = e.Row("LogType")
                       Select a("Name")).FirstOrDefault()
        End If
        If e.Column.FieldName.Equals("PayTypeName") AndAlso e.IsGetData Then
            e.Value = (From a As DataRow In PayrollTypeDataSource.Rows
                       Where a("PKey") = e.Row("PayType")
                       Select a("Name")).FirstOrDefault()
        End If
        If e.Column.FieldName.Equals("Period") AndAlso e.IsGetData Then
            e.Value = NumCodeToDate(e.Row("MCode"), 1).ToString("MMMM-yyyy")
        End If
    End Sub

    Public Sub New()

        ' Add any initialization after the InitializeComponent() call.
        InitializeComponent()

        ' This call is required by the designer.

        GridControl1.ForceInitialize()
        'User Name
        Dim ucolUserName As DevExpress.XtraGrid.Columns.GridColumn = Me.GridView1.Columns.AddField("UserName")
        With ucolUserName
            .UnboundType = DevExpress.Data.UnboundColumnType.String
            Me.GridView1.OptionsView.ColumnAutoWidth = True
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
            .Caption = "User Name"
            .OptionsColumn.ReadOnly = True
            .OptionsColumn.AllowFocus = False
            .Visible = True
            .VisibleIndex() = 5
        End With

        'Lock Type Name
        Dim ucolLockType As DevExpress.XtraGrid.Columns.GridColumn = Me.GridView1.Columns.AddField("LockTypeName")
        With ucolLockType
            .UnboundType = DevExpress.Data.UnboundColumnType.String
            Me.GridView1.OptionsView.ColumnAutoWidth = True
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
            .Caption = "Lock Type Name"
            .OptionsColumn.ReadOnly = True
            .OptionsColumn.AllowFocus = False
            .Visible = True
            .VisibleIndex() = GridView1.Columns.Count + 2
        End With

        'Payroll Type Name
        Dim ucolPayType As DevExpress.XtraGrid.Columns.GridColumn = Me.GridView1.Columns.AddField("PayTypeName")
        With ucolPayType
            .UnboundType = DevExpress.Data.UnboundColumnType.String
            Me.GridView1.OptionsView.ColumnAutoWidth = True
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
            .Caption = "Payroll Type"
            .OptionsColumn.ReadOnly = True
            .OptionsColumn.AllowFocus = False
            .Visible = True
            .VisibleIndex() = 2
        End With

        'Payroll Period Name
        Dim ucolPeriod As DevExpress.XtraGrid.Columns.GridColumn = Me.GridView1.Columns.AddField("Period")
        With ucolPeriod
            .UnboundType = DevExpress.Data.UnboundColumnType.String
            Me.GridView1.OptionsView.ColumnAutoWidth = True
            .DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
            .Caption = "Period"
            .OptionsColumn.ReadOnly = True
            .OptionsColumn.AllowFocus = False
            .Visible = True
            .VisibleIndex() = 0
        End With



    End Sub


End Class
