Imports System.Drawing
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters

Public Class LackCompetenceCrewReport

    Private mainDT As DataTable
    Private vesselDT As DataTable
    Private ReadOnly TravelDoc_SubReport As New TravelDoc_Sub
    Private ReadOnly Certificates_SubReport As New Certificates_Sub
    Private ReadOnly Courses_SubReport As New Courses_Sub
    Private ReadOnly Medical_SubReport As New Medical_Sub
    Private ReadOnly NatReq_SubReport As New NationalInformation_Sub
    Private ReadOnly CompanyDefined_SubReport As New CompanyDefined_Sub
    Private ReadOnly VesselType_Subreport As New VesselType_Sub

    Public Sub New(crewDT As DataTable, mainDT As DataTable, vesselDT As DataTable)

        InitializeComponent()

        DataSource = crewDT
        Me.mainDT = mainDT
        Me.vesselDT = vesselDT

        PrepareData(mainDT, vesselDT)

        ShowPreviewDialog()
    End Sub

    Public Sub PrepareData(_compSource As DataTable, _vesselSource As DataTable)

        BindData(CrewName, "Text", Nothing, "CrewName")
        BindData(Rank, "Text", Nothing, "Rank")

        Dim param_sub As New Parameter() With {.Name = "CrewIDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        Try

            With TravelDoc_SubReport
                Me.Sub_Travel.ReportSource = TravelDoc_SubReport
                AddHandler .BeforePrint, AddressOf SubReport_Filter_BeforePrint

                Dim dt As DataTable = LoadDetailCompetence(.Detail, "DocType = 'Travel'", _compSource)
                If dt.Rows.Count > 0 Then
                    .DataSource = dt
                    .GroupHeader_IDNbr.GroupFields.Add(New GroupField("CrewIDNbr"))
                    .Parameters.Add(param_sub)
                    .FilterString = "[CrewIDNbr]==?CrewIDNbr"

                    'Travel Documents 
                    BindData(.DocNameTravel, "Text", Nothing, "DocName")
                    BindData(.NumberTravel, "Text", Nothing, "Number")
                    BindData(.DateIssueTravel, "Text", Nothing, "Issue")
                    BindData(.DateExpiryTravel, "Text", Nothing, "Expiry")
                    BindData(.CountryTravel, "Text", Nothing, "Country")
                    BindData(.CapacityTravel, "Text", Nothing, "Capacity")
                    BindData(.CompliedTravel, "Text", Nothing, "Complied")
                    BindData(.CommentTravel, "Text", Nothing, "Comment")
                Else
                    Me.Sub_Travel.Visible = False
                End If


            End With

            With Certificates_SubReport
                Me.Sub_Certificates.ReportSource = Certificates_SubReport
                AddHandler .BeforePrint, AddressOf SubReport_Filter_BeforePrint

                Dim dt As DataTable = LoadDetailCompetence(.Detail, "DocType='Certificates'", _compSource)
                If dt.Rows.Count > 0 Then
                    .DataSource = dt
                    .GroupHeader_IDNbr.GroupFields.Add(New GroupField("CrewIDNbr"))
                    .Parameters.Add(param_sub)
                    .FilterString = "[CrewIDNbr]==?CrewIDNbr"
                    'Certificates
                    BindData(.DocNameCert, "Text", Nothing, "DocName")
                    BindData(.NumberCert, "Text", Nothing, "Number")
                    BindData(.DateIssueCert, "Text", Nothing, "Issue")
                    BindData(.DateExpiryCert, "Text", Nothing, "Expiry")
                    BindData(.CountryCert, "Text", Nothing, "Country")
                    BindData(.CapacityCert, "Text", Nothing, "Capacity")
                    BindData(.CompliedCert, "Text", Nothing, "Complied")
                    BindData(.CommentCert, "Text", Nothing, "Comment")
                Else
                    Me.Sub_Certificates.Visible = False
                End If


            End With

            With Courses_SubReport
                Me.Sub_Courses.ReportSource = Courses_SubReport
                AddHandler .BeforePrint, AddressOf SubReport_Filter_BeforePrint
                Dim dt As DataTable = LoadDetailCompetence(.Detail, "DocType='Courses'", _compSource)
                If dt.Rows.Count > 0 Then
                    .DataSource = dt
                    .GroupHeader_IDNbr.GroupFields.Add(New GroupField("CrewIDNbr"))
                    .Parameters.Add(param_sub)
                    .FilterString = "[CrewIDNbr]==?CrewIDNbr"

                    'Courses
                    BindData(.DocNameCourse, "Text", Nothing, "DocName")
                    BindData(.NumberCourse, "Text", Nothing, "Number")
                    BindData(.DateIssueCourse, "Text", Nothing, "Issue")
                    BindData(.DateExpiryCourse, "Text", Nothing, "Expiry")
                    BindData(.CountryCourse, "Text", Nothing, "Country")
                    BindData(.CapacityCourse, "Text", Nothing, "Capacity")
                    BindData(.CompliedCourse, "Text", Nothing, "Complied")
                    BindData(.CommentCourse, "Text", Nothing, "Comment")
                Else
                    Me.Sub_Courses.Visible = False
                End If

            End With

            With Medical_SubReport
                Me.Sub_Medical.ReportSource = Medical_SubReport
                AddHandler .BeforePrint, AddressOf SubReport_Filter_BeforePrint

                Dim dt As DataTable = LoadDetailCompetence(.Detail, "DocType='Medical'", _compSource)
                If dt.Rows.Count > 0 Then
                    .DataSource = dt
                    .GroupHeader_IDNbr.GroupFields.Add(New GroupField("CrewIDNbr"))
                    .Parameters.Add(param_sub)
                    .FilterString = "[CrewIDNbr]==?CrewIDNbr"

                    'Medical Documents
                    BindData(.DocNameMedical, "Text", Nothing, "DocName")
                    BindData(.NumberMedical, "Text", Nothing, "Number")
                    BindData(.DateIssueMedical, "Text", Nothing, "Issue")
                    BindData(.DateExpiryMedical, "Text", Nothing, "Expiry")
                    BindData(.CountryMedical, "Text", Nothing, "Country")
                    BindData(.CapacityMedical, "Text", Nothing, "Capacity")
                    BindData(.CompliedMedical, "Text", Nothing, "Complied")
                    BindData(.CommentMedical, "Text", Nothing, "Comment")
                Else
                    Me.Sub_Medical.Visible = False
                End If

            End With

            With NatReq_SubReport
                Me.Sub_NationalInformation.ReportSource = NatReq_SubReport
                AddHandler .BeforePrint, AddressOf SubReport_Filter_BeforePrint

                Dim dt As DataTable = LoadDetailCompetence(.Detail, "DocType='National Requirement'", _compSource)
                If dt.Rows.Count > 0 Then
                    .DataSource = dt
                    .GroupHeader_IDNbr.GroupFields.Add(New GroupField("CrewIDNbr"))
                    .Parameters.Add(param_sub)
                    .FilterString = "[CrewIDNbr]==?CrewIDNbr"

                    'National Requirements
                    BindData(.DocNameNatReq, "Text", Nothing, "DocName")
                    BindData(.NumberNatReq, "Text", Nothing, "Number")
                    BindData(.DateIssueNatReq, "Text", Nothing, "Issue")
                    BindData(.DateExpiryNatReq, "Text", Nothing, "Expiry")
                    BindData(.CountryNatReq, "Text", Nothing, "Country")
                    BindData(.CapacityNatReq, "Text", Nothing, "Capacity")
                    BindData(.CompliedNatReq, "Text", Nothing, "Complied")
                    BindData(.CommentNatReq, "Text", Nothing, "Comment")
                Else
                    Me.Sub_NationalInformation.Visible = False
                End If

            End With

            With CompanyDefined_SubReport
                Me.Sub_CompanyDefined.ReportSource = CompanyDefined_SubReport
                AddHandler .BeforePrint, AddressOf SubReport_Filter_BeforePrint

                Dim dt As DataTable = LoadDetailCompetence(.Detail, "DocType='Company Defined'", _compSource)
                If dt.Rows.Count > 0 Then
                    .DataSource = dt
                    .GroupHeader_IDNbr.GroupFields.Add(New GroupField("CrewIDNbr"))
                    .Parameters.Add(param_sub)
                    .FilterString = "[CrewIDNbr]==?CrewIDNbr"

                    'Company Defined
                    BindData(.DocNameCompanyDefined, "Text", Nothing, "DocName")
                    BindData(.NumberCompanyDefined, "Text", Nothing, "Number")
                    BindData(.DateIssueCompanyDefined, "Text", Nothing, "Issue")
                    BindData(.DateExpiryCompanyDefined, "Text", Nothing, "Expiry")
                    BindData(.CountryCompanyDefined, "Text", Nothing, "Country")
                    BindData(.CapacityCompanyDefined, "Text", Nothing, "Capacity")
                    BindData(.CompliedCompanyDefined, "Text", Nothing, "Complied")
                    BindData(.CommentCompanyDefined, "Text", Nothing, "Comment")
                Else
                    Me.Sub_CompanyDefined.Visible = False
                End If

            End With

            With VesselType_Subreport
                Me.Sub_VesselType.ReportSource = VesselType_Subreport
                AddHandler .BeforePrint, AddressOf SubReport_Filter_BeforePrint
                If _vesselSource.Rows.Count > 0 Then
                    .DataSource = _vesselSource
                    .GroupHeader_IDNbr.GroupFields.Add(New GroupField("CrewIDNbr"))
                    .Parameters.Add(param_sub)
                    .FilterString = "[CrewIDNbr]==?CrewIDNbr"

                    'Vessel Type
                    BindData(.VesselTypeName, "Text", Nothing, "VslType")
                    BindData(.RankName, "Text", Nothing, "RankName")
                    BindData(.RequiredYrOfService, "Text", Nothing, "YrOfService")
                    BindData(.TotalYrOfService, "Text", Nothing, "TotalYrsOfService")
                    BindData(.CompliedVslType, "Text", Nothing, "Complied")
                Else
                    Me.Sub_VesselType.Visible = False
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub SubReport_Filter_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(Me, TryCast(sender, XtraReport), "CrewIDNbr", "CrewIDNbr")
    End Sub

    Public Sub AssignReportParameter(MainRpt As XtraReport, RptSub As XtraReport, MainRpt_FieldName As String, SubRpt_FieldName As String)
        '####################################################################################################################################################################################################################################
        ''### Description: This procedure is used for sub reports where a field value from the mainreport is assigned to the sub report paramter
        Try
            Dim Value As String = MainRpt.GetCurrentColumnValue(MainRpt_FieldName).ToString()
            RptSub.Parameters(SubRpt_FieldName).Value = Value
        Catch ex As Exception

        End Try
    End Sub

    Public Sub BindReportControls(ByRef rep As XtraReport)
        '####################################################################################################################################################################################################################################
        '### Description: THE BELOW OPTION BINDS THE DATA BY LOOPING TO ALL CONTROLS IN THE REPORT
        '                 THE CONTROL TO BIND MUST HAVE A TAG VALUE THAT HAS THE FF FORMAT:
        '                 sample format: "BIND_" + <field name>
        '                 sample:        "BIND_LName"
        '                                "BIND_CrewName"
        '                 IF THE CONTROL IS XRTABLE, ASSIGN "BIND" TO TAG PROPERTY
        Dim type As Type

        For Each band As DevExpress.XtraReports.UI.Band In rep.Bands

            For Each control As DevExpress.XtraReports.UI.XRControl In band

                If control.Tag.ToString.Length > 0 Then

                    If control.Tag.ToString = "BIND" Then

                        type = control.GetType()

                        Select Case type.Name
                            Case "XRTable"  'if control is an XRTable
                                Dim table As DevExpress.XtraReports.UI.XRTable = TryCast(control, DevExpress.XtraReports.UI.XRTable)

                                For Each row As DevExpress.XtraReports.UI.XRTableRow In table

                                    For Each cell As DevExpress.XtraReports.UI.XRTableCell In row

                                        If cell.Tag.ToString.Length > 0 Then
                                            If cell.Tag.ToString.Substring(0, 5) = "BIND_" Then
                                                BindData(rep.FindControl(cell.Name, True), "Text", Nothing, cell.Tag.ToString.Substring(5))
                                            End If
                                        End If
                                    Next
                                Next
                        End Select

                    Else 'if .Tag is not "BIND"
                        If control.Tag.ToString.Substring(0, 5) = "BIND_" Then
                            Try
                                BindData(rep.FindControl(control.Name, True), "Text", Nothing, control.Tag.ToString.Substring(5))
                            Catch ex As Exception
                                Try
                                    rep.FindControl(control.Name, True).Text = "BIND FAILED"
                                Catch ex2 As Exception
                                    'do nothing
                                End Try
                            End Try
                        End If
                    End If
                End If
            Next
        Next

    End Sub

    Private Function LoadDetailCompetence(sender As System.Object, filter As String, ByVal d As DataTable) As DataTable
        If IsNothing(d) Then Return Nothing
        Dim dv As DataView = d.DefaultView
        dv.RowFilter = filter
        dv.Sort = "DocName"
        Return dv.ToTable
    End Function

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