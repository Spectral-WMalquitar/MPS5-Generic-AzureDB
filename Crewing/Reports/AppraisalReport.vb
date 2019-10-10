Imports DevExpress.XtraReports.UI

Public Class AppraisalReport

    Private _crewAppraisal As New CrewAppraisal
    Private _crewName As String

    Public Sub New(appraisal As CrewAppraisal)

        InitializeComponent()
        Me._crewAppraisal = appraisal
        PrepareReportDate()

        Me.ShowPreviewDialog()

    End Sub

    Private Sub SetOccasionForReport(occassion As String)
        UncheckOccasions()
        Select Case True
            Case occassion.Equals("6 Months")
                chk6Months.Checked = True
            Case occassion.Equals("Special Request")
                chkSpecialRequest.Checked = True
            Case occassion.Equals("Signing Off")
                chkSigningOff.Checked = True
            Case occassion.Equals("Dismissal")
                chkDismissal.Checked = True
        End Select
    End Sub

    Private Sub UncheckOccasions()
        chk6Months.Checked = False
        chkDismissal.Checked = False
        chkSigningOff.Checked = False
        chkSpecialRequest.Checked = False
    End Sub

    Private Sub LoadAppraisalDetails(details As HashSet(Of CrewAppraisalDetails))

        Dim data As DataTable = MPSDB.CreateTable("SELECT PKey, Title FROM tblAdmAppraisalFactors")
        For Each r As DataRow In data.Rows

            For Each c As CrewAppraisalDetails In details
                If c.AppraisalFactorID.Equals(r("PKey").ToString()) Then
                    If r("Title").ToString().ToUpper().Equals("ABILITY") Then
                        lblAbility.Text = c.AppraisalComment
                        lblAbilityScore.Text = c.AppraisalGrade
                    ElseIf r("Title").ToString().ToUpper().Equals("DILIGENCE") Then
                        lblDiligence.Text = c.AppraisalComment
                        lblDiligenceGrade.Text = c.AppraisalGrade
                    ElseIf r("Title").ToString().ToUpper().Equals("SAFETY AWARENESS") Then
                        lblSafetyAwareness.Text = c.AppraisalComment
                        lblSafetyAwarenessGrade.Text = c.AppraisalGrade
                    ElseIf r("Title").ToString().ToUpper().Equals("RESPONSIBILITY") Then
                        lblResponsibility.Text = c.AppraisalComment
                        lblResponsibilityGrade.Text = c.AppraisalGrade
                    ElseIf r("Title").ToString().ToUpper().Equals("MOTIVATION") Then
                        lblMotivation.Text = c.AppraisalComment
                        lblMotivationGrade.Text = c.AppraisalGrade
                    ElseIf r("Title").ToString().ToUpper().Equals("CONDUCT AND APPEARANCE") Then
                        lblConductAndAppearance.Text = c.AppraisalComment
                        lblConductAppearanceGrade.Text = c.AppraisalGrade
                    ElseIf r("Title").ToString().ToUpper().Equals("COOPERATION") Then
                        lblCooperation.Text = c.AppraisalComment
                        lblCooperationGrade.Text = c.AppraisalGrade
                    ElseIf r("Title").ToString().ToUpper().Equals("LEADERSHIP") Then
                        lblLeadership.Text = c.AppraisalComment
                        lblLeadershipGrade.Text = c.AppraisalGrade
                    ElseIf r("Title").ToString().ToUpper().Equals("SOBRIETY") Then
                        lblSobriety.Text = c.AppraisalComment
                        lblSobrietyGrade.Text = c.AppraisalGrade
                    End If
                End If
            Next
        Next
        data.Dispose()

    End Sub


    Private Sub GetActivityDetails(id As String)

        Dim data As DataTable = MPSDB.CreateTable("SELECT VslName, RankName, FKeyActivityGroupID FROM tblActivity WHERE PKey ='" & id & "'")
        Dim activityGroupID As String = ""
        If (data.Rows.Count > 0) Then
            For Each d As DataRow In data.Rows
                lblVessel.Text = d("VslName").ToString()
                lblRank.Text = d("RankName").ToString()
                activityGroupID = d("FKeyActivityGroupID").ToString()
            Next
        End If
        data.Dispose()

        Dim crewDetails As DataTable = MPSDB.CreateTable("SELECT FKeyIDNbr, FName, LName, DOB, NatName FROM tblActivityGroup WHERE PKey ='" & activityGroupID & "'")
        If (crewDetails.Rows.Count > 0) Then
            For Each d As DataRow In crewDetails.Rows
                lblFullName.Text = d("LName").ToString() & ", " & d("FName").ToString()
                lblDOB.Text = Convert.ToDateTime(MPSDB.DLookUp("DOB", "tblCrewInfo", "", "PKey='" & d("FKeyIDNbr") & "'")).ToString("dd-MMM-yyyy")
                lblNationality.Text = d("NatName").ToString()
            Next
        End If
        crewDetails.Dispose()
    End Sub

    Private Sub PrepareReportDate()
        If IsNothing(Me._crewAppraisal) Then
            MessageBox.Show("There is no Appraisal data to be shown.", "Appraisal Report", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With Me._crewAppraisal
                lblTitle.Text = MPSDB.GetConfig("Name")
                lblAppraisalDate.Text = .AppraisalDate
                GetActivityDetails(.FKeyActivityID)
                lblService.Text = .Service
                SetOccasionForReport(.OccasionForReport)
                LoadAppraisalDetails(.AppraisalFactorsGrades)
                lblOverallAssessment.Text = .OverallAssessment
                lblOverallAssessmentGrade.Text = .OverallScore
                chkReemployedYes.Checked = Not .Reemployed
                chkReemployedNo.Checked = .Reemployed
                chkPromotionYes.Checked = Not .Promotion
                chkPromotionNo.Checked = .Promotion
                chkSailAgainYes.Checked = Not .SailAgain
                chkSailAgainNo.Checked = .SailAgain
                lblRemarks.Text = .Remarks
                lblMaster.Text = MPSDB.DLookUp("CONCAT(FName, ' ', LName) as FullName", "tblCrewInfo", "", "PKey ='" & .Master & "'")
                lblChiefOfficer.Text = MPSDB.DLookUp("CONCAT(FName, ' ', LName) as FullName", "tblCrewInfo", "", "PKey ='" & .ChiefOfficer & "'")
                lblChiefEngineer.Text = MPSDB.DLookUp("CONCAT(FName, ' ', LName) as FullName", "tblCrewInfo", "", "PKey ='" & .ChiefEngineer & "'")
                lblStrenght.Text = .Strength
                lblWeakness.Text = .Weaknesses
                lblOfficerComment.Text = .OfficerComment
                lblOfficerName.Text = .OfficerName
                lblCommentDate.Text = IIf(.CommentDate.Equals(""), "", Convert.ToDateTime(.CommentDate).ToString("dd-MMM-yyyy"))
                lblCommentFromOffice1.Text = .CommentFromOfficer1
                lblCommentFromOffice2.Text = .CommentFromOfficer2
                lblShipFleetManager.Text = .ShipFleetManager
                lblSafetyOperationsManager.Text = .SafetyOperationsManager
                chkReemploymentYes.Checked = Not .Reemploy
                chkReemploymentNo.Checked = .Reemploy
                chkPromoteYes.Checked = Not .Promote
                chkPromoteNo.Checked = .Promote
                lblAdditionalRemarks.Text = .AdditionalRemarks
                lblTrainingRequirements.Text = .TrainingRequirements
            End With
        End If
    End Sub

End Class