Imports System.Threading

Public Class GTRSConfig

    Private ReadOnly Property LayoutControlGroups() As DevExpress.XtraLayout.LayoutControlGroup()
        Get
            Return New DevExpress.XtraLayout.LayoutControlGroup() {lcgEndpointAddr, lcgGTRSAccount}
        End Get
    End Property

    Private oGTRSAccount As New GTRSAccount
    Private isInternetConnectionOkay As Boolean = False
    Private clsAudit As New clsAudit

    Private GTRS_ACCOUNT_VALID As Boolean = False

    Private bgValidatorHasBeenInit As Boolean = False

    Private FormName As String = "GTRS Config"

    Private Property ValidGTRSAccount As Boolean
        Set(value As Boolean)
            GTRS_ACCOUNT_VALID = value
            If value Then
                lblGTRSAccount_Result.ForeColor = System.Drawing.Color.ForestGreen
            Else
                lblGTRSAccount_Result.ForeColor = System.Drawing.Color.Firebrick
            End If
        End Set
        Get
            Return GTRS_ACCOUNT_VALID
        End Get
    End Property

#Region "Sub Classes"
    Private Class GTRSAccount
        Public AccountDetails As New GTRSServiceReference.credentials
        Public Valid As Boolean = False
    End Class
#End Region
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        RaiseCustomEvent(Name, New Object() {"SetUpTravelGTRSConfigControls"})
        clsAudit.propSQLConnStr = MPSDB.GetConnectionString
        header.Focus()

        If Not bLoaded Then
            tabGTRSConfig.SelectedTabPageIndex = 0

            'SETUP TRANSACTION LOG GRIDVIEW
            InitGTRSTransactionLog()

        End If

        ClearFields(LayoutControlGroups(), False)

        'SETUP GTRS ACCOUNT
        InitGTRSDetails_Account()

        'SETUP ENDPOINT URL BEHAVIOR
        InitGTRSDetails_EndpointURL()

        LoadSub_TransactionLog()


        'INIT CONTROLS
        MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgEndpointAddr, lcgGTRSAccount})
        ValidGTRSAccount = ValidGTRSAccount 'Reassigns value to itself to trigger change of font color, the MakeReadOnlyListener method sets the forecolor to black
        RemoveEditListener(txtEndpointURL, False)
        RemoveEditListener(txtGTRSAccount_User, False)
        RemoveEditListener(txtGTRSAccount_Pwd, False)
        EnableControls(False)
        bLoaded = True

    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()

        If isEditdable Then
            AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgEndpointAddr, lcgGTRSAccount})
            'AddHandler txtEndpointURL.EditValueChanged, AddressOf URL_EditValueChanged
            RemoveReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgEndpointAddr, lcgGTRSAccount})
            ValidGTRSAccount = ValidGTRSAccount 'Reassigns value to itself to trigger change of font color, the MakeReadOnlyListener method sets the forecolor to black
            EnableControls()
        Else
            RemoveEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgEndpointAddr, lcgGTRSAccount}, False)
            MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgEndpointAddr, lcgGTRSAccount})
            ValidGTRSAccount = ValidGTRSAccount 'Reassigns value to itself to trigger change of font color, the MakeReadOnlyListener method sets the forecolor to black
            EnableControls(False)
            RefreshData()
        End If
    End Sub

    Private Sub EnableControls(Optional enable As Boolean = True)
        btnSaveURL.Enabled = enable
        btnSignInOut.Enabled = enable
        btnToggelViewPassword.Enabled = enable
    End Sub

    'Private Sub URL_EditValueChanged(sender As Object, e As System.EventArgs)
    'TryCast(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
    'End Sub

    Private Sub InitGTRSDetails_EndpointURL()
        Dim dt As DataTable
        dt = MPSDB.CreateTable("SELECT * FROM dbo.tblconfig WHERE CODE = '" & GTRSConfigCode.EndpointURL & "')")

        If dt.Rows.Count = 0 Then
            txtEndpointURL.EditValue = GTRS_DEFAULT_ENDPOINTURL
        Else
            txtEndpointURL.EditValue = IfNull(MPSDB.GetConfig(GTRSConfigCode.EndpointURL), "")
        End If

        'AddHandler txtEndpointURL.EditValueChanged, AddressOf URL_EditValueChanged

    End Sub

    Private Sub InitGTRSDetails_Account()
        SetSignInButtonCaption(SignInButtonCaptionType.SignIn)

        'RETRIEVE ACCOUNT DETAILS
        Dim dt As DataTable
        dt = MPSDB.CreateTable("SELECT * FROM dbo.tblconfig WHERE CODE IN ('" & GTRSConfigCode.Account & "', '" & GTRSConfigCode.Password & "')")

        For Each row As DataRow In dt.Rows
            Select Case row("Code")
                Case "GTRSACCOUNT"
                    txtGTRSAccount_User.EditValue = sysMpsUserPassword("DECRYPT", IfNull(row("TextValue"), ""))

                Case "GTRSPWD"
                    txtGTRSAccount_Pwd.EditValue = sysMpsUserPassword("DECRYPT", IfNull(row("TextValue"), ""))

            End Select
        Next

        'AUTHENTICATE/VALIDATE ACCOUNT
        If Not bLoaded Then
            lblGTRSAccount_Result.Text = ""
            If IfNull(txtGTRSAccount_User.EditValue, "").Length > 0 And IfNull(txtGTRSAccount_Pwd.EditValue, "").Length > 0 Then
                bgValidateAccount.RunWorkerAsync()
            End If
        Else
            lblGTRSAccount_Result.Text = "GTRS Account Valid."
        End If
        
    End Sub

    Private Sub InitGTRSTransactionLog()
        'COMPUTER NAME
        With cboComputerName.Properties
            .DataSource = MPSDB.CreateTable("SELECT ComputerName FROM dbo.tblLog_GTRSTrans GROUP BY ComputerName ORDER BY ComputerName")
            .DisplayMember = "ComputerName"
            .ValueMember = "ComputerName"
            .ShowHeader = False
        End With

        'USER NAME
        With cboUserName.Properties
            .DataSource = MPSDB.CreateTable("SELECT users.name Username FROM dbo.tblLog_GTRSTrans glog LEFT JOIN dbo.MSysSec_Users users ON glog.UserID = users.id GROUP BY users.name ORDER BY users.name DESC")
            .DisplayMember = "Username"
            .ValueMember = "Username"
            .ShowHeader = False
        End With

        'STATUS
        Dim dt As New DataTable
        Dim col As New DataColumn
        col.ColumnName = "PKey"
        col.DataType = GetType(System.Int32)
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "Name"
        col.DataType = GetType(System.String)
        dt.Columns.Add(col)

        dt.Rows.Add(New Object() {0, "Show All"})
        dt.Rows.Add(New Object() {1, "Show Valid Transactions Only"})
        dt.Rows.Add(New Object() {2, "Show Transactions with Errors Only"})

        With cboLogStatus.Properties
            .DataSource = dt
            .DisplayMember = "Name"
            .ValueMember = "PKey"
            .ShowHeader = False
            .ShowFooter = False
        End With
        cboLogStatus.EditValue = 0

        txtDateFrom.EditValue = DateAdd(DateInterval.Month, -1, DateTime.Now())
        txtDateTo.EditValue = DateTime.Now

    End Sub

    Private Sub LoadSub_GTRSAccount()

    End Sub

    Private Sub LoadSub_TransactionLog()
        Dim dt As DataTable

        Dim cCriteria As String = ""
        If IfNull(txtDateFrom.EditValue, "").Length > 0 Then
            If IsDate(txtDateFrom.EditValue) Then
                cCriteria = cCriteria & IIf(IfNull(cCriteria, "").Length > 0, " AND ", "") & _
                            "TransactionDate >= " & ChangeToSQLDate(txtDateFrom.EditValue)
            End If
        End If

        If IfNull(txtDateTo.EditValue, "").Length > 0 Then
            If IsDate(txtDateTo.EditValue) Then
                cCriteria = cCriteria & IIf(IfNull(cCriteria, "").Length > 0, " AND ", "") & _
                            "TransactionDate <= " & ChangeToSQLDate(txtDateTo.EditValue)
            End If
        End If

        If IfNull(cboComputerName.EditValue, "").Length > 0 Then
            cCriteria = cCriteria & IIf(IfNull(cCriteria, "").Length > 0, " AND ", "") & _
                        "ComputerName = '" & cboComputerName.EditValue & "'"
        End If

        If IfNull(cboUserName.EditValue, "").Length > 0 Then
            cCriteria = cCriteria & IIf(IfNull(cCriteria, "").Length > 0, " AND ", "") & _
                        "Username = '" & cboUserName.EditValue & "'"
        End If

        'If IfNull(cboLogStatus.EditValue, 0) = 1 Then       'VALID LOGS
        '    cCriteria = cCriteria & IIf(IfNull(cCriteria, "").Length > 0, " AND ", "") & _
        '                "CAST(CASE WHEN len(isnull(glog.FailErrorMessage,'')) > 0 THEN 0 ELSE 1 END as bit) = 1"
        'ElseIf IfNull(cboLogStatus.EditValue, 0) = 2 Then   'WITH ERRORS
        '    cCriteria = cCriteria & IIf(IfNull(cCriteria, "").Length > 0, " AND ", "") & _
        '                "CAST(CASE WHEN len(isnull(glog.FailErrorMessage,'')) > 0 THEN 0 ELSE 1 END as bit) = 0"
        'End If

        dt = MPSDB.CreateTable("SELECT CAST(CASE WHEN len(isnull(glog.FailErrorMessage,'')) > 0 THEN 0 ELSE 1 END as bit) ValidLog, glog.*, users.name Username FROM dbo.tblLog_GTRSTrans glog LEFT JOIN dbo.MSysSec_Users users ON glog.UserID = users.id " & IIf(IfNull(cCriteria, "").Length > 0, "WHERE " & cCriteria, "") & " ORDER BY TransactionDate DESC")
        TransactionLogGrid.DataSource = dt

    End Sub

    Private Sub SetGTRSAccountStatus(cStatus As String)
        lblGTRSAccount_Result.Text = cStatus
    End Sub

    Private Function ValidateGTRSAccount(cUsername As String, cPassword As String) As Boolean
        Dim ReturnValue As Boolean = False
        Dim Err As String = ""
        Try

            If cUsername.Length > 0 And cPassword.Length > 0 Then

                Dim ogtrs As New GTRSService
                modGTRS.LogProcess("Validating GTRS Account...")
                modGTRS.LogProcess(vbTab & "Username: " & cUsername)

                ReturnValue = ogtrs.ValidateUserAccount(cUsername, cPassword)

            End If
        Catch ex As Exception
            ReturnValue = False

        End Try

        If ReturnValue Then
            modGTRS.LogProcess(vbTab & "User Authenticate Successful")
        Else
            modGTRS.LogProcess(vbTab & "Failed to Authenticate User [" & cUsername & "]")
        End If
        modGTRS.LogProcess("")
        Return ReturnValue
    End Function

    Private Sub btnSignInOut_Click(sender As System.Object, e As System.EventArgs) Handles btnSignInOut.Click
        If btnSignInOut.Text = SignInButtonCaption.SignIn Then
            If IfNull(txtGTRSAccount_User.EditValue, "").Length = 0 Then
                MsgBox("Please enter the GTRS account name.", MsgBoxStyle.Exclamation, GetAppName)
                txtGTRSAccount_User.Focus()
                Exit Sub
            End If

            If IfNull(txtGTRSAccount_Pwd.EditValue, "").Length = 0 Then
                MsgBox("Please enter the GTRS account password.", MsgBoxStyle.Exclamation, GetAppName)
                txtGTRSAccount_Pwd.Focus()
                Exit Sub
            End If
            bgValidateAccount.RunWorkerAsync()

        Else
            If MsgBox("Are you sure you want to sign out the currently logged in account '" & txtGTRSAccount_User.EditValue & "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then
                SetSignInButtonCaption(SignInButtonCaptionType.SignIn)
                Dim username As String
                username = txtGTRSAccount_User.EditValue
                txtGTRSAccount_User.EditValue = ""
                txtGTRSAccount_Pwd.EditValue = ""
                lblGTRSAccount_Result.Text = ""
                UpdateGTRSAccount(txtGTRSAccount_User.EditValue, txtGTRSAccount_Pwd.EditValue, False)
                SaveGTRSAccount()
                LogGTRSTransaction(New TransactionLogInfo(TransactionType.MPS, "", "", "", "Sign Out GTRS Account", "GTRS Account [" & username & "]"))
                RemoveEditListener(txtGTRSAccount_User, False)
                AddEditListener(txtGTRSAccount_User)
                RemoveEditListener(txtGTRSAccount_Pwd, False)
                AddEditListener(txtGTRSAccount_Pwd)
                txtGTRSAccount_User.Focus()

            End If
        End If
    End Sub

#Region "Delegates"
    ''' UPDATE GTRS VALIDATION RESULT LABEL
    Delegate Sub UpdateGTRSAccountResultDelegate(ByVal isSuccessful As Boolean, ByVal cResult As String)
    Public Sub UpdateGTRSAccountResult(ByVal isSuccessful As Boolean, ByVal cResult As String)

        Try
            Me.lblGTRSAccount_Result.Text = cResult
            ValidGTRSAccount = isSuccessful

            
        Catch ex As Exception
            Me.lblGTRSAccount_Result.Text = ""
        End Try

    End Sub

    ''' CHANGES THE SIGN IN / SIGN OUT BUTTON CAPTION
    Public Enum SignInButtonCaptionType
        SignIn = 1
        SignOut = 2
    End Enum

    Public Structure SignInButtonCaption
        Public Shared SignIn As String = "Sign In"
        Public Shared SignOut As String = "Sign Out"
    End Structure

    Delegate Sub SetSignInButtonCaptionDelegate(ByVal Caption As SignInButtonCaptionType)
    Public Sub SetSignInButtonCaption(ByVal Caption As SignInButtonCaptionType)

        Try
            Select Case Caption
                Case SignInButtonCaptionType.SignIn
                    Me.btnSignInOut.Text = SignInButtonCaption.SignIn

                Case SignInButtonCaptionType.SignOut
                    Me.btnSignInOut.Text = SignInButtonCaption.SignOut
            End Select

            Me.btnSignInOut.Enabled = isEditdable
        Catch ex As Exception
            Me.btnSignInOut.Text = "Sign In"
            Me.btnSignInOut.Enabled = False
        End Try

    End Sub

    ''' SETS IF LOADING GIF IMAGE IS VISIBLE
    Delegate Sub ShowLoadingDelegate(ByVal show As Boolean)
    Public Sub ShowLoading(ByVal show As Boolean)
        If show Then
            Me.lciLoadingGTRSAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            Me.lciLoadingGTRSAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Delegate Sub EnableSignInButtonDelegate(ByVal enable As Boolean)
    Public Sub EnableSignInButton(ByVal enable As Boolean)
        Me.btnSignInOut.Enabled = enable
    End Sub

    ''' SETS IF LOADING GIF IMAGE IS VISIBLE
    Delegate Sub UpdateGTRSAccountDelegate(ByVal Username As String, ByVal Password As String, ByVal isValid As Boolean)
    Public Sub UpdateGTRSAccount(ByVal Username As String, ByVal Password As String, ByVal isValid As Boolean)
        With Me.oGTRSAccount

            .AccountDetails.username = IfNull(Username, "")
            .AccountDetails.password = IfNull(Password, "")
            .Valid = isValid

        End With

    End Sub

#End Region


    Private Sub bgValidateAccount_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgValidateAccount.DoWork

        Dim updateResultLabel As UpdateGTRSAccountResultDelegate = New UpdateGTRSAccountResultDelegate(AddressOf UpdateGTRSAccountResult)
        Dim doShowLoading As ShowLoadingDelegate = New ShowLoadingDelegate(AddressOf ShowLoading)
        Dim doEnableSignInButton As EnableSignInButtonDelegate = New EnableSignInButtonDelegate(AddressOf EnableSignInButton)
        Dim doSetSignInButtonCaption As SetSignInButtonCaptionDelegate = New SetSignInButtonCaptionDelegate(AddressOf SetSignInButtonCaption)
        Dim doUpdateGTRSAccount As UpdateGTRSAccountDelegate = New UpdateGTRSAccountDelegate(AddressOf UpdateGTRSAccount)

        Me.Invoke(updateResultLabel, New Object() {False, "Authenticating GTRS Account."})
        Me.Invoke(doShowLoading, True)
        Me.Invoke(doEnableSignInButton, False)

        Thread.Sleep(1000)

        Me.Invoke(doUpdateGTRSAccount, New Object() {"", "", False})
        If Not CheckForInternetConnection() Then
            isInternetConnectionOkay = False
            Me.Invoke(doSetSignInButtonCaption, SignInButtonCaptionType.SignIn)
            Me.Invoke(updateResultLabel, New Object() {False, "unable to connect to the internet."})
            LogGTRSTransaction(New TransactionLogInfo(TransactionType.NotApplicable, "", FormName, "", "Validating GTRS Account", "Attempting to connect to the internet."), "unable to connect to the internet.")
            Exit Sub
        Else
            isInternetConnectionOkay = True
        End If

        Dim bSuccess As Boolean = ValidateGTRSAccount(txtGTRSAccount_User.EditValue, txtGTRSAccount_Pwd.EditValue)
        Me.Invoke(doShowLoading, False)

        Dim logAction As String = ""
        If bgValidatorHasBeenInit Then
            logAction = "Change User Account. "
        Else
            logAction = "Initializing Config Form. "
        End If
        If bSuccess Then
            Try
                Me.Invoke(doSetSignInButtonCaption, SignInButtonCaptionType.SignOut)
                Me.Invoke(updateResultLabel, New Object() {True, "GTRS Account Valid."})
                Me.Invoke(doUpdateGTRSAccount, New Object() {txtGTRSAccount_User.EditValue, txtGTRSAccount_Pwd.EditValue, True})
                LogGTRSTransaction(New TransactionLogInfo(TransactionType.Get, "AuthenticateUser", FormName, "", logAction, "GTRS Account [" & txtGTRSAccount_User.EditValue & "]"))
            Catch ex As Exception
                Me.Invoke(doSetSignInButtonCaption, SignInButtonCaptionType.SignIn)
                Me.Invoke(updateResultLabel, New Object() {False, "Validation Failed. " & ex.Message})
                LogGTRSTransaction(New TransactionLogInfo(TransactionType.Get, "AuthenticateUser", FormName, "", logAction, "GTRS Account [" & txtGTRSAccount_User.EditValue & "]"), ex.Message)
            End Try
        Else
            Try
                Me.Invoke(doSetSignInButtonCaption, SignInButtonCaptionType.SignIn)
                Me.Invoke(updateResultLabel, New Object() {False, "Invalid GTRS Account."})
                LogGTRSTransaction(New TransactionLogInfo(TransactionType.Get, "AuthenticateUser", FormName, "", logAction, "GTRS Account [" & txtGTRSAccount_User.EditValue & "]"), "Invalid Account")
            Catch ex As Exception
                Me.Invoke(doSetSignInButtonCaption, SignInButtonCaptionType.SignIn)
                Me.Invoke(updateResultLabel, New Object() {False, "Validation Failed. " & ex.Message})
                LogGTRSTransaction(New TransactionLogInfo(TransactionType.Get, "AuthenticateUser", FormName, "", logAction, "GTRS Account [" & txtGTRSAccount_User.EditValue & "]"), ex.Message)
            End Try
        End If

        bgValidatorHasBeenInit = True
    End Sub

    Private Sub btnSaveURL_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveURL.Click
        Try
            MPSDB.SaveConfig(GTRSConfigCode.EndpointURL, txtEndpointURL.EditValue)
            LogGTRSTransaction(New TransactionLogInfo(TransactionType.MPS, "", FormName, "", "Changing Endpoint URL", "Changed to [" & txtEndpointURL.EditValue & "]"))
        Catch ex As Exception
            modGTRS.LogProcess("Failed to save Endpoint URL address in MPS Config with error : " & ex.Message)
            MsgBox("Failed to save Endpoint URL address in MPS Config with error : " & ex.Message)
            LogGTRSTransaction(New TransactionLogInfo(TransactionType.MPS, "", FormName, "", "Changing Endpoint URL", "Changed to [" & txtEndpointURL.EditValue & "]"), ex.Message)
        Finally
            txtEndpointURL.BackColor = System.Drawing.Color.White
            RemoveEditListener(txtEndpointURL, False)
            AddEditListener(txtEndpointURL)
            'AddHandler txtEndpointURL.EditValueChanged, AddressOf URL_EditValueChanged
            MsgBox("Endpoint Address URL Saved.", MsgBoxStyle.Information, GetAppName)
        End Try
    End Sub

    Private Sub bgValidateAccount_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgValidateAccount.RunWorkerCompleted
        If bgValidatorHasBeenInit Then
            If isInternetConnectionOkay Then
                If oGTRSAccount.Valid Then
                    SaveGTRSAccount()

                Else
                    MsgBox("Invalid GTRS Account.", MsgBoxStyle.Exclamation, GetAppName)
                End If
            Else
                MsgBox("Unable to connect to the internet.", MsgBoxStyle.Exclamation, GetAppName)
            End If

        End If

        LoadSub_TransactionLog()

        If isEditdable Then
            RemoveEditListener(txtGTRSAccount_User, False)
            AddEditListener(txtGTRSAccount_User)
            RemoveEditListener(txtGTRSAccount_Pwd, False)
            AddEditListener(txtGTRSAccount_Pwd)
        End If

    End Sub

    Private Sub SaveGTRSAccount()
        MPSDB.SaveConfig(GTRSConfigCode.Account, sysMpsUserPassword("ENCRYPT", IfNull(oGTRSAccount.AccountDetails.username, "")))
        MPSDB.SaveConfig(GTRSConfigCode.Password, sysMpsUserPassword("ENCRYPT", IfNull(oGTRSAccount.AccountDetails.password, "")))
    End Sub

    Private Sub EnableControlPermission()
        Dim clsSec As New clsSecurity
        clsSec.propSQLConnStr = MPSDB.GetConnectionString

        Dim disable As Boolean = clsSec.hasNoUpdatePermission("GTRSConfig", USER_ID, True, userPermDt)

        btnSaveURL.Enabled = Not disable
        btnSignInOut.Enabled = Not disable

        txtEndpointURL.ReadOnly = disable
        txtGTRSAccount_User.ReadOnly = disable
        txtGTRSAccount_Pwd.ReadOnly = disable

    End Sub


    Private Sub cmdApplyFilter_Click(sender As System.Object, e As System.EventArgs) Handles cmdApplyFilter.Click
        LoadSub_TransactionLog()
    End Sub

    Private Sub cmdClearFilter_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearFilter.Click
        txtDateFrom.EditValue = Nothing
        txtDateTo.EditValue = Nothing
        cboComputerName.EditValue = Nothing
        cboUserName.EditValue = Nothing
        cboLogStatus.EditValue = 0
        LoadSub_TransactionLog()
    End Sub

    Private Sub txtDateFrom_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDateFrom.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub txtDateTo_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDateTo.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboComputerName_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboComputerName.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboUserName_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboUserName.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboLogStatus_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboLogStatus.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            cboLogStatus.EditValue = 0
        End If
    End Sub

    Private Sub cboLogStatus_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboLogStatus.EditValueChanged
        Select Case IfNull(cboLogStatus.EditValue, 0)
            Case 0
                TransactionLogView.ActiveFilterString = ""
            Case 1
                TransactionLogView.ActiveFilterString = "ValidLog = true"
            Case 2
                TransactionLogView.ActiveFilterString = "ValidLog = false"
        End Select

    End Sub

    Private Sub btnToggelViewPassword_CheckedChanged(sender As Object, e As System.EventArgs) Handles btnToggelViewPassword.CheckedChanged
        txtGTRSAccount_Pwd.Properties.PasswordChar = IIf(btnToggelViewPassword.Checked, "", "*")
    End Sub
End Class
