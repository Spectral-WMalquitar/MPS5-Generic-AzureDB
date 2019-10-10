Public Class rptQualificationExperienceMatrixReport

    Private ReadOnly _report As New QualificationExperienceMatrixReport

    Public Sub New(ByVal db As SQLDB, ByVal sourceQuery As String)
        Try
            Dim dt As DataTable
            Dim sql As String = sourceQuery

            If (_report Is Nothing) Then
                Return
            End If

            With _report
                dt = db.CreateTable(sql)
                If (dt.Rows.Count <= 0) Or (dt Is Nothing) Then
                    MessageBox.Show(String.Format("There is no record found!"), String.Format("Qualifcation Matrix"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                .lblVesselName.Text = Qualification.QualificationMatrix.VesselName.ToUpper()
                .lblDate.Text = FormatDateWithSuffix()
                .DataSource = dt

                .pbLogoPhoto.Image = MPS4.MPS4BasicFunctions.GetLogo

                BindData(.lblQualificationOfficers, "Text", Nothing, "QualificationOfficers")
                BindData(.lblNationality, "Text", Nothing, "Nationality")
                BindData(.lblNationalCOC, "Text", Nothing, "NCOC")
                BindData(.lblIssuingCountry, "Text", Nothing, "IssuingCountry")
                BindData(.lblAdministrationAcceptance, "Text", Nothing, "AdministrationAcceptance")
                BindData(.lblDangerousCargoEndorsement, "Text", Nothing, "DangerousCargoEndorsement")
                BindData(.lblRadioQualification, "Text", Nothing, "RadioQualification")
                BindData(.lblSTCWEndorsement, "Text", Nothing, "STCW")
                BindData(.lblYearsWithPrincipal, "Text", Nothing, "YearsWithPrincipal")
                BindData(.lblYearsInRank, "Text", Nothing, "YearsInRank")
                BindData(.lblYearsOnThisTypeOfTanker, "Text", Nothing, "YearsOnThisTypeOfTanker")
                BindData(.lblYearsOnAllTypeOfTanker, "Text", Nothing, "YearsOnAllTypeOfTanker")
                BindData(.lblEnglishProficiency, "Text", Nothing, "EnglishProficiency")
                BindData(.lblMonthsOnTheVesselThisTourOfDuty, "Text", Nothing, "MonthInVessel")

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

    Protected Function FormatDateWithSuffix(Optional ByVal format As String = "d{0} MMM yyyy") As String

        Dim currDate As DateTime = DateTime.Now
        Dim formatTime As String = currDate.ToString(format)
        Dim day As Integer = currDate.Day
        Dim dayFormat As String = String.Empty

        Select Case day
            Case 1, 21, 31
                dayFormat = "st"
            Case 2, 22
                dayFormat = "nd"
            Case 3, 23
                dayFormat = "rd"
            Case Else
                dayFormat = "th"
        End Select

        Return String.Format(formatTime, dayFormat)

    End Function


End Class
