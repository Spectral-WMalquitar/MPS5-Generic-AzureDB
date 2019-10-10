Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Base


Public Class frmPopupMedHistory

    Private crews As New List(Of Utilities.SelectedCrew)
    Private dtSub As DataTable
    Private dtMain As DataTable
    Private selectedCrewIndex As Integer
    Private processDone As Boolean = False

#Region "Easy Edit"
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><Activity>"
    Private FormName As String = "Medical History"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

#End Region

    'When this form is called, the constructor will recieve a list of crews marked for adding a Medical history. 
    Public Sub New(selectedCrews As List(Of Utilities.SelectedCrew), gridLabel As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.crews = selectedCrews
        tabMainGrid.Text = gridLabel
        initControls()

    End Sub

    Public Sub initControls()
        LayoutControl1.AllowCustomization = False
        RepCertVsl.DataSource = MPSDB.CreateTable("SELECT PKey, Name FROM tblAdmVsl ORDER BY Name ASC")
        RepMedStatus.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmMedStat WHERE StatType = 1 ORDER BY SortCode, Name")
        AddUnboundColumn(Me.MedHistoryGrid, Me.SigningOffCrewsGrid, "FileName", "File Name", False)
        CreateMeHistorySubGrid()
    End Sub

    'Creating master-details view. Code pattern from Training module of Crewing. 
    Private Sub CreateMeHistorySubGrid()

        Dim ds2 As New DataSet
        dtMain = PopulateDataFromSelectedCrews()
        dtSub = MPSDB.CreateTable("SELECT *, 0 as Edited FROM dbo.tblMedHistory WHERE FKeyIDNbr = '' ORDER BY DateStatus DESC")

        ds2.Tables.Add(dtMain)
        ds2.Tables.Add(dtSub)

        ds2.Tables(0).TableName = "dtMain"
        ds2.Tables(1).TableName = "dtSub"

        If IsNothing(ds2.Relations("MedicalHistoryRel")) Then
            ds2.Relations.Add("MedicalHistoryRel", ds2.Tables("dtMain").Columns("PKey"), ds2.Tables("dtSub").Columns("FKeyIDNbr"))
        End If

        Me.SigningOffCrewsGrid.DataSource = ds2.Tables("dtMain")
        Me.SigningOffCrewsGrid.ForceInitialize()
        Me.CrewGrid.OptionsDetail.AllowExpandEmptyDetails = True

        Me.SigningOffCrewsGrid.LevelTree.Nodes.Add("MedicalHistoryRel", Me.MedHistoryGrid)
        Me.MedHistoryGrid.ViewCaption = "Add Medical History"
        Me.MedHistoryGrid.OptionsView.ShowGroupPanel = False
        Me.MedHistoryGrid.OptionsCustomization.AllowFilter = False
        Me.MedHistoryGrid.CollapseAllDetails()

        SetGridReadOnlyProperties(MedHistoryGrid, False)
    End Sub

    Public Sub SetGridReadOnlyProperties(controlGrid As GridView, Optional isReadOnly As Boolean = True)
        With controlGrid
            Select Case isReadOnly
                Case True
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    .OptionsBehavior.ReadOnly = True
                Case Else
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                    .OptionsView.ShowGroupExpandCollapseButtons = True
                    .OptionsBehavior.ReadOnly = False
            End Select
        End With
    End Sub

    'Populate master grid with crew information.
    Public Function PopulateDataFromSelectedCrews() As DataTable

        Dim crewTable As New DataTable

        crewTable.Columns.Add("PKey", GetType(String))
        crewTable.Columns.Add("CrewName", GetType(String))
        crewTable.Columns.Add("RankName", GetType(String))
        crewTable.Columns.Add("ActID", GetType(String))
        crewTable.Columns.Add("ActGrpID", GetType(String))

        For i As Integer = 0 To crews.Count - 1
            crewTable.Rows.Add(crews(i).CrewIDNbr,
                               crews(i).FirstName,
                               IIf(crews(i).RankName.Trim().Length > 0,
                                   crews(i).RankName,
                                   MPSDB.DLookUp("RankName", "tblActivity", "", "PKey='" & crews(i).ActivityID & "'")),
                               crews(i).ActivityID,
                               crews(i).ActivityGroupID)
        Next

        Return crewTable
    End Function

    Private Sub frmPopupMedHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        SaveMedicalHistory()
    End Sub

    Public Sub SaveMedicalHistory()

        If dtSub.Rows.Count = 0 Then
            MessageBox.Show("There is no Medical History assigned to any of the crews." + Environment.NewLine +
                            "You can add a Medical History by clicking the '+' sign beside the Crew name, or click the 'Cancel' button to close this window.", "Add Medical History", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            If (DialogResult.Yes = MessageBox.Show("Save Medical History for selected crews?", "Save Medical History", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) Then
                If IsSaveMedicalHistoryTransactionSuccess() Then
                    MessageBox.Show("Medical History successfully created.", "Save Medical History", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtSub.Clear()
                    dtMain.Clear()
                    processDone = True
                    Me.Close()
                End If
            End If

        End If
    End Sub

    Public Function GetActivityID(idnbr As String, actGroupID As String) As String

        Dim query As String = "SELECT TOP 1 a.PKey, a.FKeyActivityGroupID , ag.FKeyIDNbr,a.FKeyStatCode " & _
                              "FROM tblActivity a INNER JOIN tblActivityGroup ag ON a.FKeyActivityGroupID = ag.Pkey " & _
                              "WHERE ag.FKeyIDNbr = '" & idnbr & "' AND  a.FKeyActivityGroupID = '" & actGroupID & "' " & _
                              "ORDER BY a.DateUpdated DESC "

        Dim dataTable As DataTable = MPSDB.CreateTable(query)
        Dim activityID As String = ""
        For Each row As DataRow In dataTable.Rows
            activityID = row("PKey")
        Next

        Return(activityID)

    End Function

    Public Function IsSaveMedicalHistoryTransactionSuccess() As Boolean

        Dim hasError As Boolean = False
        Dim retVal As Boolean = False
        Dim sqlTrans As SqlClient.SqlTransaction = Nothing
        Dim result As Integer = 0
        Dim insertQuery As String = "INSERT INTO tblMedHistory(FKeyIDNbr, WorkRel, Diagnosis, DateAcq, FKeyVessel, IsPICase, PICaseRefNo, FKeyMedStatus, DateStatus, Remarks, PlaceAcq, FKeyActivityID, LastUpdatedBy ) " & _
                                    "VALUES(@FKeyIDNbr, @WorkRel, @Diagnosis, @DateAcq, @FKeyVessel, @IsPICase, @PICaseRefNo, @FKeyMedStatus, @DateStatus, @Remarks, @PlaceAcq, @FKeyActivityID, @LastUpdatedBy)"

        Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(MPSDB.GetConnectionString())

        Try
            sqlConn.Open()
            If sqlConn.State = ConnectionState.Open Then
                sqlTrans = sqlConn.BeginTransaction()
                For masterCounter As Integer = 0 To dtMain.Rows.Count - 1
                    For childCounter As Integer = 0 To dtSub.Rows.Count - 1
                        'Check if this medical history belong to this crew.
                        If dtMain.Rows(masterCounter).Item("PKey").ToString().Equals(dtSub.Rows(childCounter).Item("FKeyIDNbr").ToString()) Then
                            Using command As New SqlClient.SqlCommand()
                                command.Connection = sqlConn
                                command.CommandText = insertQuery
                                command.Parameters.AddWithValue("@FKeyIDNbr", HandleNullValues(dtMain.Rows(masterCounter).Item("PKey"), "STRING"))
                                command.Parameters.AddWithValue("@WorkRel", HandleNullValues(dtSub.Rows(childCounter).Item("WorkRel"), "BIT"))
                                command.Parameters.AddWithValue("@Diagnosis", HandleNullValues(dtSub.Rows(childCounter).Item("Diagnosis"), "STRING"))
                                command.Parameters.AddWithValue("@DateAcq", CDate(HandleNullValues(dtSub.Rows(childCounter).Item("DateAcq"), "DATE")))
                                command.Parameters.AddWithValue("@FKeyVessel", HandleNullValues(dtSub.Rows(childCounter).Item("FKeyVessel"), "STRING"))
                                command.Parameters.AddWithValue("@IsPICase", HandleNullValues(dtSub.Rows(childCounter).Item("IsPICase"), "BIT"))
                                command.Parameters.AddWithValue("@PICaseRefNo", HandleNullValues(dtSub.Rows(childCounter).Item("PICaseRefNo"), "STRING"))
                                command.Parameters.AddWithValue("@FKeyMedStatus", HandleNullValues(dtSub.Rows(childCounter).Item("FKeyMedStatus"), "STRING"))
                                command.Parameters.AddWithValue("@DateStatus", CDate(HandleNullValues(dtSub.Rows(childCounter).Item("DateStatus"), "DATE")))
                                command.Parameters.AddWithValue("@Remarks", HandleNullValues(dtSub.Rows(childCounter).Item("Remarks"), "STRING"))
                                command.Parameters.AddWithValue("@PlaceAcq", HandleNullValues(dtSub.Rows(childCounter).Item("PlaceAcq"), "STRING"))
                                'Get the newly added activity id for this crew. 
                                command.Parameters.AddWithValue("@FKeyActivityID", HandleNullValues(GetActivityID(dtMain.Rows(masterCounter).Item("PKey"),
                                                                                                                  dtMain.Rows(masterCounter).Item("ActGrpID")), "STRING"))
                                command.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                                command.Transaction = sqlTrans

                                If (command.ExecuteNonQuery() < 0) Then 'If so, save it to tblMedHistory under the PKeyIDNbr and ActivityID of this crew.
                                    hasError = True
                                End If
                            End Using
                        End If
                    Next
                Next
            End If
            If Not hasError Then
                sqlTrans.Commit() 'Commit/save the whole transaction.
                retVal = True
            End If

        Catch ex As Exception
            LogErrors("--Error Generated in IsSaveMedicalHistoryTransactionSuccess() method in frmPopupMedHistory.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in IsSaveMedicalHistoryTransactionSuccess() method in frmPopupMedHistory.vb - End--")

            MessageBox.Show("There is an error while saving Medical History : " + ex.Message)
            sqlTrans.Rollback()
            retVal = False
        Finally
            sqlTrans.Dispose()
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
        End Try

        Return retVal

    End Function

    Private Function HandleNullValues(source As Object, type As String) As String
        Dim retVal As String = ""
        Try
            If (IsDBNull(source)) Then
                If type.Equals("DATE") Or type.Equals("STRING") Then
                    retVal = ""
                ElseIf type.Equals("BIT") Then
                    retVal = "False"
                End If
            Else
                retVal = source.ToString()
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in HandleNullValues() method in frmPopupMedHistory.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in HandleNullValues() method in frmPopupMedHistory.vb - End--")

            retVal = ""
        End Try

        Return retVal
    End Function

    Private Sub frmPopupMedHistory_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If dtSub.Rows.Count > 0 Then
            If DialogResult.Yes = MessageBox.Show("A Medical History has been added, you will lose your changes if you close this form. Save changes to Medical History?", "Add Medical History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                SaveMedicalHistory()
            Else
                dtSub.Clear()
                dtMain.Clear()
                Me.Close()
            End If
        ElseIf dtMain.Rows.Count > 0 Then
            If DialogResult.No = MessageBox.Show("Cancel the adding of Medical History?", "Add Medical History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                e.Cancel = True
            End If
        ElseIf processDone Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Sub ValidateRequiredFields(ByRef sender As Object, ByRef e As ValidateRowEventArgs, colName As String, errMessage As String)
        Dim view As GridView = TryCast(sender, GridView)
        Dim column As DevExpress.XtraGrid.Columns.GridColumn = view.Columns(colName)

        If view.GetRowCellValue(e.RowHandle, column) Is DBNull.Value Or
            view.GetRowCellValue(e.RowHandle, column) Is Nothing Then
            view.SetColumnError(column, errMessage)
        Else
            view.SetColumnError(column, "")
        End If
    End Sub
    'Populate default data for Status, Vessel and Last Status Date
    Private Sub MedHistoryGrid_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MedHistoryGrid.InitNewRow
        Dim row As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            row.SetRowCellValue(e.RowHandle, "FKeyMedStatus", "SYSMEDONGOING")
            row.SetRowCellValue(e.RowHandle, "DateStatus", DateTime.Now.ToString("dd-MMM-yyyy"))
            Dim strDate As String = ChangeToDateSerial(CDate(crews(CrewGrid.GetRowHandle(CrewGrid.FocusedRowHandle)).StartActivityDate))
            row.SetRowCellValue(e.RowHandle, "DateAcq", DateSerial(CInt(strDate.Substring(11, 4)), CInt(strDate.Substring(16, 2)), CInt(strDate.Substring(19, 2))))
            row.SetRowCellValue(e.RowHandle, "FKeyVessel", MPSDB.DLookUp("FKeyVslCode", "tblActivity", "", "Pkey='" & CrewGrid.GetRowCellValue(CrewGrid.FocusedRowHandle, "ActID") & "'"))
            row.SetRowCellValue(e.RowHandle, "WorkRel", False)
            row.SetRowCellValue(e.RowHandle, "IsPICase", False)
        Catch ex As Exception
            LogErrors("--Error Generated in MedHistoryGrid_InitNewRow() method in frmPopupMedHistory.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in MedHistoryGrid_InitNewRow() method in frmPopupMedHistory.vb - End--")

            'MessageBox.Show("Medical history could not generate default value. Please enter values on required fields marked with 'x'.", "Medical History", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub MedHistoryGrid_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MedHistoryGrid.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MedHistoryGrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MedHistoryGrid.KeyDown
        'A medical history can be deleted using the Delete key. 
        If e.KeyCode = Keys.Delete Then
            If DialogResult.Yes = MessageBox.Show("Delete selected Medical History?", "Delete Medical History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim view As GridView = CType(sender, GridView)
                view.DeleteRow(view.FocusedRowHandle)
            End If
        End If

    End Sub

    Private Sub MedHistoryGrid_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MedHistoryGrid.ValidateRow
        'Required Fields in Medical History
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Me.Focus()
        With views
            e.Valid = False
            ValidateRequiredFields(sender, e, "Diagnosis", "Please enter Diagnosis")
            ValidateRequiredFields(sender, e, "DateAcq", "Please enter Date Acquired.")
            ValidateRequiredFields(sender, e, "PlaceAcq", "Please enter Place Acquired.")
            ValidateRequiredFields(sender, e, "FKeyMedStatus", "Please select Medical Status.")
            ValidateRequiredFields(sender, e, "DateStatus", "Please enter Status Date")

            'Clear Errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            End If
        End With
    End Sub

End Class