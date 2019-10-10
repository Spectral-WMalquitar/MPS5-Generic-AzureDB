Imports Utilities
Imports MPS4
Imports DevExpress.XtraReports.Parameters

Public Class BiodataComplete_L

    Private MainReport As New rptBiodataComplete_L

    Public Enum SeaServiceDisplay
        Continuous = 1
        Grouped = 2
    End Enum

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        'modified by tony20180129
        'cSQL = "SELECT * FROM Rpt_BioInfo" & sArc & " "
        'modified by tony20180804
        'cSQL = "SELECT firstemp.DateFirstEmployed , bio.* FROM dbo.Rpt_BioInfo" & sArc & " bio LEFT JOIN (SELECT IDNbr as CrewID, DateStart DateFirstEmployed FROM dbo.rpt_CrewActFirstVoyage WHERE IDNbr IN " & WhereList & ") firstemp ON bio.IDNbr = firstemp.CrewID "
        cSQL = "SELECT firstemp.DateFirstEmployed , bio.* FROM dbo.Rpt_BioInfo" & sArc & " bio LEFT JOIN (SELECT IDNbr as CrewID, DateStart DateFirstEmployed FROM dbo.rpt_CrewActFirstVoyage WHERE IDNbr IN " & WhereList & ") firstemp ON bio.IDNbr " & IIf(IfNull(sArc, "").Length > 0, "COLLATE DATABASE_DEFAULT ", "") & " = firstemp.CrewID "
        'end tony
        'end tony

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

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

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        'CREW INFO
        BindData(MainReport.celCoID, "Text", Nothing, "COIDNo")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celAge, "Text", Nothing, "Age")
        BindData(MainReport.celPOB, "Text", Nothing, "POB")
        BindData(MainReport.celHeight, "Text", Nothing, "Height")
        BindData(MainReport.celWeight, "Text", Nothing, "Weight")
        BindData(MainReport.celMaritalStat, "Text", Nothing, "MaritalStatus")
        BindData(MainReport.celReligion, "Text", Nothing, "Religion")
        BindData(MainReport.celRankName, "Text", Nothing, "Rank")
        BindData(MainReport.celEmployDate, "Text", Nothing, "DateFirstEmployed", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celNatName, "Text", Nothing, "Nationality")
        BindData(MainReport.celServStat, "Text", Nothing, "StatName")
        BindData(MainReport.celCurrentVsl, "Text", Nothing, "VslName")
        BindData(MainReport.celSignOn, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")

        'ADDRESS
        BindData(MainReport.celAddr, "Text", Nothing, "Address")
        BindData(MainReport.celAddrPhone, "Text", Nothing, "Phone")
        BindData(MainReport.celAddrEmail, "Text", Nothing, "Email")
        BindData(MainReport.celAddrStat, "Text", Nothing, "AddrStatName")
        BindData(MainReport.celAddrAirport, "Text", Nothing, "Airport")

        'TRAVEL DOCUMENTS
        BindData(MainReport.celTravDoc, "Text", Nothing, "DocName")
        BindData(MainReport.celTravDocNum, "Text", Nothing, "Nbr")
        BindData(MainReport.celTravDocIssue, "Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celTravDocExpiry, "Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celTravDocCntry, "Text", Nothing, "Country")
        BindData(MainReport.celTravDocBy, "Text", Nothing, "IssuedBy")

        'CERTIFICATES
        BindData(MainReport.celCertType, "Text", Nothing, "DocName")
        BindData(MainReport.celCertCap, "Text", Nothing, "Capacity")
        BindData(MainReport.celCertReg, "Text", Nothing, "Regulation")
        BindData(MainReport.celCertLimit, "Text", Nothing, "Limit")
        BindData(MainReport.celCertCntry, "Text", Nothing, "Country")
        BindData(MainReport.celCertNum, "Text", Nothing, "Nbr")
        BindData(MainReport.celCertIssue, "Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celCertExpiry, "Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        'MEDICAL CERTIFICATES
        BindData(MainReport.celMedCert, "Text", Nothing, "DocName")
        BindData(MainReport.celMedCertNum, "Text", Nothing, "Nbr")
        BindData(MainReport.celMedCertBy, "Text", Nothing, "IssuedBy")
        BindData(MainReport.celMedCertIssue, "Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celMedCertExpiry, "Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        'TRAININGS
        BindData(MainReport.celTraining, "Text", Nothing, "CourseName")
        BindData(MainReport.celTrainingInst, "Text", Nothing, "CourseInstName")
        BindData(MainReport.celTrainingStat, "Text", Nothing, "CourseStatusValue")
        BindData(MainReport.celTrainingStart, "Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celTrainingEnd, "Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        'EDUCATIONAL BACKGROUND
        BindData(MainReport.celEducFrom, "Text", Nothing, "YrStart")
        BindData(MainReport.celEducTo, "Text", Nothing, "YrEnd")
        BindData(MainReport.celEducInst, "Text", Nothing, "School")
        BindData(MainReport.celEducDegree, "Text", Nothing, "Degree")

        'SEA SERVICE
        BindData(MainReport.celSeaServVsl, "Text", Nothing, "VslName")
        BindData(MainReport.celSeaServPos, "Text", Nothing, "RankAbbrv")
        '<!-- edited by tony20181009
        'BindData(MainReport.celSeaServOn, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        'BindData(MainReport.celSeaServOff, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celSeaServOn, "Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celSeaServOff, "Text", Nothing, "DateEnd", "{0:dd-MMM-yyyy}")
        '-->
        BindData(MainReport.celSeaServMos, "Text", Nothing, "Mos")
        BindData(MainReport.celSeaServVslT, "Text", Nothing, "VslTypeName")
        BindData(MainReport.celSeaServDWT, "Text", Nothing, "DeadWt")
        BindData(MainReport.celSeaServGRT, "Text", Nothing, "GrossTon")
        BindData(MainReport.celSeaServEngT, "Text", Nothing, "EngType")
        BindData(MainReport.celSeaServBHP, "Text", Nothing, "EngPower")
        BindData(MainReport.celSeaServPrin, "Text", Nothing, "PrinName")
        BindData(MainReport.celSeaServStat, "Text", Nothing, "ActStatusName")


        MainReport.Detail_Addr.SortFields.Add(New GroupField("AddrStat", XRColumnSortOrder.Ascending))
        MainReport.Detail_TravDoc.SortFields.Add(New GroupField("DateIssue", XRColumnSortOrder.Descending))
        MainReport.Detail_LicCert.SortFields.Add(New GroupField("DateIssue", XRColumnSortOrder.Descending))
        MainReport.Detail_MedCert.SortFields.Add(New GroupField("DateIssue", XRColumnSortOrder.Descending))
        MainReport.Detail_Training.SortFields.Add(New GroupField("DateIssue", XRColumnSortOrder.Descending))
        MainReport.Detail_Educ.SortFields.Add(New GroupField("DateIssue", XRColumnSortOrder.Descending))
        MainReport.Detail_SeaServ.SortFields.Add(New GroupField("DateStart", XRColumnSortOrder.Descending))


        Dim _SeaServiceDisplay As SeaServiceDisplay = SeaServiceDisplay.Grouped
        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Sea Service Display"), "").Equals("Continuous") Then
            _SeaServiceDisplay = SeaServiceDisplay.Continuous
        ElseIf IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Sea Service Display"), "").Equals("Grouped") Then
            _SeaServiceDisplay = SeaServiceDisplay.Grouped
        End If

        If _SeaServiceDisplay = SeaServiceDisplay.Grouped Then
            BindData(MainReport.lblServType, "Text", Nothing, "ServType")
            AddFieldsToGroupHeaderBand(MainReport.GroupHeader_SeaServ, "IsCompServ", FieldSortOrder.Descending)
        ElseIf _SeaServiceDisplay = SeaServiceDisplay.Continuous Then
            MainReport.lblServType.Text = "Sea Service"
        End If

        LoadDetailReport(MainReport.DetailReport_Addr, "SELECT * FROM Rpt_BioInfo_Addr" & sArc & " a INNER JOIN Rpt_BioInfo" & sArc & " b ON  b.IDNbr = a.IDNbr WHERE b.IDNbr IN " & WhereList)
        LoadDetailReport(MainReport.DetailReport_TravDoc, "SELECT * FROM Rpt_CrewDocument" & sArc & " a INNER JOIN Rpt_BioInfo" & sArc & " b ON  b.IDNbr = a.IDNbr WHERE FKeyDocGroup = 'SYSTRAVELDOC' AND  b.IDNbr IN " & WhereList)
        LoadDetailReport(MainReport.DetailReport_LicCert, "SELECT * FROM Rpt_CrewDocument" & sArc & " a INNER JOIN Rpt_BioInfo" & sArc & " b ON  b.IDNbr = a.IDNbr WHERE FKeyDocGroup = 'SYSLICCERT' AND  b.IDNbr IN " & WhereList)
        LoadDetailReport(MainReport.DetailReport_MedCert, "SELECT * FROM Rpt_CrewDocument" & sArc & " a INNER JOIN Rpt_BioInfo" & sArc & " b ON  b.IDNbr = a.IDNbr WHERE FKeyDocGroup = 'SYSMEDCERT' AND  b.IDNbr IN " & WhereList)
        LoadDetailReport(MainReport.DetailReport_Training, "SELECT * FROM Rpt_CrewTraining" & sArc & " a INNER JOIN Rpt_BioInfo" & sArc & " b ON  b.IDNbr = a.IDNbr WHERE b.IDNbr IN " & WhereList)
        LoadDetailReport(MainReport.DetailReport_Educ, "SELECT * FROM Rpt_CrewEduc" & sArc & " a INNER JOIN Rpt_BioInfo" & sArc & " b ON  b.IDNbr = a.IDNbr WHERE b.IDNbr IN " & WhereList)
        '<!-- edited by tony20181010
        'LoadDetailReport(MainReport.DetailReport_SeaServ, "SELECT     crewserv.*, rnk.abbrv RankAbbrv, (CASE WHEN IsCompServ <> 0 THEN 'Company Sea Service' ELSE 'Other Sea Service' END) AS ServType, " & _
        '                                                   "CAST(PARSENAME(dbo.formatRangeToWord(DateSOn,DateSOff,'nM.nD'),2) AS int) + ROUND(CAST(PARSENAME(dbo.formatRangeToWord(DateSOn,DateSOff,'nM.nD'),1) AS float)/30,2,1) AS Mos " & _
        '                                                   "FROM       (SELECT * FROM dbo.Rpt_CrewActAll UNION SELECT * FROM dbo.Rpt_CrewActAll_Other) crewServ " & _
        '                                                   "           LEFT JOIN dbo.tbladmrank rnk ON crewserv.fkeyrankcode = rnk.pkey " & _
        '                                                   "WHERE      (acttype = 'SEA' OR acttype = 'OTH') AND IDNbr IN " & WhereList)
        LoadDetailReport(MainReport.DetailReport_SeaServ, "SELECT     crewserv.*, rnk.abbrv RankAbbrv, (CASE WHEN IsCompServ <> 0 THEN 'Company Sea Service' ELSE 'Other Sea Service' END) AS ServType, " & _
                                                           "CAST(PARSENAME(dbo.formatRangeToWord(DateStart,DateEnd,'nM.nD'),2) AS int) + ROUND(CAST(PARSENAME(dbo.formatRangeToWord(DateStart,DateEnd,'nM.nD'),1) AS float)/30,2,1) AS Mos " & _
                                                           "FROM       (SELECT * FROM dbo.Rpt_CrewActAll UNION SELECT * FROM dbo.Rpt_CrewActAll_Other) crewServ " & _
                                                           "           LEFT JOIN dbo.tbladmrank rnk ON crewserv.fkeyrankcode = rnk.pkey " & _
                                                           "WHERE      (acttype = 'SEA' OR acttype = 'OTH') AND IDNbr IN " & WhereList)
        '-->


        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        AddHandler MainReport.Detail.BeforePrint, AddressOf Detail_BeforePrint
        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub LoadDetailReport(sender As System.Object, sql As String)
        Dim detailReport As DetailReportBand
        Dim dt_sub As DataTable
        dt_sub = MPSDB.CreateTable(sql)
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        detailReport.DataSource = dt_sub
        AddHandler detailReport.BeforePrint, AddressOf SetDetailReport_BeforePrint
    End Sub

    Private Sub SetDetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim drb As New DevExpress.XtraReports.UI.DetailReportBand
        drb = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)

        Try
            drb.FilterString = "IDNbr='" & MainReport.GetCurrentColumnValue("IDNbr").ToString & "'"
        Catch ex As Exception
            drb.FilterString = "IDNbr=''"
        End Try

    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        GetCrewPhoto(MainReport.picCrewPhoto, MainReport.GetCurrentColumnValue("IDNbr"))
    End Sub

    Private Sub GetCrewPhoto(_PictureEdit As DevExpress.XtraReports.UI.XRPictureBox, _CrewIDNbr As String)
        Try
            'CrewPhoto.Image = New System.Drawing.Bitmap(Trim(IfNull(Items("PhotoPath"), "")))
            Dim _path = GetCrewPhotoPath(_CrewIDNbr)
            _PictureEdit.Image = ImageFromStream(_path)
            'MainReport.lblPhoto.Visible = False
        Catch ex As Exception
            _PictureEdit.Image = Nothing
            'MainReport.lblPhoto.Visible = True
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
