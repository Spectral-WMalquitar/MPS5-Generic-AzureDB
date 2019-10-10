Imports Utilities
Imports Reports.BaseReportBuilder
Imports MPS4
Imports DevExpress.XtraReports.Parameters

Public Class BiodataSheet

    Private MainReport As New rptBiodataSheet
    Private SubReport_Educ As New rptBiodataSheetsub_Educ
    Private SubReport_Sbk As New rptBiodataSheetsub_Sbk
    Private SubReport_Cert As New rptBiodataSheetsub_Cert
    Private SubReport_SeaServ As New rptBiodataSheetsub_SeaServ
    Private SubReport_CourseCompl As New rptBiodataSheetsub_CourseCompl
    Private SubReport_CourseReq As New rptBiodataSheetsub_CourseReq

    Public Sub New(ByVal db As SQLDB, ByVal ReportName As String, ByVal argsFilter As Object())
        Dim cSQL As String

        Dim MainReportFilter As String = argsFilter(0)
        Dim WhereList As String = argsFilter(1)
        Dim Sorting As String = argsFilter(2)
        Dim FilterDT As DataTable = argsFilter(3)
        Dim SortDT As DataTable = argsFilter(4)

        MainReport.Name = ReportName
        SetDefaultReportLabels(MainReport, db)

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
               "            crew.MaritalStatus, " & _
               "            crew.FKeyPrinCode, " & _
               "            crew.PrinName, " & _
               "            crew.FKeyAgentCode, " & _
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
               "            crew_nok.AllotteeName NextOfKinName, " & _
               "            crew_nok.RelationshipToAllottee as NextOfKinRel, " & _
               "            crew_nok.addr as NextOfKinAddr " & _
               "FROM        dbo.Rpt_BioInfo crew LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewPassport as crew_pp ON crew.idnbr = crew_pp.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewUSVISA as crew_usvisa ON crew.idnbr = crew_usvisa.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewYellowFever as crew_yfever ON crew.idnbr = crew_yfever.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewCholera as crew_cholera ON crew.idnbr = crew_cholera.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewSTCWEnd as crew_stcw ON crew.idnbr = crew_stcw.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewSSS as crew_sss ON crew.idnbr = crew_sss.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewTIN as crew_tin ON crew.idnbr = crew_tin.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewCurrentAddr as crew_addr ON crew.idnbr = crew_addr.fkeyidnbr LEFT OUTER JOIN " & _
               "            dbo.Rpt_CrewNextOfKin as crew_nok ON crew.idnbr = crew_nok.fkeyidnbr " & _
               IIf(MainReportFilter.Length > 0, "WHERE " & MainReportFilter & " ", "")

        '"            (" & GetCommonRptSQLStatement("TOPPASSPORT_PERCREW") & ") as crew_pp ON crew.idnbr = crew_pp.fkeyidnbr LEFT OUTER JOIN " & _
        '"            (" & GetCommonRptSQLStatement("TOPUSVISA_PERCREW") & ") as crew_usvisa ON crew.idnbr = crew_usvisa.fkeyidnbr LEFT OUTER JOIN " & _
        '"            (" & GetCommonRptSQLStatement("TOPYELLOWFEVER_PERCREW") & ") as crew_yfever ON crew.idnbr = crew_yfever.fkeyidnbr LEFT OUTER JOIN " & _
        '"            (" & GetCommonRptSQLStatement("TOPCHOLERA_PERCREW") & ") as crew_cholera ON crew.idnbr = crew_cholera.fkeyidnbr LEFT OUTER JOIN " & _
        '"            (" & GetCommonRptSQLStatement("TOPSTCWEND_PERCREW") & ") as crew_stcw ON crew.idnbr = crew_stcw.fkeyidnbr LEFT OUTER JOIN " & _
        '"            (" & GetCommonRptSQLStatement("TOPSSS_PERCREW") & ") as crew_sss ON crew.idnbr = crew_sss.fkeyidnbr LEFT OUTER JOIN " & _
        '"            (" & GetCommonRptSQLStatement("TOPTIN_PERCREW") & ") as crew_tin ON crew.idnbr = crew_tin.fkeyidnbr LEFT OUTER JOIN " & _
        '"            (" & GetCommonRptSQLStatement("TOPCURRENTADDR_PERCREW") & ") as crew_addr ON crew.idnbr = crew_addr.fkeyidnbr LEFT OUTER JOIN " & _
        '"            (" & GetCommonRptSQLStatement("NEXTOFKIN_PERCREW") & ") as crew_nok ON crew.idnbr = crew_nok.fkeyidnbr " & _
        'IIf(MainReportFilter.Length > 0, "WHERE " & MainReportFilter & " ", "")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Note: Sorting should be applied from the report bands, not on source
        'If Sorting.Length > 0 Then
        'cSQL = cSQL & "ORDER BY " & Sorting & " "
        'End If
        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        If dt Is Nothing Then
            MsgBox("Unable to generate report source.", vbExclamation)
            Exit Sub
        End If
        MainReport.DataSource = dt

        '---------------------------------------------------------------------------------------------------------------------------------------
        'EXIT IF REPORT HAS NO DATA
        If Not ReportHasData(dt, True) Then Exit Sub

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Education Sub 
        cSQL = "SELECT      PKey, FKeyIDNbr AS IDNbr, School, YrStart, YrEnd, YrStart + CASE WHEN len(YrStart) > 0 AND len(YrEnd) > 0 THEN ' to ' END + YrEnd AS YrAttended, Degree " & _
               "FROM        dbo.tblEduc " & _
               "WHERE      FKeyIDNbr IN " & WhereList & " " & _
               "ORDER BY    YrStart, YrEnd "
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Educ.DataSource = dt
        MainReport.subrpt_educ.ReportSource = SubReport_Educ

        'Add a parameter for filtering
        Dim param_educ As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_Educ.Parameters.Add(param_educ)
        SubReport_Educ.FilterString = "[IDNbr]==?IDNbr"

        SubReport_Educ.GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Seaman's Book Sub 
        cSQL = "SELECT      doc.PKey, doc.FKeyIDNbr AS IDNbr, doc.FileTag, doc.FKeyDocument, doc.Number, " & _
               "            doc.DateIssue, doc.DateExpiry, doc.IssuedBy, doc.IssuedPlace, doc.FKeyCntry, " & _
               "            cntry.Name AS Country " & _
               "FROM        dbo.tblDocument doc LEFT OUTER JOIN " & _
               "            dbo.tblAdmCntry cntry ON doc.FKeyCntry = cntry.PKey " & _
               "WHERE       (doc.FKeyDocument = 'SYSTDSB') " & _
               "            AND doc.FKeyIDNbr IN " & WhereList & " " & _
               "ORDER BY    doc.dateissue desc, cntry.name"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Sbk.DataSource = dt
        MainReport.subrpt_sbk.ReportSource = SubReport_Sbk

        'Add a parameter for filtering
        Dim param_sbk As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_Sbk.Parameters.Add(param_sbk)
        SubReport_Sbk.FilterString = "[IDNbr]==?IDNbr"

        SubReport_Sbk.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        SubReport_Sbk.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Certificate Sub 
        cSQL = "SELECT      DocKey, IDNbr, DocName, FKeyDocGroup AS SYSLICCERT, Country, Nbr, DateIssue, DateExpiry " & _
               "FROM        dbo.Rpt_CrewDocument " & _
               "WHERE       IDNbr IN " & WhereList & " " & _
               "ORDER BY    DocName"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Cert.DataSource = dt
        MainReport.subrpt_cert.ReportSource = SubReport_Cert

        'Add a parameter for filtering
        Dim param_cert As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_Cert.Parameters.Add(param_cert)
        SubReport_Cert.FilterString = "[IDNbr]==?IDNbr"

        SubReport_Cert.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        SubReport_Cert.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        SubReport_Cert.GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Course Completed Sub 
        cSQL = "SELECT      * " & _
               "FROM        dbo.Rpt_CrewTraining " & _
               "WHERE       IDNbr IN " & WhereList & " " & _
               "AND         CourseStatus = 3 " & _
               "ORDER BY    CourseName"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_CourseCompl.DataSource = dt
        MainReport.subrpt_coursecompl.ReportSource = SubReport_CourseCompl

        'Add a parameter for filtering
        Dim param_coursecompl As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_CourseCompl.Parameters.Add(param_coursecompl)
        SubReport_CourseCompl.FilterString = "[IDNbr]==?IDNbr"

        SubReport_CourseCompl.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        SubReport_CourseCompl.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        SubReport_CourseCompl.GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Course Required Sub 
        cSQL = "SELECT      * " & _
               "FROM        dbo.Rpt_CrewTraining " & _
               "WHERE       IDNbr IN " & WhereList & " " & _
               "AND         CourseStatus = 2 " & _
               "ORDER BY    CourseName"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_CourseReq.DataSource = dt
        MainReport.subrpt_coursereq.ReportSource = SubReport_CourseReq

        'Add a parameter for filtering
        Dim param_coursereq As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_CourseReq.Parameters.Add(param_coursereq)
        SubReport_CourseReq.FilterString = "[IDNbr]==?IDNbr"

        SubReport_CourseReq.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        SubReport_CourseReq.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        SubReport_CourseCompl.GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Sea Service Sub 
        cSQL = "SELECT     * " & _
               "FROM       dbo.Rpt_CrewActAll " & _
               "WHERE      IDNbr IN " & WhereList & ";"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_SeaServ.DataSource = dt
        MainReport.subrpt_seaserv.ReportSource = SubReport_SeaServ

        'Add a parameter for filtering
        Dim param_ss As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_SeaServ.Parameters.Add(param_ss)
        SubReport_SeaServ.FilterString = "[IDNbr]==?IDNbr"

        SubReport_SeaServ.txtDateStart.DataBindings.Add("Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
        SubReport_SeaServ.txtDateEnd.DataBindings.Add("Text", Nothing, "DateEnd", "{0:dd-MMM-yyyy}")
        '---------------------------------------------------------------------------------------------------------------------------------------

        BindReportControls(MainReport)
        BindReportControls(SubReport_Educ)
        BindReportControls(SubReport_Cert)
        BindReportControls(SubReport_SeaServ)
        BindReportControls(SubReport_Sbk)
        BindReportControls(SubReport_CourseCompl)
        BindReportControls(SubReport_CourseReq)

        MainReport.txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        MainReport.txtDateSOn.DataBindings.Add("Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        MainReport.txtDateSOff.DataBindings.Add("Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        'Passport
        MainReport.Passport_DateIssue.DataBindings.Add("Text", Nothing, "Passport_DateIssue", "{0:dd-MMM-yyyy}")
        MainReport.Passport_DateExpiry.DataBindings.Add("Text", Nothing, "Passport_DateExpiry", "{0:dd-MMM-yyyy}")
        'US Visa
        MainReport.USVisa_DateIssue.DataBindings.Add("Text", Nothing, "USVisa_DateIssue", "{0:dd-MMM-yyyy}")
        MainReport.USVisa_DateExpiry.DataBindings.Add("Text", Nothing, "USVisa_DateExpiry", "{0:dd-MMM-yyyy}")
        'Yellow Fever
        MainReport.YellowFever_DateIssue.DataBindings.Add("Text", Nothing, "YellowFever_DateIssue", "{0:dd-MMM-yyyy}")
        MainReport.YellowFever_DateExpiry.DataBindings.Add("Text", Nothing, "YellowFever_DateExpiry", "{0:dd-MMM-yyyy}")
        'Cholera
        MainReport.Cholera_DateIssue.DataBindings.Add("Text", Nothing, "Cholera_DateIssue", "{0:dd-MMM-yyyy}")
        MainReport.Cholera_DateExpiry.DataBindings.Add("Text", Nothing, "Cholera_DateExpiry", "{0:dd-MMM-yyyy}")
        'STCW Endorsement
        MainReport.STCW_DateIssue.DataBindings.Add("Text", Nothing, "STCW_DateIssue", "{0:dd-MMM-yyyy}")
        MainReport.STCW_DateExpiry.DataBindings.Add("Text", Nothing, "STCW_DateExpiry", "{0:dd-MMM-yyyy}")

        Dim band As DevExpress.XtraReports.UI.Band = MainReport.Detail

        'MainReport.GroupHeader_IDNbr.GroupFields.Add(New GroupField("IDNbr"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, SortDT)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Handle the Subreport.BeforePrint event for filtering details dynamically
        AddHandler SubReport_Cert.BeforePrint, AddressOf SubReport_Cert_BeforePrint
        AddHandler SubReport_Educ.BeforePrint, AddressOf SubReport_Educ_BeforePrint
        AddHandler SubReport_Sbk.BeforePrint, AddressOf SubReport_Sbk_BeforePrint
        AddHandler SubReport_SeaServ.BeforePrint, AddressOf SubReport_SeaServ_BeforePrint
        AddHandler SubReport_CourseCompl.BeforePrint, AddressOf SubReport_CourseCompl_BeforePrint
        AddHandler SubReport_CourseReq.BeforePrint, AddressOf SubReport_CourseReq_BeforePrint
        '---------------------------------------------------------------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Preview Report
        MainReport.ShowPreviewDialog()
    End Sub

    Private Sub SubReport_Cert_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_Educ_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
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

End Class
