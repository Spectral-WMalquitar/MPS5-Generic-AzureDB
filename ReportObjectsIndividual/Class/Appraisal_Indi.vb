Imports Utilities
Imports MPS4

Public Class Appraisal_Indi
    Public MainReport As New rptAppraisalReport_Indi

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        Dim dt As DataTable
        Dim cSQL As String
        'Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, , , ))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim AgentCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Agent", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        cSQL = "SELECT * FROM Rpt_AppraisalIndi "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        'If period.Length > 0 Then
        '    cSQL = cSQL & " and Period = '" & period & "' "
        'End If

        'If AgentCode.Length > 0 Then
        '    cSQL = cSQL & " and FKeyAgent = '" & AgentCode & "' "
        'End If

        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
        End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        With MainReport
            BindData(.lblAppraisalDate, "Text", Nothing, "AppraisalDate")

            'BindData( .GetActivityDetails(.FKeyActivityID)
            BindData(.lblVessel, "Text", Nothing, "VslName")
            BindData(.lblRank, "Text", Nothing, "RankName")
            BindData(.lblFullName, "Text", Nothing, "Crew")
            BindData(.lblDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
            BindData(.lblNationality, "Text", Nothing, "NatName")

            BindData(.lblService, "Text", Nothing, "Service")

            'BindData( .SetOccasionForReport(.OccasionForReport)
            BindData(.txtOccasionReport, "Text", Nothing, "OccasionForReport")

            'BindData( .LoadAppraisalDetails(.AppraisalFactorsGrades)
            BindData(.lblAbility, "Text", Nothing, "Ability_comment")
            BindData(.lblAbilityScore, "Text", Nothing, "Ability_grade")
            BindData(.lblDiligence, "Text", Nothing, "Diligence_comment")
            BindData(.lblDiligenceGrade, "Text", Nothing, "Diligence_grade")
            BindData(.lblSafetyAwareness, "Text", Nothing, "Safety_Awareness_comment")
            BindData(.lblSafetyAwarenessGrade, "Text", Nothing, "Safety_Awareness_grade")
            BindData(.lblResponsibility, "Text", Nothing, "Responsibility_comment")
            BindData(.lblResponsibilityGrade, "Text", Nothing, "Responsibility_grade")
            BindData(.lblMotivation, "Text", Nothing, "Motivation_comment")
            BindData(.lblMotivationGrade, "Text", Nothing, "Motivation_grade")
            BindData(.lblConductAndAppearance, "Text", Nothing, "Conduct_and_Appearance_comment")
            BindData(.lblConductAppearanceGrade, "Text", Nothing, "Conduct_and_Appearance_grade")
            BindData(.lblCooperation, "Text", Nothing, "Cooperation_comment")
            BindData(.lblCooperationGrade, "Text", Nothing, "Cooperation_grade")
            BindData(.lblLeadership, "Text", Nothing, "Leadership_comment")
            BindData(.lblLeadershipGrade, "Text", Nothing, "Leadership_grade")
            BindData(.lblSobriety, "Text", Nothing, "Sobriety_comment")
            BindData(.lblSobrietyGrade, "Text", Nothing, "Sobriety_grade")

            BindData(.lblOverallAssessment, "Text", Nothing, "OverallAssessment")
            BindData(.lblOverallAssessmentGrade, "Text", Nothing, "OverallScore")

            'BindData(.chkReemployedYes, "Text", Nothing, "00000")
            'BindData(.chkReemployedNo, "Text", Nothing, "00000")
            BindData(.txtReemployed, "Text", Nothing, "Reemployed")

            'BindData(.chkPromotionYes, "Text", Nothing, "00000")
            'BindData(.chkPromotionNo, "Text", Nothing, "00000")
            BindData(.txtPromotion, "Text", Nothing, "Promotion")

            'BindData(.chkSailAgainYes, "Text", Nothing, "00000")
            'BindData(.chkSailAgainNo, "Text", Nothing, "00000")
            BindData(.txtSailAgain, "Text", Nothing, "SailAgain")

            BindData(.lblRemarks, "Text", Nothing, "Remarks")
            BindData(.lblMaster, "Text", Nothing, "MasterName")
            BindData(.lblChiefOfficer, "Text", Nothing, "ChiefOfficerName")
            BindData(.lblStrenght, "Text", Nothing, "Strength")
            BindData(.lblWeakness, "Text", Nothing, "Weakneses")
            BindData(.lblOfficerComment, "Text", Nothing, "OfficerComment")
            BindData(.lblOfficerName, "Text", Nothing, "OfficerName")
            BindData(.lblCommentDate, "Text", Nothing, "CommentDate", "{0:dd-MMM-yyyy}") ' IIf(.CommentDate.Equals(""), "", Convert.ToDateTime(.CommentDate).ToString("dd-MMM-yyyy"))
            BindData(.lblCommentFromOffice1, "Text", Nothing, "CommentFromOffice1")
            BindData(.lblCommentFromOffice2, "Text", Nothing, "CommentFromOffice2")
            BindData(.lblShipFleetManager, "Text", Nothing, "ShipFleetManager")
            BindData(.lblSafetyOperationsManager, "Text", Nothing, "SafetyOperationsManager")

            'BindData(.chkReemploymentYes.Checked, "Text", Nothing, "Reemploy") ' Not .Reemploy
            'BindData(.chkReemploymentNo.Checked, "Text", Nothing, "Reemploy")
            BindData(.txtReemployment, "Text", Nothing, "Reemploy")

            'BindData(.chkPromoteYes.Checked, "Text", Nothing, "Promote") ' Not .Promote
            'BindData(.chkPromoteNo.Checked, "Text", Nothing, "Promote")
            BindData(.txtPromote, "Text", Nothing, "Promote")

            BindData(.lblAdditionalRemarks, "Text", Nothing, "AdditionalRemarks")
            BindData(.lblTrainingRequirements, "Text", Nothing, "TrainingRequirements")

            'BindData(MainReport.txtSalutation, "Text", Nothing, "Salutation")
        End With

        REPORT_DETAIL.MainReport = MainReport
    End Sub
End Class
