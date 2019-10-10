Imports System.Windows.Forms
Imports Utilities
Imports System.Data

Public Class RptReportVersion1

    Private ReadOnly _mainReport As New ReportVersion1

    Public Sub New(ByVal db As SQLDB, ByVal sourceQuery As String)
        Try
            Dim dt As DataTable
            Dim sql As String = sourceQuery

            If (_mainReport Is Nothing) Then
                Return
            End If

            _mainReport.lblVesselName.Text = Qualification.QualificationMatrix.VesselName.ToUpper()
            _mainReport.lblVesselFlag.Text = Qualification.QualificationMatrix.VesselFlag.ToUpper()
            _mainReport.lblVesselType.Text = Qualification.QualificationMatrix.VesselType.ToUpper()

            With _mainReport
                If (sql.Trim().Equals("")) Then Return
                dt = db.CreateTable(sql)

                If (dt.Rows.Count <= 0) Or (dt Is Nothing) Then
                    MessageBox.Show(String.Format("There is no record found!"), String.Format("Qualifcation Matrix"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                .DataSource = dt
                BindData(.lblOfficer, "Text", Nothing, "Officer")
                BindData(.lblQualification, "Text", Nothing, "Qualification")
                BindData(.lblNationality, "Text", Nothing, "Nationality")
                BindData(.lblNationalCOC, "Text", Nothing, "NCOC")
                BindData(.lblSTCWRegulationHeld, "Text", Nothing, "STCW")
                BindData(.lblIssuingCountry, "Text", Nothing, "IssuingCountry")
                BindData(.lblFlagCertOfCompetency, "Text", Nothing, "FlagCertOfCompetency")
                BindData(.lblFlagEndorsement, "Text", Nothing, "FlagEndorsement")
                BindData(.lblYearsWithCompany, "Text", Nothing, "YearsWithCompany")
                BindData(.lblYearsInRank, "Text", Nothing, "YearsInRank")
                BindData(.lblYearsOnThisTypeOfTanker, "Text", Nothing, "YearsOnThisTypeOfTanker")
                BindData(.lblYearsOnAllTypeOfTanker, "Text", Nothing, "YearsOnAllTypeOfTanker")
                BindData(.lblEmployingCompanyAgency, "Text", Nothing, "EmployingCompanyAgency")
                BindData(.lblEnglishProficiency, "Text", Nothing, "EnglishProficiency")
                BindData(.lblMonthsOnTheVesselThisVoyage, "Text", Nothing, "MonthInVessel")
                .ShowPreviewDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, String.Format("MPS 4 Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub New()

    End Sub

    Public Sub BindData(ByVal sender As Object, ByVal nProperty As String, ByVal dbSource As String, ByVal nFieldName As String, Optional ByVal nFormat As String = "")
        Try
            Dim nType As Type = sender.GetType
            Select Case nType.Name
                Case "XRLabel"
                    TryCast(sender, DevExpress.XtraReports.UI.XRLabel).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, dbSource, nFieldName, nFormat))
                Case "XRTableCell"
                    TryCast(sender, DevExpress.XtraReports.UI.XRTableCell).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, dbSource, nFieldName, nFormat))
                Case "XRPictureBox"
                    TryCast(sender, DevExpress.XtraReports.UI.XRPictureBox).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, dbSource, nFieldName, nFormat))
            End Select
        Catch ex As Exception
            Throw (New Exception(ex.Message))
        End Try
    End Sub

End Class
