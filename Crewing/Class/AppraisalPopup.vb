

Public Class AppraisalPopup
    Inherits EditFormUserControl

    Private crewID As String
    Private serviceName As String

    'Private appraisalDetails As New HashSet(Of MainAppraisal.AppraisalDetails)

    Public Sub New(_strID As String, strDesc As String)
        InitializeComponent()
        Me.LayoutControl1.AllowCustomization = False
        Me.header.Text = "Crew Appraisal for " & strDesc
        txtCrewFullName.Text = strDesc
        Dim dob As String = MPSDB.DLookUp("DOB", "tblCrewInfo", "", "PKey='" & _strID & "'")
        Try
            dob = Convert.ToDateTime(dob.Split(" ")(0)).ToString("dd-MMM-yyyy")
        Catch ex As Exception
            dob = ""
        End Try

        txtDateOfBirth.Text = dob
        txtNationality.Text = MPSDB.DLookUp("Nat", "tblAdmCntry", "", "PKey='" & MPSDB.DLookUp("NatCode", "tblCrewInfo", "", "PKey='" & _strID & "'") & "'")
        crewID = _strID
        LoadGradingData()
        'RefreshData()
    End Sub

    Public Sub LoadGradingData()
        Try
            WorkFactorsGrid.DataSource = MPSDB.CreateTable("SELECT PKey, Title, Description, '' AS Comments, 0 as Grade, GroupName FROM tblAdmAppraisalFactors WHERE GroupName = 'Work Factors'")
            BehavioralFactorGrid.DataSource = MPSDB.CreateTable("SELECT PKey, Title, Description, '' AS Comments, 0 as Grade, GroupName FROM tblAdmAppraisalFactors WHERE GroupName = 'Behavioral Factors'")
            cboService.Properties.DataSource = MPSDB.CreateTable("SELECT PKey AS FKeyActivity, Name FROM GetCrewService('" & crewID & "') ORDER BY DateSon DESC;")
            'dtAppraisalDate.EditValue = DateTime.Now.ToShortDateString()
        Catch ex As Exception
            MessageBox.Show("Error generated at RefreshData() method in Appraisal form : " + ex.Message)
        End Try
    End Sub

    Private Sub LoadAppraisalDetails()
        'Try
        '    If MainAppraisal.listOfAppraisalDetails.Count > 0 Then
        '        Dim id As Integer = HasCrewAppraisal()
        '        If id = -1 Then
        '            LoadGradingData()
        '            Exit Sub
        '        End If
        '        Dim crewAppraisal As MainAppraisal.CrewAppraisal = MainAppraisal.listOfAppraisalDetails(id)
        '        If Not IsNothing(crewAppraisal) Then
        '            For Each details As MainAppraisal.AppraisalDetails In crewAppraisal.Details
        '                If (details.AppraisalGroup.Equals("Work Factors")) Then
        '                    For i As Integer = 0 To WorkFactorsView.RowCount - 1
        '                        If WorkFactorsView.GetRowCellValue(i, "PKey").ToString().Equals(details.AppraisalFactorID) Then
        '                            WorkFactorsView.SetRowCellValue(i, "Comment", details.AppraisalComment)
        '                            WorkFactorsView.SetRowCellValue(i, "Grade", details.AppraisalGrade)
        '                        End If
        '                    Next
        '                ElseIf (details.AppraisalGroup.Equals("Behavioral Factors")) Then
        '                    For i As Integer = 0 To BehavioralFactorView.RowCount - 1
        '                        If BehavioralFactorView.GetRowCellValue(i, "PKey").ToString().Equals(details.AppraisalFactorID) Then
        '                            BehavioralFactorView.SetRowCellValue(i, "Comment", details.AppraisalComment)
        '                            BehavioralFactorView.SetRowCellValue(i, "Grade", details.AppraisalGrade)
        '                        End If
        '                    Next
        '                End If
        '            Next
        '        End If
        '    Else
        '        LoadGradingData()
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub WorkFactorsView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles WorkFactorsView.CellValueChanged
        If WorkFactorsView.FocusedColumn.FieldName.Equals("Grade") Then
            txtOverallScore.Text = ComputeGrade()
        End If
    End Sub

    Private Function ComputeGrade() As Double

        Dim totalGradeWorkFactor As Double = 0
        Dim totalGradeBehaviorFactor As Double = 0

        Dim workFactorGradeCounter As Integer = 0
        Dim behaviorFactorGradeCounter As Integer = 0

        For counter As Integer = 0 To WorkFactorsView.RowCount - 1
            totalGradeWorkFactor += Convert.ToInt32(WorkFactorsView.GetRowCellValue(counter, "Grade"))
            workFactorGradeCounter += 1
        Next

        For counter As Integer = 0 To BehavioralFactorView.RowCount - 1
            totalGradeBehaviorFactor += Convert.ToInt32(BehavioralFactorView.GetRowCellValue(counter, "Grade"))
            behaviorFactorGradeCounter += 1
        Next

        Dim sumGrade As Double = (totalGradeBehaviorFactor / behaviorFactorGradeCounter) + (totalGradeWorkFactor / workFactorGradeCounter)

        Return sumGrade / 2
    End Function

    Private Sub BehavioralFactorView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BehavioralFactorView.CellValueChanged
        If BehavioralFactorView.FocusedColumn.FieldName.Equals("Grade") Then
            txtOverallScore.Text = ComputeGrade()
        End If
    End Sub


    Private Sub Appraisal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadAppraisalDetails()
    End Sub

    Private Sub Appraisal_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        LoadAppraisalDetails()
    End Sub
End Class
