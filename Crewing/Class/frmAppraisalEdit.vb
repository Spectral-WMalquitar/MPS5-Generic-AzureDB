Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Ribbon.RibbonControl
Imports DevExpress.XtraBars
Imports System.IO
Imports DevExpress.XtraLayout
Imports System.Reflection
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Scrolling
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors

Public Class frmAppraisalEdit

    Public Shared crewName As String
    Public Shared crewID As String
    Public Shared selectedCrewAppraisal As CrewAppraisal
    Public Shared IsNewAppraisal As Boolean = True
    Public Shared IsTriggeredInClose As Boolean = False
    Public Shared editable As Boolean = False

    Private DocumentList As New List(Of Dictionary(Of Integer, String))()
    'Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName)

    'Dim clsAudit As New clsAudit
    Dim FormName As String = "Appraisal"
    Dim TIME_OUT As Integer = 5000
    Dim isSuccessUpdating As Boolean = False
    Dim serviceID As String = ""
    Dim serviceVesselID As String = ""
    Dim serviceRankID As String = ""
    Dim startDate As Date
    Dim endDate As Date
    Dim hasChanges As Boolean = False
    Dim folderPath As String = ""
    Dim selectedAppraisalID As String = ""
    Dim lastUpdatedBy As String = ""
    Dim clsAudit As New clsAudit


#Region "Appraisal Queries"
    Dim insertQuery As String = "INSERT INTO tblCrewAppraisal (                                   " & _
                                "FKeyIDNbr,        AppraisalDate,       FKeyActivity,             " & _
                                "Service,          OccasionForReport,   OverallScore,             " & _
                                "Reemployed ,       Promotion,           SailAgain,               " & _
                                "Remarks,          MasterName,          ChiefOfficerName,         " & _
                                "Strength,         Weakneses,           OfficerComment,           " & _
                                "OfficerName,      CommentDate,         CommentFromOffice1,       " & _
                                "ShipFleetManager, CommentFromOffice2,  SafetyOperationsManager,  " & _
                                "Reemploy,         Promote,             PromoteReemployWhen,      " & _
                                "AdditionalRemarks,TrainingRequirements,OverallAssessment,        " & _
                                "FKeyMstrId, FKeyCOId, FKeyCEId, LastUpdatedBy )                  " & _
                                "VALUES (@FKeyIDNbr,@AppraisalDate,@FKeyActivity,@Service,        " & _
                                "@OccasionForReport,@OverallScore,@Reemployed,@Promotion,         " & _
                                "@SailAgain,@Remarks,@MasterName,@ChiefOfficerName,@Strength,     " & _
                                "@Weakneses,@OfficerComment,@OfficerName,@CommentDate,            " & _
                                "@CommentFromOffice1,@ShipFleetManager,@CommentFromOffice2,       " & _
                                "@SafetyOperationsManager,@Reemploy,@Promote,@PromoteReemployWhen," & _
                                "@AdditionalRemarks,@TrainingRequirements,@OverallAssessment,     " & _
                                "@FKeyMstrID, @FKeyCOId, @FKeyCEId, @UpdatedBy)                   "


    Dim updateQuery As String = "UPDATE tblCrewAppraisal SET                                                                  " & _
                                "FKeyIDNbr = @FKeyIDNbr, AppraisalDate = @AppraisalDate,                                      " & _
                                "FKeyActivity = @FKeyActivity, Service = @Service,OverallAssessment = @OverallAssessment,     " & _
                                "OccasionForReport = @OccasionForReport, OverallScore = @OverallScore,                        " & _
                                "Reemployed = @Reemployed, Promotion = @Promotion,                                            " & _
                                "SailAgain = @SailAgain, Remarks = @Remarks, MasterName = @MasterName,                        " & _
                                "ChiefOfficerName = @ChiefOfficerName, Strength = @Strength,                                  " & _
                                "Weakneses = @Weakneses, OfficerComment = @OfficerComment,                                    " & _
                                "OfficerName = @OfficerName, CommentDate = @CommentDate,                                      " & _
                                "CommentFromOffice1 = @CommentFromOffice1, ShipFleetManager = @ShipFleetManager,              " & _
                                "CommentFromOffice2 = @CommentFromOffice2, SafetyOperationsManager = @SafetyOperationsManager," & _
                                "Reemploy = @Reemploy, Promote = @Promote, PromoteReemployWhen = @PromoteReemployWhen,        " & _
                                "AdditionalRemarks = @AdditionalRemarks, TrainingRequirements = @TrainingRequirements,        " & _
                                "FKeyMstrID = @FKeyMstrID, FKeyCOId = @FKeyCOId, FKeyCEId = @FKeyCEId,                        " & _
                                "LastUpdatedBy = @UpdatedBy                                                                   " & _
                                "WHERE PKey = @PKey "
