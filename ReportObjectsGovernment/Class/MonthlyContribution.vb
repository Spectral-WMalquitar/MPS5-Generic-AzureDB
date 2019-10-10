Public Class MonthlyContribution
    Public MainReport As New rptMonthlyContribution
    Public MainReport_HDMF As New rptMonthlyHDMF

    Private MCode As Integer
    Private MCodeDesc As String

    Dim cChequeNo As String
    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable = Nothing
        
        If REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False) = "" Then
            MsgBox("Please select period.", MsgBoxStyle.OkOnly, GetAppName)
            Exit Sub
        End If

        MCode = REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.EditValue, False)
        MCodeDesc = REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        ShowCustomLoadScreen(GetType(MPS4.Waitform), "Building Data...")
        Select Case REPORT_DETAIL.ReportInfo.ObjectID
            'Case "rptMonthlyContribution_MCR", "rptMonthlyContribution_SSS"
            '    dt = GenerateReportDataSource_MCRSSS(REPORT_DETAIL)

            Case "rptMonthlyContribution_SSS"
                dt = GenerateReportDataSource_SSS(REPORT_DETAIL)

            Case "rptMonthlyContribution_MCR"
                dt = GenerateReportDataSource_MCR(REPORT_DETAIL)

            Case "rptMonthlyContribution_HDMF"
                dt = GenerateReportDataSource_HDMF(REPORT_DETAIL)

        End Select
        CloseCustomLoadScreen()

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim rpt As DevExpress.XtraReports.UI.XtraReport = Nothing
        ArrangeReportData(REPORT_DETAIL, rpt, dt)

        'REPORT_DETAIL.ReportInfo.ReportGroup = "HOME ALLOTMENT PAYROLL" 'dummy to display DRAFT word if payroll not lock

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = rpt

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

