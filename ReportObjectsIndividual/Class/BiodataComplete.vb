Imports Utilities
Imports MPS4
Imports DevExpress.XtraReports.Parameters

Public Class BiodataComplete

    Private MainReport As New rptBiodataComplete
    Private SubReport_Educ As New rptBiodataSub_Educ
    Private SubReport_Sbk As New rptBiodataSub_Sbk
    Private SubReport_Cert As New rptBiodataSub_Cert
    Private SubReport_SeaServ As New rptBiodataSub_SeaServ
    Private SubReport_CourseCompl As New rptBiodataSub_CourseCompl
    Private SubReport_CourseReq As New rptBiodataSub_CourseReq
    Private SubReport_TravelDoc As New rptBiodataSub_TravelDoc

    Public Enum SeaServiceDisplay
        Continuous = 1
        Grouped = 2
    End Enum

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)
        '---------------------------------------------------------------------------------------------------------------------------------

        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT      crew.IDNbr, " & _
               "            crew.COIDNo, " & _
               "            crew.Crew, " & _
               "            crew.LName, " & _
               "            crew.FName, " & _
               "            crew.MName, " & _
               "            crew.FKeyRank, " & _
               "            crew.Rank, " & _
               "            crew.RankSort, " & _
               "            crew.FKeyNat, " & _
               "            crew.Nationality, " & _
               "            crew.StatCode, " & _
               "            crew.StatName, " & _
               "            crew.SOFFStat, " & _
               "            crew.VslName, " & _
               "            crew.DateSOn, " & _
               "            crew.DateSOff, " & _
               "            crew.DOB, " & _
               "            crew.Age, " & _
               "            crew.POB, " & _
               "            crew.Height, " & _
               "            crew.Weight, " & _
               "            crew.FKeyCivilStat, " & _
               "            cvstat.name as MaritalStatus, " & _
               "            crew.religion, " & _
               "            crew.Phone, " & _
               "            crew.Telefax, " & _
               "            crew.Email, " & _
               "            crew.FKeyPrinCode, " & _
               "            crew.PrinName, " & _
               "            crew.FKeyAgentCode, " & _
               "            crew.FKeyFlt, " & _
               "            crew.AgentName, " & _
               "            crew_pp.number as Passport_Number, " & _
               "            crew_pp.dateissue as Passport_DateIssue, " & _
               "            crew_pp.dateexpiry as Passport_DateExpiry, " & _
               "            crew_pp.issuedplace as Passport_PlaceIssue, " & _
               "            crew_usvisa.number as USVisa_Number, " & _
               "            crew_usvisa.dateissue as USVisa_DateIssue, " & _
               "            crew_usvisa.dateexpiry as USVisa_DateExpiry, " & _
               "            crew_yfever.number as YellowFever_Number, " & _
               "            crew_yfever.dateissue as YellowFever_DateIssue, " & _
               "            crew_yfever.dateexpiry as YellowFever_DateExpiry, " & _
               "            crew_cholera.number as Cholera_Number, " & _
               "            crew_cholera.dateissue as Cholera_DateIssue, " & _
               "            crew_cholera.dateexpiry as Cholera_DateExpiry, " & _
               "            crew_stcw.number as STCW_Number, " & _
               "            crew_stcw.dateissue as STCW_DateIssue, " & _
               "            crew_stcw.dateexpiry as STCW_DateExpiry, " & _
               "            crew_stcw.issuedplace as STCW_PlaceIssue, " & _
               "            crew_sss.number as SSS_Number, " & _
               "            crew_tin.number as TIN_Number, " & _
               "            crew_addr.bldg + CASE WHEN LEN(crew_addr.st) > 0 THEN ' ' END " & _
               "                    + crew_addr.st + CASE WHEN LEN(crew_addr.partofcity) > 0 THEN ' ' END " & _
               "                    + crew_addr.partofcity + CASE WHEN LEN(crew_addr.addrcity) > 0 THEN ' ' END as CityStreet, " & _
               "            crew_addr.AddrCity, " & _
               "            crew_addr.Phone, " & _
               "            crew_addr.Email, " & _
               "            crew_addr.Telefax, " & _
               "            dbo.FN_ToTitleCase(isnull(crew_nok.AllotteeName,'')) NextOfKinName, " & _
               "            crew_nok.RelationshipToAllottee as NextOfKinRel, " & _
               "            crew_nok.addr as NextOfKinAddr, " & _
               "            crew.ShoeSize, crew.CoverallSize, crew.PoloSize, crew.PantsSize " & _
               "FROM        dbo.Rpt_BioInfo" & sArc & "  crew LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewPassport" & sArc & " as crew_pp ON crew.idnbr = crew_pp.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewUSVISA" & sArc & " as crew_usvisa ON crew.idnbr = crew_usvisa.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewYellowFever" & sArc & " as crew_yfever ON crew.idnbr = crew_yfever.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewCholera" & sArc & " as crew_cholera ON crew.idnbr = crew_cholera.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewSTCWEnd" & sArc & " as crew_stcw ON crew.idnbr = crew_stcw.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewSSS" & sArc & " as crew_sss ON crew.idnbr = crew_sss.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewTIN" & sArc & " as crew_tin ON crew.idnbr = crew_tin.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewCurrentAddr" & sArc & " as crew_addr ON crew.idnbr = crew_addr.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewNextOfKin" & sArc & " as crew_nok ON crew.idnbr = crew_nok.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.tbladmcivilstat cvstat ON crew.fkeycivilstat = cvstat.pkey " & IIf(IfNull(sArc, "").Length > 0, "COLLATE DATABASE_DEFAULT ", "") & _
               IIf(MainReportFilter.Length > 0, "WHERE " & MainReportFilter & " ", "")

        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Education Sub 
        cSQL = "SELECT      PKey, FKeyIDNbr AS IDNbr, School, YrStart, YrEnd, YrStart + CASE WHEN len(YrStart) > 0 AND len(YrEnd) > 0 THEN ' to ' END + YrEnd AS YrAttended, Degree " & _
               "FROM        " & sPrefix & "dbo.tblEduc " & _
               "WHERE      FKeyIDNbr IN " & WhereList & " " & _
               "ORDER BY    YrStart, YrEnd "
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Educ.DataSource = dt
        MainReport.subrpt_educ.ReportSource = SubReport_Educ

        'Add a parameter for filtering
        Dim param_educ As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        With SubReport_Educ
            .Parameters.Add(param_educ)
            .FilterString = "[IDNbr]==?IDNbr"

            .GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))
            AddSortFieldToDetailBand(.Detail, "YrStart", FieldSortOrder.Ascending)
            AddSortFieldToDetailBand(.Detail, "YrEnd", FieldSortOrder.Ascending)
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Travel Document Sub 
        cSQL = "SELECT      DocKey, IDNbr, DocName, FKeyDocGroup AS DocGroup, Country, Nbr, DateIssue, DateExpiry, IssuedBy " & _
               "FROM        dbo.Rpt_CrewDocument" & sArc & " " & _
               "WHERE       IDNbr IN " & WhereList & " " & _
               "            AND FKeyDocGroup = dbo.GetRptDataMapCodeValue('DOCGRP_TRAVELDOC') " & _
               "            AND DocKey <> 'SYSTDPP' " & _
               "ORDER BY    DocName"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_TravelDoc.DataSource = dt
        MainReport.subrpt_traveldoc.ReportSource = SubReport_TravelDoc

        'Add a parameter for filtering
        Dim param_traveldoc As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        With SubReport_TravelDoc
            .Parameters.Add(param_traveldoc)
            .FilterString = "[IDNbr]==?IDNbr"

            .txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
            .txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")
            AddSortFieldToDetailBand(.Detail, "DocName", FieldSortOrder.Ascending)
            AddSortFieldToDetailBand(.Detail, "DateIssue", FieldSortOrder.Descending)

        End With
        
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Seaman's Book Sub 
        cSQL = "SELECT      doc.PKey, doc.FKeyIDNbr AS IDNbr, doc.FileTag, doc.FKeyDocument, doc.Number, " & _
               "            doc.DateIssue, doc.DateExpiry, doc.IssuedBy, doc.IssuedPlace, doc.FKeyCntry, " & _
               "            cntry.Name AS Country " & _
               "FROM        " & sPrefix & "dbo.tblDocument doc LEFT OUTER JOIN " & _
               "            dbo.tblAdmCntry cntry ON doc.FKeyCntry = cntry.PKey " & _
               "WHERE       (doc.FKeyDocument = dbo.GetRptDataMapCodeValue('DOC_SEAMANSBOOK')) " & _
               "             AND isActive<>0 AND doc.FKeyIDNbr IN " & WhereList & " " & _
               "ORDER BY    doc.dateissue desc, cntry.name"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Sbk.DataSource = dt
        MainReport.subrpt_sbk.ReportSource = SubReport_Sbk

        'Add a parameter for filtering
        Dim param_sbk As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        With SubReport_Sbk
            .Parameters.Add(param_sbk)
            .FilterString = "[IDNbr]==?IDNbr"

            .txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
            .txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")
            AddSortFieldToDetailBand(.Detail, "DateIssue", FieldSortOrder.Descending)
            AddSortFieldToDetailBand(.Detail, "Country", FieldSortOrder.Ascending)
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Certificate Sub 
        cSQL = "SELECT      DocKey, IDNbr, DocName, FKeyDocGroup AS DocGroup, Country, Nbr, Capacity, DateIssue, DateExpiry " & _
               "FROM        dbo.Rpt_CrewDocument" & sArc & " " & _
               "WHERE       IDNbr IN " & WhereList & " " & _
               "            AND FKeyDocGroup = dbo.GetRptDataMapCodeValue('DOCGRP_LICCERT') " & _
               "ORDER BY    DocName"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Cert.DataSource = dt
        MainReport.subrpt_cert.ReportSource = SubReport_Cert

        'Add a parameter for filtering
        Dim param_cert As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        With SubReport_Cert
            .Parameters.Add(param_cert)
            .FilterString = "[IDNbr]==?IDNbr"

            .txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
            .txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

            .GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))
            AddSortFieldToDetailBand(.Detail, "DocName", FieldSortOrder.Ascending)
            AddSortFieldToDetailBand(.Detail, "DateIssue", FieldSortOrder.Descending)
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Course Completed Sub 
        cSQL = "SELECT      c.*, ctype.name CourseTypeValue " & _
               "FROM        dbo.Rpt_CrewTraining" & sArc & " c LEFT OUTER JOIN " & _
               "            dbo.tbladmcoursetype ctype ON c.coursetypecode = ctype.pkey " & _
               "WHERE       IDNbr IN " & WhereList & " " & _
               "AND         CourseStatus = dbo.getRptDataMapCodeValue('COURSECOMPL') " & _
               "ORDER BY    CourseName"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_CourseCompl.DataSource = dt
        MainReport.subrpt_coursecompl.ReportSource = SubReport_CourseCompl

        'Add a parameter for filtering
        Dim param_coursecompl As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        With SubReport_CourseCompl
            .Parameters.Add(param_coursecompl)
            .FilterString = "[IDNbr]==?IDNbr"

            .txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
            .txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

            .GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))
            AddSortFieldToDetailBand(.Detail, "CourseName", FieldSortOrder.Ascending)
            AddSortFieldToDetailBand(.Detail, "DateIssue", FieldSortOrder.Descending)
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Course Required Sub 
        cSQL = "SELECT      c.*, ctype.name CourseTypeValue " & _
               "FROM        dbo.Rpt_CrewTraining" & sArc & " c LEFT OUTER JOIN " & _
               "            dbo.tbladmcoursetype ctype ON c.coursetypecode = ctype.pkey " & _
               "WHERE       IDNbr IN " & WhereList & " " & _
               "AND         CourseStatus = dbo.getRptDataMapCodeValue('COURSEREQ') " & _
               "ORDER BY    CourseName"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_CourseReq.DataSource = dt
        MainReport.subrpt_coursereq.ReportSource = SubReport_CourseReq

        'Add a parameter for filtering
        Dim param_coursereq As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        With SubReport_CourseReq
            .Parameters.Add(param_coursereq)
            .FilterString = "[IDNbr]==?IDNbr"

            .txtDateIssue.DataBindings.Add("Text", Nothing, "PlannedStart", "{0:dd-MMM-yyyy}")

            .GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))
            AddSortFieldToDetailBand(.Detail, "CourseName", FieldSortOrder.Ascending)
            AddSortFieldToDetailBand(.Detail, "PlannedStart", FieldSortOrder.Descending)

        End With
        
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Sea Service Sub 
        Dim _SeaServiceDisplay As SeaServiceDisplay = SeaServiceDisplay.Grouped

        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Sea Service Display"), "").Equals("Continuous") Then
            _SeaServiceDisplay = SeaServiceDisplay.Continuous
        ElseIf IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Sea Service Display"), "").Equals("Grouped") Then
            _SeaServiceDisplay = SeaServiceDisplay.Grouped
        End If

        If _SeaServiceDisplay = SeaServiceDisplay.Grouped Then
            cSQL = "SELECT     crewserv.*, rnk.abbrv RankAbbrv, (CASE WHEN IsCompServ <> 0 THEN 'Company Sea Service' ELSE 'Other Sea Service' END) AS ServType " & _
                   "FROM       (SELECT * FROM dbo.Rpt_CrewActAll UNION SELECT * FROM dbo.Rpt_CrewActAll_Other) crewServ " & _
                   "           LEFT JOIN dbo.tbladmrank rnk ON crewserv.fkeyrankcode = rnk.pkey " & _
                   "WHERE      (acttype = 'SEA' OR acttype = 'OTH') AND IDNbr IN " & WhereList & " " & _
                   "ORDER BY    DateStart Desc;"
        ElseIf _SeaServiceDisplay = SeaServiceDisplay.Continuous Then
            cSQL = "SELECT     crewserv.*, rnk.abbrv RankAbbrv, 'Sea Service' AS ServType " & _
                   "FROM       (SELECT * FROM dbo.Rpt_CrewActAll UNION SELECT * FROM dbo.Rpt_CrewActAll_Other) crewServ " & _
                   "           LEFT JOIN dbo.tbladmrank rnk ON crewserv.fkeyrankcode = rnk.pkey " & _
                   "WHERE      (acttype = 'SEA' OR acttype = 'OTH') AND IDNbr IN " & WhereList & " " & _
                   "ORDER BY    DateStart Desc;"
        Else
            cSQL = ""
        End If

        dt = MPSDB.CreateTable(cSQL)

        SubReport_SeaServ.DataSource = dt
        MainReport.subrpt_seaserv.ReportSource = SubReport_SeaServ

        'Add a parameter for filtering
        Dim param_ss As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        With SubReport_SeaServ
            .Parameters.Add(param_ss)
            .FilterString = "[IDNbr]==?IDNbr"

            .txtDateStart.DataBindings.Add("Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
            .txtDateEnd.DataBindings.Add("Text", Nothing, "DateEnd", "{0:dd-MMM-yyyy}")

            AddFieldsToGroupHeaderBand(.GroupHeader1, "ServType", FieldSortOrder.Ascending)
            AddSortFieldToDetailBand(.Detail, "DateStart", FieldSortOrder.Descending)

        End With
        '---------------------------------------------------------------------------------------------------------------------------------------

        BindReportControls(MainReport)
        BindReportControls(SubReport_Educ)
        BindReportControls(SubReport_Cert)
        BindReportControls(SubReport_SeaServ)
        BindReportControls(SubReport_Sbk)
        BindReportControls(SubReport_CourseCompl)
        BindReportControls(SubReport_CourseReq)
        BindReportControls(SubReport_TravelDoc)

        With MainReport
            .subHeader.ReportSource = New Reports.rptHeader(MainReport)

            .txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
            .txtDateSOn.DataBindings.Add("Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
            .txtDateSOff.DataBindings.Add("Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
            'Passport
            .Passport_DateIssue.DataBindings.Add("Text", Nothing, "Passport_DateIssue", "{0:dd-MMM-yyyy}")
            .Passport_DateExpiry.DataBindings.Add("Text", Nothing, "Passport_DateExpiry", "{0:dd-MMM-yyyy}")
            'US Visa
            .USVisa_DateIssue.DataBindings.Add("Text", Nothing, "USVisa_DateIssue", "{0:dd-MMM-yyyy}")
            .USVisa_DateExpiry.DataBindings.Add("Text", Nothing, "USVisa_DateExpiry", "{0:dd-MMM-yyyy}")
            'Yellow Fever
            .YellowFever_DateIssue.DataBindings.Add("Text", Nothing, "YellowFever_DateIssue", "{0:dd-MMM-yyyy}")
            .YellowFever_DateExpiry.DataBindings.Add("Text", Nothing, "YellowFever_DateExpiry", "{0:dd-MMM-yyyy}")
            'Cholera
            .Cholera_DateIssue.DataBindings.Add("Text", Nothing, "Cholera_DateIssue", "{0:dd-MMM-yyyy}")
            .Cholera_DateExpiry.DataBindings.Add("Text", Nothing, "Cholera_DateExpiry", "{0:dd-MMM-yyyy}")
            'STCW Endorsement
            .STCW_DateIssue.DataBindings.Add("Text", Nothing, "STCW_DateIssue", "{0:dd-MMM-yyyy}")
            .STCW_DateExpiry.DataBindings.Add("Text", Nothing, "STCW_DateExpiry", "{0:dd-MMM-yyyy}")
        End With


        Dim band As DevExpress.XtraReports.UI.Band = MainReport.Detail

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Handle the Subreport.BeforePrint event for filtering details dynamically
        AddHandler SubReport_Cert.BeforePrint, AddressOf SubReport_Cert_BeforePrint
        AddHandler SubReport_Educ.BeforePrint, AddressOf SubReport_Educ_BeforePrint
        AddHandler SubReport_Sbk.BeforePrint, AddressOf SubReport_Sbk_BeforePrint
        AddHandler SubReport_SeaServ.BeforePrint, AddressOf SubReport_SeaServ_BeforePrint
        AddHandler SubReport_CourseCompl.BeforePrint, AddressOf SubReport_CourseCompl_BeforePrint
        AddHandler SubReport_CourseReq.BeforePrint, AddressOf SubReport_CourseReq_BeforePrint
        AddHandler MainReport.Detail.BeforePrint, AddressOf Detail_BeforePrint
        AddHandler SubReport_TravelDoc.BeforePrint, AddressOf SubReport_TravelDoc_BeforePrint

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub SubReport_Cert_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_Educ_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_TravelDoc_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_Sbk_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_SeaServ_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_CourseCompl_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_CourseReq_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        GetCrewPhoto(MainReport.pbCrewPhoto, MainReport.GetCurrentColumnValue("IDNbr"))
    End Sub

    Private Sub GetCrewPhoto(_PictureEdit As DevExpress.XtraReports.UI.XRPictureBox, _CrewIDNbr As String)
        Try
            'CrewPhoto.Image = New System.Drawing.Bitmap(Trim(IfNull(Items("PhotoPath"), "")))
            Dim _path = GetCrewPhotoPath(_CrewIDNbr)
            _PictureEdit.Image = ImageFromStream(_path)
            MainReport.lblPhoto.Visible = False
        Catch ex As Exception
            _PictureEdit.Image = Nothing
            MainReport.lblPhoto.Visible = True
        End Try
    End Sub

    Private Function GetCrewPhotoPath(_CrewIDNbr As String)
        Dim retval As String = Nothing
        Try
            Dim ImagePath As String = FOLDERDIRECTORY & "\" & _CrewIDNbr & "\" & _CrewIDNbr & "_IMAGE"
            'Dim FileName As String = _CrewIDNbr & "_IMAGE"
            If System.IO.File.Exists(ImagePath & ".jpg") Then
                ImagePath = ImagePath & ".jpg"
            ElseIf System.IO.File.Exists(ImagePath & ".png") Then
                ImagePath = ImagePath & ".png"
            Else
                ImagePath = Nothing
            End If
            retval = ImagePath
        Catch ex As Exception
            retval = Nothing
        End Try
        Return retval
    End Function

End Class