#End Region

    Sub New()
        InitializeComponent()
        AppraisalTab.SelectedTabPage = lcgConfRepPage1      '--> Put the tab on Page 1.
        clsAudit.propSQLConnStr = MPSDB.GetConnectionString
        AllowUpdate()
        folderPath = IfNull(MPSDB.GetConfig("DefaultFolder"), "")
    End Sub

    Public Overrides Sub RefreshData()
        '--> Load the necessary data based on the given crewID. 
        MyBase.RefreshData()
        Me.LayoutFavoriteButtons.Text = "Appraisal for " & crewName
        Dim dob As String = MPSDB.DLookUp("DOB", "tblCrewInfo", "", "PKey='" & crewID & "'")
        Dim grade As DataTable = MPSDB.CreateTable("SELECT Grade, CONCAT(Grade, ' - ', Remarks) AS Equivalent FROM tblAdmAppraisalGrades ORDER BY CONCAT(Grade, ' - ', Remarks)  DESC ;")
        Try
            txtDOB.Text = Convert.ToDateTime(dob.Split(" ")(0)).ToString("dd-MMM-yyyy")
        Catch ex As Exception
            txtDOB.Text = ""
        End Try

        txtCrewFullName.Text = MPSDB.DLookUp("CONCAT(LName, ', ', FName) AS FullName", "tblCrewInfo", "", "PKey = '" & crewID & "'")
        txtNationality.Text = MPSDB.DLookUp("Nat", "tblAdmCntry", "", "PKey='" & MPSDB.DLookUp("NatCode", "tblCrewInfo", "", "PKey='" & crewID & "'") & "'")
        RepGradeWorkFactor.DataSource = grade
        RepGradeBehavioralFactor.DataSource = grade
        SetGridReadOnlyProperties(AppraisalAttachmentView, False)
        LoadData()
        '--> We need this listener, to add color to your life. 
        AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {lcgCrewDetails, lcgOverallAssessment, lcgPage2, lcgReviewAndConclusion, lcgCommentFromOffice, lcgOfficerComment, lcgReviewAndConclusion, lcgStrenghtWeaknesses, lcgRemarks, lcgMaster})
    End Sub

    Private Sub LoadData()
        Try
            '--> Load the default labelings and grading templates.
            WorkFactorsGrid.DataSource = MPSDB.CreateTable("SELECT PKey, Title, Description, '' AS Comments, 0 as Grade, GroupName FROM tblAdmAppraisalFactors WHERE GroupName = 'Work Factors'")
            BehavioralFactorsGrid.DataSource = MPSDB.CreateTable("SELECT PKey, Title, Description, '' AS Comments, 0 as Grade, GroupName FROM tblAdmAppraisalFactors WHERE GroupName = 'Behavioral Factors'")
            '--> Load the Sea Services, with predefined format.
            CrewServices.Properties.DataSource = MPSDB.CreateTable("SELECT PKey AS FKeyActivity, Name FROM GetCrewService('" & crewID & "') ORDER BY DateSon DESC;")
            '--> Load appraisal from the CrewAppraisal object
            LoadAppraisalForEdit()
            '--> Get the attachments.
            AppraisalAttachmentGrid.DataSource = MPSDB.CreateTable("SELECT *, CAST(0 AS BIT) AS Edited FROM tblCrewAppraisalAttachments WHERE FKeyCrewAppraisal = '" & selectedAppraisalID & "'")
            '--> Add buttons for Browse and View attachment files.
            CreateButton()
        Catch ex As Exception
            MessageBox.Show("Error generated at RefreshData() method in Appraisal form : " + ex.Message)
        End Try
    End Sub

    Private Sub AllowUpdate()

        dtAppraisalDate.ReadOnly = Not editable
        CrewServices.ReadOnly = Not editable
        rgOccasionForReport.ReadOnly = Not editable
        WorkFactorsView.OptionsBehavior.Editable = editable
        BehavioralFactorsView.OptionsBehavior.Editable = editable
        txtOverallAssessment.ReadOnly = Not editable
        btnSaveAppraisalDetails.Enabled = editable
        rgReemployed.ReadOnly = Not editable
        rgPromotion.ReadOnly = Not editable
        rgSailAgain.ReadOnly = Not editable
        txtRemarks.ReadOnly = Not editable
        txtMaster.ReadOnly = Not editable
        txtCheifOfficer.ReadOnly = Not editable
        txtChiefEngineer.ReadOnly = Not editable
        txtStrength.ReadOnly = Not editable
        txtWeakness.ReadOnly = Not editable
        txtOfficerComment.ReadOnly = Not editable
        txtOfficerName.ReadOnly = Not editable
        dtOfficerCommentDate.ReadOnly = Not editable
        txtShipFleetManagerComment.ReadOnly = Not editable
        txtShipFleetManager.ReadOnly = Not editable
        txtSafetyOperationsManagerComment.ReadOnly = Not editable
        txtSafetyOperationsManager.ReadOnly = Not editable
        rgReemployment.ReadOnly = Not editable
        rgPromotion2.ReadOnly = Not editable
        txtYesWhen.ReadOnly = Not editable
        txtReviewConclusionRemarks.ReadOnly = Not editable
        txtTrainingRequirements.ReadOnly = Not editable

    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Return hasChanges And editable
    End Function

    Private Function GetAppraisalFactorDetails() As HashSet(Of CrewAppraisalDetails)

        Dim appraisalFactors As New HashSet(Of CrewAppraisalDetails)

        For i As Integer = 0 To WorkFactorsView.RowCount - 1
            Dim factor As New CrewAppraisalDetails
            factor.AppraisalFactorID = WorkFactorsView.GetRowCellValue(i, "PKey").ToString()
            factor.AppraisalComment = WorkFactorsView.GetRowCellValue(i, "Comments").ToString()
            factor.AppraisalGrade = WorkFactorsView.GetRowCellValue(i, "Grade").ToString()
            factor.AppraisalGroup = WorkFactorsView.GetRowCellValue(i, "GroupName").ToString()
            factor.AppraisalFactorName = WorkFactorsView.GetRowCellValue(i, "Title").ToString()
            appraisalFactors.Add(factor)
        Next

        For i As Integer = 0 To BehavioralFactorsView.RowCount - 1
            Dim factor As New CrewAppraisalDetails
            factor.AppraisalFactorID = BehavioralFactorsView.GetRowCellValue(i, "PKey").ToString()
            factor.AppraisalComment = BehavioralFactorsView.GetRowCellValue(i, "Comments").ToString()
            factor.AppraisalGrade = BehavioralFactorsView.GetRowCellValue(i, "Grade").ToString()
            factor.AppraisalGroup = BehavioralFactorsView.GetRowCellValue(i, "GroupName").ToString()
            factor.AppraisalFactorName = BehavioralFactorsView.GetRowCellValue(i, "Title").ToString()
            appraisalFactors.Add(factor)
        Next

        Return appraisalFactors

    End Function

    Private Sub LoadAppraisalForEdit()
        Try
            If IsNothing(selectedCrewAppraisal) Then
                dtAppraisalDate.EditValue = DateTime.Now.ToString("dd-MMM-yyyy")
                dtOfficerCommentDate.EditValue = DateTime.Now.ToString("dd-MMM-yyyy")
                IsNewAppraisal = True
                hasChanges = False
                IsTriggeredInClose = False
                Return
            End If
            With selectedCrewAppraisal
                selectedAppraisalID = .AppraisalID
                dtAppraisalDate.EditValue = IIf(IsNothing(.AppraisalDate), DateTime.Now.ToString("dd-MMM-yyyy"), Convert.ToDateTime(.AppraisalDate).ToString("dd-MMM-yyyy"))
                CrewServices.EditValue = .FKeyActivityID
                rgOccasionForReport.SelectedIndex = Convert.ToInt32(IIf(GetOccasionForReport(.OccasionForReport, True).Equals(""), "0", GetOccasionForReport(.OccasionForReport, True)))
                LoadAppraisalFactors(WorkFactorsView, "Work Factors", .AppraisalFactorsGrades)
                LoadAppraisalFactors(BehavioralFactorsView, "Behavioral Factors", .AppraisalFactorsGrades)
                txtOverallAssessment.EditValue = .OverallAssessment
                txtOverallScore.Text = .OverallScore
                rgReemployed.SelectedIndex = IIf(.Reemployed, 1, 0)
                rgPromotion.SelectedIndex = IIf(.Promotion, 1, 0)
                rgSailAgain.SelectedIndex = IIf(.SailAgain, 1, 0)
                txtRemarks.EditValue = .Remarks
                txtMaster.EditValue = .Master
                txtCheifOfficer.EditValue = .ChiefOfficer
                txtChiefEngineer.EditValue = .ChiefEngineer
                txtStrength.EditValue = .Strength
                txtWeakness.EditValue = .Weaknesses
                txtOfficerComment.EditValue = .OfficerComment
                txtOfficerName.EditValue = .OfficerName
                dtOfficerCommentDate.EditValue = IIf(IsNothing(.CommentDate), DateTime.Now.ToString("dd-MMM-yyyy"), Convert.ToDateTime(.CommentDate).ToString("dd-MMM-yyyy"))
                txtShipFleetManagerComment.EditValue = .CommentFromOfficer1
                txtShipFleetManager.EditValue = .ShipFleetManager
                txtSafetyOperationsManagerComment.EditValue = .CommentFromOfficer2
                txtSafetyOperationsManager.EditValue = .SafetyOperationsManager
                rgReemployment.SelectedIndex = IIf(.Reemploy, 1, 0)
                rgPromotion2.SelectedIndex = IIf(.Promote, 1, 0)
                txtYesWhen.EditValue = .PromoteReemployWhen
                txtReviewConclusionRemarks.EditValue = .AdditionalRemarks
                txtTrainingRequirements.EditValue = .TrainingRequirements
                hasChanges = False
                IsTriggeredInClose = False
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadAppraisalFactors(grid As DevExpress.XtraGrid.Views.Grid.GridView, group As String, details As HashSet(Of CrewAppraisalDetails))
        For i As Integer = 0 To grid.RowCount - 1
            For Each g As CrewAppraisalDetails In details
                If grid.GetRowCellValue(i, "PKey").ToString().Equals(g.AppraisalFactorID) Then
                    grid.SetRowCellValue(i, "Comments", g.AppraisalComment)
                    grid.SetRowCellValue(i, "Grade", g.AppraisalGrade)
                End If
            Next
        Next
    End Sub

    Private Function GetOccasionForReport(value As String, Optional isByIndex As Boolean = False) As String
        If isByIndex Then
            Select Case True
                Case value.Equals("6 Months")
                    Return "0"
                Case value.Equals("Special Request")
                    Return "1"
                Case value.Equals("Signing Off")
                    Return "2"
                Case value.Equals("Dismissal")
                    Return "3"
            End Select
        Else
            Select Case True
                Case value.Equals("0")
                    Return "6 Months"
                Case value.Equals("1")
                    Return "Special Request"
                Case value.Equals("2")
                    Return "Signing Off"
                Case value.Equals("3")
                    Return "Dismissal"
            End Select
        End If
        Return ""
    End Function

    Public Sub SetRowCellStyle(controlGrid As GridView, ByRef sender As Object, ByRef e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Try
            If controlGrid.GetRowCellValue(e.RowHandle, "Edited") Is DBNull.Value Then
                e.Appearance.BackColor = SEL_COLOR
            ElseIf controlGrid.GetRowCellValue(e.RowHandle, "Edited") And controlGrid.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = EDITED_FOCUSED_COLOR
            ElseIf controlGrid.GetRowCellValue(e.RowHandle, "Edited") = True Then
                e.Appearance.BackColor = EDITED_COLOR
            ElseIf e.RowHandle = controlGrid.FocusedRowHandle Then
                e.Appearance.BackColor = SEL_COLOR
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in SetRowCellStyle() method in frmAppraisalEdit.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetRowCellStyle() method in frmAppraisalEdit.vb - End--")

            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Function ComputeGrade() As Double
        Dim totalGradeWorkFactor As Double = 0
        Dim totalGradeBehaviorFactor As Double = 0

        Dim workFactorGradeCounter As Double = 0
        Dim behaviorFactorGradeCounter As Double = 0

        For counter As Integer = 0 To WorkFactorsView.RowCount - 1
            totalGradeWorkFactor += Convert.ToDouble(WorkFactorsView.GetRowCellValue(counter, "Grade"))
            workFactorGradeCounter += 1
        Next

        For counter As Integer = 0 To BehavioralFactorsView.RowCount - 1
            totalGradeBehaviorFactor += Convert.ToDouble(BehavioralFactorsView.GetRowCellValue(counter, "Grade"))
            behaviorFactorGradeCounter += 1
        Next

        Dim sumGrade As Double = (totalGradeBehaviorFactor / behaviorFactorGradeCounter) + (totalGradeWorkFactor / workFactorGradeCounter)

        Return sumGrade / 2
    End Function

    Private Sub WorkFactorsView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles WorkFactorsView.CellValueChanged
        If WorkFactorsView.FocusedColumn.FieldName.Equals("Grade") Then
            txtOverallScore.Text = Format(ComputeGrade(), "0.00")
        End If
        hasChanges = True
    End Sub

    Private Sub BehavioralFactorsView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BehavioralFactorsView.CellValueChanged
        If BehavioralFactorsView.FocusedColumn.FieldName.Equals("Grade") Then
            txtOverallScore.Text = Format(ComputeGrade(), "0.00")
        End If
        hasChanges = True
    End Sub

    Private Function GetNewAppraisalID(ByRef connection As SqlClient.SqlConnection, ByRef trans As SqlClient.SqlTransaction) As String
        Dim retVal As String = ""
        Try
            Dim cmd = New SqlClient.SqlCommand("SELECT PKey FROM tblCrewAppraisal  WHERE ID=IDENT_CURRENT('tblCrewappraisal')", connection, trans)
            retVal = cmd.ExecuteScalar()
            cmd.Dispose()
        Catch ex As Exception
            Return retVal
        End Try

        Return retVal
    End Function

    Private Sub LoadParametersForMainAppraisal(ByRef command As SqlClient.SqlCommand, Optional ByVal appraisalPKey As String = "")
        Try
            command.Parameters.AddWithValue("@FKeyIDNbr", HandleNullValues(crewID, "STRING"))
            command.Parameters.AddWithValue("@AppraisalDate", CDate(HandleNullValues(dtAppraisalDate.EditValue, "DATE")))
            command.Parameters.AddWithValue("@FKeyActivity", HandleNullValues(CrewServices.EditValue, "STRING"))
            command.Parameters.AddWithValue("@Service", HandleNullValues(CrewServices.Text, "STRING"))
            command.Parameters.AddWithValue("@OccasionForReport", HandleNullValues(GetOccasionForReport(rgOccasionForReport.SelectedIndex.ToString(), False), "STRING"))
            command.Parameters.AddWithValue("@OverallScore", HandleNullValues(txtOverallScore.Text, "NUMBER"))
            command.Parameters.AddWithValue("@Reemployed", IIf(rgReemployed.SelectedIndex = 0, False, True))
            command.Parameters.AddWithValue("@Promotion", IIf(rgPromotion.SelectedIndex = 0, False, True))
            command.Parameters.AddWithValue("@SailAgain", IIf(rgSailAgain.SelectedIndex = 0, False, True))
            command.Parameters.AddWithValue("@Remarks", HandleNullValues(txtRemarks.EditValue, "STRING"))
            command.Parameters.AddWithValue("@MasterName", HandleNullValues(txtMaster.EditValue, "STRING"))
            command.Parameters.AddWithValue("@ChiefOfficerName", HandleNullValues(txtCheifOfficer.EditValue, "STRING"))
            command.Parameters.AddWithValue("@Strength", HandleNullValues(txtStrength.EditValue, "STRING"))
            command.Parameters.AddWithValue("@Weakneses", HandleNullValues(txtWeakness.EditValue, "STRING"))
            command.Parameters.AddWithValue("@OfficerComment", HandleNullValues(txtOfficerComment.EditValue, "STRING"))
            command.Parameters.AddWithValue("@OfficerName", HandleNullValues(txtOfficerComment.EditValue, "STRING"))
            command.Parameters.AddWithValue("@CommentDate", CDate(HandleNullValues(dtOfficerCommentDate.EditValue, "DATE")))
            command.Parameters.AddWithValue("@CommentFromOffice1", HandleNullValues(txtShipFleetManagerComment.EditValue, "STRING"))
            command.Parameters.AddWithValue("@ShipFleetManager", HandleNullValues(txtShipFleetManager.EditValue, "STRING"))
            command.Parameters.AddWithValue("@CommentFromOffice2", HandleNullValues(txtSafetyOperationsManagerComment.EditValue, "STRING"))
            command.Parameters.AddWithValue("@SafetyOperationsManager", HandleNullValues(txtSafetyOperationsManager.EditValue, "STRING"))
            command.Parameters.AddWithValue("@Reemploy", IIf(rgReemployment.SelectedIndex = 0, False, True))
            command.Parameters.AddWithValue("@Promote", IIf(rgPromotion2.SelectedIndex = 0, False, True))
            command.Parameters.AddWithValue("@PromoteReemployWhen", HandleNullValues(txtYesWhen.EditValue, "STRING"))
            command.Parameters.AddWithValue("@AdditionalRemarks", HandleNullValues(txtReviewConclusionRemarks.EditValue, "STRING"))
            command.Parameters.AddWithValue("@TrainingRequirements", HandleNullValues(txtTrainingRequirements.EditValue, "STRING"))
            command.Parameters.AddWithValue("@OverallAssessment", HandleNullValues(txtOverallAssessment.EditValue, "STRING"))
            command.Parameters.AddWithValue("@FKeyMstrId", HandleNullValues(txtMaster.EditValue, "STRING"))
            command.Parameters.AddWithValue("@FKeyCOId", HandleNullValues(txtCheifOfficer.EditValue, "STRING"))
            command.Parameters.AddWithValue("@FKeyCEId", HandleNullValues(txtChiefEngineer.EditValue, "STRING"))
            command.Parameters.AddWithValue("@UpdatedBy", HandleNullValues(lastUpdatedBy, "STRING"))
            If appraisalPKey.Trim().Length > 0 Then
                command.Parameters.AddWithValue("@PKey", HandleNullValues(appraisalPKey, "STRING"))
            End If
        Catch ex As Exception
            MessageBox.Show("LoadParametersForMainAppraisal - " & ex.Message)
        End Try
    End Sub

    Private Function HandleNullValues(source As Object, type As String) As String
        Dim retVal As String = ""
        Try
            If (IsDBNull(source)) Then
                If type.Equals("DATE") Then
                    retVal = DateTime.Now.ToShortDateString()
                ElseIf type.Equals("STRING") Then
                    retVal = ""
                ElseIf type.Equals("BIT") Then
                    retVal = "False"
                ElseIf type.Equals("NUMBER") Then
                    retVal = "0"
                End If
            Else
                If (Not (source.ToString().Equals(""))) Then
                    retVal = source.ToString()
                Else
                    If type.Equals("NUMBER") Then
                        retVal = "0"
                    End If
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in HandleNullValues() method in frmPopupMedHistory.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in HandleNullValues() method in frmPopupMedHistory.vb - End--")
            retVal = ""
        End Try

        Return retVal
    End Function

    Public Sub RunUpdateAppraisalData()
        If IsNewAppraisal Then
            Appraisal.hasAppraisalUpdated = SaveAppraisal()
        Else
            Appraisal.hasAppraisalUpdated = UpdateAppraisal()
        End If
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()

        If IsTriggeredInClose Then
            RunUpdateAppraisalData()
        Else
            Dim result = MessageBox.Show("Save the changes on this appraisal for Crew [" & crewName & "] ?", "Appraisal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (result = DialogResult.Yes) Then
                RunUpdateAppraisalData()
                IsTriggeredInClose = False
            Else
                Return
            End If
        End If

        If Appraisal.hasAppraisalUpdated Then
            MessageBox.Show("Appraisal details successfully saved.", "Appraisal", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BRECORDUPDATEDs = False
            hasChanges = False
            IsTriggeredInClose = False
            frmAppraisalPopup.ActiveForm.Close()
        Else
            MessageBox.Show("There is a problem saving the appraisal details.", "Appraisal", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSaveAppraisalDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAppraisalDetails.Click
        SaveData()
    End Sub

    Private Function SaveAppraisal() As Boolean

        Dim sqlTrans As SqlClient.SqlTransaction = Nothing
        Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(MPSDB.GetConnectionString())
        Dim retVal As Boolean = False

        Try
            sqlConn.Open()
            If sqlConn.State = ConnectionState.Open Then
                sqlTrans = sqlConn.BeginTransaction()
                lastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Appraisal", 0, System.Environment.MachineName, "Add Appraisal", FormName, crewID)

                Using command As New SqlClient.SqlCommand()
                    command.Connection = sqlConn
                    command.CommandTimeout = TIME_OUT
                    command.Transaction = sqlTrans
                    command.CommandText = insertQuery
                    LoadParametersForMainAppraisal(command)
                    command.ExecuteNonQuery()
                End Using

                Using factorGradeCommand As New SqlClient.SqlCommand()
                    factorGradeCommand.Connection = sqlConn
                    factorGradeCommand.CommandTimeout = TIME_OUT
                    factorGradeCommand.Transaction = sqlTrans
                    SaveAppraisalGradeFactors(factorGradeCommand, GetNewAppraisalID(sqlConn, sqlTrans))
                End Using

                Using attachmentCommand As New SqlClient.SqlCommand()
                    attachmentCommand.Connection = sqlConn
                    attachmentCommand.CommandTimeout = TIME_OUT
                    attachmentCommand.Transaction = sqlTrans
                    SaveAppraisalAttachments(attachmentCommand, GetNewAppraisalID(sqlConn, sqlTrans))
                End Using


                sqlTrans.Commit()
                retVal = True
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in SaveAppraisal() method in frmAppraisalEdit.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SaveAppraisal() method in frmAppraisalEdit.vb - End--")

            MessageBox.Show("There is an error while saving Adding Appraisal : " + ex.Message)
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

    Private Function UpdateAppraisal() As Boolean

        Dim sqlTrans As SqlClient.SqlTransaction = Nothing
        Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(MPSDB.GetConnectionString())
        Dim retVal As Boolean = False
        Try
            sqlConn.Open()
            If sqlConn.State = ConnectionState.Open Then
                sqlTrans = sqlConn.BeginTransaction()
                lastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Appraisal", 0, System.Environment.MachineName, "Update Appraisal", FormName, crewID)
                Using command As New SqlClient.SqlCommand()
                    command.Connection = sqlConn
                    command.CommandTimeout = TIME_OUT
                    command.Transaction = sqlTrans
                    command.CommandText = updateQuery
                    LoadParametersForMainAppraisal(command, IIf(IsNothing(selectedCrewAppraisal), "", selectedCrewAppraisal.AppraisalID))
                    command.ExecuteNonQuery()
                End Using

                Using factorGradeCommand As New SqlClient.SqlCommand()
                    factorGradeCommand.Connection = sqlConn
                    factorGradeCommand.CommandTimeout = TIME_OUT
                    factorGradeCommand.Transaction = sqlTrans
                    UpdateAppraisalGradeFactors(factorGradeCommand, selectedCrewAppraisal.AppraisalID)
                End Using

                Using attachmentCommand As New SqlClient.SqlCommand()
                    attachmentCommand.Connection = sqlConn
                    attachmentCommand.CommandTimeout = TIME_OUT
                    attachmentCommand.Transaction = sqlTrans
                    SaveAppraisalAttachments(attachmentCommand, selectedCrewAppraisal.AppraisalID)
                End Using

                sqlTrans.Commit()
                retVal = True
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in UpdateAppraisal() method in frmAppraisalEdit.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in UpdateAppraisal() method in frmAppraisalEdit.vb - End--")

            MessageBox.Show("There is an error while saving Updating Appraisal : " + ex.Message)
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

    Private Sub UpdateAppraisalGradeFactors(ByRef command As SqlClient.SqlCommand, appraisalId As String)
        Try
            For Each detail As CrewAppraisalDetails In GetAppraisalFactorDetails()
                command.CommandText = "UPDATE tblCrewAppraisalDetails SET " & _
                                      "Comments = '" & HandleNullValues(detail.AppraisalComment, "STRING") & "', " & _
                                      "Grades = " & detail.AppraisalGrade & " " & _
                                      "WHERE FKeyAppraisalFactors = '" & detail.AppraisalFactorID & "' AND FKeyCrewAppraisal = '" & appraisalId & "' "
                command.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MessageBox.Show("UpdateAppraisalGradeFactors - " & ex.Message)
        End Try
    End Sub

    Private Sub SaveAppraisalGradeFactors(ByRef command As SqlClient.SqlCommand, appraisalId As String)
        Try
            'Get the id of newly added appraisal saved in tblCrewAppraisal
            'Loop through Work and Behavioral Factors
            For Each detail As CrewAppraisalDetails In GetAppraisalFactorDetails()
                command.CommandText = "INSERT INTO tblCrewAppraisalDetails(FKeyCrewAppraisal, FKeyAppraisalFactors, Comments, Grades) " & _
                                      "VALUES ('" & HandleNullValues(appraisalId, "STRING") & "','" & HandleNullValues(detail.AppraisalFactorID, "STRING") & _
                                      "','" & HandleNullValues(detail.AppraisalComment, "STRING") & "'," & detail.AppraisalGrade & " )"
                command.ExecuteNonQuery()
            Next

        Catch ex As Exception
            MessageBox.Show("SaveAppraisalGradeFactors - " & ex.Message)
        End Try
    End Sub

    Private Sub CrewServices_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles CrewServices.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub BehavioralFactorsView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BehavioralFactorsView.RowCellStyle
        SetRowCellStyle(BehavioralFactorsView, sender, e)
    End Sub

    Private Sub WorkFactorsView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles WorkFactorsView.RowCellStyle
        SetRowCellStyle(WorkFactorsView, sender, e)
    End Sub

    Private Sub CrewServices_EditValueChanged(sender As Object, e As System.EventArgs) Handles CrewServices.EditValueChanged

        serviceVesselID = DB.DLookUp("FKeyVslCode", "tblActivity", "", "PKey ='" & CrewServices.EditValue.ToString() & "'")
        startDate = DB.DLookUp("ActDateStart", "tblActivity", DateTime.Now, "PKey ='" & CrewServices.EditValue.ToString() & "'")
        endDate = DB.DLookUp("ActDateEnd", "tblActivity", DateTime.Now, "PKey ='" & CrewServices.EditValue.ToString() & "'")

        '--> TODO: We need to find a better approach in getting the rank's id.
        txtMaster.Properties.DataSource = GetOnboardOfficers("SPECT0000000132")
        txtChiefEngineer.Properties.DataSource = GetOnboardOfficers("SPECT0000000110")
        txtCheifOfficer.Properties.DataSource = GetOnboardOfficers("SPECT0000000111")

        hasChanges = True

    End Sub

    Private Function GetOnboardOfficers(rankCode As String) As DataTable
        Dim query As String = "SELECT FKeyIDNbr, FullName FROM GetOnboardOfficers('" & serviceVesselID & "','" & rankCode & "','" & startDate.ToString("MM-dd-yyyy") & "','" & endDate.ToString("MM-dd-yyyy") & "')"
        Try
            Return DB.CreateTable(query, TIME_OUT)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#Region "Appraisal Attachments"

    Private Sub CreateButton()
        If editable Then
            '--> If the user has an edit permission and the Add/Edit button has been activated, the user can click the Browse button to select other files. 
            Dim addButton As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repBtnAddAttachment
            With addButton
                .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                                      "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                                      Nothing, Nothing, Nothing, Nothing))
                .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
                AddHandler .ButtonPressed, AddressOf repButtonClick
            End With
        End If
        

        Dim viewButton As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = RepViewAttachment

        AddHandler viewButton.ButtonPressed, AddressOf ViewAttachmentClick

    End Sub

    Private Sub OpenFile(fileName As String, notYetSaved As Boolean)
        Try
            Dim filePath As String = GetCrewDocsPath()          'Use the default storage location of images.
            If notYetSaved Then
                System.Diagnostics.Process.Start(fileName)      'If not save yet, use the file name as is (ignore the default storage) and open it.
            Else
                If (Not fileName.Trim().Equals("")) Then
                    filePath &= "\" & crewID & "\" & fileName   'Default storage, then folder, then file name. 
                    System.Diagnostics.Process.Start(filePath)  'Open the file.
                Else
                    MessageBox.Show("The file for this attachment does not exists.", "Appraisal Attachment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        End Try
    End Sub

    Private Sub ViewAttachmentClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim _Parentview As DevExpress.XtraGrid.Views.Grid.GridView = AppraisalAttachmentView
        Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim bIndex As Integer = btn.Properties.Buttons.IndexOf(e.Button)
        If bIndex = 0 Then

            Dim pkey As String = IfNull(_Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey"), "")
            Dim fileName As String = IfNull(_Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "FileName"), "")
            Dim filePath As String = IfNull(_Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "FilePath"), "")

            If IsNothing(pkey) Or IsNothing(fileName) Or IsNothing(filePath) Then Return '--> If there is no any valid path, stop the method execution.

            If (pkey.Equals("")) Then
                OpenFile(filePath, True)    'If it is added but not saved yet, use the original file path.
            Else
                OpenFile(fileName, False)   'Otherwise, use the saved filename.
            End If
        End If
    End Sub

    Private Sub repButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim _Parentview As DevExpress.XtraGrid.Views.Grid.GridView = AppraisalAttachmentView
        Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim bIndex As Integer = btn.Properties.Buttons.IndexOf(e.Button)
        Dim odMain As New System.Windows.Forms.OpenFileDialog

        If bIndex = 0 Then
            If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                btn.Text = odMain.SafeFileName
                AppraisalAttachmentView.SetFocusedRowCellValue("Description", odMain.SafeFileName)
                AppraisalAttachmentView.SetFocusedRowCellValue("FilePath", odMain.FileName.ToString())
                hasChanges = True
                BRECORDUPDATEDs = True
            End If
        End If

    End Sub


    Public Sub SetGridReadOnlyProperties(ByRef controlGrid As GridView, Optional isReadOnly As Boolean = True)
        With controlGrid
            Select Case isReadOnly
                Case True
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    .OptionsBehavior.ReadOnly = isReadOnly
                Case Else
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                    .OptionsBehavior.ReadOnly = isReadOnly
            End Select
        End With
    End Sub

    Private Function ConstructAttachmentName(appraisalID As String) As String
        'Create a name for the attachment file that corresponds with appraisalId, date and time.
        Dim dt As Date = DateTime.Now
        Dim retVal As String = ""
        If Not appraisalID.Trim().Equals("") Then
            retVal = appraisalID & "_" & dt.Year & dt.Month & dt.Day & "_" & dt.Hour & dt.Minute & dt.Second & dt.Millisecond
        End If
        Return retVal
    End Function

    Private Sub SaveAppraisalAttachments(ByRef command As SqlClient.SqlCommand, appraisalID As String)
        Dim query As String = ""
        '--> Gather and insert/update the appraisal attachments.
        Try
            For counter As Integer = 0 To AppraisalAttachmentView.DataRowCount - 1
                With AppraisalAttachmentView
                    .CloseEditForm()
                    .UpdateCurrentRow()
                    Dim filePath As String = .GetRowCellValue(counter, "FilePath").ToString()
                    Dim fileName As String = ConstructAttachmentName(appraisalID) & filePath.Substring(filePath.LastIndexOf("."))
                    If .GetRowCellValue(counter, "Edited") Then
                        If IfNull(.GetRowCellValue(counter, "PKey"), "") = "" Then
                            lastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Appraisal", 0, System.Environment.MachineName, "Added Appraisal Attachment", FormName, crewID)
                            query = "INSERT INTO dbo.tblCrewAppraisalAttachments(FKeyCrewAppraisal, FilePath, FileName, Description, LastUpdatedBy)" & _
                                    "VALUES ('" & appraisalID & "','" & filePath & "'," & _
                                    "'" & fileName & "','" & CleanInput(.GetRowCellValue(counter, "Description")) & "','" & lastUpdatedBy & "')"
                        Else
                            lastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Appraisal", 0, System.Environment.MachineName, "Updated Appraisal Attachment", FormName, crewID)
                            query = "UPDATE dbo.tblCrewAppraisalAttachments SET FKeyCrewAppraisal = '" & appraisalID & "', " & _
                                    "FilePath = '" & filePath & "', " & _
                                    "FileName = '" & fileName & "', " & _
                                    "Description = '" & CleanInput(.GetRowCellValue(counter, "Description")) & "', " & _
                                    "LastUpdatedBy = '" & lastUpdatedBy & "' " & _
                                    "WHERE FKeyCrewAppraisal = '" & appraisalID & "' AND PKey = '" & .GetRowCellValue(counter, "PKey") & "'"
                        End If
                        command.CommandText = query
                        command.ExecuteNonQuery()
                        CopyAppraisalAttachment(fileName, filePath) '--> If the attachment hase been saved/updated successfully, then copy the file and paste it on appropriate location.
                    End If

                End With
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CopyAppraisalAttachment(fileName As String, sourcePath As String)
        Try
            If Not folderPath.Trim().Equals("") Then
                If Directory.Exists(folderPath & "\" & crewID) Then     'If there is already a folder for that crew, use it.
                    File.Copy(sourcePath, folderPath & "\" & crewID & "\" & fileName, True)
                Else
                    MkDir(folderPath & "\" & crewID)                    'Otherwise, create a new folder named after the crew id, then save the file on that location/
                    File.Copy(sourcePath, folderPath & "\" & crewID & "\" & fileName, True)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub AppraisalAttachmentView_CellValueChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AppraisalAttachmentView.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName.ToString <> "Edited" Then
            view.SetRowCellValue(view.FocusedRowHandle, "Edited", True)
            Me.header.Focus()
        End If
    End Sub

    Private Sub AppraisalAttachmentView_InitNewRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AppraisalAttachmentView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
    End Sub

#End Region

#Region "Changes in Appraisal"
    Private Sub rgOccasionForReport_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rgOccasionForReport.SelectedIndexChanged
        hasChanges = True
    End Sub

    Private Sub txtOverallAssessment_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtOverallAssessment.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub rgReemployed_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rgReemployed.SelectedIndexChanged
        hasChanges = True
    End Sub

    Private Sub rgPromotion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rgPromotion.SelectedIndexChanged
        hasChanges = True
    End Sub

    Private Sub rgSailAgain_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rgSailAgain.SelectedIndexChanged
        hasChanges = True
    End Sub

    Private Sub txtRemarks_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtRemarks.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtMaster_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtMaster.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtCheifOfficer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtCheifOfficer.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtChiefEngineer_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtChiefEngineer.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtStrength_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtStrength.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtWeakness_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtWeakness.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtOfficerComment_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtOfficerComment.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtOfficerName_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtOfficerName.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub dtOfficerCommentDate_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles dtOfficerCommentDate.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtShipFleetManagerComment_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtShipFleetManagerComment.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtShipFleetManager_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtShipFleetManager.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtSafetyOperationsManagerComment_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtSafetyOperationsManagerComment.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtSafetyOperationsManager_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtSafetyOperationsManager.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub rgReemployment_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rgReemployment.SelectedIndexChanged
        hasChanges = True
    End Sub

    Private Sub rgPromotion2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rgPromotion2.SelectedIndexChanged
        hasChanges = True
    End Sub

    Private Sub txtYesWhen_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtYesWhen.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtReviewConclusionRemarks_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtReviewConclusionRemarks.EditValueChanged
        hasChanges = True
    End Sub

    Private Sub txtTrainingRequirements_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTrainingRequirements.EditValueChanged
        hasChanges = True
    End Sub
#End Region

    Private Sub AppraisalAttachmentGrid_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppraisalAttachmentGrid.KeyDown
        Dim message As String = "Deleting this record will also delete the physical file that corresponds with this attachment, you cannot undo this action. Proceed? "
        Try
            If e.KeyCode = Keys.Delete And editable Then
                If DialogResult.Yes = MessageBox.Show(message, "Delete Appraisal Attachment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Dim pkey As String = AppraisalAttachmentView.GetRowCellValue(AppraisalAttachmentView.FocusedRowHandle, "PKey")
                    Dim fileName As String = AppraisalAttachmentView.GetRowCellValue(AppraisalAttachmentView.FocusedRowHandle, "FileName")
                    Dim query As String = "DELETE FROM dbo.tblCrewAppraisalAttachments WHERE PKey = '" & pkey & "'"
                    Dim result As Integer = -1
                    MPSDB.RunSql(query, result)
                    File.Delete(folderPath & "\" & crewID & "\" & fileName)
                    AppraisalAttachmentView.DeleteRow(AppraisalAttachmentView.FocusedRowHandle)
                    MessageBox.Show("Appraisal attachment successfully deleted.", "Appraisal Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub AppraisalAttachmentView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AppraisalAttachmentView.RowCellStyle
        SetRowCellStyle(AppraisalAttachmentView, sender, e)
    End Sub

    Private Sub AppraisalAttachmentView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AppraisalAttachmentView.ShowingEditor
        If (AppraisalAttachmentView.FocusedColumn.FieldName.Equals("Description")) And Not editable Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub
End Class

