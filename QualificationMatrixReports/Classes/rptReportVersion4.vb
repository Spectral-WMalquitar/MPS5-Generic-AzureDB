
Public Class RptReportVersion4

    Private ReadOnly _report As New ReportVersion4

    Public Sub New(ByVal db As SQLDB, ByVal sourceQuery As String)
        Try
            Dim dt As DataTable
            Dim sql As String = sourceQuery

            OpenWaitForm()

            With _report
                dt = db.CreateTable(sql)

                If (dt.Rows.Count <= 0) Or (dt Is Nothing) Then
                    CloseWaitForm()
                    MessageBox.Show(String.Format("There is no record found!"), String.Format("Qualifcation Matrix"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                .DataSource = dt
                BindData(.lblCrewName, "Text", Nothing, "CrewName")
                BindData(.lblVesselName, "Text", Nothing, "VslName")
                BindData(.lblVesselType, "Text", Nothing, "VslType")
                BindData(.lblFlag, "Text", Nothing, "FlagName")
                BindData(.lblRank, "Text", Nothing, "RankAbbr")
                BindData(.lblNationality, "Text", Nothing, "Nationality")
                BindData(.lblCOC, "Text", Nothing, "Details")
                BindData(.lblIssuingCountry, "Text", Nothing, "IssuingCountry")
                BindData(.lblEnglishProficiency, "Text", Nothing, "EnglishProficiency")
                BindData(.lblTankerCertification, "Text", Nothing, "TankerCert")
                BindData(.lblRadioQualification, "Text", Nothing, "RadioQualification")
                BindData(.lblSTCWV, "Text", Nothing, "CertRegulation")
                BindData(.lblMonthsOnVesselThisTour, "Text", Nothing, "MonthInVessel")
                BindData(.lblOnboardYrsInRank, "Text", Nothing, "YearsInRank")
                BindData(.lblOnboardYrsInThisTankerType, "Text", Nothing, "YearsInThisTypeOfTanker")
                'The missing data binding is for getting the years on this principal. 
                .lblAdminAcceptance.Text = IIf(dt.Rows(0)("Details").ToString().Equals(""), "NO", "YES")
                _report.lblDate.Text = String.Format("Date: " & Date.Now.ToString("MMM-dd-yyyy"))
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