#Region "Generate Data Source"
    'Private Function GenerateReportDataSource_MCRSSS(ByRef REPORT_DETAIL As Reports.ReportDetail) As DataTable
    '    Dim ReturnValue As DataTable = Nothing
    '    Dim sqlConn As New SqlClient.SqlConnection

    '    Using sqlConn
    '        sqlConn.ConnectionString = MPSDB.GetConnectionString
    '        Try
    '            sqlConn.Open()
    '        Catch ex As Exception
    '            MsgBox("Failed to build report data source." & vbNewLine & "Error: " & ex.Message, MsgBoxStyle.Critical)
    '            Return Nothing
    '        End Try

    '        If sqlConn.State <> ConnectionState.Open Then
    '            MsgBox("Failed to build report data source.", MsgBoxStyle.Critical)
    '            Return Nothing
    '        Else
    '            Dim sqlComm As New System.Data.SqlClient.SqlCommand
    '            Dim da As New System.Data.SqlClient.SqlDataAdapter

    '            sqlComm.Connection = sqlConn

    '            sqlComm.CommandText = "RPT_GovtContributionSource"
    '            sqlComm.CommandType = CommandType.StoredProcedure
    '            sqlComm.CommandTimeout = 1000

    '            sqlComm.Parameters.AddWithValue("Period", MCode)
    '            sqlComm.Parameters.AddWithValue("PrintSelection", REPORT_DETAIL.PresentRecord.Table)

    '            'Dim retParameter As IDbDataParameter = sqlComm.CreateParameter()
    '            'retParameter.ParameterName = "@ReturnValue"
    '            'retParameter.Direction = System.Data.ParameterDirection.Output
    '            'retParameter.DbType = System.Data.DbType.String
    '            'retParameter.Size = -1
    '            'sqlComm.Parameters.Add(retParameter)

    '            da.SelectCommand = sqlComm

    '            Try
    '                'sqlComm.ExecuteNonQuery()
    '                'returnVal = retParameter.Value
    '                Dim dt As New DataTable
    '                da.Fill(dt)

    '                ReturnValue = dt

    '            Catch SqlEx As System.Data.SqlClient.SqlException
    '                Dim myError As System.Data.SqlClient.SqlError
    '                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
    '                Dim returnErr As String = ""
    '                For Each myError In SqlEx.Errors
    '                    returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
    '                Next

    '                MsgBox("Failed to build report data source." & vbNewLine & "Error: " & returnErr, MsgBoxStyle.Critical)
    '                Return Nothing
    '            End Try

    '        End If
    '        sqlConn.Close()
    '    End Using
    '    Return ReturnValue

    '    Exit Function
    'End Function

    Private Function GenerateReportDataSource_SSS(ByRef REPORT_DETAIL As Reports.ReportDetail) As DataTable
        Dim ReturnValue As DataTable = Nothing
        Dim sqlConn As New SqlClient.SqlConnection

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            Try
                sqlConn.Open()
            Catch ex As Exception
                MsgBox("Failed to build report data source." & vbNewLine & "Error: " & ex.Message, MsgBoxStyle.Critical)
                Return Nothing
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                MsgBox("Failed to build report data source.", MsgBoxStyle.Critical)
                Return Nothing
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim da As New System.Data.SqlClient.SqlDataAdapter

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "RPT_GovtContributionSource_SSS"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.CommandTimeout = 1000

                sqlComm.Parameters.AddWithValue("Period", MCode)
                sqlComm.Parameters.AddWithValue("PrintSelection", REPORT_DETAIL.PresentRecord.Table)
                sqlComm.Parameters.AddWithValue("UserDataFilterString", GetUserFilterString(, "pc.FKeyAgent", "p.FKeyPrincipal", "p.FKeyFlt"))

                'Dim retParameter As IDbDataParameter = sqlComm.CreateParameter()
                'retParameter.ParameterName = "@ReturnValue"
                'retParameter.Direction = System.Data.ParameterDirection.Output
                'retParameter.DbType = System.Data.DbType.String
                'retParameter.Size = -1
                'sqlComm.Parameters.Add(retParameter)

                da.SelectCommand = sqlComm

                Try
                    'sqlComm.ExecuteNonQuery()
                    'returnVal = retParameter.Value
                    Dim dt As New DataTable
                    da.Fill(dt)

                    ReturnValue = dt

                Catch SqlEx As System.Data.SqlClient.SqlException
                    Dim myError As System.Data.SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    Dim returnErr As String = ""
                    For Each myError In SqlEx.Errors
                        returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                    Next

                    MsgBox("Failed to build report data source." & vbNewLine & "Error: " & returnErr, MsgBoxStyle.Critical)
                    Return Nothing
                End Try

            End If
            sqlConn.Close()
        End Using
        Return ReturnValue

        Exit Function
    End Function

    Private Function GenerateReportDataSource_MCR(ByRef REPORT_DETAIL As Reports.ReportDetail) As DataTable
        Dim ReturnValue As DataTable = Nothing
        Dim sqlConn As New SqlClient.SqlConnection

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            Try
                sqlConn.Open()
            Catch ex As Exception
                MsgBox("Failed to build report data source." & vbNewLine & "Error: " & ex.Message, MsgBoxStyle.Critical)
                Return Nothing
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                MsgBox("Failed to build report data source.", MsgBoxStyle.Critical)
                Return Nothing
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim da As New System.Data.SqlClient.SqlDataAdapter

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "RPT_GovtContributionSource_MCR"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.CommandTimeout = 1000

                sqlComm.Parameters.AddWithValue("Period", MCode)
                sqlComm.Parameters.AddWithValue("PrintSelection", REPORT_DETAIL.PresentRecord.Table)
                sqlComm.Parameters.AddWithValue("UserDataFilterString", GetUserFilterString(, "pc.FKeyAgent", "p.FKeyPrincipal", "p.FKeyFlt"))

                'Dim retParameter As IDbDataParameter = sqlComm.CreateParameter()
                'retParameter.ParameterName = "@ReturnValue"
                'retParameter.Direction = System.Data.ParameterDirection.Output
                'retParameter.DbType = System.Data.DbType.String
                'retParameter.Size = -1
                'sqlComm.Parameters.Add(retParameter)

                da.SelectCommand = sqlComm

                Try
                    'sqlComm.ExecuteNonQuery()
                    'returnVal = retParameter.Value
                    Dim dt As New DataTable
                    da.Fill(dt)

                    ReturnValue = dt

                Catch SqlEx As System.Data.SqlClient.SqlException
                    Dim myError As System.Data.SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    Dim returnErr As String = ""
                    For Each myError In SqlEx.Errors
                        returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                    Next

                    MsgBox("Failed to build report data source." & vbNewLine & "Error: " & returnErr, MsgBoxStyle.Critical)
                    Return Nothing
                End Try

            End If
            sqlConn.Close()
        End Using
        Return ReturnValue

        Exit Function
    End Function

    Private Function GenerateReportDataSource_HDMF(ByRef REPORT_DETAIL As Reports.ReportDetail) As DataTable
        Dim ReturnValue As DataTable = Nothing
        Dim sqlConn As New SqlClient.SqlConnection

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            Try
                sqlConn.Open()
            Catch ex As Exception
                MsgBox("Failed to build report data source." & vbNewLine & "Error: " & ex.Message, MsgBoxStyle.Critical)
                Return Nothing
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                MsgBox("Failed to build report data source.", MsgBoxStyle.Critical)
                Return Nothing
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim da As New System.Data.SqlClient.SqlDataAdapter

                sqlComm.Connection = sqlConn
                sqlComm.CommandTimeout = 1000

                'sqlComm.CommandText = "RPT_GenerateMonthlyHDMFSource"
                sqlComm.CommandText = "RPT_GovtContributionSource_HDMF"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("Period", MCode)
                sqlComm.Parameters.AddWithValue("PrintSelection", REPORT_DETAIL.PresentRecord.Table)
                sqlComm.Parameters.AddWithValue("UserDataFilterString", GetUserFilterString(, "pc.FKeyAgent", "p.FKeyPrincipal", "p.FKeyFlt"))


                da.SelectCommand = sqlComm

                Try
                    Dim dt As New DataTable
                    da.Fill(dt)

                    ReturnValue = dt

                Catch SqlEx As System.Data.SqlClient.SqlException
                    Dim myError As System.Data.SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    Dim returnErr As String = ""
                    For Each myError In SqlEx.Errors
                        returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                    Next

                    MsgBox("Failed to build report data source." & vbNewLine & "Error: " & returnErr, MsgBoxStyle.Critical)
                    Return Nothing
                End Try

            End If
            sqlConn.Close()
        End Using
        Return ReturnValue

        Exit Function
    End Function
