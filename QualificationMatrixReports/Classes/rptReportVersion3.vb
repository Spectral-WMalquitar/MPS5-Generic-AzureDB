

Public Class RptReportVersion3

    Private ReadOnly _report As New ReportVersion3
    Public Sub New(ByVal db As SQLDB, ByVal sourceQuery As String)
        Try
            Dim dt As DataTable
            Dim sql As String = sourceQuery

            OpenWaitForm()

            _report.lblVesselNameDate.Text = Qualification.QualificationMatrix.VesselName.ToUpper() + " " + DateTime.Now().ToString("MMMM yy")
            _report.lblFlag.Text = Qualification.QualificationMatrix.VesselFlag.ToUpper()
            _report.lblVesselType.Text = Qualification.QualificationMatrix.VesselType.ToUpper()

            With _report
                dt = db.CreateTable(sql)

                If (dt.Rows.Count <= 0) Or (dt Is Nothing) Then
                    CloseWaitForm()
                    MessageBox.Show(String.Format("There is no record found!"), String.Format("Qualifcation Matrix"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                .DataSource = dt
                BindData(.lblRank, "Text", Nothing, "RankAbbr")
                BindData(.lblNationality, "Text", Nothing, "Nationality")
                BindData(.lblCertificateOfCompetency, "Text", Nothing, "Details")
                BindData(.lblIssuingCountry, "Text", Nothing, "IssuingCountry")
                BindData(.lblAdministrationAcceptance, "Text", Nothing, "AdminAcceptance")
                BindData(.lblDECSatisfactoryProof, "Text", Nothing, "DCESTCW")
                BindData(.lblISPSTrainingCourse, "Text", Nothing, "ISPSTraining")
                BindData(.lblISPSFamiliarizationCourse, "Text", Nothing, "ISPSFamiliarization")
                BindData(.lblSSBTCourse, "Text", Nothing, "SSBT")
                BindData(.lblBRMTraining, "Text", Nothing, "BRM")
                BindData(.lblBTMTrainingCourse, "Text", Nothing, "BTM")
                BindData(.lblEnglishProficiency, "Text", Nothing, "EnglishProficiency")
                BindData(.lblYrsWithOperator, "Text", Nothing, "YearsWithPrincipal")
                BindData(.lblYearsInRank, "Text", Nothing, "YearsInRank")
                BindData(.lblYrsOnTankerType, "Text", Nothing, "YearsInThisTypeOfTanker")
                BindData(.lblYrsOnAllTypeOfTanker, "Text", Nothing, "YearsOnAllTypeOfTanker")

                CloseWaitForm()

                .ShowPreviewDialog()
            End With
        Catch ex As Exception
            CloseWaitForm()
            MessageBox.Show(ex.Message, String.Format(GetAppName() & " Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
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
