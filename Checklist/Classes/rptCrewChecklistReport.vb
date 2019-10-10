
Imports System.Windows.Forms
Imports Utilities
Imports System.Data
Imports Crewing.frmCrewMain

Public Class rptCrewChecklistReport

    Private ReadOnly _mainReport As New CrewChecklistReport
    Public Shared _compSource As DataTable
    Public Shared _vesselSource As DataTable
    Public Sub New(ByVal db As SQLDB, ByVal sourceQuery As String)
        Try
            Dim hasColor As Boolean = includeFormat

            If (_mainReport Is Nothing) Then
                Return
            End If

            _mainReport.lblRank.Text = CrewChecklist.CrewSelected.RankName
            _mainReport.lblSurname.Text = CrewChecklist.CrewSelected.SurName
            _mainReport.lblFirstName.Text = CrewChecklist.CrewSelected.FirstName
            _mainReport.lblMiddleName.Text = CrewChecklist.CrewSelected.MiddleName
            _mainReport.lblCompetence.Text = CrewChecklist.CrewSelected.Competence
            _mainReport.lblCompRank.Text = CrewChecklist.CrewSelected.CompetenceRank

            With _mainReport

                If (_compSource.Rows.Count <= 0) Or (_compSource Is Nothing) Then
                    MessageBox.Show(String.Format("There is no record found!"), String.Format("Check List Report"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                'Travel Documents 
                BindData(.DocNameTravel, "Text", Nothing, "DocName")
                BindData(.NumberTravel, "Text", Nothing, "Number")
                BindData(.DateIssueTravel, "Text", Nothing, "Issue")
                BindData(.DateExpiryTravel, "Text", Nothing, "Expiry")
                BindData(.CountryTravel, "Text", Nothing, "Country")
                BindData(.CapacityTravel, "Text", Nothing, "Capacity")
                BindData(.CompliedTravel, "Text", Nothing, "Complied")
                BindData(.CommentTravel, "Text", Nothing, "Comment")
                BindData(.DocStatusTravel, "Text", Nothing, "DocStatus")
                'Certificates
                BindData(.DocNameCert, "Text", Nothing, "DocName")
                BindData(.NumberCert, "Text", Nothing, "Number")
                BindData(.DateIssueCert, "Text", Nothing, "Issue")
                BindData(.DateExpiryCert, "Text", Nothing, "Expiry")
                BindData(.CountryCert, "Text", Nothing, "Country")
                BindData(.CapacityCert, "Text", Nothing, "Capacity")
                BindData(.CompliedCert, "Text", Nothing, "Complied")
                BindData(.CommentCert, "Text", Nothing, "Comment")
                BindData(.DocStatusCerts, "Text", Nothing, "DocStatus")
                'Courses
                BindData(.DocNameCourse, "Text", Nothing, "DocName")
                BindData(.NumberCourse, "Text", Nothing, "Number")
                BindData(.DateIssueCourse, "Text", Nothing, "Issue")
                BindData(.DateExpiryCourse, "Text", Nothing, "Expiry")
                BindData(.CountryCourse, "Text", Nothing, "Country")
                BindData(.CapacityCourse, "Text", Nothing, "Capacity")
                BindData(.CompliedCourse, "Text", Nothing, "Complied")
                BindData(.CommentCourse, "Text", Nothing, "Comment")
                BindData(.DocStatusCourses, "Text", Nothing, "DocStatus")
                'Medical Documents
                BindData(.DocNameMedical, "Text", Nothing, "DocName")
                BindData(.NumberMedical, "Text", Nothing, "Number")
                BindData(.DateIssueMedical, "Text", Nothing, "Issue")
                BindData(.DateExpiryMedical, "Text", Nothing, "Expiry")
                BindData(.CountryMedical, "Text", Nothing, "Country")
                BindData(.CapacityMedical, "Text", Nothing, "Capacity")
                BindData(.CompliedMedical, "Text", Nothing, "Complied")
                BindData(.CommentMedical, "Text", Nothing, "Comment")
                BindData(.DocStatusMedical, "Text", Nothing, "DocStatus")
                'National Requirements
                BindData(.DocNameNatReq, "Text", Nothing, "DocName")
                BindData(.NumberNatReq, "Text", Nothing, "Number")
                BindData(.DateIssueNatReq, "Text", Nothing, "Issue")
                BindData(.DateExpiryNatReq, "Text", Nothing, "Expiry")
                BindData(.CountryNatReq, "Text", Nothing, "Country")
                BindData(.CapacityNatReq, "Text", Nothing, "Capacity")
                BindData(.CompliedNatReq, "Text", Nothing, "Complied")
                BindData(.CommentNatReq, "Text", Nothing, "Comment")
                BindData(.DocStatusNatReq, "Text", Nothing, "DocStatus")
                'Company Defined
                BindData(.DocNameCompanyDefined, "Text", Nothing, "DocName")
                BindData(.NumberCompanyDefined, "Text", Nothing, "Number")
                BindData(.DateIssueCompanyDefined, "Text", Nothing, "Issue")
                BindData(.DateExpiryCompanyDefined, "Text", Nothing, "Expiry")
                BindData(.CountryCompanyDefined, "Text", Nothing, "Country")
                BindData(.CapacityCompanyDefined, "Text", Nothing, "Capacity")
                BindData(.CompliedCompanyDefined, "Text", Nothing, "Complied")
                BindData(.CommentCompanyDefined, "Text", Nothing, "Comment")
                BindData(.DocStatusCompDef, "Text", Nothing, "DocStatus")
                'Age Requirement
                BindData(.DocNameAgeRequirement, "Text", Nothing, "DocName")
                BindData(.NumberAgeRequirement, "Text", Nothing, "Number")
                BindData(.DateIssueAgeRequirement, "Text", Nothing, "Issue")
                BindData(.DateExpiryAgeRequirement, "Text", Nothing, "Expiry")
                BindData(.CountryAgeRequirement, "Text", Nothing, "Country")
                BindData(.CapacityAgeRequirement, "Text", Nothing, "Capacity")
                BindData(.CompliedAgeRequirement, "Text", Nothing, "Complied")
                BindData(.CommentAgeRequirement, "Text", Nothing, "Comment")

                'Vessel Type
                BindData(.VesselTypeName, "Text", Nothing, "VslType")
                BindData(.RankName, "Text", Nothing, "RankName")
                BindData(.RequiredYrOfService, "Text", Nothing, "YrOfService")
                BindData(.TotalYrOfService, "Text", Nothing, "TotalYrsOfService")
                BindData(.CompliedVslType, "Text", Nothing, "Complied")

                'Generating document details in the sub-portion of the report. 
                LoadDetailCompetence(_mainReport.DetailReport_Travel, "DocType = 'Travel'", _compSource)
                LoadDetailCompetence(_mainReport.DetailReport_Certificates, "DocType = 'Certificates'", _compSource)
                LoadDetailCompetence(_mainReport.DetailReport_Courses, "DocType = 'Courses'", _compSource)
                LoadDetailCompetence(_mainReport.DetailReport_Medical, "DocType = 'Medical'", _compSource)
                LoadDetailCompetence(_mainReport.DetailReport_NationalRequirement, "DocType = 'National Requirement'", _compSource)
                LoadDetailCompetence(_mainReport.DetailReport_CompanyDefined, "DocType = 'Company Defined'", _compSource)
                LoadDetailCompetence(_mainReport.DetailReport_AgeRequirement, "DocType = 'Age Requirement'", _compSource)
                LoadVesselType(_mainReport.DetailReport_VesselType, "", _vesselSource)
                .ShowPreviewDialog()

                _compSource.Clear()
                _vesselSource.Clear()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub LoadDetailCompetence(sender As System.Object, filter As String, ByVal d As DataTable)
        Dim detailReport As DetailReportBand
        Dim dv As DataView = d.DefaultView
        dv.RowFilter = filter
        dv.Sort = "DocName"
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        detailReport.DataSource = dv.ToTable

    End Sub

    Private Sub LoadVesselType(sender As System.Object, filter As String, ByVal d As DataTable)
        Dim detailReport As DetailReportBand
        Dim dv As DataView = d.DefaultView
        dv.RowFilter = filter
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        detailReport.DataSource = dv.ToTable
    End Sub

    Sub New()

    End Sub

    Public Sub BindData(ByVal sender As Object, ByVal nProperty As String, ByVal dbSource As String, ByVal nFieldName As String, Optional ByVal nFormat As String = "")
        Try
            Dim nType As Type = sender.GetType
            Select Case nType.Name
                Case "XRLabel"
                    TryCast(sender, XRLabel).DataBindings.Add(New XRBinding(nProperty, dbSource, nFieldName, nFormat))
                Case "XRTableCell"
                    TryCast(sender, XRTableCell).DataBindings.Add(New XRBinding(nProperty, dbSource, nFieldName, nFormat))
                Case "XRPictureBox"
                    TryCast(sender, XRPictureBox).DataBindings.Add(New XRBinding(nProperty, dbSource, nFieldName, nFormat))
            End Select
        Catch ex As Exception
            Throw (New Exception(ex.Message))
        End Try
    End Sub

End Class