#End Region

#Region "Arrange Data"
    Private Sub ArrangeReportData(ByRef REPORT_DETAIL As ReportDetail, ByRef rpt As DevExpress.XtraReports.UI.XtraReport, RecordSource As DataTable)
        Select Case REPORT_DETAIL.ReportInfo.ObjectID
            'Case "rptMonthlyContribution_MCR", "rptMonthlyContribution_SSS"
            '    With MainReport
            '        .DataSource = RecordSource
            '        .Name = REPORT_DETAIL.ReportObjectID

            '        'Header
            '        If REPORT_DETAIL.ReportInfo.ObjectID = "rptMonthlyContribution_MCR" Then
            '            .celMainHeader.Text = "MCR " & .celMainHeader.Text
            '            .celNumberHeader.Text = "MCR Number"

            '        ElseIf REPORT_DETAIL.ReportInfo.ObjectID = "rptMonthlyContribution_SSS" Then
            '            .celMainHeader.Text = "SSS " & .celMainHeader.Text
            '            .celNumberHeader.Text = "SSS Number"

            '        End If

            '        .celMonthLabel.Text.Replace("[MMM-yyyy]", Format(NumCodeToDate(MCode, 1), "MMM-yyyy"))
            '        .celMonthLabel.Text = "Month of " & Format(NumCodeToDate(MCode, 1), "MMM-yyyy")

            '        '.celEmployerName.Text = MPSDB.GetConfig("Name")
            '        '.celEmployerAddr.Text = MPSDB.GetConfig("ADDR")
            '        BindData(.celEmployerName, "Text", Nothing, "EmployerName")
            '        BindData(.celEmployerAddr, "Text", Nothing, "EmployerAddr")

            '        'Detail
            '        BindData(.celCrewName, "Text", Nothing, "CrewName")
            '        If REPORT_DETAIL.ReportInfo.ObjectID = "rptMonthlyContribution_MCR" Then
            '            'Number and Contribution
            '            BindData(.celNumber, "Text", Nothing, "MCRNo")
            '            BindData(.celContribution, "Text", Nothing, "MCR_PHP", "{0:#,##0.00}")

            '            'Total
            '            BindData(.celContributionTotal, "Text", Nothing, "MCR_PHP", "{0:#,##0.00}")

            '        ElseIf REPORT_DETAIL.ReportInfo.ObjectID = "rptMonthlyContribution_SSS" Then
            '            'Number and Contribution
            '            BindData(.celNumber, "Text", Nothing, "Number")
            '            BindData(.celContribution, "Text", Nothing, "AmountInPHP", "{0:#,##0.00}")

            '            'Total
            '            BindData(.celContributionTotal, "Text", Nothing, "AmountInPHP", "{0:#,##0.00}")

            '        End If


            '        'Signatory
            '        .celSignatory.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False)
            '        .celSignatoryPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue, False)

            '        AddFieldsToGroupHeaderBand(.GroupHeader_Main, "EmployerName", FieldSortOrder.Ascending)
            '        AddSortFieldsToDetailBandFromDT(.Detail, "CrewName", FieldSortOrder.Ascending)
            '        'AddHandler .GroupHeader_Main.BeforePrint, AddressOf SetDetailBand_MCR_BeforePrint
            '    End With

            '    rpt = MainReport

            Case "rptMonthlyContribution_SSS"
                With MainReport
                    .DataSource = RecordSource
                    .Name = REPORT_DETAIL.ReportObjectID

                    'Header
                    .celMainHeader.Text = "SSS " & .celMainHeader.Text
                    .celNumberHeader.Text = "SSS Number"

                    .celMonthLabel.Text.Replace("[MMM-yyyy]", Format(NumCodeToDate(MCode, 1), "MMM-yyyy"))
                    .celMonthLabel.Text = "Month of " & Format(NumCodeToDate(MCode, 1), "MMM-yyyy")

                    BindData(.celEmployerName, "Text", Nothing, "EmployerName")
                    BindData(.celEmployerAddr, "Text", Nothing, "EmployerAddr")

                    'Detail
                    BindData(.celCrewName, "Text", Nothing, "CrewName")

                    'Number and Contribution
                    BindData(.celNumber, "Text", Nothing, "Number")
                    BindData(.celContribution, "Text", Nothing, "TotalContributionInPHP", "{0:#,##0.00}")

                    'Total
                    BindData(.celContributionTotal, "Text", Nothing, "TotalContributionInPHP", "{0:#,##0.00}")


                    'Signatory
                    .celSignatory.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False)
                    .celSignatoryPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue, False)

                    AddFieldsToGroupHeaderBand(.GroupHeader_Main, "EmployerName", FieldSortOrder.Ascending)
                    AddSortFieldsToDetailBandFromDT(.Detail, "CrewName", FieldSortOrder.Ascending)
                End With

                rpt = MainReport

            Case "rptMonthlyContribution_MCR"
                With MainReport
                    .DataSource = RecordSource
                    .Name = REPORT_DETAIL.ReportObjectID

                    'Header
                    .celMainHeader.Text = "Philhealth " & .celMainHeader.Text
                    .celNumberHeader.Text = "Philhealth Number"

                    .celMonthLabel.Text.Replace("[MMM-yyyy]", Format(NumCodeToDate(MCode, 1), "MMM-yyyy"))
                    .celMonthLabel.Text = "Month of " & Format(NumCodeToDate(MCode, 1), "MMM-yyyy")

                    BindData(.celEmployerName, "Text", Nothing, "EmployerName")
                    BindData(.celEmployerAddr, "Text", Nothing, "EmployerAddr")

                    'Detail
                    BindData(.celCrewName, "Text", Nothing, "CrewName")

                    'Number and Contribution
                    BindData(.celNumber, "Text", Nothing, "Number")
                    BindData(.celContribution, "Text", Nothing, "TotalContributionInPHP", "{0:#,##0.00}")

                    'Total
                    BindData(.celContributionTotal, "Text", Nothing, "TotalContributionInPHP", "{0:#,##0.00}")


                    'Signatory
                    .celSignatory.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False)
                    .celSignatoryPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue, False)

                    AddFieldsToGroupHeaderBand(.GroupHeader_Main, "EmployerName", FieldSortOrder.Ascending)
                    AddSortFieldsToDetailBandFromDT(.Detail, "CrewName", FieldSortOrder.Ascending)
                End With

                rpt = MainReport


            Case "rptMonthlyContribution_HDMF"
                With MainReport_HDMF
                    .DataSource = RecordSource
                    .Name = REPORT_DETAIL.ReportObjectID

                    .celEmployer.Text = MPSDB.GetConfig("Name")
                    .celEmployerAddr.Text = MPSDB.GetConfig("Addr")
                    .celEmployerHDMFID.Text = MPSDB.GetConfig("HDMF")

                    'Detail
                    BindData(.celRecordNumber, "Text", Nothing, "CrewName")
                    BindData(.celCrewName, "Text", Nothing, "CrewName")
                    BindData(.celPagIBIGNo, "Text", Nothing, "HDMFNo")
                    BindData(.celPeriod, "Text", Nothing, "MCode")
                    BindData(.celMonthlyCompensation, "Text", Nothing, "BasicUSD", "{0:#,##0.00}")
                    BindData(.celEEShare, "Text", Nothing, "EEShare", "{0:#,##0.00}")
                    BindData(.celERShare, "Text", Nothing, "ERShare", "{0:#,##0.00}")
                    BindData(.celTotalAmount, "Text", Nothing, "TotalAmount", "{0:#,##0.00}")

                    'Totals
                    BindData(.celTotalEEShare, "Text", Nothing, "EEShare", "{0:#,##0.00}")
                    BindData(.celTotalERShare, "Text", Nothing, "ERShare", "{0:#,##0.00}")
                    BindData(.celTotalOfTotalAmount, "Text", Nothing, "TotalAmount", "{0:#,##0.00}")

                    'Totals
                    BindData(.celGTotalEEShare, "Text", Nothing, "EEShare", "{0:#,##0.00}")
                    BindData(.celGTotalERShare, "Text", Nothing, "ERShare", "{0:#,##0.00}")
                    BindData(.celGTotalOfTotalAmount, "Text", Nothing, "TotalAmount", "{0:#,##0.00}")

                    'Signatory
                    .celSignatory.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False).ToString.ToUpper
                    .celSignatoryPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue, False).ToString.ToUpper

                    'Date
                    .celDate.Text = Format(getServerDateTime(), "dd-MMM-yyyy")

                    'AddFieldsToGroupHeaderBand(.GroupHeader_Main, "EmployerName", FieldSortOrder.Ascending)
                    AddSortFieldsToDetailBandFromDT(.Detail, "CrewName", FieldSortOrder.Ascending)
                    'AddHandler .GroupHeader_Main.BeforePrint, AddressOf SetDetailBand_MCR_BeforePrint

                    AddHandler .celGTotalEEShare.PrintOnPage, AddressOf XRCellPrintOnPage_HideValueUnlessLastPage
                    AddHandler .celGTotalERShare.PrintOnPage, AddressOf XRCellPrintOnPage_HideValueUnlessLastPage
                    AddHandler .celGTotalOfTotalAmount.PrintOnPage, AddressOf XRCellPrintOnPage_HideValueUnlessLastPage
                    AddHandler .celGTotalEEShare_PesoLabel.PrintOnPage, AddressOf XRCellPrintOnPage_HideValueUnlessLastPage
                    AddHandler .celGTotalERShare_PesoLabel.PrintOnPage, AddressOf XRCellPrintOnPage_HideValueUnlessLastPage
                    AddHandler .celGTotalOfTotalAmount_PesoLabel.PrintOnPage, AddressOf XRCellPrintOnPage_HideValueUnlessLastPage

                End With

                rpt = MainReport_HDMF
        End Select

    End Sub
#End Region
    
    'Private Sub SetDetailBand_MCR_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
    '    Try
    '        MainReport.lblBody.Text = "Enclosed is BPI cheque no. " & cChequeNo & " in the amount " & _
    '        "of " & AmountInWords(MainReport.GetCurrentColumnValue("TotalAmtPHP")) & " (Php" & Format(MainReport.GetCurrentColumnValue("TotalAmtPHP"), "#,##0.00") & ") Pesos only representing home allotment " & _
    '        "of our crew.  Kindly credit our allottees' account with their respective amounts as per attached allotment lists." & vbCrLf & vbCrLf & _
    '        "Below, please find the summary of our remittance:"
    '    Catch ex As Exception
    '        MainReport.lblBody.Text = "Error printing body of the letter => " & ex.Message
    '    End Try

    'End Sub


    Private Sub XRCellPrintOnPage_HideValueUnlessLastPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs)
        If e.PageCount > 0 Then
            Dim cel As DevExpress.XtraReports.UI.XRTableCell = TryCast(sender, DevExpress.XtraReports.UI.XRTableCell)
            If e.PageIndex = e.PageCount - 1 Then
                'cel.Text = "Last Page"
            Else
                cel.Text = ""
            End If
        End If
    End Sub
End Class

