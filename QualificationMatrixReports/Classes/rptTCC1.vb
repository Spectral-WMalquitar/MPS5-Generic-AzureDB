

Public Class rpttcc1

    Private ReadOnly _mainReport As New TCC1

    Public Sub New(ByVal db As SQLDB, ByVal sourceQuery As String)
        Try
            Dim dt As DataTable
            Dim sql As String = sourceQuery

            OpenWaitForm()

            If (_mainReport Is Nothing) Then
                CloseWaitForm()
                Return
            End If

            _mainReport.lblVesselName.Text = Qualification.QualificationMatrix.VesselName.ToUpper()
            _mainReport.lblVesselFlag.Text = Qualification.QualificationMatrix.VesselFlag.ToUpper()
            _mainReport.lblVesselType.Text = Qualification.QualificationMatrix.VesselType.ToUpper()

            With _mainReport
                If (sql.Trim().Equals("")) Then
                    CloseWaitForm()
                    Return
                End If

                dt = db.CreateTable(sql)

                If (dt.Rows.Count <= 0) Or (dt Is Nothing) Then
                    CloseWaitForm()
                    MessageBox.Show(String.Format("There is no record found!"), String.Format("Qualifcation Matrix"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                .DataSource = dt
                BindData(.celOfficer, "Text", Nothing, "Officer")
                BindData(.celQualification, "Text", Nothing, "Qualification")
                BindData(.celNationality, "Text", Nothing, "Nationality")
                BindData(.celCOC, "Text", Nothing, "COC")
                BindData(.celIssuingCountry, "Text", Nothing, "IssuingCountry")
                BindData(.celAdminAcceptance, "Text", Nothing, "AdminAcceptance")
                BindData(.celTankerCertification, "Text", Nothing, "TankerCertification")
                BindData(.celSpecialTT, "Text", Nothing, "SpecialTT")
                BindData(.celRadioQualification, "Text", Nothing, "RadioQualification")
                BindData(.celYearsWithCompany, "Text", Nothing, "YearsWithCompany")
                BindData(.celYearsInRank, "Text", Nothing, "YearsInRank")
                BindData(.celYearsOnThisTypeOfTanker, "Text", Nothing, "YearsOnThisTypeOfTanker")
                BindData(.celYearsOnAllTypeOfTanker, "Text", Nothing, "YearsOnAllTypeOfTanker")
                BindData(.celYearsInRankOfficer, "Text", Nothing, "YearsInRankOfficer")
                BindData(.celEnglishProficiency, "Text", Nothing, "EnglishProficiency")
                BindData(.celMonthInVessel, "Text", Nothing, "MonthInVessel")
                BindData(.celYearsInRankOfficerJunior, "Text", Nothing, "YearsInRankOfficerJunior")

                CloseWaitForm()
                .ShowPreviewDialog()
            End With
        Catch ex As Exception
            CloseWaitForm()
            MessageBox.Show(ex.Message, String.Format(GetAppName() & " Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
